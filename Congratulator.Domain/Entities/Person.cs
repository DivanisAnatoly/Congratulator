using System;
using System.ComponentModel.DataAnnotations;

namespace Congratulator.Domain.Entities
{
    public class Person
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string Avatar { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

    }
}