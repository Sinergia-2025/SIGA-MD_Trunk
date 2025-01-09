PRINT ''
PRINT '7. Tabla Nueva de Estados Ubicaciones - Asigna Valores Iniciales.-'
IF NOT EXISTS(SELECT * FROM EstadosUbicaciones  WHERE IdEstado = 1)
BEGIN
	INSERT INTO [dbo].[EstadosUbicaciones]
			([IdEstado],[NombreEstado],[OrdenEstado],[Activo])
	 VALUES (1, 'DISPONIBLE', 1, 'True')
END
GO

DECLARE @Operativo  VARCHAR(MAX) ='OPERATIVO'
DECLARE @Reservado  VARCHAR(MAX) ='RESERVADO'
DECLARE @EnTransito VARCHAR(MAX) ='ENTRANSITO'
DECLARE @Defectuoso VARCHAR(MAX) ='DEFECTUOSO'

DECLARE @idDepositoOperativo  INT = 1
DECLARE @idDepositoReservado  INT = 99
DECLARE @idDepositoDefectuoso INT = 98

PRINT ''
PRINT '8. Carga Sucursales Deposito.-'
BEGIN
	DECLARE @idDeposito Int = @idDepositoOperativo
	DECLARE @NombreDeposito VARCHAR(MAX) = 'Deposito Por Defecto.'

	MERGE INTO SucursalesDepositos AS DEST
			USING (SELECT IdSucursal, @idDeposito AS IdDeposito, Nombre AS NombreDeposito, 
                            RIGHT('00' + CONVERT(VARCHAR(MAX), IdSucursal), 3) + '.' + RIGHT('00' + CONVERT(VARCHAR(MAX), @idDeposito), 3) + '.000' AS CodigoDeposito, 
							idSucursalAsociada AS SucursalAsociada, CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idDeposito END IdDepositoAsociado,
                            'True' as DisponibleVenta, 'True' AS Activo, @Operativo as TipoDeposito FROM Sucursales) 
					AS ORIG ON DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdDeposito = ORIG.IdDeposito
		WHEN NOT MATCHED THEN 
			INSERT (IdSucursal, IdDeposito, NombreDeposito, CodigoDeposito, SucursalAsociada, DepositoAsociado, DisponibleVenta, Activo, TipoDeposito)
			VALUES (ORIG.IdSucursal, ORIG.IdDeposito, ORIG.NombreDeposito, ORIG.CodigoDeposito, ORIG.SucursalAsociada, ORIG.IdDepositoAsociado, ORIG.DisponibleVenta, ORIG.Activo, ORIG.TipoDeposito);

    IF EXISTS (SELECT * FROM MovimientosComprasProductos WHERE CantidadReservado <> 0)
    BEGIN
	    SET @idDeposito = @idDepositoReservado
	    SET @NombreDeposito = 'Reservado'

	    MERGE INTO SucursalesDepositos AS DEST
			    USING (SELECT IdSucursal, @idDeposito AS IdDeposito, @NombreDeposito + ' ' + Nombre AS NombreDeposito, 
                                RIGHT('00' + CONVERT(VARCHAR(MAX), IdSucursal), 3) + '.RES.000' AS CodigoDeposito, 
							    idSucursalAsociada AS SucursalAsociada, CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idDeposito END IdDepositoAsociado,
                                'True' as DisponibleVenta, 'True' AS Activo, @Reservado as TipoDeposito FROM Sucursales) 
					    AS ORIG ON DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdDeposito = ORIG.IdDeposito
		    WHEN NOT MATCHED THEN 
			    INSERT (IdSucursal, IdDeposito, NombreDeposito, CodigoDeposito, SucursalAsociada, DepositoAsociado, DisponibleVenta, Activo, TipoDeposito)
			    VALUES (ORIG.IdSucursal, ORIG.IdDeposito, ORIG.NombreDeposito, ORIG.CodigoDeposito, ORIG.SucursalAsociada, ORIG.IdDepositoAsociado, ORIG.DisponibleVenta, ORIG.Activo, ORIG.TipoDeposito);
    END

    IF EXISTS (SELECT * FROM MovimientosComprasProductos WHERE CantidadDefectuoso <> 0)
    BEGIN
	    SET @idDeposito = @idDepositoDefectuoso
	    SET @NombreDeposito = 'Defectuosos'

	    MERGE INTO SucursalesDepositos AS DEST
			    USING (SELECT IdSucursal, @idDeposito AS IdDeposito, @NombreDeposito + ' ' + Nombre AS NombreDeposito, 
                                RIGHT('00' + CONVERT(VARCHAR(MAX), IdSucursal), 3) + '.DEF.000' AS CodigoDeposito, 
							    idSucursalAsociada AS SucursalAsociada, CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idDeposito END IdDepositoAsociado,
                                'True' as DisponibleVenta, 'True' AS Activo, @Defectuoso as TipoDeposito FROM Sucursales) 
					    AS ORIG ON DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdDeposito = ORIG.IdDeposito
		    WHEN NOT MATCHED THEN 
			    INSERT (IdSucursal, IdDeposito, NombreDeposito, CodigoDeposito, SucursalAsociada, DepositoAsociado, DisponibleVenta, Activo, TipoDeposito)
			    VALUES (ORIG.IdSucursal, ORIG.IdDeposito, ORIG.NombreDeposito, ORIG.CodigoDeposito, ORIG.SucursalAsociada, ORIG.IdDepositoAsociado, ORIG.DisponibleVenta, ORIG.Activo, ORIG.TipoDeposito);
    END
