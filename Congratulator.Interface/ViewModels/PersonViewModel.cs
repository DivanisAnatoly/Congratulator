using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congratulator.Interface.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [MaxLength(100)]
        public string ExsistingAvatar { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}