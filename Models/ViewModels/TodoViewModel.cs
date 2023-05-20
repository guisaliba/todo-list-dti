using System.Collections.Generic;

namespace ToDoList.Models.ViewModels
{
  public class TodoViewModel
  {
    public List<TodoItem> TodoList { get; set; }
    public TodoItem Todo { get; set; }

    public Dictionary<DateTime, List<TodoItem>> TodoDictionary { get; set; }

  }
}