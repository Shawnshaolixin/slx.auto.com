using System;
using System.Collections;
using System.Collections.Generic;

namespace StringTrain
{
    class Program
    {
        static void Main(string[] args)
        {

            Solution solution = new Solution();
            string[] arr = new string[] { "5", "2", "C", "D", "+" };
            var count = solution.CalPoints(arr);
            Console.WriteLine(count);
            #region MyQueue

            //MyQueue myQueue = new MyQueue();
            //myQueue.Push(1);
            //myQueue.Push(2);
            //myQueue.Push(3);
            //myQueue.Push(4);
            //myQueue.Push(5);
            //Console.WriteLine(myQueue.Peek());
            //while (!myQueue.Empty())
            //{
            //    Console.WriteLine(myQueue.Pop());
            //} 
            #endregion
            #region MyStack
            //MyStack myStack = new MyStack();
            //myStack.Push(1);
            //myStack.Push(2);

            //myStack.Push(3);
            //myStack.Push(4);
            //while (!myStack.Empty())
            //{
            //    Console.WriteLine(myStack.Pop());
            //}
            //Console.WriteLine(myStack.Top());
            //Console.WriteLine(myStack.Empty()); 
            #endregion

            #region 验证符号
            //Solution solution = new Solution();
            //var b = solution.IsValid("[{[]}{[]}][]{}()");
            //Console.WriteLine(b); 
            #endregion
            #region 验证栈序列
            //Solution solution = new Solution();
            //int[] pushed = new int[] { 1, 2, 3, 4, 5 };
            //int[] popped = new int[] { 4, 3, 5, 1, 2 };
            //var b = solution.ValidateStackSequences(pushed, popped); 
            #endregion

            #region 最小栈
            //MinStack minStack = new MinStack();
            //minStack.Push(1);
            //minStack.Push(2);
            //minStack.Push(3);
            //minStack.Push(-9);
            //minStack.Push(6);
            //Console.WriteLine(minStack.Top());
            //Console.WriteLine(minStack.Top());
            //Console.WriteLine(minStack.GetMin()); 
            #endregion
            Console.Read();
        }
        static Boolean IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            var arr = s.ToCharArray();

