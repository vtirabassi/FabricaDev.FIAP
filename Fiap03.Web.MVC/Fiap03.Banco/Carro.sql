CREATE TABLE [dbo].[Carro]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Marca] VARCHAR(50) NOT NULL, 
    [Ano] INT NULL, 
    [Esportivo] BIT NULL, 
    [Placa] VARCHAR(10) NOT NULL, 
    [Descricao] VARCHAR(50) NULL, 
    [Combustivel] INT NULL,
)
