﻿namespace ToDoList.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public bool IsComplete { get; set; }
    }
}
