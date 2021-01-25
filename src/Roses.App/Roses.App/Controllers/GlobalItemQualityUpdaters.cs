using Roses.App.Controllers.Common;
using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public static class GlobalItemQualityUpdaters
    {
        public static NamedChangeStateGetter Build()
        {
            var defaultAction = NamedChangeStateGetter.Build(
                item => DefaultQuality(item.Quality),
                item => DefaultFinalQuality(item.Quality)
            );
            NamedChangeStateGetter result = new(defaultAction)
            {
                {
                    ItemCategoryEnum.AgedBrie,
                    item => AgedBrieQuality(item.Quality),
                    item => AgedBrieFinalQuality(item.Quality)
                },
                {
                    ItemCategoryEnum.BackstagePasses,
                    item => BackstagePassesQuality(item.Quality, item.SellIn),
                    _ => BackstagePassesFinalQuality()
                },
                {
                    ItemCategoryEnum.Sulfuras,
                    item => SulfurasQuality(item.Quality),
                    item => SulfurasFinalQuality(item.Quality)
                },
                {
                    ItemCategoryEnum.Conjured,
                    item => ConjuredQuality(item.Quality),
                    item => ConjuredFinalQuality(item.Quality)
                }
            };
            return result;
        }

        public static int DefaultFinalQuality(int itemQuality) =>
            itemQuality > 0
                ? itemQuality - 1
                : itemQuality;

        public static int SulfurasFinalQuality(int itemQuality)
            => itemQuality;

        public static int BackstagePassesFinalQuality()
            => 0;

        public static int AgedBrieFinalQuality(int itemQuality)
            => itemQuality < 50
                ? itemQuality + 1
                : itemQuality;


        public static int ConjuredFinalQuality(int itemQuality) =>
            itemQuality > 0
                ? itemQuality - 2
                : itemQuality;


        public static int DefaultQuality(int itemQuality) =>
            itemQuality > 0
                ? itemQuality - 1
                : itemQuality;

        public static int AgedBrieQuality(int itemQuality) =>
            itemQuality < 50
                ? itemQuality + 1
                : itemQuality;

        public static int SulfurasQuality(int itemQuality)
            => itemQuality;

        public static int BackstagePassesQuality(int itemQuality, int itemSellIn)
        {
            switch (itemQuality)
            {
                case >= 50:
                    return itemQuality;
                case 49:
                    return 50;
                default:
                    itemQuality++;
                    break;
            }

            switch (itemSellIn)
            {
                case < 6:
                    itemQuality += 2;
                    break;
                case < 11:
                    itemQuality++;
                    break;
            }

            return itemQuality;
        }

        public static int ConjuredQuality(int itemQuality) =>
            itemQuality > 0
                ? itemQuality - 2
                : itemQuality;
    }
}