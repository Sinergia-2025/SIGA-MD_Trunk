
PRINT ''
PRINT '1. Pantalla nueva de Turnos'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Turnos')
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'TurnosABM')
            BEGIN
                --Inserto la pantalla nueva
                INSERT INTO Funciones
                     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
                  VALUES
                     ('TurnosABM', 'Turnos', 'Turnos', 'True', 'False', 'True', 'True',
                      'Turnos', 20, 'Eniac.Win', 'TurnosABM', NULL);

                INSERT INTO RolesFunciones 
                      (IdRol,IdFuncion)
                SELECT DISTINCT Id AS Rol, 'TurnosABM' AS Pantalla FROM dbo.Roles
                    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            END;
    END;
GO

PRINT ''
PRINT '2. Tablas de Turnos'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TiposTurnos](
	[IdTipoTurno] [varchar](10) NOT NULL,
	[NombreTipoTurno] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoTurno] PRIMARY KEY CLUSTERED 
(
	[IdTipoTurno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT TiposTurnos ([IdTipoTurno], [NombreTipoTurno]) VALUES ('N', 'Normal');

CREATE TABLE [dbo].[TurnosCalendarios](
	[IdTurno] [int] NOT NULL,
	[IdCalendario] [int] NOT NULL,
	[FechaDesde] [datetime] NOT NULL,
	[FechaHasta] [datetime] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[Observaciones] [varchar](100) NOT NULL,
	[EsEfectivo] [bit] NOT NULL,
	[IdTipoTurno] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TurnosCalendarios] PRIMARY KEY CLUSTERED 
(
	[IdTurno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TurnosCalendarios]  WITH CHECK ADD  CONSTRAINT [FK_TurnosCalendarios_Calendarios] FOREIGN KEY([IdCalendario])
REFERENCES [dbo].[Calendarios] ([IdCalendario])
GO

ALTER TABLE [dbo].[TurnosCalendarios] CHECK CONSTRAINT [FK_TurnosCalendarios_Calendarios]
GO

ALTER TABLE [dbo].[TurnosCalendarios]  WITH CHECK ADD  CONSTRAINT [FK_TurnosCalendarios_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[TurnosCalendarios] CHECK CONSTRAINT [FK_TurnosCalendarios_Clientes]
GO

ALTER TABLE [dbo].[TurnosCalendarios]  WITH CHECK ADD  CONSTRAINT [FK_TurnosCalendarios_TiposTurnos] FOREIGN KEY([IdTipoTurno])
REFERENCES [dbo].[TiposTurnos] ([IdTipoTurno])
GO

ALTER TABLE [dbo].[TurnosCalendarios] CHECK CONSTRAINT [FK_TurnosCalendarios_TiposTurnos]
GO


PRINT ''
PRINT '3. Nuevo Menu: ABM de Tipos de Turnos'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Turnos')
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'TiposTurnosABM')
            BEGIN
                --Inserto la pantalla nueva
                INSERT INTO Funciones
                     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
                  VALUES
                     ('TiposTurnosABM', 'Tipos de Turnos', 'Tipos de Turnos', 'True', 'False', 'True', 'True',
                      'Turnos', 200, 'Eniac.Win', 'TiposTurnosABM', NULL);

                INSERT INTO RolesFunciones 
                      (IdRol,IdFuncion)
                SELECT DISTINCT Id AS Rol, 'TiposTurnosABM' AS Pantalla FROM dbo.Roles
                    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            END;
    END;
GO


PRINT ''
PRINT '4. Nuevo Menu: ABM de Feriados'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Archivos')
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'FeriadosABM')
            BEGIN
                --Inserto la pantalla nueva
                INSERT INTO Funciones
                     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
                  VALUES
                     ('FeriadosABM', 'Feriados', 'Feriados', 'True', 'False', 'True', 'True',
                      'Archivos', 47, 'Eniac.Win', 'FeriadosABM', NULL);

                INSERT INTO RolesFunciones 
                      (IdRol,IdFuncion)
                SELECT DISTINCT Id AS Rol, 'FeriadosABM' AS Pantalla FROM dbo.Roles
                    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            END;
    END;
GO


PRINT ''
PRINT '5. Nueva Tabla: Feriados // Agrego Feriados 2018.'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feriados](
	[FechaFeriado] [date] NOT NULL,
	[NombreFeriado] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Feriados] PRIMARY KEY CLUSTERED 
(
	[FechaFeriado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180101', 'A�o Nuevo')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180212', 'Carnaval')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180213', 'Carnaval')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180324', 'D�a Nacional de la Memoria por la Verdad y la Justicia')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180330', 'Viernes Santo')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180402', 'D�a del Veterano y de los Ca�dos en la Guerra de Malvinas')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180501', 'D�a del trabajador')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180525', 'D�a de la Revoluci�n de Mayo')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180617', 'D�a Paso a la Inmortalidad del General Mart�n Miguel de G�emes')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180620', 'D�a Paso a la Inmortalidad del General Manuel Belgrano')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180709', 'D�a de la Independencia')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20180820', 'Paso a la Inmortalidad del Gral. Jos� de San Mart�n (17/8)')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20181015', 'D�a del Respeto a la Diversidad Cultural (12/10)')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20181119', 'D�a de la Soberan�a Nacional (20/11)')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20181224', 'D�a no laboral con fines tur�sticos')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20181225', 'Navidad')
INSERT INTO Feriados (FechaFeriado, NombreFeriado) VALUES ('20181231', 'D�a no laboral con fines tur�sticos')

SET ANSI_PADDING OFF
GO



PRINT ''
PRINT '6. TiposComprobantes: Seteos Resumenes como EsComercial=SI.'
GO

UPDATE TiposComprobantes
   SET EsComercial = 'True'
 WHERE IdTipoComprobante IN ('RES-BANCARIO', 'RES-TARJETA')
GO
