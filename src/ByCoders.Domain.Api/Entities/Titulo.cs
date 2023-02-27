using ByCoders.Core.DomainObjects;
using ByCoders.Core.Enums;
using FluentValidation.Results;
using System;

namespace ByCoders.Domain.Api.Entities
{
    public class Titulo : Entity
    {
        protected Titulo() {
            validationResult = new ValidationResult();
        }
        public Titulo(string LinhaCnab): this()
        {
            try
            {
                Tipo = (TipoTransacao)Convert.ToInt32(LinhaCnab.Substring(0, 1));
                //Hora = TimeSpan.Parse(LinhaCnab.Substring(43, 6));
                Hora = TimeSpan.Parse("12:00");
                DonoLoja = LinhaCnab.Substring(48, 14);
                NomeLoja = LinhaCnab.Substring(62, 15);
                //Data = DateTime.Parse(LinhaCnab.Substring(2, 8));
                Data = DateTime.Now.AddMinutes(30);
                Valor = Convert.ToDecimal(LinhaCnab.Substring(10, 10));
                Cpf = new Cpf(LinhaCnab.Substring(20, 11)).Numero;
                Cartao = new CartaoCredito(nomeCartao: null,
                    numeroCartao: LinhaCnab.Substring(31, 12),
                    mesAnoVencimento: null, cVV: null).NumeroCartao;
                Processado = false;
            }
            catch (Exception e) {
                validationResult.Errors.Add(new ValidationFailure("Error",e.Message));
            }
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
