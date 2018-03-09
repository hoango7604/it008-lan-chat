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

namespace Cy_Connection_Sever
{

    public class Sever_module : DataQueue
    {
        public delegate void MessingDelegate(object obj);
        public event MessingDelegate ReciveTextEvent;
        private IPEndPoint Ip;
        private Socket Sever;
        private List<Socket> ListClient;

        /// //////////////////////////////////////////////////////////////////////////////

        public void Connect()
        {
            sizeofdata = 5000;
            ListClient = new List<Socket>();
            Ip = new IPEndPoint(IPAddress.Any, 9999);
            Sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Sever.Bind(Ip);
            Thread Listen_new_cline = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        Sever.Listen(100);
                        Socket client = Sever.Accept();
                        ListClient.Add(client);

                        Thread Receive = new Thread(Receiver);
                        Receive.IsBackground = true;
                        Receive.Start(client);

                    }

                }
                catch (Exception e)
                {
                    Console.Write("Reset sever network");
                    Ip = new IPEndPoint(IPAddress.Any, 9999);
                    Sever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });

            Listen_new_cline.IsBackground = true;
            Listen_new_cline.Start();
        }

        public void Disconnect()
        {
            Sever.Close();
        }

        public void Sent(object obj)
        {
            foreach (Socket _client in ListClient)
            {
                PhanManh divide = new PhanManh(sizeofdata, (byte)new Random().Next(1, 244), _client);
                divide.Divide(Serialize(obj));
            }
        }

        /// /////////////////////////////////////////////////////////////////////////////


        private void Receiver(object mclient)
        {
            Console.Write("client connected");
            Socket client = mclient as Socket;
            try
            {
                byte[] data;
                while (true)
                {
                    data = new byte[sizeofdata + 2];
                    client.Receive(data);
                    Extract_n_Pull(data);
                }
            }
            catch (Exception e)
            {
                ListClient.Remove(client);
                client.Close();
            }
        }

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

        /////////////////////////////////////////////////////////////////////////////////

        protected override void We_Have_Data_here(byte[] data)
        {
            String mess = (string)DeSerialize(data);
            if (ReciveTextEvent != null)
            {
                ReciveTextEvent(mess);
            }
        }

     
    }

}

