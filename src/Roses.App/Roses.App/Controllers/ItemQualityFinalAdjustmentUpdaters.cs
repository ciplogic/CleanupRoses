using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public static class ItemQualityFinalAdjustmentUpdaters
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

        private static void AgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private static void BackstagePassesToATafkal80EtcConcert(Item item) 
            => item.Quality = 0;

        private static void SulfurasHandOfRagnaros(Item item)
        {
        }

        private static void DefaultAction(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }

}