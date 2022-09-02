using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Класс для подсчёта размера и количества файлов в каталоге
    /// </summary>
    class CalcDir
    {     
        /// <summary>
        /// Размер каталога
        /// </summary>
        public long SizeDir { get; set; }
        /// <summary>
        /// Количество файлов
        /// </summary>
        public long CounFile { get; set; }
        /// <summary>
        /// Метод подсчёта количества файлов в каталоге и размер
        /// </summary>
        /// <param name="dir">путь</param>
        /// <returns></returns>
        public long GetSizeDirAndCountFiles(string dir)
        {            
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                if (dirInfo.Exists)
                {
                    CounFile += dirInfo.GetFiles().Length;                    
                    foreach (FileInfo f in dirInfo.GetFiles())
                    {
                        SizeDir += f.Length;                        
                    }
                    string[] dirs = Directory.GetDirectories(dir);
                    foreach (string d in dirs)
                    {
                        SizeDir = GetSizeDirAndCountFiles(d);
                    }
                    return SizeDir;
                }
                return SizeDir;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
                return SizeDir;
            }
        }
    }
}
