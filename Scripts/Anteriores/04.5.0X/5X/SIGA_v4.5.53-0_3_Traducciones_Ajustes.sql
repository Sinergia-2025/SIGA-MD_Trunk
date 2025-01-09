DECLARE @idAplicacion varchar(MAX)
SET @idAplicacion = (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'IDAPLICACION')

INSERT INTO Traducciones
           (IdFuncion,Pantalla,Control,IdIdioma,Texto)
SELECT 'PresupuestosClientesV2', 'PedidosClientesV2', Control, IdIdioma, Texto
  FROM Traducciones
 WHERE IdFuncion = 'PresupuestosClientesV2'
INSERT INTO Traducciones
           (IdFuncion,Pantalla,Control,IdIdioma,Texto)
SELECT 'PresupuestosClientesV2', 'PedidosClientesV2', Control, IdIdioma, Texto
  FROM Traducciones
 WHERE Pantalla = 'PedidosClientesV2' AND IdFuncion = @idAplicacion
UPDATE Traducciones
   SET IdFuncion = 'PresupuestosAdmin'
     , Pantalla = 'PedidosClientesV2'
  FROM Traducciones
 WHERE IdFuncion = 'PresupuestosClientesV2' AND Pantalla = ''
UPDATE Traducciones
   SET IdFuncion = 'PresupuestosAdmin'
     , Pantalla = 'PedidosClientesV2'
  FROM Traducciones
 WHERE Pantalla = 'PedidosClientesV2' AND IdFuncion = @idAplicacion
GO
