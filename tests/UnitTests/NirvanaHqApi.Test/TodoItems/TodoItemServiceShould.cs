using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NirvanaHqApi.Enums;
using NirvanaHqApi.Models;
using NirvanaHqApi.TodoItems;
using Xunit;

namespace NirvanaHqApi.Test.TodoItems
{
    public class TodoItemServiceShould
    {
        private List<NirvanaTask> _testData;

        public TodoItemServiceShould()
        {
            _testData = new List<NirvanaTask> {
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Active},
                new NirvanaTask { Type = TaskType.TodoItem, State = TaskState.Active },
                new NirvanaTask { Type = TaskType.Project, State = TaskState.Next },
            };
        }

        [Fact]
        public async void ReturnAllTodoItem()
        {
            var expected = new List<NirvanaTask>(_testData.Where(t => t.Type == TaskType.TodoItem));

            var sut = new TodoItemService(new FakeTaskService(_testData));

            var actual = await sut.GetTodoItems();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task AddNewTodoItemToInboxAsync()
        {
            var taskName = "Test Item";
            var task = new NirvanaTask { Name = taskName, Type = TaskType.TodoItem, State = TaskState.Inbox };
            var expected = new List<NirvanaTask>(_testData.Where(t => t.Type == TaskType.TodoItem));
            expected.Add(task);

            var sut = new TodoItemService(new FakeTaskService(_testData));

            var actual = await sut.AddNewTodoItemToInbox(taskName);
            var tasks = await sut.GetTodoItems();

            actual.Should().BeTrue();
            tasks.Should().BeEquivalentTo(expected);
        }
    }
}
