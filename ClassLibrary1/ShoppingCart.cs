using System.Linq;

namespace Domain
{
    public class ShoppingCart
    {
        public List<LineItem> LineItems { get; set; }
        public decimal TaxRate { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return LineItemsTotal + TotalSalesTax;
            }
        }

        public decimal TotalSalesTax
        {
            get
            {
                return Decimal.Round(LineItemsTotal * TaxRate, 2, MidpointRounding.AwayFromZero);
            }
        }

        public decimal LineItemsTotal
        {
            get
            {
                return Decimal.Round(LineItems.Sum(x => x.UnitPrice * x.Quantity), 2, MidpointRounding.AwayFromZero);
            }
        }

        public ShoppingCart()
        {
            LineItems = new List<LineItem>();
        }

        public void AddProduct(Product product, int quantity = 1)
        {
            if (!LineItems.Any(x => x.Name == product.Name))
            {
                var lineItem = new LineItem(product.Name, Decimal.Round(product.UnitPrice, 2, MidpointRounding.AwayFromZero), quantity);
                LineItems.Add(lineItem);
            }
            else
            {
                var lineItem = LineItems.Where(x => x.Name == product.Name).SingleOrDefault();
                if (lineItem == null)
                    return;

                lineItem.Quantity = lineItem.Quantity + quantity;
            }
        }

        public int GetProductQuantity(string name)
        {
            var lineItem = LineItems.Where(x =>x.Name == name).SingleOrDefault();
            if (lineItem == null)
                return 0;
            return lineItem.Quantity;
        }
    }
}
