namespace StudentAttendanceSystem.UI;

using static System.Console;
using StudentAttendanceSystem.Services;

public class StudentMenu
{
    private readonly StudentService _studentService;
    private readonly GroupService _groupService;

    private readonly string[] studentActions =
    {
        "1. Просмотреть",
        "2. Добавить",
        "3. Удалить",
        "4. Изменить",
        "5. Назад"
    };

    public StudentMenu(StudentService studentService, GroupService groupService)
    {
        _studentService = studentService;
        _groupService = groupService;
    }

    public void ShowMenu()
    {
        while (true)
        {
            foreach (var action in studentActions)
            {
                WriteLine(action);
            }

            Write("Выберите действие: ");

            if (int.TryParse(ReadLine(), out int choice))
            {
                if (choice < 1 || choice > 5)
                {
                    WriteLine("Ошибка: необходимо ввести число в диапазоне от 1 до 5.");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            var students = _studentService.GetAll();

                            if (students.Count == 0)
                            {
                                WriteLine("Студентов пока нет.");
                            }
                            else
                            {
                                for (int i = 0; i < students.Count; i++)
                                {
                                    WriteLine($"{i + 1}. {students[i].FullName}"); 
                                }
                            }

                            Write("Нажмите Enter, чтобы вернуться назад...");
                            ReadLine();

                            break;

                        case 2:
                            Write("Введите ФИО (0 - назад): ");
                            string? fullName = ReadLine();

                            if (fullName == "0")
                            {
                                break;
                            }

                            if (string.IsNullOrWhiteSpace(fullName))
                            {
                                WriteLine("Ошибка: ФИО не может быть пустым.");
                                break;
                            }

                            Write("Введите ID группы студента (0 - назад): ");

                            if (int.TryParse(ReadLine(), out int groupId))
                            {
                                if (groupId == 0)
                                {
                                    break;
                                }

                                if (_groupService.GroupExists(groupId))
                                {
                                    _studentService.AddStudent(fullName, groupId);
                                    WriteLine("Студент успешно добавлен.");
                                }
                                else
                                {
                                    WriteLine("Группы с таким номером не существует.");
                                }
                            }
                            else
                            {
                                WriteLine("Ошибка: необходимо ввести число.");
                            }

                            break;

                        case 3:
                            var groups = _groupService.GetAll();

                            if (groups.Count == 0)
                            {
                                WriteLine("Групп пока нет.");
                                break;
                            }

                            for (int i = 0; i < groups.Count; i++)
                            {
                                WriteLine($"{i + 1}. {groups[i].Name}");
                            }

                            Write("Введите порядковый номер группы из списка (0 - назад): ");

                            if (int.TryParse(ReadLine(), out int groupChoice))
                            {
                                if (groupChoice == 0)
                                {
                                    break;
                                }

                                if (groupChoice < 1 || groupChoice > groups.Count)
                                {
                                    WriteLine("Ошибка: необходимо выбрать номер группы из списка.");
                                    break;
                                }

                                int selectedGroupId = groups[groupChoice - 1].Id;
                                string nameOfGroup = groups[groupChoice - 1].Name;

                                WriteLine($"Студенты группы {nameOfGroup}:");

                                var groupStudents =
                                    _studentService.GetByGroupId(selectedGroupId);

                                if (groupStudents.Count == 0)
                                {
                                    WriteLine("В этой группе нет студентов.");
                                    break;
                                }

                                for (int i = 0; i < groupStudents.Count; i++)
                                {
                                    WriteLine($"{i + 1}. {groupStudents[i].FullName}");
                                }

                                Write("Введите порядковый номер студента из списка (0 - назад): ");

                                if (int.TryParse(ReadLine(), out int studentChoice))
                                {
                                    if (studentChoice == 0)
                                    {
                                        break;
                                    }

                                    if (studentChoice < 1 ||
                                        studentChoice > groupStudents.Count)
                                    {
                                        WriteLine("Ошибка: необходимо выбрать номер студента из списка.");
                                        break;
                                    }

                                    int selectedStudentId =
                                        groupStudents[studentChoice - 1].Id;

                                    _studentService.DeleteStudent(selectedStudentId);

                                    WriteLine("Студент успешно удалён.");
                                }
                                else
                                {
                                    WriteLine("Ошибка: необходимо ввести число.");
                                }
                            }
                            else
                            {
                                WriteLine("Ошибка: необходимо ввести число.");
                            }

                            break;

                        case 4:
                            var groupsForUpdate = _groupService.GetAll();

                            if (groupsForUpdate.Count == 0)
                            {
                                WriteLine("Групп пока нет.");
                                break;
                            }

                            for (int i = 0; i < groupsForUpdate.Count; i++)
                            {
                                WriteLine($"{i + 1}. {groupsForUpdate[i].Name}");
                            }

                            Write("Введите порядковый номер группы из списка (0 - назад): ");

                            if (int.TryParse(ReadLine(), out int groupChoiceForUpdate))
                            {
                                if (groupChoiceForUpdate == 0)
                                {
                                    break;
                                }

                                if (groupChoiceForUpdate < 1 ||
                                    groupChoiceForUpdate > groupsForUpdate.Count)
                                {
                                    WriteLine("Ошибка: необходимо выбрать номер группы из списка.");
                                    break;
                                }

                                int selectedGroupIdForUpdate =
                                    groupsForUpdate[groupChoiceForUpdate - 1].Id;

                                string nameOfGroupForUpdate =
                                    groupsForUpdate[groupChoiceForUpdate - 1].Name;

                                WriteLine($"Студенты группы {nameOfGroupForUpdate}:");

                                var groupStudentsForUpdate =
                                    _studentService.GetByGroupId(selectedGroupIdForUpdate);

                                if (groupStudentsForUpdate.Count == 0)
                                {
                                    WriteLine("В этой группе нет студентов.");
                                    break;
                                }

                                for (int i = 0; i < groupStudentsForUpdate.Count; i++)
                                {
                                    WriteLine($"{i + 1}. {groupStudentsForUpdate[i].FullName}");
                                }

                                Write("Введите порядковый номер студента из списка (0 - назад): ");

                                if (int.TryParse(ReadLine(), out int studentChoiceForUpdate))
                                {
                                    if (studentChoiceForUpdate == 0)
                                    {
                                        break;
                                    }

                                    if (studentChoiceForUpdate < 1 ||
                                        studentChoiceForUpdate > groupStudentsForUpdate.Count)
                                    {
                                        WriteLine("Ошибка: необходимо выбрать номер студента из списка.");
                                        break;
                                    }

                                    int selectedStudentId =
                                        groupStudentsForUpdate[studentChoiceForUpdate - 1].Id;

                                    Write("Введите новое ФИО (0 - назад, Enter - пропустить): ");
                                    string? inputFullName = ReadLine();

                                    if (inputFullName == "0")
                                    {
                                        break;
                                    }

                                    string? newFullName = null;

                                    if (inputFullName == "")
                                    {
                                        newFullName = null;
                                    }
                                    else if (string.IsNullOrWhiteSpace(inputFullName))
                                    {
                                        WriteLine("Ошибка: ФИО не может быть пустым.");
                                        break;
                                    }
                                    else
                                    {
                                        newFullName = inputFullName;
                                    }

                                    Write("Введите новый номер группы (0 - назад, Enter - пропустить): ");
                                    string? inputGroup = ReadLine();

                                    if (inputGroup == "0")
                                    {
                                        break;
                                    }

                                    int? newGroup = null;

                                    if (inputGroup == "")
                                    {
                                        newGroup = null;
                                    }
                                    else if (int.TryParse(inputGroup, out int newGroupId))
                                    {
                                        if (_groupService.GroupExists(newGroupId))
                                        {
                                            newGroup = newGroupId;
                                        }
                                        else
                                        {
                                            WriteLine("Ошибка: такой группы не существует.");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        WriteLine("Ошибка: необходимо ввести число.");
                                        break;
                                    }

                                    if (newFullName == null && newGroup == null)
                                    {
                                        WriteLine("Изменений нет.");
                                        break;
                                    }

                                    _studentService.UpdateStudent(
                                        selectedStudentId,
                                        newFullName,
                                        newGroup);

                                    WriteLine("Студент успешно изменён.");
                                }
                                else
                                {
                                    WriteLine("Ошибка: необходимо ввести число.");
                                }
                            }
                            else
                            {
                                WriteLine("Ошибка: необходимо ввести число.");
                            }

                            break;

                        case 5:
                            return;
                    }
                }
            }
            else
            {
                WriteLine("Ошибка: необходимо ввести число.");
            }
        }
    }
}