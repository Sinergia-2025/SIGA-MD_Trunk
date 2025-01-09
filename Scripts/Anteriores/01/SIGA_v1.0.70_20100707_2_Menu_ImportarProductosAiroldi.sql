
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ImportarProductosAiroldi', 'Importar Productos de Airoldi Computacion', 'Importar Productos  de Airoldi Computacion', 
    'True', 'False', 'True', 'True', 'Procesos', 90,'Eniac.Win', 'ImportarProductosAiroldi', null)
GO

UPDATE RolesFunciones SET
   IdFuncion='ImportarProductosAiroldi'
  WHERE IdFuncion = 'ImportarDatosAiroldi'
GO

DELETE Funciones
  WHERE Id = 'ImportarDatosAiroldi'
GO
