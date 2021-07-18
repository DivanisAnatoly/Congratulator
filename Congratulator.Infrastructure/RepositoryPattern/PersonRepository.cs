using Congratulator.Domain.Entities;
using Congratulator.Infrastructure.DBAccess;
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


        public void AddRecord(Person newPerson)
        {
            _context.Add(newPerson);
            _context.SaveChanges();
        }


        public IEnumerable<Person> GetAllRecords()
        {
            return _context.Person.AsEnumerable();
        }


        public Person GetRecord(int? id)
        {
            return _context.Person.Find(id);
        }


        public void UpdateRecord(Person updPerson)
        {
            _context.Update(updPerson);
            _context.SaveChanges();
        }


        public void RemoveRecord(Person person)
        {
            _context.Person.Remove(person);
            _context.SaveChanges();
        }


    }
}
