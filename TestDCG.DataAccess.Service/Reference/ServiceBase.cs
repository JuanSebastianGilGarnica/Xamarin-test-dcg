namespace TestDCG.DataAccess.Service.Reference
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class ServiceBase
    {
        private readonly HttpClient _httpClient;

        private const string MediaTypeJson = "application/JSON";

        public ServiceBase()
        {
            _httpClient = new HttpClient();
        }

        protected async Task<TResult> Get<TResult>(string url) where TResult : class, new()
        {
            try
            {
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                return await ProcessResponse<TResult>(response);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected async Task<TResult> Post<TResult>(object request, string url) where TResult : class, new()
        {
            try
            {
                string json = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(json, Encoding.UTF8, MediaTypeJson);
                var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);
                return await ProcessResponse<TResult>(response);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<TResult> ProcessResponse<TResult>(HttpResponseMessage response) where TResult : class, new()
        {
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<TResult>(responseString);
                }
                else
                {
                    string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
