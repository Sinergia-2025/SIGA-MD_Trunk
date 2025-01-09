
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InconsistCtaCtevsCtaCtePagos', 'Alerta Constrol Inconsistencias CtaCte vs CtaCtePagos', 'Alerta Constrol Inconsistencias CtaCte vs CtaCtePagos', 'False', 'False', 'True', 'False', 
      'CuentasCorrientes', 999, 'Eniac.Win', 'InconsistCtaCtevsCtaCtePagos', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InconsistCtaCtevsCtaCtePagos' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
