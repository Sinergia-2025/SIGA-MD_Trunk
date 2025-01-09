--- FUNCIONES.- ---------------------------------------------------------------------------------------------------------------------
IF dbo.BaseConCuit('30714757128') = 1 OR dbo.SoyHAR() = 1  
BEGIN
    --- Funcion -Tipo de Atributos de Productos.- -----------------------------------------------------------------------------------
	PRINT ''
	PRINT 'F1. Nuevo Menu: Invocacion Masiva de Pedidos.'
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
		VALUES
			('InvocacionMasivaPedidos', 'Invocación Masiva de Pedidos', 'Invocación Masiva de Pedidos', 'True', 'False', 'True', 'True'
			, 'Ventas', 220, 'Eniac.Win', 'PedidosInvocacionMasiva', NULL, NULL
			,'True', 'S', 'N', 'N', 'N', 'True')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'InvocacionMasivaPedidos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END
END

IF dbo.BaseConCuit('30714757128') = 1
BEGIN
	PRINT ''
	PRINT 'P1. Nuevo Parametro : Valida Ingreso de Nro. de Factura y Remito Proveedor .'
	BEGIN
		DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOSCLIENTESVALIDAREMITOFACTURAPROVEEDOR'
		DECLARE @descripcionParametro VARCHAR(MAX) = 'Validar el Ingreso de Nro de Factura y Remito en la Invocacion Masiva'
		DECLARE @valorParametro VARCHAR(MAX) = 'False'

		MERGE INTO Parametros AS DEST
				USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
			WHEN MATCHED THEN
				UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
			WHEN NOT MATCHED THEN 
				INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
	END

	PRINT ''
	PRINT 'P2. Cambia Parametro : Pedido Solicita Transportista.'
	BEGIN
		SET @idParametro = 'PEDIDOSSOLICITATRANSPORTISTA'
		SET @valorParametro = 'True'
		MERGE INTO Parametros AS DEST
				USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
			WHEN MATCHED THEN
				UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
			WHEN NOT MATCHED THEN 
				INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
	END

	PRINT ''
	PRINT 'P3. Cambia Parametro : Pedidos solicita Comprobante.'
	BEGIN
		SET @idParametro = 'PEDIDOSSOLICITACOMPROBANTEGENERAR'
		SET @valorParametro = 'True'
		MERGE INTO Parametros AS DEST
				USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
			WHEN MATCHED THEN
				UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
			WHEN NOT MATCHED THEN 
				INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
	END

	PRINT ''
	PRINT 'P4. Cambia Parametro : Pedidos al Convertir conserva precio.'
	BEGIN
		SET @idParametro = 'CONVERTIRPEDIDOENFACTURACONSERVAPRECIOSPEDIDO'
		SET @valorParametro = 'True'
		MERGE INTO Parametros AS DEST
				USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
			WHEN MATCHED THEN
				UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
			WHEN NOT MATCHED THEN 
				INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
	END

	PRINT ''
	PRINT 'P5. Nuevo Parametro : Formato para Nombre de aRchivo de Exportación.'
	BEGIN
		SET @idParametro = 'FORMATONOMBREARCHIVOEXPORTACION'
		SET @descripcionParametro = 'Define Formato de Nombre de Archivo de Exportacion'
		SET @valorParametro = '@@CUITEMPRESA@@_@@COMPROBANTE@@'

		MERGE INTO Parametros AS DEST
				USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
			WHEN MATCHED THEN
				UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
			WHEN NOT MATCHED THEN 
				INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
	END
END

PRINT ''
PRINT 'C1. Nuevos Campos Tabla Ventas : Nro de Factura Proveedor - Nro. de Remito Proveedor.'
BEGIN
	ALTER TABLE Ventas ADD NroFacturaProveedor VarChar(50) NULL
	ALTER TABLE Ventas ADD NroRemitoProveedor VarChar(50) NULL
END

GO
--------------------------------------------------------------------------------------------------------------------------------
