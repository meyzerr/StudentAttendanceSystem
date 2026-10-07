namespace StudentAttendanceSystem.Services;

public class SubjectService
{
    private readonly AppDbContext _context;

    public SubjectService(AppDbContext context)
    {
        _context = context;
    }

    public void AddSubject(string name)
    {
        Subject subject = new Subject(name);

        _context.Subjects.Add(subject);
        _context.SaveChanges();
    }

    public void DeleteSubject(int subjectId)
    {
        var subject = _context.Subjects.FirstOrDefault(subject => subject.Id == subjectId);

        if (subject == null)
        {
            return;
        }

        _context.Subjects.Remove(subject);

        _context.SaveChanges();
    }   

    public void UpdateSubject(int subjectId, string name)
    {
        var subject = _context.Subjects.FirstOrDefault(subject => subject.Id == subjectId);

        if (subject == null)
        {
            return;
        }

        subject.Name = name;

        _context.SaveChanges();
    }

    public List<Subject> GetAll()
    {
        return _context.Subjects.ToList();
    }
}