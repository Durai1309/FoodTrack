using static FoodTrack.Web.StaticData;

namespace FoodTrack.Web.Models
{
    public class ApiRequestcs
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string ApiUrl { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
