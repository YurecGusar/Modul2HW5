﻿using System;
using System.Collections;
using System.IO;
using Modul2HW5.Atributes;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5.Services
{
    public class FileService : IFileService
    {
        private readonly IConfigService _config;
        private readonly IComparer _comparer;
        private DirectoryInfo _dirInfo;
        private StreamWriter _streamWriter;
        private string _filePath;

        public FileService(
            IComparer comparer,
            IConfigService config)
        {
            _comparer = comparer;
            _config = config;
            _dirInfo = new DirectoryInfo(_config.LoggerConfig.DirectoryName);
            CreateDirectory();
            DirectorySizeControl();
            _filePath = GetFilePath();
        }

        public void WriteToFile(string value)
        {
            _streamWriter = new StreamWriter(_filePath, true);
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
            if (files.Length >= _config.LoggerConfig.DirectorySize)
            {
                for (var i = 0; i <= files.Length - _config.LoggerConfig.DirectorySize; i++)
                {
                    files[i].Delete();
                }
            }
        }

        private string GetFilePath()
        {
            return @$"{_config.LoggerConfig.DirectoryName}{DateTime.UtcNow.ToString().Replace(':', '.')}{_config.LoggerConfig.FileExtension}";
        }
    }
}
