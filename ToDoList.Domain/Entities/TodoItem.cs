namespace ToDoList.Domain.Entities;

public class TodoItem
{
    public const int MaxTitleLength = 50;

    private TodoItem(Guid id, string title, bool isCompleted, DateTime createdAt)
    {
        Id = id;
        Title = title;
        IsCompleted = isCompleted;
        CreatedAt = createdAt;
    }
    
    public Guid Id { get; }
    public string Title { get; }
    public bool IsCompleted { get; }
    public DateTime CreatedAt { get; }

    public static (TodoItem TodoItem, string Error) Create(Guid id, string title, bool isCompleted, DateTime createdAt)
    {
        var error = ValidateParameters(title);
        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var todoItem = new TodoItem(id, title, isCompleted, createdAt);
        return (todoItem, error);
    }

    private static string ValidateParameters(string title)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > MaxTitleLength)
        {
            return "Title lenght must be 50 characters or less.";
        }
        
        return string.Empty;
    }
}