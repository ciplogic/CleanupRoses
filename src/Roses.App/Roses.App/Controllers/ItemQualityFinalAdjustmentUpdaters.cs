using Roses.App.Entities;
using Roses.App.Utilities;
using static Roses.App.Controllers.StateChanges.ItemQualityFinalAdjustmentUpdatersValues;

namespace Roses.App.Controllers
{
    public static class ItemQualityFinalAdjustmentUpdaters
    {
        public static NamedBehaviorRunner<ItemCategoryEnum, Item> Build()
        {
            NamedBehaviorRunner<ItemCategoryEnum, Item> result = new(DefaultAction)
            {
                {ItemCategoryEnum.AgedBrie, AgedBrie},
                {ItemCategoryEnum.BackstagePasses, BackstagePasses},
                {ItemCategoryEnum.Sulfuras, Sulfuras},
                {ItemCategoryEnum.Conjured, Conjured},
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

        private static void BackstagePasses(Item item)
        {
            item.Quality = BackstagePassesQuality();
        }

        private static void Sulfuras(Item item)
        {
            item.Quality = SulfurasQuality(item.Quality);
        }

        private static void DefaultAction(Item item)
        {
            item.Quality = DefaultQuality(item.Quality);
        }
    }

}