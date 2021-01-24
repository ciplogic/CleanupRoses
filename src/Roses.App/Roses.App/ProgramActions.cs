using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Roses.App.Controllers;
using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App
{
    public static class ProgramActions
    {
        public static async Task RunAll()
        {
            
            Console.WriteLine("OMGHAI!");

            var appConfiguration = await BuildItemsDataSet();

            var categoryClassifier = new ItemCategoryClassifier();

            var app = new MainController(appConfiguration.Items, categoryClassifier);

            for (var i = 0; i < appConfiguration.DaysToUpdate; i++)
            {
                Console.WriteLine($"-------- day {i} --------");
                DisplayItemsStatus(appConfiguration.Items);
                app.UpdateDailyItemState();
            }
        }
        public static void DisplayItemsStatus(IEnumerable<Item> items)
        {
            Console.WriteLine("name, sellIn, quality");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
            }

            Console.WriteLine("");
        }

        public static async Task<AppConfiguration> BuildItemsDataSet()
        {
            var content = await File.ReadAllTextAsync("item_set.json");
            var items = JsonSerializer.Deserialize<AppConfiguration>(content);
            if (items == null)
                throw new ArgumentException("Configuration file 'item_set.json' is broken or of wrong content");
            return items;
        }
    }
}