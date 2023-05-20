using System.ComponentModel.DataAnnotations;
using ToDoList.Models;

public class DateLessThanActualAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
  {
    var todoItem = (TodoItem)validationContext.ObjectInstance;

    if (todoItem.Date == null)
      return new ValidationResult("A data é obrigatória.");

    return todoItem.Date < DateTime.Now.Date
    ? new ValidationResult("A data do lembrete deve ser uma data futura.")
    : ValidationResult.Success;
  }
}