using Roses.App.Entities;

namespace Roses.App.Controllers
{
    public static class DailyItemUpdatesLogic
    {
        public static void UpdateDailyItemState(this Item item)
        {
            if (item.Name != ItemNames.AgedBrie && item.Name != ItemNames.BackstagePassesToATafkal80EtcConcert)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != ItemNames.SulfurasHandOfRagnaros)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
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
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != ItemNames.SulfurasHandOfRagnaros)
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != ItemNames.AgedBrie)
                {
                    if (item.Name != ItemNames.BackstagePassesToATafkal80EtcConcert)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != ItemNames.SulfurasHandOfRagnaros)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}