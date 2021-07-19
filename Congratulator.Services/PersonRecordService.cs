using Congratulator.Domain.Entities;
using Congratulator.Infrastructure.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Congratulator.Services
{
    public class PersonRecordService : IPersonRecordService
    {
        IPersonRepository _repository;

        public PersonRecordService(IPersonRepository repository)
        {
            _repository = repository;
        }

        //добавить новую запись о человеке
        public void AddPerson(Person newPerson)
        {
            _repository.AddRecord(newPerson);
        }

        //Получить записи о людях
        public IEnumerable<Person> GetPeople()
        {
            return _repository.GetAllRecords();
        }

        //Получить запись по ID 
        public Person GetPerson(int id)
        {
            var person = _repository.GetRecord(id);

            if (person == null) return null;

            return person;
        }

        //Удалить запись из БД
        public void RemovePerson(Person delPerson)
        {
            _repository.RemoveRecord(delPerson);
        }

        //Обновить запись в БД
        public void UpdatePerson(Person updPerson)
        {
            _repository.UpdateRecord(updPerson);
        }

        //Получение записей об именинниках
        public IEnumerable<Person> GetBirthdayPeople()
        {
            return _repository.GetBirthdayPeople();
        }

        //Получение записей об ближайших именинниках
        public IEnumerable<Person> GetSoonBirthdayPeople()
        {
            return _repository.GetSoonBirthdayPeople();
        }


    }
}
