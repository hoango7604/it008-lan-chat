using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;


namespace Cy_Connection_Client

{
    public class DataQueue
    {
        //À nhìn tên class là Queue thui chứ nó o có tính chất của queue đâu

        class Data
        {
            public int ThreatIndex;
            public byte[] Info;
            public int stats;

            public Data() { }
            public Data(int stast, int thread, byte[] data)
            {
                this.stats = stats;
                this.ThreatIndex = thread;
                this.Info = data;
            }
            /*
             Stats (ý là status nhưng stast dễ đọc hơn ) : Gồm 3 trạng thái chính 
             threadindex : Nhằm phân biệt các tác vụ kháu nhau ( vai trò giống như số Port trong mạng )
             2: bắt đầu gửi, lúc này sẽ gửi Info là dung lượng file
                 lúc này 4 byte tiếp theo sẽ lưu trọng lượng vs 01 52 11 13 -> 01521113 byte ~ 1.45 mb
             1: đang gửi và còn nữa
             0: đợt cuối và o gửi nữa

             Tuy nhiên khi ở list lưu trữ thì stats mang ý nghĩa là vị trí tiếp theo gép mảng vào

             thứ tự là 
             | stats | threatIndex | info <- main |
                1byte    1bute           size

              */
        }

        List<Data> queue = new List<Data>();
        // List<Data> compiling_data = new List<Data>();

        protected int sizeofdata;// số byte dữ liệu ở mỗi lần gửi
        object Synclock = new object(); // dòng để khóa chi tiết xem ở threadpooling

        public DataQueue()
        {

        }

        public DataQueue(int size)
        {
            sizeofdata = size;
        }

        public void Extract_n_Pull(byte[] data)
        {
            Data _data = new Data();
            _data.stats = data[0];
            _data.ThreatIndex = data[1];
            if (_data.stats == 2)
            {   //Chỉnh sửa cái này nếu có update tăng số lượng cilent 
                //tiến hành khởi tạo 1 vị trí trong queue 
                int _size = data[2] * 1000000 + data[3] * 10000 + data[4] * 100 + data[5] + 1;
                _data.Info = new byte[_size];
                _data.stats = 0;
                queue.Add(_data);

            }
            else
            if (_data.stats == 1)
            {
                //ThreadPool.QueueUserWorkItem(pull, data);
                pull(data);
                // xem ThreadPool trong thread để biết thêm chi tiết
            }
            else
            if (_data.stats == 0)
            {
                //   ThreadPool.QueueUserWorkItem(gather, data);
                gather(data);
            }
        }

        //Hàm gom dữ liệu
        private void pull(object data)
        {

            byte[] _data = data as byte[];
            int _threadid = _data[1];
            foreach (Data dataitem in queue)// tìm từng tiến trình đang lưu
            {
                if (dataitem.ThreatIndex == _threadid)
                {
                    lock (Synclock)
                    {
                        int count = 0;
                        while (count < sizeofdata) // gắn zô thui
                        {
                            dataitem.Info[dataitem.stats] = _data[2 + count];
                            count++;
                            dataitem.stats++;
                        }
                    }

                }
            }
        }

        //Hàm gom dữ liệu lần cuối cùng do dữ liệu có thể o toàn vẹn ( có dung lượng < size )
        // Cơ bản nó thì o khác mấy so vs pull nhưng tương lai mình sẽ thêm 1 cố thông số ở cuối byte dữ liệu ( như địa chỉ ip cần gửi , loại file .. ) nên về sau sửa tiện hơn
        private void gather(object data)
        {
            byte[] _data = data as byte[];
            int _threadid = _data[1];
            foreach (Data dataitem in queue)
            {
                if (dataitem.ThreatIndex == _threadid)
                {
                    int sizeoflastdata = dataitem.Info.Length % sizeofdata;
                    lock (Synclock)
                    {
                        int count = 0;
                        while (count < sizeoflastdata)
                        {
                            dataitem.Info[dataitem.stats] = _data[2 + count];
                            count++;
                            dataitem.stats++;
                        }
                    }
                    /*   for (int i = 0; i < dataitem.Info.Length; i++)
                       {
                           Console.Write(dataitem.Info[i] + " ");
                       }*/

                    We_Have_Data_here(dataitem.Info);
                    queue.Remove(dataitem);
                    break;
                }

            }

        }

        protected virtual void We_Have_Data_here(byte[] data) { }
        //t biết tên hàm o đúng quy tắc :v

    }


    class PhanManh
    {
        int sizeofdata;
        int numerofrow = 0;
        byte Index;
        Socket socket;
        public PhanManh(int size, byte Index, Socket socket)
        {
            sizeofdata = size;
            this.socket = socket;
            this.Index = Index;
        }

        public void Divide(byte[] data)
        {
            int datalength = data.Length - 1;
            int remain = datalength;
            byte[] temp = new byte[6];
            temp[2] = (byte)(datalength / 1000000);
            temp[3] = (byte)((datalength - temp[2] * 1000000) / 10000);
            temp[4] = (byte)((datalength - temp[2] * 1000000 - temp[3] * 10000) / 100);
            temp[5] = (byte)(datalength - temp[2] * 1000000 - temp[3] * 10000 - temp[4] * 100);
            //chia dung lượng dữ liệu ra để lưu vào mảng byte ,vd 9875 => 00 00 98 75
            send(2, Index, temp);
            while (remain > sizeofdata)
            {
                temp = new byte[sizeofdata + 2];
                for (int i = 0; i < sizeofdata; i++)
                {
                    temp[i + 2] = data[datalength - remain];
                    remain--;
                }
                send(1, Index, temp);
            }

            temp = new byte[remain + 2 + 1]; // cộng 1 vào là lúc này remain đã bị trừ khi ở đoạn gửi trên ( cắt xong là tr72 ) nên h cộng ngc lại
            int j = 0;
            while (remain >= 0)
            {
                temp[j + 2] = data[datalength - remain];
                j++;
                remain--;
            }
            send(0, Index, temp);
        }

        private void send(byte stats, byte ThreadingId, byte[] data)
        {
            data[0] = stats;
            data[1] = ThreadingId;
            socket.Send(data);
        }


    }


}
