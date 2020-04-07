using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7.整数反转
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"123,结果：{Reverse(123)}");
            Console.WriteLine($"-123,结果：{Reverse(-123)}");
            Console.WriteLine($"120,结果：{Reverse(120)}");
            Console.ReadLine();
        }
        public static int Reverse(int x)
        {
            string numStr = "";
            bool isPositive = true;
            if (x > 0)
            {
                isPositive = true;
                numStr = x.ToString();
            }
            else
            {
                isPositive = false;
                numStr = x.ToString().Substring(1);
            }
            numStr =string.Join("" ,numStr.Reverse());

            int resultNum;
            if (!int.TryParse(numStr, out resultNum))
            {
                resultNum = 0;
            }

            if (!isPositive)
            {
                resultNum = 0 - resultNum;
            }
            return resultNum;
        }
    }
}
