﻿using System;
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
        public delegate void MessingDelegate(string sender, object obj, int RoomId);
        public delegate void LoginDelegate(string username);
        public delegate void ListClientDelegate(string[] listClients);
        public delegate void CreatRoomDelegate(int id, string[] listMember);
        /// <summary>
        /// Sự kiện xảy ra khi nhận tin nhắn là text
        /// </summary>
        public event MessingDelegate ReciveTextEvent;
        /// <summary>
        /// Sự kiện xảy ra khi nhận tin nhắn hình
        /// </summary>
        public event MessingDelegate ReciveImageEvent;
        /// <summary>
        /// Sự kiện xảy ra khi client Login và Sever gửi về kết quả nếu login thành công ( dùng để xác định Login dc hay o )
        /// </summary>
        public event LoginDelegate ReciveLoginEvent;
        /// <summary>
        /// Sự kiện xảy ra khi sever đưa cho client 1 list danh sách các user đang online
        /// </summary>
        public event ListClientDelegate ReceiveListClientEvent;
        /// <summary>
        /// Sự kiện xả ra khi client nhận dc yêu cầu vào 1 phòng chat
        /// </summary>
        public event CreatRoomDelegate ReceiveCreatRoomEvent;
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
            if (type == DataType.Image)
            {
                divide.DivideAndSend(DataConverter.Serialize_Image(obj));
            }
            if (type == DataType.Text || type == DataType.Login || type == DataType.CreatRoom)
            {
                divide.DivideAndSend(DataConverter.Serialize_Text(obj));
            }
        }


        /// <summary>
        /// chờ nhận tin nhắn
        /// </summary>
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

        //tên thằng vừa gửi tin nhắn
        protected string SenderName = "";

        protected override void We_Have_Data_here(Socket sender, byte[] data, DataType type, int RoomId)
        {
            //if từng loại Dtatatype 
            if (type == DataType.Text)
            {
                object mess = DataConverter.Deserialize_Text(data);
                if (ReciveTextEvent != null)
                {
                    ReciveTextEvent(SenderName, mess, RoomId);
                }
            }
            if (type == DataType.Image)
            {
                object img = DataConverter.DeSerialize_Image(data);
                if (ReciveImageEvent != null)
                {
                    ReciveImageEvent(SenderName, img, RoomId);
                }
            }
            if (type == DataType.Login)
            {
                object LogInresult = DataConverter.Deserialize_Text(data);
                if (ReciveLoginEvent != null)
                {
                    ReciveLoginEvent((string)LogInresult);
                }
            }

            if (type == DataType.ListClient)
            {
                object ClientsResult = DataConverter.Deserialize_Text(data);
                string result = (string)ClientsResult;
                string[] split = new string[] { " " };
                String[] finalresult = result.Split(split, StringSplitOptions.RemoveEmptyEntries);
                ReceiveListClientEvent(finalresult);
            }
            if (type == DataType.CreatRoom)
            {
                object members = DataConverter.Deserialize_Text(data);
                string result = (string)members;
                string[] split = new string[] { " " };
                String[] finalresult = result.Split(split, StringSplitOptions.RemoveEmptyEntries);
                ReceiveCreatRoomEvent(RoomId, finalresult);
            }

            if (type == DataType.SenderUsername)
            {
                SenderName = (string)DataConverter.Deserialize_Text(data);
            }

        }

    }

}