DELETE BuscadoresCampos WHERE IdBuscador = 3
DELETE Buscadores WHERE IdBuscador = 3
GO

-- Tabla Cabecera --

INSERT INTO Buscadores(IdBuscador, Titulo, AnchoAyuda)
                VALUES(3 ,'Funciones',1000)
GO

-- Tabla Detalle --

INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'Archivo',1,'Archivo', 16, 100,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'Id',2,'Id', 16, 150,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'Nombre',3,'Nombre', 16, 200,'')
--INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
--                     VALUES (3, 'Descripcion',3,'Descripcion', 16, 200,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'EsMenu',4,'EsMenu', 32, 50,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'EsBoton',5,'EsBoton', 32, 50,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'Enabled',6,'Enabled', 32, 50,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'Visible',7,'Visible', 32, 50,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'IdPadre',8,'IdPadre', 16, 150,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'Posicion',9,'Posicion', 64, 70,'')
INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
                     VALUES (3, 'Pantalla',10,'Pantalla', 16, 150,'')
GO
