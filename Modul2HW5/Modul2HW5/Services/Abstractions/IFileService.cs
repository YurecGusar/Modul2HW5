using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW5.Services.Abstractions
{
    public interface IFileService
    {
        public void StartFileStream();
        public void WriteToFile(string value);
    }
}
