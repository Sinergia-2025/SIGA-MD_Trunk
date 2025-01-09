IF dbo.ExisteFuncion('CuentasCorrientes') = 1 AND dbo.ExisteFuncion('InformeSitCrediticiaClientes') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InformeSitCrediticiaClientes', 'Informe de Situación Crediticia de Clientes', 'Informe de Situación Crediticia de Clientes', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes', 120, 'Eniac.Win', 'InformeSituacionCrediticiaClientes', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeSitCrediticiaClientes' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteCampo('TiposComprobantes', 'CodigoComprobanteSicore') = 0
BEGIN
     ALTER TABLE dbo.TiposComprobantes ADD CodigoComprobanteSicore int NULL
END
GO

IF dbo.ExisteCampo('TiposComprobantes', 'CodigoComprobanteSicore') = 1
BEGIN

    UPDATE TiposComprobantes SET CodigoComprobanteSicore = 0
    UPDATE TiposComprobantes SET CodigoComprobanteSicore = 1 WHERE IdTipoComprobante LIKE '%FACT%'
    UPDATE TiposComprobantes SET CodigoComprobanteSicore = 2 WHERE IdTipoComprobante LIKE '%RECIB%'
    UPDATE TiposComprobantes SET CodigoComprobanteSicore = 3 WHERE IdTipoComprobante LIKE '%CRED%'
    UPDATE TiposComprobantes SET CodigoComprobanteSicore = 4 WHERE IdTipoComprobante LIKE '%DEB%'
END
GO

IF dbo.ExisteCampo('TiposComprobantes', 'CodigoComprobanteSicore') = 1
BEGIN
    ALTER TABLE dbo.TiposComprobantes ALTER COLUMN CodigoComprobanteSicore int NOT NULL
END
GO