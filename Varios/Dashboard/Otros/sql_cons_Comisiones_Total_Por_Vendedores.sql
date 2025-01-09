SELECT
    IdEmpleado as IdVendedor,
    NombreEmpleado as NombreVendedor,
    0 AS IdSucursal,
    SUM(CantComprobantes) AS CantComprobantes,
    SUM(CantItems) AS CantItems,
    SUM(TotalContado) AS TotalContado,
    SUM(TotalCtaCte) AS TotalCtaCte,
    SUM(TotalContado+TotalCtaCte) AS Total,
    SUM(ComisionContado+ComisionCtaCte) AS Comision
   , 0 AS ImporteObjetivo
   , 0 AS PorcObjetivo
 FROM
(
SELECT
       E.IdEmpleado,
       E.NombreEmpleado,
       SUM(CASE VFP.Dias WHEN 0 Then (VP.ImporteTotalNeto+VP.ImporteImpuesto) ELSE 0 END) TotalContado,
       SUM(CASE VFP.Dias WHEN 0 Then 0 ELSE (VP.ImporteTotalNeto+VP.ImporteImpuesto) END) TotalCtaCte,
           SUM(ROUND(CASE WHEN VFP.Dias = 0 THEN VP.ComisionVendedor ELSE 0 END, 2)) ComisionContado,
           SUM(ROUND(CASE WHEN VFP.Dias = 0 THEN 0 ELSE VP.ComisionVendedor END, 2)) ComisionCtaCte,
       COUNT(*) AS CantItems
    FROM Ventas V
   INNER JOIN Clientes C ON V.IdCliente = C.IdCliente
   INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado 
   INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
   INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal 
                              AND V.IdTipoComprobante=VP.IdTipoComprobante
                              AND V.Letra=VP.Letra
                              AND V.CentroEmisor=VP.CentroEmisor
                              AND V.NumeroComprobante=VP.NumeroComprobante
   INNER JOIN Productos P ON VP.IdProducto = P.IdProducto 
   INNER JOIN Marcas M ON P.IdMarca = M.IdMarca 
   INNER JOIN Rubros R ON P.IdRubro = R.IdRubro
   INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica
   INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago
   LEFT JOIN EmpleadosComisionesMarcas ECM ON ECM.IdMarca = M.IdMarca AND ECM.IdEmpleado = E.IdEmpleado 
   LEFT JOIN EmpleadosComisionesRubros ECR ON ECR.IdRubro = R.IdRubro AND ECR.IdEmpleado = E.IdEmpleado 
   LEFT JOIN EmpleadosComisionesProductos ECP ON ECP.IdProducto = P.IdProducto AND ECP.IdEmpleado = E.IdEmpleado 
   WHERE 1=1
   AND V.IdSucursal IN (1,1)     AND V.Fecha >= '20210509 00:00:00'
     AND V.Fecha <= '20211209 23:59:59'
     AND TC.AfectaCaja = 'True'
     AND TC.EsComercial = 'True'
     GROUP BY E.IdEmpleado, E.NombreEmpleado, V.IdSucursal
) Detalle,
(
SELECT V.IdVendedor
      ,COUNT(*) AS CantComprobantes
  FROM Ventas V
   INNER JOIN Clientes C ON V.IdCliente = C.IdCliente 
   INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado 
   INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante    INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica
   WHERE 1=1
   AND V.IdSucursal IN (1,1)     AND V.Fecha >= '20210509 00:00:00'
     AND V.Fecha <= '20211209 23:59:59'
     AND TC.AfectaCaja = 'True'
     AND TC.EsComercial = 'True'
 GROUP BY V.IdVendedor
) DetCantComprob
 WHERE Detalle.IdEmpleado = DetCantComprob.IdVendedor
 GROUP BY IdEmpleado, NombreEmpleado
 ORDER BY Comision DESC, Total DESC
