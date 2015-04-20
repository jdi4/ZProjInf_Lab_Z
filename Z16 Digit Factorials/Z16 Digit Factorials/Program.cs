using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z16_Digit_Factorials
{
    class Program
    {
        private static int[] calculated_factorials = new int[10];
        private const int max_upper_bound = 1854721; // from wikipedia
        
        static void Main(string[] args)
        {
            for (int i = 0 ; i < 10 ; i++)
            {
                calculated_factorials[i] = CalculateFactorial(i);
            }

            Console.WriteLine("Suma znalezionych liczb: {0}", FindSumOfFactorions(10, max_upper_bound).ToString());

            Console.ReadKey();
        }

        public static int FindSumOfFactorions(int left_bound, int right_bound)
        {
            int sum_of_factorions = 0;

            for (int i = left_bound; i <= right_bound; i++)
            {
                int sum = CalculateSumOfFactorialsOfNumber(i);

                if (sum == i)
                {
                    sum_of_factorions += i;
                }
            }

            return sum_of_factorions;
        }
        
        public static int CalculateSumOfFactorialsOfNumber(int number)
        {
                int sum = 0;
                int[] number_digits = SplitNumberIntoDigits(number);

                foreach (int d in number_digits)
                {
                    sum += calculated_factorials[d];
                }
                
                return sum;
        }

        public static int[] SplitNumberIntoDigits(int number)
        {
            int[] digits_array = new int[CountNumberOfDigitsInNumber(number)];

            for (int i = digits_array.Length - 1; i > -1; i--)
            {
                digits_array[i] = number % 10;
                number /= 10;
            }

            return digits_array;
        }

        private static int CountNumberOfDigitsInNumber(int number)
        {
            int number_of_digits = 0;

            do
            {
                number_of_digits++;
                number /= 10;
            } while (number != 0);

            return number_of_digits;
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
    }
}
