using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Congratulator.Domain.Entities
{
    public class Person
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string Avatar { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

    }
}