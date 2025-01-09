PRINT ''
PRINT '1.1 Actualización de registros inconsistentes (por las dudas): CodigoProductoTiendaNube.'
UPDATE P SET P.CodigoProductoTiendaNube = NULL FROM Productos P
  WHERE P.CodigoProductoTiendaNube = ''
GO

PRINT ''
PRINT '1.2 Actualización de registros inconsistentes (por las dudas): CodigoProductoTiendaNube.'
UPDATE P SET P.CodigoProductoMercadoLibre = NULL FROM Productos P
  WHERE P.CodigoProductoMercadoLibre = ''
GO

PRINT ''
PRINT '1.3 Actualización de registros inconsistentes (por las dudas): IdRubroTiendaNube.'
UPDATE R SET R.IdRubroTiendaNube = NULL FROM Rubros R
  WHERE R.IdRubroTiendaNube = ''
GO

PRINT ''
PRINT '1.4 Actualización de registros inconsistentes (por las dudas): IdRubroMercadoLibre.'
UPDATE R SET R.IdRubroMercadoLibre = NULL FROM Rubros R
  WHERE R.IdRubroMercadoLibre = ''
GO

PRINT ''
PRINT '1.5 Actualización de registros inconsistentes (por las dudas): IdSubRubroTiendaNube.'
UPDATE R SET R.IdSubRubroTiendaNube = NULL FROM SubRubros R
  WHERE R.IdSubRubroTiendaNube = ''
GO

PRINT ''
PRINT '1.6 Actualización de registros inconsistentes (por las dudas): IdSubRubroMercadoLibre.'
UPDATE R SET R.IdSubRubroMercadoLibre = NULL FROM SubRubros R
  WHERE R.IdSubRubroMercadoLibre = ''
GO

PRINT ''
PRINT '1.7 Actualización de registros inconsistentes (por las dudas): IdSubSubRubroTiendaNube.'
UPDATE R SET R.IdSubSubRubroTiendaNube = NULL FROM SubSubRubros R
  WHERE R.IdSubSubRubroTiendaNube = ''
GO

PRINT ''
PRINT '1.8 Actualización de registros inconsistentes (por las dudas): IdSubSubRubroMercadoLibre.'
UPDATE R SET R.IdSubSubRubroMercadoLibre = NULL FROM SubSubRubros R
  WHERE R.IdSubSubRubroMercadoLibre = ''
GO