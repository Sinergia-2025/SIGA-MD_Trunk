
PRINT ''
PRINT '1. Nueva Tabla: CalendariosExcepciones'
GO

/****** Object:  Table [dbo].[CalendariosExcepciones]    Script Date: 05/29/2018 16:30:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalendariosExcepciones](
	[IdCalendario] [int] NOT NULL,
	[IdExcepcion] [int] NOT NULL,
	[IdDiaSemana] [int] NOT NULL,
	[FechaExcepcion] [date] NULL,
 CONSTRAINT [PK_CalendariosExcepciones] PRIMARY KEY CLUSTERED 
(
	[IdCalendario] ASC,
	[IdExcepcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CalendariosExcepciones]  WITH CHECK ADD  CONSTRAINT [FK_CalendariosExcepciones_Calendarios] FOREIGN KEY([IdCalendario])
REFERENCES [dbo].[Calendarios] ([IdCalendario])
GO

ALTER TABLE [dbo].[CalendariosExcepciones] CHECK CONSTRAINT [FK_CalendariosExcepciones_Calendarios]
GO


PRINT ''
PRINT '2. Nueva Menu: Turnos\Excepciones de Calendarios.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Turnos')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('CalendariosExcepciones', 'Excepciones de Calendarios', 'Excepciones de Calendarios', 'True', 'False', 'True', 'True',
              'Turnos', 15, 'Eniac.Win', 'CalendariosExcepciones', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'CalendariosExcepciones' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
    END;

