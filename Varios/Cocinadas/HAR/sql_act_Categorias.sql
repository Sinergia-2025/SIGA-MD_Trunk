DECLARE @idCategoriaOrigen int = 2
DECLARE @idCategoriaDestino int = 25

SELECT * FROM Clientes
 WHERE IdCategoria = @idCategoriaOrigen
;

UPDATE Clientes
  SET IdCategoria = @idCategoriaDestino
 WHERE IdCategoria = @idCategoriaOrigen
;

UPDATE CuentasCorrientes
  SET IdCategoria = @idCategoriaDestino
 WHERE IdCategoria = @idCategoriaOrigen
;

UPDATE Ventas
  SET IdCategoria = @idCategoriaDestino
 WHERE IdCategoria = @idCategoriaOrigen
;

UPDATE AuditoriaClientes
  SET IdCategoria = @idCategoriaDestino
 WHERE IdCategoria = @idCategoriaOrigen
;

UPDATE LiquidacionesDetallesClientes
  SET IdCategoria = @idCategoriaDestino
 WHERE IdCategoria = @idCategoriaOrigen
;

UPDATE Prospectos
  SET IdCategoria = @idCategoriaDestino
 WHERE IdCategoria = @idCategoriaOrigen
;
