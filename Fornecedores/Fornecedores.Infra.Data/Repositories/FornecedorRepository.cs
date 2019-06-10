using Fornecedores.Domain.Entities;
using Fornecedores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Infra.Data.Repositories
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public IEnumerable<Fornecedor> BuscarPorNome(string nome)
        {
            return Db.Fornecedores_.Where(p => p.nome == nome);
        }
    }
}
