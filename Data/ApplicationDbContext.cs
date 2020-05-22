using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BoilerplateMVCWithId.Models;

namespace BoilerplateMVCWithId.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EFConfigurationValue> Values { get; set; }
        public DbSet<Testing1> TestValues { get; set; }
        //public DbSet<ConfigEntity> TestValues { get; set; }

    }

    ////new code
    //public class EFConfigurationContext : DbContext
    //{
    //    public EFConfigurationContext(DbContextOptions options) : base(options) { }

    //    public DbSet<EFConfigurationValue> Values { get; set; }
    //}
}
