using System.Collections.Generic;

namespace StackTraining
{
    public class MyQueue
    {
        private Stack<int> stack;
        private Stack<int> stack_temp;

        /** Initialize your data structure here. */
        public MyQueue()
        {
            stack = new Stack<int>();
            stack_temp = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            while (stack.Count > 0)
            {
                stack_temp.Push(stack.Pop());
            }
            stack_temp.Push(x);
            while (stack_temp.Count > 0)
            {
                stack.Push(stack_temp.Pop());
            }
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            return stack.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            return stack.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return stack.Count <= 0;
        }
    }

}
