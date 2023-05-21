namespace FoodTrack.Services.ProductAPI.Models.Dto
{
    public class ResponseDto
    {
        public bool Success { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessage { get; set; }
    }
}
