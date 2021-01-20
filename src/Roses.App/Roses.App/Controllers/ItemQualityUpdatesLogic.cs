using Roses.App.Entities;

namespace Roses.App.Controllers
{
    public static class DailyItemUpdatesLogic
    {
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

            switch (item.Name)
            {
                case ItemNames.AgedBrie:
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }

                    break;
                }
                case ItemNames.BackstagePassesToATafkal80EtcConcert:
                    item.Quality = 0;
                    break;
                case ItemNames.SulfurasHandOfRagnaros:
                    break;
                default:
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }

                    break;
                }
            }
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
            switch (item.Name)
            {
                case ItemNames.AgedBrie:
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }

                    break;
                }
                case ItemNames.BackstagePassesToATafkal80EtcConcert:
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

                    break;
                }
                case ItemNames.SulfurasHandOfRagnaros:
                    break;
                default:
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }

                    break;
                }
            }
        }
    }
}
