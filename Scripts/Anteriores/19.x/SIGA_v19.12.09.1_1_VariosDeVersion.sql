INSERT INTO Empleados
           (TipoDocEmpleado,NroDocEmpleado,NombreEmpleado,TelefonoEmpleado,CelularEmpleado
           ,EsVendedor,EsComprador,IdUsuario,ComisionPorVenta,Direccion
           ,IdLocalidad,GeoLocalizacionLat,GeoLocalizacionLng,IdEmpleado,Color
           ,NivelAutorizacion,Clave)
    SELECT V.TipoDocVendedor, V.NroDocVendedor, 'Vendedor ' + V.NroDocVendedor, '', ''
          ,'True', 'True', NULL, 0, ''
          ,2000, NULL, NULL, E.IdEmpleado + V.NroDocVendedor, NULL
          ,1, ''
      FROM (SELECT DISTINCT F.TipoDocVendedor, F.NroDocVendedor --, ROW_NUMBER() OVER (ORDER BY NroDocVendedor) IdVendedor
              FROM Fichas F
             WHERE NOT EXISTS (SELECT * FROM Empleados E WHERE E.TipoDocEmpleado = F.TipoDocVendedor AND E.NroDocEmpleado = F.NroDocVendedor)) V
     CROSS JOIN (SELECT MAX(IdEmpleado) + 1 IdEmpleado FROM Empleados) E

INSERT INTO Empleados
           (TipoDocEmpleado,NroDocEmpleado,NombreEmpleado,TelefonoEmpleado,CelularEmpleado
           ,EsVendedor,EsComprador,IdUsuario,ComisionPorVenta,Direccion
           ,IdLocalidad,GeoLocalizacionLat,GeoLocalizacionLng,IdEmpleado,Color
           ,NivelAutorizacion,Clave)
    SELECT V.TipoDocCobrador, V.NroDocCobrador, 'Cobrador ' + V.NroDocCobrador, '', ''
          ,'True', 'True', NULL, 0, ''
          ,2000, NULL, NULL, E.IdEmpleado + V.NroDocCobrador, NULL
          ,1, ''
      FROM (SELECT DISTINCT F.TipoDocCobrador, F.NroDocCobrador --, ROW_NUMBER() OVER (ORDER BY NroDocCobrador) IdCobrador
              FROM Fichas F
             WHERE NOT EXISTS (SELECT * FROM Empleados E WHERE E.TipoDocEmpleado = F.TipoDocCobrador AND E.NroDocEmpleado = F.NroDocCobrador)) V
     CROSS JOIN (SELECT MAX(IdEmpleado) + 1 IdEmpleado FROM Empleados) E


PRINT ''
PRINT '. Tabla Empleados: Agregar nuevos campos de la Tablas Cobradores'

ALTER TABLE Empleados ADD DebitoDirecto	bit	null
ALTER TABLE Empleados ADD IdBanco	int	null
ALTER TABLE Empleados ADD IdDispositivo	varchar(50)	null
ALTER TABLE Empleados ADD EsCobrador	bit	null
GO
UPDATE Empleados SET DebitoDirecto = 'False', EsCobrador = 'False'
GO
ALTER TABLE Empleados ALTER COLUMN DebitoDirecto bit not null
ALTER TABLE Empleados ALTER COLUMN EsCobrador	bit	not null
GO

--Dropear todas la FKs
ALTER TABLE Pedidos DROP FK_Pedidos_Empleados
ALTER TABLE Compras DROP FK_Compras_Empleados
ALTER TABLE Clientes DROP FK_Clientes_Empleados
ALTER TABLE Prospectos DROP FK_Prospectos_Empleados
ALTER TABLE EmpleadosComisionesMarcas DROP FK_EmpleadosComisionesMarcas_Empleados
ALTER TABLE EmpleadosComisionesProductos DROP FK_EmpleadosComisionesProductos_Empleados
ALTER TABLE EmpleadosComisionesRubros DROP FK_EmpleadosComisionesRubros_Empleados

IF (OBJECT_ID('FK_Clientes_Empleados1') IS NOT NULL)
BEGIN
    ALTER TABLE Clientes DROP CONSTRAINT FK_Clientes_Empleados1
END;
IF (OBJECT_ID('FK_Clientes_Empleados_DadoAltaPor') IS NOT NULL)
BEGIN
    ALTER TABLE Clientes DROP FK_Clientes_Empleados_DadoAltaPor
END;
IF (OBJECT_ID('FK_Rutas_Empleados') IS NOT NULL)
BEGIN
    ALTER TABLE Rutas DROP FK_Rutas_Empleados
END;

