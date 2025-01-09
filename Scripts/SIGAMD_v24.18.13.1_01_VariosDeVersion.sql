IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('InformeOrdenesDeCalidad') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InformeOrdenesDeCalidad', 'Informe de Ordenes de Calidad', 'Informe de Ordenes de Calidad', 'True', 'False', 'True', 'True'
        ,'Calidad', 1000, 'Eniac.Win', 'InformeOrdenesDeCalidad', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')		
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeOrdenesDeCalidad' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

DECLARE @idBuscador int = 560
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'Estados Orden Calidad' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
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
        USING (SELECT @idBuscador IdBuscador, 'IdEstadoCalidad'		 IdBuscadorNombreCampo, 1 Orden, 'Estado Calidad'           Titulo, @alineacion_izq Alineacion, 150  Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'TipoEstadoCalidad'    IdBuscadorNombreCampo, 2 Orden, 'Tipo Estado Calidad'      Titulo, @alineacion_izq Alineacion, 150 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Orden'			     IdBuscadorNombreCampo, 3 Orden, 'Orden'    Titulo, @alineacion_der Alineacion, 120 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
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

IF dbo.ExisteTabla('FuncionesVinculadas') = 0
BEGIN
    CREATE TABLE FuncionesVinculadas(
	    IdFuncion varchar(30) NOT NULL,
	    IdFuncionVinculada varchar(30) NOT NULL,
     CONSTRAINT PK_FuncionesVinculadas PRIMARY KEY CLUSTERED (IdFuncion ASC, IdFuncionVinculada ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_FuncionesVinculadas_Funciones') = 0
BEGIN
    ALTER TABLE dbo.FuncionesVinculadas  WITH CHECK ADD  CONSTRAINT FK_FuncionesVinculadas_Funciones FOREIGN KEY(IdFuncion)
        REFERENCES dbo.Funciones (Id)
    ALTER TABLE dbo.FuncionesVinculadas CHECK CONSTRAINT FK_FuncionesVinculadas_Funciones
END
GO

IF dbo.ExisteFK('FK_FuncionesVinculadas_Funciones_Vinculada') = 0
BEGIN
    ALTER TABLE dbo.FuncionesVinculadas  WITH CHECK ADD  CONSTRAINT FK_FuncionesVinculadas_Funciones_Vinculada FOREIGN KEY(IdFuncionVinculada)
        REFERENCES dbo.Funciones (Id)
    ALTER TABLE dbo.FuncionesVinculadas CHECK CONSTRAINT FK_FuncionesVinculadas_Funciones_Vinculada
END
GO


IF dbo.ExisteIX('IX_FuncionesVinculadas_IdFuncionVinculada') = 0
BEGIN
    CREATE NONCLUSTERED INDEX IX_FuncionesVinculadas_IdFuncionVinculada ON FuncionesVinculadas
        (IdFuncionVinculada ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO

UPDATE OrdenesProduccionMRPProductos
	SET EstadoCompra = NULL
WHERE EstadoCompra = 'NULL'


IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('InfOrdenesDeCalidadDetallado') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfOrdenesDeCalidadDetallado', 'Informe Detallado de Ordenes de Calidad', 'Informe Detallado de Ordenes de Calidad', 'True', 'False', 'True', 'True'
        ,'Calidad', 1010, 'Eniac.Win', 'InfOrdenesDeCalidadDetallado', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')		
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfOrdenesDeCalidadDetallado' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '1. Tabla EstadosOrdenesProduccion: Nuevo Estado REQUERIDO'
IF NOT EXISTS (SELECT * FROM EstadosOrdenesProduccion WHERE IdEstado = 'REQUERIDO')
BEGIN
	DECLARE @sOrden integer = (SELECT MAX(Orden) FROM EstadosOrdenesProduccion) + 1

	INSERT INTO EstadosOrdenesProduccion
           (idEstado
           ,IdTipoComprobante
           ,IdTipoEstado
           ,Orden
           ,Color
           ,ReservaMateriaPrima
           ,GeneraProductoTerminado
           ,TipoEstadoPedido
		   ,IdEstadoPedido)
     VALUES
           ('REQUERIDO'
           ,NULL
           ,'EN PROCESO'
           ,@sOrden
           ,0
           ,0
           ,0
           ,NULL
           ,NULL)
END
GO

PRINT ''
PRINT '2. Tabla Parametros: Actualiza Parametro ESTADOORDENPRODUCCIONPLANIFICACIONRQ'
BEGIN
	UPDATE Parametros
		SET ValorParametro = 'REQUERIDO'
	WHERE IdParametro = 'ESTADOORDENPRODUCCIONPLANIFICACIONRQ'
END
GO

	--Estado COLOCACION
	IF EXISTS (SELECT * FROM OrdenesProduccionEstados WHERE IdEstado LIKE 'COLOCACION')
	BEGIN
    PRINT 'Existe una orden de producción que utiliza el ID COLOCACION, no se elimina'
	END

	ELSE
	BEGIN
	DELETE FROM EstadosOrdenesProduccionSucursales WHERE IdEstado = 'COLOCACION';
	DELETE FROM EstadosOrdenesProduccion WHERE IdEstado LIKE 'COLOCACION';
    PRINT 'Se eliminó el estado COLOCACION'
	END

	--Estado ESPMEDIDAS
	IF EXISTS (SELECT * FROM OrdenesProduccionEstados WHERE IdEstado LIKE 'ESPMEDIDAS')
	BEGIN
    PRINT 'Existe una orden de producción que utiliza el ID ESPMEDIDAS, no se elimina'
	END

	ELSE
	BEGIN
	DELETE FROM EstadosOrdenesProduccionSucursales WHERE IdEstado = 'ESPMEDIDAS';
	DELETE FROM EstadosOrdenesProduccion WHERE IdEstado LIKE 'ESPMEDIDAS'
    PRINT 'Se eliminó el estado ESPMEDIDAS'
	END

	--Estado OkFabrica
	IF EXISTS (SELECT * FROM OrdenesProduccionEstados WHERE IdEstado LIKE 'OkFabrica')
	BEGIN
    PRINT 'Existe una orden de producción que utiliza el ID OkFabrica, no se elimina'
	END

	ELSE
	BEGIN
	DELETE FROM EstadosOrdenesProduccionSucursales WHERE IdEstado = 'OkFabrica';
	DELETE FROM EstadosOrdenesProduccion WHERE IdEstado LIKE 'OkFabrica';
    PRINT 'Se eliminó el estado OkFabrica'
	END

	--Estado RETENIDA
	IF EXISTS (SELECT * FROM OrdenesProduccionEstados WHERE IdEstado LIKE 'RETENIDA')
	BEGIN
    PRINT 'Existe una orden de producción que utiliza el ID RETENIDA, no se elimina'
	END

	ELSE
	BEGIN
	DELETE FROM EstadosOrdenesProduccionSucursales WHERE IdEstado = 'RETENIDA';
	DELETE FROM EstadosOrdenesProduccion WHERE IdEstado LIKE 'RETENIDA';
    PRINT 'Se eliminó el estado RETENIDA'
	END

	--SCRIP mover ABMs de "MRP" a "Calidad"

IF EXISTS (SELECT * FROM Funciones WHERE IdPadre LIKE 'MRP')
BEGIN
--Chequeo de que existen funciones con padre "MRP"

	IF EXISTS (SELECT * FROM Funciones WHERE Id LIKE 'MRPAQLAABM')
	BEGIN
	update Funciones set IdPadre = 'Calidad' where Id Like 'MRPAQLAABM'
	PRINT 'Se movió la función de "MRP" hacia "Calidad".'
	END

	ELSE
	BEGIN
	PRINT 'No se encontró la función.'
	END

	
	IF EXISTS (SELECT * FROM Funciones WHERE Id LIKE 'MRPAQLBABM')
	BEGIN
	update Funciones set IdPadre = 'Calidad' where Id Like 'MRPAQLBABM'
	PRINT 'Se movió la función de "MRP" hacia "Calidad".'
	END

	ELSE
	BEGIN
	PRINT 'No se encontró la función.'
	END

END

ELSE
BEGIN
PRINT 'No existen funciones que tengan como padre "MRP".'
END