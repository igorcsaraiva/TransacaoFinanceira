using System;
using TransacaoFinanceira.Domain;
using TransacaoFinanceira.DTO;
using TransacaoFinanceira.Interfaces;
using TransacaoFinanceira.Repository;

namespace TransacaoFinanceira.Service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly IAcessoDados _acessoDados;
        private Conta ContaOrigem { get; set; }
        private Conta ContaDestino { get; set; }

        public TransacaoService()
        {
            _acessoDados = new AcessoDados();
        }

        public TransacaoService(IAcessoDados acessoDados)
        {
             _acessoDados = acessoDados;
        }

        public void Transferir(Transacao transacao)
        {
            ObterContas(transacao);

            ValidarContasObtidas();

            if (ContaOrigem.PermitidoTransferir(transacao.Valor))
            {
                ContaOrigem.Transferir(transacao.Valor);
                ContaDestino.Receber (transacao.Valor);
                _acessoDados.removeConta(ContaOrigem);
                _acessoDados.removeConta(ContaDestino);
                _acessoDados.addConta(ContaOrigem);
                _acessoDados.addConta(ContaDestino);
                Console.WriteLine($"Transacao numero {transacao.CorrelationId} foi efetivada com sucesso! Novos saldos: Conta Origem:{ContaOrigem.Saldo} | Conta Destino: {ContaDestino.Saldo}");              
            }
            else
            {
                Console.WriteLine($"Transacao numero {transacao.CorrelationId} foi cancelada por falta de saldo");
            }

        }

        private void ObterContas(Transacao transacao)
        {
            ContaOrigem = _acessoDados.getContas(transacao.ContaOrigem);
            ContaDestino = _acessoDados.getContas(transacao.ContaDestino);
        }

        private void ValidarContasObtidas()
        {
            if (ContaOrigem is null || ContaDestino is null)
            {
                throw new Exception("Contas não existem");
            }

            if (ContaOrigem.Equals(ContaDestino))
            {
                throw new Exception("Conta origem igual conta destino");
            }
        }
    }
}