ALTER TABLE MovilRutas DROP FK_MovilRutas_Empleados
ALTER TABLE PedidosProveedores DROP FK_PedidosProveedores_Empleados
ALTER TABLE OrdenesProduccionEstados DROP FK_OrdenesProduccionEstados_Empleados
ALTER TABLE OrdenesProduccion DROP FK_OrdenesProduccion_Empleados
ALTER TABLE OrdenesProduccionProductos DROP FK_OrdenesProduccionProductos_Empleados
ALTER TABLE Produccion DROP FK_Produccion_Empleados
ALTER TABLE MovimientosCompras DROP FK_MovimientosCompras_Empleados
ALTER TABLE Ventas DROP FK_Ventas_Empleados

ALTER TABLE EmpleadosComisionesMarcasPrecios DROP FK_EmpleadosComisionesMarcasPrecios_Empleados
ALTER TABLE EmpleadosComisionesProductosPrecios DROP FK_EmpleadosComisionesProductosPrecios_Empleados
ALTER TABLE EmpleadosComisionesRubrosPrecios DROP FK_EmpleadosComisionesRubrosPrecios_Empleados

ALTER TABLE EmpleadosComisionesMarcas DROP  CONSTRAINT [PK_EmpleadosComisionesMarcas] 
ALTER TABLE EmpleadosComisionesProductos DROP  CONSTRAINT [PK_EmpleadosComisionesProductos] 
ALTER TABLE EmpleadosComisionesRubros DROP  CONSTRAINT [PK_EmpleadosComisionesRubros] 

ALTER TABLE EmpleadosComisionesMarcasPrecios DROP  CONSTRAINT [PK_EmpleadosComisionesMarcasPrecios] 
ALTER TABLE EmpleadosComisionesProductosPrecios DROP  CONSTRAINT [PK_EmpleadosComisionesProductosPrecios] 
ALTER TABLE EmpleadosComisionesRubrosPrecios DROP  CONSTRAINT [PK_EmpleadosComisionesRubrosPrecios] 

ALTER TABLE EmpleadosObjetivos DROP FK_EmpleadosObjetivos_Empleados
ALTER TABLE EmpleadosObjetivos DROP  CONSTRAINT [PK_EmpleadosObjetivos_1] 
GO



-- Tabla Empleados
ALTER TABLE Empleados DROP [PK_Empleados]
ALTER TABLE Empleados ADD  CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--Pedidos
ALTER TABLE Pedidos ADD IdVendedor	int	null
--Compras
ALTER TABLE Compras ADD IdComprador	int	null
--Clientes
ALTER TABLE Clientes ADD IdVendedor	int	null
ALTER TABLE Clientes ADD IdDadoAltaPor	int	null
--AuditoriaClientes
ALTER TABLE AuditoriaClientes ADD IdVendedor	int	null
ALTER TABLE AuditoriaClientes ADD IdDadoAltaPor	int	null
--Prospectos
ALTER TABLE Prospectos ADD IdVendedor	int	null
ALTER TABLE Prospectos ADD IdDadoAltaPor	int	null
--AuditoriaProspectos
ALTER TABLE AuditoriaProspectos ADD IdVendedor	int	null
ALTER TABLE AuditoriaProspectos ADD IdDadoAltaPor	int	null
--EmpleadosComisionesMarcas
ALTER TABLE EmpleadosComisionesMarcas ADD IdEmpleado	int	null
--EmpleadosComisionesProductos
ALTER TABLE EmpleadosComisionesProductos ADD IdEmpleado	int	null
--MovilRutas
ALTER TABLE MovilRutas ADD IdVendedor	int	null
--EmpleadosComisionesRubros
ALTER TABLE EmpleadosComisionesRubros ADD IdEmpleado	int	null
--PedidosProveedores
ALTER TABLE PedidosProveedores ADD IdComprador	int	null
--OrdenesProduccionEstados
ALTER TABLE OrdenesProduccionEstados ADD IdResponsable	int	null
--OrdenesProduccion
ALTER TABLE OrdenesProduccion ADD IdVendedor	int	null
--OrdenesProduccionProductos
ALTER TABLE OrdenesProduccionProductos ADD IdResponsable	int	null
--MovimientosCompras
ALTER TABLE MovimientosCompras ADD IdEmpleado	int	null
--Produccion
ALTER TABLE Produccion ADD IdResponsable	int	null
--Ventas
ALTER TABLE Ventas ADD IdVendedor	int	null
--VentasCajeros
ALTER TABLE VentasCajeros ADD IdVendedor	int	null
--VentasColasImpresionComprobantes
ALTER TABLE VentasColasImpresionComprobantes ADD IdVendedor	int	null
--EmpleadosComisionesMarcasPrecios
ALTER TABLE EmpleadosComisionesMarcasPrecios ADD IdEmpleado	int	null
--EmpleadosComisionesProductosPrecios
ALTER TABLE EmpleadosComisionesProductosPrecios ADD IdEmpleado	int	null
--EmpleadosComisionesRubrosPrecios
ALTER TABLE EmpleadosComisionesRubrosPrecios ADD IdEmpleado	int	null
--EmpleadosObjetivos
ALTER TABLE EmpleadosObjetivos ADD IdEmpleado	int	null
--CuentasCorrientes
ALTER TABLE CuentasCorrientes ADD IdVendedor	int	null
--Fichas
ALTER TABLE Fichas ADD IdVendedor	int	null
ALTER TABLE Fichas ADD IdCobrador	int	null
--FichasPagosDetalle
ALTER TABLE FichasPagosDetalle ADD IdCobrador	int	null
--Preventa
ALTER TABLE Preventa ADD IdEmpleado	int	null
GO

