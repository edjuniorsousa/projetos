using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Domain.Interfaces.Repositories;

namespace ProtechAtividade_DDD.Infra.Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
    }
}
