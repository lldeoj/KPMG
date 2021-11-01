using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KPMG.Domain.Models;

namespace KPMG.Infrastructure.Data
{
    public class KPMGAPIContext : DbContext
    {
        public KPMGAPIContext (DbContextOptions<KPMGAPIContext> options)
            : base(options)
        {
        }

        public DbSet<KPMG.Domain.Models.GameResultModel> GameResultModel { get; set; }
    }
}
