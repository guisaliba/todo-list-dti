using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

public class TodoItem
{
  public int? Id { get; set; }

  [Required(ErrorMessage = "O nome do lembrete é obrigatório.")]
  public string Name { get; set; }

  [Display(Name = "Data")]
  [DataType(DataType.Date)]
  [Required(ErrorMessage = "A data do lembrete é obrigatória.")]
  [DateLessThanActualAttribute]
  public DateTime Date { get; set; }
}