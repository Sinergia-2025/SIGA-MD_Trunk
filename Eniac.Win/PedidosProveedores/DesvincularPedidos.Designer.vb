<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesvincularPedidos
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado")
      Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantEstado")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstado")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalVinculado")
      Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteVinculado")
      Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrevVinculado")
      Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraVinculado")
      Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorVinculado")
      Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedidoVinculado")
      Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenVinculado")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedorVinculado")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedorVinculado")
      Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedorVinculado")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoVinculado")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoVinculado")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCompradorVinculado")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCompradorVinculado")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCompradorVinculado")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedidoVinculado")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstadoVinculado")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionVinculado")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
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
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.grpEstadosNuevos = New System.Windows.Forms.GroupBox()
      Me.lblNuevoEstadoPedidoProveedor = New Eniac.Controles.Label()
      Me.lblNuevoEstadoPedidoCliente = New Eniac.Controles.Label()
      Me.cmbNuevoEstadoPedidoProveedor = New Eniac.Controles.ComboBox()
      Me.cmbNuevoEstadoPedidoCliente = New Eniac.Controles.ComboBox()
      Me.ugResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.grpEstadosNuevos.SuspendLayout()
      CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbSalir, Me.ToolStripSeparator4})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(973, 29)
      Me.tstBarra.TabIndex = 7
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
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(94, 26)
      Me.tsbGrabar.Text = "&Desvincular"
      Me.tsbGrabar.ToolTipText = "Grabar Vinculaciones"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(973, 22)
      Me.stsStado.TabIndex = 6
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(894, 17)
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
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.btnConsultar)
      Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
      Me.GroupBox1.Location = New System.Drawing.Point(0, 29)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(973, 65)
      Me.GroupBox1.TabIndex = 8
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Filtros"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
      Me.btnConsultar.Location = New System.Drawing.Point(874, 13)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(93, 45)
      Me.btnConsultar.TabIndex = 22
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'grpEstadosNuevos
      '
      Me.grpEstadosNuevos.Controls.Add(Me.lblNuevoEstadoPedidoProveedor)
      Me.grpEstadosNuevos.Controls.Add(Me.lblNuevoEstadoPedidoCliente)
      Me.grpEstadosNuevos.Controls.Add(Me.cmbNuevoEstadoPedidoProveedor)
      Me.grpEstadosNuevos.Controls.Add(Me.cmbNuevoEstadoPedidoCliente)
      Me.grpEstadosNuevos.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpEstadosNuevos.Location = New System.Drawing.Point(0, 94)
      Me.grpEstadosNuevos.Name = "grpEstadosNuevos"
      Me.grpEstadosNuevos.Size = New System.Drawing.Size(973, 47)
      Me.grpEstadosNuevos.TabIndex = 10
      Me.grpEstadosNuevos.TabStop = False
      Me.grpEstadosNuevos.Text = "Estados nuevos"
      '
      'lblNuevoEstadoPedidoProveedor
      '
      Me.lblNuevoEstadoPedidoProveedor.AutoSize = True
      Me.lblNuevoEstadoPedidoProveedor.LabelAsoc = Nothing
      Me.lblNuevoEstadoPedidoProveedor.Location = New System.Drawing.Point(438, 19)
      Me.lblNuevoEstadoPedidoProveedor.Name = "lblNuevoEstadoPedidoProveedor"
      Me.lblNuevoEstadoPedidoProveedor.Size = New System.Drawing.Size(163, 13)
      Me.lblNuevoEstadoPedidoProveedor.TabIndex = 2
      Me.lblNuevoEstadoPedidoProveedor.Text = "Nuevo Estado Pedido Proveedor"
      '
      'lblNuevoEstadoPedidoCliente
      '
      Me.lblNuevoEstadoPedidoCliente.AutoSize = True
      Me.lblNuevoEstadoPedidoCliente.LabelAsoc = Nothing
      Me.lblNuevoEstadoPedidoCliente.Location = New System.Drawing.Point(107, 19)
      Me.lblNuevoEstadoPedidoCliente.Name = "lblNuevoEstadoPedidoCliente"
      Me.lblNuevoEstadoPedidoCliente.Size = New System.Drawing.Size(146, 13)
      Me.lblNuevoEstadoPedidoCliente.TabIndex = 3
      Me.lblNuevoEstadoPedidoCliente.Text = "Nuevo Estado Pedido Cliente"
      '
      'cmbNuevoEstadoPedidoProveedor
      '
      Me.cmbNuevoEstadoPedidoProveedor.BindearPropiedadControl = ""
      Me.cmbNuevoEstadoPedidoProveedor.BindearPropiedadEntidad = ""
      Me.cmbNuevoEstadoPedidoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNuevoEstadoPedidoProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNuevoEstadoPedidoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNuevoEstadoPedidoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNuevoEstadoPedidoProveedor.FormattingEnabled = True
      Me.cmbNuevoEstadoPedidoProveedor.IsPK = False
      Me.cmbNuevoEstadoPedidoProveedor.IsRequired = False
      Me.cmbNuevoEstadoPedidoProveedor.Key = Nothing
      Me.cmbNuevoEstadoPedidoProveedor.LabelAsoc = Me.lblNuevoEstadoPedidoProveedor
      Me.cmbNuevoEstadoPedidoProveedor.Location = New System.Drawing.Point(607, 16)
      Me.cmbNuevoEstadoPedidoProveedor.Name = "cmbNuevoEstadoPedidoProveedor"
      Me.cmbNuevoEstadoPedidoProveedor.Size = New System.Drawing.Size(140, 21)
      Me.cmbNuevoEstadoPedidoProveedor.TabIndex = 4
      '
      'cmbNuevoEstadoPedidoCliente
      '
      Me.cmbNuevoEstadoPedidoCliente.BindearPropiedadControl = ""
      Me.cmbNuevoEstadoPedidoCliente.BindearPropiedadEntidad = ""
      Me.cmbNuevoEstadoPedidoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNuevoEstadoPedidoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNuevoEstadoPedidoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNuevoEstadoPedidoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNuevoEstadoPedidoCliente.FormattingEnabled = True
      Me.cmbNuevoEstadoPedidoCliente.IsPK = False
      Me.cmbNuevoEstadoPedidoCliente.IsRequired = False
      Me.cmbNuevoEstadoPedidoCliente.Key = Nothing
      Me.cmbNuevoEstadoPedidoCliente.LabelAsoc = Me.lblNuevoEstadoPedidoCliente
      Me.cmbNuevoEstadoPedidoCliente.Location = New System.Drawing.Point(259, 16)
      Me.cmbNuevoEstadoPedidoCliente.Name = "cmbNuevoEstadoPedidoCliente"
      Me.cmbNuevoEstadoPedidoCliente.Size = New System.Drawing.Size(140, 21)
      Me.cmbNuevoEstadoPedidoCliente.TabIndex = 5
      '
      'ugResumen
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugResumen.DisplayLayout.Appearance = Appearance1
      UltraGridColumn55.Header.Caption = "Sucursal"
      UltraGridColumn55.Header.VisiblePosition = 0
      UltraGridColumn55.Hidden = True
      UltraGridColumn56.Header.Caption = "Id Tipo"
      UltraGridColumn56.Header.VisiblePosition = 1
      UltraGridColumn56.Hidden = True
      UltraGridColumn56.Width = 70
      UltraGridColumn76.Header.Caption = "Tipo"
      UltraGridColumn76.Header.VisiblePosition = 2
      UltraGridColumn76.Width = 70
      UltraGridColumn57.Header.Caption = "L."
      UltraGridColumn57.Header.VisiblePosition = 3
      UltraGridColumn57.Width = 25
      UltraGridColumn58.Header.Caption = "Emisor"
      UltraGridColumn58.Header.VisiblePosition = 4
      UltraGridColumn58.Width = 50
      UltraGridColumn59.Header.Caption = "Número"
      UltraGridColumn59.Header.VisiblePosition = 5
      UltraGridColumn59.Width = 70
      UltraGridColumn60.Header.VisiblePosition = 6
      UltraGridColumn60.Width = 45
      UltraGridColumn1.Header.Caption = "Id Cliente"
      UltraGridColumn1.Header.VisiblePosition = 7
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.Caption = "Código Cliente"
      UltraGridColumn2.Header.VisiblePosition = 8
      UltraGridColumn2.Width = 51
      UltraGridColumn77.Header.Caption = "Cliente"
      UltraGridColumn77.Header.VisiblePosition = 9
      UltraGridColumn77.Width = 170
      UltraGridColumn61.Header.Caption = "Código Producto"
      UltraGridColumn61.Header.VisiblePosition = 10
      UltraGridColumn61.Width = 65
      UltraGridColumn62.Header.Caption = "Producto"
      UltraGridColumn62.Header.VisiblePosition = 11
      UltraGridColumn62.Width = 180
      UltraGridColumn3.Header.Caption = "Estado"
      UltraGridColumn3.Header.VisiblePosition = 27
      UltraGridColumn3.Width = 77
      UltraGridColumn63.Header.Caption = "Cantidad"
      UltraGridColumn63.Header.VisiblePosition = 12
      UltraGridColumn63.Width = 80
      UltraGridColumn6.Header.Caption = "Vendedor"
      UltraGridColumn6.Header.VisiblePosition = 31
      UltraGridColumn7.Header.Caption = "Fecha Pedido"
      UltraGridColumn7.Header.VisiblePosition = 19
      UltraGridColumn7.Hidden = True
      UltraGridColumn8.Header.Caption = "Fecha Estado"
      UltraGridColumn8.Header.VisiblePosition = 21
      UltraGridColumn8.Hidden = True
      UltraGridColumn9.Header.Caption = "Observación"
      UltraGridColumn9.Header.VisiblePosition = 24
      UltraGridColumn9.Hidden = True
      UltraGridColumn64.Header.Caption = "Sucursal Vinculado"
      UltraGridColumn64.Header.VisiblePosition = 13
      UltraGridColumn64.Hidden = True
      UltraGridColumn65.Header.Caption = "Id Tipo Vinculado"
      UltraGridColumn65.Header.VisiblePosition = 14
      UltraGridColumn65.Hidden = True
      UltraGridColumn65.Width = 70
      UltraGridColumn78.Header.Caption = "Tipo Vinculado"
      UltraGridColumn78.Header.VisiblePosition = 15
      UltraGridColumn78.Width = 70
      UltraGridColumn66.Header.Caption = "L. V."
      UltraGridColumn66.Header.VisiblePosition = 16
      UltraGridColumn66.Width = 25
      UltraGridColumn67.Header.Caption = "Emisor Vinc."
      UltraGridColumn67.Header.VisiblePosition = 17
      UltraGridColumn67.Width = 50
      UltraGridColumn68.Header.Caption = "Número Vinculado"
      UltraGridColumn68.Header.VisiblePosition = 18
      UltraGridColumn68.Width = 70
      UltraGridColumn69.Header.Caption = "Orden Vinc."
      UltraGridColumn69.Header.VisiblePosition = 20
      UltraGridColumn69.Width = 45
      UltraGridColumn10.Header.Caption = "ID Proveedor"
      UltraGridColumn10.Header.VisiblePosition = 25
      UltraGridColumn10.Hidden = True
      UltraGridColumn11.Header.Caption = "Código Proveedor"
      UltraGridColumn11.Header.VisiblePosition = 22
      UltraGridColumn11.Width = 62
      UltraGridColumn79.Header.Caption = "Proveedor"
      UltraGridColumn79.Header.VisiblePosition = 23
      UltraGridColumn79.Width = 170
      UltraGridColumn12.Header.Caption = "Id Producto Vinculado"
      UltraGridColumn12.Header.VisiblePosition = 26
      UltraGridColumn12.Hidden = True
      UltraGridColumn13.Header.Caption = "Estado Vinculado"
      UltraGridColumn13.Header.VisiblePosition = 28
      UltraGridColumn13.Width = 64
      UltraGridColumn14.Header.Caption = "Tp.Doc. Comprador"
      UltraGridColumn14.Header.VisiblePosition = 29
      UltraGridColumn14.Hidden = True
      UltraGridColumn15.Header.Caption = "Nro.Doc. Comprador"
      UltraGridColumn15.Header.VisiblePosition = 30
      UltraGridColumn15.Hidden = True
      UltraGridColumn16.Header.Caption = "Comprador"
      UltraGridColumn16.Header.VisiblePosition = 32
      UltraGridColumn17.Header.Caption = "Fecha Pedido Vinculado"
      UltraGridColumn17.Header.VisiblePosition = 33
      UltraGridColumn17.Hidden = True
      UltraGridColumn18.Header.Caption = "Fecha Estado Vinculado"
      UltraGridColumn18.Header.VisiblePosition = 34
      UltraGridColumn18.Hidden = True
      UltraGridColumn19.Header.Caption = "Observación Vinculado"
      UltraGridColumn19.Header.VisiblePosition = 36
      UltraGridColumn19.Hidden = True
      UltraGridColumn20.Header.VisiblePosition = 35
      UltraGridColumn20.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn55, UltraGridColumn56, UltraGridColumn76, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn1, UltraGridColumn2, UltraGridColumn77, UltraGridColumn61, UltraGridColumn62, UltraGridColumn3, UltraGridColumn63, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn64, UltraGridColumn65, UltraGridColumn78, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn10, UltraGridColumn11, UltraGridColumn79, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20})
      Me.ugResumen.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugResumen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugResumen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugResumen.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugResumen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugResumen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugResumen.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugResumen.DisplayLayout.MaxColScrollRegions = 1
      Me.ugResumen.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugResumen.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugResumen.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugResumen.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugResumen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugResumen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugResumen.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugResumen.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugResumen.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugResumen.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugResumen.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugResumen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugResumen.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugResumen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugResumen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugResumen.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugResumen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugResumen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugResumen.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugResumen.Location = New System.Drawing.Point(0, 141)
      Me.ugResumen.Name = "ugResumen"
      Me.ugResumen.Size = New System.Drawing.Size(973, 398)
      Me.ugResumen.TabIndex = 11
      Me.ugResumen.Text = "UltraGrid1"
      '
      'DesvincularPedidos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(973, 561)
      Me.Controls.Add(Me.ugResumen)
      Me.Controls.Add(Me.grpEstadosNuevos)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.stsStado)
      Me.Name = "DesvincularPedidos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Desvincular Pedidos de Clientes de Pedidos de Proveedores"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.grpEstadosNuevos.ResumeLayout(False)
      Me.grpEstadosNuevos.PerformLayout()
      CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents grpEstadosNuevos As System.Windows.Forms.GroupBox
   Friend WithEvents ugResumen As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents lblNuevoEstadoPedidoProveedor As Eniac.Controles.Label
   Friend WithEvents lblNuevoEstadoPedidoCliente As Eniac.Controles.Label
   Friend WithEvents cmbNuevoEstadoPedidoProveedor As Eniac.Controles.ComboBox
   Friend WithEvents cmbNuevoEstadoPedidoCliente As Eniac.Controles.ComboBox
End Class
