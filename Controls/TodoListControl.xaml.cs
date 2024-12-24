using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using TodoList.Models;

namespace TodoList.Controls
{
    public sealed partial class TodoListControl : UserControl
    {
        public static readonly DependencyProperty TodoItemsProperty =
            DependencyProperty.Register(nameof(TodoItems), typeof(ObservableCollection<TodoItem>),
                typeof(TodoListControl), new PropertyMetadata(null));

        public ObservableCollection<TodoItem> TodoItems
        {
            get => (ObservableCollection<TodoItem>)GetValue(TodoItemsProperty);
            set => SetValue(TodoItemsProperty, value);
        }

        public event EventHandler<TodoItem> TodoCompleted;
        public event EventHandler<TodoItem> TodoDeleted;

        public TodoListControl()
        {
            this.InitializeComponent();
        }

        private void OnTodoCompleted(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.DataContext is TodoItem todoItem)
            {
                TodoCompleted?.Invoke(this, todoItem);
            }
        }

        private void OnDeleteTodo(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is TodoItem todoItem)
            {
                TodoDeleted?.Invoke(this, todoItem);
            }
        }
    }
}
