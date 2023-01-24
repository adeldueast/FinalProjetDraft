using Microsoft.EntityFrameworkCore;

public class User
{
    public int Id { get; set; }
    public int Name { get; set; }
    public List<User_Lan> User_Lan { get; set; } = new();

    public List<Tournament> Tournaments { get; set; } = new();

}
public class Lan
{
    public int Id { get; set; }
    public int Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<User_Lan> User_Lan { get; set; } = new();
    public List<Tournament> Tournaments { get; set; } = new();
    public List<Seat> Seats { get; set; }
}

public class User_Lan
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int LanId { get; set; }
    public Lan Lan { get; set; }

    //aditional information
    public int SeatId { get; set; }
}

public class Seat
{
    public int Id { get; set; }

    public string Position { get; set; }

}
public class Tournament
{
    public int Id { get; set; }
    public int Name { get; set; }
    public DateTime Date { get; set; }
    public int LanId { get; set; }
    public Lan Lan { get; set; }
    public List<User> Users { get; set; } = new();


}

public class SchoolContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Lan> Lans { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }

    public DbSet<User_Lan> User_Lan { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=Localhost;Database=FinalProjectTest;Trusted_Connection=True;");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User_Lan>().HasKey(ul => new { ul.UserId, ul.LanId });
    }
}

class Program
{
    static void Main(string[] args)
    {
        var dateOnly = new DateOnly();
        Console.WriteLine(dateOnly);


        Console.WriteLine(new TimeOnly());
        Console.ReadLine();
    }
}