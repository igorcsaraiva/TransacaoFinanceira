# TransacaoFinanceira

Case para refatoração

Passos a implementar:

1. Corrija o que for necessario para resolver os erros de compilação.
2. Execute o programa para avaliar a saida, identifique e corrija o motivo de algumas transacoes estarem sendo canceladas mesmo com saldo positivo e outras sem saldo sendo efetivadas.
3. Aplique o code review e refatore conforme as melhores praticas(SOLID,Patterns,etc).
4. Implemente os testes unitários que julgar efetivo.
5. Crie um git hub e compartilhe o link respondendo o ultimo e-mail.


# Identificação e resolução dos erros de compilação

Ao baixar o projeto e tentar compila-lo para testar foi possivel identificar os seguintes erros abaixo listados:

1. 
![Falha build](https://github.com/igorcsaraiva/TransacaoFinanceira/blob/master/img/FalhaBuild.png)
2. 
![Falha build1](https://github.com/igorcsaraiva/TransacaoFinanceira/blob/master/img/FalhaBuild1.png)
3. 
![Falha build2](https://github.com/igorcsaraiva/TransacaoFinanceira/blob/master/img/FalhaBuild2.png)

A correção foi feita segindo as proprias mensagens de erro disparadas pelo processo de compilação tais como:

1. Execução do comando dotnet restore para realizar a restauração dos pacotes nugtes

![Resolucao build](https://github.com/igorcsaraiva/TransacaoFinanceira/blob/master/img/ResolucaoFalhaBuild.png)

2. Mudança do tipo de dado das variaveis relacionadas ao número da conta de origem e destino de uint para long

![Resolucao build](https://github.com/igorcsaraiva/TransacaoFinanceira/blob/master/img/ResolucaoFalhaBuild1.png)

3. Criação de um record para tipar o array de transação permitindo assim que os metodos que usem generics possam inferir o tipo ao qual estão relacionados

![Resolucao build](https://github.com/igorcsaraiva/TransacaoFinanceira/blob/master/img/ResolucaoFalhaBuild2.png)

# Refatoração e correção dos erros de transação

Foi identificado que o código execultava as transções em threads separadas devido ao Parallel.ForEach, o que ocasionava as inconsistências nos dados das transações. A correção foi feita aplicando a instrução lock garantindo que, no máximo, apenas um thread execute seu corpo a qualquer momento 

### Arquitetura em Camadas
O projeto foi estruturado seguindo uma Arquitetura em Camadas, promovendo a separação de responsabilidades e a modularidade.
As camadas incluem:

- Camada de Domínio (Domain): Contém as entidades centrais do negócio, como Transacao e ContaSaldo, e encapsula a lógica de negócios fundamental.
- Camada de Acesso a Dados (Repository): Responsável pela comunicação com mecanismos de armazenamento, gerenciando a persistência e recuperação de dados de transações e saldos.
- Camada de Serviço (Services): Orquestra o fluxo de operações de aplicação, interagindo com a camada de domínio para processar transações financeiras através da classe ExecutarTransacaoFinanceira.

### Código e Manutenção

- Legibilidade e Manutenção: Melhoria na legibilidade e na estrutura, aplicando nomes descritivos seguindo as convenções de nomenclatura da linguagem e mantendo métodos e classes focados em uma única responsabilidade.
- Tratamento de Erros: Melhoria no tratamento de erros para garantir que o sistema se comporte de maneira previsível e informe adequadamente sobre situações excepcionais.
- Concorrência: Implementado o gerenciamento de acesso a recursos compartilhados usando lock, garantindo a execução segura em ambientes de múltiplas threads.

### Testes Unitários

O projeto foi estruturado para permitir testes isolados de componentes, assegurando que cada parte funcione corretamente de forma independente.  
Foram implementados testes unitários abrangentes, utilizando um framework de mocking para simular dependências externas. Esses testes cobriram casos de uso críticos, como validação diversas, processamento de transações e manutenção do estado das transações processadas, garantindo que a lógica de negócios funcionasse como esperado em diferentes cenários.