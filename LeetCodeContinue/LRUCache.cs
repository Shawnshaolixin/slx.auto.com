using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeContinue
{
    public class LRUCache
    {
        public class DLinkedNode
        {
            public int key;
            public int value;
            public DLinkedNode prev;
            public DLinkedNode next;
            public DLinkedNode() { }
            public DLinkedNode(int _key, int _value) { key = _key; value = _value; }
        }
        private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
        private int size;
        private int capacity;
        private DLinkedNode head, tail;



        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            head = new DLinkedNode();
            tail = new DLinkedNode();
            head.next = tail;
            tail.prev = head;
        }

        public int Get(int key)
        {
            if (cache.TryGetValue(key, out DLinkedNode node))
            {
                moveToHead(node);
                return node.value;
            }
            else
            {
                return -1;
            }

        }

        public void Put(int key, int value)
        {

            DLinkedNode node = new DLinkedNode();
            node.key = key;
            node.value = value;
            addToHead(node);
            if (!cache.ContainsKey(key))
            {
                size++;
                cache.Add(key, node);
            }
            else
            {
                removeNode(cache[key]);
                cache[key] = node;
            }


            if (size > capacity)
            {
                cache.Remove(tail.prev.key);
                removeTail();
                size--;
            }

        }

        private void addToHead(DLinkedNode node)
        {
            node.prev = head;
            node.next = head.next;
            head.next.prev = node;
            head.next = node;
        }

        private void removeNode(DLinkedNode node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        private void moveToHead(DLinkedNode node)
        {
            removeNode(node);
            addToHead(node);
        }

        private DLinkedNode removeTail()
        {
            DLinkedNode res = tail.prev;
            removeNode(res);
            return res;
        }
    }
}
