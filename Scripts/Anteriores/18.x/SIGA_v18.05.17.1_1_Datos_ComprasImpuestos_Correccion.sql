
PRINT ''
PRINT '1. Tabla ComprasImpuestos: Inserto los Registros Faltantes de Percepciones de IVA.'
GO

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho
           ,Bruto)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'PIVA' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , 0 BaseImponible, 0 Alicuota, PercepcionIVA, 0
     , 0
  FROM Compras C
 WHERE PercepcionIVA <> 0
   AND NOT EXISTS (SELECT * FROM ComprasImpuestos CI
                           WHERE CI.IdSucursal = C.IdSucursal
                             AND CI.IdTipoComprobante = C.IdTipoComprobante
                             AND CI.Letra = C.Letra
                             AND CI.CentroEmisor = C.CentroEmisor
                             AND CI.NumeroComprobante = C.NumeroComprobante
                             AND CI.IdProveedor = C.IdProveedor
                             AND CI.IdTipoImpuesto = 'PIVA')
GO


PRINT ''
PRINT '2. Tabla ComprasImpuestos: Inserto los Registros Faltantes de Percepciones de Ganancias.'
GO

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho
           ,Bruto)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'PGANA' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , 0 BaseImponible, 0 Alicuota, PercepcionGanancias,0
     , 0
  FROM Compras C
 WHERE PercepcionGanancias <> 0
   AND NOT EXISTS (SELECT * FROM ComprasImpuestos CI
                           WHERE CI.IdSucursal = C.IdSucursal
                             AND CI.IdTipoComprobante = C.IdTipoComprobante
                             AND CI.Letra = C.Letra
                             AND CI.CentroEmisor = C.CentroEmisor
                             AND CI.NumeroComprobante = C.NumeroComprobante
                             AND CI.IdProveedor = C.IdProveedor
                             AND CI.IdTipoImpuesto = 'PGANA')
GO


PRINT ''
PRINT '3. Tabla ComprasImpuestos: Inserto los Registros Faltantes de Percepciones Varias.'
GO

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho
           ,Bruto)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'PVAR' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , 0 BaseImponible, 0 Alicuota, PercepcionVarias,0
     , 0
  FROM Compras C
 WHERE PercepcionVarias <> 0
   AND NOT EXISTS (SELECT * FROM ComprasImpuestos CI
                           WHERE CI.IdSucursal = C.IdSucursal
                             AND CI.IdTipoComprobante = C.IdTipoComprobante
                             AND CI.Letra = C.Letra
                             AND CI.CentroEmisor = C.CentroEmisor
                             AND CI.NumeroComprobante = C.NumeroComprobante
                             AND CI.IdProveedor = C.IdProveedor
                             AND CI.IdTipoImpuesto = 'PVAR')
GO


PRINT ''
PRINT '4. Tabla ComprasImpuestos: Inserto los Registros Faltantes de Percepciones de IIBB.'
GO

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho
           ,Bruto)
SELECT C.IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'PIIBB' IdTipoImpuesto, L.IdProvincia IdProvincia, NULL Emisor, NULL Numero
     , 0 BaseImponible, 0 Alicuota, PercepcionIB,0
     , 0
  FROM Compras C
 INNER JOIN Sucursales S ON S.Id = C.IdSucursal
 INNER JOIN Localidades L ON L.IdLocalidad = S.IdLocalidad
 WHERE PercepcionIB <> 0
   AND NOT EXISTS (SELECT * FROM ComprasImpuestos CI
                           WHERE CI.IdSucursal = C.IdSucursal
                             AND CI.IdTipoComprobante = C.IdTipoComprobante
                             AND CI.Letra = C.Letra
                             AND CI.CentroEmisor = C.CentroEmisor
                             AND CI.NumeroComprobante = C.NumeroComprobante
                             AND CI.IdProveedor = C.IdProveedor
                             AND CI.IdTipoImpuesto = 'PIIBB')
