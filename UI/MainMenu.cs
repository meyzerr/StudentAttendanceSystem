namespace StudentAttendanceSystem.UI;

using static System.Console;

public class MainMenu
{
    private readonly StudentMenu _studentMenu;
    private readonly GroupMenu _groupMenu;
    private readonly SubjectMenu _subjectMenu;
    private readonly string[] mainMenuActions =
    {
        "1. Студенты",
        "2. Группы",
        "3. Дисциплины",
        "4. Посещаемость",
        "5. Статистика",
        "6. Выход"
    };

    public MainMenu(StudentMenu studentMenu, GroupMenu groupMenu, SubjectMenu subjectMenu)
    {
        _studentMenu = studentMenu;
        _groupMenu = groupMenu;
        _subjectMenu = subjectMenu; 
    }

    public void Run()
    {
        while (true)
        {
            foreach(var item in mainMenuActions)
            {
                WriteLine(item);
            }

            Write("Выберите пункт меню: ");

            if (int.TryParse(ReadLine(), out int choice))
            {
                if (choice < 1 || choice > 6)
                {
                    WriteLine("Ошибка: необходимо ввести число в диапазоне от 1 до 6.");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            _studentMenu.ShowMenu();
                            break;
                        case 2:
                            _groupMenu.ShowMenu();
                            break;
                        case 3:
                            _subjectMenu.ShowMenu();
                            break;
                        case 4:
                            
                            break;
                        case 5:
                            
                            break;
                        case 6:
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