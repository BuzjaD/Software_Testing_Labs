using System;
//Calculator
namespace Calc
{
    class Calculator
    {
        private double buffer;

        public Calculator()
        {
            buffer = 0;
        }

        public bool checkBuf()
        {
            if (this.buffer != 0)
                return true;
            else
                return false;
        }

        public void putToBuf(double a)
        {
            this.buffer = a;
        }

        private void Multiply(double b)
        {
            this.buffer *= b;
        }

        private void Devision(double b)
        {
            this.buffer /= b;
        }

        private void Addition(double b)
        {
            this.buffer += b;
        }

        private void Subtration(double b)
        {
            this.buffer -= b;
        }
        
        public Double ShowBuffer()
        {
            return this.buffer;
        }

        public void ShowResult()
        {
             Console.WriteLine("Result: "+this.buffer);
        }

        public void Reset()
        {
            this.buffer = 0;
        }

        public void ChooseOper(char oper, double b)
        {
            switch (oper)
            {
                case '+':
                    {
                        Addition(b);
                        break;
                    }
                case '-':
                    {
                        Subtration(b);
                        break;
                    }
                case '*':
                    {
                        Multiply(b);
                        break;
                    }
                case '/':
                    {
                        Devision(b);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unknown operation");
                        break;
                    }
            }
        }
    }
}
