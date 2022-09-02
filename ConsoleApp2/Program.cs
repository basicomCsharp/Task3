using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)            
        {
            var sDir = string.Empty;
            long sizeDir = 0;
            CalcDir classCalcDir = new CalcDir();

            Console.WriteLine("Введите каталог для подсчёта файлов");
            do
            {
                sDir = Console.ReadLine();
                if (Directory.Exists(sDir))
                {                    
                    sizeDir = classCalcDir.GetSizeDirAndCountFiles(sDir);
                    break;
                }
                else
                {
                    Console.WriteLine("Каталог не существует или некорректно указан. \n Повторите попытку.");
                }
            }
            while (true);
            Console.WriteLine("Каталог {0} содержит {1} файлов общий объём которых равен в байтах : {2}", sDir, classCalcDir.CounFile, classCalcDir.SizeDir);
            Console.WriteLine("Завершите программу, если не хотите удалить файлы в указанном каталоге!");
            Console.ReadKey();            
            if (Directory.Exists(sDir))
            {
                Cleaner clean = new Cleaner();
                clean.DelOldFolder(sDir);
            }
            else
            {
                Console.WriteLine("Каталог не существует или некорректно указан. \n Повторите попытку.");
            }            
            classCalcDir.SizeDir = 0;
            classCalcDir.GetSizeDirAndCountFiles(sDir);
            Console.WriteLine("Из каталога {0} удалено {1} файлов общий объём которых равен в байтах : {2}.\n После удаления каталог имеет объём {3} ", sDir, classCalcDir.CounFile, sizeDir, classCalcDir.SizeDir);            
            Console.WriteLine("Программа успешно выполнила задачу.");
            Console.ReadKey();
        }
    }
}
