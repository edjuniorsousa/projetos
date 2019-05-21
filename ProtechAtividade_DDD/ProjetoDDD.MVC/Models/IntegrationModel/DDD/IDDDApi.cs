using ProjetoDDD.MVC.Models.IntegrationModel.DDD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoDDD.MVC.Models.IntegrationModel.DDD
{
    public interface IDDDApi
    {
        Task<ICollection<PessoaLista>> GetAllPersons();
        Task<Pessoa> GetPersonById(int id);
    }
}