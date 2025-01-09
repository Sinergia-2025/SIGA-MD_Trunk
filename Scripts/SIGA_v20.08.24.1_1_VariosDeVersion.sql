PRINT ''
PRINT '1. Nuevo Campo en Ventas: DescuentoRecargoPorcManual'
ALTER TABLE Ventas
	ADD DescuentoRecargoPorcManual BIT NULL
GO

PRINT ''
PRINT '2. Actualización de registros pre existentes'
UPDATE Ventas SET
	DescuentoRecargoPorcManual = 0
GO

PRINT ''
PRINT '3. Cambio el campo a NOT NULL'
ALTER TABLE Ventas 
	ALTER COLUMN DescuentoRecargoPorcManual BIT NOT NULL
GO

--SOLO PARA LA TUERCA

DELETE TiposComprobantes
 WHERE IdTipoComprobante IN ('PRESTAMO','DEV-PRESTAMO')
GO

PRINT ''
PRINT '4. TiposComprobantes: Nuevo Comprobante "Reparto Salida".'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock
           ,GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime
           ,CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual
           ,ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista
           ,ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope
           ,IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
           ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta
           ,EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad
           ,UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb
           ,IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, EsDespachoImportacion
           ,CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte
           ,ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC
           ,AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden
           ,MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva)
     VALUES
           ('PRESTAMO', 'False', 'Prestamo', 'VENTAS', -1
           ,'False', 'True', 'X', 100, 'True'
           ,1, 'SOLOPRECIOS', 'True', 'False', 'True'
           ,'False', 'Prestamo', 'False', 1, 'True'
           ,NULL, 'False', 99, NULL, 0
           ,'.', 'False', 0.01, 'False', 'True'
           ,'True', 'False', 'True', 'True', 2
           ,'False', 'False', 'VENTAS', 'False', 'False'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'False', 'False', '', 'False'
           ,'True', NULL, 'True', 'True'
           ,'True', 'False', 8, 1, 'False'
           ,'False', 'False', 'False', 'False', 'False'
           ,'False', 'False', 'False', 'False', 10
           ,'False', 'False', 'False', 'Prestamo', 'False')
GO

PRINT ''
PRINT '5. TiposComprobantes: Nuevo Comprobante "Reparto Entrada".'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock
           ,GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime
           ,CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual
           ,ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista
           ,ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope
           ,IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
           ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta
           ,EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad
           ,UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb
           ,IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, EsDespachoImportacion
           ,CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte
           ,ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC
           ,AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden
           ,MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva)
     VALUES
           ('DEV-PRESTAMO', 'False', 'Dev. Prestamo', 'VENTAS', 1
           ,'False', 'True', 'X', 100, 'True'
           ,-1, 'SOLOPRECIOS', 'True', 'False', 'True'
           ,'False', 'Dev. Pres.', 'False', 1, 'True'
           ,NULL, 'False', 99, NULL, 0
           ,'.', 'False', 0.01, 'False', 'True'
           ,'True', 'False', 'True', 'True', 2
           ,'False', 'False', 'VENTAS', 'False', 'False'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'False', 'False', '', 'False'
           ,'True', NULL, 'True', 'True',
           'True', 'False', 8, 1, 'False'
           ,'False', 'False', 'False', 'False', 'False'
           ,'False', 'False', 'False', 'False', 10
           ,'False', 'False', 'False', 'Dev. Prestamo', 'False')
GO


DECLARE @idParametro VARCHAR(MAX)
DECLARE @descripcionParametro VARCHAR(MAX)
DECLARE @valorParametro VARCHAR(MAX)

SET @idParametro = 'VISUALIZANROSERIE'
SET @descripcionParametro = 'Utiliza Numeros de Serie en Productos '
SET @valorParametro = 'SI'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

UPDATE Impresoras
   SET ComprobantesHabilitados = ComprobantesHabilitados + ',PRESTAMO,DEV-PRESTAMO'
 WHERE IdImpresora = 'NORMAL'
GO

PRINT ''
PRINT '6. Nuevo Campo en TiposComprobantes: SolicitaFechaDevolucion'
ALTER TABLE TiposComprobantes
	ADD SolicitaFechaDevolucion BIT NULL
GO

PRINT ''
PRINT '7. SET SolicitaFechaDevolucion = TRUE para el tipo de comprobante PRESTAMO'
UPDATE TiposComprobantes SET
	SolicitaFechaDevolucion = CASE WHEN IdTipoComprobante = 'PRESTAMO' THEN 1 ELSE 0 END 
