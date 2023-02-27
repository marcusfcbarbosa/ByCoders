using ByCoders.Core.Enums;
using ByCoders.Core.Extensions;
using ByCoders.Core.Identity;
using Microsoft.VisualBasic;
using System;

namespace ByCoders.Web.Models
{

    public class ListTituloModel
    {
        public PagedResult<TituloModel> titulos { get; set; }
        public IAspNetUser aspNetUser { get; set; }
    }

    public class TituloModel
    {
        public Guid Id { get; set; }
        public TipoTransacao Tipo { get;  set; }
        public DateTime Data { get;  set; }
        public decimal Valor { get;  set; }
        public string Cpf { get;  set; }
        public string Cartao { get;  set; }
        public TimeSpan Hora { get;  set; }
        public string DonoLoja { get;  set; }
        public string NomeLoja { get;  set; }
    }


}
