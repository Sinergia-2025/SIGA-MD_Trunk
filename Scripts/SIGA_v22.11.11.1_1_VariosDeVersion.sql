PRINT ''
PRINT '1. Nueva Funcion: EliminarPagoAProveedores'
IF dbo.ExisteFuncion('CuentasCorrientesProveedores') = 1 and  dbo.ExisteFuncion('EliminarPagoAProveedores') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('EliminarPagoAProveedores', 'Eliminar Pago a Proveedores Anulados', 'Eliminar Pago a Proveedores Anulados', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientesProveedores', 21, 'Eniac.Win', 'EliminarPagoAProveedores', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'EliminarPagoAProveedores' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '2. Nueva Buscador: Marcas'
BEGIN
	DECLARE @idBuscador int = 208
	DECLARE @alineacion_der int = 64
	DECLARE @alineacion_izq int = 16

	MERGE INTO Buscadores AS D
			USING (SELECT @idBuscador IdBuscador, 'Marcas' Titulo, 400 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
		WHEN MATCHED THEN
			UPDATE SET D.Titulo                 = O.Titulo
					 , D.AnchoAyuda             = O.AnchoAyuda
					 , D.IniciaConFocoEn        = O.IniciaConFocoEn
					 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
		WHEN NOT MATCHED THEN 
			INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
			VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial)
	;
	MERGE INTO BuscadoresCampos AS D
			USING (SELECT @idBuscador IdBuscador, 'IdMarca' IdBuscadorNombreCampo,  1 Orden, 'Codigo'        Titulo, @alineacion_der Alineacion,  50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador IdBuscador, 'NombreMarca'  IdBuscadorNombreCampo,  2 Orden, 'Descripcion'     Titulo, @alineacion_izq Alineacion, 250 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
				   ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
		WHEN MATCHED THEN
			UPDATE SET D.Orden      = O.Orden
					 , D.Titulo     = O.Titulo
					 , D.Alineacion = O.Alineacion
					 , D.Ancho      = O.Ancho
					 , D.Formato    = O.Formato
					 , D.Condicion  = O.Condicion
					 , D.Valor      = O.Valor
					 , D.ColorFila  = O.ColorFila
		WHEN NOT MATCHED THEN 
			INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho,   Formato,   Condicion,   Valor,   ColorFila) 
			VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila);
END
GO

PRINT ''
PRINT '3. Nuevo Campo Responsable de Produccion.'
BEGIN
	ALTER TABLE Empleados ADD EsRespProd bit NULL
END
GO

PRINT ''
PRINT '4. Nuevo Campo Responsable de Produccion.'
BEGIN
	UPDATE Empleados SET EsRespProd = 0
	ALTER TABLE Empleados ALTER COLUMN EsRespProd bit NOT NULL
END
GO

PRINT ''
PRINT '5. Tabla ProductosComponentes: Nuevo campo PorcCostoProduccion'
IF dbo.ExisteCampo('ProductosComponentes', 'PorcCostoProduccion') = 1
    ALTER TABLE dbo.ProductosComponentes DROP COLUMN PorcCostoProduccion
GO

