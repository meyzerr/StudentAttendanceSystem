namespace StudentAttendanceSystem.Services;

public class GroupService
{
    private readonly AppDbContext _context;

    public GroupService(AppDbContext context)
    {
        _context = context;
    }

    public void AddGroup(string name)
    {
        Group group = new Group(name);

        _context.Groups.Add(group);
        _context.SaveChanges();
    }

    public void DeleteGroup(int groupId)
    {
    var group = _context.Groups.FirstOrDefault(group => group.Id == groupId);

    if (group == null)
    {
        return;
    }

    var students = _context.Students
        .Where(student => student.GroupId == groupId)
        .ToList();

    _context.Students.RemoveRange(students);
    _context.Groups.Remove(group);

    _context.SaveChanges();
    }

    public void UpdateGroup(int groupId, string name)
    {
        var group = _context.Groups.FirstOrDefault(group => group.Id == groupId);

        if (group == null)
        {
            return;
        }

        group.Name = name;

        _context.SaveChanges();
    }

    public List<Group> GetAll()
    {
        return _context.Groups.ToList();
    }

    public bool GroupExists(int groupId)
    {
        return _context.Groups.Any(group => group.Id == groupId);
    }
}  