using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace lesson6
{
    public class Repository
    {
        // Список сотрудника (частный вспомогательный список)
        public List<Worker> workers { get; set; }

        //Репозиторий
        public Repository()
        {
            workers = new List<Worker>();
            workers = GetWorkersFromClv();
        }

        // Получаем список всех сотрудников
        public List<Worker> GetAll()
        {
            return workers;
        }

        // Создаем нового сотрудника
        public void Create(Worker worker)
        {
            workers.Add(worker);
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

        // Редактируем сотрудника
        public void Update(Worker worker)
        {
            var oldWorker = workers
                .FirstOrDefault(e => e.Id == worker.Id);

            workers.Remove(oldWorker);
            workers.Add(worker);
        }

        // Удаляем сотрудника
        public void Remove(Worker worker)
        {
            var oldWorker = workers
                .FirstOrDefault(e => e.Id == worker.Id);
            workers.Remove(oldWorker);
        }

        // Получаем список всех сотрудников из файла (парсинг файла, частный метод)
        public List<Worker> GetWorkersFromClv()
        {
            var workers = new List<Worker>();

            
            string[] workersClv = File.ReadAllLines("Сотрудники.csv");
            using (StreamWriter sw = new StreamWriter("Сотрудники.csv", true, Encoding.Unicode))
            {
                //string[] employeesTxt = File.ReadAllLines("Сотрудники.txt");
                foreach (string workerClvString in workersClv)
                {
                    var worker = GetWorkerFromClvString(workerClvString);
                    workers.Add(worker);
                }
                return workers;
            }

            // Получаем сотрудника из строки (парсинг сотрудника, частный метод)
            Worker GetWorkerFromClvString(string workerClvString)
            {
                string[] props = workerClvString.Split('\t');

                int id = int.Parse(props[0]);
                DateTime date = DateTime.Parse(props[1]);
                string fullName = props[2];
                int age = int.Parse(props[3]);
                int height = int.Parse(props[4]);
                DateTime dateOfBirth = DateTime.Parse(props[5]);
                string placeOfBirth = props[6];

                var worker = new Worker(
                    id,
                    date,
                    fullName,
                    age,
                    height,
                    dateOfBirth,
                    placeOfBirth
                    );

                return worker;
            }
        }

        public void SaveChanges()
        {
            using (StreamReader sr = new StreamReader("сотрудники.csv", Encoding.Unicode))
            {
                string line = "null";
                Console.WriteLine($"{"id",3} {"время добавления",20} {"фио",25} {"возраст",3} {"рост",4} {"дата рождения",12} {"место рождения",16}");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('\t');
                    Console.WriteLine($"{data[0],3} {data[1],20} {data[2],25} {data[3],3} {data[4],4} {data[5],12} {data[6],16}");
                }
            }
            //using (StreamWriter sw = new StreamWriter("Сотрудники.csv", false))
            //{
            //    foreach (var worker in workers)
            //    {
            //        sw.WriteLine(worker.Id + "\t" +
            //                     worker.Date.ToString() + "\t" +
            //                     worker.FullName + "\t" +
            //                     worker.Age + "\t" +
            //                     worker.Height + "\t" +
            //                     worker.DateOfBirth.ToString() + "\t" +
            //                     worker.PlaceOfBirth);
            //    }
            //}
        }

        // Получаем сотрудника по идентификатору
        public Worker GetById(int id)
        {
            return workers.FirstOrDefault(e => e.Id == id);
        }
    }
}