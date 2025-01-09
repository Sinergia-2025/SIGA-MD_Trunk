
/* Borro las PKs con Tipo/Nro Documento */
------------------------------------------
 
-- /// Tabla BKP con referencias 
--
IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias_2') )
    DROP TABLE dbo.t_Referencias_2
--
SELECT tc.Table_Name, tc.Constraint_Name,
      ' ALTER TABLE dbo.' + tc.Table_Name + ' DROP CONSTRAINT [' + tc.Constraint_Name + ']' AS DROP_PK
INTO    dbo.t_Referencias_2 
  FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
 WHERE tc.Table_Name IN 
  ('AuditoriaClientes', 'CartasAClientes', 'Clientes', 'ClientesActividades', 'ClientesDescuentosMarcas',
   'ClientesDescuentosSubRubros', 'ClientesMarcasListasDePrecios', 'ClientesSucursales', 
   'CuentasCorrientesRetenciones', 'Fichas', 'FichasPagos', 'FichasPagosAjustes',
   'FichasPagosDetalle', 'FichasProductos', 'Retenciones')
  AND tc.Constraint_Type = 'PRIMARY KEY'
 ORDER BY tc.Table_Name
 
--
GO 
--// Eliminar FKs
DECLARE @vSQL VARCHAR(MAX);
SET @vSQL = '';
--
SELECT  @vSQL = @vSQL + CHAR(13) + CHAR(10) + r.DROP_PK
FROM    dbo.t_Referencias_2 r
--
PRINT @vSQL
EXEC (@vSQL)
--
GO

