using System;

namespace CustomerProgram
{
    public class Payment
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Your name can not be null or empty");
                }

                this.productName = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }

            set
            {
                if (value < 0.0m)
                {
                    throw new ArgumentOutOfRangeException("value", "Your price can not be negative");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Product name: {0}, Price: {1:F2}", this.ProductName, this.Price);
        }
    }
}
