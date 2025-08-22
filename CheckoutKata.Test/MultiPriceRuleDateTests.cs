using NUnit.Framework;
using CheckoutKata;

namespace CheckoutKata.Tests
{
    public class FakeDateProvider : IDateProvider
    {
        public DateTime Today { get; set; }
    }

    [TestFixture]
    public class MultiPriceRuleDateTests
    {
        [Test]
        public void AppliesOffer_WhenWithinDateRange()
        {
            var fakeDate = new FakeDateProvider { Today = new DateTime(2025, 8, 20) };
            var rule = new MultiPriceRule("A", 50, 3, 130,
                startDate: new DateTime(2025, 8, 18),
                endDate: new DateTime(2025, 8, 25),
                dateProvider: fakeDate);

            var total = rule.CalculatePrice(3);

            Assert.That(total, Is.EqualTo(130)); // offer applies
        }

        [Test]
        public void FallbackToUnitPrice_WhenBeforeStartDate()
        {
            var fakeDate = new FakeDateProvider { Today = new DateTime(2025, 8, 17) };
            var rule = new MultiPriceRule("A", 50, 3, 130,
                startDate: new DateTime(2025, 8, 18),
                endDate: new DateTime(2025, 8, 25),
                dateProvider: fakeDate);

            var total = rule.CalculatePrice(3);

            Assert.That(total, Is.EqualTo(150)); // no offer
        }

        [Test]
        public void FallbackToUnitPrice_WhenAfterEndDate()
        {
            var fakeDate = new FakeDateProvider { Today = new DateTime(2025, 8, 30) };
            var rule = new MultiPriceRule("A", 50, 3, 130,
                startDate: new DateTime(2025, 8, 18),
                endDate: new DateTime(2025, 8, 25),
                dateProvider: fakeDate);

            var total = rule.CalculatePrice(3);

            Assert.That(total, Is.EqualTo(150)); // no offer
        }
    }
}
