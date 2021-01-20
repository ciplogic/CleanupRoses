using Roses.App.Entities;
using Roses.App.Utilities;

namespace Roses.App.Controllers
{
    public class ItemQualityFinalAdjustmentUpdaters
    {
        
        public static NamedBehaviorRunner<Item> Build()
        {   
            void AgedBrie(Item item)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }

            }

            void BackstagePassesToATafkal80EtcConcert(Item item)
            {
                item.Quality = 0;

            }

            void SulfurasHandOfRagnaros(Item item)
            {
                
            }

            void DefaultAction(Item item)
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
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