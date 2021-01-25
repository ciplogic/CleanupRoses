using Roses.App.Controllers.Common;
using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public static class ItemDailyChangeStateLogic
    {
        private static readonly NamedChangeStateGetter NamedChanges = GlobalItemQualityUpdaters.Build();

        public static void UpdateDailyItemState(this Item item, ItemCategoryClassifier itemCategoryClassifier)
        {
            var category = itemCategoryClassifier.GetItemCategory(item.Name);
            var changeStateGetter = NamedChanges.Get(category);
            changeStateGetter.ApplyEarlyChanges(item);

            if (category != ItemCategoryEnum.Sulfuras)
            {
                item.SellIn--;
            }

            if (item.SellIn < 0)
            {
                changeStateGetter.ApplyLateChanges(item);
            }
        }
    }
}