ALTER TABLE Clientes DROP CONSTRAINT [FK_Clientes_Cobradores]
ALTER TABLE Prospectos DROP [FK_Prospectos_Cobradores]
ALTER TABLE Ventas DROP CONSTRAINT [FK_Ventas_Cobradores]
ALTER TABLE CuentasCorrientes DROP CONSTRAINT [FK_CuentasCorrientes_Cobradores]
GO


CREATE TABLE [dbo].[EmpleadosSucursales](
	[IdSucursal] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdCaja] [int] NULL,
	[Observacion] [varchar](100) NULL,
 CONSTRAINT [PK_EmpleadosSucursales] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmpleadosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosSucursales_CajasNombres] FOREIGN KEY([IdSucursal], [IdCaja])
REFERENCES [dbo].[CajasNombres] ([IdSucursal], [IdCaja])
GO

ALTER TABLE [dbo].[EmpleadosSucursales] CHECK CONSTRAINT [FK_EmpleadosSucursales_CajasNombres]
GO

ALTER TABLE [dbo].[EmpleadosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosSucursales_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO

ALTER TABLE [dbo].[EmpleadosSucursales] CHECK CONSTRAINT [FK_EmpleadosSucursales_Empleados]
GO

ALTER TABLE [dbo].[EmpleadosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosSucursales_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[EmpleadosSucursales] CHECK CONSTRAINT [FK_EmpleadosSucursales_Sucursales]
GO


--************************************************ DATOS ************************************************--


DECLARE @idEmpleadoEmpresa int = ISNULL( (SELECT IdEmpleado FROM Empleados  WHERE NombreEmpleado = 'Empresa'), -1)
DECLARE @idCobradorEmpresa int = ISNULL( (SELECT IdCobrador FROM Cobradores WHERE NombreCobrador = 'Empresa'), -1)

IF @idEmpleadoEmpresa <> -1
BEGIN
    -- Tabla Empleados
    UPDATE E
       SET DebitoDirecto = C.DebitoDirecto
         , IdBanco = C.IdBanco
         , IdDispositivo = C.IdDispositivo
         , EsCobrador = 'True'
      FROM Empleados E
      CROSS JOIN Cobradores C
     WHERE E.IdEmpleado = @idEmpleadoEmpresa
       AND C.IdCobrador = @idCobradorEmpresa
END
ELSE
BEGIN
    SET @idEmpleadoEmpresa = @idCobradorEmpresa + 1001;
    INSERT INTO [dbo].[Empleados]
               ([TipoDocEmpleado],[NroDocEmpleado],[IdEmpleado]
               ,[NombreEmpleado]
               ,[TelefonoEmpleado],[CelularEmpleado]
               ,[EsVendedor],[EsComprador],[EsCobrador]
               ,[IdUsuario],[ComisionPorVenta]
               ,[Direccion],[IdLocalidad],[GeoLocalizacionLat],[GeoLocalizacionLng]
               ,[Color],[NivelAutorizacion],[Clave]
               ,[DebitoDirecto],[IdBanco],[IdDispositivo]
               )
         SELECT 'COD', IdCobrador + 1001, @idEmpleadoEmpresa,
                NombreCobrador,
                '','',
                'False', 'False', 'True',
                Null,0 ,
                '.' ,2000 ,NULL ,NULL,
		        NULL,1 ,'',
                DebitoDirecto, IdBanco, IdDispositivo
           FROM Cobradores
          WHERE IdCobrador = @idCobradorEmpresa
END

INSERT INTO [dbo].[Empleados]
           ([TipoDocEmpleado],[NroDocEmpleado],[IdEmpleado]
           ,[NombreEmpleado]
           ,[TelefonoEmpleado],[CelularEmpleado]
           ,[EsVendedor],[EsComprador],[EsCobrador]
           ,[IdUsuario],[ComisionPorVenta]
           ,[Direccion],[IdLocalidad],[GeoLocalizacionLat],[GeoLocalizacionLng]
           ,[Color],[NivelAutorizacion],[Clave]
           ,[DebitoDirecto],[IdBanco],[IdDispositivo]
           )
     SELECT 'COD', IdCobrador + 1001, IdCobrador + 1001,
            NombreCobrador,
            '','',
            'False', 'False', 'True',
            Null,0 ,
            '.' ,2000 ,NULL ,NULL,
		    NULL,1 ,'',
            DebitoDirecto, IdBanco, IdDispositivo
       FROM Cobradores
      WHERE IdCobrador <> @idCobradorEmpresa
;

--Pedidos
UPDATE TAB
   SET TAB.IdVendedor = E.IdEmpleado
  FROM Pedidos TAB
 INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

--Compras
UPDATE TAB
SET TAB.idComprador = E.IdEmpleado
FROM Compras TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocComprador AND E.NroDocEmpleado = TAB.TipoDocComprador

--Clientes
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM Clientes TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

UPDATE TAB
SET TAB.IdDadoAltaPor = E.IdEmpleado
FROM Clientes TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocDadoAltaPor AND E.NroDocEmpleado = TAB.NroDocDadoAltaPor

UPDATE Clientes SET IdCobrador = IdCobrador + 1001   WHERE IdCobrador <> @idCobradorEmpresa
UPDATE Clientes SET IdCobrador = @idEmpleadoEmpresa WHERE IdCobrador =  @idCobradorEmpresa

--AuditoriaClientes
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM AuditoriaClientes TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

UPDATE TAB
SET TAB.IdDadoAltaPor = E.IdEmpleado
FROM AuditoriaClientes TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocDadoAltaPor AND E.NroDocEmpleado = TAB.NroDocDadoAltaPor

UPDATE AuditoriaClientes SET IdCobrador = IdCobrador + 1001   WHERE IdCobrador <> @idCobradorEmpresa
UPDATE AuditoriaClientes SET IdCobrador = @idEmpleadoEmpresa WHERE IdCobrador =  @idCobradorEmpresa

--Prospectos
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM Prospectos TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

UPDATE TAB
SET TAB.IdDadoAltaPor = E.IdEmpleado
FROM Prospectos TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocDadoAltaPor AND E.NroDocEmpleado = TAB.NroDocDadoAltaPor

UPDATE Prospectos SET IdCobrador = IdCobrador + 1001   WHERE IdCobrador <> @idCobradorEmpresa
UPDATE Prospectos SET IdCobrador = @idEmpleadoEmpresa WHERE IdCobrador =  @idCobradorEmpresa

--AuditoriaProspectos
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM AuditoriaProspectos TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

UPDATE TAB
SET TAB.IdDadoAltaPor = E.IdEmpleado
FROM AuditoriaProspectos TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocDadoAltaPor AND E.NroDocEmpleado = TAB.NroDocDadoAltaPor

UPDATE AuditoriaProspectos SET IdCobrador = IdCobrador + 1001   WHERE IdCobrador <> @idCobradorEmpresa
UPDATE AuditoriaProspectos SET IdCobrador = @idEmpleadoEmpresa WHERE IdCobrador =  @idCobradorEmpresa

--EmpleadosComisionesMarcas
UPDATE TAB
SET TAB.IdEmpleado = E.IdEmpleado
FROM EmpleadosComisionesMarcas TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocEmpleado AND E.NroDocEmpleado = TAB.NroDocEmpleado

--EmpleadosComisionesProductos
UPDATE TAB
SET TAB.IdEmpleado = E.IdEmpleado
FROM EmpleadosComisionesProductos TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocEmpleado AND E.NroDocEmpleado = TAB.NroDocEmpleado

--MovilRutas
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM MovilRutas TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

--EmpleadosComisionesRubros
UPDATE TAB
SET TAB.IdEmpleado = E.IdEmpleado
FROM EmpleadosComisionesRubros TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocEmpleado AND E.NroDocEmpleado = TAB.NroDocEmpleado

--PedidosProveedores
UPDATE TAB
SET TAB.IdComprador = E.IdEmpleado
FROM PedidosProveedores TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocComprador AND E.NroDocEmpleado = TAB.NroDocComprador

--OrdenesProduccionEstados
UPDATE TAB
SET TAB.IdResponsable = E.IdEmpleado
FROM OrdenesProduccionEstados TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocResponsable AND E.NroDocEmpleado = TAB.NroDocResponsable

--OrdenesProduccion
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM OrdenesProduccion TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

--OrdenesProduccionProductos
UPDATE TAB
SET TAB.IdResponsable = E.IdEmpleado
FROM OrdenesProduccionProductos TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocResponsable AND E.NroDocEmpleado = TAB.NroDocResponsable

--MovimientosCompras
UPDATE TAB
SET TAB.IdEmpleado = E.IdEmpleado
FROM MovimientosCompras TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocEmpleado AND E.NroDocEmpleado = TAB.NroDocEmpleado

--Produccion
UPDATE TAB
SET TAB.IdResponsable = E.IdEmpleado
FROM Produccion TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocResponsable AND E.NroDocEmpleado = TAB.NroDocResponsable

--Ventas
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM Ventas TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

UPDATE Ventas SET IdCobrador = IdCobrador + 1001   WHERE IdCobrador <> @idCobradorEmpresa
UPDATE Ventas SET IdCobrador = @idEmpleadoEmpresa WHERE IdCobrador =  @idCobradorEmpresa

--VentasCajeros
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM VentasCajeros TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

--VentasColasImpresionComprobantes
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM VentasColasImpresionComprobantes TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

--EmpleadosComisionesMarcasPrecios
UPDATE TAB
SET TAB.IdEmpleado = E.IdEmpleado
FROM EmpleadosComisionesMarcasPrecios TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocEmpleado AND E.NroDocEmpleado = TAB.NroDocEmpleado

--EmpleadosComisionesProductosPrecios
UPDATE TAB
SET TAB.IdEmpleado = E.IdEmpleado
FROM EmpleadosComisionesProductosPrecios TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocEmpleado AND E.NroDocEmpleado = TAB.NroDocEmpleado

--EmpleadosComisionesRubrosPrecios
UPDATE TAB
SET TAB.IdEmpleado = E.IdEmpleado
FROM EmpleadosComisionesRubrosPrecios TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocEmpleado AND E.NroDocEmpleado = TAB.NroDocEmpleado

--EmpleadosObjetivos
UPDATE TAB
SET TAB.IdEmpleado = E.IdEmpleado
FROM EmpleadosObjetivos TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocEmpleado AND E.NroDocEmpleado = TAB.NroDocEmpleado

--CuentasCorrientes
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM CuentasCorrientes TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

UPDATE CuentasCorrientes SET IdCobrador = IdCobrador + 1001   WHERE IdCobrador <> @idCobradorEmpresa
UPDATE CuentasCorrientes SET IdCobrador = @idEmpleadoEmpresa WHERE IdCobrador =  @idCobradorEmpresa

--Fichas
UPDATE TAB
SET TAB.IdVendedor = E.IdEmpleado
FROM Fichas TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocVendedor AND E.NroDocEmpleado = TAB.NroDocVendedor

UPDATE TAB
SET TAB.IdCobrador = E.IdEmpleado
FROM Fichas TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocCobrador AND E.NroDocEmpleado = TAB.NroDocCobrador

--FichasPagosDetalle
UPDATE TAB
SET TAB.IdCobrador = E.IdEmpleado
FROM FichasPagosDetalle TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocCobrador AND E.NroDocEmpleado = TAB.NroDocCobrador

--Preventa
UPDATE TAB
SET TAB.IdEmpleado = E.IdEmpleado
FROM Preventa TAB
INNER JOIN Empleados E
    ON E.TipoDocEmpleado = TAB.TipoDocEmpleado AND E.NroDocEmpleado = TAB.NroDocEmpleado


INSERT INTO [dbo].[EmpleadosSucursales]
           ([IdSucursal]
           ,[IdEmpleado]
           ,[IdCaja]
           ,[Observacion])
 SELECT IdSucursal,
       CASE WHEN IdCobrador = @idCobradorEmpresa THEN @idEmpleadoEmpresa ELSE IdCobrador+1001 END
      ,IdCaja
      ,Observacion
  FROM [dbo].[CobradoresSucursales]

UPDATE Preventa
   SET IdEmpleado = @idEmpleadoEmpresa
 WHERE IdEmpleado IS NULL
--************************************************ DATOS ************************************************--
GO

--Pedidos
ALTER TABLE Pedidos DROP COLUMN TipoDocVendedor	
ALTER TABLE Pedidos DROP COLUMN NroDocVendedor
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Empleados] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Empleados]
GO