GO


PRINT ''
PRINT '5. Tabla ComprasImpuestos: Inserto los Registros Faltantes de IVA 21%.'
GO

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe, EsDespacho
           ,Bruto)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'IVA' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , Neto210, 21 Alicuota, IVA210, 0
     , C.Neto210 / (1 + (C.DescuentoRecargoPorc / 100))
  FROM Compras C
 WHERE C.IVA210 <> 0
   AND NOT EXISTS (SELECT * FROM ComprasImpuestos CI
                           WHERE CI.IdSucursal = C.IdSucursal
                             AND CI.IdTipoComprobante = C.IdTipoComprobante
                             AND CI.Letra = C.Letra
                             AND CI.CentroEmisor = C.CentroEmisor
                             AND CI.NumeroComprobante = C.NumeroComprobante
                             AND CI.IdProveedor = C.IdProveedor
                             AND CI.IdTipoImpuesto = 'IVA'
                             AND CI.Alicuota = 21)
GO

PRINT ''
PRINT '6. Tabla ComprasImpuestos: Inserto los Registros Faltantes de IVA 27%.'
GO

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho
           ,Bruto)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'IVA' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , Neto270, 27 Alicuota, IVA270, 0
     , C.Neto270 / (1 + (C.DescuentoRecargoPorc / 100))
  FROM Compras C
 WHERE IVA270 <> 0
   AND NOT EXISTS (SELECT * FROM ComprasImpuestos CI
                           WHERE CI.IdSucursal = C.IdSucursal
                             AND CI.IdTipoComprobante = C.IdTipoComprobante
                             AND CI.Letra = C.Letra
                             AND CI.CentroEmisor = C.CentroEmisor
                             AND CI.NumeroComprobante = C.NumeroComprobante
                             AND CI.IdProveedor = C.IdProveedor
                             AND CI.IdTipoImpuesto = 'IVA'
                             AND CI.Alicuota = 27)
GO

PRINT ''
PRINT '7. Tabla ComprasImpuestos: Inserto los Registros Faltantes de IVA 10.50%.'
GO

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho
           ,Bruto)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'IVA' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , Neto105, 10.5 Alicuota, IVA105, 0
     , C.Neto105 / (1 + (C.DescuentoRecargoPorc / 100))
  FROM Compras C
 WHERE IVA105 <> 0
   AND NOT EXISTS (SELECT * FROM ComprasImpuestos CI
                           WHERE CI.IdSucursal = C.IdSucursal
                             AND CI.IdTipoComprobante = C.IdTipoComprobante
                             AND CI.Letra = C.Letra
                             AND CI.CentroEmisor = C.CentroEmisor
                             AND CI.NumeroComprobante = C.NumeroComprobante
                             AND CI.IdProveedor = C.IdProveedor
                             AND CI.IdTipoImpuesto = 'IVA'
                             AND CI.Alicuota = 10.5)
GO


PRINT ''
PRINT '8. Tabla ComprasImpuestos: Inserto los Registros Faltantes de IVA No Gravado.'
GO

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho
           ,Bruto)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'IVA' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , NetoNoGravado, 0 Alicuota, 0, 0
     , C.NetoNoGravado / (1 + (C.DescuentoRecargoPorc / 100))
  FROM Compras C
 WHERE NetoNoGravado <> 0
   AND NOT EXISTS (SELECT * FROM ComprasImpuestos CI
                           WHERE CI.IdSucursal = C.IdSucursal
                             AND CI.IdTipoComprobante = C.IdTipoComprobante
                             AND CI.Letra = C.Letra
                             AND CI.CentroEmisor = C.CentroEmisor
                             AND CI.NumeroComprobante = C.NumeroComprobante
                             AND CI.IdProveedor = C.IdProveedor
                             AND CI.IdTipoImpuesto = 'IVA'
                             AND CI.Alicuota = 0)
GO
