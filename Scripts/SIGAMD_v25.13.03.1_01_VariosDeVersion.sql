-------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteCampo('ProductosFormulas','PorcentajeGanancia') = 0
BEGIN

ALTER TABLE ProductosFormulas ADD PorcentajeGanancia decimal(16,10) null

END
GO 

UPDATE ProductosFormulas SET PorcentajeGanancia = 0
GO

ALTER TABLE ProductosFormulas ALTER COLUMN PorcentajeGanancia decimal(16,10) NOT NULL
GO


update productosformulas set
 PorcentajeGanancia = convert(decimal(10,2), (((psp.PrecioVenta - ps.PrecioCosto )/ ps.PrecioCosto) * 100))
 from productosformulas pf
inner join ProductosSucursales ps on ps.IdProducto = pf.idproducto
inner join ProductosSucursalesPrecios psp on psp.IdProducto = pf.IdProducto
where IdListaPrecios = 0 
and psp.precioventa <> 0
and ps.PrecioCosto <> 0
and exists(select * from ProductosComponentes pc where pc.IdProducto = pf.IdProducto and pc.IdFormula = pf.idformula)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Depósitos de tipo "RESERVADO".'

DECLARE @Reservado  VARCHAR(MAX) ='RESERVADO'
DECLARE @NombreDeposito VARCHAR(MAX) = 'Reservado'

DECLARE @idDeposito INT;

IF EXISTS (SELECT * FROM SucursalesDepositos WHERE TipoDeposito = 'RESERVADO')
BEGIN
SET @IdDeposito = (SELECT TOP 1 IdDeposito FROM SucursalesDepositos WHERE TipoDeposito = 'RESERVADO')
END
ELSE
BEGIN
SET @IdDeposito = 99
END

	    MERGE INTO SucursalesDepositos AS DEST
		USING (SELECT IdSucursal, @idDeposito AS IdDeposito, @NombreDeposito + ' ' + Nombre AS NombreDeposito, 
        RIGHT('00' + CONVERT(VARCHAR(MAX), IdSucursal), 3) + '.RES.000' AS CodigoDeposito, 
		idSucursalAsociada AS SucursalAsociada, CASE WHEN idSucursalAsociada IS NULL THEN NULL ELSE @idDeposito END IdDepositoAsociado,
        'True' AS DisponibleVenta, 'True' AS Activo, @Reservado AS TipoDeposito FROM Sucursales) 
		AS ORIG ON DEST.IdSucursal = ORIG.IdSucursal AND DEST.IdDeposito = ORIG.IdDeposito
		WHEN NOT MATCHED THEN 
	    INSERT (IdSucursal, IdDeposito, NombreDeposito, CodigoDeposito, SucursalAsociada, DepositoAsociado, DisponibleVenta, Activo, TipoDeposito)
	    VALUES (ORIG.IdSucursal, ORIG.IdDeposito, ORIG.NombreDeposito, ORIG.CodigoDeposito, ORIG.SucursalAsociada, ORIG.IdDepositoAsociado, ORIG.DisponibleVenta, ORIG.Activo, ORIG.TipoDeposito);

-------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '2. Asignación de Usuarios.'

        MERGE INTO SucursalesDepositosUsuarios AS DEST
        USING SucursalesDepositosUsuarios AS ORIG
        ON DEST.IdUsuario = ORIG.IdUsuario AND DEST.IdDeposito = @idDeposito
        WHEN NOT MATCHED THEN
        INSERT (IdDeposito, IdSucursal, IdUsuario, Responsable, UsuarioDefault, PermitirEscritura)
        VALUES (@IdDeposito, ORIG.IdSucursal, ORIG.IdUsuario, ORIG.Responsable, ORIG.UsuarioDefault, ORIG.PermitirEscritura);

-------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '3. Ubicaciones para Depósitos de tipo "RESERVADO".'

DECLARE @NombreUbicacion VARCHAR(MAX) =  'Reservadas'

DECLARE @idUbicacion INT;

IF EXISTS (SELECT * FROM SucursalesUbicaciones WHERE IdDeposito = @IdDeposito)
BEGIN
SET @IdUbicacion = (SELECT MAX(IdUbicacion) FROM SucursalesUbicaciones WHERE IdDeposito = @IdDeposito)
END

ELSE
BEGIN
SET @IdUbicacion = 99 --Si no existen Ubicaciones en dicho Depósito, se crea en 99 por defecto
END

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

-------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '4. Corrección de Campos NULL en Servicio Técnico.'

