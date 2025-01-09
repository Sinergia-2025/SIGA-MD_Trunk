
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InconsCtaCteProvVsCtaCtePagos', 'Alerta Control Inconsistencias CtaCte Prov. vs CtaCtePagos', 'Alerta Constrol Inconsistencias CtaCte vs CtaCtePagos', 'False', 'False', 'True', 'False', 
      'CuentasCorrientesProveedores', 999, 'Eniac.Win', 'InconsCtaCteProvVsCtaCtePagos', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InconsCtaCteProvVsCtaCtePagos' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
