using System;
using System.Collections.Generic;
using Xunit;

namespace RefactoringIfStatements.LookupTables.Order.After.DiscountsExtractedFromOrder
{
    public class OrderShould
    {
        private readonly Dictionary<CustomerStatus, Func<Money, Money>> _discounts = new Dictionary<CustomerStatus, Func<Money, Money>>
        {
            { CustomerStatus.General, (total) => total* 0.00m },
            { CustomerStatus.Bronze, (total) => total* 0.05m },
            { CustomerStatus.Silver, (total) => total* 0.10m },
            { CustomerStatus.Gold, (total) => total* 0.15m },
            { CustomerStatus.Platinum, (total) => total* 0.20m },
        };

        [Fact]
        public void calculate_no_discount_for_general_customers()
        {
           var sut = new Order(Money.USD(100), Customer.General(), _discounts); 

           Assert.Equal(Money.USD(0), sut.Discount());
        }

        [Fact]
        public void calculate_5_percent_discount_for_bronze_customers()
        {
            var sut = new Order(Money.USD(100), Customer.Bronze(), _discounts);

            Assert.Equal(Money.USD(5), sut.Discount());
        }

        [Fact]
        public void calculate_10_percent_discount_for_silver_customers()
        {
            var sut = new Order(Money.USD(100), Customer.Silver(), _discounts);

            Assert.Equal(Money.USD(10), sut.Discount());
        }

        [Fact]
        public void calculate_15_percent_discount_for_gold_customers()
        {
            var sut = new Order(Money.USD(100), Customer.Gold(), _discounts);

            Assert.Equal(Money.USD(15), sut.Discount());
        }

        [Fact]
        public void calculate_20_percent_discount_for_platinum_customers()
        {
            var sut = new Order(Money.USD(100), Customer.Platinum(), _discounts);

            Assert.Equal(Money.USD(20), sut.Discount());
        }
    }
}
