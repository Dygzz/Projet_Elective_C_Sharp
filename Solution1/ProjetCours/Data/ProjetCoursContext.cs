using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ProjetCours.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjetCours.Data
{
    public class ProjetCoursContext : IdentityDbContext
    {

        public static readonly ILoggerFactory SqlLoger = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public ProjetCoursContext (DbContextOptions<ProjetCoursContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetCours.Models.Car> Car { get; set; }

        public DbSet<ProjetCours.Models.Fuel> Fuel { get; set; }
    }
}
