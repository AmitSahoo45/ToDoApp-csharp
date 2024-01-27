using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    interface IToDoList
    {
        void AddTodo();
        void Complete(int todoId);
        void Delete(int todoId);
        void List();
        void Pending();
    }

    internal class ToDoList : IToDoList
    {
        public List<Todo> Todos { get; set; }

        public ToDoList()
        {
            Todos = new List<Todo>();
        }

        public void AddTodo()
        {
            string title, description;
            DateTime dueDate;

            do
            {
                Console.WriteLine("Enter a title: ");
                title = Console.ReadLine();
            } while (string.IsNullOrEmpty(title));

            do
            {
                Console.WriteLine("Enter a description: ");
                description = Console.ReadLine();
            } while (string.IsNullOrEmpty(description));

            do
            {
                Console.WriteLine("Enter a due date in dd/mm/yyyy format: ");
                string dueDateInput = Console.ReadLine();
                if (DateTime.TryParseExact(
                        dueDateInput,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out dueDate)
                    )
                    break;

                Console.WriteLine("Invalid date format. Please enter a valid date.");
            } while (true);

            Todo newTodo = new Todo
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                CreatedAt = DateTime.Now,
                CompleteStatus = TaskStatus.Started
            };

            Todos.Add(newTodo);

            Console.WriteLine("Todo added successfully!");
        }


        public void Complete(int todoId)
        {
            Todo todo = Todos.FirstOrDefault(t => t.TodoId == todoId);

            if (todo == null)
            {
                Console.WriteLine("Todo not found!");
                return;
            }

            todo.CompleteStatus = TaskStatus.Complete;
            Console.WriteLine("Todo marked as completed!");
        }

        public void Delete(int todoId)
        {
            Todo todo = Todos.FirstOrDefault(t => t.TodoId == todoId);
            Todos.Remove(todo);
            Console.WriteLine("Todo deleted successfully!");
        }

        public void List()
        {
            if (Todos.Count == 0)
            {
                Console.WriteLine("No todos found!");
                return;
            }

            Console.WriteLine("id\tTitle\tDueDate\tCreatedAt\tStatus\tDescription");

            foreach (Todo todo in Todos)
                Console.WriteLine($"{todo.TodoId}\t{todo.Title}\t{todo.DueDate}\t{todo.CreatedAt}\t{todo.CompleteStatus}\t{todo.Description}");
        }

        public void Pending()
        {
            List<Todo> pendingTodos = Todos.Where(t => t.CompleteStatus == TaskStatus.Started).ToList();

            if (pendingTodos.Count == 0)
            {
                Console.WriteLine("No pending todos found!");
                return;
            }

            Console.WriteLine("id\tTitle\tDueDate\tCreatedAt\tStatus\tDescription");

            foreach (Todo todo in pendingTodos)
                Console.WriteLine($"{todo.TodoId}\t{todo.Title}\t{todo.DueDate}\t{todo.CreatedAt}\t{todo.CompleteStatus}\t{todo.Description}");
        }
    }
}
