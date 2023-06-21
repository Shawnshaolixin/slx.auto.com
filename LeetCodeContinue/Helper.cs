using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeContinue
{
    public static class Helper
    {
        public static ListNode ArrToListNode(int[] arr)
        {

            ListNode head = new ListNode(arr[0]);
            var temp = head;
            for (int i = 1; i < arr.Length; i++)
            {
                head.next = new ListNode(arr[i]);
                head = head.next;

            }
            return temp;
        }
    }
}
