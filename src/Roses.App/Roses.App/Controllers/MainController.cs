using System.Collections.Generic;
using Roses.App.Entities;

namespace Roses.App.Controllers
{
    public class MainController
    {
        private readonly List<Item> _items;

        public MainController(List<Item> items)
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
