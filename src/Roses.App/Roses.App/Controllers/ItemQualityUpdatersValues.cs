namespace Roses.App.Controllers
{
    public static class ItemQualityUpdatersValues
    {
        public static int DefaultQuality(int itemQuality)
        {
            return itemQuality > 0
                ? itemQuality - 1 
                : itemQuality;
        }

        public static int AgedBrieQuality(int itemQuality)
        {
            return itemQuality < 50 
                ? itemQuality + 1 
                : itemQuality;
        }

        public static int SulfurasHandOfRagnarosQuality(int itemQuality)
        {
            return itemQuality;
        }

        public static int BackstagePassesToATafkal80EtcConcertQuality(int itemQuality, int itemSellIn)
        {
            if (itemQuality >= 50)
            {
                return itemQuality;
            }

            itemQuality++;
            if (itemQuality >= 50)
                return itemQuality;
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
    }
}
