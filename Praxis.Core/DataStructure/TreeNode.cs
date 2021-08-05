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
    }
}
