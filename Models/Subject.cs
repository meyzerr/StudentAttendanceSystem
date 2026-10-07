public class Subject
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;

    public Subject()
    {
    }

    public Subject(string name)
    {
        Name = name;
    }
}