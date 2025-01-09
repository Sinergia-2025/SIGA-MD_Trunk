

		--Inserto el Menu Cargos
BEGIN
		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
		  VALUES
			 ('Cargos', 'Cargos', '', 'True', 'False', 'True', 'True',NULL
			  , 8, NULL, NULL, NULL,  NULL
            ,'True', 'S', 'N', 'N', 'N', NULL, 'True');
		GO
		INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'Cargos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
		GO
		--Inserto la pantalla nueva

		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo, EsMDIChild)
		  VALUES
			 ('CargosABM', 'ABM de Cargos', 'ABM de Cargos', 'True', 'False', 'True', 'True',
			  'Cargos', 200, 'Eniac.Win', 'CargosABM', NULL,  NULL
            ,'True', 'S', 'N', 'N', 'N', NULL, 'True');
		INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'CargosABM' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
		GO			
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
		VALUES
			('CargosClientes', 'Asignación de Cargos a Clientes', 'Asignación de Cargos a Clientes', 'True', 'False', 'True', 'True',
			'Cargos', 50, 'Eniac.Win', 'CargosClientes', NULL,  NULL
            ,'True', 'S', 'N', 'N', 'N', NULL, 'True');
		GO
		INSERT INTO RolesFunciones 
			(IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'CargosClientes' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
			
		GO		
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
		VALUES
			'ModImporteCargoPorCliente', 'Modificar Importe Cargo por Cliente', 'Modificar Importe Cargo por Cliente', 'True', 'False', 'True', 'True',
			'Cargos', 60, 'Eniac.Win', 'ModificarImporteCargoPorCliente', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', NULL, 'True');
		GO
		INSERT INTO RolesFunciones 
			(IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'ModImporteCargoPorCliente' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
		GO
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
		VALUES
		 ('GeneracionLiquidPorCliente', 'Generacion Liquidacion Cargos Por Cliente', 'Generacion Liquidacion Cargos Por Cliente', 'True', 'False', 'True', 'True',
		  'Cargos', 70, 'Eniac.Win', 'GeneracionLiquidacionPorCliente', NULL, NULL
           ,'True', 'S', 'N', 'N', 'N', NULL, 'True');
		GO
		INSERT INTO RolesFunciones 
			(IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'GeneracionLiquidPorCliente' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
			
		GO			
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
		VALUES
			('InfCargosClientes', 'Informe de Cargos a Clientes', 'Informe de Cargos a Clientes', 'True', 'False', 'True', 'True',
			'Cargos', 80, 'Eniac.Win', 'InfCargosClientes', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', NULL, 'True');
		GO
		INSERT INTO RolesFunciones 
			(IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'InfCargosClientes' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
		GO
		
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
		VALUES
			('GenerarFacturasDeCargos', 'Generar Facturas de Cargos', 'Generar Facturas de Cargos', 'True', 'False', 'True', 'True',
			'Cargos', 90, 'Eniac.Win', 'GenerarFacturasDeCargos', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', NULL, 'True');
		GO

		INSERT INTO RolesFunciones 
			(IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'GenerarFacturasDeCargos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
		GO

		DECLARE @max int
		SET @max = 6

		INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda, IniciaConFocoEn, ColumaBusquedaInicial) VALUES (@max, 'Cargos', 1000, 'Grilla', '');

		INSERT INTO BuscadoresCampos(IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato, Condicion, Valor, ColorFila) 
		VALUES
			(@max, 'IdCargo',1, 'Codigo', 64, 50,'',NULL,NULL,NULL),
			(@max, 'NombreCargo',2, 'Nombre', 16, 180,'',NULL,NULL,NULL),
			(@max, 'Monto',3, 'Monto', 64, 70,'',NULL,NULL,NULL),
			(@max, 'IdProducto',4,'Producto', 64, 80,'',NULL,NULL,NULL),
			(@max, 'NombreProducto',5, 'Nombre Producto', 16, 180,'',NULL,NULL,NULL),
			(@max, 'CantidadCuotas',6, 'Cant. Cuotas', 64, 60,'',NULL,NULL,NULL),
			(@max, 'CuotaActual',7, 'Cuota Actual', 64, 60,'',NULL,NULL,NULL),
			(@max, 'CantidadMeses',8, 'Cantidad de Meses', 64, 60,'',NULL,NULL,NULL),
			(@max, 'ModificaImporte',9, 'Modifica Importe', 32, 60,'',NULL,NULL,NULL),
			(@max, 'ModificaCantidad',10, 'Modifica Cantidad', 32, 60,'',NULL,NULL,NULL),
			(@max, 'ImprimeVoucher',11, 'Voucher', 32, 40,'',NULL,NULL,NULL),
			(@max, 'Activo',12, 'Activo', 32, 40,'',NULL,NULL,NULL)
		
		GO
		
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo, EsMDIChild)
		VALUES
			('InfCargos', 'Informe de Liquidacion de Cargos', 'Informe de Liquidacion de Cargos', 'True', 'False', 'True', 'True',
			'Cargos', 80, 'Eniac.Win', 'InfCargos', NULL,  NULL
            ,'True', 'S', 'N', 'N', 'N', NULL, 'True');
		GO

		INSERT INTO RolesFunciones 
			(IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'InfCargos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
		GO
END
