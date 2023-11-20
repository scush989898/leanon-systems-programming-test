using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Problem
{
    internal class Solution
    {

        static void Main(string[] args)
        {
            string word = "HANNAH";
            //string word = "GAGA";

            bool res = isPalindrome(word);
            Console.WriteLine("IsPalindrome: " + res);
        }

        static bool isPalindrome(string word)
        {
            int length = word.Length;
            int ceilingMiddle = (int)(length / 2.0);


            for (int i = 0; i < ceilingMiddle; i++)
            {
                if (word[i] != word[(length - 1) - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
