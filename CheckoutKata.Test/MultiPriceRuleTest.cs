using NUnit.Framework;
using CheckoutKata;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class MultiPriceRuleTests
    {
        [TestCase(1, 50)]
        [TestCase(2, 100)]
        [TestCase(3, 130)]   // offer applies
        [TestCase(4, 180)]   // 3 for 130 + 1*50
        [TestCase(6, 260)]   // 2 offers
        public void CalculatesCorrectPrice(int quantity, int expectedTotal)
        {
            var rule = new MultiPriceRule("A", 50, 3, 130, startDate: new DateTime(2025, 8, 18), endDate: new DateTime(2025, 8, 25));

            var total = rule.CalculatePrice(quantity);

            Assert.That(total, Is.EqualTo(expectedTotal));
        }
    }
}
