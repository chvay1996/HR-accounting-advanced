using System;
using System.Collections.Generic;

namespace HR_accounting_advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dossier = new Dictionary<string, string>();
            dossier.Add("Попов Роман Аркадьевич", "Токарь");
            dossier.Add("Черний Иван Сергеевич", "Программист");
            dossier.Add("Черний Алина Вячеславовна", "Молодая мама");
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
                                AddDossier(ref dossier);
                                break;
                            case 1:
                                DeleteDossier(ref dossier);
                                break;
                            case 2:
                                ListOfDossiers(ref dossier);
                                Clear();
                                break;
                            case 3:
                                Exit(launchingTheProgram);
                                break;
                        }
                        break;
                }
            }
        }
        static void AddDossier (ref Dictionary<string,string> dos)
        {
            Console.Write("Введите ФИО сотрудника: ");
            string fio = Convert.ToString(Console.ReadLine());

            Console.Write("Введите должность сотрудника: ");
            string post = Convert.ToString(Console.ReadLine());

            dos.Add(fio, post);

            Console.WriteLine($"Вы добавели {fio} - {post}");
            Clear();
        }
        static void DeleteDossier (ref Dictionary<string,string> dos)
        {
            ListOfDossiers(ref dos);

            Console.WriteLine("\nВведите ФМО сотрудника\n");
            string fio = Convert.ToString(Console.ReadLine());

            dos.Remove(fio);

            ListOfDossiers(ref dos);
            Clear();
        }
        static void ListOfDossiers(ref Dictionary<string,string> dos)
        {
            byte caunt = 1;
            Console.WriteLine("\nСписок всех сотрудников");

            foreach (var item in dos)
            {
                    Console.WriteLine($"{caunt}) {item.Key} - {item.Value}");
                caunt += 1;
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
            Console.ReadKey();
            Console.Clear();
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