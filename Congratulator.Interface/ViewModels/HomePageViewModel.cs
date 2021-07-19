using Congratulator.Domain.Entities;
using System.Collections.Generic;


namespace Congratulator.Interface.ViewModels
{
    public class HomePageViewModel
    {
        //список именинников
        public IEnumerable<Person> BirthdayPeople { get; set; }
        
        //список ближайших именинников
        public IEnumerable<Person> BirthdayPeopleSoon { get; set; }

    }
}