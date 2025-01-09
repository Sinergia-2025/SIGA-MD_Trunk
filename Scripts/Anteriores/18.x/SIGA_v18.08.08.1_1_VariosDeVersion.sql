
PRINT ''
PRINT '1. Configuro FTP y Parametros para sincronizar imagenes.'
GO

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('27346831052'))
	BEGIN
		MERGE INTO Parametros AS P
			 USING (SELECT 'WEBARCHIVOSPRODUCTOSPUBLICARENWEB'   AS IdParametro, 'SI' ValorParametro,   'Publicar en Web'  AS DescripcionParametro UNION
					SELECT 'WEBARCHIVOSPRODUCTOSINCLUIRIMAGENES' AS IdParametro, 'True' ValorParametro, 'Incluir Imagenes' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
		 WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
		 WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

		MERGE INTO Parametros AS P
			 USING (SELECT 'FTPSERVIDOR' AS IdParametro, 'www.distribuidoramatienzo.com' ValorParametro , 'Servidor' AS DescripcionParametro UNION
					SELECT 'FTPUSUARIO' AS IdParametro, 'siga@distribuidoramatienzo.com' ValorParametro , 'Usuario' AS DescripcionParametro UNION
					SELECT 'FTPPASSWORD' AS IdParametro, 'Ramstein2018' ValorParametro , 'Password' AS DescripcionParametro UNION
					SELECT 'FTPCONEXIONPASIVA' AS IdParametro, 'True' ValorParametro , 'Conexión Pasiva' AS DescripcionParametro UNION
					SELECT 'FTPNOMBREARCHIVO' AS IdParametro, '' ValorParametro , 'Nombre Archivo' AS DescripcionParametro UNION
					SELECT 'FTPCARPETAREMOTA' AS IdParametro, '/' ValorParametro , 'Carpeta Remota FTP' AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
		 WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
		 WHEN NOT MATCHED THEN INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);
	END;

--SELECT * FROM Parametros WHERE IdParametro IN ('WEBARCHIVOSPRODUCTOSPUBLICARENWEB', 'WEBARCHIVOSPRODUCTOSINCLUIRIMAGENES',
--                                               'FTPServidor','FTPUsuario','FTPPassword','FTPNombreArchivo','FTPConexionPasiva','FTPCarpetaRemota' )

PRINT ''
PRINT '2. Tabla Proveedores: Agregar columna FechaIndemnidad (p/SICAP).'
GO

ALTER TABLE Proveedores ADD FechaIndemnidad datetime null
GO


PRINT ''
PRINT '3. Tabla Parametros: Inserta configuración de Uso Contratistas.'
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('MODULOCONTRATISTAS', 'False', null, 'Utiliza el Modulo de Contratistas')
GO


PRINT ''
PRINT '4. Tabla TiposComprobantes: Borro Columna UtilizaImpuestosCargaPrecioCompra (Si Existe).'
GO

IF EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'TiposComprobantes'
              AND COLUMN_NAME = 'UtilizaImpuestosCargaPrecioCompra') 

	ALTER TABLE TiposComprobantes DROP COLUMN UtilizaImpuestosCargaPrecioCompra;
