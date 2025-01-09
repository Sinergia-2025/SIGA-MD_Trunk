PRINT ''
PRINT '1. Tabla CRMNovedades: Crea Campos Marca-Modelo'
ALTER TABLE dbo.CRMNovedades ADD NombreMarcaProducto varchar(50) NULL
ALTER TABLE dbo.CRMNovedades ADD NombreModeloProducto varchar(50) NULL
GO

UPDATE CRMNovedades
    SET NombreMarcaProducto = ''
      , NombreModeloProducto = ''
ALTER TABLE dbo.CRMNovedades ALTER COLUMN NombreMarcaProducto varchar(50) NOT NULL
ALTER TABLE dbo.CRMNovedades ALTER COLUMN NombreModeloProducto varchar(50) NOT NULL
GO

PRINT ''
PRINT '2. Tabla AuditoriaCRMNovedades: Crea Campos Marca-Modelo'
ALTER TABLE dbo.AuditoriaCRMNovedades ADD NombreMarcaProducto varchar(50) NULL
ALTER TABLE dbo.AuditoriaCRMNovedades ADD NombreModeloProducto varchar(50) NULL
GO
UPDATE AuditoriaCRMNovedades
    SET NombreMarcaProducto = ''
      , NombreModeloProducto = ''
ALTER TABLE dbo.AuditoriaCRMNovedades ALTER COLUMN NombreMarcaProducto varchar(50) NOT NULL
ALTER TABLE dbo.AuditoriaCRMNovedades ALTER COLUMN NombreModeloProducto varchar(50) NOT NULL
GO

PRINT ''
PRINT '3. Tabla CRMNovedades: Actualizar Campos Marca-Modelo'
UPDATE CRM
   SET IdMarcaProducto = MRK.IdMarca
     , NombreMarcaProducto = MRK.NombreMarca
     , IdModeloProducto = MDL.IdModelo
     , NombreModeloProducto = ISNULL(MDL.NombreModelo, '')
  FROM CRMNovedades AS CRM
 INNER JOIN Productos AS P ON P.IdProducto = CRM.IdProducto
 INNER JOIN Marcas AS MRK  ON P.IdMarca = MRK.IdMarca 
  LEFT JOIN Modelos AS MDL ON P.IdModelo = MDL.IdModelo
 WHERE CRM.IdMarcaProducto Is NULL


PRINT ''
PRINT '2 Tabla Tabla: Nuevo Campo: IdSucursal'
ALTER TABLE CuentasBancarias ADD IdEmpresa INT NULL
GO

PRINT '2.1. Se agrega Foreign Key a IdSucursal'
ALTER TABLE [dbo].CuentasBancarias  WITH CHECK ADD  CONSTRAINT [FK_IdEmpresa_CuentasBancarias] FOREIGN KEY(IdEmpresa)
REFERENCES [dbo].Empresas (IdEmpresa)
GO
-- Se deja como null porque es un dato opcional, fk e integer
PRINT '2.2. Actualizar registros pre-existentes'
UPDATE CuentasBancarias SET IdEmpresa = NULL
GO

PRINT ''
PRINT '3 Menu: Informe de Descuentos por Cliente/Producto/Marca/Rubro'
/*Informe de Descuentos por Cliente/Producto/Marca/Rubro*/
IF dbo.ExisteFuncion('Precios') = 1 
BEGIN
 INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('InformeDescCliProdMarcaRubro', 'Informe de Descuentos por Cliente/Producto/Marca/Rubro', 'Informe de Descuentos por Cliente/Producto/Marca/Rubro', 'True', 'False', 'True', 'True'
        ,'Precios', 280, 'Eniac.Win', 'InformeDescCliProdMarcaRubro', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')


	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InformeDescCliProdMarcaRubro' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
