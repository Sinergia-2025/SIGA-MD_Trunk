PRINT '1. Corregir Unidades de Medida en Fórmulas.'

IF EXISTS   (SELECT * 
            FROM 
            ProductosComponentes PC
            INNER JOIN Productos P ON P.IdProducto = PC.IdProductoComponente
            WHERE PC.IdUnidadDeMedidaProduccion <> P.IdUnidadDeMedidaProduccion)

            BEGIN
                
                DECLARE @CantidadDeRegistros BIGINT;

                SET @CantidadDeRegistros =  (SELECT COUNT(*) 
                                            FROM 
                                            ProductosComponentes PC
                                            INNER JOIN Productos P ON P.IdProducto = PC.IdProductoComponente
                                            WHERE PC.IdUnidadDeMedidaProduccion <> P.IdUnidadDeMedidaProduccion);

                MERGE INTO ProductosComponentes AS DEST
                USING Productos AS ORIG
                ON DEST.IdProductoComponente = ORIG.IdProducto 
                AND DEST.IdUnidadDeMedidaProduccion <> ORIG.IdUnidadDeMedidaProduccion
                WHEN MATCHED THEN
                UPDATE SET DEST.IdUnidadDeMedidaProduccion = ORIG.IdUnidadDeMedidaProduccion;

                PRINT ''
                PRINT '   1.1 Se corrigieron ' + CAST(@CantidadDeRegistros AS VARCHAR) + ' productos.'

                END

                ELSE
                BEGIN
                PRINT ''
                PRINT '   1.1 No existían productos por corregir.'
                END
