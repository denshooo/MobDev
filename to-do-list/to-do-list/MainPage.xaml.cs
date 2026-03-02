using System.Collections.ObjectModel;

namespace to_do_list;

public partial class MainPage : ContentPage
{
    public ObservableCollection<TodoItem> ActiveItems { get; set; } = new();
    public ObservableCollection<TodoItem> FinishedItems { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        var text = TaskEntry.Text?.Trim();
        if (!string.IsNullOrEmpty(text))
        {
            ActiveItems.Add(new TodoItem
            {
                Title = text,
                Deadline = DeadlinePicker.Date
            });
            TaskEntry.Text = string.Empty;
        }
    }

    private void OnTaskChecked(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value) return;

        var checkbox = sender as CheckBox;
        var item = checkbox?.BindingContext as TodoItem;

        if (item != null && ActiveItems.Contains(item))
        {
            ActiveItems.Remove(item);
            item.IsCompleted = true;
            FinishedItems.Add(item);
        }
    }
}