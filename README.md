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

1. Execução do comanda dotnet restore para realizar a restauração dos pacotes nugtes

![Resolucao build](https://github.com/igorcsaraiva/TransacaoFinanceira/blob/master/img/ResolucaoFalhaBuild.png)

2. Mudança do tipo de dado das variaveis relacionadas ao número da conta de origem e destino de uint para long

![Resolucao build](https://github.com/igorcsaraiva/TransacaoFinanceira/blob/master/img/ResolucaoFalhaBuild1.png)

3. Criação de um record para tipar o array de transação permitindo assim que os metodos que usem generics possam inferir o tipo ao quel estão relacionados

![Resolucao build](https://github.com/igorcsaraiva/TransacaoFinanceira/blob/master/img/ResolucaoFalhaBuild2.png)