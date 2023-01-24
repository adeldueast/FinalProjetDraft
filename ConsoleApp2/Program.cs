using Microsoft.EntityFrameworkCore;

public class User
{
    public int Id { get; set; }
    public int Name { get; set; }


    public List<Inscription> Inscriptions { get; set; } = new();

    public List<Tournament> Tournaments { get; set; } = new();


}

public class Event 
{
    public int Id { get; set; }
    public int Location { get; set; }
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
    public int? SeatId { get; set; }
    public Seat Seat { get; set; }
}

public class Seat
{
    public int Id { get; set; }

    public string Position { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; }



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
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=FinalProjectTest;Trusted_Connection=True;");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inscription>().HasKey(ul => new { ul.UserId, ul.EventId });
    }
}

class Program
{
    static void Main(string[] args)
    {
        var dateOnly = new DateOnly();
        Console.WriteLine(dateOnly);

        //Console.WriteLine(new TimeOnly());
        Console.ReadLine();
    }
}