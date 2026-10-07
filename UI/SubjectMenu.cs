namespace StudentAttendanceSystem.UI;

using static System.Console;
using StudentAttendanceSystem.Services;

public class SubjectMenu
{
    private readonly SubjectService _subjectService;

    private readonly string[] subjectActions =
    {
        "1. Просмотреть",
        "2. Добавить",
        "3. Удалить",
        "4. Изменить",
        "5. Назад"
    };

    public SubjectMenu(SubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    public void ShowMenu()
    {
        while (true)
        {
            foreach (var action in subjectActions)
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
                            var subjects = _subjectService.GetAll();

                            if (subjects.Count == 0)
                            {
                                WriteLine("Дисциплин пока нет.");
                            }
                            else
                            {
                                for (int i = 0; i < subjects.Count; i++)
                                {
                                    WriteLine($"{i + 1}. {subjects[i].Name}");
                                }
                            }

                            Write("Нажмите Enter, чтобы вернуться назад...");
                            ReadLine();

                            break;

                        case 2:
                            Write("Введите название дисциплины (0 - назад): ");
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

                            _subjectService.AddSubject(name);
                            WriteLine("Дисциплина успешно добавлена.");

                            break;

                        case 3:
                            var subjectsForDelete = _subjectService.GetAll();

                            if (subjectsForDelete.Count == 0)
                            {
                                WriteLine("Дисциплин пока нет.");
                                break;
                            }

                            for (int i = 0; i < subjectsForDelete.Count; i++)
                            {
                                WriteLine($"{i + 1}. {subjectsForDelete[i].Name}");
                            }

                            Write("Введите порядковый номер дисциплины из списка (0 - назад): ");

                            if (int.TryParse(ReadLine(), out int subjectChoice))
                            {
                                if (subjectChoice == 0)
                                {
                                    break;
                                }

                                if (subjectChoice < 1 || subjectChoice > subjectsForDelete.Count)
                                {
                                    WriteLine("Ошибка: необходимо выбрать номер дисциплины из списка.");
                                    break;
                                }

                                int selectedSubjectId = subjectsForDelete[subjectChoice - 1].Id;

                                _subjectService.DeleteSubject(selectedSubjectId);

                                WriteLine("Дисциплина успешно удалена.");
                            }
                            else
                            {
                                WriteLine("Ошибка: необходимо ввести число.");
                            }

                            break;

                        case 4:
                            var subjectsForUpdate = _subjectService.GetAll();

                            if (subjectsForUpdate.Count == 0)
                            {
                                WriteLine("Дисциплин пока нет.");
                                break;
                            }

                            for (int i = 0; i < subjectsForUpdate.Count; i++)
                            {
                                WriteLine($"{i + 1}. {subjectsForUpdate[i].Name}");
                            }

                            Write("Введите порядковый номер дисциплины из списка (0 - назад): ");

                            if (int.TryParse(ReadLine(), out int subjectChoiceForUpdate))
                            {
                                if (subjectChoiceForUpdate == 0)
                                {
                                    break;
                                }

                                if (subjectChoiceForUpdate < 1 ||
                                    subjectChoiceForUpdate > subjectsForUpdate.Count)
                                {
                                    WriteLine("Ошибка: необходимо выбрать номер дисциплины из списка.");
                                    break;
                                }

                                int selectedSubjectIdForUpdate =
                                    subjectsForUpdate[subjectChoiceForUpdate - 1].Id;

                                Write("Введите новое название дисциплины (0 - назад): ");
                                string? newName = ReadLine();

                                if (newName == "0")
                                {
                                    break;
                                }

                                if (string.IsNullOrWhiteSpace(newName))
                                {
                                    WriteLine("Ошибка: название не может быть пустым.");
                                    break;
                                }

                                _subjectService.UpdateSubject(
                                    selectedSubjectIdForUpdate,
                                    newName);

                                WriteLine("Дисциплина успешно изменена.");
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