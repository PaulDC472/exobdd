using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<GraphicBook> GraphicBooks { get; set; }

        public DbSet<Library> Libraries { get; set; }


        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.Entity<Book>().HasOne(b => b.SimilaryBook)
                                       .WithOne()
                                       .HasForeignKey<Book>(b => b.SimilaryBookId)
                                       .OnDelete(DeleteBehavior.Restrict)
                                       .IsRequired(false)
            ;

            ModelBuilder.Entity<Book>().HasDiscriminator<string> ("BookType")
                .HasValue<Book>("Book")
                .HasValue<GraphicBook>("Graphic")

                ;

        }



        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {

        }

    }

}
