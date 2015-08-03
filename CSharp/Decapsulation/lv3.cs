using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace btest_classdecomp.level3
{
    public class Tester
    {
        static float[] Lengths;
        static byte[] Lines;
        static Int32[] NodesFrom;
        static Int32[] NodesTo;

        static int RoadCount = 10000000; // 10mln.

        public static void doTest()
        {
            Console.WriteLine(">>> Data Structure: Array of Fields <<<");

            long memuse = GC.GetTotalMemory(true);
            Thread.Sleep(500);

            // Initialization
            Stopwatch sw = Stopwatch.StartNew();
            doInitialization();
            Console.Write("Initialization: time: " + sw.Elapsed);
            sw.Stop();

            long memuse2 = GC.GetTotalMemory(true);
            Console.Write("  memory: " + (memuse2 - memuse));

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
            Lengths = null;
            Lines = null;
            NodesFrom = null;
            NodesTo = null;
            GC.Collect();
            Thread.Sleep(500);

            Console.WriteLine();
        }

        public static void doInitialization()
        {
            Lengths = new float[RoadCount];
            Lines = new byte[RoadCount];
            NodesFrom = new Int32[RoadCount] ;
            NodesTo = new Int32[RoadCount];
        }

        public static void doWriteLength()
        {
            float ln = 10.1F;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                {
                    Lengths[i] = ln;
                    ln += 15.15F;
                }
        }

        public static void doWriteLines()
        {
            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                    Lines[i] = (byte)i;
        }

        public static void doWriteNodes()
        {
            Int32 n1 = 12;
            Int32 n2 = 83;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                {
                    NodesFrom[i] = n1;
                    NodesTo[i] = n2;
                }
        }

        public static void doWriteAll()
        {
            float ln = 10.1F;
            Int32 n1 = 12;
            Int32 n2 = 83;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                {
                    Lengths[i] = ln;
                    ln += 15.15F;
                    Lines[i] = (byte)i;
                    NodesFrom[i] = n1;
                    NodesTo[i] = n2;
                }
        }

        public static void doReadLength()
        {
            float ln = 0F;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                    ln += Lengths[i];
        }

        public static void doReadLines()
        {
            long cnt = 0;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                    cnt += Lines[i];
        }

        public static void doReadNodes()
        {
            int cnt2 = 0;

            for (int it = 0; it < 500; it++)
                for (int i = 0; i < RoadCount; i++)
                    if (NodesFrom[i] == NodesTo[i])
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
                    ln += Lengths[i];
                    cnt += Lines[i];
                    if (NodesFrom[i] == NodesTo[i])
                        cnt2++;
                }
        }

    }

}
