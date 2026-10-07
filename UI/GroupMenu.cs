namespace StudentAttendanceSystem.UI;

using static System.Console;
using StudentAttendanceSystem.Services;

public class GroupMenu
{
    private readonly GroupService _groupService;

    private readonly string[] groupActions =
    {
        "1. Просмотреть",
        "2. Добавить",
        "3. Удалить",
        "4. Изменить",
        "5. Назад"
    };

    public GroupMenu(GroupService groupService)
    {
        _groupService = groupService;
    }

    public void ShowMenu()
    {
        while (true)
        {
            foreach (var action in groupActions)
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
                            var groups = _groupService.GetAll();

                            if (groups.Count == 0)
                            {
                                WriteLine("Групп пока нет.");
                            }
                            else
                            {
                                for (int i = 0; i < groups.Count; i++)
                                {
                                    WriteLine($"{i + 1}. {groups[i].Name}");
                                }
                            }

                            Write("Нажмите Enter, чтобы вернуться назад...");
                            ReadLine();

                            break;

                        case 2:
                            Write("Введите название группы (0 - назад): ");
                            string? name = ReadLine();

                            if (name == "0")
                            {
                                break;
                            }

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                WriteLine("Ошибка: название не может быть пустым.");
                                break;
                            }

                            _groupService.AddGroup(name);
                            WriteLine("Группа успешно добавлена.");

                            break;

                        case 3:
                            var groupsForDelete = _groupService.GetAll();

                            if (groupsForDelete.Count == 0)
                            {
                                WriteLine("Групп пока нет.");
                                break;
                            }

                            for (int i = 0; i < groupsForDelete.Count; i++)
                            {
                                WriteLine($"{i + 1}. {groupsForDelete[i].Name}");
                            }

                            Write("Введите порядковый номер группы из списка (0 - назад): ");

                            if (int.TryParse(ReadLine(), out int groupChoice))
                            {
                                if (groupChoice == 0)
                                {
                                    break;
                                }

                                if (groupChoice < 1 || groupChoice > groupsForDelete.Count)
                                {
                                    WriteLine("Ошибка: необходимо выбрать номер группы из списка.");
                                    break;
                                }

                                int selectedGroupId = groupsForDelete[groupChoice - 1].Id;

                                _groupService.DeleteGroup(selectedGroupId);

                                WriteLine("Группа успешно удалена.");
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

                                Write("Введите новое название группы (0 - назад): ");
                                string? inputName = ReadLine();

                                if (inputName == "0")
                                {
                                    break;
                                }

                                if (string.IsNullOrWhiteSpace(inputName))
                                {
                                    WriteLine("Ошибка: название не может быть пустым.");
                                    break;
                                }

                                _groupService.UpdateGroup(
                                    selectedGroupIdForUpdate,
                                    inputName);

                                WriteLine("Название группы успешно изменено.");
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