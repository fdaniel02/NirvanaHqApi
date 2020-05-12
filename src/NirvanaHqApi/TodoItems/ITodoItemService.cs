using System.Collections.Generic;
using System.Threading.Tasks;
using NirvanaHqApi.Models;

namespace NirvanaHqApi.TodoItems
{
    public interface ITodoItemService
    {
        Task<bool> AddNewTodoItemToInbox(string name);

        Task<List<NirvanaTask>> GetTodoItems();
    }
}
