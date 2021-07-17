using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW5.Atributes
{
    public class FileServiceAtribute : Attribute
    {
        public int DirectorySize { get; set; }
        public string DirectoryName { get; set; }
    }
}
