using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public static class ItemDailyChangeStateLogic
    {
        private static readonly NamedBehaviorRunner<ItemCategoryEnum, Item> QualityUpdaters = ItemQualityUpdaters.Build();

        private static readonly NamedBehaviorRunner<ItemCategoryEnum, Item> QualityFinalAdjustmentUpdaters =
            ItemQualityFinalAdjustmentUpdaters.Build();

        public static void UpdateDailyItemState(this Item item, ItemCategoryClassifier itemCategoryClassifier)
        {
            UpdateDailyQuality(item, itemCategoryClassifier);

            UpdateDailySellIn(item);

            UpdateDailyQualityFinalAdjustment(item, itemCategoryClassifier);
        }

        private static void UpdateDailyQuality(Item item, ItemCategoryClassifier itemCategoryClassifier)
        {
            var itemCategory = itemCategoryClassifier.GetItemCategory(item.Name);
            QualityUpdaters.Invoke(itemCategory, item);
        }
        private static void UpdateDailyQualityFinalAdjustment(Item item, ItemCategoryClassifier itemCategoryClassifier)
        {
            if (item.SellIn >= 0)
            {
                return;
            }
            var itemCategory = itemCategoryClassifier.GetItemCategory(item.Name);
            QualityFinalAdjustmentUpdaters.Invoke(itemCategory, item);
        }

        private static void UpdateDailySellIn(Item item)
        {
            if (item.Name != ItemCategoryNames.Sulfuras)
            {
                item.SellIn--;
            }
        }
    }
}
