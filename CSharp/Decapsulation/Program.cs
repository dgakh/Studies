using System;
using System.Collections.Generic;
using System.Text;

namespace btest_classdecomp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (IntPtr.Size == 4)
                Console.WriteLine("Run as x86");
            else
                Console.WriteLine("Run as x64");

            for (int i = 0; i < 5; i++)
            {
                level1.Tester.doTest();
                level2.Tester.doTest();
                level3.Tester.doTest();
            }
        }
    }
}
