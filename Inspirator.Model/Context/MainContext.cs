using Inspirator.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Inspirator.Model.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserIdentity>().HasOne(x => x.User).WithMany(x => x.UserIdentitys).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Subject>().HasOne(x => x.Survey).WithMany(x => x.Subjects).HasForeignKey(x => x.SurveyId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Option>().HasOne(x => x.Subject).WithMany(x => x.Options).HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.Restrict);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserIdentity> UserIdentities { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}
