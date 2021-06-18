using System.Collections.Generic;
using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public class MainController
    {
        private readonly IEnumerable<Item> _items;
        private readonly ItemCategoryClassifier _itemCategoryClassifier;

        public MainController(IEnumerable<Item> items, ItemCategoryClassifier itemCategoryClassifier)
        {
            _items = items;
            _itemCategoryClassifier = itemCategoryClassifier;
        }

        public void UpdateDailyItemState()
        {
            foreach (var item in _items)
            {
                item.UpdateDailyItemState(_itemCategoryClassifier);
            }
        }
    }
}