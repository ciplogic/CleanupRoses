using System.Collections.Generic;

namespace Roses.App
{
    public class GildedRose
    {
        private readonly List<Item> _items;
        public GildedRose(List<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                UpdateItemQuality(item);
            }
        }

        private static void UpdateItemQuality(Item item)
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
