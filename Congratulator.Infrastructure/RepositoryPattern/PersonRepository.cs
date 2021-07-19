using Congratulator.Domain.Entities;
using Congratulator.Infrastructure.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Congratulator.Infrastructure.RepositoryPattern
{
    public class PersonRepository : IPersonRepository
    {
        private readonly CongratulatorContext _context;

        public PersonRepository(CongratulatorContext context)
        {
            _context = context;
        }

        //Добавить запись
        public void AddRecord(Person newPerson)
        {
            _context.Add(newPerson);
            _context.SaveChanges();
        }

        //Получить записи отсортированные по дням до ДР именинника
        public IEnumerable<Person> GetAllRecords()
        {
            var people = _context.Person.AsEnumerable();
            people = people.OrderBy(p => DaysToBirthday(p.BirthDay));

            return people;
        }

        //Получить запись по ID
        public Person GetRecord(int id)
        {
            return _context.Person.Find(id);
        }

        //Обновить запись
        public void UpdateRecord(Person updPerson)
        {
            _context.Update(updPerson);
            _context.SaveChanges();
        }

        //Удалить запись
        public void RemoveRecord(Person person)
        {
            _context.Person.Remove(person);
            _context.SaveChanges();
        }

        //Получить записи сегодняшних именинников
        public IEnumerable<Person> GetBirthdayPeople()
        {
            return _context.Person.Where(BirthdayToday).AsEnumerable();
        }

        //Получить записи ближайших именинников
        public IEnumerable<Person> GetSoonBirthdayPeople()
        {
            return _context.Person.Where(BirthdaySoon).AsEnumerable();
        }

        //Получить кол-во дней до ДР человека
        private static int DaysToBirthday(DateTime bornDate)
        {
            
            DateTime today = DateTime.Today;
            DateTime date = new DateTime(today.Year, bornDate.Month, bornDate.Day);

            if (date.DayOfYear < today.DayOfYear)
                date = new DateTime(date.Year + 1, date.Month, date.Day);

            return (date.Date - today.Date).Days;
        }


        private static bool BirthdaySoon(Person person)
        {
            DateTime bornDate = person.BirthDay;
            int daysInterval = 30;

            return DaysToBirthday(bornDate) > 0 && DaysToBirthday(bornDate) <= daysInterval;
        }
        

        private static bool BirthdayToday(Person person)
        {
            DateTime bornDate = person.BirthDay;
            
            return DaysToBirthday(bornDate) == 0;
        }


    }
}
