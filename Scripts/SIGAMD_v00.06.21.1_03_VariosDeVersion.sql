IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPCostosProcesosProductivos') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPCostosProcesosProductivos', 'Calculo de Costos de Procesos Productivos', 'Calculo de Costos de Procesos Productivos', 'True', 'False', 'True', 'True'
        ,'MRP', 300, 'Eniac.Win', 'MRPCostosProcesosProductivos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPCostosProcesosProductivos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('RequerimientosComprasAdmin') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('RequerimientosComprasAdmin', 'Administración de Requerimientos de Compra', 'Administración de Requerimientos de Compra', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 50, 'Eniac.Win', 'RequerimientosComprasAdmin', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'RequerimientosComprasAdmin' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

UPDATE EstadosPedidosProveedores
   SET IdTipoComprobante = NULL
 WHERE TipoEstadoPedido = 'PEDIDOSPROV'
   AND IdEstado = 'ENTREGADO'

PRINT ''
PRINT '1. Parametros: Visualizacion de Campos en Orden de Produccion Venta'
DECLARE @idParametro VARCHAR(MAX) = 'ORDPRODMOSTRARVENTA'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Visualiza Campos en Orden de Produccion'
DECLARE @valorParametro VARCHAR(MAX) = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