PRINT ''
PRINT '6. Nuevos Buscadores.'
BEGIN
	DECLARE @idBuscador25  int = 25
	DECLARE @idBuscador42  int = 42
	DECLARE @idBuscador70  int = 70
	DECLARE @idBuscador75  int = 75
	DECLARE @idBuscador110 int = 110
	DECLARE @idBuscador91  int = 91
	DECLARE @idBuscador92  int = 92
	DECLARE @idBuscador80  int = 80
	DECLARE @idBuscador85  int = 85
	DECLARE @idBuscador33  int = 33
	DECLARE @idBuscador35  int = 35

	DECLARE @alineacion_der int = 64
	DECLARE @alineacion_izq int = 16

	DELETE BuscadoresCampos WHERE IdBuscador IN (@idBuscador25, @idBuscador42, @idBuscador70, @idBuscador75, @idBuscador110, @idBuscador91, @idBuscador92, @idBuscador80, @idBuscador85, @idBuscador33, @idBuscador35);

	MERGE INTO Buscadores AS D
			USING (SELECT @idBuscador25  IdBuscador, 'Empleados'                    Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador42  IdBuscador, 'Estados Cheques'              Titulo, 550 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador70  IdBuscador, 'Formas de Pago'               Titulo, 550 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador75  IdBuscador, 'Listas de Precios'            Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador110 IdBuscador, 'Rutas'                        Titulo, 350 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador91  IdBuscador, 'Tipos de Comprobantes'        Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador92  IdBuscador, 'Grupo Tipos de Comprobantes'  Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador80  IdBuscador, 'Tipos de Clientes'            Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador85  IdBuscador, 'Categorias Cliente'           Titulo, 500 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador33  IdBuscador, 'Marcas'                       Titulo, 500 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial UNION ALL
				   SELECT @idBuscador35  IdBuscador, 'Localidades'                  Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial
				  ) AS O ON D.IdBuscador = O.IdBuscador
		WHEN MATCHED THEN
			UPDATE SET D.Titulo                 = O.Titulo
					 , D.AnchoAyuda             = O.AnchoAyuda
					 , D.IniciaConFocoEn        = O.IniciaConFocoEn
					 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
		WHEN NOT MATCHED THEN 
			INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
			VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial)
	;

	MERGE INTO BuscadoresCampos AS D
			USING (SELECT @idBuscador25  IdBuscador, 'IdEmpleado'           IdBuscadorNombreCampo,  1 Orden, 'Código'           Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador25  IdBuscador, 'NombreEmpleado'       IdBuscadorNombreCampo,  2 Orden, 'Nombre Empleado'  Titulo, @alineacion_izq Alineacion, 350 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador42  IdBuscador, 'IdEstadoCheque'       IdBuscadorNombreCampo,  1 Orden, 'Estado'           Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador42  IdBuscador, 'NombreEstadoCheque'   IdBuscadorNombreCampo,  2 Orden, 'Descripción'      Titulo, @alineacion_izq Alineacion, 400 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador70  IdBuscador, 'IdFormasPago'          IdBuscadorNombreCampo, 1 Orden, 'Código'           Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador70  IdBuscador, 'DescripcionFormasPago' IdBuscadorNombreCampo, 2 Orden, 'Descripción'      Titulo, @alineacion_izq Alineacion, 350 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador75  IdBuscador, 'IdListaPrecios'       IdBuscadorNombreCampo,  1 Orden, 'Código'           Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador75  IdBuscador, 'NombreListaPrecios'   IdBuscadorNombreCampo,  2 Orden, 'Descripción'      Titulo, @alineacion_izq Alineacion, 350 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador110 IdBuscador, 'IdRuta'               IdBuscadorNombreCampo,  1 Orden, 'Código'           Titulo, @alineacion_der Alineacion,  80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador110 IdBuscador, 'NombreRuta'           IdBuscadorNombreCampo,  2 Orden, 'Ruta'             Titulo, @alineacion_izq Alineacion, 250 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador91  IdBuscador, 'IdTipoComprobante'    IdBuscadorNombreCampo,  1 Orden, 'Tipo Comp.'       Titulo, @alineacion_izq Alineacion, 150 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador91  IdBuscador, 'Descripcion'          IdBuscadorNombreCampo,  2 Orden, 'Descripción'      Titulo, @alineacion_izq Alineacion, 350 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador92  IdBuscador, 'IdGrupo'              IdBuscadorNombreCampo,  1 Orden, 'Código'           Titulo, @alineacion_izq Alineacion, 150 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador92  IdBuscador, 'NombreGrupo'          IdBuscadorNombreCampo,  2 Orden, 'Nombre'           Titulo, @alineacion_izq Alineacion, 250 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador80  IdBuscador, 'IdTipoCliente'        IdBuscadorNombreCampo,  1 Orden, 'Código'           Titulo, @alineacion_der Alineacion, 150 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador80  IdBuscador, 'NombreTipoCliente'    IdBuscadorNombreCampo,  2 Orden, 'Tipo de Cliente'  Titulo, @alineacion_izq Alineacion, 350 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador85  IdBuscador, 'IdCategoria'          IdBuscadorNombreCampo,  1 Orden, 'Código'           Titulo, @alineacion_der Alineacion,  80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador85  IdBuscador, 'NombreCategoria'      IdBuscadorNombreCampo,  2 Orden, 'Descripción'      Titulo, @alineacion_izq Alineacion, 350 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador33  IdBuscador, 'IdMarca'              IdBuscadorNombreCampo,  1 Orden, 'Código'           Titulo, @alineacion_der Alineacion,  80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador33  IdBuscador, 'NombreMarca'          IdBuscadorNombreCampo,  2 Orden, 'Descripción'      Titulo, @alineacion_izq Alineacion, 350 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador35  IdBuscador, 'IdLocalidad'          IdBuscadorNombreCampo,  1 Orden, 'Código'           Titulo, @alineacion_der Alineacion,  70 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador35  IdBuscador, 'NombreLocalidad'      IdBuscadorNombreCampo,  2 Orden, 'Localidad'        Titulo, @alineacion_izq Alineacion, 250 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
				   SELECT @idBuscador35  IdBuscador, 'NombreProvincia'      IdBuscadorNombreCampo,  3 Orden, 'Provincia'        Titulo, @alineacion_izq Alineacion, 200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila

				   ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
		WHEN MATCHED THEN
			UPDATE SET D.Orden      = O.Orden
					 , D.Titulo     = O.Titulo
					 , D.Alineacion = O.Alineacion
					 , D.Ancho      = O.Ancho
					 , D.Formato    = O.Formato
					 , D.Condicion  = O.Condicion
					 , D.Valor      = O.Valor
					 , D.ColorFila  = O.ColorFila
		WHEN NOT MATCHED THEN 
			INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho,   Formato,   Condicion,   Valor,   ColorFila) 
			VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila)
	;
