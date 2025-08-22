namespace CheckoutKata;

public interface IDateProvider
{
    DateTime Today { get; }
}

public class SystemDateProvider : IDateProvider
{
    public DateTime Today => DateTime.UtcNow.Date;
}
