using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SupperSocketDome1
{
    class Program
    {
        /// <summary>
        /// 用于UDP发送的网络服务类
        /// </summary>
        private static UdpClient udpcSend = null;

        static IPEndPoint localIpep = null;
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
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 50001); // 发送到的IP地址和端口号
                udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                //udpcSend.Close();
            }
            catch { }
        }
        static void Main(string[] args)
        {


            //  localIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 40003); // 本机IP和监听端口号
            udpcSend = new UdpClient();
            // 实名发送
            string msg = null;
            while ((msg = Console.ReadLine()) != null)
            {
                Thread thrSend = new Thread(SendMessage);
                thrSend.Start(msg);
            }
            Console.ReadKey();
            //// This constructor arbitrarily assigns the local port number.
            //UdpClient udpClient = new UdpClient();
            //try
            //{
            //    udpClient.Connect("127.0.0.1", 40003);

            //    // Sends a message to the host to which you have connected.
            //    Byte[] sendBytes = Encoding.ASCII.GetBytes("1111111111111111Is anybody there test ?");

            //    udpClient.Send(sendBytes, sendBytes.Length);

            //    // Sends a message to a different host using optional hostname and port parameters.
            //    UdpClient udpClientB = new UdpClient();
            //    udpClientB.Send(sendBytes, sendBytes.Length, "AlternateHostMachineName", 40003);

            //    //IPEndPoint object will allow us to read datagrams sent from any source.
            //    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            //    // Blocks until a message returns on this socket from a remote host.
            //    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
            //    string returnData = Encoding.ASCII.GetString(receiveBytes);

            //    // Uses the IPEndPoint object to determine which of these two hosts responded.
            //    Console.WriteLine("This is the message you received " +
            //                                 returnData.ToString());
            //    Console.WriteLine("This message was sent from " +
            //                                RemoteIpEndPoint.Address.ToString() +
            //                                " on their port number " +
            //                                RemoteIpEndPoint.Port.ToString());

            //    udpClient.Close();
            //    udpClientB.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}


            //Console.WriteLine("Press any key to start the server!");

            //Console.ReadKey();
            //Console.WriteLine();

            //var appServer = new AppServer();

            ////Setup the appServer
            //if (!appServer.Setup(5000)) //Setup with listening port
            //{
            //    Console.WriteLine("Failed to setup!");
            //    Console.ReadKey();
            //    return;
            //}

            //Console.WriteLine();

            ////Try to start the appServer
            //if (!appServer.Start())
            //{
            //    Console.WriteLine("Failed to start!");
            //    Console.ReadKey();
            //    return;
            //}
            //appServer.NewSessionConnected += AppServer_NewSessionConnected;
            //appServer.NewRequestReceived += AppServer_NewRequestReceived;
            //Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            //while (Console.ReadKey().KeyChar != 'q')
            //{
            //    Console.WriteLine();
            //    continue;
            //}

            ////Stop the appServer
            //appServer.Stop();

            //Console.WriteLine("The server was stopped!");
            //Console.ReadKey();
        }

        private static void AppServer_NewRequestReceived(AppSession session, StringRequestInfo requestInfo)
        {
            switch (requestInfo.Key.ToUpper())
            {
                case ("ECHO"):
                    session.Send(requestInfo.Body);
                    break;

                case ("ADD"):
                    session.Send(requestInfo.Parameters.Select(p => Convert.ToInt32(p)).Sum().ToString());
                    break;

                case ("MULT"):

                    var result = 1;

                    foreach (var factor in requestInfo.Parameters.Select(p => Convert.ToInt32(p)))
                    {
                        result *= factor;
                    }

                    session.Send(result.ToString());
                    break;
            }
        }

        private static void AppServer_NewSessionConnected(AppSession session)
        {
            session.Send("Welcome to SuperSocket Telnet Server");
        }
    }
    public class TelnetServer : AppServer<TelnetSession>
    {
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStartup()
        {
            base.OnStartup();
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }
    }

    public class TelnetSession : AppSession<TelnetSession>
    {
        protected override void OnSessionStarted()
        {
            //this.Send("Welcome to SuperSocket Telnet Server\r\n");
            byte[] bytes = Encoding.ASCII.GetBytes("Welcome\r\n to SuperSocket\r\n Telnet Server\r\n");
            this.Send(bytes, 0, bytes.Length);
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            this.Send("Unknow request");
        }

        protected override void HandleException(Exception e)
        {
            this.Send("Application error: {0}", e.Message);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            //add you logics which will be executed after the session is closed
            base.OnSessionClosed(reason);
        }
    }

    public class ECHO : CommandBase<TelnetSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TelnetSession session, StringRequestInfo requestInfo)
        {
            session.Send(requestInfo.Body);
        }
    }
}
