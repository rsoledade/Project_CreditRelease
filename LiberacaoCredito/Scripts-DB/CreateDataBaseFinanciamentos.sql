CREATE DATABASE Financiamento
GO

USE Financiamento
GO

CREATE TABLE Clientes
(
	Id		Int Identity(1,1) Primary Key,
	Nome	Varchar(250) NOT NULL,
	UF		Nvarchar(2)  NOT NULL,
	Celular Nvarchar(20) NOT NULL
);

CREATE TABLE Financiamentos
(
	Id					INT Identity(1,1) Primary Key,
	IdCliente			INT      NOT NULL,
	TipoFinanciamento   NVARCHAR(50)  NOT NULL,
	ValorTotal          MONEY    NOT NULL,
	DataVencimento		DATETIME NOT NULL,
	QuantidadeParcelas  INT      NOT NULL
);

CREATE TABLE Parcelas
(
	Id					Int Identity(1,1) Primary Key,
	IdFinanciamento     Int		 NOT NULL,
	NumeroParcela		TinyInt  NOT NULL,
	ValorParcela		MONEY    NOT NULL,
	DataVencimento		DATETIME NOT NULL,
	DataPagamento		DATETIME NOT NULL
);