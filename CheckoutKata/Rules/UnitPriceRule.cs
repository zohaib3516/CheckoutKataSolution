namespace CheckoutKata;

public class UnitPriceRule : IPricingRule
{
    public string SKU { get; }
    private readonly int _unitPrice;

    public UnitPriceRule(string sku, int unitPrice)
    {
        SKU = sku;
        _unitPrice = unitPrice;
    }

    public int CalculatePrice(int quantity) => quantity * _unitPrice;
}