--Compras
ALTER TABLE Compras DROP COLUMN TipoDocComprador
ALTER TABLE Compras DROP COLUMN NroDocComprador
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Empleados] FOREIGN KEY([IdComprador])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Empleados]
GO


--Clientes
ALTER TABLE Clientes DROP COLUMN TipoDocVendedor
ALTER TABLE Clientes DROP COLUMN NroDocVendedor
ALTER TABLE Clientes DROP COLUMN TipoDocDadoAltaPor
ALTER TABLE Clientes DROP COLUMN NroDocDadoAltaPor
GO

ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Empleados] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Empleados]
GO

ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_DadoAltaPor] FOREIGN KEY([IdDadoAltaPor])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_DadoAltaPor]
GO

ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Cobradores] FOREIGN KEY([IdCobrador])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Cobradores]
GO


--AuditoriaClientes
ALTER TABLE AuditoriaClientes DROP COLUMN TipoDocVendedor
ALTER TABLE AuditoriaClientes DROP COLUMN NroDocVendedor
ALTER TABLE AuditoriaClientes DROP COLUMN TipoDocDadoAltaPor
ALTER TABLE AuditoriaClientes DROP COLUMN NroDocDadoAltaPor
GO


--Prospectos
ALTER TABLE Prospectos DROP COLUMN TipoDocVendedor
ALTER TABLE Prospectos DROP COLUMN NroDocVendedor
ALTER TABLE Prospectos DROP COLUMN TipoDocDadoAltaPor
ALTER TABLE Prospectos DROP COLUMN NroDocDadoAltaPor
GO

