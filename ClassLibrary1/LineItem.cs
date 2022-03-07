

namespace Domain
{
    public class LineItem
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }



        public LineItem(string name, decimal unitPrice, int quantity = 1)
        {
            Name = name;
            UnitPrice = Decimal.Round(unitPrice, 2, MidpointRounding.AwayFromZero);
            Quantity = quantity;
        }
    }
}
