using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CTCI.CH1
{
    public class Chapter1
    {   
        // Qn1: Implement an algorithm to determine if a string has all unique characters. 
        // What if you cannot use additional data structures
        // abca abcd
        public bool IsUnique(string s)
        {
            // Brute Force O(n^2)
            for(int i=0; i<s.Length; i++)
            {
                for(int j=i+1; j<s.Length; j++)
                {
                    if(s[i] == s[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsUnique1(string s)
        {
            // Sort (O(nlogn)
            Array.Sort(s.ToCharArray());
            for(int i = 0; i < s.Length-1; i++)
            {
                if(s[i] == s[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsUnique2(string s)
        {
            // Use hashmap O(1) time O(s) space
            HashSet<char> hs = new HashSet<char>();
            for(int i = 0; i< s.Length; i++)
            {
                if (!hs.Contains(s[i]))
                {
                    hs.Add(s[i]);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        // Qn2: Given two strings, write a method to decide if one is a permutation of of the other
        // abcd bcda {a:1, b:1, c:1, d:1} , {}
        // abc cdg
        public bool CheckPermutation(string s1, string s2)
        {
            int n = s1.Length;
            int k = s2.Length;

            if (n > k || k > n)
                return false;

            s1 = sortString(s1);
            s2 = sortString(s2);

            return s1 == s2;
        }

        public string sortString(string s1){
            var charArr = s1.ToCharArray();
            Array.Sort(charArr);
            return new string(charArr);
        }
        public bool CheckPermulation2(string s1, string s2)
        {
            // Use dict O(1) time O(s) space
            int n = s1.Length;
            int k = s2.Length;
            Dictionary<char,int> dict = new Dictionary<char, int>();

            // one's length is longer than others
            if (n > k || k > n)
                return false;

            for(int i=0; i < n; i++)
            {
                if (!dict.ContainsKey(s1[i]))
                {
                    dict.Add(s1[i],1);
                }
                else
                {;
                    dict[s1[i]] = dict[s1[i]]+1;
                }
            }

            for(int j = 0; j < k; j++)
            {
                if (dict.ContainsKey(s2[j]))
                {
                    int count = dict[s1[j]]-1;
                    if (count == -1)
                        return false;
                    dict[s2[j]] = count;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        // Qn3: Write a method to replace all spaces in a string with '%20'. You may assume that the string has sufficient space
        // At the end to hold the additional characters, and that you are given the true length of the string. 
        // Input: "Mr  John Smith       ", 13
        // Output: "Mr%20John%20Smith"

        public string URLify(string s, int lastChar)
        {
            char[] charArr = s.ToCharArray();
            int lastIndex = lastChar-1;
            for(int i=s.Length-1; i>=0; i--)
            {
                if(charArr[lastIndex] != ' ')
                {
                    charArr[i] = s[lastIndex--];
                }
                else
                {
                    charArr[i--] = '0';
                    charArr[i--] = '2';
                    charArr[i] = '%';
                    lastIndex--;
                }
            }

            return new string(charArr);
        }
        
        // Qn4: Palindrome Permutation: Given a string wrtie a function to check if it is a permutation
        // of a palindrome. A palindrome is a word or phase that is the same forwards and backwards. 
        // A permutation is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words
        // 
        public bool PalindomePermutation(string s)
        {
            s = s.ToLower();

            // Use dict O(1) time O(s) space
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i=0; i<s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict.Add(s[i], 1);
                }
                else
                {
                    dict[s[i]] = dict[s[i]]+1;
                }
            }

            // Check if there is more than one sets of odd integer with respect to each character
            int isOdd = 0;
            foreach (KeyValuePair<char, int> entry in dict)
            {
                if(entry.Value %2 != 0)
                {
                    isOdd++;
                }
            }
            return isOdd <= 1;
        }

        // Qn5: There are three types of edits that can be performed on strings:
        // insert a character, remove a character, or replace a character. 
        //Given two strings, write a function to check if they are one edit( or zero edits) away

        public bool OneAway1(string s1, string s2)
        {
            // Check length
            if (Math.Abs(s1.Length - s2.Length) > 1)
                return false;

            // Get shorter and longer string
            string first = s1.Length < s2.Length ? s1 : s2;
            string seocnd = s1.Length < s2.Length ? s2 : s1;

            int index1 = 0;
            int index2 = 0;
            bool foundDifference = false;
            while(index2 < seocnd.Length && index1 < first.Length)
            {
                if(first[index1] != seocnd[index2])
                {
                    if (foundDifference) return false;
                    foundDifference = true;

                    // on replace move shorter pointer
                    if(first.Length == seocnd.Length)
                    {
                        index1++;
                    }
                }
                // If matching, move shorter pointer
                else
                {
                    index1++;
                }
                index2++;
            }

            return true;    
        }

        // Qn6: Implement a method to perform basic string compression using the counts of repeated characters
        // For eexample, the string aabcccccaaa would become a2b1c5a3. If the "compressed" string would not become smaller 
        // than the original string, your method shuld return the original string. You can assume the string has only uppercase 
        // and lowercase letter
        public string StringCompression(string s1)
        {
            int count = 1;
            StringBuilder sb = new StringBuilder();
            for(int i =0; i< s1.Length-1; i++)
            {
                if(s1[i] == s1[i + 1])
                {
                    count++;
                    continue;
                }
                else
                {
                    sb.Append($"{s1[i]}{count}");
                    count = 0;
                }
            }

            if(sb.ToString().Length > s1.Length)
            {
                return s1;
            }

            return sb.ToString();
        }

        // Qn7: Given an image represented by an NxN matrix, which each pixel in the image is 4 bytes, write a method to rotate the 
        // image by 90 degrees. Can you do this in place?
        public bool RotateMatrix(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length)
                return false;
            int n = matrix.Length;
            for(int layer = 0; layer < n/2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i< last; i++)
                {
                    int offset = i - first;

                    int top = matrix[first][i]; ;

                    // left -> top
                    matrix[first][i] = matrix[last - offset][first];

                    // bottom -> left
                    matrix[last - offset][first] = matrix[last][last - offset];

                    // right -> bottom
                    matrix[last][last - offset] = matrix[i][last];

                    // top -> right
                    matrix[i][last] = top;
                }
            }
            return true;
        }

        // Qn8: Write an algorithm such that if an element is an MxN matrix is 0. Its entire row and column are set to 0
        public void ZeroMatrix(int[][] matrix)
        {
            // O(N^3) worst case

            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j=0; j<matrix[0].Length; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        Nullify(i, j, matrix);
                    }
                }
            }
        }

        public void Nullify(int row, int col, int[][] matrix)
        {
            // Nullify row
            for(int i =0; i < col; i++)
            {
                matrix[row][i] = 0;
            }

            // Nullify col
            for(int j=0; j < row; j++)
            {
                matrix[j][col] = 0;
            }
        }

        public void ZeroMatrix1(int[][] matrix)
        {
            bool[] row = new bool[matrix.Length];
            bool[] col = new bool[matrix[0].Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = true;
                        col[j] = true;
                    }
                }
            }

            for(int i =0; i< row.Length; i++)
            {
                if (row[i])
                {
                    for(int j=0; j< matrix[0].Length; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            for (int i = 0; i < row.Length; i++)
            {
                if (col[i])
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        matrix[j][i] = 0;
                    }
                }
            }
        }

        // Qn9: Assume you have method isSubstring which chekcs if one word is substring of another.
        // Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one 
        // call is Substring
        public bool StringRotation(string s1, string s2)
        {
            int len = s1.Length;
            if(len == s2.Length && len > 0)
            {
                string s1s1 = s1 + s1;
                //return isSubstring(s1s1, s2);
            }
            return false;
        }

    }
}
