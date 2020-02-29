using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            int result=0;
            while (end == false)
            {
                int firstNum = 0;
                int secondeNum = 0;
                Console.WriteLine("console calculator");
                Console.WriteLine("please input the first operation number");
                try
                {
                    firstNum = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("the input must be a number");
                    continue;
                }
                Console.WriteLine("please first input the second operation number");
                try
                {
                    secondeNum = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("the second input must be a nuber");
                    continue;
                }

                Console.WriteLine("please input + - * / to choose the operation");
                string op;
                op =(Console.ReadLine());
                switch (op)
                {
                    case "+":
                        result = firstNum + secondeNum;
                        break;
                    case "-":
                        result = firstNum - secondeNum;
                        break;
                    case "*":
                        result = firstNum * secondeNum;
                        break;
                    case "/":
                        try
                        {
                            result = firstNum / secondeNum;
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("the second number can't be 0");
                        }
                        break;

                    default:
                        Console.WriteLine("please input the right operation");
                        continue;
                            break;
                }
                Console.WriteLine("the result is {0}",result);
                Console.WriteLine("do you want to continue? if not press c");
                string ifContinue;
                ifContinue = Console.ReadLine();
                if (!ifContinue.Equals("n"))
                    end = true;
                
            }
        }
    }
}
