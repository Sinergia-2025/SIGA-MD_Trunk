
PRINT ''
PRINT '1. Función: Permitir Vincular'
GO
IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'ContabilidadGeneracionAsientos')
BEGIN
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
             IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
             PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
            ('Contabilidad-PermiteVincular', 'Contabilidad - Permite Vincular Con Asiento Manual', 'Contabilidad - Permite Vincular Con Asiento Manual', 'False', 'False', 'True', 'True', 
            'ContabilidadGeneracionAsientos', 999, '', '', NULL, NULL,
            'True', 'S', 'N', 'N', 'N');
END;
GO

PRINT ''
PRINT '2. Traducción: Modificar Presupuesto'
GO

IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'ModificarPresupuesto')
BEGIN
    INSERT Traducciones (IdFuncion, Pantalla, Control, IdIdioma, Texto) 
      VALUES 
		     ('ModificarPresupuesto', '', 'chbIdPedido', 'es_AR', 'Presupuesto'),   
		     ('ModificarPresupuesto', '', 'Me', 'es_AR', 'Modificar Presupuestos')   
END;

PRINT ''
PRINT '3. Función: Informe de Dispositivos de Clientes'
GO

IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'Estadisticas')

BEGIN

	INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
			 IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
			 PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		VALUES
			('InfCLienteDispositivos', 'Informe de Dispositivos de Clientes', 'Informe de Dispositivos de Clientes', 'True', 'False', 'True', 'True', 
			 'Estadisticas', 50, 'Eniac.Win', 'InfCLienteDispositivos', NULL, NULL,
			 'True', 'S', 'N', 'N', 'N');


	INSERT INTO RolesFunciones (IdRol, IdFuncion)
	SELECT IdRol, 'InfCLienteDispositivos' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComando'

	PRINT ''
	PRINT '4. Función: Informe de Parametros de Clientes'

	INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
			 IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
			 PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		VALUES
			('InfCLienteParametros', 'Informe de Clientes Parametros', 'Informe de Clientes Parametros', 'True', 'False', 'True', 'True', 
			 'Estadisticas', 60, 'Eniac.Win', 'InfCLienteParametros', NULL, NULL,
			 'True', 'S', 'N', 'N', 'N');

	INSERT INTO RolesFunciones (IdRol, IdFuncion)
	SELECT IdRol, 'InfCLienteParametros' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComando';

END;
GO

PRINT ''
PRINT '5. Parametro: MODALIDADCOEFICIENTECOBRANZAS'

DECLARE @ValorParametro varchar(max) = 'VencidosCobrados'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('20326412830'))
BEGIN
    SET @ValorParametro = 'SoloVencidos'

END

MERGE INTO Parametros AS P
        USING (SELECT 'MODALIDADCOEFICIENTECOBRANZAS' AS IdParametro, @ValorParametro ValorParametro, 'Informe Coeficiente de CobranzasModalidad'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;

--SELECT *
--  FROM Parametros 
-- WHERE IdParametro = 'MODALIDADCOEFICIENTECOBRANZAS'

PRINT ''
PRINT '6. Corrige fechas de ejecuciones'
GO

UPDATE ClientesBackups
   SET FechaEjecucion = DATEADD(HOUR,-3,FechaEjecucion)
     , FechaInicioBackup = DATEADD(HOUR,-3,FechaInicioBackup)
     , FechaFinBackup = DATEADD(HOUR,-3,FechaFinBackup)

