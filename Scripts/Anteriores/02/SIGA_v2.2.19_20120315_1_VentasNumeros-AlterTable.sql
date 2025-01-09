
ALTER TABLE dbo.VentasNumeros ADD Fecha date NULL
GO

-- Actualizo la ultima Fecha desde las Ventas
UPDATE dbo.VentasNumeros
 SET Fecha = ( SELECT MAX(Fecha) FROM Ventas V
                WHERE V.IdSucursal = VentasNumeros.IdSucursal
                  AND V.IdTipoComprobante = VentasNumeros.IdTipoComprobante
                  AND V.Letra = VentasNumeros.LetraFiscal
                  AND V.CentroEmisor = VentasNumeros.CentroEmisor
                  AND V.NumeroComprobante = VentasNumeros.Numero
              )
GO

-- Actualizo la Fecha entre comprobantes que comparten numeracion
UPDATE dbo.VentasNumeros
 SET Fecha = ( SELECT MAX(Fecha) FROM VentasNumeros VN
                WHERE VN.IdSucursal = VentasNumeros.IdSucursal
                  AND VN.LetraFiscal = VentasNumeros.LetraFiscal
                  AND VN.CentroEmisor = VentasNumeros.CentroEmisor
                  AND VN.LetraFiscal IN ('A', 'B')
                  AND VN.IdTipoComprobante IN ('FACT', 'NCRED', 'NDEB', 'NDEBCHEQRECH')
              )
 WHERE LetraFiscal IN ('A', 'B')
   AND IdTipoComprobante IN ('FACT', 'NCRED', 'NDEB', 'NDEBCHEQRECH')
   AND IdTipoComprobanteRelacionado IS NOT NULL
GO

-- Actualizo la Fecha al resto
UPDATE dbo.VentasNumeros set Fecha = '1900-01-01' --GETDATE()
  WHERE Fecha IS NULL
GO

ALTER TABLE dbo.VentasNumeros ALTER COLUMN Fecha date NOT NULL 
GO
