IF dbo.ExisteFuncion('AlertasSistemaABM') = 1 AND dbo.ExisteFuncion('Configuraciones') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AlertasSistemaABM', 'ABM Alertas del sistema', 'ABM Alertas del sistema', 'True', 'False', 'True', 'True'
        ,'Configuraciones', 95, 'Eniac.Win', 'AlertasSistemaABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AlertasSistemaABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

INSERT INTO CRMNovedadesCambiosEstados
    (IdTipoNovedad,Letra,CentroEmisor,IdNovedad
    ,IdCambioEstado,FechaCambioEstado,IdEstadoNovedad
    ,IdUsuario,IdUsuarioAsignado,IdSucursalNovedad)
SELECT N.IdTipoNovedad,N.Letra,N.CentroEmisor,N.IdNovedad
     , -1 IdCambioEstado, N.FechaAlta FechaCambioEstado, EN.IdEstadoNovedad
     , N.IdUsuarioAlta IdUsuario, N.IdUsuarioAsignado, N.IdSucursalNovedad
  FROM CRMNovedades N
  LEFT JOIN CRMEstadosNovedades EN ON EN.IdTipoNovedad = N.IdTipoNovedad AND EN.PorDefecto = 1
 WHERE NOT EXISTS (SELECT 1
                     FROM CRMNovedadesCambiosEstados NCE
                    WHERE NCE.IdTipoNovedad = N.IdTipoNovedad
                      AND NCE.Letra = N.Letra
                      AND NCE.CentroEmisor = N.CentroEmisor
                      AND NCE.IdNovedad = N.IdNovedad
                      AND NCE.IdCambioEstado > 0)

INSERT INTO CRMNovedadesCambiosEstados
    (IdTipoNovedad,Letra,CentroEmisor,IdNovedad
    ,IdCambioEstado,FechaCambioEstado,IdEstadoNovedad
    ,IdUsuario,IdUsuarioAsignado,IdSucursalNovedad)
SELECT N.IdTipoNovedad,N.Letra,N.CentroEmisor,N.IdNovedad
     , 2 IdCambioEstado, N.FechaEstadoNovedad FechaCambioEstado, N.IdEstadoNovedad
     , N.IdUsuarioEstadoNovedad IdUsuario, N.IdUsuarioAsignado, N.IdSucursalNovedad
  FROM CRMNovedades N
 WHERE NOT EXISTS (SELECT 1
                     FROM CRMNovedadesCambiosEstados NCE
                    WHERE NCE.IdTipoNovedad = N.IdTipoNovedad
                      AND NCE.Letra = N.Letra
                      AND NCE.CentroEmisor = N.CentroEmisor
                      AND NCE.IdNovedad = N.IdNovedad
                      AND NCE.IdCambioEstado > 0)

UPDATE CRMNovedadesCambiosEstados
   SET IdCambioEstado = 1
 WHERE IdCambioEstado < 0


DECLARE @idBuscador int = 41
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'Cajas' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
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
        USING (SELECT @idBuscador IdBuscador, 'IdSucursal' IdBuscadorNombreCampo,  1 Orden, 'Suc.'        Titulo, @alineacion_der Alineacion,  50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'IdCaja'     IdBuscadorNombreCampo,  2 Orden, 'Caja'        Titulo, @alineacion_der Alineacion,  80 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreCaja' IdBuscadorNombreCampo,  3 Orden, 'Nombre Caja' Titulo, @alineacion_izq Alineacion, 150 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombrePC'   IdBuscadorNombreCampo,  4 Orden, 'Nombre PC'   Titulo, @alineacion_izq Alineacion, 150 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'IdUsuario'  IdBuscadorNombreCampo,  5 Orden, 'Usuario'     Titulo, @alineacion_izq Alineacion, 100 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
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

SET @idBuscador = 60

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'Sucursales' Titulo, 400 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
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
        USING (SELECT @idBuscador IdBuscador, 'IdSucursal' IdBuscadorNombreCampo,  1 Orden, 'Código'    Titulo, @alineacion_der Alineacion,   50 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'Nombre'     IdBuscadorNombreCampo,  2 Orden, 'Sucursal'  Titulo, @alineacion_izq Alineacion,  200 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
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
