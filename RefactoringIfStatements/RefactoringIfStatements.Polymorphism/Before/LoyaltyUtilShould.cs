using System;
using Xunit;

namespace RefactoringIfStatements.Polymorphism.Before
{
    public class LoyaltyUtilShould
    {
        private readonly DateTime _fiveMonthsAgo;
        private readonly DateTime _sixMonthsAgo;
        private readonly DateTime _oneYearAgo;
        private readonly DateTime _twoYearsAgo;
        private readonly DateTime _sixHoursAgo;
        private readonly DateTime _twentyFourHoursAgo;
        private readonly DateTime _now;

        public LoyaltyUtilShould()
        {
            _fiveMonthsAgo = DateTime.Now.AddMonths(-5);
            _sixMonthsAgo = DateTime.Now.AddMonths(-6);
            _oneYearAgo = DateTime.Now.AddYears(-1);
            _twoYearsAgo = DateTime.Now.AddYears(-2);
            _sixHoursAgo = DateTime.Now.AddHours(-6);
            _twentyFourHoursAgo = DateTime.Now.AddHours(-24);
            _now = DateTime.Now;
        }

        [Fact]
        public void calculate_85_percent_discount_for_vip_customers()
        {
            var orderTotal = Money.USD(100);
            var nonPromotionalItemSpend = Money.USD(3000);
            var promotionalItemSpend = Money.USD(300);
            var signUpDate = _twoYearsAgo;
            var lastPurchase = _sixHoursAgo;

            var totalDiscount = LoyaltyUtil.CalculateLoyaltyDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(Money.USD(85), totalDiscount);
        }

        [Fact]
        public void calculate_75_percent_discount_for_diamond_customers()
        {
            var orderTotal = Money.USD(100);
            var nonPromotionalItemSpend = Money.USD(1500);
            var promotionalItemSpend = Money.USD(100);
            var signUpDate = _twoYearsAgo;
            var lastPurchase = _sixHoursAgo;

            var totalDiscount = LoyaltyUtil.CalculateLoyaltyDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(Money.USD(75), totalDiscount);
        }

        [Fact]
        public void calculate_50_percent_discount_for_platinum_customers()
        {
            var orderTotal = Money.USD(100);
            var nonPromotionalItemSpend = Money.USD(1000);
            var promotionalItemSpend = Money.USD(50);
            var signUpDate = _twoYearsAgo;
            var lastPurchase = _twentyFourHoursAgo;

            var totalDiscount = LoyaltyUtil.CalculateLoyaltyDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

            Assert.Equal(Money.USD(50), totalDiscount);
        }

        [Fact]
        public void calculate_40_percent_discount_for_gold_customers()
        {
            var orderTotal = Money.USD(100);
            var nonPromotionalItemSpend = Money.USD(1000);
            var promotionalItemSpend = Money.USD(50);
            var signUpDate = _oneYearAgo;
            var lastPurchase = _now;

            var totalDiscount = LoyaltyUtil.CalculateLoyaltyDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

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

            var totalDiscount = LoyaltyUtil.CalculateLoyaltyDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

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

            var totalDiscount = LoyaltyUtil.CalculateLoyaltyDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

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

            var totalDiscount = LoyaltyUtil.CalculateLoyaltyDiscount(orderTotal, nonPromotionalItemSpend, promotionalItemSpend, signUpDate, lastPurchase);

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
