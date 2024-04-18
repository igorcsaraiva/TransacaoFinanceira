namespace TransacaoFinanceira.Domain
{
    public class Conta
    {
        public decimal Saldo { get; set; }
        public long NumeroConta { get; set; }

        public Conta(long numeroConta, decimal saldo)
        {
            Saldo = saldo;
            NumeroConta = numeroConta;
        }

        public bool PermitidoTransferir(decimal valor)
        {
            return Saldo >= valor && valor > 0;
        }

        public void Transferir(decimal valor)
        {
            Saldo -= valor;
        }

        public void Receber(decimal valor)
        {
            Saldo += valor;
        }

        public bool Equals(Conta obj)
        {
            return obj.NumeroConta == NumeroConta;
        }
    }
}
