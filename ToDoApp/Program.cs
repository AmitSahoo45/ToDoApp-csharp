using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            var todoList = new ToDoList();

            while (command != "X")
            {
                Console.WriteLine("Enter a command: ");
                Console.WriteLine("A - Add a ToDo");
                Console.WriteLine("C - Complete a ToDo");
                Console.WriteLine("D - Delete a ToDo");
                Console.WriteLine("L - List all ToDos");
                Console.WriteLine("P - View Pending Tasks");
                Console.WriteLine("X - Exit");

                command = Console.ReadLine().ToUpper();

                switch (command)
                {
                    case "A":
                        todoList.AddTodo();
                        break;

                    case "C":
                        int todoId;
                        do
                        {
                            Console.WriteLine("Enter the ID of the ToDo you want to complete: ");
                            string todoIdInput = Console.ReadLine();

                            if (int.TryParse(todoIdInput, out todoId))
                                break;

                            Console.WriteLine("Invalid ID. Please enter a valid ID.");
                        } while (true);

                        todoList.Complete(todoId);
                        break;

                    case "D":
                        do
                        {
                            Console.WriteLine("Enter the ID of the ToDo you want to delete: ");
                            string todoIdInput = Console.ReadLine();

                            if (int.TryParse(todoIdInput, out todoId))
                                break;

                            Console.WriteLine("Invalid ID. Please enter a valid ID.");
                        } while (true);

                        todoList.Delete(todoId);
                        break;

                    case "L":
                        todoList.List();
                        break;

                    case "P":
                        todoList.Pending();
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}
