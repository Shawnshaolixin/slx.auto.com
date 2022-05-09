using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeContinue
{
    public class Skiplist
    {
        /// <summary>
        /// 最大层数
        /// </summary>
        private static int DEFAULT_MAX_LEVEL = 32;


        /// <summary>
        /// 随机层数概率，也就是随机出的层数，在 第1层以上（不包括第一层的概率，层数不超过maxLevel, 层数的起始号为1
        /// </summary>
        private static int DEFAULT_P_FACTOR = 25;

        SkipNode head = new SkipNode(int.MinValue, DEFAULT_MAX_LEVEL);

        int currentLevel = 1; // 当前nodes 的实际层数，它从1开始

        public Skiplist()
        {

        }

        public bool Search(int target)
        {
            return false;
        }

        public void Add(int num)
        {
            int level = randomLevel();
            SkipNode updateNode = head;
            SkipNode newNode = new SkipNode(num, level);

            for (int i = currentLevel - 1; i >= 0; i--)
            {
                updateNode = findClosest(updateNode, i, num);
                if (i < level)
                {
                    if (updateNode.next[i] == null)
                    {
                        updateNode.next[i] = newNode;
                    }
                    else
                    {
                        SkipNode temp = updateNode.next[i];
                        updateNode.next[i] = newNode;
                        newNode.next[i] = temp;
                    }
                }
            }
            if (level > currentLevel)
            {
                for (int i = currentLevel; i < level; i++)
                {
                    head.next[i] = newNode;
                }
                currentLevel = level;
            }

        }
        public bool Erase(int num)
        {
            return false;

        }

        /// <summary>
        /// 找到level 层， value 大于node 的节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="levelIndex"></param>
        /// <param name="value"></param>
        /// <returns></returns>

        private SkipNode findClosest(SkipNode node, int levelIndex, int value)
        {
            while (node.next[levelIndex] != null && value > node.next[levelIndex].value)
            {
                node = node.next[levelIndex];
            }
            return node;
        }
        private static int randomLevel()
        {
            int level = 1;
            Random random = new Random();
            var value = random.Next(0, 100);

            while (value < DEFAULT_P_FACTOR && level < DEFAULT_MAX_LEVEL)
            {
                level++;
            }
            return level;
        }
        public class SkipNode
        {
            public int value { get; set; }
            public SkipNode[] next { get; set; }

            public SkipNode(int value, int size)
            {
                this.value = value;
                this.next = new SkipNode[size];
            }


        }

    }
}
