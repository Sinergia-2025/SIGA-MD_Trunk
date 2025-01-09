
--Inserto el Menu nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('FacturacionElectronica', 'Fact. Electronica', '', 'True', 'False', 'True', 'True',
     NULL, 15, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FacturacionElectronica' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor')
GO


--- Inserto las pantallas nuevas ---

DELETE RolesFunciones WHERE IdFuncion = 'SolicitarCAE'
GO

DELETE Funciones WHERE Id = 'SolicitarCAE'
GO

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('SolicitarCAE', 'Solicitar CAEs', 'Solicitar CAEs', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 10, 'Eniac.Win', 'SolicitarCAE', NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SolicitarCAE' AS Pantalla FROM dbo.Roles
GO

---------------------------------------------------

DELETE RolesFunciones WHERE IdFuncion = 'ConsultarComprobantesEmitidos'
GO

DELETE Funciones WHERE Id = 'ConsultarComprobantesEmitidos'
GO

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('ConsultarComprobantesEmitidos', 'Consultar Comprobantes Emitidos', 'Consultar Comprobantes Emitidos', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 20, 'Eniac.Win', 'ConsultarComprobantesEmitidos', NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarComprobantesEmitidos' AS Pantalla FROM dbo.Roles
GO

---------------------------------------------------

DELETE RolesFunciones WHERE IdFuncion = 'ConsultarUltimoComprobante'
GO

DELETE Funciones WHERE Id = 'ConsultarUltimoComprobante'
GO

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
   ('ConsultarUltimoComprobante', 'Consultar Ultimo Comprobante en AFIP', 'Consultar Ultimo Comprobante en AFIP', 'True', 'False', 'True', 'True', 
    'FacturacionElectronica', 30, 'Eniac.Win', 'ConsultarUltimoComprobante', null)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarUltimoComprobante' AS Pantalla FROM dbo.Roles
GO

---------------------------------------------------

DELETE RolesFunciones WHERE IdFuncion = 'ConsultarCAE'
GO

DELETE Funciones WHERE Id = 'ConsultarCAE'
GO

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('ConsultarCAE', 'Consultar CAEs', 'Consultar CAEs', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 40, 'Eniac.Win', 'ConsultarCAE', NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarCAE' AS Pantalla FROM dbo.Roles
GO

---------------------------------------------------

DELETE RolesFunciones WHERE IdFuncion = 'ConsultarCAI'
GO

DELETE Funciones WHERE Id = 'ConsultarCAI'
GO

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ConsultarCAI', 'Consultar CAIs', 'Consultar CAIs', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 50, 'Eniac.Win', 'ConsultarCAI', NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarCAI' AS Pantalla FROM dbo.Roles
GO

---------------------------------------------------

DELETE RolesFunciones WHERE IdFuncion = 'ConsultarTablasAFIP'
GO

DELETE Funciones WHERE Id = 'ConsultarTablasAFIP'
GO

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('ConsultarTablasAFIP', 'Consultar Tablas de AFIP', 'Consultar Tablas de AFIP', 'True', 'False', 'True', 'True',
     'FacturacionElectronica', 60, 'Eniac.Win', 'ConsultarTablasAFIP', NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarTablasAFIP' AS Pantalla FROM dbo.Roles
GO

---------------------------------------------------

DELETE RolesFunciones WHERE IdFuncion = 'TesteaServidoresAFIP'
GO

DELETE Funciones WHERE Id = 'TesteaServidoresAFIP'
GO

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
   ('TesteaServidoresAFIP', 'Testea Servidores de AFIP', 'Testea Servidores de AFIP', 'True', 'False', 'True', 'True',
    'FacturacionElectronica', 70, 'Eniac.Win', 'TesteaServidoresAFIP', NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'TesteaServidoresAFIP' AS Pantalla FROM dbo.Roles
GO
