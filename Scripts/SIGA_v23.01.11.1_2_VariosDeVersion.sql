PRINT ''
PRINT '1. Tabla FormatoEtiquetas: Agrega formato 3 x Ancho (Bonificaciones)'
BEGIN
	DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;

	INSERT INTO [dbo].[FormatosEtiquetas]
			   ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
			   ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
			   ,[Activo])
		 VALUES
			   (@maxId, '3 x Ancho (Bonificaciones) ', 'PRECIOS', 'Eniac.Win.EmisionDeEtiquetasDePreciosF9.rdlc', 'True'
			   ,'', 'False', 3, 'False', 'False','True');
END
GO

PRINT ''
PRINT '2. Nuevo parámetro: Cantidad de dias de Control de Licencias.'
BEGIN
	MERGE INTO Parametros AS DEST
	USING (
			SELECT IdEmpresa, 
				'DIASCONTROLDELICENCIAS' AS IdParametro, 
				'0' ValorParametro, 
				'EmpresaND' CategoriaParametro, 
				'Cantidad de dias de Control de Licencias' DescripcionParametro FROM Empresas) AS ORIG 
			ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
	WHEN MATCHED THEN
		UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
	WHEN NOT MATCHED THEN 
		INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
		VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO

IF dbo.SoyHAR() = 1 
    UPDATE Parametros 
	   SET ValorParametro = 60
	 WHERE IdParametro = 'DIASCONTROLDELICENCIAS';

PRINT ''
PRINT '3. Nueva Alerta: Licencias Vs Dispositivos (Clientes).'
IF dbo.SoyHAR() = 1 AND dbo.ExisteFuncion('AlertaLicenciasVsDispositivos') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias, Plus, Express, Basica, PV, EsMDIChild)
    VALUES
        ('AlertaLicenciasVsDispositivos', 'Alerta de Licencias VS Dispositivos', 'Alerta de Licencias VS Dispositivos', 'False', 'False', 'True', 'False'
        ,'Seguridad', 200, 'Eniac.Win', 'AlertaLicenciasVsDispositivos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'AlertaLicenciasVsDispositivos' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Oficina')
END
GO
