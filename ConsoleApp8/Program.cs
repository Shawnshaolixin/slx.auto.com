using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static string path = "Folder";
        /// <summary>
        /// 文件数量
        /// </summary>
        static int logFileCount = 5;
        static int logSize = 1024 * 1024;
        private static void Main(string[] args)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Console.WriteLine("当前线程：" + Thread.CurrentThread.Name);
            Thread thread = new Thread(WriteLog);
            thread.Start();
            Console.WriteLine("Hello World" + thread.Name);
            Console.ReadKey();
        }

        public static void WriteLog()
        {
            Console.WriteLine("开始写日志" + Thread.CurrentThread.Name);
            while (true)
            {
                Thread.Sleep(10);
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                string type = "";
                if (fileInfos.Length <= 0)
                {
                    var filePath = Path.Combine(path, type, "Signal-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".log");
                    File.Create(filePath);
                }
                else
                {


                    if (fileInfos.Length > logFileCount)
                    {
                        var fullName = fileInfos[0].FullName;
                        File.Delete(fullName);

                        fileInfos = directoryInfo.GetFiles();
                    }



                    FileInfo fileInfo = fileInfos[fileInfos.Length - 1];
                    StreamWriter sw;
                    if (fileInfo.Length > logSize)
                    {

                        var filePath = Path.Combine(path, "Signal-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".log");
                        FileStream fileStream = File.Create(filePath);
                        sw = new StreamWriter(fileStream);
                    }
                    else
                    {
                        sw = fileInfo.AppendText();

                    }

                    sw.WriteLine("日志内容日志内容日志日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容日志内容内容日志内容日志内容日志内容日志内容日志内容");
                    Console.WriteLine("日志记录了");
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }

        }
    }
}
