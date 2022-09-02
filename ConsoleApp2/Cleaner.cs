using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Cleaner
    {
        public static string DirName { get; set; }
        private static TimeSpan ts;
        private void DelFile(string dir)
        {
            try
            {
                string[] files = Directory.GetFiles(dir);
                foreach (string s in files)
                {
                    var fileInfo = new FileInfo(s);
                    ts = DateTime.Now - fileInfo.LastWriteTime;
                    if (ts.Minutes >= 0)
                        fileInfo.Delete();
                }
            }
            catch
            {
                Console.WriteLine("Нет доступа к файлам в каталоге {0}", dir.ToString());
            }
        }
        public void DelOldFolder(string dir)
        {
            DirName = dir;
            if (Directory.Exists(DirName))
            {
                try
                {
                    DelFile(DirName);
                    string[] dirs = Directory.GetDirectories(DirName);
                    foreach (string d in dirs)
                    {
                        var dirInfo = new DirectoryInfo(d);
                        ts = DateTime.Now - dirInfo.LastAccessTime;
                        if (ts.Minutes >= 0)
                        {
                            DelFile(d);
                            DelOldFolder(d);
                            dirInfo.Delete();
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Нет доступа к каталогу {0}", DirName.ToString());
                }
            }
            else
            {
                Console.WriteLine("Каталог не существует.");
            }
        }
    }
}
