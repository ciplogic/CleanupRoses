using System.Collections.Generic;
using Roses.App.Controllers;
using Roses.App.Entities;
using Roses.App.Utilities;
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
                new() {Name = "foo", SellIn = 0, Quality = 0}
            };
            var categoryClassifier = new ItemCategoryClassifier();
            var app = new MainController(items, categoryClassifier);
            app.UpdateDailyItemState();
            Assert.Equal("foo", items[0].Name);
        }
    }
}