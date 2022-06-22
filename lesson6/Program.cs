using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace lesson6
{
    internal class Program
    {
        ///// <summary>
        ///// метод чтение
        ///// </summary>
        ///// <param name="line"></param>
        //static void ReadingData()
        //{
        //    using (StreamReader sr = new StreamReader("Сотрудники.csv", Encoding.Unicode))
        //    {
        //        string line = "null";
        //        Console.WriteLine($"{"ID",3} {"Время добавления",20} {"ФИО",25} {"Возраст",3} {"Рост",4} {"Дата рождения",12} {"Место рождения",16}");
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            string[] data = line.Split('\t');
        //            Console.WriteLine($"{data[0],3} {data[1],20} {data[2],25} {data[3],3} {data[4],4} {data[5],12} {data[6],16}");
        //        }
        //    }
        //}
        ///// <summary>
        ///// метод записи
        ///// </summary>
        ///// <param name="line"></param>
        //static void DataEntry()
        //{
        //    using (StreamWriter sw = new StreamWriter("Сотрудники.csv", true, Encoding.Unicode))
        //    {
        //        string note = string.Empty;
        //        Console.Write("\nВведите ID: ");
        //        note += $"{Console.ReadLine()}\t";

        //        string now = DateTime.Now.ToString();
        //        Console.Write($"Время заметки {now}");
        //        note += $"{now}\t";

        //        Console.Write("\nВведите ФИО: ");
        //        note += $"{Console.ReadLine()}\t";

        //        Console.Write("\nВведите возраст: ");
        //        note += $"{Console.ReadLine()}\t";

        //        Console.Write("\nВведите Рост: ");
        //        note += $"{Console.ReadLine()}\t";

        //        Console.Write("\nВведите дату рождения: ");
        //        note += $"{Console.ReadLine()}\t";

        //        Console.Write("\nВведите место рождения: ");
        //        note += $"{Console.ReadLine()}\t";
        //        sw.WriteLine(note);
        //    }
        //}

        static void Main(string[] args)
        {
            //string keyRead = "1";
            //string keyWrite = "2";
            //Console.WriteLine("Введите 1 для вывода информации, введите 2 для внесения информации");
            //string key = Console.ReadLine();
            //if (key == keyRead)
            //{
            //    ReadingData();
            //    Console.ReadKey();
            //}
            //if (key == keyWrite)
            //{
            //    DataEntry();
            //    Console.ReadKey();
            //}

            var workerRepository = new Repository();
            Console.WriteLine("Какую команду Вы хотите выполнить?:");
            Console.WriteLine("Показать список сотрудников на экране. Нажмите 1:");
            Console.WriteLine("Добавить нового сотрудника. Нажмите 2:");
            Console.WriteLine("Редактировать записи. Нажмите 3:");
            Console.WriteLine("Показать записи в выбранном диапазоне дат. Нажмите 4:");
            Console.WriteLine("Сортировать по убыванию даты записи. Нажмите 5:");
            Console.WriteLine("Сортировать по возрастанию даты записи. Нажмите 6:");
            Console.WriteLine("Выбрать и удалить запись о работнике. Нажмите 7:");

            while (true)
            {
                int userinput = int.Parse(Console.ReadLine());

                int Program = userinput;

                switch (Program)
                {
                    case 1:
                        {
                            var workers = workerRepository.GetAll();

                            foreach (var worker in workers)
                            {
                                Console.WriteLine(worker.Id + " " +
                                    worker.Id + " " +
                                    worker.FullName + " " +
                                    worker.Age + " " +
                                    worker.Height + " " +
                                    worker.DateOfBirth + " " +
                                    worker.PlaceOfBirth);
                            }
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Введите данные сотрудника");
                            var userFullName = Console.ReadLine();

                            string[] props = userFullName.Split(',');

                            int id = int.Parse(props[0]);
                            DateTime date = DateTime.Parse(props[1]);
                            string fullName = props[2];
                            int age = int.Parse(props[3]);
                            int height = int.Parse(props[4]);
                            DateTime dateOfBirth = DateTime.Parse(props[5]);
                            string placeOfBirth = props[6];

                            var employee = new Worker(id,
                                                        date,
                                                        fullName,
                                                        age,
                                                        height,
                                                        dateOfBirth,
                                                        placeOfBirth);

                            workerRepository.Create(employee);
                            workerRepository.SaveChanges();
                            break;
                        }

                    case 3:
                        {
                        Found:
                            Console.WriteLine("Введите Id сотрудника для редоктирования");
                            var workerId = Int32.Parse(Console.ReadLine());

                            var worker = workerRepository.GetById(workerId);

                            if (worker == null)
                            {
                                Console.WriteLine("Такого сотрудника нет в списке");
                                goto Found;
                            }

                            Console.WriteLine("Введите новое Id сотрудника");
                            var NewId = Console.ReadLine();
                            worker.Id = int.Parse(NewId);

                            Console.WriteLine("Введите новую дату и время записи сотрудника");
                            var NewCreatedAt = Console.ReadLine();
                            worker.Date = DateTime.Parse(NewCreatedAt);

                            Console.WriteLine("Введите новое Ф.И.О сотрудника");
                            var NewFullName = Console.ReadLine();
                            worker.FullName = NewFullName;

                            Console.WriteLine("Введите новый возраст сотрудника");
                            var NewAge = Console.ReadLine();
                            worker.Age = int.Parse(NewAge);

                            Console.WriteLine("Введите новый рост сотрудника");
                            var NewHeight = Console.ReadLine();
                            worker.Height = int.Parse(NewHeight);

                            Console.WriteLine("Введите новую дату рождения сотрудника");
                            var NewBirthDate = Console.ReadLine();
                            worker.DateOfBirth = DateTime.Parse(NewBirthDate);

                            Console.WriteLine("Введите новое место рождения сотрудника");
                            var NewBirthPlace = Console.ReadLine();
                            worker.PlaceOfBirth = NewBirthPlace;

                            workerRepository.Update(worker);
                            workerRepository.SaveChanges();

                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Введите начальную дату");
                            var WorkerDataStart = (Console.ReadLine());
                            Console.WriteLine("Введите конечную дату");
                            var WorkerDataEnd = (Console.ReadLine());
                            var workers = workerRepository.GetAll().Where(e => e.Date >= DateTime.Parse(WorkerDataStart)
                                                                              && e.Date <= DateTime.Parse(WorkerDataEnd));

                            foreach (var worker in workers)
                            {
                                Console.WriteLine(worker.Id + " " +
                                    worker.Date + " " +
                                    worker.FullName + " " +
                                    worker.Age + " " +
                                    worker.Height + " " +
                                    worker.DateOfBirth + " " +
                                    worker.PlaceOfBirth);
                            }
                            break;
                        }

                    case 5:
                        {
                            var workers = workerRepository.GetAll().OrderByDescending(e => e.Date);

                            foreach (var worker in workers)
                            {
                                Console.WriteLine(worker.Id + " " +
                                    worker.Date + " " +
                                    worker.FullName + " " +
                                    worker.Age + " " +
                                    worker.Height + " " +
                                    worker.DateOfBirth + " " +
                                    worker.PlaceOfBirth);
                            }
                            break;
                        }

                    case 6:
                        {
                            var workers = workerRepository.GetAll().OrderBy(e => e.Date);

                            foreach (var worker in workers)
                            {
                                Console.WriteLine(worker.Id + " " +
                                    worker.Date + " " +
                                    worker.FullName + " " +
                                    worker.Age + " " +
                                    worker.Height + " " +
                                    worker.DateOfBirth + " " +
                                    worker.PlaceOfBirth);
                            }
                            break;
                        }

                    case 7:
                        {
                        Found:
                            Console.WriteLine("Введите Id сотрудника для удаления");
                            var OldWorkerId = Int32.Parse(Console.ReadLine());

                            var worker = workerRepository.GetById(OldWorkerId);

                            if (worker == null)
                            {
                                Console.WriteLine("Такого сотрудника нет в списке");
                                goto Found;
                            }

                            Console.WriteLine("Повторно введите Id сотрудника для удаления");
                            var oldEmployee = Console.ReadLine();
                            worker.Id = int.Parse(oldEmployee);

                            workerRepository.Remove(worker);
                            workerRepository.SaveChanges();
                            break;
                        }
                        Console.ReadKey();
                }
            }
        }
        
    }
}
