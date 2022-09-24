using System;
using System.Collections.Generic;
using System.Linq;

namespace Собес
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            Console.WriteLine("Enter the 1 word: ");
            var firstW = Console.ReadLine();
            Console.WriteLine("Enter the 2 word: ");
            var sectW = Console.ReadLine();
            sol.isEqual(firstW, sectW);
            Console.ReadLine();
        }

    }

    class Solution 
    {
        public void isEqual(string S, string T) {
            bool isEqual = true;
            var word1 = S.ToCharArray();
            var word2 = T.ToCharArray();
            if (Math.Abs(word1.Length - word2.Length) > 1) {
                Impossible();
            }
            if (word1.Length != word2.Length)
            {
                isEqual = false;
            }
            else
            {
                isEqual = S.Contains(T);
                #region alternative
                //for (int i = 0; i < word1.Length; i++)
                //{
                //    //Console.WriteLine(word1[i]);
                //    for (int j = i; j < i + 1; j++)
                //    {
                //        if (word1[i] != word2[j])
                //        {
                //            isEqual = false;
                //        }
                //    }
                //}
                #endregion
            }
            Console.WriteLine(isEqual == true ? "The words are equal" : "The words are not equal"); 
            if (!isEqual)
            {
                insertStateFromOneToOne(S, T);
            }
        }

        public void insertStateFromOneToOne(string S, string T) {
            char[] word1 = S.ToCharArray();
            char[] word2 = T.ToCharArray();

            List<char> buffer = new List<char>();
            if (word1.Length != word2.Length)
            {
                for (int i = 0; i < word1.Length; i++)
                {
                    if (String.Compare(word1[i].ToString(), word2[i].ToString()) != 0)
                    {
                        buffer.Add(word2[i]);
                        break;
                    }
                }


                foreach (var item in buffer)
                {
                    Console.WriteLine("Insert " + item);
                }
            }
            else {
                Replace(S, T);
            }
          }

        public void Replace(string S,string T)
        {
            char[] word1 = S.ToCharArray();
            char[] word2 = T.ToCharArray();

            List<char> buffer1 = new List<char>();
            List<char> buffer = new List<char>();
            if (S.CompareTo(T) == 1)
            {
                for (int i = 0; i < word1.Length; i++)
                {
                    if (String.Compare(word1[i].ToString(), word2[i].ToString()) != 0)
                    {
                        buffer1.Add(word1[i]);
                        buffer.Add(word2[i]);
                        break;
                    }
                }
                Console.WriteLine("Replace " + buffer[0] + " , " + buffer1[0]);
            }
            else {
                Swap(S, T);
            }
            
        }

        public void Swap(string S, string T) {
            char[] word1 = S.ToCharArray();
            char[] word2 = T.ToCharArray();

            List<char> buffer1 = new List<char>();
            List<char> buffer = new List<char>();

            for (int i = 0; i < word1.Length; i++)
                {
                    if (String.Compare(word1[i].ToString(), word2[i].ToString()) != 0)
                    {
                        buffer1.Add(word1[i]);
                        buffer.Add(word2[i]);
                    }
                }
            buffer.Sort();
            buffer1.Sort();
            var ident = true;
            for (int i = 0; i < buffer.Count; i++)
            {
                if (String.Compare(buffer[i].ToString(), buffer1[i].ToString()) != 0)
                {
                    ident = false;
                }
            }

            if (ident) {
                Console.WriteLine("Swap " + buffer[0] + " , " + buffer1[1]);
            }
            }

        public void Impossible() {
             Console.WriteLine("Impossible");
        }
    }
}
