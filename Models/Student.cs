public class Student
{
    public int Id {get; set;}
    public string FullName {get; set;} = string.Empty;
    public int GroupId {get; set;}

    public Student()
    {
    }

    public Student(string fullName, int groupId)
    {
        FullName = fullName;
        GroupId = groupId;
    }
}