
--Inserto la Pantalla Nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfSaldosPorVencimientos', 'Informe de Saldos Por Vencimientos', 'Informe de Saldos Por Vencimientos', 
      'True', 'False', 'True', 'True',
      'CuentasCorrientes', 35, 'Eniac.Win', 'InfSaldosPorVencimientos', NULL)
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfSaldosPorVencimientos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
