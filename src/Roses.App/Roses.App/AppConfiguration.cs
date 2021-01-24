using System.Collections.Generic;
using Roses.App.Entities;

namespace Roses.App
{
    public class AppConfiguration
    {
        public Item[] Items { get; set; } = new Item[0];
        public int DaysToUpdate { get; set; }
    }
}