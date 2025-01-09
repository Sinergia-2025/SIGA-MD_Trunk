<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportarClientesWeb
   Inherits Eniac.Win.BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
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
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Productos", -1)
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraFiscal")
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Telefono")
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Celular")
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdZonaGeografica")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaNacimiento")
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CorreoElectronico")
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTrabajo")
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DireccionTrabajo")
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TelefonoTrabajo")
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CorreoTrabajo")
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidadTrabajo")
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidadTrabajo")
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaIngresoTrabajo")
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoPendiente")
      Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdClienteGarante")
      Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoGarante")
      Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreGarante")
      Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoria")
      Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
      Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
      Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
      Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LimiteDeCredito")
      Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalAsociada")
      Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursalAsociada")
      Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCaja")
      Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCaja")
      Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc")
      Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
      Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdtipoComprobante")
      Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
      Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
      Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
      Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
      Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Foto")
      Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Activo")
      Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IngresosBrutos")
      Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("InscriptoIBStaFe")
      Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LocalIB")
      Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ConvMultilateralIB")
      Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroLote")
      Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GeoLocalizacionLat")
      Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GeoLocalizacionLng")
      Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoDeExension")
      Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AnioExension")
      Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroCertExension")
      Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroCertPropio")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Check", 0)
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportarClientesWeb))
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbDescuentoRecargo = New Eniac.Controles.CheckBox()
      Me.txtDescuentoRecargoPorc = New Eniac.Controles.TextBox()
      Me.chbFormaPago = New Eniac.Controles.CheckBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
      Me.cmbActivo = New Eniac.Controles.ComboBox()
      Me.lblActivo = New Eniac.Controles.Label()
      Me.chbListaDePrecios = New Eniac.Controles.CheckBox()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
      Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.txtArchivoDestino = New Eniac.Controles.TextBox()
      Me.lblArchivoDestino = New Eniac.Controles.Label()
      Me.grbFiltros.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.chbDescuentoRecargo)
      Me.grbFiltros.Controls.Add(Me.txtDescuentoRecargoPorc)
      Me.grbFiltros.Controls.Add(Me.chbFormaPago)
      Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
      Me.grbFiltros.Controls.Add(Me.cmbListaDePrecios)
      Me.grbFiltros.Controls.Add(Me.cmbActivo)
      Me.grbFiltros.Controls.Add(Me.lblActivo)
      Me.grbFiltros.Controls.Add(Me.chbListaDePrecios)
      Me.grbFiltros.Controls.Add(Me.chbCategoria)
      Me.grbFiltros.Controls.Add(Me.cmbCategoria)
      Me.grbFiltros.Controls.Add(Me.chbZonaGeografica)
      Me.grbFiltros.Controls.Add(Me.cmbZonaGeografica)
      Me.grbFiltros.Controls.Add(Me.chbVendedor)
      Me.grbFiltros.Controls.Add(Me.cmbVendedor)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(988, 115)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'chbDescuentoRecargo
      '
      Me.chbDescuentoRecargo.AutoSize = True
      Me.chbDescuentoRecargo.BindearPropiedadControl = Nothing
      Me.chbDescuentoRecargo.BindearPropiedadEntidad = Nothing
      Me.chbDescuentoRecargo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbDescuentoRecargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbDescuentoRecargo.IsPK = False
      Me.chbDescuentoRecargo.IsRequired = False
      Me.chbDescuentoRecargo.Key = Nothing
      Me.chbDescuentoRecargo.LabelAsoc = Nothing
      Me.chbDescuentoRecargo.Location = New System.Drawing.Point(314, 88)
      Me.chbDescuentoRecargo.Name = "chbDescuentoRecargo"
      Me.chbDescuentoRecargo.Size = New System.Drawing.Size(106, 17)
      Me.chbDescuentoRecargo.TabIndex = 22
      Me.chbDescuentoRecargo.Text = "Desc. / Recargo"
      Me.chbDescuentoRecargo.UseVisualStyleBackColor = True
      '
      'txtDescuentoRecargoPorc
      '
      Me.txtDescuentoRecargoPorc.BindearPropiedadControl = "Text"
      Me.txtDescuentoRecargoPorc.BindearPropiedadEntidad = "DescuentoRecargoPorc"
      Me.txtDescuentoRecargoPorc.Enabled = False
      Me.txtDescuentoRecargoPorc.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescuentoRecargoPorc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescuentoRecargoPorc.Formato = "##0.00"
      Me.txtDescuentoRecargoPorc.IsDecimal = True
      Me.txtDescuentoRecargoPorc.IsNumber = True
      Me.txtDescuentoRecargoPorc.IsPK = False
      Me.txtDescuentoRecargoPorc.IsRequired = False
      Me.txtDescuentoRecargoPorc.Key = ""
      Me.txtDescuentoRecargoPorc.LabelAsoc = Nothing
      Me.txtDescuentoRecargoPorc.Location = New System.Drawing.Point(425, 86)
      Me.txtDescuentoRecargoPorc.MaxLength = 6
      Me.txtDescuentoRecargoPorc.Name = "txtDescuentoRecargoPorc"
      Me.txtDescuentoRecargoPorc.Size = New System.Drawing.Size(56, 20)
      Me.txtDescuentoRecargoPorc.TabIndex = 21
      Me.txtDescuentoRecargoPorc.Text = "0.00"
      Me.txtDescuentoRecargoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbFormaPago
      '
      Me.chbFormaPago.AutoSize = True
      Me.chbFormaPago.BindearPropiedadControl = Nothing
      Me.chbFormaPago.BindearPropiedadEntidad = Nothing
      Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFormaPago.IsPK = False
      Me.chbFormaPago.IsRequired = False
      Me.chbFormaPago.Key = Nothing
      Me.chbFormaPago.LabelAsoc = Nothing
      Me.chbFormaPago.Location = New System.Drawing.Point(10, 88)
      Me.chbFormaPago.Name = "chbFormaPago"
      Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
      Me.chbFormaPago.TabIndex = 19
      Me.chbFormaPago.Text = "Forma de Pago"
      Me.chbFormaPago.UseVisualStyleBackColor = True
      '
      'cmbFormaPago
      '
      Me.cmbFormaPago.BindearPropiedadControl = "SelectedValue"
      Me.cmbFormaPago.BindearPropiedadEntidad = "IdFormasPago"
      Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormaPago.Enabled = False
      Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormaPago.FormattingEnabled = True
      Me.cmbFormaPago.IsPK = False
      Me.cmbFormaPago.IsRequired = False
      Me.cmbFormaPago.Key = Nothing
      Me.cmbFormaPago.LabelAsoc = Nothing
      Me.cmbFormaPago.Location = New System.Drawing.Point(119, 86)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(185, 21)
      Me.cmbFormaPago.TabIndex = 18
      '
      'cmbListaDePrecios
      '
      Me.cmbListaDePrecios.BindearPropiedadControl = Nothing
      Me.cmbListaDePrecios.BindearPropiedadEntidad = Nothing
      Me.cmbListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListaDePrecios.Enabled = False
      Me.cmbListaDePrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbListaDePrecios.FormattingEnabled = True
      Me.cmbListaDePrecios.IsPK = False
      Me.cmbListaDePrecios.IsRequired = False
      Me.cmbListaDePrecios.Key = Nothing
      Me.cmbListaDePrecios.LabelAsoc = Nothing
      Me.cmbListaDePrecios.Location = New System.Drawing.Point(681, 55)
      Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
      Me.cmbListaDePrecios.Size = New System.Drawing.Size(180, 21)
      Me.cmbListaDePrecios.TabIndex = 14
      '
      'cmbActivo
      '
      Me.cmbActivo.BindearPropiedadControl = Nothing
      Me.cmbActivo.BindearPropiedadEntidad = Nothing
      Me.cmbActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbActivo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbActivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbActivo.FormattingEnabled = True
      Me.cmbActivo.IsPK = False
      Me.cmbActivo.IsRequired = False
      Me.cmbActivo.Key = Nothing
      Me.cmbActivo.LabelAsoc = Me.lblActivo
      Me.cmbActivo.Location = New System.Drawing.Point(545, 86)
      Me.cmbActivo.Name = "cmbActivo"
      Me.cmbActivo.Size = New System.Drawing.Size(83, 21)
      Me.cmbActivo.TabIndex = 17
      '
      'lblActivo
      '
      Me.lblActivo.AutoSize = True
      Me.lblActivo.LabelAsoc = Nothing
      Me.lblActivo.Location = New System.Drawing.Point(504, 90)
      Me.lblActivo.Name = "lblActivo"
      Me.lblActivo.Size = New System.Drawing.Size(37, 13)
      Me.lblActivo.TabIndex = 16
      Me.lblActivo.Text = "Activo"
      '
      'chbListaDePrecios
      '
      Me.chbListaDePrecios.AutoSize = True
      Me.chbListaDePrecios.BindearPropiedadControl = Nothing
      Me.chbListaDePrecios.BindearPropiedadEntidad = Nothing
      Me.chbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
      Me.chbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbListaDePrecios.IsPK = False
      Me.chbListaDePrecios.IsRequired = False
      Me.chbListaDePrecios.Key = Nothing
      Me.chbListaDePrecios.LabelAsoc = Nothing
      Me.chbListaDePrecios.Location = New System.Drawing.Point(579, 57)
      Me.chbListaDePrecios.Name = "chbListaDePrecios"
      Me.chbListaDePrecios.Size = New System.Drawing.Size(101, 17)
      Me.chbListaDePrecios.TabIndex = 13
      Me.chbListaDePrecios.Text = "Lista de Precios"
      Me.chbListaDePrecios.UseVisualStyleBackColor = True
      '
      'chbCategoria
      '
      Me.chbCategoria.AutoSize = True
      Me.chbCategoria.BindearPropiedadControl = Nothing
      Me.chbCategoria.BindearPropiedadEntidad = Nothing
      Me.chbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCategoria.IsPK = False
      Me.chbCategoria.IsRequired = False
      Me.chbCategoria.Key = Nothing
      Me.chbCategoria.LabelAsoc = Nothing
      Me.chbCategoria.Location = New System.Drawing.Point(314, 57)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
      Me.chbCategoria.TabIndex = 11
      Me.chbCategoria.Text = "Categoria"
      Me.chbCategoria.UseVisualStyleBackColor = True
      '
      'cmbCategoria
      '
      Me.cmbCategoria.BindearPropiedadControl = "SelectedValue"
      Me.cmbCategoria.BindearPropiedadEntidad = "Categoria.IdCategoria"
      Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoria.Enabled = False
      Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoria.FormattingEnabled = True
      Me.cmbCategoria.IsPK = False
      Me.cmbCategoria.IsRequired = True
      Me.cmbCategoria.Key = Nothing
      Me.cmbCategoria.LabelAsoc = Nothing
      Me.cmbCategoria.Location = New System.Drawing.Point(389, 55)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(174, 21)
      Me.cmbCategoria.TabIndex = 12
      '
      'chbZonaGeografica
      '
      Me.chbZonaGeografica.AutoSize = True
      Me.chbZonaGeografica.BindearPropiedadControl = Nothing
      Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
      Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbZonaGeografica.IsPK = False
      Me.chbZonaGeografica.IsRequired = False
      Me.chbZonaGeografica.Key = Nothing
      Me.chbZonaGeografica.LabelAsoc = Nothing
      Me.chbZonaGeografica.Location = New System.Drawing.Point(10, 57)
      Me.chbZonaGeografica.Name = "chbZonaGeografica"
      Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
      Me.chbZonaGeografica.TabIndex = 9
      Me.chbZonaGeografica.Text = "Zona Geográfica"
      Me.chbZonaGeografica.UseVisualStyleBackColor = True
      '
      'cmbZonaGeografica
      '
      Me.cmbZonaGeografica.BindearPropiedadControl = Nothing
      Me.cmbZonaGeografica.BindearPropiedadEntidad = Nothing
      Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbZonaGeografica.Enabled = False
      Me.cmbZonaGeografica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbZonaGeografica.FormattingEnabled = True
      Me.cmbZonaGeografica.IsPK = False
      Me.cmbZonaGeografica.IsRequired = False
      Me.cmbZonaGeografica.Key = Nothing
      Me.cmbZonaGeografica.LabelAsoc = Nothing
      Me.cmbZonaGeografica.Location = New System.Drawing.Point(119, 55)
      Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
      Me.cmbZonaGeografica.Size = New System.Drawing.Size(185, 21)
      Me.cmbZonaGeografica.TabIndex = 10
      '
      'chbVendedor
      '
      Me.chbVendedor.AutoSize = True
      Me.chbVendedor.BindearPropiedadControl = Nothing
      Me.chbVendedor.BindearPropiedadEntidad = Nothing
      Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVendedor.IsPK = False
      Me.chbVendedor.IsRequired = False
      Me.chbVendedor.Key = Nothing
      Me.chbVendedor.LabelAsoc = Nothing
      Me.chbVendedor.Location = New System.Drawing.Point(649, 30)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 7
      Me.chbVendedor.Text = "Vendedor"
      Me.chbVendedor.UseVisualStyleBackColor = True
      '
      'cmbVendedor
      '
      Me.cmbVendedor.BindearPropiedadControl = Nothing
      Me.cmbVendedor.BindearPropiedadEntidad = Nothing
      Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVendedor.Enabled = False
      Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedor.FormattingEnabled = True
      Me.cmbVendedor.IsPK = False
      Me.cmbVendedor.IsRequired = False
      Me.cmbVendedor.Key = Nothing
      Me.cmbVendedor.LabelAsoc = Nothing
      Me.cmbVendedor.Location = New System.Drawing.Point(726, 28)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(197, 21)
      Me.cmbVendedor.TabIndex = 8
      '
      'chbCliente
      '
      Me.chbCliente.AutoSize = True
      Me.chbCliente.BindearPropiedadControl = Nothing
      Me.chbCliente.BindearPropiedadEntidad = Nothing
      Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCliente.IsPK = False
      Me.chbCliente.IsRequired = False
      Me.chbCliente.Key = Nothing
      Me.chbCliente.LabelAsoc = Nothing
      Me.chbCliente.Location = New System.Drawing.Point(10, 30)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 0
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasAlineacion = Nothing
      Me.bscCodigoCliente.ColumnasAncho = Nothing
      Me.bscCodigoCliente.ColumnasFormato = Nothing
      Me.bscCodigoCliente.ColumnasOcultas = Nothing
      Me.bscCodigoCliente.ColumnasTitulos = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(119, 28)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 4
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(116, 13)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 3
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.AutoSize = True
      Me.bscCliente.AyudaAncho = 608
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasAlineacion = Nothing
      Me.bscCliente.ColumnasAncho = Nothing
      Me.bscCliente.ColumnasFormato = Nothing
      Me.bscCliente.ColumnasOcultas = Nothing
      Me.bscCliente.ColumnasTitulos = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.Enabled = False
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Me.lblNombre
      Me.bscCliente.Location = New System.Drawing.Point(216, 27)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 6
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(213, 13)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 5
      Me.lblNombre.Text = "Nombre"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(871, 64)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 15
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator3, Me.tsbRefrescar, Me.tsbExportar, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1012, 29)
      Me.tstBarra.TabIndex = 5
      Me.tstBarra.Text = "toolStrip1"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'tsbExportar
      '
      Me.tsbExportar.Enabled = False
      Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
      Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbExportar.Name = "tsbExportar"
      Me.tsbExportar.Size = New System.Drawing.Size(118, 26)
      Me.tsbExportar.Text = "&Generar Archivo"
      Me.tsbExportar.ToolTipText = "Imprimir"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 501)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(1012, 22)
      Me.stsStado.TabIndex = 4
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(933, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'chbTodos
      '
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(12, 158)
      Me.chbTodos.Margin = New System.Windows.Forms.Padding(2)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(122, 17)
      Me.chbTodos.TabIndex = 22
      Me.chbTodos.Text = "Chequear todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn33.Header.VisiblePosition = 3
      UltraGridColumn33.Hidden = True
      UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn34.Header.Caption = "Codigo"
      UltraGridColumn34.Header.VisiblePosition = 2
      UltraGridColumn34.Width = 135
      UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn35.Header.Caption = "Cliente"
      UltraGridColumn35.Header.VisiblePosition = 4
      UltraGridColumn35.Width = 166
      UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn36.Header.VisiblePosition = 5
      UltraGridColumn36.Hidden = True
      UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn37.Header.VisiblePosition = 6
      UltraGridColumn37.Width = 147
      UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn38.Header.Caption = "CP"
      UltraGridColumn38.Header.VisiblePosition = 7
      UltraGridColumn38.Width = 52
      UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn39.Header.Caption = "Localidad"
      UltraGridColumn39.Header.VisiblePosition = 8
      UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn40.Header.VisiblePosition = 17
      UltraGridColumn40.Hidden = True
      UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn41.Header.VisiblePosition = 18
      UltraGridColumn41.Hidden = True
      UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn42.Header.Caption = "CategoriaFiscal"
      UltraGridColumn42.Header.VisiblePosition = 13
      UltraGridColumn42.Width = 113
      UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn43.Header.VisiblePosition = 19
      UltraGridColumn43.Hidden = True
      UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn44.Header.VisiblePosition = 1
      UltraGridColumn44.Width = 124
      UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn45.Header.Caption = "Tipo Doc"
      UltraGridColumn45.Header.VisiblePosition = 20
      UltraGridColumn45.Width = 54
      UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn46.Header.Caption = "Nro Doc"
      UltraGridColumn46.Header.VisiblePosition = 21
      UltraGridColumn46.Width = 107
      UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn47.Header.VisiblePosition = 9
      UltraGridColumn47.Width = 104
      UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn48.Header.VisiblePosition = 10
      UltraGridColumn48.Width = 107
      UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn49.Header.VisiblePosition = 22
      UltraGridColumn49.Hidden = True
      UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn50.Header.Caption = "Zona Geografica"
      UltraGridColumn50.Header.VisiblePosition = 16
      UltraGridColumn50.Width = 119
      UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn51.Header.VisiblePosition = 23
      UltraGridColumn51.Hidden = True
      UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn52.Header.VisiblePosition = 24
      UltraGridColumn52.Hidden = True
      UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn53.Header.Caption = "Correo Electronico"
      UltraGridColumn53.Header.VisiblePosition = 11
      UltraGridColumn53.Width = 156
      UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn54.Header.VisiblePosition = 25
      UltraGridColumn54.Hidden = True
      UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn55.Header.VisiblePosition = 26
      UltraGridColumn55.Hidden = True
      UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn56.Header.VisiblePosition = 27
      UltraGridColumn56.Hidden = True
      UltraGridColumn57.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn57.Header.VisiblePosition = 28
      UltraGridColumn57.Hidden = True
      UltraGridColumn58.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn58.Header.VisiblePosition = 29
      UltraGridColumn58.Hidden = True
      UltraGridColumn59.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn59.Header.VisiblePosition = 30
      UltraGridColumn59.Hidden = True
      UltraGridColumn60.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn60.Header.VisiblePosition = 31
      UltraGridColumn60.Hidden = True
      UltraGridColumn61.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn61.Header.VisiblePosition = 32
      UltraGridColumn61.Hidden = True
      UltraGridColumn62.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn62.Header.VisiblePosition = 33
      UltraGridColumn62.Hidden = True
      UltraGridColumn63.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn63.Header.VisiblePosition = 34
      UltraGridColumn63.Hidden = True
      UltraGridColumn64.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn64.Header.VisiblePosition = 35
      UltraGridColumn64.Hidden = True
      UltraGridColumn65.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn65.Header.VisiblePosition = 36
      UltraGridColumn65.Hidden = True
      UltraGridColumn66.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn66.Header.VisiblePosition = 37
      UltraGridColumn66.Hidden = True
      UltraGridColumn67.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn67.Header.Caption = "Categoria"
      UltraGridColumn67.Header.VisiblePosition = 12
      UltraGridColumn67.Width = 122
      UltraGridColumn68.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn68.Header.VisiblePosition = 38
      UltraGridColumn68.Width = 179
      UltraGridColumn69.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn69.Header.VisiblePosition = 39
      UltraGridColumn69.Hidden = True
      UltraGridColumn70.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn70.Header.Caption = "Lista de Precios"
      UltraGridColumn70.Header.VisiblePosition = 15
      UltraGridColumn73.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn73.Header.Caption = "Vendedor"
      UltraGridColumn73.Header.VisiblePosition = 14
      UltraGridColumn73.Width = 129
      UltraGridColumn100.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn100.Header.VisiblePosition = 40
      UltraGridColumn100.Hidden = True
      UltraGridColumn101.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn101.Header.VisiblePosition = 41
      UltraGridColumn101.Hidden = True
      UltraGridColumn76.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn76.Header.VisiblePosition = 42
      UltraGridColumn76.Hidden = True
      UltraGridColumn102.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn102.Header.VisiblePosition = 43
      UltraGridColumn102.Hidden = True
      UltraGridColumn78.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn78.Header.VisiblePosition = 44
      UltraGridColumn78.Hidden = True
      UltraGridColumn103.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn103.Header.VisiblePosition = 45
      UltraGridColumn103.Hidden = True
      UltraGridColumn104.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn104.Header.VisiblePosition = 46
      UltraGridColumn104.Hidden = True
      UltraGridColumn105.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn105.Header.VisiblePosition = 47
      UltraGridColumn105.Hidden = True
      UltraGridColumn106.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn106.Header.VisiblePosition = 48
      UltraGridColumn106.Hidden = True
      UltraGridColumn107.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn107.Header.VisiblePosition = 49
      UltraGridColumn107.Hidden = True
      UltraGridColumn84.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn84.Header.VisiblePosition = 50
      UltraGridColumn84.Hidden = True
      UltraGridColumn85.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn85.Header.VisiblePosition = 51
      UltraGridColumn85.Hidden = True
      UltraGridColumn86.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn86.Header.VisiblePosition = 52
      UltraGridColumn86.Hidden = True
      UltraGridColumn108.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn108.Header.VisiblePosition = 53
      UltraGridColumn108.Hidden = True
      UltraGridColumn88.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn88.Header.VisiblePosition = 54
      UltraGridColumn88.Hidden = True
      UltraGridColumn89.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn89.Header.VisiblePosition = 55
      UltraGridColumn89.Hidden = True
      UltraGridColumn90.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn90.Header.VisiblePosition = 56
      UltraGridColumn90.Hidden = True
      UltraGridColumn91.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn91.Header.VisiblePosition = 57
      UltraGridColumn91.Hidden = True
      UltraGridColumn92.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn92.Header.VisiblePosition = 58
      UltraGridColumn92.Hidden = True
      UltraGridColumn94.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn94.Header.VisiblePosition = 59
      UltraGridColumn94.Hidden = True
      UltraGridColumn95.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn95.Header.VisiblePosition = 60
      UltraGridColumn95.Hidden = True
      UltraGridColumn96.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn96.Header.VisiblePosition = 61
      UltraGridColumn96.Hidden = True
      UltraGridColumn97.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn97.Header.VisiblePosition = 62
      UltraGridColumn97.Hidden = True
      UltraGridColumn98.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn98.Header.VisiblePosition = 63
      UltraGridColumn98.Hidden = True
      UltraGridColumn99.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn99.Header.VisiblePosition = 64
      UltraGridColumn99.Hidden = True
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Header.Caption = "Id Vendedor"
      UltraGridColumn1.Header.VisiblePosition = 65
      UltraGridColumn1.Hidden = True
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn26.CellAppearance = Appearance3
      UltraGridColumn26.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
      UltraGridColumn26.DataType = GetType(Boolean)
      UltraGridColumn26.Header.Caption = ""
      UltraGridColumn26.Header.VisiblePosition = 0
      UltraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn26.Width = 32
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn73, UltraGridColumn100, UltraGridColumn101, UltraGridColumn76, UltraGridColumn102, UltraGridColumn78, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn108, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn1, UltraGridColumn26})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance4.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance4
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna para agrupar"
      Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance6.BackColor2 = System.Drawing.SystemColors.Control
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance7
      Appearance8.BackColor = System.Drawing.SystemColors.Highlight
      Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance9
      Appearance10.BorderColor = System.Drawing.Color.Silver
      Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance11.BackColor = System.Drawing.SystemColors.Control
      Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance11
      Appearance12.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 180)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(988, 272)
      Me.ugDetalle.TabIndex = 37
      Me.ugDetalle.Text = "UltraGrid1"
      Me.ugDetalle.UseAppStyling = False
      '
      'btnExaminar
      '
      Me.btnExaminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar.Location = New System.Drawing.Point(581, 458)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(98, 40)
      Me.btnExaminar.TabIndex = 40
      Me.btnExaminar.Text = "&Examinar..."
      Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar.UseVisualStyleBackColor = True
      '
      'txtArchivoDestino
      '
      Me.txtArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtArchivoDestino.BindearPropiedadControl = ""
      Me.txtArchivoDestino.BindearPropiedadEntidad = ""
      Me.txtArchivoDestino.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoDestino.Formato = ""
      Me.txtArchivoDestino.IsDecimal = False
      Me.txtArchivoDestino.IsNumber = False
      Me.txtArchivoDestino.IsPK = False
      Me.txtArchivoDestino.IsRequired = False
      Me.txtArchivoDestino.Key = ""
      Me.txtArchivoDestino.LabelAsoc = Me.lblArchivoDestino
      Me.txtArchivoDestino.Location = New System.Drawing.Point(101, 470)
      Me.txtArchivoDestino.Name = "txtArchivoDestino"
      Me.txtArchivoDestino.Size = New System.Drawing.Size(463, 20)
      Me.txtArchivoDestino.TabIndex = 39
      '
      'lblArchivoDestino
      '
      Me.lblArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblArchivoDestino.AutoSize = True
      Me.lblArchivoDestino.LabelAsoc = Nothing
      Me.lblArchivoDestino.Location = New System.Drawing.Point(10, 473)
      Me.lblArchivoDestino.Name = "lblArchivoDestino"
      Me.lblArchivoDestino.Size = New System.Drawing.Size(85, 13)
      Me.lblArchivoDestino.TabIndex = 38
      Me.lblArchivoDestino.Text = "Archivo Destino:"
      '
      'ExportarClientesWeb
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1012, 523)
      Me.Controls.Add(Me.btnExaminar)
      Me.Controls.Add(Me.txtArchivoDestino)
      Me.Controls.Add(Me.lblArchivoDestino)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.chbTodos)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ExportarClientesWeb"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Exportar Clientes a Web"
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents chbListaDePrecios As Eniac.Controles.CheckBox
   Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents cmbActivo As Eniac.Controles.ComboBox
   Friend WithEvents lblActivo As Eniac.Controles.Label
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Public WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbDescuentoRecargo As Eniac.Controles.CheckBox
   Friend WithEvents txtDescuentoRecargoPorc As Eniac.Controles.TextBox
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnExaminar As Eniac.Controles.Button
   Friend WithEvents txtArchivoDestino As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestino As Eniac.Controles.Label
End Class
