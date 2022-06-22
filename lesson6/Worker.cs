using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    /// <summary>
    /// структура для данных сотрудников
    /// </summary>
    public class Worker
    {        
        #region Поля

        /// <summary>
        /// идентификатор сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// дата создания заметки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// возраст сотрудника
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// рост сотрудника
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// дата рождения сотрудника
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// место рождения сотрудника
        /// </summary>
        public string PlaceOfBirth { get; set; }

        #endregion

        #region Конструкторы

        public Worker(
            int id, 
            DateTime date, 
            string fullName, 
            int age, 
            int height, 
            DateTime dateOfBirth, 
            string placeOfBirth)
        {
            this.Id = id;
            this.Date = date;
            this.FullName = fullName;
            this.Age = age;
            this.Height = height;
            this.DateOfBirth = dateOfBirth;
            this.PlaceOfBirth = placeOfBirth;
        }

        #endregion

    }
}
