DECLARE @renumero int
SET @renumero = (SELECT COUNT(1) FROM (SELECT IdEmpleado, COUNT(1) Cantidad FROM Empleados GROUP BY IdEmpleado HAVING COUNT(1) > 1) A)

PRINT ''
PRINT '1. Normaliza IdEmpleado de clientes que lo tienen duplicados'
PRINT '   Existen registros con IdEmpleado duplicado: ' + CASE WHEN @renumero = 0 THEN 'NO' ELSE 'SI' END
IF @renumero > 0
BEGIN
    --UPDATE Empleados
    --   SET IdEmpleado = ROW_NUMBER() OVER (ORDER BY NroDocEmpleado);
    --SELECT N.*, E.*
    UPDATE E
       SET IdEmpleado = N.IdEmpleadoNuevo
      FROM Empleados E
     INNER JOIN (SELECT IdEmpleado, TipoDocEmpleado, NroDocEmpleado , ROW_NUMBER() OVER (ORDER BY NroDocEmpleado) IdEmpleadoNuevo FROM Empleados) N 
             ON N.TipoDocEmpleado = E.TipoDocEmpleado AND N.NroDocEmpleado = E.NroDocEmpleado
END
