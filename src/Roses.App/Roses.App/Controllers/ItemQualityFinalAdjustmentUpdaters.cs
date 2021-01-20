using Roses.App.Entities;
using Roses.App.Utilities;
using static Roses.App.Controllers.StateChanges.ItemQualityFinalAdjustmentUpdatersValues;

namespace Roses.App.Controllers
{
    public static class ItemQualityFinalAdjustmentUpdaters
    {
        public static NamedBehaviorRunner<Item> Build()
        {
            NamedBehaviorRunner<Item> result = new(DefaultAction)
            {
                {ItemCategory.AgedBrie, AgedBrie},
                {ItemCategory.BackstagePasses, BackstagePassesToATafkal80EtcConcert},
                {ItemCategory.Sulfuras, SulfurasHandOfRagnaros},
                {ItemCategory.Conjured, Conjured},
            };
            return result;
        }

        private static void Conjured(Item item)
        {
            item.Quality = ConjuredQuality(item.Quality);
        }

        private static void AgedBrie(Item item)
        {
            item.Quality = AgedBrieQuality(item.Quality);
        }

        private static void BackstagePassesToATafkal80EtcConcert(Item item)
        {
            item.Quality = BackstagePassesToATafkal80EtcConcertQuality();
        }

        private static void SulfurasHandOfRagnaros(Item item)
        {
            item.Quality = SulfurasHandOfRagnarosQuality(item.Quality);
        }

        private static void DefaultAction(Item item)
        {
            item.Quality = DefaultQuality(item.Quality);
        }
    }

}