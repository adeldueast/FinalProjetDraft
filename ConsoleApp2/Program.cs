using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }


    public List<Inscription> Inscriptions { get; set; } = new();

    public List<Tournament> Tournaments { get; set; } = new();


}

public class Event
{
    public int Id { get; set; }
    public string Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxPlayer { get; set; }


    public List<Inscription> Inscriptions { get; set; } = new();

    public List<Tournament> Tournaments { get; set; }

}
public class Tournament
{
    public int Id { get; set; }
    public int Name { get; set; }
    public DateTime Date { get; set; }


    public int EventId { get; set; }
    public Event Event { get; set; }

    public List<User> Users { get; set; } = new();


}

public class Inscription
{
    //public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; }

    //aditional information
    public int SeatId { get; set; }
    public Seat Seat { get; set; }
}

public class Seat
{
    public int Id { get; set; }

    public string Position { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; }

    public Inscription Inscription { get; set; }


}


public class SchoolContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Seat> Seats { get; set; }

    public DbSet<Inscription> Inscriptions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //localhost\SQLEXPRESS
        optionsBuilder.UseSqlServer(@"Server=Localhost;Database=FinalProjectTest5;Trusted_Connection=True;");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inscription>().HasKey(ul => new { ul.UserId, ul.EventId, ul.SeatId });

        modelBuilder.Entity<Inscription>()
            .HasOne<Event>(i => i.Event)
            .WithMany(e => e.Inscriptions)
            .HasForeignKey(i => i.EventId);
        modelBuilder.Entity<Inscription>()
          .HasOne(i => i.User)
          .WithMany(e => e.Inscriptions)
          .HasForeignKey(i => i.UserId);
        modelBuilder.Entity<Inscription>()
         .HasOne<Seat>(i => i.Seat)
         .WithOne(e => e.Inscription)
         .HasForeignKey<Inscription>(i => i.SeatId)
         .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Event>().HasData(new Event { Id = 1, StartDate = new DateTime(), EndDate = new DateTime(), Location = "Cegep", MaxPlayer = 30 });

        modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Adel Kouaou" });

        modelBuilder.Entity<Seat>().HasData(new Seat { Id = 1, EventId = 1, Position = "A2", });


        modelBuilder.Entity<Inscription>().HasData(new Inscription() { EventId = 1, UserId = 1, SeatId = 1 });

    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new SchoolContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var inscription = context.Inscriptions.Find(1,1,1);
            var test = context.Seats.Find(1);

            context.Remove(test);

            //var test2 = context.Seats.Find(1);
            //context.Remove(test);
            context.SaveChanges();
        }
        Console.ReadLine();
    }
}