END


PRINT ''
PRINT '9. Carga Sucursales Ubicaciones.-'
BEGIN
	SET @idDeposito  = @idDepositoOperativo
	DECLARE @idUbicacion INT = 1
	DECLARE @NombreUbicacion VARCHAR(MAX) = 'Unica'

	MERGE INTO SucursalesUbicaciones AS DEST
			USING (SELECT IdSucursal, @idDeposito AS IdDeposito, @IdUbicacion AS IdUbicacion,  @NombreUbicacion AS NombreUbicacion, 
                          RIGHT('00' + CONVERT(VARCHAR(MAX), IdSucursal), 3) + '.' + RIGHT('00' + CONVERT(VARCHAR(MAX), @idDeposito), 3) + '.' + RIGHT('00' + CONVERT(VARCHAR(MAX), @idUbicacion), 3) AS CodigoUbicacion,
			              idSucursalAsociada AS SucursalAsociada, CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idDeposito END IdDepositoAsociado,
                          CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idUbicacion END IdUbicacionAsociado,
                          'True' AS Activo, (SELECT MIN(IdEstado) FROM EstadosUbicaciones) AS EstadoUbicacion  FROM Sucursales) 
					AS ORIG ON DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdDeposito = ORIG.IdDeposito AND DEST.IdUbicacion = ORIG.IdUbicacion
		WHEN NOT MATCHED THEN 
			INSERT (IdSucursal, IdDeposito, IdUbicacion, NombreUbicacion, CodigoUbicacion, EstadoUbicacion, SucursalAsociada, DepositoAsociado, UbicacionAsociada, Activo) 
					VALUES (ORIG.IdSucursal, ORIG.IdDeposito, ORIG.IdUbicacion, ORIG.NombreUbicacion, ORIG.CodigoUbicacion, ORIG.EstadoUbicacion, ORIG.SucursalAsociada, ORIG.IdDepositoAsociado, ORIG.IdUbicacionAsociado, ORIG.Activo);


    IF EXISTS (SELECT * FROM MovimientosComprasProductos WHERE CantidadReservado <> 0)
    BEGIN
	    SET @idDeposito = @idDepositoReservado
	    SET @NombreUbicacion = 'Reservado'

	    MERGE INTO SucursalesUbicaciones AS DEST
			    USING (SELECT IdSucursal, @idDeposito AS IdDeposito, @IdUbicacion AS IdUbicacion,  @NombreUbicacion AS NombreUbicacion, 
                              RIGHT('00' + CONVERT(VARCHAR(MAX), IdSucursal), 3) + '.RES.' + RIGHT('00' + CONVERT(VARCHAR(MAX), @idUbicacion), 3) AS CodigoUbicacion,
			                  idSucursalAsociada AS SucursalAsociada, CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idDeposito END IdDepositoAsociado,
                              CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idUbicacion END IdUbicacionAsociado,
                              'True' AS Activo, (SELECT MIN(IdEstado) FROM EstadosUbicaciones) AS EstadoUbicacion  FROM Sucursales) 
					    AS ORIG ON DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdDeposito = ORIG.IdDeposito AND DEST.IdUbicacion = ORIG.IdUbicacion
		    WHEN NOT MATCHED THEN 
			    INSERT (IdSucursal, IdDeposito, IdUbicacion, NombreUbicacion, CodigoUbicacion, EstadoUbicacion, SucursalAsociada, DepositoAsociado, UbicacionAsociada, Activo) 
					    VALUES (ORIG.IdSucursal, ORIG.IdDeposito, ORIG.IdUbicacion, ORIG.NombreUbicacion, ORIG.CodigoUbicacion, ORIG.EstadoUbicacion, ORIG.SucursalAsociada, ORIG.IdDepositoAsociado, ORIG.IdUbicacionAsociado, ORIG.Activo);
    END

    IF EXISTS (SELECT * FROM MovimientosComprasProductos WHERE CantidadDefectuoso <> 0)
    BEGIN
	    SET @idDeposito = @idDepositoDefectuoso
	    SET @NombreUbicacion = 'Defectuosos'

	    MERGE INTO SucursalesUbicaciones AS DEST
			    USING (SELECT IdSucursal, @idDeposito AS IdDeposito, @IdUbicacion AS IdUbicacion,  @NombreUbicacion AS NombreUbicacion, 
                              RIGHT('00' + CONVERT(VARCHAR(MAX), IdSucursal), 3) + '.DEF.' + RIGHT('00' + CONVERT(VARCHAR(MAX), @idUbicacion), 3) AS CodigoUbicacion,
			                  idSucursalAsociada AS SucursalAsociada, CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idDeposito END IdDepositoAsociado,
                              CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idUbicacion END IdUbicacionAsociado,
                              'True' AS Activo, (SELECT MIN(IdEstado) FROM EstadosUbicaciones) AS EstadoUbicacion  FROM Sucursales) 
					    AS ORIG ON DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdDeposito = ORIG.IdDeposito AND DEST.IdUbicacion = ORIG.IdUbicacion
		    WHEN NOT MATCHED THEN 
			    INSERT (IdSucursal, IdDeposito, IdUbicacion, NombreUbicacion, CodigoUbicacion, EstadoUbicacion, SucursalAsociada, DepositoAsociado, UbicacionAsociada, Activo) 
					    VALUES (ORIG.IdSucursal, ORIG.IdDeposito, ORIG.IdUbicacion, ORIG.NombreUbicacion, ORIG.CodigoUbicacion, ORIG.EstadoUbicacion, ORIG.SucursalAsociada, ORIG.IdDepositoAsociado, ORIG.IdUbicacionAsociado, ORIG.Activo);
    END

