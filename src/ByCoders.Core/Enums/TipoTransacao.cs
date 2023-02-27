using System.ComponentModel;

namespace ByCoders.Core.Enums
{
    public enum TipoTransacao
    {
        [Description("Debito")]
        Debito = 1,
        [Description("Boleto")]
        Boleto = 2,
        [Description("Financiamento")]
        Financiamento = 3,
        [Description("Credito")]
        Credito = 4,
        [Description("RecebimentoEmprestimo")]
        RecebimentoEmprestimo = 5,
        [Description("Vendas")]
        Vendas = 6,
        [Description("RecebimentoTED")]
        RecebimentoTED = 7,
        [Description("RecebimentoDOC")]
        RecebimentoDOC = 8,
        [Description("Aluguel")]
        Aluguel = 9
    }
}
