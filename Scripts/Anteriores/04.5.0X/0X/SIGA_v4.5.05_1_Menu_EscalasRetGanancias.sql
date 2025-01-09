
--Inserto la Pantalla Nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('EscalasRetGananciasABM', 'ABM Escalas Retencion Ganancias', 'ABM Escalas Retencion Ganancias', 
      'True', 'False', 'True', 'True',
      'AFIP', 95, 'Eniac.Win', 'EscalasRetGananciasABM', NULL)
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EscalasRetGananciasABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

--Ajuste Pantalla Regimenes que estaba en 100 y coincidia con ABM de Categoria Fiscales.

UPDATE Funciones
 SET Posicion = 90
 WHERE Id = 'RegimenesABM'
GO
