using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NirvanaHqApi.Enums;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.TodoItems
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITaskService _taskService;

        public TodoItemService(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public TodoItemService(IConnection connection) : this(new TaskService(connection))
        {
        }

        public async Task<List<NirvanaTask>> GetTodoItems()
        {
            var tasks = await _taskService.GetTasks().ConfigureAwait(false);
            var todoItems = tasks.Where(t => t.Type == TaskType.TodoItem);

            return todoItems.ToList();
        }

        public async Task<bool> AddNewTodoItemToInbox(string name)
        {
            var todoItem = new NirvanaTask
            {
                Name = name,
                Type = TaskType.TodoItem,
                State = TaskState.Inbox,
            };

            var result = await _taskService.CreateTask(todoItem).ConfigureAwait(false);
            return result;
        }
    }
}
