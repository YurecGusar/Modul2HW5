using System;
using System.Collections;
using System.IO;
using Modul2HW5.Atributes;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5.Services
{
    [FileServiceAtribute(DirectorySize = 3, DirectoryName = "Loggers")]
    public class FileService : IFileService
    {
        private readonly IComparer _comparer;
        private DirectoryInfo _dirInfo;
        private StreamWriter _streamWriter;
        private FileServiceAtribute _attributeValue;

        public FileService(
            IComparer comparer)
        {
            _comparer = comparer;

            GetAttributes();
            _dirInfo = new DirectoryInfo(_attributeValue.DirectoryName);
            DirectorySizeControl();
        }

        public void WriteToFile(string value)
        {
            _streamWriter = new StreamWriter(GetFilePath(), true);
            CreateDirectory();
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
            Array.Sort(files, _comparer);
            if (files.Length >= _attributeValue.DirectorySize)
            {
                for (var i = 0; i <= files.Length - _attributeValue.DirectorySize; i++)
                {
                    files[i].Delete();
                }
            }
        }

        private void GetAttributes()
        {
            var type = GetType();
            if (Attribute.IsDefined(type, typeof(FileServiceAtribute)))
            {
                _attributeValue = Attribute
                    .GetCustomAttribute(type, typeof(FileServiceAtribute))
                    as FileServiceAtribute;
            }
        }

        private string GetFilePath()
        {
            return @$"{_attributeValue.DirectoryName}\{DateTime.UtcNow.ToString().Replace(':', '.')}.txt";
        }
    }
}
