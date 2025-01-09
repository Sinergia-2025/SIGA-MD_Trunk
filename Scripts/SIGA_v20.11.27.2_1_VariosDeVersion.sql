PRINT ''
PRINT '1. Tabla CRMNovedades: Nuevos Campos: PK de Ventas'
ALTER TABLE CRMNovedades ADD IdSucursalFact INT NULL 
ALTER TABLE CRMNovedades ADD IdTipoComprobanteFact VARCHAR(15) NULL 
ALTER TABLE CRMNovedades ADD LetraFact VARCHAR(1) NULL 
ALTER TABLE CRMNovedades ADD CentroEmisorFact INT NULL 
ALTER TABLE CRMNovedades ADD NumeroComprobanteFact BIGINT NULL 
GO

PRINT ''
PRINT '2. Tabla AuditoriaCRMNovedades: Nuevos Campos'
ALTER TABLE AuditoriaCRMNovedades ADD IdSucursalFact INT NULL 
ALTER TABLE AuditoriaCRMNovedades ADD IdTipoComprobanteFact VARCHAR(15) NULL 
ALTER TABLE AuditoriaCRMNovedades ADD LetraFact VARCHAR(1) NULL 
ALTER TABLE AuditoriaCRMNovedades ADD CentroEmisorFact INT NULL 
ALTER TABLE AuditoriaCRMNovedades ADD NumeroComprobanteFact BIGINT NULL 
GO


PRINT ''
PRINT '3. Tabla CRMEstadosNovedades: Nuevo Campo  EsFacturable'
ALTER TABLE CRMEstadosNovedades
	ADD EsFacturable BIT NULL
GO

PRINT ''
PRINT '3.1. Tabla CRMEstadosNovedades: Actualización de registros Pre-Existentes'
UPDATE CRMEstadosNovedades SET EsFacturable = 0
GO

PRINT ''
PRINT '3.2. Tabla CRMEstadosNovedades: Cambio el campo a NOT NULL'
ALTER TABLE CRMEstadosNovedades
	ALTER COLUMN EsFacturable BIT NOT NULL
GO

IF dbo.BaseConCuit('27201734687') = 1 -- BALANMAC
BEGIN
	PRINT ''
	PRINT '3.3 Seteo el valor de EsFacturable en True para el estado Reparado'
	UPDATE CRMEstadosNovedades SET EsFacturable = 1 WHERE IdTipoNovedad = 'SERVICE' AND IdEstadoNovedad = 130
END
GO

PRINT ''
PRINT '4. Tabla TurnosCalendarios: Nuevos Campos'
ALTER TABLE dbo.TurnosCalendarios ADD IdDestino smallint NULL
ALTER TABLE dbo.TurnosCalendarios ADD DestinoLibre varchar(30) NULL
ALTER TABLE dbo.TurnosCalendarios ADD CantidadPasajeros int NULL
ALTER TABLE dbo.TurnosCalendarios ADD FechaHoraLlegada datetime NULL
GO

PRINT ''
PRINT '5. Nuevo estado de turno - Tifon'
IF dbo.BaseConCuit('30711934088') = 1
BEGIN
    INSERT INTO EstadosTurnos (IdEstadoTurno,NombreEstadoTurno,Color,Finalizado) VALUES ('R','Reservado',NULL,'False')
END


PRINT ''
PRINT '6. Parametros: URL sync turnos'
DECLARE @idParametro VARCHAR(MAX) = 'SIMOVILGESTIONTURNOSURLBASE'
DECLARE @descripcionParametro VARCHAR(MAX) = 'URL Base para Simovil Cobranzas y Pedidos Turnos'
DECLARE @valorParametro VARCHAR(MAX) = 'http://tifon.sinergiamovil.com.ar/api/sync/'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

PRINT ''
PRINT '7. Seteo para BALANMAC - Configuración del ticket del estado REPARADO'
IF dbo.BaseConCuit('27201734687')=1
BEGIN
	PRINT ''
	PRINT '7.1. Seteo para BALANMAC - Configuración del ticket del estado REPARADO'
	UPDATE E SET 
		E.Reporte = '213_ComprobanteTicket_Reparado.rdlc',
		E.Imprime = 'True' FROM CRMEstadosNovedades E
	WHERE E.IdEstadoNovedad = 130 AND E.IdTipoNovedad = 'SERVICE'
END	
GO

PRINT ''
PRINT '8. Menu: Nueva opción Sincronizar Turnos'
IF dbo.ExisteFuncion('Turnos') = 1
BEGIN
    PRINT ''
    PRINT '8.1. Menu: Crear nueva opción Sincronizar Turnos'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('SincronizarTurnos', 'Sincronizar Turnos', 'Sincronizar Turnos', 'True', 'False', 'True', 'True'
        ,'Turnos', 300, 'Eniac.Win', 'SincronizarTurnos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '8.2. Menu: asignar roles a Sincronizar Turnos'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SincronizarTurnos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '9. Menu ABM de Tipos de Comentarios'
IF dbo.ExisteFuncion('CRM') = 'True'
BEGIN
	IF (SELECT Id FROM Funciones F WHERE F.Id = 'CRMTiposComentariosNovABM') IS NULL
	BEGIN
		PRINT ''
		PRINT '9.1. Nueva Función ABM de Tipos de Comentarios'
		INSERT INTO Funciones
		    (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
		    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		VALUES
		    ('CRMTiposComentariosNovABM', 'ABM de Tipos de Comentarios', 'ABM de Tipos de Comentarios', 'True', 'False', 'True', 'True'
		    ,'CRM', 590, 'Eniac.Win', 'CRMTiposComentariosNovedadesABM', NULL, NULL
		    ,'True', 'S', 'N', 'N', 'N')

		PRINT ''
		PRINT '9.2. Roles para función ABM de Tipos de Comentarios (copia de estado de novedades)'
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT IdRol, 'CRMTiposComentariosNovABM' FROM RolesFunciones WHERE IdFuncion = 'CRMEstadosNovedadesABM'
	END
END
GO

IF dbo.BaseConCuit('27201734687')=1
BEGIN
	PRINT ''
	PRINT '10. Seteo para BALANMAC'
	UPDATE CRMTiposComentariosNovedades SET VisibleParaCliente = 1 WHERE IdTipoComentarioNovedad = 102 -- BALANMAC
END
GO
