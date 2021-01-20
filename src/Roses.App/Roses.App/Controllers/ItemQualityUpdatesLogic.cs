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
                default:
                {
                    switch (item.Name)
                    {
                        case ItemNames.BackstagePassesToATafkal80EtcConcert:
                            item.Quality = 0;
                            break;
                        default:
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != ItemNames.SulfurasHandOfRagnaros)
                                {
                                    item.Quality--;
                                }
                            }

                            break;
                        }
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
                case ItemNames.BackstagePassesToATafkal80EtcConcert:
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == ItemNames.BackstagePassesToATafkal80EtcConcert)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }

                    break;
                }
                default:
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != ItemNames.SulfurasHandOfRagnaros)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }

                    break;
                }
            }
        }
    }
}