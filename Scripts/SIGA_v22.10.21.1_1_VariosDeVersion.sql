PRINT ''
PRINT '1. Tabla Buscadores: Cuentas de Cajas - Cambio de Ancho'
BEGIN
	UPDATE Buscadores SET AnchoAyuda = 620 WHERE IdBuscador = 206 AND AnchoAyuda = 400
END
GO

PRINT ''
PRINT '2. Campos: Operaciones Vehiculos Usados'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'PatenteVehiculoUsado' AND TABLE_NAME = 'ConcesionarioOperaciones')
BEGIN
    ALTER TABLE dbo.ConcesionarioOperaciones ADD PatenteVehiculoUsado varchar(8) NULL
    ALTER TABLE dbo.ConcesionarioOperaciones ADD PrecioListaUsado decimal(16, 2) NULL
    ALTER TABLE dbo.ConcesionarioOperaciones ADD ImporteUsado decimal(16, 2) NULL
    ALTER TABLE dbo.ConcesionarioOperaciones ADD CodigoOperacion varchar(30) NULL
END
GO

PRINT ''
PRINT '3. Campos: Operaciones Vehiculos Usados'
BEGIN
	UPDATE ConcesionarioOperaciones
	   SET CodigoOperacion  = ''
	 WHERE PrecioListaUsado IS NULL;

	ALTER TABLE dbo.ConcesionarioOperaciones ALTER COLUMN CodigoOperacion varchar(30) NOT NULL
END
GO

PRINT ''
PRINT '4. Campos: Operaciones Vehiculos Usados'
BEGIN
	UPDATE O
	   SET CodigoOperacion  = SUBSTRING(M.NombreMarca, 1, 1) + ' - ' +
							  CONVERT(VARCHAR(MAX), O.AnioOperacion) + ' - ' +
							  CONVERT(VARCHAR(MAX), O.NumeroOperacion) + ' - ' +
							  CONVERT(VARCHAR(MAX), O.SecuenciaOperacion)
	  FROM ConcesionarioOperaciones O
 		INNER JOIN Marcas M ON M.IdMarca = O.IdMarca
	  WHERE O.CodigoOperacion = ''
END
GO
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IdMarcaOperacionIngreso' AND TABLE_NAME = 'Vehiculos')
BEGIN
    ALTER TABLE dbo.Vehiculos ADD IdMarcaOperacionIngreso int NULL
    ALTER TABLE dbo.Vehiculos ADD AnioOperacionIngreso int NULL
    ALTER TABLE dbo.Vehiculos ADD NumeroOperacionIngreso int NULL
    ALTER TABLE dbo.Vehiculos ADD SecuenciaOperacionIngreso int NULL
END
GO
IF OBJECT_ID('dbo.[FK_Vehiculos_ConcesionarioOperaciones]', 'F') IS NULL
BEGIN
    ALTER TABLE dbo.Vehiculos ADD CONSTRAINT FK_Vehiculos_ConcesionarioOperaciones
        FOREIGN KEY (IdMarcaOperacionIngreso, AnioOperacionIngreso, NumeroOperacionIngreso, SecuenciaOperacionIngreso)
        REFERENCES dbo.ConcesionarioOperaciones (IdMarca, AnioOperacion, NumeroOperacion, SecuenciaOperacion)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

PRINT ''
PRINT '1. Tabla FormatoEtiquetas: Agrega formato 1 x Ancho (6 x 6 cm)'

DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;

INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
           ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
           ,[Activo])
     VALUES
           (@maxId, '1 x Ancho (6 x 6 cm) ', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF18.rdlc', 'True'
           ,'', 'False', 1, 'False', 'False','True')
GO

PRINT ''
PRINT '6. Funcion: BalanceSumasSaldosPeriodo'
IF dbo.ExisteFuncion('Contabilidad') = 1 
BEGIN	
	IF dbo.ExisteFuncion('BalanceSumasSaldosPeriodo') = 0
	BEGIN
	   INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
		VALUES
			('BalanceSumasSaldosPeriodo', 'Balance de Sumas y Saldo por año y mes', 'Balance de sumas y saldo por año y mes', 'True', 'False', 'True', 'True'
			,'Contabilidad', 145, 'Eniac.Win', 'ContabilidadBalanceSumasSaldosPeriodo', NULL, NULL
			,'True', 'S', 'N', 'N', 'N','True')

		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT IdRol, 'BalanceSumasSaldosPeriodo' FROM RolesFunciones WHERE IdFuncion = 'ContabilidadListadoBalanceSyS'
	END
END