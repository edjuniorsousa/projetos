using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjetoDDD.MVC.Extensions.Http
{
    public static class HttpContentExtensions
    {
        public static async Task<TResult> ReadAsJsonAsync<TResult>(this HttpContent httpContent)
        {
            return JsonConvert.DeserializeObject<TResult>(await httpContent.ReadAsStringAsync());
        }
    }
}