GO

PRINT ''
PRINT '8. Actualizo el campo SolicitaFechaDevolucion a NOT NULL'
ALTER TABLE TiposComprobantes
	ALTER COLUMN SolicitaFechaDevolucion BIT NOT NULL 
GO

PRINT ''
PRINT '9. Nuevo Campo en VentasProductos: FechaDevolucion'
ALTER TABLE VentasProductos 
	ADD FechaDevolucion DATE NULL
GO

PRINT ''
PRINT '10. Nueva Tabla: VentasProductosNrosSerie'
CREATE TABLE VentasProductosNrosSerie(
	IdSucursal INT NOT NULL,
	IdTipoComprobante VARCHAR(15) NOT NULL,
	Letra VARCHAR(1) NOT NULL,
	CentroEmisor INT NOT NULL,
	NumeroComprobante BIGINT NOT NULL,
	Orden INT NOT NULL,
	IdProducto VARCHAR(15) NOT NULL,
	NroSerie VARCHAR(50) NOT NULL
	PRIMARY KEY (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Orden,IdProducto,NroSerie)
)
GO

PRINT ''
PRINT '11. FK_VentasProductosNrosSerie_VentasProductos'
ALTER TABLE VentasProductosNrosSerie
	ADD CONSTRAINT FK_VentasProductosNrosSerie_VentasProductos
	FOREIGN KEY (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Orden,IdProducto) REFERENCES VentasProductos (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,Orden,IdProducto)
GO

PRINT ''
PRINT '12. Nueva Tabla: MovimientosVentasProductosNrosSerie'
CREATE TABLE MovimientosVentasProductosNrosSerie (
	IdSucursal INT NOT NULL,
	IdTipoMovimiento VARCHAR(15) NOT NULL,
	NumeroMovimiento BIGINT NOT NULL,
	Orden INT NOT NULL,
	IdProducto VARCHAR(15) NOT NULL,
	NroSerie VARCHAR(50) NOT NULL

	PRIMARY KEY (IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto, NroSerie)
)
GO

PRINT ''
PRINT '13. FK_MovimientosVentasProductosNrosSerie_MovimientosVentasProductos'
ALTER TABLE MovimientosVentasProductosNrosSerie
	ADD CONSTRAINT FK_MovimientosVentasProductosNrosSerie_MovimientosVentasProductos
	FOREIGN KEY (IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto) REFERENCES MovimientosVentasProductos(IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto)
GO

PRINT ''
PRINT '14. Nuevo Campo en MovimientosVentasProductosNrosSerie: Cantidad'
ALTER TABLE MovimientosVentasProductosNrosSerie
	ADD Cantidad INT NOT NULL
GO

PRINT ''
PRINT '15. Nueva Función: DetalleMovimientosDeProductosNrosSerie'

IF dbo.ExisteFuncion('Stock') = 1
BEGIN
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('DetalleMovDeProductosNrosSerie', 'Detalle de Movimientos de Productos con Nro. de Serie', 'Detalle de Movimientos de Productos con Nro. de Serie', 'True', 'False', 'True', 'True'
	    ,'Stock', 25, 'Eniac.Win', 'DetalleMovDeProductosNrosSerie', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'DetalleMovDeProductosNrosSerie' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO 

PRINT ''
PRINT '16. Nuevo Campo en ProductosNrosSerie: Orden'
ALTER TABLE ProductosNrosSerie
	ADD OrdenVenta INT NULL
GO

PRINT ''
PRINT '17. Corrección de datos Pre Existentes'
UPDATE PNS SET PNS.OrdenVenta = VP.Orden 
	FROM ProductosNrosSerie PNS
	INNER JOIN VentasProductos VP ON 
			PNS.IdSucursal = VP.IdSucursal
			AND PNS.IdTipoCompVenta = VP.IdTipoComprobante
			AND PNS.LetraVenta = VP.Letra
			AND PNS.CentroEmisorVenta = VP.CentroEmisor
			AND PNS.NumeroComprobanteVenta = VP.NumeroComprobante
			AND PNS.IdProducto = VP.IdProducto
GO

PRINT ''
PRINT '18. Nuevo Campo en ProductosNrosSerie: FechaDevolucionVenta'
ALTER TABLE ProductosNrosSerie
	ADD FechaDevolucionVenta DATETIME NULL
GO

