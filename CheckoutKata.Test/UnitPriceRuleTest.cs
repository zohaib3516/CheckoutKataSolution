using NUnit.Framework;
using CheckoutKata;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class UnitPriceRuleTests
    {
        [TestCase(1, 20)]
        [TestCase(2, 40)]
        [TestCase(5, 100)]
        public void CalculatesCorrectPrice(int quantity, int expectedTotal)
        {
            var rule = new UnitPriceRule("C", 20);

            var total = rule.CalculatePrice(quantity);

            Assert.That(total, Is.EqualTo(expectedTotal));
        }
    }
}
