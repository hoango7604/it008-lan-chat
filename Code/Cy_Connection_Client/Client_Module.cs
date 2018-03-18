using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Cy_Connection_Client
{
    public class Client_module : DataQueue
    {
        public delegate void MessingDelegate(object obj, int RoomId);
        public event MessingDelegate ReciveTextEvent;
        public event MessingDelegate ReciveImageEvent;
        protected IPEndPoint Ip;
        protected Socket Client;



        public void Connect()
        {

            // Còn thiếu 2 công đoạn là size định size data cho mỗi lần gửi và xác định IP phú hợp ,nên tạm thời set tĩnh
            sizeofdata = 30000;
            Ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                Client.Connect(Ip);
            }
            catch (Exception e)
            {
                Console.Write("Error in cpnnect " + e);
            }
            Thread RecieveThread = new Thread(Receiver);
            RecieveThread.IsBackground = true;
            RecieveThread.Start();

        }

        public void Disconnect()
        {
            Client.Close();
        }

        public void Send(object obj, DataType type, byte RoomId)
        {
            PhanManh divide = new PhanManh(sizeofdata, (byte)new Random().Next(1, 254), Client, type, RoomId);
            if (type == DataType.Text)
            {
                divide.Divide(DataConverter.Serialize_Text(obj));
            }
            if (type == DataType.Image)
            {
                divide.Divide(DataConverter.Serialize_Image(obj));
            }
            //trong divide đã bao gồm tác vụ sent
        }



        private void Receiver()
        {
            try
            {
                while (true)
                {
                    byte[] tempdata = new byte[sizeofdata + 2];
                    Client.Receive(tempdata);
                    Extract_n_Pull(tempdata);

                }
            }
            catch (Exception e)
            {
                Console.Write("Client reciver err " + e);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void We_Have_Data_here(byte[] data, DataType type, int RoomId)
        {
            if (type == DataType.Text)
            {
                object mess = DataConverter.Deserialize_Text(data);
                if (ReciveTextEvent != null)
                {
                    ReciveTextEvent(mess, RoomId);
                }
            }
            if (type == DataType.Image)
            {
                object img = DataConverter.DeSerialize_Image(data);
                if (ReciveImageEvent != null)
                {
                    ReciveImageEvent(img, RoomId);
                }

            }

        }

    }

}
