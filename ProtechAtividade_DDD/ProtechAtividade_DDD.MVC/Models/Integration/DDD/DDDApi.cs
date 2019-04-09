using ProtechAtividade_DDD.MVC.Extensions.Http;
using ProtechAtividade_DDD.MVC.Models.Integration.DDD.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProtechAtividade_DDD.MVC.Models.Integration.DDD
{
    public class DDDApi : IDDDApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://www.mocky.io/v2/";

        public DDDApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "AppMVC");
        }

        public async Task<ICollection<PessoaLista>> GetAllPersons()
        {
            var path = string.Concat(_baseUrl, "5c41f7033200005f007326b6");
            var response = await _httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsJsonAsync<ICollection<PessoaLista>>();
            }

            return null;
        }

        public async Task<Pessoa> GetPersonById(int id)
        {
            var path = string.Concat(_baseUrl, "5c41f7d532000052007326b9");
            var response = await _httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsJsonAsync<Pessoa>();
            }

            return null;
        }
    }
}