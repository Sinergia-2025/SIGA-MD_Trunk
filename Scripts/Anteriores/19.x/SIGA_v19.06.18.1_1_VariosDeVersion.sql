PRINT ''
PRINT '1. Tabla CRMMediosComunicacionesNovedades: Personalmente PorDefecto True para Servicio Tecnico'
UPDATE CRMMediosComunicacionesNovedades set PorDefecto = 'True' WHERE NombreMedioComunicacionNovedad = 'PERSONALMENTE' 
		AND IdTipoNovedad = 'SERVICE'

PRINT ''
PRINT '2. Table CRMEstadosNovedades - Nuevo campo Embebido'
ALTER TABLE CRMEstadosNovedades ADD Embebido bit null
GO
PRINT ''
PRINT '2.1. Table CRMEstadosNovedades - Valor por defecto para Embebido'
UPDATE CRMEstadosNovedades SET Embebido = 'False'
PRINT ''
PRINT '2.2. Table CRMEstadosNovedades - NOT NULL para Embebido'
ALTER TABLE CRMEstadosNovedades ALTER COLUMN Embebido bit not null
GO


PRINT ''
PRINT '3. Table CRMTiposNovedades - Nuevo campo VerCambios'
ALTER TABLE CRMTiposNovedades ADD VerCambios bit null
GO
PRINT ''
PRINT '3.1. Table CRMTiposNovedades - Valor por defecto para VerCambios'
UPDATE CRMTiposNovedades SET VerCambios = 'False'
GO
PRINT ''
PRINT '3.2. Table CRMTiposNovedades - NOT NULL para VerCambios'
ALTER TABLE CRMTiposNovedades ALTER COLUMN VerCambios bit not null
GO

PRINT ''
PRINT '4. Parametros: Agrego IdAplicacion si no existe'
IF NOT EXISTS(SELECT * FROM Parametros WHERE IdParametro = 'IDAPLICACION')
BEGIN
    INSERT INTO Parametros (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
                     SELECT IdEmpresa, 'IDAPLICACION', 'SIGA', NULL, NULL FROM Empresas
END

PRINT ''
PRINT '5. Funciones: Agrego la aplicación como opción de menú si no existe'
DECLARE @idFuncion VARCHAR(MAX) = (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'IDAPLICACION')
IF dbo.ExisteFuncion(@idFuncion) = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        (@idFuncion, 'Aplicacion ' + @idFuncion, 'Aplicacion ' + @idFuncion, 'False', 'False', 'False', 'False'
        ,NULL, 999, NULL, NULL, NULL, NULL
        ,'False', 'N', 'N', 'N', 'N')
END


PRINT ''
PRINT '6. Table Clientes - Nuevos campos URLWebmovilPropio, URLWebmovilAdminPropio y URLSimovilGestionPropio'
ALTER TABLE dbo.Clientes ADD URLWebmovilPropio varchar(150) NULL
ALTER TABLE dbo.Clientes ADD URLWebmovilAdminPropio varchar(150) NULL
ALTER TABLE dbo.Clientes ADD URLSimovilGestionPropio varchar(150) NULL

PRINT ''
PRINT '6.1. Table Prospectos - Nuevos campos URLWebmovilPropio, URLWebmovilAdminPropio y URLSimovilGestionPropio'
ALTER TABLE dbo.Prospectos ADD URLWebmovilPropio varchar(150) NULL
ALTER TABLE dbo.Prospectos ADD URLWebmovilAdminPropio varchar(150) NULL
ALTER TABLE dbo.Prospectos ADD URLSimovilGestionPropio varchar(150) NULL

PRINT ''
PRINT '6.2. Table AuditoriaClientes - Nuevos campos URLWebmovilPropio, URLWebmovilAdminPropio y URLSimovilGestionPropio'
ALTER TABLE dbo.AuditoriaClientes ADD URLWebmovilPropio varchar(150) NULL
ALTER TABLE dbo.AuditoriaClientes ADD URLWebmovilAdminPropio varchar(150) NULL
ALTER TABLE dbo.AuditoriaClientes ADD URLSimovilGestionPropio varchar(150) NULL

PRINT ''
PRINT '6.3. Table AuditoriaProspectos - Nuevos campos URLWebmovilPropio, URLWebmovilAdminPropio y URLSimovilGestionPropio'
ALTER TABLE dbo.AuditoriaProspectos ADD URLWebmovilPropio varchar(150) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD URLWebmovilAdminPropio varchar(150) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD URLSimovilGestionPropio varchar(150) NULL



PRINT ''
PRINT '7. Table CRMCategoriasNovedades - Ajusto datos para Soporte Tecnico'
DELETE CRMCategoriasNovedades WHERE IdTipoNovedad = 'SERVICE' AND NombreCategoriaNovedad = 'RECLAMO DEUDA'

UPDATE CRMCategoriasNovedades set PorDefecto = 'False' WHERE IdTipoNovedad = 'SERVICE'

DECLARE @idCat int = (SELECT MAX(IdCategoriaNovedad) FROM CRMCategoriasNovedades WHERE IdTipoNovedad = 'SERVICE')

IF @idCat IS NOT NULL
    INSERT INTO [dbo].[CRMCategoriasNovedades]
               ([IdCategoriaNovedad]
               ,[NombreCategoriaNovedad]
               ,[Posicion]
               ,[IdTipoNovedad]
               ,[PorDefecto]
               ,[Reporta]
               ,[Color]
               ,[PublicarEnWeb])
         VALUES
               (@idCat + 1, 'PROPIO',  	1	,'SERVICE',	'True',	'NO',	NULL,	'True')

DECLARE @idCat2 int = (SELECT MAX(IdCategoriaNovedad) FROM CRMCategoriasNovedades WHERE IdTipoNovedad = 'SERVICE')

IF @idCat2 IS NOT NULL
    INSERT INTO [dbo].[CRMCategoriasNovedades]
               ([IdCategoriaNovedad]
               ,[NombreCategoriaNovedad]
               ,[Posicion]
               ,[IdTipoNovedad]
               ,[PorDefecto]
               ,[Reporta]
               ,[Color]
               ,[PublicarEnWeb])
         VALUES
               (@idCat2 + 1, 'AJENO',  	1	,'SERVICE',	'False',	'NO',	NULL,	'True')


PRINT ''
PRINT '8. Tabla Categorias: Elimino Campo ActualizarVersion'
GO
IF EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'Categorias'
              AND COLUMN_NAME = 'ActualizarVersion') 
	ALTER TABLE Categorias DROP COLUMN ActualizarVersion;
GO

PRINT ''
PRINT '9. Tabla Categorias: Ajusto ActualizarAplicacion en False.'
UPDATE dbo.Categorias SET ActualizarAplicacion  = 0;

PRINT ''
PRINT '9.1. Tabla Categorias: NOT NULL ActualizarAplicacion'
ALTER TABLE dbo.Categorias ALTER COLUMN ActualizarAplicacion bit NOT NULL
GO

PRINT ''
PRINT '9.2. Tabla Categorias: Ajusto ActualizarAplicacion en True para los que correspondan en HAR.'
UPDATE dbo.Categorias 
   SET ActualizarAplicacion = 'True'
 WHERE IdGrupoCategoria = 'Actualizar'
GO

PRINT ''
PRINT '10. Parametros: DNI por defecto para las empresas de argentina'
IF dbo.GetValorParametro('EMPRESACURRENTUICULTURE') = 'es-AR'
	UPDATE Parametros
	   SET ValorParametro = 'DNI'
	 WHERE IdParametro = 'TIPODOCUMENTOCLIENTE'
	   AND ValorParametro ='COD';
GO
