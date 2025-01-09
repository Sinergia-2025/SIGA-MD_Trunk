PRINT ''
PRINT '1. Menu: Eliminar opción de menú Listado de Stock'
IF dbo.ExisteFuncion('InformedeStock') = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Menu: Reasignando permisos del Listado de Stock a Informe de Stock'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT IdRol, 'InformedeStock' FROM RolesFunciones 
	 WHERE IdFuncion = 'ListadoDeStock'
		AND NOT EXISTS 
			 (SELECT * FROM RolesFunciones RF
				WHERE RF.IdFuncion = 'InformedeStock'
				  AND RF.IdRol = RolesFunciones.IdRol);

    PRINT ''
    PRINT '1.2. Menu: Eliminando opción de menu Listado de Stock'
	IF dbo.SoyHAR() = 'False'
	BEGIN
		UPDATE Bitacora SET IdFuncion = 'InformedeStock'
		 WHERE IdFuncion = 'ListadoDeStock';
		delete from RolesFunciones where IdFuncion = 'ListadoDeStock';
		delete from Funciones where Id = 'ListadoDeStock';
	END
END;

PRINT ''
PRINT '2. Parametros: Informe de Stock: Precio de Costo por defecto para Nutrisur'
IF dbo.BaseConCuit('20164865720') = 'True'
BEGIN

    DECLARE @idParametro VARCHAR(MAX) = 'INFDESTOCKMOSTRARPRECIOPREDETERMINADO'
    DECLARE @descripcionParametro VARCHAR(MAX) = 'Informe de stock mostrar precio predeterminado'
    DECLARE @valorParametro VARCHAR(MAX) = 'PrecioDeCosto'

    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

END
