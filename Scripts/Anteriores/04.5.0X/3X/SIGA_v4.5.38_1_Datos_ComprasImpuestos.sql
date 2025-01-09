
INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'PIVA' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , 0 BaseImponible, 0 Alicuota, PercepcionIVA
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

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'PGANA' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , 0 BaseImponible, 0 Alicuota, PercepcionGanancias
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

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe)
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'PVAR' IdTipoImpuesto, NULL IdProvincia, NULL Emisor, NULL Numero
     , 0 BaseImponible, 0 Alicuota, PercepcionVarias
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

INSERT INTO ComprasImpuestos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdProveedor
           ,Orden
           ,IdTipoImpuesto,IdProvincia,Emisor,Numero
           ,BaseImponible,Alicuota,Importe)
SELECT C.IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor
     , ISNULL((SELECT MAX(Orden) FROM ComprasImpuestos CI
                         WHERE CI.IdSucursal = C.IdSucursal
                           AND CI.IdTipoComprobante = C.IdTipoComprobante
                           AND CI.Letra = C.Letra
                           AND CI.CentroEmisor = C.CentroEmisor
                           AND CI.NumeroComprobante = C.NumeroComprobante
                           AND CI.IdProveedor = C.IdProveedor), 0) + 1 Orden
     , 'PIIBB' IdTipoImpuesto, L.IdProvincia IdProvincia, NULL Emisor, NULL Numero
     , 0 BaseImponible, 0 Alicuota, PercepcionIB
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

SELECT * FROM ComprasImpuestos
;
