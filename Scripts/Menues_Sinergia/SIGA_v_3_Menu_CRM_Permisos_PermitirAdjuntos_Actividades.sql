
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ACTIVIDAD-PuedeAdjuntar', 'Permitir Adjuntar archivos a Novedades - Actividad', 'Permitir Adjuntar archivos a Novedades - Actividad', 'False', 'False', 'True', 'False', 
      'CRMNovedadesABMACTIVIDAD', 999, 'Eniac.Win', 'Novedades-PuedeAdjuntar', NULL)
GO


INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ACTIVIDAD-PuedeAdjuntar' AS Pantalla FROM Roles
  WHERE Id IN ('Adm', 'Soporte')
GO