IF dbo.ExisteTabla('CRMNovedadesProductos') = 1 AND EXISTS (SELECT * FROM CRMNovedades WHERE FechaNovedad BETWEEN DATEADD(MONTH,-2,GETDATE()) AND GETDATE())
BEGIN

        UPDATE  CRMNovedadesProductos SET
        IdSucursalActual = (SELECT MIN(IdSucursal) FROM ImpresorasPCs), 
        IdDepositoActual = (SELECT TOP 1 IdDeposito FROM SucursalesDepositos WHERE TipoDeposito = 'OPERATIVO'), 
        IdUbicacionActual = (SELECT TOP 1 IdUbicacion FROM ProductosUbicaciones), 
        IdsucursalAnterior = (SELECT MIN(IdSucursal) FROM ImpresorasPCs), 
        IdDepositoAnterior = @IdDeposito,
        IdUbicacionAnterior= @idUbicacion
        WHERE IdSucursalActual IS NULL 
        AND IdDepositoActual IS NULL
        AND IdUbicacionActual IS NULL
        AND IdSucursalActual IS NULL
        AND IdDepositoAnterior IS NULL
        AND IdUbicacionAnterior IS NULL;
        END

-------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '5. Configuración de Parámetros de RMA.'
PRINT ''

--Configuración de Movimiento para Consumo.

IF EXISTS (SELECT * FROM Parametros WHERE IdParametro = 'CRMMOVIMIENTOCONSUMO')
	BEGIN
		IF EXISTS (SELECT * FROM TiposMovimientos WHERE IdTipoMovimiento = 'SRV_CONSUMO')
		BEGIN
		UPDATE Parametros SET ValorParametro = 'SRV_CONSUMO' WHERE IdParametro = 'CRMMOVIMIENTOCONSUMO'
		END

		ELSE
		BEGIN
		INSERT INTO TiposMovimientos VALUES
		('SRV_CONSUMO', 'Consumo Service', -1, NULL, 0, 0, 0, 0, 0, 'NO', NULL, 0, 0);
		UPDATE Parametros SET ValorParametro = 'SRV_CONSUMO' WHERE IdParametro = 'CRMMOVIMIENTOCONSUMO';
		END
	END

	ELSE
	BEGIN
	INSERT INTO Parametros VALUES
	('CRMMOVIMIENTOCONSUMO', NULL, NULL, 'Movimiento para Consumo', (SELECT MIN(IdEmpresa) FROM Empresas), 'Parametros => RMA : ucConfRMA');
		IF EXISTS (SELECT * FROM TiposMovimientos WHERE IdTipoMovimiento = 'SRV_CONSUMO')
		BEGIN
		UPDATE Parametros SET ValorParametro = 'SRV_CONSUMO' WHERE IdParametro = 'CRMMOVIMIENTOCONSUMO'
		END

		ELSE
		BEGIN
		INSERT INTO TiposMovimientos VALUES
		('SRV_CONSUMO', 'Consumo Service', -1, NULL, 0, 0, 0, 0, 0, 'NO', NULL, 0, 0);
		UPDATE Parametros SET ValorParametro = 'SRV_CONSUMO' WHERE IdParametro = 'CRMMOVIMIENTOCONSUMO';
		END
	END

--Configuración de Movimiento para Reversado.

IF EXISTS (SELECT * FROM Parametros WHERE IdParametro = 'CRMMOVIMIENTOREVERSADO')
	BEGIN
		IF EXISTS (SELECT * FROM TiposMovimientos WHERE IdTipoMovimiento = 'SRV_DEVOL')
		BEGIN
		UPDATE Parametros SET ValorParametro = 'SRV_DEVOL' WHERE IdParametro = 'CRMMOVIMIENTOREVERSADO'
		END

		ELSE
		BEGIN
		INSERT INTO TiposMovimientos VALUES
		('SRV_DEVOL', 'Devolucion Service', 1, NULL, 0, 0, 0, 0, 0, 'NO', NULL, 0, 0);
		UPDATE Parametros SET ValorParametro = 'SRV_DEVOL' WHERE IdParametro = 'CRMMOVIMIENTOREVERSADO';
		END
	END

	ELSE
	BEGIN
	INSERT INTO Parametros VALUES
	('CRMMOVIMIENTOREVERSADO', NULL, NULL, 'Movimiento para Reversado', (SELECT MIN(IdEmpresa) FROM Empresas), 'Parametros => RMA : ucConfRMA');
		IF EXISTS (SELECT * FROM TiposMovimientos WHERE IdTipoMovimiento = 'SRV_DEVOL')
		BEGIN
		UPDATE Parametros SET ValorParametro = 'SRV_DEVOL' WHERE IdParametro = 'CRMMOVIMIENTOREVERSADO'
		END

		ELSE
		BEGIN
		INSERT INTO TiposMovimientos VALUES
		('SRV_DEVOL', 'Devolucion Service', 1, NULL, 0, 0, 0, 0, 0, 'NO', NULL, 0, 0);
		UPDATE Parametros SET ValorParametro = 'SRV_DEVOL' WHERE IdParametro = 'CRMMOVIMIENTOREVERSADO';
		END
	END

--Configuración de Movimiento para Reserva.

