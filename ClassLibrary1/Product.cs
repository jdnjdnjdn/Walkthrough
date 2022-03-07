

namespace Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public Product(string name, decimal unitPrice)
        {
            Name = name;
            UnitPrice = Decimal.Round(unitPrice, 2, MidpointRounding.AwayFromZero);
        }
    }
}
