<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalidadOrdenDeControlComprobantesCompras
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalidadOrdenDeControlComprobantesCompras))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLote")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoDeposito")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeposito")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoUbicacion")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUbicacion")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalCompra")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteCompra")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionComprobanteCompra")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraCompra")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorCompra")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteCompra")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCompra")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionCompra")
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
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Masivo")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProveedor")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProveedor")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdLote")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdDeposito")
      Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreDeposito")
      Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUbicacion")
      Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreUbicacion")
      Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursalCompra")
      Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobanteCompra")
      Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("LetraCompra")
      Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisorCompra")
      Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobanteCompra")
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.pnlInfoOP = New System.Windows.Forms.Panel()
      Me.pnlInfoOP2 = New System.Windows.Forms.TableLayoutPanel()
      Me.txtOrdenCalidad = New Eniac.Controles.TextBox()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.Label4 = New Eniac.Controles.Label()
      Me.txtProducto = New Eniac.Controles.TextBox()
      Me.txtEstado = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugOC = New Eniac.Win.UltraGridEditable()
      Me.UltraDataSource3 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.pnlInfoOP.SuspendLayout()
      Me.pnlInfoOP2.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.stsStado.SuspendLayout()
      CType(Me.ugOC, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'pnlInfoOP
      '
      Me.pnlInfoOP.Controls.Add(Me.pnlInfoOP2)
      Me.pnlInfoOP.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlInfoOP.Location = New System.Drawing.Point(0, 0)
      Me.pnlInfoOP.Name = "pnlInfoOP"
      Me.pnlInfoOP.Size = New System.Drawing.Size(984, 39)
      Me.pnlInfoOP.TabIndex = 103
      '
      'pnlInfoOP2
      '
      Me.pnlInfoOP2.ColumnCount = 5
      Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.pnlInfoOP2.Controls.Add(Me.txtOrdenCalidad, 0, 1)
      Me.pnlInfoOP2.Controls.Add(Me.lblFecha, 4, 0)
      Me.pnlInfoOP2.Controls.Add(Me.dtpFecha, 4, 1)
      Me.pnlInfoOP2.Controls.Add(Me.Label4, 0, 0)
      Me.pnlInfoOP2.Controls.Add(Me.txtProducto, 1, 1)
      Me.pnlInfoOP2.Controls.Add(Me.txtEstado, 3, 1)
      Me.pnlInfoOP2.Controls.Add(Me.Label2, 1, 0)
      Me.pnlInfoOP2.Controls.Add(Me.Label3, 3, 0)
      Me.pnlInfoOP2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlInfoOP2.Location = New System.Drawing.Point(0, 0)
      Me.pnlInfoOP2.Name = "pnlInfoOP2"
      Me.pnlInfoOP2.RowCount = 2
      Me.pnlInfoOP2.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.pnlInfoOP2.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.pnlInfoOP2.Size = New System.Drawing.Size(984, 39)
      Me.pnlInfoOP2.TabIndex = 98
      '
      'txtOrdenCalidad
      '
      Me.txtOrdenCalidad.BindearPropiedadControl = ""
      Me.txtOrdenCalidad.BindearPropiedadEntidad = ""
      Me.txtOrdenCalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtOrdenCalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtOrdenCalidad.Formato = ""
      Me.txtOrdenCalidad.IsDecimal = False
      Me.txtOrdenCalidad.IsNumber = True
      Me.txtOrdenCalidad.IsPK = False
      Me.txtOrdenCalidad.IsRequired = False
      Me.txtOrdenCalidad.Key = ""
      Me.txtOrdenCalidad.LabelAsoc = Nothing
      Me.txtOrdenCalidad.Location = New System.Drawing.Point(3, 16)
      Me.txtOrdenCalidad.Name = "txtOrdenCalidad"
      Me.txtOrdenCalidad.ReadOnly = True
      Me.txtOrdenCalidad.Size = New System.Drawing.Size(236, 20)
      Me.txtOrdenCalidad.TabIndex = 95
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.LabelAsoc = Nothing
      Me.lblFecha.Location = New System.Drawing.Point(899, 0)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 89
      Me.lblFecha.Text = "&Fecha"
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = Nothing
      Me.dtpFecha.BindearPropiedadEntidad = Nothing
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.Enabled = False
      Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(899, 16)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(82, 20)
      Me.dtpFecha.TabIndex = 88
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(3, 0)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(36, 13)
      Me.Label4.TabIndex = 85
      Me.Label4.Text = "Órden"
      '
      'txtProducto
      '
      Me.txtProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtProducto.BindearPropiedadControl = ""
      Me.txtProducto.BindearPropiedadEntidad = ""
      Me.txtProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtProducto.Formato = ""
      Me.txtProducto.IsDecimal = False
      Me.txtProducto.IsNumber = True
      Me.txtProducto.IsPK = False
      Me.txtProducto.IsRequired = False
      Me.txtProducto.Key = ""
      Me.txtProducto.LabelAsoc = Nothing
      Me.txtProducto.Location = New System.Drawing.Point(245, 16)
      Me.txtProducto.Name = "txtProducto"
      Me.txtProducto.ReadOnly = True
      Me.txtProducto.Size = New System.Drawing.Size(406, 20)
      Me.txtProducto.TabIndex = 93
      '
      'txtEstado
      '
      Me.txtEstado.BindearPropiedadControl = ""
      Me.txtEstado.BindearPropiedadEntidad = ""
      Me.txtEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEstado.Formato = ""
      Me.txtEstado.IsDecimal = False
      Me.txtEstado.IsNumber = True
      Me.txtEstado.IsPK = False
      Me.txtEstado.IsRequired = False
      Me.txtEstado.Key = ""
      Me.txtEstado.LabelAsoc = Nothing
      Me.txtEstado.Location = New System.Drawing.Point(657, 16)
      Me.txtEstado.Name = "txtEstado"
      Me.txtEstado.ReadOnly = True
      Me.txtEstado.Size = New System.Drawing.Size(236, 20)
      Me.txtEstado.TabIndex = 92
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(245, 0)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(50, 13)
      Me.Label2.TabIndex = 83
      Me.Label2.Text = "Producto"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(657, 0)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(40, 13)
      Me.Label3.TabIndex = 82
      Me.Label3.Text = "Estado"
      '
      'Panel2
      '
      Me.Panel2.AutoSize = True
      Me.Panel2.Controls.Add(Me.btnAceptar)
      Me.Panel2.Controls.Add(Me.btnCancelar)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 456)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(984, 33)
      Me.Panel2.TabIndex = 102
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(775, 0)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(100, 30)
      Me.btnAceptar.TabIndex = 5
      Me.btnAceptar.Text = "&Aceptar (F4)"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(881, 0)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(100, 30)
      Me.btnCancelar.TabIndex = 4
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.ToolStripProgressBar1, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 489)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(984, 22)
      Me.stsStado.TabIndex = 101
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(905, 17)
      Me.tssInfo.Spring = True
      '
      'ToolStripProgressBar1
      '
      Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
      Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
      Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.ToolStripProgressBar1.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'ugOC
      '
      Me.ugOC.DataMember = Nothing
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugOC.DisplayLayout.Appearance = Appearance1
      UltraGridColumn14.Header.VisiblePosition = 0
      UltraGridColumn14.Hidden = True
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Header.Caption = "Código Proveedor"
      UltraGridColumn1.Header.VisiblePosition = 1
      UltraGridColumn1.Width = 80
      UltraGridColumn15.Header.Caption = "Proveedor"
      UltraGridColumn15.Header.VisiblePosition = 2
      UltraGridColumn15.Width = 162
      UltraGridColumn16.Header.Caption = "Código Producto"
      UltraGridColumn16.Header.VisiblePosition = 3
      UltraGridColumn16.Width = 80
      UltraGridColumn17.Header.Caption = "Producto"
      UltraGridColumn17.Header.VisiblePosition = 4
      UltraGridColumn17.Width = 173
      Appearance3.TextHAlignAsString = "Right"
      Appearance3.TextVAlignAsString = "Middle"
      UltraGridColumn18.CellAppearance = Appearance3
      UltraGridColumn18.Header.Caption = "Lote"
      UltraGridColumn18.Header.VisiblePosition = 5
      UltraGridColumn18.Width = 91
      UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance4.TextHAlignAsString = "Right"
      Appearance4.TextVAlignAsString = "Middle"
      UltraGridColumn9.CellAppearance = Appearance4
      UltraGridColumn9.Format = "N2"
      UltraGridColumn9.Header.VisiblePosition = 7
      UltraGridColumn9.Width = 100
      UltraGridColumn19.Header.VisiblePosition = 6
      UltraGridColumn19.Hidden = True
      UltraGridColumn2.Header.Caption = "Código Deposito"
      UltraGridColumn2.Header.VisiblePosition = 9
      UltraGridColumn2.Width = 80
      Appearance5.TextVAlignAsString = "Middle"
      UltraGridColumn20.CellAppearance = Appearance5
      UltraGridColumn20.Header.Caption = "Deposito"
      UltraGridColumn20.Header.VisiblePosition = 10
      UltraGridColumn21.Header.VisiblePosition = 11
      UltraGridColumn21.Hidden = True
      UltraGridColumn3.Header.Caption = "Código Ubicación"
      UltraGridColumn3.Header.VisiblePosition = 12
      UltraGridColumn3.Width = 80
      Appearance6.TextVAlignAsString = "Middle"
      UltraGridColumn22.CellAppearance = Appearance6
      UltraGridColumn22.Header.Caption = "Ubicacion"
      UltraGridColumn22.Header.VisiblePosition = 13
      Appearance7.TextHAlignAsString = "Center"
      Appearance7.TextVAlignAsString = "Middle"
      UltraGridColumn23.CellAppearance = Appearance7
      UltraGridColumn23.Header.Caption = "Suc"
      UltraGridColumn23.Header.VisiblePosition = 14
      UltraGridColumn23.Width = 41
      UltraGridColumn24.Header.Caption = "Tipo Comprobante"
      UltraGridColumn24.Header.VisiblePosition = 15
      UltraGridColumn24.Hidden = True
      UltraGridColumn24.Width = 153
      UltraGridColumn4.Header.Caption = "Comprobante"
      UltraGridColumn4.Header.VisiblePosition = 16
      UltraGridColumn4.Width = 150
      Appearance8.TextHAlignAsString = "Center"
      Appearance8.TextVAlignAsString = "Middle"
      UltraGridColumn25.CellAppearance = Appearance8
      UltraGridColumn25.Header.Caption = "Letra"
      UltraGridColumn25.Header.VisiblePosition = 17
      UltraGridColumn25.Width = 38
      Appearance9.TextHAlignAsString = "Center"
      Appearance9.TextVAlignAsString = "Middle"
      UltraGridColumn26.CellAppearance = Appearance9
      UltraGridColumn26.Header.Caption = "Emisor"
      UltraGridColumn26.Header.VisiblePosition = 18
      UltraGridColumn26.Width = 46
      Appearance10.TextHAlignAsString = "Right"
      Appearance10.TextVAlignAsString = "Middle"
      UltraGridColumn27.CellAppearance = Appearance10
      UltraGridColumn27.Header.Caption = "Numero"
      UltraGridColumn27.Header.VisiblePosition = 19
      Appearance11.TextHAlignAsString = "Center"
      UltraGridColumn5.CellAppearance = Appearance11
      UltraGridColumn5.Format = "dd/MM/yyyy"
      UltraGridColumn5.Header.Caption = "Fecha"
      UltraGridColumn5.Header.VisiblePosition = 8
      UltraGridColumn5.Width = 80
      UltraGridColumn6.Header.Caption = "Observaciones"
      UltraGridColumn6.Header.VisiblePosition = 20
      UltraGridColumn6.Width = 300
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn14, UltraGridColumn1, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn9, UltraGridColumn19, UltraGridColumn2, UltraGridColumn20, UltraGridColumn21, UltraGridColumn3, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn4, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn5, UltraGridColumn6})
      Me.ugOC.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugOC.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugOC.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance12.BorderColor = System.Drawing.SystemColors.Window
      Me.ugOC.DisplayLayout.GroupByBox.Appearance = Appearance12
      Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugOC.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance13
      Me.ugOC.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance14.BackColor2 = System.Drawing.SystemColors.Control
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugOC.DisplayLayout.GroupByBox.PromptAppearance = Appearance14
      Me.ugOC.DisplayLayout.MaxColScrollRegions = 1
      Me.ugOC.DisplayLayout.MaxRowScrollRegions = 1
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugOC.DisplayLayout.Override.ActiveCellAppearance = Appearance15
      Appearance16.BackColor = System.Drawing.SystemColors.Highlight
      Appearance16.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugOC.DisplayLayout.Override.ActiveRowAppearance = Appearance16
      Me.ugOC.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugOC.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugOC.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugOC.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugOC.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance17.BackColor = System.Drawing.SystemColors.Window
      Me.ugOC.DisplayLayout.Override.CardAreaAppearance = Appearance17
      Appearance18.BorderColor = System.Drawing.Color.Silver
      Appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugOC.DisplayLayout.Override.CellAppearance = Appearance18
      Me.ugOC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugOC.DisplayLayout.Override.CellPadding = 0
      Appearance19.BackColor = System.Drawing.SystemColors.Control
      Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance19.BorderColor = System.Drawing.SystemColors.Window
      Me.ugOC.DisplayLayout.Override.GroupByRowAppearance = Appearance19
      Appearance20.TextHAlignAsString = "Left"
      Me.ugOC.DisplayLayout.Override.HeaderAppearance = Appearance20
      Me.ugOC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugOC.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance21.BackColor = System.Drawing.SystemColors.Window
      Appearance21.BorderColor = System.Drawing.Color.Silver
      Me.ugOC.DisplayLayout.Override.RowAppearance = Appearance21
      Me.ugOC.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Appearance22.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugOC.DisplayLayout.Override.TemplateAddRowAppearance = Appearance22
      Me.ugOC.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugOC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugOC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugOC.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugOC.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugOC.EnterMueveACeldaDeAbajo = True
      Me.ugOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugOC.Location = New System.Drawing.Point(0, 39)
      Me.ugOC.Name = "ugOC"
      Me.ugOC.Size = New System.Drawing.Size(984, 417)
      Me.ugOC.TabIndex = 104
      Me.ugOC.Text = "UltraGrid1"
      Me.ugOC.ToolStripLabelRegistros = Nothing
      Me.ugOC.ToolStripMenuExpandir = Nothing
      '
      'UltraDataSource3
      '
      Me.UltraDataSource3.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16})
      '
      'CalidadOrdenDeControlComprobantesCompras
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 511)
      Me.Controls.Add(Me.ugOC)
      Me.Controls.Add(Me.pnlInfoOP)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.stsStado)
      Me.Name = "CalidadOrdenDeControlComprobantesCompras"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Orden de Control de Calidad Comprobantes de Compras"
      Me.pnlInfoOP.ResumeLayout(False)
      Me.pnlInfoOP2.ResumeLayout(False)
      Me.pnlInfoOP2.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.ugOC, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Private WithEvents imageList1 As ImageList
   Friend WithEvents pnlInfoOP As Panel
   Friend WithEvents pnlInfoOP2 As TableLayoutPanel
   Friend WithEvents txtOrdenCalidad As Controles.TextBox
   Friend WithEvents lblFecha As Controles.Label
   Friend WithEvents dtpFecha As Controles.DateTimePicker
   Friend WithEvents Label4 As Controles.Label
   Friend WithEvents txtProducto As Controles.TextBox
   Friend WithEvents txtEstado As Controles.TextBox
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents Label3 As Controles.Label
   Friend WithEvents Panel2 As Panel
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Protected Friend WithEvents stsStado As StatusStrip
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
   Protected WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents ugOC As UltraGridEditable
    Friend WithEvents UltraDataSource3 As UltraWinDataSource.UltraDataSource
End Class
