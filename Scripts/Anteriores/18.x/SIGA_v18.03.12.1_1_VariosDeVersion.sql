PRINT '1. Productos_ValoresDefault'
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
ALTER TABLE dbo.Productos ADD CONSTRAINT
	DF_Productos_Alto DEFAULT 0 FOR Alto
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	DF_Productos_Ancho DEFAULT 0 FOR Ancho
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	DF_Productos_Largo DEFAULT 0 FOR Largo
GO
ALTER TABLE dbo.Productos ADD CONSTRAINT
	DF_Productos_OrigenPorcImpInt DEFAULT 'BRUTO' FOR OrigenPorcImpInt
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '2. Menu_CobranzasMovil_Sincronizacion'
GO
DELETE FROM Bitacora WHERE IdFuncion = 'SincronizacionSubidaMovil';
DELETE FROM RolesFunciones WHERE IdFuncion = 'SincronizacionSubidaMovil';
DELETE FROM Funciones WHERE Id = 'SincronizacionSubidaMovil';

-- Si tiene el menu de Pedidos y es el CUIT de Generico/Plumas Aloe

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'CobranzasMovil')
BEGIN
      
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('SincronizacionSubidaMovil', 'Sincronización - Subir a la Web', 'Sincronización - Subir a la Web', 'True', 'False', 'True', 'True', 
          'CobranzasMovil', 50, 'Eniac.Win', 'SincronizacionSubidaMovil', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'SincronizacionSubidaMovil' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    ;
END

SELECT * FROM Funciones WHERE IdPadre = 'CobranzasMovil'

PRINT '3. Indice_CuentasCorrientes_IdCliente'
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
CREATE NONCLUSTERED INDEX IX_CuentasCorrientes_IdCliente ON dbo.CuentasCorrientes
    (IdCliente)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.CuentasCorrientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '4. Campo_MovilRutas_IdDispositivoPorDefecto'
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
ALTER TABLE dbo.MovilRutas ADD IdDispositivoPorDefecto varchar(50) NULL
GO
UPDATE MovilRutas SET IdDispositivoPorDefecto = '';
ALTER TABLE dbo.MovilRutas ALTER COLUMN IdDispositivoPorDefecto varchar(50) NOT NULL
GO
ALTER TABLE dbo.MovilRutas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '5. Menu_CobranzasMovil_SincronizacionBajada'
GO
DELETE FROM Bitacora WHERE IdFuncion = 'SincronizacionBajadaCobranzas';
DELETE FROM RolesFunciones WHERE IdFuncion = 'SincronizacionBajadaCobranzas';
DELETE FROM Funciones WHERE Id = 'SincronizacionBajadaCobranzas';

-- Si tiene el menu de Pedidos y es el CUIT de Generico/Plumas Aloe

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'CobranzasMovil')
BEGIN
      
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('SincronizacionBajadaCobranzas', 'Sincronización - Bajar Cobranzas', 'Sincronización - Bajar Cobranzas', 'True', 'False', 'True', 'True', 
          'CobranzasMovil', 60, 'Eniac.Win', 'SincronizacionBajadaCobranzas', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'SincronizacionBajadaCobranzas' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    ;
END

SELECT * FROM Funciones WHERE IdPadre = 'CobranzasMovil'

PRINT '6. Campo_Cobradores_IdDispositivo'
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
ALTER TABLE dbo.Cobradores ADD IdDispositivo varchar(50) NULL
GO
ALTER TABLE dbo.Cobradores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '7. Tabla_CobradoresSucursales'
GO
/****** Object:  Table [dbo].[CobradoresSucursales]    Script Date: 03/07/2018 11:39:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CobradoresSucursales](
	[IdSucursal] [int] NOT NULL,
	[IdCobrador] [int] NOT NULL,
	[IdCaja] [int] NULL,
 CONSTRAINT [PK_CobradoresSucursales] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdCobrador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CobradoresSucursales]  WITH CHECK ADD  CONSTRAINT [FK_CobradoresSucursales_CajasNombres] FOREIGN KEY([IdSucursal], [IdCaja])
REFERENCES [dbo].[CajasNombres] ([IdSucursal], [IdCaja])
GO

ALTER TABLE [dbo].[CobradoresSucursales] CHECK CONSTRAINT [FK_CobradoresSucursales_CajasNombres]
GO

ALTER TABLE [dbo].[CobradoresSucursales]  WITH CHECK ADD  CONSTRAINT [FK_CobradoresSucursales_Cobradores] FOREIGN KEY([IdCobrador])
REFERENCES [dbo].[Cobradores] ([IdCobrador])
GO

ALTER TABLE [dbo].[CobradoresSucursales] CHECK CONSTRAINT [FK_CobradoresSucursales_Cobradores]
GO

ALTER TABLE [dbo].[CobradoresSucursales]  WITH CHECK ADD  CONSTRAINT [FK_CobradoresSucursales_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[CobradoresSucursales] CHECK CONSTRAINT [FK_CobradoresSucursales_Sucursales]
GO


PRINT '8. Campos_Calendarios_LapsoPorDefecto'
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
ALTER TABLE dbo.Calendarios ADD LapsoPorDefecto int NULL
ALTER TABLE dbo.Calendarios ADD LapsoPorDefectoFijo bit NULL
GO
UPDATE Calendarios
   SET LapsoPorDefecto = 30
     , LapsoPorDefectoFijo = 1;
ALTER TABLE dbo.Calendarios ALTER COLUMN LapsoPorDefecto int NOT NULL
ALTER TABLE dbo.Calendarios ALTER COLUMN LapsoPorDefectoFijo bit NOT NULL
GO
ALTER TABLE dbo.Calendarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
