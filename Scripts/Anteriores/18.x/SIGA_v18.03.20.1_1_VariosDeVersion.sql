
PRINT '1. Tabla Compras: Agrego Campos IVAModificadoManual de distintos %.'
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
ALTER TABLE dbo.Compras ADD IVA105Calculado decimal(12, 2) NULL
ALTER TABLE dbo.Compras ADD IVA210Calculado decimal(12, 2) NULL
ALTER TABLE dbo.Compras ADD IVA270Calculado decimal(12, 2) NULL
ALTER TABLE dbo.Compras ADD IVAModificadoManual bit NULL
GO
UPDATE Compras
   SET IVA105Calculado = IVA105
     , IVA210Calculado = IVA210
     , IVA270Calculado = IVA270
     , IVAModificadoManual = 0;
ALTER TABLE dbo.Compras ALTER COLUMN IVA105Calculado decimal(12, 2) NOT NULL
ALTER TABLE dbo.Compras ALTER COLUMN IVA210Calculado decimal(12, 2) NOT NULL
ALTER TABLE dbo.Compras ALTER COLUMN IVA270Calculado decimal(12, 2) NOT NULL
ALTER TABLE dbo.Compras ALTER COLUMN IVAModificadoManual bit NOT NULL
GO
ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Informe de Vebntas: Permisos (Seguridad) para Totales y Toolbar'
GO
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
         ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('InfDeVts-Totales+Toolbar', 'Muestra Totales y Toolbar', 'Muestra Totales y Toolbar', 'False', 'False', 'False', 'False',
          'InformeDeVentas', 10, 'Eniac.Win', 'InfDeVts-Totales+Toolbar', NULL, NULL);

    IF EXISTS(SELECT ValorParametro FROM Parametros WHERE IdParametro = 'CUITEMPRESA' AND ValorParametro = '27938999150')
        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'InfDeVts-Totales+Toolbar' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm','Supervisor');
    ELSE
        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'InfDeVts-Totales+Toolbar' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm','Supervisor','Oficina');
