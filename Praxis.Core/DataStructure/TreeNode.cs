using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Praxis.Core.DataStructure
{
    public class TreeNode
    {
        public int val;
        public TreeNode Left;
        public TreeNode Right;
        private static readonly int COUNT = 10;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.Left = left;
            this.Right = right;
        }
        public static TreeNode InsertLevelOrder(int[] arr, TreeNode root, int i)
        {
            // Base case for recursion
            if (i < arr.Length)
            {
                TreeNode temp = new TreeNode(arr[i]);
                root = temp;

                // insert left child
                root.Left = InsertLevelOrder(arr, root.Left,
                                                 2 * i + 1);

                // insert right child
                root.Right = InsertLevelOrder(arr, root.Right,
                                                   2 * i + 2);
            }

            return root;
        }

        private void Print2DUtil(TreeNode root, int space)
        {
            // Base case
            if (root == null)
                return;

            // Increase distance between levels
            space += COUNT;

            // Process right child first
            Print2DUtil(root.Right, space);

            // Print current node after space
            // count
            Console.Write("\n");
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.Write(root.val + "\n");

            // Process left child
            Print2DUtil(root.Left, space);
        }

        // Wrapper over print2DUtil()
        public void Print2D()
        {
            // Pass initial space count as 0
            Print2DUtil(this, 0);
        }

    }
}
