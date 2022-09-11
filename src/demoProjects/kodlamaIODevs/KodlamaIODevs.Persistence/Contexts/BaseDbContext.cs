using KodlamaIODevs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.CreateDate).HasColumnName("CreateDate");
                a.Property(p => p.UpdateDate).HasColumnName("UpdateDate");
                a.Property(p => p.Status).HasColumnName("Status");
                a.HasMany(p => p.ProgrammingLanguageTechnologies);
            });
            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java"),new(3, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            modelBuilder.Entity<ProgrammingLanguageTechnology>(a =>
            {
                a.ToTable("ProgrammingLanguageTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgramingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.CreateDate).HasColumnName("CreateDate");
                a.Property(p => p.UpdateDate).HasColumnName("UpdateDate");
                a.Property(p => p.Status).HasColumnName("Status");
                a.HasOne(p => p.ProgrammingLanguage);

            });
            ProgrammingLanguageTechnology[] programmingLanguageTechnologyEntitySeeds = {new(1,1,"WPF"), new(2, 2, "Spring") };
            modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologyEntitySeeds);
        }
    }
}
