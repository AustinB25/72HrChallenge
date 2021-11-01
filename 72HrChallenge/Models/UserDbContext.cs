using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _72HrChallenge.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}