using System.Collections.Generic;
using Roses.App.Controllers;
using Roses.App.Entities;
using Xunit;

namespace Roses.App.Tests.Units
{
    public class IntegrationTests
    {
        [Fact]
        public void MakesSureNameIsNotChangedAfterUpdatingStateTest()
        {
            var items = new List<Item>
            {
                new() { Name = "foo", SellIn = 0, Quality = 0 }
            };
            var app = new MainController(items);
            app.UpdateDailyItemState();
            Assert.Equal("foo", items[0].Name);
        }
    }
}