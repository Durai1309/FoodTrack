namespace FoodTrack.Web
{
    public class StaticData
    {
        public static string? ProductAPIBase { get; set; }

        public enum ApiType
        {
            GET, 
            POST,
            PUT,
            DELETE,
        }
    }
}
