<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvioNovedadesDeVersiones
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvioNovedadesDeVersiones))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CorreoElectronico")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoria")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdZonaGeografica")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Envio")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCobrador")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroVersion")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacionVersion")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadocliente")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idAplicacion")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Edicion")
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "ImporteTotal", 16, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaNovedad")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaNovedad")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoNovedad")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaNovedad")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFuncion")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFuncion")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Version", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VersionFecha")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPadre")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFuncionPadre")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Reporta")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Novedad", 0)
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ZonaGeografica", 1)
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaNovedad")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFuncion")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFuncion")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Version")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPadre")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFuncionPadre")
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEnviarCorreos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCorreoPrueba = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbCategoriasClientes = New Eniac.Win.ComboBoxCategorias()
        Me.cmbVersionHasta = New Eniac.Controles.ComboBox()
        Me.cmbVersionDesde = New Eniac.Controles.ComboBox()
        Me.cmbAplicacion = New Eniac.Controles.ComboBox()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.lblVersionDesde = New Eniac.Controles.Label()
        Me.lblVersionHasta = New Eniac.Controles.Label()
        Me.lblVersion = New Eniac.Controles.Label()
        Me.chbCobrador = New Eniac.Controles.CheckBox()
        Me.cmbCobrador = New Eniac.Controles.ComboBox()
        Me.lblComenzarPorNombreCliente = New Eniac.Controles.Label()
        Me.txtComenzarPorNombreCliente = New Eniac.Controles.TextBox()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        Me.chbCategoriaCliente = New Eniac.Controles.Label()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.bscNombreCliente = New Eniac.Controles.Buscador()
        Me.lblNombreCliente = New Eniac.Controles.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.ugClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.sspPie = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.rtbCuerpoMail = New MSDN.Html.Editor.HtmlEditorControl()
        Me.lblCuerpo = New Eniac.Controles.Label()
        Me.lblAsunto = New Eniac.Controles.Label()
        Me.grpDatosEnvio = New System.Windows.Forms.GroupBox()
        Me.btnExaminar4 = New Eniac.Controles.Button()
        Me.txtArchivo4 = New Eniac.Controles.TextBox()
        Me.lblArchivo4 = New Eniac.Controles.Label()
        Me.btnExaminar3 = New Eniac.Controles.Button()
        Me.txtArchivo3 = New Eniac.Controles.TextBox()
        Me.lblArchivo3 = New Eniac.Controles.Label()
        Me.btnExaminar2 = New Eniac.Controles.Button()
        Me.txtArchivo2 = New Eniac.Controles.TextBox()
        Me.lblArchivo2 = New Eniac.Controles.Label()
        Me.btnExpandirHtml = New Eniac.Controles.Button()
        Me.btnExaminar1 = New Eniac.Controles.Button()
        Me.txtArchivo1 = New Eniac.Controles.TextBox()
        Me.lblArchivo1 = New Eniac.Controles.Label()
        Me.txtAsuntoMail = New System.Windows.Forms.TextBox()
        Me.txtCopiaOculta = New Eniac.Controles.TextBox()
        Me.chbCopiaOculta = New Eniac.Controles.CheckBox()
        Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.chbEnvioCtaCteCliente = New Eniac.Controles.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbcEnvioMail = New System.Windows.Forms.TabControl()
        Me.tbpClientes = New System.Windows.Forms.TabPage()
        Me.tbpNovedades = New System.Windows.Forms.TabPage()
        Me.ugNovedades = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpNovedadesDelCliente = New System.Windows.Forms.TabPage()
        Me.ugClientesNovedades = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sspPie.SuspendLayout()
        Me.grpDatosEnvio.SuspendLayout()
        Me.tbcEnvioMail.SuspendLayout()
        Me.tbpClientes.SuspendLayout()
        Me.tbpNovedades.SuspendLayout()
        CType(Me.ugNovedades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpNovedadesDelCliente.SuspendLayout()
        CType(Me.ugClientesNovedades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbEnviarCorreos, Me.ToolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbCorreoPrueba, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 6
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
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
        'tsbEnviarCorreos
        '
        Me.tsbEnviarCorreos.Enabled = False
        Me.tsbEnviarCorreos.Image = Global.Eniac.Win.My.Resources.Resources.mail_next_32
        Me.tsbEnviarCorreos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviarCorreos.Name = "tsbEnviarCorreos"
        Me.tsbEnviarCorreos.Size = New System.Drawing.Size(65, 26)
        Me.tsbEnviarCorreos.Text = "Enviar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCorreoPrueba
        '
        Me.tsbCorreoPrueba.Image = Global.Eniac.Win.My.Resources.Resources.mail_server
        Me.tsbCorreoPrueba.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCorreoPrueba.Name = "tsbCorreoPrueba"
        Me.tsbCorreoPrueba.Size = New System.Drawing.Size(125, 26)
        Me.tsbCorreoPrueba.Text = "C&orreo de Prueba"
        Me.tsbCorreoPrueba.ToolTipText = "Cerrar el formulario"
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
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.cmbCategoriasClientes)
        Me.grbFiltros.Controls.Add(Me.cmbVersionHasta)
        Me.grbFiltros.Controls.Add(Me.cmbVersionDesde)
        Me.grbFiltros.Controls.Add(Me.cmbAplicacion)
        Me.grbFiltros.Controls.Add(Me.lblCodigo)
        Me.grbFiltros.Controls.Add(Me.lblVersionDesde)
        Me.grbFiltros.Controls.Add(Me.lblVersionHasta)
        Me.grbFiltros.Controls.Add(Me.lblVersion)
        Me.grbFiltros.Controls.Add(Me.chbCobrador)
        Me.grbFiltros.Controls.Add(Me.cmbCobrador)
        Me.grbFiltros.Controls.Add(Me.lblComenzarPorNombreCliente)
        Me.grbFiltros.Controls.Add(Me.txtComenzarPorNombreCliente)
        Me.grbFiltros.Controls.Add(Me.chbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.chbCategoriaCliente)
        Me.grbFiltros.Controls.Add(Me.cmbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.bscNombreCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombreCliente)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(13, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(959, 114)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        '
        'cmbCategoriasClientes
        '
        Me.cmbCategoriasClientes.BindearPropiedadControl = Nothing
        Me.cmbCategoriasClientes.BindearPropiedadEntidad = Nothing
        Me.cmbCategoriasClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriasClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriasClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriasClientes.FormattingEnabled = True
        Me.cmbCategoriasClientes.IsPK = False
        Me.cmbCategoriasClientes.IsRequired = False
        Me.cmbCategoriasClientes.Key = Nothing
        Me.cmbCategoriasClientes.LabelAsoc = Nothing
        Me.cmbCategoriasClientes.Location = New System.Drawing.Point(706, 13)
        Me.cmbCategoriasClientes.Name = "cmbCategoriasClientes"
        Me.cmbCategoriasClientes.Size = New System.Drawing.Size(140, 21)
        Me.cmbCategoriasClientes.TabIndex = 13
        '
        'cmbVersionHasta
        '
        Me.cmbVersionHasta.BindearPropiedadControl = "SelectedValue"
        Me.cmbVersionHasta.BindearPropiedadEntidad = "IdAplicacion"
        Me.cmbVersionHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersionHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVersionHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVersionHasta.FormattingEnabled = True
        Me.cmbVersionHasta.IsPK = True
        Me.cmbVersionHasta.IsRequired = True
        Me.cmbVersionHasta.Key = Nothing
        Me.cmbVersionHasta.LabelAsoc = Nothing
        Me.cmbVersionHasta.Location = New System.Drawing.Point(440, 25)
        Me.cmbVersionHasta.Name = "cmbVersionHasta"
        Me.cmbVersionHasta.Size = New System.Drawing.Size(114, 21)
        Me.cmbVersionHasta.TabIndex = 6
        '
        'cmbVersionDesde
        '
        Me.cmbVersionDesde.BindearPropiedadControl = "SelectedValue"
        Me.cmbVersionDesde.BindearPropiedadEntidad = "IdAplicacion"
        Me.cmbVersionDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersionDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVersionDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVersionDesde.FormattingEnabled = True
        Me.cmbVersionDesde.IsPK = True
        Me.cmbVersionDesde.IsRequired = True
        Me.cmbVersionDesde.Key = Nothing
        Me.cmbVersionDesde.LabelAsoc = Nothing
        Me.cmbVersionDesde.Location = New System.Drawing.Point(276, 26)
        Me.cmbVersionDesde.Name = "cmbVersionDesde"
        Me.cmbVersionDesde.Size = New System.Drawing.Size(114, 21)
        Me.cmbVersionDesde.TabIndex = 4
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbAplicacion.BindearPropiedadEntidad = "IdAplicacion"
        Me.cmbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAplicacion.FormattingEnabled = True
        Me.cmbAplicacion.IsPK = True
        Me.cmbAplicacion.IsRequired = True
        Me.cmbAplicacion.Key = Nothing
        Me.cmbAplicacion.LabelAsoc = Nothing
        Me.cmbAplicacion.Location = New System.Drawing.Point(68, 25)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.Size = New System.Drawing.Size(114, 21)
        Me.cmbAplicacion.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(11, 29)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(56, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Aplicación"
        '
        'lblVersionDesde
        '
        Me.lblVersionDesde.AutoSize = True
        Me.lblVersionDesde.LabelAsoc = Nothing
        Me.lblVersionDesde.Location = New System.Drawing.Point(232, 30)
        Me.lblVersionDesde.Name = "lblVersionDesde"
        Me.lblVersionDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblVersionDesde.TabIndex = 3
        Me.lblVersionDesde.Text = "Desde"
        '
        'lblVersionHasta
        '
        Me.lblVersionHasta.AutoSize = True
        Me.lblVersionHasta.LabelAsoc = Nothing
        Me.lblVersionHasta.Location = New System.Drawing.Point(399, 30)
        Me.lblVersionHasta.Name = "lblVersionHasta"
        Me.lblVersionHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblVersionHasta.TabIndex = 5
        Me.lblVersionHasta.Text = "Hasta"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.LabelAsoc = Nothing
        Me.lblVersion.Location = New System.Drawing.Point(188, 30)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "Versión"
        '
        'chbCobrador
        '
        Me.chbCobrador.AutoSize = True
        Me.chbCobrador.BindearPropiedadControl = Nothing
        Me.chbCobrador.BindearPropiedadEntidad = Nothing
        Me.chbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCobrador.IsPK = False
        Me.chbCobrador.IsRequired = False
        Me.chbCobrador.Key = Nothing
        Me.chbCobrador.LabelAsoc = Nothing
        Me.chbCobrador.Location = New System.Drawing.Point(594, 40)
        Me.chbCobrador.Name = "chbCobrador"
        Me.chbCobrador.Size = New System.Drawing.Size(69, 17)
        Me.chbCobrador.TabIndex = 14
        Me.chbCobrador.Text = "Cobrador"
        Me.chbCobrador.UseVisualStyleBackColor = True
        '
        'cmbCobrador
        '
        Me.cmbCobrador.BindearPropiedadControl = Nothing
        Me.cmbCobrador.BindearPropiedadEntidad = Nothing
        Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCobrador.Enabled = False
        Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCobrador.FormattingEnabled = True
        Me.cmbCobrador.IsPK = False
        Me.cmbCobrador.IsRequired = False
        Me.cmbCobrador.Key = Nothing
        Me.cmbCobrador.LabelAsoc = Nothing
        Me.cmbCobrador.Location = New System.Drawing.Point(706, 38)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.Size = New System.Drawing.Size(140, 21)
        Me.cmbCobrador.TabIndex = 15
        '
        'lblComenzarPorNombreCliente
        '
        Me.lblComenzarPorNombreCliente.AutoSize = True
        Me.lblComenzarPorNombreCliente.LabelAsoc = Nothing
        Me.lblComenzarPorNombreCliente.Location = New System.Drawing.Point(552, 93)
        Me.lblComenzarPorNombreCliente.Name = "lblComenzarPorNombreCliente"
        Me.lblComenzarPorNombreCliente.Size = New System.Drawing.Size(148, 13)
        Me.lblComenzarPorNombreCliente.TabIndex = 18
        Me.lblComenzarPorNombreCliente.Text = "Comenzar Por Nombre Cliente"
        '
        'txtComenzarPorNombreCliente
        '
        Me.txtComenzarPorNombreCliente.BindearPropiedadControl = ""
        Me.txtComenzarPorNombreCliente.BindearPropiedadEntidad = ""
        Me.txtComenzarPorNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComenzarPorNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComenzarPorNombreCliente.Formato = "N2"
        Me.txtComenzarPorNombreCliente.IsDecimal = False
        Me.txtComenzarPorNombreCliente.IsNumber = False
        Me.txtComenzarPorNombreCliente.IsPK = False
        Me.txtComenzarPorNombreCliente.IsRequired = False
        Me.txtComenzarPorNombreCliente.Key = ""
        Me.txtComenzarPorNombreCliente.LabelAsoc = Me.lblComenzarPorNombreCliente
        Me.txtComenzarPorNombreCliente.Location = New System.Drawing.Point(706, 88)
        Me.txtComenzarPorNombreCliente.MaxLength = 60
        Me.txtComenzarPorNombreCliente.Name = "txtComenzarPorNombreCliente"
        Me.txtComenzarPorNombreCliente.Size = New System.Drawing.Size(140, 20)
        Me.txtComenzarPorNombreCliente.TabIndex = 19
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
        Me.chbZonaGeografica.Location = New System.Drawing.Point(594, 65)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(109, 17)
        Me.chbZonaGeografica.TabIndex = 16
        Me.chbZonaGeografica.Text = "Zona Greográfica"
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
        '
        'chbCategoriaCliente
        '
        Me.chbCategoriaCliente.AutoSize = True
        Me.chbCategoriaCliente.LabelAsoc = Nothing
        Me.chbCategoriaCliente.Location = New System.Drawing.Point(610, 15)
        Me.chbCategoriaCliente.Name = "chbCategoriaCliente"
        Me.chbCategoriaCliente.Size = New System.Drawing.Size(52, 13)
        Me.chbCategoriaCliente.TabIndex = 12
        Me.chbCategoriaCliente.Text = "Categoria"
        '
        'cmbZonaGeografica
        '
        Me.cmbZonaGeografica.BindearPropiedadControl = ""
        Me.cmbZonaGeografica.BindearPropiedadEntidad = ""
        Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonaGeografica.Enabled = False
        Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbZonaGeografica.FormattingEnabled = True
        Me.cmbZonaGeografica.IsPK = False
        Me.cmbZonaGeografica.IsRequired = True
        Me.cmbZonaGeografica.Key = Nothing
        Me.cmbZonaGeografica.LabelAsoc = Nothing
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(706, 63)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(140, 21)
        Me.cmbZonaGeografica.TabIndex = 17
        '
        'bscNombreCliente
        '
        Me.bscNombreCliente.AyudaAncho = 608
        Me.bscNombreCliente.BindearPropiedadControl = Nothing
        Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
        Me.bscNombreCliente.ColumnasAlineacion = Nothing
        Me.bscNombreCliente.ColumnasAncho = Nothing
        Me.bscNombreCliente.ColumnasFormato = Nothing
        Me.bscNombreCliente.ColumnasOcultas = Nothing
        Me.bscNombreCliente.ColumnasTitulos = Nothing
        Me.bscNombreCliente.Datos = Nothing
        Me.bscNombreCliente.Enabled = False
        Me.bscNombreCliente.FilaDevuelta = Nothing
        Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Me.lblNombreCliente
        Me.bscNombreCliente.Location = New System.Drawing.Point(177, 75)
        Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = True
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(257, 23)
        Me.bscNombreCliente.TabIndex = 11
        Me.bscNombreCliente.Titulo = Nothing
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.LabelAsoc = Nothing
        Me.lblNombreCliente.Location = New System.Drawing.Point(174, 63)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreCliente.TabIndex = 10
        Me.lblNombreCliente.Text = "Nombre"
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
        Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(70, 75)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(100, 23)
        Me.bscCodigoCliente.TabIndex = 9
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(67, 63)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 8
        Me.lblCodigoCliente.Text = "Codigo"
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
        Me.chbCliente.Location = New System.Drawing.Point(8, 78)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 7
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(854, 62)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 45)
        Me.btnConsultar.TabIndex = 20
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'ugClientes
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.ugClientes.DisplayLayout.Appearance = Appearance1
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance2
        UltraGridColumn7.Header.VisiblePosition = 1
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance3
        UltraGridColumn8.Format = ""
        UltraGridColumn8.Header.Caption = "Código"
        UltraGridColumn8.Header.VisiblePosition = 2
        UltraGridColumn8.Width = 60
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn9.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn9.Header.Caption = "Nombre Cliente"
        UltraGridColumn9.Header.VisiblePosition = 3
        UltraGridColumn9.Width = 182
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn16.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn16.Header.Caption = "Correo(s) Electronico(s)"
        UltraGridColumn16.Header.VisiblePosition = 4
        UltraGridColumn16.Width = 150
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance4
        UltraGridColumn17.Header.VisiblePosition = 7
        UltraGridColumn17.Hidden = True
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn22.Header.Caption = "Categoria"
        UltraGridColumn22.Header.VisiblePosition = 5
        UltraGridColumn22.Width = 83
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance5
        UltraGridColumn26.Header.VisiblePosition = 8
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn27.Header.VisiblePosition = 9
        UltraGridColumn27.Hidden = True
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance6
        UltraGridColumn28.Header.VisiblePosition = 10
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn29.Header.Caption = "Zona"
        UltraGridColumn29.Header.VisiblePosition = 6
        UltraGridColumn29.Width = 77
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn30.CellAppearance = Appearance7
        UltraGridColumn30.Header.VisiblePosition = 12
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 76
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance8
        UltraGridColumn31.Header.VisiblePosition = 11
        UltraGridColumn31.Hidden = True
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn32.Header.Caption = "Comprobante"
        UltraGridColumn32.Header.VisiblePosition = 13
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 80
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn33.CellAppearance = Appearance9
        UltraGridColumn33.Header.Caption = "L."
        UltraGridColumn33.Header.VisiblePosition = 14
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 30
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance10
        UltraGridColumn34.Header.Caption = "C.E."
        UltraGridColumn34.Header.VisiblePosition = 15
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 40
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance11
        UltraGridColumn35.Header.Caption = "Numero"
        UltraGridColumn35.Header.VisiblePosition = 16
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.Width = 60
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance12
        UltraGridColumn36.Format = "N2"
        UltraGridColumn36.Header.Caption = "Total"
        UltraGridColumn36.Header.VisiblePosition = 17
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.MaskInput = "{double:-9.2}"
        UltraGridColumn36.Width = 70
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn37.Header.VisiblePosition = 18
        UltraGridColumn37.Hidden = True
        UltraGridColumn37.Width = 320
        Appearance13.TextHAlignAsString = "Center"
        UltraGridColumn38.CellAppearance = Appearance13
        UltraGridColumn38.Header.Caption = "Envío"
        UltraGridColumn38.Header.VisiblePosition = 0
        UltraGridColumn38.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn38.Width = 33
        UltraGridColumn1.Header.Caption = "Vendedor"
        UltraGridColumn1.Header.VisiblePosition = 19
        UltraGridColumn2.Header.Caption = "Cobrador"
        UltraGridColumn2.Header.VisiblePosition = 20
        UltraGridColumn5.Header.Caption = "Nro Versión"
        UltraGridColumn5.Header.VisiblePosition = 24
        UltraGridColumn6.Header.Caption = "Fecha Act. Versión"
        UltraGridColumn6.Header.VisiblePosition = 25
        UltraGridColumn10.Header.Caption = "Estado Cliente"
        UltraGridColumn10.Header.VisiblePosition = 21
        UltraGridColumn11.Header.Caption = "Aplicación"
        UltraGridColumn11.Header.VisiblePosition = 22
        UltraGridColumn20.Header.Caption = "Edición"
        UltraGridColumn20.Header.VisiblePosition = 23
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn16, UltraGridColumn17, UltraGridColumn22, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn1, UltraGridColumn2, UltraGridColumn5, UltraGridColumn6, UltraGridColumn10, UltraGridColumn11, UltraGridColumn20})
        UltraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Appearance14.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance14
        SummarySettings1.DisplayFormat = "{0:N2}"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance15
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1})
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        Me.ugClientes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugClientes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
        Me.ugClientes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientes.DisplayLayout.GroupByBox.Hidden = True
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance18.BackColor2 = System.Drawing.SystemColors.Control
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
        Me.ugClientes.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugClientes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugClientes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugClientes.DisplayLayout.Override.ActiveCellAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.SystemColors.Highlight
        Appearance20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugClientes.DisplayLayout.Override.ActiveRowAppearance = Appearance20
        Me.ugClientes.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugClientes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugClientes.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugClientes.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugClientes.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugClientes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugClientes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugClientes.DisplayLayout.Override.CellAppearance = Appearance22
        Me.ugClientes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugClientes.DisplayLayout.Override.CellPadding = 0
        Me.ugClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugClientes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance23.BackColor = System.Drawing.Color.Tomato
        Appearance23.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Me.ugClientes.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance24.TextHAlignAsString = "Left"
        Me.ugClientes.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.ugClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugClientes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.ugClientes.DisplayLayout.Override.RowAppearance = Appearance25
        Me.ugClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugClientes.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugClientes.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugClientes.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugClientes.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugClientes.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance26.BackColor = System.Drawing.Color.LimeGreen
        Appearance26.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugClientes.DisplayLayout.Override.SummaryValueAppearance = Appearance26
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugClientes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance27
        Me.ugClientes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugClientes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugClientes.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugClientes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugClientes.Location = New System.Drawing.Point(3, 3)
        Me.ugClientes.Name = "ugClientes"
        Me.ugClientes.Size = New System.Drawing.Size(943, 184)
        Me.ugClientes.TabIndex = 6
        Me.ugClientes.Text = "UltraGrid1"
        '
        'sspPie
        '
        Me.sspPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.sspPie.Location = New System.Drawing.Point(0, 540)
        Me.sspPie.Name = "sspPie"
        Me.sspPie.Size = New System.Drawing.Size(984, 22)
        Me.sspPie.TabIndex = 7
        Me.sspPie.Text = "StatusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(803, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Step = 1
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'rtbCuerpoMail
        '
        Me.rtbCuerpoMail.InnerText = Nothing
        Me.rtbCuerpoMail.Location = New System.Drawing.Point(63, 45)
        Me.rtbCuerpoMail.Name = "rtbCuerpoMail"
        Me.rtbCuerpoMail.Size = New System.Drawing.Size(407, 81)
        Me.rtbCuerpoMail.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.rtbCuerpoMail, "{0} - va a ser reemplazado por la columna """"Cliente""""")
        '
        'lblCuerpo
        '
        Me.lblCuerpo.AutoSize = True
        Me.lblCuerpo.LabelAsoc = Nothing
        Me.lblCuerpo.Location = New System.Drawing.Point(12, 46)
        Me.lblCuerpo.Name = "lblCuerpo"
        Me.lblCuerpo.Size = New System.Drawing.Size(41, 13)
        Me.lblCuerpo.TabIndex = 2
        Me.lblCuerpo.Text = "Cuerpo"
        '
        'lblAsunto
        '
        Me.lblAsunto.AutoSize = True
        Me.lblAsunto.LabelAsoc = Nothing
        Me.lblAsunto.Location = New System.Drawing.Point(12, 23)
        Me.lblAsunto.Name = "lblAsunto"
        Me.lblAsunto.Size = New System.Drawing.Size(40, 13)
        Me.lblAsunto.TabIndex = 0
        Me.lblAsunto.Text = "Asunto"
        '
        'grpDatosEnvio
        '
        Me.grpDatosEnvio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDatosEnvio.Controls.Add(Me.btnExaminar4)
        Me.grpDatosEnvio.Controls.Add(Me.txtArchivo4)
        Me.grpDatosEnvio.Controls.Add(Me.lblArchivo4)
        Me.grpDatosEnvio.Controls.Add(Me.btnExaminar3)
        Me.grpDatosEnvio.Controls.Add(Me.txtArchivo3)
        Me.grpDatosEnvio.Controls.Add(Me.lblArchivo3)
        Me.grpDatosEnvio.Controls.Add(Me.btnExaminar2)
        Me.grpDatosEnvio.Controls.Add(Me.txtArchivo2)
        Me.grpDatosEnvio.Controls.Add(Me.lblArchivo2)
        Me.grpDatosEnvio.Controls.Add(Me.btnExpandirHtml)
        Me.grpDatosEnvio.Controls.Add(Me.btnExaminar1)
        Me.grpDatosEnvio.Controls.Add(Me.txtArchivo1)
        Me.grpDatosEnvio.Controls.Add(Me.lblArchivo1)
        Me.grpDatosEnvio.Controls.Add(Me.txtAsuntoMail)
        Me.grpDatosEnvio.Controls.Add(Me.lblCuerpo)
        Me.grpDatosEnvio.Controls.Add(Me.lblAsunto)
        Me.grpDatosEnvio.Controls.Add(Me.rtbCuerpoMail)
        Me.grpDatosEnvio.Location = New System.Drawing.Point(15, 402)
        Me.grpDatosEnvio.Name = "grpDatosEnvio"
        Me.grpDatosEnvio.Size = New System.Drawing.Size(955, 133)
        Me.grpDatosEnvio.TabIndex = 7
        Me.grpDatosEnvio.TabStop = False
        Me.grpDatosEnvio.Text = "Datos de Envío"
        '
        'btnExaminar4
        '
        Me.btnExaminar4.Image = CType(resources.GetObject("btnExaminar4.Image"), System.Drawing.Image)
        Me.btnExaminar4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar4.Location = New System.Drawing.Point(878, 96)
        Me.btnExaminar4.Name = "btnExaminar4"
        Me.btnExaminar4.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar4.TabIndex = 15
        Me.btnExaminar4.Text = "Exam..."
        Me.btnExaminar4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar4.UseVisualStyleBackColor = True
        '
        'txtArchivo4
        '
        Me.txtArchivo4.BindearPropiedadControl = "Text"
        Me.txtArchivo4.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo4.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo4.Formato = ""
        Me.txtArchivo4.IsDecimal = False
        Me.txtArchivo4.IsNumber = False
        Me.txtArchivo4.IsPK = False
        Me.txtArchivo4.IsRequired = False
        Me.txtArchivo4.Key = ""
        Me.txtArchivo4.LabelAsoc = Me.lblArchivo4
        Me.txtArchivo4.Location = New System.Drawing.Point(539, 96)
        Me.txtArchivo4.Name = "txtArchivo4"
        Me.txtArchivo4.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo4.TabIndex = 14
        '
        'lblArchivo4
        '
        Me.lblArchivo4.AutoSize = True
        Me.lblArchivo4.LabelAsoc = Nothing
        Me.lblArchivo4.Location = New System.Drawing.Point(485, 100)
        Me.lblArchivo4.Name = "lblArchivo4"
        Me.lblArchivo4.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo4.TabIndex = 13
        Me.lblArchivo4.Text = "Archivo 4"
        '
        'btnExaminar3
        '
        Me.btnExaminar3.Image = CType(resources.GetObject("btnExaminar3.Image"), System.Drawing.Image)
        Me.btnExaminar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar3.Location = New System.Drawing.Point(878, 70)
        Me.btnExaminar3.Name = "btnExaminar3"
        Me.btnExaminar3.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar3.TabIndex = 12
        Me.btnExaminar3.Text = "Exam..."
        Me.btnExaminar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar3.UseVisualStyleBackColor = True
        '
        'txtArchivo3
        '
        Me.txtArchivo3.BindearPropiedadControl = "Text"
        Me.txtArchivo3.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo3.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo3.Formato = ""
        Me.txtArchivo3.IsDecimal = False
        Me.txtArchivo3.IsNumber = False
        Me.txtArchivo3.IsPK = False
        Me.txtArchivo3.IsRequired = False
        Me.txtArchivo3.Key = ""
        Me.txtArchivo3.LabelAsoc = Me.lblArchivo3
        Me.txtArchivo3.Location = New System.Drawing.Point(539, 70)
        Me.txtArchivo3.Name = "txtArchivo3"
        Me.txtArchivo3.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo3.TabIndex = 11
        '
        'lblArchivo3
        '
        Me.lblArchivo3.AutoSize = True
        Me.lblArchivo3.LabelAsoc = Nothing
        Me.lblArchivo3.Location = New System.Drawing.Point(485, 74)
        Me.lblArchivo3.Name = "lblArchivo3"
        Me.lblArchivo3.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo3.TabIndex = 10
        Me.lblArchivo3.Text = "Archivo 3"
        '
        'btnExaminar2
        '
        Me.btnExaminar2.Image = CType(resources.GetObject("btnExaminar2.Image"), System.Drawing.Image)
        Me.btnExaminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar2.Location = New System.Drawing.Point(878, 45)
        Me.btnExaminar2.Name = "btnExaminar2"
        Me.btnExaminar2.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar2.TabIndex = 9
        Me.btnExaminar2.Text = "Exam..."
        Me.btnExaminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar2.UseVisualStyleBackColor = True
        '
        'txtArchivo2
        '
        Me.txtArchivo2.BindearPropiedadControl = "Text"
        Me.txtArchivo2.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo2.Formato = ""
        Me.txtArchivo2.IsDecimal = False
        Me.txtArchivo2.IsNumber = False
        Me.txtArchivo2.IsPK = False
        Me.txtArchivo2.IsRequired = False
        Me.txtArchivo2.Key = ""
        Me.txtArchivo2.LabelAsoc = Me.lblArchivo2
        Me.txtArchivo2.Location = New System.Drawing.Point(539, 45)
        Me.txtArchivo2.Name = "txtArchivo2"
        Me.txtArchivo2.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo2.TabIndex = 8
        '
        'lblArchivo2
        '
        Me.lblArchivo2.AutoSize = True
        Me.lblArchivo2.LabelAsoc = Nothing
        Me.lblArchivo2.Location = New System.Drawing.Point(485, 49)
        Me.lblArchivo2.Name = "lblArchivo2"
        Me.lblArchivo2.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo2.TabIndex = 7
        Me.lblArchivo2.Text = "Archivo 2"
        '
        'btnExpandirHtml
        '
        Me.btnExpandirHtml.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
        Me.btnExpandirHtml.Location = New System.Drawing.Point(17, 86)
        Me.btnExpandirHtml.Name = "btnExpandirHtml"
        Me.btnExpandirHtml.Size = New System.Drawing.Size(40, 40)
        Me.btnExpandirHtml.TabIndex = 6
        Me.btnExpandirHtml.Text = "..."
        Me.btnExpandirHtml.UseVisualStyleBackColor = True
        '
        'btnExaminar1
        '
        Me.btnExaminar1.Image = CType(resources.GetObject("btnExaminar1.Image"), System.Drawing.Image)
        Me.btnExaminar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar1.Location = New System.Drawing.Point(878, 20)
        Me.btnExaminar1.Name = "btnExaminar1"
        Me.btnExaminar1.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar1.TabIndex = 6
        Me.btnExaminar1.Text = "Exam..."
        Me.btnExaminar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar1.UseVisualStyleBackColor = True
        '
        'txtArchivo1
        '
        Me.txtArchivo1.BindearPropiedadControl = "Text"
        Me.txtArchivo1.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo1.Formato = ""
        Me.txtArchivo1.IsDecimal = False
        Me.txtArchivo1.IsNumber = False
        Me.txtArchivo1.IsPK = False
        Me.txtArchivo1.IsRequired = False
        Me.txtArchivo1.Key = ""
        Me.txtArchivo1.LabelAsoc = Me.lblArchivo1
        Me.txtArchivo1.Location = New System.Drawing.Point(539, 20)
        Me.txtArchivo1.Name = "txtArchivo1"
        Me.txtArchivo1.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo1.TabIndex = 5
        '
        'lblArchivo1
        '
        Me.lblArchivo1.AutoSize = True
        Me.lblArchivo1.LabelAsoc = Nothing
        Me.lblArchivo1.Location = New System.Drawing.Point(485, 24)
        Me.lblArchivo1.Name = "lblArchivo1"
        Me.lblArchivo1.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo1.TabIndex = 4
        Me.lblArchivo1.Text = "Archivo 1"
        '
        'txtAsuntoMail
        '
        Me.txtAsuntoMail.Location = New System.Drawing.Point(63, 20)
        Me.txtAsuntoMail.Name = "txtAsuntoMail"
        Me.txtAsuntoMail.Size = New System.Drawing.Size(407, 20)
        Me.txtAsuntoMail.TabIndex = 1
        '
        'txtCopiaOculta
        '
        Me.txtCopiaOculta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCopiaOculta.BindearPropiedadControl = ""
        Me.txtCopiaOculta.BindearPropiedadEntidad = ""
        Me.txtCopiaOculta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCopiaOculta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCopiaOculta.Formato = "N2"
        Me.txtCopiaOculta.IsDecimal = False
        Me.txtCopiaOculta.IsNumber = False
        Me.txtCopiaOculta.IsPK = False
        Me.txtCopiaOculta.IsRequired = False
        Me.txtCopiaOculta.Key = ""
        Me.txtCopiaOculta.LabelAsoc = Nothing
        Me.txtCopiaOculta.Location = New System.Drawing.Point(648, 155)
        Me.txtCopiaOculta.MaxLength = 60
        Me.txtCopiaOculta.Name = "txtCopiaOculta"
        Me.txtCopiaOculta.Size = New System.Drawing.Size(186, 20)
        Me.txtCopiaOculta.TabIndex = 5
        '
        'chbCopiaOculta
        '
        Me.chbCopiaOculta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbCopiaOculta.AutoSize = True
        Me.chbCopiaOculta.BindearPropiedadControl = Nothing
        Me.chbCopiaOculta.BindearPropiedadEntidad = Nothing
        Me.chbCopiaOculta.Checked = True
        Me.chbCopiaOculta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbCopiaOculta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCopiaOculta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCopiaOculta.IsPK = False
        Me.chbCopiaOculta.IsRequired = False
        Me.chbCopiaOculta.Key = Nothing
        Me.chbCopiaOculta.LabelAsoc = Nothing
        Me.chbCopiaOculta.Location = New System.Drawing.Point(555, 157)
        Me.chbCopiaOculta.Name = "chbCopiaOculta"
        Me.chbCopiaOculta.Size = New System.Drawing.Size(87, 17)
        Me.chbCopiaOculta.TabIndex = 4
        Me.chbCopiaOculta.Text = "Copia Oculta"
        Me.chbCopiaOculta.UseVisualStyleBackColor = True
        '
        'DialogoAbrirArchivo
        '
        Me.DialogoAbrirArchivo.FileName = "OpenFileDialog1"
        Me.DialogoAbrirArchivo.Filter = "Adobe Reader (*.pdf)|*.pdf|Todos los Archivos (*.*)|*.*"
        Me.DialogoAbrirArchivo.RestoreDirectory = True
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(148, 152)
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
        Me.cmbTodos.Location = New System.Drawing.Point(21, 153)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 1
        '
        'chbEnvioCtaCteCliente
        '
        Me.chbEnvioCtaCteCliente.AutoSize = True
        Me.chbEnvioCtaCteCliente.BindearPropiedadControl = Nothing
        Me.chbEnvioCtaCteCliente.BindearPropiedadEntidad = Nothing
        Me.chbEnvioCtaCteCliente.Checked = True
        Me.chbEnvioCtaCteCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEnvioCtaCteCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEnvioCtaCteCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEnvioCtaCteCliente.IsPK = False
        Me.chbEnvioCtaCteCliente.IsRequired = False
        Me.chbEnvioCtaCteCliente.Key = Nothing
        Me.chbEnvioCtaCteCliente.LabelAsoc = Nothing
        Me.chbEnvioCtaCteCliente.Location = New System.Drawing.Point(235, 158)
        Me.chbEnvioCtaCteCliente.Name = "chbEnvioCtaCteCliente"
        Me.chbEnvioCtaCteCliente.Size = New System.Drawing.Size(262, 17)
        Me.chbEnvioCtaCteCliente.TabIndex = 3
        Me.chbEnvioCtaCteCliente.Text = "Adjuntar Cta. Cte. (Si adeuda otros comprobantes)"
        Me.chbEnvioCtaCteCliente.UseVisualStyleBackColor = True
        Me.chbEnvioCtaCteCliente.Visible = False
        '
        'tbcEnvioMail
        '
        Me.tbcEnvioMail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcEnvioMail.Controls.Add(Me.tbpClientes)
        Me.tbcEnvioMail.Controls.Add(Me.tbpNovedades)
        Me.tbcEnvioMail.Controls.Add(Me.tbpNovedadesDelCliente)
        Me.tbcEnvioMail.Location = New System.Drawing.Point(15, 180)
        Me.tbcEnvioMail.Name = "tbcEnvioMail"
        Me.tbcEnvioMail.SelectedIndex = 0
        Me.tbcEnvioMail.Size = New System.Drawing.Size(957, 216)
        Me.tbcEnvioMail.TabIndex = 8
        '
        'tbpClientes
        '
        Me.tbpClientes.BackColor = System.Drawing.SystemColors.Control
        Me.tbpClientes.Controls.Add(Me.ugClientes)
        Me.tbpClientes.Location = New System.Drawing.Point(4, 22)
        Me.tbpClientes.Name = "tbpClientes"
        Me.tbpClientes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpClientes.Size = New System.Drawing.Size(949, 190)
        Me.tbpClientes.TabIndex = 0
        Me.tbpClientes.Text = "Clientes"
        '
        'tbpNovedades
        '
        Me.tbpNovedades.BackColor = System.Drawing.SystemColors.Control
        Me.tbpNovedades.Controls.Add(Me.ugNovedades)
        Me.tbpNovedades.Location = New System.Drawing.Point(4, 22)
        Me.tbpNovedades.Name = "tbpNovedades"
        Me.tbpNovedades.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpNovedades.Size = New System.Drawing.Size(949, 190)
        Me.tbpNovedades.TabIndex = 1
        Me.tbpNovedades.Text = "Novedades"
        '
        'ugNovedades
        '
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor3DBase = System.Drawing.Color.White
        Me.ugNovedades.DisplayLayout.Appearance = Appearance28
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.Header.Caption = "Categoria Novedad"
        UltraGridColumn4.Header.VisiblePosition = 1
        UltraGridColumn4.Width = 89
        UltraGridColumn12.Header.Caption = "Tipo Novedad"
        UltraGridColumn12.Header.VisiblePosition = 3
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 82
        UltraGridColumn13.Header.Caption = "Fecha Novedad"
        UltraGridColumn13.Header.VisiblePosition = 4
        UltraGridColumn13.Width = 91
        UltraGridColumn14.Header.VisiblePosition = 9
        UltraGridColumn14.Width = 307
        UltraGridColumn15.Header.Caption = "Id Función"
        UltraGridColumn15.Header.VisiblePosition = 7
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 120
        UltraGridColumn39.Header.Caption = "Función"
        UltraGridColumn39.Header.VisiblePosition = 8
        UltraGridColumn39.Width = 184
        UltraGridColumn18.Header.VisiblePosition = 10
        UltraGridColumn18.Width = 78
        UltraGridColumn19.Header.Caption = "Version Fecha"
        UltraGridColumn19.Header.VisiblePosition = 11
        UltraGridColumn19.Width = 83
        UltraGridColumn41.Header.Caption = "Id Función Padre"
        UltraGridColumn41.Header.VisiblePosition = 5
        UltraGridColumn41.Hidden = True
        UltraGridColumn41.Width = 120
        UltraGridColumn42.Header.Caption = "Módulo"
        UltraGridColumn42.Header.VisiblePosition = 6
        UltraGridColumn42.Width = 184
        Appearance29.TextHAlignAsString = "Right"
        UltraGridColumn46.CellAppearance = Appearance29
        UltraGridColumn46.Header.Caption = "Código"
        UltraGridColumn46.Header.VisiblePosition = 13
        UltraGridColumn47.Header.Caption = "Cliente"
        UltraGridColumn47.Header.VisiblePosition = 14
        UltraGridColumn47.Width = 400
        UltraGridColumn45.Header.VisiblePosition = 12
        Appearance30.TextHAlignAsString = "Right"
        Appearance30.TextVAlignAsString = "Middle"
        UltraGridColumn48.CellAppearance = Appearance30
        UltraGridColumn48.Header.VisiblePosition = 2
        UltraGridColumn49.Header.Caption = "Zona Geografica"
        UltraGridColumn49.Header.VisiblePosition = 15
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn3, UltraGridColumn4, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn39, UltraGridColumn18, UltraGridColumn19, UltraGridColumn41, UltraGridColumn42, UltraGridColumn46, UltraGridColumn47, UltraGridColumn45, UltraGridColumn48, UltraGridColumn49})
        UltraGridBand2.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand2.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand2.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand2.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        UltraGridBand2.SummaryFooterCaption = "Totales:"
        Me.ugNovedades.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugNovedades.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugNovedades.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance31.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance31.BorderColor = System.Drawing.SystemColors.Window
        Me.ugNovedades.DisplayLayout.GroupByBox.Appearance = Appearance31
        Appearance32.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugNovedades.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance32
        Me.ugNovedades.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugNovedades.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance33.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance33.BackColor2 = System.Drawing.SystemColors.Control
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugNovedades.DisplayLayout.GroupByBox.PromptAppearance = Appearance33
        Me.ugNovedades.DisplayLayout.MaxColScrollRegions = 1
        Me.ugNovedades.DisplayLayout.MaxRowScrollRegions = 1
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Appearance34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugNovedades.DisplayLayout.Override.ActiveCellAppearance = Appearance34
        Appearance35.BackColor = System.Drawing.SystemColors.Highlight
        Appearance35.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugNovedades.DisplayLayout.Override.ActiveRowAppearance = Appearance35
        Me.ugNovedades.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugNovedades.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugNovedades.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugNovedades.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugNovedades.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugNovedades.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugNovedades.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugNovedades.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Me.ugNovedades.DisplayLayout.Override.CardAreaAppearance = Appearance36
        Appearance37.BorderColor = System.Drawing.Color.Silver
        Appearance37.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugNovedades.DisplayLayout.Override.CellAppearance = Appearance37
        Me.ugNovedades.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugNovedades.DisplayLayout.Override.CellPadding = 0
        Me.ugNovedades.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugNovedades.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugNovedades.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance38.BackColor = System.Drawing.Color.Tomato
        Appearance38.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance38.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.ugNovedades.DisplayLayout.Override.GroupByRowAppearance = Appearance38
        Me.ugNovedades.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance39.TextHAlignAsString = "Left"
        Me.ugNovedades.DisplayLayout.Override.HeaderAppearance = Appearance39
        Me.ugNovedades.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugNovedades.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance40.BackColor = System.Drawing.SystemColors.Window
        Appearance40.BorderColor = System.Drawing.Color.Silver
        Me.ugNovedades.DisplayLayout.Override.RowAppearance = Appearance40
        Me.ugNovedades.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugNovedades.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugNovedades.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugNovedades.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugNovedades.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugNovedades.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance41.BackColor = System.Drawing.Color.LimeGreen
        Appearance41.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugNovedades.DisplayLayout.Override.SummaryValueAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugNovedades.DisplayLayout.Override.TemplateAddRowAppearance = Appearance42
        Me.ugNovedades.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugNovedades.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugNovedades.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugNovedades.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugNovedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugNovedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugNovedades.Location = New System.Drawing.Point(3, 3)
        Me.ugNovedades.Name = "ugNovedades"
        Me.ugNovedades.Size = New System.Drawing.Size(943, 184)
        Me.ugNovedades.TabIndex = 7
        Me.ugNovedades.Text = "UltraGrid1"
        '
        'tbpNovedadesDelCliente
        '
        Me.tbpNovedadesDelCliente.BackColor = System.Drawing.SystemColors.Control
        Me.tbpNovedadesDelCliente.Controls.Add(Me.ugClientesNovedades)
        Me.tbpNovedadesDelCliente.Location = New System.Drawing.Point(4, 22)
        Me.tbpNovedadesDelCliente.Name = "tbpNovedadesDelCliente"
        Me.tbpNovedadesDelCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpNovedadesDelCliente.Size = New System.Drawing.Size(949, 190)
        Me.tbpNovedadesDelCliente.TabIndex = 2
        Me.tbpNovedadesDelCliente.Text = "Novedades del Cliente"
        '
        'ugClientesNovedades
        '
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Appearance43.BorderColor3DBase = System.Drawing.Color.White
        Me.ugClientesNovedades.DisplayLayout.Appearance = Appearance43
        UltraGridColumn21.Header.Caption = "Categoria Novedad"
        UltraGridColumn21.Header.VisiblePosition = 0
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 89
        UltraGridColumn23.Header.Caption = "Id Función"
        UltraGridColumn23.Header.VisiblePosition = 3
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 120
        UltraGridColumn40.Header.Caption = "Función"
        UltraGridColumn40.Header.VisiblePosition = 4
        UltraGridColumn40.Width = 184
        UltraGridColumn24.Header.VisiblePosition = 5
        UltraGridColumn24.Width = 307
        UltraGridColumn25.Header.VisiblePosition = 6
        UltraGridColumn25.Width = 78
        UltraGridColumn43.Header.Caption = "Id Función Padre"
        UltraGridColumn43.Header.VisiblePosition = 1
        UltraGridColumn43.Hidden = True
        UltraGridColumn43.Width = 120
        UltraGridColumn44.Header.Caption = "Módulo"
        UltraGridColumn44.Header.VisiblePosition = 2
        UltraGridColumn44.Width = 184
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn21, UltraGridColumn23, UltraGridColumn40, UltraGridColumn24, UltraGridColumn25, UltraGridColumn43, UltraGridColumn44})
        UltraGridBand3.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand3.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand3.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand3.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        UltraGridBand3.SummaryFooterCaption = "Totales:"
        Me.ugClientesNovedades.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugClientesNovedades.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientesNovedades.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance44.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance44.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance44.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientesNovedades.DisplayLayout.GroupByBox.Appearance = Appearance44
        Appearance45.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientesNovedades.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance45
        Me.ugClientesNovedades.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientesNovedades.DisplayLayout.GroupByBox.Hidden = True
        Appearance46.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance46.BackColor2 = System.Drawing.SystemColors.Control
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientesNovedades.DisplayLayout.GroupByBox.PromptAppearance = Appearance46
        Me.ugClientesNovedades.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugClientesNovedades.DisplayLayout.MaxColScrollRegions = 1
        Me.ugClientesNovedades.DisplayLayout.MaxRowScrollRegions = 1
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugClientesNovedades.DisplayLayout.Override.ActiveCellAppearance = Appearance47
        Appearance48.BackColor = System.Drawing.SystemColors.Highlight
        Appearance48.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugClientesNovedades.DisplayLayout.Override.ActiveRowAppearance = Appearance48
        Me.ugClientesNovedades.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugClientesNovedades.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugClientesNovedades.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugClientesNovedades.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugClientesNovedades.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugClientesNovedades.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugClientesNovedades.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugClientesNovedades.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Me.ugClientesNovedades.DisplayLayout.Override.CardAreaAppearance = Appearance49
        Appearance50.BorderColor = System.Drawing.Color.Silver
        Appearance50.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugClientesNovedades.DisplayLayout.Override.CellAppearance = Appearance50
        Me.ugClientesNovedades.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugClientesNovedades.DisplayLayout.Override.CellPadding = 0
        Me.ugClientesNovedades.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugClientesNovedades.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugClientesNovedades.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance51.BackColor = System.Drawing.Color.Tomato
        Appearance51.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance51.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance51.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientesNovedades.DisplayLayout.Override.GroupByRowAppearance = Appearance51
        Me.ugClientesNovedades.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance52.TextHAlignAsString = "Left"
        Me.ugClientesNovedades.DisplayLayout.Override.HeaderAppearance = Appearance52
        Me.ugClientesNovedades.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugClientesNovedades.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Me.ugClientesNovedades.DisplayLayout.Override.RowAppearance = Appearance53
        Me.ugClientesNovedades.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugClientesNovedades.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugClientesNovedades.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugClientesNovedades.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugClientesNovedades.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugClientesNovedades.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance54.BackColor = System.Drawing.Color.LimeGreen
        Appearance54.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugClientesNovedades.DisplayLayout.Override.SummaryValueAppearance = Appearance54
        Appearance55.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugClientesNovedades.DisplayLayout.Override.TemplateAddRowAppearance = Appearance55
        Me.ugClientesNovedades.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugClientesNovedades.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugClientesNovedades.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugClientesNovedades.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugClientesNovedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugClientesNovedades.Location = New System.Drawing.Point(3, 3)
        Me.ugClientesNovedades.Name = "ugClientesNovedades"
        Me.ugClientesNovedades.Size = New System.Drawing.Size(943, 184)
        Me.ugClientesNovedades.TabIndex = 0
        Me.ugClientesNovedades.Text = "UltraGrid1"
        '
        'EnvioNovedadesDeVersiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.tbcEnvioMail)
        Me.Controls.Add(Me.chbEnvioCtaCteCliente)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.chbCopiaOculta)
        Me.Controls.Add(Me.txtCopiaOculta)
        Me.Controls.Add(Me.grpDatosEnvio)
        Me.Controls.Add(Me.sspPie)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EnvioNovedadesDeVersiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envío de Novedades de Versiones"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sspPie.ResumeLayout(False)
        Me.sspPie.PerformLayout()
        Me.grpDatosEnvio.ResumeLayout(False)
        Me.grpDatosEnvio.PerformLayout()
        Me.tbcEnvioMail.ResumeLayout(False)
        Me.tbpClientes.ResumeLayout(False)
        Me.tbpNovedades.ResumeLayout(False)
        CType(Me.ugNovedades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpNovedadesDelCliente.ResumeLayout(False)
        CType(Me.ugClientesNovedades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbEnviarCorreos As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents ugClientes As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents sspPie As System.Windows.Forms.StatusStrip
   Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents rtbCuerpoMail As MSDN.Html.Editor.HtmlEditorControl
   Friend WithEvents lblCuerpo As Eniac.Controles.Label
   Friend WithEvents lblAsunto As Eniac.Controles.Label
   Friend WithEvents grpDatosEnvio As System.Windows.Forms.GroupBox
   Friend WithEvents txtAsuntoMail As System.Windows.Forms.TextBox
   Friend WithEvents bscNombreCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoriaCliente As Eniac.Controles.Label
   Friend WithEvents btnExaminar4 As Eniac.Controles.Button
   Friend WithEvents txtArchivo4 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo4 As Eniac.Controles.Label
   Friend WithEvents btnExaminar3 As Eniac.Controles.Button
   Friend WithEvents txtArchivo3 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo3 As Eniac.Controles.Label
   Friend WithEvents btnExaminar2 As Eniac.Controles.Button
   Friend WithEvents txtArchivo2 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo2 As Eniac.Controles.Label
   Friend WithEvents btnExaminar1 As Eniac.Controles.Button
   Friend WithEvents txtArchivo1 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo1 As Eniac.Controles.Label
   Friend WithEvents txtCopiaOculta As Eniac.Controles.TextBox
   Friend WithEvents chbCopiaOculta As Eniac.Controles.CheckBox
   Friend WithEvents lblComenzarPorNombreCliente As Eniac.Controles.Label
   Friend WithEvents txtComenzarPorNombreCliente As Eniac.Controles.TextBox
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents DialogoAbrirArchivo As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnExpandirHtml As Eniac.Controles.Button
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbEnvioCtaCteCliente As Controles.CheckBox
   Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbCobrador As Eniac.Controles.CheckBox
   Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
   Friend WithEvents lblVersionDesde As Eniac.Controles.Label
   Friend WithEvents lblVersionHasta As Eniac.Controles.Label
   Friend WithEvents lblVersion As Eniac.Controles.Label
   Friend WithEvents tbcEnvioMail As System.Windows.Forms.TabControl
   Friend WithEvents tbpClientes As System.Windows.Forms.TabPage
   Friend WithEvents tbpNovedades As System.Windows.Forms.TabPage
   Friend WithEvents cmbAplicacion As Eniac.Controles.ComboBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents ugNovedades As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents cmbVersionHasta As Eniac.Controles.ComboBox
   Friend WithEvents cmbVersionDesde As Eniac.Controles.ComboBox
   Friend WithEvents tbpNovedadesDelCliente As System.Windows.Forms.TabPage
   Friend WithEvents ugClientesNovedades As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents cmbCategoriasClientes As Eniac.Win.ComboBoxCategorias
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Public WithEvents tsbCorreoPrueba As System.Windows.Forms.ToolStripButton
End Class
