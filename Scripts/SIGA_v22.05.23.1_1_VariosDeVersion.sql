
		DECLARE @idParametro VARCHAR(MAX) = 'FORMATONOMBREARCHIVOEXPORTACION'
		DECLARE @descripcionParametro VARCHAR(MAX) = 'Define Formato de Nombre de Archivo de Exportacion'
		DECLARE @valorParametro VARCHAR(MAX) = '@@CUITEMPRESA@@_@@COMPROBANTE@@'

		MERGE INTO Parametros AS DEST
				USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
			WHEN MATCHED THEN
				UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
			WHEN NOT MATCHED THEN 
				INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
