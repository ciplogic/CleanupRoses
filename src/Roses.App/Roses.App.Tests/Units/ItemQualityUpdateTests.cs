using Xunit;
using static Roses.App.Controllers.GlobalItemQualityUpdaters;

namespace Roses.App.Tests.Units
{
    public class ItemQualityUpdateTests
    {
        [Theory]
        [InlineData(4, 3)]
        [InlineData(-1, -1)]
        public void DefaultFinalQualityTests(int quality, int expectedQuality)
        {
            var actualValue = DefaultFinalQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }

        [Theory]
        [InlineData(0)]
        public void BackstagePassesFinalQualityTests(int expectedQuality)
        {
            var actualValue = BackstagePassesFinalQuality();
            Assert.Equal(expectedQuality, actualValue);
        }

        [Theory]
        [InlineData(3, 3)]
        [InlineData(-1, -1)]
        [InlineData(15, 15)]
        [InlineData(49, 49)]
        [InlineData(50, 50)]
        public void SulfurasHandQualityTests(int quality, int expectedQuality)
        {
            var actualValue = SulfurasFinalQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(-1, 0)]
        [InlineData(15, 16)]
        [InlineData(49, 50)]
        [InlineData(50, 50)]
        [InlineData(55, 55)]
        public void AgedBrieFinalQualityTests(int quality, int expectedQuality)
        {
            var actualValue = AgedBrieFinalQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(1, -1)]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        public void ConjuredFinalQualityTests(int quality, int expectedQuality)
        {
            var actualValue = ConjuredFinalQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }

        [Theory]
        [InlineData(4, 3)]
        [InlineData(-1, -1)]
        public void DefaultQualityTests(int quality, int expectedQuality)
        {
            var actualValue = DefaultQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(55, 55)]
        public void AgedBrieQualityTests(int quality, int expectedQuality)
        {
            var actualValue = AgedBrieQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }

        [Theory]
        [InlineData(3, 3)]
        [InlineData(55, 55)]
        [InlineData(-1, -1)]
        public void SulfurasQualityTests(int quality, int expectedQuality)
        {
            var actualValue = SulfurasQuality(quality);
            Assert.Equal(expectedQuality, actualValue);
        }

        [Theory]
        [InlineData(55, 3, 55)]
        [InlineData(49, 3, 50)]
        [InlineData(48, 3, 51)]
        [InlineData(47, 3, 50)]
        [InlineData(49, 8, 50)]
        [InlineData(48, 8, 50)]
        [InlineData(47, 8, 49)]
        [InlineData(49, 28, 50)]
        [InlineData(48, 28, 49)]
        [InlineData(47, 28, 48)]
        public void BackstagePassesQualityTests(int quality, int sellIn, int expectedQuality)
        {
            var actualValue = BackstagePassesQuality(quality, sellIn);
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