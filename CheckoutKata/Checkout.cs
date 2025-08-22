using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata;

public class Checkout : ICheckout
{
    private readonly Dictionary<string, IPricingRule> _pricingRules;
    private readonly Dictionary<string, int> _items = new();

    public Checkout(IEnumerable<IPricingRule> pricingRules)
    {
        _pricingRules = pricingRules.ToDictionary(r => r.SKU, r => r);
    }

    public void Scan(string item)
    {
        if (!_pricingRules.ContainsKey(item))
            throw new ArgumentException($"Unknown item: {item}");

        if (!_items.ContainsKey(item))
            _items[item] = 0;

        _items[item]++;
    }

    public int GetTotalPrice()
    {
        int total = 0;
        foreach (var kvp in _items)
        {
            var rule = _pricingRules[kvp.Key];
            total += rule.CalculatePrice(kvp.Value);
        }
        return total;
    }
}