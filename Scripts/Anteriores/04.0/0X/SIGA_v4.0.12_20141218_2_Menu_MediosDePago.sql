
DELETE RolesFunciones WHERE Idfuncion = 'ContabilidadCuentasMediosDPago'
GO
DELETE funciones WHERE Id = 'ContabilidadCuentasMediosDPago'
GO

--Insertar Menu

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('MediosdePagoABM', 'Medios de Pago', 'Medios de Pago', 'True', 'False', 'True',
      'True', 'Archivos', 85, 'Eniac.Win', 'MediosdePagoABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'MediosdePagoABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
