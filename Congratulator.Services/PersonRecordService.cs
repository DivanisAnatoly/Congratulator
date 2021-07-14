using Congratulator.Domain.Entities;
using Congratulator.Infrastructure.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulator.Services
{
    public class PersonRecordService : IPersonRecordService
    {
        IPersonRepository _repository;

        public PersonRecordService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void AddPerson(Person newPerson)
        {
            _repository.AddRecord(newPerson);
        }

        public IEnumerable<Person> GetPeople()
        {
            return _repository.GetAllRecords();
        }

        public Person GetPerson(int? id)
        {
            if (id == null) return null;

            var person = _repository.GetRecord(id);

            if (person == null) return null;

            return person;
        }

        public void RemovePerson(Person delPerson)
        {
            _repository.RemoveRecord(delPerson);
        }

        public void UpdatePerson(Person updPerson)
        {
            _repository.UpdateRecord(updPerson);
        }

        public IEnumerable<Person> GetBirthdayPeople()
        {
            var people = _repository.GetAllRecords();
            return people.Where(p => DaysToBirthday(p.BirthDay) == 0);
        }

        public IEnumerable<Person> GetSoonBirthdayPeople(int daysInterval = 30)
        {
            var people = _repository.GetAllRecords();
            return people.Where(p => DaysToBirthday(p.BirthDay) > 0 && DaysToBirthday(p.BirthDay) < daysInterval).OrderBy(p=>p.BirthDay);
        }


        private static int DaysToBirthday(DateTime bornDate)
        {
            DateTime today = DateTime.Today;
            DateTime date = new DateTime(today.Year, bornDate.Month, bornDate.Day);

            if (date.DayOfYear < today.DayOfYear)
                date = new DateTime(date.Year + 1, date.Month, date.Day);

            return (date.Date - today.Date).Days;
        }


    }
}
