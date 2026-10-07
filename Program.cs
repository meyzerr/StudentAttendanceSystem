using StudentAttendanceSystem.Services;
using StudentAttendanceSystem.UI;
using static System.Console;

using var context = new AppDbContext();

var studentService = new StudentService(context);
var groupService = new GroupService(context);
var subjectService = new SubjectService(context);

var studentMenu = new StudentMenu(studentService, groupService);
var groupMenu = new GroupMenu(groupService);
var subjectMenu = new SubjectMenu(subjectService);


var mainMenu = new MainMenu(studentMenu, groupMenu, subjectMenu);

WriteLine("Система учета посещаемости студентов");

mainMenu.Run();