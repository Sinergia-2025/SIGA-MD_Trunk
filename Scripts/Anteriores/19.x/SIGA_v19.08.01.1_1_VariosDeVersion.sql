PRINT ''
PRINT '1. Tabla Marcas: Agrego campo DescuentoRecargoPorc1 y DescuentoRecargoPorc2 .'
ALTER TABLE dbo.Marcas ADD DescuentoRecargoPorc1  decimal(5,2) NULL
ALTER TABLE dbo.Marcas ADD DescuentoRecargoPorc2  decimal(5,2) NULL
GO
PRINT ''
PRINT '1.1. Tabla Marcas: Valores por defecto para DescuentoRecargoPorc1 y DescuentoRecargoPorc2 .'
UPDATE Marcas SET DescuentoRecargoPorc1  = 0;
UPDATE Marcas SET DescuentoRecargoPorc2  = 0;
PRINT ''
PRINT '1.2. Tabla Marcas: NOT NULL en DescuentoRecargoPorc1 y DescuentoRecargoPorc2 .'
ALTER TABLE dbo.Marcas ALTER COLUMN DescuentoRecargoPorc1 decimal(5,2) NOT NULL
ALTER TABLE dbo.Marcas ALTER COLUMN DescuentoRecargoPorc2 decimal(5,2) NOT NULL
GO

PRINT ''
PRINT '2. Tabla Rubros: Agrego campo DescuentoRecargoPorc1 y DescuentoRecargoPorc2 .'
ALTER TABLE dbo.Rubros ADD DescuentoRecargoPorc1  decimal(5,2) NULL
ALTER TABLE dbo.Rubros ADD DescuentoRecargoPorc2  decimal(5,2) NULL
GO
PRINT ''
PRINT '2.1. Tabla Rubros: Valores por defecto para DescuentoRecargoPorc1 y DescuentoRecargoPorc2 .'
UPDATE Rubros SET DescuentoRecargoPorc1  = 0;
UPDATE Rubros SET DescuentoRecargoPorc2  = 0;
PRINT ''
PRINT '2.2. Tabla Rubros: NOT NULL en DescuentoRecargoPorc1 y DescuentoRecargoPorc2 .'
ALTER TABLE dbo.Rubros ALTER COLUMN DescuentoRecargoPorc1 decimal(5,2) NOT NULL
ALTER TABLE dbo.Rubros ALTER COLUMN DescuentoRecargoPorc2 decimal(5,2) NOT NULL
GO

PRINT ''
PRINT '3. Tabla SubRubros: Renombrar DescuentoRecargo por DescuentoRecargoPorc1.'
EXEC sp_rename 'SubRubros.DescuentoRecargo', 'DescuentoRecargoPorc1', 'COLUMN';
PRINT ''
PRINT '4. Tabla SubRubros: Agrego campo DescuentoRecargoPorc2 .'
ALTER TABLE dbo.SubRubros ADD DescuentoRecargoPorc2  decimal(5,2) NULL
GO
PRINT ''
PRINT '4.1. Tabla SubRubros: Valores por defecto para DescuentoRecargoPorc2 .'
UPDATE SubRubros SET DescuentoRecargoPorc2  = 0;
PRINT ''
PRINT '4.2. Tabla SubRubros: NOT NULL en DescuentoRecargoPorc2 .'
ALTER TABLE dbo.SubRubros ALTER COLUMN DescuentoRecargoPorc2 decimal(5,2) NOT NULL
GO





-- Alineaciones
-- Right 64
-- Left 16

PRINT ''
PRINT '5. Buscador para Modificar Reparto.'
IF NOT EXISTS (SELECT 1 FROM Buscadores WHERE IdBuscador = 100)
BEGIN
	-- Tabla Cabecera --
	INSERT INTO Buscadores
			   (IdBuscador, Titulo, AnchoAyuda, IniciaConFocoEn, ColumaBusquedaInicial)
		 VALUES
			   (100, 'Comprobantes para Reenvio', 1000, 'Grilla', '')
	;

	-- Tabla Detalle --
	INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
		VALUES  (100, 'IdTipoComprobante',   1,'Tipo',      16, 80,''),
				(100, 'Letra',               2,'L.',        16, 30,''),
				(100, 'CentroEmisor',        3,'Emis.',     64, 50,'0000'),
				(100, 'NumeroPedido',        4,'Número',    64, 80,''),
				(100, 'NombreEmpleado',      5,'Vendedor',  16, 100,''),
				(100, 'DescripcionFormasPago', 6,'F.Pago',  16, 100,''),
				(100, 'FechaPedido',         7,'F.Pedido',  32, 70,'dd/MM/yyyy'),
				(100, 'CodigoCliente',       8,'Código',    64, 60,''),
				(100, 'NombreCliente',       9,'Cliente',   16, 100,''),
				(100, 'Direccion',          10,'Dirección', 16, 100,''),
				(100, 'ImporteTotal',       11,'Total',     64, 100,'N2'),
				(100, 'Observacion',        12,'Observación', 16, 100,'')
	;
END;


IF NOT EXISTS (SELECT 1 FROM Buscadores WHERE IdBuscador = 101)
BEGIN
	-- Tabla Cabecera --
	INSERT INTO Buscadores
			   (IdBuscador, Titulo, AnchoAyuda, IniciaConFocoEn, ColumaBusquedaInicial)
		 VALUES
			   (101, 'Repartos', 350, 'Grilla', '')
	;
	-- Tabla Detalle --
	INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato)
		VALUES  (101, 'NumeroReparto',      1,'Reparto',        64, 60,''),
				(101, 'FechaEnvio',         2,'F.Envio',        16, 80,'dd/MM/yyyy'),
				(101, 'NombreTransportista',3,'Transportista',  16, 150,'')
	;
END;



PRINT ''
PRINT '6. Nuevas opciones de Menu SiMovil en la Web. Pudieron no implementarse antes.'
GO
IF dbo.ExisteFuncion('Logistica') = 'True' AND dbo.ExisteFuncion('SiMovil') = 'True' 
                                          AND dbo.ExisteFuncion('SiMovilWeb') = 'False'
BEGIN

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion,EsMenu, EsBoton, [Enabled], Visible, 
        IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('SiMovilWeb', 'SiMovil en la Web', 'SiMovil en la Web', 'True', 'False', 'True', 'True', 
        'SiMovil',900, 'Eniac.Win', NULL, null, null,'N','S','N','N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT IdRol, 'SiMovilWeb' FROM RolesFunciones
	 WHERE IdFuncion = 'PreventaV3';

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion,EsMenu, EsBoton, [Enabled], Visible, 
       IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('InfPedidosSiMovil', 'Informe de Pedidos Web de SiMovil', 'Informe de Pedidos Web de SiMovil', 'True', 'False', 'True', 'True', 
        'SiMovilWeb',10, 'Eniac.Win', 'InfPedidosSiMovil', null, null,'N','S','N','N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT IdRol, 'InfPedidosSiMovil' FROM RolesFunciones
	 WHERE IdFuncion = 'PreventaV3';

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion,EsMenu, EsBoton, [Enabled], Visible, 
       IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('AdminPedidosSiMovil', 'Administración de Pedidos Web de SiMovil', 'Administración de Pedidos Web de SiMovil', 'True', 'False', 'True', 'True', 
        'SiMovilWeb',510, 'Eniac.Win', 'InfPedidosSiMovil', null, 'ADMIN','N','S','N','N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT IdRol, 'AdminPedidosSiMovil' FROM RolesFunciones
	 WHERE IdFuncion = 'PreventaV3';
END

