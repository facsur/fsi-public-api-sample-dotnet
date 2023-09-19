namespace Fsi.PublicApi.Sample.Dotnet.Examples.GetLocations
{
    public class GetLocationResponse
    {
        public int CustomerId { get; set; } 

        public int SegmentId { get; set; }

        public DateTime ModifiedUtc { get; set; }

        public Location[] Data { get; set; }
    }

    // Information on all the fields that get returned as part of this response can be found on the developer portal.
    public class Location
    {
        public int Id { get; set; }

        public string Desc { get; set; }
    }
}
