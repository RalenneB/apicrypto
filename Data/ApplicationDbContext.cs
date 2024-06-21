using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Models;
using Microsoft.EntityFrameworkCore;

namespace apicrypto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) //ctor
       : base(dbContextOptions) 
       {
            
        }
        public DbSet<Cryptocurrency> Cryptocurrency { get; set;}
        public DbSet<DcaInvestment> DcaInvestments { get; set;}
        public DbSet<Comment> Comments {get; set;}
    }
}