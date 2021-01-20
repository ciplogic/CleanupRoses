using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public class ItemQualityUpdaters
    {
        public static NamedBehaviorRunner<Item> Build()
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
    }
}