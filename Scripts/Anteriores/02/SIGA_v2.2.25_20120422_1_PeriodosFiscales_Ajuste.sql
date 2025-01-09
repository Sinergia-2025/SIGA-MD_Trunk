
UPDATE PeriodosFiscales
   SET TotalNetoVentas = 0
      ,TotalImpuestosVentas = 0
      ,TotalVentas = 0
      ,TotalNetoCompras = 0
      ,TotalImpuestosCompras = 0
      ,TotalCompras = 0
      ,Posicion = 0
      ,TotalRetenciones = 0
      ,TotalPercepciones = 0
      ,PosicionFinal = 0
GO

/* ------------ Registros de VENTAS ------------ */


--Arreglo las NCRED que tuvieron un problema (unas pocas al inicio de los tiempos) 

IF EXISTS(SELECT * FROM Ventas
           WHERE ImporteTotal < 0 AND SubTotal > 0)

       UPDATE Ventas 
          SET SubTotal = SubTotal * (-1)
             ,TotalImpuestos = TotalImpuestos * (-1)
         WHERE ImporteTotal < 0 AND SubTotal > 0
        
GO


UPDATE PeriodosFiscales
 SET TotalNetoVentas =   
       ( SELECT SUM(Subtotal) FROM Ventas V
         WHERE V.IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
         AND PeriodosFiscales.PeriodoFiscal = YEAR(V.Fecha)*100+MONTH(V.Fecha)
         )
 WHERE PeriodoFiscal IN (SELECT DISTINCT YEAR(Fecha)*100+MONTH(Fecha) FROM Ventas
                                WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True'))
GO

UPDATE PeriodosFiscales
 SET TotalImpuestosVentas =   
       ( SELECT SUM(TotalImpuestos) FROM Ventas V
         WHERE V.IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
         AND PeriodosFiscales.PeriodoFiscal = YEAR(V.Fecha)*100+MONTH(V.Fecha)
         )
 WHERE PeriodoFiscal IN (SELECT DISTINCT YEAR(Fecha)*100+MONTH(Fecha) FROM Ventas
                                WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True'))
GO

UPDATE PeriodosFiscales
 SET TotalVentas =   
       ( SELECT SUM(ImporteTotal) FROM Ventas V
         WHERE V.IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
         AND PeriodosFiscales.PeriodoFiscal = YEAR(V.Fecha)*100+MONTH(V.Fecha)
         )
 WHERE PeriodoFiscal IN (SELECT DISTINCT YEAR(Fecha)*100+MONTH(Fecha) FROM Ventas
                                WHERE IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True'))
GO

UPDATE PeriodosFiscales
 SET PeriodosFiscales.TotalRetenciones =   
       ( SELECT SUM(ImporteTotal) FROM Retenciones R
           WHERE PeriodosFiscales.PeriodoFiscal = YEAR(R.FechaEmision)*100+MONTH(R.FechaEmision)
            AND R.IdTipoImpuesto = 'RIVA'
         ) 
  WHERE PeriodoFiscal IN (SELECT DISTINCT YEAR(FechaEmision)*100+MONTH(FechaEmision) FROM Retenciones WHERE IdTipoImpuesto = 'RIVA')
GO
 

/* ------------ Registros de COMPRAS ------------ */
UPDATE PeriodosFiscales
 SET TotalNetoCompras =   
       ( SELECT SUM(NetoNoGravado+Neto210+Neto105+Neto270) FROM Compras C
         WHERE C.IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
         AND PeriodosFiscales.PeriodoFiscal = C.PeriodoFiscal
         )
 WHERE PeriodoFiscal IN (SELECT DISTINCT PeriodoFiscal FROM Compras)
GO

UPDATE PeriodosFiscales
 SET TotalImpuestosCompras =   
       ( SELECT SUM(IVA210+IVA105+IVA270) FROM Compras C
         WHERE C.IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
         AND PeriodosFiscales.PeriodoFiscal = C.PeriodoFiscal
         )
 WHERE PeriodoFiscal IN (SELECT DISTINCT PeriodoFiscal FROM Compras)
GO

UPDATE PeriodosFiscales
 SET TotalCompras =   
       ( SELECT SUM(ImporteTotal) FROM Compras C
         WHERE C.IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
         AND PeriodosFiscales.PeriodoFiscal = C.PeriodoFiscal
         )
 WHERE PeriodoFiscal IN (SELECT DISTINCT PeriodoFiscal FROM Compras)
GO

UPDATE PeriodosFiscales
 SET TotalPercepciones =   
       ( SELECT SUM(PercepcionIVA) FROM Compras C
         WHERE C.IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE GrabaLibro = 'True')
         AND PeriodosFiscales.PeriodoFiscal = C.PeriodoFiscal
         )
 WHERE PeriodoFiscal IN (SELECT DISTINCT PeriodoFiscal FROM Compras)
GO
/* ------------------------------------------------------------------------------ */

UPDATE PeriodosFiscales
 SET Posicion = TotalImpuestosVentas - TotalImpuestosCompras 
GO

UPDATE PeriodosFiscales SET
    PosicionFinal = Posicion - TotalRetenciones - TotalPercepciones
GO

/* ------------ Dejo abierto el Periodo Fiscal Actual  ------------ */

UPDATE PeriodosFiscales SET 
    FechaCierre = NULL
   ,UsuarioCierre = NULL
 WHERE YEAR(FechaCierre) = YEAR(GETDATE()) AND MONTH(FechaCierre) = MONTH(GETDATE())
GO
