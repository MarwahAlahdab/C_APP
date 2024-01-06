using System;
using System.Reflection.Emit;
using Clinica_App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinica_App.Data
{
	public class ClinicaDbContext : IdentityDbContext<ApplicationUser>
    {
	

        public ClinicaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}

