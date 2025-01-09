IF dbo.ExisteFuncion('PanelDeControlPorTipo') = 1
BEGIN
    PRINT ''
    PRINT '3.2. Nueva función menú Calidad: Panel de Control'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
	   ('PanelDeControlGerencial', 'Panel de Control Gerencia', 'Panel de Control Gerencia', 'True', 'False', 'True', 'True'
        ,'Calidad', 25, 'Eniac.Win', 'PanelDeControlPorTipo', NULL, 'ocultarfiltros'
        ,'True', 'S', 'N', 'N', 'N')
         
    PRINT ''
    PRINT '3.3. Roles menú Pedidos Prov.'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'PanelDeControlGerencial' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '1. Nuevo Estado: ALTA en Service CRM'
IF EXISTS(SELECT * FROM CRMNovedades WHERE IdTipoNovedad = 'SERVICE')
BEGIN

    INSERT INTO CRMEstadosNovedades (
	    IdEstadoNovedad,
	    NombreEstadoNovedad,
	    Posicion,
	    SolicitaUsuario,
	    Finalizado,
	    IdTipoNovedad,
	    PorDefecto,
	    Color,
	    DiasProximoContacto,
	    ActualizaUsuarioResponsable,
	    SolicitaProveedorService,
	    Imprime,
	    Reporte,
	    Embebido,
	    AcumulaContador1,
	    AcumulaContador2
    ) VALUES (
	    160,
	    'Alta',
	    160,
	    'False',
	    'False',
	    'SERVICE',
	    'False',
	    NULL,
	    NULL,
	    'False',
	    'False',
	    'False',
	    NULL,
	    'False',
	    'False',
	    'False'
    )
END
