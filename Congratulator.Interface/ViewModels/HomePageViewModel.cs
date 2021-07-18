using Congratulator.Domain.Entities;
using System.Collections.Generic;


namespace Congratulator.Interface.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Person> BirthdayPeople { get; set; }
        public IEnumerable<Person> BirthdayPeopleSoon { get; set; }

    }
}