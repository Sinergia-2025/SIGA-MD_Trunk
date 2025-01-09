UPDATE Funciones
   SET Parametros = 'TipoTipoComprobante=' + Parametros
 WHERE Pantalla IN ('PedidosAdminProvV2', 'PedidosAdminProv')
   AND ISNULL(Parametros, '') <> ''
   AND NOT ISNULL(Parametros, '') LIKE 'TipoTipoComprobante=%'


UPDATE Funciones
   SET Parametros = Parametros + ';PermitePrecioCero=SI'
 WHERE Pantalla IN ('PedidosAdminProvV2', 'PedidosAdminProv')
   AND ISNULL(Parametros, '') <> ''
   AND ISNULL(Parametros, '') LIKE '%PRESUPPROV%'
   AND NOT ISNULL(Parametros, '') LIKE '%PermitePrecioCero%'

UPDATE Funciones
   SET Parametros = 'TipoTipoComprobante=' + Parametros
 WHERE Pantalla = 'PedidosProveedores'
   AND ISNULL(Parametros, '') <> ''
   AND NOT ISNULL(Parametros, '') LIKE 'TipoTipoComprobante=%'


UPDATE Funciones
   SET Parametros = Parametros + ';PermitePrecioCero=SI'
 WHERE Pantalla = 'PedidosProveedores'
   AND ISNULL(Parametros, '') <> ''
   AND ISNULL(Parametros, '') LIKE '%PRESUPPROV%'
   AND NOT ISNULL(Parametros, '') LIKE '%PermitePrecioCero%'

