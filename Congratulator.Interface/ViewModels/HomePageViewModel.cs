using Congratulator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Congratulator.Interface.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Person> BirthdayPeople { get; set; }
        public IEnumerable<Person> BirthdayPeopleSoon { get; set; }

    }
}