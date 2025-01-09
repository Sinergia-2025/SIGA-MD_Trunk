SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
GO

PRINT ''
PRINT '1. Nueva Tabla: ProduccionModelosFormasVariables'
IF dbo.ExisteTabla('ProduccionModelosFormasVariables') = 0
BEGIN
    CREATE TABLE [dbo].[ProduccionModelosFormasVariables](
	    [IdProduccionModeloForma] [int] NOT NULL,
	    [CodigoVariable] [varchar](30) NOT NULL,
	    [ValorDecimalVariable] [decimal](18, 10) NOT NULL,
     CONSTRAINT [PK_ProduccionModelosFormasVariables] 
     PRIMARY KEY CLUSTERED ([IdProduccionModeloForma] ASC, [CodigoVariable] ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

PRINT ''
PRINT '1.1. Tabla ProduccionModelosFormasVariables: FK_ProduccionModelosFormasVariables_ProduccionModelosFormas'
IF dbo.ExisteFK('FK_ProduccionModelosFormasVariables_ProduccionModelosFormas') = 0
BEGIN
    ALTER TABLE [dbo].[ProduccionModelosFormasVariables]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionModelosFormasVariables_ProduccionModelosFormas] FOREIGN KEY([IdProduccionModeloForma])
    REFERENCES [dbo].[ProduccionModelosFormas] ([IdProduccionModeloForma])
    ALTER TABLE [dbo].[ProduccionModelosFormasVariables] CHECK CONSTRAINT [FK_ProduccionModelosFormasVariables_ProduccionModelosFormas]
END
GO

PRINT ''
PRINT '1.2. Tabla ProduccionModelosFormasVariables: DROP COLUMN Coeficiente'
IF dbo.ExisteCampo('ProduccionModelosFormas', 'Coeficiente') = 1
BEGIN
    ALTER TABLE dbo.ProduccionModelosFormas	DROP COLUMN Coeficiente
END
GO

DELETE ProduccionModelosFormasVariables
IF dbo.BaseConCUIT('30676889376') = 1
BEGIN
    PRINT ''
    PRINT '1.3. Tabla ProduccionModelosFormas: Ajustar datos para ASA SA'
    MERGE INTO ProduccionModelosFormas AS D
            USING (SELECT 1 IdProduccionModeloForma, 'S2' NombreProduccionModeloForma UNION
                   SELECT 2 IdProduccionModeloForma, 'S3' NombreProduccionModeloForma UNION
                   SELECT 3 IdProduccionModeloForma, 'S4' NombreProduccionModeloForma
                  ) AS O ON D.IdProduccionModeloForma = O.IdProduccionModeloForma
        WHEN MATCHED THEN
            UPDATE SET D.NombreProduccionModeloForma = O.NombreProduccionModeloForma
        WHEN NOT MATCHED THEN 
            INSERT (IdProduccionModeloForma, NombreProduccionModeloForma) VALUES (O.IdProduccionModeloForma, O.NombreProduccionModeloForma)
    ;

    PRINT ''
    PRINT '1.4. Tabla ProduccionModelosFormasVariables: Ajustar datos para ASA SA'
    INSERT INTO [dbo].[ProduccionModelosFormasVariables]
        ([IdProduccionModeloForma], [CodigoVariable], [ValorDecimalVariable])
    VALUES
        (1, 'COE_ARCHITRAVE', 0),(1, 'COE_ALTO', 1),(1, 'DIST_ADICIONAL',  420),
        (2, 'COE_ARCHITRAVE', 1),(2, 'COE_ALTO', 1),(2, 'DIST_ADICIONAL', -100),
        (3, 'COE_ARCHITRAVE', 0),(3, 'COE_ALTO', 2),(3, 'DIST_ADICIONAL',  400)
END
ELSE
BEGIN
    PRINT ''
    PRINT '1.3. Tabla ProduccionModelosFormas: Ajustar datos para otros'
    DELETE ProduccionModelosFormas
    MERGE INTO ProduccionModelosFormas AS D
            USING (SELECT 1 IdProduccionModeloForma, 'UNICA' NombreProduccionModeloForma) AS O ON D.IdProduccionModeloForma = O.IdProduccionModeloForma
        WHEN MATCHED THEN
            UPDATE SET D.NombreProduccionModeloForma = O.NombreProduccionModeloForma
        WHEN NOT MATCHED THEN 
            INSERT (IdProduccionModeloForma, NombreProduccionModeloForma) VALUES (O.IdProduccionModeloForma, O.NombreProduccionModeloForma)
    ;
END
GO


PRINT ''
PRINT '2. Asignar Deposito y Ubicacion a Ventas Productos'
BEGIN
	UPDATE VentasProductos 
	SET VentasProductos.IdDeposito  = PS.IdDepositoDefecto,
		VentasProductos.IdUbicacion  = PS.IdUbicacionDefecto 
	FROM VentasProductos AS VP
		INNER JOIN ProductosSucursales AS PS ON PS.IdProducto = VP.IdProducto AND PS.IdSucursal = VP.IdSucursal  
	WHERE VP.IdDeposito IS NULL
END

PRINT ''
PRINT '3. Asignar Deposito y Ubicacion a Ventas Productos'
BEGIN
	UPDATE ComprasProductos 
	SET ComprasProductos.IdDeposito  = PS.IdDepositoDefecto,
		ComprasProductos.IdUbicacion  = PS.IdUbicacionDefecto 
	FROM ComprasProductos AS VP
		INNER JOIN ProductosSucursales AS PS ON PS.IdProducto = VP.IdProducto AND PS.IdSucursal = VP.IdSucursal  
	WHERE VP.IdDeposito IS NULL
END

