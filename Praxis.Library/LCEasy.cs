using Praxis.Contracts;
using Praxis.Core;
using Praxis.Core.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Praxis.Library
{
    public class LCEasy : IProblem
    {
        public void Run()
        {
            RomanToInt();
            ValidParentheses();
            MergeTwoLists();
            MaxSubArray();
        }

        #region Caller methods

        private void RomanToInt()
        {
            var romanInput = "MCMXCIV";
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            Console.WriteLine($"--Input: {romanInput}");
            Console.WriteLine($"--Output: {RomanToInt("MCMXCIV")}");
            Helper.InsertBlankSep();
        }

        private void ValidParentheses()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var validInput = "([{}])";
            Console.WriteLine($"--Input: {validInput}");
            Console.WriteLine($"--Output: {IsValidParentheses(validInput)}");
            var invalidInput = "([{}})";
            Console.WriteLine($"--Input: {invalidInput}");
            Console.WriteLine($"--Output: {IsValidParentheses(invalidInput)}");
            Helper.InsertBlankSep();

        }

        public void MergeTwoLists()
        {
            var l1 = new ListNode<int>()
            {
                Data = 1,
                NextNode = new ListNode<int>()
                {
                    Data = 2,
                    NextNode = new ListNode<int>()
                    {
                        Data = 4
                    }
                }
            };

            var l2 = new ListNode<int>()
            {
                Data = 1,
                NextNode = new ListNode<int>()
                {
                    Data = 3,
                    NextNode = new ListNode<int>()
                    {
                        Data = 4
                    }
                }
            };

            var temp1 = l1;
            var temp2 = l2;

            //Print L1
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            Console.Write($"--Input L1: ");

            while (temp1.NextNode != null)
            {
                Console.Write($"{Convert.ToString(temp1.Data)} -> ");
                temp1 = temp1.NextNode;
            }

            Console.WriteLine($"{Convert.ToString(temp1.Data)} -> null");

            //Print L2
            Console.Write($"--Input L2: ");

            while (temp2.NextNode != null)
            {
                Console.Write($"{Convert.ToString(temp2.Data)} -> ");
                temp2 = temp2.NextNode;
            }

            Console.WriteLine($"{Convert.ToString(temp2.Data)} -> null");

            //Print L2
            Console.Write($"--Output Merged: ");

            var mergedLists = MergeTwoLists(l1, l2);

            while (mergedLists.NextNode != null)
            {
                Console.Write($"{Convert.ToString(mergedLists.Data)} -> ");
                mergedLists = mergedLists.NextNode;
            }

            Console.Write($"{Convert.ToString(mergedLists.Data)} -> null");

            Helper.InsertBlankSep(2);
        }

        public void MaxSubArray()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.WriteLine($"--Input: {string.Join(",", input)}");
            Console.WriteLine($"--Output: {MaxSubArray(input)}");
            Console.WriteLine($"--Output Array: {string.Join(",", MaxSubArray(input, input.Length))}");
            Helper.InsertBlankSep();
        }

        #endregion

        #region Implementation Methods

        /// <summary>
        /// Roman to Integer: Convert a Roman Numeral to an Integer
        /// https://leetcode.com/problems/roman-to-integer/
        /// </summary>
        /// <param name="s">Roman Numeral</param>
        /// <returns>Converted Integer Output</returns>
        private int RomanToInt(string s)
        {
            Dictionary<char, int> valueMap = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            var result = 0;
            var prevNum = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                var currNum = valueMap[s[i]];
                result += prevNum > currNum ? -currNum : currNum;
                prevNum = currNum;
            }

            return result;
        }

        /// <summary>
        /// Valid Parentheses: Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        /// https://leetcode.com/problems/valid-parentheses/
        /// </summary>
        /// <param name="s">Parenthesis String</param>
        /// <returns>Boolean if its valid</returns>
        private bool IsValidParentheses(string s)
        {
            var _bracMap = new Dictionary<char, char>()
            {
                { ')','(' },
                { ']','[' },
                { '}','{' },
            };

            var bracBag = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char curr = s[i];

                // If the current character is a closing bracket.
                if (_bracMap.ContainsKey(curr))
                {
                    // Get the top element of the stack. If the stack is empty, set a dummy value of '#'
                    var topChar = bracBag.Count <= 0 ? '#' : bracBag.Pop();

                    // If the mapping for this bracket doesn't match the stack's top element, return false.
                    if (topChar != _bracMap[curr])
                    {
                        return false;
                    }
                }
                else
                {
                    // If it was an opening bracket, push to the stack.
                    bracBag.Push(curr);
                }
            }

            //If not empty, then input is invalid expression
            return bracBag.Count <= 0;
        }

        /// <summary>
        /// Merge Two Sorted Lists: Merge two sorted linked lists and return it as a sorted list. 
        /// The list should be made by splicing together the nodes of the first two lists.
        /// https://leetcode.com/problems/merge-two-sorted-lists/
        /// </summary>
        /// <param name="l1">First list</param>
        /// <param name="l2">Second list</param>
        /// <returns>Merged list</returns>
        public ListNode<int> MergeTwoLists(ListNode<int> l1, ListNode<int> l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            // start with the linked list
            // whose head data is the least
            if (l1.Data < l2.Data)
            {
                l1.NextNode = MergeTwoLists(l1.NextNode, l2);
                return l1;
            }
            else
            {
                l2.NextNode = MergeTwoLists(l1, l2.NextNode);
                return l2;
            }
        }

        /// <summary>
        /// Maximum Subarray: Given an integer array nums, 
        /// find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
        /// https://leetcode.com/problems/maximum-subarray/
        /// Solution uses Kadane's Algorithm
        /// </summary>
        /// <param name="nums">Number of array</param>
        /// <returns>Sum of Sub Array</returns>
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length <= 0)
                return 0;

            if (nums.Length == 1)
            {
                return nums[0];
            }

            var currSum = nums[0];
            var maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int num = nums[i];

                currSum = Math.Max(num, currSum + num);
                maxSum = Math.Max(maxSum, currSum);
            }

            return maxSum;
        }

        /// <summary>
        /// Maximum Subarray: Given an integer array nums, 
        /// find the contiguous subarray (containing at least one number) which has the largest sum and return that subarray. 
        /// Variation of Original Maximum Subarray problem from Leetcode.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <returns>Maximum Subarray</returns>
        public int[] MaxSubArray(int[] nums, int n)
        {
            if (n <= 1)
                return nums;

            //Index store of maximum sum subarray found so far
            var startIndex = 0;
            var endIndex = 0;

            //Stores Maximum Sum
            int maxSum = 0;
            
            //Stores the Maximum Sum of Subarray at current position
            int maxEnd = 0;

            //Stores starting index of positive sum sequence
            int posIndex = 0;

            for (int i = 0; i < n; i++)
            {
                maxEnd = maxEnd + nums[i];

                //If negative, restart the index and reset the maxEndHere variable
                if (maxEnd < 0) 
                {
                    maxEnd = 0;
                    posIndex = i + 1;
                }

                //Update result if current subarray sum is greater
                if(maxSum < maxEnd)
                {
                    maxSum = maxEnd;
                    startIndex = posIndex;
                    endIndex = i;
                }
            }

            var result = new List<int>();

            for (var i = startIndex; i <= endIndex; i++)
            {
                result.Add(nums[i]);
            }

            return result.ToArray();
        }

        #endregion
    }
}
