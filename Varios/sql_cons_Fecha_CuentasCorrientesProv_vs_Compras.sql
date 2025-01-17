/****** Script for SelectTopNRows command from SSMS  ******/
SELECT CCP.Fecha, p.NombreProveedor, C.*
  FROM [Compras] C, [CuentasCorrientesProv] CCP, Proveedores P
   WHERE C.[IdSucursal] = CCP.[IdSucursal]
     AND C.[IdTipoComprobante] = CCP.[IdTipoComprobante]
    AND C.[Letra] = CCP.[Letra]
    AND C.[CentroEmisor] = CCP.[CentroEmisor]
    AND C.[NumeroComprobante] = CCP.[NumeroComprobante]
    AND C.[TipoDocProveedor] = CCP.[TipoDocProveedor]
    AND C.[NroDocProveedor] = CCP.[NroDocProveedor]
    AND C.[TipoDocProveedor] = P.[TipoDocProveedor]
    AND C.[NroDocProveedor] = P.[NroDocProveedor]
    AND  CONVERT(varchar(11), C.Fecha, 120) <>  CONVERT(varchar(11), CCP.Fecha, 120)
    