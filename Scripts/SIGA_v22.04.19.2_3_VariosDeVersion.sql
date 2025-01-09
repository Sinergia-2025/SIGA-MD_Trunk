PRINT ''
PRINT '1. Nueva función: ABM de Conceptos CM05'
IF dbo.ExisteFuncion('AFIP') = 1 AND dbo.ExisteFuncion('AFIPConceptosCM05ABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AFIPConceptosCM05ABM', 'ABM de Conceptos CM05', 'ABM de Conceptos CM05', 'True', 'False', 'True', 'True'
        ,'AFIP', 105, 'Eniac.Win', 'AFIPConceptosCM05ABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True');
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AFIPConceptosCM05ABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

--- BUSCADORES.- --------------------------------------------------------------------------------------------------------------------- 
PRINT ''
PRINT '2. Nuevo Buscador: Cuentas Bancos'
BEGIN
	--- Buscador - Tipos de Atributos de Productos.- ---
	DECLARE @id int = (SELECT MAX(IdBuscador) FROM Buscadores) + 1
	INSERT INTO [dbo].[Buscadores]
				([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
			VALUES
				(@id, 'Cuentas de Bancos', 600, 'Grilla', '')
	INSERT INTO [dbo].[BuscadoresCampos]
				([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato],[Condicion],[Valor],[ColorFila])
			VALUES
				(@id, 'IdCuentaBanco'           , 1, 'Código'       , 64,  80, '', NULL, NULL, NULL),
				(@id, 'NombreCuentaBanco'       , 2, 'Descripcion'  , 16, 250, '', NULL, NULL, NULL),
				(@id, 'DescripcionTipoCuenta'   , 3, 'Tipo'         , 16,  60, '', NULL, NULL, NULL),
				(@id, 'EsPosdatado_SN'          , 4, 'Posdatado'    , 32,  50, '', NULL, NULL, NULL),
				(@id, 'PideCheque_SN'           , 5, 'Pide Cheque'  , 32,  50, '', NULL, NULL, NULL),
				(@id, 'DescripcionConceptoCM05' , 6, 'Concepto CM05', 16, 150, '', NULL, NULL, NULL),
				(@id, 'TipoConceptoCM05'        , 7, 'Tipo CM05'    , 32, 100, '', NULL, NULL, NULL)
END
GO

PRINT ''
PRINT '3. Nuevo Buscador: Cuentas Contables.'
BEGIN
	--- Buscador - Tipos de Atributos de Productos.- ---
	DECLARE @id int = (SELECT MAX(IdBuscador) FROM Buscadores) + 1
	INSERT INTO [dbo].[Buscadores]
				([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
			VALUES
				(@id,'Cuentas Contables',400,'Grilla','')
	INSERT INTO [dbo].[BuscadoresCampos]
				([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato],[Condicion],[Valor],[ColorFila])
			VALUES
				(@id, 'IdCuenta', 1, 'Cuenta', 16,  80, '', NULL, NULL, NULL),
				(@id, 'NombreCuenta', 2, 'Descripcion', 16, 250, '', NULL, NULL, NULL)
END

PRINT ''
PRINT '4. Nuevo Buscador: Cuentas de Cajas.'
BEGIN
	--- Buscador - Tipos de Atributos de Productos.- ---
	DECLARE @id1 int = (SELECT MAX(IdBuscador) FROM Buscadores) + 1
	INSERT INTO [dbo].[Buscadores]
				([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
			VALUES
				(@id1,'Cuentas de Cajas',400,'Grilla','')
	INSERT INTO [dbo].[BuscadoresCampos]
				([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato],[Condicion],[Valor],[ColorFila])
			VALUES
				(@id1, 'IdCuentaCaja', 1, 'Cuenta', 16,  80, '', NULL, NULL, NULL),
				(@id1, 'NombreCuentaCaja', 2, 'Descripcion', 16, 250, '', NULL, NULL, NULL),
				(@id1, 'IdTipoCuenta', 3, 'Tipo', 16,  80, '', NULL, NULL, NULL),
				(@id1, 'EsPosdatado', 4, 'Posdatado', 16,  80, '', NULL, NULL, NULL),
				(@id1, 'PideCheque', 4, 'Requiere Cheque', 16,  80, '', NULL, NULL, NULL)
END


PRINT ''
PRINT '5. Nuevo Parametro : Muestra la Leyenda y Fecha de Validez del Presupuesto en Reporte.'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'VENTASIMPRESIONMUESTRAVALIDEZPRESUPUESTO'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Muestra la Leyenda y Fecha de Validez del Presupuesto en Reporte.'
	DECLARE @valorParametro VARCHAR(MAX) = 'False'

	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
