<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacturablesPendientesAyuda
   Inherits BaseForm

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
   '<System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Check")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoComprobanteDescripcion")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraComprobante")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CotizacionDolar")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbPendientes = New System.Windows.Forms.GroupBox()
        Me.chbProvincia = New Eniac.Controles.CheckBox()
        Me.cmbProvincia = New Eniac.Controles.ComboBox()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador2()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador2()
        Me.cmbInvocados = New Eniac.Controles.ComboBox()
        Me.lblInvocados = New Eniac.Controles.Label()
        Me.txtNroComprobante = New Eniac.Controles.TextBox()
        Me.chbNroComprobante = New Eniac.Controles.CheckBox()
        Me.clbTiposComprobantes = New Eniac.Controles.CheckedListBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.Label2 = New Eniac.Controles.Label()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbSoloCopiar = New System.Windows.Forms.CheckBox()
        Me.btnCancelar = New Eniac.Controles.Button()
        Me.btnAceptar = New Eniac.Controles.Button()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.lblTotal = New Eniac.Controles.Label()
        Me.txtTextError = New Eniac.Controles.TextBox()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblSeleccionado = New Eniac.Controles.Label()
        Me.txtSeleccionado = New Eniac.Controles.TextBox()
        Me.chbSoloCabecera = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.grbPendientes.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbPendientes
        '
        Me.grbPendientes.Controls.Add(Me.chbProvincia)
        Me.grbPendientes.Controls.Add(Me.cmbProvincia)
        Me.grbPendientes.Controls.Add(Me.chbLocalidad)
        Me.grbPendientes.Controls.Add(Me.bscCodigoLocalidad)
        Me.grbPendientes.Controls.Add(Me.bscNombreLocalidad)
        Me.grbPendientes.Controls.Add(Me.cmbInvocados)
        Me.grbPendientes.Controls.Add(Me.lblInvocados)
        Me.grbPendientes.Controls.Add(Me.txtNroComprobante)
        Me.grbPendientes.Controls.Add(Me.chbNroComprobante)
        Me.grbPendientes.Controls.Add(Me.clbTiposComprobantes)
        Me.grbPendientes.Controls.Add(Me.bscCodigoCliente)
        Me.grbPendientes.Controls.Add(Me.bscCliente)
        Me.grbPendientes.Controls.Add(Me.chbCliente)
        Me.grbPendientes.Controls.Add(Me.chkMesCompleto)
        Me.grbPendientes.Controls.Add(Me.btnBuscar)
        Me.grbPendientes.Controls.Add(Me.Label2)
        Me.grbPendientes.Controls.Add(Me.dtpHasta)
        Me.grbPendientes.Controls.Add(Me.dtpDesde)
        Me.grbPendientes.Controls.Add(Me.lblHasta)
        Me.grbPendientes.Controls.Add(Me.lblDesde)
        Me.grbPendientes.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbPendientes.Location = New System.Drawing.Point(0, 0)
        Me.grbPendientes.Name = "grbPendientes"
        Me.grbPendientes.Size = New System.Drawing.Size(980, 140)
        Me.grbPendientes.TabIndex = 0
        Me.grbPendientes.TabStop = False
        '
        'chbProvincia
        '
        Me.chbProvincia.AutoSize = True
        Me.chbProvincia.BindearPropiedadControl = Nothing
        Me.chbProvincia.BindearPropiedadEntidad = Nothing
        Me.chbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProvincia.IsPK = False
        Me.chbProvincia.IsRequired = False
        Me.chbProvincia.Key = Nothing
        Me.chbProvincia.LabelAsoc = Nothing
        Me.chbProvincia.Location = New System.Drawing.Point(321, 110)
        Me.chbProvincia.Name = "chbProvincia"
        Me.chbProvincia.Size = New System.Drawing.Size(70, 17)
        Me.chbProvincia.TabIndex = 16
        Me.chbProvincia.Text = "Provincia"
        Me.chbProvincia.UseVisualStyleBackColor = True
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
        Me.cmbProvincia.BindearPropiedadEntidad = "IdProvincia"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Enabled = False
        Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.IsPK = False
        Me.cmbProvincia.IsRequired = True
        Me.cmbProvincia.Key = Nothing
        Me.cmbProvincia.LabelAsoc = Me.chbProvincia
        Me.cmbProvincia.Location = New System.Drawing.Point(396, 108)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(119, 21)
        Me.cmbProvincia.TabIndex = 17
        '
        'chbLocalidad
        '
        Me.chbLocalidad.AutoSize = True
        Me.chbLocalidad.BindearPropiedadControl = Nothing
        Me.chbLocalidad.BindearPropiedadEntidad = Nothing
        Me.chbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLocalidad.IsPK = False
        Me.chbLocalidad.IsRequired = False
        Me.chbLocalidad.Key = Nothing
        Me.chbLocalidad.LabelAsoc = Nothing
        Me.chbLocalidad.Location = New System.Drawing.Point(10, 110)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 13
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
        '
        'bscCodigoLocalidad
        '
        Me.bscCodigoLocalidad.ActivarFiltroEnGrilla = True
        Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
        Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidad"
        Me.bscCodigoLocalidad.ConfigBuscador = Nothing
        Me.bscCodigoLocalidad.Datos = Nothing
        Me.bscCodigoLocalidad.FilaDevuelta = Nothing
        Me.bscCodigoLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoLocalidad.IsDecimal = False
        Me.bscCodigoLocalidad.IsNumber = False
        Me.bscCodigoLocalidad.IsPK = False
        Me.bscCodigoLocalidad.IsRequired = False
        Me.bscCodigoLocalidad.Key = ""
        Me.bscCodigoLocalidad.LabelAsoc = Me.chbLocalidad
        Me.bscCodigoLocalidad.Location = New System.Drawing.Point(84, 108)
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = False
        Me.bscCodigoLocalidad.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoLocalidad.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoLocalidad.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoLocalidad.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Size = New System.Drawing.Size(85, 20)
        Me.bscCodigoLocalidad.TabIndex = 14
        '
        'bscNombreLocalidad
        '
        Me.bscNombreLocalidad.ActivarFiltroEnGrilla = True
        Me.bscNombreLocalidad.BindearPropiedadControl = Nothing
        Me.bscNombreLocalidad.BindearPropiedadEntidad = Nothing
        Me.bscNombreLocalidad.ConfigBuscador = Nothing
        Me.bscNombreLocalidad.Datos = Nothing
        Me.bscNombreLocalidad.FilaDevuelta = Nothing
        Me.bscNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreLocalidad.IsDecimal = False
        Me.bscNombreLocalidad.IsNumber = False
        Me.bscNombreLocalidad.IsPK = False
        Me.bscNombreLocalidad.IsRequired = False
        Me.bscNombreLocalidad.Key = ""
        Me.bscNombreLocalidad.LabelAsoc = Me.chbLocalidad
        Me.bscNombreLocalidad.Location = New System.Drawing.Point(171, 108)
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = False
        Me.bscNombreLocalidad.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreLocalidad.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreLocalidad.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreLocalidad.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Size = New System.Drawing.Size(142, 20)
        Me.bscNombreLocalidad.TabIndex = 15
        '
        'cmbInvocados
        '
        Me.cmbInvocados.BindearPropiedadControl = "SelectedValue"
        Me.cmbInvocados.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
        Me.cmbInvocados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInvocados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbInvocados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbInvocados.FormattingEnabled = True
        Me.cmbInvocados.IsPK = False
        Me.cmbInvocados.IsRequired = False
        Me.cmbInvocados.Key = Nothing
        Me.cmbInvocados.LabelAsoc = Nothing
        Me.cmbInvocados.Location = New System.Drawing.Point(249, 83)
        Me.cmbInvocados.Name = "cmbInvocados"
        Me.cmbInvocados.Size = New System.Drawing.Size(77, 21)
        Me.cmbInvocados.TabIndex = 12
        '
        'lblInvocados
        '
        Me.lblInvocados.AutoSize = True
        Me.lblInvocados.LabelAsoc = Nothing
        Me.lblInvocados.Location = New System.Drawing.Point(178, 86)
        Me.lblInvocados.Name = "lblInvocados"
        Me.lblInvocados.Size = New System.Drawing.Size(57, 13)
        Me.lblInvocados.TabIndex = 11
        Me.lblInvocados.Text = "Invocados"
        '
        'txtNroComprobante
        '
        Me.txtNroComprobante.BindearPropiedadControl = Nothing
        Me.txtNroComprobante.BindearPropiedadEntidad = Nothing
        Me.txtNroComprobante.Enabled = False
        Me.txtNroComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroComprobante.Formato = "##0"
        Me.txtNroComprobante.IsDecimal = False
        Me.txtNroComprobante.IsNumber = True
        Me.txtNroComprobante.IsPK = False
        Me.txtNroComprobante.IsRequired = False
        Me.txtNroComprobante.Key = ""
        Me.txtNroComprobante.LabelAsoc = Me.chbNroComprobante
        Me.txtNroComprobante.Location = New System.Drawing.Point(84, 83)
        Me.txtNroComprobante.MaxLength = 8
        Me.txtNroComprobante.Name = "txtNroComprobante"
        Me.txtNroComprobante.Size = New System.Drawing.Size(65, 20)
        Me.txtNroComprobante.TabIndex = 10
        Me.txtNroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNroComprobante
        '
        Me.chbNroComprobante.AutoSize = True
        Me.chbNroComprobante.BindearPropiedadControl = Nothing
        Me.chbNroComprobante.BindearPropiedadEntidad = Nothing
        Me.chbNroComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNroComprobante.IsPK = False
        Me.chbNroComprobante.IsRequired = False
        Me.chbNroComprobante.Key = Nothing
        Me.chbNroComprobante.LabelAsoc = Nothing
        Me.chbNroComprobante.Location = New System.Drawing.Point(10, 85)
        Me.chbNroComprobante.Name = "chbNroComprobante"
        Me.chbNroComprobante.Size = New System.Drawing.Size(63, 17)
        Me.chbNroComprobante.TabIndex = 9
        Me.chbNroComprobante.Text = "Numero"
        Me.chbNroComprobante.UseVisualStyleBackColor = True
        '
        'clbTiposComprobantes
        '
        Me.clbTiposComprobantes.CheckOnClick = True
        Me.clbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.clbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.clbTiposComprobantes.FormattingEnabled = True
        Me.clbTiposComprobantes.IsPK = False
        Me.clbTiposComprobantes.IsRequired = False
        Me.clbTiposComprobantes.Key = Nothing
        Me.clbTiposComprobantes.LabelAsoc = Nothing
        Me.clbTiposComprobantes.Location = New System.Drawing.Point(523, 12)
        Me.clbTiposComprobantes.MultiColumn = True
        Me.clbTiposComprobantes.Name = "clbTiposComprobantes"
        Me.clbTiposComprobantes.Size = New System.Drawing.Size(362, 124)
        Me.clbTiposComprobantes.TabIndex = 18
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(84, 54)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 7
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Nothing
        Me.bscCliente.Location = New System.Drawing.Point(181, 54)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = False
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(280, 23)
        Me.bscCliente.TabIndex = 8
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
        Me.chbCliente.Location = New System.Drawing.Point(10, 54)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 6
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(10, 29)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(892, 91)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(82, 43)
        Me.btnBuscar.TabIndex = 19
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(150, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha de Emisión"
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(326, 27)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(288, 31)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 4
        Me.lblHasta.Text = "Hasta"
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
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(153, 27)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 3
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(112, 31)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'chbSoloCopiar
        '
        Me.chbSoloCopiar.AutoSize = True
        Me.chbSoloCopiar.Location = New System.Drawing.Point(626, 6)
        Me.chbSoloCopiar.Name = "chbSoloCopiar"
        Me.chbSoloCopiar.Size = New System.Drawing.Size(80, 17)
        Me.chbSoloCopiar.TabIndex = 6
        Me.chbSoloCopiar.Text = "Solo Copiar"
        Me.chbSoloCopiar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(892, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(801, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(85, 30)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 535)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(980, 22)
        Me.stsStado.TabIndex = 6
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(901, 17)
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
        'txtTotal
        '
        Me.txtTotal.BindearPropiedadControl = Nothing
        Me.txtTotal.BindearPropiedadEntidad = Nothing
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotal.Formato = ""
        Me.txtTotal.IsDecimal = False
        Me.txtTotal.IsNumber = False
        Me.txtTotal.IsPK = False
        Me.txtTotal.IsRequired = False
        Me.txtTotal.Key = ""
        Me.txtTotal.LabelAsoc = Nothing
        Me.txtTotal.Location = New System.Drawing.Point(425, 24)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(90, 20)
        Me.txtTotal.TabIndex = 3
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.LabelAsoc = Nothing
        Me.lblTotal.Location = New System.Drawing.Point(422, 6)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(36, 13)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.Text = "Total"
        '
        'txtTextError
        '
        Me.txtTextError.BackColor = System.Drawing.SystemColors.Window
        Me.txtTextError.BindearPropiedadControl = Nothing
        Me.txtTextError.BindearPropiedadEntidad = Nothing
        Me.txtTextError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTextError.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTextError.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTextError.Formato = "##0"
        Me.txtTextError.IsDecimal = False
        Me.txtTextError.IsNumber = False
        Me.txtTextError.IsPK = False
        Me.txtTextError.IsRequired = False
        Me.txtTextError.Key = ""
        Me.txtTextError.LabelAsoc = Me.chbNroComprobante
        Me.txtTextError.Location = New System.Drawing.Point(0, 466)
        Me.txtTextError.MaxLength = 8
        Me.txtTextError.Name = "txtTextError"
        Me.txtTextError.ReadOnly = True
        Me.txtTextError.Size = New System.Drawing.Size(980, 20)
        Me.txtTextError.TabIndex = 5
        '
        'ugDetalle
        '
        Me.ugDetalle.DataMember = Nothing
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 35
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn4.Header.Caption = "Tipo Comprobante"
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 135
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn5.CellAppearance = Appearance3
        UltraGridColumn5.Header.Caption = "Letra"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 50
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance4
        UltraGridColumn6.Format = "0000"
        UltraGridColumn6.Header.Caption = "Emisor"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Width = 50
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance5
        UltraGridColumn7.Format = "00000000"
        UltraGridColumn7.Header.Caption = "Número"
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 80
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn8.CellAppearance = Appearance6
        UltraGridColumn8.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn8.Header.Caption = "Emisión"
        UltraGridColumn8.Header.VisiblePosition = 1
        UltraGridColumn8.Width = 100
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance7
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 80
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance8
        UltraGridColumn10.Format = "N2"
        UltraGridColumn10.Header.Caption = "Total"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 80
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn11.Header.Caption = "Observación"
        UltraGridColumn11.Header.VisiblePosition = 13
        UltraGridColumn11.Width = 248
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance9
        UltraGridColumn12.Header.Caption = "C.P."
        UltraGridColumn12.Header.VisiblePosition = 10
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 50
        UltraGridColumn14.Header.Caption = "Localidad"
        UltraGridColumn14.Header.VisiblePosition = 11
        UltraGridColumn14.Width = 120
        UltraGridColumn13.Header.Caption = "Provincia"
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Width = 120
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance10
        UltraGridColumn15.Format = "N2"
        UltraGridColumn15.Header.Caption = "Cotización Dólar"
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Width = 95
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn14, UltraGridColumn13, UltraGridColumn15})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance11.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance11
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance13.BackColor2 = System.Drawing.SystemColors.Control
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.SystemColors.Highlight
        Appearance15.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance16
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Appearance17.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance18.BackColor = System.Drawing.SystemColors.Control
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance18
        Appearance19.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance21.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 140)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(980, 326)
        Me.ugDetalle.TabIndex = 4
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'lblSeleccionado
        '
        Me.lblSeleccionado.AutoSize = True
        Me.lblSeleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionado.LabelAsoc = Nothing
        Me.lblSeleccionado.Location = New System.Drawing.Point(518, 6)
        Me.lblSeleccionado.Name = "lblSeleccionado"
        Me.lblSeleccionado.Size = New System.Drawing.Size(84, 13)
        Me.lblSeleccionado.TabIndex = 4
        Me.lblSeleccionado.Text = "Seleccionado"
        '
        'txtSeleccionado
        '
        Me.txtSeleccionado.BindearPropiedadControl = Nothing
        Me.txtSeleccionado.BindearPropiedadEntidad = Nothing
        Me.txtSeleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeleccionado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSeleccionado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSeleccionado.Formato = ""
        Me.txtSeleccionado.IsDecimal = False
        Me.txtSeleccionado.IsNumber = False
        Me.txtSeleccionado.IsPK = False
        Me.txtSeleccionado.IsRequired = False
        Me.txtSeleccionado.Key = ""
        Me.txtSeleccionado.LabelAsoc = Nothing
        Me.txtSeleccionado.Location = New System.Drawing.Point(521, 24)
        Me.txtSeleccionado.Name = "txtSeleccionado"
        Me.txtSeleccionado.ReadOnly = True
        Me.txtSeleccionado.Size = New System.Drawing.Size(90, 20)
        Me.txtSeleccionado.TabIndex = 5
        Me.txtSeleccionado.Text = "0.00"
        Me.txtSeleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbSoloCabecera
        '
        Me.chbSoloCabecera.AutoSize = True
        Me.chbSoloCabecera.Location = New System.Drawing.Point(626, 29)
        Me.chbSoloCabecera.Name = "chbSoloCabecera"
        Me.chbSoloCabecera.Size = New System.Drawing.Size(96, 17)
        Me.chbSoloCabecera.TabIndex = 7
        Me.chbSoloCabecera.Text = "Solo Cabecera"
        Me.chbSoloCabecera.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.chbSoloCabecera)
        Me.Panel1.Controls.Add(Me.chbSoloCopiar)
        Me.Panel1.Controls.Add(Me.txtSeleccionado)
        Me.Panel1.Controls.Add(Me.lblSeleccionado)
        Me.Panel1.Controls.Add(Me.txtTotal)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 486)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(980, 49)
        Me.Panel1.TabIndex = 3
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(899, 146)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 2
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'cmbTodos
        '
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(773, 147)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 1
        '
        'FacturablesPendientesAyuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 557)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.txtTextError)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.grbPendientes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FacturablesPendientesAyuda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ayuda de Comprobantes a Invocar"
        Me.grbPendientes.ResumeLayout(False)
        Me.grbPendientes.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
    Friend WithEvents Label2 As Eniac.Controles.Label
    Friend WithEvents btnCancelar As Eniac.Controles.Button
    Friend WithEvents btnAceptar As Eniac.Controles.Button
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtTotal As Eniac.Controles.TextBox
    Friend WithEvents lblTotal As Eniac.Controles.Label
    Friend WithEvents btnBuscar As Eniac.Controles.Button
    Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
    Friend WithEvents clbTiposComprobantes As Eniac.Controles.CheckedListBox
    Friend WithEvents chbSoloCopiar As System.Windows.Forms.CheckBox
    Friend WithEvents txtNroComprobante As Eniac.Controles.TextBox
   Friend WithEvents chbNroComprobante As Eniac.Controles.CheckBox
   Friend WithEvents txtTextError As Eniac.Controles.TextBox
    Friend WithEvents cmbInvocados As Controles.ComboBox
    Friend WithEvents lblInvocados As Controles.Label
   Friend WithEvents ugDetalle As UltraGrid
    Friend WithEvents lblSeleccionado As Controles.Label
    Friend WithEvents txtSeleccionado As Controles.TextBox
    Friend WithEvents chbSoloCabecera As CheckBox
    Friend WithEvents chbProvincia As Controles.CheckBox
    Public WithEvents cmbProvincia As Controles.ComboBox
    Friend WithEvents chbLocalidad As Controles.CheckBox
   Friend WithEvents bscCodigoLocalidad As Controles.Buscador2
   Friend WithEvents bscNombreLocalidad As Controles.Buscador2
   Friend WithEvents Panel1 As Panel
   Friend WithEvents btnTodos As Button
   Friend WithEvents cmbTodos As Controles.ComboBox
End Class
