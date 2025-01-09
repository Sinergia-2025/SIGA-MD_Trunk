
DELETE RolesFunciones 
WHERE IdFuncion IN
 (
SELECT id FROM [Funciones]
 WHERE id='Fichas' OR IdPadre='Fichas' OR IdPadre='FichasABM'
)
GO

DELETE [Funciones]
 WHERE id='Fichas' OR IdPadre='Fichas' OR IdPadre='FichasABM'
GO


--Inserto el Menu nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Fichas', 'Fichas', '', 'True', 'False', 'True', 'True',
     NULL, 5, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Fichas' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor')
GO


--- Inserto las pantallas nuevas ---

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('FichasABM', 'Fichas (de Cliente)', 'Fichas (de Cliente)', 
    'True', 'True', 'True', 'True', 'Fichas', 10,'Eniac.Fichas.Win', 'FichasABM', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FichasABM' AS Pantalla FROM dbo.Roles
GO                          

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('FichasClienteAct', 'Intercambiar Fichas entre Clientes', 'Intercambiar Fichas entre Clientes', 
    'True', 'False', 'True', 'True', 'Fichas', 20,'Eniac.Fichas.Win', 'FichasClienteAct', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FichasClienteAct' AS Pantalla FROM dbo.Roles
GO                          

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('FichasEmitidas', 'Fichas Emitidas', 'Fichas Emitidas', 
    'True', 'False', 'True', 'True', 'Fichas', 30,'Eniac.Fichas.Win', 'FichasEmitidas', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FichasEmitidas' AS Pantalla FROM dbo.Roles
GO                          

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('IngresosPorFichas', 'Ingresos por Fichas', 'Ingresos por Fichas', 
    'True', 'False', 'True', 'True', 'Fichas', 40,'Eniac.Fichas.Win', 'IngresosPorFichas', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'IngresosPorFichas' AS Pantalla FROM dbo.Roles
GO                          

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('CartasPendientes', 'Envio de Cartas para CLientes Deudores', 'Envio de Cartas para CLientes Deudores', 
    'True', 'False', 'True', 'True', 'Fichas', 50,'Eniac.Fichas.Win', 'CartasPendientes', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CartasPendientes' AS Pantalla FROM dbo.Roles
GO                          

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('PagosPendientes', 'Pagos Pendientes', 'Pagos Pendientes', 
    'True', 'False', 'True', 'True', 'Fichas', 60,'Eniac.Fichas.Win', 'PagosPendientes', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'PagosPendientes' AS Pantalla FROM dbo.Roles
GO                          

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('FichasCtaCte', 'Fichas - Cuenta Corriente', 'Fichas - Cuenta Corriente', 
    'True', 'False', 'True', 'True', 'Fichas', 70,'Eniac.Fichas.Win', 'FichasCtaCte', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FichasCtaCte' AS Pantalla FROM dbo.Roles
GO                          


---- Boton Devolver Pago ---

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('DevolverPago', 'Devolver Pago', 'Devolver Pago', 
    'False', 'False', 'True', 'True', 'FichasABM', 10,'Eniac.Fichas.Win', 'DevolverPago', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'DevolverPago' AS Pantalla FROM dbo.Roles
GO                          
