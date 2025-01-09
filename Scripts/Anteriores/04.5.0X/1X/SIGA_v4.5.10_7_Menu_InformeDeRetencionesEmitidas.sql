
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
SELECT 'InfRetencionesEmitidas' AS XXId, 'Informe de Retenciones Emitidas' AS XXNombre, 'Informe de Retenciones Emitidas' AS XXDescripcion, EsMenu, EsBoton, Enabled, Visible
       ,IdPadre, Posicion, Archivo, 'InfRetencionesEmitidas' AS XXPantalla, Icono
  FROM Funciones
 WHERE Id = 'InfRetencionesCompras'
GO

UPDATE RolesFunciones 
   SET IdFuncion = 'InfRetencionesEmitidas'
 WHERE IdFuncion = 'InfRetencionesCompras'
GO

DELETE Funciones
 WHERE Id = 'InfRetencionesCompras'
GO
