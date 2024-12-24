using System.Collections.ObjectModel;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoViewModel
    {
        public ObservableCollection<TodoItem> TodoItems { get; } = new();

        public void AddTodo(string title, string description = "")
        {
            TodoItems.Add(new TodoItem 
            { 
                Title = title,
                Description = description
            });
        }

        public void CompleteTodo(TodoItem item)
        {
            if (item != null)
            {
                item.IsCompleted = true;
                item.CompletedAt = DateTime.Now;
            }
        }

        public void RemoveTodo(TodoItem item)
        {
            if (item != null)
            {
                TodoItems.Remove(item);
            }
        }
    }
}
