using Entities;
using UseCases;

namespace Infratructure
{
    public class InMemoryToDoItemRepository : IToDoItemRepository
    {
        private readonly List<ToDoItem> _items;

        public InMemoryToDoItemRepository()
        {
            _items = new List<ToDoItem>();
        }

        public void AddTodoItem(ToDoItem item)
        {
            _items.Add(item);
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public ToDoItem? GetById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<ToDoItem> GetTodoItems()
        {
            return _items;
        }

        public void Update(ToDoItem? item) // Thêm dấu ? để khớp với interface
        {
            if (item == null) return;

            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Text = item.Text;
                existingItem.IsComplete = item.IsComplete;
            }
        }
    }
}