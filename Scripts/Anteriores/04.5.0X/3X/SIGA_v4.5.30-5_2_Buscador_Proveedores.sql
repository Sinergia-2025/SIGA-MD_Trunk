
DECLARE @max int
SET @max = 5

INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda) VALUES (@max, 'Proveedores', 1000)

INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'CodigoProveedor',1, 'Codigo', 16, 50,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'NombreProveedor',2, 'Nombre', 16, 200,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'DireccionProveedor',3, 'Dirección', 16, 150,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'NombreLocalidad',4, 'Localidad', 16, 100,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'NombreCategoriaFiscal',5, 'Categ.Fiscal', 16, 120,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'NombreCategoria',6, 'Categoria', 16, 120,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'NombreRubro',7, 'Rubro', 16, 120,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'CuitProveedor',8, 'CUIT', 16, 80,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'TipoDocProveedor',9, 'Tp Doc', 16, 50,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'NroDocProveedor',10,'Nro. Doc', 16, 80,'')

INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'IngresosBrutos',11, 'Ing. Brutos', 16, 120,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'TelefonoProveedor',12, 'Ing. Brutos', 16, 170,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'FaxProveedor',13, 'Fax', 16, 170,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'CorreoElectronico',14, 'E-Mail', 16, 80,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'NombreCuentaCaja',15, 'Cuenta de Caja', 16, 240,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'Activo',16, 'Activo', 32, 40,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'EsPasibleRetencion',17, 'Ret.Gan.', 32, 70,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'EsPasibleRetencionIVA',18, 'Ret.IVA.', 32, 70,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'EsPasibleRetencionIIBB',19, 'Ret.IIBB.', 32, 70,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'IdTipoComprobante',20, 'Comprobante', 16, 100,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'FechaHigSeg',21, 'Fecha HyS', 32, 80,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'FechaRes559',22, 'Fecha Res559', 32, 80,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'FechaIndiceInc',23, 'Fecha Indice', 32, 80,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'IdCuentaContable',24, 'Cuenta', 16, 90,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'NombreCuenta',25, 'Nombre Cuenta', 16, 280,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) VALUES (@max, 'Observacion',26, 'Observaciones', 16, 400,'')
GO
