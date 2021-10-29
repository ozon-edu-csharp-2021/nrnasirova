namespace MerchandiseService.HttpModels
{
    public class BaseResponse<T>
    {
        public int Code { get; set; }
        public T Payload { get; set; }
        public string Message { get; set; }
    }

    public enum Status
    {
        Approved = 10,
        Error = 11
    }
}