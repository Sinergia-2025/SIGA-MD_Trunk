--- Campos.- ---------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Nuevos Campos Tabla Clientes : Nro de Factura Proveedor - Nro. de Remito Proveedor.'
BEGIN
	ALTER TABLE Clientes ADD IdTipoComprobanteInvocacionMasiva VarChar(15) NULL

	ALTER TABLE Clientes ADD CONSTRAINT FK_TipoComprobante_InvocaMasiva
	FOREIGN KEY (IdTipoComprobanteInvocacionMasiva)
	REFERENCES TiposComprobantes (IdTipoComprobante) 
	ON UPDATE  NO ACTION ON DELETE  NO ACTION

	ALTER TABLE AuditoriaClientes ADD IdTipoComprobanteInvocacionMasiva VarChar(15) NULL
	ALTER TABLE Prospectos ADD IdTipoComprobanteInvocacionMasiva VarChar(15) NULL
	ALTER TABLE AuditoriaProspectos ADD IdTipoComprobanteInvocacionMasiva VarChar(15) NULL

END

GO
--- Menues.- ---------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '2. Nuevo Menu: Comprobantes Invocacion Masiva.'
IF dbo.BaseConCuit('30714757128') = 1 OR dbo.SoyHAR() = 1  
BEGIN
    --- Funcion -Tipo de Atributos de Productos.- -----------------------------------------------------------------------------------
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
		VALUES
			('InvocacionMasivaComprobantes', 'Invocación Masiva de Comprobantes', 'Invocación Masiva de Comprobantes', 'True', 'False', 'True', 'True'
			, 'Ventas', 230, 'Eniac.Win', 'ComprobantesInvocacionMasiva', NULL, NULL
			,'True', 'S', 'N', 'N', 'N', 'True')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'InvocacionMasivaComprobantes' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END
END
--------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '3. Nuevos Campos Tabla Ventas : IdTipoComprobanteInvocacionMasiva.'
BEGIN
	ALTER TABLE Ventas ADD IdTipoComprobanteInvocacionMasiva VarChar(15) NULL

	ALTER TABLE Ventas ADD CONSTRAINT FK_TipoComprobante_InvocacionMasiva
	FOREIGN KEY (IdTipoComprobanteInvocacionMasiva)
	REFERENCES TiposComprobantes (IdTipoComprobante) 
	ON UPDATE  NO ACTION ON DELETE  NO ACTION
END
GO

PRINT ''
PRINT '4. Nuevos Campos Tabla Ventas : NroRepartoInvocacionMasiva.'
BEGIN
	ALTER TABLE Ventas ADD NroRepartoInvocacionMasiva Integer NULL
END
GO

