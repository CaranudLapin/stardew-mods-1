using SmartTodo.Components.TodoItems;
using SmartTodo.Models;

namespace SmartTodo.Engines
{
    internal class TestEngine : IEngine
    {
        public ITodoItem[] GetTodos()
        {
            return [
                new TestTodoItem("TEST: Go to the store"),
                new TestTodoItem("TEST: Give Morris a present (birthday)"),
                new TestTodoItem("TEST: Sleep!")
            ];
        }
    }
}