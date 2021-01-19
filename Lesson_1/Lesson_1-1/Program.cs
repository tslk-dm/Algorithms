using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int d = 0; 
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                    d++;
                i++;
            }
            if (d == 0)
                Console.WriteLine("Простое");
            else
                Console.WriteLine("Не простое");

            Console.ReadLine();
        }
    }
}
