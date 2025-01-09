
PRINT ''
PRINT '1. Tabla CRMCategoriasNovedades: Agrego campo PublicarEnWeb.'
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
ALTER TABLE dbo.CRMCategoriasNovedades ADD PublicarEnWeb bit NULL
GO
UPDATE CRMCategoriasNovedades SET PublicarEnWeb = 1;
ALTER TABLE dbo.CRMCategoriasNovedades ALTER COLUMN PublicarEnWeb bit NOT NULL
GO
ALTER TABLE dbo.CRMCategoriasNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tabla Funciones: Agrego Menu AnularModifEliminar\Copiar Factura a Nota de Credito.'
GO
INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
	('CopiarFacturaNCred', 'Copiar Factura a Nota de Credito', 'Copiar Factura a Nota de Credito', 'True', 'False', 'True', 'True', 
    'VentasAnulModifElim', 90, 'Eniac.Win', 'CopiarComprobantes', null, 'COPIA-FACT-NCRED',
    'True', 'S', 'N', 'N', 'N');
INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT IdRol, 'CopiarFacturaNCred' FROM RolesFunciones WHERE IdFuncion = 'CopiarComprobantes'
GO
