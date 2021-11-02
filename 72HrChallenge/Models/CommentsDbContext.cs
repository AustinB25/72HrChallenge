using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _72HrChallenge.Models
{
    public class CommentsDbContext : DbContext
    {
        public CommentsDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Comments> Comments { get; set; }

    }
}