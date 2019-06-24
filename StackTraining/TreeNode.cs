namespace StackTraining
{
    /// <summary>
    /// 二叉树
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// 根节点
        /// </summary>
        public int val { get; set; }
        /// <summary>
        /// 左子树
        /// </summary>
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int node)
        {
            this.val = node;
        }
    }
}
