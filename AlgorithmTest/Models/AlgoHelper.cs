using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest.Models
{
    public class AlgoHelper
    {
        public const int MAX = 256;

        // This function returns true if
        // contents of arr1[] and arr2[]
        // are same, otherwise false.
        public static bool compare(char[] arr1,
        char[] arr2)
        {
            for (int i = 0; i < MAX; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> SearchResult(string s, string p)
        {
            List<int> list = new List<int>();
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p)) return list;
            if (s.Length < p.Length) return list;
            var pMap = new Dictionary<char, int>();
            var sMap = new Dictionary<char, int>();
            foreach (var ch in p) pMap[ch] = pMap.ContainsKey(ch) ? pMap[ch] + 1 : 1;
            var queue = new Queue<char>();
            var output = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                queue.Enqueue(s[i]);
                sMap[ch] = sMap.ContainsKey(ch) ? sMap[ch] + 1 : 1;
                if (queue.Count > p.Length)
                {
                    sMap[queue.Dequeue()]--;
                }
                //do not use else if, use if
                if (queue.Count == p.Length)
                {
                    bool isSame = pMap.Keys.All(x => sMap.ContainsKey(x) && sMap[x] == pMap[x]);
                    //do not use else pMap.Length, use p.Length
                    if (isSame) output.Add(i - p.Length + 1);
                }
            }
            return output;
        }

        // This function search for all
        // permutations of pat[] in txt[]
        public static String search(string pat,string txt)
        {
            int M = pat.Length;
            int N = txt.Length;
            String result = "";
            // countP[]: Store count of all
            // characters of pattern
            // countTW[]: Store count of current
            // window of text
            char[] countP = new char[MAX];
            char[] countTW = new char[MAX];
            for (int i = 0; i < M; i++)
            {
                (countP[pat[i]])++;
                (countTW[txt[i]])++;
            }

            // Traverse through remaining
            // characters of pattern
            for (int i = M; i < N; i++)
            {
                // Compare counts of current window
                // of text with counts of pattern[]
                if (compare(countP, countTW))
                {
                    string.Concat(result, " " + (i - M));
                }

            // Add current character to
            // current window
            (countTW[txt[i]])++;

                // Remove the first character of
                // previous window
                countTW[txt[i - M]]--;
            }

            // Check for the last window in text
            if (compare(countP, countTW))
            {
                string.Concat(result, " " + (N - M));
            }

            return result;
        }
    }
}
