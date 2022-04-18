using TPProject.Application.TodoLists.Queries.ExportTodos;

namespace TPProject.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
