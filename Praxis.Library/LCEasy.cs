using Praxis.Contracts;
using Praxis.Core;
using Praxis.Core.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Praxis.Library
{
    /// <summary>
    /// This class contains solution for all the important LC Easy questions.
    /// https://leetcode.com/list/?selectedList=5srjg9p5
    /// </summary>
    public class LCEasy : IProblem
    {
        public void Run()
        {
            RomanToInt();
            ValidParentheses();
            MergeTwoLists();
            MaxSubArray();
            MergeSortedArray();
            HasLLCycle();
            PrintMinStack();
            IntersectionNode();
            MajorityElement();
            TrailingZeroes();
            RotateArray();
            RobHouses();
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

        public void MergeSortedArray()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new int[] { 1, 3, 8, 0, 0, 0 };
            var input2 = new int[] { 5, 7, 9 };
            Console.WriteLine($"--Input1: {string.Join(",", input)}");
            Console.WriteLine($"--Input2: {string.Join(",", input2)}");
            MergeSortedArray(input, input.Length - input2.Length, input2, input2.Length);
            Console.WriteLine($"--Output: {string.Join(",", input)}");
            Helper.InsertBlankSep();
        }

        public void HasLLCycle()
        {
            var prev = new ListNode<int>();

            var head = new ListNode<int>()
            {
                Data = 0,
                NextNode = prev
            };

            prev.Data = 1;
            prev.NextNode = new ListNode<int>()
            {
                Data = 1,
                NextNode = head
            };

            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            Console.WriteLine($"--HasCycle?: {HasLLCycle(head)}");
            Helper.InsertBlankSep();
        }

        public void PrintMinStack()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var minResult = GenerateMinStack();
            Console.WriteLine($"--Top: {minResult.Top()}");
            Console.WriteLine($"--Min: {minResult.Min()}");
            Helper.InsertBlankSep();
        }

        public void IntersectionNode()
        {
            var headA = new ListNode<int>()
            {
                Data = 4,
                NextNode = new ListNode<int>()
                {
                    Data = 1,
                    NextNode = new ListNode<int>()
                    {
                        Data = 8,
                        NextNode = new ListNode<int>()
                        {
                            Data = 4,
                            NextNode = new ListNode<int>()
                            {
                                Data = 5,
                                NextNode = null
                            }
                        }
                    }
                }
            };

            var headB = new ListNode<int>()
            {
                Data = 5,
                NextNode = new ListNode<int>()
                {
                    Data = 6,
                    NextNode = new ListNode<int>()
                    {
                        Data = 1,
                        NextNode = headA.NextNode.NextNode.NextNode
                    }
                }
            };

            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            Console.Write($"--HeadA: ");
            headA.PrintNode();
            Helper.InsertBlankSep();
            Console.Write($"--HeadB: ");
            headB.PrintNode();
            Helper.InsertBlankSep();
            Console.Write($"--Intersection: ");

            var intersectionPoint = GetIntersectionNode(headA, headB);
            
            if (intersectionPoint != null)
                intersectionPoint.PrintNode();
            else
                Console.WriteLine("HeadA and HeadB are not intersecting at any point.");
            Helper.InsertBlankSep(2);

        }

        public void MajorityElement()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            Console.WriteLine($"--Input: {string.Join(",", input)}");
            Console.WriteLine($"--Majority Element: {MajorityElement(input)}");
            Helper.InsertBlankSep();
        }

        public void TrailingZeroes()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = 123;
            Console.WriteLine($"--Input: {input}!");
            Console.WriteLine($"--Trailing Zeroes: {TrailingZeroes(input)}");
            Helper.InsertBlankSep();
        }

        public void RotateArray()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var k = 3;
            Console.WriteLine($"--Input: {string.Join(",", input)} | K = {k}");
            RotateArray(input, k);
            Console.WriteLine($"--Output: {string.Join(",", input)}");
            Helper.InsertBlankSep();
        }

        public void RobHouses()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new int[] { 2, 7, 9, 3, 1 };
            Console.WriteLine($"--Houses: {string.Join(",", input)}");
            Console.WriteLine($"--Maximum amount robbed: {Rob(input)}");
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
                if (maxSum < maxEnd)
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

        /// <summary>
        /// Merge Sorted Array: ou are given two integer arrays nums1 and nums2, 
        /// sorted in non-decreasing order, and two integers m and n, 
        /// representing the number of elements in nums1 and nums2 respectively.
        /// The final sorted array should not be returned by the function, but instead be stored inside the array nums1
        /// To accommodate this, nums1 has a length of m + n, 
        /// where the first m elements denote the elements that should be merged, 
        /// and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
        /// https://leetcode.com/problems/merge-sorted-array/
        /// </summary>
        /// <param name="nums1">First sorted array</param>
        /// <param name="m">Length of nums1</param>
        /// <param name="nums2">Second sorted array</param>
        /// <param name="n">Length of nums2</param>
        public void MergeSortedArray(int[] nums1, int m, int[] nums2, int n)
        {
            //End pointers for both arrays
            int p1 = m - 1;
            int p2 = n - 1;

            //Iterate from the end and keep writing the smallest value pointed at p1 or p2 from its respective arrays. 
            for (int p = m + n - 1; p >= 0; p--)
            {
                if (p2 < 0)
                    break;

                if (p1 >= 0 && nums1[p1] > nums2[p2])
                {
                    nums1[p] = nums1[p1--];
                }
                else
                {
                    nums1[p] = nums2[p2--];
                }
            }
        }

        /// <summary>
        /// Linked List Cycle: Given head, the head of a linked list, determine if the linked list has a cycle in it.
        /// https://leetcode.com/problems/linked-list-cycle/
        /// </summary>
        /// <param name="head">Head of the linked list</param>
        /// <returns>Boolean value based on cycle detection</returns>
        public bool HasLLCycle(ListNode<int> head)
        {
            if (head == null)
                return false;

            var slow = head;
            var fast = head.NextNode;

            while (slow != fast)
            {
                if (fast == null || fast.NextNode == null)
                {
                    return false;
                }

                slow = slow.NextNode;
                fast = fast.NextNode.NextNode;
            }

            return true;
        }

        /// <summary>
        /// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
        /// https://leetcode.com/problems/min-stack/
        /// </summary>
        /// <returns>MinStack containing values</returns>
        public MinStack GenerateMinStack()
        {
            var minStack = new MinStack();

            minStack.Push(10);
            minStack.Push(12);
            minStack.Push(15);

            return minStack;
        }

        /// <summary>
        /// Intersection of Two Linked Lists: Given the heads of two singly linked-lists headA and headB, 
        /// return the node at which the two lists intersect. If the two linked lists have no intersection at all, 
        /// return null.
        /// https://leetcode.com/problems/intersection-of-two-linked-lists/
        /// </summary>
        /// <param name="headA">Head of LinkedList A</param>
        /// <param name="headB">Head of LinkedList B</param>
        /// <returns>Intersection point</returns>
        public ListNode<int> GetIntersectionNode(ListNode<int> headA, ListNode<int> headB)
        {
            if (headA == null || headB == null)
                return null;

            var nodeB = new HashSet<ListNode<int>>();

            while (headB != null)
            {
                nodeB.Add(headB);
                headB = headB.NextNode;
            }

            while (headA != null)
            {
                if (nodeB.Contains(headA))
                {
                    return headA;
                }

                headA = headA.NextNode;
            }

            return null;
        }

        /// <summary>
        /// Given an array nums of size n, return the majority element.
        /// The majority element is the element that appears more than ⌊n / 2⌋ times. 
        /// You may assume that the majority element always exists in the array.
        /// Boyer-Moore Majority Vote Algorithm (https://www.cs.utexas.edu/~moore/best-ideas/mjrty/)
        /// https://leetcode.com/problems/majority-element/
        /// </summary>
        /// <param name="nums">Array of numbers</param>
        /// <returns>Majority element</returns>
        public int MajorityElement(int[] nums)
        {
            int majorElement = nums[0];
            int count = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    count++;
                    majorElement = nums[i];
                }
                else if (nums[i] == majorElement)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            return majorElement;
        }

        /// <summary>
        /// Factorial Trailing Zeroes: Given an integer n, return the number of trailing zeroes in n!.
        /// </summary>
        /// <param name="n">Number input</param>
        /// <returns>Returns number of trailing zeroes in factorial of given input</returns>
        public int TrailingZeroes(int n)
        {
            int result = 0;

            while(n >= 5)
            {
                n /= 5;
                result += n;
            }

            return result;
        }

        /// <summary>
        /// Rotate array by K number and return it. 
        /// </summary>
        /// <param name="nums">Array of integers</param>
        /// <param name="k">Number of places it should be rotated</param>
        public void RotateArray(int[] nums, int k)
        {
            k %= nums.Length;

            ReverseElements(nums, 0, nums.Length - 1);
            ReverseElements(nums, 0, k - 1);
            ReverseElements(nums, k, nums.Length - 1);
        }

        /// <summary>
        /// Reveres the elements in an array from start to end indexes
        /// </summary>
        /// <param name="nums">Array of integers</param>
        /// <param name="start">Start index</param>
        /// <param name="end">End index</param>
        private void ReverseElements(int[] nums, int start, int end)
        {
            while (start < end)
            {
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        /// <summary>
        /// Maximum Sum Subsequence Non-Adjacent: House Robber: You are a professional robber planning to rob houses along a street. 
        /// Each house has a certain amount of money stashed, 
        /// the only constraint stopping you from robbing each of them is that 
        /// adjacent houses have security systems connected and it will 
        /// automatically contact the police if two adjacent houses were broken into on the same night.
        /// https://leetcode.com/problems/house-robber/
        /// </summary>
        /// <param name="nums">Array of houses</param>
        /// <returns>Total amount robbed</returns>
        public int Rob(int[] nums)
        {
            // As we rob, we peek the next adjacent house
            // Maintain incl variable to store maximum robbed so far including current house
            // Maintain excl variable to store maximum robbed so far excluding current house

            if (nums.Length <= 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int excl = 0;
            int incl = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                var temp = incl;
                incl = Math.Max(excl + nums[i], incl);
                excl = temp;
            }

            return incl;
        }

        #endregion
    }
}
