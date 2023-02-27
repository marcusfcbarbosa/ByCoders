using ByCoders.Core.DomainObjects;
using ByCoders.Core.Enums;
using System;

namespace ByCoders.Domain.Api.Entities
{
    public class Titulo : Entity
    {
        protected Titulo() { }
        public Titulo(string LinhaCnab)
        {
            Tipo = (TipoTransacao)Convert.ToInt32(LinhaCnab.Substring(0, 1));
            Data = DateTime.Parse(LinhaCnab.Substring(2, 7));
            Valor = Convert.ToDecimal(LinhaCnab.Substring(10, 9));
            Cpf = new Cpf(LinhaCnab.Substring(20, 30)).Numero;
            Cartao = new CartaoCredito(nomeCartao: null, numeroCartao: LinhaCnab.Substring(31, 11), mesAnoVencimento: null, cVV: null).NumeroCartao;
            Hora = TimeSpan.Parse(LinhaCnab.Substring(43, 5));
            DonoLoja = LinhaCnab.Substring(49, 13);
            NomeLoja = LinhaCnab.Substring(63, 18);
            Processado = false;
        }
        public Titulo(TipoTransacao tipo,
            DateTime data,
            decimal valor,
            string cpf,
            string cartao,
            TimeSpan hora,
            string donoLoja,
            string nomeLoja)
        {
            Tipo = tipo;
            Data = data;
            Valor = valor;
            Cpf = new Cpf(cpf).Numero;
            Cartao = new CartaoCredito(nomeCartao: null, numeroCartao: cartao, mesAnoVencimento: null, cVV: null).NumeroCartao;
            Hora = hora;
            DonoLoja = donoLoja;
            NomeLoja = nomeLoja;
        }

        public TipoTransacao Tipo { get; private set; }
        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public string Cpf { get; private set; }
        public string Cartao { get; private set; }
        public TimeSpan Hora { get; private set; }
        public string DonoLoja { get; private set; }
        public string NomeLoja { get; private set; }
        public bool Processado { get; private set; }

        public void ProcessaTitulo()
        {
            Processado = true;
        }

    }
}
