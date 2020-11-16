# CustomerWebApiDDD
Projeto de implantação de uma aplicação .NET Core WebApi REST utilizando DDD, SOLID, NUnit, Swagger 

# Script para criação de banco de dados

```
CREATE TABLE Customer(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(30) NOT NULL,
Cpf VARCHAR(11) NOT NULL,
Birth DATETIME NOT NULL
);

CREATE TABLE Address(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Street VARCHAR(50) NOT NULL,
Neighborhood VARCHAR(40) NOT NULL,
City VARCHAR(30) NOT NULL,
State VARCHAR(30) NOT NULL,
);
```

<b>Default server: </b> MSSQLLocalDB<br>
<b>Default DB: </b> Customer<br>

<i>Para alterar a conexão é só acessar a classe: <b>CustomerWebApiDDD.Infrastruture.Repository.DBConnection.Connection</b>  </i>
