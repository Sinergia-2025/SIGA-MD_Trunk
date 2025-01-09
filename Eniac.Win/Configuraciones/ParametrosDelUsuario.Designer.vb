<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ParametrosDelUsuario
   Inherits BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ParametrosDelUsuario))
      Me.ofdArchivos = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.ofdEjecutableTareaProgramada = New System.Windows.Forms.OpenFileDialog()
        Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tbcParametros = New System.Windows.Forms.TabControl()
        Me.tbpDatosEmpresa = New System.Windows.Forms.TabPage()
        Me.UcConfDatosEmpresa1 = New Eniac.Win.ucConfDatosEmpresa()
        Me.tbpFichas = New System.Windows.Forms.TabPage()
        Me.UcConfFichas1 = New Eniac.Win.ucConfFichas()
        Me.tbpPedidos = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tbpPedidosGeneral = New System.Windows.Forms.TabPage()
        Me.UcConfPedidosPedidos1 = New Eniac.Win.ucConfPedidosPedidos()
        Me.tbpPedidosWeb = New System.Windows.Forms.TabPage()
        Me.UcConfPedidosWeb1 = New Eniac.Win.ucConfPedidosWeb()
        Me.lnkSimovilURLBase_04 = New System.Windows.Forms.LinkLabel()
        Me.tbpPedidosVisualizacion = New System.Windows.Forms.TabPage()
        Me.UcConfPedidosVisualizacion1 = New Eniac.Win.ucConfPedidosVisualizacion()
        Me.tbpPedidosProveedor = New System.Windows.Forms.TabPage()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.tpPedidosProv = New System.Windows.Forms.TabPage()
        Me.UcConfPedidosProvPedidosProv1 = New Eniac.Win.ucConfPedidosProvPedidosProv()
        Me.tpPedidosProvVisualizacion = New System.Windows.Forms.TabPage()
        Me.UcConfPedidosProvVisualizacion1 = New Eniac.Win.ucConfPedidosProvVisualizacion()
        Me.tpPedidosProvRequerimiento = New System.Windows.Forms.TabPage()
        Me.UcConfPedidosProvRequerimiento1 = New Eniac.Win.ucConfPedidosProvRequerimiento()
        Me.tbpVentas = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.UcConfVentas11 = New Eniac.Win.ucConfVentas1()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.UcConfVentas21 = New Eniac.Win.ucConfVentas2()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.UcConfVentas31 = New Eniac.Win.ucConfVentas3()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.UcConfVentas41 = New Eniac.Win.ucConfVentas4()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.UcConfVentasCajero1 = New Eniac.Win.ucConfVentasCajero()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.UcConfVentasFacturacionRapida1 = New Eniac.Win.ucConfVentasFacturacionRapida()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.UcConfVentasVisualizacion1 = New Eniac.Win.ucConfVentasVisualizacion()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.UcConfVentasImpresion1 = New Eniac.Win.ucConfVentasImpresion()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.UcConfVentasExportacion1 = New Eniac.Win.ucConfVentasExportacion()
        Me.tbpFactElectronica = New System.Windows.Forms.TabPage()
        Me.UcConfFacturacionElectronica1 = New Eniac.Win.ucConfFacturacionElectronica()
        Me.tbpCompras = New System.Windows.Forms.TabPage()
        Me.UcConfCompras1 = New Eniac.Win.ucConfCompras()
        Me.tbpStock = New System.Windows.Forms.TabPage()
        Me.UcConfStock1 = New Eniac.Win.ucConfStock()
        Me.tbpPrecios = New System.Windows.Forms.TabPage()
        Me.tbcPrecios = New System.Windows.Forms.TabControl()
        Me.tbpPrecios1 = New System.Windows.Forms.TabPage()
        Me.UcConfPrecios1 = New Eniac.Win.ucConfPrecios()
        Me.tbpPrecios2 = New System.Windows.Forms.TabPage()
        Me.UcConfPrecios21 = New Eniac.Win.ucConfPrecios2()
        Me.tbpCtaCteClientes = New System.Windows.Forms.TabPage()
        Me.tbcCtaCteClientes = New System.Windows.Forms.TabControl()
        Me.tbpCtaCteClientes_General = New System.Windows.Forms.TabPage()
        Me.UcConfCtaCteClienteGeneral1 = New Eniac.Win.ucConfCtaCteClienteGeneral()
        Me.tbpCtaCteClientes_General2 = New System.Windows.Forms.TabPage()
        Me.UcConfCtaCteClienteGeneral21 = New Eniac.Win.ucConfCtaCteClienteGeneral2()
        Me.tbpCtaCteClientes_DebitoAutomatico = New System.Windows.Forms.TabPage()
        Me.UcConfCtaCteClienteDebitoAutomatico1 = New Eniac.Win.ucConfCtaCteClienteDebitoAutomatico()
        Me.tbpCtaCteClientes_Informes = New System.Windows.Forms.TabPage()
        Me.UcConfCtaCteClienteInformes1 = New Eniac.Win.ucConfCtaCteClienteInformes()
        Me.tbpArchivos = New System.Windows.Forms.TabPage()
        Me.tbcArchivos = New System.Windows.Forms.TabControl()
        Me.tbpArchivosGeneral = New System.Windows.Forms.TabPage()
        Me.UcConfArchivos1 = New Eniac.Win.ucConfArchivos()
        Me.tbpArchivosClientes = New System.Windows.Forms.TabPage()
        Me.UcConfArchivosClientes1 = New Eniac.Win.ucConfArchivosClientes()
        Me.tbpArchivosProductos = New System.Windows.Forms.TabPage()
        Me.UcConfArchivosProductos1 = New Eniac.Win.ucConfArchivosProductos()
        Me.tbpArchivosWeb = New System.Windows.Forms.TabPage()
        Me.UcConfArchivosWeb1 = New Eniac.Win.ucConfArchivosWeb()
        Me.tbpArchivosSync = New System.Windows.Forms.TabPage()
        Me.UcConfArchivosSync1 = New Eniac.Win.ucConfArchivosSync()
        Me.tbpCtaCteProveedores = New System.Windows.Forms.TabPage()
        Me.UcConfCtaCteProv1 = New Eniac.Win.ucConfCtaCteProv()
        Me.tbpCaja = New System.Windows.Forms.TabPage()
        Me.UcConfCaja1 = New Eniac.Win.ucConfCaja()
        Me.tbpBanco = New System.Windows.Forms.TabPage()
        Me.UcConfBanco1 = New Eniac.Win.ucConfBanco()
        Me.tbpProcesos = New System.Windows.Forms.TabPage()
        Me.UcConfProcesos1 = New Eniac.Win.ucConfProcesos()
        Me.tbpSueldos = New System.Windows.Forms.TabPage()
        Me.UcConfSueldos1 = New Eniac.Win.ucConfSueldos()
        Me.tbpRMA = New System.Windows.Forms.TabPage()
        Me.UcConfRMA1 = New Eniac.Win.ucConfRMA()
        Me.tbpProduccion = New System.Windows.Forms.TabPage()
        Me.UcConfProduccion1 = New Eniac.Win.ucConfProduccion()
        Me.tbpContabilidad = New System.Windows.Forms.TabPage()
        Me.UcConfContabilidad1 = New Eniac.Win.ucConfContabilidad()
        Me.tbpCargos = New System.Windows.Forms.TabPage()
        Me.UcConfCargos1 = New Eniac.Win.ucConfCargos()
        Me.tbpCRM = New System.Windows.Forms.TabPage()
        Me.tbcCRM = New System.Windows.Forms.TabControl()
        Me.tbpCRMGenerales = New System.Windows.Forms.TabPage()
        Me.UcConfCRMGenerales1 = New Eniac.Win.ucConfCRMGenerales()
        Me.tbpCRMCorreos = New System.Windows.Forms.TabPage()
        Me.UcConfCRMEnvioCorreo1 = New Eniac.Win.ucConfCRMEnvioCorreo()
        Me.tbpAFIP = New System.Windows.Forms.TabPage()
        Me.UcConfAFIP1 = New Eniac.Win.ucConfAFIP()
        Me.tbpTurnos = New System.Windows.Forms.TabPage()
        Me.UcConfTurnos1 = New Eniac.Win.ucConfTurnos()
        Me.tbpEstadisticas = New System.Windows.Forms.TabPage()
        Me.UcConfEstadisticas1 = New Eniac.Win.ucConfEstadisticas()
        Me.tbpAplicacionesMoviles = New System.Windows.Forms.TabPage()
        Me.tbcAplicacionesMoviles = New System.Windows.Forms.TabControl()
        Me.tbpAplicacionesMoviles_CobranzasPedidos = New System.Windows.Forms.TabPage()
        Me.UcConfAppMovilesConfiguraciones1 = New Eniac.Win.ucConfAppMovilesConfiguraciones()
        Me.lnkSimovilURLBase_01 = New System.Windows.Forms.LinkLabel()
        Me.tbpAplicacionesMoviles_Urls = New System.Windows.Forms.TabPage()
        Me.UcConfAppMovilesURLsBase1 = New Eniac.Win.ucConfAppMovilesURLsBase()
        Me.tbpAplicacionesMoviles_Soporte = New System.Windows.Forms.TabPage()
        Me.UcConfAppMovilesSoporte1 = New Eniac.Win.ucConfAppMovilesSoporte()
        Me.lnkSimovilURLBase_02 = New System.Windows.Forms.LinkLabel()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.UcConfAppMovilesFTP1 = New Eniac.Win.ucConfAppMovilesFTP()
        Me.tbpLogistica = New System.Windows.Forms.TabPage()
        Me.UcConfLogistica1 = New Eniac.Win.ucConfLogistica()
        Me.tbpCalidad = New System.Windows.Forms.TabPage()
        Me.UcConfCalidad1 = New Eniac.Win.ucConfCalidad()
        Me.tbpTurismo = New System.Windows.Forms.TabPage()
        Me.UcConfTurismo1 = New Eniac.Win.ucConfTurismo()
        Me.lnkSimovilURLBase_03 = New System.Windows.Forms.LinkLabel()
        Me.tpTiendaWeb = New System.Windows.Forms.TabPage()
        Me.TblTiendasWeb = New System.Windows.Forms.TabControl()
        Me.tbpTiendaNube = New System.Windows.Forms.TabPage()
        Me.UcConfTiendaNube1 = New Eniac.Win.ucConfTiendaNube()
        Me.tbpMercadoLibre = New System.Windows.Forms.TabPage()
        Me.UcConfMercadoLibre1 = New Eniac.Win.ucConfMercadoLibre()
        Me.tbpArborea = New System.Windows.Forms.TabPage()
        Me.UcConfArborea1 = New Eniac.Win.ucConfArborea()
        Me.tbpGenerales = New System.Windows.Forms.TabPage()
        Me.UcConfGenerales1 = New Eniac.Win.ucConfGenerales()
        Me.tbpMRP = New System.Windows.Forms.TabPage()
        Me.UcConfMRP1 = New Eniac.Win.ucConfMRP()
        Me.lnkRoelaSirPlus = New System.Windows.Forms.LinkLabel()
        Me.tspFacturacion.SuspendLayout()
        Me.tbcParametros.SuspendLayout()
        Me.tbpDatosEmpresa.SuspendLayout()
        Me.tbpFichas.SuspendLayout()
        Me.tbpPedidos.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tbpPedidosGeneral.SuspendLayout()
        Me.tbpPedidosWeb.SuspendLayout()
        Me.tbpPedidosVisualizacion.SuspendLayout()
        Me.tbpPedidosProveedor.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.tpPedidosProv.SuspendLayout()
        Me.tpPedidosProvVisualizacion.SuspendLayout()
        Me.tpPedidosProvRequerimiento.SuspendLayout()
        Me.tbpVentas.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.tbpFactElectronica.SuspendLayout()
        Me.tbpCompras.SuspendLayout()
        Me.tbpStock.SuspendLayout()
        Me.tbpPrecios.SuspendLayout()
        Me.tbcPrecios.SuspendLayout()
        Me.tbpPrecios1.SuspendLayout()
        Me.tbpPrecios2.SuspendLayout()
        Me.tbpCtaCteClientes.SuspendLayout()
        Me.tbcCtaCteClientes.SuspendLayout()
        Me.tbpCtaCteClientes_General.SuspendLayout()
        Me.tbpCtaCteClientes_General2.SuspendLayout()
        Me.tbpCtaCteClientes_DebitoAutomatico.SuspendLayout()
        Me.tbpCtaCteClientes_Informes.SuspendLayout()
        Me.tbpArchivos.SuspendLayout()
        Me.tbcArchivos.SuspendLayout()
        Me.tbpArchivosGeneral.SuspendLayout()
        Me.tbpArchivosClientes.SuspendLayout()
        Me.tbpArchivosProductos.SuspendLayout()
        Me.tbpArchivosWeb.SuspendLayout()
        Me.tbpArchivosSync.SuspendLayout()
        Me.tbpCtaCteProveedores.SuspendLayout()
        Me.tbpCaja.SuspendLayout()
        Me.tbpBanco.SuspendLayout()
        Me.tbpProcesos.SuspendLayout()
        Me.tbpSueldos.SuspendLayout()
        Me.tbpRMA.SuspendLayout()
        Me.tbpProduccion.SuspendLayout()
        Me.tbpContabilidad.SuspendLayout()
        Me.tbpCargos.SuspendLayout()
        Me.tbpCRM.SuspendLayout()
        Me.tbcCRM.SuspendLayout()
        Me.tbpCRMGenerales.SuspendLayout()
        Me.tbpCRMCorreos.SuspendLayout()
        Me.tbpAFIP.SuspendLayout()
        Me.tbpTurnos.SuspendLayout()
        Me.tbpEstadisticas.SuspendLayout()
        Me.tbpAplicacionesMoviles.SuspendLayout()
        Me.tbcAplicacionesMoviles.SuspendLayout()
        Me.tbpAplicacionesMoviles_CobranzasPedidos.SuspendLayout()
        Me.tbpAplicacionesMoviles_Urls.SuspendLayout()
        Me.tbpAplicacionesMoviles_Soporte.SuspendLayout()
        Me.TabPage10.SuspendLayout()
        Me.tbpLogistica.SuspendLayout()
        Me.tbpCalidad.SuspendLayout()
        Me.tbpTurismo.SuspendLayout()
        Me.tpTiendaWeb.SuspendLayout()
        Me.TblTiendasWeb.SuspendLayout()
        Me.tbpTiendaNube.SuspendLayout()
        Me.tbpMercadoLibre.SuspendLayout()
        Me.tbpArborea.SuspendLayout()
        Me.tbpGenerales.SuspendLayout()
        Me.tbpMRP.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofdArchivos
        '
        Me.ofdArchivos.Filter = "jpg files|*.jpg"
        '
        'ofdEjecutableTareaProgramada
        '
        Me.ofdEjecutableTareaProgramada.Filter = "Ejecutables Sinergia|Eniac*.exe"
        Me.ofdEjecutableTareaProgramada.InitialDirectory = "c:\Eniac"
        '
        'tspFacturacion
        '
        Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
        Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
        Me.tspFacturacion.Name = "tspFacturacion"
        Me.tspFacturacion.Size = New System.Drawing.Size(939, 25)
        Me.tspFacturacion.TabIndex = 1
        Me.tspFacturacion.Text = "ToolStrip1"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(85, 22)
        Me.tsbGrabar.Text = "&Grabar (F4)"
        Me.tsbGrabar.ToolTipText = "Imprimir y Grabar (F4)"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'tbcParametros
        '
        Me.tbcParametros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcParametros.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcParametros.Controls.Add(Me.tbpDatosEmpresa)
        Me.tbcParametros.Controls.Add(Me.tbpFichas)
        Me.tbcParametros.Controls.Add(Me.tbpPedidos)
        Me.tbcParametros.Controls.Add(Me.tbpPedidosProveedor)
        Me.tbcParametros.Controls.Add(Me.tbpVentas)
        Me.tbcParametros.Controls.Add(Me.tbpFactElectronica)
        Me.tbcParametros.Controls.Add(Me.tbpCompras)
        Me.tbcParametros.Controls.Add(Me.tbpStock)
        Me.tbcParametros.Controls.Add(Me.tbpPrecios)
        Me.tbcParametros.Controls.Add(Me.tbpCtaCteClientes)
        Me.tbcParametros.Controls.Add(Me.tbpArchivos)
        Me.tbcParametros.Controls.Add(Me.tbpCtaCteProveedores)
        Me.tbcParametros.Controls.Add(Me.tbpCaja)
        Me.tbcParametros.Controls.Add(Me.tbpBanco)
        Me.tbcParametros.Controls.Add(Me.tbpProcesos)
        Me.tbcParametros.Controls.Add(Me.tbpSueldos)
        Me.tbcParametros.Controls.Add(Me.tbpRMA)
        Me.tbcParametros.Controls.Add(Me.tbpProduccion)
        Me.tbcParametros.Controls.Add(Me.tbpContabilidad)
        Me.tbcParametros.Controls.Add(Me.tbpCargos)
        Me.tbcParametros.Controls.Add(Me.tbpCRM)
        Me.tbcParametros.Controls.Add(Me.tbpAFIP)
        Me.tbcParametros.Controls.Add(Me.tbpTurnos)
        Me.tbcParametros.Controls.Add(Me.tbpEstadisticas)
        Me.tbcParametros.Controls.Add(Me.tbpAplicacionesMoviles)
        Me.tbcParametros.Controls.Add(Me.tbpLogistica)
        Me.tbcParametros.Controls.Add(Me.tbpCalidad)
        Me.tbcParametros.Controls.Add(Me.tbpTurismo)
        Me.tbcParametros.Controls.Add(Me.tpTiendaWeb)
        Me.tbcParametros.Controls.Add(Me.tbpGenerales)
        Me.tbcParametros.Controls.Add(Me.tbpMRP)
        Me.tbcParametros.HotTrack = True
        Me.tbcParametros.ItemSize = New System.Drawing.Size(93, 21)
        Me.tbcParametros.Location = New System.Drawing.Point(0, 28)
        Me.tbcParametros.Multiline = True
        Me.tbcParametros.Name = "tbcParametros"
        Me.tbcParametros.SelectedIndex = 0
        Me.tbcParametros.Size = New System.Drawing.Size(939, 519)
        Me.tbcParametros.TabIndex = 1
        '
        'tbpDatosEmpresa
        '
        Me.tbpDatosEmpresa.Controls.Add(Me.UcConfDatosEmpresa1)
        Me.tbpDatosEmpresa.Location = New System.Drawing.Point(4, 73)
        Me.tbpDatosEmpresa.Name = "tbpDatosEmpresa"
        Me.tbpDatosEmpresa.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDatosEmpresa.Size = New System.Drawing.Size(931, 442)
        Me.tbpDatosEmpresa.TabIndex = 0
        Me.tbpDatosEmpresa.Text = "Datos Empresa"
        Me.tbpDatosEmpresa.UseVisualStyleBackColor = True
        '
        'UcConfDatosEmpresa1
        '
        Me.UcConfDatosEmpresa1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfDatosEmpresa1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfDatosEmpresa1.Name = "UcConfDatosEmpresa1"
        Me.UcConfDatosEmpresa1.Size = New System.Drawing.Size(925, 436)
        Me.UcConfDatosEmpresa1.TabIndex = 0
        '
        'tbpFichas
        '
        Me.tbpFichas.Controls.Add(Me.UcConfFichas1)
        Me.tbpFichas.Location = New System.Drawing.Point(4, 73)
        Me.tbpFichas.Name = "tbpFichas"
        Me.tbpFichas.Size = New System.Drawing.Size(931, 442)
        Me.tbpFichas.TabIndex = 23
        Me.tbpFichas.Text = "Fichas"
        Me.tbpFichas.UseVisualStyleBackColor = True
        '
        'UcConfFichas1
        '
        Me.UcConfFichas1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfFichas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfFichas1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfFichas1.Name = "UcConfFichas1"
        Me.UcConfFichas1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfFichas1.TabIndex = 0
        '
        'tbpPedidos
        '
        Me.tbpPedidos.Controls.Add(Me.TabControl2)
        Me.tbpPedidos.Location = New System.Drawing.Point(4, 73)
        Me.tbpPedidos.Name = "tbpPedidos"
        Me.tbpPedidos.Size = New System.Drawing.Size(931, 442)
        Me.tbpPedidos.TabIndex = 14
        Me.tbpPedidos.Text = "Pedidos"
        Me.tbpPedidos.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tbpPedidosGeneral)
        Me.TabControl2.Controls.Add(Me.tbpPedidosWeb)
        Me.TabControl2.Controls.Add(Me.tbpPedidosVisualizacion)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(931, 442)
        Me.TabControl2.TabIndex = 0
        '
        'tbpPedidosGeneral
        '
        Me.tbpPedidosGeneral.BackColor = System.Drawing.SystemColors.Control
        Me.tbpPedidosGeneral.Controls.Add(Me.UcConfPedidosPedidos1)
        Me.tbpPedidosGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tbpPedidosGeneral.Name = "tbpPedidosGeneral"
        Me.tbpPedidosGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPedidosGeneral.Size = New System.Drawing.Size(923, 416)
        Me.tbpPedidosGeneral.TabIndex = 0
        Me.tbpPedidosGeneral.Text = "Pedidos"
        '
        'UcConfPedidosPedidos1
        '
        Me.UcConfPedidosPedidos1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfPedidosPedidos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfPedidosPedidos1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfPedidosPedidos1.Name = "UcConfPedidosPedidos1"
        Me.UcConfPedidosPedidos1.Size = New System.Drawing.Size(917, 410)
        Me.UcConfPedidosPedidos1.TabIndex = 0
        '
        'tbpPedidosWeb
        '
        Me.tbpPedidosWeb.BackColor = System.Drawing.SystemColors.Control
        Me.tbpPedidosWeb.Controls.Add(Me.UcConfPedidosWeb1)
        Me.tbpPedidosWeb.Controls.Add(Me.lnkSimovilURLBase_04)
        Me.tbpPedidosWeb.Location = New System.Drawing.Point(4, 22)
        Me.tbpPedidosWeb.Name = "tbpPedidosWeb"
        Me.tbpPedidosWeb.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPedidosWeb.Size = New System.Drawing.Size(184, 45)
        Me.tbpPedidosWeb.TabIndex = 1
        Me.tbpPedidosWeb.Text = "Web"
        '
        'UcConfPedidosWeb1
        '
        Me.UcConfPedidosWeb1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfPedidosWeb1.Dock = System.Windows.Forms.DockStyle.Left
        Me.UcConfPedidosWeb1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfPedidosWeb1.Name = "UcConfPedidosWeb1"
        Me.UcConfPedidosWeb1.Size = New System.Drawing.Size(496, 39)
        Me.UcConfPedidosWeb1.TabIndex = 22
        '
        'lnkSimovilURLBase_04
        '
        Me.lnkSimovilURLBase_04.AutoSize = True
        Me.lnkSimovilURLBase_04.Location = New System.Drawing.Point(541, 41)
        Me.lnkSimovilURLBase_04.Name = "lnkSimovilURLBase_04"
        Me.lnkSimovilURLBase_04.Size = New System.Drawing.Size(344, 13)
        Me.lnkSimovilURLBase_04.TabIndex = 21
        Me.lnkSimovilURLBase_04.TabStop = True
        Me.lnkSimovilURLBase_04.Text = "La URL Base se movió a la solapa URLs Base de Aplicaciones Móviles"
        '
        'tbpPedidosVisualizacion
        '
        Me.tbpPedidosVisualizacion.BackColor = System.Drawing.SystemColors.Control
        Me.tbpPedidosVisualizacion.Controls.Add(Me.UcConfPedidosVisualizacion1)
        Me.tbpPedidosVisualizacion.Location = New System.Drawing.Point(4, 22)
        Me.tbpPedidosVisualizacion.Name = "tbpPedidosVisualizacion"
        Me.tbpPedidosVisualizacion.Size = New System.Drawing.Size(184, 45)
        Me.tbpPedidosVisualizacion.TabIndex = 2
        Me.tbpPedidosVisualizacion.Text = "Visualizacion"
        '
        'UcConfPedidosVisualizacion1
        '
        Me.UcConfPedidosVisualizacion1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfPedidosVisualizacion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfPedidosVisualizacion1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfPedidosVisualizacion1.Name = "UcConfPedidosVisualizacion1"
        Me.UcConfPedidosVisualizacion1.Size = New System.Drawing.Size(184, 45)
        Me.UcConfPedidosVisualizacion1.TabIndex = 0
        '
        'tbpPedidosProveedor
        '
        Me.tbpPedidosProveedor.Controls.Add(Me.TabControl3)
        Me.tbpPedidosProveedor.Location = New System.Drawing.Point(4, 73)
        Me.tbpPedidosProveedor.Name = "tbpPedidosProveedor"
        Me.tbpPedidosProveedor.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPedidosProveedor.Size = New System.Drawing.Size(931, 442)
        Me.tbpPedidosProveedor.TabIndex = 15
        Me.tbpPedidosProveedor.Text = "Pedidos Prov."
        Me.tbpPedidosProveedor.UseVisualStyleBackColor = True
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.tpPedidosProv)
        Me.TabControl3.Controls.Add(Me.tpPedidosProvVisualizacion)
        Me.TabControl3.Controls.Add(Me.tpPedidosProvRequerimiento)
        Me.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl3.Location = New System.Drawing.Point(3, 3)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(925, 436)
        Me.TabControl3.TabIndex = 8
        '
        'tpPedidosProv
        '
        Me.tpPedidosProv.BackColor = System.Drawing.SystemColors.Control
        Me.tpPedidosProv.Controls.Add(Me.UcConfPedidosProvPedidosProv1)
        Me.tpPedidosProv.Location = New System.Drawing.Point(4, 22)
        Me.tpPedidosProv.Name = "tpPedidosProv"
        Me.tpPedidosProv.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPedidosProv.Size = New System.Drawing.Size(917, 410)
        Me.tpPedidosProv.TabIndex = 0
        Me.tpPedidosProv.Text = "Pedidos Prov."
        '
        'UcConfPedidosProvPedidosProv1
        '
        Me.UcConfPedidosProvPedidosProv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfPedidosProvPedidosProv1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfPedidosProvPedidosProv1.Name = "UcConfPedidosProvPedidosProv1"
        Me.UcConfPedidosProvPedidosProv1.Size = New System.Drawing.Size(911, 404)
        Me.UcConfPedidosProvPedidosProv1.TabIndex = 0
        '
        'tpPedidosProvVisualizacion
        '
        Me.tpPedidosProvVisualizacion.BackColor = System.Drawing.SystemColors.Control
        Me.tpPedidosProvVisualizacion.Controls.Add(Me.UcConfPedidosProvVisualizacion1)
        Me.tpPedidosProvVisualizacion.Location = New System.Drawing.Point(4, 22)
        Me.tpPedidosProvVisualizacion.Name = "tpPedidosProvVisualizacion"
        Me.tpPedidosProvVisualizacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPedidosProvVisualizacion.Size = New System.Drawing.Size(178, 15)
        Me.tpPedidosProvVisualizacion.TabIndex = 1
        Me.tpPedidosProvVisualizacion.Text = "Visualización"
        '
        'UcConfPedidosProvVisualizacion1
        '
        Me.UcConfPedidosProvVisualizacion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfPedidosProvVisualizacion1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfPedidosProvVisualizacion1.Name = "UcConfPedidosProvVisualizacion1"
        Me.UcConfPedidosProvVisualizacion1.Size = New System.Drawing.Size(172, 9)
        Me.UcConfPedidosProvVisualizacion1.TabIndex = 0
        '
        'tpPedidosProvRequerimiento
        '
        Me.tpPedidosProvRequerimiento.BackColor = System.Drawing.SystemColors.Control
        Me.tpPedidosProvRequerimiento.Controls.Add(Me.UcConfPedidosProvRequerimiento1)
        Me.tpPedidosProvRequerimiento.Location = New System.Drawing.Point(4, 22)
        Me.tpPedidosProvRequerimiento.Name = "tpPedidosProvRequerimiento"
        Me.tpPedidosProvRequerimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPedidosProvRequerimiento.Size = New System.Drawing.Size(178, 15)
        Me.tpPedidosProvRequerimiento.TabIndex = 2
        Me.tpPedidosProvRequerimiento.Text = "Requerimientos"
        '
        'UcConfPedidosProvRequerimiento1
        '
        Me.UcConfPedidosProvRequerimiento1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfPedidosProvRequerimiento1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfPedidosProvRequerimiento1.Name = "UcConfPedidosProvRequerimiento1"
        Me.UcConfPedidosProvRequerimiento1.Size = New System.Drawing.Size(172, 9)
        Me.UcConfPedidosProvRequerimiento1.TabIndex = 0
        '
        'tbpVentas
        '
        Me.tbpVentas.Controls.Add(Me.TabControl1)
        Me.tbpVentas.Location = New System.Drawing.Point(4, 73)
        Me.tbpVentas.Name = "tbpVentas"
        Me.tbpVentas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpVentas.Size = New System.Drawing.Size(931, 442)
        Me.tbpVentas.TabIndex = 3
        Me.tbpVentas.Text = "Ventas"
        Me.tbpVentas.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage9)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(925, 426)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.UcConfVentas11)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(917, 400)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ventas 1"
        '
        'UcConfVentas11
        '
        Me.UcConfVentas11.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfVentas11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfVentas11.Location = New System.Drawing.Point(3, 3)
        Me.UcConfVentas11.Name = "UcConfVentas11"
        Me.UcConfVentas11.Size = New System.Drawing.Size(911, 394)
        Me.UcConfVentas11.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.UcConfVentas21)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(917, 400)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Ventas 2"
        '
        'UcConfVentas21
        '
        Me.UcConfVentas21.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfVentas21.Location = New System.Drawing.Point(8, 5)
        Me.UcConfVentas21.Name = "UcConfVentas21"
        Me.UcConfVentas21.Size = New System.Drawing.Size(900, 400)
        Me.UcConfVentas21.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.UcConfVentas31)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(917, 400)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Ventas 3"
        '
        'UcConfVentas31
        '
        Me.UcConfVentas31.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfVentas31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfVentas31.Location = New System.Drawing.Point(3, 3)
        Me.UcConfVentas31.Name = "UcConfVentas31"
        Me.UcConfVentas31.Size = New System.Drawing.Size(911, 394)
        Me.UcConfVentas31.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.UcConfVentas41)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(917, 400)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Ventas 4"
        '
        'UcConfVentas41
        '
        Me.UcConfVentas41.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfVentas41.Location = New System.Drawing.Point(7, 7)
        Me.UcConfVentas41.Name = "UcConfVentas41"
        Me.UcConfVentas41.Size = New System.Drawing.Size(900, 400)
        Me.UcConfVentas41.TabIndex = 0
        '
        'TabPage9
        '
        Me.TabPage9.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage9.Controls.Add(Me.UcConfVentasCajero1)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(917, 400)
        Me.TabPage9.TabIndex = 8
        Me.TabPage9.Text = "Cajero"
        '
        'UcConfVentasCajero1
        '
        Me.UcConfVentasCajero1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfVentasCajero1.Location = New System.Drawing.Point(4, 4)
        Me.UcConfVentasCajero1.Name = "UcConfVentasCajero1"
        Me.UcConfVentasCajero1.Size = New System.Drawing.Size(900, 400)
        Me.UcConfVentasCajero1.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage7.Controls.Add(Me.UcConfVentasFacturacionRapida1)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(917, 400)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Facturación Rápida"
        '
        'UcConfVentasFacturacionRapida1
        '
        Me.UcConfVentasFacturacionRapida1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfVentasFacturacionRapida1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfVentasFacturacionRapida1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfVentasFacturacionRapida1.Name = "UcConfVentasFacturacionRapida1"
        Me.UcConfVentasFacturacionRapida1.Size = New System.Drawing.Size(917, 400)
        Me.UcConfVentasFacturacionRapida1.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage6.Controls.Add(Me.UcConfVentasVisualizacion1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(917, 400)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Visualización"
        '
        'UcConfVentasVisualizacion1
        '
        Me.UcConfVentasVisualizacion1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfVentasVisualizacion1.Location = New System.Drawing.Point(3, 4)
        Me.UcConfVentasVisualizacion1.Name = "UcConfVentasVisualizacion1"
        Me.UcConfVentasVisualizacion1.Size = New System.Drawing.Size(900, 400)
        Me.UcConfVentasVisualizacion1.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage5.Controls.Add(Me.UcConfVentasImpresion1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(917, 400)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Impresión"
        '
        'UcConfVentasImpresion1
        '
        Me.UcConfVentasImpresion1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfVentasImpresion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfVentasImpresion1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfVentasImpresion1.Name = "UcConfVentasImpresion1"
        Me.UcConfVentasImpresion1.Size = New System.Drawing.Size(911, 394)
        Me.UcConfVentasImpresion1.TabIndex = 0
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage8.Controls.Add(Me.UcConfVentasExportacion1)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(917, 400)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "Exportación"
        '
        'UcConfVentasExportacion1
        '
        Me.UcConfVentasExportacion1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfVentasExportacion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfVentasExportacion1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfVentasExportacion1.Name = "UcConfVentasExportacion1"
        Me.UcConfVentasExportacion1.Size = New System.Drawing.Size(911, 394)
        Me.UcConfVentasExportacion1.TabIndex = 0
        '
        'tbpFactElectronica
        '
        Me.tbpFactElectronica.Controls.Add(Me.UcConfFacturacionElectronica1)
        Me.tbpFactElectronica.Location = New System.Drawing.Point(4, 73)
        Me.tbpFactElectronica.Name = "tbpFactElectronica"
        Me.tbpFactElectronica.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFactElectronica.Size = New System.Drawing.Size(931, 442)
        Me.tbpFactElectronica.TabIndex = 13
        Me.tbpFactElectronica.Text = "Fact. Electr."
        Me.tbpFactElectronica.UseVisualStyleBackColor = True
        '
        'UcConfFacturacionElectronica1
        '
        Me.UcConfFacturacionElectronica1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfFacturacionElectronica1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfFacturacionElectronica1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfFacturacionElectronica1.Name = "UcConfFacturacionElectronica1"
        Me.UcConfFacturacionElectronica1.Size = New System.Drawing.Size(925, 436)
        Me.UcConfFacturacionElectronica1.TabIndex = 0
        '
        'tbpCompras
        '
        Me.tbpCompras.Controls.Add(Me.UcConfCompras1)
        Me.tbpCompras.Location = New System.Drawing.Point(4, 73)
        Me.tbpCompras.Name = "tbpCompras"
        Me.tbpCompras.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCompras.Size = New System.Drawing.Size(931, 442)
        Me.tbpCompras.TabIndex = 5
        Me.tbpCompras.Text = "Compras"
        Me.tbpCompras.UseVisualStyleBackColor = True
        '
        'UcConfCompras1
        '
        Me.UcConfCompras1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfCompras1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCompras1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfCompras1.Name = "UcConfCompras1"
        Me.UcConfCompras1.Size = New System.Drawing.Size(925, 436)
        Me.UcConfCompras1.TabIndex = 0
        '
        'tbpStock
        '
        Me.tbpStock.Controls.Add(Me.UcConfStock1)
        Me.tbpStock.Location = New System.Drawing.Point(4, 73)
        Me.tbpStock.Name = "tbpStock"
        Me.tbpStock.Size = New System.Drawing.Size(931, 442)
        Me.tbpStock.TabIndex = 12
        Me.tbpStock.Text = "Stock"
        Me.tbpStock.UseVisualStyleBackColor = True
        '
        'UcConfStock1
        '
        Me.UcConfStock1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfStock1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfStock1.Name = "UcConfStock1"
        Me.UcConfStock1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfStock1.TabIndex = 0
        '
        'tbpPrecios
        '
        Me.tbpPrecios.Controls.Add(Me.tbcPrecios)
        Me.tbpPrecios.Location = New System.Drawing.Point(4, 73)
        Me.tbpPrecios.Name = "tbpPrecios"
        Me.tbpPrecios.Size = New System.Drawing.Size(931, 442)
        Me.tbpPrecios.TabIndex = 7
        Me.tbpPrecios.Text = "Precios"
        Me.tbpPrecios.UseVisualStyleBackColor = True
        '
        'tbcPrecios
        '
        Me.tbcPrecios.Controls.Add(Me.tbpPrecios1)
        Me.tbcPrecios.Controls.Add(Me.tbpPrecios2)
        Me.tbcPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcPrecios.Location = New System.Drawing.Point(0, 0)
        Me.tbcPrecios.Name = "tbcPrecios"
        Me.tbcPrecios.SelectedIndex = 0
        Me.tbcPrecios.Size = New System.Drawing.Size(931, 442)
        Me.tbcPrecios.TabIndex = 1
        '
        'tbpPrecios1
        '
        Me.tbpPrecios1.BackColor = System.Drawing.SystemColors.Control
        Me.tbpPrecios1.Controls.Add(Me.UcConfPrecios1)
        Me.tbpPrecios1.Location = New System.Drawing.Point(4, 22)
        Me.tbpPrecios1.Name = "tbpPrecios1"
        Me.tbpPrecios1.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPrecios1.Size = New System.Drawing.Size(923, 416)
        Me.tbpPrecios1.TabIndex = 0
        Me.tbpPrecios1.Text = "Precios 1"
        '
        'UcConfPrecios1
        '
        Me.UcConfPrecios1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfPrecios1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfPrecios1.Name = "UcConfPrecios1"
        Me.UcConfPrecios1.Size = New System.Drawing.Size(917, 410)
        Me.UcConfPrecios1.TabIndex = 0
        '
        'tbpPrecios2
        '
        Me.tbpPrecios2.BackColor = System.Drawing.SystemColors.Control
        Me.tbpPrecios2.Controls.Add(Me.UcConfPrecios21)
        Me.tbpPrecios2.Location = New System.Drawing.Point(4, 22)
        Me.tbpPrecios2.Name = "tbpPrecios2"
        Me.tbpPrecios2.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPrecios2.Size = New System.Drawing.Size(184, 0)
        Me.tbpPrecios2.TabIndex = 1
        Me.tbpPrecios2.Text = "Precios 2"
        '
        'UcConfPrecios21
        '
        Me.UcConfPrecios21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfPrecios21.Location = New System.Drawing.Point(3, 3)
        Me.UcConfPrecios21.Name = "UcConfPrecios21"
        Me.UcConfPrecios21.Size = New System.Drawing.Size(178, 0)
        Me.UcConfPrecios21.TabIndex = 0
        '
        'tbpCtaCteClientes
        '
        Me.tbpCtaCteClientes.Controls.Add(Me.tbcCtaCteClientes)
        Me.tbpCtaCteClientes.Location = New System.Drawing.Point(4, 73)
        Me.tbpCtaCteClientes.Name = "tbpCtaCteClientes"
        Me.tbpCtaCteClientes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCtaCteClientes.Size = New System.Drawing.Size(931, 442)
        Me.tbpCtaCteClientes.TabIndex = 1
        Me.tbpCtaCteClientes.Text = "C.C. Clientes"
        Me.tbpCtaCteClientes.UseVisualStyleBackColor = True
        '
        'tbcCtaCteClientes
        '
        Me.tbcCtaCteClientes.Controls.Add(Me.tbpCtaCteClientes_General)
        Me.tbcCtaCteClientes.Controls.Add(Me.tbpCtaCteClientes_General2)
        Me.tbcCtaCteClientes.Controls.Add(Me.tbpCtaCteClientes_DebitoAutomatico)
        Me.tbcCtaCteClientes.Controls.Add(Me.tbpCtaCteClientes_Informes)
        Me.tbcCtaCteClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcCtaCteClientes.Location = New System.Drawing.Point(3, 3)
        Me.tbcCtaCteClientes.Name = "tbcCtaCteClientes"
        Me.tbcCtaCteClientes.SelectedIndex = 0
        Me.tbcCtaCteClientes.Size = New System.Drawing.Size(925, 436)
        Me.tbcCtaCteClientes.TabIndex = 39
        '
        'tbpCtaCteClientes_General
        '
        Me.tbpCtaCteClientes_General.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCtaCteClientes_General.Controls.Add(Me.UcConfCtaCteClienteGeneral1)
        Me.tbpCtaCteClientes_General.Location = New System.Drawing.Point(4, 22)
        Me.tbpCtaCteClientes_General.Name = "tbpCtaCteClientes_General"
        Me.tbpCtaCteClientes_General.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCtaCteClientes_General.Size = New System.Drawing.Size(917, 410)
        Me.tbpCtaCteClientes_General.TabIndex = 0
        Me.tbpCtaCteClientes_General.Text = "General"
        '
        'UcConfCtaCteClienteGeneral1
        '
        Me.UcConfCtaCteClienteGeneral1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCtaCteClienteGeneral1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfCtaCteClienteGeneral1.Name = "UcConfCtaCteClienteGeneral1"
        Me.UcConfCtaCteClienteGeneral1.Size = New System.Drawing.Size(911, 404)
        Me.UcConfCtaCteClienteGeneral1.TabIndex = 0
        '
        'tbpCtaCteClientes_General2
        '
        Me.tbpCtaCteClientes_General2.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCtaCteClientes_General2.Controls.Add(Me.UcConfCtaCteClienteGeneral21)
        Me.tbpCtaCteClientes_General2.Location = New System.Drawing.Point(4, 22)
        Me.tbpCtaCteClientes_General2.Name = "tbpCtaCteClientes_General2"
        Me.tbpCtaCteClientes_General2.Size = New System.Drawing.Size(917, 410)
        Me.tbpCtaCteClientes_General2.TabIndex = 4
        Me.tbpCtaCteClientes_General2.Text = "General 2"
        '
        'UcConfCtaCteClienteGeneral21
        '
        Me.UcConfCtaCteClienteGeneral21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCtaCteClienteGeneral21.Location = New System.Drawing.Point(0, 0)
        Me.UcConfCtaCteClienteGeneral21.Name = "UcConfCtaCteClienteGeneral21"
        Me.UcConfCtaCteClienteGeneral21.Size = New System.Drawing.Size(917, 410)
        Me.UcConfCtaCteClienteGeneral21.TabIndex = 0
        '
        'tbpCtaCteClientes_DebitoAutomatico
        '
        Me.tbpCtaCteClientes_DebitoAutomatico.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCtaCteClientes_DebitoAutomatico.Controls.Add(Me.UcConfCtaCteClienteDebitoAutomatico1)
        Me.tbpCtaCteClientes_DebitoAutomatico.Location = New System.Drawing.Point(4, 22)
        Me.tbpCtaCteClientes_DebitoAutomatico.Name = "tbpCtaCteClientes_DebitoAutomatico"
        Me.tbpCtaCteClientes_DebitoAutomatico.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCtaCteClientes_DebitoAutomatico.Size = New System.Drawing.Size(917, 410)
        Me.tbpCtaCteClientes_DebitoAutomatico.TabIndex = 1
        Me.tbpCtaCteClientes_DebitoAutomatico.Text = "Cobranzas Electrónicas"
        '
        'UcConfCtaCteClienteDebitoAutomatico1
        '
        Me.UcConfCtaCteClienteDebitoAutomatico1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCtaCteClienteDebitoAutomatico1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfCtaCteClienteDebitoAutomatico1.Name = "UcConfCtaCteClienteDebitoAutomatico1"
        Me.UcConfCtaCteClienteDebitoAutomatico1.Size = New System.Drawing.Size(911, 404)
        Me.UcConfCtaCteClienteDebitoAutomatico1.TabIndex = 0
        '
        'tbpCtaCteClientes_Informes
        '
        Me.tbpCtaCteClientes_Informes.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCtaCteClientes_Informes.Controls.Add(Me.UcConfCtaCteClienteInformes1)
        Me.tbpCtaCteClientes_Informes.Location = New System.Drawing.Point(4, 22)
        Me.tbpCtaCteClientes_Informes.Name = "tbpCtaCteClientes_Informes"
        Me.tbpCtaCteClientes_Informes.Size = New System.Drawing.Size(917, 410)
        Me.tbpCtaCteClientes_Informes.TabIndex = 3
        Me.tbpCtaCteClientes_Informes.Text = "Informes"
        '
        'UcConfCtaCteClienteInformes1
        '
        Me.UcConfCtaCteClienteInformes1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCtaCteClienteInformes1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfCtaCteClienteInformes1.Name = "UcConfCtaCteClienteInformes1"
        Me.UcConfCtaCteClienteInformes1.Size = New System.Drawing.Size(917, 410)
        Me.UcConfCtaCteClienteInformes1.TabIndex = 0
        '
        'tbpArchivos
        '
        Me.tbpArchivos.Controls.Add(Me.tbcArchivos)
        Me.tbpArchivos.Location = New System.Drawing.Point(4, 73)
        Me.tbpArchivos.Name = "tbpArchivos"
        Me.tbpArchivos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpArchivos.Size = New System.Drawing.Size(931, 442)
        Me.tbpArchivos.TabIndex = 11
        Me.tbpArchivos.Text = "Archivos"
        Me.tbpArchivos.UseVisualStyleBackColor = True
        '
        'tbcArchivos
        '
        Me.tbcArchivos.Controls.Add(Me.tbpArchivosGeneral)
        Me.tbcArchivos.Controls.Add(Me.tbpArchivosClientes)
        Me.tbcArchivos.Controls.Add(Me.tbpArchivosProductos)
        Me.tbcArchivos.Controls.Add(Me.tbpArchivosWeb)
        Me.tbcArchivos.Controls.Add(Me.tbpArchivosSync)
        Me.tbcArchivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcArchivos.Location = New System.Drawing.Point(3, 3)
        Me.tbcArchivos.Name = "tbcArchivos"
        Me.tbcArchivos.SelectedIndex = 0
        Me.tbcArchivos.Size = New System.Drawing.Size(925, 436)
        Me.tbcArchivos.TabIndex = 0
        '
        'tbpArchivosGeneral
        '
        Me.tbpArchivosGeneral.BackColor = System.Drawing.SystemColors.Control
        Me.tbpArchivosGeneral.Controls.Add(Me.UcConfArchivos1)
        Me.tbpArchivosGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tbpArchivosGeneral.Name = "tbpArchivosGeneral"
        Me.tbpArchivosGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpArchivosGeneral.Size = New System.Drawing.Size(917, 410)
        Me.tbpArchivosGeneral.TabIndex = 0
        Me.tbpArchivosGeneral.Text = "Archivos"
        '
        'UcConfArchivos1
        '
        Me.UcConfArchivos1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfArchivos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfArchivos1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfArchivos1.Name = "UcConfArchivos1"
        Me.UcConfArchivos1.Size = New System.Drawing.Size(911, 404)
        Me.UcConfArchivos1.TabIndex = 0
        '
        'tbpArchivosClientes
        '
        Me.tbpArchivosClientes.BackColor = System.Drawing.SystemColors.Control
        Me.tbpArchivosClientes.Controls.Add(Me.UcConfArchivosClientes1)
        Me.tbpArchivosClientes.Location = New System.Drawing.Point(4, 22)
        Me.tbpArchivosClientes.Name = "tbpArchivosClientes"
        Me.tbpArchivosClientes.Size = New System.Drawing.Size(178, 0)
        Me.tbpArchivosClientes.TabIndex = 4
        Me.tbpArchivosClientes.Text = "Clientes"
        '
        'UcConfArchivosClientes1
        '
        Me.UcConfArchivosClientes1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfArchivosClientes1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfArchivosClientes1.Name = "UcConfArchivosClientes1"
        Me.UcConfArchivosClientes1.Size = New System.Drawing.Size(178, 0)
        Me.UcConfArchivosClientes1.TabIndex = 0
        '
        'tbpArchivosProductos
        '
        Me.tbpArchivosProductos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpArchivosProductos.Controls.Add(Me.UcConfArchivosProductos1)
        Me.tbpArchivosProductos.Location = New System.Drawing.Point(4, 22)
        Me.tbpArchivosProductos.Name = "tbpArchivosProductos"
        Me.tbpArchivosProductos.Size = New System.Drawing.Size(178, 0)
        Me.tbpArchivosProductos.TabIndex = 2
        Me.tbpArchivosProductos.Text = "Productos"
        '
        'UcConfArchivosProductos1
        '
        Me.UcConfArchivosProductos1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfArchivosProductos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfArchivosProductos1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfArchivosProductos1.Name = "UcConfArchivosProductos1"
        Me.UcConfArchivosProductos1.Size = New System.Drawing.Size(178, 0)
        Me.UcConfArchivosProductos1.TabIndex = 0
        '
        'tbpArchivosWeb
        '
        Me.tbpArchivosWeb.BackColor = System.Drawing.SystemColors.Control
        Me.tbpArchivosWeb.Controls.Add(Me.UcConfArchivosWeb1)
        Me.tbpArchivosWeb.Location = New System.Drawing.Point(4, 22)
        Me.tbpArchivosWeb.Name = "tbpArchivosWeb"
        Me.tbpArchivosWeb.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpArchivosWeb.Size = New System.Drawing.Size(178, 0)
        Me.tbpArchivosWeb.TabIndex = 1
        Me.tbpArchivosWeb.Text = "Web"
        '
        'UcConfArchivosWeb1
        '
        Me.UcConfArchivosWeb1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfArchivosWeb1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfArchivosWeb1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfArchivosWeb1.Name = "UcConfArchivosWeb1"
        Me.UcConfArchivosWeb1.Size = New System.Drawing.Size(172, 0)
        Me.UcConfArchivosWeb1.TabIndex = 0
        '
        'tbpArchivosSync
        '
        Me.tbpArchivosSync.BackColor = System.Drawing.SystemColors.Control
        Me.tbpArchivosSync.Controls.Add(Me.UcConfArchivosSync1)
        Me.tbpArchivosSync.Location = New System.Drawing.Point(4, 22)
        Me.tbpArchivosSync.Name = "tbpArchivosSync"
        Me.tbpArchivosSync.Size = New System.Drawing.Size(178, 0)
        Me.tbpArchivosSync.TabIndex = 3
        Me.tbpArchivosSync.Text = "Sync"
        '
        'UcConfArchivosSync1
        '
        Me.UcConfArchivosSync1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfArchivosSync1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfArchivosSync1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfArchivosSync1.Name = "UcConfArchivosSync1"
        Me.UcConfArchivosSync1.Size = New System.Drawing.Size(178, 0)
        Me.UcConfArchivosSync1.TabIndex = 0
        '
        'tbpCtaCteProveedores
        '
        Me.tbpCtaCteProveedores.Controls.Add(Me.UcConfCtaCteProv1)
        Me.tbpCtaCteProveedores.Location = New System.Drawing.Point(4, 73)
        Me.tbpCtaCteProveedores.Name = "tbpCtaCteProveedores"
        Me.tbpCtaCteProveedores.Size = New System.Drawing.Size(931, 442)
        Me.tbpCtaCteProveedores.TabIndex = 10
        Me.tbpCtaCteProveedores.Text = "C.C. Proveedores"
        Me.tbpCtaCteProveedores.UseVisualStyleBackColor = True
        '
        'UcConfCtaCteProv1
        '
        Me.UcConfCtaCteProv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCtaCteProv1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfCtaCteProv1.Name = "UcConfCtaCteProv1"
        Me.UcConfCtaCteProv1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfCtaCteProv1.TabIndex = 0
        '
        'tbpCaja
        '
        Me.tbpCaja.Controls.Add(Me.UcConfCaja1)
        Me.tbpCaja.Location = New System.Drawing.Point(4, 73)
        Me.tbpCaja.Name = "tbpCaja"
        Me.tbpCaja.Size = New System.Drawing.Size(931, 442)
        Me.tbpCaja.TabIndex = 2
        Me.tbpCaja.Text = "Caja"
        Me.tbpCaja.UseVisualStyleBackColor = True
        '
        'UcConfCaja1
        '
        Me.UcConfCaja1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfCaja1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCaja1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfCaja1.Name = "UcConfCaja1"
        Me.UcConfCaja1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfCaja1.TabIndex = 66
        '
        'tbpBanco
        '
        Me.tbpBanco.Controls.Add(Me.UcConfBanco1)
        Me.tbpBanco.Location = New System.Drawing.Point(4, 73)
        Me.tbpBanco.Name = "tbpBanco"
        Me.tbpBanco.Size = New System.Drawing.Size(931, 442)
        Me.tbpBanco.TabIndex = 8
        Me.tbpBanco.Text = "Banco"
        Me.tbpBanco.UseVisualStyleBackColor = True
        '
        'UcConfBanco1
        '
        Me.UcConfBanco1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfBanco1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfBanco1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfBanco1.Name = "UcConfBanco1"
        Me.UcConfBanco1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfBanco1.TabIndex = 44
        '
        'tbpProcesos
        '
        Me.tbpProcesos.Controls.Add(Me.UcConfProcesos1)
        Me.tbpProcesos.Location = New System.Drawing.Point(4, 73)
        Me.tbpProcesos.Name = "tbpProcesos"
        Me.tbpProcesos.Size = New System.Drawing.Size(931, 442)
        Me.tbpProcesos.TabIndex = 9
        Me.tbpProcesos.Text = "Procesos"
        Me.tbpProcesos.UseVisualStyleBackColor = True
        '
        'UcConfProcesos1
        '
        Me.UcConfProcesos1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfProcesos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfProcesos1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfProcesos1.Name = "UcConfProcesos1"
        Me.UcConfProcesos1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfProcesos1.TabIndex = 13
        '
        'tbpSueldos
        '
        Me.tbpSueldos.Controls.Add(Me.UcConfSueldos1)
        Me.tbpSueldos.Location = New System.Drawing.Point(4, 73)
        Me.tbpSueldos.Name = "tbpSueldos"
        Me.tbpSueldos.Size = New System.Drawing.Size(931, 442)
        Me.tbpSueldos.TabIndex = 16
        Me.tbpSueldos.Text = "Sueldos"
        Me.tbpSueldos.UseVisualStyleBackColor = True
        '
        'UcConfSueldos1
        '
        Me.UcConfSueldos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfSueldos1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfSueldos1.Name = "UcConfSueldos1"
        Me.UcConfSueldos1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfSueldos1.TabIndex = 0
        '
        'tbpRMA
        '
        Me.tbpRMA.Controls.Add(Me.UcConfRMA1)
        Me.tbpRMA.Location = New System.Drawing.Point(4, 73)
        Me.tbpRMA.Name = "tbpRMA"
        Me.tbpRMA.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpRMA.Size = New System.Drawing.Size(931, 442)
        Me.tbpRMA.TabIndex = 17
        Me.tbpRMA.Text = "RMA"
        Me.tbpRMA.UseVisualStyleBackColor = True
        '
        'UcConfRMA1
        '
        Me.UcConfRMA1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfRMA1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfRMA1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfRMA1.Name = "UcConfRMA1"
        Me.UcConfRMA1.Size = New System.Drawing.Size(925, 436)
        Me.UcConfRMA1.TabIndex = 0
        '
        'tbpProduccion
        '
        Me.tbpProduccion.Controls.Add(Me.UcConfProduccion1)
        Me.tbpProduccion.Location = New System.Drawing.Point(4, 73)
        Me.tbpProduccion.Name = "tbpProduccion"
        Me.tbpProduccion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpProduccion.Size = New System.Drawing.Size(931, 442)
        Me.tbpProduccion.TabIndex = 18
        Me.tbpProduccion.Text = "Producción"
        Me.tbpProduccion.UseVisualStyleBackColor = True
        '
        'UcConfProduccion1
        '
        Me.UcConfProduccion1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfProduccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfProduccion1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfProduccion1.Name = "UcConfProduccion1"
        Me.UcConfProduccion1.Size = New System.Drawing.Size(925, 436)
        Me.UcConfProduccion1.TabIndex = 0
        '
        'tbpContabilidad
        '
        Me.tbpContabilidad.Controls.Add(Me.UcConfContabilidad1)
        Me.tbpContabilidad.Location = New System.Drawing.Point(4, 73)
        Me.tbpContabilidad.Name = "tbpContabilidad"
        Me.tbpContabilidad.Size = New System.Drawing.Size(931, 442)
        Me.tbpContabilidad.TabIndex = 19
        Me.tbpContabilidad.Text = "Contabilidad"
        Me.tbpContabilidad.UseVisualStyleBackColor = True
        '
        'UcConfContabilidad1
        '
        Me.UcConfContabilidad1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfContabilidad1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfContabilidad1.Name = "UcConfContabilidad1"
        Me.UcConfContabilidad1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfContabilidad1.TabIndex = 0
        '
        'tbpCargos
        '
        Me.tbpCargos.Controls.Add(Me.UcConfCargos1)
        Me.tbpCargos.Location = New System.Drawing.Point(4, 73)
        Me.tbpCargos.Name = "tbpCargos"
        Me.tbpCargos.Size = New System.Drawing.Size(931, 442)
        Me.tbpCargos.TabIndex = 20
        Me.tbpCargos.Text = "Cargos"
        Me.tbpCargos.UseVisualStyleBackColor = True
        '
        'UcConfCargos1
        '
        Me.UcConfCargos1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfCargos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCargos1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfCargos1.Name = "UcConfCargos1"
        Me.UcConfCargos1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfCargos1.TabIndex = 0
        '
        'tbpCRM
        '
        Me.tbpCRM.Controls.Add(Me.tbcCRM)
        Me.tbpCRM.Location = New System.Drawing.Point(4, 73)
        Me.tbpCRM.Name = "tbpCRM"
        Me.tbpCRM.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCRM.Size = New System.Drawing.Size(931, 442)
        Me.tbpCRM.TabIndex = 21
        Me.tbpCRM.Text = "CRM"
        Me.tbpCRM.UseVisualStyleBackColor = True
        '
        'tbcCRM
        '
        Me.tbcCRM.Controls.Add(Me.tbpCRMGenerales)
        Me.tbcCRM.Controls.Add(Me.tbpCRMCorreos)
        Me.tbcCRM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcCRM.Location = New System.Drawing.Point(3, 3)
        Me.tbcCRM.Name = "tbcCRM"
        Me.tbcCRM.SelectedIndex = 0
        Me.tbcCRM.Size = New System.Drawing.Size(925, 436)
        Me.tbcCRM.TabIndex = 34
        '
        'tbpCRMGenerales
        '
        Me.tbpCRMGenerales.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCRMGenerales.Controls.Add(Me.UcConfCRMGenerales1)
        Me.tbpCRMGenerales.Location = New System.Drawing.Point(4, 22)
        Me.tbpCRMGenerales.Name = "tbpCRMGenerales"
        Me.tbpCRMGenerales.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCRMGenerales.Size = New System.Drawing.Size(917, 410)
        Me.tbpCRMGenerales.TabIndex = 0
        Me.tbpCRMGenerales.Text = "Generales"
        '
        'UcConfCRMGenerales1
        '
        Me.UcConfCRMGenerales1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfCRMGenerales1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCRMGenerales1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfCRMGenerales1.Name = "UcConfCRMGenerales1"
        Me.UcConfCRMGenerales1.Size = New System.Drawing.Size(911, 404)
        Me.UcConfCRMGenerales1.TabIndex = 0
        '
        'tbpCRMCorreos
        '
        Me.tbpCRMCorreos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCRMCorreos.Controls.Add(Me.UcConfCRMEnvioCorreo1)
        Me.tbpCRMCorreos.Location = New System.Drawing.Point(4, 22)
        Me.tbpCRMCorreos.Name = "tbpCRMCorreos"
        Me.tbpCRMCorreos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCRMCorreos.Size = New System.Drawing.Size(178, 0)
        Me.tbpCRMCorreos.TabIndex = 1
        Me.tbpCRMCorreos.Text = "Envio de Correos"
        '
        'UcConfCRMEnvioCorreo1
        '
        Me.UcConfCRMEnvioCorreo1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfCRMEnvioCorreo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfCRMEnvioCorreo1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfCRMEnvioCorreo1.Name = "UcConfCRMEnvioCorreo1"
        Me.UcConfCRMEnvioCorreo1.Size = New System.Drawing.Size(172, 0)
        Me.UcConfCRMEnvioCorreo1.TabIndex = 0
        '
        'tbpAFIP
        '
        Me.tbpAFIP.Controls.Add(Me.UcConfAFIP1)
        Me.tbpAFIP.Location = New System.Drawing.Point(4, 73)
        Me.tbpAFIP.Name = "tbpAFIP"
        Me.tbpAFIP.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAFIP.Size = New System.Drawing.Size(931, 442)
        Me.tbpAFIP.TabIndex = 22
        Me.tbpAFIP.Text = "AFIP"
        Me.tbpAFIP.UseVisualStyleBackColor = True
        '
        'UcConfAFIP1
        '
        Me.UcConfAFIP1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfAFIP1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfAFIP1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfAFIP1.Name = "UcConfAFIP1"
        Me.UcConfAFIP1.Size = New System.Drawing.Size(925, 436)
        Me.UcConfAFIP1.TabIndex = 0
        '
        'tbpTurnos
        '
        Me.tbpTurnos.Controls.Add(Me.UcConfTurnos1)
        Me.tbpTurnos.Location = New System.Drawing.Point(4, 73)
        Me.tbpTurnos.Name = "tbpTurnos"
        Me.tbpTurnos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpTurnos.Size = New System.Drawing.Size(931, 442)
        Me.tbpTurnos.TabIndex = 24
        Me.tbpTurnos.Text = "Turnos"
        Me.tbpTurnos.UseVisualStyleBackColor = True
        '
        'UcConfTurnos1
        '
        Me.UcConfTurnos1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfTurnos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfTurnos1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfTurnos1.Name = "UcConfTurnos1"
        Me.UcConfTurnos1.Size = New System.Drawing.Size(925, 436)
        Me.UcConfTurnos1.TabIndex = 0
        '
        'tbpEstadisticas
        '
        Me.tbpEstadisticas.Controls.Add(Me.UcConfEstadisticas1)
        Me.tbpEstadisticas.Location = New System.Drawing.Point(4, 73)
        Me.tbpEstadisticas.Name = "tbpEstadisticas"
        Me.tbpEstadisticas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpEstadisticas.Size = New System.Drawing.Size(931, 442)
        Me.tbpEstadisticas.TabIndex = 25
        Me.tbpEstadisticas.Text = "Estadisticas"
        Me.tbpEstadisticas.UseVisualStyleBackColor = True
        '
        'UcConfEstadisticas1
        '
        Me.UcConfEstadisticas1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfEstadisticas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfEstadisticas1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfEstadisticas1.Name = "UcConfEstadisticas1"
        Me.UcConfEstadisticas1.Size = New System.Drawing.Size(925, 436)
        Me.UcConfEstadisticas1.TabIndex = 0
        '
        'tbpAplicacionesMoviles
        '
        Me.tbpAplicacionesMoviles.Controls.Add(Me.tbcAplicacionesMoviles)
        Me.tbpAplicacionesMoviles.Location = New System.Drawing.Point(4, 73)
        Me.tbpAplicacionesMoviles.Name = "tbpAplicacionesMoviles"
        Me.tbpAplicacionesMoviles.Size = New System.Drawing.Size(931, 442)
        Me.tbpAplicacionesMoviles.TabIndex = 26
        Me.tbpAplicacionesMoviles.Text = "Aplicaciones Móviles"
        Me.tbpAplicacionesMoviles.UseVisualStyleBackColor = True
        '
        'tbcAplicacionesMoviles
        '
        Me.tbcAplicacionesMoviles.Controls.Add(Me.tbpAplicacionesMoviles_CobranzasPedidos)
        Me.tbcAplicacionesMoviles.Controls.Add(Me.tbpAplicacionesMoviles_Urls)
        Me.tbcAplicacionesMoviles.Controls.Add(Me.tbpAplicacionesMoviles_Soporte)
        Me.tbcAplicacionesMoviles.Controls.Add(Me.TabPage10)
        Me.tbcAplicacionesMoviles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcAplicacionesMoviles.Location = New System.Drawing.Point(0, 0)
        Me.tbcAplicacionesMoviles.Name = "tbcAplicacionesMoviles"
        Me.tbcAplicacionesMoviles.SelectedIndex = 0
        Me.tbcAplicacionesMoviles.Size = New System.Drawing.Size(931, 442)
        Me.tbcAplicacionesMoviles.TabIndex = 0
        '
        'tbpAplicacionesMoviles_CobranzasPedidos
        '
        Me.tbpAplicacionesMoviles_CobranzasPedidos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpAplicacionesMoviles_CobranzasPedidos.Controls.Add(Me.UcConfAppMovilesConfiguraciones1)
        Me.tbpAplicacionesMoviles_CobranzasPedidos.Controls.Add(Me.lnkSimovilURLBase_01)
        Me.tbpAplicacionesMoviles_CobranzasPedidos.Location = New System.Drawing.Point(4, 22)
        Me.tbpAplicacionesMoviles_CobranzasPedidos.Name = "tbpAplicacionesMoviles_CobranzasPedidos"
        Me.tbpAplicacionesMoviles_CobranzasPedidos.Size = New System.Drawing.Size(923, 416)
        Me.tbpAplicacionesMoviles_CobranzasPedidos.TabIndex = 2
        Me.tbpAplicacionesMoviles_CobranzasPedidos.Text = "Cobranzas / Pedidos"
        '
        'UcConfAppMovilesConfiguraciones1
        '
        Me.UcConfAppMovilesConfiguraciones1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfAppMovilesConfiguraciones1.Location = New System.Drawing.Point(13, 18)
        Me.UcConfAppMovilesConfiguraciones1.Name = "UcConfAppMovilesConfiguraciones1"
        Me.UcConfAppMovilesConfiguraciones1.Size = New System.Drawing.Size(900, 397)
        Me.UcConfAppMovilesConfiguraciones1.TabIndex = 11
        '
        'lnkSimovilURLBase_01
        '
        Me.lnkSimovilURLBase_01.AutoSize = True
        Me.lnkSimovilURLBase_01.Location = New System.Drawing.Point(278, 5)
        Me.lnkSimovilURLBase_01.Name = "lnkSimovilURLBase_01"
        Me.lnkSimovilURLBase_01.Size = New System.Drawing.Size(344, 13)
        Me.lnkSimovilURLBase_01.TabIndex = 10
        Me.lnkSimovilURLBase_01.TabStop = True
        Me.lnkSimovilURLBase_01.Text = "La URL Base se movió a la solapa URLs Base de Aplicaciones Móviles"
        '
        'tbpAplicacionesMoviles_Urls
        '
        Me.tbpAplicacionesMoviles_Urls.BackColor = System.Drawing.SystemColors.Control
        Me.tbpAplicacionesMoviles_Urls.Controls.Add(Me.UcConfAppMovilesURLsBase1)
        Me.tbpAplicacionesMoviles_Urls.Location = New System.Drawing.Point(4, 22)
        Me.tbpAplicacionesMoviles_Urls.Name = "tbpAplicacionesMoviles_Urls"
        Me.tbpAplicacionesMoviles_Urls.Size = New System.Drawing.Size(184, 0)
        Me.tbpAplicacionesMoviles_Urls.TabIndex = 3
        Me.tbpAplicacionesMoviles_Urls.Text = "URLs Base"
        '
        'UcConfAppMovilesURLsBase1
        '
        Me.UcConfAppMovilesURLsBase1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfAppMovilesURLsBase1.Location = New System.Drawing.Point(9, 3)
        Me.UcConfAppMovilesURLsBase1.Name = "UcConfAppMovilesURLsBase1"
        Me.UcConfAppMovilesURLsBase1.Size = New System.Drawing.Size(900, 400)
        Me.UcConfAppMovilesURLsBase1.TabIndex = 0
        '
        'tbpAplicacionesMoviles_Soporte
        '
        Me.tbpAplicacionesMoviles_Soporte.BackColor = System.Drawing.SystemColors.Control
        Me.tbpAplicacionesMoviles_Soporte.Controls.Add(Me.UcConfAppMovilesSoporte1)
        Me.tbpAplicacionesMoviles_Soporte.Controls.Add(Me.lnkSimovilURLBase_02)
        Me.tbpAplicacionesMoviles_Soporte.Location = New System.Drawing.Point(4, 22)
        Me.tbpAplicacionesMoviles_Soporte.Name = "tbpAplicacionesMoviles_Soporte"
        Me.tbpAplicacionesMoviles_Soporte.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAplicacionesMoviles_Soporte.Size = New System.Drawing.Size(184, 0)
        Me.tbpAplicacionesMoviles_Soporte.TabIndex = 0
        Me.tbpAplicacionesMoviles_Soporte.Text = "Soporte"
        '
        'UcConfAppMovilesSoporte1
        '
        Me.UcConfAppMovilesSoporte1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfAppMovilesSoporte1.Location = New System.Drawing.Point(12, 37)
        Me.UcConfAppMovilesSoporte1.Name = "UcConfAppMovilesSoporte1"
        Me.UcConfAppMovilesSoporte1.Size = New System.Drawing.Size(900, 400)
        Me.UcConfAppMovilesSoporte1.TabIndex = 12
        '
        'lnkSimovilURLBase_02
        '
        Me.lnkSimovilURLBase_02.AutoSize = True
        Me.lnkSimovilURLBase_02.Location = New System.Drawing.Point(76, 21)
        Me.lnkSimovilURLBase_02.Name = "lnkSimovilURLBase_02"
        Me.lnkSimovilURLBase_02.Size = New System.Drawing.Size(344, 13)
        Me.lnkSimovilURLBase_02.TabIndex = 11
        Me.lnkSimovilURLBase_02.TabStop = True
        Me.lnkSimovilURLBase_02.Text = "La URL Base se movió a la solapa URLs Base de Aplicaciones Móviles"
        '
        'TabPage10
        '
        Me.TabPage10.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage10.Controls.Add(Me.UcConfAppMovilesFTP1)
        Me.TabPage10.Location = New System.Drawing.Point(4, 22)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage10.Size = New System.Drawing.Size(184, 0)
        Me.TabPage10.TabIndex = 4
        Me.TabPage10.Text = "FTP"
        '
        'UcConfAppMovilesFTP1
        '
        Me.UcConfAppMovilesFTP1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfAppMovilesFTP1.Location = New System.Drawing.Point(10, 7)
        Me.UcConfAppMovilesFTP1.Name = "UcConfAppMovilesFTP1"
        Me.UcConfAppMovilesFTP1.Size = New System.Drawing.Size(900, 400)
        Me.UcConfAppMovilesFTP1.TabIndex = 0
        '
        'tbpLogistica
        '
        Me.tbpLogistica.Controls.Add(Me.UcConfLogistica1)
        Me.tbpLogistica.Location = New System.Drawing.Point(4, 73)
        Me.tbpLogistica.Name = "tbpLogistica"
        Me.tbpLogistica.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpLogistica.Size = New System.Drawing.Size(931, 442)
        Me.tbpLogistica.TabIndex = 26
        Me.tbpLogistica.Text = "Logística"
        Me.tbpLogistica.UseVisualStyleBackColor = True
        '
        'UcConfLogistica1
        '
        Me.UcConfLogistica1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfLogistica1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfLogistica1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfLogistica1.Name = "UcConfLogistica1"
        Me.UcConfLogistica1.Size = New System.Drawing.Size(925, 436)
        Me.UcConfLogistica1.TabIndex = 0
        '
        'tbpCalidad
        '
        Me.tbpCalidad.Controls.Add(Me.UcConfCalidad1)
        Me.tbpCalidad.Location = New System.Drawing.Point(4, 73)
        Me.tbpCalidad.Name = "tbpCalidad"
        Me.tbpCalidad.Size = New System.Drawing.Size(931, 442)
        Me.tbpCalidad.TabIndex = 27
        Me.tbpCalidad.Text = "Calidad"
        Me.tbpCalidad.UseVisualStyleBackColor = True
        '
        'UcConfCalidad1
        '
        Me.UcConfCalidad1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfCalidad1.Location = New System.Drawing.Point(8, 3)
        Me.UcConfCalidad1.Name = "UcConfCalidad1"
        Me.UcConfCalidad1.Size = New System.Drawing.Size(900, 431)
        Me.UcConfCalidad1.TabIndex = 0
        '
        'tbpTurismo
        '
        Me.tbpTurismo.Controls.Add(Me.lnkRoelaSirPlus)
        Me.tbpTurismo.Controls.Add(Me.UcConfTurismo1)
        Me.tbpTurismo.Controls.Add(Me.lnkSimovilURLBase_03)
        Me.tbpTurismo.Location = New System.Drawing.Point(4, 73)
        Me.tbpTurismo.Name = "tbpTurismo"
        Me.tbpTurismo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpTurismo.Size = New System.Drawing.Size(931, 442)
        Me.tbpTurismo.TabIndex = 28
        Me.tbpTurismo.Text = "Turismo"
        Me.tbpTurismo.UseVisualStyleBackColor = True
        '
        'UcConfTurismo1
        '
        Me.UcConfTurismo1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfTurismo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfTurismo1.Location = New System.Drawing.Point(3, 16)
        Me.UcConfTurismo1.Name = "UcConfTurismo1"
        Me.UcConfTurismo1.Size = New System.Drawing.Size(925, 423)
        Me.UcConfTurismo1.TabIndex = 24
        '
        'lnkSimovilURLBase_03
        '
        Me.lnkSimovilURLBase_03.Dock = System.Windows.Forms.DockStyle.Top
        Me.lnkSimovilURLBase_03.Location = New System.Drawing.Point(3, 3)
        Me.lnkSimovilURLBase_03.Name = "lnkSimovilURLBase_03"
        Me.lnkSimovilURLBase_03.Size = New System.Drawing.Size(925, 13)
        Me.lnkSimovilURLBase_03.TabIndex = 23
        Me.lnkSimovilURLBase_03.TabStop = True
        Me.lnkSimovilURLBase_03.Text = "La URL Base se movió a la solapa URLs Base de Aplicaciones Móviles"
        Me.lnkSimovilURLBase_03.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tpTiendaWeb
        '
        Me.tpTiendaWeb.Controls.Add(Me.TblTiendasWeb)
        Me.tpTiendaWeb.Location = New System.Drawing.Point(4, 73)
        Me.tpTiendaWeb.Name = "tpTiendaWeb"
        Me.tpTiendaWeb.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTiendaWeb.Size = New System.Drawing.Size(931, 442)
        Me.tpTiendaWeb.TabIndex = 29
        Me.tpTiendaWeb.Text = "Tienda Web"
        Me.tpTiendaWeb.UseVisualStyleBackColor = True
        '
        'TblTiendasWeb
        '
        Me.TblTiendasWeb.Controls.Add(Me.tbpTiendaNube)
        Me.TblTiendasWeb.Controls.Add(Me.tbpMercadoLibre)
        Me.TblTiendasWeb.Controls.Add(Me.tbpArborea)
        Me.TblTiendasWeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TblTiendasWeb.Location = New System.Drawing.Point(3, 3)
        Me.TblTiendasWeb.Name = "TblTiendasWeb"
        Me.TblTiendasWeb.SelectedIndex = 0
        Me.TblTiendasWeb.Size = New System.Drawing.Size(925, 436)
        Me.TblTiendasWeb.TabIndex = 1
        '
        'tbpTiendaNube
        '
        Me.tbpTiendaNube.BackColor = System.Drawing.SystemColors.Control
        Me.tbpTiendaNube.Controls.Add(Me.UcConfTiendaNube1)
        Me.tbpTiendaNube.Location = New System.Drawing.Point(4, 22)
        Me.tbpTiendaNube.Name = "tbpTiendaNube"
        Me.tbpTiendaNube.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpTiendaNube.Size = New System.Drawing.Size(917, 410)
        Me.tbpTiendaNube.TabIndex = 1
        Me.tbpTiendaNube.Text = "Tienda Nube"
        '
        'UcConfTiendaNube1
        '
        Me.UcConfTiendaNube1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfTiendaNube1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfTiendaNube1.Location = New System.Drawing.Point(3, 3)
        Me.UcConfTiendaNube1.Name = "UcConfTiendaNube1"
        Me.UcConfTiendaNube1.Size = New System.Drawing.Size(911, 404)
        Me.UcConfTiendaNube1.TabIndex = 0
        '
        'tbpMercadoLibre
        '
        Me.tbpMercadoLibre.BackColor = System.Drawing.SystemColors.Control
        Me.tbpMercadoLibre.Controls.Add(Me.UcConfMercadoLibre1)
        Me.tbpMercadoLibre.Location = New System.Drawing.Point(4, 22)
        Me.tbpMercadoLibre.Name = "tbpMercadoLibre"
        Me.tbpMercadoLibre.Size = New System.Drawing.Size(178, 0)
        Me.tbpMercadoLibre.TabIndex = 2
        Me.tbpMercadoLibre.Text = "Mercado Libre"
        '
        'UcConfMercadoLibre1
        '
        Me.UcConfMercadoLibre1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfMercadoLibre1.Location = New System.Drawing.Point(4, 3)
        Me.UcConfMercadoLibre1.Name = "UcConfMercadoLibre1"
        Me.UcConfMercadoLibre1.Size = New System.Drawing.Size(910, 404)
        Me.UcConfMercadoLibre1.TabIndex = 0
        '
        'tbpArborea
        '
        Me.tbpArborea.BackColor = System.Drawing.SystemColors.Control
        Me.tbpArborea.Controls.Add(Me.UcConfArborea1)
        Me.tbpArborea.Location = New System.Drawing.Point(4, 22)
        Me.tbpArborea.Name = "tbpArborea"
        Me.tbpArborea.Size = New System.Drawing.Size(178, 0)
        Me.tbpArborea.TabIndex = 3
        Me.tbpArborea.Text = "Arborea"
        '
        'UcConfArborea1
        '
        Me.UcConfArborea1.BackColor = System.Drawing.SystemColors.Control
        Me.UcConfArborea1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfArborea1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfArborea1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfArborea1.Name = "UcConfArborea1"
        Me.UcConfArborea1.Size = New System.Drawing.Size(178, 0)
        Me.UcConfArborea1.TabIndex = 0
        '
        'tbpGenerales
        '
        Me.tbpGenerales.Controls.Add(Me.UcConfGenerales1)
        Me.tbpGenerales.Location = New System.Drawing.Point(4, 73)
        Me.tbpGenerales.Name = "tbpGenerales"
        Me.tbpGenerales.Size = New System.Drawing.Size(931, 442)
        Me.tbpGenerales.TabIndex = 30
        Me.tbpGenerales.Text = "Generales"
        Me.tbpGenerales.UseVisualStyleBackColor = True
        '
        'UcConfGenerales1
        '
        Me.UcConfGenerales1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.UcConfGenerales1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConfGenerales1.Location = New System.Drawing.Point(0, 0)
        Me.UcConfGenerales1.Name = "UcConfGenerales1"
        Me.UcConfGenerales1.Size = New System.Drawing.Size(931, 442)
        Me.UcConfGenerales1.TabIndex = 0
        '
        'tbpMRP
        '
        Me.tbpMRP.Controls.Add(Me.UcConfMRP1)
        Me.tbpMRP.Location = New System.Drawing.Point(4, 73)
        Me.tbpMRP.Name = "tbpMRP"
        Me.tbpMRP.Size = New System.Drawing.Size(931, 442)
        Me.tbpMRP.TabIndex = 31
        Me.tbpMRP.Text = "MRP"
        Me.tbpMRP.UseVisualStyleBackColor = True
        '
        'UcConfMRP1
        '
        Me.UcConfMRP1.Location = New System.Drawing.Point(8, 3)
        Me.UcConfMRP1.Name = "UcConfMRP1"
        Me.UcConfMRP1.Size = New System.Drawing.Size(915, 431)
        Me.UcConfMRP1.TabIndex = 0
        '
        'lnkRoelaSirPlus
        '
        Me.lnkRoelaSirPlus.Location = New System.Drawing.Point(387, 34)
        Me.lnkRoelaSirPlus.Name = "lnkRoelaSirPlus"
        Me.lnkRoelaSirPlus.Size = New System.Drawing.Size(521, 19)
        Me.lnkRoelaSirPlus.TabIndex = 25
        Me.lnkRoelaSirPlus.TabStop = True
        Me.lnkRoelaSirPlus.Text = "Las opciones de Roela y SirPlus se movieron a la solapa Cobranzas Electrónicas de" &
    " C.C. Clientes"
        Me.lnkRoelaSirPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ParametrosDelUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 547)
        Me.Controls.Add(Me.tbcParametros)
        Me.Controls.Add(Me.tspFacturacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ParametrosDelUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ºº"
        Me.Text = "Parametros"
        Me.tspFacturacion.ResumeLayout(False)
        Me.tspFacturacion.PerformLayout()
        Me.tbcParametros.ResumeLayout(False)
        Me.tbpDatosEmpresa.ResumeLayout(False)
        Me.tbpFichas.ResumeLayout(False)
        Me.tbpPedidos.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.tbpPedidosGeneral.ResumeLayout(False)
        Me.tbpPedidosWeb.ResumeLayout(False)
        Me.tbpPedidosWeb.PerformLayout()
        Me.tbpPedidosVisualizacion.ResumeLayout(False)
        Me.tbpPedidosProveedor.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.tpPedidosProv.ResumeLayout(False)
        Me.tpPedidosProvVisualizacion.ResumeLayout(False)
        Me.tpPedidosProvRequerimiento.ResumeLayout(False)
        Me.tbpVentas.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.tbpFactElectronica.ResumeLayout(False)
        Me.tbpCompras.ResumeLayout(False)
        Me.tbpStock.ResumeLayout(False)
        Me.tbpPrecios.ResumeLayout(False)
        Me.tbcPrecios.ResumeLayout(False)
        Me.tbpPrecios1.ResumeLayout(False)
        Me.tbpPrecios2.ResumeLayout(False)
        Me.tbpCtaCteClientes.ResumeLayout(False)
        Me.tbcCtaCteClientes.ResumeLayout(False)
        Me.tbpCtaCteClientes_General.ResumeLayout(False)
        Me.tbpCtaCteClientes_General2.ResumeLayout(False)
        Me.tbpCtaCteClientes_DebitoAutomatico.ResumeLayout(False)
        Me.tbpCtaCteClientes_Informes.ResumeLayout(False)
        Me.tbpArchivos.ResumeLayout(False)
        Me.tbcArchivos.ResumeLayout(False)
        Me.tbpArchivosGeneral.ResumeLayout(False)
        Me.tbpArchivosClientes.ResumeLayout(False)
        Me.tbpArchivosProductos.ResumeLayout(False)
        Me.tbpArchivosWeb.ResumeLayout(False)
        Me.tbpArchivosSync.ResumeLayout(False)
        Me.tbpCtaCteProveedores.ResumeLayout(False)
        Me.tbpCaja.ResumeLayout(False)
        Me.tbpBanco.ResumeLayout(False)
        Me.tbpProcesos.ResumeLayout(False)
        Me.tbpSueldos.ResumeLayout(False)
        Me.tbpRMA.ResumeLayout(False)
        Me.tbpProduccion.ResumeLayout(False)
        Me.tbpContabilidad.ResumeLayout(False)
        Me.tbpCargos.ResumeLayout(False)
        Me.tbpCRM.ResumeLayout(False)
        Me.tbcCRM.ResumeLayout(False)
        Me.tbpCRMGenerales.ResumeLayout(False)
        Me.tbpCRMCorreos.ResumeLayout(False)
        Me.tbpAFIP.ResumeLayout(False)
        Me.tbpTurnos.ResumeLayout(False)
        Me.tbpEstadisticas.ResumeLayout(False)
        Me.tbpAplicacionesMoviles.ResumeLayout(False)
        Me.tbcAplicacionesMoviles.ResumeLayout(False)
        Me.tbpAplicacionesMoviles_CobranzasPedidos.ResumeLayout(False)
        Me.tbpAplicacionesMoviles_CobranzasPedidos.PerformLayout()
        Me.tbpAplicacionesMoviles_Urls.ResumeLayout(False)
        Me.tbpAplicacionesMoviles_Soporte.ResumeLayout(False)
        Me.tbpAplicacionesMoviles_Soporte.PerformLayout()
        Me.TabPage10.ResumeLayout(False)
        Me.tbpLogistica.ResumeLayout(False)
        Me.tbpCalidad.ResumeLayout(False)
        Me.tbpTurismo.ResumeLayout(False)
        Me.tpTiendaWeb.ResumeLayout(False)
        Me.TblTiendasWeb.ResumeLayout(False)
        Me.tbpTiendaNube.ResumeLayout(False)
        Me.tbpMercadoLibre.ResumeLayout(False)
        Me.tbpArborea.ResumeLayout(False)
        Me.tbpGenerales.ResumeLayout(False)
        Me.tbpMRP.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ofdArchivos As System.Windows.Forms.OpenFileDialog
   Friend WithEvents tbpProduccion As System.Windows.Forms.TabPage
    Friend WithEvents tbpRMA As System.Windows.Forms.TabPage
    Friend WithEvents tbpSueldos As System.Windows.Forms.TabPage
    Friend WithEvents tbpProcesos As System.Windows.Forms.TabPage
    Friend WithEvents tbpArchivos As System.Windows.Forms.TabPage
    Friend WithEvents tbpBanco As System.Windows.Forms.TabPage
    Friend WithEvents tbpCaja As System.Windows.Forms.TabPage
    Friend WithEvents tbpCtaCteProveedores As System.Windows.Forms.TabPage
    Friend WithEvents tbpCtaCteClientes As System.Windows.Forms.TabPage
    Friend WithEvents tbpPrecios As System.Windows.Forms.TabPage
    Friend WithEvents tbpStock As System.Windows.Forms.TabPage
    Friend WithEvents tbpCompras As System.Windows.Forms.TabPage
    Friend WithEvents tbpFactElectronica As System.Windows.Forms.TabPage
    Friend WithEvents tbpVentas As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tbpPedidosProveedor As System.Windows.Forms.TabPage
    Friend WithEvents tbpPedidos As System.Windows.Forms.TabPage
    Friend WithEvents tbpDatosEmpresa As System.Windows.Forms.TabPage
    Friend WithEvents tbcParametros As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents tbpContabilidad As System.Windows.Forms.TabPage
    Friend WithEvents tbpCargos As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents tbpCRM As System.Windows.Forms.TabPage
    Friend WithEvents tbpAFIP As System.Windows.Forms.TabPage
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tbpPedidosGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tbpPedidosWeb As System.Windows.Forms.TabPage
    Friend WithEvents tbcArchivos As System.Windows.Forms.TabControl
    Friend WithEvents tbpArchivosGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tbpArchivosWeb As System.Windows.Forms.TabPage
    Friend WithEvents tbpArchivosProductos As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents tbpFichas As System.Windows.Forms.TabPage
    Friend WithEvents tbpTurnos As System.Windows.Forms.TabPage
    Friend WithEvents tbcCtaCteClientes As System.Windows.Forms.TabControl
    Friend WithEvents tbpCtaCteClientes_General As System.Windows.Forms.TabPage
    Friend WithEvents tbpCtaCteClientes_DebitoAutomatico As System.Windows.Forms.TabPage
    Friend WithEvents tbpAplicacionesMoviles_CobranzasPedidos As System.Windows.Forms.TabPage
    Friend WithEvents tbpEstadisticas As System.Windows.Forms.TabPage
    Friend WithEvents tbpPedidosVisualizacion As System.Windows.Forms.TabPage
    Friend WithEvents tbpCtaCteClientes_Informes As System.Windows.Forms.TabPage
    Friend WithEvents tbcCRM As System.Windows.Forms.TabControl
    Friend WithEvents tbpCRMGenerales As System.Windows.Forms.TabPage
    Friend WithEvents tbpCRMCorreos As System.Windows.Forms.TabPage
    Friend WithEvents tbpAplicacionesMoviles As System.Windows.Forms.TabPage
    Friend WithEvents tbcAplicacionesMoviles As System.Windows.Forms.TabControl
    Friend WithEvents tbpAplicacionesMoviles_Soporte As System.Windows.Forms.TabPage
    Friend WithEvents tbpLogistica As System.Windows.Forms.TabPage
    Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents tbpCalidad As System.Windows.Forms.TabPage
    Friend WithEvents ofdEjecutableTareaProgramada As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbpTurismo As System.Windows.Forms.TabPage
    Friend WithEvents tbpArchivosSync As System.Windows.Forms.TabPage
    Friend WithEvents tbpAplicacionesMoviles_Urls As System.Windows.Forms.TabPage
    Friend WithEvents lnkSimovilURLBase_01 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSimovilURLBase_02 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSimovilURLBase_03 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSimovilURLBase_04 As System.Windows.Forms.LinkLabel
    Friend WithEvents TabPage10 As System.Windows.Forms.TabPage

    Friend WithEvents tpTiendaWeb As System.Windows.Forms.TabPage
    Friend WithEvents tbpGenerales As System.Windows.Forms.TabPage
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents tpPedidosProv As TabPage
    Friend WithEvents tpPedidosProvVisualizacion As TabPage
    Friend WithEvents UcConfCaja1 As ucConfCaja
    Friend WithEvents UcConfBanco1 As ucConfBanco
    Friend WithEvents UcConfProcesos1 As ucConfProcesos
    Friend WithEvents UcConfVentas11 As ucConfVentas1
    Friend WithEvents UcConfVentas21 As ucConfVentas2
    Friend WithEvents UcConfVentas31 As ucConfVentas3
    Friend WithEvents UcConfVentas41 As ucConfVentas4
    Friend WithEvents UcConfVentasCajero1 As ucConfVentasCajero
    Friend WithEvents UcConfVentasVisualizacion1 As ucConfVentasVisualizacion
    Friend WithEvents UcConfFacturacionElectronica1 As ucConfFacturacionElectronica
    Friend WithEvents UcConfRMA1 As ucConfRMA
    Friend WithEvents UcConfCalidad1 As ucConfCalidad
    Friend WithEvents UcConfAppMovilesConfiguraciones1 As ucConfAppMovilesConfiguraciones
    Friend WithEvents UcConfAppMovilesURLsBase1 As ucConfAppMovilesURLsBase
    Friend WithEvents UcConfAppMovilesSoporte1 As ucConfAppMovilesSoporte
    Friend WithEvents UcConfAppMovilesFTP1 As ucConfAppMovilesFTP
    Friend WithEvents UcConfArchivosWeb1 As ucConfArchivosWeb
    Friend WithEvents UcConfArchivos1 As ucConfArchivos
    Friend WithEvents UcConfArchivosProductos1 As ucConfArchivosProductos
    Friend WithEvents UcConfArchivosSync1 As ucConfArchivosSync
    Friend WithEvents UcConfCRMGenerales1 As ucConfCRMGenerales
    Friend WithEvents UcConfCRMEnvioCorreo1 As ucConfCRMEnvioCorreo
    Friend WithEvents TblTiendasWeb As TabControl
    Friend WithEvents tbpTiendaNube As TabPage
    Friend WithEvents tbpMercadoLibre As TabPage
    Friend WithEvents UcConfTiendaNube1 As ucConfTiendaNube
    Friend WithEvents UcConfMercadoLibre1 As ucConfMercadoLibre
    Friend WithEvents UcConfGenerales1 As ucConfGenerales
    Friend WithEvents UcConfAFIP1 As ucConfAFIP
    Friend WithEvents tbpArborea As TabPage
    Friend WithEvents UcConfArborea1 As ucConfArborea
    Friend WithEvents UcConfVentasFacturacionRapida1 As ucConfVentasFacturacionRapida
    Friend WithEvents UcConfVentasImpresion1 As ucConfVentasImpresion
    Friend WithEvents UcConfVentasExportacion1 As ucConfVentasExportacion
    Friend WithEvents UcConfTurnos1 As ucConfTurnos
    Friend WithEvents UcConfEstadisticas1 As ucConfEstadisticas
    Friend WithEvents UcConfTurismo1 As ucConfTurismo
    Friend WithEvents UcConfFichas1 As ucConfFichas
    Friend WithEvents UcConfCompras1 As ucConfCompras
    Friend WithEvents UcConfPedidosPedidos1 As ucConfPedidosPedidos
    Friend WithEvents UcConfPedidosWeb1 As ucConfPedidosWeb
    Friend WithEvents UcConfPedidosVisualizacion1 As ucConfPedidosVisualizacion
    Friend WithEvents UcConfLogistica1 As ucConfLogistica
    Friend WithEvents UcConfCargos1 As ucConfCargos
    Friend WithEvents UcConfProduccion1 As ucConfProduccion
    Friend WithEvents UcConfDatosEmpresa1 As ucConfDatosEmpresa
    Friend WithEvents UcConfPedidosProvPedidosProv1 As ucConfPedidosProvPedidosProv
    Friend WithEvents UcConfPedidosProvVisualizacion1 As ucConfPedidosProvVisualizacion
    Friend WithEvents UcConfStock1 As ucConfStock
    Friend WithEvents UcConfCtaCteProv1 As ucConfCtaCteProv
    Friend WithEvents UcConfSueldos1 As ucConfSueldos
    Friend WithEvents UcConfContabilidad1 As ucConfContabilidad
    Friend WithEvents UcConfCtaCteClienteGeneral1 As ucConfCtaCteClienteGeneral
    Friend WithEvents UcConfCtaCteClienteDebitoAutomatico1 As ucConfCtaCteClienteDebitoAutomatico
    Friend WithEvents UcConfCtaCteClienteInformes1 As ucConfCtaCteClienteInformes
    Friend WithEvents UcConfPrecios1 As ucConfPrecios
    Friend WithEvents tbpArchivosClientes As TabPage
    Friend WithEvents UcConfArchivosClientes1 As ucConfArchivosClientes
    Friend WithEvents tbcPrecios As TabControl
    Friend WithEvents tbpPrecios1 As TabPage
    Friend WithEvents tbpPrecios2 As TabPage
    Friend WithEvents UcConfPrecios21 As ucConfPrecios2
    Friend WithEvents tbpMRP As TabPage
    Friend WithEvents UcConfMRP1 As ucConfMRP
    Friend WithEvents tpPedidosProvRequerimiento As TabPage
    Friend WithEvents UcConfPedidosProvRequerimiento1 As ucConfPedidosProvRequerimiento
    Friend WithEvents tbpCtaCteClientes_General2 As TabPage
    Friend WithEvents UcConfCtaCteClienteGeneral21 As ucConfCtaCteClienteGeneral2
    Friend WithEvents lnkRoelaSirPlus As LinkLabel
End Class
