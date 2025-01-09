
PRINT ''
PRINT '1. Nueva Pantalla: Parametros (solo perfil Admin).'
GO

--DELETE RolesFunciones WHERE IdFuncion = 'ParametrosABM';

--DELETE Funciones WHERE Id = 'ParametrosABM';

INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
        IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
    VALUES
        ('ParametrosABM', 'ABM de Parámetros', 'ABM de Parámetros', 'True', 'False', 'True', 'True', 
        'Configuraciones', 29, 'Eniac.Win', 'ParametrosABM', NULL, NULL)
;

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ParametrosABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm')
;


PRINT ''
PRINT '2. Tabla RecepcionEstados: Nuevo Campo "Reporte".'
GO

ALTER TABLE RecepcionEstados ADD Reporte varchar(150) null
GO


PRINT ''
PRINT '3. RecepcionEstados: Campo "Reporte": Seteo especial si es 27201734687.'
GO

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('27201734687'))
BEGIN

	UPDATE RecepcionEstados
	   SET Reporte = 'Eniac.Win.NotaRecepcion_Balanmac.rdlc'
	 WHERE IdEstado = 10

	UPDATE RecepcionEstados
	   SET Reporte = 'Eniac.Win.ComandaSalida_Balanmac.rdlc'
	 WHERE IdEstado = 50

	;
END
