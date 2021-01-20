using System;
using System.Collections.Generic;
using Roses.App.Controllers;
using Roses.App.Entities;

namespace Roses.App
{
    public class Program
    {

        public static void Main()
        {
            Console.WriteLine("OMGHAI!");

            var items = BuildItemsDataSet();

            var app = new MainController(items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine($"-------- day {i} --------");
                DisplayItemsStatus(items);
                app.UpdateDailyItemState();
            }
        }

        private static void DisplayItemsStatus(List<Item> items)
        {
            Console.WriteLine("name, sellIn, quality");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
            }

            Console.WriteLine("");
        }

        private static List<Item> BuildItemsDataSet()
        {
            var items = new List<Item>
            {
                new()
                {
                    Name = ItemNames.DexterityVest,
                    SellIn = 10,
                    Quality = 20
                },
                new()
                {
                    Name = ItemNames.AgedBrie,
                    SellIn = 2,
                    Quality = 0
                },
                new()
                {
                    Name = ItemNames.ElixirOfTheMongoose,
                    SellIn = 5,
                    Quality = 7
                },
                new()
                {
                    Name = ItemNames.SulfurasHandOfRagnaros,
                    SellIn = 0,
                    Quality = 80
                },
                new()
                {
                    Name = ItemNames.SulfurasHandOfRagnaros,
                    SellIn = -1,
                    Quality = 80
                },
                new()
                {
                    Name = ItemNames.BackstagePassesToATafkal80EtcConcert,
                    SellIn = 15,
                    Quality = 20
                },
                new()
                {
                    Name = ItemNames.BackstagePassesToATafkal80EtcConcert,
                    SellIn = 10,
                    Quality = 49
                },
                new()
                {
                    Name = ItemNames.BackstagePassesToATafkal80EtcConcert,
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new()
                {
                    Name = ItemNames.ConjuredManaCake,
                    SellIn = 3,
                    Quality = 6
                }
            };
            return items;
        }
    }
}
