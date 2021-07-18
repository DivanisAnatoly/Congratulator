using Congratulator.Domain.Entities;
using System.Collections.Generic;


namespace Congratulator.Infrastructure.RepositoryPattern
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllRecords();

        Person GetRecord(int? id);

        void AddRecord(Person newPerson);

        void UpdateRecord(Person updPerson);

        public void RemoveRecord(Person person);

    }
}