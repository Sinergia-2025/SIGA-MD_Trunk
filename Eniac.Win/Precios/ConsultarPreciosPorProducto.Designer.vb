<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultarPreciosPorProducto
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
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreListaPrecios")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioVentaSinIVA")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioVentaConIVA")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaActualizacion")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSucursal")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdDeposito")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreDeposito")
      Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUbicacion")
      Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreUbicacion")
      Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Stock")
      Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Actualizacion")
      Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDeposito")
      Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSucursal")
      Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdDeposito")
      Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreDeposito")
      Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUbicacion")
      Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreUbicacion")
      Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Stock")
      Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Actualizacion")
      Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSucursal")
      Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdDeposito")
      Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreDeposito")
      Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUbicacion")
      Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreUbicacion")
      Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Actualizacion")
      Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Stock")
      Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSucursal")
      Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdDeposito")
      Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreDeposito")
      Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUbicacion")
      Dim UltraDataColumn35 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreUbicacion")
      Dim UltraDataColumn36 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Stock")
      Dim UltraDataColumn37 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Actualizacion")
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
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeposito")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUbicacion")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Actualizacion")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoDeposito", 0)
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDeposito", 1)
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarPreciosPorProducto))
      Me.UltraDataSource4 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraDataSource5 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraDataSource3 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.tbcPrecioProducto = New System.Windows.Forms.TabControl()
      Me.tpgLista = New System.Windows.Forms.TabPage()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.picBoxProducto = New System.Windows.Forms.PictureBox()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblOferta = New System.Windows.Forms.Label()
      Me.txtFechaActProd = New Eniac.Controles.TextBox()
      Me.lblCodigoDeBarras = New Eniac.Controles.Label()
      Me.lblDescripcion = New System.Windows.Forms.Label()
      Me.LblFechaActProd = New Eniac.Controles.Label()
      Me.txtPrecio = New Eniac.Controles.TextBox()
      Me.lblAlicuota = New Eniac.Controles.Label()
      Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
      Me.lblListaPrecios = New Eniac.Controles.Label()
      Me.tpgMultiple = New System.Windows.Forms.TabPage()
      Me.ugvPrecios = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.txtNombreRubro = New Eniac.Controles.TextBox()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.txtNombreMarca = New Eniac.Controles.TextBox()
      Me.lblMarca = New Eniac.Controles.Label()
      Me.txtNombreProducto = New Eniac.Controles.TextBox()
      Me.lblNombreProducto = New Eniac.Controles.Label()
      Me.tpgStock = New System.Windows.Forms.TabPage()
      Me.ugStockDepositos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.txtNombreProductoII = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.txtCantidad = New Eniac.Controles.TextBox()
        Me.cmbTipoDeposito = New Eniac.Controles.ComboBox()
        Me.lblTipoDeposito = New Eniac.Controles.Label()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.txtMoneda = New Eniac.Controles.TextBox()
        Me.lblMoneda = New Eniac.Controles.Label()
        Me.txtAlicuota = New Eniac.Controles.TextBox()
        Me.txtCodigoDeBarras = New Eniac.Controles.TextBox()
        Me.txtStock = New Eniac.Controles.TextBox()
        Me.lblStock = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.txtCodigo = New Eniac.Controles.TextBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        CType(Me.UltraDataSource4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcPrecioProducto.SuspendLayout()
        Me.tpgLista.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.picBoxProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tpgMultiple.SuspendLayout()
        CType(Me.ugvPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgStock.SuspendLayout()
        CType(Me.ugStockDepositos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDataSource4
        '
        Me.UltraDataSource4.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4})
        '
        'UltraDataSource5
        '
        Me.UltraDataSource5.Band.Columns.AddRange(New Object() {UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13})
        '
        'UltraDataSource3
        '
        Me.UltraDataSource3.Band.Columns.AddRange(New Object() {UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21})
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27, UltraDataColumn28, UltraDataColumn29})
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn30, UltraDataColumn31, UltraDataColumn32, UltraDataColumn33, UltraDataColumn34, UltraDataColumn35, UltraDataColumn36, UltraDataColumn37})
        '
        'tbcPrecioProducto
        '
        Me.tbcPrecioProducto.Controls.Add(Me.tpgLista)
        Me.tbcPrecioProducto.Controls.Add(Me.tpgMultiple)
        Me.tbcPrecioProducto.Controls.Add(Me.tpgStock)
        Me.tbcPrecioProducto.Location = New System.Drawing.Point(8, 164)
        Me.tbcPrecioProducto.Name = "tbcPrecioProducto"
        Me.tbcPrecioProducto.SelectedIndex = 0
        Me.tbcPrecioProducto.Size = New System.Drawing.Size(848, 289)
        Me.tbcPrecioProducto.TabIndex = 1
        '
        'tpgLista
        '
        Me.tpgLista.BackColor = System.Drawing.SystemColors.Control
        Me.tpgLista.Controls.Add(Me.GroupBox1)
        Me.tpgLista.Controls.Add(Me.cmbListaDePrecios)
        Me.tpgLista.Controls.Add(Me.lblListaPrecios)
        Me.tpgLista.Location = New System.Drawing.Point(4, 22)
        Me.tpgLista.Name = "tpgLista"
        Me.tpgLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgLista.Size = New System.Drawing.Size(840, 263)
        Me.tpgLista.TabIndex = 1
        Me.tpgLista.Text = "Una Lista"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(828, 222)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.picBoxProducto, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(822, 203)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'picBoxProducto
        '
        Me.picBoxProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picBoxProducto.BackColor = System.Drawing.SystemColors.Control
        Me.picBoxProducto.Location = New System.Drawing.Point(3, 3)
        Me.picBoxProducto.Name = "picBoxProducto"
        Me.picBoxProducto.Size = New System.Drawing.Size(261, 197)
        Me.picBoxProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoxProducto.TabIndex = 10
        Me.picBoxProducto.TabStop = False
        Me.picBoxProducto.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblOferta)
        Me.Panel1.Controls.Add(Me.txtFechaActProd)
        Me.Panel1.Controls.Add(Me.lblDescripcion)
        Me.Panel1.Controls.Add(Me.LblFechaActProd)
        Me.Panel1.Controls.Add(Me.txtPrecio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(270, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(549, 197)
        Me.Panel1.TabIndex = 11
        '
        'lblOferta
        '
        Me.lblOferta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblOferta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOferta.ForeColor = System.Drawing.Color.Red
        Me.lblOferta.Location = New System.Drawing.Point(226, 74)
        Me.lblOferta.Name = "lblOferta"
        Me.lblOferta.Size = New System.Drawing.Size(104, 26)
        Me.lblOferta.TabIndex = 9
        Me.lblOferta.Text = "Oferta:"
        Me.lblOferta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblOferta.Visible = False
        '
        'txtFechaActProd
        '
        Me.txtFechaActProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFechaActProd.BindearPropiedadControl = ""
        Me.txtFechaActProd.BindearPropiedadEntidad = ""
        Me.txtFechaActProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaActProd.ForeColor = System.Drawing.Color.Red
        Me.txtFechaActProd.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFechaActProd.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFechaActProd.Formato = "##0.0"
        Me.txtFechaActProd.IsDecimal = False
        Me.txtFechaActProd.IsNumber = False
        Me.txtFechaActProd.IsPK = False
        Me.txtFechaActProd.IsRequired = False
        Me.txtFechaActProd.Key = ""
        Me.txtFechaActProd.LabelAsoc = Me.lblCodigoDeBarras
        Me.txtFechaActProd.Location = New System.Drawing.Point(406, 171)
        Me.txtFechaActProd.MaxLength = 100
        Me.txtFechaActProd.Name = "txtFechaActProd"
        Me.txtFechaActProd.ReadOnly = True
        Me.txtFechaActProd.Size = New System.Drawing.Size(128, 24)
        Me.txtFechaActProd.TabIndex = 7
        Me.txtFechaActProd.TabStop = False
        Me.txtFechaActProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCodigoDeBarras
        '
        Me.lblCodigoDeBarras.AutoSize = True
        Me.lblCodigoDeBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoDeBarras.LabelAsoc = Nothing
        Me.lblCodigoDeBarras.Location = New System.Drawing.Point(467, 27)
        Me.lblCodigoDeBarras.Name = "lblCodigoDeBarras"
        Me.lblCodigoDeBarras.Size = New System.Drawing.Size(103, 17)
        Me.lblCodigoDeBarras.TabIndex = 5
        Me.lblCodigoDeBarras.Text = "Cod. de Barras"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.Color.Green
        Me.lblDescripcion.Location = New System.Drawing.Point(23, 0)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(501, 83)
        Me.lblDescripcion.TabIndex = 0
        Me.lblDescripcion.Text = "Descripcion del Producto"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDescripcion.Visible = False
        '
        'LblFechaActProd
        '
        Me.LblFechaActProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFechaActProd.AutoSize = True
        Me.LblFechaActProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaActProd.LabelAsoc = Nothing
        Me.LblFechaActProd.Location = New System.Drawing.Point(403, 151)
        Me.LblFechaActProd.Name = "LblFechaActProd"
        Me.LblFechaActProd.Size = New System.Drawing.Size(133, 17)
        Me.LblFechaActProd.TabIndex = 8
        Me.LblFechaActProd.Text = "Ultima actualización"
        '
        'txtPrecio
        '
        Me.txtPrecio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPrecio.BindearPropiedadControl = ""
        Me.txtPrecio.BindearPropiedadEntidad = ""
        Me.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtPrecio.ForeColorFocus = System.Drawing.Color.Empty
        Me.txtPrecio.ForeColorLostFocus = System.Drawing.Color.Empty
        Me.txtPrecio.Formato = "##,##0.00"
        Me.txtPrecio.IsDecimal = True
        Me.txtPrecio.IsNumber = True
        Me.txtPrecio.IsPK = False
        Me.txtPrecio.IsRequired = False
        Me.txtPrecio.Key = ""
        Me.txtPrecio.LabelAsoc = Me.lblAlicuota
        Me.txtPrecio.Location = New System.Drawing.Point(30, 86)
        Me.txtPrecio.MaxLength = 13
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.ReadOnly = True
        Me.txtPrecio.Size = New System.Drawing.Size(494, 109)
        Me.txtPrecio.TabIndex = 1
        Me.txtPrecio.Text = "0.00"
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPrecio.Visible = False
        '
        'lblAlicuota
        '
        Me.lblAlicuota.AutoSize = True
        Me.lblAlicuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlicuota.LabelAsoc = Nothing
        Me.lblAlicuota.Location = New System.Drawing.Point(691, 59)
        Me.lblAlicuota.Name = "lblAlicuota"
        Me.lblAlicuota.Size = New System.Drawing.Size(29, 17)
        Me.lblAlicuota.TabIndex = 9
        Me.lblAlicuota.Text = "IVA"
        '
        'cmbListaDePrecios
        '
        Me.cmbListaDePrecios.BindearPropiedadControl = Nothing
        Me.cmbListaDePrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaDePrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaDePrecios.FormattingEnabled = True
        Me.cmbListaDePrecios.IsPK = False
        Me.cmbListaDePrecios.IsRequired = False
        Me.cmbListaDePrecios.Key = Nothing
        Me.cmbListaDePrecios.LabelAsoc = Me.lblListaPrecios
        Me.cmbListaDePrecios.Location = New System.Drawing.Point(96, 8)
        Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
        Me.cmbListaDePrecios.Size = New System.Drawing.Size(194, 21)
        Me.cmbListaDePrecios.TabIndex = 1
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblListaPrecios.LabelAsoc = Nothing
        Me.lblListaPrecios.Location = New System.Drawing.Point(8, 11)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblListaPrecios.TabIndex = 0
        Me.lblListaPrecios.Text = "Lista de Precios"
        '
        'tpgMultiple
        '
        Me.tpgMultiple.BackColor = System.Drawing.SystemColors.Control
        Me.tpgMultiple.Controls.Add(Me.ugvPrecios)
        Me.tpgMultiple.Controls.Add(Me.txtNombreRubro)
        Me.tpgMultiple.Controls.Add(Me.txtNombreMarca)
        Me.tpgMultiple.Controls.Add(Me.lblMarca)
        Me.tpgMultiple.Controls.Add(Me.txtNombreProducto)
        Me.tpgMultiple.Controls.Add(Me.lblNombreProducto)
        Me.tpgMultiple.Controls.Add(Me.lblRubro)
        Me.tpgMultiple.Location = New System.Drawing.Point(4, 22)
        Me.tpgMultiple.Name = "tpgMultiple"
        Me.tpgMultiple.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgMultiple.Size = New System.Drawing.Size(840, 263)
        Me.tpgMultiple.TabIndex = 0
        Me.tpgMultiple.Text = "Listas Múltiples"
        '
        'ugvPrecios
        '
        Me.ugvPrecios.DataSource = Me.UltraDataSource4
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvPrecios.DisplayLayout.Appearance = Appearance1
        Me.ugvPrecios.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvPrecios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.ugvPrecios.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvPrecios.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvPrecios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugvPrecios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvPrecios.DisplayLayout.GroupByBox.Hidden = True
        Me.ugvPrecios.DisplayLayout.GroupByBox.Prompt = "Arrastrar la columna que desea agrupar"
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvPrecios.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugvPrecios.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvPrecios.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvPrecios.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvPrecios.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugvPrecios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvPrecios.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugvPrecios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvPrecios.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvPrecios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvPrecios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugvPrecios.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvPrecios.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugvPrecios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvPrecios.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.BackColor2 = System.Drawing.Color.Transparent
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.FontData.SizeInPoints = 9.0!
        Me.ugvPrecios.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.Silver
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.TextHAlignAsString = "Left"
        Me.ugvPrecios.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugvPrecios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvPrecios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugvPrecios.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugvPrecios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvPrecios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugvPrecios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvPrecios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvPrecios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvPrecios.Location = New System.Drawing.Point(189, 49)
        Me.ugvPrecios.Name = "ugvPrecios"
        Me.ugvPrecios.Size = New System.Drawing.Size(491, 208)
        Me.ugvPrecios.TabIndex = 0
        Me.ugvPrecios.Text = "UltraGrid1"
        '
        'txtNombreRubro
        '
        Me.txtNombreRubro.BindearPropiedadControl = ""
        Me.txtNombreRubro.BindearPropiedadEntidad = ""
        Me.txtNombreRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreRubro.ForeColor = System.Drawing.Color.Red
        Me.txtNombreRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreRubro.Formato = "##0"
        Me.txtNombreRubro.IsDecimal = False
        Me.txtNombreRubro.IsNumber = False
        Me.txtNombreRubro.IsPK = False
        Me.txtNombreRubro.IsRequired = False
        Me.txtNombreRubro.Key = ""
        Me.txtNombreRubro.LabelAsoc = Me.lblRubro
        Me.txtNombreRubro.Location = New System.Drawing.Point(62, 231)
        Me.txtNombreRubro.MaxLength = 100
        Me.txtNombreRubro.Name = "txtNombreRubro"
        Me.txtNombreRubro.ReadOnly = True
        Me.txtNombreRubro.Size = New System.Drawing.Size(390, 26)
        Me.txtNombreRubro.TabIndex = 6
        Me.txtNombreRubro.Visible = False
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(11, 234)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(47, 17)
        Me.lblRubro.TabIndex = 5
        Me.lblRubro.Text = "Rubro"
        Me.lblRubro.Visible = False
        '
        'txtNombreMarca
        '
        Me.txtNombreMarca.BindearPropiedadControl = ""
        Me.txtNombreMarca.BindearPropiedadEntidad = ""
        Me.txtNombreMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreMarca.ForeColor = System.Drawing.Color.Red
        Me.txtNombreMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreMarca.Formato = "##0"
        Me.txtNombreMarca.IsDecimal = False
        Me.txtNombreMarca.IsNumber = False
        Me.txtNombreMarca.IsPK = False
        Me.txtNombreMarca.IsRequired = False
        Me.txtNombreMarca.Key = ""
        Me.txtNombreMarca.LabelAsoc = Me.lblMarca
        Me.txtNombreMarca.Location = New System.Drawing.Point(62, 201)
        Me.txtNombreMarca.MaxLength = 100
        Me.txtNombreMarca.Name = "txtNombreMarca"
        Me.txtNombreMarca.ReadOnly = True
        Me.txtNombreMarca.Size = New System.Drawing.Size(390, 26)
        Me.txtNombreMarca.TabIndex = 4
        Me.txtNombreMarca.Visible = False
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.LabelAsoc = Nothing
        Me.lblMarca.Location = New System.Drawing.Point(11, 205)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(47, 17)
        Me.lblMarca.TabIndex = 3
        Me.lblMarca.Text = "Marca"
        Me.lblMarca.Visible = False
        '
        'txtNombreProducto
        '
        Me.txtNombreProducto.BindearPropiedadControl = ""
        Me.txtNombreProducto.BindearPropiedadEntidad = ""
        Me.txtNombreProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreProducto.ForeColor = System.Drawing.Color.Red
        Me.txtNombreProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreProducto.Formato = "##0"
        Me.txtNombreProducto.IsDecimal = False
        Me.txtNombreProducto.IsNumber = False
        Me.txtNombreProducto.IsPK = False
        Me.txtNombreProducto.IsRequired = False
        Me.txtNombreProducto.Key = ""
        Me.txtNombreProducto.LabelAsoc = Me.lblNombreProducto
        Me.txtNombreProducto.Location = New System.Drawing.Point(81, 16)
        Me.txtNombreProducto.MaxLength = 100
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.ReadOnly = True
        Me.txtNombreProducto.Size = New System.Drawing.Size(739, 26)
        Me.txtNombreProducto.TabIndex = 2
        '
        'lblNombreProducto
        '
        Me.lblNombreProducto.AutoSize = True
        Me.lblNombreProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreProducto.LabelAsoc = Nothing
        Me.lblNombreProducto.Location = New System.Drawing.Point(12, 19)
        Me.lblNombreProducto.Name = "lblNombreProducto"
        Me.lblNombreProducto.Size = New System.Drawing.Size(58, 17)
        Me.lblNombreProducto.TabIndex = 1
        Me.lblNombreProducto.Text = "Nombre"
        '
        'tpgStock
        '
        Me.tpgStock.BackColor = System.Drawing.SystemColors.Control
        Me.tpgStock.Controls.Add(Me.ugStockDepositos)
        Me.tpgStock.Controls.Add(Me.txtNombreProductoII)
        Me.tpgStock.Controls.Add(Me.Label2)
        Me.tpgStock.Location = New System.Drawing.Point(4, 22)
        Me.tpgStock.Name = "tpgStock"
        Me.tpgStock.Size = New System.Drawing.Size(840, 263)
        Me.tpgStock.TabIndex = 2
        Me.tpgStock.Text = "Stock x Deposito"
        '
        'ugStockDepositos
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugStockDepositos.DisplayLayout.Appearance = Appearance13
        Me.ugStockDepositos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 128
        UltraGridColumn2.Header.Caption = "Sucursal"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 113
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 146
        UltraGridColumn4.Header.Caption = "Deposito"
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 155
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 173
        UltraGridColumn6.Header.Caption = "Ubicacion"
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Width = 165
        Appearance14.TextHAlignAsString = "Center"
        Appearance14.TextVAlignAsString = "Middle"
        UltraGridColumn7.CellAppearance = Appearance14
        UltraGridColumn7.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn7.Header.VisiblePosition = 9
        UltraGridColumn7.Width = 132
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance15
        UltraGridColumn8.Header.Caption = "Cantidad"
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Width = 121
        UltraGridColumn40.Header.Caption = "Codigo Depósito"
        UltraGridColumn40.Header.VisiblePosition = 3
        UltraGridColumn40.Hidden = True
        UltraGridColumn40.Width = 110
        UltraGridColumn9.Header.Caption = "Tipo Deposito"
        UltraGridColumn9.Header.VisiblePosition = 5
        UltraGridColumn9.Width = 117
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn40, UltraGridColumn9})
        Me.ugStockDepositos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugStockDepositos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugStockDepositos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockDepositos.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockDepositos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
        Me.ugStockDepositos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance18.BackColor2 = System.Drawing.SystemColors.Control
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugStockDepositos.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
        Me.ugStockDepositos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugStockDepositos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugStockDepositos.DisplayLayout.Override.ActiveCellAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.SystemColors.Highlight
        Appearance20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugStockDepositos.DisplayLayout.Override.ActiveRowAppearance = Appearance20
        Me.ugStockDepositos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugStockDepositos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugStockDepositos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugStockDepositos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugStockDepositos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.ugStockDepositos.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugStockDepositos.DisplayLayout.Override.CellAppearance = Appearance22
        Me.ugStockDepositos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugStockDepositos.DisplayLayout.Override.CellPadding = 0
        Appearance23.BackColor = System.Drawing.SystemColors.Control
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugStockDepositos.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Appearance24.TextHAlignAsString = "Left"
        Me.ugStockDepositos.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.ugStockDepositos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugStockDepositos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.ugStockDepositos.DisplayLayout.Override.RowAppearance = Appearance25
        Me.ugStockDepositos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugStockDepositos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance26
        Me.ugStockDepositos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugStockDepositos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugStockDepositos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugStockDepositos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ugStockDepositos.Location = New System.Drawing.Point(19, 49)
        Me.ugStockDepositos.Name = "ugStockDepositos"
        Me.ugStockDepositos.Size = New System.Drawing.Size(805, 202)
        Me.ugStockDepositos.TabIndex = 12
        Me.ugStockDepositos.Text = "UltraGrid1"
        '
        'txtNombreProductoII
        '
        Me.txtNombreProductoII.BindearPropiedadControl = ""
        Me.txtNombreProductoII.BindearPropiedadEntidad = ""
        Me.txtNombreProductoII.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreProductoII.ForeColor = System.Drawing.Color.Red
        Me.txtNombreProductoII.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreProductoII.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreProductoII.Formato = "##0"
        Me.txtNombreProductoII.IsDecimal = False
        Me.txtNombreProductoII.IsNumber = False
        Me.txtNombreProductoII.IsPK = False
        Me.txtNombreProductoII.IsRequired = False
        Me.txtNombreProductoII.Key = ""
        Me.txtNombreProductoII.LabelAsoc = Me.Label2
        Me.txtNombreProductoII.Location = New System.Drawing.Point(85, 17)
        Me.txtNombreProductoII.MaxLength = 100
        Me.txtNombreProductoII.Name = "txtNombreProductoII"
        Me.txtNombreProductoII.ReadOnly = True
        Me.txtNombreProductoII.Size = New System.Drawing.Size(739, 26)
        Me.txtNombreProductoII.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(16, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 460)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(868, 22)
        Me.stsStado.TabIndex = 3
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(789, 17)
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
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(868, 29)
        Me.tstBarra.TabIndex = 2
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
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.txtCantidad)
        Me.grbConsultar.Controls.Add(Me.cmbTipoDeposito)
        Me.grbConsultar.Controls.Add(Me.lblTipoDeposito)
        Me.grbConsultar.Controls.Add(Me.bscProducto2)
        Me.grbConsultar.Controls.Add(Me.txtMoneda)
        Me.grbConsultar.Controls.Add(Me.lblMoneda)
        Me.grbConsultar.Controls.Add(Me.txtAlicuota)
        Me.grbConsultar.Controls.Add(Me.lblAlicuota)
        Me.grbConsultar.Controls.Add(Me.txtCodigoDeBarras)
        Me.grbConsultar.Controls.Add(Me.lblCodigoDeBarras)
        Me.grbConsultar.Controls.Add(Me.txtStock)
        Me.grbConsultar.Controls.Add(Me.lblStock)
        Me.grbConsultar.Controls.Add(Me.Label1)
        Me.grbConsultar.Controls.Add(Me.lblCodigo)
        Me.grbConsultar.Controls.Add(Me.txtCodigo)
        Me.grbConsultar.Controls.Add(Me.btnBuscar)
        Me.grbConsultar.Location = New System.Drawing.Point(8, 32)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(844, 127)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar Precios"
        '
        'txtCantidad
        '
        Me.txtCantidad.BindearPropiedadControl = ""
        Me.txtCantidad.BindearPropiedadEntidad = ""
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "##0.00"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Me.lblAlicuota
        Me.txtCantidad.Location = New System.Drawing.Point(733, 22)
        Me.txtCantidad.MaxLength = 13
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(61, 26)
        Me.txtCantidad.TabIndex = 15
        Me.txtCantidad.TabStop = False
        Me.txtCantidad.Text = "0.000"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCantidad.Visible = False
        '
        'cmbTipoDeposito
        '
        Me.cmbTipoDeposito.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoDeposito.BindearPropiedadEntidad = "TipoDeposito"
        Me.cmbTipoDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDeposito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDeposito.FormattingEnabled = True
        Me.cmbTipoDeposito.IsPK = False
        Me.cmbTipoDeposito.IsRequired = False
        Me.cmbTipoDeposito.Key = Nothing
        Me.cmbTipoDeposito.LabelAsoc = Me.lblTipoDeposito
        Me.cmbTipoDeposito.Location = New System.Drawing.Point(85, 97)
        Me.cmbTipoDeposito.Name = "cmbTipoDeposito"
        Me.cmbTipoDeposito.Size = New System.Drawing.Size(148, 21)
        Me.cmbTipoDeposito.TabIndex = 14
        '
        'lblTipoDeposito
        '
        Me.lblTipoDeposito.AutoSize = True
        Me.lblTipoDeposito.LabelAsoc = Nothing
        Me.lblTipoDeposito.Location = New System.Drawing.Point(29, 100)
        Me.lblTipoDeposito.Name = "lblTipoDeposito"
        Me.lblTipoDeposito.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoDeposito.TabIndex = 13
        Me.lblTipoDeposito.Text = "Tipo"
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(85, 71)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(326, 20)
        Me.bscProducto2.TabIndex = 3
        '
        'txtMoneda
        '
        Me.txtMoneda.BindearPropiedadControl = ""
        Me.txtMoneda.BindearPropiedadEntidad = ""
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.ForeColor = System.Drawing.Color.Red
        Me.txtMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMoneda.Formato = "##0.0"
        Me.txtMoneda.IsDecimal = False
        Me.txtMoneda.IsNumber = False
        Me.txtMoneda.IsPK = False
        Me.txtMoneda.IsRequired = False
        Me.txtMoneda.Key = ""
        Me.txtMoneda.LabelAsoc = Me.lblMoneda
        Me.txtMoneda.Location = New System.Drawing.Point(576, 54)
        Me.txtMoneda.MaxLength = 100
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(97, 26)
        Me.txtMoneda.TabIndex = 8
        Me.txtMoneda.TabStop = False
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.LabelAsoc = Nothing
        Me.lblMoneda.Location = New System.Drawing.Point(511, 59)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(59, 17)
        Me.lblMoneda.TabIndex = 7
        Me.lblMoneda.Text = "Moneda"
        '
        'txtAlicuota
        '
        Me.txtAlicuota.BindearPropiedadControl = ""
        Me.txtAlicuota.BindearPropiedadEntidad = ""
        Me.txtAlicuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlicuota.ForeColor = System.Drawing.Color.Red
        Me.txtAlicuota.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAlicuota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAlicuota.Formato = "##0.00"
        Me.txtAlicuota.IsDecimal = True
        Me.txtAlicuota.IsNumber = True
        Me.txtAlicuota.IsPK = False
        Me.txtAlicuota.IsRequired = False
        Me.txtAlicuota.Key = ""
        Me.txtAlicuota.LabelAsoc = Me.lblAlicuota
        Me.txtAlicuota.Location = New System.Drawing.Point(733, 54)
        Me.txtAlicuota.MaxLength = 13
        Me.txtAlicuota.Name = "txtAlicuota"
        Me.txtAlicuota.ReadOnly = True
        Me.txtAlicuota.Size = New System.Drawing.Size(61, 26)
        Me.txtAlicuota.TabIndex = 10
        Me.txtAlicuota.TabStop = False
        Me.txtAlicuota.Text = "0.00"
        Me.txtAlicuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCodigoDeBarras
        '
        Me.txtCodigoDeBarras.BindearPropiedadControl = ""
        Me.txtCodigoDeBarras.BindearPropiedadEntidad = ""
        Me.txtCodigoDeBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoDeBarras.ForeColor = System.Drawing.Color.Red
        Me.txtCodigoDeBarras.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoDeBarras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoDeBarras.Formato = "##0.0"
        Me.txtCodigoDeBarras.IsDecimal = False
        Me.txtCodigoDeBarras.IsNumber = False
        Me.txtCodigoDeBarras.IsPK = False
        Me.txtCodigoDeBarras.IsRequired = False
        Me.txtCodigoDeBarras.Key = ""
        Me.txtCodigoDeBarras.LabelAsoc = Me.lblCodigoDeBarras
        Me.txtCodigoDeBarras.Location = New System.Drawing.Point(576, 21)
        Me.txtCodigoDeBarras.MaxLength = 100
        Me.txtCodigoDeBarras.Name = "txtCodigoDeBarras"
        Me.txtCodigoDeBarras.ReadOnly = True
        Me.txtCodigoDeBarras.Size = New System.Drawing.Size(151, 26)
        Me.txtCodigoDeBarras.TabIndex = 6
        Me.txtCodigoDeBarras.TabStop = False
        Me.txtCodigoDeBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStock
        '
        Me.txtStock.BindearPropiedadControl = ""
        Me.txtStock.BindearPropiedadEntidad = ""
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.ForeColor = System.Drawing.Color.Red
        Me.txtStock.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStock.Formato = "##0.00"
        Me.txtStock.IsDecimal = True
        Me.txtStock.IsNumber = True
        Me.txtStock.IsPK = False
        Me.txtStock.IsRequired = False
        Me.txtStock.Key = ""
        Me.txtStock.LabelAsoc = Me.lblStock
        Me.txtStock.Location = New System.Drawing.Point(576, 85)
        Me.txtStock.MaxLength = 13
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(97, 26)
        Me.txtStock.TabIndex = 12
        Me.txtStock.TabStop = False
        Me.txtStock.Text = "0.00"
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.LabelAsoc = Nothing
        Me.lblStock.Location = New System.Drawing.Point(527, 91)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(43, 17)
        Me.lblStock.TabIndex = 11
        Me.lblStock.Text = "Stock"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(27, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(27, 42)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(52, 17)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BindearPropiedadControl = Nothing
        Me.txtCodigo.BindearPropiedadEntidad = Nothing
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigo.Formato = ""
        Me.txtCodigo.IsDecimal = False
        Me.txtCodigo.IsNumber = False
        Me.txtCodigo.IsPK = False
        Me.txtCodigo.IsRequired = False
        Me.txtCodigo.Key = ""
        Me.txtCodigo.LabelAsoc = Me.lblCodigo
        Me.txtCodigo.Location = New System.Drawing.Point(85, 39)
        Me.txtCodigo.MaxLength = 15
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(209, 26)
        Me.txtCodigo.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.Enabled = False
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(417, 76)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(88, 45)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        Me.btnBuscar.Visible = False
        '
        'ConsultarPreciosPorProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 482)
        Me.Controls.Add(Me.tbcPrecioProducto)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbConsultar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ConsultarPreciosPorProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Precios por Producto"
        CType(Me.UltraDataSource4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcPrecioProducto.ResumeLayout(False)
        Me.tpgLista.ResumeLayout(False)
        Me.tpgLista.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.picBoxProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tpgMultiple.ResumeLayout(False)
        Me.tpgMultiple.PerformLayout()
        CType(Me.ugvPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgStock.ResumeLayout(False)
        Me.tpgStock.PerformLayout()
        CType(Me.ugStockDepositos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As Eniac.Controles.Button
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCodigo As Eniac.Controles.Label
    Friend WithEvents txtCodigo As Eniac.Controles.TextBox
    Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtStock As Eniac.Controles.TextBox
    Friend WithEvents lblStock As Eniac.Controles.Label
    Friend WithEvents ugvPrecios As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
    Friend WithEvents lblNombreProducto As Eniac.Controles.Label
    Friend WithEvents txtCodigoDeBarras As Eniac.Controles.TextBox
    Friend WithEvents lblCodigoDeBarras As Eniac.Controles.Label
    Friend WithEvents txtNombreRubro As Eniac.Controles.TextBox
    Friend WithEvents lblRubro As Eniac.Controles.Label
    Friend WithEvents txtNombreMarca As Eniac.Controles.TextBox
    Friend WithEvents lblMarca As Eniac.Controles.Label
    Friend WithEvents txtMoneda As Eniac.Controles.TextBox
    Friend WithEvents lblMoneda As Eniac.Controles.Label
    Friend WithEvents txtAlicuota As Eniac.Controles.TextBox
    Friend WithEvents lblAlicuota As Eniac.Controles.Label
    Friend WithEvents tbcPrecioProducto As System.Windows.Forms.TabControl
    Friend WithEvents tpgMultiple As System.Windows.Forms.TabPage
    Friend WithEvents tpgLista As System.Windows.Forms.TabPage
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
    Friend WithEvents lblListaPrecios As Eniac.Controles.Label
    Friend WithEvents txtPrecio As Eniac.Controles.TextBox
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents txtFechaActProd As Eniac.Controles.TextBox
    Friend WithEvents LblFechaActProd As Eniac.Controles.Label
    Friend WithEvents picBoxProducto As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblOferta As Label
    Friend WithEvents tpgStock As TabPage
    Friend WithEvents txtNombreProductoII As Controles.TextBox
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents UltraDataSource1 As UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraDataSource2 As UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraDataSource3 As UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraDataSource4 As UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraDataSource5 As UltraWinDataSource.UltraDataSource
    Friend WithEvents cmbTipoDeposito As Controles.ComboBox
    Friend WithEvents lblTipoDeposito As Controles.Label
    Friend WithEvents ugStockDepositos As UltraGrid
    Friend WithEvents txtCantidad As Controles.TextBox
End Class
