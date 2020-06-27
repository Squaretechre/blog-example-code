namespace RefactoringIfStatements.LookupTables.Order.Before
{
    public class Order
    {
        private readonly Money _total;
        private readonly Customer _customer;

        public Order(Money total, Customer customer)
        {
            _total = total;
            _customer = customer;
        }

        public Money Discount()
        {
            if (_customer.Status == CustomerStatus.Bronze)
            {
                return _total * 0.05m;
            }
            else if (_customer.Status == CustomerStatus.Silver)
            {
                return _total * 0.10m;
            }
            else if (_customer.Status == CustomerStatus.Gold)
            {
                return _total * 0.15m;
            }
            else if (_customer.Status == CustomerStatus.Platinum)
            {
                return _total * 0.20m;
            }

            return _total * 0;
        }
    }
}
