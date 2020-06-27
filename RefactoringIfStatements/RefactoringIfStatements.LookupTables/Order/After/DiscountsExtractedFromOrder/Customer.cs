namespace RefactoringIfStatements.LookupTables.Order.After.DiscountsExtractedFromOrder
{
    public class Customer
    {
        public CustomerStatus Status { get; }

        private Customer(CustomerStatus status)
        {
            Status = status;
        }

        public static Customer General() => new Customer(CustomerStatus.General);
        public static Customer Bronze() => new Customer(CustomerStatus.Bronze);
        public static Customer Silver() => new Customer(CustomerStatus.Silver);
        public static Customer Gold() => new Customer(CustomerStatus.Gold);
        public static Customer Platinum() => new Customer(CustomerStatus.Platinum);
    }
}