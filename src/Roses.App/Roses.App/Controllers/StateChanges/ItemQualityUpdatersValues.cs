namespace Roses.App.Controllers.StateChanges
{
    public static class ItemQualityUpdatersValues
    {
        public static int DefaultQuality(int itemQuality) =>
            itemQuality > 0
                ? itemQuality - 1 
                : itemQuality;

        public static int AgedBrieQuality(int itemQuality) =>
            itemQuality < 50 
                ? itemQuality + 1 
                : itemQuality;

        public static int SulfurasHandOfRagnarosQuality(int itemQuality) 
            => itemQuality;

        public static int BackstagePassesToATafkal80EtcConcertQuality(int itemQuality, int itemSellIn)
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
