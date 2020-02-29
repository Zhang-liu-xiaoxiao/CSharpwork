using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AishiSiftForPrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            int []a = new int[101];
            int i, j;
            for (i = 2; i <= 100; i++)
                a[i] = 1;
            a[1] = 0;
            for (i = 2; i <= 100; i++)
            {
                if (a[i] != 0)
                {
                    for (j = i + i; j <=100; j += i)
                        a[j] = 0;
                }
            }
            for (int k = 2; k <= 100; k++)
            {
                if(a[k]!=0)
                    Console.WriteLine($"{k}");
            }
        }
    }
}
