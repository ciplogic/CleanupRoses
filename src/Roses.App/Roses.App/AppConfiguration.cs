using System.Collections.Generic;
using Roses.App.Entities;

namespace Roses.App
{
    public class AppConfiguration
    {
        public List<Item> Items { get; set; }
        public int DaysToUpdate { get; set; }
    }
}