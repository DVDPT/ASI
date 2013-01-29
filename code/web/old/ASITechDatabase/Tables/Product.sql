CREATE TABLE [dbo].[Product]
(
	[Code] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [StockQuantity] BIGINT NOT NULL DEFAULT 0, 
    [Supplier] INT NOT NULL, 
    CONSTRAINT [FK_Product_Supplier] FOREIGN KEY ([Supplier]) REFERENCES [Supplier]([Id])
)
