using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DanhMucMonAn
{
    public class FileNameDirectory
    {
        public string filePath(string name)
        {
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string dir = "Resources\\" + name;
            string filePath = Path.Combine(projectPath, dir);
            return filePath;
        }
    }
}
