DECLARE @maxNumeroMovimiento BIGINT = (SELECT MAX(NumeroMovimiento) FROM MovimientosCompras WHERE IdSucursal = 1 AND IdTipoMovimiento = 'COMPRA')
PRINT @maxNumeroMovimiento

INSERT INTO [dbo].[MovimientosCompras]
           ([IdSucursal],[IdTipoMovimiento],[NumeroMovimiento],[FechaMovimiento]
           ,[Neto210_Viejo],[Neto105_Viejo],[Neto270_Viejo],[NetoNoGravado_Viejo],[IVA210_Viejo],[IVA105_Viejo],[IVA270_Viejo]
           ,[Total],[PorcentajeIVA],[IdProveedor],[IdCategoriaFiscal]
           ,[IdTipoComprobante],[Letra],[CentroEmisor],[NumeroComprobante]
           ,[IdSucursal2],[Usuario],[Observacion]
           ,[PercepcionIVA],[PercepcionIB],[PercepcionGanancias],[PercepcionVarias]
           ,[IdProduccion],[IdEmpleado])
SELECT [IdSucursal], 'COMPRA' [IdTipoMovimiento], @maxNumeroMovimiento + 1,[Fecha]
      ,[Neto210_Viejo],[Neto105_Viejo],[Neto270_Viejo],[NetoNoGravado_Viejo],[IVA210_Viejo],[IVA105_Viejo],[IVA270_Viejo]
      ,[ImporteTotal], 0 [PorcentajeIVA],[IdProveedor],[IdCategoriaFiscal]
      ,[IdTipoComprobante],[Letra],[CentroEmisor],[NumeroComprobante]
      ,NULL [IdSucursal2],[Usuario],[Observacion]
      ,[PercepcionIVA],[PercepcionIB],[PercepcionGanancias],[PercepcionVarias]
      , NULL[IdProduccion],NULL [IdEmpleado]
  FROM [dbo].[Compras]
 WHERE IdSucursal = 1
   AND IdTipoComprobante = 'FACTCOM'
   AND Letra = 'A'
   AND CentroEmisor = 6
   AND NumeroComprobante = 1015779
   AND IdProveedor = 47


INSERT INTO [dbo].[MovimientosComprasProductos]
           ([IdSucursal],[IdTipoMovimiento],[NumeroMovimiento]
           ,[IdProducto],[Orden]
           ,[Cantidad],[Precio],[IdLote]
           ,[CantidadReservado],[CantidadDefectuoso],[CantidadFuturo],[CantidadFuturoReservado])

SELECT [IdSucursal], 'COMPRA' [IdTipoMovimiento], @maxNumeroMovimiento + 1
      ,[IdProducto],[Orden]
      ,[Cantidad],[Precio], NULL [IdLote]
      ,0 [CantidadReservado],0 [CantidadDefectuoso],0 [CantidadFuturo],0 [CantidadFuturoReservado]
  FROM [dbo].[ComprasProductos]
 WHERE IdSucursal = 1
   AND IdTipoComprobante = 'FACTCOM'
   AND Letra = 'A'
   AND CentroEmisor = 6
   AND NumeroComprobante = 1015779
   AND IdProveedor = 47

