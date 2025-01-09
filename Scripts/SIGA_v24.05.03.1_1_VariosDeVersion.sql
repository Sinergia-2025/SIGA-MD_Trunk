PRINT ''
PRINT '1. Parametros para Talkiu - RDS'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30714757128'))
	BEGIN
		IF NOT EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'PEDIDOTALKIUGET')
		BEGIN
			INSERT [dbo].[Parametros] ([IdParametro], [ValorParametro], [CategoriaParametro], [DescripcionParametro], [IdEmpresa], [UbicacionParametro]) VALUES (N'PEDIDOTALKIUGET', N'https://staging-talkiu.web-experto.com.ar/api/v3/proposals/R{0}', N'', N'URL GET', 1, N'Parametros => Pedidos -> Web : ucConfPedidosWeb')
			INSERT [dbo].[Parametros] ([IdParametro], [ValorParametro], [CategoriaParametro], [DescripcionParametro], [IdEmpresa], [UbicacionParametro]) VALUES (N'PEDIDOTALKIUTOKEN', N'eyJhbGciOiJIUzI1NiJ9.eyJ1c2VyX2lkIjoiNjVkNjBhYTY1ZWVkMGUwMDAxYTczZDNiIiwiZXhwIjo4MDIwNTYyNzQ4fQ.pMywEXRU-U1zyPoBJVMdQRFZpxAdNa8YvpsyA5u6EuQ', N'', N'TOKEN', 1, N'Parametros => Pedidos -> Web : ucConfPedidosWeb')
		END
END
GO

IF dbo.ExisteFuncion('Compras') = 1 AND dbo.ExisteFuncion('ResumenDetallePorComprobanteCompras') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ResumenDetallePorCbanteCompras', 'Resumen Detalle por Comprobantes de Compras', 'Resumen Detalle por Comprobantes de Compras', 'True', 'False', 'True', 'True'
        ,'Compras', 21, 'Eniac.Win', 'ResumenDetallePorComprobanteCompras', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ResumenDetallePorCbanteCompras' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
go

IF dbo.ExisteCampo('OrdenesCompra', 'AplicaDescuentoRecargo') = 0
BEGIN
	ALTER TABLE OrdenesCompra ADD AplicaDescuentoRecargo bit null
	ALTER TABLE OrdenesCompra ADD Anticipado bit null
END
GO

UPDATE OrdenesCompra SET AplicaDescuentoRecargo = 'False' where AplicaDescuentoRecargo is null
GO
UPDATE OrdenesCompra SET Anticipado = 'False' where Anticipado is null
GO

ALTER TABLE OrdenesCompra ALTER COLUMN AplicaDescuentoRecargo bit not null
GO
ALTER TABLE OrdenesCompra ALTER COLUMN Anticipado bit not null
GO

DECLARE @idParametro VARCHAR(MAX) = 'TURISMOSIRPLUSTIPOSCOMPROBANTES'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Tipo de Comprobante SIRPLUS'
DECLARE @valorParametro VARCHAR(MAX) = 'FICHAS'
IF EXISTS (SELECT * FROM TiposComprobantes WHERE IdTipoComprobante = 'FICHAS-SIRPLUS')
    SET @valorParametro = 'FICHAS-SIRPLUS'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
