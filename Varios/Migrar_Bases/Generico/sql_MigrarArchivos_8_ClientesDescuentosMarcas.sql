
INSERT [ClientesDescuentosMarcas]
           ([IdMarca]
           ,[DescuentoRecargoPorc1]
           ,[DescuentoRecargoPorc2]
           ,[IdCliente])
SELECT [IdMarca]
      ,[DescuentoRecargoPorc1]
      ,[DescuentoRecargoPorc2]
      ,[NroDocumento] AS IdCliente
  FROM [MO_SIGA].[dbo].[ClientesDescuentosMarcas]
GO
