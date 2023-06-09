﻿using FoodTrack.Web.Models;
using FoodTrack.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FoodTrack.Web.Services
{
    public class BaseServices : IBaseSevices
    {
        public ResponseDto responseDto { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseServices(IHttpClientFactory httpClient)
        {
            this.responseDto = new ResponseDto();
            this.httpClient = httpClient;
        }
        public async Task<T> SentAsync<T>(ApiRequestcs apiRequestcs)
        {
            try
            {
                var client = httpClient.CreateClient("FoodTrack");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequestcs.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                if (apiRequestcs.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequestcs.Data),
                        Encoding.UTF8, "application/json");
                }
            
                ////get Response from Client
                HttpResponseMessage apiResponse = null;
                ///Type of Message
                switch (apiRequestcs.ApiType)
                {
                    case StaticData.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticData.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticData.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
        
            }
            catch (Exception)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    Success = false,
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }

        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