IF EXISTS (SELECT * FROM Parametros WHERE IdParametro = 'CRMMOVIMIENTORESERVA')
	BEGIN
		IF EXISTS (SELECT * FROM TiposMovimientos WHERE IdTipoMovimiento = 'SRV_RESERVA')
		BEGIN
		UPDATE Parametros SET ValorParametro = 'SRV_RESERVA' WHERE IdParametro = 'CRMMOVIMIENTORESERVA'
		END

		ELSE
		BEGIN
		INSERT INTO TiposMovimientos VALUES
		('SRV_RESERVA', 'Reserva Service', 1, NULL, 0, 0, 0, 0, 0, 'NO', NULL, 0, 1);
		UPDATE Parametros SET ValorParametro = 'SRV_RESERVA' WHERE IdParametro = 'CRMMOVIMIENTORESERVA';
		END
	END

	ELSE
	BEGIN
	INSERT INTO Parametros VALUES
	('CRMMOVIMIENTORESERVA', NULL, NULL, 'Movimiento para Reserva', (SELECT MIN(IdEmpresa) FROM Empresas), 'Parametros => RMA : ucConfRMA');
		IF EXISTS (SELECT * FROM TiposMovimientos WHERE IdTipoMovimiento = 'SRV_RESERVA')
		BEGIN
		UPDATE Parametros SET ValorParametro = 'SRV_RESERVA' WHERE IdParametro = 'CRMMOVIMIENTORESERVA'
		END

		ELSE
		BEGIN
		INSERT INTO TiposMovimientos VALUES
		('SRV_RESERVA', 'Reserva Service', 1, NULL, 0, 0, 0, 0, 0, 'NO', NULL, 0, 1);
		UPDATE Parametros SET ValorParametro = 'SRV_RESERVA' WHERE IdParametro = 'CRMMOVIMIENTORESERVA';
		END
	END

--Configuración de Movimiento para Dev Reserva.

IF EXISTS (SELECT * FROM Parametros WHERE IdParametro = 'CRMMOVIMIENTODEVRESERVA')
	BEGIN
		IF EXISTS (SELECT * FROM TiposMovimientos WHERE IdTipoMovimiento = 'SRV_DEVRESERVA')
		BEGIN
		UPDATE Parametros SET ValorParametro = 'SRV_DEVRESERVA' WHERE IdParametro = 'CRMMOVIMIENTODEVRESERVA'
		END

		ELSE
		BEGIN
		INSERT INTO TiposMovimientos VALUES
		('SRV_DEVRESERVA', 'Devolucion Reserva Servic', -1, NULL, 0, 0, 0, 0, 0, 'NO', NULL, 0, 0);
		UPDATE Parametros SET ValorParametro = 'SRV_DEVRESERVA' WHERE IdParametro = 'CRMMOVIMIENTODEVRESERVA';
		END
	END

	ELSE
	BEGIN
	INSERT INTO Parametros VALUES
	('CRMMOVIMIENTODEVRESERVA', NULL, NULL, 'Movimiento para Dev Reserva', (SELECT MIN(IdEmpresa) FROM Empresas), 'Parametros => RMA : ucConfRMA');
		IF EXISTS (SELECT * FROM TiposMovimientos WHERE IdTipoMovimiento = 'SRV_DEVRESERVA')
		BEGIN
		UPDATE Parametros SET ValorParametro = 'SRV_DEVRESERVA' WHERE IdParametro = 'CRMMOVIMIENTODEVRESERVA'
		END

		ELSE
		BEGIN
		INSERT INTO TiposMovimientos VALUES
		('SRV_DEVRESERVA', 'Devolucion Reserva Servic', -1, NULL, 0, 0, 0, 0, 0, 'NO', NULL, 0, 0);
		UPDATE Parametros SET ValorParametro = 'SRV_DEVRESERVA' WHERE IdParametro = 'CRMMOVIMIENTODEVRESERVA';
		END
	END


--Configuración de Depósito de Reserva de Mercaderia.

IF EXISTS (SELECT * FROM Parametros WHERE IdParametro = 'CRMNOVEDADESDEPOSITORESERVA')
	BEGIN
	UPDATE Parametros SET ValorParametro = (SELECT TOP 1 IdDeposito FROM SucursalesDepositos WHERE TipoDeposito = 'RESERVADO') WHERE IdParametro = 'CRMNOVEDADESDEPOSITORESERVA'
	END

	ELSE
	BEGIN
	INSERT INTO Parametros VALUES
	('CRMNOVEDADESDEPOSITORESERVA', (SELECT TOP 1 IdDeposito FROM SucursalesDepositos WHERE TipoDeposito = 'RESERVADO'), '', 'Depósito de Reserva de Mercaderia', (SELECT MIN(IdEmpresa) FROM Empresas), 'Parametros => RMA : ucConfRMA')
	END

--Configuración de Ubicación de Reserva de Mercaderia.

IF EXISTS (SELECT * FROM Parametros WHERE IdParametro = 'CRMNOVEDADESUBICACIONRESERVA')
	BEGIN
	UPDATE Parametros SET ValorParametro = @idUbicacion WHERE IdParametro = 'CRMNOVEDADESUBICACIONRESERVA'
	END

	ELSE
	BEGIN
	INSERT INTO Parametros VALUES
	('CRMNOVEDADESUBICACIONRESERVA', @idUbicacion, '', 'Ubicación de Reserva de Mercaderia', (SELECT MIN(IdEmpresa) FROM Empresas), 'Parametros => RMA : ucConfRMA')
	END

