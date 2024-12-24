using System.Text.Json;
using TodoList.Models;

namespace TodoList.Helpers
{
    /// <summary>
    /// 提供Todo项的持久化存储功能
    /// 使用JSON格式将数据保存到应用程序的本地存储中
    /// </summary>
    public static class StorageHelper
    {
        /// <summary>
        /// 存储Todo项的JSON文件名
        /// </summary>
        private const string TodoFileName = "todos.json";

        /// <summary>
        /// 异步保存Todo项集合到本地存储
        /// </summary>
        /// <param name="todos">要保存的Todo项集合</param>
        /// <returns>表示异步操作的任务</returns>
        public static async Task SaveTodosAsync(IEnumerable<TodoItem> todos)
        {
            var folderPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var filePath = Path.Combine(folderPath, TodoFileName);
            var json = JsonSerializer.Serialize(todos);
            await File.WriteAllTextAsync(filePath, json);
        }

        /// <summary>
        /// 从本地存储异步加载Todo项集合
        /// </summary>
        /// <returns>
        /// 返回加载的Todo项集合。
        /// 如果文件不存在或发生错误，返回空列表。
        /// </returns>
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
