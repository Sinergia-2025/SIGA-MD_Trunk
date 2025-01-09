PRINT ''
PRINT '1. Menu Informe de Listas de Control'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '1.1. Menu Informe de Listas de Control: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('InformeListasControl', 'Informe de Listas de Control por¨Productos', 'Informe de Listas de Control por Productos', 'True', 'False', 'True', 'True'
             ,'Calidad', 90, 'Eniac.Win', 'InformeListasControl', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N');

    PRINT ''
    PRINT '1.2. Menu Informe de Listas de Control: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'InformeListasControl' FROM RolesFunciones WHERE IdFuncion = 'Calidad';

	PRINT ''
    PRINT '1.3. Menu Informe de Listas de Control con Items pendientes: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('InformeListasControlPendientes', 'Informe de Listas de Control con Items pendientes', 'Informe de Listas de Control con Items pendientes', 'True', 'False', 'True', 'True'
             ,'Calidad', 100, 'Eniac.Win', 'InformeListasControlPendientes', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N');

    PRINT ''
    PRINT '1.4. Menu Informe de Listas de Control con Items pendientes: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'InformeListasControlPendientes' FROM RolesFunciones WHERE IdFuncion = 'Calidad';

END;


IF dbo.ExisteFuncion('Ventas') = 'True'
BEGIN

	PRINT ''
	PRINT '2. Menu: Impresion de Tickets Fiscales'

	INSERT INTO [dbo].Funciones
					 (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
					  IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
				 VALUES
					 ('ImpresionTicketFiscal', 'Impresión de Tickets Fiscales', 'Impresión de Tickets Fiscales', 'True', 'False', 'True', 'True'
					 ,'Ventas', 108, 'Eniac.Win', 'ImpresionTicketFiscal', NULL, NULL
					 ,'True', 'S', 'N', 'N', 'N');
	 INSERT INTO RolesFunciones (IdRol,IdFuncion)
			SELECT DISTINCT IdRol, 'ImpresionTicketFiscal' FROM RolesFunciones WHERE IdFuncion IN ('FacturacionV2');

	--Seguridad Para Controlar Info 
	PRINT ''
	PRINT '2.1 Menu: Seguridad Para Controlar Info'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('ImpresionTicketFiscal-CtrlInfo', 'Impresion Ticket Fiscal - CtrlInfo', 'Impresion Ticket Fiscal - CtrlInfo', 
		'False', 'False', 'True', 'True', 'ImpresionTicketFiscal', 10, 'Eniac.Win', 'ImpresionTicketFiscal-CtrlInfo', NULL, NULL
					 ,'True', 'S', 'N', 'N', 'N');

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImpresionTicketFiscal-CtrlInfo' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

	--Seguridad Cambiar Numero de Comprobante al Controlar Info
	PRINT ''
	PRINT '3. Menu: Seguridad Cambiar Numero de Comprobante al Controlar Info'
	INSERT INTO [dbo].Funciones
					 (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
					  IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
				 VALUES
					 ('ImpresionTicketFiscal-IngPapel', 'IngPapel: Impresión de Tickets Fiscales', 'IngPapel: Impresión de Tickets Fiscales', 'False', 'False', 'True', 'True'
					 ,'ImpresionTicketFiscal', 999, '', '', NULL, NULL
					 ,'True', 'S', 'N', 'N', 'N');
 
	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImpresionTicketFiscal-IngPapel' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor');

END;


--UPDATE TiposComprobantes SET UsaFacturacion = 'False' , UsaFacturacionRapida = 'False' where EsFiscal = 'True'
--GO
PRINT ''
PRINT '4. Tipo de Comprobantes: Comprobantes PRE-FISCALES'
INSERT INTO [dbo].[TiposComprobantes]
           ([IdTipoComprobante],[EsFiscal],[Descripcion],[Tipo],[CoeficienteStock]
           ,[GrabaLibro],[EsFacturable],[LetrasHabilitadas],[CantidadMaximaItems],[Imprime]
           ,[CoeficienteValores],[ModificaAlFacturar],[EsFacturador],[AfectaCaja],[CargaPrecioActual]
           ,[ActualizaCtaCte],[DescripcionAbrev],[PuedeSerBorrado],[CantidadCopias],[EsRemitoTransportista]
           ,[ComprobantesAsociados],[EsComercial],[CantidadMaximaItemsObserv],[IdTipoComprobanteSecundario],[ImporteTope]
           ,[IdTipoComprobanteEpson],[UsaFacturacionRapida],[ImporteMinimo],[EsElectronico],[UsaFacturacion]
           ,[UtilizaImpuestos],[NumeracionAutomatica],[GeneraObservConInvocados],[ImportaObservDeInvocados],[IdPlanCuenta]
           ,[EsAnticipo],[EsRecibo],[Grupo],[EsPreElectronico],[GeneraContabilidad]
           ,[UtilizaCtaSecundariaProd],[UtilizaCtaSecundariaCateg],[IncluirEnExpensas],[IdTipoComprobanteNCred],[IdTipoComprobanteNDeb]
           ,[IdProductoNCred],[IdProductoNDeb],[ConsumePedidos],[EsPreFiscal],[CodigoComprobanteSifere],[EsDespachoImportacion]
           ,[CargaDescRecActual],[IdTipoComprobanteContraMovInvocar],[AlInvocarPedidoAfectaFactura],[AlInvocarPedidoAfectaRemito],[InvocarPedidosConEstadoEspecifico]
           ,[InvocaCompras],[LargoMaximoNumero],[NivelAutorizacion],[RequiereReferenciaCtaCte],[ControlaTopeConsumidorFinal]
           ,[CargaDescRecGralActual],[EsReciboClienteVinculado],AFIPWSIncluyeFechaVencimiento,AFIPWSEsFEC)
SELECT substring('PRE-' + RTRIM(LTRIM([IdTipoComprobante])),1,15) ,[EsFiscal] ,substring('Pre ' + RTRIM(LTRIM([Descripcion])),1,25)  ,[Tipo] ,0
      ,'False',[EsFacturable],[LetrasHabilitadas],[CantidadMaximaItems],[Imprime]
      ,[CoeficienteValores],[ModificaAlFacturar],[EsFacturador],'False',[CargaPrecioActual]
      ,[ActualizaCtaCte],substring('Pre ' + RTRIM(LTRIM([DescripcionAbrev])),1,10) ,'True',[CantidadCopias],[EsRemitoTransportista]
      ,[ComprobantesAsociados],'False',[CantidadMaximaItemsObserv],[IdTipoComprobante],[ImporteTope]
      ,[IdTipoComprobanteEpson],'True',[ImporteMinimo],[EsElectronico],'True'
      ,[UtilizaImpuestos],[NumeracionAutomatica],[GeneraObservConInvocados],[ImportaObservDeInvocados],[IdPlanCuenta]
      ,[EsAnticipo],[EsRecibo],[Grupo],'True','False'
      ,[UtilizaCtaSecundariaProd],[UtilizaCtaSecundariaCateg],[IncluirEnExpensas],[IdTipoComprobanteNCred],[IdTipoComprobanteNDeb]
      ,[IdProductoNCred],[IdProductoNDeb],'False',[EsPreFiscal],[CodigoComprobanteSifere]
      ,[EsDespachoImportacion],[CargaDescRecActual],[IdTipoComprobanteContraMovInvocar],[AlInvocarPedidoAfectaFactura],[AlInvocarPedidoAfectaRemito]
      ,[InvocarPedidosConEstadoEspecifico],[InvocaCompras],[LargoMaximoNumero],[NivelAutorizacion],[RequiereReferenciaCtaCte]
      ,[ControlaTopeConsumidorFinal],[CargaDescRecGralActual],[EsReciboClienteVinculado],AFIPWSIncluyeFechaVencimiento
      ,AFIPWSEsFEC
  FROM [dbo].[TiposComprobantes]
 WHERE EsFiscal = 'True'
GO

