
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('RestoreDB', 'Restaurar Backup de otro Local', 'Restaurar Backup de otro Local', 
    'True', 'False', 'True', 'True', 'Seguridad', 100,'Eniac.Win', 'RestoreDB', null)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)           
  VALUES ('Adm', 'RestoreDB')
GO

/*

INSERT INTO RolesFunciones (IdRol, IdFuncion)           
  VALUES ('Supervisor', 'RestoreDB')
GO

*/
