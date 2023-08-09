using DataAccess.Layer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Layer
{
    public class DataAccess :DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=SEZER;Database=BookDb;Integrated Security=True;Trust Server Certificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasMany(b => b.Books)
                .WithOne(a => a.Authors)
                .HasForeignKey( a => a.AuthorId);

            modelBuilder.Entity<Book>()
                 .HasData(new Book() { Id = 1, Name = "Gün olur asra bedel",AuthorId=1 },
                         new Book() { Id = 2, Name = "Kürk mantolu madonna",AuthorId=2 },
                         new Book() { Id = 3, Name = "Tutunamayanlar",AuthorId =3 },
                         new Book() { Id = 4, Name = "Kara Kitap" , AuthorId = 4 },
                         new Book() { Id = 5, Name = "Yaban" , AuthorId = 5 },
                         new Book() { Id = 6, Name = "Tehlikeli Oyunlar" , AuthorId = 3 },
                         new Book() { Id = 7, Name = "Çalıkuşu" , AuthorId = 6 },
                         new Book() { Id = 8, Name = "Kuyucaklı Yusuf" , AuthorId = 2});

            modelBuilder.Entity<Author>()
           .HasData(new Author() { Id = 1, Name = "Cengiz Aytmatov" },
                   new Author() { Id = 2, Name = "Sabahattin Ali" },
                   new Author() { Id = 3, Name = "Oğuz Atay" },
                   new Author() { Id = 4, Name = "Orhan Pamuk" },
                   new Author() { Id = 5, Name = "Yakup Kadri Karaosmanoğlu" },
                   new Author() { Id = 6, Name = "Reşat Nuri Güntekin" });

        }

    }
}