ALTER TABLE [dbo].[Prospectos]  WITH CHECK ADD  CONSTRAINT [FK_Prospectos_Cobradores] FOREIGN KEY([IdCobrador])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Prospectos] CHECK CONSTRAINT [FK_Prospectos_Cobradores]
GO

--AuditoriaProspectos
ALTER TABLE AuditoriaProspectos DROP COLUMN TipoDocVendedor
ALTER TABLE AuditoriaProspectos DROP COLUMN NroDocVendedor
ALTER TABLE AuditoriaProspectos DROP COLUMN TipoDocDadoAltaPor
ALTER TABLE AuditoriaProspectos DROP COLUMN NroDocDadoAltaPor
GO


--EmpleadosComisionesMarcas
ALTER TABLE EmpleadosComisionesMarcas DROP COLUMN TipoDocEmpleado
ALTER TABLE EmpleadosComisionesMarcas DROP COLUMN NroDocEmpleado
GO

ALTER TABLE EmpleadosComisionesMarcas ALTER COLUMN IdEmpleado	int not	null
GO
ALTER TABLE EmpleadosComisionesMarcas ADD  CONSTRAINT [PK_EmpleadosComisionesMarcas] PRIMARY KEY CLUSTERED 
([IdEmpleado] ASC,[IdMarca] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
ALTER TABLE [dbo].[EmpleadosComisionesMarcas]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesMarcas_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[EmpleadosComisionesMarcas] CHECK CONSTRAINT [FK_EmpleadosComisionesMarcas_Empleados]
GO

--EmpleadosComisionesProductos
ALTER TABLE EmpleadosComisionesProductos DROP COLUMN TipoDocEmpleado
ALTER TABLE EmpleadosComisionesProductos DROP COLUMN NroDocEmpleado
GO

ALTER TABLE EmpleadosComisionesProductos ALTER COLUMN IdEmpleado	int not	null
GO
ALTER TABLE EmpleadosComisionesProductos ADD  CONSTRAINT [PK_EmpleadosComisionesProductos] PRIMARY KEY CLUSTERED 
([IdEmpleado] ASC,[IdProducto] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
ALTER TABLE [dbo].[EmpleadosComisionesProductos]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesProductos_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[EmpleadosComisionesProductos] CHECK CONSTRAINT [FK_EmpleadosComisionesProductos_Empleados]
GO


--EmpleadosComisionesRubros
ALTER TABLE EmpleadosComisionesRubros DROP COLUMN TipoDocEmpleado
ALTER TABLE EmpleadosComisionesRubros DROP COLUMN NroDocEmpleado
GO

ALTER TABLE EmpleadosComisionesRubros ALTER COLUMN IdEmpleado	int not	null
GO
ALTER TABLE EmpleadosComisionesRubros ADD  CONSTRAINT [PK_EmpleadosComisionesRubros] PRIMARY KEY CLUSTERED 
([IdEmpleado] ASC,[IdRubro] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
ALTER TABLE [dbo].[EmpleadosComisionesRubros]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesRubros_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[EmpleadosComisionesRubros] CHECK CONSTRAINT [FK_EmpleadosComisionesRubros_Empleados]
GO

--MovilRutas
ALTER TABLE MovilRutas DROP COLUMN TipoDocVendedor	
ALTER TABLE MovilRutas DROP COLUMN NroDocVendedor
GO

ALTER TABLE [dbo].[MovilRutas]  WITH CHECK ADD  CONSTRAINT [FK_MovilRutas_Empleados] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[MovilRutas] CHECK CONSTRAINT [FK_MovilRutas_Empleados]
GO

--PedidosProveedores
ALTER TABLE PedidosProveedores DROP COLUMN TipoDocComprador	
ALTER TABLE PedidosProveedores DROP COLUMN NroDocComprador
GO

ALTER TABLE [dbo].[PedidosProveedores]  WITH CHECK ADD  CONSTRAINT [FK_PedidosProveedores_Empleados] FOREIGN KEY([IdComprador])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[PedidosProveedores] CHECK CONSTRAINT [FK_PedidosProveedores_Empleados]
GO

--OrdenesProduccionEstados
ALTER TABLE OrdenesProduccionEstados DROP COLUMN TipoDocResponsable	
ALTER TABLE OrdenesProduccionEstados DROP COLUMN NroDocResponsable
GO

ALTER TABLE [dbo].[OrdenesProduccionEstados]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionEstados_Empleados] FOREIGN KEY([IdResponsable])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[OrdenesProduccionEstados] CHECK CONSTRAINT [FK_OrdenesProduccionEstados_Empleados]
GO

--OrdenesProduccion
ALTER TABLE OrdenesProduccion DROP COLUMN TipoDocVendedor	
ALTER TABLE OrdenesProduccion DROP COLUMN NroDocVendedor
GO

ALTER TABLE [dbo].[OrdenesProduccion]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccion_Empleados] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[OrdenesProduccion] CHECK CONSTRAINT [FK_OrdenesProduccion_Empleados]
GO

--OrdenesProduccionProductos
ALTER TABLE OrdenesProduccionProductos DROP COLUMN TipoDocResponsable	
ALTER TABLE OrdenesProduccionProductos DROP COLUMN NroDocResponsable
GO

ALTER TABLE [dbo].[OrdenesProduccionProductos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionProductos_Empleados] FOREIGN KEY([IdResponsable])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[OrdenesProduccionProductos] CHECK CONSTRAINT [FK_OrdenesProduccionProductos_Empleados]
GO

--MovimientosCompras
ALTER TABLE MovimientosCompras DROP COLUMN TipoDocEmpleado	
ALTER TABLE MovimientosCompras DROP COLUMN NroDocEmpleado
GO

ALTER TABLE [dbo].[MovimientosCompras]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosCompras_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[MovimientosCompras] CHECK CONSTRAINT [FK_MovimientosCompras_Empleados]
GO

--Produccion
ALTER TABLE Produccion DROP COLUMN TipoDocResponsable	
ALTER TABLE Produccion DROP COLUMN NroDocResponsable
GO

ALTER TABLE [dbo].[Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Produccion_Empleados] FOREIGN KEY([IdResponsable])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Produccion] CHECK CONSTRAINT [FK_Produccion_Empleados]
GO

