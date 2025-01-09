PRINT ''
PRINT '1.Tabla EstadosVenta: Nuevo Campo IdTipoMovimiento'
ALTER TABLE EstadosVenta ADD IdTipoMovimiento varchar(15) null
GO

PRINT ''
PRINT '2.Tabla Tipo de Movimiento de stock: Nuevo tipo que se utilizará al Realizar NC '
INSERT INTO [dbo].[TiposMovimientos]
           ([IdTipoMovimiento]
           ,[Descripcion]
           ,[CoeficienteStock]
           ,[ComprobantesAsociados]
           ,[AsociaSucursal]
           ,[MuestraCombo]
           ,[HabilitaDestinatario]
           ,[HabilitaRubro]
           ,[Imprime]
           ,[CargaPrecio]
           ,[IdContraTipoMovimiento]
           ,[HabilitaEmpleado]
           ,[ReservaMercaderia])
     VALUES
           ('AJUSTE-NC'	,'Ajuste Nota Crédito'	,1	,NULL	,'False'	,'True'	,
		   'False'	,'False'	,'True'	,'PrecioCosto'	,NULL	,
		   'False'	,'False')
GO


DECLARE @max int
SET @max = (SELECT MAX(IdEstadoVenta)+1 FROM EstadosVenta)

PRINT ''
PRINT '3.Tabla EstadosVenta: Nuevo estado Faltante'
INSERT INTO [dbo].[EstadosVenta]
           ([IdEstadoVenta]
           ,[NombreEstadoVenta]
           ,[IdTipoMovimiento])
     VALUES
           (@max, 'Faltante', 'AJUSTE-NC')

PRINT ''
PRINT '4.Tabla EstadosVenta: Nuevo estado No se Cargó'
INSERT INTO [dbo].[EstadosVenta]
           ([IdEstadoVenta]
           ,[NombreEstadoVenta]
           ,[IdTipoMovimiento])
     VALUES
           --(@max + 1, 'No se Cargó', 'AJUSTE-NC')
           (@max + 1, 'No se Cargo', NULL)
GO
