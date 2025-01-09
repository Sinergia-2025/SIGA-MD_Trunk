
PRINT ''
PRINT '1. Tabla AFIPTiposComprobantes: Agregar Campos IdAFIPTipoDocumento y IncluyeFechaVencimiento.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.AFIPTiposComprobantes ADD IdAFIPTipoDocumento int NULL
ALTER TABLE dbo.AFIPTiposComprobantes ADD IncluyeFechaVencimiento bit NULL
GO
ALTER TABLE dbo.AFIPTiposComprobantes ADD CONSTRAINT FK_AFIPTiposComprobantes_AFIPTiposDocumentos
    FOREIGN KEY (IdAFIPTipoDocumento)
    REFERENCES dbo.AFIPTiposDocumentos (IdAFIPTipoDocumento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.AFIPTiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Nueva Pantalla: AFIP\Tablas AFIP.'
GO

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
 VALUES
   ('AFIPTablasAfip', 'Tablas AFIP', 'Tablas AFIP', 
    'True', 'False', 'True', 'True', 'AFIP', 900, 'Eniac.Win', NULL, NULL, NULL)
;

INSERT INTO RolesFunciones 
				(IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AFIPTablasAfip' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor') 
;


PRINT ''
PRINT '3. Nueva Pantalla: AFIP\Tipos de Comprobantes AFIP.'
GO

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
 VALUES
   ('AFIPTiposComprobantesABM', 'Tipos de Comprobantes AFIP', 'Tipos de Comprobantes AFIP', 
    'True', 'False', 'True', 'True', 'AFIPTablasAfip', 10, 'Eniac.Win', 'AFIPTiposComprobantesABM', NULL, NULL)
;

INSERT INTO RolesFunciones 
				(IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AFIPTiposComprobantesABM' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor') 
;


PRINT ''
PRINT '4. Nueva Parametro: EXPORTARPRECIOSCONIVA - Exportar los Precios de productos Con IVA.'
GO

DECLARE @Valor VARCHAR(MAX)
SELECT @Valor = CASE WHEN ValorParametro = 'NO' THEN 'False' ELSE 'True' END FROM Parametros WHERE IdParametro = 'PRECIOCONIVA';

--INDUFER
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30708742550'))
BEGIN
    SET @Valor = 'True';
END

MERGE INTO Parametros AS P
        USING (SELECT 'EXPORTARPRECIOSCONIVA' AS IdParametro, @Valor ValorParametro, 'Exportar los Precios de productos Con IVA'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

--SELECT * FROM Parametros WHERE IdParametro IN ('EXPORTARPRECIOSCONIVA', 'PRECIOCONIVA');
