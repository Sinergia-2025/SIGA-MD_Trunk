--Quito la pantalla en desuso
DELETE [dbo].RolesFunciones WHERE IdFuncion = 'ContabilidadPlanCuentasDetalle'
GO
DELETE [dbo].Funciones WHERE Id = 'ContabilidadPlanCuentasDetalle'
GO

-- Inserto la Pantalla que la reemplaza.
INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadPlanesCuentasPV', 'Consultar Plan de Cuentas por Jerarquia', 'Consultar Plan de Cuentas por Jerarquia', 'True', 'False', 'True', 'True', 
          'Contabilidad', 150, 'Eniac.Win', 'ContabilidadPlanesCuentasPreView', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadPlanesCuentasPV' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
