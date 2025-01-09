
---Opcion de Menu

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ContabilidadCuentasMediosDPago', 'Configurar Cuentas por Medio de Pago', 'Configurar Cuentas por Medio de Pago', 'True', 'False', 'True',
      'True', 'Contabilidad', 260, 'Eniac.Win', 'ContabilidadCuentasMediosDePago', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCuentasMediosDPago' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
