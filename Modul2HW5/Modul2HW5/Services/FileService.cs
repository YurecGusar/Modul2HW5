using System;
using System.IO;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5.Services
{
    public class FileService : IFileService
    {
        private const int _directorySize = 3;
        private const string _directoryName = "Loggers";
        private DirectoryInfo _dirInfo;
        private StreamWriter _streamWriter;

        public FileService()
        {
            _dirInfo = new DirectoryInfo(_directoryName);
            DirectorySizeControl();
        }

        public void WriteToFile(string value)
        {
            CreateDirectory();
            _streamWriter = new StreamWriter(GetFilePath(), true);
            _streamWriter.WriteLine(value);
            _streamWriter.Close();
        }

        private void CreateDirectory()
        {
            if (!_dirInfo.Exists)
            {
                _dirInfo.Create();
            }
        }

        private void DirectorySizeControl()
        {
            var files = _dirInfo.GetFiles();
            if (files.Length >= _directorySize)
            {
                for (var i = 0; i <= files.Length - _directorySize; i++)
                {
                    files[i].Delete();
                }
            }
        }

        private string GetFilePath()
        {
            return @$"{_directoryName}\{DateTime.UtcNow.ToString().Replace(':', '.')}.txt";
        }
    }
}
