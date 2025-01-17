DECLARE @IdSucOrigen INT = 2
DECLARE @IdSucDestino INT = 3
;

PRINT ''
PRINT '1. Elimino Cajas.'
;
DELETE SIGA_Separada.dbo.Cajas
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '2. Elimino CajasUsuarios.'
;

DELETE SIGA_Separada.dbo.CajasUsuarios
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '3. Elimino CajasNombres.'
;

DELETE SIGA_Separada.dbo.CajasNombres
 WHERE IdSucursal = @IdSucDestino
;

PRINT ''
PRINT '4. Inserto CajasNombres.'
;
INSERT INTO SIGA_Separada.dbo.CajasNombres
           (IdSucursal
           ,IdCaja
           ,NombreCaja
           ,NombrePC
           ,IdPlanCuenta
           ,TopeAviso
           ,TopeBloqueo
           ,IdCuentaContable
           ,IdUsuario)
SELECT @IdSucDestino AS IdSucursal
           ,IdCaja
           ,NombreCaja
           ,NombrePC
           ,IdPlanCuenta
           ,TopeAviso
           ,TopeBloqueo
           ,IdCuentaContable
           ,IdUsuario
  FROM SIGA.dbo.CajasNombres CN
  WHERE CN.IdSucursal = @IdSucOrigen
;

PRINT ''
PRINT '5. Inserto CajasUsuarios.'
;
INSERT INTO SIGA_Separada.dbo.CajasUsuarios
           (IdSucursal
           ,IdCaja
           ,IdUsuario
           ,PermitirEscritura)
SELECT @IdSucDestino AS IdSucursal
           ,IdCaja
           ,IdUsuario
           ,PermitirEscritura
  FROM SIGA.dbo.CajasUsuarios CU
  WHERE CU.IdSucursal = @IdSucOrigen
;

PRINT ''
PRINT '6. Inserto Cajas.'
;
INSERT INTO SIGA_Separada.dbo.Cajas
           (IdSucursal
           ,IdCaja
           ,NumeroPlanilla
           ,FechaPlanilla
           ,PesosSaldoInicial
           ,PesosSaldoFinal
           ,DolaresSaldoInicial
           ,DolaresSaldoFinal
           ,EurosSaldoInicial
           ,EurosSaldoFinal
           ,ChequesSaldoInicial
           ,ChequesSaldoFinal
           ,TarjetasSaldoInicial
           ,TarjetasSaldoFinal
           ,TicketsSaldoInicial
           ,TicketsSaldoFinal
           ,PesosSaldoFinalDigit
           ,DolaresSaldoFinalDigit
           ,ChequesSaldoFinalDigit
           ,TarjetasSaldoFinalDigit
           ,TicketsSaldoFinalDigit
           ,BancosSaldoInicial
           ,BancosSaldoFinal
           ,BancosSaldoFinalDigit
           ,RetencionesSaldoInicial
           ,RetencionesSaldoFinal
           ,RetencionesSaldoFinalDigit)
SELECT @IdSucDestino AS IdSucursal
           ,IdCaja
           ,NumeroPlanilla
           ,FechaPlanilla
           ,PesosSaldoInicial
           ,PesosSaldoFinal
           ,DolaresSaldoInicial
           ,DolaresSaldoFinal
           ,EurosSaldoInicial
           ,EurosSaldoFinal
           ,ChequesSaldoInicial
           ,ChequesSaldoFinal
           ,TarjetasSaldoInicial
           ,TarjetasSaldoFinal
           ,TicketsSaldoInicial
           ,TicketsSaldoFinal
           ,PesosSaldoFinalDigit
           ,DolaresSaldoFinalDigit
           ,ChequesSaldoFinalDigit
           ,TarjetasSaldoFinalDigit
           ,TicketsSaldoFinalDigit
           ,BancosSaldoInicial
           ,BancosSaldoFinal
           ,BancosSaldoFinalDigit
           ,RetencionesSaldoInicial
           ,RetencionesSaldoFinal
           ,RetencionesSaldoFinalDigit
  FROM SIGA.dbo.Cajas C
  WHERE C.IdSucursal = @IdSucOrigen
;
