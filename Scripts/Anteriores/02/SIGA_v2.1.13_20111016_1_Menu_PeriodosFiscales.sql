
--Inserto la pantalla nueva

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
     IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('PeriodosFiscalesABM', 'ABM de Periodos Fiscales', 'ABM de Periodos Fiscales', 'True', 'False', 'True', 'True', 
     'AFIP', 20, 'Eniac.Win', 'PeriodosFiscalesABM', NULL)
GO


INSERT INTO RolesFunciones 
     (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'PeriodosFiscalesABM' AS Pantalla FROM Roles
GO
