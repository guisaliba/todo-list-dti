using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Globalization;
using ToDoList.Models;
using ToDoList.Models.ViewModels;
using System.Data;

namespace ToDoList.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult ResetTable()
  {
    using (SqliteConnection con = new SqliteConnection("Data Source=db.sqlite"))
    {
      using (var tableCmd = con.CreateCommand())
      {
        con.Open();
        tableCmd.CommandText = "DROP TABLE IF EXISTS todo";
        tableCmd.ExecuteNonQuery();

        tableCmd.CommandText = "CREATE TABLE todo (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Date DATETIME)";
        tableCmd.ExecuteNonQuery();
      }
    }

    return RedirectToAction("Index");
  }

  [HttpGet]
  public IActionResult Index()
  {
    var todoListViewModel = Get();

    TempData.Put("todoList", todoListViewModel);

    return View(todoListViewModel);
  }

  internal TodoViewModel Get()
  {
    List<TodoItem> todoList = new List<TodoItem>();
    Dictionary<DateTime, List<TodoItem>> todoDictionary = new Dictionary<DateTime, List<TodoItem>>();

    using (SqliteConnection con = new SqliteConnection("Data Source=db.sqlite"))
    {
      using (var tableCmd = con.CreateCommand())
      {
        con.Open();
        tableCmd.CommandText = "SELECT * FROM todo ORDER BY Date";

        using (var reader = tableCmd.ExecuteReader())
        {
          if (reader.HasRows)
          {
            while (reader.Read())
            {
              var todoItem = new TodoItem
              {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Date = reader.GetDateTime(2)
              };

              if (todoDictionary.ContainsKey(todoItem.Date))
              {
                todoDictionary[todoItem.Date].Add(todoItem);
              }
              else
              {
                todoDictionary.Add(todoItem.Date, new List<TodoItem> { todoItem });
              }

              todoList.Add(todoItem);
            }
          }
          else
          {
            return new TodoViewModel
            {
              TodoList = todoList
            };
          }
        }
      }
    }

    return new TodoViewModel
    {
      TodoList = todoList,
      TodoDictionary = todoDictionary
    };
  }

  [HttpPost]
  public IActionResult Create(TodoItem todo)
  {

    if (!ModelState.IsValid)
    {
      return View("Index");
    }

    using (SqliteConnection con =
      new SqliteConnection("Data Source=db.sqlite"))
    {
      using (var tableCmd = con.CreateCommand())
      {
        con.Open();
        tableCmd.CommandText = $"INSERT INTO todo (name, date) VALUES (@Name, @ToDoDate)";

        tableCmd.Parameters.Add("@Name", SqliteType.Text).Value = todo.Name;
        tableCmd.Parameters.Add("@ToDoDate", (SqliteType)SqlDbType.DateTime).Value = todo.Date;

        try
        {
          tableCmd.ExecuteNonQuery();
        }
        catch (Exception err)
        {
          Console.WriteLine(err.Message);
        }
      }
    }

    return Redirect("https://localhost:7253");
  }

  [HttpPost]
  public JsonResult Delete(int id)
  {
    using (SqliteConnection con =
      new SqliteConnection("Data Source=db.sqlite"))
    {
      using (var tableCmd = con.CreateCommand())
      {
        con.Open();
        tableCmd.CommandText = $"DELETE FROM todo WHERE id = {id}";
        tableCmd.ExecuteNonQuery();
      }
    }

    return Json(new { });
  }
}
