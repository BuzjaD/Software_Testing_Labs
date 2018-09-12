using System;
//Some comment

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine("Operations list:\n+ - addition\n- - subtration\n* - multiplication\n/ - devision\n= - show result\nr - reset buffer\nq-exit\n");
            while (true)
            {
                try
                {
                    Console.WriteLine("Buffer = " + calc.ShowBuffer());
                    bool check = calc.checkBuf();
                    if (!check)
                    {
                        Console.WriteLine("Enter number:");
                        double a = Convert.ToDouble(Console.ReadLine());
                        calc.putToBuf(a);
                    }
                    Console.WriteLine("Enter operation:");
                    Char oper = Convert.ToChar(Console.ReadLine());
                    if (oper == '=')
                    {
                        calc.ShowResult();
                    }
                    else if (oper == 'r')
                    {
                        calc.Reset();
                    }
                    else if (oper == 'q')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter number:");
                        double b = Convert.ToDouble(Console.ReadLine());
                        calc.ChooseOper(oper, b);
                    }
                }
                catch
                {
                    Console.WriteLine("Error!!! Uncorrect number or operation");
                }
            }
        }
    }
}
