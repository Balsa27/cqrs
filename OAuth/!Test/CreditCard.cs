using OAuth.Infrastructure;

namespace OAuth._Test;

public class CreditCard : Enumeration<CreditCard>
{
    public static readonly CreditCard Visa = new(1, nameof(Visa));
    public static readonly CreditCard MasterCard = new(2, nameof(MasterCard));
    public static readonly CreditCard Maestro = new(3, nameof(Maestro));
    private CreditCard(int value, string name)
        : base(value, name)
    {
    }

    public double Discount => 0.0;
}