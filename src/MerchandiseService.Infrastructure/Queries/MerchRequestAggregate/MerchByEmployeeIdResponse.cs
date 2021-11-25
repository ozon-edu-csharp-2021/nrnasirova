using System;

namespace Infrastructure.Queries.MerchRequestAggregate
{
    public class MerchByEmployeeIdResponse
    {
        public string EmployeeEmail { get; set; }
        public int MerchPackType { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset GivenOutAt { get; set; }
    }
}