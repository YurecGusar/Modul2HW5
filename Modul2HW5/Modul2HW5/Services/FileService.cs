using System;
using System.IO;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5.Services
{
    public class FileService : IFileService
    {
        private StreamWriter _streamWriter;

        public void WriteToFile(string value)
        {
            _streamWriter = new StreamWriter(GetFileName(), true);
            _streamWriter.WriteLine(value);
            _streamWriter.Close();
        }

        private string GetFileName()
        {
            return $"{DateTime.UtcNow.ToString().Replace(':', '.')}.txt";
        }
    }
}
