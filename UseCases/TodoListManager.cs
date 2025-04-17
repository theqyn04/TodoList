using Entities;

namespace UseCases
{
    public class TodoListManager
    {
        private readonly IToDoItemRepository _repository;

        public TodoListManager(IToDoItemRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<ToDoItem> GetTodoItems()
        { 
            return _repository.GetTodoItems();
        }

        public void AddTodoItem(ToDoItem item)
        {
            _repository.AddTodoItem(item);
        }

        public void MarkComplete(int id)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                item.IsComplete = true;

            }
            _repository.Update(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
