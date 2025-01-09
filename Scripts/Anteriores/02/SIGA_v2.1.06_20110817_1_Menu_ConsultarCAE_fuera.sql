
DELETE RolesFunciones
  WHERE IdFuncion = 'ConsultarCAE' --AND IdRol <> 'Adm'
GO

UPDATE Funciones SET Posicion = 20
  WHERE Id = 'ConsultarUltimoComprobante'
GO

UPDATE Funciones SET Posicion = 30
  WHERE Id = 'ConsultarComprobantesEmitidos'
GO
