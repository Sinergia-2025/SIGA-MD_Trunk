PRINT ''
PRINT '1. Nueva Tabla para SiGA: Nacionalidades'
CREATE TABLE [dbo].[Nacionalidades](
	[IdNacionalidad] [int] NOT NULL,
	[NombreNacionalidad] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Nacionalidades] PRIMARY KEY CLUSTERED ([IdNacionalidad] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT '1.1 Se inserta una Nacionalidad' --Debido a que SueldosPersonal tiene registros con idNacionalidad = 0
INSERT INTO Nacionalidades VALUES (1, 'Argentino/a')
GO

PRINT ''
PRINT '2. Tabla SueldosPersonal: Actualizar registros pre-existentes para los campos'
UPDATE SueldosPersonal SET IdNacionalidad = 1
ALTER TABLE SueldosPersonal ALTER COLUMN IdNacionalidad Int NOT NULL
GO

PRINT ''
PRINT '2.1. Foreign Key para IdNacionalidad' --Se encontro que ya existe la columna IdNacionalidad pero no es FK
ALTER TABLE [dbo].SueldosPersonal  WITH CHECK ADD  CONSTRAINT [FK_SueldosPersonal_Nacionalidades] FOREIGN KEY(idNacionalidad)
        REFERENCES [dbo].[Nacionalidades] ([IdNacionalidad])
GO
ALTER TABLE [dbo].[SueldosPersonal] CHECK CONSTRAINT [FK_SueldosPersonal_Nacionalidades]
GO

PRINT ''
PRINT '3. Nuevo Menu: Nacionalidades'
BEGIN
    PRINT ''
    PRINT '3.1. Nueva Función: Nacionalidades'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('NacionalidadesABM', 'Nacionalidades', 'Nacionalidades', 'True', 'False', 'True', 'True'
        ,'Archivos', 93, 'Eniac.Win', 'NacionalidadesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

    PRINT ''
    PRINT '3.2. Roles para función: Nacionalidades'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'NacionalidadesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '4. Borrar Menu: LiquidacionesTarjeta'
IF dbo.SoyHAR() = 0
BEGIN
    DECLARE @idFuncion VARCHAR(MAX) = 'LiquidacionesTarjeta'

    DELETE FROM Bitacora WHERE IdFuncion = @idFuncion
    DELETE FROM RolesFunciones WHERE IdFuncion = @idFuncion
    DELETE FROM Funciones WHERE Id = @idFuncion
END

PRINT ''
PRINT '5. Parametros: Cambiar tope Consumidor Fiscal'
DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCONTROLATOPECF'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Tope Consumidor Final'
DECLARE @valorParametro_NuevoTope DECIMAL(12) = '13115'

UPDATE Parametros
   SET ValorParametro = CASE WHEN ValorParametro < @valorParametro_NuevoTope THEN @valorParametro_NuevoTope ELSE ValorParametro END
 WHERE IdParametro = @idParametro


PRINT ''
PRINT '6. Nuevo Formato Etiqueta Codigo De Barra: 10 x 3 cm'
DECLARE @maxId INT = (SELECT max(IdFormatoEtiqueta) FROM FormatosEtiquetas)
INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta],[NombreFormatoEtiqueta] ,[Tipo] ,[ArchivoAImprimir] ,[ArchivoAImprimirEmbebido] ,[NombreImpresora] ,[ImprimeLote]
           ,[MaximoColumnas] ,[UtilizaCabecera] ,[SolicitaListaPrecios2] ,[Activo])
     VALUES
           (@maxId + 1, '1 x Ancho (10 x 3 cm)', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF12.rdlc', 1, '', 0, 1, 0, 0, 1)
GO

PRINT '7. Se Setean los registros que tienen LeyendaCategoriaFiscal NULL a Espacio '
UPDATE CategoriasFiscales SET LeyendaCategoriaFiscal = '' WHERE LeyendaCategoriaFiscal  IS NULL
GO

PRINT ''
PRINT '8. Se setea el campo LeyendaCategoriaFiscal a Not Null'
ALTER TABLE [dbo].[CategoriasFiscales] ALTER COLUMN [LeyendaCategoriaFiscal] [varchar](500) NOT NULL
GO
