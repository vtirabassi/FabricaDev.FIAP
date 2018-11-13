CREATE TABLE [dbo].[Marca]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Nome] VARCHAR(50) NOT NULL, 
    [DataCriacao] DATETIME NOT NULL, 
    [Cnpj] VARCHAR(50) NOT NULL

)
