
SELECT * FROM Compras
 WHERE IdProveedor = 15
  and NumeroComprobante in (1114, 1115, 1116, 1117, 1118 , 1171, 1172, 1173, 1174, 1175, 24, 25, 34)
go

UPDATE Compras
   SET Neto210 = Neto210 + NetoNoGravado
    , Bruto210 =  Bruto210 + BrutoNoGravado
    , IVA210 = IVA210 + PercepcionIVA
 WHERE IdProveedor = 15
  AND NumeroComprobante IN (1114, 1115, 1116, 1117, 1118 , 1171, 1172, 1173, 1174, 1175, 24, 25, 34)
GO

UPDATE Compras
   SET NetoNoGravado = 0
    , BrutoNoGravado = 0
    , PercepcionIVA = 0
 WHERE IdProveedor = 15
  AND NumeroComprobante IN (1114, 1115, 1116, 1117, 1118 , 1171, 1172, 1173, 1174, 1175, 24, 25, 34)
GO


SELECT * FROM ComprasProductos
 WHERE IdProveedor = 15
  and NumeroComprobante in (1114, 1115, 1116, 1117, 1118 , 1171, 1172, 1173, 1174, 1175, 24, 25, 34)
go

UPDATE ComprasProductos
  SET PorcentajeIVA = 21
     , IVA = ROUND(ImporteTotalNeto * 0.21,2)
 WHERE IdProveedor = 15
   AND NumeroComprobante in (1114, 1115, 1116, 1117, 1118 , 1171, 1172, 1173, 1174, 1175, 24, 25, 34)
go

UPDATE ComprasProductos
  SET ProporcionalImp = IVA
 WHERE IdProveedor = 15
   AND NumeroComprobante in (1114, 1115, 1116, 1117, 1118 , 1171, 1172, 1173, 1174, 1175, 24, 25, 34)
go
