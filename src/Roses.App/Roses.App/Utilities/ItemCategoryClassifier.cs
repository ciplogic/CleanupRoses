using System.Collections.Generic;
using Roses.App.Entities;

namespace Roses.App.Utilities
{
    public class ItemCategoryClassifier
    {
        private readonly List<(string categoryName, bool shouldSearchInline)> _categoryTuples = new()
            {
                (ItemCategory.AgedBrie, false),
                (ItemCategory.Conjured, true),
                (ItemCategory.BackstagePasses, true),
                (ItemCategory.Sulfuras, false)
            };
        public string GetItemCategory(string itemName)
        {
            foreach (var categoryTuple in _categoryTuples)
            {
                var (categoryName, shouldSearchInline) = categoryTuple;
                if (!shouldSearchInline && categoryName == itemName)
                {
                    return categoryName;
                }

                if (itemName.Contains(categoryName))
                {
                    return categoryName;
                }
            }

            //not found/not handled, should be a default
            return itemName;
        }
    }
}