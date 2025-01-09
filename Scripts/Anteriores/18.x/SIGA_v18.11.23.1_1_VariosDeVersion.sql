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
ALTER TABLE dbo.TiposComprobantes ADD CargaDescRecGralActual bit NULL
GO
UPDATE TiposComprobantes SET CargaDescRecGralActual = CargaDescRecActual;
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                  AND P.ValorParametro IN ('33714918449'))

BEGIN
    UPDATE TiposComprobantes SET CargaDescRecGralActual = 1 WHERE IdTipoComprobante = 'ePRE-FACT';
END
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN CargaDescRecGralActual bit NOT NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


--Insertar Menu

INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
         PermiteMultiplesInstancias,Plus,Express,Basica,PV)
  VALUES
        ('Facturacion-OBLIGA-Invocar', 'Facturacion - Obliga Invocar', 'Facturacion - Obliga Invocar', 'False', 'False', 'True', 'True', 
        'FacturacionV2', 999, '', '', NULL, NULL,
        'True', 'S', 'N', 'N', 'N')
GO

--INSERT INTO RolesFunciones (IdRol, IdFuncion)
--SELECT DISTINCT Id AS Rol, 'Facturacion-OBLIGA-Invocar' AS Pantalla FROM Roles
--    WHERE Id IN ('Adm', 'Supervisor') 
--GO
