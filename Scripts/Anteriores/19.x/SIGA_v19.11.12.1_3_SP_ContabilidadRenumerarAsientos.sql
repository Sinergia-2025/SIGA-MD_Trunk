IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[ContabilidadRenumerarAsientos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.ContabilidadRenumerarAsientos
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE ContabilidadRenumerarAsientos
	-- Add the parameters for the stored procedure here
    @IdEjercicioParam int,
    @IdPlanCuentaParam int,
    @IdAsientoParam int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @IdEjercicio int
    DECLARE @IdPlanCuenta int
    DECLARE @IdAsiento int
    DECLARE @FechaAsiento datetime
    DECLARE @IdAsientoNuevo int = 0

    DECLARE @columnasTablaContabilidadAsientos VARCHAR(MAX)
    SET @columnasTablaContabilidadAsientos = (SELECT COLUMN_NAME + ', ' FROM INFORMATION_SCHEMA.COLUMNS
                                               WHERE TABLE_NAME = 'ContabilidadAsientos' AND COLUMN_NAME <> 'IdAsiento' FOR XML PATH(''))
    SET @columnasTablaContabilidadAsientos = LEFT(@columnasTablaContabilidadAsientos, LEN(@columnasTablaContabilidadAsientos) - 1)

    DECLARE @columnasTablaContabilidadAsientosTmp VARCHAR(MAX)
    SET @columnasTablaContabilidadAsientosTmp = (SELECT COLUMN_NAME + ', ' FROM INFORMATION_SCHEMA.COLUMNS
                                                  WHERE TABLE_NAME = 'ContabilidadAsientosTmp' AND COLUMN_NAME <> 'IdAsiento' FOR XML PATH(''))
    SET @columnasTablaContabilidadAsientosTmp = LEFT(@columnasTablaContabilidadAsientosTmp, LEN(@columnasTablaContabilidadAsientosTmp) - 1)

    -- declaramos un cursor llamado "cursorito". 
    DECLARE cursorito CURSOR FOR
    SELECT CA.IdEjercicio, CA.IdPlanCuenta, CA.FechaAsiento, CA.IdAsiento
      FROM ContabilidadAsientos CA
     WHERE CA.IdEjercicio = @IdEjercicioParam
       AND CA.IdPlanCuenta = @IdPlanCuentaParam
       AND (@IdAsientoParam IS NULL OR CA.IdAsiento = @IdAsientoParam)
     ORDER BY CA.IdEjercicio, CA.IdPlanCuenta, CA.FechaAsiento, CA.IdAsiento

    OPEN cursorito
    -- Avanzamos un registro y cargamos en las variables los valores encontrados en el primer registro
        FETCH NEXT FROM cursorito
                   INTO @IdEjercicio, @IdPlanCuenta, @FechaAsiento, @IdAsiento

        WHILE @@fetch_status = 0
        BEGIN
            SET @IdAsientoNuevo = @IdAsientoNuevo + 1;
            DECLARE @IdAsientoNuevoParam int = @IdAsientoNuevo * -1;

            EXEC [dbo].[ContabilidadRenumerarAsientosIndividual]
                        @IdEjercicio = @IdEjercicio,
                        @IdPlanCuenta = @IdPlanCuenta,
                        @IdAsiento = @IdAsiento,
                        @IdAsientoNuevoParam = @IdAsientoNuevoParam,
                        @columnasTablaContabilidadAsientos = @columnasTablaContabilidadAsientos,
                        @columnasTablaContabilidadAsientosTmp = @columnasTablaContabilidadAsientosTmp

            -- Avanzamos otro registro
            FETCH NEXT FROM cursorito
                       INTO @IdEjercicio, @IdPlanCuenta, @FechaAsiento, @IdAsiento
        END

    -- cerramos el cursor
    CLOSE cursorito
    DEALLOCATE cursorito

    -- declaramos un cursor llamado "cursorito". 
    DECLARE cursorito2 CURSOR FOR
    SELECT CA.IdEjercicio, CA.IdPlanCuenta, CA.FechaAsiento, CA.IdAsiento
      FROM ContabilidadAsientos CA
     WHERE CA.IdEjercicio = @IdEjercicioParam
       AND CA.IdPlanCuenta = @IdPlanCuentaParam
       AND CA.IdAsiento < 0
     ORDER BY CA.IdEjercicio, CA.IdPlanCuenta, CA.FechaAsiento, CA.IdAsiento

    OPEN cursorito2
    -- Avanzamos un registro y cargamos en las variables los valores encontrados en el primer registro
        FETCH NEXT FROM cursorito2
                   INTO @IdEjercicio, @IdPlanCuenta, @FechaAsiento, @IdAsiento

        WHILE @@fetch_status = 0
        BEGIN
            SET @IdAsientoNuevoParam = @IdAsiento * -1;

            EXEC [dbo].[ContabilidadRenumerarAsientosIndividual]
                        @IdEjercicio = @IdEjercicio,
                        @IdPlanCuenta = @IdPlanCuenta,
                        @IdAsiento = @IdAsiento,
                        @IdAsientoNuevoParam = @IdAsientoNuevoParam,
                        @columnasTablaContabilidadAsientos = @columnasTablaContabilidadAsientos,
                        @columnasTablaContabilidadAsientosTmp = @columnasTablaContabilidadAsientosTmp

            -- Avanzamos otro registro
            FETCH NEXT FROM cursorito2
                       INTO @IdEjercicio, @IdPlanCuenta, @FechaAsiento, @IdAsiento
        END

    -- cerramos el cursor
    CLOSE cursorito2
    DEALLOCATE cursorito2
END
GO
