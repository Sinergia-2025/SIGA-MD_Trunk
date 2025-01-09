--Inserto el Campo de Pantalla
INSERT INTO Funciones (Id, Nombre, Descripcion
                      ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES ('Proveedores-NivelAutorizacion', 'Proveedores: Nivel de Autorizacion', 'Proveedores: Nivel de Autorizacion', 
         'False', 'False', 'True', 'True', 'Proveedores', 999, 'Eniac.Win', 'Proveedores-NivelAutorizacion', NULL)
;
INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT IdRol, 'Proveedores-NivelAutorizacion' FROM RolesFunciones WHERE IdFuncion = 'Proveedores'
;

INSERT INTO Funciones (Id, Nombre, Descripcion
                      ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES ('Empleados-NivelAutorizacion', 'Empleados: Nivel de Autorizacion', 'Empleados: Nivel de Autorizacion', 
         'False', 'False', 'True', 'True', 'Empleados', 999, 'Eniac.Win', 'Empleados-NivelAutorizacion', NULL)
;
INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT IdRol, 'Empleados-NivelAutorizacion' FROM RolesFunciones WHERE IdFuncion = 'Empleados'
;

INSERT INTO Funciones (Id, Nombre, Descripcion
                      ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES ('Comprobantes-NivelAutorizacion', 'Tipos Comprobantes: Nivel de Autorizacion', 'Tipos Comprobantes: Nivel de Autorizacion', 
         'False', 'False', 'True', 'True', 'TiposComprobantesABM', 999, 'Eniac.Win', 'Comprobantes-NivelAutorizacion', NULL)
;
INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT IdRol, 'Comprobantes-NivelAutorizacion' FROM RolesFunciones WHERE IdFuncion = 'TiposComprobantesABM'
;

SELECT * FROM RolesFunciones WHERE IdFuncion IN ('Proveedores-NivelAutorizacion','Empleados-NivelAutorizacion','Comprobantes-NivelAutorizacion') ORDER BY IdFuncion, IdRol
;
