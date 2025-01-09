
PRINT '1. Tabla CuentasCorrientes: Actualizo campo IdCobrador/IdEstadoCliente en NULL.'
GO

UPDATE CuentasCorrientes 
   SET IdCobrador = NULL
      ,IdEstadoCliente = NULL
GO


PRINT ''
PRINT '2. Tabla CuentasCorrientes: Actualizo campo IdCobrador segun AuditoriasClientes.'
GO

-- declaramos las variables
declare @idSucursal as int
declare @idTipoComp as varchar(15)
declare @letra as varchar(1)
declare @centroEmisor as int
declare @numeroCompro as bigint
declare @fecha as datetime
declare @idCli as int


-- declaramos un cursor llamado "CURSORITO". 
DECLARE CURSORITO CURSOR FOR

SELECT IdSucursal, CC.IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Fecha, IdCliente
  FROM CuentasCorrientes CC
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante AND TC.EsRecibo = 'True'  

open CURSORITO

-- Avanzamos un registro y cargamos en las variables los valores encontrados en el primer registro

fetch next from CURSORITO

into @idSucursal, @idTipoComp, @letra, @centroEmisor, @numeroCompro, @fecha, @idCli
  while @@fetch_status = 0

begin

	update CuentasCorrientes 
		set IdCobrador = (SELECT TOP(1) IdCobrador
								FROM AuditoriaClientes AC
								WHERE AC.IdCliente = @idCli
								  AND AC.FechaAuditoria <= @fecha
								  AND AC.IdCobrador IS NOT NULL
								ORDER BY FechaAuditoria DESC)

			where idsucursal = @idSucursal
			 and idtipocomprobante = @idTipoComp
			 and letra = @letra
			 and CentroEmisor = @centroEmisor
			 and numerocomprobante = @numeroCompro
		 
-- Avanzamos otro registro
fetch next from CURSORITO
into @idSucursal, @idTipoComp, @letra, @centroEmisor, @numeroCompro, @fecha, @idCli
end

-- cerramos el cursor
    close CURSORITO
deallocate CURSORITO



PRINT ''
PRINT '3. Tabla CuentasCorrientes: Actualizo campo IdEstadoCliente segun AuditoriasClientes.'
GO

-- declaramos las variables
declare @idSucursal as int
declare @idTipoComp as varchar(15)
declare @letra as varchar(1)
declare @centroEmisor as int
declare @numeroCompro as bigint
declare @fecha as datetime
declare @idCli as int


-- declaramos un cursor llamado "CURSORITO". 
DECLARE CURSORITO CURSOR FOR

SELECT IdSucursal, CC.IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Fecha, IdCliente
  FROM CuentasCorrientes CC
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante AND TC.EsRecibo = 'True'  

open CURSORITO

-- Avanzamos un registro y cargamos en las variables los valores encontrados en el primer registro

fetch next from CURSORITO

into @idSucursal, @idTipoComp, @letra, @centroEmisor, @numeroCompro, @fecha, @idCli
  while @@fetch_status = 0

begin

	update CuentasCorrientes 
		set IdEstadoCliente = (SELECT TOP(1) IdEstado
								FROM AuditoriaClientes AC
								WHERE AC.IdCliente = @idCli
								  AND AC.FechaAuditoria <= @fecha
								  AND AC.IdEstado IS NOT NULL
								ORDER BY FechaAuditoria DESC)

			where idsucursal = @idSucursal
			 and idtipocomprobante = @idTipoComp
			 and letra = @letra
			 and CentroEmisor = @centroEmisor
			 and numerocomprobante = @numeroCompro
		 
-- Avanzamos otro registro
fetch next from CURSORITO
into @idSucursal, @idTipoComp, @letra, @centroEmisor, @numeroCompro, @fecha, @idCli
end

-- cerramos el cursor
    close CURSORITO
deallocate CURSORITO


PRINT ''
PRINT '4. Tabla CuentasCorrientes: Actualizo campo IdCobrador con el valor mas antiguo segun AuditoriasClientes.'
GO

UPDATE CuentasCorrientes
   SET IdCobrador = AC.IdCobradorNuevo
  FROM (SELECT CC.IdCliente 
             ,(SELECT TOP(1) IdCobrador
	            FROM AuditoriaClientes AC
                WHERE AC.IdCliente = CC.IdCliente
                  AND AC.IdCobrador IS NOT NULL
	           ORDER BY FechaAuditoria) IdCobradorNuevo
         FROM CuentasCorrientes CC
              ) AC
 INNER JOIN CuentasCorrientes CC ON CC.IdCliente = AC.IdCliente
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante= CC.IdTipoComprobante AND TC.EsRecibo = 'True'
 WHERE CC.IdCobrador IS NULL AND AC.IdCobradorNuevo IS NOT NULL
GO


PRINT ''
PRINT '5. Tabla CuentasCorrientes: Actualizo campo IdCobrador con el valor mas antiguo segun AuditoriasClientes.'
GO

UPDATE CuentasCorrientes
   SET IdEstadoCliente = AC.IdEstadoNuevo
  FROM (SELECT CC.IdCliente 
             ,(SELECT TOP(1) IdEstado
	            FROM AuditoriaClientes AC
                WHERE AC.IdCliente = CC.IdCliente
                  AND AC.IdEstado IS NOT NULL
	           ORDER BY FechaAuditoria) IdEstadoNuevo
         FROM CuentasCorrientes CC
              ) AC
 INNER JOIN CuentasCorrientes CC ON CC.IdCliente = AC.IdCliente
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante= CC.IdTipoComprobante AND TC.EsRecibo = 'True'
 WHERE CC.IdEstadoCliente IS NULL AND AC.IdEstadoNuevo IS NOT NULL
GO


PRINT ''
PRINT '6. Tabla CuentasCorrientes: Actualizo campo IdCobrador con el valor actual para los NULL'
GO

UPDATE CuentasCorrientes 
   SET CuentasCorrientes.IdCobrador = C.IdCobrador
 FROM CuentasCorrientes CC
 INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante= CC.IdTipoComprobante AND TC.EsRecibo = 'True'
 WHERE CC.IdCobrador IS NULL
GO


PRINT ''
PRINT '7. Tabla CuentasCorrientes: Actualizo campo IdEstadoCliente con el valor actual para los NULL'
GO

UPDATE CuentasCorrientes 
   SET CuentasCorrientes.IdEstadoCliente = C.IdEstado
 FROM CuentasCorrientes CC
 INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante= CC.IdTipoComprobante AND TC.EsRecibo = 'True'
 WHERE CC.IdEstadoCliente IS NULL
GO
