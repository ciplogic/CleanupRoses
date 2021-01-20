using System;
using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public static class DailyItemUpdatesLogic
    {
        private static readonly NamedBehaviorRunner<Item> QualityUpdaters = ItemQualityUpdaters.Build();

        private static readonly NamedBehaviorRunner<Item> QualityFinalAdjustmentUpdaters =
            ItemQualityFinalAdjustmentUpdaters.Build();



        public static void UpdateDailyItemState(this Item item)
        {
            UpdateDailyQuality(item);

            UpdateDailySellIn(item);

            UpdateDailyQualityFinalAdjustment(item);
        }

        private static void UpdateDailyQualityFinalAdjustment(Item item)
        {
            if (item.SellIn >= 0)
            {
                return;
            }
            QualityFinalAdjustmentUpdaters.Invoke(item.Name, item);
        }

        private static void UpdateDailySellIn(Item item)
        {
            if (item.Name != ItemNames.SulfurasHandOfRagnaros)
            {
                item.SellIn--;
            }
        }
        private static void UpdateDailyQuality(Item item)
        {
            QualityUpdaters.Invoke(item.Name, item);
        }
    }
}
