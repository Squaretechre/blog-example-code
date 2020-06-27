using System;

namespace RefactoringIfStatements.LookupTables.Order.After.DiscountsExtractedFromOrder
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money USD(decimal amount)
        {
            return new Money(amount, "USD");
        }

        public static Money operator *(Money money, decimal multiplier)
        {
            return new Money(money.Amount * multiplier, money.Currency);
        }

        protected bool Equals(Money other)
        {
            return Amount == other.Amount && Currency == other.Currency;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }
    }
}