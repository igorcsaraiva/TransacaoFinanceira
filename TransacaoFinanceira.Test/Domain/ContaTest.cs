using TransacaoFinanceira.Domain;
using Xunit;

namespace TransacaoFinanceira.Test.Domain
{
    public class ContaTest
    {
        [Fact]
        public void PermitodoTransferirDeveRetornarTrue()
        {
            // Arrange
            var conta = new Conta(1, 100);

            // Act
            var permitidoTransferir = conta.PermitidoTransferir(50);
            var permitidoTransferir1 = conta.PermitidoTransferir(100);

            // Assert
            Assert.True(permitidoTransferir);
            Assert.True(permitidoTransferir1);

        }

        [Fact]
        public void PermitodoTransferirDeveRetornarFalse()
        {
            // Arrange
            var conta = new Conta(1, 100);

            // Act
            var permitidoTransferir = conta.PermitidoTransferir(101);
            var permitidoTransferir1 = conta.PermitidoTransferir(0);

            // Assert
            Assert.False(permitidoTransferir);
            Assert.False(permitidoTransferir1);

        }

        [Fact]
        public void TransferirDeveSubtrairSaldo()
        {
            // Arrange
            var conta = new Conta(1, 100);

            // Act
            conta.Transferir(99);

            // Assert
            Assert.Equal(1, conta.Saldo);

        }

        [Fact]
        public void ReceberDeveAdicionarSaldo()
        {
            // Arrange
            var conta = new Conta(1, 100);

            // Act
            conta.Receber(50);

            // Assert
            Assert.Equal(150, conta.Saldo);

        }

        [Fact]
        public void EqualsDeveRetornarTrue()
        {
            // Arrange
            var conta = new Conta(1, 100);
            var conta1 = new Conta(1, 200);

            // Act
            var igual = conta.Equals(conta1);

            // Assert
            Assert.True(igual);

        }

        [Fact]
        public void EqualsDeveRetornarFalse()
        {
            // Arrange
            var conta = new Conta(1, 100);
            var conta1 = new Conta(2, 200);

            // Act
            var igual = conta.Equals(conta1);

            // Assert
            Assert.False(igual);

        }
    }
}
