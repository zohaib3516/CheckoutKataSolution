namespace CheckoutKata;

public class MultiPriceRule : IPricingRule
{
    public string SKU { get; }
    private readonly int _unitPrice;
    private readonly int _offerQty;
    private readonly int _offerPrice;
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly IDateProvider _dateProvider;

    public MultiPriceRule(
        string sku,
        int unitPrice,
        int offerQty,
        int offerPrice,
        DateTime startDate,
        DateTime endDate,
        IDateProvider? dateProvider = null)
    {
        SKU = sku;
        _unitPrice = unitPrice;
        _offerQty = offerQty;
        _offerPrice = offerPrice;
        _startDate = startDate.Date;
        _endDate = endDate.Date;
        _dateProvider = dateProvider ?? new SystemDateProvider();
    }

    public int CalculatePrice(int quantity)
    {
        var today = _dateProvider.Today;

        if (today < _startDate || today > _endDate)
        {
            return quantity * _unitPrice;
        }

        int total = (quantity / _offerQty) * _offerPrice;
        total += (quantity % _offerQty) * _unitPrice;
        return total;
    }
}
