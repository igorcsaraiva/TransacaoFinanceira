using TransacaoFinanceira.Domain;

namespace TransacaoFinanceira.Interfaces
{
    public interface IAcessoDados
    {
        Conta getContas(long numeroConta);
        bool addConta(Conta contas);
        bool removeConta(Conta contas);
    }
}
