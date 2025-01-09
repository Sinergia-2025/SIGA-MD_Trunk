UPDATE Compras
   SET IdEmpresa = 1
 WHERE ISNULL(PeriodoFiscal, 0) <> 0
   AND IdEmpresa IS NULL
