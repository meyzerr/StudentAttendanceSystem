using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Student>Students {get; set;}
    public DbSet<Group>Groups {get; set;}
    public DbSet<Subject>Subjects {get; set;}
    public DbSet<GroupSubject>GroupSubjects {get; set;}
    public DbSet<AttendanceSession>AttendanceSessions {get; set;}
    public DbSet<AttendanceRecord>AttendanceRecords {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlite("Data Source=attendance.db");
       
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<GroupSubject>()
        .HasKey(x => new { x.GroupId, x.SubjectId });
}
}