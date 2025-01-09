<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarComprasDetalle
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoImpuesto")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProvincia")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Emisor")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BaseImponible")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoImpuesto")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoTipoImpuesto")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsDespacho")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bruto")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarComprasDetalle))
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador2()
      Me.lblNombreProv = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.lblComprador = New Eniac.Controles.Label()
      Me.cmbComprador = New Eniac.Controles.ComboBox()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.cboRubro = New Eniac.Controles.ComboBox()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.lblProveedor = New Eniac.Controles.Label()
      Me.grpComprobante = New System.Windows.Forms.GroupBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.lblComprobante = New Eniac.Controles.Label()
      Me.txtNumeroFactura = New Eniac.Controles.TextBox()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.txtEmisorFactura = New Eniac.Controles.TextBox()
      Me.cboTipoComprobante = New Eniac.Controles.ComboBox()
      Me.lblNumeroFactura = New Eniac.Controles.Label()
      Me.lblEmisorFactura = New Eniac.Controles.Label()
      Me.lblTipoFactura = New Eniac.Controles.Label()
      Me.cboLetra = New Eniac.Controles.ComboBox()
      Me.lblPeriodoFiscal = New Eniac.Controles.Label()
      Me.cboPeriodoFiscal = New Eniac.Controles.ComboBox()
      Me.cboFormaPago = New Eniac.Controles.ComboBox()
      Me.lblFormaPago = New Eniac.Controles.Label()
      Me.grpProveedor = New System.Windows.Forms.GroupBox()
      Me.txtCategoriaFiscal = New Eniac.Controles.TextBox()
      Me.lblCategoriaFiscal = New System.Windows.Forms.Label()
      Me.grbDescRecargo = New System.Windows.Forms.GroupBox()
      Me.lblTotalDescRec = New Eniac.Controles.Label()
      Me.txtPorcDescRecargoGral = New Eniac.Controles.TextBox()
      Me.grbPercepciones = New System.Windows.Forms.GroupBox()
      Me.btnPercIIBB = New System.Windows.Forms.Button()
      Me.lblPercepcionTotal = New Eniac.Controles.Label()
      Me.txtPercepcionTotal = New Eniac.Controles.TextBox()
      Me.lblPercepcionVarias = New Eniac.Controles.Label()
      Me.txtPercepcionVarias = New Eniac.Controles.TextBox()
      Me.lblPercepcionGanancias = New Eniac.Controles.Label()
      Me.txtPercepcionGanancias = New Eniac.Controles.TextBox()
      Me.lblPercepcionIB = New Eniac.Controles.Label()
      Me.txtPercepcionIB = New Eniac.Controles.TextBox()
      Me.lblPercepcionIVA = New Eniac.Controles.Label()
      Me.txtPercepcionIVA = New Eniac.Controles.TextBox()
      Me.grbTotales = New System.Windows.Forms.GroupBox()
      Me.txtTotalGeneral = New Eniac.Controles.TextBox()
      Me.txtTotalPercepciones = New Eniac.Controles.TextBox()
      Me.lblTotalPercepciones = New Eniac.Controles.Label()
      Me.txtTotalIVA = New Eniac.Controles.TextBox()
      Me.lblTotalIVA = New Eniac.Controles.Label()
      Me.lblTotalNeto = New Eniac.Controles.Label()
      Me.txtTotalNeto = New Eniac.Controles.TextBox()
      Me.txtTotalBruto = New Eniac.Controles.TextBox()
      Me.lblTotalBruto = New Eniac.Controles.Label()
      Me.lblTotalGeneral = New Eniac.Controles.Label()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tspFichas = New System.Windows.Forms.ToolStrip()
      Me.ugIVAs = New Eniac.Win.UltraGridEditable()
      Me.chbMercaderiaEnviada = New Eniac.Controles.CheckBox()
      Me.grpComprobante.SuspendLayout()
      Me.grpProveedor.SuspendLayout()
      Me.grbDescRecargo.SuspendLayout()
      Me.grbPercepciones.SuspendLayout()
      Me.grbTotales.SuspendLayout()
      Me.tspFichas.SuspendLayout()
      CType(Me.ugIVAs, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'bscCodigoProveedor
      '
      Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
      Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedor.ConfigBuscador = Nothing
      Me.bscCodigoProveedor.Datos = Nothing
      Me.bscCodigoProveedor.Enabled = False
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = False
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(87, 33)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 52
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.LabelAsoc = Nothing
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(84, 16)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProveedor.TabIndex = 56
      Me.lblCodigoProveedor.Text = "Código"
      '
      'bscProveedor
      '
      Me.bscProveedor.ActivarFiltroEnGrilla = True
      Me.bscProveedor.AutoSize = True
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ConfigBuscador = Nothing
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.Enabled = False
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProveedor.IsDecimal = False
      Me.bscProveedor.IsNumber = False
      Me.bscProveedor.IsPK = False
      Me.bscProveedor.IsRequired = False
      Me.bscProveedor.Key = ""
      Me.bscProveedor.LabelAsoc = Me.lblNombreProv
      Me.bscProveedor.Location = New System.Drawing.Point(182, 33)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
      Me.bscProveedor.TabIndex = 53
      '
      'lblNombreProv
      '
      Me.lblNombreProv.AutoSize = True
      Me.lblNombreProv.LabelAsoc = Nothing
      Me.lblNombreProv.Location = New System.Drawing.Point(183, 16)
      Me.lblNombreProv.Name = "lblNombreProv"
      Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProv.TabIndex = 54
      Me.lblNombreProv.Text = "Nombre"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Nothing
      Me.dtpDesde.Location = New System.Drawing.Point(517, 24)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(127, 20)
      Me.dtpDesde.TabIndex = 10
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.ForeColor = System.Drawing.Color.Red
      Me.lblFecha.LabelAsoc = Nothing
      Me.lblFecha.Location = New System.Drawing.Point(471, 28)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 9
      Me.lblFecha.Text = "Fecha"
      '
      'lblComprador
      '
      Me.lblComprador.AutoSize = True
      Me.lblComprador.ForeColor = System.Drawing.Color.Red
      Me.lblComprador.LabelAsoc = Nothing
      Me.lblComprador.Location = New System.Drawing.Point(6, 62)
      Me.lblComprador.Name = "lblComprador"
      Me.lblComprador.Size = New System.Drawing.Size(58, 13)
      Me.lblComprador.TabIndex = 13
      Me.lblComprador.Text = "Comprador"
      '
      'cmbComprador
      '
      Me.cmbComprador.BindearPropiedadControl = Nothing
      Me.cmbComprador.BindearPropiedadEntidad = Nothing
      Me.cmbComprador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComprador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbComprador.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbComprador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbComprador.FormattingEnabled = True
      Me.cmbComprador.IsPK = False
      Me.cmbComprador.IsRequired = False
      Me.cmbComprador.Key = Nothing
      Me.cmbComprador.LabelAsoc = Nothing
      Me.cmbComprador.Location = New System.Drawing.Point(84, 58)
      Me.cmbComprador.Name = "cmbComprador"
      Me.cmbComprador.Size = New System.Drawing.Size(171, 21)
      Me.cmbComprador.TabIndex = 14
      '
      'txtObservacion
      '
      Me.txtObservacion.BackColor = System.Drawing.Color.White
      Me.txtObservacion.BindearPropiedadControl = Nothing
      Me.txtObservacion.BindearPropiedadEntidad = Nothing
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Nothing
      Me.txtObservacion.Location = New System.Drawing.Point(83, 90)
      Me.txtObservacion.MaxLength = 100
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(556, 20)
      Me.txtObservacion.TabIndex = 18
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.ForeColor = System.Drawing.Color.Red
      Me.lblObservacion.LabelAsoc = Nothing
      Me.lblObservacion.Location = New System.Drawing.Point(6, 94)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 17
      Me.lblObservacion.Text = "Observación"
      '
      'cboRubro
      '
      Me.cboRubro.BindearPropiedadControl = Nothing
      Me.cboRubro.BindearPropiedadEntidad = Nothing
      Me.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cboRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboRubro.FormattingEnabled = True
      Me.cboRubro.IsPK = False
      Me.cboRubro.IsRequired = False
      Me.cboRubro.Key = Nothing
      Me.cboRubro.LabelAsoc = Nothing
      Me.cboRubro.Location = New System.Drawing.Point(317, 58)
      Me.cboRubro.Name = "cboRubro"
      Me.cboRubro.Size = New System.Drawing.Size(167, 21)
      Me.cboRubro.TabIndex = 16
      '
      'lblRubro
      '
      Me.lblRubro.AutoSize = True
      Me.lblRubro.ForeColor = System.Drawing.Color.Red
      Me.lblRubro.LabelAsoc = Nothing
      Me.lblRubro.Location = New System.Drawing.Point(275, 62)
      Me.lblRubro.Name = "lblRubro"
      Me.lblRubro.Size = New System.Drawing.Size(36, 13)
      Me.lblRubro.TabIndex = 15
      Me.lblRubro.Text = "Rubro"
      '
      'lblProveedor
      '
      Me.lblProveedor.AutoSize = True
      Me.lblProveedor.LabelAsoc = Nothing
      Me.lblProveedor.Location = New System.Drawing.Point(13, 35)
      Me.lblProveedor.Name = "lblProveedor"
      Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
      Me.lblProveedor.TabIndex = 73
      Me.lblProveedor.Text = "Proveedor"
      '
      'grpComprobante
      '
      Me.grpComprobante.Controls.Add(Me.chbMercaderiaEnviada)
      Me.grpComprobante.Controls.Add(Me.cmbCajas)
      Me.grpComprobante.Controls.Add(Me.Label1)
      Me.grpComprobante.Controls.Add(Me.lblComprobante)
      Me.grpComprobante.Controls.Add(Me.txtNumeroFactura)
      Me.grpComprobante.Controls.Add(Me.lblTipoComprobante)
      Me.grpComprobante.Controls.Add(Me.txtEmisorFactura)
      Me.grpComprobante.Controls.Add(Me.cboTipoComprobante)
      Me.grpComprobante.Controls.Add(Me.lblNumeroFactura)
      Me.grpComprobante.Controls.Add(Me.lblEmisorFactura)
      Me.grpComprobante.Controls.Add(Me.lblTipoFactura)
      Me.grpComprobante.Controls.Add(Me.cboLetra)
      Me.grpComprobante.Controls.Add(Me.lblPeriodoFiscal)
      Me.grpComprobante.Controls.Add(Me.cboPeriodoFiscal)
      Me.grpComprobante.Controls.Add(Me.cboFormaPago)
      Me.grpComprobante.Controls.Add(Me.lblFormaPago)
      Me.grpComprobante.Controls.Add(Me.txtObservacion)
      Me.grpComprobante.Controls.Add(Me.lblObservacion)
      Me.grpComprobante.Controls.Add(Me.dtpDesde)
      Me.grpComprobante.Controls.Add(Me.lblFecha)
      Me.grpComprobante.Controls.Add(Me.cmbComprador)
      Me.grpComprobante.Controls.Add(Me.lblComprador)
      Me.grpComprobante.Controls.Add(Me.cboRubro)
      Me.grpComprobante.Controls.Add(Me.lblRubro)
      Me.grpComprobante.Location = New System.Drawing.Point(6, 101)
      Me.grpComprobante.Name = "grpComprobante"
      Me.grpComprobante.Size = New System.Drawing.Size(951, 120)
      Me.grpComprobante.TabIndex = 1
      Me.grpComprobante.TabStop = False
      '
      'cmbCajas
      '
      Me.cmbCajas.BindearPropiedadControl = Nothing
      Me.cmbCajas.BindearPropiedadEntidad = Nothing
      Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCajas.FormattingEnabled = True
      Me.cmbCajas.IsPK = False
      Me.cmbCajas.IsRequired = False
      Me.cmbCajas.Key = Nothing
      Me.cmbCajas.LabelAsoc = Nothing
      Me.cmbCajas.Location = New System.Drawing.Point(730, 59)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
      Me.cmbCajas.TabIndex = 22
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.ForeColor = System.Drawing.Color.Red
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(655, 62)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(28, 13)
      Me.Label1.TabIndex = 21
      Me.Label1.Text = "Caja"
      '
      'lblComprobante
      '
      Me.lblComprobante.AutoSize = True
      Me.lblComprobante.LabelAsoc = Nothing
      Me.lblComprobante.Location = New System.Drawing.Point(9, 28)
      Me.lblComprobante.Name = "lblComprobante"
      Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
      Me.lblComprobante.TabIndex = 0
      Me.lblComprobante.Text = "Comprobante"
      '
      'txtNumeroFactura
      '
      Me.txtNumeroFactura.BindearPropiedadControl = Nothing
      Me.txtNumeroFactura.BindearPropiedadEntidad = Nothing
      Me.txtNumeroFactura.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroFactura.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroFactura.Formato = ""
      Me.txtNumeroFactura.IsDecimal = False
      Me.txtNumeroFactura.IsNumber = True
      Me.txtNumeroFactura.IsPK = False
      Me.txtNumeroFactura.IsRequired = True
      Me.txtNumeroFactura.Key = ""
      Me.txtNumeroFactura.LabelAsoc = Nothing
      Me.txtNumeroFactura.Location = New System.Drawing.Point(364, 24)
      Me.txtNumeroFactura.MaxLength = 8
      Me.txtNumeroFactura.Name = "txtNumeroFactura"
      Me.txtNumeroFactura.Size = New System.Drawing.Size(92, 20)
      Me.txtNumeroFactura.TabIndex = 7
      Me.txtNumeroFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.LabelAsoc = Nothing
      Me.lblTipoComprobante.Location = New System.Drawing.Point(84, 9)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(28, 13)
      Me.lblTipoComprobante.TabIndex = 1
      Me.lblTipoComprobante.Text = "Tipo"
      '
      'txtEmisorFactura
      '
      Me.txtEmisorFactura.BindearPropiedadControl = Nothing
      Me.txtEmisorFactura.BindearPropiedadEntidad = Nothing
      Me.txtEmisorFactura.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisorFactura.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisorFactura.Formato = ""
      Me.txtEmisorFactura.IsDecimal = False
      Me.txtEmisorFactura.IsNumber = True
      Me.txtEmisorFactura.IsPK = False
      Me.txtEmisorFactura.IsRequired = True
      Me.txtEmisorFactura.Key = ""
      Me.txtEmisorFactura.LabelAsoc = Nothing
      Me.txtEmisorFactura.Location = New System.Drawing.Point(317, 24)
      Me.txtEmisorFactura.MaxLength = 4
      Me.txtEmisorFactura.Name = "txtEmisorFactura"
      Me.txtEmisorFactura.Size = New System.Drawing.Size(41, 20)
      Me.txtEmisorFactura.TabIndex = 6
      Me.txtEmisorFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cboTipoComprobante
      '
      Me.cboTipoComprobante.BackColor = System.Drawing.SystemColors.Control
      Me.cboTipoComprobante.BindearPropiedadControl = Nothing
      Me.cboTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTipoComprobante.Enabled = False
      Me.cboTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.cboTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboTipoComprobante.FormattingEnabled = True
      Me.cboTipoComprobante.IsPK = False
      Me.cboTipoComprobante.IsRequired = False
      Me.cboTipoComprobante.Key = Nothing
      Me.cboTipoComprobante.LabelAsoc = Me.lblTipoComprobante
      Me.cboTipoComprobante.Location = New System.Drawing.Point(86, 24)
      Me.cboTipoComprobante.Name = "cboTipoComprobante"
      Me.cboTipoComprobante.Size = New System.Drawing.Size(168, 21)
      Me.cboTipoComprobante.TabIndex = 2
      '
      'lblNumeroFactura
      '
      Me.lblNumeroFactura.AutoSize = True
      Me.lblNumeroFactura.ForeColor = System.Drawing.Color.Red
      Me.lblNumeroFactura.LabelAsoc = Nothing
      Me.lblNumeroFactura.Location = New System.Drawing.Point(406, 9)
      Me.lblNumeroFactura.Name = "lblNumeroFactura"
      Me.lblNumeroFactura.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroFactura.TabIndex = 8
      Me.lblNumeroFactura.Text = "Numero"
      '
      'lblEmisorFactura
      '
      Me.lblEmisorFactura.AutoSize = True
      Me.lblEmisorFactura.ForeColor = System.Drawing.Color.Red
      Me.lblEmisorFactura.LabelAsoc = Nothing
      Me.lblEmisorFactura.Location = New System.Drawing.Point(317, 9)
      Me.lblEmisorFactura.Name = "lblEmisorFactura"
      Me.lblEmisorFactura.Size = New System.Drawing.Size(38, 13)
      Me.lblEmisorFactura.TabIndex = 5
      Me.lblEmisorFactura.Text = "Emisor"
      '
      'lblTipoFactura
      '
      Me.lblTipoFactura.AutoSize = True
      Me.lblTipoFactura.LabelAsoc = Nothing
      Me.lblTipoFactura.Location = New System.Drawing.Point(258, 9)
      Me.lblTipoFactura.Name = "lblTipoFactura"
      Me.lblTipoFactura.Size = New System.Drawing.Size(31, 13)
      Me.lblTipoFactura.TabIndex = 3
      Me.lblTipoFactura.Text = "Letra"
      '
      'cboLetra
      '
      Me.cboLetra.BackColor = System.Drawing.SystemColors.Control
      Me.cboLetra.BindearPropiedadControl = Nothing
      Me.cboLetra.BindearPropiedadEntidad = Nothing
      Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLetra.Enabled = False
      Me.cboLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboLetra.FormattingEnabled = True
      Me.cboLetra.IsPK = False
      Me.cboLetra.IsRequired = False
      Me.cboLetra.Key = Nothing
      Me.cboLetra.LabelAsoc = Me.lblTipoFactura
      Me.cboLetra.Location = New System.Drawing.Point(260, 24)
      Me.cboLetra.Name = "cboLetra"
      Me.cboLetra.Size = New System.Drawing.Size(48, 21)
      Me.cboLetra.TabIndex = 4
      '
      'lblPeriodoFiscal
      '
      Me.lblPeriodoFiscal.AutoSize = True
      Me.lblPeriodoFiscal.ForeColor = System.Drawing.Color.Red
      Me.lblPeriodoFiscal.LabelAsoc = Nothing
      Me.lblPeriodoFiscal.Location = New System.Drawing.Point(655, 28)
      Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
      Me.lblPeriodoFiscal.Size = New System.Drawing.Size(73, 13)
      Me.lblPeriodoFiscal.TabIndex = 11
      Me.lblPeriodoFiscal.Text = "Periodo Fiscal"
      '
      'cboPeriodoFiscal
      '
      Me.cboPeriodoFiscal.BindearPropiedadControl = Nothing
      Me.cboPeriodoFiscal.BindearPropiedadEntidad = Nothing
      Me.cboPeriodoFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboPeriodoFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboPeriodoFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.cboPeriodoFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboPeriodoFiscal.FormatString = "0000/00"
      Me.cboPeriodoFiscal.FormattingEnabled = True
      Me.cboPeriodoFiscal.IsPK = False
      Me.cboPeriodoFiscal.IsRequired = False
      Me.cboPeriodoFiscal.Key = Nothing
      Me.cboPeriodoFiscal.LabelAsoc = Nothing
      Me.cboPeriodoFiscal.Location = New System.Drawing.Point(730, 24)
      Me.cboPeriodoFiscal.Name = "cboPeriodoFiscal"
      Me.cboPeriodoFiscal.Size = New System.Drawing.Size(75, 21)
      Me.cboPeriodoFiscal.TabIndex = 12
      '
      'cboFormaPago
      '
      Me.cboFormaPago.BindearPropiedadControl = Nothing
      Me.cboFormaPago.BindearPropiedadEntidad = Nothing
      Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboFormaPago.Enabled = False
      Me.cboFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cboFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboFormaPago.FormattingEnabled = True
      Me.cboFormaPago.IsPK = False
      Me.cboFormaPago.IsRequired = False
      Me.cboFormaPago.Key = Nothing
      Me.cboFormaPago.LabelAsoc = Nothing
      Me.cboFormaPago.Location = New System.Drawing.Point(730, 90)
      Me.cboFormaPago.Name = "cboFormaPago"
      Me.cboFormaPago.Size = New System.Drawing.Size(125, 21)
      Me.cboFormaPago.TabIndex = 20
      '
      'lblFormaPago
      '
      Me.lblFormaPago.AutoSize = True
      Me.lblFormaPago.LabelAsoc = Nothing
      Me.lblFormaPago.Location = New System.Drawing.Point(655, 97)
      Me.lblFormaPago.Name = "lblFormaPago"
      Me.lblFormaPago.Size = New System.Drawing.Size(64, 13)
      Me.lblFormaPago.TabIndex = 19
      Me.lblFormaPago.Text = "Forma Pago"
      '
      'grpProveedor
      '
      Me.grpProveedor.Controls.Add(Me.txtCategoriaFiscal)
      Me.grpProveedor.Controls.Add(Me.lblCategoriaFiscal)
      Me.grpProveedor.Controls.Add(Me.bscProveedor)
      Me.grpProveedor.Controls.Add(Me.lblNombreProv)
      Me.grpProveedor.Controls.Add(Me.lblCodigoProveedor)
      Me.grpProveedor.Controls.Add(Me.bscCodigoProveedor)
      Me.grpProveedor.Controls.Add(Me.lblProveedor)
      Me.grpProveedor.Location = New System.Drawing.Point(6, 32)
      Me.grpProveedor.Name = "grpProveedor"
      Me.grpProveedor.Size = New System.Drawing.Size(951, 67)
      Me.grpProveedor.TabIndex = 0
      Me.grpProveedor.TabStop = False
      '
      'txtCategoriaFiscal
      '
      Me.txtCategoriaFiscal.BindearPropiedadControl = Nothing
      Me.txtCategoriaFiscal.BindearPropiedadEntidad = Nothing
      Me.txtCategoriaFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCategoriaFiscal.Formato = ""
      Me.txtCategoriaFiscal.IsDecimal = False
      Me.txtCategoriaFiscal.IsNumber = False
      Me.txtCategoriaFiscal.IsPK = False
      Me.txtCategoriaFiscal.IsRequired = False
      Me.txtCategoriaFiscal.Key = ""
      Me.txtCategoriaFiscal.LabelAsoc = Nothing
      Me.txtCategoriaFiscal.Location = New System.Drawing.Point(489, 33)
      Me.txtCategoriaFiscal.Name = "txtCategoriaFiscal"
      Me.txtCategoriaFiscal.ReadOnly = True
      Me.txtCategoriaFiscal.Size = New System.Drawing.Size(164, 20)
      Me.txtCategoriaFiscal.TabIndex = 74
      Me.txtCategoriaFiscal.TabStop = False
      '
      'lblCategoriaFiscal
      '
      Me.lblCategoriaFiscal.AutoSize = True
      Me.lblCategoriaFiscal.Location = New System.Drawing.Point(486, 16)
      Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
      Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
      Me.lblCategoriaFiscal.TabIndex = 75
      Me.lblCategoriaFiscal.Text = "Categoria Fiscal"
      '
      'grbDescRecargo
      '
      Me.grbDescRecargo.Controls.Add(Me.lblTotalDescRec)
      Me.grbDescRecargo.Controls.Add(Me.txtPorcDescRecargoGral)
      Me.grbDescRecargo.Location = New System.Drawing.Point(531, 224)
      Me.grbDescRecargo.Name = "grbDescRecargo"
      Me.grbDescRecargo.Size = New System.Drawing.Size(75, 123)
      Me.grbDescRecargo.TabIndex = 99
      Me.grbDescRecargo.TabStop = False
      Me.grbDescRecargo.Text = "Descuento / Recargo"
      '
      'lblTotalDescRec
      '
      Me.lblTotalDescRec.AutoSize = True
      Me.lblTotalDescRec.LabelAsoc = Nothing
      Me.lblTotalDescRec.Location = New System.Drawing.Point(33, 38)
      Me.lblTotalDescRec.Name = "lblTotalDescRec"
      Me.lblTotalDescRec.Size = New System.Drawing.Size(15, 13)
      Me.lblTotalDescRec.TabIndex = 8
      Me.lblTotalDescRec.Text = "%"
      '
      'txtPorcDescRecargoGral
      '
      Me.txtPorcDescRecargoGral.BindearPropiedadControl = Nothing
      Me.txtPorcDescRecargoGral.BindearPropiedadEntidad = Nothing
      Me.txtPorcDescRecargoGral.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPorcDescRecargoGral.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPorcDescRecargoGral.Formato = "##0.00"
      Me.txtPorcDescRecargoGral.IsDecimal = True
      Me.txtPorcDescRecargoGral.IsNumber = True
      Me.txtPorcDescRecargoGral.IsPK = False
      Me.txtPorcDescRecargoGral.IsRequired = False
      Me.txtPorcDescRecargoGral.Key = ""
      Me.txtPorcDescRecargoGral.LabelAsoc = Me.lblTotalDescRec
      Me.txtPorcDescRecargoGral.Location = New System.Drawing.Point(18, 54)
      Me.txtPorcDescRecargoGral.MaxLength = 7
      Me.txtPorcDescRecargoGral.Name = "txtPorcDescRecargoGral"
      Me.txtPorcDescRecargoGral.ReadOnly = True
      Me.txtPorcDescRecargoGral.Size = New System.Drawing.Size(45, 20)
      Me.txtPorcDescRecargoGral.TabIndex = 0
      Me.txtPorcDescRecargoGral.Text = "0.00"
      Me.txtPorcDescRecargoGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'grbPercepciones
      '
      Me.grbPercepciones.Controls.Add(Me.btnPercIIBB)
      Me.grbPercepciones.Controls.Add(Me.lblPercepcionTotal)
      Me.grbPercepciones.Controls.Add(Me.txtPercepcionTotal)
      Me.grbPercepciones.Controls.Add(Me.lblPercepcionVarias)
      Me.grbPercepciones.Controls.Add(Me.txtPercepcionVarias)
      Me.grbPercepciones.Controls.Add(Me.lblPercepcionGanancias)
      Me.grbPercepciones.Controls.Add(Me.txtPercepcionGanancias)
      Me.grbPercepciones.Controls.Add(Me.lblPercepcionIB)
      Me.grbPercepciones.Controls.Add(Me.txtPercepcionIB)
      Me.grbPercepciones.Controls.Add(Me.lblPercepcionIVA)
      Me.grbPercepciones.Controls.Add(Me.txtPercepcionIVA)
      Me.grbPercepciones.Location = New System.Drawing.Point(612, 224)
      Me.grbPercepciones.Name = "grbPercepciones"
      Me.grbPercepciones.Size = New System.Drawing.Size(185, 123)
      Me.grbPercepciones.TabIndex = 102
      Me.grbPercepciones.TabStop = False
      Me.grbPercepciones.Text = "Percepciones"
      '
      'btnPercIIBB
      '
      Me.btnPercIIBB.Location = New System.Drawing.Point(155, 33)
      Me.btnPercIIBB.Name = "btnPercIIBB"
      Me.btnPercIIBB.Size = New System.Drawing.Size(27, 20)
      Me.btnPercIIBB.TabIndex = 28
      Me.btnPercIIBB.Text = "..."
      Me.btnPercIIBB.UseVisualStyleBackColor = True
      '
      'lblPercepcionTotal
      '
      Me.lblPercepcionTotal.AutoSize = True
      Me.lblPercepcionTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblPercepcionTotal.LabelAsoc = Nothing
      Me.lblPercepcionTotal.Location = New System.Drawing.Point(8, 103)
      Me.lblPercepcionTotal.Name = "lblPercepcionTotal"
      Me.lblPercepcionTotal.Size = New System.Drawing.Size(36, 13)
      Me.lblPercepcionTotal.TabIndex = 27
      Me.lblPercepcionTotal.Text = "Total"
      '
      'txtPercepcionTotal
      '
      Me.txtPercepcionTotal.BindearPropiedadControl = Nothing
      Me.txtPercepcionTotal.BindearPropiedadEntidad = Nothing
      Me.txtPercepcionTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPercepcionTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPercepcionTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPercepcionTotal.Formato = "##0.00"
      Me.txtPercepcionTotal.IsDecimal = True
      Me.txtPercepcionTotal.IsNumber = True
      Me.txtPercepcionTotal.IsPK = False
      Me.txtPercepcionTotal.IsRequired = False
      Me.txtPercepcionTotal.Key = ""
      Me.txtPercepcionTotal.LabelAsoc = Me.lblPercepcionTotal
      Me.txtPercepcionTotal.Location = New System.Drawing.Point(74, 96)
      Me.txtPercepcionTotal.MaxLength = 30
      Me.txtPercepcionTotal.Name = "txtPercepcionTotal"
      Me.txtPercepcionTotal.ReadOnly = True
      Me.txtPercepcionTotal.Size = New System.Drawing.Size(78, 20)
      Me.txtPercepcionTotal.TabIndex = 4
      Me.txtPercepcionTotal.TabStop = False
      Me.txtPercepcionTotal.Text = "0.00"
      Me.txtPercepcionTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPercepcionVarias
      '
      Me.lblPercepcionVarias.AutoSize = True
      Me.lblPercepcionVarias.LabelAsoc = Nothing
      Me.lblPercepcionVarias.Location = New System.Drawing.Point(7, 82)
      Me.lblPercepcionVarias.Name = "lblPercepcionVarias"
      Me.lblPercepcionVarias.Size = New System.Drawing.Size(36, 13)
      Me.lblPercepcionVarias.TabIndex = 25
      Me.lblPercepcionVarias.Text = "Varias"
      '
      'txtPercepcionVarias
      '
      Me.txtPercepcionVarias.BindearPropiedadControl = Nothing
      Me.txtPercepcionVarias.BindearPropiedadEntidad = Nothing
      Me.txtPercepcionVarias.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPercepcionVarias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPercepcionVarias.Formato = "##0.00"
      Me.txtPercepcionVarias.IsDecimal = True
      Me.txtPercepcionVarias.IsNumber = True
      Me.txtPercepcionVarias.IsPK = False
      Me.txtPercepcionVarias.IsRequired = False
      Me.txtPercepcionVarias.Key = ""
      Me.txtPercepcionVarias.LabelAsoc = Me.lblPercepcionVarias
      Me.txtPercepcionVarias.Location = New System.Drawing.Point(74, 75)
      Me.txtPercepcionVarias.MaxLength = 30
      Me.txtPercepcionVarias.Name = "txtPercepcionVarias"
      Me.txtPercepcionVarias.ReadOnly = True
      Me.txtPercepcionVarias.Size = New System.Drawing.Size(78, 20)
      Me.txtPercepcionVarias.TabIndex = 3
      Me.txtPercepcionVarias.Text = "0.00"
      Me.txtPercepcionVarias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPercepcionGanancias
      '
      Me.lblPercepcionGanancias.AutoSize = True
      Me.lblPercepcionGanancias.LabelAsoc = Nothing
      Me.lblPercepcionGanancias.Location = New System.Drawing.Point(7, 61)
      Me.lblPercepcionGanancias.Name = "lblPercepcionGanancias"
      Me.lblPercepcionGanancias.Size = New System.Drawing.Size(58, 13)
      Me.lblPercepcionGanancias.TabIndex = 23
      Me.lblPercepcionGanancias.Text = "Ganancias"
      '
      'txtPercepcionGanancias
      '
      Me.txtPercepcionGanancias.BindearPropiedadControl = Nothing
      Me.txtPercepcionGanancias.BindearPropiedadEntidad = Nothing
      Me.txtPercepcionGanancias.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPercepcionGanancias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPercepcionGanancias.Formato = "##0.00"
      Me.txtPercepcionGanancias.IsDecimal = True
      Me.txtPercepcionGanancias.IsNumber = True
      Me.txtPercepcionGanancias.IsPK = False
      Me.txtPercepcionGanancias.IsRequired = False
      Me.txtPercepcionGanancias.Key = ""
      Me.txtPercepcionGanancias.LabelAsoc = Me.lblPercepcionGanancias
      Me.txtPercepcionGanancias.Location = New System.Drawing.Point(74, 54)
      Me.txtPercepcionGanancias.MaxLength = 30
      Me.txtPercepcionGanancias.Name = "txtPercepcionGanancias"
      Me.txtPercepcionGanancias.ReadOnly = True
      Me.txtPercepcionGanancias.Size = New System.Drawing.Size(78, 20)
      Me.txtPercepcionGanancias.TabIndex = 2
      Me.txtPercepcionGanancias.Text = "0.00"
      Me.txtPercepcionGanancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPercepcionIB
      '
      Me.lblPercepcionIB.AutoSize = True
      Me.lblPercepcionIB.LabelAsoc = Nothing
      Me.lblPercepcionIB.Location = New System.Drawing.Point(8, 40)
      Me.lblPercepcionIB.Name = "lblPercepcionIB"
      Me.lblPercepcionIB.Size = New System.Drawing.Size(23, 13)
      Me.lblPercepcionIB.TabIndex = 21
      Me.lblPercepcionIB.Text = "I.B."
      '
      'txtPercepcionIB
      '
      Me.txtPercepcionIB.BindearPropiedadControl = Nothing
      Me.txtPercepcionIB.BindearPropiedadEntidad = Nothing
      Me.txtPercepcionIB.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPercepcionIB.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPercepcionIB.Formato = "##0.00"
      Me.txtPercepcionIB.IsDecimal = True
      Me.txtPercepcionIB.IsNumber = True
      Me.txtPercepcionIB.IsPK = False
      Me.txtPercepcionIB.IsRequired = False
      Me.txtPercepcionIB.Key = ""
      Me.txtPercepcionIB.LabelAsoc = Me.lblPercepcionIB
      Me.txtPercepcionIB.Location = New System.Drawing.Point(74, 33)
      Me.txtPercepcionIB.MaxLength = 30
      Me.txtPercepcionIB.Name = "txtPercepcionIB"
      Me.txtPercepcionIB.ReadOnly = True
      Me.txtPercepcionIB.Size = New System.Drawing.Size(78, 20)
      Me.txtPercepcionIB.TabIndex = 1
      Me.txtPercepcionIB.Text = "0.00"
      Me.txtPercepcionIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPercepcionIVA
      '
      Me.lblPercepcionIVA.AutoSize = True
      Me.lblPercepcionIVA.LabelAsoc = Nothing
      Me.lblPercepcionIVA.Location = New System.Drawing.Point(8, 20)
      Me.lblPercepcionIVA.Name = "lblPercepcionIVA"
      Me.lblPercepcionIVA.Size = New System.Drawing.Size(33, 13)
      Me.lblPercepcionIVA.TabIndex = 19
      Me.lblPercepcionIVA.Text = "I.V.A."
      '
      'txtPercepcionIVA
      '
      Me.txtPercepcionIVA.BindearPropiedadControl = Nothing
      Me.txtPercepcionIVA.BindearPropiedadEntidad = Nothing
      Me.txtPercepcionIVA.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPercepcionIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPercepcionIVA.Formato = "##0.00"
      Me.txtPercepcionIVA.IsDecimal = True
      Me.txtPercepcionIVA.IsNumber = True
      Me.txtPercepcionIVA.IsPK = False
      Me.txtPercepcionIVA.IsRequired = False
      Me.txtPercepcionIVA.Key = ""
      Me.txtPercepcionIVA.LabelAsoc = Me.lblPercepcionIVA
      Me.txtPercepcionIVA.Location = New System.Drawing.Point(74, 12)
      Me.txtPercepcionIVA.MaxLength = 30
      Me.txtPercepcionIVA.Name = "txtPercepcionIVA"
      Me.txtPercepcionIVA.ReadOnly = True
      Me.txtPercepcionIVA.Size = New System.Drawing.Size(78, 20)
      Me.txtPercepcionIVA.TabIndex = 0
      Me.txtPercepcionIVA.Text = "0.00"
      Me.txtPercepcionIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'grbTotales
      '
      Me.grbTotales.Controls.Add(Me.txtTotalGeneral)
      Me.grbTotales.Controls.Add(Me.txtTotalPercepciones)
      Me.grbTotales.Controls.Add(Me.lblTotalPercepciones)
      Me.grbTotales.Controls.Add(Me.txtTotalIVA)
      Me.grbTotales.Controls.Add(Me.lblTotalIVA)
      Me.grbTotales.Controls.Add(Me.lblTotalNeto)
      Me.grbTotales.Controls.Add(Me.txtTotalNeto)
      Me.grbTotales.Controls.Add(Me.txtTotalBruto)
      Me.grbTotales.Controls.Add(Me.lblTotalBruto)
      Me.grbTotales.Controls.Add(Me.lblTotalGeneral)
      Me.grbTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbTotales.Location = New System.Drawing.Point(802, 224)
      Me.grbTotales.Name = "grbTotales"
      Me.grbTotales.Size = New System.Drawing.Size(155, 123)
      Me.grbTotales.TabIndex = 103
      Me.grbTotales.TabStop = False
      Me.grbTotales.Text = "Totales"
      '
      'txtTotalGeneral
      '
      Me.txtTotalGeneral.BindearPropiedadControl = Nothing
      Me.txtTotalGeneral.BindearPropiedadEntidad = Nothing
      Me.txtTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotalGeneral.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalGeneral.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalGeneral.Formato = "##,##0.00"
      Me.txtTotalGeneral.IsDecimal = True
      Me.txtTotalGeneral.IsNumber = True
      Me.txtTotalGeneral.IsPK = False
      Me.txtTotalGeneral.IsRequired = False
      Me.txtTotalGeneral.Key = ""
      Me.txtTotalGeneral.LabelAsoc = Nothing
      Me.txtTotalGeneral.Location = New System.Drawing.Point(50, 96)
      Me.txtTotalGeneral.Name = "txtTotalGeneral"
      Me.txtTotalGeneral.ReadOnly = True
      Me.txtTotalGeneral.Size = New System.Drawing.Size(99, 21)
      Me.txtTotalGeneral.TabIndex = 15
      Me.txtTotalGeneral.TabStop = False
      Me.txtTotalGeneral.Text = "0.00"
      Me.txtTotalGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalPercepciones
      '
      Me.txtTotalPercepciones.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotalPercepciones.BindearPropiedadControl = Nothing
      Me.txtTotalPercepciones.BindearPropiedadEntidad = Nothing
      Me.txtTotalPercepciones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalPercepciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalPercepciones.Formato = "##0.00"
      Me.txtTotalPercepciones.IsDecimal = True
      Me.txtTotalPercepciones.IsNumber = True
      Me.txtTotalPercepciones.IsPK = False
      Me.txtTotalPercepciones.IsRequired = False
      Me.txtTotalPercepciones.Key = ""
      Me.txtTotalPercepciones.LabelAsoc = Me.lblTotalPercepciones
      Me.txtTotalPercepciones.Location = New System.Drawing.Point(71, 75)
      Me.txtTotalPercepciones.Name = "txtTotalPercepciones"
      Me.txtTotalPercepciones.ReadOnly = True
      Me.txtTotalPercepciones.Size = New System.Drawing.Size(78, 20)
      Me.txtTotalPercepciones.TabIndex = 3
      Me.txtTotalPercepciones.TabStop = False
      Me.txtTotalPercepciones.Text = "0.00"
      Me.txtTotalPercepciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalPercepciones
      '
      Me.lblTotalPercepciones.AutoSize = True
      Me.lblTotalPercepciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotalPercepciones.LabelAsoc = Nothing
      Me.lblTotalPercepciones.Location = New System.Drawing.Point(8, 81)
      Me.lblTotalPercepciones.Name = "lblTotalPercepciones"
      Me.lblTotalPercepciones.Size = New System.Drawing.Size(51, 13)
      Me.lblTotalPercepciones.TabIndex = 14
      Me.lblTotalPercepciones.Text = "Percep."
      '
      'txtTotalIVA
      '
      Me.txtTotalIVA.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotalIVA.BindearPropiedadControl = Nothing
      Me.txtTotalIVA.BindearPropiedadEntidad = Nothing
      Me.txtTotalIVA.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalIVA.Formato = "##0.00"
      Me.txtTotalIVA.IsDecimal = True
      Me.txtTotalIVA.IsNumber = True
      Me.txtTotalIVA.IsPK = False
      Me.txtTotalIVA.IsRequired = False
      Me.txtTotalIVA.Key = ""
      Me.txtTotalIVA.LabelAsoc = Me.lblTotalIVA
      Me.txtTotalIVA.Location = New System.Drawing.Point(71, 54)
      Me.txtTotalIVA.Name = "txtTotalIVA"
      Me.txtTotalIVA.ReadOnly = True
      Me.txtTotalIVA.Size = New System.Drawing.Size(78, 20)
      Me.txtTotalIVA.TabIndex = 2
      Me.txtTotalIVA.TabStop = False
      Me.txtTotalIVA.Text = "0.00"
      Me.txtTotalIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalIVA
      '
      Me.lblTotalIVA.AutoSize = True
      Me.lblTotalIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotalIVA.LabelAsoc = Nothing
      Me.lblTotalIVA.Location = New System.Drawing.Point(9, 61)
      Me.lblTotalIVA.Name = "lblTotalIVA"
      Me.lblTotalIVA.Size = New System.Drawing.Size(27, 13)
      Me.lblTotalIVA.TabIndex = 11
      Me.lblTotalIVA.Text = "IVA"
      '
      'lblTotalNeto
      '
      Me.lblTotalNeto.AutoSize = True
      Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotalNeto.LabelAsoc = Nothing
      Me.lblTotalNeto.Location = New System.Drawing.Point(9, 40)
      Me.lblTotalNeto.Name = "lblTotalNeto"
      Me.lblTotalNeto.Size = New System.Drawing.Size(34, 13)
      Me.lblTotalNeto.TabIndex = 10
      Me.lblTotalNeto.Text = "Neto"
      '
      'txtTotalNeto
      '
      Me.txtTotalNeto.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotalNeto.BindearPropiedadControl = Nothing
      Me.txtTotalNeto.BindearPropiedadEntidad = Nothing
      Me.txtTotalNeto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalNeto.Formato = "##0.00"
      Me.txtTotalNeto.IsDecimal = True
      Me.txtTotalNeto.IsNumber = True
      Me.txtTotalNeto.IsPK = False
      Me.txtTotalNeto.IsRequired = False
      Me.txtTotalNeto.Key = ""
      Me.txtTotalNeto.LabelAsoc = Me.lblTotalNeto
      Me.txtTotalNeto.Location = New System.Drawing.Point(71, 33)
      Me.txtTotalNeto.Name = "txtTotalNeto"
      Me.txtTotalNeto.ReadOnly = True
      Me.txtTotalNeto.Size = New System.Drawing.Size(78, 20)
      Me.txtTotalNeto.TabIndex = 1
      Me.txtTotalNeto.TabStop = False
      Me.txtTotalNeto.Text = "0.00"
      Me.txtTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalBruto
      '
      Me.txtTotalBruto.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotalBruto.BindearPropiedadControl = Nothing
      Me.txtTotalBruto.BindearPropiedadEntidad = Nothing
      Me.txtTotalBruto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalBruto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalBruto.Formato = "##,##0.00"
      Me.txtTotalBruto.IsDecimal = True
      Me.txtTotalBruto.IsNumber = True
      Me.txtTotalBruto.IsPK = False
      Me.txtTotalBruto.IsRequired = False
      Me.txtTotalBruto.Key = ""
      Me.txtTotalBruto.LabelAsoc = Me.lblTotalBruto
      Me.txtTotalBruto.Location = New System.Drawing.Point(71, 12)
      Me.txtTotalBruto.Name = "txtTotalBruto"
      Me.txtTotalBruto.ReadOnly = True
      Me.txtTotalBruto.Size = New System.Drawing.Size(78, 20)
      Me.txtTotalBruto.TabIndex = 0
      Me.txtTotalBruto.TabStop = False
      Me.txtTotalBruto.Text = "0.00"
      Me.txtTotalBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalBruto
      '
      Me.lblTotalBruto.AutoSize = True
      Me.lblTotalBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotalBruto.LabelAsoc = Nothing
      Me.lblTotalBruto.Location = New System.Drawing.Point(7, 19)
      Me.lblTotalBruto.Name = "lblTotalBruto"
      Me.lblTotalBruto.Size = New System.Drawing.Size(37, 13)
      Me.lblTotalBruto.TabIndex = 7
      Me.lblTotalBruto.Text = "Bruto"
      '
      'lblTotalGeneral
      '
      Me.lblTotalGeneral.AutoSize = True
      Me.lblTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotalGeneral.LabelAsoc = Nothing
      Me.lblTotalGeneral.Location = New System.Drawing.Point(9, 103)
      Me.lblTotalGeneral.Name = "lblTotalGeneral"
      Me.lblTotalGeneral.Size = New System.Drawing.Size(36, 13)
      Me.lblTotalGeneral.TabIndex = 12
      Me.lblTotalGeneral.Text = "Total"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(85, 22)
      Me.tsbGrabar.Text = "&Grabar (F4)"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(73, 22)
      Me.tsbSalir.Text = "&Cancelar"
      '
      'tspFichas
      '
      Me.tspFichas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
      Me.tspFichas.Location = New System.Drawing.Point(0, 0)
      Me.tspFichas.Name = "tspFichas"
      Me.tspFichas.Size = New System.Drawing.Size(963, 25)
      Me.tspFichas.TabIndex = 3
      Me.tspFichas.Text = "ToolStrip1"
      '
      'ugIVAs
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugIVAs.DisplayLayout.Appearance = Appearance1
      UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn4.Header.VisiblePosition = 0
      UltraGridColumn4.Hidden = True
      UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn5.Header.VisiblePosition = 1
      UltraGridColumn5.Hidden = True
      UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn6.Header.VisiblePosition = 2
      UltraGridColumn6.Hidden = True
      UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn7.Header.VisiblePosition = 3
      UltraGridColumn7.Hidden = True
      UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn8.Header.VisiblePosition = 4
      UltraGridColumn8.Hidden = True
      UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn9.Header.Caption = "Tipo Imp."
      UltraGridColumn9.Header.VisiblePosition = 6
      UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn10.Header.VisiblePosition = 5
      UltraGridColumn10.Hidden = True
      UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn11.Header.VisiblePosition = 9
      UltraGridColumn11.Hidden = True
      UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn12.Header.VisiblePosition = 10
      UltraGridColumn12.Hidden = True
      UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn13.Header.VisiblePosition = 11
      UltraGridColumn13.Hidden = True
      UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn14.Header.VisiblePosition = 12
      UltraGridColumn14.Hidden = True
      UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn15.CellAppearance = Appearance2
      UltraGridColumn15.Format = "N2"
      UltraGridColumn15.Header.Caption = "Neto"
      UltraGridColumn15.Header.VisiblePosition = 14
      UltraGridColumn15.Width = 85
      UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn16.CellAppearance = Appearance3
      UltraGridColumn16.Format = "N2"
      UltraGridColumn16.Header.VisiblePosition = 8
      UltraGridColumn16.Width = 57
      UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn17.CellAppearance = Appearance4
      UltraGridColumn17.Format = "N2"
      UltraGridColumn17.Header.Caption = "Impuesto"
      UltraGridColumn17.Header.VisiblePosition = 15
      UltraGridColumn17.Width = 85
      UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn22.CellAppearance = Appearance5
      UltraGridColumn22.Format = "N2"
      UltraGridColumn22.Header.Caption = "Total"
      UltraGridColumn22.Header.VisiblePosition = 16
      UltraGridColumn22.Width = 85
      UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn18.Header.VisiblePosition = 17
      UltraGridColumn18.Hidden = True
      UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn19.Header.Caption = "Tipo Imp."
      UltraGridColumn19.Header.VisiblePosition = 7
      UltraGridColumn19.Hidden = True
      UltraGridColumn19.Width = 167
      UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn20.Header.VisiblePosition = 18
      UltraGridColumn20.Hidden = True
      UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn21.Header.VisiblePosition = 19
      UltraGridColumn21.Hidden = True
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance6
      UltraGridColumn1.Format = "N2"
      UltraGridColumn1.Header.VisiblePosition = 13
      UltraGridColumn1.Width = 85
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn22, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn1})
      Me.ugIVAs.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugIVAs.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugIVAs.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance7.BorderColor = System.Drawing.SystemColors.Window
      Me.ugIVAs.DisplayLayout.GroupByBox.Appearance = Appearance7
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugIVAs.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
      Me.ugIVAs.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugIVAs.DisplayLayout.GroupByBox.Hidden = True
      Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance9.BackColor2 = System.Drawing.SystemColors.Control
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugIVAs.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
      Me.ugIVAs.DisplayLayout.MaxColScrollRegions = 1
      Me.ugIVAs.DisplayLayout.MaxRowScrollRegions = 1
      Appearance10.BackColor = System.Drawing.SystemColors.Window
      Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugIVAs.DisplayLayout.Override.ActiveCellAppearance = Appearance10
      Appearance11.BackColor = System.Drawing.SystemColors.Highlight
      Appearance11.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugIVAs.DisplayLayout.Override.ActiveRowAppearance = Appearance11
      Me.ugIVAs.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugIVAs.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Me.ugIVAs.DisplayLayout.Override.CardAreaAppearance = Appearance12
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugIVAs.DisplayLayout.Override.CellAppearance = Appearance13
      Me.ugIVAs.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugIVAs.DisplayLayout.Override.CellPadding = 0
      Appearance14.BackColor = System.Drawing.SystemColors.Control
      Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance14.BorderColor = System.Drawing.SystemColors.Window
      Me.ugIVAs.DisplayLayout.Override.GroupByRowAppearance = Appearance14
      Appearance15.TextHAlignAsString = "Left"
      Me.ugIVAs.DisplayLayout.Override.HeaderAppearance = Appearance15
      Me.ugIVAs.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugIVAs.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance16.BackColor = System.Drawing.SystemColors.Window
      Appearance16.BorderColor = System.Drawing.Color.Silver
      Me.ugIVAs.DisplayLayout.Override.RowAppearance = Appearance16
      Me.ugIVAs.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugIVAs.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
      Me.ugIVAs.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugIVAs.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugIVAs.EnterMueveACeldaDeAbajo = True
      Me.ugIVAs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugIVAs.Location = New System.Drawing.Point(6, 224)
      Me.ugIVAs.Name = "ugIVAs"
      Me.ugIVAs.Size = New System.Drawing.Size(519, 123)
      Me.ugIVAs.TabIndex = 104
      Me.ugIVAs.Text = "UltraGrid1"
      '
      'chbMercaderiaEnviada
      '
      Me.chbMercaderiaEnviada.AutoSize = True
      Me.chbMercaderiaEnviada.BindearPropiedadControl = ""
      Me.chbMercaderiaEnviada.BindearPropiedadEntidad = ""
      Me.chbMercaderiaEnviada.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMercaderiaEnviada.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMercaderiaEnviada.IsPK = False
      Me.chbMercaderiaEnviada.IsRequired = False
      Me.chbMercaderiaEnviada.Key = Nothing
      Me.chbMercaderiaEnviada.LabelAsoc = Nothing
      Me.chbMercaderiaEnviada.Location = New System.Drawing.Point(514, 61)
      Me.chbMercaderiaEnviada.Name = "chbMercaderiaEnviada"
      Me.chbMercaderiaEnviada.Size = New System.Drawing.Size(123, 17)
      Me.chbMercaderiaEnviada.TabIndex = 38
      Me.chbMercaderiaEnviada.Text = "Mercadería Enviada"
      Me.chbMercaderiaEnviada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbMercaderiaEnviada.UseVisualStyleBackColor = True
      '
      'ModificarComprasDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(963, 357)
      Me.Controls.Add(Me.ugIVAs)
      Me.Controls.Add(Me.grbDescRecargo)
      Me.Controls.Add(Me.grbPercepciones)
      Me.Controls.Add(Me.grbTotales)
      Me.Controls.Add(Me.tspFichas)
      Me.Controls.Add(Me.grpProveedor)
      Me.Controls.Add(Me.grpComprobante)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ModificarComprasDetalle"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Detalle de Compra"
      Me.grpComprobante.ResumeLayout(False)
      Me.grpComprobante.PerformLayout()
      Me.grpProveedor.ResumeLayout(False)
      Me.grpProveedor.PerformLayout()
      Me.grbDescRecargo.ResumeLayout(False)
      Me.grbDescRecargo.PerformLayout()
      Me.grbPercepciones.ResumeLayout(False)
      Me.grbPercepciones.PerformLayout()
      Me.grbTotales.ResumeLayout(False)
      Me.grbTotales.PerformLayout()
      Me.tspFichas.ResumeLayout(False)
      Me.tspFichas.PerformLayout()
      CType(Me.ugIVAs, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents lblComprador As Eniac.Controles.Label
   Friend WithEvents cmbComprador As Eniac.Controles.ComboBox
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents cboRubro As Eniac.Controles.ComboBox
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents lblProveedor As Eniac.Controles.Label
   Friend WithEvents grpComprobante As System.Windows.Forms.GroupBox
   Friend WithEvents grpProveedor As System.Windows.Forms.GroupBox
   Friend WithEvents grbDescRecargo As System.Windows.Forms.GroupBox
   Friend WithEvents lblTotalDescRec As Eniac.Controles.Label
   Friend WithEvents txtPorcDescRecargoGral As Eniac.Controles.TextBox
   Friend WithEvents grbPercepciones As System.Windows.Forms.GroupBox
   Friend WithEvents lblPercepcionTotal As Eniac.Controles.Label
   Friend WithEvents txtPercepcionTotal As Eniac.Controles.TextBox
   Friend WithEvents lblPercepcionVarias As Eniac.Controles.Label
   Friend WithEvents txtPercepcionVarias As Eniac.Controles.TextBox
   Friend WithEvents lblPercepcionGanancias As Eniac.Controles.Label
   Friend WithEvents txtPercepcionGanancias As Eniac.Controles.TextBox
   Friend WithEvents lblPercepcionIB As Eniac.Controles.Label
   Friend WithEvents txtPercepcionIB As Eniac.Controles.TextBox
   Friend WithEvents lblPercepcionIVA As Eniac.Controles.Label
   Friend WithEvents txtPercepcionIVA As Eniac.Controles.TextBox
   Friend WithEvents grbTotales As System.Windows.Forms.GroupBox
   Friend WithEvents txtTotalGeneral As Eniac.Controles.TextBox
   Friend WithEvents txtTotalPercepciones As Eniac.Controles.TextBox
   Friend WithEvents lblTotalPercepciones As Eniac.Controles.Label
   Friend WithEvents txtTotalIVA As Eniac.Controles.TextBox
   Friend WithEvents lblTotalIVA As Eniac.Controles.Label
   Friend WithEvents lblTotalNeto As Eniac.Controles.Label
   Friend WithEvents txtTotalNeto As Eniac.Controles.TextBox
   Friend WithEvents txtTotalBruto As Eniac.Controles.TextBox
   Friend WithEvents lblTotalBruto As Eniac.Controles.Label
   Friend WithEvents lblTotalGeneral As Eniac.Controles.Label
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tspFichas As System.Windows.Forms.ToolStrip
   Friend WithEvents cboFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents txtCategoriaFiscal As Eniac.Controles.TextBox
   Friend WithEvents lblCategoriaFiscal As System.Windows.Forms.Label
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents cboPeriodoFiscal As Eniac.Controles.ComboBox
   Friend WithEvents lblComprobante As Eniac.Controles.Label
   Friend WithEvents txtNumeroFactura As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroFactura As Eniac.Controles.Label
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents txtEmisorFactura As Eniac.Controles.TextBox
   Friend WithEvents lblEmisorFactura As Eniac.Controles.Label
   Friend WithEvents cboTipoComprobante As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoFactura As Eniac.Controles.Label
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents btnPercIIBB As System.Windows.Forms.Button
   Friend WithEvents ugIVAs As Eniac.Win.UltraGridEditable
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbMercaderiaEnviada As Controles.CheckBox
End Class
