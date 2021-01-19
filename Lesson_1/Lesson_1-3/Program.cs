using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1_3
{
    class Program
    {
        static int FibonachiRecursion(int n) //рекурсия
        {
            if (n <= 1)
                return n;
            else
                return FibonachiRecursion(n - 1) + FibonachiRecursion(n - 2);
        }

        static int FibonachiCycle(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            else
            {
                int sum = 0;
                int f1 = 1;
                int f2 = 1;
                for (int i = 2; i < n; i++)
                {
                    sum = f1 + f2;
                    f1 = f2;
                    f2 = sum;
                }
                return sum;
            }
            
        }

        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"FibonachiRecursion({number}) = {FibonachiRecursion(number)}");
            Console.WriteLine($"FibonachiCycle({number}) = {FibonachiCycle(number)}");
            Console.ReadLine();
        }

    }
}
