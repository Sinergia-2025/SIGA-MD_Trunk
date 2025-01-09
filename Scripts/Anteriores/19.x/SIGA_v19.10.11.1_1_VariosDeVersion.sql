PRINT ''
PRINT '1. Renombrar descripcion del estado 0 Nota de Credito a Devuelto'
UPDATE EstadosVenta
   SET NombreEstadoVenta = 'Devuelto'
 WHERE IdEstadoVenta = 0

PRINT ''
PRINT '2. Menu: Eliminar función Libro De IVA Compras  (v1)'
UPDATE Bitacora
    SET IdFuncion='LibrodeIvaComprasV2'
    WHERE IdFuncion = 'LibrodeIVACompras';
DELETE FROM RolesFunciones 
    WHERE IdFuncion = 'LibrodeIVACompras';
IF dbo.SoyHAR() = 'False'
BEGIN
    DELETE FROM Funciones
     WHERE Id = 'LibrodeIVACompras';
END
