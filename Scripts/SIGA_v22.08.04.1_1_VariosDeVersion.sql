
PRINT ''
PRINT 'X. Tabla TiposCheques:  Creo Tipo TARJETA para utilizar en las Corporativas.'

IF NOT EXISTS(SELECT IdTipoCheque FROM TiposCheques WHERE IdTipoCheque = 'T' )
BEGIN

	INSERT INTO TiposCheques
			   (IdTipoCheque, NombreTipoCheque, SolicitaNroOperacion)
		 VALUES
			   ('T', 'Tarjeta', 'False');

END

PRINT ''
PRINT '6. Buscadores - Rubros, SubRubros y SubSubRubros.'
MERGE INTO Buscadores AS D
        USING (SELECT 30 IdBuscador, 'Rubros'       Titulo, 400 AnchoAyuda UNION ALL
               SELECT 31 IdBuscador, 'SubRubros'    Titulo, 650 AnchoAyuda UNION ALL
               SELECT 32 IdBuscador, 'SubSubRubros' Titulo, 900 AnchoAyuda
               ) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.AnchoAyuda = O.AnchoAyuda
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda, IniciaConFocoEn, ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, 'Grilla',        '')
;
GO

MERGE INTO BuscadoresCampos AS D
        USING (SELECT 30 IdBuscador, 'IdRubro'           IdBuscadorNombreCampo, 1 Orden, 'Código'   Titulo, 64 Alineacion,  70 Ancho UNION ALL
               SELECT 30 IdBuscador, 'NombreRubro'       IdBuscadorNombreCampo, 2 Orden, 'Nombre'   Titulo, 16 Alineacion, 250 Ancho UNION ALL
               
               SELECT 31 IdBuscador, 'NombreRubro'       IdBuscadorNombreCampo, 1 Orden, 'Rubro'    Titulo, 16 Alineacion, 250 Ancho UNION ALL
               SELECT 31 IdBuscador, 'IdSubRubro'        IdBuscadorNombreCampo, 2 Orden, 'Código'   Titulo, 64 Alineacion,  70 Ancho UNION ALL
               SELECT 31 IdBuscador, 'NombreSubRubro'    IdBuscadorNombreCampo, 3 Orden, 'Nombre'   Titulo, 16 Alineacion, 250 Ancho UNION ALL
               
               SELECT 32 IdBuscador, 'NombreRubro'       IdBuscadorNombreCampo, 1 Orden, 'Rubro'    Titulo, 16 Alineacion, 250 Ancho UNION ALL
               SELECT 32 IdBuscador, 'NombreSubRubro'    IdBuscadorNombreCampo, 2 Orden, 'SubRubro' Titulo, 16 Alineacion, 250 Ancho UNION ALL
               SELECT 32 IdBuscador, 'IdSubSubRubro'     IdBuscadorNombreCampo, 3 Orden, 'Código'   Titulo, 64 Alineacion,  70 Ancho UNION ALL
               SELECT 32 IdBuscador, 'NombreSubSubRubro' IdBuscadorNombreCampo, 4 Orden, 'Nombre'   Titulo, 16 Alineacion, 250 Ancho
               ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
    WHEN MATCHED THEN
        UPDATE SET D.Ancho = O.Ancho
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho, Formato, Condicion, Valor, ColorFila)
        VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, '', NULL, NULL, NULL)
;
GO


UPDATE Funciones
   SET Parametros = 'ModoFechas=PORVENCIMIENTO;ReportesCtaCte=CTACTEDET'
 WHERE Id = 'EnvioMasivoDeCompVenc'
UPDATE Funciones
   SET Parametros = 'ReportesCtaCte=CTACTEDET'
 WHERE Id = 'EnvioMasivoDeComprobantes'

PRINT ''
PRINT '1. Nuevo Parametro: Facturacion Utiliza Canje.'
BEGIN
		DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONUTILIZACANJE'
		DECLARE @descripcionParametro VARCHAR(MAX) = 'Define La utilizacion de Canje'
		DECLARE @valorParametro VARCHAR(MAX) = 'False'

		MERGE INTO Parametros AS DEST
				USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
			WHEN MATCHED THEN
				UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
			WHEN NOT MATCHED THEN 
				INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

 DECLARE @maxId INT = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) +1;

INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
           ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
           ,[Activo])
     VALUES
           (@maxId, '1 x Ancho (10 x 10 cm)', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF16.rdlc', 'True'
           ,'', 'False', 1, 'False', 'False'
           ,'True')
GO
IF NOT EXISTS(SELECT * FROM Roles WHERE Id = 'AdmSinergia')
    INSERT INTO [dbo].[Roles] ([Id],[Nombre],[Descripcion])
				       VALUES ('AdmSinergia', 'Administradores Sinergia', 'Administradores Sinergia')
GO

MERGE INTO RolesFunciones AS D
        USING (SELECT Id, 'AdmSinergia' IdRol FROM Funciones WHERE (IdPadre IN ('Seguridad', 'Configuraciones', 'Ayuda') OR     -- Funciones dentro de los padres
                                                                    Id IN ('Seguridad', 'Configuraciones', 'Ayuda') OR          -- Padres
                                                                    Id IN ('InfProductosSinStock', 'InfChequesADepositar',      -- Alertas
                                                                           'Remitos-RemitosSinFacturar', 'InfPuntoDePedidoDeProductos',
                                                                           'InfStockMinimoDeProductos', 'FacturacionV2'  /*Vto. Certificado AFIP*/  ,
                                                                           'InconsistStockVsStockLotes', 'InconsistStockVsMovDeStock',
                                                                           'InconsistCtaCtevsCtaCtePagos', 'InconsCtaCteProvVsCtaCtePagos',
                                                                           'PlanillaDeCaja', 'OrganizarEntregasV2',
                                                                           'Pedidos-PedidosSinFacturar', 'CRMNovedades-PuedeVerAlerta',
                                                                           'CRMNovedades-PuedeVerAlerta', 'AlertaTurnos',
                                                                           'CRMNovedadesABMPROSP', 'InformeChequesPropios',
                                                                           'AlertaCambioCategoriaCliente', 'AlertaPedidosConCantidadItems',
                                                                           'AlertaPedidosSinCantidadItems', 'AlertaClientesConDeuda',
                                                                           'SincronizarOrdenesCompra')
                                                                   )) AS O
            ON D.IdFuncion = O.Id AND D.IdRol = O.IdRol
    WHEN NOT MATCHED THEN
        INSERT (IdFuncion, IdRol) VALUES (O.Id, O.IdRol)
;

MERGE INTO UsuariosRoles AS D
        USING (SELECT 'Admin' IdUsuario, 'AdmSinergia' IdRol, IdSucursal FROM Sucursales) AS O
            ON D.IdUsuario = O.IdUsuario AND D.IdRol = O.IdRol AND D.IdSucursal = O.IdSucursal
    WHEN NOT MATCHED THEN
        INSERT (IdUsuario, IdRol, IdSucursal) VALUES (O.IdUsuario, O.IdRol, O.IdSucursal)
;

DELETE UsuariosRoles WHERE IdUsuario = 'Admin' AND IdRol = 'Adm'
