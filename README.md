# Cash Flow Api

o sistema que permitirá o registro e consulta do fluxo de caixa de um comércio. 

## Desenho da solução

### EndPoints
Será disponibilizado dois endpoints:
1. Permitirá que os front-ends possam registrar os lançamentos
```
    [POST] host:port/api/cash-flow/
```
2. Permitirá que os front-ends possam listar todos os lançamentos
```
    [GET] host:port/api/cash-flow/
```
3. Permitirá a consulta de um relatório do fluxo diário
```
    [GET] host:port/api/cash-flow/report
```
  
  ### Dados
Os dados seguirão uma estrutura similar ao comando abaixo, podendo futuramente ser usado para criar a tabela em um banco de dados:
```
CREATE TABLE entries (
id int IDENTITY, 
date datetime, 
description varchar(100), 
value decimal
)
```

### Aplicação
A aplicação será desenvolvida em C# ASP .Net Core, o que permitirá a sua implantação em servidores linux e windows ou ainda a criação de um container docker com a aplicação.

### Dependências Ambiente Local

1. Instalar o .NET 6.0 SDK

https://dotnet.microsoft.com/en-us/download/dotnet/6.0

2. Clonar o projeto

3. Adicionar o repositório de dependencias do Nuget (se necessário)

```
dotnet nuget add source --name nuget.org https://api.nuget.org/v3/index.json
```
4. Pelo terminal, abrir a pasta do projeto CashFlowApi
```
cd CashFlowApi/
```
5. instalar as dependências
```
dotnet restore
```
6. rodar o projeto
```
dotnet run
```

Após instaladas as dependências, você pode rodar o projeto a partir da raiz com o seguinte comando:
```
dotnet run --project CashFlowApi
```


### Como rodar os testes

```
dotnet test
```