--Ventas
ALTER TABLE Ventas DROP COLUMN TipoDocVendedor	
ALTER TABLE Ventas DROP COLUMN NroDocVendedor
GO

ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Empleados] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Empleados]
ALTER TABLE Ventas ALTER COLUMN IdVendedor	int	not null
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Cobradores] FOREIGN KEY([IdCobrador])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO


--VentasCajeros
ALTER TABLE VentasCajeros DROP COLUMN TipoDocVendedor	
ALTER TABLE VentasCajeros DROP COLUMN NroDocVendedor
GO
ALTER TABLE VentasCajeros ALTER COLUMN IdVendedor	int	not null
GO

--VentasColasImpresionComprobantes
ALTER TABLE VentasColasImpresionComprobantes DROP COLUMN TipoDocVendedor	
ALTER TABLE VentasColasImpresionComprobantes DROP COLUMN NroDocVendedor
GO
ALTER TABLE VentasColasImpresionComprobantes ALTER COLUMN IdVendedor	int	not null
GO

--EmpleadosComisionesMarcasPrecios
ALTER TABLE EmpleadosComisionesMarcasPrecios DROP COLUMN TipoDocEmpleado
ALTER TABLE EmpleadosComisionesMarcasPrecios DROP COLUMN NroDocEmpleado
GO
ALTER TABLE EmpleadosComisionesMarcasPrecios ALTER COLUMN IdEmpleado	int not	null
GO

