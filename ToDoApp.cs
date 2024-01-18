using System;
using System.Collections.Generic;

namespace TodoApp {

  class Todo {
    public int ID {get; set;}  
    public string Title {get; set;}
    public string Description {get; set;}
    public DateTime DueDate {get; set;}
    public bool IsComplete {get; set;}
  }

  class TodoService {

    private List<Todo> todos = new List<Todo>();
    
    public void AddTodo(Todo todo) {
      todos.Add(todo);
    }

    public List<Todo> GetTodos() {
      return todos; 
    } 

    public void UpdateTodoStatus(int id, bool status) {
      todos.Find(t => t.ID == id).IsComplete = status;
    }

  }

  class Program {

    static void Main(string[] args) {
      
      TodoService service = new TodoService();
      string choice = "";

      while (choice != "X") {

        Console.WriteLine("\n** TODO MENU **\n"); 
        Console.WriteLine("A. Add New Todo");
        Console.WriteLine("V. View Todos");
        Console.WriteLine("M. Mark Todo Complete");
        Console.WriteLine("X. Exit");

        choice = Console.ReadLine().ToUpper();

        switch(choice) {

  case "A":
    // Code to add todo
    Console.Write("Enter Title: ");
    string title = Console.ReadLine();
    
    Console.Write("Enter Description: ");
    string desc = Console.ReadLine();
    
    Console.Write("Enter Due Date (mm/dd/yyyy): ");
    DateTime dueDate = DateTime.Parse(Console.ReadLine());
    
    Todo newTodo = new Todo{
      Title = title,
      Description = desc,
      DueDate = dueDate
    };
    
    service.AddTodo(newTodo);
    
    Console.WriteLine("Todo Added!");
    break;

  case "V":
    // Code to view todos
    List<Todo> todos = service.GetTodos();
    
    Console.WriteLine("ID\tTitle\t\tDue");
    foreach(var todo in todos) {
      Console.WriteLine($"{todo.ID}\t{todo.Title}\t{todo.DueDate}"); 
    }
    break;

  case "M":
    // Code to update todo 
    
    Console.Write("Enter ID of todo to mark as complete: ");
    int id = Int32.Parse(Console.ReadLine());
  
    service.UpdateTodoStatus(id, true);
    
    Console.WriteLine("Updated status!");            
    break;
}
      }

    }

  }

}