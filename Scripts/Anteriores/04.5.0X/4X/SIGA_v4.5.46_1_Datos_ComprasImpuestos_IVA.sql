
--SELECT COUNT(*) FROM ComprasImpuestos;

PRINT '1. ComprasImpuestos: Inserto lo de IVA 21%'

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe, EsDespacho)
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
PRINT '2. ComprasImpuestos: Inserto lo de IVA 27%'

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho)
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
PRINT '3. ComprasImpuestos: Inserto lo de IVA 10.5%'

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho)
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
PRINT '4. ComprasImpuestos: Inserto lo de IVA No Gravado'

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe,EsDespacho)
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

--SELECT COUNT(*) FROM ComprasImpuestos;
