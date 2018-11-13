CREATE TABLE [dbo].[Carro]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MarcaId] INT NOT NULL, 
    [Ano] INT NULL, 
    [Esportivo] BIT NULL, 
    [Placa] VARCHAR(10) NOT NULL, 
    [Descricao] VARCHAR(50) NULL, 
    [Combustivel] INT NULL, 
    [Renavam] INT NOT NULL, 
    CONSTRAINT [FK_Carro_Documento] FOREIGN KEY (Renavam) REFERENCES Documento(Renavam), 
    CONSTRAINT [FK_Carro_Marca] FOREIGN KEY (MarcaId) REFERENCES Marca(Id),
)
