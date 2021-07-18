using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;


namespace Congratulator.Interface.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [MaxLength(100)]
        public string ExsistingAvatar { get; set; }

        public IFormFile ImageFile { get; set; }

    }
}