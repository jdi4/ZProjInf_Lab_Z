using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z16_Digit_Factorials
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] calculated_factorials = new int[10];
            const int upper_bound = 1854721; // wiki
            int sum_to_find = 0;

            for (int i = 0 ; i < 10 ; i++)
            {
                calculated_factorials[i] = CalculateFactorialRecursively(i);
            }

            // verification
            //int j = 0;
            //foreach (int i in calculated_factorials)
            //{
            //    Console.WriteLine("{0}! = {1}", (j++).ToString(), i.ToString());
            //}

            for (int i = 10; i <= upper_bound; i++)
            {
                int number_part = i;
                int digit; // = part % 10;
                int sum = 0;

                while (number_part > 0)
                {
                    digit = number_part % 10;
                    sum += calculated_factorials[digit];
                    number_part /= 10;
                }

                if (sum == i)
                {
                    sum_to_find += i;
                }

            }

            Console.WriteLine("Suma znalezionych liczb: {0}", sum_to_find.ToString());


            Console.ReadKey();
        }

        /// Public: Calculate factorial of a given number
        ///
        /// number - The number to calculate factorial from.
        ///
        /// Examples
        ///
        ///     CalculateFactorial(4)
        ///     # => 24
        ///     CalculateFactorial(8)
        ///     # => 40320
        ///
        ///    Returns factorial of a given number
        public static int CalculateFactorial(int number)
        {
            int result = 1;
            for (int i = 1 ; i <= number ; i++)
            {
                result *= i;
            }
            return result;
        }

        public static int CalculateFactorialRecursively(int number)
        {
            int result;
            if (number < 2)
            {
                result = 1;
            }
            else
            {
                result = number * FactorialRecursion(number - 1);
            }

            return result;
        }
    }
}
