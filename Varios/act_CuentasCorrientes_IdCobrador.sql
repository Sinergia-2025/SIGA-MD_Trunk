
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

