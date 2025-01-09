<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TiposComprobantesDetalle
    Inherits Eniac.Win.BaseDetalle

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selecciono")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tipo")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Grupo")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro_SN")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsRecibo_SN")
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TiposComprobantesDetalle))
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblId = New Eniac.Controles.Label()
        Me.txtCategoria = New Eniac.Controles.TextBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.txtDescripcion = New Eniac.Controles.TextBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.txtTipo = New Eniac.Controles.TextBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.Label6 = New Eniac.Controles.Label()
        Me.txtLetrasHabilitadas = New Eniac.Controles.TextBox()
        Me.Label7 = New Eniac.Controles.Label()
        Me.txtCantMaxItems = New Eniac.Controles.TextBox()
        Me.Label9 = New Eniac.Controles.Label()
        Me.Label10 = New Eniac.Controles.Label()
        Me.Label15 = New Eniac.Controles.Label()
        Me.txtDescripAbrev = New Eniac.Controles.TextBox()
        Me.Label17 = New Eniac.Controles.Label()
        Me.txtCantidadCopias = New Eniac.Controles.TextBox()
        Me.chbGrabaLibro = New Eniac.Controles.CheckBox()
        Me.chbImprime = New Eniac.Controles.CheckBox()
        Me.chbAfectaCaja = New Eniac.Controles.CheckBox()
        Me.chbActualizaCtaCte = New Eniac.Controles.CheckBox()
        Me.chbEsFiscal = New Eniac.Controles.CheckBox()
        Me.chbEsFacturador = New Eniac.Controles.CheckBox()
        Me.chbCargaPrecioActual = New Eniac.Controles.CheckBox()
        Me.chbPuedeSerBorrado = New Eniac.Controles.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chbSolicitaInformeCalidad = New Eniac.Controles.CheckBox()
        Me.chbActivaTildeMercDespEnv = New Eniac.Controles.CheckBox()
        Me.chbSolicitaFechaDevolucion = New Eniac.Controles.CheckBox()
        Me.chbInformaLibroIVA = New Eniac.Controles.CheckBox()
        Me.chbImportaObsGrales = New Eniac.Controles.CheckBox()
        Me.chbPermiteSeleccionarAlicuotaIVA = New Eniac.Controles.CheckBox()
        Me.chbMarcaInvocado = New Eniac.Controles.CheckBox()
        Me.chbEsReciboClienteVinculado = New Eniac.Controles.CheckBox()
        Me.chbCargaDescRecGralActual = New Eniac.Controles.CheckBox()
        Me.chbControlaTopeConsumidorFinal = New Eniac.Controles.CheckBox()
        Me.CheckBox7 = New Eniac.Controles.CheckBox()
        Me.CheckBox6 = New Eniac.Controles.CheckBox()
        Me.CheckBox2 = New Eniac.Controles.CheckBox()
        Me.chbUtilizaCtaSecundariaCateg = New Eniac.Controles.CheckBox()
        Me.chbUtilizaCtaSecundariaProd = New Eniac.Controles.CheckBox()
        Me.CheckBox1 = New Eniac.Controles.CheckBox()
        Me.chbGeneraContabilidad = New Eniac.Controles.CheckBox()
        Me.chbEsRecibo = New Eniac.Controles.CheckBox()
        Me.chbEsAnticipo = New Eniac.Controles.CheckBox()
        Me.chbEsPreElectronico = New Eniac.Controles.CheckBox()
        Me.chbNumeracionAutomatica = New Eniac.Controles.CheckBox()
        Me.chbIncluirEnExpensas = New Eniac.Controles.CheckBox()
        Me.chbDespachoImportacion = New Eniac.Controles.CheckBox()
        Me.chbUtilizaImpuestos = New Eniac.Controles.CheckBox()
        Me.chbEsElectronico = New Eniac.Controles.CheckBox()
        Me.CheckBox5 = New Eniac.Controles.CheckBox()
        Me.CheckBox4 = New Eniac.Controles.CheckBox()
        Me.CheckBox3 = New Eniac.Controles.CheckBox()
        Me.chbConsumePedidos = New Eniac.Controles.CheckBox()
        Me.chbEsComercial = New Eniac.Controles.CheckBox()
        Me.chbEsRemitoTransportista = New Eniac.Controles.CheckBox()
        Me.chbUsaFacturacion = New Eniac.Controles.CheckBox()
        Me.chbGeneraObservConInvocados = New Eniac.Controles.CheckBox()
        Me.chbUsaFacturacionRapida = New Eniac.Controles.CheckBox()
        Me.chbCargaDescRecActual = New Eniac.Controles.CheckBox()
        Me.Label4 = New Eniac.Controles.Label()
        Me.txtCantidadMaximaItemsObserv = New Eniac.Controles.TextBox()
        Me.Label8 = New Eniac.Controles.Label()
        Me.txtImporteTope = New Eniac.Controles.TextBox()
        Me.Label11 = New Eniac.Controles.Label()
        Me.txtIdTipoComprobanteEpson = New Eniac.Controles.TextBox()
        Me.Label12 = New Eniac.Controles.Label()
        Me.txtImporteMinimo = New Eniac.Controles.TextBox()
        Me.Label13 = New Eniac.Controles.Label()
        Me.Label14 = New Eniac.Controles.Label()
        Me.txtGrupo = New Eniac.Controles.TextBox()
        Me.txtIdPlanCuenta = New Eniac.Controles.TextBox()
        Me.chbComprobanteSecundario = New Eniac.Controles.CheckBox()
        Me.chbTipoComprobanteNCred = New Eniac.Controles.CheckBox()
        Me.chbTipoComprobanteNDeb = New Eniac.Controles.CheckBox()
        Me.bscCodigoProducto2Cred = New Eniac.Controles.Buscador2()
        Me.bscProducto2Cred = New Eniac.Controles.Buscador2()
        Me.chbCodigoProducto2Cred = New Eniac.Controles.CheckBox()
        Me.chbCodigoProducto2Deb = New Eniac.Controles.CheckBox()
        Me.bscCodigoProducto2Deb = New Eniac.Controles.Buscador2()
        Me.bscProducto2Deb = New Eniac.Controles.Buscador2()
        Me.txtCodigoComprobanteSifere = New Eniac.Controles.TextBox()
        Me.lblCodigoComprobanteSifere = New Eniac.Controles.Label()
        Me.chbTipoComprobanteContraMovInvocar = New Eniac.Controles.CheckBox()
        Me.txtLargoMaximoNumero = New Eniac.Controles.TextBox()
        Me.lblLargoMaximoNumero = New Eniac.Controles.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtNivelAutorizacion = New Eniac.Controles.TextBox()
        Me.lblNivelAutorizacion = New Eniac.Controles.Label()
        Me.tbcComporbantes = New System.Windows.Forms.TabControl()
        Me.tbpDetalle = New System.Windows.Forms.TabPage()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.cmbCoeficienteStock = New Eniac.Controles.ComboBox()
        Me.cmbCoefValores = New Eniac.Controles.ComboBox()
        Me.cmbModificaAlFacturar = New Eniac.Controles.ComboBox()
        Me.cmbTipoComprobanteNDeb = New Eniac.Controles.ComboBox()
        Me.cmbTipoComprobanteNCred = New Eniac.Controles.ComboBox()
        Me.cmbTipoComprobanteContraMovInvocar = New Eniac.Controles.ComboBox()
        Me.tbpCompAsoci = New System.Windows.Forms.TabPage()
        Me.ugComprobantesAsociados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpProducto = New System.Windows.Forms.TabPage()
        Me.lblCodProducto = New Eniac.Controles.Label()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.txtCantidad = New Eniac.Controles.TextBox()
        Me.lblCantidad = New Eniac.Controles.Label()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.btnEliminarContacto = New Eniac.Controles.Button()
        Me.btnInsertarProducto = New Eniac.Controles.Button()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.btnLimpiarProducto = New Eniac.Controles.Button()
        Me.ugProductoDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpAFIP = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblIncluyeFechaVencimiento = New Eniac.Controles.Label()
        Me.CheckBox8 = New Eniac.Controles.CheckBox()
        Me.chbAFIPWSRequiereReferenciaComercial = New Eniac.Controles.CheckBox()
        Me.cmbAFIPWSIncluyeFechaVencimiento = New Eniac.Controles.ComboBox()
        Me.chbAFIPWSCodigoAnulacion = New Eniac.Controles.CheckBox()
        Me.chbAFIPWSRequiereCBU = New Eniac.Controles.CheckBox()
        Me.chbAFIPWSRequiereComprobanteAsociado = New Eniac.Controles.CheckBox()
        Me.chbAFIPWSEsFEC = New Eniac.Controles.CheckBox()
        Me.tbpExportaciones = New System.Windows.Forms.TabPage()
        Me.txtCodigoRoela = New Eniac.Controles.TextBox()
        Me.lblCodigoRoela = New Eniac.Controles.Label()
        Me.lblOrdeTipoComprobante = New Eniac.Controles.Label()
        Me.txtOrdenTipoComprobante = New Eniac.Controles.TextBox()
        Me.lblDescripcionImpresion = New Eniac.Controles.Label()
        Me.txtDescripcionImpresion = New Eniac.Controles.TextBox()
        Me.txtColor = New Eniac.Controles.TextBox()
        Me.chbColor = New Eniac.Controles.CheckBox()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.lblClaseComprobante = New Eniac.Controles.Label()
        Me.cmbClaseComprobante = New Eniac.Controles.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.tbcComporbantes.SuspendLayout()
        Me.tbpDetalle.SuspendLayout()
        Me.tbpCompAsoci.SuspendLayout()
        CType(Me.ugComprobantesAsociados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpProducto.SuspendLayout()
        CType(Me.ugProductoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpAFIP.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbpExportaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(705, 542)
        Me.btnAceptar.TabIndex = 25
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(791, 542)
        Me.btnCancelar.TabIndex = 26
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(604, 542)
        Me.btnCopiar.TabIndex = 28
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(544, 542)
        Me.btnAplicar.TabIndex = 27
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(23, 10)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(94, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Tipo Comprobante"
        '
        'txtCategoria
        '
        Me.txtCategoria.BindearPropiedadControl = "Text"
        Me.txtCategoria.BindearPropiedadEntidad = "IdTipoComprobante"
        Me.txtCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCategoria.Formato = ""
        Me.txtCategoria.IsDecimal = False
        Me.txtCategoria.IsNumber = False
        Me.txtCategoria.IsPK = True
        Me.txtCategoria.IsRequired = True
        Me.txtCategoria.Key = ""
        Me.txtCategoria.LabelAsoc = Me.lblId
        Me.txtCategoria.Location = New System.Drawing.Point(120, 5)
        Me.txtCategoria.MaxLength = 15
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(127, 20)
        Me.txtCategoria.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(23, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = ""
        Me.txtDescripcion.LabelAsoc = Me.Label1
        Me.txtDescripcion.Location = New System.Drawing.Point(120, 29)
        Me.txtDescripcion.MaxLength = 25
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(305, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(23, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Tipo"
        '
        'txtTipo
        '
        Me.txtTipo.BindearPropiedadControl = "Text"
        Me.txtTipo.BindearPropiedadEntidad = "Tipo"
        Me.txtTipo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipo.Formato = ""
        Me.txtTipo.IsDecimal = False
        Me.txtTipo.IsNumber = False
        Me.txtTipo.IsPK = False
        Me.txtTipo.IsRequired = True
        Me.txtTipo.Key = ""
        Me.txtTipo.LabelAsoc = Me.Label2
        Me.txtTipo.Location = New System.Drawing.Point(120, 53)
        Me.txtTipo.MaxLength = 15
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(127, 20)
        Me.txtTipo.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(44, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Coeficiente Stock"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(672, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Letras Hab."
        '
        'txtLetrasHabilitadas
        '
        Me.txtLetrasHabilitadas.BindearPropiedadControl = "Text"
        Me.txtLetrasHabilitadas.BindearPropiedadEntidad = "LetrasHabilitadas"
        Me.txtLetrasHabilitadas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLetrasHabilitadas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLetrasHabilitadas.Formato = ""
        Me.txtLetrasHabilitadas.IsDecimal = False
        Me.txtLetrasHabilitadas.IsNumber = False
        Me.txtLetrasHabilitadas.IsPK = False
        Me.txtLetrasHabilitadas.IsRequired = False
        Me.txtLetrasHabilitadas.Key = ""
        Me.txtLetrasHabilitadas.LabelAsoc = Me.Label6
        Me.txtLetrasHabilitadas.Location = New System.Drawing.Point(749, 53)
        Me.txtLetrasHabilitadas.MaxLength = 15
        Me.txtLetrasHabilitadas.Name = "txtLetrasHabilitadas"
        Me.txtLetrasHabilitadas.Size = New System.Drawing.Size(70, 20)
        Me.txtLetrasHabilitadas.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(280, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Cantidad máxima de Items"
        '
        'txtCantMaxItems
        '
        Me.txtCantMaxItems.BindearPropiedadControl = "Text"
        Me.txtCantMaxItems.BindearPropiedadEntidad = "CantidadMaximaItems"
        Me.txtCantMaxItems.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantMaxItems.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantMaxItems.Formato = ""
        Me.txtCantMaxItems.IsDecimal = False
        Me.txtCantMaxItems.IsNumber = False
        Me.txtCantMaxItems.IsPK = False
        Me.txtCantMaxItems.IsRequired = False
        Me.txtCantMaxItems.Key = ""
        Me.txtCantMaxItems.LabelAsoc = Me.Label7
        Me.txtCantMaxItems.Location = New System.Drawing.Point(414, 4)
        Me.txtCantMaxItems.MaxLength = 15
        Me.txtCantMaxItems.Name = "txtCantMaxItems"
        Me.txtCantMaxItems.Size = New System.Drawing.Size(40, 20)
        Me.txtCantMaxItems.TabIndex = 18
        Me.txtCantMaxItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.LabelAsoc = Nothing
        Me.Label9.Location = New System.Drawing.Point(44, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Coeficiente Valores"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.LabelAsoc = Nothing
        Me.Label10.Location = New System.Drawing.Point(42, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Modifica al Facturar"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label15.LabelAsoc = Nothing
        Me.Label15.Location = New System.Drawing.Point(440, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Descripción abrev"
        '
        'txtDescripAbrev
        '
        Me.txtDescripAbrev.BindearPropiedadControl = "Text"
        Me.txtDescripAbrev.BindearPropiedadEntidad = "DescripcionAbrev"
        Me.txtDescripAbrev.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripAbrev.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripAbrev.Formato = ""
        Me.txtDescripAbrev.IsDecimal = False
        Me.txtDescripAbrev.IsNumber = False
        Me.txtDescripAbrev.IsPK = False
        Me.txtDescripAbrev.IsRequired = True
        Me.txtDescripAbrev.Key = ""
        Me.txtDescripAbrev.LabelAsoc = Me.Label15
        Me.txtDescripAbrev.Location = New System.Drawing.Point(546, 29)
        Me.txtDescripAbrev.MaxLength = 10
        Me.txtDescripAbrev.Name = "txtDescripAbrev"
        Me.txtDescripAbrev.Size = New System.Drawing.Size(104, 20)
        Me.txtDescripAbrev.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.LabelAsoc = Nothing
        Me.Label17.Location = New System.Drawing.Point(280, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 13)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "Cantidad copias"
        '
        'txtCantidadCopias
        '
        Me.txtCantidadCopias.BindearPropiedadControl = "Text"
        Me.txtCantidadCopias.BindearPropiedadEntidad = "CantidadCopias"
        Me.txtCantidadCopias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadCopias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadCopias.Formato = ""
        Me.txtCantidadCopias.IsDecimal = False
        Me.txtCantidadCopias.IsNumber = False
        Me.txtCantidadCopias.IsPK = False
        Me.txtCantidadCopias.IsRequired = False
        Me.txtCantidadCopias.Key = ""
        Me.txtCantidadCopias.LabelAsoc = Me.Label17
        Me.txtCantidadCopias.Location = New System.Drawing.Point(414, 28)
        Me.txtCantidadCopias.MaxLength = 15
        Me.txtCantidadCopias.Name = "txtCantidadCopias"
        Me.txtCantidadCopias.Size = New System.Drawing.Size(40, 20)
        Me.txtCantidadCopias.TabIndex = 26
        Me.txtCantidadCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbGrabaLibro
        '
        Me.chbGrabaLibro.AutoSize = True
        Me.chbGrabaLibro.BindearPropiedadControl = "Checked"
        Me.chbGrabaLibro.BindearPropiedadEntidad = "GrabaLibro"
        Me.chbGrabaLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGrabaLibro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGrabaLibro.IsPK = False
        Me.chbGrabaLibro.IsRequired = False
        Me.chbGrabaLibro.Key = Nothing
        Me.chbGrabaLibro.LabelAsoc = Nothing
        Me.chbGrabaLibro.Location = New System.Drawing.Point(10, 11)
        Me.chbGrabaLibro.Name = "chbGrabaLibro"
        Me.chbGrabaLibro.Size = New System.Drawing.Size(81, 17)
        Me.chbGrabaLibro.TabIndex = 0
        Me.chbGrabaLibro.Text = "Graba Libro"
        Me.chbGrabaLibro.UseVisualStyleBackColor = True
        '
        'chbImprime
        '
        Me.chbImprime.AutoSize = True
        Me.chbImprime.BindearPropiedadControl = "Checked"
        Me.chbImprime.BindearPropiedadEntidad = "Imprime"
        Me.chbImprime.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImprime.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImprime.IsPK = False
        Me.chbImprime.IsRequired = False
        Me.chbImprime.Key = Nothing
        Me.chbImprime.LabelAsoc = Nothing
        Me.chbImprime.Location = New System.Drawing.Point(310, 126)
        Me.chbImprime.Name = "chbImprime"
        Me.chbImprime.Size = New System.Drawing.Size(62, 17)
        Me.chbImprime.TabIndex = 22
        Me.chbImprime.Text = "Imprime"
        Me.chbImprime.UseVisualStyleBackColor = True
        '
        'chbAfectaCaja
        '
        Me.chbAfectaCaja.AutoSize = True
        Me.chbAfectaCaja.BindearPropiedadControl = "Checked"
        Me.chbAfectaCaja.BindearPropiedadEntidad = "AfectaCaja"
        Me.chbAfectaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAfectaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAfectaCaja.IsPK = False
        Me.chbAfectaCaja.IsRequired = False
        Me.chbAfectaCaja.Key = Nothing
        Me.chbAfectaCaja.LabelAsoc = Nothing
        Me.chbAfectaCaja.Location = New System.Drawing.Point(10, 57)
        Me.chbAfectaCaja.Name = "chbAfectaCaja"
        Me.chbAfectaCaja.Size = New System.Drawing.Size(81, 17)
        Me.chbAfectaCaja.TabIndex = 2
        Me.chbAfectaCaja.Text = "Afecta Caja"
        Me.chbAfectaCaja.UseVisualStyleBackColor = True
        '
        'chbActualizaCtaCte
        '
        Me.chbActualizaCtaCte.AutoSize = True
        Me.chbActualizaCtaCte.BindearPropiedadControl = "Checked"
        Me.chbActualizaCtaCte.BindearPropiedadEntidad = "ActualizaCtaCte"
        Me.chbActualizaCtaCte.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizaCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizaCtaCte.IsPK = False
        Me.chbActualizaCtaCte.IsRequired = False
        Me.chbActualizaCtaCte.Key = Nothing
        Me.chbActualizaCtaCte.LabelAsoc = Nothing
        Me.chbActualizaCtaCte.Location = New System.Drawing.Point(10, 80)
        Me.chbActualizaCtaCte.Name = "chbActualizaCtaCte"
        Me.chbActualizaCtaCte.Size = New System.Drawing.Size(113, 17)
        Me.chbActualizaCtaCte.TabIndex = 3
        Me.chbActualizaCtaCte.Text = "Actualiza Cta. Cte."
        Me.chbActualizaCtaCte.UseVisualStyleBackColor = True
        '
        'chbEsFiscal
        '
        Me.chbEsFiscal.AutoSize = True
        Me.chbEsFiscal.BindearPropiedadControl = "Checked"
        Me.chbEsFiscal.BindearPropiedadEntidad = "EsFiscal"
        Me.chbEsFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsFiscal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsFiscal.IsPK = False
        Me.chbEsFiscal.IsRequired = False
        Me.chbEsFiscal.Key = Nothing
        Me.chbEsFiscal.LabelAsoc = Nothing
        Me.chbEsFiscal.Location = New System.Drawing.Point(10, 103)
        Me.chbEsFiscal.Name = "chbEsFiscal"
        Me.chbEsFiscal.Size = New System.Drawing.Size(68, 17)
        Me.chbEsFiscal.TabIndex = 4
        Me.chbEsFiscal.Text = "Es Fiscal"
        Me.chbEsFiscal.UseVisualStyleBackColor = True
        '
        'chbEsFacturador
        '
        Me.chbEsFacturador.AutoSize = True
        Me.chbEsFacturador.BindearPropiedadControl = "Checked"
        Me.chbEsFacturador.BindearPropiedadEntidad = "EsFacturador"
        Me.chbEsFacturador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsFacturador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsFacturador.IsPK = False
        Me.chbEsFacturador.IsRequired = False
        Me.chbEsFacturador.Key = Nothing
        Me.chbEsFacturador.LabelAsoc = Nothing
        Me.chbEsFacturador.Location = New System.Drawing.Point(465, 11)
        Me.chbEsFacturador.Name = "chbEsFacturador"
        Me.chbEsFacturador.Size = New System.Drawing.Size(92, 17)
        Me.chbEsFacturador.TabIndex = 25
        Me.chbEsFacturador.Text = "Es Facturador"
        Me.chbEsFacturador.UseVisualStyleBackColor = True
        '
        'chbCargaPrecioActual
        '
        Me.chbCargaPrecioActual.AutoSize = True
        Me.chbCargaPrecioActual.BindearPropiedadControl = "Checked"
        Me.chbCargaPrecioActual.BindearPropiedadEntidad = "CargaPrecioActual"
        Me.chbCargaPrecioActual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCargaPrecioActual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCargaPrecioActual.IsPK = False
        Me.chbCargaPrecioActual.IsRequired = False
        Me.chbCargaPrecioActual.Key = Nothing
        Me.chbCargaPrecioActual.LabelAsoc = Nothing
        Me.chbCargaPrecioActual.Location = New System.Drawing.Point(465, 149)
        Me.chbCargaPrecioActual.Name = "chbCargaPrecioActual"
        Me.chbCargaPrecioActual.Size = New System.Drawing.Size(120, 17)
        Me.chbCargaPrecioActual.TabIndex = 31
        Me.chbCargaPrecioActual.Text = "Carga Precio Actual"
        Me.chbCargaPrecioActual.UseVisualStyleBackColor = True
        '
        'chbPuedeSerBorrado
        '
        Me.chbPuedeSerBorrado.AutoSize = True
        Me.chbPuedeSerBorrado.BindearPropiedadControl = "Checked"
        Me.chbPuedeSerBorrado.BindearPropiedadEntidad = "PuedeSerBorrado"
        Me.chbPuedeSerBorrado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPuedeSerBorrado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPuedeSerBorrado.IsPK = False
        Me.chbPuedeSerBorrado.IsRequired = False
        Me.chbPuedeSerBorrado.Key = Nothing
        Me.chbPuedeSerBorrado.LabelAsoc = Nothing
        Me.chbPuedeSerBorrado.Location = New System.Drawing.Point(310, 103)
        Me.chbPuedeSerBorrado.Name = "chbPuedeSerBorrado"
        Me.chbPuedeSerBorrado.Size = New System.Drawing.Size(113, 17)
        Me.chbPuedeSerBorrado.TabIndex = 21
        Me.chbPuedeSerBorrado.Text = "Puede ser borrado"
        Me.chbPuedeSerBorrado.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chbSolicitaInformeCalidad)
        Me.GroupBox1.Controls.Add(Me.chbActivaTildeMercDespEnv)
        Me.GroupBox1.Controls.Add(Me.chbSolicitaFechaDevolucion)
        Me.GroupBox1.Controls.Add(Me.chbInformaLibroIVA)
        Me.GroupBox1.Controls.Add(Me.chbImportaObsGrales)
        Me.GroupBox1.Controls.Add(Me.chbPermiteSeleccionarAlicuotaIVA)
        Me.GroupBox1.Controls.Add(Me.chbMarcaInvocado)
        Me.GroupBox1.Controls.Add(Me.chbEsReciboClienteVinculado)
        Me.GroupBox1.Controls.Add(Me.chbCargaDescRecGralActual)
        Me.GroupBox1.Controls.Add(Me.chbControlaTopeConsumidorFinal)
        Me.GroupBox1.Controls.Add(Me.CheckBox7)
        Me.GroupBox1.Controls.Add(Me.CheckBox6)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.chbUtilizaCtaSecundariaCateg)
        Me.GroupBox1.Controls.Add(Me.chbUtilizaCtaSecundariaProd)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.chbGeneraContabilidad)
        Me.GroupBox1.Controls.Add(Me.chbEsRecibo)
        Me.GroupBox1.Controls.Add(Me.chbEsAnticipo)
        Me.GroupBox1.Controls.Add(Me.chbEsPreElectronico)
        Me.GroupBox1.Controls.Add(Me.chbNumeracionAutomatica)
        Me.GroupBox1.Controls.Add(Me.chbIncluirEnExpensas)
        Me.GroupBox1.Controls.Add(Me.chbDespachoImportacion)
        Me.GroupBox1.Controls.Add(Me.chbUtilizaImpuestos)
        Me.GroupBox1.Controls.Add(Me.chbEsElectronico)
        Me.GroupBox1.Controls.Add(Me.CheckBox5)
        Me.GroupBox1.Controls.Add(Me.CheckBox4)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.chbConsumePedidos)
        Me.GroupBox1.Controls.Add(Me.chbEsComercial)
        Me.GroupBox1.Controls.Add(Me.chbEsRemitoTransportista)
        Me.GroupBox1.Controls.Add(Me.chbUsaFacturacion)
        Me.GroupBox1.Controls.Add(Me.chbGeneraObservConInvocados)
        Me.GroupBox1.Controls.Add(Me.chbUsaFacturacionRapida)
        Me.GroupBox1.Controls.Add(Me.chbGrabaLibro)
        Me.GroupBox1.Controls.Add(Me.chbImprime)
        Me.GroupBox1.Controls.Add(Me.chbAfectaCaja)
        Me.GroupBox1.Controls.Add(Me.chbCargaDescRecActual)
        Me.GroupBox1.Controls.Add(Me.chbPuedeSerBorrado)
        Me.GroupBox1.Controls.Add(Me.chbCargaPrecioActual)
        Me.GroupBox1.Controls.Add(Me.chbActualizaCtaCte)
        Me.GroupBox1.Controls.Add(Me.chbEsFiscal)
        Me.GroupBox1.Controls.Add(Me.chbEsFacturador)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(841, 216)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'chbSolicitaInformeCalidad
        '
        Me.chbSolicitaInformeCalidad.AutoSize = True
        Me.chbSolicitaInformeCalidad.BindearPropiedadControl = "Checked"
        Me.chbSolicitaInformeCalidad.BindearPropiedadEntidad = "SolicitaInformeCalidad"
        Me.chbSolicitaInformeCalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaInformeCalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaInformeCalidad.IsPK = False
        Me.chbSolicitaInformeCalidad.IsRequired = False
        Me.chbSolicitaInformeCalidad.Key = Nothing
        Me.chbSolicitaInformeCalidad.LabelAsoc = Nothing
        Me.chbSolicitaInformeCalidad.Location = New System.Drawing.Point(310, 195)
        Me.chbSolicitaInformeCalidad.Name = "chbSolicitaInformeCalidad"
        Me.chbSolicitaInformeCalidad.Size = New System.Drawing.Size(151, 17)
        Me.chbSolicitaInformeCalidad.TabIndex = 42
        Me.chbSolicitaInformeCalidad.Text = "Solicita Informe de Calidad"
        Me.chbSolicitaInformeCalidad.UseVisualStyleBackColor = True
        '
        'chbActivaTildeMercDespEnv
        '
        Me.chbActivaTildeMercDespEnv.AutoSize = True
        Me.chbActivaTildeMercDespEnv.BindearPropiedadControl = "Checked"
        Me.chbActivaTildeMercDespEnv.BindearPropiedadEntidad = "ActivaTildeMercDespacha"
        Me.chbActivaTildeMercDespEnv.CausesValidation = False
        Me.chbActivaTildeMercDespEnv.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivaTildeMercDespEnv.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivaTildeMercDespEnv.IsPK = False
        Me.chbActivaTildeMercDespEnv.IsRequired = False
        Me.chbActivaTildeMercDespEnv.Key = Nothing
        Me.chbActivaTildeMercDespEnv.LabelAsoc = Nothing
        Me.chbActivaTildeMercDespEnv.Location = New System.Drawing.Point(630, 195)
        Me.chbActivaTildeMercDespEnv.Name = "chbActivaTildeMercDespEnv"
        Me.chbActivaTildeMercDespEnv.Size = New System.Drawing.Size(191, 17)
        Me.chbActivaTildeMercDespEnv.TabIndex = 41
        Me.chbActivaTildeMercDespEnv.Text = "Activa tilde Mercadería Desp./Env"
        Me.chbActivaTildeMercDespEnv.UseVisualStyleBackColor = True
        '
        'chbSolicitaFechaDevolucion
        '
        Me.chbSolicitaFechaDevolucion.AutoSize = True
        Me.chbSolicitaFechaDevolucion.BindearPropiedadControl = "Checked"
        Me.chbSolicitaFechaDevolucion.BindearPropiedadEntidad = "SolicitaFechaDevolucion"
        Me.chbSolicitaFechaDevolucion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaFechaDevolucion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaFechaDevolucion.IsPK = False
        Me.chbSolicitaFechaDevolucion.IsRequired = False
        Me.chbSolicitaFechaDevolucion.Key = Nothing
        Me.chbSolicitaFechaDevolucion.LabelAsoc = Nothing
        Me.chbSolicitaFechaDevolucion.Location = New System.Drawing.Point(310, 172)
        Me.chbSolicitaFechaDevolucion.Name = "chbSolicitaFechaDevolucion"
        Me.chbSolicitaFechaDevolucion.Size = New System.Drawing.Size(150, 17)
        Me.chbSolicitaFechaDevolucion.TabIndex = 24
        Me.chbSolicitaFechaDevolucion.Text = "Usa Fecha de Devolución"
        Me.chbSolicitaFechaDevolucion.UseVisualStyleBackColor = True
        '
        'chbInformaLibroIVA
        '
        Me.chbInformaLibroIVA.AutoSize = True
        Me.chbInformaLibroIVA.BindearPropiedadControl = ""
        Me.chbInformaLibroIVA.BindearPropiedadEntidad = ""
        Me.chbInformaLibroIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbInformaLibroIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbInformaLibroIVA.IsPK = False
        Me.chbInformaLibroIVA.IsRequired = False
        Me.chbInformaLibroIVA.Key = Nothing
        Me.chbInformaLibroIVA.LabelAsoc = Nothing
        Me.chbInformaLibroIVA.Location = New System.Drawing.Point(10, 193)
        Me.chbInformaLibroIVA.Name = "chbInformaLibroIVA"
        Me.chbInformaLibroIVA.Size = New System.Drawing.Size(107, 17)
        Me.chbInformaLibroIVA.TabIndex = 8
        Me.chbInformaLibroIVA.Text = "Informa Libro IVA"
        Me.chbInformaLibroIVA.UseVisualStyleBackColor = True
        '
        'chbImportaObsGrales
        '
        Me.chbImportaObsGrales.AutoSize = True
        Me.chbImportaObsGrales.BindearPropiedadControl = "Checked"
        Me.chbImportaObsGrales.BindearPropiedadEntidad = "ImportaObservGrales"
        Me.chbImportaObsGrales.CausesValidation = False
        Me.chbImportaObsGrales.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImportaObsGrales.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImportaObsGrales.IsPK = False
        Me.chbImportaObsGrales.IsRequired = False
        Me.chbImportaObsGrales.Key = Nothing
        Me.chbImportaObsGrales.LabelAsoc = Nothing
        Me.chbImportaObsGrales.Location = New System.Drawing.Point(465, 126)
        Me.chbImportaObsGrales.Name = "chbImportaObsGrales"
        Me.chbImportaObsGrales.Size = New System.Drawing.Size(134, 17)
        Me.chbImportaObsGrales.TabIndex = 30
        Me.chbImportaObsGrales.Text = "Importa Observ Grales."
        Me.chbImportaObsGrales.UseVisualStyleBackColor = True
        '
        'chbPermiteSeleccionarAlicuotaIVA
        '
        Me.chbPermiteSeleccionarAlicuotaIVA.AutoSize = True
        Me.chbPermiteSeleccionarAlicuotaIVA.BindearPropiedadControl = "Checked"
        Me.chbPermiteSeleccionarAlicuotaIVA.BindearPropiedadEntidad = "PermiteSeleccionarAlicuotaIVA"
        Me.chbPermiteSeleccionarAlicuotaIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteSeleccionarAlicuotaIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteSeleccionarAlicuotaIVA.IsPK = False
        Me.chbPermiteSeleccionarAlicuotaIVA.IsRequired = False
        Me.chbPermiteSeleccionarAlicuotaIVA.Key = Nothing
        Me.chbPermiteSeleccionarAlicuotaIVA.LabelAsoc = Nothing
        Me.chbPermiteSeleccionarAlicuotaIVA.Location = New System.Drawing.Point(10, 172)
        Me.chbPermiteSeleccionarAlicuotaIVA.Name = "chbPermiteSeleccionarAlicuotaIVA"
        Me.chbPermiteSeleccionarAlicuotaIVA.Size = New System.Drawing.Size(112, 17)
        Me.chbPermiteSeleccionarAlicuotaIVA.TabIndex = 7
        Me.chbPermiteSeleccionarAlicuotaIVA.Text = "Permite selec. IVA"
        Me.chbPermiteSeleccionarAlicuotaIVA.UseVisualStyleBackColor = True
        '
        'chbMarcaInvocado
        '
        Me.chbMarcaInvocado.AutoSize = True
        Me.chbMarcaInvocado.BindearPropiedadControl = "Checked"
        Me.chbMarcaInvocado.BindearPropiedadEntidad = "MarcaInvocado"
        Me.chbMarcaInvocado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarcaInvocado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarcaInvocado.IsPK = False
        Me.chbMarcaInvocado.IsRequired = False
        Me.chbMarcaInvocado.Key = Nothing
        Me.chbMarcaInvocado.LabelAsoc = Nothing
        Me.chbMarcaInvocado.Location = New System.Drawing.Point(630, 103)
        Me.chbMarcaInvocado.Name = "chbMarcaInvocado"
        Me.chbMarcaInvocado.Size = New System.Drawing.Size(104, 17)
        Me.chbMarcaInvocado.TabIndex = 38
        Me.chbMarcaInvocado.Text = "Marca Invocado"
        Me.chbMarcaInvocado.UseVisualStyleBackColor = True
        '
        'chbEsReciboClienteVinculado
        '
        Me.chbEsReciboClienteVinculado.AutoSize = True
        Me.chbEsReciboClienteVinculado.BindearPropiedadControl = "Checked"
        Me.chbEsReciboClienteVinculado.BindearPropiedadEntidad = "EsReciboClienteVinculado"
        Me.chbEsReciboClienteVinculado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsReciboClienteVinculado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsReciboClienteVinculado.IsPK = False
        Me.chbEsReciboClienteVinculado.IsRequired = False
        Me.chbEsReciboClienteVinculado.Key = Nothing
        Me.chbEsReciboClienteVinculado.LabelAsoc = Nothing
        Me.chbEsReciboClienteVinculado.Location = New System.Drawing.Point(152, 149)
        Me.chbEsReciboClienteVinculado.Name = "chbEsReciboClienteVinculado"
        Me.chbEsReciboClienteVinculado.Size = New System.Drawing.Size(138, 17)
        Me.chbEsReciboClienteVinculado.TabIndex = 16
        Me.chbEsReciboClienteVinculado.Text = "Es Recibo C. Vinculado"
        Me.chbEsReciboClienteVinculado.UseVisualStyleBackColor = True
        '
        'chbCargaDescRecGralActual
        '
        Me.chbCargaDescRecGralActual.AutoSize = True
        Me.chbCargaDescRecGralActual.BindearPropiedadControl = "Checked"
        Me.chbCargaDescRecGralActual.BindearPropiedadEntidad = "CargaDescRecGralActual"
        Me.chbCargaDescRecGralActual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCargaDescRecGralActual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCargaDescRecGralActual.IsPK = False
        Me.chbCargaDescRecGralActual.IsRequired = False
        Me.chbCargaDescRecGralActual.Key = Nothing
        Me.chbCargaDescRecGralActual.LabelAsoc = Nothing
        Me.chbCargaDescRecGralActual.Location = New System.Drawing.Point(465, 195)
        Me.chbCargaDescRecGralActual.Name = "chbCargaDescRecGralActual"
        Me.chbCargaDescRecGralActual.Size = New System.Drawing.Size(133, 17)
        Me.chbCargaDescRecGralActual.TabIndex = 33
        Me.chbCargaDescRecGralActual.Text = "Carga D/R Gral Actual"
        Me.chbCargaDescRecGralActual.UseVisualStyleBackColor = True
        '
        'chbControlaTopeConsumidorFinal
        '
        Me.chbControlaTopeConsumidorFinal.AutoSize = True
        Me.chbControlaTopeConsumidorFinal.BindearPropiedadControl = "Checked"
        Me.chbControlaTopeConsumidorFinal.BindearPropiedadEntidad = "ControlaTopeConsumidorFinal"
        Me.chbControlaTopeConsumidorFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbControlaTopeConsumidorFinal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbControlaTopeConsumidorFinal.IsPK = False
        Me.chbControlaTopeConsumidorFinal.IsRequired = False
        Me.chbControlaTopeConsumidorFinal.Key = Nothing
        Me.chbControlaTopeConsumidorFinal.LabelAsoc = Nothing
        Me.chbControlaTopeConsumidorFinal.Location = New System.Drawing.Point(310, 149)
        Me.chbControlaTopeConsumidorFinal.Name = "chbControlaTopeConsumidorFinal"
        Me.chbControlaTopeConsumidorFinal.Size = New System.Drawing.Size(148, 17)
        Me.chbControlaTopeConsumidorFinal.TabIndex = 23
        Me.chbControlaTopeConsumidorFinal.Text = "Controla Tope Cons. Final"
        Me.chbControlaTopeConsumidorFinal.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.BindearPropiedadControl = "Checked"
        Me.CheckBox7.BindearPropiedadEntidad = "RequiereReferenciaCtaCte"
        Me.CheckBox7.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox7.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox7.IsPK = False
        Me.CheckBox7.IsRequired = False
        Me.CheckBox7.Key = Nothing
        Me.CheckBox7.LabelAsoc = Nothing
        Me.CheckBox7.Location = New System.Drawing.Point(10, 149)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(139, 17)
        Me.CheckBox7.TabIndex = 6
        Me.CheckBox7.Text = "Req. Referencia CtaCte"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.BindearPropiedadControl = "Checked"
        Me.CheckBox6.BindearPropiedadEntidad = "InvocaCompras"
        Me.CheckBox6.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox6.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox6.IsPK = False
        Me.CheckBox6.IsRequired = False
        Me.CheckBox6.Key = Nothing
        Me.CheckBox6.LabelAsoc = Nothing
        Me.CheckBox6.Location = New System.Drawing.Point(465, 57)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(103, 17)
        Me.CheckBox6.TabIndex = 27
        Me.CheckBox6.Text = "Invoca Compras"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BindearPropiedadControl = "Checked"
        Me.CheckBox2.BindearPropiedadEntidad = "EsFacturable"
        Me.CheckBox2.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox2.IsPK = False
        Me.CheckBox2.IsRequired = False
        Me.CheckBox2.Key = Nothing
        Me.CheckBox2.LabelAsoc = Nothing
        Me.CheckBox2.Location = New System.Drawing.Point(465, 34)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(91, 17)
        Me.CheckBox2.TabIndex = 26
        Me.CheckBox2.Text = "Es Facturable"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'chbUtilizaCtaSecundariaCateg
        '
        Me.chbUtilizaCtaSecundariaCateg.AutoSize = True
        Me.chbUtilizaCtaSecundariaCateg.BindearPropiedadControl = "Checked"
        Me.chbUtilizaCtaSecundariaCateg.BindearPropiedadEntidad = "UtilizaCtaSecundariaCateg"
        Me.chbUtilizaCtaSecundariaCateg.CausesValidation = False
        Me.chbUtilizaCtaSecundariaCateg.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUtilizaCtaSecundariaCateg.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUtilizaCtaSecundariaCateg.IsPK = False
        Me.chbUtilizaCtaSecundariaCateg.IsRequired = False
        Me.chbUtilizaCtaSecundariaCateg.Key = Nothing
        Me.chbUtilizaCtaSecundariaCateg.LabelAsoc = Nothing
        Me.chbUtilizaCtaSecundariaCateg.Location = New System.Drawing.Point(630, 172)
        Me.chbUtilizaCtaSecundariaCateg.Name = "chbUtilizaCtaSecundariaCateg"
        Me.chbUtilizaCtaSecundariaCateg.Size = New System.Drawing.Size(156, 17)
        Me.chbUtilizaCtaSecundariaCateg.TabIndex = 0
        Me.chbUtilizaCtaSecundariaCateg.Text = "Utiliza Cta Cble Sec. Categ."
        Me.chbUtilizaCtaSecundariaCateg.UseVisualStyleBackColor = True
        '
        'chbUtilizaCtaSecundariaProd
        '
        Me.chbUtilizaCtaSecundariaProd.AutoSize = True
        Me.chbUtilizaCtaSecundariaProd.BindearPropiedadControl = "Checked"
        Me.chbUtilizaCtaSecundariaProd.BindearPropiedadEntidad = "UtilizaCtaSecundariaProd"
        Me.chbUtilizaCtaSecundariaProd.CausesValidation = False
        Me.chbUtilizaCtaSecundariaProd.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUtilizaCtaSecundariaProd.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUtilizaCtaSecundariaProd.IsPK = False
        Me.chbUtilizaCtaSecundariaProd.IsRequired = False
        Me.chbUtilizaCtaSecundariaProd.Key = Nothing
        Me.chbUtilizaCtaSecundariaProd.LabelAsoc = Nothing
        Me.chbUtilizaCtaSecundariaProd.Location = New System.Drawing.Point(630, 149)
        Me.chbUtilizaCtaSecundariaProd.Name = "chbUtilizaCtaSecundariaProd"
        Me.chbUtilizaCtaSecundariaProd.Size = New System.Drawing.Size(150, 17)
        Me.chbUtilizaCtaSecundariaProd.TabIndex = 40
        Me.chbUtilizaCtaSecundariaProd.Text = "Utiliza Cta Cble Sec. Prod."
        Me.chbUtilizaCtaSecundariaProd.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BindearPropiedadControl = "Checked"
        Me.CheckBox1.BindearPropiedadEntidad = "ImportaObservDeInvocados"
        Me.CheckBox1.CausesValidation = False
        Me.CheckBox1.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox1.IsPK = False
        Me.CheckBox1.IsRequired = False
        Me.CheckBox1.Key = Nothing
        Me.CheckBox1.LabelAsoc = Nothing
        Me.CheckBox1.Location = New System.Drawing.Point(465, 103)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(151, 17)
        Me.CheckBox1.TabIndex = 29
        Me.CheckBox1.Text = "Importa Observ Invocados"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chbGeneraContabilidad
        '
        Me.chbGeneraContabilidad.AutoSize = True
        Me.chbGeneraContabilidad.BindearPropiedadControl = "Checked"
        Me.chbGeneraContabilidad.BindearPropiedadEntidad = "GeneraContabilidad"
        Me.chbGeneraContabilidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGeneraContabilidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGeneraContabilidad.IsPK = False
        Me.chbGeneraContabilidad.IsRequired = False
        Me.chbGeneraContabilidad.Key = Nothing
        Me.chbGeneraContabilidad.LabelAsoc = Nothing
        Me.chbGeneraContabilidad.Location = New System.Drawing.Point(630, 126)
        Me.chbGeneraContabilidad.Name = "chbGeneraContabilidad"
        Me.chbGeneraContabilidad.Size = New System.Drawing.Size(122, 17)
        Me.chbGeneraContabilidad.TabIndex = 39
        Me.chbGeneraContabilidad.Text = "Genera Contabilidad"
        Me.chbGeneraContabilidad.UseVisualStyleBackColor = True
        '
        'chbEsRecibo
        '
        Me.chbEsRecibo.AutoSize = True
        Me.chbEsRecibo.BindearPropiedadControl = "Checked"
        Me.chbEsRecibo.BindearPropiedadEntidad = "EsRecibo"
        Me.chbEsRecibo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsRecibo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsRecibo.IsPK = False
        Me.chbEsRecibo.IsRequired = False
        Me.chbEsRecibo.Key = Nothing
        Me.chbEsRecibo.LabelAsoc = Nothing
        Me.chbEsRecibo.Location = New System.Drawing.Point(152, 11)
        Me.chbEsRecibo.Name = "chbEsRecibo"
        Me.chbEsRecibo.Size = New System.Drawing.Size(75, 17)
        Me.chbEsRecibo.TabIndex = 9
        Me.chbEsRecibo.Text = "Es Recibo"
        Me.chbEsRecibo.UseVisualStyleBackColor = True
        '
        'chbEsAnticipo
        '
        Me.chbEsAnticipo.AutoSize = True
        Me.chbEsAnticipo.BindearPropiedadControl = "Checked"
        Me.chbEsAnticipo.BindearPropiedadEntidad = "EsAnticipo"
        Me.chbEsAnticipo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsAnticipo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsAnticipo.IsPK = False
        Me.chbEsAnticipo.IsRequired = False
        Me.chbEsAnticipo.Key = Nothing
        Me.chbEsAnticipo.LabelAsoc = Nothing
        Me.chbEsAnticipo.Location = New System.Drawing.Point(152, 34)
        Me.chbEsAnticipo.Name = "chbEsAnticipo"
        Me.chbEsAnticipo.Size = New System.Drawing.Size(79, 17)
        Me.chbEsAnticipo.TabIndex = 10
        Me.chbEsAnticipo.Text = "Es Anticipo"
        Me.chbEsAnticipo.UseVisualStyleBackColor = True
        '
        'chbEsPreElectronico
        '
        Me.chbEsPreElectronico.AutoSize = True
        Me.chbEsPreElectronico.BindearPropiedadControl = "Checked"
        Me.chbEsPreElectronico.BindearPropiedadEntidad = "EsPreElectronico"
        Me.chbEsPreElectronico.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsPreElectronico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsPreElectronico.IsPK = False
        Me.chbEsPreElectronico.IsRequired = False
        Me.chbEsPreElectronico.Key = Nothing
        Me.chbEsPreElectronico.LabelAsoc = Nothing
        Me.chbEsPreElectronico.Location = New System.Drawing.Point(152, 80)
        Me.chbEsPreElectronico.Name = "chbEsPreElectronico"
        Me.chbEsPreElectronico.Size = New System.Drawing.Size(110, 17)
        Me.chbEsPreElectronico.TabIndex = 13
        Me.chbEsPreElectronico.Text = "Es PreElectrónico"
        Me.chbEsPreElectronico.UseVisualStyleBackColor = True
        '
        'chbNumeracionAutomatica
        '
        Me.chbNumeracionAutomatica.AutoSize = True
        Me.chbNumeracionAutomatica.BindearPropiedadControl = "Checked"
        Me.chbNumeracionAutomatica.BindearPropiedadEntidad = "NumeracionAutomatica"
        Me.chbNumeracionAutomatica.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeracionAutomatica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeracionAutomatica.IsPK = False
        Me.chbNumeracionAutomatica.IsRequired = False
        Me.chbNumeracionAutomatica.Key = Nothing
        Me.chbNumeracionAutomatica.LabelAsoc = Nothing
        Me.chbNumeracionAutomatica.Location = New System.Drawing.Point(310, 57)
        Me.chbNumeracionAutomatica.Name = "chbNumeracionAutomatica"
        Me.chbNumeracionAutomatica.Size = New System.Drawing.Size(139, 17)
        Me.chbNumeracionAutomatica.TabIndex = 19
        Me.chbNumeracionAutomatica.Text = "Numeración Automática"
        Me.chbNumeracionAutomatica.UseVisualStyleBackColor = True
        '
        'chbIncluirEnExpensas
        '
        Me.chbIncluirEnExpensas.AutoSize = True
        Me.chbIncluirEnExpensas.BindearPropiedadControl = "Checked"
        Me.chbIncluirEnExpensas.BindearPropiedadEntidad = "IncluirEnExpensas"
        Me.chbIncluirEnExpensas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIncluirEnExpensas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIncluirEnExpensas.IsPK = False
        Me.chbIncluirEnExpensas.IsRequired = False
        Me.chbIncluirEnExpensas.Key = Nothing
        Me.chbIncluirEnExpensas.LabelAsoc = Nothing
        Me.chbIncluirEnExpensas.Location = New System.Drawing.Point(310, 80)
        Me.chbIncluirEnExpensas.Name = "chbIncluirEnExpensas"
        Me.chbIncluirEnExpensas.Size = New System.Drawing.Size(117, 17)
        Me.chbIncluirEnExpensas.TabIndex = 20
        Me.chbIncluirEnExpensas.Text = "Incluir en expensas"
        Me.chbIncluirEnExpensas.UseVisualStyleBackColor = True
        '
        'chbDespachoImportacion
        '
        Me.chbDespachoImportacion.AutoSize = True
        Me.chbDespachoImportacion.BindearPropiedadControl = "Checked"
        Me.chbDespachoImportacion.BindearPropiedadEntidad = "EsDespachoImportacion"
        Me.chbDespachoImportacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDespachoImportacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDespachoImportacion.IsPK = False
        Me.chbDespachoImportacion.IsRequired = False
        Me.chbDespachoImportacion.Key = Nothing
        Me.chbDespachoImportacion.LabelAsoc = Nothing
        Me.chbDespachoImportacion.Location = New System.Drawing.Point(152, 126)
        Me.chbDespachoImportacion.Name = "chbDespachoImportacion"
        Me.chbDespachoImportacion.Size = New System.Drawing.Size(148, 17)
        Me.chbDespachoImportacion.TabIndex = 15
        Me.chbDespachoImportacion.Text = "Es Despacho Importación"
        Me.chbDespachoImportacion.UseVisualStyleBackColor = True
        '
        'chbUtilizaImpuestos
        '
        Me.chbUtilizaImpuestos.AutoSize = True
        Me.chbUtilizaImpuestos.BindearPropiedadControl = "Checked"
        Me.chbUtilizaImpuestos.BindearPropiedadEntidad = "UtilizaImpuestos"
        Me.chbUtilizaImpuestos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUtilizaImpuestos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUtilizaImpuestos.IsPK = False
        Me.chbUtilizaImpuestos.IsRequired = False
        Me.chbUtilizaImpuestos.Key = Nothing
        Me.chbUtilizaImpuestos.LabelAsoc = Nothing
        Me.chbUtilizaImpuestos.Location = New System.Drawing.Point(10, 126)
        Me.chbUtilizaImpuestos.Name = "chbUtilizaImpuestos"
        Me.chbUtilizaImpuestos.Size = New System.Drawing.Size(105, 17)
        Me.chbUtilizaImpuestos.TabIndex = 5
        Me.chbUtilizaImpuestos.Text = "Utiliza Impuestos"
        Me.chbUtilizaImpuestos.UseVisualStyleBackColor = True
        '
        'chbEsElectronico
        '
        Me.chbEsElectronico.AutoSize = True
        Me.chbEsElectronico.BindearPropiedadControl = "Checked"
        Me.chbEsElectronico.BindearPropiedadEntidad = "EsElectronico"
        Me.chbEsElectronico.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsElectronico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsElectronico.IsPK = False
        Me.chbEsElectronico.IsRequired = False
        Me.chbEsElectronico.Key = Nothing
        Me.chbEsElectronico.LabelAsoc = Nothing
        Me.chbEsElectronico.Location = New System.Drawing.Point(152, 57)
        Me.chbEsElectronico.Name = "chbEsElectronico"
        Me.chbEsElectronico.Size = New System.Drawing.Size(94, 17)
        Me.chbEsElectronico.TabIndex = 12
        Me.chbEsElectronico.Text = "Es Electrónico"
        Me.chbEsElectronico.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.BindearPropiedadControl = "Checked"
        Me.CheckBox5.BindearPropiedadEntidad = "InvocarPedidosConEstadoEspecifico"
        Me.CheckBox5.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox5.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox5.IsPK = False
        Me.CheckBox5.IsRequired = False
        Me.CheckBox5.Key = Nothing
        Me.CheckBox5.LabelAsoc = Nothing
        Me.CheckBox5.Location = New System.Drawing.Point(630, 80)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(205, 17)
        Me.CheckBox5.TabIndex = 37
        Me.CheckBox5.Text = "Invoca Pedido con Estado específico"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.BindearPropiedadControl = "Checked"
        Me.CheckBox4.BindearPropiedadEntidad = "AlInvocarPedidoAfectaRemito"
        Me.CheckBox4.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox4.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox4.IsPK = False
        Me.CheckBox4.IsRequired = False
        Me.CheckBox4.Key = Nothing
        Me.CheckBox4.LabelAsoc = Nothing
        Me.CheckBox4.Location = New System.Drawing.Point(630, 57)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(187, 17)
        Me.CheckBox4.TabIndex = 36
        Me.CheckBox4.Text = "Al invocar Pedido afecta REMITO"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.BindearPropiedadControl = "Checked"
        Me.CheckBox3.BindearPropiedadEntidad = "AlInvocarPedidoAfectaFactura"
        Me.CheckBox3.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox3.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox3.IsPK = False
        Me.CheckBox3.IsRequired = False
        Me.CheckBox3.Key = Nothing
        Me.CheckBox3.LabelAsoc = Nothing
        Me.CheckBox3.Location = New System.Drawing.Point(630, 34)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(195, 17)
        Me.CheckBox3.TabIndex = 35
        Me.CheckBox3.Text = "Al invocar Pedido afecta FACTURA"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'chbConsumePedidos
        '
        Me.chbConsumePedidos.AutoSize = True
        Me.chbConsumePedidos.BindearPropiedadControl = "Checked"
        Me.chbConsumePedidos.BindearPropiedadEntidad = "ConsumePedidos"
        Me.chbConsumePedidos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConsumePedidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConsumePedidos.IsPK = False
        Me.chbConsumePedidos.IsRequired = False
        Me.chbConsumePedidos.Key = Nothing
        Me.chbConsumePedidos.LabelAsoc = Nothing
        Me.chbConsumePedidos.Location = New System.Drawing.Point(630, 11)
        Me.chbConsumePedidos.Name = "chbConsumePedidos"
        Me.chbConsumePedidos.Size = New System.Drawing.Size(111, 17)
        Me.chbConsumePedidos.TabIndex = 34
        Me.chbConsumePedidos.Text = "Consume Pedidos"
        Me.chbConsumePedidos.UseVisualStyleBackColor = True
        '
        'chbEsComercial
        '
        Me.chbEsComercial.AutoSize = True
        Me.chbEsComercial.BindearPropiedadControl = "Checked"
        Me.chbEsComercial.BindearPropiedadEntidad = "EsComercial"
        Me.chbEsComercial.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsComercial.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsComercial.IsPK = False
        Me.chbEsComercial.IsRequired = False
        Me.chbEsComercial.Key = Nothing
        Me.chbEsComercial.LabelAsoc = Nothing
        Me.chbEsComercial.Location = New System.Drawing.Point(10, 34)
        Me.chbEsComercial.Name = "chbEsComercial"
        Me.chbEsComercial.Size = New System.Drawing.Size(87, 17)
        Me.chbEsComercial.TabIndex = 1
        Me.chbEsComercial.Text = "Es Comercial"
        Me.chbEsComercial.UseVisualStyleBackColor = True
        '
        'chbEsRemitoTransportista
        '
        Me.chbEsRemitoTransportista.AutoSize = True
        Me.chbEsRemitoTransportista.BindearPropiedadControl = "Checked"
        Me.chbEsRemitoTransportista.BindearPropiedadEntidad = "EsRemitoTransportista"
        Me.chbEsRemitoTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsRemitoTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsRemitoTransportista.IsPK = False
        Me.chbEsRemitoTransportista.IsRequired = False
        Me.chbEsRemitoTransportista.Key = Nothing
        Me.chbEsRemitoTransportista.LabelAsoc = Nothing
        Me.chbEsRemitoTransportista.Location = New System.Drawing.Point(152, 103)
        Me.chbEsRemitoTransportista.Name = "chbEsRemitoTransportista"
        Me.chbEsRemitoTransportista.Size = New System.Drawing.Size(138, 17)
        Me.chbEsRemitoTransportista.TabIndex = 14
        Me.chbEsRemitoTransportista.Text = "Es Remito Transportista"
        Me.chbEsRemitoTransportista.UseVisualStyleBackColor = True
        '
        'chbUsaFacturacion
        '
        Me.chbUsaFacturacion.AutoSize = True
        Me.chbUsaFacturacion.BindearPropiedadControl = "Checked"
        Me.chbUsaFacturacion.BindearPropiedadEntidad = "UsaFacturacion"
        Me.chbUsaFacturacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsaFacturacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsaFacturacion.IsPK = False
        Me.chbUsaFacturacion.IsRequired = False
        Me.chbUsaFacturacion.Key = Nothing
        Me.chbUsaFacturacion.LabelAsoc = Nothing
        Me.chbUsaFacturacion.Location = New System.Drawing.Point(310, 11)
        Me.chbUsaFacturacion.Name = "chbUsaFacturacion"
        Me.chbUsaFacturacion.Size = New System.Drawing.Size(104, 17)
        Me.chbUsaFacturacion.TabIndex = 17
        Me.chbUsaFacturacion.Text = "Usa Facturación"
        Me.chbUsaFacturacion.UseVisualStyleBackColor = True
        '
        'chbGeneraObservConInvocados
        '
        Me.chbGeneraObservConInvocados.AutoSize = True
        Me.chbGeneraObservConInvocados.BindearPropiedadControl = "Checked"
        Me.chbGeneraObservConInvocados.BindearPropiedadEntidad = "GeneraObservConInvocados"
        Me.chbGeneraObservConInvocados.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGeneraObservConInvocados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGeneraObservConInvocados.IsPK = False
        Me.chbGeneraObservConInvocados.IsRequired = False
        Me.chbGeneraObservConInvocados.Key = Nothing
        Me.chbGeneraObservConInvocados.LabelAsoc = Nothing
        Me.chbGeneraObservConInvocados.Location = New System.Drawing.Point(465, 80)
        Me.chbGeneraObservConInvocados.Name = "chbGeneraObservConInvocados"
        Me.chbGeneraObservConInvocados.Size = New System.Drawing.Size(149, 17)
        Me.chbGeneraObservConInvocados.TabIndex = 28
        Me.chbGeneraObservConInvocados.Text = "Genera observ Invocados"
        Me.chbGeneraObservConInvocados.UseVisualStyleBackColor = True
        '
        'chbUsaFacturacionRapida
        '
        Me.chbUsaFacturacionRapida.AutoSize = True
        Me.chbUsaFacturacionRapida.BindearPropiedadControl = "Checked"
        Me.chbUsaFacturacionRapida.BindearPropiedadEntidad = "UsaFacturacionRapida"
        Me.chbUsaFacturacionRapida.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsaFacturacionRapida.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsaFacturacionRapida.IsPK = False
        Me.chbUsaFacturacionRapida.IsRequired = False
        Me.chbUsaFacturacionRapida.Key = Nothing
        Me.chbUsaFacturacionRapida.LabelAsoc = Nothing
        Me.chbUsaFacturacionRapida.Location = New System.Drawing.Point(310, 34)
        Me.chbUsaFacturacionRapida.Name = "chbUsaFacturacionRapida"
        Me.chbUsaFacturacionRapida.Size = New System.Drawing.Size(141, 17)
        Me.chbUsaFacturacionRapida.TabIndex = 18
        Me.chbUsaFacturacionRapida.Text = "Usa Facturación Rápida"
        Me.chbUsaFacturacionRapida.UseVisualStyleBackColor = True
        '
        'chbCargaDescRecActual
        '
        Me.chbCargaDescRecActual.AutoSize = True
        Me.chbCargaDescRecActual.BindearPropiedadControl = "Checked"
        Me.chbCargaDescRecActual.BindearPropiedadEntidad = "CargaDescRecActual"
        Me.chbCargaDescRecActual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCargaDescRecActual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCargaDescRecActual.IsPK = False
        Me.chbCargaDescRecActual.IsRequired = False
        Me.chbCargaDescRecActual.Key = Nothing
        Me.chbCargaDescRecActual.LabelAsoc = Nothing
        Me.chbCargaDescRecActual.Location = New System.Drawing.Point(465, 172)
        Me.chbCargaDescRecActual.Name = "chbCargaDescRecActual"
        Me.chbCargaDescRecActual.Size = New System.Drawing.Size(140, 17)
        Me.chbCargaDescRecActual.TabIndex = 32
        Me.chbCargaDescRecActual.Text = "Carga Desc/Rec Actual"
        Me.chbCargaDescRecActual.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(255, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Cantidad máxima de Items obs."
        '
        'txtCantidadMaximaItemsObserv
        '
        Me.txtCantidadMaximaItemsObserv.BindearPropiedadControl = "Text"
        Me.txtCantidadMaximaItemsObserv.BindearPropiedadEntidad = "CantidadMaximaItemsObserv"
        Me.txtCantidadMaximaItemsObserv.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadMaximaItemsObserv.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadMaximaItemsObserv.Formato = ""
        Me.txtCantidadMaximaItemsObserv.IsDecimal = False
        Me.txtCantidadMaximaItemsObserv.IsNumber = False
        Me.txtCantidadMaximaItemsObserv.IsPK = False
        Me.txtCantidadMaximaItemsObserv.IsRequired = False
        Me.txtCantidadMaximaItemsObserv.Key = ""
        Me.txtCantidadMaximaItemsObserv.LabelAsoc = Me.Label4
        Me.txtCantidadMaximaItemsObserv.Location = New System.Drawing.Point(414, 54)
        Me.txtCantidadMaximaItemsObserv.MaxLength = 15
        Me.txtCantidadMaximaItemsObserv.Name = "txtCantidadMaximaItemsObserv"
        Me.txtCantidadMaximaItemsObserv.Size = New System.Drawing.Size(40, 20)
        Me.txtCantidadMaximaItemsObserv.TabIndex = 34
        Me.txtCantidadMaximaItemsObserv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.LabelAsoc = Nothing
        Me.Label8.Location = New System.Drawing.Point(461, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Importe Tope"
        '
        'txtImporteTope
        '
        Me.txtImporteTope.BindearPropiedadControl = "Text"
        Me.txtImporteTope.BindearPropiedadEntidad = "ImporteTope"
        Me.txtImporteTope.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteTope.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteTope.Formato = ""
        Me.txtImporteTope.IsDecimal = False
        Me.txtImporteTope.IsNumber = False
        Me.txtImporteTope.IsPK = False
        Me.txtImporteTope.IsRequired = False
        Me.txtImporteTope.Key = ""
        Me.txtImporteTope.LabelAsoc = Me.Label8
        Me.txtImporteTope.Location = New System.Drawing.Point(590, 4)
        Me.txtImporteTope.MaxLength = 15
        Me.txtImporteTope.Name = "txtImporteTope"
        Me.txtImporteTope.Size = New System.Drawing.Size(92, 20)
        Me.txtImporteTope.TabIndex = 20
        Me.txtImporteTope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label11.LabelAsoc = Nothing
        Me.Label11.Location = New System.Drawing.Point(461, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Tipo Comprobante Epson"
        '
        'txtIdTipoComprobanteEpson
        '
        Me.txtIdTipoComprobanteEpson.BindearPropiedadControl = "Text"
        Me.txtIdTipoComprobanteEpson.BindearPropiedadEntidad = "IdTipoComprobanteEpson"
        Me.txtIdTipoComprobanteEpson.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTipoComprobanteEpson.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTipoComprobanteEpson.Formato = ""
        Me.txtIdTipoComprobanteEpson.IsDecimal = False
        Me.txtIdTipoComprobanteEpson.IsNumber = False
        Me.txtIdTipoComprobanteEpson.IsPK = False
        Me.txtIdTipoComprobanteEpson.IsRequired = False
        Me.txtIdTipoComprobanteEpson.Key = ""
        Me.txtIdTipoComprobanteEpson.LabelAsoc = Me.Label11
        Me.txtIdTipoComprobanteEpson.Location = New System.Drawing.Point(590, 54)
        Me.txtIdTipoComprobanteEpson.MaxLength = 15
        Me.txtIdTipoComprobanteEpson.Name = "txtIdTipoComprobanteEpson"
        Me.txtIdTipoComprobanteEpson.Size = New System.Drawing.Size(31, 20)
        Me.txtIdTipoComprobanteEpson.TabIndex = 36
        Me.txtIdTipoComprobanteEpson.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.LabelAsoc = Nothing
        Me.Label12.Location = New System.Drawing.Point(461, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Importe Mínimo"
        '
        'txtImporteMinimo
        '
        Me.txtImporteMinimo.BindearPropiedadControl = "Text"
        Me.txtImporteMinimo.BindearPropiedadEntidad = "ImporteMinimo"
        Me.txtImporteMinimo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteMinimo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteMinimo.Formato = ""
        Me.txtImporteMinimo.IsDecimal = False
        Me.txtImporteMinimo.IsNumber = False
        Me.txtImporteMinimo.IsPK = False
        Me.txtImporteMinimo.IsRequired = False
        Me.txtImporteMinimo.Key = ""
        Me.txtImporteMinimo.LabelAsoc = Me.Label12
        Me.txtImporteMinimo.Location = New System.Drawing.Point(590, 28)
        Me.txtImporteMinimo.MaxLength = 15
        Me.txtImporteMinimo.Name = "txtImporteMinimo"
        Me.txtImporteMinimo.Size = New System.Drawing.Size(92, 20)
        Me.txtImporteMinimo.TabIndex = 28
        Me.txtImporteMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.LabelAsoc = Nothing
        Me.Label13.Location = New System.Drawing.Point(672, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Plan Cuenta"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.LabelAsoc = Nothing
        Me.Label14.Location = New System.Drawing.Point(261, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Grupo"
        '
        'txtGrupo
        '
        Me.txtGrupo.BindearPropiedadControl = "Text"
        Me.txtGrupo.BindearPropiedadEntidad = "Grupo"
        Me.txtGrupo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtGrupo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtGrupo.Formato = ""
        Me.txtGrupo.IsDecimal = False
        Me.txtGrupo.IsNumber = False
        Me.txtGrupo.IsPK = False
        Me.txtGrupo.IsRequired = True
        Me.txtGrupo.Key = ""
        Me.txtGrupo.LabelAsoc = Me.Label14
        Me.txtGrupo.Location = New System.Drawing.Point(300, 53)
        Me.txtGrupo.MaxLength = 15
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Size = New System.Drawing.Size(125, 20)
        Me.txtGrupo.TabIndex = 13
        '
        'txtIdPlanCuenta
        '
        Me.txtIdPlanCuenta.BindearPropiedadControl = "Text"
        Me.txtIdPlanCuenta.BindearPropiedadEntidad = "IdPlanCuenta"
        Me.txtIdPlanCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdPlanCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdPlanCuenta.Formato = ""
        Me.txtIdPlanCuenta.IsDecimal = False
        Me.txtIdPlanCuenta.IsNumber = False
        Me.txtIdPlanCuenta.IsPK = False
        Me.txtIdPlanCuenta.IsRequired = True
        Me.txtIdPlanCuenta.Key = ""
        Me.txtIdPlanCuenta.LabelAsoc = Me.Label11
        Me.txtIdPlanCuenta.Location = New System.Drawing.Point(751, 29)
        Me.txtIdPlanCuenta.MaxLength = 15
        Me.txtIdPlanCuenta.Name = "txtIdPlanCuenta"
        Me.txtIdPlanCuenta.Size = New System.Drawing.Size(30, 20)
        Me.txtIdPlanCuenta.TabIndex = 7
        '
        'chbComprobanteSecundario
        '
        Me.chbComprobanteSecundario.AutoSize = True
        Me.chbComprobanteSecundario.BindearPropiedadControl = ""
        Me.chbComprobanteSecundario.BindearPropiedadEntidad = ""
        Me.chbComprobanteSecundario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprobanteSecundario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprobanteSecundario.IsPK = False
        Me.chbComprobanteSecundario.IsRequired = False
        Me.chbComprobanteSecundario.Key = Nothing
        Me.chbComprobanteSecundario.LabelAsoc = Nothing
        Me.chbComprobanteSecundario.Location = New System.Drawing.Point(11, 81)
        Me.chbComprobanteSecundario.Name = "chbComprobanteSecundario"
        Me.chbComprobanteSecundario.Size = New System.Drawing.Size(146, 17)
        Me.chbComprobanteSecundario.TabIndex = 39
        Me.chbComprobanteSecundario.Text = "Comprobante Secundario"
        Me.chbComprobanteSecundario.UseVisualStyleBackColor = True
        '
        'chbTipoComprobanteNCred
        '
        Me.chbTipoComprobanteNCred.AutoSize = True
        Me.chbTipoComprobanteNCred.BindearPropiedadControl = ""
        Me.chbTipoComprobanteNCred.BindearPropiedadEntidad = ""
        Me.chbTipoComprobanteNCred.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobanteNCred.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobanteNCred.IsPK = False
        Me.chbTipoComprobanteNCred.IsRequired = False
        Me.chbTipoComprobanteNCred.Key = Nothing
        Me.chbTipoComprobanteNCred.LabelAsoc = Nothing
        Me.chbTipoComprobanteNCred.Location = New System.Drawing.Point(11, 108)
        Me.chbTipoComprobanteNCred.Name = "chbTipoComprobanteNCred"
        Me.chbTipoComprobanteNCred.Size = New System.Drawing.Size(151, 17)
        Me.chbTipoComprobanteNCred.TabIndex = 43
        Me.chbTipoComprobanteNCred.Text = "Comprobante Nota Crédito"
        Me.chbTipoComprobanteNCred.UseVisualStyleBackColor = True
        '
        'chbTipoComprobanteNDeb
        '
        Me.chbTipoComprobanteNDeb.AutoSize = True
        Me.chbTipoComprobanteNDeb.BindearPropiedadControl = ""
        Me.chbTipoComprobanteNDeb.BindearPropiedadEntidad = ""
        Me.chbTipoComprobanteNDeb.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobanteNDeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobanteNDeb.IsPK = False
        Me.chbTipoComprobanteNDeb.IsRequired = False
        Me.chbTipoComprobanteNDeb.Key = Nothing
        Me.chbTipoComprobanteNDeb.LabelAsoc = Nothing
        Me.chbTipoComprobanteNDeb.Location = New System.Drawing.Point(11, 135)
        Me.chbTipoComprobanteNDeb.Name = "chbTipoComprobanteNDeb"
        Me.chbTipoComprobanteNDeb.Size = New System.Drawing.Size(149, 17)
        Me.chbTipoComprobanteNDeb.TabIndex = 48
        Me.chbTipoComprobanteNDeb.Text = "Comprobante Nota Débito"
        Me.chbTipoComprobanteNDeb.UseVisualStyleBackColor = True
        '
        'bscCodigoProducto2Cred
        '
        Me.bscCodigoProducto2Cred.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2Cred.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2Cred.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2Cred.ConfigBuscador = Nothing
        Me.bscCodigoProducto2Cred.Datos = Nothing
        Me.bscCodigoProducto2Cred.Enabled = False
        Me.bscCodigoProducto2Cred.FilaDevuelta = Nothing
        Me.bscCodigoProducto2Cred.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2Cred.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2Cred.IsDecimal = False
        Me.bscCodigoProducto2Cred.IsNumber = False
        Me.bscCodigoProducto2Cred.IsPK = False
        Me.bscCodigoProducto2Cred.IsRequired = False
        Me.bscCodigoProducto2Cred.Key = ""
        Me.bscCodigoProducto2Cred.LabelAsoc = Nothing
        Me.bscCodigoProducto2Cred.Location = New System.Drawing.Point(496, 105)
        Me.bscCodigoProducto2Cred.MaxLengh = "32767"
        Me.bscCodigoProducto2Cred.Name = "bscCodigoProducto2Cred"
        Me.bscCodigoProducto2Cred.Permitido = True
        Me.bscCodigoProducto2Cred.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2Cred.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2Cred.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2Cred.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2Cred.Selecciono = False
        Me.bscCodigoProducto2Cred.Size = New System.Drawing.Size(130, 20)
        Me.bscCodigoProducto2Cred.TabIndex = 46
        '
        'bscProducto2Cred
        '
        Me.bscProducto2Cred.ActivarFiltroEnGrilla = True
        Me.bscProducto2Cred.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscProducto2Cred.BindearPropiedadControl = Nothing
        Me.bscProducto2Cred.BindearPropiedadEntidad = Nothing
        Me.bscProducto2Cred.ConfigBuscador = Nothing
        Me.bscProducto2Cred.Datos = Nothing
        Me.bscProducto2Cred.Enabled = False
        Me.bscProducto2Cred.FilaDevuelta = Nothing
        Me.bscProducto2Cred.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2Cred.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2Cred.IsDecimal = False
        Me.bscProducto2Cred.IsNumber = False
        Me.bscProducto2Cred.IsPK = False
        Me.bscProducto2Cred.IsRequired = False
        Me.bscProducto2Cred.Key = ""
        Me.bscProducto2Cred.LabelAsoc = Nothing
        Me.bscProducto2Cred.Location = New System.Drawing.Point(629, 105)
        Me.bscProducto2Cred.MaxLengh = "60"
        Me.bscProducto2Cred.Name = "bscProducto2Cred"
        Me.bscProducto2Cred.Permitido = True
        Me.bscProducto2Cred.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2Cred.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2Cred.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2Cred.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2Cred.Selecciono = False
        Me.bscProducto2Cred.Size = New System.Drawing.Size(224, 20)
        Me.bscProducto2Cred.TabIndex = 47
        '
        'chbCodigoProducto2Cred
        '
        Me.chbCodigoProducto2Cred.AutoSize = True
        Me.chbCodigoProducto2Cred.BindearPropiedadControl = ""
        Me.chbCodigoProducto2Cred.BindearPropiedadEntidad = ""
        Me.chbCodigoProducto2Cred.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCodigoProducto2Cred.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCodigoProducto2Cred.IsPK = False
        Me.chbCodigoProducto2Cred.IsRequired = False
        Me.chbCodigoProducto2Cred.Key = Nothing
        Me.chbCodigoProducto2Cred.LabelAsoc = Nothing
        Me.chbCodigoProducto2Cred.Location = New System.Drawing.Point(385, 108)
        Me.chbCodigoProducto2Cred.Name = "chbCodigoProducto2Cred"
        Me.chbCodigoProducto2Cred.Size = New System.Drawing.Size(105, 17)
        Me.chbCodigoProducto2Cred.TabIndex = 45
        Me.chbCodigoProducto2Cred.Text = "Producto N.Créd"
        Me.chbCodigoProducto2Cred.UseVisualStyleBackColor = True
        '
        'chbCodigoProducto2Deb
        '
        Me.chbCodigoProducto2Deb.AutoSize = True
        Me.chbCodigoProducto2Deb.BindearPropiedadControl = ""
        Me.chbCodigoProducto2Deb.BindearPropiedadEntidad = ""
        Me.chbCodigoProducto2Deb.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCodigoProducto2Deb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCodigoProducto2Deb.IsPK = False
        Me.chbCodigoProducto2Deb.IsRequired = False
        Me.chbCodigoProducto2Deb.Key = Nothing
        Me.chbCodigoProducto2Deb.LabelAsoc = Nothing
        Me.chbCodigoProducto2Deb.Location = New System.Drawing.Point(385, 134)
        Me.chbCodigoProducto2Deb.Name = "chbCodigoProducto2Deb"
        Me.chbCodigoProducto2Deb.Size = New System.Drawing.Size(103, 17)
        Me.chbCodigoProducto2Deb.TabIndex = 50
        Me.chbCodigoProducto2Deb.Text = "Producto N.Déb"
        Me.chbCodigoProducto2Deb.UseVisualStyleBackColor = True
        '
        'bscCodigoProducto2Deb
        '
        Me.bscCodigoProducto2Deb.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2Deb.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2Deb.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2Deb.ConfigBuscador = Nothing
        Me.bscCodigoProducto2Deb.Datos = Nothing
        Me.bscCodigoProducto2Deb.Enabled = False
        Me.bscCodigoProducto2Deb.FilaDevuelta = Nothing
        Me.bscCodigoProducto2Deb.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2Deb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2Deb.IsDecimal = False
        Me.bscCodigoProducto2Deb.IsNumber = False
        Me.bscCodigoProducto2Deb.IsPK = False
        Me.bscCodigoProducto2Deb.IsRequired = False
        Me.bscCodigoProducto2Deb.Key = ""
        Me.bscCodigoProducto2Deb.LabelAsoc = Nothing
        Me.bscCodigoProducto2Deb.Location = New System.Drawing.Point(496, 131)
        Me.bscCodigoProducto2Deb.MaxLengh = "32767"
        Me.bscCodigoProducto2Deb.Name = "bscCodigoProducto2Deb"
        Me.bscCodigoProducto2Deb.Permitido = True
        Me.bscCodigoProducto2Deb.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2Deb.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2Deb.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2Deb.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2Deb.Selecciono = False
        Me.bscCodigoProducto2Deb.Size = New System.Drawing.Size(130, 20)
        Me.bscCodigoProducto2Deb.TabIndex = 51
        '
        'bscProducto2Deb
        '
        Me.bscProducto2Deb.ActivarFiltroEnGrilla = True
        Me.bscProducto2Deb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscProducto2Deb.BindearPropiedadControl = Nothing
        Me.bscProducto2Deb.BindearPropiedadEntidad = Nothing
        Me.bscProducto2Deb.ConfigBuscador = Nothing
        Me.bscProducto2Deb.Datos = Nothing
        Me.bscProducto2Deb.Enabled = False
        Me.bscProducto2Deb.FilaDevuelta = Nothing
        Me.bscProducto2Deb.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2Deb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2Deb.IsDecimal = False
        Me.bscProducto2Deb.IsNumber = False
        Me.bscProducto2Deb.IsPK = False
        Me.bscProducto2Deb.IsRequired = False
        Me.bscProducto2Deb.Key = ""
        Me.bscProducto2Deb.LabelAsoc = Nothing
        Me.bscProducto2Deb.Location = New System.Drawing.Point(629, 131)
        Me.bscProducto2Deb.MaxLengh = "60"
        Me.bscProducto2Deb.Name = "bscProducto2Deb"
        Me.bscProducto2Deb.Permitido = True
        Me.bscProducto2Deb.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2Deb.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2Deb.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2Deb.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2Deb.Selecciono = False
        Me.bscProducto2Deb.Size = New System.Drawing.Size(224, 20)
        Me.bscProducto2Deb.TabIndex = 52
        '
        'txtCodigoComprobanteSifere
        '
        Me.txtCodigoComprobanteSifere.BindearPropiedadControl = "Text"
        Me.txtCodigoComprobanteSifere.BindearPropiedadEntidad = "CodigoComprobanteSifere"
        Me.txtCodigoComprobanteSifere.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoComprobanteSifere.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoComprobanteSifere.Formato = ""
        Me.txtCodigoComprobanteSifere.IsDecimal = False
        Me.txtCodigoComprobanteSifere.IsNumber = False
        Me.txtCodigoComprobanteSifere.IsPK = False
        Me.txtCodigoComprobanteSifere.IsRequired = False
        Me.txtCodigoComprobanteSifere.Key = ""
        Me.txtCodigoComprobanteSifere.LabelAsoc = Me.lblCodigoComprobanteSifere
        Me.txtCodigoComprobanteSifere.Location = New System.Drawing.Point(818, 4)
        Me.txtCodigoComprobanteSifere.MaxLength = 15
        Me.txtCodigoComprobanteSifere.Name = "txtCodigoComprobanteSifere"
        Me.txtCodigoComprobanteSifere.Size = New System.Drawing.Size(31, 20)
        Me.txtCodigoComprobanteSifere.TabIndex = 22
        '
        'lblCodigoComprobanteSifere
        '
        Me.lblCodigoComprobanteSifere.AutoSize = True
        Me.lblCodigoComprobanteSifere.LabelAsoc = Nothing
        Me.lblCodigoComprobanteSifere.Location = New System.Drawing.Point(742, 8)
        Me.lblCodigoComprobanteSifere.Name = "lblCodigoComprobanteSifere"
        Me.lblCodigoComprobanteSifere.Size = New System.Drawing.Size(70, 13)
        Me.lblCodigoComprobanteSifere.TabIndex = 21
        Me.lblCodigoComprobanteSifere.Text = "Código Sifere"
        '
        'chbTipoComprobanteContraMovInvocar
        '
        Me.chbTipoComprobanteContraMovInvocar.AutoSize = True
        Me.chbTipoComprobanteContraMovInvocar.BindearPropiedadControl = ""
        Me.chbTipoComprobanteContraMovInvocar.BindearPropiedadEntidad = ""
        Me.chbTipoComprobanteContraMovInvocar.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobanteContraMovInvocar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobanteContraMovInvocar.IsPK = False
        Me.chbTipoComprobanteContraMovInvocar.IsRequired = False
        Me.chbTipoComprobanteContraMovInvocar.Key = Nothing
        Me.chbTipoComprobanteContraMovInvocar.LabelAsoc = Nothing
        Me.chbTipoComprobanteContraMovInvocar.Location = New System.Drawing.Point(385, 81)
        Me.chbTipoComprobanteContraMovInvocar.Name = "chbTipoComprobanteContraMovInvocar"
        Me.chbTipoComprobanteContraMovInvocar.Size = New System.Drawing.Size(186, 17)
        Me.chbTipoComprobanteContraMovInvocar.TabIndex = 41
        Me.chbTipoComprobanteContraMovInvocar.Text = "Contramovimiento al ser Invocado"
        Me.chbTipoComprobanteContraMovInvocar.UseVisualStyleBackColor = True
        '
        'txtLargoMaximoNumero
        '
        Me.txtLargoMaximoNumero.BindearPropiedadControl = "Text"
        Me.txtLargoMaximoNumero.BindearPropiedadEntidad = "LargoMaximoNumero"
        Me.txtLargoMaximoNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLargoMaximoNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLargoMaximoNumero.Formato = ""
        Me.txtLargoMaximoNumero.IsDecimal = False
        Me.txtLargoMaximoNumero.IsNumber = True
        Me.txtLargoMaximoNumero.IsPK = False
        Me.txtLargoMaximoNumero.IsRequired = True
        Me.txtLargoMaximoNumero.Key = ""
        Me.txtLargoMaximoNumero.LabelAsoc = Me.lblLargoMaximoNumero
        Me.txtLargoMaximoNumero.Location = New System.Drawing.Point(818, 28)
        Me.txtLargoMaximoNumero.MaxLength = 2
        Me.txtLargoMaximoNumero.Name = "txtLargoMaximoNumero"
        Me.txtLargoMaximoNumero.Size = New System.Drawing.Size(31, 20)
        Me.txtLargoMaximoNumero.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.txtLargoMaximoNumero, "Cantidad máxima de dígitos que se pueden tipear en el Número de Comprobante")
        '
        'lblLargoMaximoNumero
        '
        Me.lblLargoMaximoNumero.AutoSize = True
        Me.lblLargoMaximoNumero.LabelAsoc = Nothing
        Me.lblLargoMaximoNumero.Location = New System.Drawing.Point(685, 32)
        Me.lblLargoMaximoNumero.Name = "lblLargoMaximoNumero"
        Me.lblLargoMaximoNumero.Size = New System.Drawing.Size(127, 13)
        Me.lblLargoMaximoNumero.TabIndex = 29
        Me.lblLargoMaximoNumero.Text = "Largo máximo del número"
        '
        'txtNivelAutorizacion
        '
        Me.txtNivelAutorizacion.BindearPropiedadControl = "Text"
        Me.txtNivelAutorizacion.BindearPropiedadEntidad = "NivelAutorizacion"
        Me.txtNivelAutorizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNivelAutorizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNivelAutorizacion.Formato = ""
        Me.txtNivelAutorizacion.IsDecimal = False
        Me.txtNivelAutorizacion.IsNumber = True
        Me.txtNivelAutorizacion.IsPK = False
        Me.txtNivelAutorizacion.IsRequired = True
        Me.txtNivelAutorizacion.Key = ""
        Me.txtNivelAutorizacion.LabelAsoc = Me.lblNivelAutorizacion
        Me.txtNivelAutorizacion.Location = New System.Drawing.Point(818, 54)
        Me.txtNivelAutorizacion.MaxLength = 2
        Me.txtNivelAutorizacion.Name = "txtNivelAutorizacion"
        Me.txtNivelAutorizacion.Size = New System.Drawing.Size(31, 20)
        Me.txtNivelAutorizacion.TabIndex = 38
        '
        'lblNivelAutorizacion
        '
        Me.lblNivelAutorizacion.AutoSize = True
        Me.lblNivelAutorizacion.LabelAsoc = Nothing
        Me.lblNivelAutorizacion.Location = New System.Drawing.Point(705, 58)
        Me.lblNivelAutorizacion.Name = "lblNivelAutorizacion"
        Me.lblNivelAutorizacion.Size = New System.Drawing.Size(107, 13)
        Me.lblNivelAutorizacion.TabIndex = 37
        Me.lblNivelAutorizacion.Text = "Nivel de Autorización"
        '
        'tbcComporbantes
        '
        Me.tbcComporbantes.Controls.Add(Me.tbpDetalle)
        Me.tbcComporbantes.Controls.Add(Me.tbpCompAsoci)
        Me.tbcComporbantes.Controls.Add(Me.tbpProducto)
        Me.tbcComporbantes.Controls.Add(Me.tbpAFIP)
        Me.tbcComporbantes.Controls.Add(Me.tbpExportaciones)
        Me.tbcComporbantes.Location = New System.Drawing.Point(2, 317)
        Me.tbcComporbantes.Name = "tbcComporbantes"
        Me.tbcComporbantes.SelectedIndex = 0
        Me.tbcComporbantes.Size = New System.Drawing.Size(879, 224)
        Me.tbcComporbantes.TabIndex = 24
        '
        'tbpDetalle
        '
        Me.tbpDetalle.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDetalle.Controls.Add(Me.cmbTiposComprobantes)
        Me.tbpDetalle.Controls.Add(Me.Label3)
        Me.tbpDetalle.Controls.Add(Me.cmbCoeficienteStock)
        Me.tbpDetalle.Controls.Add(Me.txtCantMaxItems)
        Me.tbpDetalle.Controls.Add(Me.bscProducto2Deb)
        Me.tbpDetalle.Controls.Add(Me.Label7)
        Me.tbpDetalle.Controls.Add(Me.bscProducto2Cred)
        Me.tbpDetalle.Controls.Add(Me.Label9)
        Me.tbpDetalle.Controls.Add(Me.bscCodigoProducto2Deb)
        Me.tbpDetalle.Controls.Add(Me.cmbCoefValores)
        Me.tbpDetalle.Controls.Add(Me.bscCodigoProducto2Cred)
        Me.tbpDetalle.Controls.Add(Me.Label10)
        Me.tbpDetalle.Controls.Add(Me.chbCodigoProducto2Deb)
        Me.tbpDetalle.Controls.Add(Me.cmbModificaAlFacturar)
        Me.tbpDetalle.Controls.Add(Me.chbTipoComprobanteNDeb)
        Me.tbpDetalle.Controls.Add(Me.txtCantidadCopias)
        Me.tbpDetalle.Controls.Add(Me.chbCodigoProducto2Cred)
        Me.tbpDetalle.Controls.Add(Me.Label17)
        Me.tbpDetalle.Controls.Add(Me.chbTipoComprobanteNCred)
        Me.tbpDetalle.Controls.Add(Me.chbTipoComprobanteContraMovInvocar)
        Me.tbpDetalle.Controls.Add(Me.txtCantidadMaximaItemsObserv)
        Me.tbpDetalle.Controls.Add(Me.chbComprobanteSecundario)
        Me.tbpDetalle.Controls.Add(Me.Label4)
        Me.tbpDetalle.Controls.Add(Me.cmbTipoComprobanteNDeb)
        Me.tbpDetalle.Controls.Add(Me.txtImporteTope)
        Me.tbpDetalle.Controls.Add(Me.cmbTipoComprobanteNCred)
        Me.tbpDetalle.Controls.Add(Me.Label8)
        Me.tbpDetalle.Controls.Add(Me.cmbTipoComprobanteContraMovInvocar)
        Me.tbpDetalle.Controls.Add(Me.txtIdTipoComprobanteEpson)
        Me.tbpDetalle.Controls.Add(Me.txtCodigoComprobanteSifere)
        Me.tbpDetalle.Controls.Add(Me.txtLargoMaximoNumero)
        Me.tbpDetalle.Controls.Add(Me.txtNivelAutorizacion)
        Me.tbpDetalle.Controls.Add(Me.Label11)
        Me.tbpDetalle.Controls.Add(Me.lblCodigoComprobanteSifere)
        Me.tbpDetalle.Controls.Add(Me.lblLargoMaximoNumero)
        Me.tbpDetalle.Controls.Add(Me.Label12)
        Me.tbpDetalle.Controls.Add(Me.lblNivelAutorizacion)
        Me.tbpDetalle.Controls.Add(Me.txtImporteMinimo)
        Me.tbpDetalle.Location = New System.Drawing.Point(4, 22)
        Me.tbpDetalle.Name = "tbpDetalle"
        Me.tbpDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDetalle.Size = New System.Drawing.Size(871, 198)
        Me.tbpDetalle.TabIndex = 0
        Me.tbpDetalle.Text = "Comprobante"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = "IdTipoComprobanteSecundario"
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Enabled = False
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(173, 79)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(189, 21)
        Me.cmbTiposComprobantes.TabIndex = 40
        '
        'cmbCoeficienteStock
        '
        Me.cmbCoeficienteStock.BindearPropiedadControl = "Text"
        Me.cmbCoeficienteStock.BindearPropiedadEntidad = "CoeficienteStock"
        Me.cmbCoeficienteStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCoeficienteStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCoeficienteStock.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCoeficienteStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCoeficienteStock.FormattingEnabled = True
        Me.cmbCoeficienteStock.IsPK = False
        Me.cmbCoeficienteStock.IsRequired = False
        Me.cmbCoeficienteStock.Items.AddRange(New Object() {"0", "1", "-1"})
        Me.cmbCoeficienteStock.Key = Nothing
        Me.cmbCoeficienteStock.LabelAsoc = Nothing
        Me.cmbCoeficienteStock.Location = New System.Drawing.Point(173, 28)
        Me.cmbCoeficienteStock.Name = "cmbCoeficienteStock"
        Me.cmbCoeficienteStock.Size = New System.Drawing.Size(46, 21)
        Me.cmbCoeficienteStock.TabIndex = 24
        '
        'cmbCoefValores
        '
        Me.cmbCoefValores.BindearPropiedadControl = "Text"
        Me.cmbCoefValores.BindearPropiedadEntidad = "CoeficienteValores"
        Me.cmbCoefValores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCoefValores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCoefValores.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCoefValores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCoefValores.FormattingEnabled = True
        Me.cmbCoefValores.IsPK = False
        Me.cmbCoefValores.IsRequired = False
        Me.cmbCoefValores.Items.AddRange(New Object() {"0", "1", "-1"})
        Me.cmbCoefValores.Key = Nothing
        Me.cmbCoefValores.LabelAsoc = Nothing
        Me.cmbCoefValores.Location = New System.Drawing.Point(173, 54)
        Me.cmbCoefValores.Name = "cmbCoefValores"
        Me.cmbCoefValores.Size = New System.Drawing.Size(47, 21)
        Me.cmbCoefValores.TabIndex = 32
        '
        'cmbModificaAlFacturar
        '
        Me.cmbModificaAlFacturar.BindearPropiedadControl = "Text"
        Me.cmbModificaAlFacturar.BindearPropiedadEntidad = "ModificaAlFacturar"
        Me.cmbModificaAlFacturar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModificaAlFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModificaAlFacturar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbModificaAlFacturar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbModificaAlFacturar.FormattingEnabled = True
        Me.cmbModificaAlFacturar.IsPK = False
        Me.cmbModificaAlFacturar.IsRequired = False
        Me.cmbModificaAlFacturar.Items.AddRange(New Object() {"", "SOLOPRECIOS", "NO", "SI"})
        Me.cmbModificaAlFacturar.Key = Nothing
        Me.cmbModificaAlFacturar.LabelAsoc = Nothing
        Me.cmbModificaAlFacturar.Location = New System.Drawing.Point(173, 4)
        Me.cmbModificaAlFacturar.Name = "cmbModificaAlFacturar"
        Me.cmbModificaAlFacturar.Size = New System.Drawing.Size(101, 21)
        Me.cmbModificaAlFacturar.TabIndex = 16
        '
        'cmbTipoComprobanteNDeb
        '
        Me.cmbTipoComprobanteNDeb.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoComprobanteNDeb.BindearPropiedadEntidad = "IdTipoComprobanteNDeb"
        Me.cmbTipoComprobanteNDeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteNDeb.Enabled = False
        Me.cmbTipoComprobanteNDeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobanteNDeb.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteNDeb.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteNDeb.FormattingEnabled = True
        Me.cmbTipoComprobanteNDeb.IsPK = False
        Me.cmbTipoComprobanteNDeb.IsRequired = False
        Me.cmbTipoComprobanteNDeb.Key = Nothing
        Me.cmbTipoComprobanteNDeb.LabelAsoc = Nothing
        Me.cmbTipoComprobanteNDeb.Location = New System.Drawing.Point(173, 133)
        Me.cmbTipoComprobanteNDeb.Name = "cmbTipoComprobanteNDeb"
        Me.cmbTipoComprobanteNDeb.Size = New System.Drawing.Size(189, 21)
        Me.cmbTipoComprobanteNDeb.TabIndex = 49
        '
        'cmbTipoComprobanteNCred
        '
        Me.cmbTipoComprobanteNCred.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoComprobanteNCred.BindearPropiedadEntidad = "IdTipoComprobanteNCred"
        Me.cmbTipoComprobanteNCred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteNCred.Enabled = False
        Me.cmbTipoComprobanteNCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobanteNCred.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteNCred.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteNCred.FormattingEnabled = True
        Me.cmbTipoComprobanteNCred.IsPK = False
        Me.cmbTipoComprobanteNCred.IsRequired = False
        Me.cmbTipoComprobanteNCred.Key = Nothing
        Me.cmbTipoComprobanteNCred.LabelAsoc = Nothing
        Me.cmbTipoComprobanteNCred.Location = New System.Drawing.Point(173, 106)
        Me.cmbTipoComprobanteNCred.Name = "cmbTipoComprobanteNCred"
        Me.cmbTipoComprobanteNCred.Size = New System.Drawing.Size(189, 21)
        Me.cmbTipoComprobanteNCred.TabIndex = 44
        '
        'cmbTipoComprobanteContraMovInvocar
        '
        Me.cmbTipoComprobanteContraMovInvocar.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoComprobanteContraMovInvocar.BindearPropiedadEntidad = "IdTipoComprobanteContraMovInvocar"
        Me.cmbTipoComprobanteContraMovInvocar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteContraMovInvocar.Enabled = False
        Me.cmbTipoComprobanteContraMovInvocar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobanteContraMovInvocar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteContraMovInvocar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteContraMovInvocar.FormattingEnabled = True
        Me.cmbTipoComprobanteContraMovInvocar.IsPK = False
        Me.cmbTipoComprobanteContraMovInvocar.IsRequired = False
        Me.cmbTipoComprobanteContraMovInvocar.Key = Nothing
        Me.cmbTipoComprobanteContraMovInvocar.LabelAsoc = Nothing
        Me.cmbTipoComprobanteContraMovInvocar.Location = New System.Drawing.Point(577, 79)
        Me.cmbTipoComprobanteContraMovInvocar.Name = "cmbTipoComprobanteContraMovInvocar"
        Me.cmbTipoComprobanteContraMovInvocar.Size = New System.Drawing.Size(189, 21)
        Me.cmbTipoComprobanteContraMovInvocar.TabIndex = 42
        '
        'tbpCompAsoci
        '
        Me.tbpCompAsoci.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCompAsoci.Controls.Add(Me.ugComprobantesAsociados)
        Me.tbpCompAsoci.Location = New System.Drawing.Point(4, 22)
        Me.tbpCompAsoci.Name = "tbpCompAsoci"
        Me.tbpCompAsoci.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCompAsoci.Size = New System.Drawing.Size(871, 198)
        Me.tbpCompAsoci.TabIndex = 2
        Me.tbpCompAsoci.Text = "Comprobantes Asociados"
        '
        'ugComprobantesAsociados
        '
        Me.ugComprobantesAsociados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.ugComprobantesAsociados.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn1.FilterCellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "S"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 14
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "Comprobante"
        UltraGridColumn4.Header.VisiblePosition = 1
        UltraGridColumn4.Width = 215
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "Descripción"
        UltraGridColumn5.Header.VisiblePosition = 2
        UltraGridColumn5.Width = 261
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 3
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.VisiblePosition = 4
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "Graba Libro"
        UltraGridColumn2.Header.VisiblePosition = 5
        UltraGridColumn2.Width = 83
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "Es Recibo"
        UltraGridColumn3.Header.VisiblePosition = 6
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn2, UltraGridColumn3})
        UltraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        Me.ugComprobantesAsociados.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugComprobantesAsociados.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugComprobantesAsociados.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantesAsociados.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantesAsociados.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugComprobantesAsociados.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugComprobantesAsociados.DisplayLayout.GroupByBox.Hidden = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantesAsociados.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugComprobantesAsociados.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugComprobantesAsociados.DisplayLayout.MaxColScrollRegions = 1
        Me.ugComprobantesAsociados.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugComprobantesAsociados.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugComprobantesAsociados.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugComprobantesAsociados.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugComprobantesAsociados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugComprobantesAsociados.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugComprobantesAsociados.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugComprobantesAsociados.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugComprobantesAsociados.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugComprobantesAsociados.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugComprobantesAsociados.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugComprobantesAsociados.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugComprobantesAsociados.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugComprobantesAsociados.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugComprobantesAsociados.DisplayLayout.Override.CellPadding = 0
        Me.ugComprobantesAsociados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugComprobantesAsociados.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugComprobantesAsociados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance10.BackColor = System.Drawing.Color.Tomato
        Appearance10.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantesAsociados.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Me.ugComprobantesAsociados.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance11.TextHAlignAsString = "Left"
        Me.ugComprobantesAsociados.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugComprobantesAsociados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugComprobantesAsociados.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugComprobantesAsociados.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugComprobantesAsociados.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugComprobantesAsociados.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugComprobantesAsociados.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugComprobantesAsociados.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugComprobantesAsociados.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugComprobantesAsociados.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance13.BackColor = System.Drawing.Color.LimeGreen
        Appearance13.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugComprobantesAsociados.DisplayLayout.Override.SummaryValueAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugComprobantesAsociados.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.ugComprobantesAsociados.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugComprobantesAsociados.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugComprobantesAsociados.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugComprobantesAsociados.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugComprobantesAsociados.Location = New System.Drawing.Point(3, 3)
        Me.ugComprobantesAsociados.Name = "ugComprobantesAsociados"
        Me.ugComprobantesAsociados.Size = New System.Drawing.Size(865, 189)
        Me.ugComprobantesAsociados.TabIndex = 28
        Me.ugComprobantesAsociados.Text = "UltraGrid1"
        '
        'tbpProducto
        '
        Me.tbpProducto.BackColor = System.Drawing.SystemColors.Control
        Me.tbpProducto.Controls.Add(Me.lblCodProducto)
        Me.tbpProducto.Controls.Add(Me.lblProducto)
        Me.tbpProducto.Controls.Add(Me.txtCantidad)
        Me.tbpProducto.Controls.Add(Me.lblCantidad)
        Me.tbpProducto.Controls.Add(Me.bscProducto2)
        Me.tbpProducto.Controls.Add(Me.btnEliminarContacto)
        Me.tbpProducto.Controls.Add(Me.btnInsertarProducto)
        Me.tbpProducto.Controls.Add(Me.bscCodigoProducto2)
        Me.tbpProducto.Controls.Add(Me.btnLimpiarProducto)
        Me.tbpProducto.Controls.Add(Me.ugProductoDetalle)
        Me.tbpProducto.Location = New System.Drawing.Point(4, 22)
        Me.tbpProducto.Name = "tbpProducto"
        Me.tbpProducto.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpProducto.Size = New System.Drawing.Size(871, 198)
        Me.tbpProducto.TabIndex = 1
        Me.tbpProducto.Text = "Productos"
        '
        'lblCodProducto
        '
        Me.lblCodProducto.AutoSize = True
        Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodProducto.LabelAsoc = Nothing
        Me.lblCodProducto.Location = New System.Drawing.Point(40, 5)
        Me.lblCodProducto.Name = "lblCodProducto"
        Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblCodProducto.TabIndex = 52
        Me.lblCodProducto.Text = "Código"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(189, 5)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 51
        Me.lblProducto.Text = "Producto"
        '
        'txtCantidad
        '
        Me.txtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCantidad.BindearPropiedadControl = Nothing
        Me.txtCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "#0.00"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Me.lblCantidad
        Me.txtCantidad.Location = New System.Drawing.Point(430, 21)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(60, 20)
        Me.txtCantidad.TabIndex = 3
        Me.txtCantidad.Text = "1.00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidad
        '
        Me.lblCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(427, 5)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 49
        Me.lblCantidad.Text = "Cantidad"
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(192, 20)
        Me.bscProducto2.MaxLengh = "60"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(224, 20)
        Me.bscProducto2.TabIndex = 2
        '
        'btnEliminarContacto
        '
        Me.btnEliminarContacto.Image = CType(resources.GetObject("btnEliminarContacto.Image"), System.Drawing.Image)
        Me.btnEliminarContacto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminarContacto.Location = New System.Drawing.Point(555, 6)
        Me.btnEliminarContacto.Name = "btnEliminarContacto"
        Me.btnEliminarContacto.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminarContacto.TabIndex = 5
        Me.btnEliminarContacto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarContacto.UseVisualStyleBackColor = True
        '
        'btnInsertarProducto
        '
        Me.btnInsertarProducto.Image = CType(resources.GetObject("btnInsertarProducto.Image"), System.Drawing.Image)
        Me.btnInsertarProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertarProducto.Location = New System.Drawing.Point(512, 6)
        Me.btnInsertarProducto.Name = "btnInsertarProducto"
        Me.btnInsertarProducto.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertarProducto.TabIndex = 4
        Me.btnInsertarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarProducto.UseVisualStyleBackColor = True
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(40, 20)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
        Me.bscCodigoProducto2.TabIndex = 1
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.Image = CType(resources.GetObject("btnLimpiarProducto.Image"), System.Drawing.Image)
        Me.btnLimpiarProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(13, 19)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(26, 22)
        Me.btnLimpiarProducto.TabIndex = 0
        Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'ugProductoDetalle
        '
        Me.ugProductoDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor3DBase = System.Drawing.Color.White
        Me.ugProductoDetalle.DisplayLayout.Appearance = Appearance15
        UltraGridColumn8.Header.Caption = "Código"
        UltraGridColumn8.Header.VisiblePosition = 0
        UltraGridColumn9.Header.Caption = "Producto"
        UltraGridColumn9.Header.VisiblePosition = 1
        UltraGridColumn9.Width = 375
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance16
        UltraGridColumn10.Format = "N2"
        UltraGridColumn10.Header.VisiblePosition = 2
        UltraGridColumn10.Width = 104
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn8, UltraGridColumn9, UltraGridColumn10})
        UltraGridBand2.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand2.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand2.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand2.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        UltraGridBand2.SummaryFooterCaption = "Totales:"
        Me.ugProductoDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugProductoDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductoDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance17.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductoDetalle.DisplayLayout.GroupByBox.Appearance = Appearance17
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductoDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance18
        Me.ugProductoDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductoDetalle.DisplayLayout.GroupByBox.Hidden = True
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance19.BackColor2 = System.Drawing.SystemColors.Control
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductoDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance19
        Me.ugProductoDetalle.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugProductoDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugProductoDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugProductoDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance20
        Appearance21.BackColor = System.Drawing.SystemColors.Highlight
        Appearance21.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugProductoDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance21
        Me.ugProductoDetalle.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugProductoDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductoDetalle.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductoDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductoDetalle.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugProductoDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductoDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugProductoDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Me.ugProductoDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance22
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Appearance23.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugProductoDetalle.DisplayLayout.Override.CellAppearance = Appearance23
        Me.ugProductoDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugProductoDetalle.DisplayLayout.Override.CellPadding = 0
        Me.ugProductoDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugProductoDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugProductoDetalle.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance24.BackColor = System.Drawing.Color.Tomato
        Appearance24.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance24.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductoDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance24
        Me.ugProductoDetalle.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance25.TextHAlignAsString = "Left"
        Me.ugProductoDetalle.DisplayLayout.Override.HeaderAppearance = Appearance25
        Me.ugProductoDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugProductoDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.BorderColor = System.Drawing.Color.Silver
        Me.ugProductoDetalle.DisplayLayout.Override.RowAppearance = Appearance26
        Me.ugProductoDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductoDetalle.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugProductoDetalle.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugProductoDetalle.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugProductoDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugProductoDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance27.BackColor = System.Drawing.Color.LimeGreen
        Appearance27.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugProductoDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance27
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugProductoDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
        Me.ugProductoDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugProductoDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugProductoDetalle.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugProductoDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugProductoDetalle.Location = New System.Drawing.Point(3, 46)
        Me.ugProductoDetalle.Name = "ugProductoDetalle"
        Me.ugProductoDetalle.Size = New System.Drawing.Size(865, 146)
        Me.ugProductoDetalle.TabIndex = 27
        Me.ugProductoDetalle.Text = "UltraGrid1"
        '
        'tbpAFIP
        '
        Me.tbpAFIP.BackColor = System.Drawing.SystemColors.Control
        Me.tbpAFIP.Controls.Add(Me.GroupBox2)
        Me.tbpAFIP.Controls.Add(Me.chbAFIPWSEsFEC)
        Me.tbpAFIP.Location = New System.Drawing.Point(4, 22)
        Me.tbpAFIP.Name = "tbpAFIP"
        Me.tbpAFIP.Size = New System.Drawing.Size(871, 198)
        Me.tbpAFIP.TabIndex = 3
        Me.tbpAFIP.Text = "AFIP"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblIncluyeFechaVencimiento)
        Me.GroupBox2.Controls.Add(Me.CheckBox8)
        Me.GroupBox2.Controls.Add(Me.chbAFIPWSRequiereReferenciaComercial)
        Me.GroupBox2.Controls.Add(Me.cmbAFIPWSIncluyeFechaVencimiento)
        Me.GroupBox2.Controls.Add(Me.chbAFIPWSCodigoAnulacion)
        Me.GroupBox2.Controls.Add(Me.chbAFIPWSRequiereCBU)
        Me.GroupBox2.Controls.Add(Me.chbAFIPWSRequiereComprobanteAsociado)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(473, 128)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "WS Factura Electrónica"
        '
        'lblIncluyeFechaVencimiento
        '
        Me.lblIncluyeFechaVencimiento.AutoSize = True
        Me.lblIncluyeFechaVencimiento.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIncluyeFechaVencimiento.LabelAsoc = Nothing
        Me.lblIncluyeFechaVencimiento.Location = New System.Drawing.Point(24, 26)
        Me.lblIncluyeFechaVencimiento.Name = "lblIncluyeFechaVencimiento"
        Me.lblIncluyeFechaVencimiento.Size = New System.Drawing.Size(111, 13)
        Me.lblIncluyeFechaVencimiento.TabIndex = 0
        Me.lblIncluyeFechaVencimiento.Text = "Requiere Vencimiento"
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.BindearPropiedadControl = "Checked"
        Me.CheckBox8.BindearPropiedadEntidad = "AFIPWSRequiereReferenciaTransferencia"
        Me.CheckBox8.CausesValidation = False
        Me.CheckBox8.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox8.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox8.IsPK = False
        Me.CheckBox8.IsRequired = False
        Me.CheckBox8.Key = Nothing
        Me.CheckBox8.LabelAsoc = Nothing
        Me.CheckBox8.Location = New System.Drawing.Point(27, 96)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(192, 17)
        Me.CheckBox8.TabIndex = 4
        Me.CheckBox8.Text = "Requiere Referencia Transferencia"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'chbAFIPWSRequiereReferenciaComercial
        '
        Me.chbAFIPWSRequiereReferenciaComercial.AutoSize = True
        Me.chbAFIPWSRequiereReferenciaComercial.BindearPropiedadControl = "Checked"
        Me.chbAFIPWSRequiereReferenciaComercial.BindearPropiedadEntidad = "AFIPWSRequiereReferenciaComercial"
        Me.chbAFIPWSRequiereReferenciaComercial.CausesValidation = False
        Me.chbAFIPWSRequiereReferenciaComercial.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAFIPWSRequiereReferenciaComercial.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAFIPWSRequiereReferenciaComercial.IsPK = False
        Me.chbAFIPWSRequiereReferenciaComercial.IsRequired = False
        Me.chbAFIPWSRequiereReferenciaComercial.Key = Nothing
        Me.chbAFIPWSRequiereReferenciaComercial.LabelAsoc = Nothing
        Me.chbAFIPWSRequiereReferenciaComercial.Location = New System.Drawing.Point(27, 73)
        Me.chbAFIPWSRequiereReferenciaComercial.Name = "chbAFIPWSRequiereReferenciaComercial"
        Me.chbAFIPWSRequiereReferenciaComercial.Size = New System.Drawing.Size(173, 17)
        Me.chbAFIPWSRequiereReferenciaComercial.TabIndex = 3
        Me.chbAFIPWSRequiereReferenciaComercial.Text = "Requiere Referencia Comercial"
        Me.chbAFIPWSRequiereReferenciaComercial.UseVisualStyleBackColor = True
        '
        'cmbAFIPWSIncluyeFechaVencimiento
        '
        Me.cmbAFIPWSIncluyeFechaVencimiento.BindearPropiedadControl = ""
        Me.cmbAFIPWSIncluyeFechaVencimiento.BindearPropiedadEntidad = ""
        Me.cmbAFIPWSIncluyeFechaVencimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAFIPWSIncluyeFechaVencimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAFIPWSIncluyeFechaVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAFIPWSIncluyeFechaVencimiento.FormattingEnabled = True
        Me.cmbAFIPWSIncluyeFechaVencimiento.IsPK = False
        Me.cmbAFIPWSIncluyeFechaVencimiento.IsRequired = True
        Me.cmbAFIPWSIncluyeFechaVencimiento.Key = Nothing
        Me.cmbAFIPWSIncluyeFechaVencimiento.LabelAsoc = Me.lblIncluyeFechaVencimiento
        Me.cmbAFIPWSIncluyeFechaVencimiento.Location = New System.Drawing.Point(141, 23)
        Me.cmbAFIPWSIncluyeFechaVencimiento.Name = "cmbAFIPWSIncluyeFechaVencimiento"
        Me.cmbAFIPWSIncluyeFechaVencimiento.Size = New System.Drawing.Size(116, 21)
        Me.cmbAFIPWSIncluyeFechaVencimiento.TabIndex = 1
        '
        'chbAFIPWSCodigoAnulacion
        '
        Me.chbAFIPWSCodigoAnulacion.AutoSize = True
        Me.chbAFIPWSCodigoAnulacion.BindearPropiedadControl = "Checked"
        Me.chbAFIPWSCodigoAnulacion.BindearPropiedadEntidad = "AFIPWSCodigoAnulacion"
        Me.chbAFIPWSCodigoAnulacion.CausesValidation = False
        Me.chbAFIPWSCodigoAnulacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAFIPWSCodigoAnulacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAFIPWSCodigoAnulacion.IsPK = False
        Me.chbAFIPWSCodigoAnulacion.IsRequired = False
        Me.chbAFIPWSCodigoAnulacion.Key = Nothing
        Me.chbAFIPWSCodigoAnulacion.LabelAsoc = Nothing
        Me.chbAFIPWSCodigoAnulacion.Location = New System.Drawing.Point(268, 73)
        Me.chbAFIPWSCodigoAnulacion.Name = "chbAFIPWSCodigoAnulacion"
        Me.chbAFIPWSCodigoAnulacion.Size = New System.Drawing.Size(170, 17)
        Me.chbAFIPWSCodigoAnulacion.TabIndex = 6
        Me.chbAFIPWSCodigoAnulacion.Text = "Requiere Código de Anulación"
        Me.chbAFIPWSCodigoAnulacion.UseVisualStyleBackColor = True
        '
        'chbAFIPWSRequiereCBU
        '
        Me.chbAFIPWSRequiereCBU.AutoSize = True
        Me.chbAFIPWSRequiereCBU.BindearPropiedadControl = "Checked"
        Me.chbAFIPWSRequiereCBU.BindearPropiedadEntidad = "AFIPWSRequiereCBU"
        Me.chbAFIPWSRequiereCBU.CausesValidation = False
        Me.chbAFIPWSRequiereCBU.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAFIPWSRequiereCBU.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAFIPWSRequiereCBU.IsPK = False
        Me.chbAFIPWSRequiereCBU.IsRequired = False
        Me.chbAFIPWSRequiereCBU.Key = Nothing
        Me.chbAFIPWSRequiereCBU.LabelAsoc = Nothing
        Me.chbAFIPWSRequiereCBU.Location = New System.Drawing.Point(268, 50)
        Me.chbAFIPWSRequiereCBU.Name = "chbAFIPWSRequiereCBU"
        Me.chbAFIPWSRequiereCBU.Size = New System.Drawing.Size(163, 17)
        Me.chbAFIPWSRequiereCBU.TabIndex = 5
        Me.chbAFIPWSRequiereCBU.Text = "Requiere CBU y/o CBU Alias"
        Me.chbAFIPWSRequiereCBU.UseVisualStyleBackColor = True
        '
        'chbAFIPWSRequiereComprobanteAsociado
        '
        Me.chbAFIPWSRequiereComprobanteAsociado.AutoSize = True
        Me.chbAFIPWSRequiereComprobanteAsociado.BindearPropiedadControl = "Checked"
        Me.chbAFIPWSRequiereComprobanteAsociado.BindearPropiedadEntidad = "AFIPWSRequiereComprobanteAsociado"
        Me.chbAFIPWSRequiereComprobanteAsociado.CausesValidation = False
        Me.chbAFIPWSRequiereComprobanteAsociado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAFIPWSRequiereComprobanteAsociado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAFIPWSRequiereComprobanteAsociado.IsPK = False
        Me.chbAFIPWSRequiereComprobanteAsociado.IsRequired = False
        Me.chbAFIPWSRequiereComprobanteAsociado.Key = Nothing
        Me.chbAFIPWSRequiereComprobanteAsociado.LabelAsoc = Nothing
        Me.chbAFIPWSRequiereComprobanteAsociado.Location = New System.Drawing.Point(27, 50)
        Me.chbAFIPWSRequiereComprobanteAsociado.Name = "chbAFIPWSRequiereComprobanteAsociado"
        Me.chbAFIPWSRequiereComprobanteAsociado.Size = New System.Drawing.Size(182, 17)
        Me.chbAFIPWSRequiereComprobanteAsociado.TabIndex = 2
        Me.chbAFIPWSRequiereComprobanteAsociado.Text = "Requiere Comprobante Asociado"
        Me.chbAFIPWSRequiereComprobanteAsociado.UseVisualStyleBackColor = True
        '
        'chbAFIPWSEsFEC
        '
        Me.chbAFIPWSEsFEC.AutoSize = True
        Me.chbAFIPWSEsFEC.BindearPropiedadControl = "Checked"
        Me.chbAFIPWSEsFEC.BindearPropiedadEntidad = "AFIPWSEsFEC"
        Me.chbAFIPWSEsFEC.CausesValidation = False
        Me.chbAFIPWSEsFEC.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAFIPWSEsFEC.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAFIPWSEsFEC.IsPK = False
        Me.chbAFIPWSEsFEC.IsRequired = False
        Me.chbAFIPWSEsFEC.Key = Nothing
        Me.chbAFIPWSEsFEC.LabelAsoc = Nothing
        Me.chbAFIPWSEsFEC.Location = New System.Drawing.Point(27, 16)
        Me.chbAFIPWSEsFEC.Name = "chbAFIPWSEsFEC"
        Me.chbAFIPWSEsFEC.Size = New System.Drawing.Size(245, 17)
        Me.chbAFIPWSEsFEC.TabIndex = 0
        Me.chbAFIPWSEsFEC.Text = "Factura de Crédito Electrónica MiPyMEs (FCE)"
        Me.chbAFIPWSEsFEC.UseVisualStyleBackColor = True
        '
        'tbpExportaciones
        '
        Me.tbpExportaciones.BackColor = System.Drawing.SystemColors.Control
        Me.tbpExportaciones.Controls.Add(Me.txtCodigoRoela)
        Me.tbpExportaciones.Controls.Add(Me.lblCodigoRoela)
        Me.tbpExportaciones.Location = New System.Drawing.Point(4, 22)
        Me.tbpExportaciones.Name = "tbpExportaciones"
        Me.tbpExportaciones.Size = New System.Drawing.Size(871, 198)
        Me.tbpExportaciones.TabIndex = 4
        Me.tbpExportaciones.Text = "Exportaciones"
        '
        'txtCodigoRoela
        '
        Me.txtCodigoRoela.BindearPropiedadControl = "Text"
        Me.txtCodigoRoela.BindearPropiedadEntidad = "CodigoRoela"
        Me.txtCodigoRoela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoRoela.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoRoela.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoRoela.Formato = ""
        Me.txtCodigoRoela.IsDecimal = False
        Me.txtCodigoRoela.IsNumber = False
        Me.txtCodigoRoela.IsPK = False
        Me.txtCodigoRoela.IsRequired = False
        Me.txtCodigoRoela.Key = ""
        Me.txtCodigoRoela.LabelAsoc = Me.lblCodigoRoela
        Me.txtCodigoRoela.Location = New System.Drawing.Point(91, 14)
        Me.txtCodigoRoela.MaxLength = 1
        Me.txtCodigoRoela.Name = "txtCodigoRoela"
        Me.txtCodigoRoela.Size = New System.Drawing.Size(31, 20)
        Me.txtCodigoRoela.TabIndex = 22
        Me.txtCodigoRoela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCodigoRoela
        '
        Me.lblCodigoRoela.AutoSize = True
        Me.lblCodigoRoela.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoRoela.LabelAsoc = Nothing
        Me.lblCodigoRoela.Location = New System.Drawing.Point(14, 17)
        Me.lblCodigoRoela.Name = "lblCodigoRoela"
        Me.lblCodigoRoela.Size = New System.Drawing.Size(71, 13)
        Me.lblCodigoRoela.TabIndex = 21
        Me.lblCodigoRoela.Text = "Código Roela"
        '
        'lblOrdeTipoComprobante
        '
        Me.lblOrdeTipoComprobante.AutoSize = True
        Me.lblOrdeTipoComprobante.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOrdeTipoComprobante.LabelAsoc = Nothing
        Me.lblOrdeTipoComprobante.Location = New System.Drawing.Point(790, 33)
        Me.lblOrdeTipoComprobante.Name = "lblOrdeTipoComprobante"
        Me.lblOrdeTipoComprobante.Size = New System.Drawing.Size(36, 13)
        Me.lblOrdeTipoComprobante.TabIndex = 8
        Me.lblOrdeTipoComprobante.Text = "Orden"
        '
        'txtOrdenTipoComprobante
        '
        Me.txtOrdenTipoComprobante.BindearPropiedadControl = "Text"
        Me.txtOrdenTipoComprobante.BindearPropiedadEntidad = "Orden"
        Me.txtOrdenTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenTipoComprobante.Formato = ""
        Me.txtOrdenTipoComprobante.IsDecimal = False
        Me.txtOrdenTipoComprobante.IsNumber = True
        Me.txtOrdenTipoComprobante.IsPK = False
        Me.txtOrdenTipoComprobante.IsRequired = True
        Me.txtOrdenTipoComprobante.Key = ""
        Me.txtOrdenTipoComprobante.LabelAsoc = Me.lblOrdeTipoComprobante
        Me.txtOrdenTipoComprobante.Location = New System.Drawing.Point(835, 29)
        Me.txtOrdenTipoComprobante.MaxLength = 3
        Me.txtOrdenTipoComprobante.Name = "txtOrdenTipoComprobante"
        Me.txtOrdenTipoComprobante.Size = New System.Drawing.Size(29, 20)
        Me.txtOrdenTipoComprobante.TabIndex = 9
        Me.txtOrdenTipoComprobante.Text = "0"
        Me.txtOrdenTipoComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescripcionImpresion
        '
        Me.lblDescripcionImpresion.AutoSize = True
        Me.lblDescripcionImpresion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescripcionImpresion.LabelAsoc = Nothing
        Me.lblDescripcionImpresion.Location = New System.Drawing.Point(23, 83)
        Me.lblDescripcionImpresion.Name = "lblDescripcionImpresion"
        Me.lblDescripcionImpresion.Size = New System.Drawing.Size(86, 13)
        Me.lblDescripcionImpresion.TabIndex = 18
        Me.lblDescripcionImpresion.Text = "Descr. Impresión"
        '
        'txtDescripcionImpresion
        '
        Me.txtDescripcionImpresion.BindearPropiedadControl = "Text"
        Me.txtDescripcionImpresion.BindearPropiedadEntidad = "DescripcionImpresion"
        Me.txtDescripcionImpresion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcionImpresion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcionImpresion.Formato = ""
        Me.txtDescripcionImpresion.IsDecimal = False
        Me.txtDescripcionImpresion.IsNumber = False
        Me.txtDescripcionImpresion.IsPK = False
        Me.txtDescripcionImpresion.IsRequired = True
        Me.txtDescripcionImpresion.Key = ""
        Me.txtDescripcionImpresion.LabelAsoc = Me.lblDescripcionImpresion
        Me.txtDescripcionImpresion.Location = New System.Drawing.Point(120, 79)
        Me.txtDescripcionImpresion.MaxLength = 70
        Me.txtDescripcionImpresion.Name = "txtDescripcionImpresion"
        Me.txtDescripcionImpresion.Size = New System.Drawing.Size(530, 20)
        Me.txtDescripcionImpresion.TabIndex = 19
        '
        'txtColor
        '
        Me.txtColor.BindearPropiedadControl = "Key"
        Me.txtColor.BindearPropiedadEntidad = "Color"
        Me.txtColor.Enabled = False
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Me.chbColor
        Me.txtColor.Location = New System.Drawing.Point(749, 79)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(47, 20)
        Me.txtColor.TabIndex = 21
        Me.txtColor.TabStop = False
        '
        'chbColor
        '
        Me.chbColor.AutoSize = True
        Me.chbColor.BindearPropiedadControl = Nothing
        Me.chbColor.BindearPropiedadEntidad = Nothing
        Me.chbColor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbColor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbColor.IsPK = False
        Me.chbColor.IsRequired = False
        Me.chbColor.Key = Nothing
        Me.chbColor.LabelAsoc = Nothing
        Me.chbColor.Location = New System.Drawing.Point(675, 83)
        Me.chbColor.Name = "chbColor"
        Me.chbColor.Size = New System.Drawing.Size(50, 17)
        Me.chbColor.TabIndex = 20
        Me.chbColor.Text = "Color"
        '
        'btnColor
        '
        Me.btnColor.Enabled = False
        Me.btnColor.Location = New System.Drawing.Point(802, 78)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(62, 23)
        Me.btnColor.TabIndex = 22
        Me.btnColor.Text = "Paleta"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'lblClaseComprobante
        '
        Me.lblClaseComprobante.AutoSize = True
        Me.lblClaseComprobante.LabelAsoc = Nothing
        Me.lblClaseComprobante.Location = New System.Drawing.Point(440, 57)
        Me.lblClaseComprobante.Name = "lblClaseComprobante"
        Me.lblClaseComprobante.Size = New System.Drawing.Size(33, 13)
        Me.lblClaseComprobante.TabIndex = 14
        Me.lblClaseComprobante.Text = "Clase"
        '
        'cmbClaseComprobante
        '
        Me.cmbClaseComprobante.BindearPropiedadControl = "SelectedValue"
        Me.cmbClaseComprobante.BindearPropiedadEntidad = "ClaseComprobante"
        Me.cmbClaseComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClaseComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClaseComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbClaseComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbClaseComprobante.FormattingEnabled = True
        Me.cmbClaseComprobante.IsPK = False
        Me.cmbClaseComprobante.IsRequired = False
        Me.cmbClaseComprobante.Items.AddRange(New Object() {"", "SOLOPRECIOS", "NO", "SI"})
        Me.cmbClaseComprobante.Key = Nothing
        Me.cmbClaseComprobante.LabelAsoc = Nothing
        Me.cmbClaseComprobante.Location = New System.Drawing.Point(546, 53)
        Me.cmbClaseComprobante.Name = "cmbClaseComprobante"
        Me.cmbClaseComprobante.Size = New System.Drawing.Size(104, 21)
        Me.cmbClaseComprobante.TabIndex = 15
        '
        'TiposComprobantesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(880, 577)
        Me.Controls.Add(Me.cmbClaseComprobante)
        Me.Controls.Add(Me.lblClaseComprobante)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.chbColor)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.lblDescripcionImpresion)
        Me.Controls.Add(Me.txtDescripcionImpresion)
        Me.Controls.Add(Me.lblOrdeTipoComprobante)
        Me.Controls.Add(Me.txtOrdenTipoComprobante)
        Me.Controls.Add(Me.tbcComporbantes)
        Me.Controls.Add(Me.txtIdPlanCuenta)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtGrupo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtDescripAbrev)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtLetrasHabilitadas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtCategoria)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TiposComprobantesDetalle"
        Me.Text = "Tipo Comprobante"
        Me.Controls.SetChildIndex(Me.txtCategoria, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtTipo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtLetrasHabilitadas, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtDescripAbrev, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtGrupo, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.txtIdPlanCuenta, 0)
        Me.Controls.SetChildIndex(Me.tbcComporbantes, 0)
        Me.Controls.SetChildIndex(Me.txtOrdenTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.lblOrdeTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcionImpresion, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcionImpresion, 0)
        Me.Controls.SetChildIndex(Me.btnColor, 0)
        Me.Controls.SetChildIndex(Me.chbColor, 0)
        Me.Controls.SetChildIndex(Me.txtColor, 0)
        Me.Controls.SetChildIndex(Me.lblClaseComprobante, 0)
        Me.Controls.SetChildIndex(Me.cmbClaseComprobante, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbcComporbantes.ResumeLayout(False)
        Me.tbpDetalle.ResumeLayout(False)
        Me.tbpDetalle.PerformLayout()
        Me.tbpCompAsoci.ResumeLayout(False)
        CType(Me.ugComprobantesAsociados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpProducto.ResumeLayout(False)
        Me.tbpProducto.PerformLayout()
        CType(Me.ugProductoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpAFIP.ResumeLayout(False)
        Me.tbpAFIP.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbpExportaciones.ResumeLayout(False)
        Me.tbpExportaciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblId As Eniac.Controles.Label
    Friend WithEvents txtCategoria As Eniac.Controles.TextBox
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
    Friend WithEvents Label2 As Eniac.Controles.Label
    Friend WithEvents txtTipo As Eniac.Controles.TextBox
    Public WithEvents cmbCoeficienteStock As Eniac.Controles.ComboBox
    Friend WithEvents Label3 As Eniac.Controles.Label
    Friend WithEvents Label6 As Eniac.Controles.Label
    Friend WithEvents txtLetrasHabilitadas As Eniac.Controles.TextBox
    Friend WithEvents Label7 As Eniac.Controles.Label
    Friend WithEvents txtCantMaxItems As Eniac.Controles.TextBox
    Public WithEvents cmbCoefValores As Eniac.Controles.ComboBox
    Friend WithEvents Label9 As Eniac.Controles.Label
    Public WithEvents cmbModificaAlFacturar As Eniac.Controles.ComboBox
    Friend WithEvents Label10 As Eniac.Controles.Label
    Friend WithEvents Label15 As Eniac.Controles.Label
    Friend WithEvents txtDescripAbrev As Eniac.Controles.TextBox
    Friend WithEvents Label17 As Eniac.Controles.Label
    Friend WithEvents txtCantidadCopias As Eniac.Controles.TextBox
    Friend WithEvents chbGrabaLibro As Eniac.Controles.CheckBox
    Friend WithEvents chbImprime As Eniac.Controles.CheckBox
    Friend WithEvents chbAfectaCaja As Eniac.Controles.CheckBox
    Friend WithEvents chbActualizaCtaCte As Eniac.Controles.CheckBox
    Friend WithEvents chbEsFiscal As Eniac.Controles.CheckBox
    Friend WithEvents chbEsFacturador As Eniac.Controles.CheckBox
    Friend WithEvents chbCargaPrecioActual As Eniac.Controles.CheckBox
    Friend WithEvents chbPuedeSerBorrado As Eniac.Controles.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chbEsComercial As Eniac.Controles.CheckBox
    Friend WithEvents chbEsRemitoTransportista As Eniac.Controles.CheckBox
    Friend WithEvents Label4 As Eniac.Controles.Label
    Friend WithEvents txtCantidadMaximaItemsObserv As Eniac.Controles.TextBox
    Friend WithEvents chbGeneraContabilidad As Eniac.Controles.CheckBox
    Friend WithEvents chbEsRecibo As Eniac.Controles.CheckBox
    Friend WithEvents chbEsAnticipo As Eniac.Controles.CheckBox
    Friend WithEvents chbEsPreElectronico As Eniac.Controles.CheckBox
    Friend WithEvents chbNumeracionAutomatica As Eniac.Controles.CheckBox
    Friend WithEvents chbUtilizaImpuestos As Eniac.Controles.CheckBox
    Friend WithEvents chbGeneraObservConInvocados As Eniac.Controles.CheckBox
    Friend WithEvents chbEsElectronico As Eniac.Controles.CheckBox
    Friend WithEvents chbUsaFacturacion As Eniac.Controles.CheckBox
    Friend WithEvents chbUsaFacturacionRapida As Eniac.Controles.CheckBox
    Friend WithEvents Label8 As Eniac.Controles.Label
    Friend WithEvents txtImporteTope As Eniac.Controles.TextBox
    Friend WithEvents Label11 As Eniac.Controles.Label
    Friend WithEvents txtIdTipoComprobanteEpson As Eniac.Controles.TextBox
    Friend WithEvents Label12 As Eniac.Controles.Label
    Friend WithEvents txtImporteMinimo As Eniac.Controles.TextBox
    Friend WithEvents Label13 As Eniac.Controles.Label
    Friend WithEvents Label14 As Eniac.Controles.Label
    Friend WithEvents txtGrupo As Eniac.Controles.TextBox
    Friend WithEvents CheckBox2 As Eniac.Controles.CheckBox
    Friend WithEvents CheckBox1 As Eniac.Controles.CheckBox
    Friend WithEvents txtIdPlanCuenta As Eniac.Controles.TextBox
    Public WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
    Friend WithEvents chbComprobanteSecundario As Eniac.Controles.CheckBox
    Friend WithEvents chbUtilizaCtaSecundariaProd As Eniac.Controles.CheckBox
    Friend WithEvents chbUtilizaCtaSecundariaCateg As Eniac.Controles.CheckBox
    Friend WithEvents chbIncluirEnExpensas As Eniac.Controles.CheckBox
    Public WithEvents cmbTipoComprobanteNCred As Eniac.Controles.ComboBox
    Friend WithEvents chbTipoComprobanteNCred As Eniac.Controles.CheckBox
    Public WithEvents cmbTipoComprobanteNDeb As Eniac.Controles.ComboBox
    Friend WithEvents chbTipoComprobanteNDeb As Eniac.Controles.CheckBox
    Friend WithEvents bscCodigoProducto2Cred As Eniac.Controles.Buscador2
    Friend WithEvents bscProducto2Cred As Eniac.Controles.Buscador2
    Friend WithEvents chbCodigoProducto2Cred As Eniac.Controles.CheckBox
    Friend WithEvents chbCodigoProducto2Deb As Eniac.Controles.CheckBox
    Friend WithEvents bscCodigoProducto2Deb As Eniac.Controles.Buscador2
    Friend WithEvents bscProducto2Deb As Eniac.Controles.Buscador2
    Friend WithEvents chbConsumePedidos As Eniac.Controles.CheckBox
    Friend WithEvents chbDespachoImportacion As Eniac.Controles.CheckBox
    Friend WithEvents txtCodigoComprobanteSifere As Eniac.Controles.TextBox
    Friend WithEvents lblCodigoComprobanteSifere As Eniac.Controles.Label
    Friend WithEvents chbCargaDescRecActual As Eniac.Controles.CheckBox
    Public WithEvents cmbTipoComprobanteContraMovInvocar As Eniac.Controles.ComboBox
    Friend WithEvents chbTipoComprobanteContraMovInvocar As Eniac.Controles.CheckBox
    Friend WithEvents CheckBox5 As Eniac.Controles.CheckBox
    Friend WithEvents CheckBox4 As Eniac.Controles.CheckBox
    Friend WithEvents CheckBox3 As Eniac.Controles.CheckBox
    Friend WithEvents CheckBox6 As Eniac.Controles.CheckBox
    Friend WithEvents txtLargoMaximoNumero As Eniac.Controles.TextBox
    Friend WithEvents lblLargoMaximoNumero As Eniac.Controles.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtNivelAutorizacion As Eniac.Controles.TextBox
    Friend WithEvents lblNivelAutorizacion As Eniac.Controles.Label
    Friend WithEvents CheckBox7 As Eniac.Controles.CheckBox
    Friend WithEvents chbControlaTopeConsumidorFinal As Eniac.Controles.CheckBox
    Friend WithEvents chbCargaDescRecGralActual As Eniac.Controles.CheckBox
    Friend WithEvents tbcComporbantes As System.Windows.Forms.TabControl
    Friend WithEvents tbpDetalle As System.Windows.Forms.TabPage
    Friend WithEvents tbpProducto As System.Windows.Forms.TabPage
    Friend WithEvents btnInsertarProducto As Eniac.Controles.Button
    Friend WithEvents btnEliminarContacto As Eniac.Controles.Button
    Friend WithEvents ugProductoDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents btnLimpiarProducto As Eniac.Controles.Button
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents txtCantidad As Eniac.Controles.TextBox
    Friend WithEvents lblCantidad As Eniac.Controles.Label
    Friend WithEvents lblProducto As Eniac.Controles.Label
    Friend WithEvents lblCodProducto As Eniac.Controles.Label
    Friend WithEvents tbpCompAsoci As System.Windows.Forms.TabPage
    Friend WithEvents chbEsReciboClienteVinculado As Eniac.Controles.CheckBox
    Friend WithEvents tbpAFIP As System.Windows.Forms.TabPage
    Friend WithEvents chbAFIPWSEsFEC As Eniac.Controles.CheckBox
    Friend WithEvents cmbAFIPWSIncluyeFechaVencimiento As Eniac.Controles.ComboBox
    Friend WithEvents lblIncluyeFechaVencimiento As Eniac.Controles.Label
    Friend WithEvents chbAFIPWSRequiereReferenciaComercial As Eniac.Controles.CheckBox
    Friend WithEvents chbAFIPWSRequiereComprobanteAsociado As Eniac.Controles.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chbAFIPWSRequiereCBU As Eniac.Controles.CheckBox
    Friend WithEvents chbAFIPWSCodigoAnulacion As Eniac.Controles.CheckBox
    Friend WithEvents lblOrdeTipoComprobante As Eniac.Controles.Label
    Friend WithEvents txtOrdenTipoComprobante As Eniac.Controles.TextBox
    Friend WithEvents chbMarcaInvocado As Eniac.Controles.CheckBox
    Friend WithEvents chbPermiteSeleccionarAlicuotaIVA As Eniac.Controles.CheckBox
    Friend WithEvents chbImportaObsGrales As Eniac.Controles.CheckBox
    Friend WithEvents lblDescripcionImpresion As Eniac.Controles.Label
    Friend WithEvents txtDescripcionImpresion As Eniac.Controles.TextBox
    Friend WithEvents chbInformaLibroIVA As Eniac.Controles.CheckBox
    Friend WithEvents ugComprobantesAsociados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chbSolicitaFechaDevolucion As Eniac.Controles.CheckBox
    Friend WithEvents CheckBox8 As Controles.CheckBox
    Friend WithEvents chbActivaTildeMercDespEnv As Controles.CheckBox
    Friend WithEvents txtColor As Controles.TextBox
    Friend WithEvents chbColor As Controles.CheckBox
    Friend WithEvents btnColor As Button
    Friend WithEvents cdColor As ColorDialog
    Friend WithEvents tbpExportaciones As TabPage
    Friend WithEvents txtCodigoRoela As Controles.TextBox
    Friend WithEvents lblCodigoRoela As Controles.Label
    Friend WithEvents lblClaseComprobante As Controles.Label
    Public WithEvents cmbClaseComprobante As Controles.ComboBox
    Friend WithEvents chbSolicitaInformeCalidad As Controles.CheckBox
End Class
