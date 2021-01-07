using Microsoft.EntityFrameworkCore;
using SuperPerros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPerros.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Post> Post { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //p from Post, pd from PostDetails
            modelBuilder.Entity<Post>().HasOne(p => p.PostDetail)
                .WithOne(pd => pd.Post)
                .HasForeignKey<PostDetail>(pd => pd.PostId);
        }
    }
}
