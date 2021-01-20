using System;
using System.Collections.Generic;
using System.IO;
using Roses.App.Controllers;
using Roses.App.Entities;
using Roses.App.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Roses.App
{
    public class Program
    {

        public static void Main()
        {
            Console.WriteLine("OMGHAI!");
            

            var appConfiguration = BuildItemsDataSet();

            var categoryClassifier = new ItemCategoryClassifier();

            var app = new MainController(appConfiguration.Items, categoryClassifier);
            
            for (var i = 0; i < appConfiguration.DaysToUpdate; i++)
            {
                Console.WriteLine($"-------- day {i} --------");
                DisplayItemsStatus(appConfiguration.Items);
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

        private static AppConfiguration BuildItemsDataSet()
        {
            var content = File.ReadAllText("item_set.json");
            var items = JsonSerializer.Deserialize<AppConfiguration>(content);
            if (items == null)
                throw new ArgumentException("Configuration file 'item_set.json' is broken or of wrong content");
            return items;
        }
    }
}
