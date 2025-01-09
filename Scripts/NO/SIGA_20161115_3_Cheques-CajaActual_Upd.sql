UPDATE Cheques
   SET IdCajaActual         = IdCajaIngreso
      ,NroPlanillaActual    = NroPlanillaIngreso
      ,NroMovimientoActual  = NroMovimientoIngreso
 WHERE IdEstadoCheque = 'ENCARTERA'
   AND IdCajaEgreso IS NULL

UPDATE Cheques
   SET IdCajaActual         = IdCajaEgreso
      ,NroPlanillaActual    = NroPlanillaEgreso
      ,NroMovimientoActual  = NroMovimientoEgreso
      ,IdCajaEgreso         = NULL
      ,NroPlanillaEgreso    = NULL
      ,NroMovimientoEgreso  = NULL
 WHERE IdEstadoCheque = 'ENCARTERA'
   AND IdCajaEgreso IS NOT NULL

