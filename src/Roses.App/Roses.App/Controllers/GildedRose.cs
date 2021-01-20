using System.Collections.Generic;
using Roses.App.Entities;

namespace Roses.App.Controllers
{
    public class GildedRose
    {
        private readonly List<Item> _items;

        public GildedRose(List<Item> items)
        {
            _items = items;
        }

        public void UpdateDailyItemState()
        {
            foreach (var item in _items)
            {
                item.UpdateDailyItemState();
            }
        }
    }
}
