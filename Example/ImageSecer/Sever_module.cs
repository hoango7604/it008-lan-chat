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
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageSecer

{
    struct Client
    {
       public Socket socket;
       public string username;
    }

    class Room
    {
        public byte Id;
        public List<Client> Members;
        public Room() { Members = new List<Client>(); }
    }

    public class Sever_module : DataQueue
    {
        public delegate void MessingDelegate(object obj,int RoomId);
        public event MessingDelegate ReciveTextEvent;
        public event MessingDelegate ReciveImageEvent;
        private IPEndPoint Ip;
        private Socket Sever;
        private List<Socket> tempclient;
        private List<Client> ListClients;
        private List<Room> ListRoom;
        /// //////////////////////////////////////////////////////////////////////////////

        #region kết nối
        public void Connect()
        {
            sizeofdata = 20000;
            ListClients = new List<Client>();
            tempclient = new List<Socket>();
            ListRoom = new List<Room>();

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
                        tempclient.Add(client);
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

        #endregion

        #region Gửi

        public void Send(object obj, DataType type,byte roomid)
        {
            Room room = new Room();
            foreach (Room _room in ListRoom)
            {
                if (_room.Id == roomid)
                {
                    room = _room;
                    break;
                }
            }

            foreach (Client member in room.Members)
            {
                Send_1_Client(obj, type, member.socket, room.Id);
            }
        }

        public void SendAll(object obj, DataType type)
        {
            foreach (Client _client in ListClients)
            {
                byte id = (byte)new Random().Next(1, 244);

                Send_1_Client(obj, type, _client.socket, 0);

            }
        }

        /// <summary>
        /// chỉ gửi qua client
        /// </summary>
        public void Send_1_Client(object obj, DataType type, Socket socket,byte roomid)
        {
            PhanManh Divide = new PhanManh(sizeofdata, (byte)new Random().Next(1, 244), socket, type, roomid);
            if (type == DataType.Image)
            {
                Divide.DivideAndSend(DataConverter.Serialize_Image(obj));
            }
            if (type == DataType.Text || type == DataType.Login || type == DataType.ListClient || type == DataType.CreatRoom || type == DataType.SenderUsername)
            {
                Divide.DivideAndSend(DataConverter.Serialize_Text(obj));
            }

        }
     
        
        public void Ping()
        {
            string usernameStr = "";
            foreach (Client client in ListClients)
            {
                usernameStr = usernameStr+ " " + client.username;
            }

            SendAll(usernameStr, DataType.ListClient);
            
        }
        #endregion

        #region Nhận
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
                    Extract_n_Pull(client, data);
                }
            }
            catch (Exception e)
            {
                foreach (Client _client in ListClients)
                {
                    if (_client.socket == client)
                    {
                        ListClients.Remove(_client);
                        break;
                    }
                }
                client.Close();
            }
        }

        public void SendMesstoRoomm(Socket sender,object mess, DataType type, int Roomid)
        {
            Room room = new Room();
            //xác định phònh cần gửi
            foreach (Room r in ListRoom)
            {
                if (r.Id == Roomid)
                {
                    room = r;
                    break;
                }
            }

            //xác định thằng lờ client nào vừ gửi
            string sendername= "";
            foreach (Client cli in room.Members)
            {
                if (cli.socket == sender)
                {
                    sendername = cli.username;
                    break;
                }
            }

            foreach (Client client in room.Members)
            {
                Send_1_Client(sendername, DataType.SenderUsername, client.socket, 0);
            }
            foreach (Client client in room.Members)
            {
                Send_1_Client(mess, type, client.socket, 0);
            }
        }

        protected override void We_Have_Data_here(Socket sender, byte[] data, DataType type, int RoomId)
        {
            if (type == DataType.Text)
            {
                String mess = (string)DataConverter.Deserialize_Text(data);
                if (ReciveTextEvent != null)
                {
                    ReciveTextEvent(mess, RoomId);
                    SendMesstoRoomm(sender, mess, type, RoomId);
                }
            }
            if (type == DataType.Image)
            {
                Image img = (Image)DataConverter.DeSerialize_Image(data);
                if (ReciveImageEvent != null)
                {
                    ReciveImageEvent(img, RoomId);
                    SendMesstoRoomm(sender, img, type, RoomId);
                }
            }
            ///chỉnh sửa lại là string
            if (type == DataType.Login)
            {
                string username_pass = (string)DataConverter.Deserialize_Text(data);
                string[] space = new string[] { " " };
                string[] info = username_pass.Split(space, StringSplitOptions.RemoveEmptyEntries);
                string username = info[0];
                string pass = info[1];
                // Coi như là auto login

                tempclient.Remove(sender);

                Client client;
                client.socket = sender;
                client.username = username;
                ListClients.Add(client);
                Send_1_Client(username, DataType.Login, sender, 0);

            }
            if (type == DataType.CreatRoom)
            {
                byte id =(byte)( ListRoom.Count + 1);
                Room room = new Room();
                room.Id = id;

                string username = (string)DataConverter.Deserialize_Text(data);
                string[] split = new string[] { " " };
                string[] info = username.Split(split, StringSplitOptions.RemoveEmptyEntries);
                string menbers = " ";
                foreach (string name in info)
                {
                    foreach (Client client in ListClients)
                    {
                        if (name == client.username)
                        {
                            room.Members.Add(client);
                            break;
                        }
                    }
                    menbers += name + " ";
                }

                ListRoom.Add(room);
                Send(menbers, DataType.CreatRoom, room.Id);

            }

        }

        #endregion




    }

}
