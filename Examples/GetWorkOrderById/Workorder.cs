namespace FSI.PublicApi.Sample.Dotnet.Examples.GetWorkOrderById
{
    // For the full list of available work order properties please see the documentation on the FSI Public API Developer Portal.
    public class Workorder
    {
        public Guid Id { get; set; }

        public int IdCustomer { get; set; }

        public int IdCustomerSegment { get; set; }

        public string Description { get; set; }

        public int IdLocation { get; set; }
    }
}
