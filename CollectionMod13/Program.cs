namespace Collections
{
    using System.Diagnostics;

    class Programm
    {
        static void Main()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Text\Text1.txt");

            using (StreamReader sr = new StreamReader(path))
            {
                List<string> DefaultList = new List<string>();

                Console.WriteLine("Обычный список\n");

                Write(DefaultList, sr);
                Read(DefaultList);
                Console.WriteLine();

                LinkedList<string> LinkList = new LinkedList<string>();

                Console.WriteLine("Связанный список\n");
                Write(LinkList, sr);
                Read(LinkList);
                Console.Read();
            }
        }

        // Запись в файл
        #region Write

        static void Write(List<string> list, StreamReader sr)
        {
            var stopWatch = Stopwatch.StartNew();

            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine());
            }

            Console.WriteLine($"Время записи: {stopWatch.Elapsed.TotalMilliseconds}");
        }

        static void Write(LinkedList<string> list, StreamReader sr)
        {
            var stopWatch = Stopwatch.StartNew();

            while (!sr.EndOfStream)
            {
                list.AddLast(sr.ReadLine());
            }

            Console.WriteLine($"Время записи: {stopWatch.Elapsed.TotalMilliseconds}");
        }
        #endregion

        // Чтение из файла
        #region Read
        static void Read(List<string> list)
        {
            var stopWatch = Stopwatch.StartNew();

            foreach (var item in list)
            {
                string str = item;
            }

            Console.WriteLine($"Время чтения: {stopWatch.Elapsed.TotalMilliseconds}");
        }

        static void Read(LinkedList<string> list)
        {
            var stopWatch = Stopwatch.StartNew();

            foreach (var item in list)
            {
                string str = item;
            }

            Console.WriteLine($"Время чтения: {stopWatch.Elapsed.TotalMilliseconds}");
        }
        #endregion
    }
}