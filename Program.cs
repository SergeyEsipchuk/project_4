using System.Globalization;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int n = 0;
            int up = 2;
            int left = 0;
            string Arrow = "->";

            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape)
            {

                if (key.Key == ConsoleKey.DownArrow)
                {
                    up++;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    up--;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    while (key.Key != ConsoleKey.Backspace)
                    {
                        Console.Clear();
                        drew_note_all(n,up-2);
                        key = Console.ReadKey();
                    }
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    --n;
                    n = n_arr(n);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    ++n;
                    n = n_arr(n);
                }
                Console.Clear();

                int lenght_List = drew_note(n);
                if (lenght_List != 0)
                {
                    if (up < 2)
                    {
                        up = lenght_List + 2;
                    }
                    if (up > lenght_List + 2)
                    {
                        up = 2;
                    }
                    if (up > (lenght_List + 1))
                    {
                        left = 17;
                        Arrow = "<-";
                        if (key.Key == ConsoleKey.F)
                        {
                            Console.Clear();
                            add_new_note(key);
                        }
                    }
                    else
                    {
                        left = 0;
                        Arrow = "->";
                    }

                    Console.SetCursorPosition(left, up);
                    Console.WriteLine(Arrow);
                }
                key = Console.ReadKey();
            }
        }
        static int drew_note(int n)
        {
            Console.WriteLine("Ежедневник");
            var all_list = List_note();
            int Lenght_arr = all_list.Count;
            var list = all_list[n];
            if (list[0].name == " ")
            {
                Console.WriteLine("Нету никаких записей . ");
                return (0);
            }
            else
            {
                Console.WriteLine(list[1].date);
                foreach (note decription in list)
                {
                    Console.WriteLine(decription.name);
                }
                Console.WriteLine("Добавить заметку  ");
                return (list.Count);
            }
        }
        static int n_arr(int n)
        {
            var lenght_List_all = List_note().Count;
            if (n == lenght_List_all)
            {
                n = 0;
                return (n);
            }
            else if (n < 0)
            {
                n = lenght_List_all - 1;
                return (n);
            }
            else
            {
                return (n);
            }
        }
        static void add_new_note(ConsoleKeyInfo key)
        {
            var list = new List<note> { };
            DateTime nowTime = DateTime.Now;
            ConsoleKeyInfo key_end = key;
            while (key_end.Key != ConsoleKey.Backspace)
            {
                var note_arr = new note()
                {
                    name = "",
                    date = " ",
                    time = " ",
                    description = " ",
                    deadline = " "
                };
                Console.WriteLine("Введите название заметки : ");
                note_arr.name = Console.ReadLine();
                note_arr.date = nowTime.ToString();
                note_arr.time = nowTime.ToLongTimeString();
                Console.WriteLine("Введите описание заметки : ");
                note_arr.description = Console.ReadLine();
                Console.WriteLine("Введите дедлайн : ");
                note_arr.deadline = Console.ReadLine();

                key_end = Console.ReadKey();
                list.Add(note_arr);
                Console.Clear();
            }
            List_note().Add(list);
        }
        static void drew_note_all(int n, int up)
        {
            var arr = List_note();
            var element = arr[n];
            var elem = element[up];
            Console.WriteLine("Название заметки : " + elem.name);
            Console.WriteLine("Дата добавления заметки : " + elem.date);
            Console.WriteLine("Время добавления  заметки : " + elem.time);
            Console.WriteLine("Описание заметки : " + elem.description);
            Console.WriteLine("Дедлайн : " + elem.deadline);
        }
        static List<List<note>> List_note()
        {
            List<List<note>> List_note = new List<List<note>>
            {
                new List<note>
                {
                    new note
                    {
                        name = "  День рождение кота",
                        date = "07.10.22",
                        time = "15:00",
                        description = "Поздравить кота с др.",
                        deadline = "12.12.22"
                    },
                    new note()
                    {
                        name = "  Практическая по Дискретной математике",
                        date = "07.10.22",
                        time = "15:34",
                        description = "Файл ЭЛЕМЕНТЫ  ТЕОРИИ МНОЖЕСТВ \n 1.Подмножества (просмотреть основные понятия, примеры) стр.11-12.Выполнить упражнения на стр.13-14",
                        deadline = "16.10.22"
                    }
                },
                new List<note>
                {
                    new note()
                    {
                        name = " ",
                        date = "08.10.22" ,
                        time = " ",
                        description = " ",
                        deadline = " "
                    }
                },
                new List<note>
                {
                    new note()
                    {
                       name = "  Практическая по философии",
                       date = "09.10.22",
                       time = "16:16",
                       description = "Выполнить работу в тетради , отвтетить на вопросы развернуто.",
                       deadline = "10.12.22"
                    },
                    new note()
                    {
                        name = "  Практическая по AAC",
                        date = "09.10.22",
                        time = "15:30",
                        description = "1. Необходимо установить программу Handy Recovery 5.5 (программное решение, предназначенное для восстановления данных, которое может помочь вернуть случайно удаленные файлы со всех типов дисков);\r\n2. Создайте файл, удалите его, а затем восстановите его с помощью данной программы.\r\n3. Составить отчёт по проделанной работе с добавлением скриншотов из программы",
                        deadline = "20.11.22"
                    },
                },
            };
            return (List_note);
        }
    }
}