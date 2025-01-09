<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductosRecepcion
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
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductosRecepcion))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MesesGarantia ")
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
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tslTexto = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tslRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.lblCompra = New Eniac.Controles.Label()
      Me.lblFechaHasta = New Eniac.Controles.Label()
      Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
      Me.lblFechaDesde = New Eniac.Controles.Label()
      Me.dtpFechaDesde = New Eniac.Controles.DateTimePicker()
      Me.txtCategoria = New Eniac.Controles.TextBox()
      Me.lblCategoria = New Eniac.Controles.Label()
      Me.txtTelefono = New Eniac.Controles.TextBox()
      Me.lblTelefono = New Eniac.Controles.Label()
      Me.txtLocalidad = New Eniac.Controles.TextBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.txtDireccion = New Eniac.Controles.TextBox()
      Me.lblDireccion = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbRecibir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbRecibirSinComprobante = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.StatusStrip1.SuspendLayout()
      Me.grbCliente.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslTexto, Me.tslRegistros, Me.tspBarra})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(1058, 22)
      Me.StatusStrip1.TabIndex = 19
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tslTexto
      '
      Me.tslTexto.Name = "tslTexto"
      Me.tslTexto.Size = New System.Drawing.Size(979, 17)
      Me.tslTexto.Spring = True
      '
      'tslRegistros
      '
      Me.tslRegistros.Name = "tslRegistros"
      Me.tslRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tslRegistros.Text = "0 Registros"
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Marquee
      Me.tspBarra.Visible = False
      '
      'grbCliente
      '
      Me.grbCliente.Controls.Add(Me.lblCompra)
      Me.grbCliente.Controls.Add(Me.lblFechaHasta)
      Me.grbCliente.Controls.Add(Me.dtpFechaHasta)
      Me.grbCliente.Controls.Add(Me.lblFechaDesde)
      Me.grbCliente.Controls.Add(Me.dtpFechaDesde)
      Me.grbCliente.Controls.Add(Me.txtCategoria)
      Me.grbCliente.Controls.Add(Me.lblCategoria)
      Me.grbCliente.Controls.Add(Me.txtTelefono)
      Me.grbCliente.Controls.Add(Me.lblTelefono)
      Me.grbCliente.Controls.Add(Me.txtLocalidad)
      Me.grbCliente.Controls.Add(Me.lblLocalidad)
      Me.grbCliente.Controls.Add(Me.txtDireccion)
      Me.grbCliente.Controls.Add(Me.lblDireccion)
      Me.grbCliente.Controls.Add(Me.btnConsultar)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.lblNombre)
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
      Me.grbCliente.Location = New System.Drawing.Point(12, 32)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(1034, 107)
      Me.grbCliente.TabIndex = 17
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Cliente"
      '
      'lblCompra
      '
      Me.lblCompra.AutoSize = True
      Me.lblCompra.Location = New System.Drawing.Point(470, 37)
      Me.lblCompra.Name = "lblCompra"
      Me.lblCompra.Size = New System.Drawing.Size(43, 13)
      Me.lblCompra.TabIndex = 44
      Me.lblCompra.Text = "Compra"
      '
      'lblFechaHasta
      '
      Me.lblFechaHasta.AutoSize = True
      Me.lblFechaHasta.Location = New System.Drawing.Point(618, 16)
      Me.lblFechaHasta.Name = "lblFechaHasta"
      Me.lblFechaHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblFechaHasta.TabIndex = 43
      Me.lblFechaHasta.Text = "Hasta"
      '
      'dtpFechaHasta
      '
      Me.dtpFechaHasta.BindearPropiedadControl = ""
      Me.dtpFechaHasta.BindearPropiedadEntidad = ""
      Me.dtpFechaHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaHasta.IsPK = False
      Me.dtpFechaHasta.IsRequired = True
      Me.dtpFechaHasta.Key = ""
      Me.dtpFechaHasta.LabelAsoc = Me.lblFechaHasta
      Me.dtpFechaHasta.Location = New System.Drawing.Point(621, 33)
      Me.dtpFechaHasta.Name = "dtpFechaHasta"
      Me.dtpFechaHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaHasta.TabIndex = 42
      '
      'lblFechaDesde
      '
      Me.lblFechaDesde.AutoSize = True
      Me.lblFechaDesde.Location = New System.Drawing.Point(515, 16)
      Me.lblFechaDesde.Name = "lblFechaDesde"
      Me.lblFechaDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblFechaDesde.TabIndex = 41
      Me.lblFechaDesde.Text = "Desde"
      '
      'dtpFechaDesde
      '
      Me.dtpFechaDesde.BindearPropiedadControl = ""
      Me.dtpFechaDesde.BindearPropiedadEntidad = ""
      Me.dtpFechaDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaDesde.IsPK = False
      Me.dtpFechaDesde.IsRequired = True
      Me.dtpFechaDesde.Key = ""
      Me.dtpFechaDesde.LabelAsoc = Me.lblFechaDesde
      Me.dtpFechaDesde.Location = New System.Drawing.Point(518, 33)
      Me.dtpFechaDesde.Name = "dtpFechaDesde"
      Me.dtpFechaDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaDesde.TabIndex = 40
      '
      'txtCategoria
      '
      Me.txtCategoria.BindearPropiedadControl = Nothing
      Me.txtCategoria.BindearPropiedadEntidad = Nothing
      Me.txtCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCategoria.Formato = ""
      Me.txtCategoria.IsDecimal = False
      Me.txtCategoria.IsNumber = False
      Me.txtCategoria.IsPK = False
      Me.txtCategoria.IsRequired = False
      Me.txtCategoria.Key = ""
      Me.txtCategoria.LabelAsoc = Me.lblCategoria
      Me.txtCategoria.Location = New System.Drawing.Point(579, 81)
      Me.txtCategoria.Name = "txtCategoria"
      Me.txtCategoria.ReadOnly = True
      Me.txtCategoria.Size = New System.Drawing.Size(140, 20)
      Me.txtCategoria.TabIndex = 38
      Me.txtCategoria.TabStop = False
      '
      'lblCategoria
      '
      Me.lblCategoria.AutoSize = True
      Me.lblCategoria.Location = New System.Drawing.Point(578, 65)
      Me.lblCategoria.Name = "lblCategoria"
      Me.lblCategoria.Size = New System.Drawing.Size(52, 13)
      Me.lblCategoria.TabIndex = 39
      Me.lblCategoria.Text = "Categoria"
      '
      'txtTelefono
      '
      Me.txtTelefono.BindearPropiedadControl = Nothing
      Me.txtTelefono.BindearPropiedadEntidad = Nothing
      Me.txtTelefono.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefono.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefono.Formato = ""
      Me.txtTelefono.IsDecimal = False
      Me.txtTelefono.IsNumber = False
      Me.txtTelefono.IsPK = False
      Me.txtTelefono.IsRequired = False
      Me.txtTelefono.Key = ""
      Me.txtTelefono.LabelAsoc = Me.lblTelefono
      Me.txtTelefono.Location = New System.Drawing.Point(428, 81)
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.ReadOnly = True
      Me.txtTelefono.Size = New System.Drawing.Size(144, 20)
      Me.txtTelefono.TabIndex = 33
      Me.txtTelefono.TabStop = False
      '
      'lblTelefono
      '
      Me.lblTelefono.AutoSize = True
      Me.lblTelefono.Location = New System.Drawing.Point(425, 65)
      Me.lblTelefono.Name = "lblTelefono"
      Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
      Me.lblTelefono.TabIndex = 37
      Me.lblTelefono.Text = "Telefono"
      '
      'txtLocalidad
      '
      Me.txtLocalidad.BindearPropiedadControl = Nothing
      Me.txtLocalidad.BindearPropiedadEntidad = Nothing
      Me.txtLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLocalidad.Formato = ""
      Me.txtLocalidad.IsDecimal = False
      Me.txtLocalidad.IsNumber = False
      Me.txtLocalidad.IsPK = False
      Me.txtLocalidad.IsRequired = False
      Me.txtLocalidad.Key = ""
      Me.txtLocalidad.LabelAsoc = Me.lblLocalidad
      Me.txtLocalidad.Location = New System.Drawing.Point(268, 81)
      Me.txtLocalidad.Name = "txtLocalidad"
      Me.txtLocalidad.ReadOnly = True
      Me.txtLocalidad.Size = New System.Drawing.Size(155, 20)
      Me.txtLocalidad.TabIndex = 32
      Me.txtLocalidad.TabStop = False
      '
      'lblLocalidad
      '
      Me.lblLocalidad.AutoSize = True
      Me.lblLocalidad.Location = New System.Drawing.Point(267, 65)
      Me.lblLocalidad.Name = "lblLocalidad"
      Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
      Me.lblLocalidad.TabIndex = 35
      Me.lblLocalidad.Text = "Localidad"
      '
      'txtDireccion
      '
      Me.txtDireccion.BindearPropiedadControl = Nothing
      Me.txtDireccion.BindearPropiedadEntidad = Nothing
      Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDireccion.Formato = ""
      Me.txtDireccion.IsDecimal = False
      Me.txtDireccion.IsNumber = False
      Me.txtDireccion.IsPK = False
      Me.txtDireccion.IsRequired = False
      Me.txtDireccion.Key = ""
      Me.txtDireccion.LabelAsoc = Me.lblDireccion
      Me.txtDireccion.Location = New System.Drawing.Point(15, 81)
      Me.txtDireccion.Name = "txtDireccion"
      Me.txtDireccion.ReadOnly = True
      Me.txtDireccion.Size = New System.Drawing.Size(248, 20)
      Me.txtDireccion.TabIndex = 30
      Me.txtDireccion.TabStop = False
      '
      'lblDireccion
      '
      Me.lblDireccion.AutoSize = True
      Me.lblDireccion.Location = New System.Drawing.Point(12, 65)
      Me.lblDireccion.Name = "lblDireccion"
      Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblDireccion.TabIndex = 34
      Me.lblDireccion.Text = "Dirección"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.Location = New System.Drawing.Point(781, 49)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 29
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasCondiciones = CType(resources.GetObject("bscCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCliente.ColumnasVisibles = CType(resources.GetObject("bscCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
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
      Me.bscCliente.LabelAsoc = Me.lblNombre
      Me.bscCliente.Location = New System.Drawing.Point(142, 34)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 15
      Me.bscCliente.TextBoxBackColor = System.Drawing.Color.Empty
      Me.bscCliente.TextBoxForeColor = System.Drawing.Color.Empty
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(139, 20)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 14
      Me.lblNombre.Text = "Nombre"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasCondiciones = CType(resources.GetObject("bscCodigoCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoCliente.ColumnasVisibles = CType(resources.GetObject("bscCodigoCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
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
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(19, 34)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoCliente.TabIndex = 10
      Me.bscCodigoCliente.TextBoxBackColor = System.Drawing.Color.Empty
      Me.bscCodigoCliente.TextBoxForeColor = System.Drawing.Color.Empty
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(19, 19)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 12
      Me.lblCodigoCliente.Text = "Codigo"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbRecibir, Me.toolStripSeparator3, Me.tsbRecibirSinComprobante, Me.ToolStripSeparator2, Me.tsbImprimir, Me.tsddExportar, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1058, 29)
      Me.tstBarra.TabIndex = 16
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbRecibir
      '
      Me.tsbRecibir.Enabled = False
      Me.tsbRecibir.Image = Global.Eniac.Win.My.Resources.Resources.import1
      Me.tsbRecibir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRecibir.Name = "tsbRecibir"
      Me.tsbRecibir.Size = New System.Drawing.Size(69, 26)
      Me.tsbRecibir.Text = "Reci&bir"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbRecibirSinComprobante
      '
      Me.tsbRecibirSinComprobante.Enabled = False
      Me.tsbRecibirSinComprobante.Image = Global.Eniac.Win.My.Resources.Resources.id_card_add
      Me.tsbRecibirSinComprobante.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRecibirSinComprobante.Name = "tsbRecibirSinComprobante"
      Me.tsbRecibirSinComprobante.Size = New System.Drawing.Size(165, 26)
      Me.tsbRecibirSinComprobante.Text = "Recibir Sin &Comprobante"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAPDF.Text = "a PDF"
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
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Format = "dd/MM/yyyy HH:mm"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 100
      UltraGridColumn2.Header.Caption = "Comprobante"
      UltraGridColumn2.Header.VisiblePosition = 1
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn4.CellAppearance = Appearance3
      UltraGridColumn4.Header.VisiblePosition = 2
      UltraGridColumn4.Width = 20
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance4
      UltraGridColumn5.Header.Caption = "Emisor"
      UltraGridColumn5.Header.VisiblePosition = 3
      UltraGridColumn5.Width = 40
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance5
      UltraGridColumn6.Header.Caption = "Número"
      UltraGridColumn6.Header.VisiblePosition = 4
      UltraGridColumn6.Width = 70
      UltraGridColumn51.Header.Caption = "Codigo"
      UltraGridColumn51.Header.VisiblePosition = 5
      UltraGridColumn52.Header.Caption = "Producto"
      UltraGridColumn52.Header.VisiblePosition = 6
      UltraGridColumn52.Width = 253
      UltraGridColumn53.Header.VisiblePosition = 7
      UltraGridColumn53.Width = 88
      UltraGridColumn54.Header.VisiblePosition = 9
      UltraGridColumn54.Hidden = True
      UltraGridColumn55.Header.VisiblePosition = 10
      UltraGridColumn55.Hidden = True
      UltraGridColumn56.Header.VisiblePosition = 11
      UltraGridColumn56.Hidden = True
      UltraGridColumn57.Header.Caption = "Marca"
      UltraGridColumn57.Header.VisiblePosition = 8
      UltraGridColumn57.Width = 175
      UltraGridColumn58.Header.VisiblePosition = 12
      UltraGridColumn58.Hidden = True
      UltraGridColumn59.Header.VisiblePosition = 13
      UltraGridColumn59.Hidden = True
      UltraGridColumn60.Header.Caption = "Garantia "
      UltraGridColumn60.Header.VisiblePosition = 14
      UltraGridColumn60.Width = 62
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance6.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance6
      Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance8.BackColor2 = System.Drawing.SystemColors.Control
      Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance9
      Appearance10.BackColor = System.Drawing.SystemColors.Highlight
      Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance11
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance13.BackColor = System.Drawing.SystemColors.Control
      Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance13.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance13
      Appearance14.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 145)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(1034, 392)
      Me.ugDetalle.TabIndex = 20
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance17
      Me.UltraGridPrintDocument1.Header.BorderSides = System.Windows.Forms.Border3DSide.Bottom
      Me.UltraGridPrintDocument1.Header.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.UltraGridPrintDocument1.Header.TextCenter = ""
      Me.UltraGridPrintDocument1.Page.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.UltraGridPrintDocument1.Page.Margins.Bottom = 2
      Me.UltraGridPrintDocument1.Page.Margins.Left = 2
      Me.UltraGridPrintDocument1.Page.Margins.Right = 2
      Me.UltraGridPrintDocument1.Page.Margins.Top = 2
      Me.UltraGridPrintDocument1.PageBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Left = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Right = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Top = 2
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'ProductosRecepcion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1058, 562)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.grbCliente)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ProductosRecepcion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Recepción de productos para reparación"
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbRecibir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tslTexto As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents txtCategoria As Eniac.Controles.TextBox
   Friend WithEvents lblCategoria As Eniac.Controles.Label
   Friend WithEvents txtTelefono As Eniac.Controles.TextBox
   Friend WithEvents lblTelefono As Eniac.Controles.Label
   Friend WithEvents txtLocalidad As Eniac.Controles.TextBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents lblCompra As Eniac.Controles.Label
   Friend WithEvents lblFechaHasta As Eniac.Controles.Label
   Friend WithEvents dtpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaDesde As Eniac.Controles.Label
   Friend WithEvents dtpFechaDesde As Eniac.Controles.DateTimePicker
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbRecibirSinComprobante As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
End Class
