

--Inserto las pantallas nuevas
INSERT INTO Funciones
    (Id,Nombre,Descripcion,EsMenu,EsBoton,Enabled,Visible,IdPadre,Posicion,Archivo,Pantalla,Icono)
 VALUES
    ('FacturacionCentAutop','Facturacion','Facturacion','True','False','True','True','Ventas', 12,'Eniac.Win','FacturacionCentAutop',NULL)
GO
    
INSERT INTO RolesFunciones
    (IdRol, IdFuncion)
  VALUES
    ('Adm', 'FacturacionCentAutop')
GO

INSERT INTO RolesFunciones
    (IdRol, IdFuncion)
  VALUES
    ('Supervisor', 'FacturacionCentAutop')
GO


