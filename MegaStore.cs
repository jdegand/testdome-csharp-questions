using System;

public class MegaStore
{
    public enum DiscountType
    {
        Standard,
        Seasonal,
        Weight
    }

    public static double GetDiscountedPrice(double cartWeight, double totalPrice, DiscountType discountType)
    {
        switch (discountType)
        {
            case DiscountType.Seasonal:
                return totalPrice - (totalPrice * 0.12);
            case DiscountType.Weight:
                if (cartWeight > 10)
                {
                    return totalPrice - (totalPrice * 0.18);
                }
                else
                {
                    return totalPrice - (totalPrice * 0.06);
                }
            default:
                return totalPrice - (totalPrice * 0.06);
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(GetDiscountedPrice(12, 100, DiscountType.Weight));
    }
}
