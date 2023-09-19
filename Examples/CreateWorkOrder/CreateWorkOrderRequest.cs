namespace Fsi.PublicApi.Sample.Dotnet.Examples.CreateWorkOrder
{
    public class CreateWorkorderRequest
    {
        public int? StatusId { get; set; }

        public int? CategoryId { get; set; }

        public int? ProblemId { get; set; }

        public string Description { get; set; }

        public int? LocationId { get; set; }

        public string RequestorName { get; set; }

        public string RequestorEmail { get; set; }

        public string RequestorPhone { get; set; }

        public int? TradeId { get; set; }

        public int? PriorityId { get; set; }
    }
}
