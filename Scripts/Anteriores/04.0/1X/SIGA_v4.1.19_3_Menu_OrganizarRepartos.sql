
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('OrganizarRepartos', 'Organizar Repartos', 'Organizar Repartos', 'True', 'False', 'True', 'True', 
      'Ventas', 50, 'Eniac.Win', 'OrganizarRepartos', NULL)
GO

UPDATE RolesFunciones 
   SET IdFuncion = 'OrganizarRepartos'
 WHERE IdFuncion = 'ConsolidarComprobPorProductos' 
GO

DELETE Funciones
 WHERE Id = 'ConsolidarComprobPorProductos'
GO
