namespace TodoList.Models
{
    /// <summary>
    /// 表示一个待办事项的数据模型
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// 获取或设置待办事项的唯一标识符
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 获取或设置待办事项的标题
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 获取或设置待办事项的详细描述
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 获取或设置待办事项是否已完成
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// 获取或设置待办事项的创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 获取或设置待办事项的完成时间
        /// 如果尚未完成，则为 null
        /// </summary>
        public DateTime? CompletedAt { get; set; }
    }
}
