PRINT ''
PRINT '2. Tabla Buscadores: Agregar Buscador de Asientos Contables'
DECLARE @idBuscador305  int = 305
DECLARE @alineacion_der int = 64
DECLARE @alineacion_cen int = 32
DECLARE @alineacion_izq int = 16

DELETE BuscadoresCampos WHERE IdBuscador IN (@idBuscador305)

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador305 IdBuscador, 'Nros. Serie' Titulo, 650 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial)
;

MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador305 IdBuscador, 'NroSerie'         IdBuscadorNombreCampo,  1 Orden, 'Nro Serie'        Titulo, @alineacion_izq Alineacion,  140 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador305 IdBuscador, 'IdProducto'       IdBuscadorNombreCampo,  2 Orden, 'Producto'         Titulo, @alineacion_der Alineacion,  100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador305 IdBuscador, 'NombreProducto'   IdBuscadorNombreCampo,  3 Orden, 'Nombre Producto'  Titulo, @alineacion_izq Alineacion,  180 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador305 IdBuscador, 'Vendido'          IdBuscadorNombreCampo,  4 Orden, 'Vendido'          Titulo, @alineacion_cen Alineacion,   70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
               ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
    WHEN MATCHED THEN
        UPDATE SET D.Orden      = O.Orden
                 , D.Titulo     = O.Titulo
                 , D.Alineacion = O.Alineacion
                 , D.Ancho      = O.Ancho
                 , D.Formato    = O.Formato
                 , D.Condicion  = O.Condicion
                 , D.Valor      = O.Valor
                 , D.ColorFila  = O.ColorFila
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho,   Formato,   Condicion,   Valor,   ColorFila) 
        VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila)
;
GO
PRINT ''
PRINT '1.1. Tabla OrdenesProduccionMRPProductos: Nuevo Campo de Cantidades'
IF dbo.ExisteCampo('OrdenesProduccionMRPProductos', 'CantidadProcesada') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPProductos ADD CantidadProcesada Decimal(16,4) NULL
END
GO

PRINT ''
PRINT '1.2. Tabla OrdenesProduccionMRPProductos: Nuevo Campo de Cantidades'
BEGIN
    UPDATE OrdenesProduccionMRPProductos SET CantidadProcesada = 0
	ALTER TABLE dbo.OrdenesProduccionMRPProductos ALTER COLUMN CantidadProcesada Decimal(16, 4) NOT NULL

END
GO
PRINT ''
PRINT '2.1. Tabla PedidosEstadosProveedores: Nuevos Campos Produccion'
IF dbo.ExisteCampo('PedidosEstadosProveedores', 'IdSucursalProduccion') = 0
BEGIN
    ALTER TABLE PedidosEstadosProveedores ADD IdSucursalProduccion int NULL
    ALTER TABLE PedidosEstadosProveedores ADD IdTipoComprobanteProduccion Varchar(15) NULL
    ALTER TABLE PedidosEstadosProveedores ADD LetraProduccion Varchar(1) NULL
    ALTER TABLE PedidosEstadosProveedores ADD CentroEmisorProduccion int NULL
    ALTER TABLE PedidosEstadosProveedores ADD NumeroOrdenProduccion int NULL
    ALTER TABLE PedidosEstadosProveedores ADD IdProductoProduccion varchar(15) NULL
    ALTER TABLE PedidosEstadosProveedores ADD OrdenProduccion int NULL

	ALTER TABLE PedidosEstadosProveedores  
		WITH CHECK ADD  CONSTRAINT FK_PedidosEstadosProveedores_OrdenProduccion 
		FOREIGN KEY(IdSucursalProduccion, NumeroOrdenProduccion, IdProductoProduccion, OrdenProduccion, IdTipoComprobanteProduccion, LetraProduccion, CentroEmisorProduccion)
		REFERENCES OrdenesProduccionProductos (IdSucursal, NumeroOrdenProduccion, IdProducto, Orden, IdTipoComprobante, Letra, CentroEmisor)

	ALTER TABLE [dbo].[PedidosEstadosProveedores] CHECK CONSTRAINT FK_PedidosEstadosProveedores_OrdenProduccion

END
GO

PRINT ''
PRINT '2.2. Tabla NovedadesProduccionMRPProductos: Nuevos Campos Produccion'
IF dbo.ExisteCampo('NovedadesProduccionMRPProductos', 'IdSucursalProduccion') = 0
BEGIN
    ALTER TABLE NovedadesProduccionMRPProductos ADD IdSucursalProduccion int NULL
    ALTER TABLE NovedadesProduccionMRPProductos ADD IdTipoComprobanteProduccion Varchar(15) NULL
    ALTER TABLE NovedadesProduccionMRPProductos ADD LetraProduccion Varchar(1) NULL
    ALTER TABLE NovedadesProduccionMRPProductos ADD CentroEmisorProduccion int NULL
    ALTER TABLE NovedadesProduccionMRPProductos ADD NumeroOrdenProduccion bigint NULL
    ALTER TABLE NovedadesProduccionMRPProductos ADD IdProductoProduccion varchar(15) NULL
    ALTER TABLE NovedadesProduccionMRPProductos ADD OrdenProduccion int NULL
    ALTER TABLE NovedadesProduccionMRPProductos ADD IdProcesoProduccion bigint NULL
    ALTER TABLE NovedadesProduccionMRPProductos ADD IdOperacionProduccion Varchar(30) NULL

END
GO