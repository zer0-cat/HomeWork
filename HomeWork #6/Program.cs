using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        
        string sourceZipPath = "archive.zip";
        string extractPath = Path.Combine(Directory.GetCurrentDirectory(), "extracted");
        ZipFile.ExtractToDirectory(sourceZipPath, extractPath);

       
        var contents = Directory.EnumerateFileSystemEntries(extractPath)
            .Select(path => new FileRecord
            {
                Type = File.GetAttributes(path).HasFlag(FileAttributes.Directory) ? "Folder" : "File",
                Name = Path.GetFileName(path),
                Modified = File.GetLastWriteTime(path)
            });

        
        string csvPath = Path.Combine(Directory.GetCurrentDirectory(), "contents.csv");
        using (var writer = new StreamWriter(csvPath))
        {
            await writer.WriteLineAsync("Type\tName\tModified");
            foreach (var record in contents)
            {
                await writer.WriteLineAsync($"{record.Type}\t{record.Name}\t{Convert.ToDateTime(record.Modified, CultureInfo.CurrentCulture)}");
            }
        }

        
        Directory.Delete(extractPath, true);

        
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string homeworkPath = Path.Combine(appDataPath, "Lesson12Homework.txt");
        using (var writer = new StreamWriter(homeworkPath))
        {
            await writer.WriteAsync(csvPath);
        }
        Console.WriteLine("Done!");
    }
}

class FileRecord
{
    public string Type { get; set; }
    public string Name { get; set; }
    public DateTime Modified { get; set; }
}
