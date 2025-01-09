/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
PRINT '1. Campo Tipos de Comprobantes Controla Tope'

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TiposComprobantes ADD ControlaTopeConsumidorFinal bit NULL
GO
UPDATE TiposComprobantes SET ControlaTopeConsumidorFinal = 1;
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN ControlaTopeConsumidorFinal bit NOT NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '2. Pedidos Modifica Descripcion Solicita Kilos'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                  AND P.ValorParametro IN ('20231852698'))

BEGIN
    MERGE INTO Parametros AS P
            USING (SELECT 'PEDIDOSMODIFICADESCRIPSOLICITAKILOS' AS IdParametro, 'False' ValorParametro, 'Pedidos Modifica Descripción Solicita Kilos'  AS DescripcionParametro UNION
                   SELECT 'PEDIDOSMODIFICAPRECIOPRODUCTO' AS IdParametro, 'False' ValorParametro, 'Pedidos Modifica Descripción Solicita Kilos'  AS DescripcionParametro UNION
                   SELECT 'PEDIDOSMOSTRARUM' AS IdParametro, 'False' ValorParametro, 'Pedidos Modifica Descripción Solicita Kilos'  AS DescripcionParametro UNION
                   SELECT 'PEDIDOSDECIMALESMOSTRARLARGOANCHO' AS IdParametro, '0' ValorParametro, 'Pedidos Modifica Descripción Solicita Kilos'  AS DescripcionParametro)
            AS PT ON P.IdParametro = PT.IdParametro
        WHEN MATCHED THEN
            UPDATE SET P.ValorParametro = PT.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
    ;

    INSERT INTO Traducciones
               (IdFuncion,Pantalla,Control,IdIdioma,Texto)
         VALUES
               ('PresupuestosClientesV2', '', 'Kilos', 'es_AR', 'Kg Total'),
               ('PresupuestosClientesV2', '', 'PrecioVentaPorTamano', 'es_AR', '$ x Kg'),
               ('PresupuestosClientesV2', '', 'Tamano', 'es_AR', 'Kg Pieza')
    ;
END


PRINT '3. Campos Cuentas de Caja Genera Contabilidad'

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasDeCajas ADD GeneraContabilidad bit NULL
GO
UPDATE CuentasDeCajas SET GeneraContabilidad = 1;
ALTER TABLE dbo.CuentasDeCajas ALTER COLUMN GeneraContabilidad bit NOT NULL
GO
ALTER TABLE dbo.CuentasDeCajas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
