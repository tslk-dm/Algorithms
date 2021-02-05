using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_2
{
    class Program
    {
        public static int BinarySearch(int[] inputArray, int searchValue) //сложность log n
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2; ;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if(searchValue < inputArray[mid])
                {
                     max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] array = new int[1000];
            int value = 1;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
                value += 3;

            }

            Console.WriteLine(BinarySearch(array, 169));
            Console.WriteLine(BinarySearch(array, 170));
            Console.ReadLine();
        }
    }
}
