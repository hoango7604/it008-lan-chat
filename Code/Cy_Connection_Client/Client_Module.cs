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
        public delegate void MessingDelegate(object obj);
        public event MessingDelegate ReciveTextEvent;
        protected IPEndPoint Ip;
        protected Socket Client;



        public void Connect()
        {

            // Còn thiếu 2 công đoạn là size định size data cho mỗi lần gửi và xác định IP phú hợp ,nên tạm thời set tĩnh
            sizeofdata = 5000;
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

        public void Send(object obj)
        {
            PhanManh divide = new PhanManh(sizeofdata, (byte)new Random().Next(1, 254), Client);
            divide.Divide(Serialize(obj));
            //trong divide đã bao gồm tác vụ sent
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        private byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        private object DeSerialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);

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
        protected override void We_Have_Data_here(byte[] data)
        {
            //mặc định là text trc
            String mess = (string)DeSerialize(data);
            if (ReciveTextEvent != null)
            {
                ReciveTextEvent(mess);
            }
        }





    }

}
