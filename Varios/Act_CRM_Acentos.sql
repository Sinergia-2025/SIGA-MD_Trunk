--CRMNovedades
--AuditoriaCRMNovedades


PRINT ''
PRINT '1. Letra a.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'�','a')
 WHERE Descripcion like '%�%'
GO

PRINT ''
PRINT '2. Letra e.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'�','e')
 WHERE Descripcion like '%�%'
GO

PRINT ''
PRINT '3. Letra i.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'�','i')
 WHERE Descripcion like '%�%'
GO


PRINT ''
PRINT '4. Letra o.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'�','o')
 WHERE Descripcion like '%�%'
GO

PRINT ''
PRINT '5. Letra u.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'�','u')
 WHERE Descripcion like '%�%'
GO
