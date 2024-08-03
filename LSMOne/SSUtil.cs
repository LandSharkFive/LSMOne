
namespace LSMOne
{
    public class SSUtil
    {
        public static void WriteFileOne(string fileName, List<TableOne> list)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                int pos = 0;
                int step = 10;
                int count = list.Count;
                bw.Write(count);
                bw.Write(12);   // data
                bw.Write(0);   // index

                List<IndexOne> index = new List<IndexOne>();

                // data
                for (int i = 0; i < count; i++)
                {
                    int key = list[i].Key;
                    int value = list[i].Value;
                    if (i % step == 0)
                    {
                        // sparse index
                        pos = (int)bw.BaseStream.Position;
                        index.Add(new IndexOne(key, pos));
                    }
                    bw.Write(i);
                    bw.Write(key);
                    bw.Write(value);
                }
                bw.Write(-1);

                // index
                pos = (int)bw.BaseStream.Position;
                bw.Seek(8, SeekOrigin.Begin);
                bw.Write(pos);
                bw.Seek(pos, SeekOrigin.Begin);

                // index count
                bw.Write(index.Count);

                // index
                for (int i = 0; i < index.Count; i++)
                {
                    int key = index[i].Key;
                    int value = index[i].Value;
                    bw.Write(i);
                    bw.Write(key);
                    bw.Write(value);
                }

            }
        }

        public static List<TableOne> ReadFileOne(string fileName)
        {
            List<TableOne> list = new List<TableOne>();

            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName)))
            {
                int count = br.ReadInt32();
                int data = br.ReadInt32();
                int index = br.ReadInt32();

                for (int i = 0; i < count; i++)
                {
                    int row = br.ReadInt32();
                    int key = br.ReadInt32();
                    int value = br.ReadInt32();
                    list.Add(new TableOne(key, value));
                }
            }

            return list;
        }

        public static List<IndexOne> ReadIndexOne(string fileName)
        {
            List<IndexOne> list = new List<IndexOne>();
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName)))
            {
                int count = br.ReadInt32();
                int data = br.ReadInt32();
                int index = br.ReadInt32();

                br.BaseStream.Seek(index, SeekOrigin.Begin);
                int maxIndex = br.ReadInt32();

                for (int i = 0; i < maxIndex; i++)
                {
                    int row = br.ReadInt32();
                    int key = br.ReadInt32();
                    int value = br.ReadInt32();
                    list.Add(new IndexOne(key, value));
                }
            }

            return list;
        }

        public static void WriteFileTwo(string fileName, List<TableTwo> list)
        {
            int pos = 0;
            int step = 10;
            List<IndexTwo> index = new List<IndexTwo>();

            using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                int count = list.Count;
                bw.Write(count);
                bw.Write(12);   // data
                bw.Write(0);    // index

                // data
                for (int i = 0; i < count; i++)
                {
                    string key = list[i].Key;
                    string value = list[i].Value;
                    if (i % step == 0)
                    {
                        // sparse index
                        pos = (int)bw.BaseStream.Position;
                        index.Add(new IndexTwo(key, pos));
                    }
                    bw.Write(i);
                    bw.Write(key);
                    bw.Write(value);
                }
                bw.Write(-1);

                // index
                pos = (int)bw.BaseStream.Position;
                bw.Seek(8, SeekOrigin.Begin);
                bw.Write(pos);
                bw.Seek(pos, SeekOrigin.Begin);

                bw.Write(index.Count);

                // index
                for (int i = 0; i < index.Count; i++)
                {
                    string key = index[i].Key;
                    int value = index[i].Value;
                    bw.Write(i);
                    bw.Write(key);
                    bw.Write(value);
                }
                bw.Write(-1);

            }
        }

        public static List<TableTwo> ReadFileTwo(string fileName)
        {
            List<TableTwo> list = new List<TableTwo>();
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName)))
            {
                int count = br.ReadInt32();
                int data = br.ReadInt32();
                int index = br.ReadInt32();

                for (int i = 0; i < count; i++)
                {
                    int row = br.ReadInt32();
                    string key = br.ReadString();
                    string value = br.ReadString();
                    list.Add(new TableTwo(key, value));
                }
            }

            return list;
        }

        public static string GetFileTwo(string fileName, string myKey)
        {
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName)))
            {
                int count = br.ReadInt32();
                int data = br.ReadInt32();
                int index = br.ReadInt32();

                // data
                for (int i = 0; i < count; i++)
                {
                    int row = br.ReadInt32();
                    string key = br.ReadString();
                    string name = br.ReadString();
                    int k = string.Compare(myKey, key);
                    if (k == 0)
                    {
                        return name;
                    }
                    if (k == -1)
                    {
                        break;
                    }
                }
            }

            return string.Empty;
        }

        public static string GetFileTwo(string fileName, string myKey, int position)
        {
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName)))
            {
                int count = br.ReadInt32();
                int data = br.ReadInt32();
                int index = br.ReadInt32();

                // data
                br.BaseStream.Position = position;
                while (true)
                {
                    int row = br.ReadInt32();
                    if (row == -1)
                    {
                        break;
                    }
                    string key = br.ReadString();
                    string name = br.ReadString();
                    int k = string.Compare(myKey, key);
                    if (k == 0)
                    {
                        return name;
                    }
                    if (k == -1)
                    {
                        break;
                    }
                }
            }

            return string.Empty;
        }

        public static List<IndexTwo> ReadIndexTwo(string fileName)
        {
            List<IndexTwo> list = new List<IndexTwo>();
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName)))
            {
                int count = br.ReadInt32();
                int data = br.ReadInt32();
                int index = br.ReadInt32();

                br.BaseStream.Seek(index, SeekOrigin.Begin);
                int maxIndex = br.ReadInt32();

                for (int i = 0; i < maxIndex; i++)
                {
                    int row = br.ReadInt32();
                    string key = br.ReadString();
                    int value = br.ReadInt32();
                    list.Add(new IndexTwo(key, value));
                }
            }

            return list;
        }

        public static int ReadIndexTwo(string fileName, string myKey)
        {
            int value = 0;
            int oldValue = 0;
            using (BinaryReader br = new BinaryReader(File.OpenRead(fileName)))
            {
                int count = br.ReadInt32();
                int data = br.ReadInt32();
                int index = br.ReadInt32();

                // index
                br.BaseStream.Position = index;
                int rowCount = br.ReadInt32();

                while (true)
                {
                    int row = br.ReadInt32();
                    if (row == -1)
                    {
                        break;
                    }
                    string key = br.ReadString();
                    oldValue = value;
                    value = br.ReadInt32();
                    if (oldValue == 0)
                    {
                        oldValue = value;
                    }
                    int k = string.Compare(myKey, key);
                    if (k == 0)
                    {
                        return value;
                    }
                    if (k == -1)
                    {
                        return oldValue;
                    }
                }
            }

            return value;
        }

        public static string SearchTableTwo(string filename, string key)
        {
            int pos = ReadIndexTwo(filename, key);
            return GetFileTwo(filename, key, pos);
        }

        public static string SearchTableTwo(string key, List<TableTwo> data)
        {
            var result = data.FirstOrDefault(x => x.Key.Contains(key));
            return result == null ? String.Empty : result.Value;
        }

        public static int SearchIndexTwo(string key, List<IndexTwo> index)
        {
            var result = index.FirstOrDefault(a => key == a.Key);
            return result == null ? -1 : result.Value;
        }

        public static int FindIndexTwo(string key, List<IndexTwo> index)
        {
            if (index.Any(x => string.Compare(key, x.Key) >= 0))
            {
                return index.Where(x => string.Compare(key, x.Key) >= 0).Max(x => x.Value);
            }

            return index.Min(x => x.Value);
        }

        public static int BinarySearchTableTwo(string key, List<TableTwo> index)
        {
            int low = 0;
            int high = index.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int k = String.Compare(index[mid].Key, key);
                if (k == 0)
                {
                    return mid;
                }
                else if (k > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        public static int BinarySearchIndexTwo(string key, List<IndexTwo> index)
        {
            int low = 0;
            int high = index.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int k = String.Compare(index[mid].Key, key);
                if (k == 0)
                {
                    return mid;
                }
                else if (k > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return high;
        }

        public static string GetByIndexTwo(string fileName, List<IndexTwo> index, string key)
        {
            int pos = FindIndexTwo(key, index);
            return GetFileTwo(fileName, key, pos);
        }

        public static void CompactTableTwo(string inFile1, string inFile2, string outFile)
        {
            string tempFile = "1.tmp";
            MergeTableTwo(inFile1, inFile2, tempFile);
            GroupTableTwo(tempFile, outFile);
            File.Delete(tempFile);
        }

        public static void MergeTableTwo(string inFile1, string inFile2, string outFile)
        {
            using (BinaryReader br1 = new BinaryReader(File.Open(inFile1, FileMode.Open)))
            {
                using (BinaryReader br2 = new BinaryReader(File.Open(inFile2, FileMode.Open)))
                {
                    using (BinaryWriter bw = new BinaryWriter(File.Open(outFile, FileMode.Create)))
                    {
                        // header
                        int k1 = br1.ReadInt32();
                        int data1 = br1.ReadInt32();
                        int index1 = br1.ReadInt32();

                        // header
                        int k2 = br2.ReadInt32();
                        int data2 = br2.ReadInt32();
                        int index2 = br2.ReadInt32();

                        // header
                        int count = 0;
                        int data = 0;
                        int index = 0;
                        bw.Write(count);
                        bw.Write(data);
                        bw.Write(index);

                        // compare
                        TableTwo a = ReadTableTwo(br1);
                        TableTwo b = ReadTableTwo(br2);
                        while (a != null && b != null)
                        {
                            if (string.Compare(a.Key, b.Key) <= 0)
                            {
                                WriteTableTwo(bw, count, a);
                                ++count;
                                a = ReadTableTwo(br1);
                            }
                            else
                            {
                                WriteTableTwo(bw, count, b);
                                ++count;
                                b = ReadTableTwo(br2);
                            }
                        }

                        while (a != null)
                        {
                            WriteTableTwo(bw, count, a);
                            ++count;
                            a = ReadTableTwo(br1);
                        }

                        while (b != null)
                        {
                            WriteTableTwo(bw, count, b);
                            ++count;
                            b = ReadTableTwo(br2);
                        }

                        bw.Write(-1);

                        index = (int)bw.BaseStream.Position;
                        bw.Seek(0, SeekOrigin.Begin);
                        bw.Write(count);
                        bw.Write(12);
                        bw.Write(index);
                    }
                }
            }
        }

        public static void GroupTableTwo(string inFile, string outFile)
        {
            using (BinaryReader br = new BinaryReader(File.Open(inFile, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(outFile, FileMode.Create)))
                {
                    // header
                    int k1 = br.ReadInt32();
                    int data1 = br.ReadInt32();
                    int index1 = br.ReadInt32();

                    // header
                    int count = 0;
                    int data = 0;
                    int index = 0;
                    bw.Write(count);
                    bw.Write(data);
                    bw.Write(index);

                    // compare
                    string lastKey = string.Empty;
                    TableTwo a = ReadTableTwo(br);
                    while (a != null)
                    {
                        if (string.Compare(a.Key, lastKey) != 0)
                        { 
                            WriteTableTwo(bw, count, a);
                            ++count;
                        }
                        lastKey = a.Key;
                        a = ReadTableTwo(br);
                    }

                    bw.Write(-1);

                    index = (int)bw.BaseStream.Position;
                    bw.Seek(0, SeekOrigin.Begin);
                    bw.Write(count);
                    bw.Write(12);
                    bw.Write(index);
                }
            }
        }

        public static TableTwo ReadTableTwo(BinaryReader br)
        {
            int row = br.ReadInt32();
            if (row == -1)
            {
                return null;
            }
            string key = br.ReadString();
            string value = br.ReadString();
            return new TableTwo(key, value);
        }

        public static void WriteTableTwo(BinaryWriter bw, int row, TableTwo item)
        {
            bw.Write(row);
            bw.Write(item.Key);
            bw.Write(item.Value);
        }

        public static void IndexTableTwo(string filename)
        {
            int index = 0;
            List<IndexTwo> list = new List<IndexTwo>();
            using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                // header
                int count = br.ReadInt32();
                int data = br.ReadInt32();
                index = br.ReadInt32();

                int step = 10;
                for (int i = 0; i < count; i++)
                {
                    int pos = (int)br.BaseStream.Position;
                    int row = br.ReadInt32();
                    string key = br.ReadString();
                    string value = br.ReadString();

                    // sparse index
                    if (i % step == 0)
                    {
                        // sparse index
                        list.Add(new IndexTwo(key, pos));
                    }
                }
            }

            // index
            using (BinaryWriter bw = new BinaryWriter(File.Open(filename, FileMode.Open)))
            {
                bw.Seek(index, SeekOrigin.Begin);
                bw.Write(list.Count);

                for (int i = 0; i < list.Count; i++)
                {
                    string key = list[i].Key;
                    int value = list[i].Value;
                    bw.Write(i);
                    bw.Write(key);
                    bw.Write(value);
                }
                bw.Write(-1);
            }
        }


    }
}
