using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    static class Helper
    {
        public static bool IsPrime(long number)
        {
            if(number == 2 || number == 3 || number == 5)
            {
                return true;
            }
            if(number % 2 == 0)
            {
                return false;
            }
            if(number % 5 == 0)
            {
                return false;
            }

            int sum = 0;
            foreach(char num in number.ToString())
            {
                sum += int.Parse($"{num}");
            }
            if(sum % 3 == 0)
            {
                return false;
            }

            long halfNum = number / 2;
            for (int i = 7; i <= halfNum; i+=2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static int CharacterCount(this string str, char character)
        {
            string toTest = str;
            int count = 0;
            while(true)
            {
                int testIndex = toTest.IndexOf(character) + 1;
                if (testIndex == 0)
                {
                    return count;
                }
                else
                {
                    ++count;
                    toTest = toTest.Substring(testIndex, toTest.Length - testIndex);
                }
            }
        }

        public static bool[] MakeSieve(int max)
        {
            // Make an array indicating whether numbers are prime.
            bool[] is_prime = new bool[max + 1];
            for (int i = 2; i <= max; i++)
            {
                is_prime[i] = true;
            }

            // Cross out multiples.
            for (int i = 2; i <= max; i++)
            {
                // See if i is prime.
                if (is_prime[i])
                {
                    // Knock out multiples of i.
                    for (int j = i * 2; j <= max; j += i)
                    {
                        is_prime[j] = false;
                    }
                }
            }
            return is_prime;
        }
    }
}
