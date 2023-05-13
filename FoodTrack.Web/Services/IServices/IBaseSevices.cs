using FoodTrack.Web.Models;

namespace FoodTrack.Web.Services.IServices
{
    public interface IBaseSevices :IDisposable
    {
        ResponseDto responseDto { get; set; }
        Task <T> SentAsync<T>(ApiRequestcs apiRequestcs);
    }
}
