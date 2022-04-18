using System.Globalization;
using TPProject.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace TPProject.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
