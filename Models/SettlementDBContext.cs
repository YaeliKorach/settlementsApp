using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationTask.Models
{
    public class SettlementDBContext: DbContext
    {
        public SettlementDBContext(DbContextOptions<SettlementDBContext> options)
          : base(options)
        {
        }
        public DbSet<Settelment> settelments { get; set; }
    }
}
