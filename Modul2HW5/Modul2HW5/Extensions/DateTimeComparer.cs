using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW5.Extensions
{
    public class DateTimeComparer : IComparer
    {
        public int Compare(object file1, object file2)
        {
            var creationTime1 = (file1 as FileInfo).CreationTime;
            var creationTime2 = (file2 as FileInfo).CreationTime;

            if (creationTime1 > creationTime2)
            {
                return 1;
            }
            else if (creationTime1 < creationTime2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
