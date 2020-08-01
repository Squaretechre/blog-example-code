using System;
using System.Collections.Generic;
using Xunit;

namespace RefactoringIfStatements.Polymorphism.Before
{
    public class LoyaltyUtilShould
    {
        private readonly DateTime _fiveMonthsAgo;
        private readonly DateTime _sixMonthsAgo;
        private readonly DateTime _oneYearAgo;
        private readonly DateTime _twoYearsAgo;
        private readonly DateTime _now;

        public LoyaltyUtilShould()
        {
            _fiveMonthsAgo = DateTime.Now.AddMonths(-5);
            _sixMonthsAgo = DateTime.Now.AddMonths(-6);
            _oneYearAgo = DateTime.Now.AddYears(-1);
            _twoYearsAgo = DateTime.Now.AddYears(-2);
            _now = DateTime.Now;
        }

        public static IEnumerable<object[]> VipCustomerDiscountData =>
            new List<object[]>
            {
                new object[] { DateTime.Now, Money.USD(8.92m) },
                new object[] { DateTime.Now.AddHours(-1), Money.USD(8.85m) },
                new object[] { DateTime.Now.AddHours(-2), Money.USD(8.79m) },
                new object[] { DateTime.Now.AddHours(-3), Money.USD(8.72m) },
                new object[] { DateTime.Now.AddHours(-4), Money.USD(8.66m) },
                new object[] { DateTime.Now.AddHours(-5), Money.USD(8.59m) },
                new object[] { DateTime.Now.AddHours(-6), Money.USD(8.52m) },
            };

        [Theory]
        [MemberData(nameof(VipCustomerDiscountData))]
        public void calculate_base_85_percent_discount_plus_purchase_frequency_and_duration_bonuses_for_vip_customers(DateTime lastPurchase, Money expectedDiscount)
        {
            var orderTotal = Money.USD(10);
            var nonPromotionalItemSpend = Money.USD(3000);
            var promotionalItemSpend = Money.USD(300);
            var signUpDate = _twoYearsAgo;

            var totalDiscount = LoyaltyUtil.CalculateDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(expectedDiscount, totalDiscount);
        }

        public static IEnumerable<object[]> DiamondCustomerDiscountData =>
            new List<object[]>
            {
                new object[] { DateTime.Now, Money.USD(7.67m) },
                new object[] { DateTime.Now.AddHours(-1), Money.USD(7.64m) },
                new object[] { DateTime.Now.AddHours(-2), Money.USD(7.62m) },
                new object[] { DateTime.Now.AddHours(-3), Money.USD(7.60m) },
                new object[] { DateTime.Now.AddHours(-4), Money.USD(7.57m) },
                new object[] { DateTime.Now.AddHours(-5), Money.USD(7.55m) },
                new object[] { DateTime.Now.AddHours(-6), Money.USD(7.52m) },
            };

        [Theory]
        [MemberData(nameof(DiamondCustomerDiscountData))]
        public void calculate_base_75_percent_discount_plus_purchase_frequency_and_duration_bonuses_for_diamond_customers(DateTime lastPurchase, Money expectedDiscount)
        {
            var orderTotal = Money.USD(10);
            var nonPromotionalItemSpend = Money.USD(1500);
            var promotionalItemSpend = Money.USD(100);
            var signUpDate = _twoYearsAgo;

            var totalDiscount = LoyaltyUtil.CalculateDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(expectedDiscount, totalDiscount);
        }

        public static IEnumerable<object[]> PlatinumCustomerDiscountData =>
            new List<object[]>
            {
                new object[] { DateTime.Now, Money.USD(5.24m) },
                new object[] { DateTime.Now.AddHours(-1), Money.USD(5.23m) },
                new object[] { DateTime.Now.AddHours(-2), Money.USD(5.22m) },
                new object[] { DateTime.Now.AddHours(-3), Money.USD(5.21m) },
                new object[] { DateTime.Now.AddHours(-4), Money.USD(5.20m) },
                new object[] { DateTime.Now.AddHours(-5), Money.USD(5.19m) },
                new object[] { DateTime.Now.AddHours(-6), Money.USD(5.18m) },
            };

        [Theory]
        [MemberData(nameof(PlatinumCustomerDiscountData))]
        public void calculate_base_50_percent_discount_plus_purchase_frequency_and_duration_bonuses_for_platinum_customers(DateTime lastPurchase, Money expectedDiscount)
        {
            var orderTotal = Money.USD(10);
            var nonPromotionalItemSpend = Money.USD(1000);
            var promotionalItemSpend = Money.USD(50);
            var signUpDate = _twoYearsAgo;

            var totalDiscount = LoyaltyUtil.CalculateDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(expectedDiscount, totalDiscount);
        }

        [Fact]
        public void calculate_40_percent_discount_for_gold_customers()
        {
            var orderTotal = Money.USD(100);
            var nonPromotionalItemSpend = Money.USD(1000);
            var promotionalItemSpend = Money.USD(50);
            var signUpDate = _oneYearAgo;
            var lastPurchase = _now;

            var totalDiscount = LoyaltyUtil.CalculateDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(Money.USD(40), totalDiscount);
        }

        [Fact]
        public void calculate_35_percent_discount_for_silver_customers()
        {
            var orderTotal = Money.USD(100);
            var nonPromotionalItemSpend = Money.USD(800);
            var promotionalItemSpend = Money.USD(50);
            var signUpDate = _oneYearAgo;
            var lastPurchase = _now;

            var totalDiscount = LoyaltyUtil.CalculateDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(Money.USD(35), totalDiscount);
        }

        [Fact]
        public void calculate_25_percent_discount_for_bronze_customers()
        {
            var orderTotal = Money.USD(100);
            var nonPromotionalItemSpend = Money.USD(400);
            var promotionalItemSpend = Money.USD(25);
            var signUpDate = _sixMonthsAgo;
            var lastPurchase = _now;

            var totalDiscount = LoyaltyUtil.CalculateDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(Money.USD(25), totalDiscount);
        }

        [Fact]
        public void calculate_0_percent_discount_for_regular_customers()
        {
            var orderTotal = Money.USD(100);
            var nonPromotionalItemSpend = Money.USD(400);
            var promotionalItemSpend = Money.USD(25);
            var signUpDate = _fiveMonthsAgo;
            var lastPurchase = _now;

            var totalDiscount = LoyaltyUtil.CalculateDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(Money.USD(0), totalDiscount);
        }

        [Fact]
        public void calculate_hours_difference_between_two_dates()
        {
            var startDate = new DateTime(2020, 07, 09, 12, 0, 0);
            var endDate = new DateTime(2020, 07, 11, 12, 0, 0);

            Assert.Equal(48, LoyaltyUtil.HoursDifferenceBetween(startDate, endDate));
        }

        [Fact]
        public void calculate_months_difference_between_two_dates()
        {
            var startDate = new DateTime(2020, 01, 09, 12, 0, 0);
            var endDate = new DateTime(2020, 07, 11, 12, 0, 0);

            Assert.Equal(6, LoyaltyUtil.MonthDifferenceBetween(startDate, endDate));
        }
    }
}
