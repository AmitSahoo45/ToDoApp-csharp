using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Controllers
{
    internal class Requests
    {
        public static void AddAToDo()
        {
            Console.WriteLine("Add a ToDo");
        }

        public static void CompleteAToDo()
        {
            Console.WriteLine("Complete a ToDo");
        }

        public static void DeleteAToDo()
        {
            Console.WriteLine("Delete a ToDo");
        }

        public static void ViewAllToDos()
        {
            Console.WriteLine("List all ToDos");
        }
    }
}
