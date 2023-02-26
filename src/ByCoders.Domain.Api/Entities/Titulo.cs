using ByCoders.Core.DomainObjects;
using Microsoft.VisualBasic;
using System;

namespace ByCoders.Domain.Api.Entities
{
    public class Titulo : Entity
    {
        protected Titulo() { }
        public Titulo(int tipo, DateAndTime data, 
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

        public int Tipo { get; private set; } 
        public DateAndTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public string Cpf { get; private set; }
        public string Cartao { get; private set; }
        public TimeSpan Hora { get; private set; }
        public string DonoLoja { get; private set; }
        public string NomeLoja { get; private set; }
    }
}
