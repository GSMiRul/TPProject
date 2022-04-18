using TPProject.Application.Common.Interfaces;

namespace TPProject.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
