<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPPlanificacionNecesidadesProduccion
   Inherits Eniac.Win.BaseForm

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
      Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Masivo")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstado")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantEstado")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idEstado")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubRubro")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProcesoProductivo")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProcesoProductivo")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionProceso")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstado_Fecha")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstado_Hora")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido", 0)
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenPedido", 1)
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCalcularNecesidades = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbFechaEntrega = New Eniac.Controles.CheckBox()
      Me.chkMesCompletoEntrega = New Eniac.Controles.CheckBox()
      Me.dtpHastaEntrega = New Eniac.Controles.DateTimePicker()
      Me.lblHastaEntrega = New Eniac.Controles.Label()
      Me.dtpDesdeEntrega = New Eniac.Controles.DateTimePicker()
      Me.lblDesdeEntrega = New Eniac.Controles.Label()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbEstados = New Eniac.Controles.ComboBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.bscNombreCliente = New Eniac.Controles.Buscador2()
      Me.ugDetalle = New Eniac.Win.UltraGridSiga()
      Me.btnTodos = New System.Windows.Forms.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbCalcularNecesidades, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(987, 29)
      Me.tstBarra.TabIndex = 1
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCalcularNecesidades
      '
      Me.tsbCalcularNecesidades.Image = Global.Eniac.Win.My.Resources.Resources.factory
      Me.tsbCalcularNecesidades.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCalcularNecesidades.Name = "tsbCalcularNecesidades"
      Me.tsbCalcularNecesidades.Size = New System.Drawing.Size(99, 26)
      Me.tsbCalcularNecesidades.Text = "Calcular (F4)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.btnConsultar)
      Me.GroupBox1.Controls.Add(Me.chbFechaEntrega)
      Me.GroupBox1.Controls.Add(Me.chkMesCompletoEntrega)
      Me.GroupBox1.Controls.Add(Me.dtpHastaEntrega)
      Me.GroupBox1.Controls.Add(Me.dtpDesdeEntrega)
      Me.GroupBox1.Controls.Add(Me.lblHastaEntrega)
      Me.GroupBox1.Controls.Add(Me.lblDesdeEntrega)
      Me.GroupBox1.Controls.Add(Me.chbFecha)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.cmbEstados)
      Me.GroupBox1.Controls.Add(Me.chkMesCompleto)
      Me.GroupBox1.Controls.Add(Me.dtpHasta)
      Me.GroupBox1.Controls.Add(Me.dtpDesde)
      Me.GroupBox1.Controls.Add(Me.lblHasta)
      Me.GroupBox1.Controls.Add(Me.lblDesde)
      Me.GroupBox1.Controls.Add(Me.chbCliente)
      Me.GroupBox1.Controls.Add(Me.bscCodigoCliente)
      Me.GroupBox1.Controls.Add(Me.bscNombreCliente)
      Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
      Me.GroupBox1.Location = New System.Drawing.Point(0, 29)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(987, 109)
      Me.GroupBox1.TabIndex = 2
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Filtros"
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
      Me.btnConsultar.Location = New System.Drawing.Point(871, 71)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(110, 32)
      Me.btnConsultar.TabIndex = 41
      Me.btnConsultar.Text = "&Consultar (F3)"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chbFechaEntrega
      '
      Me.chbFechaEntrega.AutoSize = True
      Me.chbFechaEntrega.BindearPropiedadControl = Nothing
      Me.chbFechaEntrega.BindearPropiedadEntidad = Nothing
      Me.chbFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaEntrega.IsPK = False
      Me.chbFechaEntrega.IsRequired = False
      Me.chbFechaEntrega.Key = Nothing
      Me.chbFechaEntrega.LabelAsoc = Nothing
      Me.chbFechaEntrega.Location = New System.Drawing.Point(228, 49)
      Me.chbFechaEntrega.Name = "chbFechaEntrega"
      Me.chbFechaEntrega.Size = New System.Drawing.Size(111, 17)
      Me.chbFechaEntrega.TabIndex = 35
      Me.chbFechaEntrega.Text = "Fecha de Entrega"
      Me.chbFechaEntrega.UseVisualStyleBackColor = True
      '
      'chkMesCompletoEntrega
      '
      Me.chkMesCompletoEntrega.AutoSize = True
      Me.chkMesCompletoEntrega.BindearPropiedadControl = Nothing
      Me.chkMesCompletoEntrega.BindearPropiedadEntidad = Nothing
      Me.chkMesCompletoEntrega.Enabled = False
      Me.chkMesCompletoEntrega.ForeColorFocus = System.Drawing.Color.Red
      Me.chkMesCompletoEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkMesCompletoEntrega.IsPK = False
      Me.chkMesCompletoEntrega.IsRequired = False
      Me.chkMesCompletoEntrega.Key = Nothing
      Me.chkMesCompletoEntrega.LabelAsoc = Nothing
      Me.chkMesCompletoEntrega.Location = New System.Drawing.Point(342, 49)
      Me.chkMesCompletoEntrega.Name = "chkMesCompletoEntrega"
      Me.chkMesCompletoEntrega.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompletoEntrega.TabIndex = 36
      Me.chkMesCompletoEntrega.Text = "Mes Completo"
      Me.chkMesCompletoEntrega.UseVisualStyleBackColor = True
      '
      'dtpHastaEntrega
      '
      Me.dtpHastaEntrega.BindearPropiedadControl = Nothing
      Me.dtpHastaEntrega.BindearPropiedadEntidad = Nothing
      Me.dtpHastaEntrega.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHastaEntrega.Enabled = False
      Me.dtpHastaEntrega.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHastaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHastaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHastaEntrega.IsPK = False
      Me.dtpHastaEntrega.IsRequired = False
      Me.dtpHastaEntrega.Key = ""
      Me.dtpHastaEntrega.LabelAsoc = Me.lblHastaEntrega
      Me.dtpHastaEntrega.Location = New System.Drawing.Point(663, 47)
      Me.dtpHastaEntrega.Name = "dtpHastaEntrega"
      Me.dtpHastaEntrega.Size = New System.Drawing.Size(128, 20)
      Me.dtpHastaEntrega.TabIndex = 40
      '
      'lblHastaEntrega
      '
      Me.lblHastaEntrega.AutoSize = True
      Me.lblHastaEntrega.LabelAsoc = Nothing
      Me.lblHastaEntrega.Location = New System.Drawing.Point(622, 51)
      Me.lblHastaEntrega.Name = "lblHastaEntrega"
      Me.lblHastaEntrega.Size = New System.Drawing.Size(35, 13)
      Me.lblHastaEntrega.TabIndex = 39
      Me.lblHastaEntrega.Text = "Hasta"
      '
      'dtpDesdeEntrega
      '
      Me.dtpDesdeEntrega.BindearPropiedadControl = Nothing
      Me.dtpDesdeEntrega.BindearPropiedadEntidad = Nothing
      Me.dtpDesdeEntrega.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesdeEntrega.Enabled = False
      Me.dtpDesdeEntrega.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesdeEntrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesdeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesdeEntrega.IsPK = False
      Me.dtpDesdeEntrega.IsRequired = False
      Me.dtpDesdeEntrega.Key = ""
      Me.dtpDesdeEntrega.LabelAsoc = Me.lblDesdeEntrega
      Me.dtpDesdeEntrega.Location = New System.Drawing.Point(485, 47)
      Me.dtpDesdeEntrega.Name = "dtpDesdeEntrega"
      Me.dtpDesdeEntrega.Size = New System.Drawing.Size(129, 20)
      Me.dtpDesdeEntrega.TabIndex = 38
      '
      'lblDesdeEntrega
      '
      Me.lblDesdeEntrega.AutoSize = True
      Me.lblDesdeEntrega.LabelAsoc = Nothing
      Me.lblDesdeEntrega.Location = New System.Drawing.Point(441, 51)
      Me.lblDesdeEntrega.Name = "lblDesdeEntrega"
      Me.lblDesdeEntrega.Size = New System.Drawing.Size(38, 13)
      Me.lblDesdeEntrega.TabIndex = 37
      Me.lblDesdeEntrega.Text = "Desde"
      '
      'chbFecha
      '
      Me.chbFecha.AutoSize = True
      Me.chbFecha.BindearPropiedadControl = Nothing
      Me.chbFecha.BindearPropiedadEntidad = Nothing
      Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFecha.IsPK = False
      Me.chbFecha.IsRequired = False
      Me.chbFecha.Key = Nothing
      Me.chbFecha.LabelAsoc = Nothing
      Me.chbFecha.Location = New System.Drawing.Point(228, 23)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(56, 17)
      Me.chbFecha.TabIndex = 4
      Me.chbFecha.Text = "Fecha"
      Me.chbFecha.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(14, 25)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Estado"
      '
      'cmbEstados
      '
      Me.cmbEstados.BindearPropiedadControl = ""
      Me.cmbEstados.BindearPropiedadEntidad = ""
      Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEstados.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstados.FormattingEnabled = True
      Me.cmbEstados.IsPK = False
      Me.cmbEstados.IsRequired = False
      Me.cmbEstados.Key = Nothing
      Me.cmbEstados.LabelAsoc = Me.Label1
      Me.cmbEstados.Location = New System.Drawing.Point(60, 21)
      Me.cmbEstados.Name = "cmbEstados"
      Me.cmbEstados.Size = New System.Drawing.Size(158, 21)
      Me.cmbEstados.TabIndex = 3
      '
      'chkMesCompleto
      '
      Me.chkMesCompleto.AutoSize = True
      Me.chkMesCompleto.BindearPropiedadControl = Nothing
      Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
      Me.chkMesCompleto.Enabled = False
      Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
      Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkMesCompleto.IsPK = False
      Me.chkMesCompleto.IsRequired = False
      Me.chkMesCompleto.Key = Nothing
      Me.chkMesCompleto.LabelAsoc = Nothing
      Me.chkMesCompleto.Location = New System.Drawing.Point(342, 23)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 5
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.Enabled = False
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(663, 21)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
      Me.dtpHasta.TabIndex = 9
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(622, 25)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 8
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.Enabled = False
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(485, 21)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
      Me.dtpDesde.TabIndex = 7
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(441, 25)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 6
      Me.lblDesde.Text = "Desde"
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
      Me.chbCliente.Location = New System.Drawing.Point(17, 76)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 14
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
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
      Me.bscCodigoCliente.Location = New System.Drawing.Point(86, 74)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = False
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoCliente.TabIndex = 16
      '
      'bscNombreCliente
      '
      Me.bscNombreCliente.ActivarFiltroEnGrilla = True
      Me.bscNombreCliente.AutoSize = True
      Me.bscNombreCliente.BindearPropiedadControl = Nothing
      Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
      Me.bscNombreCliente.ConfigBuscador = Nothing
      Me.bscNombreCliente.Datos = Nothing
      Me.bscNombreCliente.FilaDevuelta = Nothing
      Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreCliente.IsDecimal = False
      Me.bscNombreCliente.IsNumber = False
      Me.bscNombreCliente.IsPK = False
      Me.bscNombreCliente.IsRequired = False
      Me.bscNombreCliente.Key = ""
      Me.bscNombreCliente.LabelAsoc = Nothing
      Me.bscNombreCliente.Location = New System.Drawing.Point(183, 73)
      Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreCliente.MaxLengh = "32767"
      Me.bscNombreCliente.Name = "bscNombreCliente"
      Me.bscNombreCliente.Permitido = False
      Me.bscNombreCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreCliente.Selecciono = False
      Me.bscNombreCliente.Size = New System.Drawing.Size(267, 23)
      Me.bscNombreCliente.TabIndex = 18
      '
      'ugDetalle
      '
      Me.ugDetalle.DataMember = Nothing
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn104.Header.VisiblePosition = 0
      UltraGridColumn104.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn104.Width = 51
      UltraGridColumn1.Header.VisiblePosition = 1
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn4.Header.VisiblePosition = 4
      UltraGridColumn5.Header.VisiblePosition = 5
      UltraGridColumn6.Header.VisiblePosition = 6
      UltraGridColumn7.Header.VisiblePosition = 7
      UltraGridColumn8.Header.VisiblePosition = 8
      UltraGridColumn9.Header.VisiblePosition = 9
      UltraGridColumn10.Header.VisiblePosition = 10
      UltraGridColumn11.Header.VisiblePosition = 11
      UltraGridColumn12.Header.VisiblePosition = 12
      UltraGridColumn13.Header.VisiblePosition = 13
      UltraGridColumn14.Header.VisiblePosition = 14
      UltraGridColumn15.Header.VisiblePosition = 15
      UltraGridColumn16.Header.VisiblePosition = 16
      UltraGridColumn17.Header.VisiblePosition = 17
      UltraGridColumn18.Header.VisiblePosition = 18
      UltraGridColumn19.Header.VisiblePosition = 19
      UltraGridColumn20.Header.VisiblePosition = 20
      UltraGridColumn21.Header.VisiblePosition = 21
      UltraGridColumn22.Header.VisiblePosition = 22
      UltraGridColumn23.Header.VisiblePosition = 23
      UltraGridColumn26.Header.VisiblePosition = 24
      UltraGridColumn27.Header.VisiblePosition = 26
      UltraGridColumn24.Header.VisiblePosition = 25
      UltraGridColumn25.Header.VisiblePosition = 27
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn104, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn26, UltraGridColumn27, UltraGridColumn24, UltraGridColumn25})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Me.ugDetalle.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(0, 138)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(987, 401)
      Me.ugDetalle.TabIndex = 13
      Me.ugDetalle.ToolStripLabelRegistros = Nothing
      Me.ugDetalle.ToolStripMenuExpandir = Nothing
      '
      'btnTodos
      '
      Me.btnTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnTodos.Location = New System.Drawing.Point(906, 145)
      Me.btnTodos.Name = "btnTodos"
      Me.btnTodos.Size = New System.Drawing.Size(75, 23)
      Me.btnTodos.TabIndex = 12
      Me.btnTodos.Text = "Aplicar"
      Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnTodos.UseVisualStyleBackColor = True
      '
      'cmbTodos
      '
      Me.cmbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
      Me.cmbTodos.Location = New System.Drawing.Point(779, 145)
      Me.cmbTodos.Name = "cmbTodos"
      Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
      Me.cmbTodos.TabIndex = 11
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(987, 22)
      Me.stsStado.TabIndex = 15
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(908, 17)
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
      'MRPPlanificacionNecesidadesProduccion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(987, 561)
      Me.Controls.Add(Me.cmbTodos)
      Me.Controls.Add(Me.btnTodos)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "MRPPlanificacionNecesidadesProduccion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Planificacion de Necesidades de Produccion"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Public WithEvents tstBarra As ToolStrip
    Public WithEvents tsbRefrescar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbCalcularNecesidades As ToolStripButton
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents tsbSalir As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chbFecha As Controles.CheckBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents cmbEstados As Controles.ComboBox
    Friend WithEvents chkMesCompleto As Controles.CheckBox
    Friend WithEvents dtpHasta As Controles.DateTimePicker
    Friend WithEvents lblHasta As Controles.Label
    Friend WithEvents dtpDesde As Controles.DateTimePicker
    Friend WithEvents lblDesde As Controles.Label
    Friend WithEvents chbCliente As Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Controles.Buscador2
   Friend WithEvents bscNombreCliente As Controles.Buscador2
   Friend WithEvents chbFechaEntrega As Controles.CheckBox
    Friend WithEvents chkMesCompletoEntrega As Controles.CheckBox
    Friend WithEvents dtpHastaEntrega As Controles.DateTimePicker
    Friend WithEvents lblHastaEntrega As Controles.Label
    Friend WithEvents dtpDesdeEntrega As Controles.DateTimePicker
    Friend WithEvents lblDesdeEntrega As Controles.Label
    Friend WithEvents ugDetalle As UltraGridSiga
    Friend WithEvents btnTodos As Button
    Friend WithEvents cmbTodos As Controles.ComboBox
    Protected Friend WithEvents stsStado As StatusStrip
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As ToolStripProgressBar
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents btnConsultar As Controles.Button
End Class
