using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ErikVanDelft.Models;
using System.ComponentModel.DataAnnotations;

namespace ErikVanDelft.Models
{
    public class InformationDbContext : DbContext
    {

        public InformationDbContext(DbContextOptions<InformationDbContext> options) : base(options)
        {

        }
        public DbSet<CvContent> CvContent { get; set; }
        //public DbSet<ContactFormModel> ContactForm { get; set; }

    }
   
  

}
