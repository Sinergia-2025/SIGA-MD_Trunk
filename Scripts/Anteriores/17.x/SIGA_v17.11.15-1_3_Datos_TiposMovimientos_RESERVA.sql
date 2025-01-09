INSERT INTO TiposMovimientos
           (IdTipoMovimiento,Descripcion,CoeficienteStock,ComprobantesAsociados,AsociaSucursal
           ,MuestraCombo,HabilitaDestinatario,HabilitaRubro,Imprime,CargaPrecio
           ,IdContraTipoMovimiento,HabilitaEmpleado,ReservaMercaderia)
     VALUES
           ('RESERVA','Reserva de mercadería',-1,NULL,'False'
           ,'False','False','False','False','PrecioCosto'
           ,NULL,'False','True')
GO
