using System;
using System.Collections.Generic;

namespace HR_accounting_advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fio = new List<string> { "Попов Роман Аркадьевич", "Черний Иван Сергеевич", "Черний Алина Вячеславовна" };
            List<string> post = new List<string> { "Токарь", "Программист", "Молодая мама" };
            string[] menu = { "Добавить", "Удалить", "Вывести все досье", "Выход" };
            int index = 0;
            bool launchingTheProgram = true;

            while (launchingTheProgram == true)
            {
                Console.SetCursorPosition(0, 0);
                Console.ResetColor();
                Console.WriteLine("\t\tМеню");

                for (int i = 0; i < menu.Length; i++)
                {
                    if (index == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index != 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index != menu.Length - 1) index++;
                        break;
                    case ConsoleKey.Enter:

                        switch (index)
                        {
                            case 0:
                                AddDossier(fio, post);
                                break;
                            case 1:
                                DeleteDossier(fio, post);
                                break;
                            case 2:
                                ListOfDossiers(fio, post);
                                break;
                            case 3:
                                Exit(launchingTheProgram);
                                break;
                        }
                        break;
                }
            }
        }
        static void AddDossier (List<string> fio, List<string> post)
        {
            Console.Write("Введите ФИО сотрудника: ");
            string addFIO = Convert.ToString(Console.ReadLine());

            Console.Write("Введите должность сотрудника: ");
            string addPost = Convert.ToString(Console.ReadLine());

            fio.Add(addFIO);
            post.Add(addPost);
            Console.WriteLine($"Вы добавели {addFIO} - {addPost}");
            Clear();
        }
        static void DeleteDossier (List<string> fio, List<string> post)
        {
            ListOfDossiers(fio,post, 0);

            Console.WriteLine("\nВведите номер сотрудника\n");
            byte namberDelete = byte.Parse(Console.ReadLine());
            fio.RemoveAt(namberDelete - 1);
            post.RemoveAt(namberDelete - 1);
            ListOfDossiers(fio,post);
        }
        static void ListOfDossiers(List<string> fio, List<string> post, int positionClear = 1)
        {
            Console.WriteLine("\nСписок всех сотрудников");

            for (int i = 0; i < fio.Count; i++)
            {
                    Console.WriteLine($"{i+1}) {fio[i]} - {post[i]}");
            }
            if(positionClear == 1)
            {
                Clear();
            }
        }
        static void Exit (bool start)
        {
            Console.Clear();
            start = false;
            Environment.Exit(0);
        }
        static void Clear()
        {
            Console.SetCursorPosition(0, 5);
            Console.ReadKey();

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("\t\t\t\t\t\t\t\t");
            }
        }
    }
}
/*Задача:
В функциях вы выполняли задание "Кадровый учёт"
Используя одну из изученных коллекций вы смогли бы сильно себе упростить код выполненной программы, ведь у нас данные это ФИО и позиция.
Поиск в данном задании не нужен.

1) добавить досье.

2) вывести все досье (в одну строку через “-” фио и должность)

3) удалить досье

4) выход*/