using System;

namespace RefactoringIfStatements.Polymorphism.Before
{
    public class Money
    {
        private Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; }
        public string Currency { get; }

        public static Money USD(decimal amount)
        {
            return new Money(amount, "USD");
        }

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(money1.Amount + money2.Amount, money1.Currency);
        }

        public static Money operator *(Money money, decimal multiplier)
        {
            return new Money(money.Amount * multiplier, money.Currency);
        }

        public static bool operator >=(Money money1, Money money2)
        {
            return money1.Amount >= money2.Amount;
        }

        public static bool operator <=(Money money1, Money money2)
        {
            return money1.Amount <= money2.Amount;
        }

        protected bool Equals(Money other)
        {
            return Amount == other.Amount && Currency == other.Currency;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public static implicit operator decimal(Money money) => money.Amount;
    }
}