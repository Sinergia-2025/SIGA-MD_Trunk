DECLARE @IdProducto BIGINT; --Variable que pasará por todos los valores de IdProducto
DECLARE @tope BIGINT;       --Variable que determina el final de la setencia
DECLARE @IdSubRubro INT;    --Variable para comparar
DECLARE @IdSubSubRubro INT; --Variable para comparar

SELECT @tope = MAX(CAST(IdProducto AS BIGINT))
FROM Productos;

SELECT @IdProducto = MIN(CAST(IdProducto AS BIGINT))
FROM Productos;

WHILE @IdProducto <= @tope
BEGIN
    
    SELECT @IdSubRubro = (SELECT IdSubRubro FROM Productos WHERE CAST(IdProducto AS BIGINT) = @IdProducto);
    SELECT @IdSubSubRubro = (SELECT IdSubSubRubro FROM Productos WHERE CAST(IdProducto AS BIGINT) = @IdProducto);

    IF NOT EXISTS (SELECT * FROM SubSubRubros WHERE IdSubSubRubro = @IdSubSubRubro AND IdSubRubro = @IdSubRubro)
        BEGIN
        UPDATE Productos SET IdSubSubRubro = NULL WHERE CAST(IdProducto AS BIGINT) = @IdProducto
        SET @IdProducto = @IdProducto + 1;
        END
        ELSE
        BEGIN
        SET @IdProducto = @IdProducto + 1;
        END
END
