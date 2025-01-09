<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ResumenDetallePorComprobanteCompras
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResumenDetallePorComprobanteCompras))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NetoNoGravado")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Neto")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DerechoAduanero")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
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
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.cmbCategoriasFiscales = New Eniac.Win.ComboBoxCategoriasFiscales()
        Me.Label6 = New Eniac.Controles.Label()
        Me.cmbRubroCompra = New Eniac.Win.ComboBoxRubroCompras()
        Me.Label5 = New Eniac.Controles.Label()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTiposComprobantes = New Eniac.Controles.Label()
        Me.chbSepararNetos = New Eniac.Controles.CheckBox()
        Me.cmbInformaLibroIva = New Eniac.Controles.ComboBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.chkUltimoAno = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.cmbEsComercial = New Eniac.Controles.ComboBox()
        Me.lblEsComercial = New Eniac.Controles.Label()
        Me.cmbAfectaCaja = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.Label4 = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.txtIVA105 = New Eniac.Controles.TextBox()
        Me.txtIVA210 = New Eniac.Controles.TextBox()
        Me.txtNeto = New Eniac.Controles.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPercepcionVarias = New Eniac.Controles.TextBox()
        Me.txtPercepcionGanancias = New Eniac.Controles.TextBox()
        Me.txtPercepcionIB = New Eniac.Controles.TextBox()
        Me.txtPercepcionIVA = New Eniac.Controles.TextBox()
        Me.txtIva270 = New Eniac.Controles.TextBox()
        Me.txtNetoNoGravado = New Eniac.Controles.TextBox()
        Me.ugPorComprobante = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.grbConsultar.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ugPorComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbConsultar
        '
        Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbConsultar.Controls.Add(Me.cmbCategoriasFiscales)
        Me.grbConsultar.Controls.Add(Me.Label6)
        Me.grbConsultar.Controls.Add(Me.cmbRubroCompra)
        Me.grbConsultar.Controls.Add(Me.Label5)
        Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.lblTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.chbSepararNetos)
        Me.grbConsultar.Controls.Add(Me.cmbInformaLibroIva)
        Me.grbConsultar.Controls.Add(Me.Label3)
        Me.grbConsultar.Controls.Add(Me.Label2)
        Me.grbConsultar.Controls.Add(Me.chkUltimoAno)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Controls.Add(Me.cmbEsComercial)
        Me.grbConsultar.Controls.Add(Me.lblEsComercial)
        Me.grbConsultar.Controls.Add(Me.cmbAfectaCaja)
        Me.grbConsultar.Controls.Add(Me.Label1)
        Me.grbConsultar.Controls.Add(Me.cmbGrabanLibro)
        Me.grbConsultar.Controls.Add(Me.Label4)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Location = New System.Drawing.Point(12, 30)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(956, 108)
        Me.grbConsultar.TabIndex = 2
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'cmbCategoriasFiscales
        '
        Me.cmbCategoriasFiscales.BindearPropiedadControl = Nothing
        Me.cmbCategoriasFiscales.BindearPropiedadEntidad = Nothing
        Me.cmbCategoriasFiscales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriasFiscales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbCategoriasFiscales.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriasFiscales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriasFiscales.FormattingEnabled = True
        Me.cmbCategoriasFiscales.IsPK = False
        Me.cmbCategoriasFiscales.IsRequired = False
        Me.cmbCategoriasFiscales.ItemHeight = 13
        Me.cmbCategoriasFiscales.Key = Nothing
        Me.cmbCategoriasFiscales.LabelAsoc = Me.Label6
        Me.cmbCategoriasFiscales.Location = New System.Drawing.Point(446, 77)
        Me.cmbCategoriasFiscales.Name = "cmbCategoriasFiscales"
        Me.cmbCategoriasFiscales.Size = New System.Drawing.Size(156, 21)
        Me.cmbCategoriasFiscales.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(350, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Categoría Fiscal"
        '
        'cmbRubroCompra
        '
        Me.cmbRubroCompra.BindearPropiedadControl = Nothing
        Me.cmbRubroCompra.BindearPropiedadEntidad = Nothing
        Me.cmbRubroCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubroCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubroCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubroCompra.FormattingEnabled = True
        Me.cmbRubroCompra.IsPK = False
        Me.cmbRubroCompra.IsRequired = False
        Me.cmbRubroCompra.Key = Nothing
        Me.cmbRubroCompra.LabelAsoc = Me.Label5
        Me.cmbRubroCompra.Location = New System.Drawing.Point(669, 51)
        Me.cmbRubroCompra.Name = "cmbRubroCompra"
        Me.cmbRubroCompra.Size = New System.Drawing.Size(156, 21)
        Me.cmbRubroCompra.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(627, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Rubro"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTiposComprobantes
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(446, 52)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(156, 21)
        Me.cmbTiposComprobantes.TabIndex = 16
        '
        'lblTiposComprobantes
        '
        Me.lblTiposComprobantes.AutoSize = True
        Me.lblTiposComprobantes.LabelAsoc = Nothing
        Me.lblTiposComprobantes.Location = New System.Drawing.Point(346, 54)
        Me.lblTiposComprobantes.Name = "lblTiposComprobantes"
        Me.lblTiposComprobantes.Size = New System.Drawing.Size(94, 13)
        Me.lblTiposComprobantes.TabIndex = 15
        Me.lblTiposComprobantes.Text = "Tipo Comprobante"
        '
        'chbSepararNetos
        '
        Me.chbSepararNetos.AutoSize = True
        Me.chbSepararNetos.BindearPropiedadControl = Nothing
        Me.chbSepararNetos.BindearPropiedadEntidad = Nothing
        Me.chbSepararNetos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSepararNetos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSepararNetos.IsPK = False
        Me.chbSepararNetos.IsRequired = False
        Me.chbSepararNetos.Key = Nothing
        Me.chbSepararNetos.LabelAsoc = Nothing
        Me.chbSepararNetos.Location = New System.Drawing.Point(436, 19)
        Me.chbSepararNetos.Name = "chbSepararNetos"
        Me.chbSepararNetos.Size = New System.Drawing.Size(94, 17)
        Me.chbSepararNetos.TabIndex = 6
        Me.chbSepararNetos.Text = "Separar Netos"
        Me.chbSepararNetos.UseVisualStyleBackColor = True
        '
        'cmbInformaLibroIva
        '
        Me.cmbInformaLibroIva.BindearPropiedadControl = Nothing
        Me.cmbInformaLibroIva.BindearPropiedadEntidad = Nothing
        Me.cmbInformaLibroIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInformaLibroIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInformaLibroIva.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbInformaLibroIva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbInformaLibroIva.FormattingEnabled = True
        Me.cmbInformaLibroIva.IsPK = False
        Me.cmbInformaLibroIva.IsRequired = False
        Me.cmbInformaLibroIva.Key = Nothing
        Me.cmbInformaLibroIva.LabelAsoc = Me.Label3
        Me.cmbInformaLibroIva.Location = New System.Drawing.Point(262, 77)
        Me.cmbInformaLibroIva.Name = "cmbInformaLibroIva"
        Me.cmbInformaLibroIva.Size = New System.Drawing.Size(67, 21)
        Me.cmbInformaLibroIva.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(171, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Informa Libro IVA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(10, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Periodo Fiscal"
        '
        'chkUltimoAno
        '
        Me.chkUltimoAno.AutoSize = True
        Me.chkUltimoAno.BindearPropiedadControl = Nothing
        Me.chkUltimoAno.BindearPropiedadEntidad = Nothing
        Me.chkUltimoAno.ForeColorFocus = System.Drawing.Color.Red
        Me.chkUltimoAno.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkUltimoAno.IsPK = False
        Me.chkUltimoAno.IsRequired = False
        Me.chkUltimoAno.Key = Nothing
        Me.chkUltimoAno.LabelAsoc = Nothing
        Me.chkUltimoAno.Location = New System.Drawing.Point(353, 19)
        Me.chkUltimoAno.Name = "chkUltimoAno"
        Me.chkUltimoAno.Size = New System.Drawing.Size(77, 17)
        Me.chkUltimoAno.TabIndex = 5
        Me.chkUltimoAno.Text = "Último Año"
        Me.chkUltimoAno.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "MM/yyyy"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(252, 19)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(68, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(215, 22)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 3
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "MM/yyyy"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(126, 19)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(73, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(86, 22)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'cmbEsComercial
        '
        Me.cmbEsComercial.BindearPropiedadControl = Nothing
        Me.cmbEsComercial.BindearPropiedadEntidad = Nothing
        Me.cmbEsComercial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEsComercial.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsComercial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsComercial.FormattingEnabled = True
        Me.cmbEsComercial.IsPK = False
        Me.cmbEsComercial.IsRequired = False
        Me.cmbEsComercial.Key = Nothing
        Me.cmbEsComercial.LabelAsoc = Me.lblEsComercial
        Me.cmbEsComercial.Location = New System.Drawing.Point(262, 51)
        Me.cmbEsComercial.Name = "cmbEsComercial"
        Me.cmbEsComercial.Size = New System.Drawing.Size(67, 21)
        Me.cmbEsComercial.TabIndex = 12
        '
        'lblEsComercial
        '
        Me.lblEsComercial.AutoSize = True
        Me.lblEsComercial.LabelAsoc = Nothing
        Me.lblEsComercial.Location = New System.Drawing.Point(171, 55)
        Me.lblEsComercial.Name = "lblEsComercial"
        Me.lblEsComercial.Size = New System.Drawing.Size(53, 13)
        Me.lblEsComercial.TabIndex = 11
        Me.lblEsComercial.Text = "Comercial"
        '
        'cmbAfectaCaja
        '
        Me.cmbAfectaCaja.BindearPropiedadControl = Nothing
        Me.cmbAfectaCaja.BindearPropiedadEntidad = Nothing
        Me.cmbAfectaCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfectaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAfectaCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAfectaCaja.FormattingEnabled = True
        Me.cmbAfectaCaja.IsPK = False
        Me.cmbAfectaCaja.IsRequired = False
        Me.cmbAfectaCaja.Key = Nothing
        Me.cmbAfectaCaja.LabelAsoc = Nothing
        Me.cmbAfectaCaja.Location = New System.Drawing.Point(84, 77)
        Me.cmbAfectaCaja.Name = "cmbAfectaCaja"
        Me.cmbAfectaCaja.Size = New System.Drawing.Size(67, 21)
        Me.cmbAfectaCaja.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(10, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Afecta Caja"
        '
        'cmbGrabanLibro
        '
        Me.cmbGrabanLibro.BindearPropiedadControl = Nothing
        Me.cmbGrabanLibro.BindearPropiedadEntidad = Nothing
        Me.cmbGrabanLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrabanLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrabanLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrabanLibro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrabanLibro.FormattingEnabled = True
        Me.cmbGrabanLibro.IsPK = False
        Me.cmbGrabanLibro.IsRequired = False
        Me.cmbGrabanLibro.Key = Nothing
        Me.cmbGrabanLibro.LabelAsoc = Nothing
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(84, 51)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(67, 21)
        Me.cmbGrabanLibro.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(10, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Graban Libro"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(840, 53)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 21
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(979, 29)
        Me.tstBarra.TabIndex = 3
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "Imprimir"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(110, 22)
        Me.ToolStripMenuItem1.Text = "a Excel"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(110, 22)
        Me.ToolStripMenuItem2.Text = "a PDF"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.BindearPropiedadControl = Nothing
        Me.txtTotal.BindearPropiedadEntidad = Nothing
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotal.Formato = "##,##0.00"
        Me.txtTotal.IsDecimal = True
        Me.txtTotal.IsNumber = True
        Me.txtTotal.IsPK = False
        Me.txtTotal.IsRequired = False
        Me.txtTotal.Key = ""
        Me.txtTotal.LabelAsoc = Nothing
        Me.txtTotal.Location = New System.Drawing.Point(840, 19)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(90, 21)
        Me.txtTotal.TabIndex = 9
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA105
        '
        Me.txtIVA105.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIVA105.BindearPropiedadControl = Nothing
        Me.txtIVA105.BindearPropiedadEntidad = Nothing
        Me.txtIVA105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA105.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA105.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIVA105.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIVA105.Formato = "##,##0.00"
        Me.txtIVA105.IsDecimal = True
        Me.txtIVA105.IsNumber = True
        Me.txtIVA105.IsPK = False
        Me.txtIVA105.IsRequired = False
        Me.txtIVA105.Key = ""
        Me.txtIVA105.LabelAsoc = Nothing
        Me.txtIVA105.Location = New System.Drawing.Point(400, 19)
        Me.txtIVA105.Name = "txtIVA105"
        Me.txtIVA105.ReadOnly = True
        Me.txtIVA105.Size = New System.Drawing.Size(80, 21)
        Me.txtIVA105.TabIndex = 3
        Me.txtIVA105.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA210
        '
        Me.txtIVA210.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIVA210.BindearPropiedadControl = Nothing
        Me.txtIVA210.BindearPropiedadEntidad = Nothing
        Me.txtIVA210.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA210.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA210.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIVA210.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIVA210.Formato = "##,##0.00"
        Me.txtIVA210.IsDecimal = True
        Me.txtIVA210.IsNumber = True
        Me.txtIVA210.IsPK = False
        Me.txtIVA210.IsRequired = False
        Me.txtIVA210.Key = ""
        Me.txtIVA210.LabelAsoc = Nothing
        Me.txtIVA210.Location = New System.Drawing.Point(320, 19)
        Me.txtIVA210.Name = "txtIVA210"
        Me.txtIVA210.ReadOnly = True
        Me.txtIVA210.Size = New System.Drawing.Size(80, 21)
        Me.txtIVA210.TabIndex = 2
        Me.txtIVA210.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.BindearPropiedadControl = Nothing
        Me.txtNeto.BindearPropiedadEntidad = Nothing
        Me.txtNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNeto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNeto.Formato = "##,##0.00"
        Me.txtNeto.IsDecimal = True
        Me.txtNeto.IsNumber = True
        Me.txtNeto.IsPK = False
        Me.txtNeto.IsRequired = False
        Me.txtNeto.Key = ""
        Me.txtNeto.LabelAsoc = Nothing
        Me.txtNeto.Location = New System.Drawing.Point(240, 19)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(80, 21)
        Me.txtNeto.TabIndex = 1
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPercepcionVarias)
        Me.GroupBox1.Controls.Add(Me.txtPercepcionGanancias)
        Me.GroupBox1.Controls.Add(Me.txtPercepcionIB)
        Me.GroupBox1.Controls.Add(Me.txtPercepcionIVA)
        Me.GroupBox1.Controls.Add(Me.txtIva270)
        Me.GroupBox1.Controls.Add(Me.txtNetoNoGravado)
        Me.GroupBox1.Controls.Add(Me.txtNeto)
        Me.GroupBox1.Controls.Add(Me.txtIVA210)
        Me.GroupBox1.Controls.Add(Me.txtIVA105)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 505)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(942, 49)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totales"
        '
        'txtPercepcionVarias
        '
        Me.txtPercepcionVarias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPercepcionVarias.BindearPropiedadControl = Nothing
        Me.txtPercepcionVarias.BindearPropiedadEntidad = Nothing
        Me.txtPercepcionVarias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPercepcionVarias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercepcionVarias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPercepcionVarias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPercepcionVarias.Formato = "##,##0.00"
        Me.txtPercepcionVarias.IsDecimal = True
        Me.txtPercepcionVarias.IsNumber = True
        Me.txtPercepcionVarias.IsPK = False
        Me.txtPercepcionVarias.IsRequired = False
        Me.txtPercepcionVarias.Key = ""
        Me.txtPercepcionVarias.LabelAsoc = Nothing
        Me.txtPercepcionVarias.Location = New System.Drawing.Point(770, 19)
        Me.txtPercepcionVarias.Name = "txtPercepcionVarias"
        Me.txtPercepcionVarias.ReadOnly = True
        Me.txtPercepcionVarias.Size = New System.Drawing.Size(70, 21)
        Me.txtPercepcionVarias.TabIndex = 8
        Me.txtPercepcionVarias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPercepcionGanancias
        '
        Me.txtPercepcionGanancias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPercepcionGanancias.BindearPropiedadControl = Nothing
        Me.txtPercepcionGanancias.BindearPropiedadEntidad = Nothing
        Me.txtPercepcionGanancias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPercepcionGanancias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercepcionGanancias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPercepcionGanancias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPercepcionGanancias.Formato = "##,##0.00"
        Me.txtPercepcionGanancias.IsDecimal = True
        Me.txtPercepcionGanancias.IsNumber = True
        Me.txtPercepcionGanancias.IsPK = False
        Me.txtPercepcionGanancias.IsRequired = False
        Me.txtPercepcionGanancias.Key = ""
        Me.txtPercepcionGanancias.LabelAsoc = Nothing
        Me.txtPercepcionGanancias.Location = New System.Drawing.Point(700, 19)
        Me.txtPercepcionGanancias.Name = "txtPercepcionGanancias"
        Me.txtPercepcionGanancias.ReadOnly = True
        Me.txtPercepcionGanancias.Size = New System.Drawing.Size(70, 21)
        Me.txtPercepcionGanancias.TabIndex = 7
        Me.txtPercepcionGanancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPercepcionIB
        '
        Me.txtPercepcionIB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPercepcionIB.BindearPropiedadControl = Nothing
        Me.txtPercepcionIB.BindearPropiedadEntidad = Nothing
        Me.txtPercepcionIB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPercepcionIB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercepcionIB.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPercepcionIB.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPercepcionIB.Formato = "##,##0.00"
        Me.txtPercepcionIB.IsDecimal = True
        Me.txtPercepcionIB.IsNumber = True
        Me.txtPercepcionIB.IsPK = False
        Me.txtPercepcionIB.IsRequired = False
        Me.txtPercepcionIB.Key = ""
        Me.txtPercepcionIB.LabelAsoc = Nothing
        Me.txtPercepcionIB.Location = New System.Drawing.Point(630, 19)
        Me.txtPercepcionIB.Name = "txtPercepcionIB"
        Me.txtPercepcionIB.ReadOnly = True
        Me.txtPercepcionIB.Size = New System.Drawing.Size(70, 21)
        Me.txtPercepcionIB.TabIndex = 6
        Me.txtPercepcionIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPercepcionIVA
        '
        Me.txtPercepcionIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPercepcionIVA.BindearPropiedadControl = Nothing
        Me.txtPercepcionIVA.BindearPropiedadEntidad = Nothing
        Me.txtPercepcionIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPercepcionIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercepcionIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPercepcionIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPercepcionIVA.Formato = "##,##0.00"
        Me.txtPercepcionIVA.IsDecimal = True
        Me.txtPercepcionIVA.IsNumber = True
        Me.txtPercepcionIVA.IsPK = False
        Me.txtPercepcionIVA.IsRequired = False
        Me.txtPercepcionIVA.Key = ""
        Me.txtPercepcionIVA.LabelAsoc = Nothing
        Me.txtPercepcionIVA.Location = New System.Drawing.Point(560, 19)
        Me.txtPercepcionIVA.Name = "txtPercepcionIVA"
        Me.txtPercepcionIVA.ReadOnly = True
        Me.txtPercepcionIVA.Size = New System.Drawing.Size(70, 21)
        Me.txtPercepcionIVA.TabIndex = 5
        Me.txtPercepcionIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIva270
        '
        Me.txtIva270.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIva270.BindearPropiedadControl = Nothing
        Me.txtIva270.BindearPropiedadEntidad = Nothing
        Me.txtIva270.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIva270.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva270.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIva270.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIva270.Formato = "##,##0.00"
        Me.txtIva270.IsDecimal = True
        Me.txtIva270.IsNumber = True
        Me.txtIva270.IsPK = False
        Me.txtIva270.IsRequired = False
        Me.txtIva270.Key = ""
        Me.txtIva270.LabelAsoc = Nothing
        Me.txtIva270.Location = New System.Drawing.Point(480, 19)
        Me.txtIva270.Name = "txtIva270"
        Me.txtIva270.ReadOnly = True
        Me.txtIva270.Size = New System.Drawing.Size(80, 21)
        Me.txtIva270.TabIndex = 4
        Me.txtIva270.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNetoNoGravado
        '
        Me.txtNetoNoGravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNetoNoGravado.BindearPropiedadControl = Nothing
        Me.txtNetoNoGravado.BindearPropiedadEntidad = Nothing
        Me.txtNetoNoGravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNetoNoGravado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetoNoGravado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNetoNoGravado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNetoNoGravado.Formato = "##,##0.00"
        Me.txtNetoNoGravado.IsDecimal = True
        Me.txtNetoNoGravado.IsNumber = True
        Me.txtNetoNoGravado.IsPK = False
        Me.txtNetoNoGravado.IsRequired = False
        Me.txtNetoNoGravado.Key = ""
        Me.txtNetoNoGravado.LabelAsoc = Nothing
        Me.txtNetoNoGravado.Location = New System.Drawing.Point(160, 19)
        Me.txtNetoNoGravado.Name = "txtNetoNoGravado"
        Me.txtNetoNoGravado.ReadOnly = True
        Me.txtNetoNoGravado.Size = New System.Drawing.Size(80, 21)
        Me.txtNetoNoGravado.TabIndex = 0
        Me.txtNetoNoGravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ugPorComprobante
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugPorComprobante.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.Caption = "Comprobante"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 120
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance2
        UltraGridColumn3.Header.Caption = "L."
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 30
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance3
        UltraGridColumn4.Format = "N2"
        UltraGridColumn4.Header.Caption = "Neto No Grav."
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Width = 120
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance4
        UltraGridColumn5.Format = "N2"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 120
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance5
        UltraGridColumn6.Format = "N2"
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Width = 120
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance6
        UltraGridColumn26.Format = "N2"
        UltraGridColumn26.Header.Caption = "Derecho Aduanero"
        UltraGridColumn26.Header.VisiblePosition = 8
        UltraGridColumn13.Header.Caption = "Categoría Fiscal"
        UltraGridColumn13.Header.VisiblePosition = 3
        UltraGridColumn13.Width = 151
        UltraGridColumn19.Header.Caption = "Rubro Compra"
        UltraGridColumn19.Header.VisiblePosition = 4
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn26, UltraGridColumn13, UltraGridColumn19})
        Me.ugPorComprobante.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugPorComprobante.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPorComprobante.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPorComprobante.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPorComprobante.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.ugPorComprobante.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance9.BackColor2 = System.Drawing.SystemColors.Control
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPorComprobante.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
        Me.ugPorComprobante.DisplayLayout.MaxColScrollRegions = 1
        Me.ugPorComprobante.DisplayLayout.MaxRowScrollRegions = 1
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugPorComprobante.DisplayLayout.Override.ActiveCellAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.SystemColors.Highlight
        Appearance11.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugPorComprobante.DisplayLayout.Override.ActiveRowAppearance = Appearance11
        Me.ugPorComprobante.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPorComprobante.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugPorComprobante.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.ugPorComprobante.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugPorComprobante.DisplayLayout.Override.CellAppearance = Appearance13
        Me.ugPorComprobante.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugPorComprobante.DisplayLayout.Override.CellPadding = 0
        Appearance14.BackColor = System.Drawing.SystemColors.Control
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPorComprobante.DisplayLayout.Override.GroupByRowAppearance = Appearance14
        Appearance15.TextHAlignAsString = "Left"
        Me.ugPorComprobante.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.ugPorComprobante.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugPorComprobante.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Me.ugPorComprobante.DisplayLayout.Override.RowAppearance = Appearance16
        Me.ugPorComprobante.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugPorComprobante.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
        Me.ugPorComprobante.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugPorComprobante.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugPorComprobante.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugPorComprobante.Location = New System.Drawing.Point(12, 144)
        Me.ugPorComprobante.Name = "ugPorComprobante"
        Me.ugPorComprobante.Size = New System.Drawing.Size(955, 300)
        Me.ugPorComprobante.TabIndex = 1
        Me.ugPorComprobante.Text = "UltraGrid1"
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
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance18
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
        'ResumenDetallePorComprobanteCompras
        '
        Me.AcceptButton = Me.btnConsultar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 473)
        Me.Controls.Add(Me.ugPorComprobante)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbConsultar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ResumenDetallePorComprobanteCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resumen Detalle por Comprobantes de Compras"
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ugPorComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents txtIVA105 As Eniac.Controles.TextBox
   Friend WithEvents txtIVA210 As Eniac.Controles.TextBox
   Friend WithEvents txtNeto As Eniac.Controles.TextBox
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents txtNetoNoGravado As Eniac.Controles.TextBox
   Friend WithEvents txtIva270 As Eniac.Controles.TextBox
    Friend WithEvents txtPercepcionIVA As Eniac.Controles.TextBox
    Friend WithEvents txtPercepcionVarias As Eniac.Controles.TextBox
    Friend WithEvents txtPercepcionGanancias As Eniac.Controles.TextBox
    Friend WithEvents txtPercepcionIB As Eniac.Controles.TextBox
    Friend WithEvents cmbAfectaCaja As Eniac.Controles.ComboBox
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents cmbEsComercial As Eniac.Controles.ComboBox
    Friend WithEvents lblEsComercial As Eniac.Controles.Label
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ugPorComprobante As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkUltimoAno As Eniac.Controles.CheckBox
    Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblHasta As Eniac.Controles.Label
    Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblDesde As Eniac.Controles.Label
    Friend WithEvents Label2 As Eniac.Controles.Label
    Friend WithEvents cmbInformaLibroIva As Eniac.Controles.ComboBox
    Friend WithEvents Label3 As Eniac.Controles.Label
    Friend WithEvents chbSepararNetos As Controles.CheckBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Public WithEvents tsbPreferencias As ToolStripButton
    Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
    Friend WithEvents lblTiposComprobantes As Controles.Label
    Friend WithEvents cmbRubroCompra As ComboBoxRubroCompras
    Friend WithEvents Label5 As Controles.Label
    Friend WithEvents cmbCategoriasFiscales As ComboBoxCategoriasFiscales
    Friend WithEvents Label6 As Controles.Label
End Class
