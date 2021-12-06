using Praxis.Contracts;
using Praxis.Core;
using Praxis.Core.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Praxis.Library
{
    /// <summary>
    /// This class contains solution for all the important LC Blind Curated questions.
    /// https://leetcode.com/list?selectedList=51cpy4pm
    /// </summary>
    public class LCBlind : IProblem
    {
        const int _numberLimit = 10;
        static object _monitor = new object();

        public void Run()
        {
            TwoSum();
            LengthOfLongestSubstring();
            LongestPalindrome();
            TwoSumII();
            ThreeSum();
            RemoveNthFromEnd();
            IsValidParenthesis();
            MergeTwoLists();
            SubdomainVisits();
            SearchRotatedArray();
            FindContiguousUrl();
            GameOfLife();
            PrintOddEvenFromTwoThreads();
            IPAddressValidation();
        }

        #region Caller Methods
        public void TwoSum()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var target = 26;
            var twoSumArr = new int[] { 2, 7, 11, 15 };
            Console.WriteLine($"--Input: {string.Join(",", twoSumArr)}");
            Console.WriteLine($"--Target: {target}");
            Console.WriteLine($"--Output Index: {string.Join(",", TwoSum(twoSumArr, target))}");
            Console.WriteLine($"--Output Values: {string.Join(",", TwoSumValues(twoSumArr, target))}");
            Helper.InsertBlankSep();
        }

        public void LengthOfLongestSubstring()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = "abcabcbb";
            Console.WriteLine($"--Input: {input}");
            Console.WriteLine($"--Longest Substring: {LengthOfLongestSubstring(input)}");
            Helper.InsertBlankSep();
        }

        public void LongestPalindrome()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = "babad";
            Console.WriteLine($"--Input: {input}");
            Console.WriteLine($"--Longest Palindrome: {LongestPalindrome(input)}");
            Helper.InsertBlankSep();
        }

        public void TwoSumII()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var target = 9;
            var twoSumArr = new int[] { 2, 7, 11, 15 };
            Console.WriteLine($"--Input: {string.Join(",", twoSumArr)}");
            Console.WriteLine($"--Target: {target}");
            Console.WriteLine($"--Output Index: {string.Join(",", TwoSumII(twoSumArr, target))}");
            Helper.InsertBlankSep();
        }

        public void ThreeSum()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var threeSumArr = new int[] { -1, 0, 1, 2, -1, -4 };
            Console.WriteLine($"--Input: {string.Join(",", threeSumArr)}");
            var result = ThreeSum(threeSumArr);

            foreach (var item in result)
            {
                Console.WriteLine($"--Output: {string.Join(",", item)}");
            }

            Helper.InsertBlankSep();
        }

        public void RemoveNthFromEnd()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var inputList = new CustomLinkedList<int>();
            var headNode = new ListNode<int>()
            {
                Data = 1,
                NextNode = new ListNode<int>()
                {
                    Data = 2,
                    NextNode = new ListNode<int>()
                    {
                        Data = 3,
                        NextNode = new ListNode<int>()
                        {
                            Data = 4,
                            NextNode = new ListNode<int>()
                            {
                                Data = 5,
                                NextNode = new ListNode<int>()
                            }
                        }
                    }
                }
            };
            inputList.SetHeadNode(headNode);

            Console.Write($"--Input:");
            inputList.PrintList();
            Helper.InsertBlankSep();
            var removeIndex = 2;
            Console.WriteLine($"--Remove Index: {removeIndex}");
            RemoveNthFromEnd(inputList, removeIndex);
            Console.Write($"--Output:");
            inputList.PrintList();
            Helper.InsertBlankSep(2);
        }

        public void IsValidParenthesis()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = "()[]{}";
            Console.WriteLine($"--Input: {input}");
            Console.WriteLine($"--Valid Parenthesis: {IsValidParenthesis(input)}");
            input = "([)]";
            Console.WriteLine($"--Input: {input}");
            Console.WriteLine($"--Valid Parenthesis: {IsValidParenthesis(input)}");
            Helper.InsertBlankSep();
        }

        public void MergeTwoLists()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var l1 = new ListNode<int>()
            {
                Data = 1,
                NextNode = new ListNode<int>()
                {
                    Data = 2,
                    NextNode = new ListNode<int>()
                    {
                        Data = 4,
                        NextNode = null
                    }
                }
            };

            Console.Write($"--Input L1: ");
            l1.PrintNode();
            Helper.InsertBlankSep();

            var l2 = new ListNode<int>()
            {
                Data = 1,
                NextNode = new ListNode<int>()
                {
                    Data = 3,
                    NextNode = new ListNode<int>()
                    {
                        Data = 4,
                        NextNode = null
                    }
                }
            };

            Console.Write($"--Input L2: ");
            l2.PrintNode();
            Helper.InsertBlankSep();

            var mergedResult = MergeTwoLists(l1, l2);

            Console.Write("--Merged Output: ");
            mergedResult.PrintList();
            Helper.InsertBlankSep(2);
        }

        public void SubdomainVisits()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new string[] { "900 google.mail.com", "50 yahoo.com", "5 wiki.org" };
            Console.WriteLine($"--Input: {string.Join(",", input)}");
            Console.WriteLine($"--Output: {string.Join(",", SubdomainVisits(input)) }");
            Helper.InsertBlankSep();
        }

        public static void FindContiguousUrl()
        {
            string[] user0 = { "/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two" };
            string[] user1 = { "/start", "/pink", "/register", "/orange", "/red", "a" };
            string[] user2 = { "a", "/one", "/two" };
            string[] user3 = {"/pink", "/orange", "/yellow", "/plum", "/blue", "/tan", "/red", "/amber", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow", "/BritishRacingGreen"};
            string[] user4 = { "/pink", "/orange", "/amber", "/BritishRacingGreen", "/plum", "/blue", "/tan", "/red", "/lavender", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow" };
            string[] user5 = { "a" };
            string[] user6 = { "/pink", "/orange", "/six", "/plum", "/seven", "/tan", "/red", "/amber" };

            FindContiguousHistory(user0, user1); //=> ["/pink", "/register", "/orange"]
            FindContiguousHistory(user0, user2); //=> [] (empty)
            FindContiguousHistory(user0, user0); //=> ["/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two"]
            FindContiguousHistory(user2, user1); //=> ["a"] 
            FindContiguousHistory(user5, user2); //=> ["a"]
            FindContiguousHistory(user3, user4); //=> ["/plum", "/blue", "/tan", "/red"]
            FindContiguousHistory(user4, user3); //=> ["/plum", "/blue", "/tan", "/red"]
            FindContiguousHistory(user3, user6); //=> ["/tan", "/red", "/amber"]
        }

        public static void FindContiguousHistory(string[] userA, string[] userB)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Input UserA: ");
            Console.WriteLine($"[{string.Join(",", userA)}]");
            Console.WriteLine("Input UserB: ");
            Console.WriteLine($"[{string.Join(",", userB)}]");

            var resultData = FindContiguousHistoryProcess(userA, userB);

            Console.WriteLine("Output (Contiguous History): ");
            Console.WriteLine($"[{string.Join(",", resultData)}]");
            Console.WriteLine("===========================================");
        }

        public void SearchRotatedArray()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            var target = 7;
            Console.WriteLine($"--Input: {string.Join(",", input)}");
            Console.WriteLine($"--Target: {target}");
            Console.WriteLine($"--Output Index: {SearchRotatedArray(input, target)}");
            target = 3;
            Console.WriteLine($"--Target: {target}");
            Console.WriteLine($"--Output Index: {SearchRotatedArray(input, target)}");
            Helper.InsertBlankSep();
        }

        public void GameOfLife()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = Helper.RandomMatrix2D(4,3,0,1);
            Console.WriteLine("Input:");
            Helper.PrintMatrix(input);
            GameOfLife(input);
            Console.WriteLine("Output: ");
            Helper.PrintMatrix(input);
        }

        public void PrintOddEvenFromTwoThreads()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            Console.WriteLine($"--Input: {_numberLimit}");

            Thread oddThread = new Thread(Odd);
            Thread evenThread = new Thread(Even);
            Console.Write($"--Output: ");

            //Start even thread.
            evenThread.Start();

            //puase for 10 ms, to make sure even thread has started
            //or else odd thread may start first resulting other sequence.
            Thread.Sleep(100);

            //Start odd thread.
            oddThread.Start();

            oddThread.Join();
            evenThread.Join();

            Helper.InsertBlankSep();
        }

        public static void IPAddressValidation()
        {
            var fileData = new List<string>();
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");

            fileData.Add("2021-08-11 12:15:01 This is a line of text in the log file.");
            fileData.Add("2021-08-11 12:16:01 This is a line of text that has an IP 73.67.200.201 Address");
            fileData.Add("2021-08-11 12:17:01 This is a line of text in the log file");
            fileData.Add("2021-08-11 12:16:01 This is a line of text with an IP address of 71.60.210.64 (unknown user)");
            fileData.Add("2021-08-11 12:17:01 This is a line of text in the log file");

            var stringResult = new StringBuilder();
            Console.WriteLine($"--Input: ");

            fileData.ForEach(line => 
            {
                Console.WriteLine(line);
                
                line.Split(" ").ToList().ForEach(word => 
                { 
                    if(word.Split(".").Length == 4 && IsValidIPAddress(word)) 
                        stringResult.Append(word + Environment.NewLine);    
                });
                
            });

            Console.WriteLine("--Output: ");
            Console.WriteLine(stringResult.ToString());
            Helper.InsertBlankSep();
        }

        #endregion

        #region Implementation Methods

        /// <summary>
        /// Two Sum:
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// Approach: Hashmap to find complement values.
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums">Input Array</param>
        /// <param name="target">Target addition</param>
        /// <returns>Indexes of values which add up to target</returns>
        public int[] TwoSum(int[] nums, int target)
        {
            var hash = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (hash.ContainsKey(complement))
                {
                    return new int[] { hash[complement], i };
                }

                hash.Add(nums[i], i);
            }

            return null;
        }

        /// <summary>
        /// Two Sum Values:
        /// Given an array of integers nums and an integer target, return the two numbers such that they add up to target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// Variation of https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums">Input Array</param>
        /// <param name="target">Target addition</param>
        /// <returns>Values which add up to target</returns>
        public int[] TwoSumValues(int[] nums, int target)
        {
            var hash = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (hash.ContainsKey(complement))
                {
                    return new int[] { complement, nums[i] };
                }

                hash.Add(nums[i], i);
            }

            return null;
        }

        /// <summary>
        /// Longest Substring Without Repeating Characters:
        /// Given a string s, find the length of the longest substring without repeating characters.
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// Approach: Slinding Window Technique
        /// </summary>
        /// <param name="s">Random String</param>
        /// <returns>Length of longest sub string</returns>
        public int LengthOfLongestSubstring(string s)
        {
            int sPtr = 0;
            int fPtr = 0;
            int max = 0;

            var bag = new HashSet<char>();

            while (fPtr < s.Length)
            {
                if (!bag.Contains(s[fPtr]))
                {
                    bag.Add(s[fPtr]);
                    fPtr++;
                    max = Math.Max(bag.Count, max);
                }
                else
                {
                    bag.Remove(s[sPtr]);
                    sPtr++;
                }
            }

            return max;
        }

        /// <summary>
        /// Longest Palindromic Substring:
        /// Given a string s, return the longest palindromic substring in s.
        /// https://leetcode.com/problems/longest-palindromic-substring/
        /// Approach: Set an odd and even center at i, then expand it with requirement of palindrome.
        /// </summary>
        /// <param name="s">Input String</param>
        /// <returns>Longest Palindrome Substring</returns>
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            var result = string.Empty;
            var resultLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var odd = ExpandAroundCenter(s, i, i);

                if (odd.Length > resultLen)
                {
                    resultLen = odd.Length;
                    result = odd;
                }

                var even = ExpandAroundCenter(s, i, i + 1);
                if (even.Length > resultLen)
                {
                    resultLen = even.Length;
                    result = even;
                }
            }

            return result;
        }

        private string ExpandAroundCenter(string s, int left, int right)
        {
            int l = left;
            int r = right;

            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }

            return s.Substring(l + 1, r - l - 1);
        }

        /// <summary>
        /// Two Sum II - Input array is sorted:
        /// Given an array of integers numbers that is already sorted in non-decreasing order, 
        /// find two numbers such that they add up to a specific target number.
        /// Return the indices of the two numbers (1-indexed) as an integer array answer of size 2, 
        /// where 1 <= answer[0] < answer[1] <= numbers.length.
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        /// </summary>
        /// <param name="numbers">Sorted Array</param>
        /// <param name="target">Target Sum</param>
        /// <returns>Number indices which totals to Target</returns>
        public int[] TwoSumII(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length - 1;

            while (numbers[l] + numbers[r] != target)
            {
                if (numbers[l] + numbers[r] > target) r--;
                else l++;

                if (r == l) return new int[] { -1, -1 };
            }

            return new int[] { l + 1, r + 1 };
        }

        /// <summary>
        /// 3Sum: 
        /// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] 
        /// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
        /// Notice that the solution set must not contain duplicate triplets.
        /// https://leetcode.com/problems/3sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var resultSet = new HashSet<List<int>>();
            var duplicateBag = new HashSet<int>();
            var seenMap = new Dictionary<int, int>();
            List<int> triplets;

            for (int i = 0; i < nums.Length; i++)
            {
                if (duplicateBag.Add(nums[i]))
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        var complement = -nums[i] - nums[j];

                        if (seenMap.ContainsKey(complement) && seenMap[complement] == i)
                        {
                            triplets = new List<int>()
                            {
                                nums[i],
                                nums[j],
                                complement
                            };

                            triplets.Sort();

                            if (!resultSet.Contains(triplets))
                                resultSet.Add(triplets);
                        }

                        if (!seenMap.ContainsKey(nums[j]))
                            seenMap.Add(nums[j], i);
                        else
                            seenMap[nums[j]] = i;
                    }
                }
            }

            var updatedList = Helper.FindDistinctWithoutLinq(resultSet.ToList());

            return updatedList.ToList().Cast<IList<int>>().ToList();
        }

        /// <summary>
        /// Remove Nth Node From End of List:
        /// Given the head of a linked list, remove the nth node from the end of the list and return its head.
        /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public CustomLinkedList<int> RemoveNthFromEnd(CustomLinkedList<int> head, int n)
        {
            var headNode = head.GetHeadNode();

            var temp = new ListNode<int>
            {
                Data = 0,
                NextNode = headNode
            };

            ListNode<int> first = temp;
            ListNode<int> second = temp;

            for (int i = 1; i <= n + 1; i++)
            {
                first = first.NextNode;
            }

            while (first != null)
            {
                first = first.NextNode;
                second = second.NextNode;
            }

            second.NextNode = second.NextNode.NextNode;

            head.SetHeadNode(temp.NextNode);

            return head;
        }

        /// <summary>
        /// Valid Parentheses:
        /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        /// An input string is valid if:
        /// Open brackets must be closed by the same type of brackets.
        /// Open brackets must be closed in the correct order.
        /// https://leetcode.com/problems/valid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValidParenthesis(string s)
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
                var curr = s[i];

                if (_bracMap.ContainsKey(curr))
                {
                    var top = bracBag.Count <= 0 ? '#' : bracBag.Pop();

                    if (top != _bracMap[curr])
                    {
                        return false;
                    }
                }
                else
                {
                    bracBag.Push(curr);
                }
            }

            return bracBag.Count <= 0;
        }

        /// <summary>
        /// Merge Two Sorted Lists:
        /// Merge two sorted linked lists and return it as a sorted list. 
        /// The list should be made by splicing together the nodes of the first two lists.
        /// https://leetcode.com/problems/merge-two-sorted-lists/
        /// Approach: Iterative approach
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public CustomLinkedList<int> MergeTwoLists(ListNode<int> l1, ListNode<int> l2)
        {
            var resultList = new CustomLinkedList<int>();
            if (l1 == null)
            {
                resultList.SetHeadNode(l2);
                return resultList;
            }
            if (l2 == null)
            {
                resultList.SetHeadNode(l1);
                return resultList;
            }

            var preHead = new ListNode<int>() { Data = -1 };

            ListNode<int> prev = preHead;

            while (l1 != null && l2 != null)
            {
                if (l1.Data < l2.Data)
                {
                    prev.NextNode = l1;
                    l1 = l1.NextNode;
                }
                else
                {
                    prev.NextNode = l2;
                    l2 = l2.NextNode;
                }
                prev = prev.NextNode;
            }

            prev.NextNode = l1 ?? l2;

            resultList.SetHeadNode(preHead.NextNode);

            return resultList;
        }

        /// <summary>
        /// Subdomain Visit Count
        /// https://leetcode.com/problems/subdomain-visit-count/
        /// </summary>
        /// <param name="cpdomains">Count paired domains array</param>
        /// <returns>Count paired domains of each sub domain</returns>
        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            if (cpdomains.Length <= 0)
                return null;

            var resultList = new List<string>();
            var countMap = new Dictionary<string, int>();

            foreach (var domain in cpdomains)
            {
                var index = domain.IndexOf(' ');
                int ct = Convert.ToInt32(domain.Substring(0, index));
                var domStr = domain.Substring(index + 1);

                for (int i = 0; i < domStr.Length; i++)
                {
                    if(domStr[i] == '.')
                    {
                        var d = domStr.Substring(i + 1);
                        if (countMap.ContainsKey(d))
                        {
                            countMap[d] = countMap.GetValueOrDefault(d, 0) + ct;
                        }
                        else
                        {
                            countMap.Add(d, countMap.GetValueOrDefault(d, 0) + ct);
                        }
                    }
                }
                
                countMap.Add(domStr, countMap.GetValueOrDefault(domain, 0) + ct);
            }

            foreach (var item in countMap)
            {
                resultList.Add($"{item.Value} {item.Key}");
            }


            return resultList;
        }

        /// <summary>
        /// Parents and Children:
        /// Input data describing a graph of relationships between parents and children over multiple generations. 
        /// The data is formatted as a list of (parent, child) pairs, where each individual is assigned a unique integer identifier.
        /// Write a function that takes the graph, as well as two of the individuals in our dataset, as its inputs and returns true if and only if they share at least one ancestor.
        /// </summary>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public List<List<int>> FindParents(int[][] pairs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search element in a Rotated Sorted Array
        /// Approach: Modified Binary Search
        /// Initiate the pointer start to 0, and the pointer end to n - 1.
        /// Perform standard binary search
        ///     Pivot element is larger than the first element in the array, i.e. the subarray from the first element to the pivot is non-rotated.
        ///     Pivot element is smaller than the first element of the array, i.e. the rotation index is somewhere between 0 and mid. It implies that the sub-array from the pivot element to the last one is non-rotated.
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/
        /// </summary>
        /// <param name="nums">Input rotated sorted array</param>
        /// <param name="target">Target to search</param>
        /// <returns></returns>
        public int SearchRotatedArray(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if(nums[mid] > nums[left])
                {
                    if (target >= nums[left] && target <= nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (target <= nums[right] && target >= nums[mid])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// We have some clickstream data that we gathered on our client's website. 
        /// Using cookies, we collected snippets of users' anonymized URL histories while they browsed the site. 
        /// The histories are in chronological order, and no URL was visited more than once per person.
        /// 
        /// Write a function that takes two users' browsing histories as input and returns the longest contiguous sequence of URLs that appears in both.
        /// 
        /// Sample input:
        /// user0 = ["/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two"]
        /// user1 = ["/start", "/pink", "/register", "/orange", "/red", "a"]
        /// user2 = ["a", "/one", "/two"]
        /// user3 = ["/pink", "/orange", "/yellow", "/plum", "/blue", "/tan", "/red", "/amber", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow", "/BritishRacingGreen"]
        /// user4 = ["/pink", "/orange", "/amber", "/BritishRacingGreen", "/plum", "/blue", "/tan", "/red", "/lavender", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow"]
        /// user5 = ["a"]
        /// user6 = ["/pink","/orange","/six","/plum","/seven","/tan","/red", "/amber"]
        /// 
        /// Output:
        /// findContiguousHistory(user0, user1) => ["/pink", "/register", "/orange"]
        /// findContiguousHistory(user0, user2) => [] (empty)
        /// findContiguousHistory(user0, user0) => ["/start", "/green", "/blue", "/pink", "/register", "/orange", "/one/two"]
        /// findContiguousHistory(user2, user1) => ["a"] 
        /// findContiguousHistory(user5, user2) => ["a"]
        /// findContiguousHistory(user3, user4) => ["/plum", "/blue", "/tan", "/red"]
        /// findContiguousHistory(user4, user3) => ["/plum", "/blue", "/tan", "/red"]
        /// findContiguousHistory(user3, user6) => ["/tan", "/red", "/amber"]
        /// 
        /// n: length of the first user's browsing history
        /// m: length of the second user's browsing history
        /// </summary>
        /// <param name="user1"></param>
        /// <param name="user2"></param>
        /// <returns></returns>
        public static List<string> FindContiguousHistoryProcess(string[] user1, string[] user2)
        {
            var result = new List<string>();

            int[,] dp = new int[user1.Length + 1, user2.Length + 1];

            int max = 0;
            int end = 0;

            for (int i = user1.Length - 1; i >= 0; i--)
            {
                for (int j = user2.Length - 1; j >= 0; j--)
                {
                    if (user1[i].Equals(user2[j]))
                    {
                        dp[i, j] = 1 + dp[i + 1, j + 1];

                        if (max < dp[i, j])
                        {
                            max = dp[i, j];
                            end = j;
                        }
                        break;
                    }
                }
            }

            for (int i = end; i < end + max; i++)
            {
                result.Add(user2[i]);
            }

            return result;
        }

        /// <summary>
        /// Game of Life: https://leetcode.com/problems/game-of-life/
        /// The board is made up of an m x n grid of cells, where each cell has an initial state: live (represented by a 1) or dead (represented by a 0). 
        /// Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):
        /// Any live cell with fewer than two live neighbors dies as if caused by under-population.
        /// Any live cell with two or three live neighbors lives on to the next generation.
        /// Any live cell with more than three live neighbors dies, as if by over-population.
        /// Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
        /// The next state is created by applying the above rules simultaneously to every cell in the current state, where births and deaths occur simultaneously. 
        /// Given the current state of the m x n grid board, return the next state.
        /// </summary>
        /// <param name="board"></param>
        public void GameOfLife(int[,] board)
        {
            int m = board.GetLength(0);
            int n = board.GetLength(1);
            int[,] nextArr = new int[m, n];
            int[][] dirArr = new int[][]
            {
                new [] { -1, 0 },
                new [] { -1, 1 },
                new [] { 0, 1 },
                new [] { 1, 1 },
                new [] { 1, 0 },
                new [] { 1, -1 },
                new [] { 0, -1 },
                new [] { -1, -1 }
            };

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int liveCount = 0;

                    foreach (var dir in dirArr)
                    {
                        int x = dir[0] + i;
                        int y = dir[1] + j;

                        if(x >= 0 && x < m && y >= 0 && y < n && board[x,y] == 1)
                        {
                            liveCount++;
                        }
                    }

                    if(board[i,j] == 0 && liveCount == 3)
                    {
                        nextArr[i,j] = 1;
                    } 
                    else if(board[i,j] == 1)
                    {
                        if(liveCount == 3 || liveCount == 2)
                        {
                            nextArr[i,j] = 1;
                        }
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i,j] = nextArr[i,j];
                }
            }
        }

        public void Odd()
        {
            try
            {
                //hold lock as console is shared between threads.
                Monitor.Enter(_monitor);

                for (int i = 1; i <= _numberLimit; i = i + 2)
                {
                    //Complete the task (printing odd number on console)
                    Console.Write(" " + i);
                    //Notify other thread - here even thread
                    //that I'm done you do your job
                    Monitor.Pulse(_monitor);

                    //I will wait here till even thread notify me
                    // Monitor.Wait(monitor);

                    // without this logic application will wait forever
                    bool isLast = i == _numberLimit - 1;
                    if (!isLast)
                        Monitor.Wait(_monitor); //I will wait here till even thread notify me
                }
            }
            finally
            {
                //Release lock
                Monitor.Exit(_monitor);
            }
        }

        public void Even()
        {
            try
            {
                //hold lock
                Monitor.Enter(_monitor);
                for (int i = 0; i <= _numberLimit; i = i + 2)
                {
                    //Complete the task (printing even number on console)
                    Console.Write(" " + i);
                    //Notify other thread - here odd thread
                    //that I'm done, you do your job
                    Monitor.Pulse(_monitor);
                    //I will wait here till odd thread notify me
                    // Monitor.Wait(monitor);

                    //Monitors last element
                    bool isLast = i == _numberLimit;
                    if (!isLast)
                        Monitor.Wait(_monitor);
                }
            }
            finally
            {
                //release the lock
                Monitor.Exit(_monitor);
            }

        }

        
        /// <summary>
        /// # write a program that parses a log file looking for IP address
        /// # the log file is a local file on disk with the name "/logs/app.log" or (C:\logs\app.log)
        /// # the contents of the file to parse is:
        /// </summary>
        /// <param name="ipText">Word containing IP Address</param>
        /// <returns>Bool if valid</returns>
        public static bool IsValidIPAddress(string ipText)
        {
            var ipArr = ipText.Split(".");

            if (ipArr.Length != 4)
                return false;

            foreach (var num in ipArr)
            {
                bool isValid = int.TryParse(num, out int k);

                if (isValid)
                {
                    return (k > 0 && k < 255);
                }

                return false;
            }

            return true;
        }

        #endregion
    }
}
