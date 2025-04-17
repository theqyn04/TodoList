using Entities;
using Infratructure;
using UseCases;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void CreteTodoItem_And_Set_Completeed_Test()
        {
            //Arrange
            var mockRepository = new InMemoryToDoItemRepository();
            var todoListManager = new TodoListManager(mockRepository);

            var todoItem = new ToDoItem { Id = 1, Text = "Test Item", IsComplete = false };

            //Act
            todoListManager.AddTodoItem(todoItem);
            todoListManager.MarkComplete(1);

            //Assert
            Assert.True(todoListManager.GetTodoItems().First().IsComplete);

        }
    }
}