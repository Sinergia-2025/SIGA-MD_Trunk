IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[ContabilidadRenumerarAsientosIndividual]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ContabilidadRenumerarAsientosIndividual
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE ContabilidadRenumerarAsientosIndividual
	-- Add the parameters for the stored procedure here
	@IdEjercicio int,
    @IdPlanCuenta int,
    @IdAsiento int,
	@IdAsientoNuevoParam int,
    @columnasTablaContabilidadAsientos VARCHAR(MAX),
    @columnasTablaContabilidadAsientosTmp VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @sqlCommand NVARCHAR(MAX)
    SET @sqlCommand = 'INSERT INTO ContabilidadAsientos (IdAsiento, ' + @columnasTablaContabilidadAsientos + ') ' +
                        'SELECT @IdAsientoNuevo, ' + @columnasTablaContabilidadAsientos +
                        '  FROM ContabilidadAsientos' +
                        ' WHERE IdEjercicio = @IdEjercicio AND IdPlanCuenta = @IdPlanCuenta AND IdAsiento = @IdAsiento;'

    EXECUTE sp_executesql @sqlCommand, N'@IdAsientoNuevo int, @IdEjercicio int, @IdPlanCuenta int, @IdAsiento int',
                          @IdAsientoNuevo = @IdAsientoNuevoParam, @IdEjercicio = @IdEjercicio, @IdPlanCuenta = @IdPlanCuenta, @IdAsiento = @IdAsiento
    --EXEC(@sqlCommand)

    UPDATE ContabilidadAsientosCuentas
        SET IdAsiento = @IdAsientoNuevoParam
      WHERE IdEjercicio = @IdEjercicio
        AND IdPlanCuenta = @IdPlanCuenta
        AND IdAsiento = @IdAsiento;

    DECLARE @IdEjercicioTmp int
    DECLARE @IdPlanCuentaTmp int
    DECLARE @IdAsientoTmp int
    DECLARE @FechaAsientoTmp datetime
    -- declaramos un cursor llamado "cursoritoTmp". 
    DECLARE cursoritoTmp CURSOR FOR
    SELECT CA.IdEjercicio, CA.IdPlanCuenta, CA.FechaAsiento, CA.IdAsiento
      FROM ContabilidadAsientosTmp CA
     WHERE CA.IdEjercicioDefinitivo = @IdEjercicio
       AND CA.IdPlanCuentaDefinitivo = @IdPlanCuenta
       AND CA.IdAsientoDefinitivo = @IdAsiento
     ORDER BY CA.IdEjercicio, CA.IdPlanCuenta, CA.FechaAsiento, CA.IdAsiento

    OPEN cursoritoTmp
    -- Avanzamos un registro y cargamos en las variables los valores encontrados en el primer registro
        FETCH NEXT FROM cursoritoTmp
                   INTO @IdEjercicioTmp, @IdPlanCuentaTmp, @FechaAsientoTmp, @IdAsientoTmp

        WHILE @@fetch_status = 0
        BEGIN


            SET @sqlCommand = 'INSERT INTO ContabilidadAsientosTmp (IdAsiento, ' + @columnasTablaContabilidadAsientosTmp + ') ' +
                                'SELECT @IdAsientoNuevo, ' + @columnasTablaContabilidadAsientosTmp +
                                '  FROM ContabilidadAsientosTmp' +
                                ' WHERE IdEjercicio = @IdEjercicio AND IdPlanCuenta = @IdPlanCuenta AND IdAsiento = @IdAsiento;'

            EXECUTE sp_executesql @sqlCommand, N'@IdAsientoNuevo int, @IdEjercicio int, @IdPlanCuenta int, @IdAsiento int',
                                  @IdAsientoNuevo = @IdAsientoNuevoParam, @IdEjercicio = @IdEjercicioTmp, @IdPlanCuenta = @IdPlanCuentaTmp, @IdAsiento = @IdAsientoTmp
    
            UPDATE ContabilidadAsientosCuentasTmp
                SET IdAsiento = @IdAsientoNuevoParam
              WHERE IdEjercicio = @IdEjercicioTmp
                AND IdPlanCuenta = @IdPlanCuentaTmp
                AND IdAsiento = @IdAsientoTmp;

            UPDATE Ventas
                SET IdAsiento = @IdAsientoNuevoParam
              WHERE IdEjercicio = @IdEjercicioTmp
                AND IdPlanCuenta = @IdPlanCuentaTmp
                AND IdAsiento = @IdAsientoTmp;
            UPDATE Compras
                SET IdAsiento = @IdAsientoNuevoParam
              WHERE IdEjercicio = @IdEjercicioTmp
                AND IdPlanCuenta = @IdPlanCuentaTmp
                AND IdAsiento = @IdAsientoTmp;
            UPDATE CuentasCorrientes
                SET IdAsiento = @IdAsientoNuevoParam
              WHERE IdEjercicio = @IdEjercicioTmp
                AND IdPlanCuenta = @IdPlanCuentaTmp
                AND IdAsiento = @IdAsientoTmp;
            UPDATE CuentasCorrientesProv
                SET IdAsiento = @IdAsientoNuevoParam
              WHERE IdEjercicio = @IdEjercicioTmp
                AND IdPlanCuenta = @IdPlanCuentaTmp
                AND IdAsiento = @IdAsientoTmp;
            UPDATE CajasDetalle
                SET IdAsiento = @IdAsientoNuevoParam
              WHERE IdEjercicio = @IdEjercicioTmp
                AND IdPlanCuenta = @IdPlanCuentaTmp
                AND IdAsiento = @IdAsientoTmp;
            UPDATE LibrosBancos
                SET IdAsiento = @IdAsientoNuevoParam
              WHERE IdEjercicio = @IdEjercicioTmp
                AND IdPlanCuenta = @IdPlanCuentaTmp
                AND IdAsiento = @IdAsientoTmp;
            UPDATE Depositos
                SET IdAsiento = @IdAsientoNuevoParam
              WHERE IdEjercicio = @IdEjercicioTmp
                AND IdPlanCuenta = @IdPlanCuentaTmp
                AND IdAsiento = @IdAsientoTmp;

             DELETE ContabilidadAsientosTmp
              WHERE IdEjercicio = @IdEjercicio
                AND IdPlanCuenta = @IdPlanCuenta
                AND IdAsiento = @IdAsiento;

            -- Avanzamos otro registro
            FETCH NEXT FROM cursoritoTmp
                       INTO @IdEjercicioTmp, @IdPlanCuentaTmp, @FechaAsientoTmp, @IdAsientoTmp
        END

    -- cerramos el cursor
    CLOSE cursoritoTmp
    DEALLOCATE cursoritoTmp

    UPDATE ContabilidadAsientosTmp
        SET IdAsientoDefinitivo = @IdAsientoNuevoParam
      WHERE IdEjercicioDefinitivo = @IdEjercicio
        AND IdPlanCuentaDefinitivo = @IdPlanCuenta
        AND IdAsientoDefinitivo = @IdAsiento;

    DELETE ContabilidadAsientos
      WHERE IdEjercicio = @IdEjercicio
        AND IdPlanCuenta = @IdPlanCuenta
        AND IdAsiento = @IdAsiento;

END
GO
