using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace 中介者
{
    class Program
    {
        static void Main(string[] args)
        {
            var procName = Process.GetCurrentProcess().ProcessName;
            //对象数组，装不下的时候。就扩大一倍。
            List<int> ls = new List<int>();
            ArrayList arrayList = new ArrayList();
            arrayList.Add(123);

            //泛型双向链表
            LinkedList<int> vs = new LinkedList<int>();

            //也是可变的数组
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            while (q.Count > 0)
            {
                Console.WriteLine(q.Dequeue());
                Thread.Sleep(1000);
            }
            // 栈：可以根据需求调整大小的数组
            Stack<int> stack = new Stack<int>();

            // Contains 散列查找 执行速度快，不能保存重复元素，不能根据位置访问元素
            //只存储键的散列表
            HashSet<int> hs = new HashSet<int>();
            //红/黑树
            SortedSet<int> ss = new SortedSet<int>();
            //散列表
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

            Console.WriteLine("Hello World!" + procName);
            Console.ReadKey();
        }

    }


}
