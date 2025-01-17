
Print'1. Agrego el Control Dinamico PROYECTOS en el CRM';

IF EXISTS (SELECT 1 FROM CRMTiposNovedades WHERE IdTipoNovedad = 'ACTIVIDAD')
	INSERT INTO CRMTiposNovedadesDinamicos
			   (IdTipoNovedad, IdNombreDinamico, EsRequerido)
		 VALUES
			   ('ACTIVIDAD', 'PROYECTOS', 'False')
;


PRINT '2. Agrego columna IdProyecto a la tabla de CRMNovedades';

ALTER TABLE dbo.CRMNovedades ADD IdProyecto int NULL
;

PRINT '3. Agrego la clave foranea CRMNovedades.FK_CRMNovedades_Proyectos';

ALTER TABLE dbo.CRMNovedades  WITH CHECK ADD  
	CONSTRAINT FK_CRMNovedades_Proyectos FOREIGN KEY(IdProyecto)
	REFERENCES dbo.Proyectos (IdProyecto)
;

--------------------------------

PRINT '4. configurar el buscador de Proyectos - Cabecera';

declare @maximo as int
set @maximo = (Select max(idBuscador) + 1 as Id from Buscadores)

INSERT INTO Buscadores
           (IdBuscador, Titulo, AnchoAyuda)
     VALUES
           (@maximo, 'Proyectos', 800)
;

PRINT '5. configurar el buscador de Proyectos - Campos';

INSERT INTO BuscadoresCampos     (IdBuscador,IdBuscadorNombreCampo,Orden,Titulo
           ,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
     VALUES
           (@maximo, 'IdProyecto',1,'Codigo',32,80,'',null,null,null);
           
INSERT INTO BuscadoresCampos     (IdBuscador,IdBuscadorNombreCampo,Orden,Titulo
           ,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
     VALUES
           (@maximo, 'NombreProyecto',2,'Proyecto',16,250,'',null,null,null);
           
INSERT INTO BuscadoresCampos     (IdBuscador,IdBuscadorNombreCampo,Orden,Titulo
           ,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
     VALUES
           (@maximo, 'NombreCliente',3,'Cliente',16,250,'',null,null,null);
