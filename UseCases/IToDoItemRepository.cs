using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace UseCases
{
    public interface IToDoItemRepository
    {
        void AddTodoItem(ToDoItem item);
        void Delete(int id);
        ToDoItem? GetById(int id);
        IEnumerable<ToDoItem> GetTodoItems();
        void Update(ToDoItem? item);
    }
}
