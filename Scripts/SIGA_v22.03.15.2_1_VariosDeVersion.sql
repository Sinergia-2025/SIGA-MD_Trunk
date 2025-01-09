PRINT ''
PRINT '1.1. Insertar funcion: Inf. Productos No Vendidos'
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
			VALUES
			('InfNoVendidos', 'Inf. Productos No Vendidos', 'Inf. Productos No Vendidos', 'True', 'False', 'True', 'True', 'Ventas', 210, 'Eniac.Win', 'InfNoVendidos', null, null,'N','S','N','N','True')

		INSERT INTO RolesFunciones (IdRol,IdFuncion)
			SELECT DISTINCT Id AS Rol, 'InfNoVendidos' AS Pantalla FROM dbo.Roles
					WHERE Id IN ('Adm', 'Supervisor')
	END
GO

PRINT ''
PRINT '2. Parametro: Alta de Nuevo Cliente Publicar en Web'
DECLARE @idParametro VARCHAR(MAX) = 'ALTANUEVOCLIENTEPUBLICAWEB'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Alta de Nuevo Cliente Publicar en Web'
DECLARE @valorParametro VARCHAR(MAX) = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
GO

PRINT ''
PRINT '3. Indice: Crea indice IX_Pedidos_FechaPedidoSucursal'
CREATE NONCLUSTERED INDEX IX_Pedidos_FechaPedidoSucursal
ON [dbo].[Pedidos] ([FechaPedido],[IdSucursal])
GO

PRINT ''
PRINT '4. Indice: Crea indice IX_PedidosEstados_IdEstadoSucursal'
CREATE NONCLUSTERED INDEX IX_PedidosEstados_IdEstadoSucursal
ON [dbo].[PedidosEstados] ([IdEstado],[IdSucursal])
INCLUDE ([IdUsuario],[Observacion],[IdTipoComprobanteFact],[LetraFact],[CentroEmisorFact],[NumeroComprobanteFact],[IdCriticidad],[FechaEntrega],[NumeroReparto],[CantEstado],[TipoEstadoPedido],[IdSucursalGenerado],[IdTipoComprobanteGenerado],[LetraGenerado],[CentroEmisorGenerado],[NumeroPedidoGenerado],[IdSucursalRemito],[IdTipoComprobanteRemito],[LetraRemito],[CentroEmisorRemito],[NumeroComprobanteRemito],[IdSucursalProduccion],[IdTipoComprobanteProduccion],[LetraProduccion],[CentroEmisorProduccion],[NumeroOrdenProduccion],[IdProductoProduccion],[OrdenProduccion],[IdSucursalVinculado],[IdTipoComprobanteVinculado],[LetraVinculado],[CentroEmisorVinculado],[NumeroPedidoVinculado],[FechaEstadoVinculado],[IdSucursalFact])
GO

PRINT ''
PRINT '5. Delete: Borra dispositivos viejos'
DELETE Dispositivos
 WHERE FechaUltimoLogin <  GETDATE()-90
GO

PRINT ''
PRINT '6. Borro Menu TURNOS a todos los que no lo usaron salvo clientes especificos'

-- SIGA + SILIVE
IF dbo.GetValorParametro('IDAPLICACION') IN ('SIGA','SILIVE') 

-- Clientes J.Homs / F.C.Wash / Lub. La Curva  
    AND dbo.BaseConCuit('27329245069') = 0 AND dbo.BaseConCuit('30715016717') = 0 AND dbo.BaseConCuit('33712236049') = 0

-- HAR / Desarrollo 20244785922
	AND dbo.SoyHAR() = 0 AND dbo.BaseConCuit('20244785922') = 0

-- No tengo Turnos en los ultimos 90 dias
    AND NOT EXISTS (SELECT TOP 1 * FROM TurnosCalendarios WHERE FechaHasta >  GETDATE()-90)

BEGIN

	DECLARE @Menu varchar(255) = 'Turnos'

	DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

	DELETE Funciones WHERE Id = @Menu or IdPadre = @Menu ;

END;