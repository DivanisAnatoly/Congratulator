using Congratulator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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