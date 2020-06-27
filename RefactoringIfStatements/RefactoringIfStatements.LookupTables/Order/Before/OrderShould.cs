using Xunit;

namespace RefactoringIfStatements.LookupTables.Order.Before
{
    public class OrderShould
    {
        [Fact]
        public void calculate_no_discount_for_general_customers()
        {
           var sut = new Order(Money.USD(100), Customer.General()); 

           Assert.Equal(Money.USD(0), sut.Discount());
        }

        [Fact]
        public void calculate_5_percent_discount_for_bronze_customers()
        {
            var sut = new Order(Money.USD(100), Customer.Bronze());

            Assert.Equal(Money.USD(5), sut.Discount());
        }

        [Fact]
        public void calculate_10_percent_discount_for_silver_customers()
        {
            var sut = new Order(Money.USD(100), Customer.Silver());

            Assert.Equal(Money.USD(10), sut.Discount());
        }

        [Fact]
        public void calculate_15_percent_discount_for_gold_customers()
        {
            var sut = new Order(Money.USD(100), Customer.Gold());

            Assert.Equal(Money.USD(15), sut.Discount());
        }

        [Fact]
        public void calculate_20_percent_discount_for_platinum_customers()
        {
            var sut = new Order(Money.USD(100), Customer.Platinum());

            Assert.Equal(Money.USD(20), sut.Discount());
        }
    }
}
