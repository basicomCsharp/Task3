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
            string sDir = "";
            Console.WriteLine("Введите каталог для подсчёта файлов");
            sDir = Console.ReadLine();

            CalcDir classCalcDir = new CalcDir();
            var sizeDir = classCalcDir.GetSizeDirAndCountFiles(sDir);            
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



            //            // объект для сериализации
            //            var person = new Pet("Rex", 2);
            //            person.SecretName = "1234567890";
            //            Console.WriteLine("Объект создан");

            //            BinaryFormatter formatter = new BinaryFormatter();
            //            // получаем поток, куда будем записывать сериализованный объект
            //            using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
            //            {
            //                formatter.Serialize(fs, person);
            //                Console.WriteLine("Объект сериализован");
            //            }
            //            person.SecretName2 = "";
            //            // десериализация
            //            using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
            //            {
            //                var newPet = (Pet)formatter.Deserialize(fs);
            //                Console.WriteLine("Объект десериализован");
            //                Console.WriteLine($"Имя: {newPet.Name} --- Возраст: {newPet.Age}");
            //                Console.WriteLine("SecretName: " + newPet.SecretName);
            //                Console.WriteLine("SecretName2: " + newPet.SecretName2);
            //            }
            //            Console.ReadLine();
            ////            BinaryExperiment.WriteValuesFile();
            ////            BinaryExperiment.ReadValuesFile();
        }
    }
}
