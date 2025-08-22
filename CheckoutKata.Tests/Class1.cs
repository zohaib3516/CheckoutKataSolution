using NUnit.Framework;
using CheckoutKata;
using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private List<PricingRule> _rules;

        [SetUp]
        public void Setup()
        {
            _rules = new List<PricingRule>
            {
                new PricingRule("A", 50, (3, 130)),
                new PricingRule("B", 30, (2, 45)),
                new PricingRule("C", 20),
                new PricingRule("D", 15)
            };
        }

        [Test]
        public void EmptyCheckout_ReturnsZero()
        {
            var checkout = new Checkout(_rules);
            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(0));
        }

        [Test]
        public void SingleItem_ReturnsUnitPrice()
        {
            var checkout = new Checkout(_rules);
            checkout.Scan("A");
            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(50));
        }

        [Test]
        public void MultipleItems_NoOffer()
        {
            var checkout = new Checkout(_rules);
            checkout.Scan("A");
            checkout.Scan("C");
            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(70));
        }

        [Test]
        public void ApplySpecialPriceForA()
        {
            var checkout = new Checkout(_rules);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(130));
        }

        [Test]
        public void ApplySpecialPriceForB()
        {
            var checkout = new Checkout(_rules);
            checkout.Scan("B");
            checkout.Scan("B");
            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(45));
        }

        [Test]
        public void MixedItemsWithSpecialOffers()
        {
            var checkout = new Checkout(_rules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(175)); // 3 A’s = 130 + 2 B’s = 45
        }
    }
}
