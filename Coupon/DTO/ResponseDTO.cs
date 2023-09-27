namespace Service.Shop.Coupons.DTO
{
    public class ResponseDTO
    {
        public object? Result
        { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public string Message { get; set; } = ""; 
    }
}
