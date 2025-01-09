/****** Object:  StoredProcedure [dbo].[LimpiaSucursal]    Script Date: 4/10/2023 12:24:59 ******/
DROP PROCEDURE [dbo].[LimpiaSucursal]
GO

/****** Object:  StoredProcedure [dbo].[LimpiaSucursal]    Script Date: 4/10/2023 12:07:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Sinergia SS
-- Create date: 01/01/2000
-- Description: Limpiar sucursales de prueba
-- =============================================
CREATE PROCEDURE [dbo].[LimpiaSucursal]
    @IdSucursal int
AS
BEGIN
    SET NOCOUNT OFF;
    BEGIN TRY
        BEGIN TRANSACTION BORRARTODO
            -- SET NOCOUNT ON added to prevent extra result sets from
            -- interfering with SELECT statements.

            PRINT 'OrdenesCompra'
            DELETE OrdenesCompraPedidos WHERE IdSucursal = @IdSucursal
            DELETE OrdenesCompra WHERE IdSucursal = @IdSucursal


            PRINT 'Repartos'
            IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RepartosComprobantes]') AND type in (N'U'))
                DELETE RepartosComprobantes WHERE IdSucursal = @IdSucursal

            IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Repartos]') AND type in (N'U'))
                DELETE Repartos WHERE IdSucursal = @IdSucursal



            PRINT 'Pedidos'
            UPDATE PedidosEstados
               SET IdSucursalGenerado = NULL
                 , IdTipoComprobanteGenerado = NULL
                 , LetraGenerado = NULL
                 , CentroEmisorGenerado = NULL
                 , NumeroPedidoGenerado = NULL
             WHERE IdSucursal = @IdSucursal
            DELETE PedidosEstados WHERE IdSucursal = @IdSucursal
            DELETE PedidosProductos WHERE IdSucursal = @IdSucursal
            DELETE PedidosObservaciones WHERE IdSucursal = @IdSucursal
            DELETE PedidosClientesContactos WHERE IdSucursal = @IdSucursal
            DELETE Pedidos WHERE IdSucursal = @IdSucursal

            PRINT 'Pedidos Proveedores'
            UPDATE PedidosEstadosProveedores
               SET IdSucursalGenerado = NULL
                 , IdTipoComprobanteGenerado = NULL
                 , LetraGenerado = NULL
                 , CentroEmisorGenerado = NULL
                 , NumeroPedidoGenerado = NULL
             WHERE IdSucursal = @IdSucursal
            DELETE PedidosEstadosProveedores WHERE IdSucursal = @IdSucursal
            DELETE PedidosProductosProveedores WHERE IdSucursal = @IdSucursal
            DELETE PedidosObservacionesProveedores WHERE IdSucursal = @IdSucursal
            DELETE PedidosProveedores WHERE IdSucursal = @IdSucursal


            PRINT ' Liquidaciones'
            DELETE LiquidacionesCargos WHERE IdSucursal = @IdSucursal
            DELETE LiquidacionesDetallesClientes WHERE IdSucursal = @IdSucursal
            DELETE LiquidacionesObservaciones WHERE IdSucursal = @IdSucursal
            DELETE Liquidaciones WHERE IdSucursal = @IdSucursal


            PRINT ' Ventas'
            DELETE VentasAdjuntos WHERE IdSucursal = @IdSucursal
            DELETE VentasCajeros WHERE IdSucursal = @IdSucursal
            DELETE VentasChequesRechazados WHERE IdSucursal = @IdSucursal
            DELETE VentasCheques WHERE IdSucursal = @IdSucursal
            DELETE VentasClientesContactos WHERE IdSucursal = @IdSucursal
            DELETE VentasColasImpresionComprobantes WHERE IdSucursal = @IdSucursal
            DELETE VentasImpuestos WHERE IdSucursal = @IdSucursal
            DELETE VentasNumeros WHERE IdSucursal = @IdSucursal
            DELETE VentasObservaciones WHERE IdSucursal = @IdSucursal
            DELETE VentasPercepciones WHERE IdSucursal = @IdSucursal
            DELETE VentasProductos WHERE IdSucursal = @IdSucursal
            DELETE VentasProductosLotes WHERE IdSucursal = @IdSucursal
            DELETE VentasTarjetas WHERE IdSucursal = @IdSucursal

            PRINT 'Cuentas Corrientes'
            DELETE CuentasCorrientesCheques WHERE IdSucursal = @IdSucursal
            UPDATE CuentasCorrientesPagos
               SET IdTipoComprobante2 = NULL
                 , Letra2 = NULL
                 , CentroEmisor2 = NULL
                 , NumeroComprobante2 = NULL
                 , CuotaNumero2 = NULL
             WHERE IdSucursal = @IdSucursal
            DELETE CuentasCorrientesPagos WHERE IdSucursal = @IdSucursal
            DELETE CuentasCorrientesRetenciones WHERE IdSucursal = @IdSucursal
            DELETE CuentasCorrientesTarjetas WHERE IdSucursal = @IdSucursal

            DELETE CuentasCorrientes WHERE IdSucursal = @IdSucursal
            PRINT 'Ventas'
            UPDATE Ventas
               SET IdTipoComprobanteFact_Viejo = NULL
                 , LetraFact_Viejo = NULL
                 , CentroEmisorFact_Viejo = NULL
                 , NumeroComprobanteFact_Viejo = NULL
             WHERE IdSucursal = @IdSucursal
            DELETE Ventas WHERE IdSucursal = @IdSucursal

            PRINT 'Compras'
            DELETE ComprasCheques WHERE IdSucursal = @IdSucursal
            DELETE ComprasImpuestos WHERE IdSucursal = @IdSucursal
            DELETE ComprasNumeros WHERE IdSucursal = @IdSucursal
            DELETE ComprasObservaciones WHERE IdSucursal = @IdSucursal
            DELETE ComprasProductos WHERE IdSucursal = @IdSucursal

            PRINT 'Cuentas Corrientes Proveedores'
            DELETE CuentasCorrientesProvCheques WHERE IdSucursal = @IdSucursal
            UPDATE CuentasCorrientesProvPagos
               SET IdTipoComprobante2 = NULL
                 , Letra2 = NULL
                 , CentroEmisor2 = NULL
                 , NumeroComprobante2 = NULL
                 , CuotaNumero2 = NULL
             WHERE IdSucursal = @IdSucursal
            DELETE CuentasCorrientesProvPagos WHERE IdSucursal = @IdSucursal
            DELETE CuentasCorrientesProvRetenciones WHERE IdSucursal = @IdSucursal

            DELETE CuentasCorrientesProv WHERE IdSucursal = @IdSucursal
            UPDATE Compras
               SET IdTipoComprobanteFact = NULL
                 , LetraFact = NULL
                 , CentroEmisorFact = NULL
                 , NumeroComprobanteFact = NULL
             WHERE IdSucursal = @IdSucursal
            DELETE Compras WHERE IdSucursal = @IdSucursal

            PRINT 'Retenciones/Percepciones'
            DELETE Retenciones WHERE IdSucursal = @IdSucursal
            DELETE RetencionesCompras WHERE IdSucursal = @IdSucursal
            DELETE PercepcionVentas WHERE IdSucursal = @IdSucursal

            PRINT 'Fichas'
            DELETE FichasPagos WHERE IdSucursal = @IdSucursal
            DELETE FichasPagosAjustes WHERE IdSucursal = @IdSucursal
            DELETE FichasPagosDetalle WHERE IdSucursal = @IdSucursal
            DELETE FichasProductos WHERE IdSucursal = @IdSucursal
            DELETE Fichas WHERE IdSucursal = @IdSucursal


            PRINT 'MovimientosStock'
            --DELETE MovimientosComprasProductos WHERE IdSucursal = @IdSucursal
            --DELETE MovimientosCompras WHERE IdSucursal = @IdSucursal
            --DELETE MovimientosVentasProductos WHERE IdSucursal = @IdSucursal
            --DELETE MovimientosVentas WHERE IdSucursal = @IdSucursal
			DELETE MovimientosStockProductos WHERE IdSucursal = @IdSucursal
			DELETE MovimientosStock WHERE IdSucursal = @IdSucursal


            PRINT 'Cargos'
            DELETE CargosClientesObservaciones WHERE IdSucursal = @IdSucursal
            DELETE CargosClientes WHERE IdSucursal = @IdSucursal

            PRINT 'Contabilidad'
            DELETE cac
              FROM ContabilidadAsientosCuentas cac
             INNER JOIN ContabilidadAsientos ca ON ca.IdPlanCuenta = cac.IdPlanCuenta AND ca.IdAsiento = cac.IdAsiento
             WHERE ca.IdSucursal = @IdSucursal
            DELETE ContabilidadAsientos WHERE IdSucursal = @IdSucursal
            DELETE cac
              FROM ContabilidadAsientosCuentasTmp cac
             INNER JOIN ContabilidadAsientosTmp ca ON ca.IdPlanCuenta = cac.IdPlanCuenta AND ca.IdAsiento = cac.IdAsiento
             WHERE ca.IdSucursal = @IdSucursal
            DELETE ContabilidadAsientosTmp WHERE IdSucursal = @IdSucursal


            PRINT 'Bancos'
            DELETE LibrosBancos WHERE IdSucursal = @IdSucursal


            PRINT 'Depositos'
            DELETE DepositosCheques WHERE IdSucursal = @IdSucursal
            DELETE Depositos WHERE IdSucursal = @IdSucursal


            PRINT 'Cheque'
            DELETE ChequesHistorial WHERE IdSucursal = @IdSucursal
            DELETE Cheques WHERE IdSucursal = @IdSucursal

            PRINT 'Cajas'
            DELETE CajasDetalle WHERE IdSucursal = @IdSucursal
            DELETE Cajas WHERE IdSucursal = @IdSucursal


            PRINT 'Otros'
            DELETE HistorialPrecios WHERE IdSucursal = @IdSucursal
            DELETE Bitacora WHERE IdSucursal = @IdSucursal


            --DELETE Alquileres WHERE IdSucursal = @IdSucursal
            --DELETE AlquileresTarifasProductos WHERE IdSucursal = @IdSucursal
            --DELETE ArchivosAImprimir WHERE IdSucursal = @IdSucursal
            --DELETE AuditoriaClientes WHERE IdSucursalAsociada = @IdSucursal
            --DELETE AuditoriaProspectos WHERE IdSucursalAsociada = @IdSucursal
            --DELETE CajasNombres WHERE IdSucursal = @IdSucursal
            --DELETE CajasUsuarios WHERE IdSucursal = @IdSucursal
            --DELETE Calendarios WHERE IdSucursal = @IdSucursal
            --DELETE CartasAClientes WHERE IdSucursal = @IdSucursal
            --DELETE Clientes WHERE IdSucursalAsociada = @IdSucursal
            --DELETE ClientesSucursales WHERE IdSucursal = @IdSucursal
            --DELETE CobradoresSucursales WHERE IdSucursal = @IdSucursal
            --DELETE HistorialConsultaProductos WHERE IdSucursal = @IdSucursal
            --DELETE Impresoras WHERE IdSucursal = @IdSucursal
            --DELETE ImpresorasPCs WHERE IdSucursal = @IdSucursal
            --DELETE MovimientosNumeros WHERE IdSucursal = @IdSucursal
            --DELETE OrdenesProduccion WHERE IdSucursal = @IdSucursal
            --DELETE OrdenesProduccionEstados WHERE IdSucursal = @IdSucursal
            --DELETE OrdenesProduccionProductos WHERE IdSucursal = @IdSucursal
            --DELETE Produccion WHERE IdSucursal = @IdSucursal
            --DELETE ProduccionProductos WHERE IdSucursal = @IdSucursal
            --DELETE ProduccionProductosComponentes WHERE IdSucursal = @IdSucursal
            --DELETE ProductosLotes WHERE IdSucursal = @IdSucursal
            --DELETE ProductosNrosSerie WHERE IdSucursal = @IdSucursal
            --DELETE ProductosNrosSerie WHERE IdSucursalVenta = @IdSucursal
            --DELETE ProductosSucursales WHERE IdSucursal = @IdSucursal
            --DELETE ProductosSucursalesPrecios WHERE IdSucursal = @IdSucursal
            --DELETE Prospectos WHERE IdSucursalAsociada = @IdSucursal
            --DELETE RecepcionNotas WHERE IdSucursal = @IdSucursal
            --DELETE RecepcionNotasEstados WHERE IdSucursal = @IdSucursal
            --DELETE RecepcionNotasEstadosF WHERE IdSucursal = @IdSucursal
            --DELETE RecepcionNotasF WHERE IdSucursal = @IdSucursal
            --DELETE RecepcionNotasProveedores WHERE IdSucursal = @IdSucursal
            --DELETE RecepcionNotasProveedoresF WHERE IdSucursal = @IdSucursal
            --DELETE SincronizaTablas WHERE IdSucursal = @IdSucursal
            --DELETE Sucursales WHERE IdSucursal = @IdSucursal
            --DELETE UsuariosAccesos WHERE IdSucursal = @IdSucursal
            --DELETE UsuariosRoles WHERE IdSucursal = @IdSucursal
        PRINT 'COMMIT TRANSACTION BORRARTODO'
        --PRINT '1- @@TRANCOUNT ' + CONVERT(VARCHAR(MAX), @@TRANCOUNT);
        COMMIT TRANSACTION BORRARTODO
        --PRINT '2- @@TRANCOUNT ' + CONVERT(VARCHAR(MAX), @@TRANCOUNT);
    END TRY
    BEGIN CATCH
        --PRINT '3- @@TRANCOUNT ' + CONVERT(VARCHAR(MAX), @@TRANCOUNT);
        IF (@@TRANCOUNT > 0)
        BEGIN
            --PRINT '4- @@TRANCOUNT ' + CONVERT(VARCHAR(MAX), @@TRANCOUNT);
            ROLLBACK TRANSACTION BORRARTODO
        END 

    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    -- Use RAISERROR inside the CATCH block to return error
    -- information about the original error that caused
    -- execution to jump to the CATCH block.
    RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
    END CATCH
END
GO


