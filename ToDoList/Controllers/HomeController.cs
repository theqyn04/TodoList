using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using UseCases;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoListManager _listManager;

        public HomeController(TodoListManager listManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _listManager = listManager;
        }

        public IActionResult Index()
        {
            var todoItems = _listManager.GetTodoItems();

            return View(new TodoListViewModel()
            {
                Items = todoItems.Select(ti => new Item()
                {
                    Id = ti.Id,
                    Text = ti.Text,
                    IsComplete = ti.IsComplete,
                })
            });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Item item)
        {
            _listManager.AddTodoItem(new ToDoItem()
            {
                Id = item.Id,
                Text = item.Text,
                IsComplete = false
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _listManager.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleComplete(int id, bool isComplete)
        {
            _listManager.MarkComplete(id);
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
