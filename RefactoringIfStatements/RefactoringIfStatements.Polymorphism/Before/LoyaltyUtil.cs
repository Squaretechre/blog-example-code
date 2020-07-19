﻿using System;

namespace RefactoringIfStatements.Polymorphism.Before
{
    public class LoyaltyUtil
    {
        public static Money CalculateLoyaltyDiscount(Money orderTotal, Money nonPromotionalItemSpend, Money promotionalItemSpend, DateTime signUpDate, DateTime lastPurchase)
        {
            var monthsAsACustomer = MonthDifferenceBetween(signUpDate, DateTime.Now);
            var hoursSinceLastPurchase = HoursDifferenceBetween(lastPurchase, DateTime.Now);

            if (monthsAsACustomer >= 24 && nonPromotionalItemSpend >= Money.USD(3000) && promotionalItemSpend >= Money.USD(300) && hoursSinceLastPurchase <= 6)
            {
                return orderTotal * 0.85m;
            }
            else if (monthsAsACustomer >= 24 && nonPromotionalItemSpend >= Money.USD(1500) && promotionalItemSpend >= Money.USD(100) && hoursSinceLastPurchase <= 6)
            {
                return orderTotal * 0.75m;
            }
            else if (monthsAsACustomer >= 24 && nonPromotionalItemSpend >= Money.USD(1000) && promotionalItemSpend >= Money.USD(50) && hoursSinceLastPurchase <= 24)
            {
                return orderTotal * 0.50m;
            }
            else if (monthsAsACustomer >= 12 && nonPromotionalItemSpend >= Money.USD(1000) && promotionalItemSpend >= Money.USD(50))
            {
                return orderTotal * 0.40m;
            }
            else if (monthsAsACustomer >= 12 && nonPromotionalItemSpend >= Money.USD(800) && promotionalItemSpend >= Money.USD(50))
            {
                return orderTotal * 0.35m;
            }
            else if (monthsAsACustomer >= 6 && nonPromotionalItemSpend >= Money.USD(400) && promotionalItemSpend >= Money.USD(25))
            {
                return orderTotal * 0.25m;
            }

            return Money.USD(0);
        }

        public static double HoursDifferenceBetween(DateTime startDate, DateTime endDate)
        {
            return Math.Floor((endDate - startDate).TotalHours);
        }

        public static int MonthDifferenceBetween(DateTime startDate, DateTime endDate)
        {
            return (endDate.Month - startDate.Month) + 12 * (endDate.Year - startDate.Year);
        }
    }
}
