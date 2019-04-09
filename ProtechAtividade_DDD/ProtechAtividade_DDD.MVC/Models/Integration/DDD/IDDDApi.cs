using ProtechAtividade_DDD.MVC.Models.Integration.DDD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProtechAtividade_DDD.MVC.Models.Integration.DDD
{
    public interface IDDDApi
    {
        Task<ICollection<PessoaLista>> GetAllPersons();
        Task<Pessoa> GetPersonById(int id);
    }
}