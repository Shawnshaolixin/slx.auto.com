﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LabelReceiveService.StartReceive();
            Console.ReadKey();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            return WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>();
        }

    }

    /// <summary>
    /// 接受
    /// </summary>
    public class LabelReceiveService
    {
        /// <summary>
        /// 用于UDP发送的网络服务类
        /// </summary>
        static UdpClient udpcRecv = null;

        static IPEndPoint localIpep = null;

        /// <summary>
        /// 开关：在监听UDP报文阶段为true，否则为false
        /// </summary>
        static bool IsUdpcRecvStart = false;
        /// <summary>
        /// 线程：不断监听UDP报文
        /// </summary>
        static Thread thrRecv;

        public static void StartReceive()
        {
            if (!IsUdpcRecvStart) // 未监听的情况，开始监听
            {
                localIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8899); // 本机IP和监听端口号
                udpcRecv = new UdpClient(localIpep);
                thrRecv = new Thread(ReceiveMessage);
                thrRecv.Start();
                IsUdpcRecvStart = true;
                Console.WriteLine("UDP监听器已成功启动");
            }
        }

        public static void StopReceive()
        {
            if (IsUdpcRecvStart)
            {
                thrRecv.Abort(); // 必须先关闭这个线程，否则会异常
                udpcRecv.Close();
                IsUdpcRecvStart = false;
                Console.WriteLine("UDP监听器已成功关闭");
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="obj"></param>
        private static void ReceiveMessage(object obj)
        {
            while (IsUdpcRecvStart)
            {
                try
                {
                    byte[] bytRecv = udpcRecv.Receive(ref localIpep);
                    string message = Encoding.UTF8.GetString(bytRecv, 0, bytRecv.Length);
                    Console.WriteLine(string.Format("{0}[{1}]", localIpep, message));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }

    }


    class Program1
    {
        /// <summary>
        /// 用于UDP发送的网络服务类
        /// </summary>
        private static UdpClient udpcSend = null;

        static IPEndPoint localIpep = null;

        public static void Main1111(string[] args)
        {
            localIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888); // 本机IP和监听端口号
            udpcSend = new UdpClient(localIpep);


            // 实名发送
            string msg = null;
            while ((msg = Console.ReadLine()) != null)
            {
                Thread thrSend = new Thread(SendMessage);
                thrSend.Start(msg);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="obj"></param>
        private static void SendMessage(object obj)
        {
            try
            {
                string message = (string)obj;
                byte[] sendbytes = Encoding.Unicode.GetBytes(message);
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8899); // 发送到的IP地址和端口号
                udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                //udpcSend.Close();
            }
            catch { }
        }

    }
}
