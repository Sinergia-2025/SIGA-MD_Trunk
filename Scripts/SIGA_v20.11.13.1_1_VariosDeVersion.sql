PRINT ''
PRINT '1. Nuevo Campo: NroSerieProductoPrestado'
ALTER TABLE CRMNovedades ADD NroSerieProductoPrestado VARCHAR(50) NULL
GO

PRINT ''
PRINT '1.1. Nuevo Campo Auditoría: NroSerieProductoPrestado'
ALTER TABLE AuditoriaCRMNovedades  ADD NroSerieProductoPrestado VARCHAR(50) NULL
GO


PRINT ''
PRINT '2. Datos Metalsur'
IF dbo.BaseConCuit('33631312379') = 1
BEGIN
    PRINT ''
    PRINT '2.1. Tabla CalidadListasControlTipos: Datos'
    UPDATE CalidadListasControlTipos
       SET NombreListaControlTipo = 'Mecánica', RangoDesde = 1, RangoHasta = 999
     WHERE IdListaControlTipo = 1

    INSERT INTO CalidadListasControlTipos
           (IdListaControlTipo,NombreListaControlTipo,RangoDesde,RangoHasta)
    VALUES (2,'Herreria',    1000, 1999),
           (3,'Chaperia',    2000, 2999),
           (4,'Pintura',     3000, 3999),
           (5,'Terminación', 4000, 4999),
           (6,'PDI',         5000, 5999),
           (99,'A definir',  6000, 9999999)

    UPDATE CalidadListasControl
       SET IdListaControlTipo = CASE WHEN Orden < 1000 THEN 1 ELSE
                                CASE WHEN Orden < 2000 THEN 2 ELSE
                                CASE WHEN Orden < 3000 THEN 3 ELSE
                                CASE WHEN Orden < 4000 THEN 4 ELSE
                                CASE WHEN Orden < 5000 THEN 5 ELSE
                                CASE WHEN Orden < 6000 THEN 6 ELSE 99
                                END END END END END END
END

PRINT ''
PRINT '3. Opciones de menú Metalsur'
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN

    PRINT ''
    PRINT '3.1. Renombrar Panel de Control'
    UPDATE Funciones
    SET Nombre = 'Panel de Control detallado' 
     , Descripcion = 'Panel de Control detallado' 
	 ,Posicion = 21
    WHERE Id = 'PanelDeControl'
		

    PRINT ''
    PRINT '3.2. Nueva función menú Calidad: Panel de Control'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
	   ('PanelDeControlPorTipo', 'Panel de Control', 'Panel de Control', 'True', 'False', 'True', 'True'
        ,'Calidad', 20, 'Eniac.Win', 'PanelDeControlPorTipo', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
         
    PRINT ''
    PRINT '3.3. Roles menú Pedidos Prov.'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'PanelDeControlPorTipo' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '4. Configuración de reporte específico para el cliente BALANMAC'
IF dbo.BaseConCuit('27201734687') = 1
BEGIN 
	UPDATE CRMTiposNovedades SET Reporte = '213_CRMServiceRecepcion.rdlc', Embebido = 'False'
	  WHERE IdTipoNovedad = 'SERVICE'
END
