using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public static class ItemQualityUpdaters
    {
        public static NamedBehaviorRunner<Item> Build()
        {
            NamedBehaviorRunner<Item> result = new(DefaultAction)
            {
                {ItemNames.AgedBrie, AgedBrie},
                {ItemNames.BackstagePassesToATafkal80EtcConcert, BackstagePassesToATafkal80EtcConcert},
                {ItemNames.SulfurasHandOfRagnaros, SulfurasHandOfRagnaros},
            };
            return result;
        }

        private static void DefaultAction(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

        private static void AgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private static void BackstagePassesToATafkal80EtcConcert(Item item)
        {
            if (item.Quality >= 50)
            {
                return;
            }
            item.Quality++;
            if (item.Quality >= 50) 
                return;
            switch (item.SellIn)
            {
                case < 6:
                    item.Quality+=2;
                    return;
                case < 11:
                    item.Quality++;
                    break;
            }
        }

        private static void SulfurasHandOfRagnaros(Item item)
        {
        }

    }
}