END

PRINT ''
PRINT '10. Carga Productos Deposito.-'
BEGIN
	TRUNCATE TABLE ProductosDepositos
	MERGE INTO ProductosDepositos AS DEST
			USING (SELECT P.IdProducto, SD.IdSucursal, SD.IdDeposito
                        , CASE SD.IdDeposito
                               WHEN @idDepositoOperativo   THEN PS.Stock
                               WHEN @idDepositoReservado   THEN PS.StockReservado_Viejo
                               WHEN @idDepositoDefectuoso  THEN PS.StockDefectuoso_Viejo
                               ELSE 0 END AS Stock
                        , 0 AS Stock2
                     FROM Productos P
                    CROSS JOIN SucursalesDepositos SD
                    INNER JOIN ProductosSucursales PS ON PS.IdSucursal = SD.IdSucursal AND PS.IdProducto = P.IdProducto) AS ORIG 
				ON ORIG.IdProducto = DEST.IdProducto AND DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdDeposito = ORIG.IdDeposito
		WHEN NOT MATCHED THEN 
			INSERT (IdProducto, IdSucursal, IdDeposito, Stock, Stock2) 
					VALUES (ORIG.IdProducto, ORIG.IdSucursal, ORIG.IdDeposito, ISNULL(ORIG.Stock, 0), ISNULL(ORIG.Stock2, 0));
END

PRINT ''
PRINT '11. Carga Productos Ubicaciones.-'
BEGIN
	TRUNCATE TABLE ProductosUbicaciones
	MERGE INTO ProductosUbicaciones AS DEST
			USING (SELECT P.IdProducto, SU.IdSucursal, SU.IdDeposito, SU.IdUbicacion
                        , CASE SU.IdDeposito
                               WHEN @idDepositoOperativo   THEN PS.Stock
                               WHEN @idDepositoReservado   THEN PS.StockReservado_Viejo
                               WHEN @idDepositoDefectuoso  THEN PS.StockDefectuoso_Viejo
                               ELSE 0 END AS Stock
                        , CASE SU.IdDeposito
                               WHEN @idDepositoOperativo   THEN PS.Stock
                               WHEN @idDepositoReservado   THEN PS.StockReservado_Viejo
                               WHEN @idDepositoDefectuoso  THEN PS.StockDefectuoso_Viejo
                               ELSE 0 END AS Stock2
                     FROM Productos P
                    CROSS JOIN SucursalesUbicaciones SU
                    INNER JOIN ProductosSucursales PS ON PS.IdSucursal = SU.IdSucursal AND PS.IdProducto = P.IdProducto
				  ) AS ORIG 
				ON ORIG.IdProducto = DEST.IdProducto AND DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdDeposito = ORIG.IdDeposito AND DEST.IdUbicacion = ORIG.IdUbicacion
		WHEN NOT MATCHED THEN 
			INSERT (IdProducto, IdSucursal, IdDeposito, IdUbicacion, Stock, Stock2) 
					VALUES (ORIG.IdProducto, ORIG.IdSucursal, ORIG.IdDeposito, ORIG.IdUbicacion, ISNULL(ORIG.Stock, 0), ISNULL(ORIG.Stock2, 0));
END
GO
