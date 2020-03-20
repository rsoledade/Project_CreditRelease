USE [Financiamento]
GO

INSERT INTO [dbo].[Parcelas]
           ([IdFinanciamento]
           ,[NumeroParcela]
           ,[ValorParcela]
           ,[DataVencimento]
           ,[DataPagamento])
     VALUES
           (1
           ,12
           ,650
           ,GETDATE()+1
           ,GETDATE()-9),
		   (2
           ,23
           ,1200
           ,GETDATE()-4
           ,GETDATE()-6),
		   (3
           ,42
           ,750
           ,GETDATE()-4
           ,GETDATE()-6),
		   (4
           ,4
           ,890
           ,GETDATE()-2
           ,GETDATE()-8)
GO


