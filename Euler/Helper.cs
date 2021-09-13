using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

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

        public static bool[] MakePrimeSieve(int max)
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

        public static BigInteger GetFactorial(long number)
        {
            BigInteger fact = 1;
            for (int x = 1; x <= number; x++)
            {
                fact *= x;
            }
            return fact;
        }

        public static string ToEnglishString(this int value)
        {
            string[] ones = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
                    "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = {"null", "null", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
            if (0 <= value && value < 20)
            {
                return ones[value];
            }
            else if(20 <= value && value <= 90 && value % 10 == 0)
            {
                return tens[value / 10];
            }
            else if(20 < value && value < 100)
            {
                return tens[value / 10] + "-" + ones[value % 10];
            }
            else if(100 <= value && value <= 900 && value % 100 == 0)
            {
                return ones[value / 100] + " hundred";
            }
            else if(100 < value && value < 1000)
            {
                return ones[value / 100] + " hundred and " + ToEnglishString(value % 100);
            }
            else if(1000 < value && value < 10000)
            {
                return "Null";
            }
            else if(value == 1000)
            {
                return "one thousand";
            }
            else
            {
                return "Not implemented";
            }
        }

        public static HashSet<int> GetDivisitors(int num)
        {
            HashSet<int> items = new HashSet<int>();
            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    if (num / i == i)
                    {
                        items.Add(i);
                    }
                }
            }

            return items;
        }

        public static string GetAllResourcesText(string fileName)
        {
            const string BasePath = @"..\..\..\..\Resources\";

            try
            {
                return File.ReadAllText($"{BasePath}{fileName}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return "";
        }

        public static BigInteger GetFibonacciAtIndex(int index, List<BigInteger> precalculated = null)
        {
            if(precalculated == null)
            {
                precalculated = new List<BigInteger>(index)
                {
                    1, 1
                };
            }
            else
            {
                if(precalculated.Count <= 0)
                {
                    precalculated = new List<BigInteger>(index)
                    {
                        1, 1
                    };
                }

                if(index < precalculated.Count)
                {
                    return precalculated[index];
                }
                else
                {
                    precalculated.Capacity = index + 1;
                }
            }

            for(int i = 1; i <= index; ++i)
            {
                precalculated.Add(precalculated[i] + precalculated[i - 1]);
            }

            return precalculated[index];
        }
    }
}
