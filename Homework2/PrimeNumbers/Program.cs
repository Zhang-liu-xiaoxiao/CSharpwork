using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input a number");
            Console.WriteLine();
            int number = 0;
            number = Convert.ToInt32 (Console.ReadLine());
            for(int i=2;i<=number/2;i++)
            {
                if(number%i==0)
                {
                    bool isPrime = true;
                    for (int j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0)
                            isPrime = false;
                    }
                    if(isPrime)
                        Console.WriteLine(i);
                }
            }
        }
    }
}
