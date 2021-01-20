using System.Collections.Generic;
using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public class MainController
    {
        private readonly List<Item> _items;
        private readonly ItemCategoryClassifier _itemCategoryClassifier;

        public MainController(List<Item> items, ItemCategoryClassifier itemCategoryClassifier)
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
