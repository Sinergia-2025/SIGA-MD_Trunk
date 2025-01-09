<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cajero
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
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocVendedor")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocVendedor")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoria")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTarjetas")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCaja")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCaja")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selec")
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
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cajero))
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc")
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteImpuestoInterno")
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
      Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.chbActualizacionAutomatica = New System.Windows.Forms.CheckBox()
      Me.txtSegundos = New System.Windows.Forms.NumericUpDown()
      Me.lblSegundos = New System.Windows.Forms.Label()
      Me.ugVentas = New Eniac.Win.UltraGridEditable()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCobrar = New System.Windows.Forms.ToolStripButton()
      Me.tsbVisto = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCobrarEfectivo = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ugVentasProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CalculosDescuentosRecargos1 = New Eniac.Win.CalculosDescuentosRecargos(Me.components)
        CType(Me.txtSegundos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugVentasProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'chbActualizacionAutomatica
        '
        Me.chbActualizacionAutomatica.AutoSize = True
        Me.chbActualizacionAutomatica.Location = New System.Drawing.Point(12, 32)
        Me.chbActualizacionAutomatica.Name = "chbActualizacionAutomatica"
        Me.chbActualizacionAutomatica.Size = New System.Drawing.Size(144, 17)
        Me.chbActualizacionAutomatica.TabIndex = 1
        Me.chbActualizacionAutomatica.Text = "Actualización automática"
        Me.chbActualizacionAutomatica.UseVisualStyleBackColor = True
        '
        'txtSegundos
        '
        Me.txtSegundos.Location = New System.Drawing.Point(162, 30)
        Me.txtSegundos.Name = "txtSegundos"
        Me.txtSegundos.Size = New System.Drawing.Size(60, 20)
        Me.txtSegundos.TabIndex = 2
        Me.txtSegundos.TabStop = False
        Me.txtSegundos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSegundos.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'lblSegundos
        '
        Me.lblSegundos.AutoSize = True
        Me.lblSegundos.Location = New System.Drawing.Point(228, 34)
        Me.lblSegundos.Name = "lblSegundos"
        Me.lblSegundos.Size = New System.Drawing.Size(53, 13)
        Me.lblSegundos.TabIndex = 3
        Me.lblSegundos.Text = "segundos"
        '
        'ugVentas
        '
        Me.ugVentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugVentas.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn1.Header.Caption = "Sucursal"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 60
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn2.Header.Caption = "Tipo"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 78
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 25
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Header.Caption = "Emisor"
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 50
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance3
        UltraGridColumn5.Header.Caption = "Número"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 63
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance4
        UltraGridColumn6.Header.Caption = "Id Cliente"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance5
        UltraGridColumn7.Header.Caption = "Código"
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 64
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn8.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn8.Header.Caption = "Cliente"
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Width = 205
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn9.Header.Caption = "T.D. Vendedor"
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance6
        UltraGridColumn10.Header.Caption = "Nro. Vendedor"
        UltraGridColumn10.Header.VisiblePosition = 10
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn11.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn11.Header.Caption = "Vendedor"
        UltraGridColumn11.Header.VisiblePosition = 11
        UltraGridColumn11.Width = 92
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn12.CellAppearance = Appearance7
        UltraGridColumn12.Format = "HH:mm"
        UltraGridColumn12.Header.Caption = "Hora"
        UltraGridColumn12.Header.VisiblePosition = 12
        UltraGridColumn12.Width = 61
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn13.Header.Caption = "Id Formas Pago"
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn14.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn14.Header.Caption = "F.P."
        UltraGridColumn14.Header.VisiblePosition = 14
        UltraGridColumn14.Width = 70
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance8
        UltraGridColumn15.Format = "N2"
        UltraGridColumn15.Header.Caption = "Importe"
        UltraGridColumn15.Header.VisiblePosition = 16
        UltraGridColumn15.MaskInput = "{double:-12.2}"
        UltraGridColumn15.Width = 74
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance9
        UltraGridColumn31.Header.Caption = "% D/R"
        UltraGridColumn31.Header.VisiblePosition = 15
        UltraGridColumn31.Width = 51
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn32.Header.Caption = "Id Categoria Cliente"
        UltraGridColumn32.Header.VisiblePosition = 17
        UltraGridColumn32.Hidden = True
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn33.Header.Caption = "Id Categoria Fiscal"
        UltraGridColumn33.Header.VisiblePosition = 18
        UltraGridColumn33.Hidden = True
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn34.Header.Caption = "Categoria Fiscal"
        UltraGridColumn34.Header.VisiblePosition = 19
        UltraGridColumn34.Hidden = True
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance10
        UltraGridColumn35.Format = "N2"
        UltraGridColumn35.Header.Caption = "Tarjetas"
        UltraGridColumn35.Header.VisiblePosition = 20
        UltraGridColumn35.Width = 84
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn37.CellAppearance = Appearance11
        UltraGridColumn37.Header.Caption = "Id Caja"
        UltraGridColumn37.Header.VisiblePosition = 21
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn38.Header.Caption = "Caja"
        UltraGridColumn38.Header.VisiblePosition = 22
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn36.CellAppearance = Appearance12
        UltraGridColumn36.Header.Caption = ""
        UltraGridColumn36.Header.VisiblePosition = 1
        UltraGridColumn36.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn36.Width = 47
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn37, UltraGridColumn38, UltraGridColumn36})
        Me.ugVentas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugVentas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugVentas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVentas.DisplayLayout.GroupByBox.Appearance = Appearance13
        Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVentas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance14
        Me.ugVentas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance15.BackColor2 = System.Drawing.SystemColors.Control
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVentas.DisplayLayout.GroupByBox.PromptAppearance = Appearance15
        Me.ugVentas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugVentas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugVentas.DisplayLayout.Override.ActiveCellAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.SystemColors.Highlight
        Appearance17.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugVentas.DisplayLayout.Override.ActiveRowAppearance = Appearance17
        Me.ugVentas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugVentas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugVentas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugVentas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugVentas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugVentas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Me.ugVentas.DisplayLayout.Override.CardAreaAppearance = Appearance18
        Appearance19.BorderColor = System.Drawing.Color.Silver
        Appearance19.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugVentas.DisplayLayout.Override.CellAppearance = Appearance19
        Me.ugVentas.DisplayLayout.Override.CellPadding = 0
        Me.ugVentas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugVentas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance20.BackColor = System.Drawing.SystemColors.Control
        Appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance20.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVentas.DisplayLayout.Override.GroupByRowAppearance = Appearance20
        Appearance21.TextHAlignAsString = "Left"
        Me.ugVentas.DisplayLayout.Override.HeaderAppearance = Appearance21
        Me.ugVentas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugVentas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Me.ugVentas.DisplayLayout.Override.RowAppearance = Appearance22
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugVentas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance23
        Me.ugVentas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugVentas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugVentas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugVentas.Location = New System.Drawing.Point(12, 56)
        Me.ugVentas.Name = "ugVentas"
        Me.ugVentas.Size = New System.Drawing.Size(910, 231)
        Me.ugVentas.TabIndex = 4
        Me.ugVentas.Text = "UltraGrid1"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbCobrar, Me.tsbVisto, Me.ToolStripSeparator4, Me.tsbCobrarEfectivo, Me.ToolStripSeparator5, Me.tsbAnular, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.toolStripSeparator3, Me.tsbSalir, Me.lblEstado})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(934, 29)
        Me.tstBarra.TabIndex = 5
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCobrar
        '
        Me.tsbCobrar.Image = Global.Eniac.Win.My.Resources.Resources.cashier
        Me.tsbCobrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCobrar.Name = "tsbCobrar"
        Me.tsbCobrar.Size = New System.Drawing.Size(92, 26)
        Me.tsbCobrar.Text = "&Cobrar (F4)"
        '
        'tsbVisto
        '
        Me.tsbVisto.Image = Global.Eniac.Win.My.Resources.Resources.check2
        Me.tsbVisto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVisto.Name = "tsbVisto"
        Me.tsbVisto.Size = New System.Drawing.Size(82, 26)
        Me.tsbVisto.Text = "Visto (F4)"
        Me.tsbVisto.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCobrarEfectivo
        '
        Me.tsbCobrarEfectivo.Image = Global.Eniac.Win.My.Resources.Resources.money2
        Me.tsbCobrarEfectivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCobrarEfectivo.Name = "tsbCobrarEfectivo"
        Me.tsbCobrarEfectivo.Size = New System.Drawing.Size(137, 26)
        Me.tsbCobrarEfectivo.Text = "Cobrar &Efectivo (F8)"
        Me.tsbCobrarEfectivo.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        Me.ToolStripSeparator5.Visible = False
        '
        'tsbAnular
        '
        Me.tsbAnular.Image = Global.Eniac.Win.My.Resources.Resources.document_delete
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(103, 26)
        Me.tsbAnular.Text = "&Anular (Supr)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'lblEstado
        '
        Me.lblEstado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(0, 26)
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 489)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(934, 22)
        Me.stsStado.TabIndex = 6
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(855, 17)
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
        'ugVentasProductos
        '
        Me.ugVentasProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugVentasProductos.DisplayLayout.Appearance = Appearance24
        Me.ugVentasProductos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance25
        UltraGridColumn16.Header.Caption = "Sucursal"
        UltraGridColumn16.Header.VisiblePosition = 0
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.Header.Caption = "Tipo"
        UltraGridColumn17.Header.VisiblePosition = 1
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.Header.VisiblePosition = 2
        UltraGridColumn18.Hidden = True
        Appearance26.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance26
        UltraGridColumn19.Header.Caption = "Emisor"
        UltraGridColumn19.Header.VisiblePosition = 3
        UltraGridColumn19.Hidden = True
        Appearance27.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance27
        UltraGridColumn20.Header.Caption = "Número"
        UltraGridColumn20.Header.VisiblePosition = 4
        UltraGridColumn20.Hidden = True
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance28
        UltraGridColumn21.Header.VisiblePosition = 5
        UltraGridColumn21.Width = 60
        UltraGridColumn22.Header.Caption = "Código"
        UltraGridColumn22.Header.VisiblePosition = 6
        UltraGridColumn22.Width = 93
        UltraGridColumn23.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn23.Header.Caption = "Producto"
        UltraGridColumn23.Header.VisiblePosition = 7
        UltraGridColumn23.Width = 371
        Appearance29.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance29
        UltraGridColumn24.Format = "N2"
        UltraGridColumn24.Header.VisiblePosition = 8
        UltraGridColumn24.Width = 68
        Appearance30.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance30
        UltraGridColumn25.Header.VisiblePosition = 9
        UltraGridColumn25.Width = 68
        Appearance31.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance31
        UltraGridColumn26.Header.Caption = "% D/R 1"
        UltraGridColumn26.Header.VisiblePosition = 10
        UltraGridColumn26.Width = 68
        Appearance32.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance32
        UltraGridColumn27.Header.Caption = "% D/R 2"
        UltraGridColumn27.Header.VisiblePosition = 11
        UltraGridColumn27.Width = 68
        Appearance33.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance33
        UltraGridColumn28.Header.Caption = "Id Lista Precios"
        UltraGridColumn28.Header.VisiblePosition = 12
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.Header.Caption = "Lista Precios"
        UltraGridColumn29.Header.VisiblePosition = 13
        UltraGridColumn29.Width = 112
        Appearance34.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance34
        UltraGridColumn30.Header.Caption = "Impuestos Internos"
        UltraGridColumn30.Header.VisiblePosition = 14
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 60
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30})
        Me.ugVentasProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugVentasProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugVentasProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance35.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance35.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance35.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVentasProductos.DisplayLayout.GroupByBox.Appearance = Appearance35
        Appearance36.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVentasProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance36
        Me.ugVentasProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance37.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance37.BackColor2 = System.Drawing.SystemColors.Control
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance37.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVentasProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance37
        Me.ugVentasProductos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugVentasProductos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugVentasProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance38
        Appearance39.BackColor = System.Drawing.SystemColors.Highlight
        Appearance39.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugVentasProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance39
        Me.ugVentasProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugVentasProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugVentasProductos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugVentasProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugVentasProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugVentasProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance40.BackColor = System.Drawing.SystemColors.Window
        Me.ugVentasProductos.DisplayLayout.Override.CardAreaAppearance = Appearance40
        Appearance41.BorderColor = System.Drawing.Color.Silver
        Appearance41.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugVentasProductos.DisplayLayout.Override.CellAppearance = Appearance41
        Me.ugVentasProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugVentasProductos.DisplayLayout.Override.CellPadding = 0
        Me.ugVentasProductos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugVentasProductos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance42.BackColor = System.Drawing.SystemColors.Control
        Appearance42.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance42.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance42.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVentasProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance42
        Appearance43.TextHAlignAsString = "Left"
        Me.ugVentasProductos.DisplayLayout.Override.HeaderAppearance = Appearance43
        Me.ugVentasProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugVentasProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance44.BackColor = System.Drawing.SystemColors.Window
        Appearance44.BorderColor = System.Drawing.Color.Silver
        Me.ugVentasProductos.DisplayLayout.Override.RowAppearance = Appearance44
        Me.ugVentasProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance45.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugVentasProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance45
        Me.ugVentasProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugVentasProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugVentasProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugVentasProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugVentasProductos.Location = New System.Drawing.Point(12, 293)
        Me.ugVentasProductos.Name = "ugVentasProductos"
        Me.ugVentasProductos.Size = New System.Drawing.Size(910, 193)
        Me.ugVentasProductos.TabIndex = 7
        Me.ugVentasProductos.Text = "UltraGrid1"
        '
        'CalculosDescuentosRecargos1
        '
        Me.CalculosDescuentosRecargos1.HabilitaDescuentoRecargoProducto = True
        '
        'Cajero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 511)
        Me.Controls.Add(Me.ugVentasProductos)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.ugVentas)
        Me.Controls.Add(Me.lblSegundos)
        Me.Controls.Add(Me.txtSegundos)
        Me.Controls.Add(Me.chbActualizacionAutomatica)
        Me.KeyPreview = True
        Me.Name = "Cajero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cajero"
        CType(Me.txtSegundos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugVentasProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents chbActualizacionAutomatica As System.Windows.Forms.CheckBox
   Friend WithEvents txtSegundos As System.Windows.Forms.NumericUpDown
   Friend WithEvents lblSegundos As System.Windows.Forms.Label
   Friend WithEvents ugVentas As UltraGridEditable
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ugVentasProductos As Infragistics.Win.UltraWinGrid.UltraGrid
   Public WithEvents tsbCobrar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbCobrarEfectivo As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbVisto As System.Windows.Forms.ToolStripButton
   Friend WithEvents CalculosDescuentosRecargos1 As Eniac.Win.CalculosDescuentosRecargos
   Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
End Class
