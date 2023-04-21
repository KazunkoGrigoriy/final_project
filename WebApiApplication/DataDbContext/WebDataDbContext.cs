using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApplication.Models;

namespace WebApiApplication.DataDbContext
{
    public class WebDataDbContext : DbContext
    {
        public WebDataDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Request> Requests { get; set; }

    }
}
