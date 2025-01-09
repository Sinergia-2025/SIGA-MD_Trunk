<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolicitarCAE
   Inherits Eniac.Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolicitarCAE))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestos")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePesos")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTickets")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTarjetas")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCheques")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTransfBancaria")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CAE")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CAEVencimiento")
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CUIT")
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalPercepcion")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalIVA")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestoInterno")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Check", 0)
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObtenerCAE", 1)
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ControlarInfo", 2)
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver", 3)
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoErrorAfip", 4)
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbObtenerCAEs = New System.Windows.Forms.ToolStripButton()
      Me.tsbConfigurarMail = New System.Windows.Forms.ToolStripButton()
      Me.tsbConsultarUltimoComprobante = New System.Windows.Forms.ToolStripButton()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbFormaPago = New Eniac.Controles.CheckBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.chbLetra = New Eniac.Controles.CheckBox()
      Me.chbEmisor = New Eniac.Controles.CheckBox()
      Me.cmbEmisor = New Eniac.Controles.ComboBox()
      Me.cboLetra = New Eniac.Controles.ComboBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.txtNroRepartoHasta = New Eniac.Controles.TextBox()
      Me.lblNroRepartoHasta = New Eniac.Controles.Label()
      Me.txtNroRepartoDesde = New Eniac.Controles.TextBox()
      Me.chbNroReparto = New Eniac.Controles.CheckBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.chbPorFecha = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.cmbEstados = New Eniac.Controles.ComboBox()
      Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbTipoComprobante = New Eniac.Controles.Label()
      Me.chbImprimeLuegoDeSolicitarCAE = New Eniac.Controles.CheckBox()
      Me.dtpCambiarFecha = New Eniac.Controles.DateTimePicker()
      Me.chbCambiarFecha = New Eniac.Controles.CheckBox()
      Me.btnTesteaServidorAfip = New Eniac.Controles.Button()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.pcbAFIP = New System.Windows.Forms.PictureBox()
      Me.pcbInternet = New System.Windows.Forms.PictureBox()
      Me.lblAplicaciones = New Eniac.Controles.Label()
      Me.lblAutorización = New Eniac.Controles.Label()
        Me.chk_ExcluirComprobantesFalloCF = New Eniac.Controles.CheckBox()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbAFIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbInternet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugDetalle
        '
        resources.ApplyResources(Me.ugDetalle, "ugDetalle")
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridBand1.ColHeaderLines = 2
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance2, "Appearance2")
        UltraGridColumn1.CellAppearance = Appearance2
        resources.ApplyResources(UltraGridColumn1, "UltraGridColumn1")
        UltraGridColumn1.Header.VisiblePosition = 9
        UltraGridColumn1.Width = 100
        UltraGridColumn1.ForceApplyResources = ""
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 4
        UltraGridColumn2.Hidden = True
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn38.Header, "UltraGridColumn38.Header")
        UltraGridColumn38.Header.VisiblePosition = 5
        UltraGridColumn38.Width = 86
        UltraGridColumn38.ForceApplyResources = "Header"
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance3, "Appearance3")
        UltraGridColumn4.CellAppearance = Appearance3
        resources.ApplyResources(UltraGridColumn4.Header, "UltraGridColumn4.Header")
        UltraGridColumn4.Header.VisiblePosition = 6
        UltraGridColumn4.Width = 20
        UltraGridColumn4.ForceApplyResources = "Header"
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance4, "Appearance4")
        UltraGridColumn5.CellAppearance = Appearance4
        resources.ApplyResources(UltraGridColumn5.Header, "UltraGridColumn5.Header")
        UltraGridColumn5.Header.VisiblePosition = 7
        UltraGridColumn5.Width = 35
        UltraGridColumn5.ForceApplyResources = "Header"
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance5, "Appearance5")
        UltraGridColumn6.CellAppearance = Appearance5
        resources.ApplyResources(UltraGridColumn6.Header, "UltraGridColumn6.Header")
        UltraGridColumn6.Header.VisiblePosition = 8
        UltraGridColumn6.Width = 50
        UltraGridColumn6.ForceApplyResources = "Header"
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.VisiblePosition = 10
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.VisiblePosition = 11
        UltraGridColumn16.Hidden = True
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn9.Header, "UltraGridColumn9.Header")
        UltraGridColumn9.Header.VisiblePosition = 12
        UltraGridColumn9.Width = 156
        UltraGridColumn9.ForceApplyResources = "Header"
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn10.Header, "UltraGridColumn10.Header")
        UltraGridColumn10.Header.VisiblePosition = 26
        UltraGridColumn10.Width = 73
        UltraGridColumn10.ForceApplyResources = "Header"
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn11.Header, "UltraGridColumn11.Header")
        UltraGridColumn11.Header.VisiblePosition = 27
        UltraGridColumn11.Width = 66
        UltraGridColumn11.ForceApplyResources = "Header"
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance6, "Appearance6")
        UltraGridColumn41.CellAppearance = Appearance6
        resources.ApplyResources(UltraGridColumn41, "UltraGridColumn41")
        resources.ApplyResources(UltraGridColumn41.Header, "UltraGridColumn41.Header")
        UltraGridColumn41.Header.VisiblePosition = 17
        UltraGridColumn41.Width = 69
        UltraGridColumn41.ForceApplyResources = "|Header"
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance7, "Appearance7")
        UltraGridColumn13.CellAppearance = Appearance7
        resources.ApplyResources(UltraGridColumn13, "UltraGridColumn13")
        resources.ApplyResources(UltraGridColumn13.Header, "UltraGridColumn13.Header")
        UltraGridColumn13.Header.VisiblePosition = 18
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 70
        UltraGridColumn13.ForceApplyResources = "|Header"
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance8, "Appearance8")
        UltraGridColumn27.CellAppearance = Appearance8
        resources.ApplyResources(UltraGridColumn27, "UltraGridColumn27")
        resources.ApplyResources(UltraGridColumn27.Header, "UltraGridColumn27.Header")
        UltraGridColumn27.Header.VisiblePosition = 22
        UltraGridColumn27.Width = 64
        UltraGridColumn27.ForceApplyResources = "|Header"
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn28.Header.VisiblePosition = 25
        UltraGridColumn28.Width = 64
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.Header.VisiblePosition = 28
        UltraGridColumn26.Width = 200
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn31.Header, "UltraGridColumn31.Header")
        UltraGridColumn31.Header.VisiblePosition = 32
        UltraGridColumn31.Width = 150
        UltraGridColumn31.ForceApplyResources = "Header"
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn32.Header, "UltraGridColumn32.Header")
        UltraGridColumn32.Header.VisiblePosition = 31
        UltraGridColumn32.Width = 150
        UltraGridColumn32.ForceApplyResources = "Header"
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn7.Header, "UltraGridColumn7.Header")
        UltraGridColumn7.Header.VisiblePosition = 29
        UltraGridColumn7.Width = 130
        UltraGridColumn7.ForceApplyResources = "Header"
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn8.Header, "UltraGridColumn8.Header")
        UltraGridColumn8.Header.VisiblePosition = 30
        UltraGridColumn8.Width = 110
        UltraGridColumn8.ForceApplyResources = "Header"
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn17, "UltraGridColumn17")
        resources.ApplyResources(UltraGridColumn17.Header, "UltraGridColumn17.Header")
        UltraGridColumn17.Header.VisiblePosition = 33
        UltraGridColumn17.Width = 100
        UltraGridColumn17.ForceApplyResources = "|Header"
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn18.Header, "UltraGridColumn18.Header")
        UltraGridColumn18.Header.VisiblePosition = 34
        UltraGridColumn18.Width = 150
        UltraGridColumn18.ForceApplyResources = "Header"
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance9, "Appearance9")
        UltraGridColumn19.CellAppearance = Appearance9
        resources.ApplyResources(UltraGridColumn19, "UltraGridColumn19")
        resources.ApplyResources(UltraGridColumn19.Header, "UltraGridColumn19.Header")
        UltraGridColumn19.Header.VisiblePosition = 35
        UltraGridColumn19.Width = 80
        UltraGridColumn19.ForceApplyResources = "|Header"
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance10, "Appearance10")
        UltraGridColumn20.CellAppearance = Appearance10
        resources.ApplyResources(UltraGridColumn20, "UltraGridColumn20")
        resources.ApplyResources(UltraGridColumn20.Header, "UltraGridColumn20.Header")
        UltraGridColumn20.Header.VisiblePosition = 36
        UltraGridColumn20.Width = 80
        UltraGridColumn20.ForceApplyResources = "|Header"
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance11, "Appearance11")
        UltraGridColumn21.CellAppearance = Appearance11
        resources.ApplyResources(UltraGridColumn21, "UltraGridColumn21")
        resources.ApplyResources(UltraGridColumn21.Header, "UltraGridColumn21.Header")
        UltraGridColumn21.Header.VisiblePosition = 37
        UltraGridColumn21.Width = 80
        UltraGridColumn21.ForceApplyResources = "|Header"
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance12, "Appearance12")
        UltraGridColumn22.CellAppearance = Appearance12
        resources.ApplyResources(UltraGridColumn22, "UltraGridColumn22")
        resources.ApplyResources(UltraGridColumn22.Header, "UltraGridColumn22.Header")
        UltraGridColumn22.Header.VisiblePosition = 38
        UltraGridColumn22.Width = 80
        UltraGridColumn22.ForceApplyResources = "|Header"
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.Header.VisiblePosition = 39
        UltraGridColumn23.Hidden = True
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance13, "Appearance13")
        UltraGridColumn24.CellAppearance = Appearance13
        resources.ApplyResources(UltraGridColumn24, "UltraGridColumn24")
        resources.ApplyResources(UltraGridColumn24.Header, "UltraGridColumn24.Header")
        UltraGridColumn24.Header.VisiblePosition = 41
        UltraGridColumn24.Width = 80
        UltraGridColumn24.ForceApplyResources = "|Header"
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn25.Header, "UltraGridColumn25.Header")
        UltraGridColumn25.Header.VisiblePosition = 42
        UltraGridColumn25.ForceApplyResources = "Header"
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(UltraGridColumn33.Header, "UltraGridColumn33.Header")
        UltraGridColumn33.Header.VisiblePosition = 14
        UltraGridColumn33.Width = 37
        UltraGridColumn33.ForceApplyResources = "Header"
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance14, "Appearance14")
        UltraGridColumn34.CellAppearance = Appearance14
        resources.ApplyResources(UltraGridColumn34.Header, "UltraGridColumn34.Header")
        UltraGridColumn34.Header.VisiblePosition = 15
        UltraGridColumn34.Width = 70
        UltraGridColumn34.ForceApplyResources = "Header"
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn35.Header.VisiblePosition = 23
        UltraGridColumn35.Hidden = True
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn36.Header.VisiblePosition = 24
        UltraGridColumn36.Hidden = True
        UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn43.Header.VisiblePosition = 40
        UltraGridColumn43.Hidden = True
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 13
        resources.ApplyResources(UltraGridColumn3.Header, "UltraGridColumn3.Header")
        UltraGridColumn3.ForceApplyResources = "Header"
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance15, "Appearance15")
        UltraGridColumn37.CellAppearance = Appearance15
        resources.ApplyResources(UltraGridColumn37.Header, "UltraGridColumn37.Header")
        UltraGridColumn37.Header.VisiblePosition = 20
        UltraGridColumn37.Width = 50
        UltraGridColumn37.ForceApplyResources = "Header"
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance16, "Appearance16")
        UltraGridColumn39.CellAppearance = Appearance16
        resources.ApplyResources(UltraGridColumn39.Header, "UltraGridColumn39.Header")
        UltraGridColumn39.Header.VisiblePosition = 19
        UltraGridColumn39.Width = 64
        UltraGridColumn39.ForceApplyResources = "Header"
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        resources.ApplyResources(Appearance17, "Appearance17")
        UltraGridColumn40.CellAppearance = Appearance17
        resources.ApplyResources(UltraGridColumn40, "UltraGridColumn40")
        resources.ApplyResources(UltraGridColumn40.Header, "UltraGridColumn40.Header")
        UltraGridColumn40.Header.VisiblePosition = 21
        UltraGridColumn40.Width = 42
        UltraGridColumn40.ForceApplyResources = "|Header"
        resources.ApplyResources(Appearance18, "Appearance18")
        UltraGridColumn14.CellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance19.BackColor2 = System.Drawing.Color.Gray
        Appearance19.BorderColor3DBase = System.Drawing.Color.Gray
        UltraGridColumn14.CellButtonAppearance = Appearance19
        resources.ApplyResources(UltraGridColumn14.Header, "UltraGridColumn14.Header")
        UltraGridColumn14.Header.VisiblePosition = 1
        UltraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn14.Width = 23
        UltraGridColumn14.ForceApplyResources = "Header"
        UltraGridColumn29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        resources.ApplyResources(Appearance20, "Appearance20")
        UltraGridColumn29.Header.Appearance = Appearance20
        resources.ApplyResources(UltraGridColumn29.Header, "UltraGridColumn29.Header")
        UltraGridColumn29.Header.VisiblePosition = 2
        UltraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn29.Width = 35
        UltraGridColumn29.ForceApplyResources = "Header"
        UltraGridColumn30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        resources.ApplyResources(UltraGridColumn30.Header, "UltraGridColumn30.Header")
        UltraGridColumn30.Header.VisiblePosition = 3
        UltraGridColumn30.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn30.Width = 35
        UltraGridColumn30.ForceApplyResources = "Header"
        UltraGridColumn42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        resources.ApplyResources(Appearance21, "Appearance21")
        UltraGridColumn42.CellAppearance = Appearance21
        UltraGridColumn42.Header.VisiblePosition = 0
        UltraGridColumn42.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn42.Width = 29
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        resources.ApplyResources(Appearance22, "Appearance22")
        UltraGridColumn12.CellAppearance = Appearance22
        resources.ApplyResources(UltraGridColumn12.Header, "UltraGridColumn12.Header")
        UltraGridColumn12.Header.VisiblePosition = 16
        UltraGridColumn12.SupportDataErrorInfo = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridColumn12.Width = 41
        UltraGridColumn12.ForceApplyResources = "Header"
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn38, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn15, UltraGridColumn16, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn41, UltraGridColumn13, UltraGridColumn27, UltraGridColumn28, UltraGridColumn26, UltraGridColumn31, UltraGridColumn32, UltraGridColumn7, UltraGridColumn8, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn43, UltraGridColumn3, UltraGridColumn37, UltraGridColumn39, UltraGridColumn40, UltraGridColumn14, UltraGridColumn29, UltraGridColumn30, UltraGridColumn42, UltraGridColumn12})
        resources.ApplyResources(Appearance23, "Appearance23")
        UltraGridBand1.Header.Appearance = Appearance23
        UltraGridBand1.Header.FixOnRight = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand1.Header.TextOrientation = New Infragistics.Win.TextOrientationInfo(0, Infragistics.Win.TextFlowDirection.Horizontal)
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance24.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance24
        Appearance25.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = resources.GetString("ugDetalle.DisplayLayout.GroupByBox.Prompt")
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance26.BackColor2 = System.Drawing.SystemColors.Control
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance26.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance26
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance27
        Appearance28.BackColor = System.Drawing.SystemColors.Highlight
        Appearance28.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance29
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Appearance30.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance31.BackColor = System.Drawing.SystemColors.Control
        Appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance31
        resources.ApplyResources(Appearance32, "Appearance32")
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance32
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance34.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance34
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Name = "ugDetalle"
        '
        'cmbCajas
        '
        resources.ApplyResources(Me.cmbCajas, "cmbCajas")
        Me.cmbCajas.BindearPropiedadControl = ""
        Me.cmbCajas.BindearPropiedadEntidad = ""
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCaja
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.TabStop = False
        '
        'lblCaja
        '
        resources.ApplyResources(Me.lblCaja, "lblCaja")
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Name = "lblCaja"
        '
        'chbTodos
        '
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.chbTodos, "chbTodos")
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspBarra, Me.tssInfo, Me.tssRegistros})
        resources.ApplyResources(Me.stsStado, "stsStado")
        Me.stsStado.Name = "stsStado"
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        resources.ApplyResources(Me.tspBarra, "tspBarra")
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        resources.ApplyResources(Me.tssInfo, "tssInfo")
        Me.tssInfo.Spring = True
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        resources.ApplyResources(Me.tssRegistros, "tssRegistros")
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbObtenerCAEs, Me.tsbConfigurarMail, Me.tsbConsultarUltimoComprobante, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
        resources.ApplyResources(Me.tstBarra, "tstBarra")
        Me.tstBarra.Name = "tstBarra"
        '
        'tsbRefrescar
        '
        resources.ApplyResources(Me.tsbRefrescar, "tsbRefrescar")
        Me.tsbRefrescar.Name = "tsbRefrescar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'tsbObtenerCAEs
        '
        resources.ApplyResources(Me.tsbObtenerCAEs, "tsbObtenerCAEs")
        Me.tsbObtenerCAEs.Name = "tsbObtenerCAEs"
        '
        'tsbConfigurarMail
        '
        resources.ApplyResources(Me.tsbConfigurarMail, "tsbConfigurarMail")
        Me.tsbConfigurarMail.Name = "tsbConfigurarMail"
        '
        'tsbConsultarUltimoComprobante
        '
        resources.ApplyResources(Me.tsbConsultarUltimoComprobante, "tsbConsultarUltimoComprobante")
        Me.tsbConsultarUltimoComprobante.Name = "tsbConsultarUltimoComprobante"
        '
        'tsbPreferencias
        '
        resources.ApplyResources(Me.tsbPreferencias, "tsbPreferencias")
        Me.tsbPreferencias.Name = "tsbPreferencias"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'tsbSalir
        '
        resources.ApplyResources(Me.tsbSalir, "tsbSalir")
        Me.tsbSalir.Name = "tsbSalir"
        '
        'grbFiltros
        '
        resources.ApplyResources(Me.grbFiltros, "grbFiltros")
        Me.grbFiltros.Controls.Add(Me.chk_ExcluirComprobantesFalloCF)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.chbFormaPago)
        Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.chbUsuario)
        Me.grbFiltros.Controls.Add(Me.cmbUsuario)
        Me.grbFiltros.Controls.Add(Me.chbCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbCategoria)
        Me.grbFiltros.Controls.Add(Me.chbLetra)
        Me.grbFiltros.Controls.Add(Me.chbEmisor)
        Me.grbFiltros.Controls.Add(Me.cmbEmisor)
        Me.grbFiltros.Controls.Add(Me.cboLetra)
        Me.grbFiltros.Controls.Add(Me.txtNumero)
        Me.grbFiltros.Controls.Add(Me.chbNumero)
        Me.grbFiltros.Controls.Add(Me.txtNroRepartoHasta)
        Me.grbFiltros.Controls.Add(Me.txtNroRepartoDesde)
        Me.grbFiltros.Controls.Add(Me.chbNroReparto)
        Me.grbFiltros.Controls.Add(Me.lblEstado)
        Me.grbFiltros.Controls.Add(Me.chbPorFecha)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblNroRepartoHasta)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.cmbEstados)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.TabStop = False
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
        resources.ApplyResources(Me.bscCodigoCliente, "bscCodigoCliente")
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        resources.ApplyResources(Me.lblCodigoCliente, "lblCodigoCliente")
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        '
        'bscCliente
        '
        resources.ApplyResources(Me.bscCliente, "bscCliente")
        Me.bscCliente.AyudaAncho = 608
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ColumnasAlineacion = Nothing
        Me.bscCliente.ColumnasAncho = Nothing
        Me.bscCliente.ColumnasFormato = Nothing
        Me.bscCliente.ColumnasOcultas = Nothing
        Me.bscCliente.ColumnasTitulos = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        resources.ApplyResources(Me.lblNombre, "lblNombre")
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Name = "lblNombre"
        '
        'chbCliente
        '
        resources.ApplyResources(Me.chbCliente, "chbCliente")
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'chbFormaPago
        '
        resources.ApplyResources(Me.chbFormaPago, "chbFormaPago")
        Me.chbFormaPago.BindearPropiedadControl = Nothing
        Me.chbFormaPago.BindearPropiedadEntidad = Nothing
        Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFormaPago.IsPK = False
        Me.chbFormaPago.IsRequired = False
        Me.chbFormaPago.Key = Nothing
        Me.chbFormaPago.LabelAsoc = Nothing
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.UseVisualStyleBackColor = True
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbFormaPago, "cmbFormaPago")
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Nothing
        Me.cmbFormaPago.Name = "cmbFormaPago"
        '
        'chbVendedor
        '
        resources.ApplyResources(Me.chbVendedor, "chbVendedor")
        Me.chbVendedor.BindearPropiedadControl = Nothing
        Me.chbVendedor.BindearPropiedadEntidad = Nothing
        Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVendedor.IsPK = False
        Me.chbVendedor.IsRequired = False
        Me.chbVendedor.Key = Nothing
        Me.chbVendedor.LabelAsoc = Nothing
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbVendedor, "cmbVendedor")
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Nothing
        Me.cmbVendedor.Name = "cmbVendedor"
        '
        'chbUsuario
        '
        resources.ApplyResources(Me.chbUsuario, "chbUsuario")
        Me.chbUsuario.BindearPropiedadControl = Nothing
        Me.chbUsuario.BindearPropiedadEntidad = Nothing
        Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuario.IsPK = False
        Me.chbUsuario.IsRequired = False
        Me.chbUsuario.Key = Nothing
        Me.chbUsuario.LabelAsoc = Nothing
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'cmbUsuario
        '
        Me.cmbUsuario.BindearPropiedadControl = Nothing
        Me.cmbUsuario.BindearPropiedadEntidad = Nothing
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbUsuario, "cmbUsuario")
        Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.IsPK = False
        Me.cmbUsuario.IsRequired = False
        Me.cmbUsuario.Key = Nothing
        Me.cmbUsuario.LabelAsoc = Nothing
        Me.cmbUsuario.Name = "cmbUsuario"
        '
        'chbCategoria
        '
        resources.ApplyResources(Me.chbCategoria, "chbCategoria")
        Me.chbCategoria.BindearPropiedadControl = Nothing
        Me.chbCategoria.BindearPropiedadEntidad = Nothing
        Me.chbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoria.IsPK = False
        Me.chbCategoria.IsRequired = False
        Me.chbCategoria.Key = Nothing
        Me.chbCategoria.LabelAsoc = Nothing
        Me.chbCategoria.Name = "chbCategoria"
        Me.chbCategoria.UseVisualStyleBackColor = True
        '
        'cmbCategoria
        '
        Me.cmbCategoria.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoria.BindearPropiedadEntidad = "Categoria.IdCategoria"
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbCategoria, "cmbCategoria")
        Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.IsPK = False
        Me.cmbCategoria.IsRequired = True
        Me.cmbCategoria.Key = Nothing
        Me.cmbCategoria.LabelAsoc = Nothing
        Me.cmbCategoria.Name = "cmbCategoria"
        '
        'chbLetra
        '
        resources.ApplyResources(Me.chbLetra, "chbLetra")
        Me.chbLetra.BindearPropiedadControl = Nothing
        Me.chbLetra.BindearPropiedadEntidad = Nothing
        Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLetra.IsPK = False
        Me.chbLetra.IsRequired = False
        Me.chbLetra.Key = Nothing
        Me.chbLetra.LabelAsoc = Nothing
        Me.chbLetra.Name = "chbLetra"
        Me.chbLetra.UseVisualStyleBackColor = True
        '
        'chbEmisor
        '
        resources.ApplyResources(Me.chbEmisor, "chbEmisor")
        Me.chbEmisor.BindearPropiedadControl = Nothing
        Me.chbEmisor.BindearPropiedadEntidad = Nothing
        Me.chbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmisor.IsPK = False
        Me.chbEmisor.IsRequired = False
        Me.chbEmisor.Key = Nothing
        Me.chbEmisor.LabelAsoc = Nothing
        Me.chbEmisor.Name = "chbEmisor"
        Me.chbEmisor.UseVisualStyleBackColor = True
        '
        'cmbEmisor
        '
        Me.cmbEmisor.BindearPropiedadControl = Nothing
        Me.cmbEmisor.BindearPropiedadEntidad = Nothing
        Me.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbEmisor, "cmbEmisor")
        Me.cmbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEmisor.FormattingEnabled = True
        Me.cmbEmisor.IsPK = False
        Me.cmbEmisor.IsRequired = False
        Me.cmbEmisor.Key = Nothing
        Me.cmbEmisor.LabelAsoc = Nothing
        Me.cmbEmisor.Name = "cmbEmisor"
        '
        'cboLetra
        '
        Me.cboLetra.BindearPropiedadControl = Nothing
        Me.cboLetra.BindearPropiedadEntidad = Nothing
        Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboLetra, "cboLetra")
        Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboLetra.FormattingEnabled = True
        Me.cboLetra.IsPK = False
        Me.cboLetra.IsRequired = False
        Me.cboLetra.Key = Nothing
        Me.cboLetra.LabelAsoc = Nothing
        Me.cboLetra.Name = "cboLetra"
        '
        'txtNumero
        '
        Me.txtNumero.BindearPropiedadControl = Nothing
        Me.txtNumero.BindearPropiedadEntidad = Nothing
        resources.ApplyResources(Me.txtNumero, "txtNumero")
        Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumero.Formato = "##0"
        Me.txtNumero.IsDecimal = False
        Me.txtNumero.IsNumber = True
        Me.txtNumero.IsPK = False
        Me.txtNumero.IsRequired = False
        Me.txtNumero.Key = ""
        Me.txtNumero.LabelAsoc = Nothing
        Me.txtNumero.Name = "txtNumero"
        '
        'chbNumero
        '
        resources.ApplyResources(Me.chbNumero, "chbNumero")
        Me.chbNumero.BindearPropiedadControl = Nothing
        Me.chbNumero.BindearPropiedadEntidad = Nothing
        Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumero.IsPK = False
        Me.chbNumero.IsRequired = False
        Me.chbNumero.Key = Nothing
        Me.chbNumero.LabelAsoc = Nothing
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.UseVisualStyleBackColor = True
        '
        'txtNroRepartoHasta
        '
        Me.txtNroRepartoHasta.BindearPropiedadControl = Nothing
        Me.txtNroRepartoHasta.BindearPropiedadEntidad = Nothing
        resources.ApplyResources(Me.txtNroRepartoHasta, "txtNroRepartoHasta")
        Me.txtNroRepartoHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroRepartoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroRepartoHasta.Formato = "##0"
        Me.txtNroRepartoHasta.IsDecimal = False
        Me.txtNroRepartoHasta.IsNumber = True
        Me.txtNroRepartoHasta.IsPK = False
        Me.txtNroRepartoHasta.IsRequired = False
        Me.txtNroRepartoHasta.Key = ""
        Me.txtNroRepartoHasta.LabelAsoc = Me.lblNroRepartoHasta
        Me.txtNroRepartoHasta.Name = "txtNroRepartoHasta"
        '
        'lblNroRepartoHasta
        '
        resources.ApplyResources(Me.lblNroRepartoHasta, "lblNroRepartoHasta")
        Me.lblNroRepartoHasta.LabelAsoc = Nothing
        Me.lblNroRepartoHasta.Name = "lblNroRepartoHasta"
        '
        'txtNroRepartoDesde
        '
        Me.txtNroRepartoDesde.BindearPropiedadControl = Nothing
        Me.txtNroRepartoDesde.BindearPropiedadEntidad = Nothing
        resources.ApplyResources(Me.txtNroRepartoDesde, "txtNroRepartoDesde")
        Me.txtNroRepartoDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroRepartoDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroRepartoDesde.Formato = "##0"
        Me.txtNroRepartoDesde.IsDecimal = False
        Me.txtNroRepartoDesde.IsNumber = True
        Me.txtNroRepartoDesde.IsPK = False
        Me.txtNroRepartoDesde.IsRequired = False
        Me.txtNroRepartoDesde.Key = ""
        Me.txtNroRepartoDesde.LabelAsoc = Nothing
        Me.txtNroRepartoDesde.Name = "txtNroRepartoDesde"
        '
        'chbNroReparto
        '
        resources.ApplyResources(Me.chbNroReparto, "chbNroReparto")
        Me.chbNroReparto.BindearPropiedadControl = Nothing
        Me.chbNroReparto.BindearPropiedadEntidad = Nothing
        Me.chbNroReparto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNroReparto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNroReparto.IsPK = False
        Me.chbNroReparto.IsRequired = False
        Me.chbNroReparto.Key = Nothing
        Me.chbNroReparto.LabelAsoc = Nothing
        Me.chbNroReparto.Name = "chbNroReparto"
        Me.chbNroReparto.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        resources.ApplyResources(Me.lblEstado, "lblEstado")
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Name = "lblEstado"
        '
        'chbPorFecha
        '
        resources.ApplyResources(Me.chbPorFecha, "chbPorFecha")
        Me.chbPorFecha.BindearPropiedadControl = Nothing
        Me.chbPorFecha.BindearPropiedadEntidad = Nothing
        Me.chbPorFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPorFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPorFecha.IsPK = False
        Me.chbPorFecha.IsRequired = False
        Me.chbPorFecha.Key = Nothing
        Me.chbPorFecha.LabelAsoc = Nothing
        Me.chbPorFecha.Name = "chbPorFecha"
        Me.chbPorFecha.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        resources.ApplyResources(Me.dtpHasta, "dtpHasta")
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Name = "dtpHasta"
        '
        'lblHasta
        '
        resources.ApplyResources(Me.lblHasta, "lblHasta")
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Name = "lblHasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        resources.ApplyResources(Me.dtpDesde, "dtpDesde")
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Name = "dtpDesde"
        '
        'lblDesde
        '
        resources.ApplyResources(Me.lblDesde, "lblDesde")
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Name = "lblDesde"
        '
        'cmbEstados
        '
        Me.cmbEstados.BindearPropiedadControl = Nothing
        Me.cmbEstados.BindearPropiedadEntidad = Nothing
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbEstados, "cmbEstados")
        Me.cmbEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.IsPK = False
        Me.cmbEstados.IsRequired = False
        Me.cmbEstados.Items.AddRange(New Object() {resources.GetString("cmbEstados.Items"), resources.GetString("cmbEstados.Items1"), resources.GetString("cmbEstados.Items2")})
        Me.cmbEstados.Key = Nothing
        Me.cmbEstados.LabelAsoc = Me.lblEstado
        Me.cmbEstados.Name = "cmbEstados"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbTiposComprobantes, "cmbTiposComprobantes")
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        '
        'btnConsultar
        '
        resources.ApplyResources(Me.btnConsultar, "btnConsultar")
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbTipoComprobante
        '
        resources.ApplyResources(Me.chbTipoComprobante, "chbTipoComprobante")
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        '
        'chbImprimeLuegoDeSolicitarCAE
        '
        resources.ApplyResources(Me.chbImprimeLuegoDeSolicitarCAE, "chbImprimeLuegoDeSolicitarCAE")
        Me.chbImprimeLuegoDeSolicitarCAE.BindearPropiedadControl = Nothing
        Me.chbImprimeLuegoDeSolicitarCAE.BindearPropiedadEntidad = Nothing
        Me.chbImprimeLuegoDeSolicitarCAE.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImprimeLuegoDeSolicitarCAE.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImprimeLuegoDeSolicitarCAE.IsPK = False
        Me.chbImprimeLuegoDeSolicitarCAE.IsRequired = False
        Me.chbImprimeLuegoDeSolicitarCAE.Key = Nothing
        Me.chbImprimeLuegoDeSolicitarCAE.LabelAsoc = Nothing
        Me.chbImprimeLuegoDeSolicitarCAE.Name = "chbImprimeLuegoDeSolicitarCAE"
        Me.chbImprimeLuegoDeSolicitarCAE.UseVisualStyleBackColor = True
        '
        'dtpCambiarFecha
        '
        Me.dtpCambiarFecha.BindearPropiedadControl = Nothing
        Me.dtpCambiarFecha.BindearPropiedadEntidad = Nothing
        resources.ApplyResources(Me.dtpCambiarFecha, "dtpCambiarFecha")
        Me.dtpCambiarFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpCambiarFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpCambiarFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCambiarFecha.IsPK = False
        Me.dtpCambiarFecha.IsRequired = False
        Me.dtpCambiarFecha.Key = ""
        Me.dtpCambiarFecha.LabelAsoc = Me.lblDesde
        Me.dtpCambiarFecha.Name = "dtpCambiarFecha"
        '
        'chbCambiarFecha
        '
        resources.ApplyResources(Me.chbCambiarFecha, "chbCambiarFecha")
        Me.chbCambiarFecha.BindearPropiedadControl = Nothing
        Me.chbCambiarFecha.BindearPropiedadEntidad = Nothing
        Me.chbCambiarFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCambiarFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCambiarFecha.IsPK = False
        Me.chbCambiarFecha.IsRequired = False
        Me.chbCambiarFecha.Key = Nothing
        Me.chbCambiarFecha.LabelAsoc = Nothing
        Me.chbCambiarFecha.Name = "chbCambiarFecha"
        Me.chbCambiarFecha.UseVisualStyleBackColor = True
        '
        'btnTesteaServidorAfip
        '
        resources.ApplyResources(Me.btnTesteaServidorAfip, "btnTesteaServidorAfip")
        Me.btnTesteaServidorAfip.Image = Global.Eniac.Win.My.Resources.Resources.play_16
        Me.btnTesteaServidorAfip.Name = "btnTesteaServidorAfip"
        Me.btnTesteaServidorAfip.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.pcbAFIP)
        Me.GroupBox1.Controls.Add(Me.pcbInternet)
        Me.GroupBox1.Controls.Add(Me.lblAplicaciones)
        Me.GroupBox1.Controls.Add(Me.lblAutorización)
        Me.GroupBox1.Controls.Add(Me.btnTesteaServidorAfip)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'pcbAFIP
        '
        resources.ApplyResources(Me.pcbAFIP, "pcbAFIP")
        Me.pcbAFIP.Name = "pcbAFIP"
        Me.pcbAFIP.TabStop = False
        '
        'pcbInternet
        '
        resources.ApplyResources(Me.pcbInternet, "pcbInternet")
        Me.pcbInternet.Name = "pcbInternet"
        Me.pcbInternet.TabStop = False
        '
        'lblAplicaciones
        '
        resources.ApplyResources(Me.lblAplicaciones, "lblAplicaciones")
        Me.lblAplicaciones.LabelAsoc = Nothing
        Me.lblAplicaciones.Name = "lblAplicaciones"
        '
        'lblAutorización
        '
        resources.ApplyResources(Me.lblAutorización, "lblAutorización")
        Me.lblAutorización.LabelAsoc = Nothing
        Me.lblAutorización.Name = "lblAutorización"
        '
        'chk_ExcluirComprobantesFalloCF
        '
        resources.ApplyResources(Me.chk_ExcluirComprobantesFalloCF, "chk_ExcluirComprobantesFalloCF")
        Me.chk_ExcluirComprobantesFalloCF.BindearPropiedadControl = Nothing
        Me.chk_ExcluirComprobantesFalloCF.BindearPropiedadEntidad = Nothing
        Me.chk_ExcluirComprobantesFalloCF.Checked = True
        Me.chk_ExcluirComprobantesFalloCF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_ExcluirComprobantesFalloCF.ForeColorFocus = System.Drawing.Color.Red
        Me.chk_ExcluirComprobantesFalloCF.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chk_ExcluirComprobantesFalloCF.IsPK = False
        Me.chk_ExcluirComprobantesFalloCF.IsRequired = False
        Me.chk_ExcluirComprobantesFalloCF.Key = Nothing
        Me.chk_ExcluirComprobantesFalloCF.LabelAsoc = Nothing
        Me.chk_ExcluirComprobantesFalloCF.Name = "chk_ExcluirComprobantesFalloCF"
        Me.chk_ExcluirComprobantesFalloCF.UseVisualStyleBackColor = True
        '
        'SolicitarCAE
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.cmbCajas)
        Me.Controls.Add(Me.lblCaja)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.chbCambiarFecha)
        Me.Controls.Add(Me.dtpCambiarFecha)
        Me.Controls.Add(Me.chbImprimeLuegoDeSolicitarCAE)
        Me.KeyPreview = True
        Me.Name = "SolicitarCAE"
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcbAFIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbInternet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTipoComprobante As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbEstados As Eniac.Controles.ComboBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbPorFecha As Eniac.Controles.CheckBox
   Friend WithEvents tsbObtenerCAEs As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents dtpCambiarFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents chbCambiarFecha As Eniac.Controles.CheckBox
   Friend WithEvents tsbConfigurarMail As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbImprimeLuegoDeSolicitarCAE As Eniac.Controles.CheckBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tsbConsultarUltimoComprobante As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtNroRepartoDesde As Eniac.Controles.TextBox
   Friend WithEvents chbNroReparto As Eniac.Controles.CheckBox
   Friend WithEvents txtNroRepartoHasta As Eniac.Controles.TextBox
   Friend WithEvents lblNroRepartoHasta As Eniac.Controles.Label
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents chbEmisor As Eniac.Controles.CheckBox
   Friend WithEvents cmbEmisor As Eniac.Controles.ComboBox
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents btnTesteaServidorAfip As Eniac.Controles.Button
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents lblAutorización As Eniac.Controles.Label
   Friend WithEvents lblAplicaciones As Eniac.Controles.Label
   Friend WithEvents pcbAFIP As System.Windows.Forms.PictureBox
   Friend WithEvents pcbInternet As System.Windows.Forms.PictureBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
    Friend WithEvents chk_ExcluirComprobantesFalloCF As Controles.CheckBox
End Class
