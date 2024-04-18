using TransacaoFinanceira.DTO;

namespace TransacaoFinanceira.Interfaces
{
    public interface ITransacaoService
    {
        void Transferir(Transacao transacao);
    }
}
