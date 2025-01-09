<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChequesMovimientosSucursales
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChequesMovimientosSucursales))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Aplicar")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoCheque")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ingreso")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCajaIngreso")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroPlanillaIngreso")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroMovimientoIngreso")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Egreso")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCajaEgreso")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroPlanillaEgreso")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroMovimientoEgreso")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FotoFrente")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FotoDorso")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
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
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Aplicar")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTarjeta")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTarjeta")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroLote")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCupon")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Monto")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoTarjeta")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSituacion")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuotas")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.ugDetalle = New Eniac.Win.UltraGridSiga()
        Me.lblFechaCobro = New Eniac.Controles.Label()
        Me.dtpFechaCobroHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaCobroHasta = New Eniac.Controles.Label()
        Me.dtpFechaCobroDesde = New Eniac.Controles.DateTimePicker()
        Me.lblFechaCobroDesde = New Eniac.Controles.Label()
        Me.cmbCajasOrigen = New Eniac.Controles.ComboBox()
        Me.lblCajaOrigen = New Eniac.Controles.Label()
        Me.lblSucursalDestino = New Eniac.Controles.Label()
        Me.cmbSucursalDestino = New Eniac.Controles.ComboBox()
        Me.btnMover = New Eniac.Controles.Button()
        Me.cmbCajasDestino = New Eniac.Controles.ComboBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.lblTickets = New Eniac.Controles.Label()
        Me.lblDolares = New Eniac.Controles.Label()
        Me.lblPesos = New Eniac.Controles.Label()
        Me.txtPesos = New Eniac.Controles.TextBox()
        Me.txtTickets = New Eniac.Controles.TextBox()
        Me.txtDolares = New Eniac.Controles.TextBox()
        Me.txtPACCheques = New Eniac.Controles.MaskedTextBox()
        Me.txtPACTarjetas = New Eniac.Controles.MaskedTextBox()
        Me.lblPACTarjetas = New Eniac.Controles.Label()
        Me.txtPACTickets = New Eniac.Controles.MaskedTextBox()
        Me.txtPACDolares = New Eniac.Controles.MaskedTextBox()
        Me.lblPACDolares = New Eniac.Controles.Label()
        Me.txtPACEfectivo = New Eniac.Controles.MaskedTextBox()
        Me.Label7 = New Eniac.Controles.Label()
        Me.Label9 = New Eniac.Controles.Label()
        Me.lblPesosActual = New Eniac.Controles.Label()
        Me.txtPACCheques2 = New Eniac.Controles.MaskedTextBox()
        Me.txtPACTarjetas2 = New Eniac.Controles.MaskedTextBox()
        Me.lblPACTarjetas2 = New Eniac.Controles.Label()
        Me.txtPACTickets2 = New Eniac.Controles.MaskedTextBox()
        Me.txtPACDolares2 = New Eniac.Controles.MaskedTextBox()
        Me.lblPACDolares2 = New Eniac.Controles.Label()
        Me.txtPACEfectivo2 = New Eniac.Controles.MaskedTextBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.Label3 = New Eniac.Controles.Label()
        Me.Label5 = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbcMovimientos = New System.Windows.Forms.TabControl()
        Me.tpgCarteraCheques = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.tpgTarjetasCupones = New System.Windows.Forms.TabPage()
        Me.dtpDesdeEmision = New Eniac.Controles.DateTimePicker()
        Me.lblDesdeEmision = New Eniac.Controles.Label()
        Me.btnTodosTrj = New System.Windows.Forms.Button()
        Me.dtpHastaEmision = New Eniac.Controles.DateTimePicker()
        Me.lblHastaEmision = New Eniac.Controles.Label()
        Me.cmbTodosTrj = New Eniac.Controles.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.bscNombreCliente = New Eniac.Controles.Buscador2()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.cmbBanco = New Eniac.Controles.ComboBox()
        Me.chbBanco = New Eniac.Controles.CheckBox()
        Me.chbNumeroLote = New Eniac.Controles.CheckBox()
        Me.btnConsultarTrj = New Eniac.Controles.Button()
        Me.txtNumeroLote = New Eniac.Controles.TextBox()
        Me.chbNumeroCupon = New Eniac.Controles.CheckBox()
        Me.txtNumeroCupon = New Eniac.Controles.TextBox()
        Me.cmbTarjeta = New Eniac.Controles.ComboBox()
        Me.chbTarjeta = New Eniac.Controles.CheckBox()
        Me.chbMesCompleto = New Eniac.Controles.CheckBox()
        Me.chbFechaEmision = New Eniac.Controles.CheckBox()
        Me.ugTarjetas = New Eniac.Win.UltraGridSiga()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblCotizacionDolares = New Eniac.Controles.Label()
        Me.pnlBancos3 = New System.Windows.Forms.Panel()
        Me.Label2 = New Eniac.Controles.Label()
        Me.txtBancos = New Eniac.Controles.TextBox()
        Me.txtCotizacionDolares = New Eniac.Controles.TextBox()
        Me.dtpFecha = New Eniac.Controles.DateTimePicker()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.pnlSaldosCuentaDestino = New System.Windows.Forms.Panel()
        Me.pnlBancos2 = New System.Windows.Forms.Panel()
        Me.txtPACBancos2 = New Eniac.Controles.MaskedTextBox()
        Me.lblPACBancos2 = New Eniac.Controles.Label()
        Me.txtPACBancos = New Eniac.Controles.MaskedTextBox()
        Me.lblPACBancos = New Eniac.Controles.Label()
        Me.pnlBancos = New System.Windows.Forms.Panel()
        Me.Label4 = New Eniac.Controles.Label()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tbcMovimientos.SuspendLayout()
        Me.tpgCarteraCheques.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.tpgTarjetasCupones.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.ugTarjetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnlBancos3.SuspendLayout()
        Me.pnlSaldosCuentaDestino.SuspendLayout()
        Me.pnlBancos2.SuspendLayout()
        Me.pnlBancos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbSalir})
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 606)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 3
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
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(852, 10)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 30)
        Me.btnConsultar.TabIndex = 6
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(874, 55)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 9
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
        Me.cmbTodos.Location = New System.Drawing.Point(747, 56)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 8
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
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 30
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Header.Caption = "Id Cliente"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance4
        UltraGridColumn3.Header.Caption = "Código Cliente"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn4.Header.Caption = "Tipo Cheque"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 100
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance5
        UltraGridColumn5.Header.Caption = "Código Banco"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn6.Header.Caption = "Banco"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 100
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance6
        UltraGridColumn7.Header.Caption = "Suc."
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 40
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance7
        UltraGridColumn8.Header.Caption = "C.P."
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn9.Header.Caption = "Localidad"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 90
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance8
        UltraGridColumn10.Header.Caption = "Número"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 70
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance9
        UltraGridColumn11.Header.Caption = "Nro. Operación"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Width = 99
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn12.CellAppearance = Appearance10
        UltraGridColumn12.Format = "dd/MM/yyyy"
        UltraGridColumn12.Header.Caption = "Emisión"
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Width = 70
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn13.CellAppearance = Appearance11
        UltraGridColumn13.Format = "dd/MM/yyyy"
        UltraGridColumn13.Header.Caption = "Cobro"
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Width = 70
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance12
        UltraGridColumn14.Format = "N2"
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Width = 80
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Width = 110
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance13
        UltraGridColumn16.Header.Caption = "Código Estado Cheque"
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn17.Header.Caption = "Cliente"
        UltraGridColumn17.Header.VisiblePosition = 17
        UltraGridColumn17.Width = 200
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn18.Format = "N2"
        UltraGridColumn18.Header.VisiblePosition = 16
        UltraGridColumn18.Width = 250
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance14
        UltraGridColumn19.Header.Caption = "Código Caja Ingreso"
        UltraGridColumn19.Header.VisiblePosition = 18
        UltraGridColumn19.Hidden = True
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance15
        UltraGridColumn20.Header.Caption = "Nro. Planilla Ingreso"
        UltraGridColumn20.Header.VisiblePosition = 19
        UltraGridColumn20.Hidden = True
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance16
        UltraGridColumn21.Header.Caption = "Nro. Movimiento Ingreso"
        UltraGridColumn21.Header.VisiblePosition = 20
        UltraGridColumn21.Hidden = True
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn22.Header.Caption = "Proveedor"
        UltraGridColumn22.Header.VisiblePosition = 22
        UltraGridColumn22.Width = 200
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn23.Header.VisiblePosition = 21
        UltraGridColumn23.Width = 250
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance17
        UltraGridColumn24.Header.Caption = "Código Caja Egreso"
        UltraGridColumn24.Header.VisiblePosition = 23
        UltraGridColumn24.Hidden = True
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance18
        UltraGridColumn25.Header.Caption = "Nro. Planilla Egreso"
        UltraGridColumn25.Header.VisiblePosition = 24
        UltraGridColumn25.Hidden = True
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance19
        UltraGridColumn26.Header.Caption = "Nro. Movimiento Egreso"
        UltraGridColumn26.Header.VisiblePosition = 25
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn27.Header.VisiblePosition = 26
        UltraGridColumn27.Hidden = True
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn28.Header.VisiblePosition = 27
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance20
        UltraGridColumn29.Header.Caption = "Código Tipo Cheque"
        UltraGridColumn29.Header.VisiblePosition = 28
        UltraGridColumn29.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance21.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance21
        Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance22
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance23.BackColor2 = System.Drawing.SystemColors.Control
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance23
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.SystemColors.Highlight
        Appearance25.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance26
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance28.BackColor = System.Drawing.SystemColors.Control
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance28
        Appearance29.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance31
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(7, 48)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(948, 295)
        Me.ugDetalle.TabIndex = 7
        Me.ugDetalle.Text = "UltraGrid1"
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'lblFechaCobro
        '
        Me.lblFechaCobro.AutoSize = True
        Me.lblFechaCobro.LabelAsoc = Nothing
        Me.lblFechaCobro.Location = New System.Drawing.Point(5, 11)
        Me.lblFechaCobro.Name = "lblFechaCobro"
        Me.lblFechaCobro.Size = New System.Drawing.Size(68, 13)
        Me.lblFechaCobro.TabIndex = 0
        Me.lblFechaCobro.Text = "Fecha Cobro"
        '
        'dtpFechaCobroHasta
        '
        Me.dtpFechaCobroHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaCobroHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaCobroHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaCobroHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCobroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCobroHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCobroHasta.IsPK = False
        Me.dtpFechaCobroHasta.IsRequired = False
        Me.dtpFechaCobroHasta.Key = ""
        Me.dtpFechaCobroHasta.LabelAsoc = Me.lblFechaCobroHasta
        Me.dtpFechaCobroHasta.Location = New System.Drawing.Point(260, 13)
        Me.dtpFechaCobroHasta.Name = "dtpFechaCobroHasta"
        Me.dtpFechaCobroHasta.Size = New System.Drawing.Size(83, 20)
        Me.dtpFechaCobroHasta.TabIndex = 4
        '
        'lblFechaCobroHasta
        '
        Me.lblFechaCobroHasta.AutoSize = True
        Me.lblFechaCobroHasta.LabelAsoc = Nothing
        Me.lblFechaCobroHasta.Location = New System.Drawing.Point(212, 11)
        Me.lblFechaCobroHasta.Name = "lblFechaCobroHasta"
        Me.lblFechaCobroHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaCobroHasta.TabIndex = 3
        Me.lblFechaCobroHasta.Text = "Hasta"
        '
        'dtpFechaCobroDesde
        '
        Me.dtpFechaCobroDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaCobroDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaCobroDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaCobroDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCobroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCobroDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCobroDesde.IsPK = False
        Me.dtpFechaCobroDesde.IsRequired = False
        Me.dtpFechaCobroDesde.Key = ""
        Me.dtpFechaCobroDesde.LabelAsoc = Me.lblFechaCobroDesde
        Me.dtpFechaCobroDesde.Location = New System.Drawing.Point(130, 13)
        Me.dtpFechaCobroDesde.Name = "dtpFechaCobroDesde"
        Me.dtpFechaCobroDesde.Size = New System.Drawing.Size(83, 20)
        Me.dtpFechaCobroDesde.TabIndex = 2
        '
        'lblFechaCobroDesde
        '
        Me.lblFechaCobroDesde.AutoSize = True
        Me.lblFechaCobroDesde.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaCobroDesde.LabelAsoc = Nothing
        Me.lblFechaCobroDesde.Location = New System.Drawing.Point(79, 11)
        Me.lblFechaCobroDesde.Name = "lblFechaCobroDesde"
        Me.lblFechaCobroDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaCobroDesde.TabIndex = 1
        Me.lblFechaCobroDesde.Text = "Desde"
        '
        'cmbCajasOrigen
        '
        Me.cmbCajasOrigen.BindearPropiedadControl = ""
        Me.cmbCajasOrigen.BindearPropiedadEntidad = ""
        Me.cmbCajasOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajasOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajasOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajasOrigen.FormattingEnabled = True
        Me.cmbCajasOrigen.IsPK = False
        Me.cmbCajasOrigen.IsRequired = False
        Me.cmbCajasOrigen.Key = Nothing
        Me.cmbCajasOrigen.LabelAsoc = Me.lblCajaOrigen
        Me.cmbCajasOrigen.Location = New System.Drawing.Point(111, 19)
        Me.cmbCajasOrigen.Name = "cmbCajasOrigen"
        Me.cmbCajasOrigen.Size = New System.Drawing.Size(145, 21)
        Me.cmbCajasOrigen.TabIndex = 1
        '
        'lblCajaOrigen
        '
        Me.lblCajaOrigen.AutoSize = True
        Me.lblCajaOrigen.LabelAsoc = Nothing
        Me.lblCajaOrigen.Location = New System.Drawing.Point(38, 22)
        Me.lblCajaOrigen.Name = "lblCajaOrigen"
        Me.lblCajaOrigen.Size = New System.Drawing.Size(62, 13)
        Me.lblCajaOrigen.TabIndex = 0
        Me.lblCajaOrigen.Text = "Caja Origen"
        '
        'lblSucursalDestino
        '
        Me.lblSucursalDestino.AutoSize = True
        Me.lblSucursalDestino.LabelAsoc = Nothing
        Me.lblSucursalDestino.Location = New System.Drawing.Point(23, 9)
        Me.lblSucursalDestino.Name = "lblSucursalDestino"
        Me.lblSucursalDestino.Size = New System.Drawing.Size(87, 13)
        Me.lblSucursalDestino.TabIndex = 0
        Me.lblSucursalDestino.Text = "Sucursal Destino"
        '
        'cmbSucursalDestino
        '
        Me.cmbSucursalDestino.BindearPropiedadControl = Nothing
        Me.cmbSucursalDestino.BindearPropiedadEntidad = Nothing
        Me.cmbSucursalDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursalDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursalDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursalDestino.FormattingEnabled = True
        Me.cmbSucursalDestino.IsPK = False
        Me.cmbSucursalDestino.IsRequired = False
        Me.cmbSucursalDestino.Key = Nothing
        Me.cmbSucursalDestino.LabelAsoc = Me.lblSucursalDestino
        Me.cmbSucursalDestino.Location = New System.Drawing.Point(111, 4)
        Me.cmbSucursalDestino.Name = "cmbSucursalDestino"
        Me.cmbSucursalDestino.Size = New System.Drawing.Size(145, 21)
        Me.cmbSucursalDestino.TabIndex = 1
        '
        'btnMover
        '
        Me.btnMover.Image = CType(resources.GetObject("btnMover.Image"), System.Drawing.Image)
        Me.btnMover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMover.Location = New System.Drawing.Point(863, 6)
        Me.btnMover.Name = "btnMover"
        Me.btnMover.Size = New System.Drawing.Size(100, 38)
        Me.btnMover.TabIndex = 11
        Me.btnMover.Text = "&Mover"
        Me.btnMover.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMover.UseVisualStyleBackColor = True
        '
        'cmbCajasDestino
        '
        Me.cmbCajasDestino.BindearPropiedadControl = ""
        Me.cmbCajasDestino.BindearPropiedadEntidad = ""
        Me.cmbCajasDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajasDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajasDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajasDestino.FormattingEnabled = True
        Me.cmbCajasDestino.IsPK = False
        Me.cmbCajasDestino.IsRequired = False
        Me.cmbCajasDestino.Key = Nothing
        Me.cmbCajasDestino.LabelAsoc = Me.lblCaja
        Me.cmbCajasDestino.Location = New System.Drawing.Point(111, 31)
        Me.cmbCajasDestino.Name = "cmbCajasDestino"
        Me.cmbCajasDestino.Size = New System.Drawing.Size(145, 21)
        Me.cmbCajasDestino.TabIndex = 3
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(43, 35)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(67, 13)
        Me.lblCaja.TabIndex = 2
        Me.lblCaja.Text = "Caja Destino"
        '
        'lblTickets
        '
        Me.lblTickets.AutoSize = True
        Me.lblTickets.LabelAsoc = Nothing
        Me.lblTickets.Location = New System.Drawing.Point(127, 2)
        Me.lblTickets.Name = "lblTickets"
        Me.lblTickets.Size = New System.Drawing.Size(42, 13)
        Me.lblTickets.TabIndex = 4
        Me.lblTickets.Text = "Tickets"
        '
        'lblDolares
        '
        Me.lblDolares.AutoSize = True
        Me.lblDolares.LabelAsoc = Nothing
        Me.lblDolares.Location = New System.Drawing.Point(248, 2)
        Me.lblDolares.Name = "lblDolares"
        Me.lblDolares.Size = New System.Drawing.Size(43, 13)
        Me.lblDolares.TabIndex = 6
        Me.lblDolares.Text = "Dolares"
        '
        'lblPesos
        '
        Me.lblPesos.AutoSize = True
        Me.lblPesos.LabelAsoc = Nothing
        Me.lblPesos.Location = New System.Drawing.Point(3, 2)
        Me.lblPesos.Name = "lblPesos"
        Me.lblPesos.Size = New System.Drawing.Size(36, 13)
        Me.lblPesos.TabIndex = 0
        Me.lblPesos.Text = "Pesos"
        '
        'txtPesos
        '
        Me.txtPesos.BackColor = System.Drawing.SystemColors.Window
        Me.txtPesos.BindearPropiedadControl = Nothing
        Me.txtPesos.BindearPropiedadEntidad = Nothing
        Me.txtPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPesos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPesos.Formato = "N2"
        Me.txtPesos.IsDecimal = True
        Me.txtPesos.IsNumber = True
        Me.txtPesos.IsPK = False
        Me.txtPesos.IsRequired = False
        Me.txtPesos.Key = ""
        Me.txtPesos.LabelAsoc = Nothing
        Me.txtPesos.Location = New System.Drawing.Point(6, 18)
        Me.txtPesos.MaxLength = 18
        Me.txtPesos.Name = "txtPesos"
        Me.txtPesos.Size = New System.Drawing.Size(120, 23)
        Me.txtPesos.TabIndex = 1
        Me.txtPesos.Text = "0.00"
        Me.txtPesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTickets
        '
        Me.txtTickets.BackColor = System.Drawing.SystemColors.Window
        Me.txtTickets.BindearPropiedadControl = Nothing
        Me.txtTickets.BindearPropiedadEntidad = Nothing
        Me.txtTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTickets.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTickets.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTickets.Formato = "N2"
        Me.txtTickets.IsDecimal = True
        Me.txtTickets.IsNumber = True
        Me.txtTickets.IsPK = False
        Me.txtTickets.IsRequired = False
        Me.txtTickets.Key = ""
        Me.txtTickets.LabelAsoc = Nothing
        Me.txtTickets.Location = New System.Drawing.Point(130, 18)
        Me.txtTickets.MaxLength = 18
        Me.txtTickets.Name = "txtTickets"
        Me.txtTickets.Size = New System.Drawing.Size(120, 23)
        Me.txtTickets.TabIndex = 5
        Me.txtTickets.Text = "0.00"
        Me.txtTickets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolares
        '
        Me.txtDolares.BackColor = System.Drawing.SystemColors.Window
        Me.txtDolares.BindearPropiedadControl = Nothing
        Me.txtDolares.BindearPropiedadEntidad = Nothing
        Me.txtDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDolares.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDolares.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDolares.Formato = "N2"
        Me.txtDolares.IsDecimal = True
        Me.txtDolares.IsNumber = True
        Me.txtDolares.IsPK = False
        Me.txtDolares.IsRequired = False
        Me.txtDolares.Key = ""
        Me.txtDolares.LabelAsoc = Me.lblDolares
        Me.txtDolares.Location = New System.Drawing.Point(251, 18)
        Me.txtDolares.MaxLength = 18
        Me.txtDolares.Name = "txtDolares"
        Me.txtDolares.Size = New System.Drawing.Size(120, 23)
        Me.txtDolares.TabIndex = 7
        Me.txtDolares.Text = "0.00"
        Me.txtDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPACCheques
        '
        Me.txtPACCheques.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACCheques.BindearPropiedadControl = Nothing
        Me.txtPACCheques.BindearPropiedadEntidad = Nothing
        Me.txtPACCheques.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACCheques.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACCheques.IsDecimal = True
        Me.txtPACCheques.IsNumber = True
        Me.txtPACCheques.IsPK = False
        Me.txtPACCheques.IsRequired = False
        Me.txtPACCheques.Key = ""
        Me.txtPACCheques.LabelAsoc = Nothing
        Me.txtPACCheques.Location = New System.Drawing.Point(343, 20)
        Me.txtPACCheques.Name = "txtPACCheques"
        Me.txtPACCheques.ReadOnly = True
        Me.txtPACCheques.Size = New System.Drawing.Size(75, 20)
        Me.txtPACCheques.TabIndex = 5
        Me.txtPACCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPACTarjetas
        '
        Me.txtPACTarjetas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACTarjetas.BindearPropiedadControl = Nothing
        Me.txtPACTarjetas.BindearPropiedadEntidad = Nothing
        Me.txtPACTarjetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACTarjetas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACTarjetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACTarjetas.IsDecimal = True
        Me.txtPACTarjetas.IsNumber = True
        Me.txtPACTarjetas.IsPK = False
        Me.txtPACTarjetas.IsRequired = False
        Me.txtPACTarjetas.Key = ""
        Me.txtPACTarjetas.LabelAsoc = Me.lblPACTarjetas
        Me.txtPACTarjetas.Location = New System.Drawing.Point(418, 20)
        Me.txtPACTarjetas.Name = "txtPACTarjetas"
        Me.txtPACTarjetas.ReadOnly = True
        Me.txtPACTarjetas.Size = New System.Drawing.Size(75, 20)
        Me.txtPACTarjetas.TabIndex = 7
        Me.txtPACTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPACTarjetas
        '
        Me.lblPACTarjetas.AutoSize = True
        Me.lblPACTarjetas.LabelAsoc = Nothing
        Me.lblPACTarjetas.Location = New System.Drawing.Point(445, 4)
        Me.lblPACTarjetas.Name = "lblPACTarjetas"
        Me.lblPACTarjetas.Size = New System.Drawing.Size(45, 13)
        Me.lblPACTarjetas.TabIndex = 6
        Me.lblPACTarjetas.Text = "Tarjetas"
        '
        'txtPACTickets
        '
        Me.txtPACTickets.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACTickets.BindearPropiedadControl = Nothing
        Me.txtPACTickets.BindearPropiedadEntidad = Nothing
        Me.txtPACTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACTickets.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACTickets.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACTickets.IsDecimal = True
        Me.txtPACTickets.IsNumber = True
        Me.txtPACTickets.IsPK = False
        Me.txtPACTickets.IsRequired = False
        Me.txtPACTickets.Key = ""
        Me.txtPACTickets.LabelAsoc = Nothing
        Me.txtPACTickets.Location = New System.Drawing.Point(493, 20)
        Me.txtPACTickets.Name = "txtPACTickets"
        Me.txtPACTickets.ReadOnly = True
        Me.txtPACTickets.Size = New System.Drawing.Size(75, 20)
        Me.txtPACTickets.TabIndex = 9
        Me.txtPACTickets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPACDolares
        '
        Me.txtPACDolares.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACDolares.BindearPropiedadControl = Nothing
        Me.txtPACDolares.BindearPropiedadEntidad = Nothing
        Me.txtPACDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACDolares.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACDolares.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACDolares.IsDecimal = True
        Me.txtPACDolares.IsNumber = True
        Me.txtPACDolares.IsPK = False
        Me.txtPACDolares.IsRequired = False
        Me.txtPACDolares.Key = ""
        Me.txtPACDolares.LabelAsoc = Me.lblPACDolares
        Me.txtPACDolares.Location = New System.Drawing.Point(568, 20)
        Me.txtPACDolares.Name = "txtPACDolares"
        Me.txtPACDolares.ReadOnly = True
        Me.txtPACDolares.Size = New System.Drawing.Size(75, 20)
        Me.txtPACDolares.TabIndex = 11
        Me.txtPACDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPACDolares
        '
        Me.lblPACDolares.AutoSize = True
        Me.lblPACDolares.LabelAsoc = Nothing
        Me.lblPACDolares.Location = New System.Drawing.Point(595, 4)
        Me.lblPACDolares.Name = "lblPACDolares"
        Me.lblPACDolares.Size = New System.Drawing.Size(43, 13)
        Me.lblPACDolares.TabIndex = 10
        Me.lblPACDolares.Text = "Dolares"
        '
        'txtPACEfectivo
        '
        Me.txtPACEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACEfectivo.BindearPropiedadControl = Nothing
        Me.txtPACEfectivo.BindearPropiedadEntidad = Nothing
        Me.txtPACEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACEfectivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACEfectivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACEfectivo.IsDecimal = True
        Me.txtPACEfectivo.IsNumber = True
        Me.txtPACEfectivo.IsPK = False
        Me.txtPACEfectivo.IsRequired = False
        Me.txtPACEfectivo.Key = ""
        Me.txtPACEfectivo.LabelAsoc = Nothing
        Me.txtPACEfectivo.Location = New System.Drawing.Point(268, 20)
        Me.txtPACEfectivo.Name = "txtPACEfectivo"
        Me.txtPACEfectivo.ReadOnly = True
        Me.txtPACEfectivo.Size = New System.Drawing.Size(75, 20)
        Me.txtPACEfectivo.TabIndex = 3
        Me.txtPACEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(370, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Cheques"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.LabelAsoc = Nothing
        Me.Label9.Location = New System.Drawing.Point(520, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Tickets"
        '
        'lblPesosActual
        '
        Me.lblPesosActual.AutoSize = True
        Me.lblPesosActual.LabelAsoc = Nothing
        Me.lblPesosActual.Location = New System.Drawing.Point(295, 4)
        Me.lblPesosActual.Name = "lblPesosActual"
        Me.lblPesosActual.Size = New System.Drawing.Size(36, 13)
        Me.lblPesosActual.TabIndex = 2
        Me.lblPesosActual.Text = "Pesos"
        '
        'txtPACCheques2
        '
        Me.txtPACCheques2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACCheques2.BindearPropiedadControl = Nothing
        Me.txtPACCheques2.BindearPropiedadEntidad = Nothing
        Me.txtPACCheques2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACCheques2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACCheques2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACCheques2.IsDecimal = True
        Me.txtPACCheques2.IsNumber = True
        Me.txtPACCheques2.IsPK = False
        Me.txtPACCheques2.IsRequired = False
        Me.txtPACCheques2.Key = ""
        Me.txtPACCheques2.LabelAsoc = Nothing
        Me.txtPACCheques2.Location = New System.Drawing.Point(81, 27)
        Me.txtPACCheques2.Name = "txtPACCheques2"
        Me.txtPACCheques2.ReadOnly = True
        Me.txtPACCheques2.Size = New System.Drawing.Size(75, 20)
        Me.txtPACCheques2.TabIndex = 3
        Me.txtPACCheques2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPACTarjetas2
        '
        Me.txtPACTarjetas2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACTarjetas2.BindearPropiedadControl = Nothing
        Me.txtPACTarjetas2.BindearPropiedadEntidad = Nothing
        Me.txtPACTarjetas2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACTarjetas2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACTarjetas2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACTarjetas2.IsDecimal = True
        Me.txtPACTarjetas2.IsNumber = True
        Me.txtPACTarjetas2.IsPK = False
        Me.txtPACTarjetas2.IsRequired = False
        Me.txtPACTarjetas2.Key = ""
        Me.txtPACTarjetas2.LabelAsoc = Me.lblPACTarjetas2
        Me.txtPACTarjetas2.Location = New System.Drawing.Point(156, 27)
        Me.txtPACTarjetas2.Name = "txtPACTarjetas2"
        Me.txtPACTarjetas2.ReadOnly = True
        Me.txtPACTarjetas2.Size = New System.Drawing.Size(75, 20)
        Me.txtPACTarjetas2.TabIndex = 5
        Me.txtPACTarjetas2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPACTarjetas2
        '
        Me.lblPACTarjetas2.AutoSize = True
        Me.lblPACTarjetas2.LabelAsoc = Nothing
        Me.lblPACTarjetas2.Location = New System.Drawing.Point(183, 11)
        Me.lblPACTarjetas2.Name = "lblPACTarjetas2"
        Me.lblPACTarjetas2.Size = New System.Drawing.Size(45, 13)
        Me.lblPACTarjetas2.TabIndex = 4
        Me.lblPACTarjetas2.Text = "Tarjetas"
        '
        'txtPACTickets2
        '
        Me.txtPACTickets2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACTickets2.BindearPropiedadControl = Nothing
        Me.txtPACTickets2.BindearPropiedadEntidad = Nothing
        Me.txtPACTickets2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACTickets2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACTickets2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACTickets2.IsDecimal = True
        Me.txtPACTickets2.IsNumber = True
        Me.txtPACTickets2.IsPK = False
        Me.txtPACTickets2.IsRequired = False
        Me.txtPACTickets2.Key = ""
        Me.txtPACTickets2.LabelAsoc = Nothing
        Me.txtPACTickets2.Location = New System.Drawing.Point(231, 27)
        Me.txtPACTickets2.Name = "txtPACTickets2"
        Me.txtPACTickets2.ReadOnly = True
        Me.txtPACTickets2.Size = New System.Drawing.Size(75, 20)
        Me.txtPACTickets2.TabIndex = 7
        Me.txtPACTickets2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPACDolares2
        '
        Me.txtPACDolares2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACDolares2.BindearPropiedadControl = Nothing
        Me.txtPACDolares2.BindearPropiedadEntidad = Nothing
        Me.txtPACDolares2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACDolares2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACDolares2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACDolares2.IsDecimal = True
        Me.txtPACDolares2.IsNumber = True
        Me.txtPACDolares2.IsPK = False
        Me.txtPACDolares2.IsRequired = False
        Me.txtPACDolares2.Key = ""
        Me.txtPACDolares2.LabelAsoc = Me.lblPACDolares2
        Me.txtPACDolares2.Location = New System.Drawing.Point(306, 27)
        Me.txtPACDolares2.Name = "txtPACDolares2"
        Me.txtPACDolares2.ReadOnly = True
        Me.txtPACDolares2.Size = New System.Drawing.Size(75, 20)
        Me.txtPACDolares2.TabIndex = 9
        Me.txtPACDolares2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPACDolares2
        '
        Me.lblPACDolares2.AutoSize = True
        Me.lblPACDolares2.LabelAsoc = Nothing
        Me.lblPACDolares2.Location = New System.Drawing.Point(333, 11)
        Me.lblPACDolares2.Name = "lblPACDolares2"
        Me.lblPACDolares2.Size = New System.Drawing.Size(43, 13)
        Me.lblPACDolares2.TabIndex = 8
        Me.lblPACDolares2.Text = "Dolares"
        '
        'txtPACEfectivo2
        '
        Me.txtPACEfectivo2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACEfectivo2.BindearPropiedadControl = Nothing
        Me.txtPACEfectivo2.BindearPropiedadEntidad = Nothing
        Me.txtPACEfectivo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACEfectivo2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACEfectivo2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACEfectivo2.IsDecimal = True
        Me.txtPACEfectivo2.IsNumber = True
        Me.txtPACEfectivo2.IsPK = False
        Me.txtPACEfectivo2.IsRequired = False
        Me.txtPACEfectivo2.Key = ""
        Me.txtPACEfectivo2.LabelAsoc = Nothing
        Me.txtPACEfectivo2.Location = New System.Drawing.Point(6, 27)
        Me.txtPACEfectivo2.Name = "txtPACEfectivo2"
        Me.txtPACEfectivo2.ReadOnly = True
        Me.txtPACEfectivo2.Size = New System.Drawing.Size(75, 20)
        Me.txtPACEfectivo2.TabIndex = 0
        Me.txtPACEfectivo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(108, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cheques"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(258, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tickets"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(33, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Pesos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbcMovimientos)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(984, 452)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Items a Mover"
        '
        'tbcMovimientos
        '
        Me.tbcMovimientos.Controls.Add(Me.tpgCarteraCheques)
        Me.tbcMovimientos.Controls.Add(Me.tpgTarjetasCupones)
        Me.tbcMovimientos.Location = New System.Drawing.Point(7, 19)
        Me.tbcMovimientos.Name = "tbcMovimientos"
        Me.tbcMovimientos.SelectedIndex = 0
        Me.tbcMovimientos.Size = New System.Drawing.Size(970, 376)
        Me.tbcMovimientos.TabIndex = 2
        '
        'tpgCarteraCheques
        '
        Me.tpgCarteraCheques.BackColor = System.Drawing.SystemColors.Control
        Me.tpgCarteraCheques.Controls.Add(Me.btnConsultar)
        Me.tpgCarteraCheques.Controls.Add(Me.btnTodos)
        Me.tpgCarteraCheques.Controls.Add(Me.dtpFechaCobroHasta)
        Me.tpgCarteraCheques.Controls.Add(Me.cmbTodos)
        Me.tpgCarteraCheques.Controls.Add(Me.dtpFechaCobroDesde)
        Me.tpgCarteraCheques.Controls.Add(Me.ugDetalle)
        Me.tpgCarteraCheques.Controls.Add(Me.Panel4)
        Me.tpgCarteraCheques.Location = New System.Drawing.Point(4, 22)
        Me.tpgCarteraCheques.Name = "tpgCarteraCheques"
        Me.tpgCarteraCheques.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgCarteraCheques.Size = New System.Drawing.Size(962, 350)
        Me.tpgCarteraCheques.TabIndex = 0
        Me.tpgCarteraCheques.Text = "Cartera en Cartera"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel4.Controls.Add(Me.lblFechaCobroDesde)
        Me.Panel4.Controls.Add(Me.lblFechaCobroHasta)
        Me.Panel4.Controls.Add(Me.lblFechaCobro)
        Me.Panel4.Location = New System.Drawing.Point(7, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(948, 38)
        Me.Panel4.TabIndex = 10
        '
        'tpgTarjetasCupones
        '
        Me.tpgTarjetasCupones.BackColor = System.Drawing.SystemColors.Control
        Me.tpgTarjetasCupones.Controls.Add(Me.dtpDesdeEmision)
        Me.tpgTarjetasCupones.Controls.Add(Me.btnTodosTrj)
        Me.tpgTarjetasCupones.Controls.Add(Me.dtpHastaEmision)
        Me.tpgTarjetasCupones.Controls.Add(Me.cmbTodosTrj)
        Me.tpgTarjetasCupones.Controls.Add(Me.Panel5)
        Me.tpgTarjetasCupones.Controls.Add(Me.ugTarjetas)
        Me.tpgTarjetasCupones.Location = New System.Drawing.Point(4, 22)
        Me.tpgTarjetasCupones.Name = "tpgTarjetasCupones"
        Me.tpgTarjetasCupones.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgTarjetasCupones.Size = New System.Drawing.Size(962, 350)
        Me.tpgTarjetasCupones.TabIndex = 1
        Me.tpgTarjetasCupones.Text = "Cupones"
        '
        'dtpDesdeEmision
        '
        Me.dtpDesdeEmision.BindearPropiedadControl = Nothing
        Me.dtpDesdeEmision.BindearPropiedadEntidad = Nothing
        Me.dtpDesdeEmision.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesdeEmision.Enabled = False
        Me.dtpDesdeEmision.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesdeEmision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesdeEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeEmision.IsPK = False
        Me.dtpDesdeEmision.IsRequired = False
        Me.dtpDesdeEmision.Key = ""
        Me.dtpDesdeEmision.LabelAsoc = Me.lblDesdeEmision
        Me.dtpDesdeEmision.Location = New System.Drawing.Point(259, 14)
        Me.dtpDesdeEmision.Name = "dtpDesdeEmision"
        Me.dtpDesdeEmision.Size = New System.Drawing.Size(83, 20)
        Me.dtpDesdeEmision.TabIndex = 1
        '
        'lblDesdeEmision
        '
        Me.lblDesdeEmision.AutoSize = True
        Me.lblDesdeEmision.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDesdeEmision.LabelAsoc = Nothing
        Me.lblDesdeEmision.Location = New System.Drawing.Point(208, 11)
        Me.lblDesdeEmision.Name = "lblDesdeEmision"
        Me.lblDesdeEmision.Size = New System.Drawing.Size(38, 13)
        Me.lblDesdeEmision.TabIndex = 2
        Me.lblDesdeEmision.Text = "Desde"
        '
        'btnTodosTrj
        '
        Me.btnTodosTrj.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodosTrj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodosTrj.Location = New System.Drawing.Point(873, 84)
        Me.btnTodosTrj.Name = "btnTodosTrj"
        Me.btnTodosTrj.Size = New System.Drawing.Size(75, 23)
        Me.btnTodosTrj.TabIndex = 4
        Me.btnTodosTrj.Text = "Aplicar"
        Me.btnTodosTrj.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodosTrj.UseVisualStyleBackColor = True
        '
        'dtpHastaEmision
        '
        Me.dtpHastaEmision.BindearPropiedadControl = Nothing
        Me.dtpHastaEmision.BindearPropiedadEntidad = Nothing
        Me.dtpHastaEmision.CustomFormat = "dd/MM/yyyy"
        Me.dtpHastaEmision.Enabled = False
        Me.dtpHastaEmision.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHastaEmision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHastaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaEmision.IsPK = False
        Me.dtpHastaEmision.IsRequired = False
        Me.dtpHastaEmision.Key = ""
        Me.dtpHastaEmision.LabelAsoc = Me.lblHastaEmision
        Me.dtpHastaEmision.Location = New System.Drawing.Point(389, 14)
        Me.dtpHastaEmision.Name = "dtpHastaEmision"
        Me.dtpHastaEmision.Size = New System.Drawing.Size(83, 20)
        Me.dtpHastaEmision.TabIndex = 2
        '
        'lblHastaEmision
        '
        Me.lblHastaEmision.AutoSize = True
        Me.lblHastaEmision.LabelAsoc = Nothing
        Me.lblHastaEmision.Location = New System.Drawing.Point(341, 11)
        Me.lblHastaEmision.Name = "lblHastaEmision"
        Me.lblHastaEmision.Size = New System.Drawing.Size(35, 13)
        Me.lblHastaEmision.TabIndex = 3
        Me.lblHastaEmision.Text = "Hasta"
        '
        'cmbTodosTrj
        '
        Me.cmbTodosTrj.BindearPropiedadControl = Nothing
        Me.cmbTodosTrj.BindearPropiedadEntidad = Nothing
        Me.cmbTodosTrj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodosTrj.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodosTrj.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodosTrj.FormattingEnabled = True
        Me.cmbTodosTrj.IsPK = False
        Me.cmbTodosTrj.IsRequired = False
        Me.cmbTodosTrj.Key = Nothing
        Me.cmbTodosTrj.LabelAsoc = Nothing
        Me.cmbTodosTrj.Location = New System.Drawing.Point(746, 85)
        Me.cmbTodosTrj.Name = "cmbTodosTrj"
        Me.cmbTodosTrj.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodosTrj.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel5.Controls.Add(Me.bscCodigoCliente)
        Me.Panel5.Controls.Add(Me.bscNombreCliente)
        Me.Panel5.Controls.Add(Me.chbCliente)
        Me.Panel5.Controls.Add(Me.cmbBanco)
        Me.Panel5.Controls.Add(Me.chbBanco)
        Me.Panel5.Controls.Add(Me.chbNumeroLote)
        Me.Panel5.Controls.Add(Me.btnConsultarTrj)
        Me.Panel5.Controls.Add(Me.txtNumeroLote)
        Me.Panel5.Controls.Add(Me.chbNumeroCupon)
        Me.Panel5.Controls.Add(Me.txtNumeroCupon)
        Me.Panel5.Controls.Add(Me.cmbTarjeta)
        Me.Panel5.Controls.Add(Me.chbTarjeta)
        Me.Panel5.Controls.Add(Me.chbMesCompleto)
        Me.Panel5.Controls.Add(Me.chbFechaEmision)
        Me.Panel5.Controls.Add(Me.lblDesdeEmision)
        Me.Panel5.Controls.Add(Me.lblHastaEmision)
        Me.Panel5.Location = New System.Drawing.Point(7, 7)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(948, 64)
        Me.Panel5.TabIndex = 0
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(71, 33)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 5
        '
        'bscNombreCliente
        '
        Me.bscNombreCliente.ActivarFiltroEnGrilla = True
        Me.bscNombreCliente.AutoSize = True
        Me.bscNombreCliente.BindearPropiedadControl = Nothing
        Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
        Me.bscNombreCliente.ConfigBuscador = Nothing
        Me.bscNombreCliente.Datos = Nothing
        Me.bscNombreCliente.Enabled = False
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
        Me.bscNombreCliente.Location = New System.Drawing.Point(168, 33)
        Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = True
        Me.bscNombreCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(294, 23)
        Me.bscNombreCliente.TabIndex = 6
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
        Me.chbCliente.Location = New System.Drawing.Point(7, 36)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 4
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'cmbBanco
        '
        Me.cmbBanco.BindearPropiedadControl = ""
        Me.cmbBanco.BindearPropiedadEntidad = ""
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.Enabled = False
        Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.IsPK = True
        Me.cmbBanco.IsRequired = True
        Me.cmbBanco.Key = Nothing
        Me.cmbBanco.LabelAsoc = Nothing
        Me.cmbBanco.Location = New System.Drawing.Point(658, 32)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(172, 21)
        Me.cmbBanco.TabIndex = 14
        '
        'chbBanco
        '
        Me.chbBanco.AutoSize = True
        Me.chbBanco.BindearPropiedadControl = Nothing
        Me.chbBanco.BindearPropiedadEntidad = Nothing
        Me.chbBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBanco.IsPK = False
        Me.chbBanco.IsRequired = False
        Me.chbBanco.Key = Nothing
        Me.chbBanco.LabelAsoc = Nothing
        Me.chbBanco.Location = New System.Drawing.Point(595, 35)
        Me.chbBanco.Name = "chbBanco"
        Me.chbBanco.Size = New System.Drawing.Size(57, 17)
        Me.chbBanco.TabIndex = 13
        Me.chbBanco.Text = "Banco"
        Me.chbBanco.UseVisualStyleBackColor = True
        '
        'chbNumeroLote
        '
        Me.chbNumeroLote.AutoSize = True
        Me.chbNumeroLote.BindearPropiedadControl = Nothing
        Me.chbNumeroLote.BindearPropiedadEntidad = Nothing
        Me.chbNumeroLote.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroLote.IsPK = False
        Me.chbNumeroLote.IsRequired = False
        Me.chbNumeroLote.Key = Nothing
        Me.chbNumeroLote.LabelAsoc = Nothing
        Me.chbNumeroLote.Location = New System.Drawing.Point(471, 35)
        Me.chbNumeroLote.Name = "chbNumeroLote"
        Me.chbNumeroLote.Size = New System.Drawing.Size(47, 17)
        Me.chbNumeroLote.TabIndex = 11
        Me.chbNumeroLote.Text = "Lote"
        Me.chbNumeroLote.UseVisualStyleBackColor = True
        '
        'btnConsultarTrj
        '
        Me.btnConsultarTrj.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultarTrj.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultarTrj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultarTrj.Location = New System.Drawing.Point(845, 3)
        Me.btnConsultarTrj.Name = "btnConsultarTrj"
        Me.btnConsultarTrj.Size = New System.Drawing.Size(100, 30)
        Me.btnConsultarTrj.TabIndex = 15
        Me.btnConsultarTrj.Text = "&Consultar"
        Me.btnConsultarTrj.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultarTrj.UseVisualStyleBackColor = True
        '
        'txtNumeroLote
        '
        Me.txtNumeroLote.BindearPropiedadControl = Nothing
        Me.txtNumeroLote.BindearPropiedadEntidad = Nothing
        Me.txtNumeroLote.Enabled = False
        Me.txtNumeroLote.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroLote.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroLote.Formato = "##0"
        Me.txtNumeroLote.IsDecimal = False
        Me.txtNumeroLote.IsNumber = True
        Me.txtNumeroLote.IsPK = False
        Me.txtNumeroLote.IsRequired = False
        Me.txtNumeroLote.Key = ""
        Me.txtNumeroLote.LabelAsoc = Nothing
        Me.txtNumeroLote.Location = New System.Drawing.Point(520, 33)
        Me.txtNumeroLote.MaxLength = 8
        Me.txtNumeroLote.Name = "txtNumeroLote"
        Me.txtNumeroLote.Size = New System.Drawing.Size(69, 20)
        Me.txtNumeroLote.TabIndex = 12
        Me.txtNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNumeroCupon
        '
        Me.chbNumeroCupon.AutoSize = True
        Me.chbNumeroCupon.BindearPropiedadControl = Nothing
        Me.chbNumeroCupon.BindearPropiedadEntidad = Nothing
        Me.chbNumeroCupon.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroCupon.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroCupon.IsPK = False
        Me.chbNumeroCupon.IsRequired = False
        Me.chbNumeroCupon.Key = Nothing
        Me.chbNumeroCupon.LabelAsoc = Nothing
        Me.chbNumeroCupon.Location = New System.Drawing.Point(702, 9)
        Me.chbNumeroCupon.Name = "chbNumeroCupon"
        Me.chbNumeroCupon.Size = New System.Drawing.Size(57, 17)
        Me.chbNumeroCupon.TabIndex = 9
        Me.chbNumeroCupon.Text = "Cupón"
        Me.chbNumeroCupon.UseVisualStyleBackColor = True
        '
        'txtNumeroCupon
        '
        Me.txtNumeroCupon.BindearPropiedadControl = Nothing
        Me.txtNumeroCupon.BindearPropiedadEntidad = Nothing
        Me.txtNumeroCupon.Enabled = False
        Me.txtNumeroCupon.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCupon.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCupon.Formato = "##0"
        Me.txtNumeroCupon.IsDecimal = False
        Me.txtNumeroCupon.IsNumber = True
        Me.txtNumeroCupon.IsPK = False
        Me.txtNumeroCupon.IsRequired = False
        Me.txtNumeroCupon.Key = ""
        Me.txtNumeroCupon.LabelAsoc = Nothing
        Me.txtNumeroCupon.Location = New System.Drawing.Point(761, 7)
        Me.txtNumeroCupon.MaxLength = 8
        Me.txtNumeroCupon.Name = "txtNumeroCupon"
        Me.txtNumeroCupon.Size = New System.Drawing.Size(69, 20)
        Me.txtNumeroCupon.TabIndex = 10
        Me.txtNumeroCupon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTarjeta
        '
        Me.cmbTarjeta.BindearPropiedadControl = ""
        Me.cmbTarjeta.BindearPropiedadEntidad = ""
        Me.cmbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTarjeta.Enabled = False
        Me.cmbTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTarjeta.FormattingEnabled = True
        Me.cmbTarjeta.IsPK = True
        Me.cmbTarjeta.IsRequired = True
        Me.cmbTarjeta.Key = Nothing
        Me.cmbTarjeta.LabelAsoc = Nothing
        Me.cmbTarjeta.Location = New System.Drawing.Point(536, 7)
        Me.cmbTarjeta.Name = "cmbTarjeta"
        Me.cmbTarjeta.Size = New System.Drawing.Size(160, 21)
        Me.cmbTarjeta.TabIndex = 8
        '
        'chbTarjeta
        '
        Me.chbTarjeta.AutoSize = True
        Me.chbTarjeta.BindearPropiedadControl = Nothing
        Me.chbTarjeta.BindearPropiedadEntidad = Nothing
        Me.chbTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTarjeta.IsPK = False
        Me.chbTarjeta.IsRequired = False
        Me.chbTarjeta.Key = Nothing
        Me.chbTarjeta.LabelAsoc = Nothing
        Me.chbTarjeta.Location = New System.Drawing.Point(471, 10)
        Me.chbTarjeta.Name = "chbTarjeta"
        Me.chbTarjeta.Size = New System.Drawing.Size(59, 17)
        Me.chbTarjeta.TabIndex = 7
        Me.chbTarjeta.Text = "Tarjeta"
        Me.chbTarjeta.UseVisualStyleBackColor = True
        '
        'chbMesCompleto
        '
        Me.chbMesCompleto.AutoSize = True
        Me.chbMesCompleto.BindearPropiedadControl = Nothing
        Me.chbMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chbMesCompleto.Enabled = False
        Me.chbMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMesCompleto.IsPK = False
        Me.chbMesCompleto.IsRequired = False
        Me.chbMesCompleto.Key = Nothing
        Me.chbMesCompleto.LabelAsoc = Nothing
        Me.chbMesCompleto.Location = New System.Drawing.Point(107, 10)
        Me.chbMesCompleto.Name = "chbMesCompleto"
        Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chbMesCompleto.TabIndex = 1
        Me.chbMesCompleto.Text = "Mes Completo"
        Me.chbMesCompleto.UseVisualStyleBackColor = True
        '
        'chbFechaEmision
        '
        Me.chbFechaEmision.AutoSize = True
        Me.chbFechaEmision.BindearPropiedadControl = Nothing
        Me.chbFechaEmision.BindearPropiedadEntidad = Nothing
        Me.chbFechaEmision.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEmision.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEmision.IsPK = False
        Me.chbFechaEmision.IsRequired = False
        Me.chbFechaEmision.Key = Nothing
        Me.chbFechaEmision.LabelAsoc = Nothing
        Me.chbFechaEmision.Location = New System.Drawing.Point(8, 10)
        Me.chbFechaEmision.Name = "chbFechaEmision"
        Me.chbFechaEmision.Size = New System.Drawing.Size(95, 17)
        Me.chbFechaEmision.TabIndex = 0
        Me.chbFechaEmision.Text = "Fecha Emisión"
        Me.chbFechaEmision.UseVisualStyleBackColor = True
        '
        'ugTarjetas
        '
        Me.ugTarjetas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugTarjetas.DisplayLayout.Appearance = Appearance32
        Appearance33.TextHAlignAsString = "Center"
        UltraGridColumn30.CellAppearance = Appearance33
        UltraGridColumn30.Header.Caption = ""
        UltraGridColumn30.Header.VisiblePosition = 0
        UltraGridColumn30.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn30.Width = 30
        UltraGridColumn33.Header.VisiblePosition = 1
        UltraGridColumn33.Hidden = True
        UltraGridColumn36.Header.Caption = "Tarjeta"
        UltraGridColumn36.Header.VisiblePosition = 2
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance34.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance34
        UltraGridColumn34.Header.Caption = "Código Banco"
        UltraGridColumn34.Header.VisiblePosition = 3
        UltraGridColumn34.Hidden = True
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn35.Header.Caption = "Banco"
        UltraGridColumn35.Header.VisiblePosition = 4
        UltraGridColumn35.Width = 100
        UltraGridColumn37.Header.Caption = "Nro Lote"
        UltraGridColumn37.Header.VisiblePosition = 5
        UltraGridColumn38.Header.Caption = "Nro Cupon"
        UltraGridColumn38.Header.VisiblePosition = 6
        UltraGridColumn39.Header.VisiblePosition = 8
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance35.TextHAlignAsString = "Center"
        UltraGridColumn41.CellAppearance = Appearance35
        UltraGridColumn41.Format = "dd/MM/yyyy"
        UltraGridColumn41.Header.Caption = "Fecha Emisión"
        UltraGridColumn41.Header.VisiblePosition = 9
        UltraGridColumn41.Width = 70
        UltraGridColumn40.Header.Caption = "Estado"
        UltraGridColumn40.Header.VisiblePosition = 10
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance36.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance36
        UltraGridColumn31.Header.Caption = "Id Cliente"
        UltraGridColumn31.Header.VisiblePosition = 11
        UltraGridColumn31.Hidden = True
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance37.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance37
        UltraGridColumn32.Header.Caption = "Código Cliente"
        UltraGridColumn32.Header.VisiblePosition = 12
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn46.Header.Caption = "Cliente"
        UltraGridColumn46.Header.VisiblePosition = 13
        UltraGridColumn46.Width = 200
        UltraGridColumn42.Header.Caption = "Situacion"
        UltraGridColumn42.Header.VisiblePosition = 14
        UltraGridColumn44.Header.VisiblePosition = 7
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn30, UltraGridColumn33, UltraGridColumn36, UltraGridColumn34, UltraGridColumn35, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn41, UltraGridColumn40, UltraGridColumn31, UltraGridColumn32, UltraGridColumn46, UltraGridColumn42, UltraGridColumn44})
        Me.ugTarjetas.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugTarjetas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugTarjetas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.ugTarjetas.DisplayLayout.GroupByBox.Appearance = Appearance38
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugTarjetas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
        Me.ugTarjetas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance40.BackColor2 = System.Drawing.SystemColors.Control
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugTarjetas.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
        Me.ugTarjetas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugTarjetas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugTarjetas.DisplayLayout.Override.ActiveCellAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.SystemColors.Highlight
        Appearance42.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugTarjetas.DisplayLayout.Override.ActiveRowAppearance = Appearance42
        Me.ugTarjetas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugTarjetas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugTarjetas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugTarjetas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugTarjetas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Me.ugTarjetas.DisplayLayout.Override.CardAreaAppearance = Appearance43
        Appearance44.BorderColor = System.Drawing.Color.Silver
        Appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugTarjetas.DisplayLayout.Override.CellAppearance = Appearance44
        Me.ugTarjetas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugTarjetas.DisplayLayout.Override.CellPadding = 0
        Appearance45.BackColor = System.Drawing.SystemColors.Control
        Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance45.BorderColor = System.Drawing.SystemColors.Window
        Me.ugTarjetas.DisplayLayout.Override.GroupByRowAppearance = Appearance45
        Appearance46.TextHAlignAsString = "Left"
        Me.ugTarjetas.DisplayLayout.Override.HeaderAppearance = Appearance46
        Me.ugTarjetas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugTarjetas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.BorderColor = System.Drawing.Color.Silver
        Me.ugTarjetas.DisplayLayout.Override.RowAppearance = Appearance47
        Me.ugTarjetas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance48.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugTarjetas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance48
        Me.ugTarjetas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugTarjetas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugTarjetas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugTarjetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugTarjetas.Location = New System.Drawing.Point(7, 77)
        Me.ugTarjetas.Name = "ugTarjetas"
        Me.ugTarjetas.Size = New System.Drawing.Size(948, 266)
        Me.ugTarjetas.TabIndex = 8
        Me.ugTarjetas.Text = "UltraGrid1"
        Me.ugTarjetas.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugTarjetas.ToolStripMenuExpandir = Nothing
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnMover)
        Me.Panel3.Controls.Add(Me.lblCotizacionDolares)
        Me.Panel3.Controls.Add(Me.pnlBancos3)
        Me.Panel3.Controls.Add(Me.txtCotizacionDolares)
        Me.Panel3.Controls.Add(Me.txtDolares)
        Me.Panel3.Controls.Add(Me.txtTickets)
        Me.Panel3.Controls.Add(Me.txtPesos)
        Me.Panel3.Controls.Add(Me.lblPesos)
        Me.Panel3.Controls.Add(Me.lblTickets)
        Me.Panel3.Controls.Add(Me.lblDolares)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 402)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(978, 47)
        Me.Panel3.TabIndex = 1
        '
        'lblCotizacionDolares
        '
        Me.lblCotizacionDolares.AutoSize = True
        Me.lblCotizacionDolares.LabelAsoc = Nothing
        Me.lblCotizacionDolares.Location = New System.Drawing.Point(535, 3)
        Me.lblCotizacionDolares.Name = "lblCotizacionDolares"
        Me.lblCotizacionDolares.Size = New System.Drawing.Size(56, 13)
        Me.lblCotizacionDolares.TabIndex = 9
        Me.lblCotizacionDolares.Text = "Cotización"
        '
        'pnlBancos3
        '
        Me.pnlBancos3.Controls.Add(Me.Label2)
        Me.pnlBancos3.Controls.Add(Me.txtBancos)
        Me.pnlBancos3.Location = New System.Drawing.Point(397, -1)
        Me.pnlBancos3.Name = "pnlBancos3"
        Me.pnlBancos3.Size = New System.Drawing.Size(136, 49)
        Me.pnlBancos3.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(2, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Bancos"
        '
        'txtBancos
        '
        Me.txtBancos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBancos.BackColor = System.Drawing.SystemColors.Window
        Me.txtBancos.BindearPropiedadControl = Nothing
        Me.txtBancos.BindearPropiedadEntidad = Nothing
        Me.txtBancos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBancos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancos.Formato = "N2"
        Me.txtBancos.IsDecimal = True
        Me.txtBancos.IsNumber = True
        Me.txtBancos.IsPK = False
        Me.txtBancos.IsRequired = False
        Me.txtBancos.Key = ""
        Me.txtBancos.LabelAsoc = Me.Label2
        Me.txtBancos.Location = New System.Drawing.Point(2, 20)
        Me.txtBancos.MaxLength = 18
        Me.txtBancos.Name = "txtBancos"
        Me.txtBancos.Size = New System.Drawing.Size(120, 23)
        Me.txtBancos.TabIndex = 1
        Me.txtBancos.Text = "0.00"
        Me.txtBancos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCotizacionDolares
        '
        Me.txtCotizacionDolares.BindearPropiedadControl = Nothing
        Me.txtCotizacionDolares.BindearPropiedadEntidad = Nothing
        Me.txtCotizacionDolares.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolares.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolares.Formato = "##0.00"
        Me.txtCotizacionDolares.IsDecimal = True
        Me.txtCotizacionDolares.IsNumber = True
        Me.txtCotizacionDolares.IsPK = False
        Me.txtCotizacionDolares.IsRequired = False
        Me.txtCotizacionDolares.Key = ""
        Me.txtCotizacionDolares.LabelAsoc = Me.lblCotizacionDolares
        Me.txtCotizacionDolares.Location = New System.Drawing.Point(537, 22)
        Me.txtCotizacionDolares.Name = "txtCotizacionDolares"
        Me.txtCotizacionDolares.Size = New System.Drawing.Size(62, 20)
        Me.txtCotizacionDolares.TabIndex = 10
        Me.txtCotizacionDolares.Text = "0.00"
        Me.txtCotizacionDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = Nothing
        Me.dtpFecha.BindearPropiedadEntidad = Nothing
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Me.lblFecha
        Me.dtpFecha.Location = New System.Drawing.Point(753, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 14
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(750, 4)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 13
        Me.lblFecha.Text = "Fecha"
        '
        'pnlSaldosCuentaDestino
        '
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.Label1)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.Label5)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.lblPACDolares2)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.Label3)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.txtPACCheques2)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.lblPACTarjetas2)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.txtPACEfectivo2)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.txtPACDolares2)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.txtPACTarjetas2)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.txtPACTickets2)
        Me.pnlSaldosCuentaDestino.Controls.Add(Me.pnlBancos2)
        Me.pnlSaldosCuentaDestino.Location = New System.Drawing.Point(262, 3)
        Me.pnlSaldosCuentaDestino.Name = "pnlSaldosCuentaDestino"
        Me.pnlSaldosCuentaDestino.Size = New System.Drawing.Size(492, 48)
        Me.pnlSaldosCuentaDestino.TabIndex = 6
        '
        'pnlBancos2
        '
        Me.pnlBancos2.Controls.Add(Me.txtPACBancos2)
        Me.pnlBancos2.Controls.Add(Me.lblPACBancos2)
        Me.pnlBancos2.Location = New System.Drawing.Point(381, 6)
        Me.pnlBancos2.Name = "pnlBancos2"
        Me.pnlBancos2.Size = New System.Drawing.Size(104, 42)
        Me.pnlBancos2.TabIndex = 10
        '
        'txtPACBancos2
        '
        Me.txtPACBancos2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACBancos2.BindearPropiedadControl = Nothing
        Me.txtPACBancos2.BindearPropiedadEntidad = Nothing
        Me.txtPACBancos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACBancos2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACBancos2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACBancos2.IsDecimal = True
        Me.txtPACBancos2.IsNumber = True
        Me.txtPACBancos2.IsPK = False
        Me.txtPACBancos2.IsRequired = False
        Me.txtPACBancos2.Key = ""
        Me.txtPACBancos2.LabelAsoc = Me.lblPACBancos2
        Me.txtPACBancos2.Location = New System.Drawing.Point(1, 21)
        Me.txtPACBancos2.Name = "txtPACBancos2"
        Me.txtPACBancos2.ReadOnly = True
        Me.txtPACBancos2.Size = New System.Drawing.Size(101, 20)
        Me.txtPACBancos2.TabIndex = 1
        Me.txtPACBancos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPACBancos2
        '
        Me.lblPACBancos2.AutoSize = True
        Me.lblPACBancos2.LabelAsoc = Nothing
        Me.lblPACBancos2.Location = New System.Drawing.Point(59, 5)
        Me.lblPACBancos2.Name = "lblPACBancos2"
        Me.lblPACBancos2.Size = New System.Drawing.Size(43, 13)
        Me.lblPACBancos2.TabIndex = 0
        Me.lblPACBancos2.Text = "Bancos"
        '
        'txtPACBancos
        '
        Me.txtPACBancos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACBancos.BindearPropiedadControl = Nothing
        Me.txtPACBancos.BindearPropiedadEntidad = Nothing
        Me.txtPACBancos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACBancos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACBancos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACBancos.IsDecimal = True
        Me.txtPACBancos.IsNumber = True
        Me.txtPACBancos.IsPK = False
        Me.txtPACBancos.IsRequired = False
        Me.txtPACBancos.Key = ""
        Me.txtPACBancos.LabelAsoc = Me.lblPACBancos
        Me.txtPACBancos.Location = New System.Drawing.Point(0, 16)
        Me.txtPACBancos.Name = "txtPACBancos"
        Me.txtPACBancos.ReadOnly = True
        Me.txtPACBancos.Size = New System.Drawing.Size(101, 20)
        Me.txtPACBancos.TabIndex = 1
        Me.txtPACBancos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPACBancos
        '
        Me.lblPACBancos.AutoSize = True
        Me.lblPACBancos.LabelAsoc = Nothing
        Me.lblPACBancos.Location = New System.Drawing.Point(58, 0)
        Me.lblPACBancos.Name = "lblPACBancos"
        Me.lblPACBancos.Size = New System.Drawing.Size(43, 13)
        Me.lblPACBancos.TabIndex = 0
        Me.lblPACBancos.Text = "Bancos"
        '
        'pnlBancos
        '
        Me.pnlBancos.Controls.Add(Me.txtPACBancos)
        Me.pnlBancos.Controls.Add(Me.lblPACBancos)
        Me.pnlBancos.Location = New System.Drawing.Point(643, 4)
        Me.pnlBancos.Name = "pnlBancos"
        Me.pnlBancos.Size = New System.Drawing.Size(104, 37)
        Me.pnlBancos.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(38, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtObservacion.BindearPropiedadControl = Nothing
        Me.txtObservacion.BindearPropiedadEntidad = Nothing
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Formato = "##0.00"
        Me.txtObservacion.IsDecimal = False
        Me.txtObservacion.IsNumber = False
        Me.txtObservacion.IsPK = False
        Me.txtObservacion.IsRequired = False
        Me.txtObservacion.Key = ""
        Me.txtObservacion.LabelAsoc = Nothing
        Me.txtObservacion.Location = New System.Drawing.Point(111, 57)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(643, 21)
        Me.txtObservacion.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlSaldosCuentaDestino)
        Me.Panel1.Controls.Add(Me.txtObservacion)
        Me.Panel1.Controls.Add(Me.cmbSucursalDestino)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblSucursalDestino)
        Me.Panel1.Controls.Add(Me.lblCaja)
        Me.Panel1.Controls.Add(Me.cmbCajasDestino)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 526)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 80)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlBancos)
        Me.Panel2.Controls.Add(Me.lblCajaOrigen)
        Me.Panel2.Controls.Add(Me.dtpFecha)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cmbCajasOrigen)
        Me.Panel2.Controls.Add(Me.lblPACTarjetas)
        Me.Panel2.Controls.Add(Me.lblFecha)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtPACEfectivo)
        Me.Panel2.Controls.Add(Me.lblPACDolares)
        Me.Panel2.Controls.Add(Me.txtPACDolares)
        Me.Panel2.Controls.Add(Me.lblPesosActual)
        Me.Panel2.Controls.Add(Me.txtPACCheques)
        Me.Panel2.Controls.Add(Me.txtPACTickets)
        Me.Panel2.Controls.Add(Me.txtPACTarjetas)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 45)
        Me.Panel2.TabIndex = 0
        '
        'ChequesMovimientosSucursales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 628)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ChequesMovimientosSucursales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos entre Cajas y Sucursales"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.tbcMovimientos.ResumeLayout(False)
        Me.tpgCarteraCheques.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.tpgTarjetasCupones.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.ugTarjetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlBancos3.ResumeLayout(False)
        Me.pnlBancos3.PerformLayout()
        Me.pnlSaldosCuentaDestino.ResumeLayout(False)
        Me.pnlSaldosCuentaDestino.PerformLayout()
        Me.pnlBancos2.ResumeLayout(False)
        Me.pnlBancos2.PerformLayout()
        Me.pnlBancos.ResumeLayout(False)
        Me.pnlBancos.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dtpFechaCobroDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaCobroDesde As Eniac.Controles.Label
    Friend WithEvents dtpFechaCobroHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaCobroHasta As Eniac.Controles.Label
    Friend WithEvents btnConsultar As Eniac.Controles.Button
    Friend WithEvents lblSucursalDestino As Eniac.Controles.Label
    Friend WithEvents cmbSucursalDestino As Eniac.Controles.ComboBox
    Friend WithEvents btnMover As Eniac.Controles.Button
    Friend WithEvents lblFechaCobro As Eniac.Controles.Label
    Friend WithEvents cmbCajasDestino As Eniac.Controles.ComboBox
    Friend WithEvents lblCaja As Eniac.Controles.Label
    Friend WithEvents lblTickets As Eniac.Controles.Label
    Friend WithEvents lblDolares As Eniac.Controles.Label
    Friend WithEvents lblPesos As Eniac.Controles.Label
    Friend WithEvents txtPesos As Eniac.Controles.TextBox
    Friend WithEvents txtTickets As Eniac.Controles.TextBox
    Friend WithEvents txtDolares As Eniac.Controles.TextBox
    Friend WithEvents cmbCajasOrigen As Eniac.Controles.ComboBox
    Friend WithEvents lblCajaOrigen As Eniac.Controles.Label
    Friend WithEvents txtPACCheques As Eniac.Controles.MaskedTextBox
    Friend WithEvents txtPACTarjetas As Eniac.Controles.MaskedTextBox
    Friend WithEvents txtPACTickets As Eniac.Controles.MaskedTextBox
    Friend WithEvents txtPACDolares As Eniac.Controles.MaskedTextBox
    Friend WithEvents txtPACEfectivo As Eniac.Controles.MaskedTextBox
    Friend WithEvents Label7 As Eniac.Controles.Label
    Friend WithEvents lblPACTarjetas As Eniac.Controles.Label
    Friend WithEvents Label9 As Eniac.Controles.Label
    Friend WithEvents lblPACDolares As Eniac.Controles.Label
    Friend WithEvents lblPesosActual As Eniac.Controles.Label
    Friend WithEvents txtPACCheques2 As Eniac.Controles.MaskedTextBox
    Friend WithEvents txtPACTarjetas2 As Eniac.Controles.MaskedTextBox
    Friend WithEvents txtPACTickets2 As Eniac.Controles.MaskedTextBox
    Friend WithEvents txtPACDolares2 As Eniac.Controles.MaskedTextBox
    Friend WithEvents txtPACEfectivo2 As Eniac.Controles.MaskedTextBox
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents lblPACTarjetas2 As Eniac.Controles.Label
    Friend WithEvents Label3 As Eniac.Controles.Label
    Friend WithEvents lblPACDolares2 As Eniac.Controles.Label
    Friend WithEvents Label5 As Eniac.Controles.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFecha As Eniac.Controles.Label
    Friend WithEvents lblCotizacionDolares As Eniac.Controles.Label
    Friend WithEvents txtCotizacionDolares As Eniac.Controles.TextBox
    Friend WithEvents pnlSaldosCuentaDestino As System.Windows.Forms.Panel
    Friend WithEvents txtPACBancos2 As Eniac.Controles.MaskedTextBox
    Friend WithEvents lblPACBancos2 As Eniac.Controles.Label
    Friend WithEvents txtPACBancos As Eniac.Controles.MaskedTextBox
    Friend WithEvents lblPACBancos As Eniac.Controles.Label
    Friend WithEvents Label2 As Eniac.Controles.Label
    Friend WithEvents txtBancos As Eniac.Controles.TextBox
    Friend WithEvents pnlBancos As System.Windows.Forms.Panel
    Friend WithEvents pnlBancos2 As System.Windows.Forms.Panel
    Friend WithEvents pnlBancos3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As Eniac.Controles.Label
    Friend WithEvents txtObservacion As Eniac.Controles.TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ugDetalle As UltraGridSiga
    Friend WithEvents btnTodos As Button
    Friend WithEvents cmbTodos As Controles.ComboBox
    Friend WithEvents tbcMovimientos As TabControl
    Friend WithEvents tpgCarteraCheques As TabPage
    Friend WithEvents tpgTarjetasCupones As TabPage
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dtpDesdeEmision As Controles.DateTimePicker
    Friend WithEvents lblDesdeEmision As Controles.Label
    Friend WithEvents btnConsultarTrj As Controles.Button
    Friend WithEvents btnTodosTrj As Button
    Friend WithEvents dtpHastaEmision As Controles.DateTimePicker
    Friend WithEvents lblHastaEmision As Controles.Label
    Friend WithEvents cmbTodosTrj As Controles.ComboBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents chbMesCompleto As Controles.CheckBox
    Friend WithEvents chbFechaEmision As Controles.CheckBox
    Friend WithEvents cmbTarjeta As Controles.ComboBox
    Friend WithEvents chbTarjeta As Controles.CheckBox
    Friend WithEvents chbNumeroLote As Controles.CheckBox
    Friend WithEvents txtNumeroLote As Controles.TextBox
    Friend WithEvents chbNumeroCupon As Controles.CheckBox
    Friend WithEvents txtNumeroCupon As Controles.TextBox
    Friend WithEvents cmbBanco As Controles.ComboBox
    Friend WithEvents chbBanco As Controles.CheckBox
    Friend WithEvents bscCodigoCliente As Controles.Buscador2
    Friend WithEvents bscNombreCliente As Controles.Buscador2
    Friend WithEvents chbCliente As Controles.CheckBox
    Friend WithEvents ugTarjetas As UltraGridSiga
End Class
