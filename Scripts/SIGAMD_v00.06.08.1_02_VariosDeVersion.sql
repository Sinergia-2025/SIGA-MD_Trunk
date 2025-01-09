DECLARE @idAlerta INT = (SELECT ISNULL(MAX(IdAlertaSistema), 0) FROM AlertasSistema) + 1
IF NOT EXISTS(SELECT 1 FROM AlertasSistema WHERE TituloAlerta = 'Productos sin Deposito/Ubicación Predefinida')
BEGIN
    INSERT [dbo].[AlertasSistema] ([IdAlertaSistema], [TituloAlerta], [ConsultaAlerta], [PermisosCondicion], [IdFuncionClick], [ParametrosPantalla], [UtilizaConsultaGenerica]) VALUES 
        (@idAlerta, N'Productos sin Deposito/Ubicación Predefinida',
    'SELECT PS.IdSucursal
         , S.Nombre NombreSucursal
         , PS.IdProducto
         , P.NombreProducto
         , PS.IdDepositoDefecto
         , SD.NombreDeposito
         , PS.IdUbicacionDefecto
         , SU.NombreUbicacion
      FROM ProductosSucursales PS
     INNER JOIN Productos P ON P.IdProducto = PS.IdProducto
     INNER JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal
      LEFT JOIN SucursalesDepositos SD ON SD.IdSucursal = PS.IdSucursal AND SD.IdDeposito = PS.IdDepositoDefecto
      LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PS.IdSucursal AND SU.IdDeposito = PS.IdDepositoDefecto AND SU.IdUbicacion = PS.IdUbicacionDefecto
     WHERE (IdDepositoDefecto IS NULL OR IdUbicacionDefecto IS NULL)',

    'AND', NULL, N'', 1)

    INSERT [dbo].[AlertasSistemaCondiciones] ([IdAlertaSistema], [OrdenCondicion], [CondicionCount], [ValorCondicionCount], [MensajeCount], [ColorCondicionCount], [OrdenPrioridad], [MostrarPopUp], [ParametrosAdicionalesPantalla]) VALUES 
    (@idAlerta, 0, N'Mayor', 0, N'Hay @@COUNT@@ Productos sin Deposito/Ubicación Predefinida', -256, 200, 0, N'')

    INSERT [dbo].[AlertasSistemaPermisos] ([IdAlertaSistema], [IdFuncion]) VALUES (@idAlerta, N'Productos')
END


DECLARE @idViejo VARCHAR(MAX) = 'ConsultarOrdenCompraProv'
DECLARE @idNuevo VARCHAR(MAX) = 'ConsultarOCProv'

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = @idViejo)
BEGIN
    INSERT INTO Funciones
          (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
         , IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias
         , Plus, Express, Basica, PV, IdModulo, EsMDIChild)
    SELECT @idNuevo Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
         , IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias
         , Plus, Express, Basica, PV, IdModulo, EsMDIChild
      FROM Funciones
     WHERE Id = @idViejo
END

UPDATE RolesFunciones SET IdFuncion = @idNuevo WHERE IdFuncion = @idViejo

UPDATE Bitacora SET IdFuncion = @idNuevo WHERE IdFuncion = @idViejo
UPDATE Traducciones SET IdFuncion = @idNuevo WHERE IdFuncion = @idViejo
UPDATE Funciones SET IdPadre = @idNuevo WHERE IdPadre = @idViejo

DELETE Funciones WHERE Id = @idViejo

IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('InfReqComprasDetProducto') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfReqComprasDetProducto', 'Inf. Req. de Compra Det. Producto', 'Inf. Req. de Compra Det. Producto', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 550, 'Eniac.Win', 'InfReqComprasDetProducto', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfReqComprasDetProducto' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT 'T1. Nueva Tabla: Ordenes Produccion MRP.'
BEGIN 
	UPDATE BuscadoresCampos 
		SET Titulo = 'Nombre Deposito'
	WHERE IdBuscador = 55 AND Orden = 4
END 
GO

