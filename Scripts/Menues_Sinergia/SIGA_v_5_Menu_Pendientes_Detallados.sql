INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InformeDeNovSeguimPendientes', 'Informe de Pendientes Detallado', 'Informe de Pendientes Detallado', 
      'True', 'False', 'True', 'True', 
      'CRM', 210, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'PENDIENTE')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeNovSeguimPendientes' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Funciones')
GO
