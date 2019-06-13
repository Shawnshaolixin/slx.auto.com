using System;

namespace 回文串
{
    class Program
    {
        static void Main(string[] args)
        {
            //题目：给定一个字符串，问是否能通过添加一个字母将其变为回文串。
            // 一行一个由小写字母构成的字符串，字符串长度小于等于10。

            /*
             思路:
             1.根据输入字符串的长度，声明一个长度+1 的数组
             2.遍历输入字符串，将每个字符对应放到数组里
             3.输入字符串的第一位，放到数组的最后一位
             4.遍历数组，第一位和最后一位进行比较，第二位和倒数第二位进行比较，依次类推。
             如果有不想等的情况，则不是回文串
             如果，都相等，则是回文串
             注意：这里我不做输入和10位长度限制了，直接写死。
             */
            string str = "abcb";
            string[] arr = new string[str.Length + 1];
            int i = 0;
            foreach (var item in str)
            {
                arr[i] = item.ToString();
                i++;
            }
            arr[arr.Length - 1] = str[0].ToString();
            foreach (var item in arr)
            {
                Console.Write(item + " ");

            }
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == arr[arr.Length - 1 - j])
                {
                    continue;
                } else
                {
                    Console.WriteLine("No");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("Yes");
            Console.ReadKey();
        }
    }
}
