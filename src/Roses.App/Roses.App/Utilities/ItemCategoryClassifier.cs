using System.Collections.Generic;
using Roses.App.Entities;

namespace Roses.App.Utilities
{
    public class ItemCategoryClassifier
    {
        private readonly List<(string categoryName, bool shouldSearchInline, ItemCategoryEnum category)> _categoryTuples
            = new()
            {
                (ItemCategoryNames.AgedBrie, false, ItemCategoryEnum.AgedBrie),
                (ItemCategoryNames.Conjured, true, ItemCategoryEnum.Conjured),
                (ItemCategoryNames.BackstagePasses, true, ItemCategoryEnum.BackstagePasses),
                (ItemCategoryNames.Sulfuras, false, ItemCategoryEnum.Sulfuras)
            };

        public ItemCategoryEnum GetItemCategory(string itemName)
        {
            foreach (var categoryTuple in _categoryTuples)
            {
                var (categoryName, shouldSearchInline, category) = categoryTuple;
                if (!shouldSearchInline && categoryName == itemName)
                {
                    return category;
                }

                if (itemName.Contains(categoryName))
                {
                    return category;
                }
            }

            //not found/not handled, should be a default
            return ItemCategoryEnum.None;
        }
    }
}