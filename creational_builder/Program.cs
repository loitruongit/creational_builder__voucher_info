// Object voucher
class Voucher
{
    public string Code { get; set; }
    public double Value { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string DiscountType { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"Voucher: {Code}, Value: {Value}, Expiry Date: {ExpiryDate}, Discount Type: {DiscountType}, Description: {Description}";
    }
}

// Builder interface
interface IVoucherBuilder
{
    void SetCode(string code);
    void SetValue(double value);
    void SetExpiryDate(DateTime expiryDate);
    void SetDiscountType(string discountType);
    void SetDescription(string description);
    Voucher GetVoucher();
}

// Concrete builder
class VoucherBuilder : IVoucherBuilder
{
    private Voucher _voucher = new Voucher();

    public void SetCode(string code)
    {
        _voucher.Code = code;
    }

    public void SetValue(double value)
    {
        _voucher.Value = value;
    }

    public void SetExpiryDate(DateTime expiryDate)
    {
        _voucher.ExpiryDate = expiryDate;
    }

    public void SetDiscountType(string discountType)
    {
        _voucher.DiscountType = discountType;
    }

    public void SetDescription(string description)
    {
        _voucher.Description = description;
    }

    public Voucher GetVoucher()
    {
        return _voucher;
    }
}

// Director - Implement builder
class VoucherCreator
{
    private IVoucherBuilder _builder;

    public VoucherCreator(IVoucherBuilder builder)
    {
        _builder = builder;
    }

    public void CreateVoucher(string code, double value, DateTime expiryDate, string discountType, string description)
    {
        _builder.SetCode(code);
        _builder.SetValue(value);
        _builder.SetExpiryDate(expiryDate);
        _builder.SetDiscountType(discountType);
        _builder.SetDescription(description);
    }

    public Voucher GetVoucher()
    {
        return _builder.GetVoucher();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var builder = new VoucherBuilder();
        var creator = new VoucherCreator(builder);

        creator.CreateVoucher("VOUCHER123", 50.0, DateTime.Now.AddMonths(1), "Percentage", "50% off on all items");

        var voucher = creator.GetVoucher();
        Console.WriteLine(voucher);
    }
}
