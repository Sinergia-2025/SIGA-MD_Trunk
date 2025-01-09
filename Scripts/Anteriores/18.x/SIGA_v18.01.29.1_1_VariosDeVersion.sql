
PRINT ''
PRINT '1. Tabla CajasNombres: Agrego campos IdTipoComprobanteF3/4 y FKs.'
GO

ALTER TABLE CajasNombres ADD IdTipoComprobanteF3 varchar(15) null
GO

ALTER TABLE CajasNombres ADD IdTipoComprobanteF4 varchar(15) null
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
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CajasNombres ADD CONSTRAINT
	FK_CajasNombres_TiposComprobantes FOREIGN KEY
	(
	IdTipoComprobanteF3
	) REFERENCES dbo.TiposComprobantes
	(
	IdTipoComprobante
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CajasNombres ADD CONSTRAINT
	FK_CajasNombres_TiposComprobantes2 FOREIGN KEY
	(
	IdTipoComprobanteF4
	) REFERENCES dbo.TiposComprobantes
	(
	IdTipoComprobante
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CajasNombres SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '2. Tablas Nuevas: Calendarios y CalendariosHorarios.'
GO

/****** Object:  Table [dbo].[Calendarios]    Script Date: 01/24/2018 17:34:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Calendarios](
	[IdCalendario] [int] NOT NULL,
	[NombreCalendario] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdSucursal] [int] NULL,
 CONSTRAINT [PK_Calendarios] PRIMARY KEY CLUSTERED 
(
	[IdCalendario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[CalendariosHorarios](
	[IdCalendario] [int] NOT NULL,
	[IdDiaSemana] [int] NOT NULL,
	[IdHorario] [int] NOT NULL,
	[HoraDesde] [varchar](50) NOT NULL,
	[HoraHasta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CalendariosHorarios] PRIMARY KEY CLUSTERED 
(
	[IdCalendario] ASC,
	[IdDiaSemana] ASC,
	[IdHorario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Calendarios]  WITH CHECK ADD  CONSTRAINT [FK_Calendarios_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[Calendarios] CHECK CONSTRAINT [FK_Calendarios_Sucursales]
GO
ALTER TABLE [dbo].[CalendariosHorarios]  WITH CHECK ADD  CONSTRAINT [FK_CalendariosHorarios_Calendarios] FOREIGN KEY([IdCalendario])
REFERENCES [dbo].[Calendarios] ([IdCalendario])
GO
ALTER TABLE [dbo].[CalendariosHorarios] CHECK CONSTRAINT [FK_CalendariosHorarios_Calendarios]
GO


PRINT ''
PRINT '3. Menu Nuevo: Turnos.'
GO

IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Turnos')
   AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                         AND P.ValorParametro = '50000000024')
    BEGIN
        --Inserto el Menú del Módulo
        INSERT INTO Funciones
           (Id, Nombre, Descripcion
           ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
         VALUES
           ('Turnos', 'Turnos', '', 
            'True', 'False', 'True', 'True', NULL, 60, 'Eniac.Win', NULL, NULL);
        INSERT INTO RolesFunciones 
                      (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'Turnos' AS Pantalla FROM dbo.Roles
                WHERE Id IN ('Adm', 'Supervidor', 'Oficina');
    END;


PRINT ''
PRINT '4. Menu Nuevo: Turnos\CalendariosABM.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Turnos')
   AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                         AND P.ValorParametro = '50000000024')
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CalendariosABM')
            BEGIN
                --Inserto la pantalla nueva
                INSERT INTO Funciones
                     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
                  VALUES
                     ('CalendariosABM', 'Calendarios', 'Calendarios', 'True', 'False', 'True', 'True',
                      'Turnos', 10, 'Eniac.Win', 'CalendariosABM', NULL);

                INSERT INTO RolesFunciones 
                      (IdRol,IdFuncion)
                SELECT DISTINCT Id AS Rol, 'CalendariosABM' AS Pantalla FROM dbo.Roles
                    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            END;
    END;
