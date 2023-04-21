using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace WpfApplication.UserApp
{
    class DataUsers : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataUsers() : base("Connection") { }
    }
}
