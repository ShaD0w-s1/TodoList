using System.Collections.ObjectModel;
using TodoList.Models;

namespace TodoList.ViewModels
{
    /// <summary>
    /// Todo列表的视图模型，负责管理Todo项的集合和相关操作
    /// 实现了MVVM模式中的ViewModel层
    /// </summary>
    public class TodoViewModel
    {
        /// <summary>
        /// 获取Todo项的可观察集合
        /// 当集合变化时会自动通知UI更新
        /// </summary>
        public ObservableCollection<TodoItem> TodoItems { get; } = new();

        /// <summary>
        /// 添加新的Todo项到集合中
        /// </summary>
        /// <param name="title">Todo项的标题</param>
        /// <param name="description">Todo项的描述（可选）</param>
        public void AddTodo(string title, string description = "")
        {
            TodoItems.Add(new TodoItem 
            { 
                Title = title,
                Description = description
            });
        }

        /// <summary>
        /// 将指定的Todo项标记为已完成
        /// </summary>
        /// <param name="item">要完成的Todo项</param>
        public void CompleteTodo(TodoItem item)
        {
            if (item != null)
            {
                item.IsCompleted = true;
                item.CompletedAt = DateTime.Now;
            }
        }

        /// <summary>
        /// 从集合中移除指定的Todo项
        /// </summary>
        /// <param name="item">要移除的Todo项</param>
        public void RemoveTodo(TodoItem item)
        {
            if (item != null)
            {
                TodoItems.Remove(item);
            }
        }
    }
}
