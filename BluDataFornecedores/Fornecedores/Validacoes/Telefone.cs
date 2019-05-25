using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Fornecedores.Validacoes
{
    public class Telefone
    {
        #region Validar telefone
        public static bool ValidarTelefone(string telefone)
        {
            string padraoTelefone = @"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$";
            Regex expressaoRegularDeTelefone = new Regex(padraoTelefone);
            return expressaoRegularDeTelefone.IsMatch(telefone);
        }
        #endregion
    }
}