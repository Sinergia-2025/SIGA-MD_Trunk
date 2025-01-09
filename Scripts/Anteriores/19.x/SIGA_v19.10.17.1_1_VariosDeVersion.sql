PRINT '1. Renombrar  Reportes BBP AMOBLAMIENTOS S.R.L..'
IF dbo.BaseConCuit('33714918449') = 1
BEGIN

   EXECUTE [dbo].[RenombrarReporte] 'Eniac.Win.eComprobanteCredito.rdlc', '187_eComprobanteCredito.rdlc', 'N'
   EXECUTE [dbo].[RenombrarReporte] 'Eniac.Win.eComprabanteCreditoDolares.rdlc', '187_eComprobanteCreditoDolares.rdlc', 'N'

END
