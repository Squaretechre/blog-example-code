using System;
using System.Collections.Generic;

namespace RefactoringIfStatements.LookupTables.Order.After.DiscountsExtractedFromOrder
{
    public class Order
    {
        private readonly Money _total;
        private readonly Customer _customer;
        private readonly Dictionary<CustomerStatus, Func<Money, Money>> _discounts;

        public Order(Money total, Customer customer, Dictionary<CustomerStatus, Func<Money, Money>> discounts)
        {
            _total = total;
            _customer = customer;
            _discounts = discounts;
        }

        public Money Discount()
        {
            return _discounts[_customer.Status](_total);
        }
    }
}
