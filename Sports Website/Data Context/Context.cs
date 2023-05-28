using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data_Context
{
    public class Context:IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public virtual DbSet<Matches> matches { get; set; }
        public virtual DbSet<Players> players { get; set; }
        public virtual DbSet<Teams> teams { get; set; }
        public virtual DbSet<Tournaments> tournaments { get; set; }
    }
}