END
GO

PRINT ''
PRINT '7. Tabla FormatoEtiquetas: Agrega formato 4 x Ancho (3 x 2.9 cm)'
BEGIN
	DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;

	INSERT INTO [dbo].[FormatosEtiquetas]
			   ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
			   ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
			   ,[Activo])
		 VALUES
			   (@maxId, '4 x Ancho (3 x 2.9 cm) ', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF19.rdlc', 'True'
			   ,'', 'False', 4, 'False', 'False','True');
END
GO

PRINT ''
PRINT '8. Cambios de Campos.'
BEGIN
	ALTER TABLE SueldosPersonal ALTER COLUMN SueldoBasico DECIMAL(16,2) NOT NULL
	ALTER TABLE SueldosPersonal ALTER COLUMN MejorSueldo DECIMAL(16,2) NOT NULL
	ALTER TABLE SueldosPersonal ALTER COLUMN AcumuladoAnual DECIMAL(16,2) NOT NULL
	ALTER TABLE SueldosPersonal ALTER COLUMN AcumuladoSalarioFamiliar DECIMAL(16,2) NOT NULL
	ALTER TABLE SueldosPersonal ALTER COLUMN SueldoActual DECIMAL(16,2) NOT NULL
	ALTER TABLE SueldosPersonal ALTER COLUMN SalarioFamiliarActual DECIMAL(16,2) NOT NULL
	ALTER TABLE SueldosPersonal ALTER COLUMN AnteriorAcumuladoAnual DECIMAL(16,2) NOT NULL
	ALTER TABLE SueldosPersonal ALTER COLUMN AnteriorMejorSueldo DECIMAL(16,2) NOT NULL
	ALTER TABLE SueldosPersonal ALTER COLUMN AnteriorSalarioFamiliar DECIMAL(16,2) NOT NULL
END
GO
