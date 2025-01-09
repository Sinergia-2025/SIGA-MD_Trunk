<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompararProdPlantillaExcel
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompararProdPlantillaExcel))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Select")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlantilla")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePlantilla")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
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
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Actual")
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
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbEliminarPlantilla = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.tbcDetalle = New System.Windows.Forms.TabControl()
      Me.tbpFiltros = New System.Windows.Forms.TabPage()
      Me.pSubSubRubro = New System.Windows.Forms.Panel()
      Me.cmbSubSubRubro = New Eniac.Win.ComboBoxSubSubRubro()
      Me.chbSubSubRubro = New Eniac.Controles.Label()
      Me.pSubRubro = New System.Windows.Forms.Panel()
      Me.cmbSubRubro = New Eniac.Win.ComboBoxSubRubro()
      Me.Label4 = New Eniac.Controles.Label()
      Me.btnTodos = New System.Windows.Forms.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbRubro = New Eniac.Win.ComboBoxRubro()
      Me.cmbMarca = New Eniac.Win.ComboBoxMarcas()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.ugPlantillas = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tbpDatos = New System.Windows.Forms.TabPage()
      Me.lblFiltrosAplicados = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.ugDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.tstBarra.SuspendLayout()
        Me.tbcDetalle.SuspendLayout()
        Me.tbpFiltros.SuspendLayout()
        Me.pSubSubRubro.SuspendLayout()
        Me.pSubRubro.SuspendLayout()
        CType(Me.ugPlantillas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpDatos.SuspendLayout()
        CType(Me.ugDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbImprimir, Me.tss2, Me.tsddExportar, Me.tss3, Me.tsbEliminarPlantilla, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(912, 29)
        Me.tstBarra.TabIndex = 8
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
        'tss1
        '
        Me.tss1.Name = "tss1"
        Me.tss1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tss2
        '
        Me.tss2.Name = "tss2"
        Me.tss2.Size = New System.Drawing.Size(6, 29)
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'tsmiAExcel
        '
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'tss3
        '
        Me.tss3.Name = "tss3"
        Me.tss3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbEliminarPlantilla
        '
        Me.tsbEliminarPlantilla.Image = Global.Eniac.Win.My.Resources.Resources.delete2
        Me.tsbEliminarPlantilla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminarPlantilla.Name = "tsbEliminarPlantilla"
        Me.tsbEliminarPlantilla.Size = New System.Drawing.Size(121, 26)
        Me.tsbEliminarPlantilla.Text = "Eliminar Plantilla"
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
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(772, 304)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(102, 50)
        Me.btnConsultar.TabIndex = 12
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDetalle.Controls.Add(Me.tbpFiltros)
        Me.tbcDetalle.Controls.Add(Me.tbpDatos)
        Me.tbcDetalle.Location = New System.Drawing.Point(12, 32)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(888, 464)
        Me.tbcDetalle.TabIndex = 0
        '
        'tbpFiltros
        '
        Me.tbpFiltros.BackColor = System.Drawing.SystemColors.Control
        Me.tbpFiltros.Controls.Add(Me.pSubSubRubro)
        Me.tbpFiltros.Controls.Add(Me.pSubRubro)
        Me.tbpFiltros.Controls.Add(Me.btnTodos)
        Me.tbpFiltros.Controls.Add(Me.cmbTodos)
        Me.tbpFiltros.Controls.Add(Me.Label2)
        Me.tbpFiltros.Controls.Add(Me.Label1)
        Me.tbpFiltros.Controls.Add(Me.cmbRubro)
        Me.tbpFiltros.Controls.Add(Me.cmbMarca)
        Me.tbpFiltros.Controls.Add(Me.bscProducto2)
        Me.tbpFiltros.Controls.Add(Me.bscCodigoProducto2)
        Me.tbpFiltros.Controls.Add(Me.chbProducto)
        Me.tbpFiltros.Controls.Add(Me.ugPlantillas)
        Me.tbpFiltros.Controls.Add(Me.btnConsultar)
        Me.tbpFiltros.Location = New System.Drawing.Point(4, 22)
        Me.tbpFiltros.Name = "tbpFiltros"
        Me.tbpFiltros.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFiltros.Size = New System.Drawing.Size(880, 438)
        Me.tbpFiltros.TabIndex = 0
        Me.tbpFiltros.Text = "Filtros"
        '
        'pSubSubRubro
        '
        Me.pSubSubRubro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pSubSubRubro.Controls.Add(Me.cmbSubSubRubro)
        Me.pSubSubRubro.Controls.Add(Me.chbSubSubRubro)
        Me.pSubSubRubro.Location = New System.Drawing.Point(3, 379)
        Me.pSubSubRubro.Name = "pSubSubRubro"
        Me.pSubSubRubro.Size = New System.Drawing.Size(280, 24)
        Me.pSubSubRubro.TabIndex = 11
        Me.pSubSubRubro.Visible = False
        '
        'cmbSubSubRubro
        '
        Me.cmbSubSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubSubRubro.ConcatenarNombreSubRubro = False
        Me.cmbSubSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubSubRubro.FormattingEnabled = True
        Me.cmbSubSubRubro.IsPK = False
        Me.cmbSubSubRubro.IsRequired = False
        Me.cmbSubSubRubro.Key = Nothing
        Me.cmbSubSubRubro.LabelAsoc = Me.chbSubSubRubro
        Me.cmbSubSubRubro.Location = New System.Drawing.Point(85, 3)
        Me.cmbSubSubRubro.Name = "cmbSubSubRubro"
        Me.cmbSubSubRubro.Size = New System.Drawing.Size(194, 21)
        Me.cmbSubSubRubro.TabIndex = 1
        '
        'chbSubSubRubro
        '
        Me.chbSubSubRubro.AutoSize = True
        Me.chbSubSubRubro.LabelAsoc = Nothing
        Me.chbSubSubRubro.Location = New System.Drawing.Point(2, 6)
        Me.chbSubSubRubro.Name = "chbSubSubRubro"
        Me.chbSubSubRubro.Size = New System.Drawing.Size(77, 13)
        Me.chbSubSubRubro.TabIndex = 0
        Me.chbSubSubRubro.Text = "SubSub Rubro"
        '
        'pSubRubro
        '
        Me.pSubRubro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pSubRubro.Controls.Add(Me.cmbSubRubro)
        Me.pSubRubro.Controls.Add(Me.Label4)
        Me.pSubRubro.Location = New System.Drawing.Point(2, 349)
        Me.pSubRubro.Name = "pSubRubro"
        Me.pSubRubro.Size = New System.Drawing.Size(280, 24)
        Me.pSubRubro.TabIndex = 10
        Me.pSubRubro.Visible = False
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubro.ConcatenarNombreRubro = False
        Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubro.FormattingEnabled = True
        Me.cmbSubRubro.IsPK = False
        Me.cmbSubRubro.IsRequired = False
        Me.cmbSubRubro.Key = Nothing
        Me.cmbSubRubro.LabelAsoc = Nothing
        Me.cmbSubRubro.Location = New System.Drawing.Point(86, 3)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(193, 21)
        Me.cmbSubRubro.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Sub Rubro"
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(133, 5)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 1
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
        Me.cmbTodos.Location = New System.Drawing.Point(6, 6)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 325)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Rubro"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 297)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Marca"
        '
        'cmbRubro
        '
        Me.cmbRubro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbRubro.BindearPropiedadControl = Nothing
        Me.cmbRubro.BindearPropiedadEntidad = Nothing
        Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubro.FormattingEnabled = True
        Me.cmbRubro.IsPK = False
        Me.cmbRubro.IsRequired = False
        Me.cmbRubro.Key = Nothing
        Me.cmbRubro.LabelAsoc = Nothing
        Me.cmbRubro.Location = New System.Drawing.Point(48, 322)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(211, 21)
        Me.cmbRubro.TabIndex = 9
        '
        'cmbMarca
        '
        Me.cmbMarca.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbMarca.BindearPropiedadControl = Nothing
        Me.cmbMarca.BindearPropiedadEntidad = Nothing
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = False
        Me.cmbMarca.IsRequired = False
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Nothing
        Me.cmbMarca.Location = New System.Drawing.Point(48, 294)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(211, 21)
        Me.cmbMarca.TabIndex = 7
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
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
        Me.bscProducto2.Location = New System.Drawing.Point(214, 268)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(247, 20)
        Me.bscProducto2.TabIndex = 5
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(85, 267)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(123, 20)
        Me.bscCodigoProducto2.TabIndex = 4
        '
        'chbProducto
        '
        Me.chbProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(6, 269)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 3
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'ugPlantillas
        '
        Me.ugPlantillas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugPlantillas.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance2
        UltraGridColumn6.Header.Caption = "S."
        UltraGridColumn6.Header.VisiblePosition = 0
        UltraGridColumn6.Width = 28
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance3
        UltraGridColumn1.Header.Caption = "Código"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Width = 77
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "Proveedor"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 272
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance4
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "Plantilla"
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 237
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn5.CellAppearance = Appearance5
        UltraGridColumn5.Header.Caption = "Fecha de Actualizacion"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 137
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn6, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.ugPlantillas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugPlantillas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPlantillas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPlantillas.DisplayLayout.GroupByBox.Appearance = Appearance6
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPlantillas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
        Me.ugPlantillas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPlantillas.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance8.BackColor2 = System.Drawing.SystemColors.Control
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPlantillas.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
        Me.ugPlantillas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugPlantillas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugPlantillas.DisplayLayout.Override.ActiveCellAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugPlantillas.DisplayLayout.Override.ActiveRowAppearance = Appearance10
        Me.ugPlantillas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugPlantillas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPlantillas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugPlantillas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Me.ugPlantillas.DisplayLayout.Override.CardAreaAppearance = Appearance11
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugPlantillas.DisplayLayout.Override.CellAppearance = Appearance12
        Me.ugPlantillas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugPlantillas.DisplayLayout.Override.CellPadding = 0
        Appearance13.BackColor = System.Drawing.SystemColors.Control
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPlantillas.DisplayLayout.Override.GroupByRowAppearance = Appearance13
        Appearance14.TextHAlignAsString = "Left"
        Me.ugPlantillas.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.ugPlantillas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugPlantillas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Me.ugPlantillas.DisplayLayout.Override.RowAppearance = Appearance15
        Me.ugPlantillas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPlantillas.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugPlantillas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.ugPlantillas.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugPlantillas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugPlantillas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugPlantillas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugPlantillas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugPlantillas.Location = New System.Drawing.Point(6, 33)
        Me.ugPlantillas.Name = "ugPlantillas"
        Me.ugPlantillas.Size = New System.Drawing.Size(868, 218)
        Me.ugPlantillas.TabIndex = 2
        '
        'tbpDatos
        '
        Me.tbpDatos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDatos.Controls.Add(Me.lblFiltrosAplicados)
        Me.tbpDatos.Controls.Add(Me.Label3)
        Me.tbpDatos.Controls.Add(Me.ugDatos)
        Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDatos.Name = "tbpDatos"
        Me.tbpDatos.Size = New System.Drawing.Size(880, 438)
        Me.tbpDatos.TabIndex = 2
        Me.tbpDatos.Text = "Datos"
        '
        'lblFiltrosAplicados
        '
        Me.lblFiltrosAplicados.AutoSize = True
        Me.lblFiltrosAplicados.Location = New System.Drawing.Point(94, 23)
        Me.lblFiltrosAplicados.Name = "lblFiltrosAplicados"
        Me.lblFiltrosAplicados.Size = New System.Drawing.Size(14, 13)
        Me.lblFiltrosAplicados.TabIndex = 9
        Me.lblFiltrosAplicados.Text = "#"
        Me.lblFiltrosAplicados.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Filtros aplicados:"
        '
        'ugDatos
        '
        Me.ugDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDatos.DisplayLayout.Appearance = Appearance17
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "Código"
        UltraGridColumn7.Header.VisiblePosition = 0
        UltraGridColumn9.Header.Caption = "Producto"
        UltraGridColumn9.Header.VisiblePosition = 1
        UltraGridColumn9.Width = 215
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Format = "N2"
        UltraGridColumn8.Header.Caption = "Pr. Costo Actual"
        UltraGridColumn8.Header.VisiblePosition = 2
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn7, UltraGridColumn9, UltraGridColumn8})
        Me.ugDatos.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugDatos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDatos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDatos.DisplayLayout.GroupByBox.Appearance = Appearance18
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDatos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
        Me.ugDatos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance20.BackColor2 = System.Drawing.SystemColors.Control
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDatos.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
        Me.ugDatos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDatos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDatos.DisplayLayout.Override.ActiveCellAppearance = Appearance21
        Appearance22.BackColor = System.Drawing.SystemColors.Highlight
        Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDatos.DisplayLayout.Override.ActiveRowAppearance = Appearance22
        Me.ugDatos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDatos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDatos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDatos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDatos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Me.ugDatos.DisplayLayout.Override.CardAreaAppearance = Appearance23
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDatos.DisplayLayout.Override.CellAppearance = Appearance24
        Me.ugDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDatos.DisplayLayout.Override.CellPadding = 0
        Appearance25.BackColor = System.Drawing.SystemColors.Control
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDatos.DisplayLayout.Override.GroupByRowAppearance = Appearance25
        Appearance26.TextHAlignAsString = "Left"
        Me.ugDatos.DisplayLayout.Override.HeaderAppearance = Appearance26
        Me.ugDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDatos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Me.ugDatos.DisplayLayout.Override.RowAppearance = Appearance27
        Me.ugDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDatos.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDatos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
        Me.ugDatos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDatos.Location = New System.Drawing.Point(3, 58)
        Me.ugDatos.Name = "ugDatos"
        Me.ugDatos.Size = New System.Drawing.Size(874, 377)
        Me.ugDatos.TabIndex = 7
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDatos
        Appearance29.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance29.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance29
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
        'CompararProdPlantillaExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 508)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "CompararProdPlantillaExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comparar Productos entre Proveedores"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.tbcDetalle.ResumeLayout(False)
        Me.tbpFiltros.ResumeLayout(False)
        Me.tbpFiltros.PerformLayout()
        Me.pSubSubRubro.ResumeLayout(False)
        Me.pSubSubRubro.PerformLayout()
        Me.pSubRubro.ResumeLayout(False)
        Me.pSubRubro.PerformLayout()
        CType(Me.ugPlantillas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpDatos.ResumeLayout(False)
        Me.tbpDatos.PerformLayout()
        CType(Me.ugDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents tbpFiltros As System.Windows.Forms.TabPage
   Friend WithEvents ugPlantillas As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
   Friend WithEvents ugDatos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Win.ComboBoxRubro
   Friend WithEvents cmbMarca As Eniac.Win.ComboBoxMarcas
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents lblFiltrosAplicados As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Friend WithEvents tsbEliminarPlantilla As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents pSubRubro As System.Windows.Forms.Panel
   Friend WithEvents cmbSubRubro As Eniac.Win.ComboBoxSubRubro
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents pSubSubRubro As System.Windows.Forms.Panel
   Friend WithEvents cmbSubSubRubro As Eniac.Win.ComboBoxSubSubRubro
   Friend WithEvents chbSubSubRubro As Eniac.Controles.Label
End Class
