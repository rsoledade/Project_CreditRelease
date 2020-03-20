USE [Financiamento]
GO

INSERT INTO [dbo].[Financiamentos]
           ([IdCliente]
           ,[TipoFinanciamento]
           ,[ValorTotal]
           ,[DataVencimento])
     VALUES
           (1
           ,'Carro'
           ,25000
           ,GETDATE()-4),
		   (2
           ,'Imóvel'
           ,120000
           ,GETDATE()-9),
		   (3
           ,'Carro'
           ,65000
           ,GETDATE()-12),
		   (1
           ,'Carro'
           ,65000
           ,GETDATE()-12)
GO


