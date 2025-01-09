
PRINT ''
PRINT '1. Creo Funciones Gestion (Solo SIAP).'
GO
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30710784236'))

BEGIN
	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('Gestión', 'Gestión', '', 
		'True', 'False', 'True', 'True', NULL, 40, NULL, NULL, null, null,
              'True', 'S', 'N', 'N', 'N')
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'Gestión' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('ImportarArchivosExcel', 'Importar Archivos de Excel', 'Importar Archivos de Excel', 
		'True', 'False', 'True', 'True', 'Gestión', 40, 'Eniac.Win', 'ImportarArchivosExcel', null, null,
              'True', 'S', 'N', 'N', 'N')
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarArchivosExcel' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('GestionMutual', 'Gestion de Préstamos Mutual', 'Gestion de Préstamos Mutual', 
		'True', 'True', 'True', 'True', 'Gestión', 41, 'Eniac.Win', 'GestionMutual', null, null,
              'True', 'S', 'N', 'N', 'N')
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'GestionMutual' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('AlertasInforme', 'Informe de Alertas', 'Informe de Alertas', 
		'True', 'True', 'True', 'True', 'Gestión', 42, 'Eniac.Win', 'AlertasInforme', null, null,
              'True', 'S', 'N', 'N', 'N')
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AlertasInforme' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('ContactosInforme', 'Informe de Contactos de Clientes', 'Informe de Contactos de Clientes', 
		'True', 'False', 'True', 'True', 'Gestión', 43, 'Eniac.Win', 'ContactosInforme', null, null,
              'True', 'S', 'N', 'N', 'N')
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ContactosInforme' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;


	INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('CartasABM', 'Cartas', 'Cartas', 
		'True', 'False', 'True', 'True', 'Gestión', 49, 'Eniac.Win', 'CartasABM', null, null,
              'True', 'S', 'N', 'N', 'N')
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CartasABM' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

END;


PRINT ''
PRINT '2. Tabla CRMTiposNovedades: Copio Informacion desde Dominios.'
GO
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30710784236'))

BEGIN

	INSERT [dbo].[CRMTiposNovedades] ([IdTipoNovedad], [NombreTipoNovedad], [UnidadDeMedida], [UsuarioRequerido], [UsuarioPorDefecto], [ProximoContactoRequerido], [PrimerOrdenGrilla], [PrimerOrdenDesc], [SegundoOrdenGrilla], [SegundoOrdenDesc], [VisualizaOtrasNovedades], [VisualizaRevisionAdministrativa], [PermiteBorrarComentarios], [DiasProximoContacto], [PermiteIngresarNumero], [ReportaCantidad], [ReportaAvance]) VALUES (N'ALERTAS', N'Alertas', N'%', 1, 1, 1, N'N__FechaProximoContacto', 0, N'', 0, 1, 0, 1, 1, 0, 0, 1)
	;

	INSERT [dbo].[CRMTiposNovedades] ([IdTipoNovedad], [NombreTipoNovedad], [UnidadDeMedida], [UsuarioRequerido], [UsuarioPorDefecto], [ProximoContactoRequerido], [PrimerOrdenGrilla], [PrimerOrdenDesc], [SegundoOrdenGrilla], [SegundoOrdenDesc], [VisualizaOtrasNovedades], [VisualizaRevisionAdministrativa], [PermiteBorrarComentarios], [DiasProximoContacto], [PermiteIngresarNumero], [ReportaCantidad], [ReportaAvance]) VALUES (N'GESTIONES', N'Gestiones', N'%', 1, 1, 1, N'N__FechaProximoContacto', 0, N'', 0, 1, 0, 1, 1, 0, 0, 1)
	;

	DELETE from CRMCategoriasNovedades
	;

	INSERT INTO [CRMCategoriasNovedades]   ([IdCategoriaNovedad]
			   ,[NombreCategoriaNovedad]
			   ,[Posicion]
			   ,[IdTipoNovedad]
			   ,[PorDefecto]
			   ,[Reporta]
			   ,[Color])
	SELECT  IdTipoNotificacion , SUBSTRING(NombreTipoNotificacion, 1,20), 0, 'GESTIONES', 'False' ,'NO', NULL 
	  FROM Dominios.dbo.TiposNotificaciones
	;



	INSERT INTO [CRMCategoriasNovedades]   ([IdCategoriaNovedad] 
			   ,[NombreCategoriaNovedad]
			   ,[Posicion]
			   ,[IdTipoNovedad]
			   ,[PorDefecto]
			   ,[Reporta]
			   ,[Color])
	SELECT  IdTipoNotificacion + 40
				 , SUBSTRING(NombreTipoNotificacion, 1,20), 0, 'ALERTAS', 'False' ,'NO', NULL 
	FROM Dominios.dbo.TiposNotificaciones
	;

	INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto], [Color], [DiasProximoContacto], [ActualizaUsuarioResponsable]) VALUES (100, N'NUEVO', 10, 1, 0, N'GESTIONES', 1, NULL, NULL, 0)
	;

	INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto], [Color], [DiasProximoContacto], [ActualizaUsuarioResponsable]) VALUES (101, N'NUEVO', 10, 1, 0, N'ALERTAS', 1, NULL, NULL, 0)
	;

	DELETE FROM CRMMediosComunicacionesNovedades
	;

	INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (1, N'Defecto', 0, N'GESTIONES', 0)
	;

	INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (2, N'Defecto', 0, N'ALERTAS', 0)
	;

	INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (100, N'ALTA', 1, N'GESTIONES', 1)
	;
	INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (101, N'ALTA', 1, N'ALERTAS', 1)
	;

