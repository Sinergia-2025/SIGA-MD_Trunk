
ALTER TABLE CuentasCorrientes ADD IdClienteCtaCte bigint null
GO


UPDATE CuentasCorrientes 
   SET CuentasCorrientes.IdClienteCtaCte = (CASE WHEN C.IdClienteCtaCte IS NULL THEN C.IdCliente ELSE C.IdClienteCtaCte END)
 FROM CuentasCorrientes CC 
 INNER JOIN CLientes C ON CC.IdCliente = C.IdCliente
GO

--SELECT * from CuentasCorrientes
-- WHERE IdClienteCtaCte IS NULL
--GO




----actualizo los registros que tienen el IDClienteCtaCte en nulo
--BEGIN;
---- Variables para obtencion de datos en el cursor
--DECLARE @IDCLIENTE BIGINT, @IDCLIENTECTACTE BIGINT;
---- Declaración del cursor
--DECLARE cursor_emp CURSOR STATIC
--FOR SELECT idCliente, idClienteCtaCte 
--FROM Clientes where IdClienteCtaCte is null;
---- Apertura del cursor
--OPEN cursor_emp;
---- Primer resultado del FETCH
--FETCH cursor_emp INTO @IDCLIENTE, @IDCLIENTECTACTE;
----Bucle de lectura
--WHILE (@@FETCH_STATUS = 0 )
--       BEGIN;
--       -- Transferir los registros a la nueva tabla
--       UPDATE CuentasCorrientes SET IdClienteCtaCte = @IDCLIENTE WHERE Idcliente = @IDCLIENTE;
--       -- enesima iteración sobre el cursor
--       FETCH cursor_emp INTO @IDCLIENTE, @IDCLIENTECTACTE;
--END;
---- Cierre del cursor
--CLOSE cursor_emp;
---- Limpieza
--DEALLOCATE cursor_emp;

--END;

-----------------------------------------------------------------------------------------------------------------
----actualizo los registros que tienen el IDClienteCtaCte con valor
--BEGIN;
---- Variables para obtencion de datos en el cursor
--DECLARE @IDCLIENTE1 BIGINT, @IDCLIENTECTACTE1 BIGINT;
---- Declaración del cursor
--DECLARE cursor_emp CURSOR STATIC
--FOR SELECT idCliente, idClienteCtaCte 
--FROM Clientes where IdClienteCtaCte is not null;
---- Apertura del cursor
--OPEN cursor_emp;
---- Primer resultado del FETCH
--FETCH cursor_emp INTO @IDCLIENTE1, @IDCLIENTECTACTE1;
----Bucle de lectura
--WHILE (@@FETCH_STATUS = 0 )
--       BEGIN;
--       -- Transferir los registros a la nueva tabla
--       UPDATE CuentasCorrientes SET IdClienteCtaCte = @IDCLIENTECTACTE1 WHERE Idcliente = @IDCLIENTE1;
--       -- enesima iteración sobre el cursor
--       FETCH cursor_emp INTO @IDCLIENTE1, @IDCLIENTECTACTE1;
--END;
---- Cierre del cursor
--CLOSE cursor_emp;
---- Limpieza
--DEALLOCATE cursor_emp;

--END;

----select IdClienteCtaCte from cuentascorrientes

