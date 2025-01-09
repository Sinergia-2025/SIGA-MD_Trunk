
-- Tabla Cabecera --

INSERT INTO Buscadores
           (IdBuscador, Titulo, AnchoAyuda)
     VALUES
           (2 ,'Productos',1000)
GO

-- Tabla Detalle --

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'IdProducto',1,'Codigo', 64, 100,'')
GO

IF EXISTS (SELECT 1 FROM Parametros P WHERE P.IdParametro = 'PRODUCTOUTILIZACODIGOLARGO' AND P.ValorParametro = 'TRUE')
BEGIN
    INSERT INTO BuscadoresCampos(IdBuscador
			  ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
    VALUES
		(2, 'CodigoLargoProducto',2,'Codigo Largo', 16, 150,'');
END

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'NombreProducto',3,'Descripcion', 16, 285,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'Alicuota',4,'IVA', 64, 50,'N2')
GO      

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'NombreMoneda',5,'M.', 16, 50,'')
GO

 INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'PrecioVentaSinIVA',6,'P.Venta Sin IVA', 64, 70,'N2')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'PrecioVentaConIVA',7,'P.Venta Con IVA', 64, 70,'N2')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'Stock',8,'Stock', 64, 70,'N2')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'CodigoDeBarras',9,'Codigo De Barras', 64, 100,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'AfectaStock',10,'Afecta Stock', 32, 50,'')
GO        

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'EsServicio',11,'Es Servicio', 32, 50,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'PublicarEnWeb',12,'En Web', 32, 50,'')
GO

INSERT INTO BuscadoresCampos(IdBuscador
		   ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
VALUES
           (2, 'Observacion',13,'Observacion', 16, 300,'')
GO

IF EXISTS (SELECT 1 FROM Parametros P WHERE P.IdParametro = 'MODULOALQUILER' AND P.ValorParametro = 'TRUE')
BEGIN
    INSERT INTO BuscadoresCampos(IdBuscador
			  ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
    VALUES
		(2, 'EquipoMarca',14,'Equipo Marca', 64, 150,'')

    INSERT INTO BuscadoresCampos(IdBuscador
			  ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
    VALUES
		(2, 'EquipoModelo',15,'Equipo Modelo', 64, 150,'')

    INSERT INTO BuscadoresCampos(IdBuscador
			  ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
    VALUES
		(2, 'NumeroSerie',16,'Numero Serie', 64, 150,'')

    INSERT INTO BuscadoresCampos(IdBuscador
			  ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
    VALUES
		(2, 'CaractSII',17,'CaractSII', 64, 150,'')

    INSERT INTO BuscadoresCampos(IdBuscador
			  ,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
    VALUES
		(2, 'Anio',18,'Año', 64, 40,'')

END
