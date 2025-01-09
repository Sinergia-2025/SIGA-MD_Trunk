
--Inserto la pantalla nueva

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
          PermiteMultiplesInstancias,Plus,Express,Basica,PV)
  VALUES
     ('ConceptosABM', 'ABM de Conceptos', 'ABM de Conceptos', 'True', 'False', 'True', 'True',
      'Compras', 300, 'Eniac.Win', 'ConceptosABM', NULL, NULL,
      'True', 'S', 'O', 'O', 'O')
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConceptosABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
          PermiteMultiplesInstancias,Plus,Express,Basica,PV)
  VALUES
     ('RubrosConceptosABM', 'ABM de Rubros Conceptos', 'ABM de Rubros Conceptos', 'True', 'False', 'True', 'True',
      'Compras', 310, 'Eniac.Win', 'RubrosConceptosABM', NULL, NULL,
      'True', 'S', 'O', 'O', 'O')
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'RubrosConceptosABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
