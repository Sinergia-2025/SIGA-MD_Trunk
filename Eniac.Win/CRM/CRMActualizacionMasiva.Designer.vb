<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMActualizacionMasiva
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRMActualizacionMasiva))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoComprobante")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocCliente")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocCliente")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoriaFiscal")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaDePago")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
        Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
        Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioLista")
        Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
        Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc")
        Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc2")
        Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorcGral")
        Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNeto")
        Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AlicuotaImpuesto")
        Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuesto")
        Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotalNeto")
        Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAplicacion")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroVersion")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Script")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Obligatorio")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Aplicacion")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Version")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
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
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdNovedad")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaNovedad")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaNovedad")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombredeFantasia")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePadre")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFuncion")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Interocutor")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUsuarioResponsable")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGenerarVersion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.tbpVersion = New System.Windows.Forms.TabPage()
        Me.btnEliminarScript = New System.Windows.Forms.Button()
        Me.btnSeleccionarScript = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistrosScript = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ugScripts = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnProbarFTP = New System.Windows.Forms.Button()
        Me.LblFtp = New Eniac.Controles.Label()
        Me.TxtRutaFTP = New System.Windows.Forms.TextBox()
        Me.BtnFTP = New System.Windows.Forms.Button()
        Me.txtVersionFinal = New Eniac.Controles.TextBox()
        Me.chbColorVersion = New Eniac.Controles.CheckBox()
        Me.pnlColorNuevoVersion = New System.Windows.Forms.Panel()
        Me.btnColorVersion = New System.Windows.Forms.Button()
        Me.chbMedioVersion = New Eniac.Controles.CheckBox()
        Me.chbFechaProximoContactoVersion = New Eniac.Controles.CheckBox()
        Me.dtpFechaProximoContactoVersion = New Eniac.Controles.DateTimePicker()
        Me.chbPriorizadoVersion = New Eniac.Controles.CheckBox()
        Me.chbPrioridadVersion = New Eniac.Controles.CheckBox()
        Me.chbAvanceVersion = New Eniac.Controles.CheckBox()
        Me.txtAvanceVersion = New Eniac.Controles.TextBox()
        Me.chbVersionFechaFinal = New Eniac.Controles.CheckBox()
        Me.dtpVersionFechaFinal = New Eniac.Controles.DateTimePicker()
        Me.chbVersionFinal = New Eniac.Controles.CheckBox()
        Me.chbEstadoVersion = New Eniac.Controles.CheckBox()
        Me.cmbMedioVersion = New Eniac.Controles.ComboBox()
        Me.cmbPriorizadoVersion = New Eniac.Controles.ComboBox()
        Me.cmbPrioridadNovedadVersion = New Eniac.Controles.ComboBox()
        Me.cmbEstadoVersion = New Eniac.Controles.ComboBox()
        Me.tbpCambios = New System.Windows.Forms.TabPage()
        Me.chbMetodoNuevo = New Eniac.Controles.CheckBox()
        Me.cmbMetodoNuevo = New Eniac.Controles.ComboBox()
        Me.bscCodigoProyectoNuevo = New Eniac.Controles.Buscador2()
        Me.chbProyectoNuevo = New Eniac.Controles.CheckBox()
        Me.bscProyectoNuevo = New Eniac.Controles.Buscador2()
        Me.bscCodigoFuncionNuevo = New Eniac.Controles.Buscador2()
        Me.chbFuncionNuevo = New Eniac.Controles.CheckBox()
        Me.bscFuncionNuevo = New Eniac.Controles.Buscador2()
        Me.cmbAplicacionNueva = New Eniac.Controles.ComboBox()
        Me.chbAplicacionNueva = New Eniac.Controles.CheckBox()
        Me.bscNombreClienteNuevo = New Eniac.Controles.Buscador2()
        Me.chbClienteNuevo = New Eniac.Controles.CheckBox()
        Me.bscCodClienteNuevo = New Eniac.Controles.Buscador2()
        Me.chbCategoriaNuevo = New Eniac.Controles.CheckBox()
        Me.cmbCategoriaNovedadNuevo = New Eniac.Controles.ComboBox()
        Me.chbColorNuevo = New Eniac.Controles.CheckBox()
        Me.pnlColorNuevo = New System.Windows.Forms.Panel()
        Me.btnColorNuevo = New System.Windows.Forms.Button()
        Me.chbMedioNuevo = New Eniac.Controles.CheckBox()
        Me.cmbMedioNuevo = New Eniac.Controles.ComboBox()
        Me.chbFechaProximoContacto = New Eniac.Controles.CheckBox()
        Me.dtpFechaProximoContacto = New Eniac.Controles.DateTimePicker()
        Me.chbRequiereTesteoNuevo = New Eniac.Controles.CheckBox()
        Me.chbPriorizadoNuevo = New Eniac.Controles.CheckBox()
        Me.cmbRequiereTesteoNuevo = New Eniac.Controles.ComboBox()
        Me.cmbPriorizadoNuevo = New Eniac.Controles.ComboBox()
        Me.chbPrioridadNuevo = New Eniac.Controles.CheckBox()
        Me.cmbPrioridadNovedadNuevo = New Eniac.Controles.ComboBox()
        Me.chbAvanceNuevo = New Eniac.Controles.CheckBox()
        Me.txtAvanceNuevo = New Eniac.Controles.TextBox()
        Me.txtVersionNuevo = New Eniac.Controles.TextBox()
        Me.chbVersionNuevo = New Eniac.Controles.CheckBox()
        Me.chbVersionFechaNuevo = New Eniac.Controles.CheckBox()
        Me.dtpVersionFechaNuevo = New Eniac.Controles.DateTimePicker()
        Me.chbAsignadoANuevo = New Eniac.Controles.CheckBox()
        Me.chbEstadoNuevo = New Eniac.Controles.CheckBox()
        Me.cmbAsignadoANuevo = New Eniac.Controles.ComboBox()
        Me.cmbEstadoNuevo = New Eniac.Controles.ComboBox()
        Me.tbpFiltros = New System.Windows.Forms.TabPage()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.bscCodigoFuncion = New Eniac.Controles.Buscador2()
        Me.chbFuncion = New Eniac.Controles.CheckBox()
        Me.bscFuncion = New Eniac.Controles.Buscador2()
        Me.chbMetodoResolulcion = New Eniac.Controles.CheckBox()
        Me.cmbMetodoResolulcion = New Eniac.Controles.ComboBox()
        Me.cmbPriorizado = New Eniac.Controles.ComboBox()
        Me.Label4 = New Eniac.Controles.Label()
        Me.bscCodigoProyecto = New Eniac.Controles.Buscador2()
        Me.bscProyecto = New Eniac.Controles.Buscador2()
        Me.chbProyecto = New Eniac.Controles.CheckBox()
        Me.lblDescripcion = New Eniac.Controles.Label()
        Me.txtDescripcion = New Eniac.Controles.TextBox()
        Me.chbVersion = New Eniac.Controles.CheckBox()
        Me.cmbVersion = New Eniac.Controles.ComboBox()
        Me.chbAplicacion = New Eniac.Controles.CheckBox()
        Me.cmbAplicacion = New Eniac.Controles.ComboBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.cmbRevisionAdministrativa = New Eniac.Controles.ComboBox()
        Me.lblRevisionAdministrativa = New Eniac.Controles.Label()
        Me.txtNumero = New Eniac.Controles.TextBox()
        Me.cmbFinalizado = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.rdbFechaProxContacto = New Eniac.Controles.RadioButton()
        Me.rdbFechaNovedad = New Eniac.Controles.RadioButton()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.Label2 = New Eniac.Controles.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.Label3 = New Eniac.Controles.Label()
        Me.chbAsignadoA = New Eniac.Controles.CheckBox()
        Me.chbProspecto = New Eniac.Controles.CheckBox()
        Me.chbEstado = New Eniac.Controles.CheckBox()
        Me.chbMedio = New Eniac.Controles.CheckBox()
        Me.chbPrioridad = New Eniac.Controles.CheckBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
        Me.cmbIdUsuarioAsignado = New Eniac.Controles.ComboBox()
        Me.cmbEstadoNovedad = New Eniac.Controles.ComboBox()
        Me.cmbMedio = New Eniac.Controles.ComboBox()
        Me.cmbPrioridadNovedad = New Eniac.Controles.ComboBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.cmbUsuarioAlta = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.tbcVersion = New System.Windows.Forms.TabControl()
        Me.tbpEnviar = New System.Windows.Forms.TabPage()
        Me.ugEnviar = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.bwkGenerarVersion = New System.ComponentModel.BackgroundWorker()
        Me.ofgScript = New System.Windows.Forms.OpenFileDialog()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.lblPriorizado = New Eniac.Controles.Label()
        Me.cmbCategoriasNovedad = New Eniac.Win.ComboBoxCRMCategorias()
        Me.tstBarra.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpVersion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ugScripts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlColorNuevoVersion.SuspendLayout()
        Me.tbpCambios.SuspendLayout()
        Me.pnlColorNuevo.SuspendLayout()
        Me.tbpFiltros.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.tbcVersion.SuspendLayout()
        Me.tbpEnviar.SuspendLayout()
        CType(Me.ugEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbActualizar, Me.ToolStripSeparator2, Me.tsbGenerarVersion, Me.ToolStripSeparator6, Me.tsbModificar, Me.ToolStripSeparator7, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsddExportar, Me.ToolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 4
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
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
        'tsbActualizar
        '
        Me.tsbActualizar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
        Me.tsbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbActualizar.Name = "tsbActualizar"
        Me.tsbActualizar.Size = New System.Drawing.Size(108, 26)
        Me.tsbActualizar.Text = "&Actualizar (F4)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbGenerarVersion
        '
        Me.tsbGenerarVersion.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
        Me.tsbGenerarVersion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerarVersion.Name = "tsbGenerarVersion"
        Me.tsbGenerarVersion.Size = New System.Drawing.Size(138, 26)
        Me.tsbGenerarVersion.Text = "&Generar Versión (F4)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 29)
        '
        'tsbModificar
        '
        Me.tsbModificar.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
        Me.tsbModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbModificar.Name = "tsbModificar"
        Me.tsbModificar.Size = New System.Drawing.Size(84, 26)
        Me.tsbModificar.Text = "&Modificar"
        Me.tsbModificar.ToolTipText = "Anular el Comprobante"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
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
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
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
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(6, 295)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(969, 241)
        Me.ugDetalle.TabIndex = 3
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 5
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
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
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance13
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
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(134, 267)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 2
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'tbpVersion
        '
        Me.tbpVersion.BackColor = System.Drawing.SystemColors.Control
        Me.tbpVersion.Controls.Add(Me.btnEliminarScript)
        Me.tbpVersion.Controls.Add(Me.btnSeleccionarScript)
        Me.tbpVersion.Controls.Add(Me.GroupBox2)
        Me.tbpVersion.Controls.Add(Me.btnProbarFTP)
        Me.tbpVersion.Controls.Add(Me.LblFtp)
        Me.tbpVersion.Controls.Add(Me.TxtRutaFTP)
        Me.tbpVersion.Controls.Add(Me.BtnFTP)
        Me.tbpVersion.Controls.Add(Me.txtVersionFinal)
        Me.tbpVersion.Controls.Add(Me.chbColorVersion)
        Me.tbpVersion.Controls.Add(Me.pnlColorNuevoVersion)
        Me.tbpVersion.Controls.Add(Me.chbMedioVersion)
        Me.tbpVersion.Controls.Add(Me.chbFechaProximoContactoVersion)
        Me.tbpVersion.Controls.Add(Me.dtpFechaProximoContactoVersion)
        Me.tbpVersion.Controls.Add(Me.chbPriorizadoVersion)
        Me.tbpVersion.Controls.Add(Me.chbPrioridadVersion)
        Me.tbpVersion.Controls.Add(Me.chbAvanceVersion)
        Me.tbpVersion.Controls.Add(Me.txtAvanceVersion)
        Me.tbpVersion.Controls.Add(Me.chbVersionFechaFinal)
        Me.tbpVersion.Controls.Add(Me.dtpVersionFechaFinal)
        Me.tbpVersion.Controls.Add(Me.chbVersionFinal)
        Me.tbpVersion.Controls.Add(Me.chbEstadoVersion)
        Me.tbpVersion.Controls.Add(Me.cmbMedioVersion)
        Me.tbpVersion.Controls.Add(Me.cmbPriorizadoVersion)
        Me.tbpVersion.Controls.Add(Me.cmbPrioridadNovedadVersion)
        Me.tbpVersion.Controls.Add(Me.cmbEstadoVersion)
        Me.tbpVersion.Location = New System.Drawing.Point(4, 22)
        Me.tbpVersion.Name = "tbpVersion"
        Me.tbpVersion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpVersion.Size = New System.Drawing.Size(976, 203)
        Me.tbpVersion.TabIndex = 2
        Me.tbpVersion.Text = "Generar Versión"
        '
        'btnEliminarScript
        '
        Me.btnEliminarScript.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarScript.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminarScript.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarScript.Location = New System.Drawing.Point(928, 107)
        Me.btnEliminarScript.Name = "btnEliminarScript"
        Me.btnEliminarScript.Size = New System.Drawing.Size(35, 35)
        Me.btnEliminarScript.TabIndex = 50
        Me.btnEliminarScript.UseVisualStyleBackColor = False
        '
        'btnSeleccionarScript
        '
        Me.btnSeleccionarScript.BackColor = System.Drawing.Color.Transparent
        Me.btnSeleccionarScript.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnSeleccionarScript.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSeleccionarScript.Location = New System.Drawing.Point(928, 67)
        Me.btnSeleccionarScript.Name = "btnSeleccionarScript"
        Me.btnSeleccionarScript.Size = New System.Drawing.Size(35, 35)
        Me.btnSeleccionarScript.TabIndex = 49
        Me.btnSeleccionarScript.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.StatusStrip1)
        Me.GroupBox2.Controls.Add(Me.ugScripts)
        Me.GroupBox2.Location = New System.Drawing.Point(500, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(422, 137)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Scripts de Versión"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1, Me.tssRegistrosScript})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 112)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(416, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "statusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(337, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ToolStripProgressBar1.Visible = False
        '
        'tssRegistrosScript
        '
        Me.tssRegistrosScript.Name = "tssRegistrosScript"
        Me.tssRegistrosScript.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistrosScript.Text = "0 Registros"
        '
        'ugScripts
        '
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor3DBase = System.Drawing.Color.White
        Me.ugScripts.DisplayLayout.Appearance = Appearance14
        UltraGridColumn11.Header.VisiblePosition = 0
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.Header.VisiblePosition = 1
        UltraGridColumn12.Hidden = True
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance15
        UltraGridColumn7.Header.VisiblePosition = 2
        UltraGridColumn7.Width = 30
        UltraGridColumn8.Header.VisiblePosition = 4
        UltraGridColumn8.Width = 340
        UltraGridColumn13.Header.VisiblePosition = 5
        UltraGridColumn13.Hidden = True
        UltraGridColumn10.Header.VisiblePosition = 6
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 30
        UltraGridColumn9.Header.VisiblePosition = 3
        UltraGridColumn9.Hidden = True
        UltraGridColumn14.Header.VisiblePosition = 7
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.Header.VisiblePosition = 8
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.Header.VisiblePosition = 9
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.Header.VisiblePosition = 10
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.Header.VisiblePosition = 11
        UltraGridColumn18.Hidden = True
        UltraGridColumn19.Header.VisiblePosition = 12
        UltraGridColumn19.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn11, UltraGridColumn12, UltraGridColumn7, UltraGridColumn8, UltraGridColumn13, UltraGridColumn10, UltraGridColumn9, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19})
        UltraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        Me.ugScripts.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugScripts.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugScripts.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugScripts.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugScripts.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
        Me.ugScripts.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugScripts.DisplayLayout.GroupByBox.Hidden = True
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance18.BackColor2 = System.Drawing.SystemColors.Control
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugScripts.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
        Me.ugScripts.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugScripts.DisplayLayout.MaxColScrollRegions = 1
        Me.ugScripts.DisplayLayout.MaxRowScrollRegions = 1
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugScripts.DisplayLayout.Override.ActiveCellAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.SystemColors.Highlight
        Appearance20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugScripts.DisplayLayout.Override.ActiveRowAppearance = Appearance20
        Me.ugScripts.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugScripts.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugScripts.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugScripts.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugScripts.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugScripts.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugScripts.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugScripts.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.ugScripts.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugScripts.DisplayLayout.Override.CellAppearance = Appearance22
        Me.ugScripts.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugScripts.DisplayLayout.Override.CellPadding = 0
        Me.ugScripts.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugScripts.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugScripts.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance23.BackColor = System.Drawing.Color.Tomato
        Appearance23.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugScripts.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Me.ugScripts.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance24.TextHAlignAsString = "Left"
        Me.ugScripts.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.ugScripts.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugScripts.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.ugScripts.DisplayLayout.Override.RowAppearance = Appearance25
        Me.ugScripts.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugScripts.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugScripts.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugScripts.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugScripts.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugScripts.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance26.BackColor = System.Drawing.Color.LimeGreen
        Appearance26.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugScripts.DisplayLayout.Override.SummaryValueAppearance = Appearance26
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugScripts.DisplayLayout.Override.TemplateAddRowAppearance = Appearance27
        Me.ugScripts.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugScripts.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugScripts.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugScripts.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugScripts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugScripts.Location = New System.Drawing.Point(3, 16)
        Me.ugScripts.Name = "ugScripts"
        Me.ugScripts.Size = New System.Drawing.Size(416, 97)
        Me.ugScripts.TabIndex = 3
        Me.ugScripts.Text = "UltraGrid1"
        '
        'btnProbarFTP
        '
        Me.btnProbarFTP.Location = New System.Drawing.Point(501, 14)
        Me.btnProbarFTP.Name = "btnProbarFTP"
        Me.btnProbarFTP.Size = New System.Drawing.Size(75, 23)
        Me.btnProbarFTP.TabIndex = 20
        Me.btnProbarFTP.Text = "Validar FTP"
        Me.btnProbarFTP.UseVisualStyleBackColor = True
        '
        'LblFtp
        '
        Me.LblFtp.AutoSize = True
        Me.LblFtp.LabelAsoc = Nothing
        Me.LblFtp.Location = New System.Drawing.Point(579, -1)
        Me.LblFtp.Name = "LblFtp"
        Me.LblFtp.Size = New System.Drawing.Size(66, 13)
        Me.LblFtp.TabIndex = 17
        Me.LblFtp.Text = "Archivo FTP"
        '
        'TxtRutaFTP
        '
        Me.TxtRutaFTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TxtRutaFTP.Location = New System.Drawing.Point(582, 14)
        Me.TxtRutaFTP.Name = "TxtRutaFTP"
        Me.TxtRutaFTP.Size = New System.Drawing.Size(294, 23)
        Me.TxtRutaFTP.TabIndex = 18
        '
        'BtnFTP
        '
        Me.BtnFTP.BackColor = System.Drawing.Color.Transparent
        Me.BtnFTP.BackgroundImage = CType(resources.GetObject("BtnFTP.BackgroundImage"), System.Drawing.Image)
        Me.BtnFTP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFTP.Location = New System.Drawing.Point(887, 3)
        Me.BtnFTP.Name = "BtnFTP"
        Me.BtnFTP.Size = New System.Drawing.Size(35, 35)
        Me.BtnFTP.TabIndex = 19
        Me.BtnFTP.UseVisualStyleBackColor = False
        '
        'txtVersionFinal
        '
        Me.txtVersionFinal.BindearPropiedadControl = "Text"
        Me.txtVersionFinal.BindearPropiedadEntidad = "Version"
        Me.txtVersionFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVersionFinal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVersionFinal.Formato = ""
        Me.txtVersionFinal.IsDecimal = False
        Me.txtVersionFinal.IsNumber = False
        Me.txtVersionFinal.IsPK = False
        Me.txtVersionFinal.IsRequired = False
        Me.txtVersionFinal.Key = ""
        Me.txtVersionFinal.LabelAsoc = Nothing
        Me.txtVersionFinal.Location = New System.Drawing.Point(77, 81)
        Me.txtVersionFinal.MaxLength = 20
        Me.txtVersionFinal.Name = "txtVersionFinal"
        Me.txtVersionFinal.Size = New System.Drawing.Size(113, 20)
        Me.txtVersionFinal.TabIndex = 9
        '
        'chbColorVersion
        '
        Me.chbColorVersion.AutoSize = True
        Me.chbColorVersion.BindearPropiedadControl = Nothing
        Me.chbColorVersion.BindearPropiedadEntidad = Nothing
        Me.chbColorVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbColorVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbColorVersion.IsPK = False
        Me.chbColorVersion.IsRequired = False
        Me.chbColorVersion.Key = Nothing
        Me.chbColorVersion.LabelAsoc = Nothing
        Me.chbColorVersion.Location = New System.Drawing.Point(228, 80)
        Me.chbColorVersion.Name = "chbColorVersion"
        Me.chbColorVersion.Size = New System.Drawing.Size(50, 17)
        Me.chbColorVersion.TabIndex = 10
        Me.chbColorVersion.Text = "Color"
        Me.chbColorVersion.UseVisualStyleBackColor = True
        '
        'pnlColorNuevoVersion
        '
        Me.pnlColorNuevoVersion.BackColor = System.Drawing.SystemColors.Control
        Me.pnlColorNuevoVersion.Controls.Add(Me.btnColorVersion)
        Me.pnlColorNuevoVersion.Location = New System.Drawing.Point(342, 79)
        Me.pnlColorNuevoVersion.Name = "pnlColorNuevoVersion"
        Me.pnlColorNuevoVersion.Size = New System.Drawing.Size(26, 21)
        Me.pnlColorNuevoVersion.TabIndex = 47
        '
        'btnColorVersion
        '
        Me.btnColorVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColorVersion.Location = New System.Drawing.Point(1, 1)
        Me.btnColorVersion.Margin = New System.Windows.Forms.Padding(0)
        Me.btnColorVersion.Name = "btnColorVersion"
        Me.btnColorVersion.Size = New System.Drawing.Size(24, 20)
        Me.btnColorVersion.TabIndex = 0
        Me.btnColorVersion.TabStop = False
        Me.btnColorVersion.UseVisualStyleBackColor = False
        '
        'chbMedioVersion
        '
        Me.chbMedioVersion.AutoSize = True
        Me.chbMedioVersion.BindearPropiedadControl = Nothing
        Me.chbMedioVersion.BindearPropiedadEntidad = Nothing
        Me.chbMedioVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMedioVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMedioVersion.IsPK = False
        Me.chbMedioVersion.IsRequired = False
        Me.chbMedioVersion.Key = Nothing
        Me.chbMedioVersion.LabelAsoc = Nothing
        Me.chbMedioVersion.Location = New System.Drawing.Point(8, 106)
        Me.chbMedioVersion.Name = "chbMedioVersion"
        Me.chbMedioVersion.Size = New System.Drawing.Size(55, 17)
        Me.chbMedioVersion.TabIndex = 11
        Me.chbMedioVersion.Text = "Medio"
        Me.chbMedioVersion.UseVisualStyleBackColor = True
        '
        'chbFechaProximoContactoVersion
        '
        Me.chbFechaProximoContactoVersion.AutoSize = True
        Me.chbFechaProximoContactoVersion.BindearPropiedadControl = Nothing
        Me.chbFechaProximoContactoVersion.BindearPropiedadEntidad = Nothing
        Me.chbFechaProximoContactoVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaProximoContactoVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaProximoContactoVersion.IsPK = False
        Me.chbFechaProximoContactoVersion.IsRequired = False
        Me.chbFechaProximoContactoVersion.Key = Nothing
        Me.chbFechaProximoContactoVersion.LabelAsoc = Nothing
        Me.chbFechaProximoContactoVersion.Location = New System.Drawing.Point(228, 132)
        Me.chbFechaProximoContactoVersion.Name = "chbFechaProximoContactoVersion"
        Me.chbFechaProximoContactoVersion.Size = New System.Drawing.Size(108, 17)
        Me.chbFechaProximoContactoVersion.TabIndex = 15
        Me.chbFechaProximoContactoVersion.Text = "Próximo contacto"
        '
        'dtpFechaProximoContactoVersion
        '
        Me.dtpFechaProximoContactoVersion.BindearPropiedadControl = "Value"
        Me.dtpFechaProximoContactoVersion.BindearPropiedadEntidad = "FechaProximoContacto"
        Me.dtpFechaProximoContactoVersion.Checked = False
        Me.dtpFechaProximoContactoVersion.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaProximoContactoVersion.Enabled = False
        Me.dtpFechaProximoContactoVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaProximoContactoVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaProximoContactoVersion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaProximoContactoVersion.IsPK = False
        Me.dtpFechaProximoContactoVersion.IsRequired = False
        Me.dtpFechaProximoContactoVersion.Key = ""
        Me.dtpFechaProximoContactoVersion.LabelAsoc = Nothing
        Me.dtpFechaProximoContactoVersion.Location = New System.Drawing.Point(342, 132)
        Me.dtpFechaProximoContactoVersion.Name = "dtpFechaProximoContactoVersion"
        Me.dtpFechaProximoContactoVersion.ShowCheckBox = True
        Me.dtpFechaProximoContactoVersion.Size = New System.Drawing.Size(144, 20)
        Me.dtpFechaProximoContactoVersion.TabIndex = 16
        '
        'chbPriorizadoVersion
        '
        Me.chbPriorizadoVersion.AutoSize = True
        Me.chbPriorizadoVersion.BindearPropiedadControl = Nothing
        Me.chbPriorizadoVersion.BindearPropiedadEntidad = Nothing
        Me.chbPriorizadoVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPriorizadoVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPriorizadoVersion.IsPK = False
        Me.chbPriorizadoVersion.IsRequired = False
        Me.chbPriorizadoVersion.Key = Nothing
        Me.chbPriorizadoVersion.LabelAsoc = Nothing
        Me.chbPriorizadoVersion.Location = New System.Drawing.Point(228, 28)
        Me.chbPriorizadoVersion.Name = "chbPriorizadoVersion"
        Me.chbPriorizadoVersion.Size = New System.Drawing.Size(72, 17)
        Me.chbPriorizadoVersion.TabIndex = 2
        Me.chbPriorizadoVersion.Text = "Priorizado"
        Me.chbPriorizadoVersion.UseVisualStyleBackColor = True
        '
        'chbPrioridadVersion
        '
        Me.chbPrioridadVersion.AutoSize = True
        Me.chbPrioridadVersion.BindearPropiedadControl = Nothing
        Me.chbPrioridadVersion.BindearPropiedadEntidad = Nothing
        Me.chbPrioridadVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPrioridadVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPrioridadVersion.IsPK = False
        Me.chbPrioridadVersion.IsRequired = False
        Me.chbPrioridadVersion.Key = Nothing
        Me.chbPrioridadVersion.LabelAsoc = Nothing
        Me.chbPrioridadVersion.Location = New System.Drawing.Point(8, 28)
        Me.chbPrioridadVersion.Name = "chbPrioridadVersion"
        Me.chbPrioridadVersion.Size = New System.Drawing.Size(67, 17)
        Me.chbPrioridadVersion.TabIndex = 0
        Me.chbPrioridadVersion.Text = "Prioridad"
        Me.chbPrioridadVersion.UseVisualStyleBackColor = True
        '
        'chbAvanceVersion
        '
        Me.chbAvanceVersion.AutoSize = True
        Me.chbAvanceVersion.BindearPropiedadControl = Nothing
        Me.chbAvanceVersion.BindearPropiedadEntidad = Nothing
        Me.chbAvanceVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAvanceVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAvanceVersion.IsPK = False
        Me.chbAvanceVersion.IsRequired = False
        Me.chbAvanceVersion.Key = Nothing
        Me.chbAvanceVersion.LabelAsoc = Nothing
        Me.chbAvanceVersion.Location = New System.Drawing.Point(228, 54)
        Me.chbAvanceVersion.Name = "chbAvanceVersion"
        Me.chbAvanceVersion.Size = New System.Drawing.Size(34, 17)
        Me.chbAvanceVersion.TabIndex = 6
        Me.chbAvanceVersion.Text = "%"
        Me.chbAvanceVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAvanceVersion
        '
        Me.txtAvanceVersion.BindearPropiedadControl = "Text"
        Me.txtAvanceVersion.BindearPropiedadEntidad = "Avance"
        Me.txtAvanceVersion.Enabled = False
        Me.txtAvanceVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAvanceVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAvanceVersion.Formato = "N2"
        Me.txtAvanceVersion.IsDecimal = True
        Me.txtAvanceVersion.IsNumber = True
        Me.txtAvanceVersion.IsPK = False
        Me.txtAvanceVersion.IsRequired = True
        Me.txtAvanceVersion.Key = ""
        Me.txtAvanceVersion.LabelAsoc = Nothing
        Me.txtAvanceVersion.Location = New System.Drawing.Point(342, 53)
        Me.txtAvanceVersion.MaxLength = 6
        Me.txtAvanceVersion.Name = "txtAvanceVersion"
        Me.txtAvanceVersion.Size = New System.Drawing.Size(45, 20)
        Me.txtAvanceVersion.TabIndex = 7
        Me.txtAvanceVersion.Text = "0.00"
        Me.txtAvanceVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbVersionFechaFinal
        '
        Me.chbVersionFechaFinal.AutoSize = True
        Me.chbVersionFechaFinal.BindearPropiedadControl = Nothing
        Me.chbVersionFechaFinal.BindearPropiedadEntidad = Nothing
        Me.chbVersionFechaFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVersionFechaFinal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVersionFechaFinal.IsPK = False
        Me.chbVersionFechaFinal.IsRequired = False
        Me.chbVersionFechaFinal.Key = Nothing
        Me.chbVersionFechaFinal.LabelAsoc = Nothing
        Me.chbVersionFechaFinal.Location = New System.Drawing.Point(228, 106)
        Me.chbVersionFechaFinal.Name = "chbVersionFechaFinal"
        Me.chbVersionFechaFinal.Size = New System.Drawing.Size(73, 17)
        Me.chbVersionFechaFinal.TabIndex = 13
        Me.chbVersionFechaFinal.Text = "F. Versión"
        '
        'dtpVersionFechaFinal
        '
        Me.dtpVersionFechaFinal.BindearPropiedadControl = "Value"
        Me.dtpVersionFechaFinal.BindearPropiedadEntidad = "VersionFecha"
        Me.dtpVersionFechaFinal.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpVersionFechaFinal.Enabled = False
        Me.dtpVersionFechaFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpVersionFechaFinal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpVersionFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVersionFechaFinal.IsPK = False
        Me.dtpVersionFechaFinal.IsRequired = False
        Me.dtpVersionFechaFinal.Key = ""
        Me.dtpVersionFechaFinal.LabelAsoc = Nothing
        Me.dtpVersionFechaFinal.Location = New System.Drawing.Point(346, 108)
        Me.dtpVersionFechaFinal.Name = "dtpVersionFechaFinal"
        Me.dtpVersionFechaFinal.Size = New System.Drawing.Size(131, 20)
        Me.dtpVersionFechaFinal.TabIndex = 14
        '
        'chbVersionFinal
        '
        Me.chbVersionFinal.AutoSize = True
        Me.chbVersionFinal.BindearPropiedadControl = Nothing
        Me.chbVersionFinal.BindearPropiedadEntidad = Nothing
        Me.chbVersionFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVersionFinal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVersionFinal.IsPK = False
        Me.chbVersionFinal.IsRequired = False
        Me.chbVersionFinal.Key = Nothing
        Me.chbVersionFinal.LabelAsoc = Nothing
        Me.chbVersionFinal.Location = New System.Drawing.Point(8, 80)
        Me.chbVersionFinal.Name = "chbVersionFinal"
        Me.chbVersionFinal.Size = New System.Drawing.Size(61, 17)
        Me.chbVersionFinal.TabIndex = 8
        Me.chbVersionFinal.Text = "Versión"
        '
        'chbEstadoVersion
        '
        Me.chbEstadoVersion.AutoSize = True
        Me.chbEstadoVersion.BindearPropiedadControl = Nothing
        Me.chbEstadoVersion.BindearPropiedadEntidad = Nothing
        Me.chbEstadoVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstadoVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstadoVersion.IsPK = False
        Me.chbEstadoVersion.IsRequired = False
        Me.chbEstadoVersion.Key = Nothing
        Me.chbEstadoVersion.LabelAsoc = Nothing
        Me.chbEstadoVersion.Location = New System.Drawing.Point(8, 54)
        Me.chbEstadoVersion.Name = "chbEstadoVersion"
        Me.chbEstadoVersion.Size = New System.Drawing.Size(59, 17)
        Me.chbEstadoVersion.TabIndex = 4
        Me.chbEstadoVersion.Text = "Estado"
        Me.chbEstadoVersion.UseVisualStyleBackColor = True
        '
        'cmbMedioVersion
        '
        Me.cmbMedioVersion.BindearPropiedadControl = "SelectedValue"
        Me.cmbMedioVersion.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
        Me.cmbMedioVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedioVersion.Enabled = False
        Me.cmbMedioVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMedioVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMedioVersion.FormattingEnabled = True
        Me.cmbMedioVersion.IsPK = False
        Me.cmbMedioVersion.IsRequired = False
        Me.cmbMedioVersion.Key = Nothing
        Me.cmbMedioVersion.LabelAsoc = Nothing
        Me.cmbMedioVersion.Location = New System.Drawing.Point(77, 107)
        Me.cmbMedioVersion.Name = "cmbMedioVersion"
        Me.cmbMedioVersion.Size = New System.Drawing.Size(140, 21)
        Me.cmbMedioVersion.TabIndex = 12
        '
        'cmbPriorizadoVersion
        '
        Me.cmbPriorizadoVersion.BindearPropiedadControl = "SelectedValue"
        Me.cmbPriorizadoVersion.BindearPropiedadEntidad = "PrioridadNovedad.IdPrioridadNovedad"
        Me.cmbPriorizadoVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPriorizadoVersion.Enabled = False
        Me.cmbPriorizadoVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPriorizadoVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPriorizadoVersion.FormattingEnabled = True
        Me.cmbPriorizadoVersion.IsPK = False
        Me.cmbPriorizadoVersion.IsRequired = False
        Me.cmbPriorizadoVersion.Key = Nothing
        Me.cmbPriorizadoVersion.LabelAsoc = Nothing
        Me.cmbPriorizadoVersion.Location = New System.Drawing.Point(342, 26)
        Me.cmbPriorizadoVersion.Name = "cmbPriorizadoVersion"
        Me.cmbPriorizadoVersion.Size = New System.Drawing.Size(82, 21)
        Me.cmbPriorizadoVersion.TabIndex = 3
        '
        'cmbPrioridadNovedadVersion
        '
        Me.cmbPrioridadNovedadVersion.BindearPropiedadControl = "SelectedValue"
        Me.cmbPrioridadNovedadVersion.BindearPropiedadEntidad = "PrioridadNovedad.IdPrioridadNovedad"
        Me.cmbPrioridadNovedadVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrioridadNovedadVersion.Enabled = False
        Me.cmbPrioridadNovedadVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPrioridadNovedadVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPrioridadNovedadVersion.FormattingEnabled = True
        Me.cmbPrioridadNovedadVersion.IsPK = False
        Me.cmbPrioridadNovedadVersion.IsRequired = False
        Me.cmbPrioridadNovedadVersion.Key = Nothing
        Me.cmbPrioridadNovedadVersion.LabelAsoc = Nothing
        Me.cmbPrioridadNovedadVersion.Location = New System.Drawing.Point(77, 26)
        Me.cmbPrioridadNovedadVersion.Name = "cmbPrioridadNovedadVersion"
        Me.cmbPrioridadNovedadVersion.Size = New System.Drawing.Size(140, 21)
        Me.cmbPrioridadNovedadVersion.TabIndex = 1
        '
        'cmbEstadoVersion
        '
        Me.cmbEstadoVersion.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoVersion.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
        Me.cmbEstadoVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoVersion.Enabled = False
        Me.cmbEstadoVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoVersion.FormattingEnabled = True
        Me.cmbEstadoVersion.IsPK = False
        Me.cmbEstadoVersion.IsRequired = False
        Me.cmbEstadoVersion.Key = Nothing
        Me.cmbEstadoVersion.LabelAsoc = Nothing
        Me.cmbEstadoVersion.Location = New System.Drawing.Point(77, 53)
        Me.cmbEstadoVersion.Name = "cmbEstadoVersion"
        Me.cmbEstadoVersion.Size = New System.Drawing.Size(140, 21)
        Me.cmbEstadoVersion.TabIndex = 5
        '
        'tbpCambios
        '
        Me.tbpCambios.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCambios.Controls.Add(Me.chbMetodoNuevo)
        Me.tbpCambios.Controls.Add(Me.cmbMetodoNuevo)
        Me.tbpCambios.Controls.Add(Me.bscCodigoProyectoNuevo)
        Me.tbpCambios.Controls.Add(Me.bscProyectoNuevo)
        Me.tbpCambios.Controls.Add(Me.chbProyectoNuevo)
        Me.tbpCambios.Controls.Add(Me.bscCodigoFuncionNuevo)
        Me.tbpCambios.Controls.Add(Me.bscFuncionNuevo)
        Me.tbpCambios.Controls.Add(Me.chbFuncionNuevo)
        Me.tbpCambios.Controls.Add(Me.cmbAplicacionNueva)
        Me.tbpCambios.Controls.Add(Me.chbAplicacionNueva)
        Me.tbpCambios.Controls.Add(Me.bscNombreClienteNuevo)
        Me.tbpCambios.Controls.Add(Me.bscCodClienteNuevo)
        Me.tbpCambios.Controls.Add(Me.chbClienteNuevo)
        Me.tbpCambios.Controls.Add(Me.chbCategoriaNuevo)
        Me.tbpCambios.Controls.Add(Me.cmbCategoriaNovedadNuevo)
        Me.tbpCambios.Controls.Add(Me.chbColorNuevo)
        Me.tbpCambios.Controls.Add(Me.pnlColorNuevo)
        Me.tbpCambios.Controls.Add(Me.chbMedioNuevo)
        Me.tbpCambios.Controls.Add(Me.cmbMedioNuevo)
        Me.tbpCambios.Controls.Add(Me.chbFechaProximoContacto)
        Me.tbpCambios.Controls.Add(Me.dtpFechaProximoContacto)
        Me.tbpCambios.Controls.Add(Me.chbRequiereTesteoNuevo)
        Me.tbpCambios.Controls.Add(Me.chbPriorizadoNuevo)
        Me.tbpCambios.Controls.Add(Me.cmbRequiereTesteoNuevo)
        Me.tbpCambios.Controls.Add(Me.cmbPriorizadoNuevo)
        Me.tbpCambios.Controls.Add(Me.chbPrioridadNuevo)
        Me.tbpCambios.Controls.Add(Me.cmbPrioridadNovedadNuevo)
        Me.tbpCambios.Controls.Add(Me.chbAvanceNuevo)
        Me.tbpCambios.Controls.Add(Me.txtAvanceNuevo)
        Me.tbpCambios.Controls.Add(Me.txtVersionNuevo)
        Me.tbpCambios.Controls.Add(Me.chbVersionFechaNuevo)
        Me.tbpCambios.Controls.Add(Me.dtpVersionFechaNuevo)
        Me.tbpCambios.Controls.Add(Me.chbVersionNuevo)
        Me.tbpCambios.Controls.Add(Me.chbAsignadoANuevo)
        Me.tbpCambios.Controls.Add(Me.chbEstadoNuevo)
        Me.tbpCambios.Controls.Add(Me.cmbAsignadoANuevo)
        Me.tbpCambios.Controls.Add(Me.cmbEstadoNuevo)
        Me.tbpCambios.Location = New System.Drawing.Point(4, 22)
        Me.tbpCambios.Name = "tbpCambios"
        Me.tbpCambios.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCambios.Size = New System.Drawing.Size(976, 203)
        Me.tbpCambios.TabIndex = 1
        Me.tbpCambios.Text = "Cambios"
        '
        'chbMetodoNuevo
        '
        Me.chbMetodoNuevo.AutoSize = True
        Me.chbMetodoNuevo.BindearPropiedadControl = Nothing
        Me.chbMetodoNuevo.BindearPropiedadEntidad = Nothing
        Me.chbMetodoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMetodoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMetodoNuevo.IsPK = False
        Me.chbMetodoNuevo.IsRequired = False
        Me.chbMetodoNuevo.Key = Nothing
        Me.chbMetodoNuevo.LabelAsoc = Nothing
        Me.chbMetodoNuevo.Location = New System.Drawing.Point(254, 175)
        Me.chbMetodoNuevo.Name = "chbMetodoNuevo"
        Me.chbMetodoNuevo.Size = New System.Drawing.Size(62, 17)
        Me.chbMetodoNuevo.TabIndex = 25
        Me.chbMetodoNuevo.Text = "Método"
        Me.chbMetodoNuevo.UseVisualStyleBackColor = True
        '
        'cmbMetodoNuevo
        '
        Me.cmbMetodoNuevo.BindearPropiedadControl = "SelectedValue"
        Me.cmbMetodoNuevo.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
        Me.cmbMetodoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMetodoNuevo.Enabled = False
        Me.cmbMetodoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMetodoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMetodoNuevo.FormattingEnabled = True
        Me.cmbMetodoNuevo.IsPK = False
        Me.cmbMetodoNuevo.IsRequired = False
        Me.cmbMetodoNuevo.Key = Nothing
        Me.cmbMetodoNuevo.LabelAsoc = Me.chbMetodoNuevo
        Me.cmbMetodoNuevo.Location = New System.Drawing.Point(365, 173)
        Me.cmbMetodoNuevo.Name = "cmbMetodoNuevo"
        Me.cmbMetodoNuevo.Size = New System.Drawing.Size(146, 21)
        Me.cmbMetodoNuevo.TabIndex = 26
        '
        'bscCodigoProyectoNuevo
        '
        Me.bscCodigoProyectoNuevo.ActivarFiltroEnGrilla = True
        Me.bscCodigoProyectoNuevo.BindearPropiedadControl = Nothing
        Me.bscCodigoProyectoNuevo.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProyectoNuevo.ConfigBuscador = Nothing
        Me.bscCodigoProyectoNuevo.Datos = Nothing
        Me.bscCodigoProyectoNuevo.Enabled = False
        Me.bscCodigoProyectoNuevo.FilaDevuelta = Nothing
        Me.bscCodigoProyectoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProyectoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProyectoNuevo.IsDecimal = False
        Me.bscCodigoProyectoNuevo.IsNumber = True
        Me.bscCodigoProyectoNuevo.IsPK = False
        Me.bscCodigoProyectoNuevo.IsRequired = False
        Me.bscCodigoProyectoNuevo.Key = ""
        Me.bscCodigoProyectoNuevo.LabelAsoc = Me.chbProyectoNuevo
        Me.bscCodigoProyectoNuevo.Location = New System.Drawing.Point(596, 38)
        Me.bscCodigoProyectoNuevo.MaxLengh = "32767"
        Me.bscCodigoProyectoNuevo.Name = "bscCodigoProyectoNuevo"
        Me.bscCodigoProyectoNuevo.Permitido = True
        Me.bscCodigoProyectoNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProyectoNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProyectoNuevo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProyectoNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProyectoNuevo.Selecciono = False
        Me.bscCodigoProyectoNuevo.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProyectoNuevo.TabIndex = 31
        '
        'chbProyectoNuevo
        '
        Me.chbProyectoNuevo.AutoSize = True
        Me.chbProyectoNuevo.BindearPropiedadControl = Nothing
        Me.chbProyectoNuevo.BindearPropiedadEntidad = Nothing
        Me.chbProyectoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProyectoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProyectoNuevo.IsPK = False
        Me.chbProyectoNuevo.IsRequired = False
        Me.chbProyectoNuevo.Key = Nothing
        Me.chbProyectoNuevo.LabelAsoc = Nothing
        Me.chbProyectoNuevo.Location = New System.Drawing.Point(531, 41)
        Me.chbProyectoNuevo.Name = "chbProyectoNuevo"
        Me.chbProyectoNuevo.Size = New System.Drawing.Size(68, 17)
        Me.chbProyectoNuevo.TabIndex = 30
        Me.chbProyectoNuevo.Text = "Proyecto"
        '
        'bscProyectoNuevo
        '
        Me.bscProyectoNuevo.ActivarFiltroEnGrilla = True
        Me.bscProyectoNuevo.AutoSize = True
        Me.bscProyectoNuevo.BindearPropiedadControl = Nothing
        Me.bscProyectoNuevo.BindearPropiedadEntidad = Nothing
        Me.bscProyectoNuevo.ConfigBuscador = Nothing
        Me.bscProyectoNuevo.Datos = Nothing
        Me.bscProyectoNuevo.Enabled = False
        Me.bscProyectoNuevo.FilaDevuelta = Nothing
        Me.bscProyectoNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProyectoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProyectoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProyectoNuevo.IsDecimal = False
        Me.bscProyectoNuevo.IsNumber = False
        Me.bscProyectoNuevo.IsPK = False
        Me.bscProyectoNuevo.IsRequired = False
        Me.bscProyectoNuevo.Key = ""
        Me.bscProyectoNuevo.LabelAsoc = Me.chbProyectoNuevo
        Me.bscProyectoNuevo.Location = New System.Drawing.Point(690, 38)
        Me.bscProyectoNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProyectoNuevo.MaxLengh = "32767"
        Me.bscProyectoNuevo.Name = "bscProyectoNuevo"
        Me.bscProyectoNuevo.Permitido = True
        Me.bscProyectoNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProyectoNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProyectoNuevo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProyectoNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProyectoNuevo.Selecciono = False
        Me.bscProyectoNuevo.Size = New System.Drawing.Size(277, 23)
        Me.bscProyectoNuevo.TabIndex = 32
        '
        'bscCodigoFuncionNuevo
        '
        Me.bscCodigoFuncionNuevo.ActivarFiltroEnGrilla = True
        Me.bscCodigoFuncionNuevo.BindearPropiedadControl = Nothing
        Me.bscCodigoFuncionNuevo.BindearPropiedadEntidad = Nothing
        Me.bscCodigoFuncionNuevo.ConfigBuscador = Nothing
        Me.bscCodigoFuncionNuevo.Datos = Nothing
        Me.bscCodigoFuncionNuevo.Enabled = False
        Me.bscCodigoFuncionNuevo.FilaDevuelta = Nothing
        Me.bscCodigoFuncionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoFuncionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoFuncionNuevo.IsDecimal = False
        Me.bscCodigoFuncionNuevo.IsNumber = False
        Me.bscCodigoFuncionNuevo.IsPK = False
        Me.bscCodigoFuncionNuevo.IsRequired = False
        Me.bscCodigoFuncionNuevo.Key = ""
        Me.bscCodigoFuncionNuevo.LabelAsoc = Me.chbFuncionNuevo
        Me.bscCodigoFuncionNuevo.Location = New System.Drawing.Point(596, 66)
        Me.bscCodigoFuncionNuevo.MaxLengh = "32767"
        Me.bscCodigoFuncionNuevo.Name = "bscCodigoFuncionNuevo"
        Me.bscCodigoFuncionNuevo.Permitido = True
        Me.bscCodigoFuncionNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoFuncionNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoFuncionNuevo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoFuncionNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoFuncionNuevo.Selecciono = False
        Me.bscCodigoFuncionNuevo.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoFuncionNuevo.TabIndex = 34
        '
        'chbFuncionNuevo
        '
        Me.chbFuncionNuevo.AutoSize = True
        Me.chbFuncionNuevo.BindearPropiedadControl = Nothing
        Me.chbFuncionNuevo.BindearPropiedadEntidad = Nothing
        Me.chbFuncionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFuncionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFuncionNuevo.IsPK = False
        Me.chbFuncionNuevo.IsRequired = False
        Me.chbFuncionNuevo.Key = Nothing
        Me.chbFuncionNuevo.LabelAsoc = Nothing
        Me.chbFuncionNuevo.Location = New System.Drawing.Point(531, 68)
        Me.chbFuncionNuevo.Name = "chbFuncionNuevo"
        Me.chbFuncionNuevo.Size = New System.Drawing.Size(64, 17)
        Me.chbFuncionNuevo.TabIndex = 33
        Me.chbFuncionNuevo.Text = "Función"
        Me.chbFuncionNuevo.UseVisualStyleBackColor = True
        '
        'bscFuncionNuevo
        '
        Me.bscFuncionNuevo.ActivarFiltroEnGrilla = True
        Me.bscFuncionNuevo.BindearPropiedadControl = Nothing
        Me.bscFuncionNuevo.BindearPropiedadEntidad = Nothing
        Me.bscFuncionNuevo.ConfigBuscador = Nothing
        Me.bscFuncionNuevo.Datos = Nothing
        Me.bscFuncionNuevo.Enabled = False
        Me.bscFuncionNuevo.FilaDevuelta = Nothing
        Me.bscFuncionNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscFuncionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscFuncionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscFuncionNuevo.IsDecimal = False
        Me.bscFuncionNuevo.IsNumber = False
        Me.bscFuncionNuevo.IsPK = False
        Me.bscFuncionNuevo.IsRequired = False
        Me.bscFuncionNuevo.Key = ""
        Me.bscFuncionNuevo.LabelAsoc = Me.chbFuncionNuevo
        Me.bscFuncionNuevo.Location = New System.Drawing.Point(690, 65)
        Me.bscFuncionNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.bscFuncionNuevo.MaxLengh = "32767"
        Me.bscFuncionNuevo.Name = "bscFuncionNuevo"
        Me.bscFuncionNuevo.Permitido = True
        Me.bscFuncionNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscFuncionNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscFuncionNuevo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscFuncionNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscFuncionNuevo.Selecciono = False
        Me.bscFuncionNuevo.Size = New System.Drawing.Size(279, 23)
        Me.bscFuncionNuevo.TabIndex = 35
        '
        'cmbAplicacionNueva
        '
        Me.cmbAplicacionNueva.BindearPropiedadControl = "SelectedValue"
        Me.cmbAplicacionNueva.BindearPropiedadEntidad = "CategoriaNovedad.IdCategoriaNovedad"
        Me.cmbAplicacionNueva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAplicacionNueva.Enabled = False
        Me.cmbAplicacionNueva.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAplicacionNueva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAplicacionNueva.FormattingEnabled = True
        Me.cmbAplicacionNueva.IsPK = False
        Me.cmbAplicacionNueva.IsRequired = False
        Me.cmbAplicacionNueva.Key = Nothing
        Me.cmbAplicacionNueva.LabelAsoc = Me.chbAplicacionNueva
        Me.cmbAplicacionNueva.Location = New System.Drawing.Point(365, 146)
        Me.cmbAplicacionNueva.Name = "cmbAplicacionNueva"
        Me.cmbAplicacionNueva.Size = New System.Drawing.Size(146, 21)
        Me.cmbAplicacionNueva.TabIndex = 22
        '
        'chbAplicacionNueva
        '
        Me.chbAplicacionNueva.AutoSize = True
        Me.chbAplicacionNueva.BindearPropiedadControl = Nothing
        Me.chbAplicacionNueva.BindearPropiedadEntidad = Nothing
        Me.chbAplicacionNueva.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAplicacionNueva.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAplicacionNueva.IsPK = False
        Me.chbAplicacionNueva.IsRequired = False
        Me.chbAplicacionNueva.Key = Nothing
        Me.chbAplicacionNueva.LabelAsoc = Nothing
        Me.chbAplicacionNueva.Location = New System.Drawing.Point(254, 148)
        Me.chbAplicacionNueva.Name = "chbAplicacionNueva"
        Me.chbAplicacionNueva.Size = New System.Drawing.Size(75, 17)
        Me.chbAplicacionNueva.TabIndex = 21
        Me.chbAplicacionNueva.Text = "Aplicación"
        Me.chbAplicacionNueva.UseVisualStyleBackColor = True
        '
        'bscNombreClienteNuevo
        '
        Me.bscNombreClienteNuevo.ActivarFiltroEnGrilla = True
        Me.bscNombreClienteNuevo.AutoSize = True
        Me.bscNombreClienteNuevo.BindearPropiedadControl = Nothing
        Me.bscNombreClienteNuevo.BindearPropiedadEntidad = Nothing
        Me.bscNombreClienteNuevo.ConfigBuscador = Nothing
        Me.bscNombreClienteNuevo.Datos = Nothing
        Me.bscNombreClienteNuevo.Enabled = False
        Me.bscNombreClienteNuevo.FilaDevuelta = Nothing
        Me.bscNombreClienteNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreClienteNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreClienteNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreClienteNuevo.IsDecimal = False
        Me.bscNombreClienteNuevo.IsNumber = False
        Me.bscNombreClienteNuevo.IsPK = False
        Me.bscNombreClienteNuevo.IsRequired = False
        Me.bscNombreClienteNuevo.Key = ""
        Me.bscNombreClienteNuevo.LabelAsoc = Me.chbClienteNuevo
        Me.bscNombreClienteNuevo.Location = New System.Drawing.Point(690, 10)
        Me.bscNombreClienteNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreClienteNuevo.MaxLengh = "32767"
        Me.bscNombreClienteNuevo.Name = "bscNombreClienteNuevo"
        Me.bscNombreClienteNuevo.Permitido = True
        Me.bscNombreClienteNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreClienteNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreClienteNuevo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreClienteNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreClienteNuevo.Selecciono = False
        Me.bscNombreClienteNuevo.Size = New System.Drawing.Size(279, 23)
        Me.bscNombreClienteNuevo.TabIndex = 29
        '
        'chbClienteNuevo
        '
        Me.chbClienteNuevo.AutoSize = True
        Me.chbClienteNuevo.BindearPropiedadControl = Nothing
        Me.chbClienteNuevo.BindearPropiedadEntidad = Nothing
        Me.chbClienteNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbClienteNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbClienteNuevo.IsPK = False
        Me.chbClienteNuevo.IsRequired = False
        Me.chbClienteNuevo.Key = Nothing
        Me.chbClienteNuevo.LabelAsoc = Nothing
        Me.chbClienteNuevo.Location = New System.Drawing.Point(531, 13)
        Me.chbClienteNuevo.Name = "chbClienteNuevo"
        Me.chbClienteNuevo.Size = New System.Drawing.Size(58, 17)
        Me.chbClienteNuevo.TabIndex = 27
        Me.chbClienteNuevo.Text = "Cliente"
        Me.chbClienteNuevo.UseVisualStyleBackColor = True
        '
        'bscCodClienteNuevo
        '
        Me.bscCodClienteNuevo.ActivarFiltroEnGrilla = True
        Me.bscCodClienteNuevo.BindearPropiedadControl = Nothing
        Me.bscCodClienteNuevo.BindearPropiedadEntidad = Nothing
        Me.bscCodClienteNuevo.ConfigBuscador = Nothing
        Me.bscCodClienteNuevo.Datos = Nothing
        Me.bscCodClienteNuevo.Enabled = False
        Me.bscCodClienteNuevo.FilaDevuelta = Nothing
        Me.bscCodClienteNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodClienteNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodClienteNuevo.IsDecimal = False
        Me.bscCodClienteNuevo.IsNumber = False
        Me.bscCodClienteNuevo.IsPK = False
        Me.bscCodClienteNuevo.IsRequired = False
        Me.bscCodClienteNuevo.Key = ""
        Me.bscCodClienteNuevo.LabelAsoc = Me.chbClienteNuevo
        Me.bscCodClienteNuevo.Location = New System.Drawing.Point(596, 10)
        Me.bscCodClienteNuevo.MaxLengh = "32767"
        Me.bscCodClienteNuevo.Name = "bscCodClienteNuevo"
        Me.bscCodClienteNuevo.Permitido = True
        Me.bscCodClienteNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodClienteNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodClienteNuevo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodClienteNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodClienteNuevo.Selecciono = False
        Me.bscCodClienteNuevo.Size = New System.Drawing.Size(90, 23)
        Me.bscCodClienteNuevo.TabIndex = 28
        '
        'chbCategoriaNuevo
        '
        Me.chbCategoriaNuevo.AutoSize = True
        Me.chbCategoriaNuevo.BindearPropiedadControl = Nothing
        Me.chbCategoriaNuevo.BindearPropiedadEntidad = Nothing
        Me.chbCategoriaNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoriaNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoriaNuevo.IsPK = False
        Me.chbCategoriaNuevo.IsRequired = False
        Me.chbCategoriaNuevo.Key = Nothing
        Me.chbCategoriaNuevo.LabelAsoc = Nothing
        Me.chbCategoriaNuevo.Location = New System.Drawing.Point(254, 121)
        Me.chbCategoriaNuevo.Name = "chbCategoriaNuevo"
        Me.chbCategoriaNuevo.Size = New System.Drawing.Size(71, 17)
        Me.chbCategoriaNuevo.TabIndex = 17
        Me.chbCategoriaNuevo.Text = "Categoria"
        Me.chbCategoriaNuevo.UseVisualStyleBackColor = True
        '
        'cmbCategoriaNovedadNuevo
        '
        Me.cmbCategoriaNovedadNuevo.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoriaNovedadNuevo.BindearPropiedadEntidad = "CategoriaNovedad.IdCategoriaNovedad"
        Me.cmbCategoriaNovedadNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriaNovedadNuevo.Enabled = False
        Me.cmbCategoriaNovedadNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriaNovedadNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriaNovedadNuevo.FormattingEnabled = True
        Me.cmbCategoriaNovedadNuevo.IsPK = False
        Me.cmbCategoriaNovedadNuevo.IsRequired = False
        Me.cmbCategoriaNovedadNuevo.Key = Nothing
        Me.cmbCategoriaNovedadNuevo.LabelAsoc = Me.chbCategoriaNuevo
        Me.cmbCategoriaNovedadNuevo.Location = New System.Drawing.Point(365, 119)
        Me.cmbCategoriaNovedadNuevo.Name = "cmbCategoriaNovedadNuevo"
        Me.cmbCategoriaNovedadNuevo.Size = New System.Drawing.Size(146, 21)
        Me.cmbCategoriaNovedadNuevo.TabIndex = 18
        '
        'chbColorNuevo
        '
        Me.chbColorNuevo.AutoSize = True
        Me.chbColorNuevo.BindearPropiedadControl = Nothing
        Me.chbColorNuevo.BindearPropiedadEntidad = Nothing
        Me.chbColorNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbColorNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbColorNuevo.IsPK = False
        Me.chbColorNuevo.IsRequired = False
        Me.chbColorNuevo.Key = Nothing
        Me.chbColorNuevo.LabelAsoc = Nothing
        Me.chbColorNuevo.Location = New System.Drawing.Point(254, 41)
        Me.chbColorNuevo.Name = "chbColorNuevo"
        Me.chbColorNuevo.Size = New System.Drawing.Size(50, 17)
        Me.chbColorNuevo.TabIndex = 6
        Me.chbColorNuevo.Text = "Color"
        Me.chbColorNuevo.UseVisualStyleBackColor = True
        '
        'pnlColorNuevo
        '
        Me.pnlColorNuevo.BackColor = System.Drawing.SystemColors.Control
        Me.pnlColorNuevo.Controls.Add(Me.btnColorNuevo)
        Me.pnlColorNuevo.Location = New System.Drawing.Point(365, 38)
        Me.pnlColorNuevo.Name = "pnlColorNuevo"
        Me.pnlColorNuevo.Size = New System.Drawing.Size(26, 21)
        Me.pnlColorNuevo.TabIndex = 7
        '
        'btnColorNuevo
        '
        Me.btnColorNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColorNuevo.Location = New System.Drawing.Point(1, 0)
        Me.btnColorNuevo.Margin = New System.Windows.Forms.Padding(0)
        Me.btnColorNuevo.Name = "btnColorNuevo"
        Me.btnColorNuevo.Size = New System.Drawing.Size(24, 20)
        Me.btnColorNuevo.TabIndex = 0
        Me.btnColorNuevo.TabStop = False
        Me.btnColorNuevo.UseVisualStyleBackColor = False
        '
        'chbMedioNuevo
        '
        Me.chbMedioNuevo.AutoSize = True
        Me.chbMedioNuevo.BindearPropiedadControl = Nothing
        Me.chbMedioNuevo.BindearPropiedadEntidad = Nothing
        Me.chbMedioNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMedioNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMedioNuevo.IsPK = False
        Me.chbMedioNuevo.IsRequired = False
        Me.chbMedioNuevo.Key = Nothing
        Me.chbMedioNuevo.LabelAsoc = Nothing
        Me.chbMedioNuevo.Location = New System.Drawing.Point(9, 121)
        Me.chbMedioNuevo.Name = "chbMedioNuevo"
        Me.chbMedioNuevo.Size = New System.Drawing.Size(55, 17)
        Me.chbMedioNuevo.TabIndex = 15
        Me.chbMedioNuevo.Text = "Medio"
        Me.chbMedioNuevo.UseVisualStyleBackColor = True
        '
        'cmbMedioNuevo
        '
        Me.cmbMedioNuevo.BindearPropiedadControl = "SelectedValue"
        Me.cmbMedioNuevo.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
        Me.cmbMedioNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedioNuevo.Enabled = False
        Me.cmbMedioNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMedioNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMedioNuevo.FormattingEnabled = True
        Me.cmbMedioNuevo.IsPK = False
        Me.cmbMedioNuevo.IsRequired = False
        Me.cmbMedioNuevo.Key = Nothing
        Me.cmbMedioNuevo.LabelAsoc = Me.chbMedioNuevo
        Me.cmbMedioNuevo.Location = New System.Drawing.Point(100, 119)
        Me.cmbMedioNuevo.Name = "cmbMedioNuevo"
        Me.cmbMedioNuevo.Size = New System.Drawing.Size(140, 21)
        Me.cmbMedioNuevo.TabIndex = 16
        '
        'chbFechaProximoContacto
        '
        Me.chbFechaProximoContacto.AutoSize = True
        Me.chbFechaProximoContacto.BindearPropiedadControl = Nothing
        Me.chbFechaProximoContacto.BindearPropiedadEntidad = Nothing
        Me.chbFechaProximoContacto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaProximoContacto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaProximoContacto.IsPK = False
        Me.chbFechaProximoContacto.IsRequired = False
        Me.chbFechaProximoContacto.Key = Nothing
        Me.chbFechaProximoContacto.LabelAsoc = Nothing
        Me.chbFechaProximoContacto.Location = New System.Drawing.Point(254, 68)
        Me.chbFechaProximoContacto.Name = "chbFechaProximoContacto"
        Me.chbFechaProximoContacto.Size = New System.Drawing.Size(108, 17)
        Me.chbFechaProximoContacto.TabIndex = 9
        Me.chbFechaProximoContacto.Text = "Próximo contacto"
        '
        'dtpFechaProximoContacto
        '
        Me.dtpFechaProximoContacto.BindearPropiedadControl = "Value"
        Me.dtpFechaProximoContacto.BindearPropiedadEntidad = "FechaProximoContacto"
        Me.dtpFechaProximoContacto.Checked = False
        Me.dtpFechaProximoContacto.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaProximoContacto.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaProximoContacto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaProximoContacto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaProximoContacto.IsPK = False
        Me.dtpFechaProximoContacto.IsRequired = False
        Me.dtpFechaProximoContacto.Key = ""
        Me.dtpFechaProximoContacto.LabelAsoc = Me.chbFechaProximoContacto
        Me.dtpFechaProximoContacto.Location = New System.Drawing.Point(365, 66)
        Me.dtpFechaProximoContacto.Name = "dtpFechaProximoContacto"
        Me.dtpFechaProximoContacto.ShowCheckBox = True
        Me.dtpFechaProximoContacto.Size = New System.Drawing.Size(156, 20)
        Me.dtpFechaProximoContacto.TabIndex = 10
        '
        'chbRequiereTesteoNuevo
        '
        Me.chbRequiereTesteoNuevo.AutoSize = True
        Me.chbRequiereTesteoNuevo.BindearPropiedadControl = Nothing
        Me.chbRequiereTesteoNuevo.BindearPropiedadEntidad = Nothing
        Me.chbRequiereTesteoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereTesteoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereTesteoNuevo.IsPK = False
        Me.chbRequiereTesteoNuevo.IsRequired = False
        Me.chbRequiereTesteoNuevo.Key = Nothing
        Me.chbRequiereTesteoNuevo.LabelAsoc = Nothing
        Me.chbRequiereTesteoNuevo.Location = New System.Drawing.Point(9, 175)
        Me.chbRequiereTesteoNuevo.Name = "chbRequiereTesteoNuevo"
        Me.chbRequiereTesteoNuevo.Size = New System.Drawing.Size(85, 17)
        Me.chbRequiereTesteoNuevo.TabIndex = 23
        Me.chbRequiereTesteoNuevo.Text = "Req. Testeo"
        Me.chbRequiereTesteoNuevo.UseVisualStyleBackColor = True
        '
        'chbPriorizadoNuevo
        '
        Me.chbPriorizadoNuevo.AutoSize = True
        Me.chbPriorizadoNuevo.BindearPropiedadControl = Nothing
        Me.chbPriorizadoNuevo.BindearPropiedadEntidad = Nothing
        Me.chbPriorizadoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPriorizadoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPriorizadoNuevo.IsPK = False
        Me.chbPriorizadoNuevo.IsRequired = False
        Me.chbPriorizadoNuevo.Key = Nothing
        Me.chbPriorizadoNuevo.LabelAsoc = Nothing
        Me.chbPriorizadoNuevo.Location = New System.Drawing.Point(9, 148)
        Me.chbPriorizadoNuevo.Name = "chbPriorizadoNuevo"
        Me.chbPriorizadoNuevo.Size = New System.Drawing.Size(72, 17)
        Me.chbPriorizadoNuevo.TabIndex = 19
        Me.chbPriorizadoNuevo.Text = "Priorizado"
        Me.chbPriorizadoNuevo.UseVisualStyleBackColor = True
        '
        'cmbRequiereTesteoNuevo
        '
        Me.cmbRequiereTesteoNuevo.BindearPropiedadControl = "SelectedValue"
        Me.cmbRequiereTesteoNuevo.BindearPropiedadEntidad = "PrioridadNovedad.IdPrioridadNovedad"
        Me.cmbRequiereTesteoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRequiereTesteoNuevo.Enabled = False
        Me.cmbRequiereTesteoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRequiereTesteoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRequiereTesteoNuevo.FormattingEnabled = True
        Me.cmbRequiereTesteoNuevo.IsPK = False
        Me.cmbRequiereTesteoNuevo.IsRequired = False
        Me.cmbRequiereTesteoNuevo.Key = Nothing
        Me.cmbRequiereTesteoNuevo.LabelAsoc = Me.chbRequiereTesteoNuevo
        Me.cmbRequiereTesteoNuevo.Location = New System.Drawing.Point(100, 173)
        Me.cmbRequiereTesteoNuevo.Name = "cmbRequiereTesteoNuevo"
        Me.cmbRequiereTesteoNuevo.Size = New System.Drawing.Size(82, 21)
        Me.cmbRequiereTesteoNuevo.TabIndex = 24
        '
        'cmbPriorizadoNuevo
        '
        Me.cmbPriorizadoNuevo.BindearPropiedadControl = "SelectedValue"
        Me.cmbPriorizadoNuevo.BindearPropiedadEntidad = "PrioridadNovedad.IdPrioridadNovedad"
        Me.cmbPriorizadoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPriorizadoNuevo.Enabled = False
        Me.cmbPriorizadoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPriorizadoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPriorizadoNuevo.FormattingEnabled = True
        Me.cmbPriorizadoNuevo.IsPK = False
        Me.cmbPriorizadoNuevo.IsRequired = False
        Me.cmbPriorizadoNuevo.Key = Nothing
        Me.cmbPriorizadoNuevo.LabelAsoc = Me.chbPriorizadoNuevo
        Me.cmbPriorizadoNuevo.Location = New System.Drawing.Point(100, 146)
        Me.cmbPriorizadoNuevo.Name = "cmbPriorizadoNuevo"
        Me.cmbPriorizadoNuevo.Size = New System.Drawing.Size(82, 21)
        Me.cmbPriorizadoNuevo.TabIndex = 20
        '
        'chbPrioridadNuevo
        '
        Me.chbPrioridadNuevo.AutoSize = True
        Me.chbPrioridadNuevo.BindearPropiedadControl = Nothing
        Me.chbPrioridadNuevo.BindearPropiedadEntidad = Nothing
        Me.chbPrioridadNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPrioridadNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPrioridadNuevo.IsPK = False
        Me.chbPrioridadNuevo.IsRequired = False
        Me.chbPrioridadNuevo.Key = Nothing
        Me.chbPrioridadNuevo.LabelAsoc = Nothing
        Me.chbPrioridadNuevo.Location = New System.Drawing.Point(9, 14)
        Me.chbPrioridadNuevo.Name = "chbPrioridadNuevo"
        Me.chbPrioridadNuevo.Size = New System.Drawing.Size(67, 17)
        Me.chbPrioridadNuevo.TabIndex = 0
        Me.chbPrioridadNuevo.Text = "Prioridad"
        Me.chbPrioridadNuevo.UseVisualStyleBackColor = True
        '
        'cmbPrioridadNovedadNuevo
        '
        Me.cmbPrioridadNovedadNuevo.BindearPropiedadControl = "SelectedValue"
        Me.cmbPrioridadNovedadNuevo.BindearPropiedadEntidad = "PrioridadNovedad.IdPrioridadNovedad"
        Me.cmbPrioridadNovedadNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrioridadNovedadNuevo.Enabled = False
        Me.cmbPrioridadNovedadNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPrioridadNovedadNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPrioridadNovedadNuevo.FormattingEnabled = True
        Me.cmbPrioridadNovedadNuevo.IsPK = False
        Me.cmbPrioridadNovedadNuevo.IsRequired = False
        Me.cmbPrioridadNovedadNuevo.Key = Nothing
        Me.cmbPrioridadNovedadNuevo.LabelAsoc = Me.chbPrioridadNuevo
        Me.cmbPrioridadNovedadNuevo.Location = New System.Drawing.Point(100, 12)
        Me.cmbPrioridadNovedadNuevo.Name = "cmbPrioridadNovedadNuevo"
        Me.cmbPrioridadNovedadNuevo.Size = New System.Drawing.Size(140, 21)
        Me.cmbPrioridadNovedadNuevo.TabIndex = 1
        '
        'chbAvanceNuevo
        '
        Me.chbAvanceNuevo.AutoSize = True
        Me.chbAvanceNuevo.BindearPropiedadControl = Nothing
        Me.chbAvanceNuevo.BindearPropiedadEntidad = Nothing
        Me.chbAvanceNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAvanceNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAvanceNuevo.IsPK = False
        Me.chbAvanceNuevo.IsRequired = False
        Me.chbAvanceNuevo.Key = Nothing
        Me.chbAvanceNuevo.LabelAsoc = Nothing
        Me.chbAvanceNuevo.Location = New System.Drawing.Point(254, 14)
        Me.chbAvanceNuevo.Name = "chbAvanceNuevo"
        Me.chbAvanceNuevo.Size = New System.Drawing.Size(34, 17)
        Me.chbAvanceNuevo.TabIndex = 2
        Me.chbAvanceNuevo.Text = "%"
        Me.chbAvanceNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAvanceNuevo
        '
        Me.txtAvanceNuevo.BindearPropiedadControl = "Text"
        Me.txtAvanceNuevo.BindearPropiedadEntidad = "Avance"
        Me.txtAvanceNuevo.Enabled = False
        Me.txtAvanceNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAvanceNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAvanceNuevo.Formato = "N2"
        Me.txtAvanceNuevo.IsDecimal = True
        Me.txtAvanceNuevo.IsNumber = True
        Me.txtAvanceNuevo.IsPK = False
        Me.txtAvanceNuevo.IsRequired = True
        Me.txtAvanceNuevo.Key = ""
        Me.txtAvanceNuevo.LabelAsoc = Me.chbAvanceNuevo
        Me.txtAvanceNuevo.Location = New System.Drawing.Point(365, 12)
        Me.txtAvanceNuevo.MaxLength = 6
        Me.txtAvanceNuevo.Name = "txtAvanceNuevo"
        Me.txtAvanceNuevo.Size = New System.Drawing.Size(45, 20)
        Me.txtAvanceNuevo.TabIndex = 3
        Me.txtAvanceNuevo.Text = "0.00"
        Me.txtAvanceNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVersionNuevo
        '
        Me.txtVersionNuevo.BindearPropiedadControl = "Text"
        Me.txtVersionNuevo.BindearPropiedadEntidad = "Version"
        Me.txtVersionNuevo.Enabled = False
        Me.txtVersionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVersionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVersionNuevo.Formato = ""
        Me.txtVersionNuevo.IsDecimal = False
        Me.txtVersionNuevo.IsNumber = False
        Me.txtVersionNuevo.IsPK = False
        Me.txtVersionNuevo.IsRequired = False
        Me.txtVersionNuevo.Key = ""
        Me.txtVersionNuevo.LabelAsoc = Me.chbVersionNuevo
        Me.txtVersionNuevo.Location = New System.Drawing.Point(100, 93)
        Me.txtVersionNuevo.MaxLength = 20
        Me.txtVersionNuevo.Name = "txtVersionNuevo"
        Me.txtVersionNuevo.Size = New System.Drawing.Size(113, 20)
        Me.txtVersionNuevo.TabIndex = 12
        '
        'chbVersionNuevo
        '
        Me.chbVersionNuevo.AutoSize = True
        Me.chbVersionNuevo.BindearPropiedadControl = Nothing
        Me.chbVersionNuevo.BindearPropiedadEntidad = Nothing
        Me.chbVersionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVersionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVersionNuevo.IsPK = False
        Me.chbVersionNuevo.IsRequired = False
        Me.chbVersionNuevo.Key = Nothing
        Me.chbVersionNuevo.LabelAsoc = Nothing
        Me.chbVersionNuevo.Location = New System.Drawing.Point(9, 96)
        Me.chbVersionNuevo.Name = "chbVersionNuevo"
        Me.chbVersionNuevo.Size = New System.Drawing.Size(61, 17)
        Me.chbVersionNuevo.TabIndex = 11
        Me.chbVersionNuevo.Text = "Versión"
        '
        'chbVersionFechaNuevo
        '
        Me.chbVersionFechaNuevo.AutoSize = True
        Me.chbVersionFechaNuevo.BindearPropiedadControl = Nothing
        Me.chbVersionFechaNuevo.BindearPropiedadEntidad = Nothing
        Me.chbVersionFechaNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVersionFechaNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVersionFechaNuevo.IsPK = False
        Me.chbVersionFechaNuevo.IsRequired = False
        Me.chbVersionFechaNuevo.Key = Nothing
        Me.chbVersionFechaNuevo.LabelAsoc = Nothing
        Me.chbVersionFechaNuevo.Location = New System.Drawing.Point(254, 95)
        Me.chbVersionFechaNuevo.Name = "chbVersionFechaNuevo"
        Me.chbVersionFechaNuevo.Size = New System.Drawing.Size(73, 17)
        Me.chbVersionFechaNuevo.TabIndex = 13
        Me.chbVersionFechaNuevo.Text = "F. Versión"
        '
        'dtpVersionFechaNuevo
        '
        Me.dtpVersionFechaNuevo.BindearPropiedadControl = "Value"
        Me.dtpVersionFechaNuevo.BindearPropiedadEntidad = "VersionFecha"
        Me.dtpVersionFechaNuevo.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpVersionFechaNuevo.Enabled = False
        Me.dtpVersionFechaNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpVersionFechaNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpVersionFechaNuevo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVersionFechaNuevo.IsPK = False
        Me.dtpVersionFechaNuevo.IsRequired = False
        Me.dtpVersionFechaNuevo.Key = ""
        Me.dtpVersionFechaNuevo.LabelAsoc = Me.chbVersionFechaNuevo
        Me.dtpVersionFechaNuevo.Location = New System.Drawing.Point(365, 93)
        Me.dtpVersionFechaNuevo.Name = "dtpVersionFechaNuevo"
        Me.dtpVersionFechaNuevo.Size = New System.Drawing.Size(131, 20)
        Me.dtpVersionFechaNuevo.TabIndex = 14
        '
        'chbAsignadoANuevo
        '
        Me.chbAsignadoANuevo.AutoSize = True
        Me.chbAsignadoANuevo.BindearPropiedadControl = Nothing
        Me.chbAsignadoANuevo.BindearPropiedadEntidad = Nothing
        Me.chbAsignadoANuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAsignadoANuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAsignadoANuevo.IsPK = False
        Me.chbAsignadoANuevo.IsRequired = False
        Me.chbAsignadoANuevo.Key = Nothing
        Me.chbAsignadoANuevo.LabelAsoc = Nothing
        Me.chbAsignadoANuevo.Location = New System.Drawing.Point(9, 68)
        Me.chbAsignadoANuevo.Name = "chbAsignadoANuevo"
        Me.chbAsignadoANuevo.Size = New System.Drawing.Size(79, 17)
        Me.chbAsignadoANuevo.TabIndex = 7
        Me.chbAsignadoANuevo.Text = "Asignado a"
        Me.chbAsignadoANuevo.UseVisualStyleBackColor = True
        '
        'chbEstadoNuevo
        '
        Me.chbEstadoNuevo.AutoSize = True
        Me.chbEstadoNuevo.BindearPropiedadControl = Nothing
        Me.chbEstadoNuevo.BindearPropiedadEntidad = Nothing
        Me.chbEstadoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstadoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstadoNuevo.IsPK = False
        Me.chbEstadoNuevo.IsRequired = False
        Me.chbEstadoNuevo.Key = Nothing
        Me.chbEstadoNuevo.LabelAsoc = Nothing
        Me.chbEstadoNuevo.Location = New System.Drawing.Point(9, 40)
        Me.chbEstadoNuevo.Name = "chbEstadoNuevo"
        Me.chbEstadoNuevo.Size = New System.Drawing.Size(59, 17)
        Me.chbEstadoNuevo.TabIndex = 4
        Me.chbEstadoNuevo.Text = "Estado"
        Me.chbEstadoNuevo.UseVisualStyleBackColor = True
        '
        'cmbAsignadoANuevo
        '
        Me.cmbAsignadoANuevo.BindearPropiedadControl = "SelectedValue"
        Me.cmbAsignadoANuevo.BindearPropiedadEntidad = "UsuarioAsignado.Usuario"
        Me.cmbAsignadoANuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAsignadoANuevo.Enabled = False
        Me.cmbAsignadoANuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAsignadoANuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAsignadoANuevo.FormattingEnabled = True
        Me.cmbAsignadoANuevo.IsPK = False
        Me.cmbAsignadoANuevo.IsRequired = False
        Me.cmbAsignadoANuevo.Key = Nothing
        Me.cmbAsignadoANuevo.LabelAsoc = Me.chbAsignadoANuevo
        Me.cmbAsignadoANuevo.Location = New System.Drawing.Point(100, 66)
        Me.cmbAsignadoANuevo.Name = "cmbAsignadoANuevo"
        Me.cmbAsignadoANuevo.Size = New System.Drawing.Size(140, 21)
        Me.cmbAsignadoANuevo.TabIndex = 8
        '
        'cmbEstadoNuevo
        '
        Me.cmbEstadoNuevo.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoNuevo.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
        Me.cmbEstadoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoNuevo.Enabled = False
        Me.cmbEstadoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoNuevo.FormattingEnabled = True
        Me.cmbEstadoNuevo.IsPK = False
        Me.cmbEstadoNuevo.IsRequired = False
        Me.cmbEstadoNuevo.Key = Nothing
        Me.cmbEstadoNuevo.LabelAsoc = Me.chbEstadoNuevo
        Me.cmbEstadoNuevo.Location = New System.Drawing.Point(100, 39)
        Me.cmbEstadoNuevo.Name = "cmbEstadoNuevo"
        Me.cmbEstadoNuevo.Size = New System.Drawing.Size(140, 21)
        Me.cmbEstadoNuevo.TabIndex = 5
        '
        'tbpFiltros
        '
        Me.tbpFiltros.BackColor = System.Drawing.SystemColors.Control
        Me.tbpFiltros.Controls.Add(Me.grbFiltros)
        Me.tbpFiltros.Location = New System.Drawing.Point(4, 22)
        Me.tbpFiltros.Name = "tbpFiltros"
        Me.tbpFiltros.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFiltros.Size = New System.Drawing.Size(976, 203)
        Me.tbpFiltros.TabIndex = 0
        Me.tbpFiltros.Text = "Filtros"
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.lblPriorizado)
        Me.grbFiltros.Controls.Add(Me.bscCodigoFuncion)
        Me.grbFiltros.Controls.Add(Me.cmbCategoriasNovedad)
        Me.grbFiltros.Controls.Add(Me.bscFuncion)
        Me.grbFiltros.Controls.Add(Me.chbFuncion)
        Me.grbFiltros.Controls.Add(Me.chbMetodoResolulcion)
        Me.grbFiltros.Controls.Add(Me.cmbMetodoResolulcion)
        Me.grbFiltros.Controls.Add(Me.cmbPriorizado)
        Me.grbFiltros.Controls.Add(Me.Label4)
        Me.grbFiltros.Controls.Add(Me.bscCodigoProyecto)
        Me.grbFiltros.Controls.Add(Me.bscProyecto)
        Me.grbFiltros.Controls.Add(Me.chbProyecto)
        Me.grbFiltros.Controls.Add(Me.lblDescripcion)
        Me.grbFiltros.Controls.Add(Me.txtDescripcion)
        Me.grbFiltros.Controls.Add(Me.chbVersion)
        Me.grbFiltros.Controls.Add(Me.cmbVersion)
        Me.grbFiltros.Controls.Add(Me.chbAplicacion)
        Me.grbFiltros.Controls.Add(Me.cmbAplicacion)
        Me.grbFiltros.Controls.Add(Me.chbFecha)
        Me.grbFiltros.Controls.Add(Me.cmbRevisionAdministrativa)
        Me.grbFiltros.Controls.Add(Me.lblRevisionAdministrativa)
        Me.grbFiltros.Controls.Add(Me.txtNumero)
        Me.grbFiltros.Controls.Add(Me.cmbFinalizado)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.rdbFechaProxContacto)
        Me.grbFiltros.Controls.Add(Me.rdbFechaNovedad)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.Label3)
        Me.grbFiltros.Controls.Add(Me.chbAsignadoA)
        Me.grbFiltros.Controls.Add(Me.chbProspecto)
        Me.grbFiltros.Controls.Add(Me.chbEstado)
        Me.grbFiltros.Controls.Add(Me.chbMedio)
        Me.grbFiltros.Controls.Add(Me.chbPrioridad)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.cmbTipoNovedad)
        Me.grbFiltros.Controls.Add(Me.cmbIdUsuarioAsignado)
        Me.grbFiltros.Controls.Add(Me.cmbEstadoNovedad)
        Me.grbFiltros.Controls.Add(Me.cmbMedio)
        Me.grbFiltros.Controls.Add(Me.cmbPrioridadNovedad)
        Me.grbFiltros.Controls.Add(Me.chbNumero)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.chbUsuario)
        Me.grbFiltros.Controls.Add(Me.cmbUsuarioAlta)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbFiltros.Location = New System.Drawing.Point(3, 3)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(970, 197)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        '
        'bscCodigoFuncion
        '
        Me.bscCodigoFuncion.ActivarFiltroEnGrilla = True
        Me.bscCodigoFuncion.BindearPropiedadControl = Nothing
        Me.bscCodigoFuncion.BindearPropiedadEntidad = Nothing
        Me.bscCodigoFuncion.ConfigBuscador = Nothing
        Me.bscCodigoFuncion.Datos = Nothing
        Me.bscCodigoFuncion.Enabled = False
        Me.bscCodigoFuncion.FilaDevuelta = Nothing
        Me.bscCodigoFuncion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoFuncion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoFuncion.IsDecimal = False
        Me.bscCodigoFuncion.IsNumber = False
        Me.bscCodigoFuncion.IsPK = False
        Me.bscCodigoFuncion.IsRequired = False
        Me.bscCodigoFuncion.Key = ""
        Me.bscCodigoFuncion.LabelAsoc = Me.chbFuncion
        Me.bscCodigoFuncion.Location = New System.Drawing.Point(695, 167)
        Me.bscCodigoFuncion.MaxLengh = "32767"
        Me.bscCodigoFuncion.Name = "bscCodigoFuncion"
        Me.bscCodigoFuncion.Permitido = True
        Me.bscCodigoFuncion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoFuncion.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoFuncion.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoFuncion.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoFuncion.Selecciono = False
        Me.bscCodigoFuncion.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoFuncion.TabIndex = 47
        '
        'chbFuncion
        '
        Me.chbFuncion.AutoSize = True
        Me.chbFuncion.BindearPropiedadControl = Nothing
        Me.chbFuncion.BindearPropiedadEntidad = Nothing
        Me.chbFuncion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFuncion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFuncion.IsPK = False
        Me.chbFuncion.IsRequired = False
        Me.chbFuncion.Key = Nothing
        Me.chbFuncion.LabelAsoc = Nothing
        Me.chbFuncion.Location = New System.Drawing.Point(630, 169)
        Me.chbFuncion.Name = "chbFuncion"
        Me.chbFuncion.Size = New System.Drawing.Size(64, 17)
        Me.chbFuncion.TabIndex = 46
        Me.chbFuncion.Text = "Función"
        Me.chbFuncion.UseVisualStyleBackColor = True
        '
        'bscFuncion
        '
        Me.bscFuncion.ActivarFiltroEnGrilla = True
        Me.bscFuncion.BindearPropiedadControl = Nothing
        Me.bscFuncion.BindearPropiedadEntidad = Nothing
        Me.bscFuncion.ConfigBuscador = Nothing
        Me.bscFuncion.Datos = Nothing
        Me.bscFuncion.Enabled = False
        Me.bscFuncion.FilaDevuelta = Nothing
        Me.bscFuncion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscFuncion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscFuncion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscFuncion.IsDecimal = False
        Me.bscFuncion.IsNumber = False
        Me.bscFuncion.IsPK = False
        Me.bscFuncion.IsRequired = False
        Me.bscFuncion.Key = ""
        Me.bscFuncion.LabelAsoc = Me.chbFuncion
        Me.bscFuncion.Location = New System.Drawing.Point(789, 166)
        Me.bscFuncion.Margin = New System.Windows.Forms.Padding(4)
        Me.bscFuncion.MaxLengh = "32767"
        Me.bscFuncion.Name = "bscFuncion"
        Me.bscFuncion.Permitido = True
        Me.bscFuncion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscFuncion.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscFuncion.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscFuncion.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscFuncion.Selecciono = False
        Me.bscFuncion.Size = New System.Drawing.Size(175, 23)
        Me.bscFuncion.TabIndex = 48
        '
        'chbMetodoResolulcion
        '
        Me.chbMetodoResolulcion.AutoSize = True
        Me.chbMetodoResolulcion.BindearPropiedadControl = Nothing
        Me.chbMetodoResolulcion.BindearPropiedadEntidad = Nothing
        Me.chbMetodoResolulcion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMetodoResolulcion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMetodoResolulcion.IsPK = False
        Me.chbMetodoResolulcion.IsRequired = False
        Me.chbMetodoResolulcion.Key = Nothing
        Me.chbMetodoResolulcion.LabelAsoc = Nothing
        Me.chbMetodoResolulcion.Location = New System.Drawing.Point(517, 117)
        Me.chbMetodoResolulcion.Name = "chbMetodoResolulcion"
        Me.chbMetodoResolulcion.Size = New System.Drawing.Size(62, 17)
        Me.chbMetodoResolulcion.TabIndex = 33
        Me.chbMetodoResolulcion.Text = "Método"
        Me.chbMetodoResolulcion.UseVisualStyleBackColor = True
        Me.chbMetodoResolulcion.Visible = False
        '
        'cmbMetodoResolulcion
        '
        Me.cmbMetodoResolulcion.BindearPropiedadControl = "SelectedValue"
        Me.cmbMetodoResolulcion.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
        Me.cmbMetodoResolulcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMetodoResolulcion.Enabled = False
        Me.cmbMetodoResolulcion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMetodoResolulcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMetodoResolulcion.FormattingEnabled = True
        Me.cmbMetodoResolulcion.IsPK = False
        Me.cmbMetodoResolulcion.IsRequired = False
        Me.cmbMetodoResolulcion.Key = Nothing
        Me.cmbMetodoResolulcion.LabelAsoc = Nothing
        Me.cmbMetodoResolulcion.Location = New System.Drawing.Point(602, 115)
        Me.cmbMetodoResolulcion.Name = "cmbMetodoResolulcion"
        Me.cmbMetodoResolulcion.Size = New System.Drawing.Size(140, 21)
        Me.cmbMetodoResolulcion.TabIndex = 34
        Me.cmbMetodoResolulcion.Visible = False
        '
        'cmbPriorizado
        '
        Me.cmbPriorizado.BindearPropiedadControl = Nothing
        Me.cmbPriorizado.BindearPropiedadEntidad = Nothing
        Me.cmbPriorizado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPriorizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPriorizado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPriorizado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPriorizado.FormattingEnabled = True
        Me.cmbPriorizado.IsPK = False
        Me.cmbPriorizado.IsRequired = False
        Me.cmbPriorizado.Key = Nothing
        Me.cmbPriorizado.LabelAsoc = Me.Label4
        Me.cmbPriorizado.Location = New System.Drawing.Point(831, 67)
        Me.cmbPriorizado.Name = "cmbPriorizado"
        Me.cmbPriorizado.Size = New System.Drawing.Size(76, 21)
        Me.cmbPriorizado.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(754, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Priorizado"
        '
        'bscCodigoProyecto
        '
        Me.bscCodigoProyecto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProyecto.BindearPropiedadControl = Nothing
        Me.bscCodigoProyecto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProyecto.ConfigBuscador = Nothing
        Me.bscCodigoProyecto.Datos = Nothing
        Me.bscCodigoProyecto.Enabled = False
        Me.bscCodigoProyecto.FilaDevuelta = Nothing
        Me.bscCodigoProyecto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProyecto.IsDecimal = False
        Me.bscCodigoProyecto.IsNumber = True
        Me.bscCodigoProyecto.IsPK = False
        Me.bscCodigoProyecto.IsRequired = False
        Me.bscCodigoProyecto.Key = ""
        Me.bscCodigoProyecto.LabelAsoc = Nothing
        Me.bscCodigoProyecto.Location = New System.Drawing.Point(91, 168)
        Me.bscCodigoProyecto.MaxLengh = "32767"
        Me.bscCodigoProyecto.Name = "bscCodigoProyecto"
        Me.bscCodigoProyecto.Permitido = True
        Me.bscCodigoProyecto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProyecto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProyecto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProyecto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProyecto.Selecciono = False
        Me.bscCodigoProyecto.Size = New System.Drawing.Size(75, 23)
        Me.bscCodigoProyecto.TabIndex = 42
        '
        'bscProyecto
        '
        Me.bscProyecto.ActivarFiltroEnGrilla = True
        Me.bscProyecto.AutoSize = True
        Me.bscProyecto.BindearPropiedadControl = Nothing
        Me.bscProyecto.BindearPropiedadEntidad = Nothing
        Me.bscProyecto.ConfigBuscador = Nothing
        Me.bscProyecto.Datos = Nothing
        Me.bscProyecto.Enabled = False
        Me.bscProyecto.FilaDevuelta = Nothing
        Me.bscProyecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProyecto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProyecto.IsDecimal = False
        Me.bscProyecto.IsNumber = False
        Me.bscProyecto.IsPK = False
        Me.bscProyecto.IsRequired = False
        Me.bscProyecto.Key = ""
        Me.bscProyecto.LabelAsoc = Nothing
        Me.bscProyecto.Location = New System.Drawing.Point(172, 168)
        Me.bscProyecto.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProyecto.MaxLengh = "32767"
        Me.bscProyecto.Name = "bscProyecto"
        Me.bscProyecto.Permitido = True
        Me.bscProyecto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProyecto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProyecto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProyecto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProyecto.Selecciono = False
        Me.bscProyecto.Size = New System.Drawing.Size(160, 23)
        Me.bscProyecto.TabIndex = 43
        '
        'chbProyecto
        '
        Me.chbProyecto.AutoSize = True
        Me.chbProyecto.BindearPropiedadControl = Nothing
        Me.chbProyecto.BindearPropiedadEntidad = Nothing
        Me.chbProyecto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProyecto.IsPK = False
        Me.chbProyecto.IsRequired = False
        Me.chbProyecto.Key = Nothing
        Me.chbProyecto.LabelAsoc = Nothing
        Me.chbProyecto.Location = New System.Drawing.Point(11, 171)
        Me.chbProyecto.Name = "chbProyecto"
        Me.chbProyecto.Size = New System.Drawing.Size(68, 17)
        Me.chbProyecto.TabIndex = 41
        Me.chbProyecto.Text = "Proyecto"
        Me.chbProyecto.UseVisualStyleBackColor = True
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(354, 172)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 44
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BindearPropiedadControl = Nothing
        Me.txtDescripcion.BindearPropiedadEntidad = Nothing
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = False
        Me.txtDescripcion.Key = ""
        Me.txtDescripcion.LabelAsoc = Nothing
        Me.txtDescripcion.Location = New System.Drawing.Point(419, 168)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(207, 20)
        Me.txtDescripcion.TabIndex = 45
        '
        'chbVersion
        '
        Me.chbVersion.AutoSize = True
        Me.chbVersion.BindearPropiedadControl = Nothing
        Me.chbVersion.BindearPropiedadEntidad = Nothing
        Me.chbVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVersion.IsPK = False
        Me.chbVersion.IsRequired = False
        Me.chbVersion.Key = Nothing
        Me.chbVersion.LabelAsoc = Nothing
        Me.chbVersion.Location = New System.Drawing.Point(269, 144)
        Me.chbVersion.Name = "chbVersion"
        Me.chbVersion.Size = New System.Drawing.Size(61, 17)
        Me.chbVersion.TabIndex = 37
        Me.chbVersion.Text = "Versión"
        Me.chbVersion.UseVisualStyleBackColor = True
        '
        'cmbVersion
        '
        Me.cmbVersion.BindearPropiedadControl = "SelectedValue"
        Me.cmbVersion.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
        Me.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersion.Enabled = False
        Me.cmbVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVersion.FormattingEnabled = True
        Me.cmbVersion.IsPK = False
        Me.cmbVersion.IsRequired = False
        Me.cmbVersion.Key = Nothing
        Me.cmbVersion.LabelAsoc = Nothing
        Me.cmbVersion.Location = New System.Drawing.Point(354, 142)
        Me.cmbVersion.Name = "cmbVersion"
        Me.cmbVersion.Size = New System.Drawing.Size(137, 21)
        Me.cmbVersion.TabIndex = 38
        '
        'chbAplicacion
        '
        Me.chbAplicacion.AutoSize = True
        Me.chbAplicacion.BindearPropiedadControl = Nothing
        Me.chbAplicacion.BindearPropiedadEntidad = Nothing
        Me.chbAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAplicacion.IsPK = False
        Me.chbAplicacion.IsRequired = False
        Me.chbAplicacion.Key = Nothing
        Me.chbAplicacion.LabelAsoc = Nothing
        Me.chbAplicacion.Location = New System.Drawing.Point(11, 144)
        Me.chbAplicacion.Name = "chbAplicacion"
        Me.chbAplicacion.Size = New System.Drawing.Size(75, 17)
        Me.chbAplicacion.TabIndex = 35
        Me.chbAplicacion.Text = "Aplicación"
        Me.chbAplicacion.UseVisualStyleBackColor = True
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbAplicacion.BindearPropiedadEntidad = "CategoriaNovedad.IdCategoriaNovedad"
        Me.cmbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAplicacion.Enabled = False
        Me.cmbAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAplicacion.FormattingEnabled = True
        Me.cmbAplicacion.IsPK = False
        Me.cmbAplicacion.IsRequired = False
        Me.cmbAplicacion.Key = Nothing
        Me.cmbAplicacion.LabelAsoc = Nothing
        Me.cmbAplicacion.Location = New System.Drawing.Point(91, 142)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.Size = New System.Drawing.Size(146, 21)
        Me.cmbAplicacion.TabIndex = 36
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
        Me.chbFecha.Location = New System.Drawing.Point(11, 17)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 0
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'cmbRevisionAdministrativa
        '
        Me.cmbRevisionAdministrativa.BindearPropiedadControl = Nothing
        Me.cmbRevisionAdministrativa.BindearPropiedadEntidad = Nothing
        Me.cmbRevisionAdministrativa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRevisionAdministrativa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRevisionAdministrativa.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRevisionAdministrativa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRevisionAdministrativa.FormattingEnabled = True
        Me.cmbRevisionAdministrativa.IsPK = False
        Me.cmbRevisionAdministrativa.IsRequired = False
        Me.cmbRevisionAdministrativa.Items.AddRange(New Object() {"TODAS", "SI", "NO"})
        Me.cmbRevisionAdministrativa.Key = Nothing
        Me.cmbRevisionAdministrativa.LabelAsoc = Me.lblRevisionAdministrativa
        Me.cmbRevisionAdministrativa.Location = New System.Drawing.Point(757, 36)
        Me.cmbRevisionAdministrativa.Name = "cmbRevisionAdministrativa"
        Me.cmbRevisionAdministrativa.Size = New System.Drawing.Size(76, 21)
        Me.cmbRevisionAdministrativa.TabIndex = 11
        '
        'lblRevisionAdministrativa
        '
        Me.lblRevisionAdministrativa.AutoSize = True
        Me.lblRevisionAdministrativa.LabelAsoc = Nothing
        Me.lblRevisionAdministrativa.Location = New System.Drawing.Point(676, 39)
        Me.lblRevisionAdministrativa.Name = "lblRevisionAdministrativa"
        Me.lblRevisionAdministrativa.Size = New System.Drawing.Size(65, 13)
        Me.lblRevisionAdministrativa.TabIndex = 10
        Me.lblRevisionAdministrativa.Text = "Rev. Admin."
        '
        'txtNumero
        '
        Me.txtNumero.BindearPropiedadControl = Nothing
        Me.txtNumero.BindearPropiedadEntidad = Nothing
        Me.txtNumero.Enabled = False
        Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumero.Formato = "##0"
        Me.txtNumero.IsDecimal = False
        Me.txtNumero.IsNumber = True
        Me.txtNumero.IsPK = False
        Me.txtNumero.IsRequired = False
        Me.txtNumero.Key = ""
        Me.txtNumero.LabelAsoc = Nothing
        Me.txtNumero.Location = New System.Drawing.Point(905, 36)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(59, 20)
        Me.txtNumero.TabIndex = 20
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbFinalizado
        '
        Me.cmbFinalizado.BindearPropiedadControl = Nothing
        Me.cmbFinalizado.BindearPropiedadEntidad = Nothing
        Me.cmbFinalizado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFinalizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFinalizado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFinalizado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFinalizado.FormattingEnabled = True
        Me.cmbFinalizado.IsPK = False
        Me.cmbFinalizado.IsRequired = False
        Me.cmbFinalizado.Key = Nothing
        Me.cmbFinalizado.LabelAsoc = Me.lblGrabanLibro
        Me.cmbFinalizado.Location = New System.Drawing.Point(602, 62)
        Me.cmbFinalizado.Name = "cmbFinalizado"
        Me.cmbFinalizado.Size = New System.Drawing.Size(83, 21)
        Me.cmbFinalizado.TabIndex = 18
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(514, 66)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(54, 13)
        Me.lblGrabanLibro.TabIndex = 17
        Me.lblGrabanLibro.Text = "Finalizado"
        '
        'rdbFechaProxContacto
        '
        Me.rdbFechaProxContacto.AutoSize = True
        Me.rdbFechaProxContacto.BindearPropiedadControl = Nothing
        Me.rdbFechaProxContacto.BindearPropiedadEntidad = Nothing
        Me.rdbFechaProxContacto.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbFechaProxContacto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbFechaProxContacto.IsPK = False
        Me.rdbFechaProxContacto.IsRequired = False
        Me.rdbFechaProxContacto.Key = Nothing
        Me.rdbFechaProxContacto.LabelAsoc = Nothing
        Me.rdbFechaProxContacto.Location = New System.Drawing.Point(518, 36)
        Me.rdbFechaProxContacto.Name = "rdbFechaProxContacto"
        Me.rdbFechaProxContacto.Size = New System.Drawing.Size(156, 17)
        Me.rdbFechaProxContacto.TabIndex = 9
        Me.rdbFechaProxContacto.Text = "Fecha de Próximo Contacto"
        Me.rdbFechaProxContacto.UseVisualStyleBackColor = True
        '
        'rdbFechaNovedad
        '
        Me.rdbFechaNovedad.AutoSize = True
        Me.rdbFechaNovedad.BindearPropiedadControl = Nothing
        Me.rdbFechaNovedad.BindearPropiedadEntidad = Nothing
        Me.rdbFechaNovedad.Checked = True
        Me.rdbFechaNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbFechaNovedad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbFechaNovedad.IsPK = False
        Me.rdbFechaNovedad.IsRequired = False
        Me.rdbFechaNovedad.Key = Nothing
        Me.rdbFechaNovedad.LabelAsoc = Nothing
        Me.rdbFechaNovedad.Location = New System.Drawing.Point(518, 13)
        Me.rdbFechaNovedad.Name = "rdbFechaNovedad"
        Me.rdbFechaNovedad.Size = New System.Drawing.Size(117, 17)
        Me.rdbFechaNovedad.TabIndex = 6
        Me.rdbFechaNovedad.TabStop = True
        Me.rdbFechaNovedad.Text = "Fecha de Novedad"
        Me.rdbFechaNovedad.UseVisualStyleBackColor = True
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.Enabled = False
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
        Me.bscCliente.Location = New System.Drawing.Point(185, 61)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(306, 23)
        Me.bscCliente.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(91, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Código"
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(91, 61)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(182, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "&Nombre"
        '
        'chbAsignadoA
        '
        Me.chbAsignadoA.AutoSize = True
        Me.chbAsignadoA.BindearPropiedadControl = Nothing
        Me.chbAsignadoA.BindearPropiedadEntidad = Nothing
        Me.chbAsignadoA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAsignadoA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAsignadoA.IsPK = False
        Me.chbAsignadoA.IsRequired = False
        Me.chbAsignadoA.Key = Nothing
        Me.chbAsignadoA.LabelAsoc = Nothing
        Me.chbAsignadoA.Location = New System.Drawing.Point(269, 90)
        Me.chbAsignadoA.Name = "chbAsignadoA"
        Me.chbAsignadoA.Size = New System.Drawing.Size(79, 17)
        Me.chbAsignadoA.TabIndex = 23
        Me.chbAsignadoA.Text = "Asignado a"
        Me.chbAsignadoA.UseVisualStyleBackColor = True
        '
        'chbProspecto
        '
        Me.chbProspecto.AutoSize = True
        Me.chbProspecto.BindearPropiedadControl = Nothing
        Me.chbProspecto.BindearPropiedadEntidad = Nothing
        Me.chbProspecto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProspecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProspecto.IsPK = False
        Me.chbProspecto.IsRequired = False
        Me.chbProspecto.Key = Nothing
        Me.chbProspecto.LabelAsoc = Nothing
        Me.chbProspecto.Location = New System.Drawing.Point(11, 64)
        Me.chbProspecto.Name = "chbProspecto"
        Me.chbProspecto.Size = New System.Drawing.Size(74, 17)
        Me.chbProspecto.TabIndex = 12
        Me.chbProspecto.Text = "Prospecto"
        Me.chbProspecto.UseVisualStyleBackColor = True
        '
        'chbEstado
        '
        Me.chbEstado.AutoSize = True
        Me.chbEstado.BindearPropiedadControl = Nothing
        Me.chbEstado.BindearPropiedadEntidad = Nothing
        Me.chbEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstado.IsPK = False
        Me.chbEstado.IsRequired = False
        Me.chbEstado.Key = Nothing
        Me.chbEstado.LabelAsoc = Nothing
        Me.chbEstado.Location = New System.Drawing.Point(517, 90)
        Me.chbEstado.Name = "chbEstado"
        Me.chbEstado.Size = New System.Drawing.Size(59, 17)
        Me.chbEstado.TabIndex = 25
        Me.chbEstado.Text = "Estado"
        Me.chbEstado.UseVisualStyleBackColor = True
        '
        'chbMedio
        '
        Me.chbMedio.AutoSize = True
        Me.chbMedio.BindearPropiedadControl = Nothing
        Me.chbMedio.BindearPropiedadEntidad = Nothing
        Me.chbMedio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMedio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMedio.IsPK = False
        Me.chbMedio.IsRequired = False
        Me.chbMedio.Key = Nothing
        Me.chbMedio.LabelAsoc = Nothing
        Me.chbMedio.Location = New System.Drawing.Point(269, 117)
        Me.chbMedio.Name = "chbMedio"
        Me.chbMedio.Size = New System.Drawing.Size(55, 17)
        Me.chbMedio.TabIndex = 31
        Me.chbMedio.Text = "Medio"
        Me.chbMedio.UseVisualStyleBackColor = True
        '
        'chbPrioridad
        '
        Me.chbPrioridad.AutoSize = True
        Me.chbPrioridad.BindearPropiedadControl = Nothing
        Me.chbPrioridad.BindearPropiedadEntidad = Nothing
        Me.chbPrioridad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPrioridad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPrioridad.IsPK = False
        Me.chbPrioridad.IsRequired = False
        Me.chbPrioridad.Key = Nothing
        Me.chbPrioridad.LabelAsoc = Nothing
        Me.chbPrioridad.Location = New System.Drawing.Point(11, 90)
        Me.chbPrioridad.Name = "chbPrioridad"
        Me.chbPrioridad.Size = New System.Drawing.Size(67, 17)
        Me.chbPrioridad.TabIndex = 21
        Me.chbPrioridad.Text = "Prioridad"
        Me.chbPrioridad.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(676, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Tipo Novedad"
        '
        'cmbTipoNovedad
        '
        Me.cmbTipoNovedad.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoNovedad.BindearPropiedadEntidad = "TipoNovedad.IdTipoNovedad"
        Me.cmbTipoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoNovedad.FormattingEnabled = True
        Me.cmbTipoNovedad.IsPK = False
        Me.cmbTipoNovedad.IsRequired = False
        Me.cmbTipoNovedad.Key = Nothing
        Me.cmbTipoNovedad.LabelAsoc = Nothing
        Me.cmbTipoNovedad.Location = New System.Drawing.Point(757, 9)
        Me.cmbTipoNovedad.Name = "cmbTipoNovedad"
        Me.cmbTipoNovedad.Size = New System.Drawing.Size(140, 21)
        Me.cmbTipoNovedad.TabIndex = 8
        Me.cmbTipoNovedad.TabStop = False
        '
        'cmbIdUsuarioAsignado
        '
        Me.cmbIdUsuarioAsignado.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdUsuarioAsignado.BindearPropiedadEntidad = "UsuarioAsignado.Usuario"
        Me.cmbIdUsuarioAsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdUsuarioAsignado.Enabled = False
        Me.cmbIdUsuarioAsignado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdUsuarioAsignado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdUsuarioAsignado.FormattingEnabled = True
        Me.cmbIdUsuarioAsignado.IsPK = False
        Me.cmbIdUsuarioAsignado.IsRequired = False
        Me.cmbIdUsuarioAsignado.Key = Nothing
        Me.cmbIdUsuarioAsignado.LabelAsoc = Nothing
        Me.cmbIdUsuarioAsignado.Location = New System.Drawing.Point(354, 88)
        Me.cmbIdUsuarioAsignado.Name = "cmbIdUsuarioAsignado"
        Me.cmbIdUsuarioAsignado.Size = New System.Drawing.Size(137, 21)
        Me.cmbIdUsuarioAsignado.TabIndex = 24
        '
        'cmbEstadoNovedad
        '
        Me.cmbEstadoNovedad.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoNovedad.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
        Me.cmbEstadoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoNovedad.Enabled = False
        Me.cmbEstadoNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoNovedad.FormattingEnabled = True
        Me.cmbEstadoNovedad.IsPK = False
        Me.cmbEstadoNovedad.IsRequired = False
        Me.cmbEstadoNovedad.Key = Nothing
        Me.cmbEstadoNovedad.LabelAsoc = Nothing
        Me.cmbEstadoNovedad.Location = New System.Drawing.Point(602, 88)
        Me.cmbEstadoNovedad.Name = "cmbEstadoNovedad"
        Me.cmbEstadoNovedad.Size = New System.Drawing.Size(140, 21)
        Me.cmbEstadoNovedad.TabIndex = 26
        '
        'cmbMedio
        '
        Me.cmbMedio.BindearPropiedadControl = "SelectedValue"
        Me.cmbMedio.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
        Me.cmbMedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedio.Enabled = False
        Me.cmbMedio.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMedio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMedio.FormattingEnabled = True
        Me.cmbMedio.IsPK = False
        Me.cmbMedio.IsRequired = False
        Me.cmbMedio.Key = Nothing
        Me.cmbMedio.LabelAsoc = Nothing
        Me.cmbMedio.Location = New System.Drawing.Point(354, 115)
        Me.cmbMedio.Name = "cmbMedio"
        Me.cmbMedio.Size = New System.Drawing.Size(137, 21)
        Me.cmbMedio.TabIndex = 32
        '
        'cmbPrioridadNovedad
        '
        Me.cmbPrioridadNovedad.BindearPropiedadControl = "SelectedValue"
        Me.cmbPrioridadNovedad.BindearPropiedadEntidad = "PrioridadNovedad.IdPrioridadNovedad"
        Me.cmbPrioridadNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrioridadNovedad.Enabled = False
        Me.cmbPrioridadNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPrioridadNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPrioridadNovedad.FormattingEnabled = True
        Me.cmbPrioridadNovedad.IsPK = False
        Me.cmbPrioridadNovedad.IsRequired = False
        Me.cmbPrioridadNovedad.Key = Nothing
        Me.cmbPrioridadNovedad.LabelAsoc = Nothing
        Me.cmbPrioridadNovedad.Location = New System.Drawing.Point(91, 88)
        Me.cmbPrioridadNovedad.Name = "cmbPrioridadNovedad"
        Me.cmbPrioridadNovedad.Size = New System.Drawing.Size(146, 21)
        Me.cmbPrioridadNovedad.TabIndex = 22
        '
        'chbNumero
        '
        Me.chbNumero.AutoSize = True
        Me.chbNumero.BindearPropiedadControl = Nothing
        Me.chbNumero.BindearPropiedadEntidad = Nothing
        Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumero.IsPK = False
        Me.chbNumero.IsRequired = False
        Me.chbNumero.Key = Nothing
        Me.chbNumero.LabelAsoc = Nothing
        Me.chbNumero.Location = New System.Drawing.Point(837, 38)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 19
        Me.chbNumero.Text = "Numero"
        Me.chbNumero.UseVisualStyleBackColor = True
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkExpandAll.AutoSize = True
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(864, 142)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
        Me.chkExpandAll.TabIndex = 50
        Me.chkExpandAll.Tag = ""
        Me.chkExpandAll.Text = "Expandir Grupos"
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
        Me.chbUsuario.Location = New System.Drawing.Point(517, 144)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(82, 17)
        Me.chbUsuario.TabIndex = 39
        Me.chbUsuario.Text = "Usuario alta"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'cmbUsuarioAlta
        '
        Me.cmbUsuarioAlta.BindearPropiedadControl = Nothing
        Me.cmbUsuarioAlta.BindearPropiedadEntidad = Nothing
        Me.cmbUsuarioAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarioAlta.Enabled = False
        Me.cmbUsuarioAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuarioAlta.FormattingEnabled = True
        Me.cmbUsuarioAlta.IsPK = False
        Me.cmbUsuarioAlta.IsRequired = False
        Me.cmbUsuarioAlta.Key = Nothing
        Me.cmbUsuarioAlta.LabelAsoc = Nothing
        Me.cmbUsuarioAlta.Location = New System.Drawing.Point(602, 142)
        Me.cmbUsuarioAlta.Name = "cmbUsuarioAlta"
        Me.cmbUsuarioAlta.Size = New System.Drawing.Size(140, 21)
        Me.cmbUsuarioAlta.TabIndex = 40
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(864, 94)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 49
        Me.btnConsultar.Tag = ""
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(73, 17)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 1
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(379, 15)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(340, 19)
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
        Me.dtpDesde.Location = New System.Drawing.Point(211, 15)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 3
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(167, 19)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 2
        Me.lblDesde.Text = "Desde"
        '
        'tbcVersion
        '
        Me.tbcVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcVersion.Controls.Add(Me.tbpFiltros)
        Me.tbcVersion.Controls.Add(Me.tbpCambios)
        Me.tbcVersion.Controls.Add(Me.tbpVersion)
        Me.tbcVersion.Controls.Add(Me.tbpEnviar)
        Me.tbcVersion.Location = New System.Drawing.Point(0, 32)
        Me.tbcVersion.Name = "tbcVersion"
        Me.tbcVersion.SelectedIndex = 0
        Me.tbcVersion.Size = New System.Drawing.Size(984, 229)
        Me.tbcVersion.TabIndex = 0
        '
        'tbpEnviar
        '
        Me.tbpEnviar.BackColor = System.Drawing.SystemColors.Control
        Me.tbpEnviar.Controls.Add(Me.ugEnviar)
        Me.tbpEnviar.Location = New System.Drawing.Point(4, 22)
        Me.tbpEnviar.Name = "tbpEnviar"
        Me.tbpEnviar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpEnviar.Size = New System.Drawing.Size(976, 203)
        Me.tbpEnviar.TabIndex = 3
        Me.tbpEnviar.Text = "Novedades a Enviar"
        '
        'ugEnviar
        '
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor3DBase = System.Drawing.Color.White
        Me.ugEnviar.DisplayLayout.Appearance = Appearance28
        UltraGridColumn3.Header.Caption = "Número"
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn3.Width = 45
        UltraGridColumn1.Header.Caption = "Alta"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Width = 67
        UltraGridColumn21.Header.Caption = "Categoria"
        UltraGridColumn21.Header.VisiblePosition = 2
        UltraGridColumn21.Width = 100
        UltraGridColumn2.Header.Caption = "Nombre de Fantasia"
        UltraGridColumn2.Header.VisiblePosition = 3
        UltraGridColumn2.Width = 201
        UltraGridColumn5.Header.Caption = "Padre"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn40.Header.Caption = "Función"
        UltraGridColumn40.Header.VisiblePosition = 5
        UltraGridColumn40.Width = 194
        UltraGridColumn24.Header.Caption = "Descripción"
        UltraGridColumn24.Header.VisiblePosition = 6
        UltraGridColumn24.Width = 307
        UltraGridColumn4.Header.VisiblePosition = 7
        UltraGridColumn6.Header.Caption = "Responsable"
        UltraGridColumn6.Header.VisiblePosition = 8
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn3, UltraGridColumn1, UltraGridColumn21, UltraGridColumn2, UltraGridColumn5, UltraGridColumn40, UltraGridColumn24, UltraGridColumn4, UltraGridColumn6})
        UltraGridBand2.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand2.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand2.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand2.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        UltraGridBand2.SummaryFooterCaption = "Totales:"
        Me.ugEnviar.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugEnviar.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugEnviar.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEnviar.DisplayLayout.GroupByBox.Appearance = Appearance29
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEnviar.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance30
        Me.ugEnviar.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugEnviar.DisplayLayout.GroupByBox.Hidden = True
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance31.BackColor2 = System.Drawing.SystemColors.Control
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEnviar.DisplayLayout.GroupByBox.PromptAppearance = Appearance31
        Me.ugEnviar.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugEnviar.DisplayLayout.MaxColScrollRegions = 1
        Me.ugEnviar.DisplayLayout.MaxRowScrollRegions = 1
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugEnviar.DisplayLayout.Override.ActiveCellAppearance = Appearance32
        Appearance33.BackColor = System.Drawing.SystemColors.Highlight
        Appearance33.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugEnviar.DisplayLayout.Override.ActiveRowAppearance = Appearance33
        Me.ugEnviar.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugEnviar.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugEnviar.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugEnviar.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugEnviar.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugEnviar.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugEnviar.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugEnviar.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Me.ugEnviar.DisplayLayout.Override.CardAreaAppearance = Appearance34
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugEnviar.DisplayLayout.Override.CellAppearance = Appearance35
        Me.ugEnviar.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugEnviar.DisplayLayout.Override.CellPadding = 0
        Me.ugEnviar.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugEnviar.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugEnviar.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance36.BackColor = System.Drawing.Color.Tomato
        Appearance36.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEnviar.DisplayLayout.Override.GroupByRowAppearance = Appearance36
        Me.ugEnviar.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance37.TextHAlignAsString = "Left"
        Me.ugEnviar.DisplayLayout.Override.HeaderAppearance = Appearance37
        Me.ugEnviar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugEnviar.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.BorderColor = System.Drawing.Color.Silver
        Me.ugEnviar.DisplayLayout.Override.RowAppearance = Appearance38
        Me.ugEnviar.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugEnviar.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugEnviar.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugEnviar.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugEnviar.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugEnviar.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance39.BackColor = System.Drawing.Color.LimeGreen
        Appearance39.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugEnviar.DisplayLayout.Override.SummaryValueAppearance = Appearance39
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugEnviar.DisplayLayout.Override.TemplateAddRowAppearance = Appearance40
        Me.ugEnviar.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugEnviar.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugEnviar.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugEnviar.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugEnviar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugEnviar.Location = New System.Drawing.Point(3, 3)
        Me.ugEnviar.Name = "ugEnviar"
        Me.ugEnviar.Size = New System.Drawing.Size(970, 197)
        Me.ugEnviar.TabIndex = 1
        Me.ugEnviar.Text = "UltraGrid1"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'bwkGenerarVersion
        '
        Me.bwkGenerarVersion.WorkerReportsProgress = True
        Me.bwkGenerarVersion.WorkerSupportsCancellation = True
        '
        'ofgScript
        '
        Me.ofgScript.DefaultExt = "png"
        Me.ofgScript.Filter = "Archivos de Texto (*.sql)|*.sql|Todos los Archivos (*.*)|*.*"
        Me.ofgScript.Multiselect = True
        Me.ofgScript.RestoreDirectory = True
        Me.ofgScript.Title = "Seleccione un archivo"
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
        Me.cmbTodos.Location = New System.Drawing.Point(7, 268)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 1
        '
        'lblPriorizado
        '
        Me.lblPriorizado.AutoSize = True
        Me.lblPriorizado.LabelAsoc = Nothing
        Me.lblPriorizado.Location = New System.Drawing.Point(24, 118)
        Me.lblPriorizado.Name = "lblPriorizado"
        Me.lblPriorizado.Size = New System.Drawing.Size(54, 13)
        Me.lblPriorizado.TabIndex = 54
        Me.lblPriorizado.Text = "Categoría"
        '
        'cmbCategoriasNovedad
        '
        Me.cmbCategoriasNovedad.BindearPropiedadControl = Nothing
        Me.cmbCategoriasNovedad.BindearPropiedadEntidad = Nothing
        Me.cmbCategoriasNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriasNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriasNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriasNovedad.FormattingEnabled = True
        Me.cmbCategoriasNovedad.IsPK = False
        Me.cmbCategoriasNovedad.IsRequired = False
        Me.cmbCategoriasNovedad.Key = Nothing
        Me.cmbCategoriasNovedad.LabelAsoc = Nothing
        Me.cmbCategoriasNovedad.Location = New System.Drawing.Point(91, 115)
        Me.cmbCategoriasNovedad.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbCategoriasNovedad.Name = "cmbCategoriasNovedad"
        Me.cmbCategoriasNovedad.Size = New System.Drawing.Size(146, 21)
        Me.cmbCategoriasNovedad.TabIndex = 53
        '
        'CRMActualizacionMasiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.tbcVersion)
        Me.KeyPreview = True
        Me.Name = "CRMActualizacionMasiva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualización Masiva de Novedades"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpVersion.ResumeLayout(False)
        Me.tbpVersion.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ugScripts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlColorNuevoVersion.ResumeLayout(False)
        Me.tbpCambios.ResumeLayout(False)
        Me.tbpCambios.PerformLayout()
        Me.pnlColorNuevo.ResumeLayout(False)
        Me.tbpFiltros.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tbcVersion.ResumeLayout(False)
        Me.tbpEnviar.ResumeLayout(False)
        CType(Me.ugEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbActualizar As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents tbpVersion As System.Windows.Forms.TabPage
   Friend WithEvents chbColorVersion As Eniac.Controles.CheckBox
   Friend WithEvents pnlColorNuevoVersion As System.Windows.Forms.Panel
   Friend WithEvents btnColorVersion As System.Windows.Forms.Button
   Friend WithEvents chbMedioVersion As Eniac.Controles.CheckBox
   Friend WithEvents cmbMedioVersion As Eniac.Controles.ComboBox
   Friend WithEvents chbFechaProximoContactoVersion As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaProximoContactoVersion As Eniac.Controles.DateTimePicker
   Friend WithEvents chbPriorizadoVersion As Eniac.Controles.CheckBox
   Friend WithEvents cmbPriorizadoVersion As Eniac.Controles.ComboBox
   Friend WithEvents chbPrioridadVersion As Eniac.Controles.CheckBox
   Friend WithEvents cmbPrioridadNovedadVersion As Eniac.Controles.ComboBox
   Friend WithEvents chbAvanceVersion As Eniac.Controles.CheckBox
   Friend WithEvents txtAvanceVersion As Eniac.Controles.TextBox
   Friend WithEvents chbVersionFechaFinal As Eniac.Controles.CheckBox
   Friend WithEvents dtpVersionFechaFinal As Eniac.Controles.DateTimePicker
   Friend WithEvents chbVersionFinal As Eniac.Controles.CheckBox
   Friend WithEvents chbEstadoVersion As Eniac.Controles.CheckBox
   Friend WithEvents cmbEstadoVersion As Eniac.Controles.ComboBox
   Friend WithEvents tbpCambios As System.Windows.Forms.TabPage
   Friend WithEvents chbColorNuevo As Eniac.Controles.CheckBox
   Friend WithEvents pnlColorNuevo As System.Windows.Forms.Panel
   Friend WithEvents btnColorNuevo As System.Windows.Forms.Button
   Friend WithEvents chbMedioNuevo As Eniac.Controles.CheckBox
   Friend WithEvents cmbMedioNuevo As Eniac.Controles.ComboBox
   Friend WithEvents chbFechaProximoContacto As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaProximoContacto As Eniac.Controles.DateTimePicker
   Friend WithEvents chbPriorizadoNuevo As Eniac.Controles.CheckBox
   Friend WithEvents cmbPriorizadoNuevo As Eniac.Controles.ComboBox
   Friend WithEvents chbPrioridadNuevo As Eniac.Controles.CheckBox
   Friend WithEvents cmbPrioridadNovedadNuevo As Eniac.Controles.ComboBox
   Friend WithEvents chbAvanceNuevo As Eniac.Controles.CheckBox
   Friend WithEvents txtAvanceNuevo As Eniac.Controles.TextBox
   Friend WithEvents txtVersionNuevo As Eniac.Controles.TextBox
   Friend WithEvents chbVersionFechaNuevo As Eniac.Controles.CheckBox
   Friend WithEvents dtpVersionFechaNuevo As Eniac.Controles.DateTimePicker
   Friend WithEvents chbVersionNuevo As Eniac.Controles.CheckBox
   Friend WithEvents chbAsignadoANuevo As Eniac.Controles.CheckBox
   Friend WithEvents chbEstadoNuevo As Eniac.Controles.CheckBox
   Friend WithEvents cmbAsignadoANuevo As Eniac.Controles.ComboBox
   Friend WithEvents cmbEstadoNuevo As Eniac.Controles.ComboBox
   Friend WithEvents tbpFiltros As System.Windows.Forms.TabPage
   Friend WithEvents tbcVersion As System.Windows.Forms.TabControl
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents chbVersion As Eniac.Controles.CheckBox
   Friend WithEvents cmbVersion As Eniac.Controles.ComboBox
   Friend WithEvents chbAplicacion As Eniac.Controles.CheckBox
   Friend WithEvents cmbAplicacion As Eniac.Controles.ComboBox
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents cmbRevisionAdministrativa As Eniac.Controles.ComboBox
   Friend WithEvents lblRevisionAdministrativa As Eniac.Controles.Label
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents cmbFinalizado As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents rdbFechaProxContacto As Eniac.Controles.RadioButton
   Friend WithEvents rdbFechaNovedad As Eniac.Controles.RadioButton
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents chbAsignadoA As Eniac.Controles.CheckBox
   Friend WithEvents chbProspecto As Eniac.Controles.CheckBox
   Friend WithEvents chbEstado As Eniac.Controles.CheckBox
   Friend WithEvents chbMedio As Eniac.Controles.CheckBox
    Friend WithEvents chbPrioridad As Eniac.Controles.CheckBox
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents cmbTipoNovedad As Eniac.Controles.ComboBox
    Friend WithEvents cmbIdUsuarioAsignado As Eniac.Controles.ComboBox
    Friend WithEvents cmbEstadoNovedad As Eniac.Controles.ComboBox
    Friend WithEvents cmbMedio As Eniac.Controles.ComboBox
    Friend WithEvents cmbPrioridadNovedad As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuarioAlta As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents tsbGenerarVersion As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents txtVersionFinal As Eniac.Controles.TextBox
   Public WithEvents tsbModificar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tbpEnviar As System.Windows.Forms.TabPage
   Friend WithEvents ugEnviar As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents LblFtp As Eniac.Controles.Label
   Friend WithEvents TxtRutaFTP As System.Windows.Forms.TextBox
   Friend WithEvents BtnFTP As System.Windows.Forms.Button
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnProbarFTP As System.Windows.Forms.Button
   Friend WithEvents bwkGenerarVersion As System.ComponentModel.BackgroundWorker
   Friend WithEvents bscNombreClienteNuevo As Eniac.Controles.Buscador2
   Friend WithEvents bscCodClienteNuevo As Eniac.Controles.Buscador2
   Friend WithEvents chbClienteNuevo As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoriaNuevo As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoriaNovedadNuevo As Eniac.Controles.ComboBox
   Friend WithEvents cmbAplicacionNueva As Eniac.Controles.ComboBox
   Friend WithEvents chbAplicacionNueva As Eniac.Controles.CheckBox
   Friend WithEvents chbFuncionNuevo As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoFuncionNuevo As Eniac.Controles.Buscador2
   Friend WithEvents bscFuncionNuevo As Eniac.Controles.Buscador2
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents ugScripts As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistrosScript As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents btnSeleccionarScript As System.Windows.Forms.Button
   Friend WithEvents ofgScript As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnEliminarScript As System.Windows.Forms.Button
   Friend WithEvents chbProyecto As Eniac.Controles.CheckBox
   Friend WithEvents chbProyectoNuevo As Eniac.Controles.CheckBox
   Friend WithEvents bscProyecto As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProyecto As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProyectoNuevo As Eniac.Controles.Buscador2
   Friend WithEvents bscProyectoNuevo As Eniac.Controles.Buscador2
    Friend WithEvents cmbPriorizado As Controles.ComboBox
    Friend WithEvents Label4 As Controles.Label
    Friend WithEvents chbRequiereTesteoNuevo As Controles.CheckBox
    Friend WithEvents cmbRequiereTesteoNuevo As Controles.ComboBox
    Friend WithEvents chbMetodoResolulcion As Controles.CheckBox
    Friend WithEvents cmbMetodoResolulcion As Controles.ComboBox
    Friend WithEvents chbMetodoNuevo As Controles.CheckBox
    Friend WithEvents cmbMetodoNuevo As Controles.ComboBox
    Friend WithEvents bscCodigoFuncion As Controles.Buscador2
    Friend WithEvents chbFuncion As Controles.CheckBox
    Friend WithEvents bscFuncion As Controles.Buscador2
    Friend WithEvents lblPriorizado As Controles.Label
    Friend WithEvents cmbCategoriasNovedad As ComboBoxCRMCategorias
End Class
