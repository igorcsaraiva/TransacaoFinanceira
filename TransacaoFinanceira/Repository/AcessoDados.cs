using System;
using System.Collections.Generic;
using TransacaoFinanceira.Domain;
using TransacaoFinanceira.Interfaces;

namespace TransacaoFinanceira.Repository
{
    public class AcessoDados : IAcessoDados
    {
        private List<Conta> TABELA_SALDOS;
        public AcessoDados()
        {
            TABELA_SALDOS = new List<Conta>();
            TABELA_SALDOS.Add(new Conta(938485762, 180));
            TABELA_SALDOS.Add(new Conta(347586970, 1200));
            TABELA_SALDOS.Add(new Conta(2147483649, 0));
            TABELA_SALDOS.Add(new Conta(675869708, 4900));
            TABELA_SALDOS.Add(new Conta(238596054, 478));
            TABELA_SALDOS.Add(new Conta(573659065, 787));
            TABELA_SALDOS.Add(new Conta(210385733, 10));
            TABELA_SALDOS.Add(new Conta(674038564, 400));
            TABELA_SALDOS.Add(new Conta(563856300, 1200));
        }

        public Conta getContas(long numeroConta)
        {
            return TABELA_SALDOS.Find(x => x.NumeroConta == numeroConta);
        }

        public bool addConta(Conta contas)
        {
            try
            {
                TABELA_SALDOS.Add(contas);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool removeConta(Conta contas)
        {
            try
            {  
                return TABELA_SALDOS.Remove(contas); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
