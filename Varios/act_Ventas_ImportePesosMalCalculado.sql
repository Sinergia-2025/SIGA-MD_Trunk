
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
      ,Fecha, ImporteTotal
      ,ImportePesos
      ,ImporteTickets
      ,ImporteTarjetas
      ,ImporteCheques
      ,IdFormasPago
      ,IdCaja
      ,NumeroPlanilla
      ,NumeroMovimiento
  FROM Ventas
  WHERE ImportePesos>0 and (ImporteTarjetas>0 or ImporteCheques>0 or ImporteTickets>0)
 GO
 
UPDATE Ventas
  SET ImportePesos = ImporteTotal - ImporteTarjetas - ImporteCheques - ImporteTickets
  WHERE ImportePesos>0 and (ImporteTarjetas>0 or ImporteCheques>0 or ImporteTickets>0)
GO
