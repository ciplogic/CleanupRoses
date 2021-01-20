using Xunit;
using static Roses.App.Controllers.StateChanges.ItemQualityFinalAdjustmentUpdatersValues;

namespace Roses.App.Tests.Units
{
    public class ItemQualityFinalAdjustmentUpdatersValuesTests
    {
        
        [Theory]
        [InlineData(4, 3)]
        [InlineData(-1, -1)]
        public void DefaultQualityTests(int quality, int expectedQuality)
        {
            var actualValue = DefaultQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }
          
        [Theory]
        [InlineData(0)]
        public void BackstagePassesToATafkal80EtcConcertQualityTests(int expectedQuality)
        {
            var actualValue = BackstagePassesToATafkal80EtcConcertQuality();
            Assert.Equal(expectedQuality, actualValue);
        }
          
        [Theory]
        [InlineData(3, 3)]
        [InlineData(-1, -1)]
        [InlineData(15, 15)]
        [InlineData(49, 49)]
        [InlineData(50, 50)]
        public void SulfurasHandOfRagnarosQualityTests(int quality, int expectedQuality)
        {
            var actualValue = SulfurasHandOfRagnarosQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }
        
        [Theory]
        [InlineData(3, 4)]
        [InlineData(-1, 0)]
        [InlineData(15, 16)]
        [InlineData(49, 50)]
        [InlineData(50, 50)]
        [InlineData(55, 55)]
        public void AgedBrieQualityTests(int quality, int expectedQuality)
        {
            var actualValue = AgedBrieQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }
        
        [Theory]
        [InlineData(4, 2)]
        [InlineData(1, -1)]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        public void ConjuredQualityTests(int quality, int expectedQuality)
        {
            var actualValue = ConjuredQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }
    }
}