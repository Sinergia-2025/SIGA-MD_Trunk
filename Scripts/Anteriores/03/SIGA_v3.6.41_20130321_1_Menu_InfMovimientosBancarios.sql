
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('InfMovimientosBancarios', 'Informe de Movimientos Bancarios', 'Informe de Movimientos Bancarios', 
      'True', 'False', 'True', 'True', 
      'Bancos', 20, 'Eniac.Win', 'InfMovimientosBancarios', NULL)
GO


--Actualizo el nombre de la consulta vieja

UPDATE RolesFunciones 
   SET IdFuncion = 'InfMovimientosBancarios'
 WHERE IdFuncion = 'Movimientos'
GO

--Borro la pantalla que dejo de existir.

DELETE RolesFunciones WHERE IdFuncion = 'MovimientosPosdatados'
GO

DELETE Funciones WHERE Id = 'MovimientosPosdatados'
GO
