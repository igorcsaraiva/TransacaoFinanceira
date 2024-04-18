using Moq;
using System;
using TransacaoFinanceira.Domain;
using TransacaoFinanceira.DTO;
using TransacaoFinanceira.Interfaces;
using TransacaoFinanceira.Service;
using Xunit;

namespace TransacaoFinanceira.Test.Service
{
    public class TransacaoServiceTest
    {
        [Fact]
        public void TransferirDeveTransferirParaContasValidas()
        {
            // Arrange
            var acessoDadosMock = new Mock<IAcessoDados>();
            acessoDadosMock.Setup(ad => ad.getContas(938485762)).Returns(new Conta(938485762, 180));
            acessoDadosMock.Setup(ad => ad.getContas(2147483649)).Returns(new Conta(2147483649, 0));
            acessoDadosMock.Setup(ad => ad.removeConta(It.IsAny<Conta>()));
            acessoDadosMock.Setup(ad => ad.addConta(It.IsAny<Conta>()));

            var transacaoService = new TransacaoService(acessoDadosMock.Object);

            var transacao = new Transacao { CorrelationId = 1, DateTime = "09/09/2023 14:15:00", ContaOrigem = 938485762, ContaDestino = 2147483649, Valor = 150 };

            // Act
            transacaoService.Transferir(transacao);

            // Assert
            acessoDadosMock.Verify(ad => ad.getContas(938485762), Times.Once);
            acessoDadosMock.Verify(ad => ad.getContas(2147483649), Times.Once);
            acessoDadosMock.Verify(ad => ad.removeConta(It.IsAny<Conta>()), Times.Exactly(2));
            acessoDadosMock.Verify(ad => ad.addConta(It.IsAny<Conta>()), Times.Exactly(2));

        }

        [Fact]
        public void TransferirDeveTransferirParaContasValidasValorValido()
        {
            // Arrange
            var acessoDadosMock = new Mock<IAcessoDados>();
            acessoDadosMock.Setup(ad => ad.getContas(938485762)).Returns(new Conta(938485762, 180));
            acessoDadosMock.Setup(ad => ad.getContas(2147483649)).Returns(new Conta(2147483649, 0));
            acessoDadosMock.Setup(ad => ad.removeConta(It.IsAny<Conta>()));
            acessoDadosMock.Setup(ad => ad.addConta(It.IsAny<Conta>()));

            var transacaoService = new TransacaoService(acessoDadosMock.Object);

            var transacao = new Transacao { CorrelationId = 1, DateTime = "09/09/2023 14:15:00", ContaOrigem = 938485762, ContaDestino = 2147483649, Valor = 150 };

            // Act
            transacaoService.Transferir(transacao);

            // Assert
            acessoDadosMock.Verify(ad => ad.getContas(938485762), Times.Once);
            acessoDadosMock.Verify(ad => ad.getContas(2147483649), Times.Once);
            acessoDadosMock.Verify(ad => ad.removeConta(It.IsAny<Conta>()), Times.Exactly(2));
            acessoDadosMock.Verify(ad => ad.addConta(It.IsAny<Conta>()), Times.Exactly(2));

        }

        [Fact]
        public void TransferirDeveTransferirParaContasValidasValorInvalido()
        {
            // Arrange
            var acessoDadosMock = new Mock<IAcessoDados>();
            acessoDadosMock.Setup(ad => ad.getContas(938485762)).Returns(new Conta(938485762, 180));
            acessoDadosMock.Setup(ad => ad.getContas(2147483649)).Returns(new Conta(2147483649, 0));
            acessoDadosMock.Setup(ad => ad.removeConta(It.IsAny<Conta>()));
            acessoDadosMock.Setup(ad => ad.addConta(It.IsAny<Conta>()));

            var transacaoService = new TransacaoService(acessoDadosMock.Object);

            var transacao = new Transacao { CorrelationId = 1, DateTime = "09/09/2023 14:15:00", ContaOrigem = 938485762, ContaDestino = 2147483649, Valor = 200 };

            // Act
            transacaoService.Transferir(transacao);

            // Assert
            acessoDadosMock.Verify(ad => ad.getContas(938485762), Times.Once);
            acessoDadosMock.Verify(ad => ad.getContas(2147483649), Times.Once);
            acessoDadosMock.Verify(ad => ad.removeConta(It.IsAny<Conta>()), Times.Never);
            acessoDadosMock.Verify(ad => ad.addConta(It.IsAny<Conta>()), Times.Never);

        }

        [Fact]
        public void TransferirDeveGerarExceptionContasInvalidas()
        {
            // Arrange
            var acessoDadosMock = new Mock<IAcessoDados>();
            acessoDadosMock.Setup(ad => ad.getContas(1)).Returns((Conta)null);
            acessoDadosMock.Setup(ad => ad.getContas(2147483649)).Returns(new Conta(2147483649, 0));
            acessoDadosMock.Setup(ad => ad.removeConta(It.IsAny<Conta>()));
            acessoDadosMock.Setup(ad => ad.addConta(It.IsAny<Conta>()));

            var transacaoService = new TransacaoService(acessoDadosMock.Object);

            var transacao = new Transacao { CorrelationId = 1, DateTime = "09/09/2023 14:15:00", ContaOrigem = 938485762, ContaDestino = 2147483649, Valor = 150 };

            // act & assert
            Assert.Throws<Exception>(() => transacaoService.Transferir(transacao));

        }

        [Fact]
        public void TransferirDeveGerarExceptionContasIguais()
        {
            // Arrange
            var acessoDadosMock = new Mock<IAcessoDados>();
            acessoDadosMock.Setup(ad => ad.getContas(938485762)).Returns(new Conta(2147483649, 0));
            acessoDadosMock.Setup(ad => ad.getContas(938485762)).Returns(new Conta(2147483649, 0));
            acessoDadosMock.Setup(ad => ad.removeConta(It.IsAny<Conta>()));
            acessoDadosMock.Setup(ad => ad.addConta(It.IsAny<Conta>()));

            var transacaoService = new TransacaoService(acessoDadosMock.Object);

            var transacao = new Transacao { CorrelationId = 1, DateTime = "09/09/2023 14:15:00", ContaOrigem = 938485762, ContaDestino = 938485762, Valor = 150 };

            // act & assert
            Assert.Throws<Exception>(() => transacaoService.Transferir(transacao));

        }
    }
}
