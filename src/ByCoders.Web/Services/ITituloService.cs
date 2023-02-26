using ByCoders.Core.Communications;
using ByCoders.Core.Extensions;
using ByCoders.Web.Extensions;
using ByCoders.Web.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ByCoders.Web.Services
{
    public interface ITituloService
    {
        Task<PagedResult<TituloModel>> GetAllTitulosPaged(int pageSize, int pageIndex, string query = null);

        Task<ResponseResult> Add(AddTituloModel command);
    }

    public class TituloService : Service, ITituloService
    {
        private readonly HttpClient _httpClient;

        public TituloService(HttpClient httpClient,
           IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ByCodersUrl);
        }
        public async Task<ResponseResult> Add(AddTituloModel command)
        {
            var content = GetContent(command);
            var response = await _httpClient.PostAsync("/api/titulos/create", content);
            if (!HandleErrorsResponse(response)) return await DeserializeResponseObject<ResponseResult>(response);
            return ReturnOk();
        }

        public async Task<PagedResult<TituloModel>> GetAllTitulosPaged(int pageSize, int pageIndex, string query = null)
        {
            var response = await _httpClient.GetAsync($"/api/titulos/all?ps={pageSize}&page={pageIndex}&q={query}");
            HandleErrorsResponse(response);
            return await DeserializeResponseObject<PagedResult<TituloModel>>(response);
        }
    }
}
