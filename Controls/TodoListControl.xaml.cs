using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using TodoList.Models;

namespace TodoList.Controls
{
    /// <summary>
    /// 自定义的Todo列表控件
    /// 提供Todo项的显示、完成状态切换和删除功能
    /// </summary>
    public sealed partial class TodoListControl : UserControl
    {
        /// <summary>
        /// Todo项集合的依赖属性
        /// 支持数据绑定和UI自动更新
        /// </summary>
        public static readonly DependencyProperty TodoItemsProperty =
            DependencyProperty.Register(nameof(TodoItems), typeof(ObservableCollection<TodoItem>),
                typeof(TodoListControl), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置Todo项的可观察集合
        /// </summary>
        public ObservableCollection<TodoItem> TodoItems
        {
            get => (ObservableCollection<TodoItem>)GetValue(TodoItemsProperty);
            set => SetValue(TodoItemsProperty, value);
        }

        /// <summary>
        /// 当Todo项被标记为完成时触发的事件
        /// </summary>
        public event EventHandler<TodoItem> TodoCompleted;

        /// <summary>
        /// 当Todo项被删除时触发的事件
        /// </summary>
        public event EventHandler<TodoItem> TodoDeleted;

        public TodoListControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 处理Todo项完成状态改变的事件
        /// </summary>
        /// <param name="sender">事件源（CheckBox）</param>
        /// <param name="e">事件参数</param>
        private void OnTodoCompleted(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.DataContext is TodoItem todoItem)
            {
                TodoCompleted?.Invoke(this, todoItem);
            }
        }

        /// <summary>
        /// 处理Todo项删除的事件
        /// </summary>
        /// <param name="sender">事件源（Button）</param>
        /// <param name="e">事件参数</param>
        private void OnDeleteTodo(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is TodoItem todoItem)
            {
                TodoDeleted?.Invoke(this, todoItem);
            }
        }
    }
}
