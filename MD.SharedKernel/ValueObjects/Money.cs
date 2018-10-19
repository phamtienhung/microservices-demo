using System;

namespace MD.SharedKernel.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; private set; }

        public string Currency { get; private set; }

        public Money() : this(0)
        {
        }

        public Money(decimal amount, string currency = "VND")
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public void SetAmount(decimal amount)
        {
            this.Amount = amount;
        }

        public static Money Sum(Money a, Money b)
        {
            return new Money(a.Amount + b.Amount);
        }

        public override string ToString()
        {
            return this.Amount == 0 ? "0 VND" : string.Format("{0:#,##0.00} {1}", this.Amount, this.Currency);
        }

        public static Money operator *(Money a, decimal param)
        {
            return new Money(a.Amount * param);
        }

        public static Money operator *(Money a, double param)
        {
            return new Money(a.Amount * (decimal)param);
        }

        public static Money operator *(Money a, int param)
        {
            return new Money(a.Amount * param);
        }

        public static Money operator -(Money a, Money b)
        {
            return new Money(a.Amount - b.Amount);
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.Amount + b.Amount);
        }

        public static bool operator >(Money a, Money b)
        {
            return a.Amount > b.Amount;
        }

        public static bool operator ==(Money a, Money b)
        {
            return a.Amount == b.Amount && string.Equals(a.Currency, b.Currency);
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public static bool operator <(Money a, Money b)
        {
            return a.Amount < b.Amount;
        }

        public static Money operator /(Money a, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n must be greater than 0");
            }

            return new Money(a.Amount / n, a.Currency);
        }
    }
}