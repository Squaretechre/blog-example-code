using System;
using System.Collections.Generic;

namespace RefactoringIfStatements.LookupTables.Order.After.DiscountsLiveInOrder
{
    public class Order
    {
        private readonly Money _total;
        private readonly Customer _customer;

        private readonly Dictionary<CustomerStatus, Func<Money, Money>> _discounts = new Dictionary<CustomerStatus, Func<Money, Money>>
        {
            { CustomerStatus.General, (total) => total * 0.00m },
            { CustomerStatus.Bronze, (total) => total * 0.05m },
            { CustomerStatus.Silver, (total) => total * 0.10m },
            { CustomerStatus.Gold, (total) => total * 0.15m },
            { CustomerStatus.Platinum, (total) => total * 0.20m },
        };

        public Order(Money total, Customer customer)
        {
            _total = total;
            _customer = customer;
        }

        public Money Discount()
        {
            return _discounts[_customer.Status](_total);
        }
    }
}
