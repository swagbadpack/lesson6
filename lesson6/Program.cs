using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    internal class Program
    {
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="line"></param>
        static void ReadingData()
        {
            using(StreamReader sr = new StreamReader("Сотрудники.csv", Encoding.Unicode))
            {
                string line = "null";
                Console.WriteLine($"{"ID",3} {"Время добавления",20} {"ФИО",25} {"Возраст",3} {"Рост",4} {"Дата рождения",12} {"Место рождения",16}");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('\t');
                    Console.WriteLine($"{data[0],3} {data[1],20} {data[2],25} {data[3],3} {data[4],4} {data[5],12} {data[6],16}");
                }
            }
        }
        /// <summary>
        /// Запись
        /// </summary>
        /// <param name="line"></param>
        static void DataEntry()
        {
            using (StreamWriter sw = new StreamWriter("Сотрудники.csv", true, Encoding.Unicode))
            {
                
                string note = string.Empty;
                Console.Write("\nВведите ID: ");
                note += $"{Console.ReadLine()}\t";


                string now = DateTime.Now.ToString();
                Console.Write($"Время заметки {now}");
                note += $"{now}\t";

                
                Console.Write("\nВведите ФИО: ");
                note += $"{Console.ReadLine()}\t";

                
                Console.Write("\nВведите возраст: ");
                note += $"{Console.ReadLine()}\t";

                
                Console.Write("\nВведите Рост: ");
                note += $"{Console.ReadLine()}\t";

                
                Console.Write("\nВведите дату рождения: ");
                note += $"{Console.ReadLine()}\t";

                
                Console.Write("\nВведите место рождения: ");
                note += $"{Console.ReadLine()}\t";
                sw.WriteLine(note);


            }
        }


        static void Main(string[] args)
        {
            string keyRead = "1";
            string keyWrite = "2";
            Console.WriteLine("Введите 1 для вывода информации, введите 2 для внесения информации");
            string key = Console.ReadLine();
            if (key == keyRead)
            {
                ReadingData();
                Console.ReadKey();
            }
            if (key == keyWrite)
            {
                DataEntry();
                Console.ReadKey();
            }
            
            
            
        }
    }
}
