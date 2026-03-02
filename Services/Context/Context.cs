using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using saltingandhashing.Models;

namespace saltingandhashing.Services.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<BlogItemModel> BlogInfo { get; set; }

    }
}