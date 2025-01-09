--CRMNovedades
--AuditoriaCRMNovedades


PRINT ''
PRINT '1. Letra a.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'á','a')
 WHERE Descripcion like '%á%'
GO

PRINT ''
PRINT '2. Letra e.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'é','e')
 WHERE Descripcion like '%é%'
GO

PRINT ''
PRINT '3. Letra i.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'í','i')
 WHERE Descripcion like '%í%'
GO


PRINT ''
PRINT '4. Letra o.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'ó','o')
 WHERE Descripcion like '%ó%'
GO

PRINT ''
PRINT '5. Letra u.'
UPDATE AuditoriaCRMNovedades
  SET Descripcion = REPLACE(Descripcion,'ú','u')
 WHERE Descripcion like '%ú%'
GO
