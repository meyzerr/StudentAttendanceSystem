public class AttendanceRecord
{
    public int Id {get; set;}
    public int StudentId {get; set;}
    public int AttendanceSessionId {get; set;}
    public string Status {get; set;} = string.Empty;
}