namespace Collections
{
    using System.Linq;
    using System.Globalization;
    class Programm
    {
        static char[] delimeters = Enumerable.Range(0, 256) // Здесь храним разделители (среднне тире сюда не попадает,даже если прописывать в ручную)
                            .Select(x => (char)x)
                            .Where(c => char.IsWhiteSpace(c) || char.IsPunctuation(c) || char.IsSurrogate(c))
                            .ToArray();

        static void Main()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Text\Text1.txt");

            using (StreamReader sr = new StreamReader(path))
            {
                var text = sr.ReadToEnd().ToLower().Split(delimeters, StringSplitOptions.RemoveEmptyEntries); // В массиве хранится текст разделенный по словам

                Dictionary<string, int> words = text
                    .GroupBy(s => s)
                    .ToDictionary(g => g.Key, g => g.Count()); // Собираем слова в пары слово-колличетсво

                words = words.OrderByDescending (x => x.Value)
                       .ToDictionary(x => x.Key, x => x.Value); // Сортируем от большего к меньшему

                words.Remove("\u2013");  // Удаляем среднее тире

                words = words.Take(10)
                       .ToDictionary(g => g.Key, g => g.Value); // Берем первые 10

                foreach (var word in words)
                    Console.WriteLine(word);
            }
        }
    }
}