END;

PRINT ''
PRINT '3. Creo Tabla Cartas.'
GO
/****** Object:  Table [dbo].[Cartas]    Script Date: 14/1/2019 16:25:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cartas](
	[IdCarta] [int] NOT NULL,
	[NombreCarta] [varchar](50) NULL,
	[Firma] [varchar](50) NULL,
	[DiasDefault] [int] NULL,
	[ProximaCarta] [int] NULL,
	[Texto] [ntext] NULL,
	[Texto2] [ntext] NULL,
	[MiraAnoEnCurso] [bit] NOT NULL,
	[TextoRTF] [ntext] NULL,
	[Texto2RTF] [ntext] NULL,
	[EsHTML] [bit] NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Cartas] PRIMARY KEY CLUSTERED 
(
	[IdCarta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

PRINT ''
PRINT '4. Tabla Tabla: Coloco algunas manualmente (Solo SIAP).'
GO

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30710784236'))

BEGIN

INSERT [dbo].[Cartas] ([IdCarta], [NombreCarta], [Firma], [DiasDefault], [ProximaCarta], [Texto], [Texto2], [MiraAnoEnCurso], [TextoRTF], [Texto2RTF], [EsHTML], [Tipo]) VALUES (80, N'Carta 1', N'Oficina de Cobranzas SIAP', 30, 2, N'						

	  Nos dirigimos a Ud. a los efectos de informales que registra impago el Impuesto  de  Patente Única Sobre Vehículo,   correspondiente al :	', N'Para su comodidad,  le  acompañamos   liquidación   que  Ud. deberá abonar  antes del vencimiento  indicado  en cualquier sucursal del Nuevo Banco de Santa Fe S.A.	
El banco no recepcionará el pago vencida la liquidación.
                                                                        		
Atentamente.-', 0, N'						

	  Nos dirigimos a Ud. a los efectos de informales que registra impago el Impuesto  de  Patente Única Sobre Vehículo,   correspondiente al dominio:	', N'Para su comodidad,  le  acompañamos   liquidación   que  Ud. deberá abonar  antes del vencimiento  indicado  en cualquier sucursal del Nuevo Banco de Santa Fe S.A.	
El banco no recepcionará el pago vencida la liquidación.
                                                                        		
Atentamente.-', 0, N'MUTUAL')

INSERT [dbo].[Cartas] ([IdCarta], [NombreCarta], [Firma], [DiasDefault], [ProximaCarta], [Texto], [Texto2], [MiraAnoEnCurso], [TextoRTF], [Texto2RTF], [EsHTML], [Tipo]) VALUES (82, N'Carta Liq.', N'Oficina de Cobranzas', 30, NULL, N'NOTIFICACION DE DEUDA  - ', N'Estimado:

De acuerdo a lo convenido telefonicamente, enviamos en archivo adjunto Liquidacion  con fecha de vencimiento:

Esta boleta es valida para ser abonada en:

SANTA FE SERVICIOS
RAPI PAGO
PAGO FACIL


TENGA EN CUENTA QUE SOLO PODRA ABONARLA HASTA LA FECHA DE VENCIMIENTO INCLUSIVE, UNA VEZ VENCIDO NINGUNA DE LAS ENTIDADES HABILITADAS LO COBRA O ACTUALIZA.

Una vez efectuado el pago, le agradeceriamos tenga a bien comunicarlo.

Cualquier duda o consulta comuniquese al 0341-4469797 / 4461212 de Lunes a Viernes de 9 a 17 hs.

Saludos cordiales.-

DEPARTAMENTO DE COBRANZAS
SIAP ', 0, N'{\rtf1\ansi\ansicpg1252\deff0\deflang11274{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
\viewkind4\uc1\pard\f0\fs17 NOTIFICACION DE DEUDA  - \par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang11274{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}
\viewkind4\uc1\pard\f0\fs17 Estimado:\par
\par
De acuerdo a lo convenido telefonicamente, enviamos en archivo adjunto Liquidacion  con fecha de vencimiento:\par
\par
Esta boleta es valida para ser abonada en:\par
\par
SANTA FE SERVICIOS\par
RAPI PAGO\par
PAGO FACIL\par
\par
\par
TENGA EN CUENTA QUE SOLO PODRA ABONARLA HASTA LA FECHA DE VENCIMIENTO INCLUSIVE, UNA VEZ VENCIDO NINGUNA DE LAS ENTIDADES HABILITADAS LO COBRA O ACTUALIZA.\par
\par
Una vez efectuado el pago, le agradeceriamos tenga a bien comunicarlo.\par
\par
Cualquier duda o consulta comuniquese al 0341-4469797 / 4461212 de Lunes a Viernes de 9 a 17 hs.\par
\par
Saludos cordiales.-\par
\par
DEPARTAMENTO DE COBRANZAS\par
SIAP \par
}
', 1, N'MUTUAL')
;

INSERT [dbo].[Cartas] ([IdCarta], [NombreCarta], [Firma], [DiasDefault], [ProximaCarta], [Texto], [Texto2], [MiraAnoEnCurso], [TextoRTF], [Texto2RTF], [EsHTML], [Tipo]) VALUES (83, N'Correo Promesa', N'Oficina', 0, NULL, NULL, NULL, 0, NULL, NULL, 0, N'MUTUAL')
;

END;


PRINT ''
PRINT '5. Creo Tabla ClientesDeudas.'
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientesDeudas](
	[IdCliente] [bigint] NOT NULL,
	[nro_prestamo] [bigint] NOT NULL,
	[fecha_corte] [date] NULL,
	[tipo_cobro] [varchar](100) NULL,
	[convenio] [varchar](100) NULL,
	[linea] [varchar](100) NULL,
	[fecha_emision] [date] NULL,
	[cantidad_cuotas] [int] NULL,
	[cuotas_pagas] [int] NULL,
	[cuotas_adeudadas] [int] NULL,
	[capital_total] [decimal](14, 2) NULL,
	[deuda_exigible] [decimal](14, 2) NULL,
	[fecha_ult_cobranza] [date] NULL,
	[dias_mora] [int] NULL,
	[deuda_exigible_con_quita] [decimal](14, 2) NULL,
	[empresa] [varchar](100) NULL,
	[FechaCarta1] [datetime] NULL,
	[FechaCarta2] [datetime] NULL,
	[FechaLiquidacion] [datetime] NULL,
	[ImporteAcordado] [decimal](14, 2) NULL,
	[IdSucursal] [int] NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[Letra] [varchar](1) NULL,
	[CentroEmisor] [int] NULL,
	[NumeroComprobante] [bigint] NULL,
 CONSTRAINT [PK_ClientesDeudas] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[nro_prestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClientesDeudas]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDeudas_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[ClientesDeudas] CHECK CONSTRAINT [FK_ClientesDeudas_Clientes]
GO

PRINT ''
PRINT '5. Migro Seguridad desde Dominios (Solo SIAP).'
GO
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30710784236'))

BEGIN

	INSERT INTO SIGA.dbo.Usuarios 
	SELECT *, 0 FROM Dominios.dbo.Usuarios 
	 WHERE Id <> 'Admin'
	;

	INSERT INTO SIGA.dbo.UsuariosRoles
	SELECT * FROM Dominios.dbo.UsuariosRoles
	 WHERE IdUsuario <> 'Admin'
	;


	INSERT INTO SIGA.dbo.Localidades
	SELECT IdLocalidad, SUBSTRING(NombreLocalidad, 0, 50) as NombreLocalidad, IdProvincia, FechaActualizacionWeb  FROM Dominios.dbo.Localidades L
	 WHERE NOT EXISTS (SELECT * FROM SIGA.dbo.Localidades where idLocalidad = L.IdLocalidad )
	;

	INSERT [dbo].[TiposContactos] ([IdTipoContacto], [NombreTipoContacto], [NombreAbrevTipoContacto]) VALUES (1, N'Fijo', N'F');
	INSERT [dbo].[TiposContactos] ([IdTipoContacto], [NombreTipoContacto], [NombreAbrevTipoContacto]) VALUES (2, N'Celular', N'C');
	INSERT [dbo].[TiposComprobantes] ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], EsReciboClienteVinculado) VALUES (N'MUTUAL', 0, N'Mutual', N'VENTAS', 0, 0, 1, N'X', 100, 1, 1, N'NO', 0, 1, 0, 1, N'Mutual', 0, 1, 0, NULL, 1, 99, NULL, CAST(0.00 AS Decimal(10, 2)), N'.', 0, CAST(0.01 AS Decimal(10, 2)), 0, 1, 1, 0, 1, 1, 2, 0, 0, N'VENTAS', 0, 1, 0, 0, 0, NULL, NULL, NULL, NULL, 0, 0, N'', 0, 1, NULL, 1, 1, 1, 0, 8, 1, 0, 1, 1, 'False');
	INSERT [dbo].[TiposComprobantes] ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], [GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], [ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], [PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], [CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], [IdTipoComprobanteEpson], [UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], [UtilizaImpuestos], [NumeracionAutomatica], [GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], [EsAnticipo], [EsRecibo], [Grupo], [EsPreElectronico], [GeneraContabilidad], [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], [IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal], [CodigoComprobanteSifere], [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], [AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], [InvocarPedidosConEstadoEspecifico], [InvocaCompras], [LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], [ControlaTopeConsumidorFinal], [CargaDescRecGralActual], EsReciboClienteVinculado) VALUES (N'RECIBOMUTUAL', 0, N' Recibo Mutual', N'CTACTECLIE', 0, 0, 0, N'X', 100, 1, -1, NULL, 0, 1, 0, 1, N'ReciboMut', 0, 1, 0, N'''MUTUAL''', 1, 0, N'ANTICIPOPROV', CAST(99999999.00 AS Decimal(10, 2)), N'.', 0, CAST(0.01 AS Decimal(10, 2)), 0, 0, 1, 1, 0, 0, 2, 0, 1, N'CTACTECLIE', 0, 1, 0, 0, 0, NULL, NULL, NULL, NULL, 0, 0, N'', 0, 0, NULL, 1, 1, 1, 0, 8, 1, 0, 1, 0, 'False');
	INSERT [dbo].[Parametros] ([IdParametro], [ValorParametro], [CategoriaParametro], [DescripcionParametro]) VALUES (N'URLTELEPROM', N'http://localhost:9000/MakeCall?p_tel=', NULL, N'URL Teleprom');

END;