ALTER TABLE EmpleadosComisionesMarcasPrecios  ADD CONSTRAINT [PK_EmpleadosComisionesMarcasPrecios] PRIMARY KEY CLUSTERED 
([IdMarca] ASC,[IdListaPrecios] ASC,[IdEmpleado] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
ALTER TABLE [dbo].[EmpleadosComisionesMarcasPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[EmpleadosComisionesMarcasPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_Empleados]
GO

--EmpleadosComisionesProductosPrecios
ALTER TABLE EmpleadosComisionesProductosPrecios DROP COLUMN TipoDocEmpleado
ALTER TABLE EmpleadosComisionesProductosPrecios DROP COLUMN NroDocEmpleado
GO

ALTER TABLE EmpleadosComisionesProductosPrecios ALTER COLUMN IdEmpleado	int not	null
GO
ALTER TABLE EmpleadosComisionesProductosPrecios ADD CONSTRAINT [PK_EmpleadosComisionesProductosPrecios] PRIMARY KEY CLUSTERED 
([IdProducto] ASC,[IdListaPrecios] ASC,[IdEmpleado] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
ALTER TABLE [dbo].[EmpleadosComisionesProductosPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[EmpleadosComisionesProductosPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_Empleados]
GO

--EmpleadosComisionesRubrosPrecios
ALTER TABLE EmpleadosComisionesRubrosPrecios DROP COLUMN TipoDocEmpleado
ALTER TABLE EmpleadosComisionesRubrosPrecios DROP COLUMN NroDocEmpleado
GO

ALTER TABLE EmpleadosComisionesRubrosPrecios ALTER COLUMN IdEmpleado	int not	null
GO
ALTER TABLE EmpleadosComisionesRubrosPrecios ADD CONSTRAINT [PK_EmpleadosComisionesRubrosPrecios] PRIMARY KEY CLUSTERED 
([IdRubro] ASC,[IdListaPrecios] ASC,[IdEmpleado] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
ALTER TABLE [dbo].[EmpleadosComisionesRubrosPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[EmpleadosComisionesRubrosPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_Empleados]
GO

--EmpleadosObjetivos
ALTER TABLE EmpleadosObjetivos DROP COLUMN TipoDocEmpleado
ALTER TABLE EmpleadosObjetivos DROP COLUMN NroDocEmpleado
GO

ALTER TABLE EmpleadosObjetivos ALTER COLUMN IdEmpleado	int not	null
GO
ALTER TABLE EmpleadosObjetivos ADD CONSTRAINT [PK_EmpleadosObjetivos] PRIMARY KEY CLUSTERED 
([PeriodoFiscal] ASC,[IdEmpleado] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
ALTER TABLE [dbo].[EmpleadosObjetivos]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosObjetivos_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[EmpleadosObjetivos] CHECK CONSTRAINT [FK_EmpleadosObjetivos_Empleados]
GO

--CuentasCorrientes
ALTER TABLE CuentasCorrientes DROP COLUMN TipoDocVendedor	
ALTER TABLE CuentasCorrientes DROP COLUMN NroDocVendedor
GO
ALTER TABLE [dbo].[CuentasCorrientes]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientes_Empleados] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[CuentasCorrientes] CHECK CONSTRAINT [FK_CuentasCorrientes_Empleados]
ALTER TABLE [dbo].[CuentasCorrientes]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientes_Cobrador] FOREIGN KEY([IdCobrador])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[CuentasCorrientes] CHECK CONSTRAINT [FK_CuentasCorrientes_Cobrador]
GO
/* ---------- ERROR ---------- */

--Fichas
ALTER TABLE Fichas DROP COLUMN TipoDocVendedor	
ALTER TABLE Fichas DROP COLUMN NroDocVendedor
ALTER TABLE Fichas DROP COLUMN TipoDocCobrador
ALTER TABLE Fichas DROP COLUMN NroDocCobrador
GO

ALTER TABLE Fichas ALTER COLUMN IdVendedor	int	not null
ALTER TABLE [dbo].[Fichas]  WITH CHECK ADD  CONSTRAINT [FK_Fichas_Vendedor] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Fichas] CHECK CONSTRAINT [FK_Fichas_Vendedor]
GO

ALTER TABLE Fichas ALTER COLUMN IdCobrador	int	not null
ALTER TABLE [dbo].[Fichas]  WITH CHECK ADD  CONSTRAINT [FK_Fichas_Cobradores] FOREIGN KEY([IdCobrador])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[Fichas] CHECK CONSTRAINT [FK_Fichas_Cobradores]
GO


--FichasPagosDetalle
ALTER TABLE FichasPagosDetalle DROP COLUMN TipoDocCobrador
ALTER TABLE FichasPagosDetalle DROP COLUMN NroDocCobrador
GO

ALTER TABLE FichasPagosDetalle ALTER COLUMN IdCobrador	int	not null
ALTER TABLE [dbo].[FichasPagosDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FichasPagosDetalle_Cobrador] FOREIGN KEY([IdCobrador])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[FichasPagosDetalle] CHECK CONSTRAINT [FK_FichasPagosDetalle_Cobrador]
GO

--Preventa
ALTER TABLE Preventa DROP COLUMN TipoDocEmpleado	
ALTER TABLE Preventa DROP COLUMN NroDocEmpleado
GO

ALTER TABLE Preventa ALTER COLUMN IdEmpleado int	not null
GO
ALTER TABLE [dbo].[PreVenta]  WITH CHECK ADD  CONSTRAINT [FK_PreVenta_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
ALTER TABLE [dbo].[PreVenta] CHECK CONSTRAINT [FK_PreVenta_Empleados]
GO

DROP TABLE [dbo].[CobradoresSucursales]
DROP TABLE [dbo].[Cobradores]
GO



UPDATE CRMNovedades
   SET IdFuncion = 'Empleados'
 WHERE IdFuncion = 'CobradoresABM'
UPDATE Bitacora
   SET IdFuncion = 'Empleados'
 WHERE IdFuncion = 'CobradoresABM'
DELETE RolesFunciones WHERE IdFuncion = 'CobradoresABM'
DELETE Funciones WHERE Id = 'CobradoresABM'
