using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            LabelReceiveService.StartReceive();
            Console.ReadKey();
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
                localIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 40003); // 本机IP和监听端口号
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
}
