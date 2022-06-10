using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeContinue
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
        public TreeNode(TreeNode left,int x ,TreeNode right)
        {
            this.left = left;
            this.val = x;
            this.right = right;
        }
    }
}
