namespace Roses.App.Controllers.StateChanges
{
    public static class ItemQualityFinalAdjustmentUpdatersValues
    {
        public static int DefaultQuality(int itemQuality) =>
            itemQuality > 0
                ? itemQuality - 1
                : itemQuality;

        public static int SulfurasHandOfRagnarosQuality(int itemQuality)
            => itemQuality;

        public static int BackstagePassesToATafkal80EtcConcertQuality() 
            => 0;

        public static int AgedBrieQuality(int itemQuality)
            => itemQuality < 50
                ? itemQuality + 1
                : itemQuality;
        
        
        public static int ConjuredQuality(int itemQuality) =>
            itemQuality > 0
                ? itemQuality - 2
                : itemQuality;
    }
}