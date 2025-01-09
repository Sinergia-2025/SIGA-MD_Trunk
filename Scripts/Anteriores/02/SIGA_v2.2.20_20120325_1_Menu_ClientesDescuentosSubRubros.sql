
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ClientesDescuentosSubRubros', 'Clientes - Asignación de Descuentos en SubRubros', 'Clientes - Asignación de Descuentos en SubRubros', 
      'True', 'False', 'True', 'True',
      'Precios', 120, 'Eniac.Win', 'ClientesDescuentosSubRubros', NULL)
GO

UPDATE RolesFunciones 
   SET IdFuncion = 'ClientesDescuentosSubRubros'
 WHERE IdFuncion = 'ClientesSubRubrosDescuentos'
GO

-- Ajusto la posicion de la pantalla estandar

DELETE Funciones
 WHERE Id = 'ClientesSubRubrosDescuentos'
GO
