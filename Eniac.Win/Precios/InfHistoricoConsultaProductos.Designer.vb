<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfHistoricoConsultaProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfHistoricoConsultaProductos))
        Dim DockAreaPane1 As Infragistics.Win.UltraWinDock.DockAreaPane = New Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, New System.Guid("2d6fdcab-c921-47e5-be54-e8fbb55ff5f5"))
        Dim DockableControlPane1 As Infragistics.Win.UltraWinDock.DockableControlPane = New Infragistics.Win.UltraWinDock.DockableControlPane(New System.Guid("d83460d5-3a80-4866-a953-70b6a424346e"), New System.Guid("00000000-0000-0000-0000-000000000000"), -1, New System.Guid("2d6fdcab-c921-47e5-be54-e8fbb55ff5f5"), -1)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaHora")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
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
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdMarca")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdRubro")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaHora")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioFabrica")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioCosto")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioVenta")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.cmbUsuario = New Eniac.Controles.ComboBox()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.chbMarca = New Eniac.Controles.CheckBox()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.clbSucursales = New Eniac.Controles.CheckedListBox()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.udmAutomatico = New Infragistics.Win.UltraWinDock.UltraDockManager(Me.components)
        Me._InfHistoricoPreciosUnpinnedTabAreaLeft = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._InfHistoricoPreciosUnpinnedTabAreaRight = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._InfHistoricoPreciosUnpinnedTabAreaTop = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._InfHistoricoPreciosUnpinnedTabAreaBottom = New Infragistics.Win.UltraWinDock.UnpinnedTabArea()
        Me._InfHistoricoPreciosAutoHideControl = New Infragistics.Win.UltraWinDock.AutoHideControl()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.WindowDockingArea1 = New Infragistics.Win.UltraWinDock.WindowDockingArea()
        Me.DockableWindow1 = New Infragistics.Win.UltraWinDock.DockableWindow()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.udmAutomatico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WindowDockingArea1.SuspendLayout()
        Me.DockableWindow1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.bscProducto2)
        Me.grbFiltros.Controls.Add(Me.bscCodigoProducto2)
        Me.grbFiltros.Controls.Add(Me.chbUsuario)
        Me.grbFiltros.Controls.Add(Me.cmbUsuario)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.chbRubro)
        Me.grbFiltros.Controls.Add(Me.cmbRubro)
        Me.grbFiltros.Controls.Add(Me.chbMarca)
        Me.grbFiltros.Controls.Add(Me.chbProducto)
        Me.grbFiltros.Controls.Add(Me.cmbMarca)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.clbSucursales)
        Me.grbFiltros.Location = New System.Drawing.Point(0, 18)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(986, 99)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        '
        'bscProducto2
        '
        Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ColumnasVisibles = CType(resources.GetObject("bscProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.Enabled = False
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(441, 47)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(306, 20)
        Me.bscProducto2.TabIndex = 48
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ColumnasVisibles = CType(resources.GetObject("bscCodigoProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.Enabled = False
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(287, 46)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
        Me.bscCodigoProducto2.TabIndex = 47
        '
        'chbUsuario
        '
        Me.chbUsuario.AutoSize = True
        Me.chbUsuario.BindearPropiedadControl = Nothing
        Me.chbUsuario.BindearPropiedadEntidad = Nothing
        Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuario.IsPK = False
        Me.chbUsuario.IsRequired = False
        Me.chbUsuario.Key = Nothing
        Me.chbUsuario.LabelAsoc = Nothing
        Me.chbUsuario.Location = New System.Drawing.Point(213, 76)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 12
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'cmbUsuario
        '
        Me.cmbUsuario.BindearPropiedadControl = Nothing
        Me.cmbUsuario.BindearPropiedadEntidad = Nothing
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.Enabled = False
        Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.IsPK = False
        Me.cmbUsuario.IsRequired = False
        Me.cmbUsuario.Key = Nothing
        Me.cmbUsuario.LabelAsoc = Nothing
        Me.cmbUsuario.Location = New System.Drawing.Point(287, 74)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(136, 21)
        Me.cmbUsuario.TabIndex = 13
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(874, 71)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 26)
        Me.chkExpandAll.TabIndex = 15
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'chbRubro
        '
        Me.chbRubro.AutoSize = True
        Me.chbRubro.BindearPropiedadControl = Nothing
        Me.chbRubro.BindearPropiedadEntidad = Nothing
        Me.chbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRubro.IsPK = False
        Me.chbRubro.IsRequired = False
        Me.chbRubro.Key = Nothing
        Me.chbRubro.LabelAsoc = Nothing
        Me.chbRubro.Location = New System.Drawing.Point(512, 18)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 7
        Me.chbRubro.Text = "Rubro"
        Me.chbRubro.UseVisualStyleBackColor = True
        '
        'cmbRubro
        '
        Me.cmbRubro.BindearPropiedadControl = Nothing
        Me.cmbRubro.BindearPropiedadEntidad = Nothing
        Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro.Enabled = False
        Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubro.FormattingEnabled = True
        Me.cmbRubro.IsPK = False
        Me.cmbRubro.IsRequired = False
        Me.cmbRubro.Key = Nothing
        Me.cmbRubro.LabelAsoc = Nothing
        Me.cmbRubro.Location = New System.Drawing.Point(573, 16)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(170, 21)
        Me.cmbRubro.TabIndex = 8
        '
        'chbMarca
        '
        Me.chbMarca.AutoSize = True
        Me.chbMarca.BindearPropiedadControl = Nothing
        Me.chbMarca.BindearPropiedadEntidad = Nothing
        Me.chbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarca.IsPK = False
        Me.chbMarca.IsRequired = False
        Me.chbMarca.Key = Nothing
        Me.chbMarca.LabelAsoc = Nothing
        Me.chbMarca.Location = New System.Drawing.Point(213, 18)
        Me.chbMarca.Name = "chbMarca"
        Me.chbMarca.Size = New System.Drawing.Size(56, 17)
        Me.chbMarca.TabIndex = 5
        Me.chbMarca.Text = "Marca"
        Me.chbMarca.UseVisualStyleBackColor = True
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(213, 48)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 9
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'cmbMarca
        '
        Me.cmbMarca.BindearPropiedadControl = Nothing
        Me.cmbMarca.BindearPropiedadEntidad = Nothing
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = False
        Me.cmbMarca.IsRequired = False
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Nothing
        Me.cmbMarca.Location = New System.Drawing.Point(287, 16)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(170, 21)
        Me.cmbMarca.TabIndex = 6
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(55, 16)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(807, 11)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 56)
        Me.btnConsultar.TabIndex = 14
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(55, 65)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.Location = New System.Drawing.Point(11, 71)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 3
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
        Me.dtpDesde.Location = New System.Drawing.Point(55, 39)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.Location = New System.Drawing.Point(11, 43)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'clbSucursales
        '
        Me.clbSucursales.CheckOnClick = True
        Me.clbSucursales.FormattingEnabled = True
        Me.clbSucursales.Location = New System.Drawing.Point(874, 40)
        Me.clbSucursales.Name = "clbSucursales"
        Me.clbSucursales.Size = New System.Drawing.Size(134, 64)
        Me.clbSucursales.TabIndex = 6
        Me.clbSucursales.Visible = False
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(986, 29)
        Me.tstBarra.TabIndex = 0
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
        'udmAutomatico
        '
        Me.udmAutomatico.AutoHideDelay = 200
        Me.udmAutomatico.CompressUnpinnedTabs = False
        DockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit
        DockableControlPane1.Control = Me.grbFiltros
        DockableControlPane1.FlyoutSize = New System.Drawing.Size(-1, 153)
        DockableControlPane1.OriginalControlBounds = New System.Drawing.Rectangle(269, 123, 208, 189)
        DockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.[False]
        DockableControlPane1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.[True]
        DockableControlPane1.Size = New System.Drawing.Size(100, 100)
        DockableControlPane1.Text = "Filtros"
        DockAreaPane1.Panes.AddRange(New Infragistics.Win.UltraWinDock.DockablePaneBase() {DockableControlPane1})
        DockAreaPane1.Size = New System.Drawing.Size(986, 117)
        Me.udmAutomatico.DockAreas.AddRange(New Infragistics.Win.UltraWinDock.DockAreaPane() {DockAreaPane1})
        Me.udmAutomatico.HostControl = Me
        Me.udmAutomatico.SplitterBarWidth = 3
        '
        '_InfHistoricoPreciosUnpinnedTabAreaLeft
        '
        Me._InfHistoricoPreciosUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me._InfHistoricoPreciosUnpinnedTabAreaLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._InfHistoricoPreciosUnpinnedTabAreaLeft.Location = New System.Drawing.Point(0, 29)
        Me._InfHistoricoPreciosUnpinnedTabAreaLeft.Name = "_InfHistoricoPreciosUnpinnedTabAreaLeft"
        Me._InfHistoricoPreciosUnpinnedTabAreaLeft.Owner = Me.udmAutomatico
        Me._InfHistoricoPreciosUnpinnedTabAreaLeft.Size = New System.Drawing.Size(0, 542)
        Me._InfHistoricoPreciosUnpinnedTabAreaLeft.TabIndex = 2
        '
        '_InfHistoricoPreciosUnpinnedTabAreaRight
        '
        Me._InfHistoricoPreciosUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right
        Me._InfHistoricoPreciosUnpinnedTabAreaRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._InfHistoricoPreciosUnpinnedTabAreaRight.Location = New System.Drawing.Point(986, 29)
        Me._InfHistoricoPreciosUnpinnedTabAreaRight.Name = "_InfHistoricoPreciosUnpinnedTabAreaRight"
        Me._InfHistoricoPreciosUnpinnedTabAreaRight.Owner = Me.udmAutomatico
        Me._InfHistoricoPreciosUnpinnedTabAreaRight.Size = New System.Drawing.Size(0, 542)
        Me._InfHistoricoPreciosUnpinnedTabAreaRight.TabIndex = 3
        '
        '_InfHistoricoPreciosUnpinnedTabAreaTop
        '
        Me._InfHistoricoPreciosUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top
        Me._InfHistoricoPreciosUnpinnedTabAreaTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._InfHistoricoPreciosUnpinnedTabAreaTop.Location = New System.Drawing.Point(0, 29)
        Me._InfHistoricoPreciosUnpinnedTabAreaTop.Name = "_InfHistoricoPreciosUnpinnedTabAreaTop"
        Me._InfHistoricoPreciosUnpinnedTabAreaTop.Owner = Me.udmAutomatico
        Me._InfHistoricoPreciosUnpinnedTabAreaTop.Size = New System.Drawing.Size(986, 0)
        Me._InfHistoricoPreciosUnpinnedTabAreaTop.TabIndex = 4
        '
        '_InfHistoricoPreciosUnpinnedTabAreaBottom
        '
        Me._InfHistoricoPreciosUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me._InfHistoricoPreciosUnpinnedTabAreaBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._InfHistoricoPreciosUnpinnedTabAreaBottom.Location = New System.Drawing.Point(0, 571)
        Me._InfHistoricoPreciosUnpinnedTabAreaBottom.Name = "_InfHistoricoPreciosUnpinnedTabAreaBottom"
        Me._InfHistoricoPreciosUnpinnedTabAreaBottom.Owner = Me.udmAutomatico
        Me._InfHistoricoPreciosUnpinnedTabAreaBottom.Size = New System.Drawing.Size(986, 0)
        Me._InfHistoricoPreciosUnpinnedTabAreaBottom.TabIndex = 5
        '
        '_InfHistoricoPreciosAutoHideControl
        '
        Me._InfHistoricoPreciosAutoHideControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._InfHistoricoPreciosAutoHideControl.Location = New System.Drawing.Point(0, 50)
        Me._InfHistoricoPreciosAutoHideControl.Name = "_InfHistoricoPreciosAutoHideControl"
        Me._InfHistoricoPreciosAutoHideControl.Owner = Me.udmAutomatico
        Me._InfHistoricoPreciosAutoHideControl.Size = New System.Drawing.Size(986, 158)
        Me._InfHistoricoPreciosAutoHideControl.TabIndex = 6
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance2
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance3
        UltraGridColumn2.Header.Caption = "Producto"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "Nombre Producto"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 250
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "Marca"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 150
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "Rubro"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 150
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn8.CellAppearance = Appearance4
        UltraGridColumn8.Format = "dd/MM/yyyy HH:mm"
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn8.Header.Appearance = Appearance5
        UltraGridColumn8.Header.Caption = "Fecha Hora"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 100
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 80
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9})
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
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aquí para agrupar"
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
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 149)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(986, 422)
        Me.ugDetalle.TabIndex = 9
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12})
        '
        'WindowDockingArea1
        '
        Me.WindowDockingArea1.Controls.Add(Me.DockableWindow1)
        Me.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top
        Me.WindowDockingArea1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowDockingArea1.Location = New System.Drawing.Point(0, 29)
        Me.WindowDockingArea1.Name = "WindowDockingArea1"
        Me.WindowDockingArea1.Owner = Me.udmAutomatico
        Me.WindowDockingArea1.Size = New System.Drawing.Size(986, 120)
        Me.WindowDockingArea1.TabIndex = 10
        '
        'DockableWindow1
        '
        Me.DockableWindow1.Controls.Add(Me.grbFiltros)
        Me.DockableWindow1.Location = New System.Drawing.Point(0, 0)
        Me.DockableWindow1.Name = "DockableWindow1"
        Me.DockableWindow1.Owner = Me.udmAutomatico
        Me.DockableWindow1.Size = New System.Drawing.Size(986, 117)
        Me.DockableWindow1.TabIndex = 11
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
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
        'InfHistoricoConsultaProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 571)
        Me.Controls.Add(Me._InfHistoricoPreciosAutoHideControl)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.WindowDockingArea1)
        Me.Controls.Add(Me._InfHistoricoPreciosUnpinnedTabAreaBottom)
        Me.Controls.Add(Me._InfHistoricoPreciosUnpinnedTabAreaTop)
        Me.Controls.Add(Me._InfHistoricoPreciosUnpinnedTabAreaLeft)
        Me.Controls.Add(Me._InfHistoricoPreciosUnpinnedTabAreaRight)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "InfHistoricoConsultaProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Historico Consulta Productos"
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.udmAutomatico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WindowDockingArea1.ResumeLayout(False)
        Me.DockableWindow1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents udmAutomatico As Infragistics.Win.UltraWinDock.UltraDockManager
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents _InfHistoricoPreciosAutoHideControl As Infragistics.Win.UltraWinDock.AutoHideControl
   Friend WithEvents _InfHistoricoPreciosUnpinnedTabAreaTop As Infragistics.Win.UltraWinDock.UnpinnedTabArea
   Friend WithEvents _InfHistoricoPreciosUnpinnedTabAreaBottom As Infragistics.Win.UltraWinDock.UnpinnedTabArea
   Friend WithEvents _InfHistoricoPreciosUnpinnedTabAreaRight As Infragistics.Win.UltraWinDock.UnpinnedTabArea
   Friend WithEvents _InfHistoricoPreciosUnpinnedTabAreaLeft As Infragistics.Win.UltraWinDock.UnpinnedTabArea
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents clbSucursales As Eniac.Controles.CheckedListBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents DockableWindow1 As Infragistics.Win.UltraWinDock.DockableWindow
   Friend WithEvents WindowDockingArea1 As Infragistics.Win.UltraWinDock.WindowDockingArea
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
    Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
    Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
End Class
