PRINT ''
PRINT '1. Drop table: Funciones Documentos'
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[FuncionesDocumentos]') AND type in ('U'))
	DROP TABLE [dbo].[FuncionesDocumentos]
GO

PRINT ''
PRINT '2. Create table: Funciones Documentos'
CREATE TABLE [dbo].[FuncionesDocumentos](
    [IdFuncion] [varchar](30) NOT NULL,
    [IdTipoLink] [varchar](15) NULL,
    [Orden] [int] NOT NULL,
    [Link] [varchar](500) NULL,
    [Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
    [IdFuncion] ASC,
    [Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[FuncionesDocumentos]  WITH CHECK ADD FOREIGN KEY([IdFuncion])
REFERENCES [dbo].[Funciones] ([Id])
GO

PRINT ''
PRINT '3. Función Menu: Permitir Editar Clientes Desde Otras Pantallas'
IF dbo.ExisteFuncion('Clientes-PuedeUsarMasInfo') = 'False' and dbo.ExisteFuncion('Clientes') = 'True'
BEGIN
    PRINT ''
    PRINT '3.1. Función Menu: Crear función: Permitir Editar Clientes Desde Otras Pantallas'
    -- Clientes-Puede Editar Desde Otras Pantallas
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
          ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
         ('Clientes-PuedeUsarMasInfo', 'Permitir Editar Clientes Desde Otras Pantallas', 'Permitir Editar Clientes Desde Otras Pantallas', 'False', 'False', 'True', 'False', 
          'Clientes', 999, 'Eniac.Win', 'Clientes-PuedeUsarMasInfo', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N')
    ;
    
    -- Otorgar los Permisos a quienes tienen acceso al ABM 
    PRINT ''
    PRINT '3.2. Función Menu: Agregar permisos a función: Permitir Editar Clientes Desde Otras Pantallas'
    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'Clientes-PuedeUsarMasInfo' AS Pantalla FROM Roles
      WHERE Id IN (SELECT IdRol as Id FROM RolesFunciones WHERE IdFuncion = 'Clientes')
    ;
END
