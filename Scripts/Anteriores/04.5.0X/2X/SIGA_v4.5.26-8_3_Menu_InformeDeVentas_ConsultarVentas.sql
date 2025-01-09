
UPDATE Funciones 
   SET EsBoton = (SELECT EsBoton FROM Funciones WHERE id = 'ConsultarVentas')
      WHERE id = 'InformeDeVentas'
GO

DELETE RolesFunciones WHERE idFuncion = 'ConsultarVentas' 
GO

DELETE Funciones WHERE id = 'ConsultarVentas' 
GO
