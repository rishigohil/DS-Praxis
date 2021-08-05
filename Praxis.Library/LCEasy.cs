using Praxis.Contracts;
using Praxis.Core;
using Praxis.Core.DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

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
            IsHappy();
            CountPrimes();
            InvertTree();
            IsAnagram();
            FindDisappearedNumbers();
            ReverseStringIII();
            IsSubTree();
            MergeTrees();
            CheckPossibility();
            TrimBST();
            FindLengthOfLCIS();
            NaryPreOrder();
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

        public void IsHappy()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = 19;
            Console.WriteLine($"--Input: {input}");
            Console.WriteLine($"--Happy Num? : {IsHappy(input)}");
            input = 33;
            Console.WriteLine($"--Input 2: {input}");
            Console.WriteLine($"--Happy Num? : {IsHappy(input)}");
            Helper.InsertBlankSep();
        }

        public void CountPrimes()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = 21;
            Console.WriteLine($"--Input: {input}");
            Console.WriteLine($"--Output: {CountPrimes(input)}");
            Helper.InsertBlankSep();
        }

        public void InvertTree()
        {
            var tree = new TreeNode(1)
            {
                Left = new TreeNode(2)
            };

            tree.Left.Left = new TreeNode(3);
            tree.Right = new TreeNode(4);
            tree.Right.Right = new TreeNode(5);
            tree.Right.Left = new TreeNode(6);

            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            Console.Write($"--Input: ");
            PostOrderPrint(tree);
            var inverted = InvertTree(tree);
            Helper.InsertBlankSep();
            Console.Write($"--Output: ");
            PostOrderPrint(inverted);
            Helper.InsertBlankSep(2);

        }

        public void IsAnagram()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var strInput = new string[] { "anagram", "nagaram", "rat", "car" };
            Console.WriteLine($"--Input: {string.Join(",", strInput.Take(2))}");
            Console.WriteLine($"--IsAnagram: {IsAnagram(strInput[0], strInput[1])}");
            Console.WriteLine($"--Input: {string.Join(",", strInput.Skip(2).Take(2))}");
            Console.WriteLine($"--IsAnagram: {IsAnagram(strInput[2], strInput[3])}");
            Helper.InsertBlankSep();
        }

        public void FindDisappearedNumbers()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            Console.WriteLine($"--Input: {string.Join(",", input)}");
            Console.WriteLine($"--Missing Nums: {string.Join(",", FindDisappearedNumbers(input))}");
            Helper.InsertBlankSep();
        }

        public void ReverseStringIII()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = "Let's take LeetCode contest";
            Console.WriteLine($"--Input: {input}");
            Console.WriteLine($"--Output: {ReverseWords(input)}");
            Helper.InsertBlankSep();
        }

        public void IsSubTree()
        {
            var rootTreeArr = new int[] { 3, 4, 5, 1, 2 };
            var subTreeArr = new int[] { 4, 1, 2 };
            var root = new TreeNode();
            var subTreeRoot = new TreeNode();
            root = TreeNode.InsertLevelOrder(rootTreeArr, root, 0);
            subTreeRoot = TreeNode.InsertLevelOrder(subTreeArr, subTreeRoot, 0);

            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            Console.WriteLine($"--Root: {string.Join(",", rootTreeArr)}");
            Console.WriteLine($"--SubTreeRoot: {string.Join(",", subTreeArr)}");
            Console.WriteLine($"--IsSubTree? : {IsSubtree(root, subTreeRoot)}");
            Helper.InsertBlankSep();
        }

        public void MergeTrees()
        {
            var rootArr1 = new int[] { 1, 3, 2, 5 };
            var rootArr2 = new int[] { 2, 1, 3, 4, 7 };
            var root = new TreeNode();
            var root2 = new TreeNode();
            root = TreeNode.InsertLevelOrder(rootArr1, root, 0);
            root2 = TreeNode.InsertLevelOrder(rootArr2, root2, 0);

            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            Console.WriteLine($"--Root 1: {string.Join(",", rootArr1)}");
            Console.WriteLine($"--Root 2: {string.Join(",", rootArr2)}");
            var mergedTree = MergeTrees(root, root2);
            Console.Write($"--Output: ");
            PostOrderPrint(mergedTree);
            Helper.InsertBlankSep(2);
        }

        public void CheckPossibility()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new int[] { 4, 2, 3 };
            Console.WriteLine($"--Input: {string.Join(",", input)}");
            Console.WriteLine($"--Non-decreasing Array: {CheckPossibility(input)}");
            input = new int[] { 4, 2, 1 };
            Console.WriteLine($"--Input: {string.Join(",", input)}");
            Console.WriteLine($"--Non-decreasing Array: {CheckPossibility(input)}");

            Helper.InsertBlankSep();
        }

        public void TrimBST()
        {
            var rootTreeArr = new int[] { 1, 0, 2 };
            var root = new TreeNode();
            root = TreeNode.InsertLevelOrder(rootTreeArr, root, 0);
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            Console.WriteLine($"--Root: {string.Join(",", rootTreeArr)}");
            Console.WriteLine($"--Trim Points: Low: 1, High: 2");
            var trimmedTree = TrimBST(root, 1, 2);
            Console.Write($"--Output: ");
            PostOrderPrint(trimmedTree);
            Helper.InsertBlankSep(2);
        }

        public void FindLengthOfLCIS()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new int[] { 1, 3, 5, 4, 7 };
            Console.WriteLine($"--Input: {string.Join(",", input)}");
            Console.WriteLine($"--LCIS Length: {FindLengthOfLCIS(input)}");
            Helper.InsertBlankSep();
        }

        public void NaryPreOrder()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var naryTree = new NTreeNode
            {
                val = 1,
                children = new List<NTreeNode>()
                {
                    new NTreeNode()
                    {
                        val = 3,
                        children = new List<NTreeNode>()
                        {
                            new NTreeNode()
                            {
                                val = 5,
                                children = new List<NTreeNode>()
                            },
                            new NTreeNode()
                            {
                                val = 6,
                                children = new List<NTreeNode>()
                            }
                        }
                    },
                    new NTreeNode()
                    {
                        val = 2,
                        children = new List<NTreeNode>()
                    },
                    new NTreeNode()
                    {
                        val = 4,
                        children = new List<NTreeNode>()
                    }
                }
            };
            Console.WriteLine($"--N-ary Preorder Traversal: {string.Join(",", Preorder(naryTree))}");
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

            while (n >= 5)
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

            for (int i = 1; i < nums.Length; i++)
            {
                var temp = incl;
                incl = Math.Max(excl + nums[i], incl);
                excl = temp;
            }

            return incl;
        }

        /// <summary>
        /// Happy Number: Write an algorithm to determine if a number n is happy.
        /// A happy number is a number defined by the following process:
        /// Starting with any positive integer, replace the number by the sum of the squares of its digits.
        /// Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        /// Those numbers for which this process ends in 1 are happy.
        /// https://leetcode.com/problems/happy-number/
        /// </summary>
        /// <param name="n">Input Number</param>
        /// <returns>Return true if n is a happy number, and false if not.</returns>
        public bool IsHappy(int n)
        {
            if (n == 1)
                return true;

            var seenSet = new HashSet<int>();

            while (n != 1)
            {
                int current = n;
                int sum = 0;

                while (current != 0)
                {
                    sum += (int)Math.Pow(current % 10, 2);
                    current /= 10;
                }

                if (seenSet.Contains(sum))
                    return false;

                seenSet.Add(sum);
                n = sum;
            }

            return true;
        }

        /// <summary>
        /// Count Primes: Count the number of prime numbers less than a non-negative number, n.
        /// https://leetcode.com/problems/count-primes/
        /// </summary>
        /// <param name="n">Non negative Number</param>
        /// <returns>Number of prime numbers less than input</returns>
        public int CountPrimes(int n)
        {

            if (n <= 2)
                return 0;

            bool[] numArr = new bool[n];

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (numArr[i] == false)
                {
                    for (int j = i * i; j < n; j += i)
                    {
                        numArr[j] = true;
                    }
                }
            }

            var primeCount = 0;

            for (int i = 2; i < n; i++)
            {
                if (numArr[i] == false)
                    primeCount++;
            }

            return primeCount;
        }

        /// <summary>
        /// Invert Binary Tree: Given the root of a binary tree, invert the tree, and return its root.
        /// https://leetcode.com/problems/invert-binary-tree/
        /// </summary>
        /// <param name="root">Root of the tree</param>
        /// <returns>Root of inverted tree</returns>
        public TreeNode InvertTree(TreeNode root)
        {

            if (root == null)
                return null;

            var temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;

            InvertTree(root.Left);
            InvertTree(root.Right);

            return root;
        }

        /// <summary>
        /// Post Order Tree Traversal = Prints the tree in PostOrder manner.
        /// </summary>
        /// <param name="node">TreeNode root</param>
        private void PostOrderPrint(TreeNode node)
        {
            if (node == null)
                return;

            PostOrderPrint(node.Left);
            PostOrderPrint(node.Right);
            Console.Write(node.val + " ");
        }

        /// <summary>
        /// Valid Anagram: Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        /// https://leetcode.com/problems/valid-anagram/
        /// </summary>
        /// <param name="s">String A</param>
        /// <param name="t">String B</param>
        /// <returns>Boolean if both string parameters are anagram of each other</returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            var counter = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                counter[s[i] - 'a']++;
                counter[t[i] - 'a']--;
            }

            foreach (var count in counter)
            {
                if (count != 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Find All Numbers Disappeared in an Array: 
        /// Given an array nums of n integers where nums[i] is in the range [1, n], 
        /// return an array of all the integers in the range [1, n] that do not appear in nums.
        /// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
        /// </summary>
        /// <param name="nums">Integer Input Array</param>
        /// <returns>List of numbers which does not appear in input </returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            for (int i = 0; i < nums.Length; i++)
            {
                //Value as index.
                int newIndex = Math.Abs(nums[i]) - 1;

                if (newIndex > nums.Length)
                    return null;

                //Mark visited index as negative
                if (nums[newIndex] > 0)
                {
                    nums[newIndex] *= -1;
                }
            }

            //Result array containing missing numbers
            var result = new List<int>();

            //Iterate over the array and add positive number index to result array
            for (int i = 1; i <= nums.Length; i++)
            {
                if (nums[i - 1] > 0)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        /// <summary>
        /// Reverse Words in a String III: Given a string s, reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.
        /// https://leetcode.com/problems/reverse-words-in-a-string-iii/
        /// </summary>
        /// <param name="s">String Input</param>
        /// <returns>Reversed string</returns>
        public string ReverseWords(string s)
        {
            var charArr = s.ToCharArray();
            int start = 0;
            int end = 0;

            for (; end < charArr.Length; end++)
            {
                if (charArr[end] == ' ')
                {
                    ReverseText(charArr, start, end - 1);
                    start = end + 1;
                }

            }
            ReverseText(charArr, start, end - 1);

            return new string(charArr);
        }
        /// <summary>
        /// Function to reverse the character array by index
        /// </summary>
        /// <param name="c">Character Array</param>
        /// <param name="start">Start index</param>
        /// <param name="end">End index</param>
        private void ReverseText(char[] c, int start, int end)
        {
            while (start < end)
            {
                char tmp = c[end];
                c[end] = c[start];
                c[start] = tmp;
                start++;
                end--;
            }
        }

        /// <summary>
        /// Symmetric Tree: Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
        /// https://leetcode.com/problems/symmetric-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="subRoot"></param>
        /// <returns></returns>
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null)
                return false;

            if (IsSameTree(root, subRoot))
                return true;

            return IsSubtree(root.Left, subRoot) || IsSubtree(root.Right, subRoot);
        }

        /// <summary>
        /// Same Tree: Given the roots of two binary trees p and q, write a function to check if they are the same or not.
        /// Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
        /// https://leetcode.com/problems/same-tree/
        /// </summary>
        /// <param name="p">Tree A</param>
        /// <param name="q">Tree B</param>
        /// <returns>Computes and returns if both the trees are same. </returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if (p == null || q == null)
                return false;

            if (p.val == q.val)
            {
                return IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);
            }

            return false;
        }

        /// <summary>
        /// Merge Two Binary Trees: You are given two binary trees root1 and root2.
        /// Imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not. You need to merge the two trees into a new binary tree. 
        /// The merge rule is that if two nodes overlap, 
        /// then sum node values up as the new value of the merged node. 
        /// Otherwise, the NOT null node will be used as the node of the new tree.
        /// https://leetcode.com/problems/merge-two-binary-trees/
        /// *ITERATIVE*
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)
                return root2;
            if (root2 == null)
                return root1;

            root1.val += root2.val;
            root1.Left = MergeTrees(root1.Left, root2.Left);
            root1.Right = MergeTrees(root1.Right, root2.Right);

            return root1;
        }

        /// <summary>
        /// Non-decreasing Array: 
        /// Given an array nums with n integers, your task is to check if it could become non-decreasing by modifying at most one element.
        /// We define an array is non-decreasing if nums[i] <= nums[i + 1] holds for every i (0-based) such that (0 <= i <= n - 2).
        /// https://leetcode.com/problems/non-decreasing-array/
        /// </summary>
        /// <param name="nums">Input Array</param>
        /// <returns>Boolean if the array can be converted to non-decreasing array with at most one element modification</returns>
        public bool CheckPossibility(int[] nums)
        {
            int count = 0;

            for (int i = 1; i < nums.Length && count <= 1; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    count++;

                    if (i - 2 < 0 || nums[i - 2] <= nums[i])
                    {
                        nums[i - 1] = nums[i];
                    }
                    else
                    {
                        nums[i] = nums[i - 1];
                    }
                }
            }

            return count <= 1;
        }

        /// <summary>
        /// Trim a Binary Search Tree: 
        /// Given the root of a binary search tree and the lowest and highest boundaries as low and high, trim the tree so that all its elements lies in [low, high]. 
        /// Trimming the tree should not change the relative structure of the elements that will remain in the tree (i.e., any node's descendant should remain a descendant). 
        /// It can be proven that there is a unique answer.
        /// Return the root of the trimmed binary search tree.Note that the root may change depending on the given bounds.
        /// https://leetcode.com/problems/trim-a-binary-search-tree/
        /// </summary>
        /// <param name="root">Root of the tree</param>
        /// <param name="low">Low Index</param>
        /// <param name="high">High Index</param>
        /// <returns>Trimmed Tree</returns>
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return root;

            //Range [ low, high ] is present at the left of the root, so we need to call TrimBST(root.Left, low, high)
            if (root.val > high)
                return TrimBST(root.Left, low, high);

            //Range[low, high] is present at the right of the root, so we need to call TrimBST(root.Right, low, high)
            if (root.val < low)
                return TrimBST(root.Right, low, high);

            //Range[low, high] contains the root ,
            //So find the left and right subtree by recursively calling TrimBST(root.Left, low, high) and trimBST(root.Right, low, high) respectively
            root.Left = TrimBST(root.Left, low, high);
            root.Right = TrimBST(root.Right, low, high);

            return root;
        }

        /// <summary>
        /// Longest Continuous Increasing Subsequence:
        /// Given an unsorted array of integers nums, return the length of the longest continuous increasing subsequence (i.e. subarray). 
        /// The subsequence must be strictly increasing.
        /// A continuous increasing subsequence is defined by two indices 
        /// l and r (l < r) such that it is [nums[l], nums[l + 1], ..., nums[r - 1], nums[r]] and for each l <= i < r, nums[i] < nums[i + 1].
        /// https://leetcode.com/problems/longest-continuous-increasing-subsequence/
        /// Sliding Window Approach
        /// </summary>
        /// <param name="nums">Nums Array</param>
        /// <returns>Longest subsequence count</returns>
        public int FindLengthOfLCIS(int[] nums)
        {
            int result = 0;
            int start = 0;

            for (int end = 0; end < nums.Length; end++)
            {
                if (end > 0 && nums[end - 1] >= nums[end])
                    start = end;

                result = Math.Max(result, end - start + 1);
            }

            return result;
        }

        /// <summary>
        /// N-ary Tree Preorder Traversal: 
        /// Given the root of an n-ary tree, return the preorder traversal of its nodes' values.
        /// Nary-Tree input serialization is represented in their level order traversal. 
        /// Each group of children is separated by the null value
        /// https://leetcode.com/problems/n-ary-tree-preorder-traversal/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(NTreeNode root)
        {
            if (root == null)
                return new List<int>();

            var resultList = new List<int>();
            var stack = new Stack<NTreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                root = stack.Pop();

                resultList.Add(root.val);

                for (int i = root.children.Count - 1; i >= 0; i--)
                {
                    stack.Push(root.children[i]);
                }
            }

            return resultList;
        }

        #endregion
    }
}
