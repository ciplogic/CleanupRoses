using System;
using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public static class DailyItemUpdatesLogic
    {
        private static readonly NamedBehaviorRunner<Item> QualityUpdaters = SetupDefaultQualityUpdaters();

        private static readonly NamedBehaviorRunner<Item> QualityFinalAdjustmentUpdaters =
            SetupDefaultQualityFinalAdjustmentUpdaters();



        public static void UpdateDailyItemState(this Item item)
        {
            UpdateDailyQuality(item);

            UpdateDailySellIn(item);

            UpdateDailyQualityFinalAdjustment(item);
        }

        private static NamedBehaviorRunner<Item> SetupDefaultQualityFinalAdjustmentUpdaters()
        {   
            void AgedBrie(Item item)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }

            }

            void BackstagePassesToATafkal80EtcConcert(Item item)
            {
                item.Quality = 0;

            }

            void SulfurasHandOfRagnaros(Item item)
            {
                
            }

            void DefaultAction(Item item)
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
            }
            
            NamedBehaviorRunner<Item> result = new(DefaultAction)
            {
                {ItemNames.AgedBrie, AgedBrie},
                {ItemNames.BackstagePassesToATafkal80EtcConcert, BackstagePassesToATafkal80EtcConcert},
                {ItemNames.SulfurasHandOfRagnaros, SulfurasHandOfRagnaros},
            };
            return result;
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
        private static NamedBehaviorRunner<Item> SetupDefaultQualityUpdaters()
        {
            void DefaultAction(Item item)
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
            } 
            void AgedBrie(Item item)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
            void BackstagePassesToATafkal80EtcConcert(Item item)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                    if (item.Quality < 50)
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality++;
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality++;
                        }
                    }
                }
            }

            void SulfurasHandOfRagnaros(Item item)
            {
            }

            NamedBehaviorRunner<Item> result = new(DefaultAction)
            {
                {ItemNames.AgedBrie, AgedBrie},
                {ItemNames.BackstagePassesToATafkal80EtcConcert, BackstagePassesToATafkal80EtcConcert},
                {ItemNames.SulfurasHandOfRagnaros, SulfurasHandOfRagnaros},
            };
            return result;
        }
        private static void UpdateDailyQuality(Item item)
        {
            QualityUpdaters.Invoke(item.Name, item);
        }
    }
}
