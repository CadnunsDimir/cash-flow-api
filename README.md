# Cash Flow Api

o sistema que permitirá o registro e consulta do fluxo de caixa de um comércio. 

## Desenho da solução

### EndPoints
Será disponibilizado dois endpoints:
1. Permitirá que os front-ends possam registrar os lançamentos
```
    [POST] host:port/api/cash-flow/
```
2. Permitirá a consulta de um relatório do fluxo diário
```
    [GET] host:port/api/cash-flow/report
```
  
  ### Dados
Os dados serão guardados em um banco de dados mysql, que conterá uma tabela com a seguinte estrutura 
```
CREATE TABLE entries (
id int IDENTITY, 
datetime datetime, 
description varchar(100), 
value decimal
)
```

### Aplicação
A aplicação será desenvolvida em C# ASP .Net Core, o que permitirá a sua implantação em servidores linux e windows ou ainda a criação de um container docker com a aplicação.
