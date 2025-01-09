BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

PRINT ''
PRINT '1. Nueva tabla EstadosTurnos'
/****** Object:  Table [dbo].[EstadosTurnos]    Script Date: 23/4/2019 11:33:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosTurnos](
	[IdEstadoTurno] [varchar](10) NOT NULL,
	[NombreEstadoTurno] [varchar](50) NOT NULL,
	[Color] [int] NULL,
    [Finalizado] [bit] NOT NULL
 CONSTRAINT [PK_EstadoTurno] PRIMARY KEY CLUSTERED ([IdEstadoTurno] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '2. Copiar datos de TiposTurnos a EstadosTurnos'
INSERT INTO EstadosTurnos (IdEstadoTurno, NombreEstadoTurno, Color, Finalizado)
  SELECT IdTipoTurno, NombreTipoTurno, null, 'False' FROM TiposTurnos
GO
PRINT ''
PRINT '3. Asignar Finalizado True al estado ´T´'
UPDATE EstadosTurnos SET Finalizado = 'True'  WHERE IdEstadoTurno = 'T'
GO

PRINT ''
PRINT '4. Agregar columna IdEstadoTurno a TurnosCalendarios'
ALTER TABLE TurnosCalendarios ADD IdEstadoTurno varchar(10) null
GO
PRINT ''
PRINT '5. Ajusta datos de IdEstadoTurno y IdTipoTurno en TurnosCalendarios'
UPDATE TurnosCalendarios SET IdEstadoTurno = IdTipoTurno
UPDATE TurnosCalendarios SET IdTipoTurno = 'N'
DELETE TiposTurnos WHERE IdTipoTurno <> 'N'
ALTER TABLE TurnosCalendarios ALTER COLUMN IdEstadoTurno varchar(10) not null
GO

PRINT ''
PRINT '6. FK_TurnosCalendarios_EstadosTurnos'
--FK
ALTER TABLE dbo.TurnosCalendarios ADD CONSTRAINT FK_TurnosCalendarios_EstadosTurnos
    FOREIGN KEY (IdEstadoTurno)
    REFERENCES dbo.EstadosTurnos (IdEstadoTurno)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '7. Quitar columna EsEfectivo de TurnosCalendarios'
ALTER TABLE TurnosCalendarios DROP COLUMN EsEfectivo
GO


PRINT ''
PRINT '8. Nueva función ABM de Estados de Turnos'
IF dbo.ExisteFuncion('Turnos') = 1
BEGIN
    PRINT ''
    PRINT '8.1. Insertar funcion'
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
         ('EstadosTurnosABM', 'ABM de Estados de Turnos', 'ABM de Estados de Turnos', 'True', 'False', 'True', 'True', 
          'Turnos', 190, 'Eniac.Win', 'EstadosTurnosABM', NULL, NULL ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '8.2. Asignar permisos'
    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'EstadosTurnosABM' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '9. Normalizar nombre de función ABM de Tipos de Turnos'
UPDATE Funciones
   SET Nombre      = 'ABM de Tipos de Turnos'
     , Descripcion = 'ABM de Tipos de Turnos'
    WHERE Id = 'TiposTurnosABM'


PRINT ''
PRINT '10. Tabla Clientes/AuditoriaClientes/Prospectos/AuditoriaProspectos: Agrego Campo NivelAutorizacion'
ALTER TABLE dbo.Clientes ADD NivelAutorizacion smallint null;
ALTER TABLE dbo.AuditoriaClientes ADD NivelAutorizacion smallint null;
ALTER TABLE dbo.Prospectos ADD NivelAutorizacion smallint null;
ALTER TABLE dbo.AuditoriaProspectos ADD NivelAutorizacion smallint null;
GO

PRINT ''
PRINT '11. Valor por defecto para NivelAutorizacion en tablas Clientes/Prospectos'
UPDATE dbo.Clientes SET NivelAutorizacion  = 0;
UPDATE dbo.Prospectos SET NivelAutorizacion  = 0;
ALTER TABLE dbo.Clientes ALTER COLUMN NivelAutorizacion smallint NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN NivelAutorizacion smallint NOT NULL
GO

PRINT ''
PRINT '12. Agrega Funcion Clientes: Clientes-NivelAutorizacion'
GO
BEGIN TRANSACTION
IF dbo.ExisteFuncion('Clientes-NivelAutorizacion') = 0
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '12.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('Clientes-NivelAutorizacion', 'Clientes: Nivel de Autorizacion', 'Clientes: Nivel de Autorizacion', 
		'False', 'False', 'True', 'True', 'Clientes',888, 'Eniac.Win', 'Clientes-NivelAutorizacion', null, null,'N','S','N','N')
	END;

    PRINT ''
    PRINT '12.2. Asignar Permisos'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'Clientes-NivelAutorizacion' FROM RolesFunciones
     WHERE IdFuncion = 'Clientes';
	;
	COMMIT
GO

PRINT ''
PRINT '13. Tabla Productos/AuditoriaProductos: Agrego Campo ActualizaPreciosSucursalesAsociadas'
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Productos ADD ActualizaPreciosSucursalesAsociadas bit NULL
ALTER TABLE dbo.AuditoriaProductos ADD ActualizaPreciosSucursalesAsociadas bit NULL
GO
PRINT ''
PRINT '14. Valores por defecto para el campo ActualizaPreciosSucursalesAsociadas en tabla Productos'
UPDATE Productos SET ActualizaPreciosSucursalesAsociadas = 1;
ALTER TABLE dbo.Productos ALTER COLUMN ActualizaPreciosSucursalesAsociadas bit NOT NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '15. Tabla Categorias: Agrego Campo NivelAutorizacion'
ALTER TABLE dbo.Categorias ADD NivelAutorizacion smallint null;
GO
PRINT ''
PRINT '16. Valores por defecto para el campo NivelAutorizacion en tabla Categorias'
UPDATE dbo.Categorias SET NivelAutorizacion  = 1;
GO


PRINT ''
PRINT '17. Agrega Funcion Clientes: Categoria-NivelAutorizacion'
BEGIN TRANSACTION
IF dbo.ExisteFuncion('Categoria-NivelAutorizacion') = 0
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '17.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('Categoria-NivelAutorizacion', 'Categoria: Nivel de Autorizacion', 'Categoria: Nivel de Autorizacion', 
		'False', 'False', 'True', 'True', 'Categorias',888, 'Eniac.Win', 'Categoria-NivelAutorizacion', null, null,'N','S','N','N')
	END;

    PRINT ''
    PRINT '17.2. Asignar Permisos'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'Categoria-NivelAutorizacion' FROM RolesFunciones
     WHERE IdFuncion = 'Categorias';
	;
	COMMIT
GO

DECLARE @idParametro VARCHAR(MAX) = 'CLIENTEPERMITEMODIFICARCODIGO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Cliente permite modificar código'
DECLARE @valorParametro VARCHAR(MAX) = 'True'
IF dbo.BaseConCuit('33711345499') = 1 OR dbo.BaseConCuit('23238857449') = 1 OR dbo.BaseConCuit('30715507907') = 1
    SET @valorParametro = 'False'

PRINT ''
PRINT '18. Parametro Cliente permite modificar código'
MERGE INTO Parametros AS DEST
        USING (SELECT @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro) AS ORIG ON DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

PRINT ''
PRINT '18. Traducciones para SAURO JOSE LUIS'
IF dbo.BaseConCuit('20220875181') = 1 AND dbo.ExisteFuncion('Clientes') = 1
BEGIN
    PRINT '1.1. ClientesABM  Cambiar Nombre Instagram por Horarios'
    INSERT INTO [dbo].Traducciones
                (IdFuncion, Pantalla, Control, IdIdioma, Texto)
            VALUES ('Clientes', '', 'Instagram', 'es_AR', 'Horarios');

    PRINT '1.2. ClientesABM  Cambiar Nombre Instagram por Horarios'
    INSERT INTO [dbo].Traducciones
                (IdFuncion, Pantalla, Control, IdIdioma, Texto)
            VALUES ('Clientes', '', 'Twitter', 'es_AR', 'Contacto');

    PRINT '2.1. ClientesDetalle  Cambiar Nombre Instagram por Horarios'
    INSERT INTO [dbo].Traducciones
                (IdFuncion, Pantalla, Control, IdIdioma, Texto)
            VALUES ('Clientes', '', 'lblInstagram', 'es_AR', 'Horarios');

    PRINT '2.2. ClientesDetalle  Cambiar Nombre Twitter por Contacto'
    INSERT INTO [dbo].Traducciones
                (IdFuncion, Pantalla, Control, IdIdioma, Texto)
            VALUES ('Clientes', '', 'lblTwitter', 'es_AR', 'Contacto');
END

PRINT ''
PRINT '19. Nuevo campo EsProveedorGenerico para tabla Proveedores'
ALTER TABLE dbo.Proveedores ADD EsProveedorGenerico bit NULL
GO
PRINT ''
PRINT '20. Valor por defecto para EsProveedorGenerico de tabla Proveedores'
UPDATE Proveedores SET EsProveedorGenerico = 0;
ALTER TABLE dbo.Proveedores ALTER COLUMN EsProveedorGenerico bit NOT NULL
GO
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
