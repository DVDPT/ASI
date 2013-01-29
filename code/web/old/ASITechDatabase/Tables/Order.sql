CREATE TABLE [dbo].[Order]
(
	[Product] INT NOT NULL , 
    [Client] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [OrderDate] DATETIME NOT NULL, 
    PRIMARY KEY ([Product], [Client]), 
    CONSTRAINT [FK_Order_Product] FOREIGN KEY ([Product]) REFERENCES [Product]([Code]), 
    CONSTRAINT [FK_Order_Client] FOREIGN KEY ([Client]) REFERENCES [Client]([Id])
)
