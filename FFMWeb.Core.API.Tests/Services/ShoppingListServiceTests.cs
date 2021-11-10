using AutoFixture;
using FFMWeb.Core.API.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FFMWeb.Core.API.Tests.Services
{
    public class ShoppingListServiceTests
    {
        private readonly ShoppingListService _service = new();

        [Fact]
        public void TestGetAllItems_ShouldReturnEmptyList()
        {
            var result = _service.GetAllItems();
            result.Should().BeEmpty();
        }

        [Fact]
        public void TestAddItem_AddsAnItemToTheList()
        {
            var itemToAdd = "item";
            var result = _service.AddItem(itemToAdd);
            result.Should().Be(itemToAdd);
            _service.GetAllItems().Should().Contain(itemToAdd);
        }

        [Fact]
        public void RemoveItem_RemovesAnItemFromTheList()
        {
            var itemToRemove = "item";
            _service.AddItem(itemToRemove);
            _service.GetAllItems().Should().Contain(itemToRemove);

            var result = _service.RemoveItem(itemToRemove);
            result.Should().Be(itemToRemove);
            _service.GetAllItems().Should().BeEmpty();

            var notFound = "not_found";
            Assert.Throws<ArgumentException>(() => _service.RemoveItem(notFound));
        }

        [Fact]
        public void ClearAll_ClearsAllExistingItems()
        {
            var fixture = new Fixture();
            var items = new List<string>();
            fixture.AddManyTo(items);

            foreach (var item in items)
            {
                _service.AddItem(item);
            }

            var currentList = _service.GetAllItems();
            currentList.Should().NotBeEmpty();

            _service.ClearAll();
            currentList = _service.GetAllItems();
            currentList.Should().BeEmpty();
        }
    }
}
