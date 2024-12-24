using System.Text.Json;
using TodoList.Models;

namespace TodoList.Helpers
{
    public static class StorageHelper
    {
        private const string TodoFileName = "todos.json";

        public static async Task SaveTodosAsync(IEnumerable<TodoItem> todos)
        {
            var folderPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var filePath = Path.Combine(folderPath, TodoFileName);
            var json = JsonSerializer.Serialize(todos);
            await File.WriteAllTextAsync(filePath, json);
        }

        public static async Task<List<TodoItem>> LoadTodosAsync()
        {
            try
            {
                var folderPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
                var filePath = Path.Combine(folderPath, TodoFileName);
                
                if (File.Exists(filePath))
                {
                    var json = await File.ReadAllTextAsync(filePath);
                    return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
                }
            }
            catch (Exception)
            {
                // Log error in production
            }
            
            return new List<TodoItem>();
        }
    }
}
