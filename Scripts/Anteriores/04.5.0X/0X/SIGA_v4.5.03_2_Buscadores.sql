
-- Tabla Cabecera --

INSERT INTO Buscadores
           (IdBuscador, Titulo, AnchoAyuda)
     VALUES
           (1 ,'Clientes',1000)
GO

-- Tabla Detalle --

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'CodigoCliente',1,'Codigo', 64, 70,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'NombreCliente',2,'Nombre', 16, 200,'')
GO
INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'NombreCategoria',3,'Categoria', 16, 100,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'Direccion',4,'Direccion', 16, 150,'')
GO  

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'NombreLocalidad',5,'Localidad', 16, 120,'')
GO      

 INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'NombreProvincia',6,'Provincia', 16, 80,'')
GO

 INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'NombreCategoriaFiscal',7,'Categ. Fiscal', 16, 100,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'TipoDocCliente',8,'T.D.', 16, 40,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'NroDocCliente',9,'Nro. Documento', 64, 80,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'Cuit',10,'CUIT', 64, 80,'')
GO
        
INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'Telefono',11,'Telefono', 64, 100,'')
GO        
		 
INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'Celular',12,'Celular', 64, 100,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'NombreZonaGeografica',13,'Zona Geograf.', 16, 100,'')
GO

 INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (1, 'Observacion',14,'Observacion', 16, 300,'')
GO