            return false;
        }
    }

    //public class Solution
    //{
    //    public bool ValidateStackSequences(int[] pushed, int[] popped)
    //    {

    //        Queue q = new Queue();
    //        Stack s = new Stack();
    //        for (int i = 0; i < popped.Length; i++)
    //        {
    //            q.Enqueue(popped[i]);
    //        }
    //        for (int i = 0; i < pushed.Length; i++)
    //        {
    //            s.Push(pushed[i]);
    //            while (s.Count > 0 && ((int)s.Peek() == (int)q.Peek()))
    //            {
    //                q.Dequeue();
    //                s.Pop();
    //            }
    //        }
    //        return s.Count <= 0;
    //    }
    //}
    public class MinStack
    {
        Stack stack = new Stack();
        Stack minStack = new Stack();
        /** initialize your data structure here. */
        public MinStack()
        {


        }

        public void Push(int x)
        {
            stack.Push(x);
            if (minStack.Count <= 0)
            {
                minStack.Push(x);
            }
            else
            {
                if (x < (int)minStack.Peek())
                {
                    minStack.Push(x);
                }
                else
                {
                    minStack.Push((int)minStack.Peek());
                }
            }

        }
        public void Pop()
        {
            stack.Pop();
            minStack.Pop();
        }
        public int Top()
        {
            return (int)stack.Peek();
        }
        public int GetMin()
        {
            return (int)minStack.Peek();
        }
    }
    #region 验证括号
    //public class Solution1
    //{
    //    public bool IsValid(string s)
    //    {
    //        if (string.IsNullOrEmpty(s))
    //            return true;
    //        Queue q = new Queue();
    //        Stack stack = new Stack();
    //        char a = '(';
    //        char b = ')';
    //        char c = '{';
    //        char d = '}';
    //        char e = '[';
    //        char f = ']';

    //        for (int i = 0; i < s.Length; i++)
    //        {
    //            if (s[i] == a)
    //            {
    //                q.Enqueue(1);
    //            }
    //            if (s[i] == b)
    //            {
    //                q.Enqueue(-1);
    //            }
    //            if (s[i] == c)
    //            {
    //                q.Enqueue(2);
    //            }
    //            if (s[i] == d)
    //            {
    //                q.Enqueue(-2);
    //            }
    //            if (s[i] == e)
    //            {
    //                q.Enqueue(3);
    //            }
    //            if (s[i] == f)
    //            {
    //                q.Enqueue(-3);
    //            }
    //        }
    //        while(q.Count>0)
    //        {
    //            if (stack.Count > 0 && ((int)stack.Peek() + (int)q.Peek() == 0))
    //            {
    //                stack.Pop();
    //                q.Dequeue();
    //            }
    //            else
    //            {
    //                stack.Push(q.Dequeue());
    //            }

    //        }



    //        return stack.Count <= 0;
    //    }
    //} 
    #endregion
    public class Solution1
    {
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c.IsLeft())
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    else
                    {
                        var top = stack.Pop();
                        if (!top.Match(c)) return false;
                    }
                }
            }

            return stack.Count == 0;
        }




    }
    public static class CharExtension
    {
        public static bool IsLeft(this char ch)
        {
            return ch == '[' || ch == '{' || ch == '(';
        }
        public static bool Match(this char lhs, char rhs)
        {
            return (lhs == '(' && rhs == ')') || (lhs == '[' && rhs == ']') || (lhs == '{' && rhs == '}');
        }
    }
    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
    public class MyStack
    {
        Queue<int> queue = new Queue<int>();
        Queue<int> temp_queue = new Queue<int>();
        /** Initialize your data structure here. */
        public MyStack()
        {

        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            temp_queue.Enqueue(x);
            while (queue.Count > 0)
            {
                temp_queue.Enqueue(queue.Dequeue());
            }
            while (temp_queue.Count > 0)
            {
                queue.Enqueue(temp_queue.Dequeue());
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            return queue.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            if (queue.Count <= 0)
            {
                throw new InvalidOperationException("mystack empty");
            }
            return queue.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return queue.Count <= 0;
        }
    }

    /**
     * Your MyStack object will be instantiated and called as such:
     * MyStack obj = new MyStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * bool param_4 = obj.Empty();
     */
    public class MyQueue
    {
        private Stack<int> stack;
        private Stack<int> temp_stack;
        /** Initialize your data structure here. */
        public MyQueue()
        {
            stack = new Stack<int>();
            temp_stack = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            while (stack.Count > 0)
            {
                temp_stack.Push(stack.Pop());
            }
            temp_stack.Push(x);
            while (temp_stack.Count > 0)
            {
                stack.Push(temp_stack.Pop());
            }
        }
        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            if (Empty())
            {
                throw new InvalidOperationException("myqueue empty");
            }
            return stack.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            if (Empty())
            {
                throw new InvalidOperationException("myqueue empty");
            }
            return stack.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return stack.Count <= 0;
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */

    public class Solution
    {
        public int CalPoints(string[] arr)
        {
            Stack stack = new Stack();
            Stack<int> score_stack = new Stack<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int num = 0;

                if (int.TryParse(arr[i], out num))
                {
                    stack.Push(arr[i]);
                    if (score_stack.Count > 0)
                    {
                        score_stack.Push(num + score_stack.Peek());
                    }
                    else
                    {
                        score_stack.Push(num);
                    }
                }
                else
                {

                    if (arr[i] == "C")
                    {
                        score_stack.Push(score_stack.Peek() - Convert.ToInt32(stack.Pop()));

                    }
                    if (arr[i] == "D")
                    {
                        score_stack.Push(score_stack.Peek() + Convert.ToInt32(stack.Peek()));
                    }
                    if (arr[i] == "+")
                    {
                        var qian1 = score_stack.Pop();
                        var qian2 = score_stack.Pop();
                        score_stack.Push(qian2);
                        score_stack.Push(qian1);
                        score_stack.Push(qian1 + qian2);
                    }

                }
            }
            return score_stack.Peek();
        }
    }
}

