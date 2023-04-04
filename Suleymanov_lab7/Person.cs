using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suleymanov_lab7
{
    class Person : ICLlable, INalog
    {
        protected string lastname { get; set; }
        protected string name { get; set; }
        protected DateTime birthday { get; set; }
        protected char g;
        public char gender
        {
            get { return g; }
            set
            {
                if (value == 'М' || value == 'Ж' || value == 'м' || value == 'ж')
                {
                    g = Char.ToUpper(value);
                }
                else
                {
                    Console.WriteLine("Пол может иметь только значения: 'М' или 'Ж'");
                }
            }
        }

        public Person()
        {
            lastname = "Kuztecova";
            name = "Svetlana";
            birthday = new DateTime(2004, 5, 20);
            g = 'М';
        }

        public Person(string l, string n, DateTime bh, char s)
        {
            lastname = l;
            name = n;
            birthday = bh;
            g = s;
        }

        public Person(Person other)
        {
            lastname = other.lastname;
            name = other.name;
            birthday = other.birthday;
            g = other.g;
        }
        public virtual void ReadFromConsole()
        {
            Console.Write("Введите фамилию:  ");
            lastname = Console.ReadLine();
            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите дату рождения (дд.мм.гггг): ");
            birthday = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.Write("Пол (М/Ж): ");
            g = Convert.ToChar(Console.ReadLine());
        }

        public virtual void WriteToConsole()
        {
            Console.WriteLine($"Фамилия: {lastname}" +
                $"\nИмя: {name}" +
                $"\nДата рождения: {birthday.Day}.{birthday.Month}.{birthday.Year}" +
                $"\nПол: {g}");
        }
        public override string ToString()
        {
            return $"{lastname}, {name}, {birthday.Day}.{birthday.Month}.{birthday.Year}, {g}";
        }

        public int Age()
        {
            int age = DateTime.Now.Year - birthday.Year;
            if (DateTime.Now.DayOfYear < birthday.DayOfYear) age--;
            return age;
        }

        public virtual double PayDay()
        {
            return 0;
        }

        public virtual double Nalog()
        {
            return 0;
        }
    }
}
