
PRINT '1. Nueva Tabla: MovilRutas.'
GO

/****** Object:  Table [dbo].[MovilRutas]    Script Date: 02/23/2018 17:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MovilRutas](
	[IdRuta] [int] NOT NULL,
	[NombreRuta] [varchar](70) NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_Rutas] PRIMARY KEY CLUSTERED 
(
	[IdRuta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


PRINT ''
PRINT '2. Nueva Tabla: MovilRutasClientes.'
GO

/****** Object:  Table [dbo].[MovilRutasClientes]    Script Date: 02/23/2018 17:20:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MovilRutasClientes](
	[IdRuta] [int] NOT NULL,
	[Dia] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
 CONSTRAINT [PK_RutasClientes] PRIMARY KEY CLUSTERED 
(
	[IdRuta] ASC,
	[Dia] ASC,
	[Orden] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MovilRutasClientes]  WITH CHECK ADD  CONSTRAINT [FK_RutasClientes_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[MovilRutasClientes] CHECK CONSTRAINT [FK_RutasClientes_Clientes]
GO

ALTER TABLE [dbo].[MovilRutasClientes]  WITH CHECK ADD  CONSTRAINT [FK_RutasClientes_Rutas] FOREIGN KEY([IdRuta])
REFERENCES [dbo].[MovilRutas] ([IdRuta])
GO

ALTER TABLE [dbo].[MovilRutasClientes] CHECK CONSTRAINT [FK_RutasClientes_Rutas]
GO


PRINT ''
PRINT '3. Borro Pantallas del Movil Anteriores.'
GO

DELETE FROM Bitacora WHERE IdFuncion IN ('MovilRutasABM', 'MovilRutasClientes','CobranzasMovil');
DELETE FROM RolesFunciones WHERE IdFuncion IN ('MovilRutasABM', 'MovilRutasClientes','CobranzasMovil');
DELETE FROM Funciones WHERE Id IN ('MovilRutasABM', 'MovilRutasClientes','CobranzasMovil');


PRINT ''
PRINT '4. Nuevo Menu: Cuentas Corrientes\SiMovil Cobranzas (Empresa Generica).'
GO

IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CobranzasMovil')
   AND EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CuentasCorrientes')
   AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                         AND P.ValorParametro = '50000000024')
    BEGIN
        --Inserto el Menú del Módulo
        INSERT INTO Funciones
           (Id, Nombre, Descripcion
           ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
         VALUES
           ('CobranzasMovil', 'SiMovil Cobranzas', 'SiMovil Cobranzas', 
            'True', 'False', 'True', 'True', 'CuentasCorrientes', 500, 'Eniac.Win', NULL, NULL);
        INSERT INTO RolesFunciones 
                      (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'CobranzasMovil' AS Pantalla FROM dbo.Roles
                WHERE Id IN ('Adm', 'Supervidor', 'Oficina');
    END;


IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CobranzasMovil')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('MovilRutasABM', 'Rutas', 'Rutas', 'True', 'False', 'True', 'True',
              'CobranzasMovil', 10, 'Eniac.Win', 'MovilRutasABM', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'MovilRutasABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('MovilRutasClientes', 'Asignar Clientes a Rutas', 'Rutas', 'True', 'False', 'True', 'True',
              'CobranzasMovil', 20, 'Eniac.Win', 'MovilRutasClientes', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'MovilRutasClientes' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;
