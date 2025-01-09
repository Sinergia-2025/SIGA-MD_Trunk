PRINT ''
PRINT '1.1. Insertar funcion: Exportación Invoinet '
    BEGIN 
        IF dbo.BaseConCuit('30714757128') = 1 OR dbo.SoyHAR() = 1
            BEGIN
                UPDATE Funciones
                    SET Nombre = 'Exportación de Pago a Proveedores',
                        Descripcion = 'Exportación de Pago a Proveedores'
                WHERE id = 'ExportacionInvoinet'
            END
    END
GO



PRINT ''
PRINT '1.1. Parametros Subida Moviles '
    BEGIN 
        MERGE INTO Parametros AS DEST
                USING (SELECT 'SIMOVILSUBIDAPAGINARUTASLISTASPRECIOS' IdParametro, '100' ValorParametro UNION
                       SELECT 'SIMOVILSUBIDAPAGINACLIENTES', '100' UNION
                       SELECT 'SIMOVILSUBIDAPAGINACUENTASCORRIENTES', '100' UNION
                       SELECT 'SIMOVILSUBIDAPAGINACUENTASCORRIENTESDEBEHABER', 
                              CASE WHEN dbo.BaseConCuit('30716309955') = 1 THEN '25' ELSE '100' END UNION
                       SELECT 'SIMOVILSUBIDAPAGINARUBROS', '100' UNION
                       SELECT 'SIMOVILSUBIDAPAGINAPRODUCTOS', '100' UNION
                       SELECT 'SIMOVILSUBIDAPAGINAPRODUCTOSPRECIOS', '100') 
                    AS ORIG ON DEST.IdParametro = ORIG.IdParametro
            WHEN MATCHED THEN
                UPDATE SET DEST.ValorParametro = ORIG.ValorParametro;
        END
GO
