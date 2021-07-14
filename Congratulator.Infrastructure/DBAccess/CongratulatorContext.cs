using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Congratulator.Infrastructure.DBAccess
{
    public class CongratulatorContext:DbContext
    {
        public CongratulatorContext(DbContextOptions<CongratulatorContext> options) : base(options)
        {
        }

        public DbSet<Congratulator.Domain.Entities.Person> Person { get; set; }
    }
}
