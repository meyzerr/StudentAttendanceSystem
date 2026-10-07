namespace StudentAttendanceSystem.Services;

public class StudentService
{
    private readonly AppDbContext _context;
    

    public StudentService(AppDbContext context)
    {
        _context = context;
    }

    public void AddStudent(string fullName, int groupId)
    {
        Student student = new Student(fullName, groupId);

        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public void DeleteStudent(int studentId)
    {
        var student = _context.Students.FirstOrDefault(student => student.Id == studentId);

        if (student == null)
        {
            return;
        }

        _context.Students.Remove(student);
        _context.SaveChanges();
    }

    public void UpdateStudent(int studentId, string? newFullName, int? newGroupId)
    {
        var student = _context.Students
            .FirstOrDefault(student => student.Id == studentId);

        if (student == null)
        {
            return;
        }

        if (newFullName != null)
        {
            student.FullName = newFullName;
        }

        if (newGroupId != null)
        {
            student.GroupId = newGroupId.Value;
        }

        _context.SaveChanges();
    }
    public List<Student> GetAll()
    {
        return _context.Students.ToList();
    }

    public List<Student> GetByGroupId(int groupId)
    {
        return _context.Students
            .Where(student => student.GroupId == groupId)
            .ToList();
    }


}