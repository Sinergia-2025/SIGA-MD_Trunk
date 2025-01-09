--Inserto el Menu nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express , Basica , PV, IdModulo,EsMDIChild)
  VALUES
    ('FacturacionElectronica', 'Fact. Electronica', '', 'True', 'False', 'True', 'True',
     NULL, 20, NULL, NULL, NULL, NULL, 0, 'False' , 'False', 'False', 'False',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FacturacionElectronica' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


--- Inserto las pantallas nuevas ---

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express , Basica , PV, IdModulo,EsMDIChild)
  VALUES
    ('SolicitarCAE', 'Solicitar CAEs', 'Solicitar CAEs', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 10, 'Eniac.Win', 'SolicitarCAE', NULL, NULL, 0, 'False' , 'False', 'False', 'False',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SolicitarCAE' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

---------------------------------------------------

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express , Basica , PV, IdModulo,EsMDIChild)
  VALUES
   ('ConsultarUltimoComprobante', 'Consultar Ultimo Comprobante en AFIP', 'Consultar Ultimo Comprobante en AFIP', 'True', 'False', 'True', 'True', 
    'FacturacionElectronica', 20, 'Eniac.Win', 'ConsultarUltimoComprobante', NULL, NULL, 0, 'False' , 'False', 'False', 'False',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarUltimoComprobante' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

---------------------------------------------------

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express , Basica , PV, IdModulo,EsMDIChild)
  VALUES
    ('ConsultarComprobantesEmitidos', 'Consultar Comprobantes Emitidos', 'Consultar Comprobantes Emitidos', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 30, 'Eniac.Win', 'ConsultarComprobantesEmitidos', NULL, NULL, 0, 'False' , 'False', 'False', 'False',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarComprobantesEmitidos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

---------------------------------------------------

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express , Basica , PV, IdModulo,EsMDIChild)
  VALUES
    ('ConsultarCAE', 'Consultar CAEs', 'Consultar CAEs', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 40, 'Eniac.Win', 'ConsultarCAE', NULL, NULL, 0, 'False' , 'False', 'False', 'False',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarCAE' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


---------------------------------------------------

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express , Basica , PV, IdModulo,EsMDIChild)
  VALUES
     ('ConsultarCAI', 'Consultar CAIs', 'Consultar CAIs', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 50, 'Eniac.Win', 'ConsultarCAI', NULL, NULL, 0, 'False' , 'False', 'False', 'False',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarCAI' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

---------------------------------------------------

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express , Basica , PV, IdModulo,EsMDIChild)
  VALUES
    ('ConsultarTablasAFIP', 'Consultar Tablas de AFIP', 'Consultar Tablas de AFIP', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 60, 'Eniac.Win', 'ConsultarTablasAFIP', NULL, NULL, 0, 'False' , 'False', 'False', 'False',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarTablasAFIP' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

---------------------------------------------------

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express , Basica , PV, IdModulo,EsMDIChild)
  VALUES
   ('TesteaServidoresAFIP', 'Testea Servidores de AFIP', 'Testea Servidores de AFIP', 'True', 'False', 'True', 'True',
    'FacturacionElectronica', 70, 'Eniac.Win', 'TesteaServidoresAFIP', NULL, NULL, 0, 'False' , 'False', 'False', 'False',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'TesteaServidoresAFIP' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO




INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, Enabled, Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express , Basica , PV, IdModulo,EsMDIChild)
 VALUES
   ('FacturacionElectro', 'Facturacion Electrónica', 'Facturacion Electrónica', 
    'True', 'False', 'True', 'True', 'Ventas', 10, 'Eniac.Win', 'FacturacionElectro', NULL, NULL, 0, 'False' , 'False', 'False', 'False',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FacturacionElectro' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
