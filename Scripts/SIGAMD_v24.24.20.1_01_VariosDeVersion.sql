PRINT ''
PRINT 'Nuevo Buscador: CRMMetodosResolucionesNovedad'

DECLARE @idBuscador INT = 23
DECLARE @alineacion_der INT = 64
DECLARE @alineacion_izq INT = 16

-- MERGE para la tabla Buscadores
MERGE INTO [dbo].[Buscadores] AS D
USING (SELECT @idBuscador AS IdBuscador, 
              'CRMMetodosResolucionesNovedad' AS Titulo, 
              1000 AS AnchoAyuda, 
              'Grilla' AS IniciaConFocoEn, 
              '' AS ColumaBusquedaInicial) AS O 
ON D.IdBuscador = O.IdBuscador
WHEN MATCHED THEN
    UPDATE SET D.Titulo = O.Titulo,
               D.AnchoAyuda = O.AnchoAyuda,
               D.IniciaConFocoEn = O.IniciaConFocoEn,
               D.ColumaBusquedaInicial = O.ColumaBusquedaInicial
WHEN NOT MATCHED THEN 
    INSERT (IdBuscador, Titulo, AnchoAyuda, IniciaConFocoEn, ColumaBusquedaInicial) 
    VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial);

-- MERGE para la tabla BuscadoresCampos
MERGE INTO [dbo].[BuscadoresCampos] AS D
USING (
       SELECT @idBuscador AS IdBuscador, 
              'IdMetodoResolucionNovedad' AS IdBuscadorNombreCampo, 
              1 AS Orden, 
              'Código' AS Titulo, 
              @alineacion_der AS Alineacion, 
              70 AS Ancho, 
              '' AS Formato, 
              NULL AS Condicion, 
              NULL AS Valor, 
              NULL AS ColorFila 
       UNION ALL
       SELECT @idBuscador AS IdBuscador, 
              'NombreMetodoResolucionNovedad' AS IdBuscadorNombreCampo, 
              2 AS Orden, 
              'Nombre' AS Titulo, 
              @alineacion_izq AS Alineacion, 
              200 AS Ancho, 
              '' AS Formato, 
              NULL AS Condicion, 
              NULL AS Valor, 
              NULL AS ColorFila 
) AS O 
ON D.IdBuscador = O.IdBuscador 
   AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
WHEN MATCHED THEN
    UPDATE SET D.Orden = O.Orden,
               D.Titulo = O.Titulo,
               D.Alineacion = O.Alineacion,
               D.Ancho = O.Ancho,
               D.Formato = O.Formato,
               D.Condicion = O.Condicion,
               D.Valor = O.Valor,
               D.ColorFila = O.ColorFila
WHEN NOT MATCHED THEN 
    INSERT (IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato, Condicion, Valor, ColorFila) 
    VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila);

ALTER TABLE Ventas ALTER COLUMN SaldoActualCtaCte decimal(16,2) NULL
ALTER TABLE Ventas ALTER COLUMN SaldoActualCtaCteUnificado decimal(16,2) NULL

ALTER TABLE CuentasCorrientes ALTER COLUMN Saldo decimal(16,2) NULL
ALTER TABLE CuentasCorrientes ALTER COLUMN SaldoCtaCte decimal(16,2) NULL

ALTER TABLE CuentasCorrientesProv ALTER COLUMN Saldo decimal(16,2) NULL
ALTER TABLE CuentasCorrientesProv ALTER COLUMN SaldoCtaCte decimal(16,2) NULL

PRINT ''
PRINT '1. Nuevo campo Idsucursal Tabla ArchivosImportados'
IF dbo.ExisteCampo('ArchivosImportados', 'IdSucursal') = 0
BEGIN
	ALTER TABLE ArchivosImportados ADD IdSucursal int NULL

	-- Delete the primary key constraint.  
	ALTER TABLE ArchivosImportados DROP CONSTRAINT PK_ArchivosImportados;   

	ALTER TABLE ArchivosImportados  WITH CHECK ADD  CONSTRAINT FK_ArchivosImportados_Sucursales 
		FOREIGN KEY(IdSucursal) REFERENCES Sucursales (IdSucursal)

END
GO

PRINT ''
PRINT '2. Nuevo campo Idsucursal Tabla ArchivosImportados'
IF dbo.ExisteCampo('ArchivosImportados', 'IdSucursal') = 1
BEGIN
	UPDATE ArchivosImportados SET IdSucursal = (SELECT SUC.IdSucursal FROM Sucursales SUC WHERE EstoyAca = 1 AND SoyLaCentral = 1) 

	ALTER TABLE ArchivosImportados ALTER COLUMN IdSucursal int NOT NULL
END
GO

PRINT ''
PRINT '3. Nuevo campo Idsucursal Tabla ArchivosImportados'
IF dbo.ExisteCampo('ArchivosImportados', 'IdSucursal') = 1
BEGIN
	ALTER TABLE ArchivosImportados ADD CONSTRAINT PK_ArchivosImportados 
	PRIMARY KEY CLUSTERED (IdFuncion, IdSubFuncion, NombreArchivo, IdSucursal);
END
GO

PRINT ''
PRINT '1. Nuevo Parametro Pedidos: Visualiza columna de ImporteIva desde Presupuestos-Pedidos'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOSMOSTRARPRECIOMASIVA'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Visualizar columna de ImporteIVA desde Presupuestos-Pedidos'
	DECLARE @valorParametro VARCHAR(MAX) = 'False'
	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO