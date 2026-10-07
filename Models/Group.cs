public class Group
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;

    public Group()
    {
    }

    public Group(string name)
    {
        Name = name;
    }
}