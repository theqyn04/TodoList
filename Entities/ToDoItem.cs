namespace Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public bool IsComplete { get; set; }
    }
}
