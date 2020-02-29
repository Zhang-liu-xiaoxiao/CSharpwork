using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = { 124,12,24, 5246, 234, 125,6748,57,32 };
            double max = a[0];
            double min = a[0];
            int count = 0;
            double sum = 0;
            foreach(double number in a)
            {
                if (number > max)
                    max = number;
                if (number < min)
                    min = number;
                count++;
                sum += number;
            }
            double even = sum / count;

            Console.WriteLine($"the max is {max}");
            Console.WriteLine($"the min is {min}");
            Console.WriteLine($"the even is {even}");


        }
    }
}
