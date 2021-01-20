using System.Collections.Generic;
using Xunit;

namespace Roses.App.Tests
{
    public class GildedRoseTest
    {
        [Fact]
        public void Foo()
        {
            var items = new List<Item>
            {
                new() { Name = "foo", SellIn = 0, Quality = 0 }
            };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
        }
    }
}