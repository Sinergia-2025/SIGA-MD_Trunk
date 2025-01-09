
--- ADUANAS MENU
INSERT INTO Funciones  
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AduanasABM', 'ABM de Aduanas', 'ABM de Aduanas', 'True', 'False', 'True', 'True', 
      'Compras', 70, 'Eniac.Win', 'AduanasABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AduanasABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


--- AGENTE DE TRANSPORTE MENU
INSERT INTO Funciones  
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AduanasAgentesTransporteABM', 'ABM de Agentes de Transporte de Aduana', 'ABM de Agentes de Transporte de Aduanas', 'True', 'False', 'True', 'True', 
      'Compras', 75, 'Eniac.Win', 'AduanasAgentesTransporteABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AduanasAgentesTransporteABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

--- DESPACHANTES MENU
INSERT INTO Funciones  
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AduanasDespachantesABM', 'ABM de Despachantes de Aduanas', 'ABM de Despachantes de Aduanas', 'True', 'False', 'True', 'True', 
      'Compras', 80, 'Eniac.Win', 'AduanasDespachantesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AduanasDespachantesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

--- DESTINACIONES MENU
INSERT INTO Funciones  
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AduanasDestinacionesABM', 'ABM de Destinaciones de Aduanas', 'ABM de Destinaciones de Aduanas', 'True', 'False', 'True', 'True', 
      'Compras', 85, 'Eniac.Win', 'AduanasDestinacionesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AduanasDestinacionesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
