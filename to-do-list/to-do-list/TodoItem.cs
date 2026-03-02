namespace to_do_list;

public class TodoItem
{
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime? Deadline { get; set; }

    public string DeadlineText => Deadline.HasValue
        ? $"Due: {Deadline.Value:MMM dd, yyyy}"
        : "No deadline";
}