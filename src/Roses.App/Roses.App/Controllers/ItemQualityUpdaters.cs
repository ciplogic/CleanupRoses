using Roses.App.Entities;
using Roses.App.Utilities;
using static Roses.App.Controllers.ItemQualityUpdatersValues;

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
            item.Quality = DefaultQuality(item.Quality);
        }

        private static void AgedBrie(Item item)
        {
            item.Quality = AgedBrieQuality(item.Quality);
        }

        private static void BackstagePassesToATafkal80EtcConcert(Item item)
        {
            item.Quality = BackstagePassesToATafkal80EtcConcertQuality(item.Quality, item.SellIn);
        }

        private static void SulfurasHandOfRagnaros(Item item)
        {
            item.Quality = SulfurasHandOfRagnarosQuality(item.Quality);
        }

    }
}