PRINT ''
PRINT '1. Carga Conserva Orden de Productos en Grilla.- Facturacion, Facturación Rápida, Compras, Pedidos y Pedidos Proveedores'
MERGE INTO Parametros AS DEST
USING (
        SELECT IdEmpresa, 'FACTURACIONORDENPRODUCTOS' AS IdParametro, 'True' ValorParametro, 'Facturacion' CategoriaParametro, 'FACTURACIONORDENPRODUCTOS' DescripcionParametro FROM Empresas UNION ALL
        SELECT IdEmpresa, 'FACTURACIONRAPIDAORDENPRODUCTOS' AS IdParametro, 'True' ValorParametro, 'Facturacion RAPIDA' CategoriaParametro, 'FACTURACIONRAPIDAORDENPRODUCTOS' DescripcionParametro FROM Empresas UNION ALL
        SELECT IdEmpresa, 'COMPRASCONSERVAORDENPRODUCTOS' AS IdParametro, 'True' ValorParametro, 'Compras' CategoriaParametro, 'COMPRASCONSERVAORDENPRODUCTOS' DescripcionParametro FROM Empresas UNION ALL
        SELECT IdEmpresa, 'PEDIDOSCLIENTESCONSERVAORDENPRODUCTOS' AS IdParametro, 'True' ValorParametro, 'Pedidos Clientes' CategoriaParametro, 'PEDIDOSCLIENTESCONSERVAORDENPRODUCTOS' DescripcionParametro FROM Empresas UNION ALL
        SELECT IdEmpresa, 'PEDIDOSPROVEEDORESCONSERVAORDENPRODUCTOS' AS IdParametro, 'True' ValorParametro, 'Pedidos Clientes' CategoriaParametro, 'PEDIDOSPROVEEDORESCONSERVAORDENPRODUCTOS' DescripcionParametro FROM Empresas
        ) AS ORIG 
        ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
WHEN MATCHED THEN
    UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
WHEN NOT MATCHED THEN 
    INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
    VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);

PRINT ''
PRINT '2. Quitar Iconos a Funciones'
UPDATE Funciones SET Icono = NULL WHERE Icono IS NOT NULL


PRINT ''
PRINT '3. Menú: Alerta de Pedidos sin Cantidad de Items'
IF dbo.ExisteFuncion('Pedidos') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
    VALUES
        ('AlertaPedidosSinCantidadItems', 'Alerta de Pedidos sin Cantidad de Items', 'Alerta de Pedidos sin Cantidad de Items', 'False', 'False', 'True', 'False'
        ,'Pedidos', 630, 'Eniac.Win', 'AlertaPedidosSinCantidadItems', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', NULL,'True')
		,
		('AlertaPedidosConCantidadItems', 'Alerta Pedidos con Cantidad de Items', 'Alerta Pedidos con Cantidad de Items', 'False', 'False', 'True', 'False'
        ,'Pedidos', 640, 'Eniac.Win', 'AlertaPedidosConCantidadItems', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', NULL,'True')


	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'AlertaPedidosSinCantidadItems' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

	 INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'AlertaPedidosConCantidadItems' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

END

PRINT ''
PRINT '4. Tabla CategoriasFiscales: Nueva categoría 8 - Responsable Inscripto Micro'
IF NOT EXISTS (SELECT * FROM CategoriasFiscales WHERE IdCategoriaFiscal = 8)
BEGIN
INSERT [dbo].[CategoriasFiscales] 
            ([IdCategoriaFiscal], [NombreCategoriaFiscal], [CondicionIvaImpresoraFiscalEpson], [NombreCategoriaFiscalAbrev], [Activo], 
             [UtilizaImpuestos], [CondicionIvaImpresoraFiscalHasar], [SolicitaCUIT], [EsPasiblePercIIBB], [UtilizaAlicuota2Producto], 
             [CodigoExportacion], [LeyendaCategoriaFiscal]) 
     VALUES (8, 'Responsable Inscripto Micro', 'I', 'Resp.InscN', 'False',
             'True', 'I', 'True', 'True', 'True', 
             '0', '')

INSERT [dbo].[CategoriasFiscalesConfiguraciones] 
            ([IdCategoriaFiscalEmpresa], [IdCategoriaFiscalCliente], [LetraFiscal], [LetraFiscalCompra], [IvaDiscriminado]) 
     VALUES (2, 8, 'A', 'A', 'True')
END
