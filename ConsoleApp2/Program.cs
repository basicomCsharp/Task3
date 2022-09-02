using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)            
        {
            string sDir = "";
            Console.WriteLine("Введите каталог для подсчёта файлов");
            sDir = Console.ReadLine();

            CalcDir classCalcDir = new CalcDir();
            var sizeDir = classCalcDir.GetSizeDirAndCountFiles(sDir);            
            Console.WriteLine("Каталог {0} содержит {1} файлов общий объём которых равен в байтах : {2}", sDir, classCalcDir.CounFile, sizeDir);
            Console.ReadKey();
        }
    }
}
