
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ClientesActualizacionMasiva', 'Clientes - Actualizacion Masiva', 'Clientes - Actualizacion Masiva', 
    'True', 'False', 'True', 'True', 'Archivos', 25, 'Eniac.Win', 'ClientesActualizacionMasiva', NULL)
GO

UPDATE RolesFunciones 
   SET IdFuncion = 'ClientesActualizacionMasiva'
 WHERE IdFuncion = 'ClientesActualizMasivaVend'
GO

DELETE Funciones
 WHERE Id = 'ClientesActualizMasivaVend'
GO
