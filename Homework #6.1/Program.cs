using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lesson12Homework.txt");
            string csvFilePath = "";

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                csvFilePath = await streamReader.ReadLineAsync();
            }

            List<Record> records = new List<Record>();

            using (StreamReader streamReader = new StreamReader(csvFilePath))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] line = (await streamReader.ReadLineAsync()).Split('\t');
                    Record record = new Record(line[0], line[1], Convert.ToDateTime(line[2], CultureInfo.CurrentCulture));
                    records.Add(record);
                }
            }

            var sortedRecords = records.OrderBy(r => r.Modified);

            Console.WriteLine("Список файлов:");
            foreach (var record in sortedRecords)
            {
                Console.WriteLine($"{record.Type}\t{record.Name}\t{Convert.ToDateTime(record.Modified, CultureInfo.CurrentCulture)}");
            }

            File.Delete(filePath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }

        Console.ReadKey();
    }
}

class Record
{
    public string Type { get; set; }
    public string Name { get; set; }
    public DateTime Modified { get; set; }

    public Record(string type, string name, DateTime modified)
    {
        Type = type;
        Name = name;
        Modified = modified;
    }
}
