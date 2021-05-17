using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace les_1
{
    class TodoProgram
    {
        static public List<Todo> Todos;

        static void Main(string[] args)
        {
            Todos = new List<Todo>() { };

            string input = "";

            while (input != "q")
            {
                Console.Clear();
                Console.WriteLine("TODOLIST");
                Console.WriteLine("--------");
                PrintTodos();

                input = AskInput();

                if (input == "a")
                {
                    AddItem();
                }
                else if (input == "r")
                {
                    RemoveItem();
                }
                else if (input == "c")
                {
                    ChangeItem();
                }
                else if (input == "h")
                {
                    HandleItem();
                }
            }
        }

        static void PrintTodos()
        {
            foreach (Todo todo in GetAllTodos()) 
            {
                if (todo.Status == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (todo.Status == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write($"{todo.TodoId}. {todo.Naam}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }

        static List<Todo> GetAllTodos()
        {
            Todos.Clear();
            using (var db = new TodoContext())
            {
                Todos.AddRange(db.Todos.ToList());
            }

            return Todos;
        }

        static Todo GetTodo(int id)
        {
            Todo todo = null;

            using (var db = new TodoContext())
            {
                todo = db.Todos.FirstOrDefault(t => t.TodoId == id);
            }

            return todo;
        }

        static string AskInput()
        {
            Console.WriteLine("\na. Add Item");
            Console.WriteLine("r. Remove item");
            Console.WriteLine("c. Change item");
            Console.WriteLine("h. handle item");
            Console.WriteLine("q. Quit");

            Console.Write("\nWhat do you want to do (a, r, c, h or q)? ");
            return Console.ReadLine();
        }

        static void AddItem()
        {
            Console.Write("Item dat je wilt toevoegen: ");
            string newItem = Console.ReadLine();

            using (var db = new TodoContext())
            {
                db.Todos.Add(new Todo { Naam = newItem, Status = -1 });
                db.SaveChanges();
            }
        }

        static void RemoveItem()
        {
            Console.Write("Welk item wil je verwijderen? ");
            int nItem = ReadInt();

            Todo todo = GetTodo(nItem);

            using (var db = new TodoContext())
            {
                db.Todos.Remove(todo);
                db.SaveChanges();
            }
        }

        static void ChangeItem()
        {
            Console.Write("Welk item wil je veranderen? ");
            int nItem = ReadInt();

            Todo todo = GetTodo(nItem);

            Console.WriteLine($"Vorige waarde: {todo.Naam}");
            Console.Write("Nieuwe waarde: ");
            string newItem = Console.ReadLine();

            using (var db = new TodoContext())
            {
                todo.Naam = newItem;
                db.Todos.Update(todo);
                db.SaveChanges();
            }
        }

        static void HandleItem()
        {
            Console.Write("Kies een item om af te handelen: ");
            int nItem = ReadInt();

            Todo todo = GetTodo(nItem);

            Console.WriteLine($"Todo: {todo.Naam} | Status: {todo.Status}");
            Console.WriteLine("-1. Nog niet begonnen");
            Console.WriteLine("0. In Progess");
            Console.WriteLine("1. Afgehandeld");
            
            Console.Write("\nWelke status wil je het geven? ");
            int status = ReadInt();

            using (var db = new TodoContext())
            {
                todo.Status = status;
                db.Todos.Update(todo);
                db.SaveChanges();
            }
        }

        static int ReadInt()
        {
            string nItem = Console.ReadLine();
            int number;
            while (!int.TryParse(nItem, out number))
            {
                Console.Write("Geef een geldig getal: ");
                nItem = Console.ReadLine();
            }

            return number;
        }
    }
}
