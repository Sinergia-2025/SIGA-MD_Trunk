PRINT ''
PRINT '1. Nuevo Menu: InfVentasCobranzasMensuales'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
VALUES
    ('InfVentasCobranzasMensuales', 'Inf. Ventas y Cobranzas Mensuales', 'Inf. Ventas y Cobranzas Mensuales', 'True', 'False', 'True', 'True'
    ,'Ventas', 213, 'Eniac.Win', 'InfVentasCobranzasMensuales', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N', 'True')
   
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfVentasCobranzasMensuales' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

PRINT ''
PRINT '2. Nuevo Menu: InfComprasPagosMensuales'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
VALUES
    ('InfComprasPagosMensuales', 'Inf. Compras y Pagos Mensuales', 'Inf. Compras y Pagos Mensuales', 'True', 'False', 'True', 'True'
    ,'Compras', 33, 'Eniac.Win', 'InfComprasPagosMensuales', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N', 'True')
   
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfComprasPagosMensuales' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

PRINT ''
PRINT '3. Nueva Tabla: SituacionCupones'
CREATE TABLE [dbo].[SituacionCupones](
    IdSituacionCupon int NOT NULL,
    NombreSituacionCupon varchar (50) NOT NULL,
    PorDefecto bit NOT NULL,
 CONSTRAINT PK_SituacionCupones PRIMARY KEY CLUSTERED (IdSituacionCupon ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '4. Nueva Menu: SituacionCuponesABM'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
VALUES
    ('SituacionCuponesABM', 'ABM Situación de Cupones', 'ABM Situación de Cupones', 'True', 'False', 'True', 'True'
    ,'Caja', 155, 'Eniac.Win', 'SituacionCuponesABM', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N', 'True')
   
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SituacionCuponesABM' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

INSERT INTO [dbo].[SituacionCupones]
            ([IdSituacionCupon], [NombreSituacionCupon], [PorDefecto])
    VALUES (1, 'NORMAL', 'True')
GO

PRINT ''
PRINT '5. Cambios Tabla: Calles'
ALTER TABLE [dbo].[Calles]   DROP CONSTRAINT [FK_Calles_Localidades]
IF (OBJECT_ID('dbo.FK_Clientes_Calles', 'F')  IS NOT NULL) ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_Clientes_Calles]
IF (OBJECT_ID('dbo.FK_Clientes_Calles1', 'F') IS NOT NULL) ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_Clientes_Calles1]
GO

ALTER TABLE [dbo].[Calles] DROP CONSTRAINT [PK_Calles] WITH ( ONLINE = OFF )
GO

EXECUTE sp_rename N'Calles', N'Tmp_Calles', 'OBJECT' 
GO

CREATE TABLE [dbo].[Calles](
	[IdCalle] [int] NOT NULL,
	[NombreCalle] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
 CONSTRAINT [PK_Calles] PRIMARY KEY CLUSTERED 
(
	[IdCalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Calles] ([IdCalle], [NombreCalle], [IdLocalidad])
                     SELECT [IdCalle], [NombreCalle], [IdLocalidad] FROM [dbo].[Tmp_Calles]
GO

UPDATE Clientes
   SET IdCalle  = ISNULL(NULLIF(IdCalle,  0), 1)
     , IdCalle2 = ISNULL(NULLIF(IdCalle2, 0), 1)

--ALTER TABLE Clientes ALTER COLUMN IdCalle  INT NOT NULL
--ALTER TABLE Clientes ALTER COLUMN IdCalle2 INT NOT NULL

ALTER TABLE [dbo].[Calles]  WITH NOCHECK ADD  CONSTRAINT [FK_Calles_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Calles] FOREIGN KEY([IdCalle])
REFERENCES [dbo].[Calles] ([IdCalle])
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Calles1] FOREIGN KEY([IdCalle2])
REFERENCES [dbo].[Calles] ([IdCalle])
GO

ALTER TABLE [dbo].[Calles] CHECK CONSTRAINT [FK_Calles_Localidades]
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Calles]
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Calles1]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tmp_Calles]') AND type in (N'U'))
DROP TABLE [dbo].[Tmp_Calles]
GO

