PRINT ''
PRINT '1. Nuevo Parámetro: COMPRASSOLOCARGAPRODUCTOSDELPROVEEDOR'
DECLARE @idParametro VARCHAR(MAX) = 'COMPRASSOLOCARGAPRODUCTOSDELPROVEEDOR'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Compras: Solo carga Productos del Proveedor'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('20315659311') = 1 OR dbo.BaseConCuit('30712079459') = 1 -- CHANGO DIGITAL ó ELECTRO +
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO


PRINT ''
PRINT '2. Tabla Productos: Agrega campos'

ALTER TABLE Productos ADD CalidadNumeroChasis varchar(35) null
GO

ALTER TABLE Productos ADD CalidadNroCarroceria int null
GO

PRINT ''
PRINT '3. Tabla AuditoriaProductos: Agrega campos'

ALTER TABLE AuditoriaProductos ADD CalidadNumeroChasis varchar(35) null
GO

ALTER TABLE AuditoriaProductos ADD CalidadNroCarroceria int null
GO


PRINT ''
PRINT '4. Tabla TiposComprobantes: ComprobantesAsociados al Máximo de caracteres.'
GO
ALTER TABLE dbo.TiposComprobantes  ALTER COLUMN ComprobantesAsociados varchar(MAX) NULL
GO

PRINT ''
PRINT '5. Nueva Función: Importar Productos Clientes desde Excel'
GO
IF dbo.ExisteFuncion('Calidad') = 'True'
BEGIN
	INSERT INTO Funciones
		(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
		('ImportarProductosClientesExcel', 'Importar Productos Clientes desde Excel', 'Importar Productos Clientes desde Excel', 'True', 'False', 'True', 'True'
		,'Calidad', 294, 'Eniac.Win', 'ImportarProductosClientesExcel', NULL, NULL
		,'True', 'S', 'N', 'N', 'N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarProductosClientesExcel' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END 
GO

PRINT ''
PRINT '6. Tabla CRMTiposNovedadesDinamicos'
 IF dbo.BaseConCuit('33631312379') = 'True'
BEGIN
    INSERT CRMTiposNovedadesDinamicos 
           (IdTipoNovedad, IdNombreDinamico, EsRequerido, Orden) 
    VALUES ('TICKETS', 'PRODUCTOS', 'True', 10)
END

ALTER TABLE CRMNovedades ADD IdProductoNovedad	varchar(15)	null
GO

ALTER TABLE [dbo].[CRMNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedades_ProductosNovedad] FOREIGN KEY([IdProductoNovedad])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[CRMNovedades] CHECK CONSTRAINT [FK_CRMNovedades_ProductosNovedad]
GO

