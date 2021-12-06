using Praxis.Contracts;
using Praxis.Core.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Praxis.Library
{
    public class TreeCohort : IProblem
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {

            if (nums == null || nums.Length <= 0)
                return null;

            return BuildTree(nums, 0, nums.Length - 1);
        }

        private TreeNode BuildTree(int[] nums, int start, int end)
        {
            if (start > end)
                return null;

            var mid = (start + end) / 2;

            var node = new TreeNode(nums[mid]);

            node.Left = BuildTree(nums, start, mid - 1);
            node.Right = BuildTree(nums, mid + 1, end);

            return node;
        }
    }
}
