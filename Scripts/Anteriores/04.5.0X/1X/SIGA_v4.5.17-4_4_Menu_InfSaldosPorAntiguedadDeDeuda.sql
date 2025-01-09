
--Inserto la Pantalla Nueva y luego piso la anterior porque cambio la funcionalidad.

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfSaldosPorAntiguedadDeDeuda', 'Informe de Saldos Por Antigüedad de Deuda', 'Informe de Saldos Por Antigüedad de Deuda', 
      'True', 'False', 'True', 'True',
      'CuentasCorrientes', 35, 'Eniac.Win', 'InfSaldosPorAntiguedadDeDeuda', NULL)
GO

UPDATE RolesFunciones 
   SET IdFuncion = 'InfSaldosPorAntiguedadDeDeuda'
  WHERE IdFuncion = 'InfSaldosPorVencimientos' 
GO

DELETE Funciones
 WHERE Id = 'InfSaldosPorVencimientos' 
GO
