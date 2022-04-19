﻿using TPProject.Application.Common.Exceptions;
using TPProject.Application.TodoItems.Commands.CreateTodoItem;
using TPProject.Application.TodoItems.Commands.DeleteTodoItem;
using TPProject.Application.TodoLists.Commands.CreateTodoList;
using TPProject.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace TPProject.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteBrandCommand { Id = 99 };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateBrandCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteBrandCommand
        {
            Id = itemId
        });

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
