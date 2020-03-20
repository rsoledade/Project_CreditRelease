SELECT
	TOP(4)
	Cli.Nome, Cli.UF, Cli.Celular, Par.DataVencimento,
	Fin.TipoFinanciamento, Fin.ValorTotal, Fin.QuantidadeParcelas,
	Par.NumeroParcela, Par.ValorParcela, Par.DataPagamento
FROM
	Clientes Cli
	INNER JOIN Financiamentos Fin ON Cli.Id = Fin.IdCliente
	INNER JOIN Parcelas        Par ON Fin.Id = Par.IdFinanciamento
WHERE
	Par.DataPagamento IS NULL
	AND Par.DataVencimento > GETDATE()
ORDER BY Par.DataVencimento






