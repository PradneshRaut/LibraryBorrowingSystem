using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasvaAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArasvaAssignment.Persistence.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<BorrowTransactions> BorrowTransactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PK for Setting
            modelBuilder.Entity<Setting>()
                .HasKey(s => s.KeyName);

            // RELATION → BorrowTransaction → Book
            modelBuilder.Entity<BorrowTransactions>()
                .HasOne(b => b.Book)
                .WithMany(t => t.BorrowTransactions)
                .HasForeignKey(b => b.BookId);

            // RELATION → BorrowTransaction → Member
            modelBuilder.Entity<BorrowTransactions>()
                .HasOne(m => m.Member)
                .WithMany(t => t.BorrowTransactions)
                .HasForeignKey(m => m.MemberId); 

            modelBuilder.Entity<Book>()
                    .HasIndex(b => b.ISBN)
                    .IsUnique();

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Title)
                .IsUnique();

            modelBuilder.Entity<Member>()
        .HasIndex(m => m.Email)
        .IsUnique();

            modelBuilder.Entity<Member>()
                .HasIndex(m => m.Mobile)
                .IsUnique();
        }
    }
}
