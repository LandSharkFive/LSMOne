namespace LSMOne
{
    internal class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            DemoOne();
            DemoTwo();
            DemoThree();
            DemoFour();
            DemoFive();
            DemoSix();
        }

        static void DemoOne()
        {
            Console.WriteLine("Demo #1");
            Console.WriteLine("Create Data File");
            Console.WriteLine();

            var list = new List<TableOne>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new TableOne(i, rand.Next(100)));
            }

            // Create data file
            SSUtil.WriteFileOne("a.txt", list);

            // read data file
            var b = SSUtil.ReadFileOne("a.txt");

            // print data file
            foreach (var r in b)
            {
                Console.WriteLine("{0} {1}", r.Key, r.Value);
            }

            // read index from file
            var c = SSUtil.ReadIndexOne("a.txt");

            Console.WriteLine();

            // print index
            foreach (var r in c)
            {
                Console.WriteLine("{0} {1}", r.Key, r.Value);
            }

            Console.WriteLine();
        }

        static void DemoTwo()
        {
            Console.WriteLine("Demo #2");
            Console.WriteLine("Search data file");
            Console.WriteLine();

            var list = new List<TableTwo>();
            for (int i = 0; i < 100; i++)
            {
                string key = "a" + i.ToString();
                string value = "b" + rand.Next(100).ToString();
                list.Add(new TableTwo(key, value));
            }

            // create data file
            SSUtil.WriteFileTwo("b.txt", list);

            // read data file
            var b = SSUtil.ReadFileTwo("b.txt");

            // print
            foreach (var r in b)
            {
                Console.WriteLine("{0} {1}", r.Key, r.Value);
            }

            Console.WriteLine();

            // read index from file
            var c = SSUtil.ReadIndexTwo("b.txt");

            // print
            foreach (var r in c)
            {
                Console.WriteLine("{0} {1}", r.Key, r.Value);
            }

            Console.WriteLine();

            // search for key in memory
            Console.WriteLine(SSUtil.SearchTableTwo("a92", b));

            Console.WriteLine();

            Console.WriteLine(SSUtil.FindIndexTwo("a10", c));

            Console.WriteLine();

            // binary search for key in memory
            Console.WriteLine(SSUtil.BinarySearchIndexTwo("a75", c));

            Console.WriteLine();

            int k = SSUtil.BinarySearchTableTwo("a75", b);
            Console.WriteLine(b[k].Value);

            Console.WriteLine(SSUtil.GetFileTwo("b.txt", "a99"));

            // use index to find key
            Console.WriteLine(SSUtil.GetByIndexTwo("b.txt", c, "a38"));

            Console.WriteLine();
        }

        public static void DemoThree()
        {
            Console.WriteLine("Demo #3");
            Console.WriteLine("Create second data file");
            Console.WriteLine();

            var list = new List<TableTwo>();
            for (int i = 0; i < 100; i++)
            {
                string key = "a" + i.ToString();
                string value = "b" + rand.Next(100).ToString();
                list.Add(new TableTwo(key, value));
            }

            // create data file
            SSUtil.WriteFileTwo("a.txt", list);

            list.Clear();

            for (int i = 0; i < 100; i++)
            {
                string key = "a" + i.ToString();
                string value = "b" + rand.Next(100).ToString();
                list.Add(new TableTwo(key, value));
            }

            // create second data file
            SSUtil.WriteFileTwo("b.txt", list);

            Console.WriteLine();
        }

        public static void DemoFour()
        {
            Console.WriteLine("Demo #4");
            Console.WriteLine("Merge two files");
            Console.WriteLine();

            // merge and index the file
            SSUtil.MergeTableTwo("a.txt", "b.txt", "out.txt");
            SSUtil.IndexTableTwo("out.txt");

            Console.WriteLine();
        }

        public static void DemoFive()
        {
            Console.WriteLine("Demo #2");
            Console.WriteLine("Read three data files");
            Console.WriteLine();

            // read and print two data files
            List<TableTwo> a = SSUtil.ReadFileTwo("a.txt");

            foreach (var x in a)
            {
                Console.WriteLine("{0} {1}", x.Key, x.Value);
            }

            Console.WriteLine();

            List<TableTwo> b = SSUtil.ReadFileTwo("b.txt");

            foreach (var x in b)
            {
                Console.WriteLine("{0} {1}", x.Key, x.Value);
            }

            Console.WriteLine();

            List<TableTwo> c = SSUtil.ReadFileTwo("out.txt");

            // print merged file
            foreach (var x in c)
            {
                Console.WriteLine("{0} {1}", x.Key, x.Value);
            }

            Console.WriteLine();
        }

        public static void DemoSix()
        {
            Console.WriteLine("Demo #6");
            Console.WriteLine("Print index file");
            Console.WriteLine();

            List<IndexTwo> list = SSUtil.ReadIndexTwo("out.txt");

            // print index file
            foreach (var x in list)
            {
                Console.WriteLine("{0} {1}", x.Key, x.Value);
            }

            Console.WriteLine();
        }
    }


}

