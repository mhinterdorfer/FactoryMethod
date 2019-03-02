using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminApplication.DataAccessLayer
{
    internal class DataAccessLayer
    {
        private static DataAccessLayer _instance;
        private readonly HttpClient HttpClient;

        public DataAccessLayer()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/")
            };
        }

        public static DataAccessLayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataAccessLayer();
                }
                return _instance;
            }
        }


        public async Task<string> GetAsync(string Url)
        {
            Console.WriteLine("GetAsync: " + Url);
            string JsonString = "";
            HttpResponseMessage Response = HttpClient.GetAsync(Url).Result;
            if (Response.IsSuccessStatusCode)
            {
                JsonString = await Response.Content.ReadAsStringAsync();
            }

            return JsonString;
        }

        public async Task<HttpResponseMessage> PostAsync(string Url, StringContent HttpContent)
        {
            HttpResponseMessage HttpResponse = await HttpClient.PostAsync(Url, HttpContent);
            return HttpResponse;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string Url)
        {
            HttpResponseMessage HttpResponse = await HttpClient.DeleteAsync(Url);
            return HttpResponse;
        }

        public async Task<HttpResponseMessage> PutAsync(string Url, StringContent HttpContent)
        {
            HttpResponseMessage HttpResponse = await HttpClient.PutAsync(Url, HttpContent);
            return HttpResponse;
        }
    }

}
