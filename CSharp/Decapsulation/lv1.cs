using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace btest_classdecomp.level1
{
    public class Road
    {
        public float Length;
        public byte Lines;
        public Node NodeFrom;
        public Node NodeTo;
    }

    public class Node{}

    public class Tester
    {
        static Road[] Roads;
        static int RoadCount = 10000000; // 10mln.

        public static void doTest()
        {
            Console.WriteLine(">>> Data Structure: Array of Objects <<<");

            long memuse = GC.GetTotalMemory(true);
            Thread.Sleep(500);

            // Initialization
            Stopwatch sw = Stopwatch.StartNew();
            doInitialization();
            Console.Write("Initialization: time: " + sw.Elapsed);
            sw.Stop();

            long memuse2 = GC.GetTotalMemory(true);
            Console.Write("  memory: " + (memuse2 - memuse ));

            Console.WriteLine();

            // Write Access

            sw = Stopwatch.StartNew();
            doWriteLength();
            Console.WriteLine("Write Length: " + sw.Elapsed);
            sw.Stop();

            sw = Stopwatch.StartNew();
            doWriteLines();
            Console.WriteLine("Write Lines: " + sw.Elapsed);
            sw.Stop();

            sw = Stopwatch.StartNew();
            doWriteNodes();
            Console.WriteLine("Write Nodes: " + sw.Elapsed);
            sw.Stop();

            sw = Stopwatch.StartNew();
            doWriteAll();
            Console.WriteLine("Write All: " + sw.Elapsed);
            sw.Stop();
            

            // Read Access

            sw = Stopwatch.StartNew();
            doReadLength();
            Console.WriteLine("Read Length: " + sw.Elapsed);
            sw.Stop();

            sw = Stopwatch.StartNew();
            doReadLines();
            Console.WriteLine("Read Lines: " + sw.Elapsed);
            sw.Stop();

            sw = Stopwatch.StartNew();
            doReadNodes();
            Console.WriteLine("Read Nodes: " + sw.Elapsed);
            sw.Stop();

            sw = Stopwatch.StartNew();
            doReadAll();
            Console.WriteLine("Read All: " + sw.Elapsed);
            sw.Stop();

            // Clean up
            Roads = null;
            GC.Collect();
            Thread.Sleep(500);

            Console.WriteLine();
        }

        public static void doInitialization()
        {
            Roads = new Road[RoadCount];
            for (int i = 0; i < RoadCount; i++)
                Roads[i] = new Road();
        }

        public static void doWriteLength()
        {
            float ln = 10.1F;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                {
                    Roads[i].Length = ln;
                    ln += 15.15F;
                }
        }

        public static void doWriteLines()
        {
            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                    Roads[i].Lines = (byte)i;
        }

        public static void doWriteNodes()
        {
            Node n1 = new Node();
            Node n2 = new Node();

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                {
                    Roads[i].NodeFrom = n1;
                    Roads[i].NodeTo = n2;
                }
        }

        public static void doWriteAll()
        {
            float ln = 10.1F;
            Node n1 = new Node();
            Node n2 = new Node();

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                {
                    Roads[i].Length = ln;
                    ln += 15.15F;
                    Roads[i].Lines = (byte)i;
                    Roads[i].NodeFrom = n1;
                    Roads[i].NodeTo = n2;
                }
        }

        public static void doReadLength()
        {
            float ln = 0F;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                    ln += Roads[i].Length;
        }

        public static void doReadLines()
        {
            long cnt = 0;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                    cnt += Roads[i].Lines;
        }

        public static void doReadNodes()
        {
            int cnt2 = 0;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                    if (Roads[i].NodeFrom == Roads[i].NodeTo)
                        cnt2++;
        }

        public static void doReadAll()
        {
            float ln = 0F;
            long cnt = 0;
            int cnt2 = 0;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                {
                    ln += Roads[i].Length;
                    cnt += Roads[i].Lines;
                    if (Roads[i].NodeFrom == Roads[i].NodeTo)
                        cnt2++;
                }
        }

    }

}
