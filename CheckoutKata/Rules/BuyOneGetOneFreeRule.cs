using CheckoutKata;

public class BuyOneGetOneFreeRule : IPricingRule
{
    public string SKU { get; }
    private readonly int _unitPrice;

    public BuyOneGetOneFreeRule(string sku, int unitPrice)
    {
        SKU = sku;
        _unitPrice = unitPrice;
    }

    public int CalculatePrice(int quantity) =>
        ((quantity / 2) * _unitPrice) + ((quantity % 2) * _unitPrice);
}