<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SincronizacionSubida
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
      Me.tsbContinuar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.lblCantidadClientes = New Eniac.Controles.Label()
      Me.chbClientes = New Eniac.Controles.CheckBox()
      Me.chbProductos = New Eniac.Controles.CheckBox()
      Me.lblCantidadProductos = New Eniac.Controles.Label()
      Me.lblCantidadProductosSucursales = New Eniac.Controles.Label()
      Me.lblCantidadProductosSucursalesPrecios = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.lblFechaActualizacionDesde = New Eniac.Controles.Label()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.chbLocalidades = New Eniac.Controles.CheckBox()
      Me.dtpClientes = New Eniac.Controles.DateTimePicker()
      Me.chbTodosClientes = New Eniac.Controles.CheckBox()
      Me.chbRubros = New Eniac.Controles.CheckBox()
      Me.lblCantidadLocalidades = New Eniac.Controles.Label()
      Me.lblCantidadRubros = New Eniac.Controles.Label()
      Me.lblCantidadSubRubros = New Eniac.Controles.Label()
      Me.lblCantidadSubSubRubros = New Eniac.Controles.Label()
      Me.dtpProductos = New Eniac.Controles.DateTimePicker()
      Me.dtpProductosSucursales = New Eniac.Controles.DateTimePicker()
      Me.dtpProductosSucursalesPrecios = New Eniac.Controles.DateTimePicker()
      Me.dtpLocalidades = New Eniac.Controles.DateTimePicker()
      Me.dtpRubros = New Eniac.Controles.DateTimePicker()
      Me.dtpSubRubros = New Eniac.Controles.DateTimePicker()
      Me.dtpSubSubRubros = New Eniac.Controles.DateTimePicker()
      Me.chbTodosProductos = New Eniac.Controles.CheckBox()
      Me.chbTodosProductosSucursales = New Eniac.Controles.CheckBox()
      Me.chbTodosProductosSucursalesPrecios = New Eniac.Controles.CheckBox()
      Me.chbTodosLocalidades = New Eniac.Controles.CheckBox()
      Me.chbTodosRubros = New Eniac.Controles.CheckBox()
      Me.chbTodosSubRubros = New Eniac.Controles.CheckBox()
      Me.chbTodosSubSubRubros = New Eniac.Controles.CheckBox()
      Me.lblClientePaginaActual = New Eniac.Controles.Label()
      Me.lblClienteTotalPaginas = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Label4 = New Eniac.Controles.Label()
      Me.Label5 = New Eniac.Controles.Label()
      Me.Label6 = New Eniac.Controles.Label()
      Me.Label7 = New Eniac.Controles.Label()
      Me.Label8 = New Eniac.Controles.Label()
      Me.Label9 = New Eniac.Controles.Label()
      Me.lblProductosPaginaActual = New Eniac.Controles.Label()
      Me.lblProductosTotalPaginas = New Eniac.Controles.Label()
      Me.lblProductosSucursalesPaginaActual = New Eniac.Controles.Label()
      Me.lblProductosSucursalesTotalPaginas = New Eniac.Controles.Label()
      Me.lblProductosSucursalesPreciosPaginaActual = New Eniac.Controles.Label()
      Me.lblProductosSucursalesPreciosTotalPaginas = New Eniac.Controles.Label()
      Me.lblLocalidadesPaginaActual = New Eniac.Controles.Label()
      Me.lblLocalidadesTotalPaginas = New Eniac.Controles.Label()
      Me.lblRubrosPaginaActual = New Eniac.Controles.Label()
      Me.lblRubrosTotalPaginas = New Eniac.Controles.Label()
      Me.lblSubRubrosPaginaActual = New Eniac.Controles.Label()
      Me.lblSubRubrosTotalPaginas = New Eniac.Controles.Label()
      Me.lblSubSubRubrosPaginaActual = New Eniac.Controles.Label()
      Me.lblSubSubRubrosTotalPaginas = New Eniac.Controles.Label()
      Me.Label22 = New Eniac.Controles.Label()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.chbMarcas = New Eniac.Controles.CheckBox()
      Me.lblCantidadMarcas = New Eniac.Controles.Label()
      Me.dtpMarcas = New Eniac.Controles.DateTimePicker()
      Me.chbTodosMarcas = New Eniac.Controles.CheckBox()
      Me.lblMarcasPaginaActual = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.lblMarcasTotalPaginas = New Eniac.Controles.Label()
      Me.chbProveedores = New Eniac.Controles.CheckBox()
      Me.dtpProveedores = New Eniac.Controles.DateTimePicker()
      Me.chbTodosProveedores = New Eniac.Controles.CheckBox()
      Me.lblProveedoresPaginaActual = New Eniac.Controles.Label()
      Me.lblHashProv = New Eniac.Controles.Label()
      Me.chbRubrosCompras = New Eniac.Controles.CheckBox()
      Me.lblProveedoresTotalPaginas = New Eniac.Controles.Label()
      Me.lblCantidadProveedores = New Eniac.Controles.Label()
      Me.lblCantidadRubrosCompras = New Eniac.Controles.Label()
      Me.dtpRubrosCompras = New Eniac.Controles.DateTimePicker()
      Me.chbTodosRubrosCompras = New Eniac.Controles.CheckBox()
      Me.lblRubrosComprasPaginaActual = New Eniac.Controles.Label()
      Me.lblHashRuCom = New Eniac.Controles.Label()
      Me.lblRubrosComprasTotalPaginas = New Eniac.Controles.Label()
      Me.lblProductosPublicarEnWeb = New Eniac.Controles.Label()
      Me.cmbProductosPublicarEnWeb = New Eniac.Controles.ComboBox()
      Me.chbProductosIncluirImagenes = New Eniac.Controles.CheckBox()
      Me.lblProductosIncluirImagenes = New Eniac.Controles.Label()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbExportar, Me.tsbContinuar, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(774, 29)
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbExportar
        '
        Me.tsbExportar.Enabled = False
        Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(93, 26)
        Me.tsbExportar.Text = "&Subir Datos"
        Me.tsbExportar.ToolTipText = "Subir Datos"
        '
        'tsbContinuar
        '
        Me.tsbContinuar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
        Me.tsbContinuar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbContinuar.Name = "tsbContinuar"
        Me.tsbContinuar.Size = New System.Drawing.Size(86, 26)
        Me.tsbContinuar.Text = "&Continuar"
        Me.tsbContinuar.ToolTipText = "Continuar Subida de Datos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 418)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(774, 22)
        Me.stsStado.TabIndex = 7
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(695, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'lblCantidadClientes
        '
        Me.lblCantidadClientes.AutoSize = True
        Me.lblCantidadClientes.LabelAsoc = Nothing
        Me.lblCantidadClientes.Location = New System.Drawing.Point(113, 26)
        Me.lblCantidadClientes.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadClientes.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadClientes.Name = "lblCantidadClientes"
        Me.lblCantidadClientes.Size = New System.Drawing.Size(133, 17)
        Me.lblCantidadClientes.TabIndex = 18
        Me.lblCantidadClientes.Tag = "Se sincronizarán {0} clientes"
        Me.lblCantidadClientes.Text = "Se sincronizarán 0 clientes"
        Me.lblCantidadClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbClientes
        '
        Me.chbClientes.AutoSize = True
        Me.chbClientes.BindearPropiedadControl = Nothing
        Me.chbClientes.BindearPropiedadEntidad = Nothing
        Me.chbClientes.Enabled = False
        Me.chbClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbClientes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbClientes.IsPK = False
        Me.chbClientes.IsRequired = False
        Me.chbClientes.Key = Nothing
        Me.chbClientes.LabelAsoc = Nothing
        Me.chbClientes.Location = New System.Drawing.Point(3, 26)
        Me.chbClientes.Name = "chbClientes"
        Me.chbClientes.Size = New System.Drawing.Size(63, 17)
        Me.chbClientes.TabIndex = 17
        Me.chbClientes.Text = "Clientes"
        Me.chbClientes.UseVisualStyleBackColor = True
        '
        'chbProductos
        '
        Me.chbProductos.AutoSize = True
        Me.chbProductos.BindearPropiedadControl = Nothing
        Me.chbProductos.BindearPropiedadEntidad = Nothing
        Me.chbProductos.Enabled = False
        Me.chbProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductos.IsPK = False
        Me.chbProductos.IsRequired = False
        Me.chbProductos.Key = Nothing
        Me.chbProductos.LabelAsoc = Nothing
        Me.chbProductos.Location = New System.Drawing.Point(3, 52)
        Me.chbProductos.Name = "chbProductos"
        Me.chbProductos.Size = New System.Drawing.Size(74, 17)
        Me.chbProductos.TabIndex = 17
        Me.chbProductos.Text = "Productos"
        Me.chbProductos.UseVisualStyleBackColor = True
        '
        'lblCantidadProductos
        '
        Me.lblCantidadProductos.AutoSize = True
        Me.lblCantidadProductos.LabelAsoc = Nothing
        Me.lblCantidadProductos.Location = New System.Drawing.Point(113, 52)
        Me.lblCantidadProductos.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadProductos.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadProductos.Name = "lblCantidadProductos"
        Me.lblCantidadProductos.Size = New System.Drawing.Size(144, 17)
        Me.lblCantidadProductos.TabIndex = 18
        Me.lblCantidadProductos.Tag = "Se sincronizarán {0} productos"
        Me.lblCantidadProductos.Text = "Se sincronizarán 0 productos"
        Me.lblCantidadProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantidadProductosSucursales
        '
        Me.lblCantidadProductosSucursales.AutoSize = True
        Me.lblCantidadProductosSucursales.LabelAsoc = Nothing
        Me.lblCantidadProductosSucursales.Location = New System.Drawing.Point(113, 79)
        Me.lblCantidadProductosSucursales.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadProductosSucursales.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadProductosSucursales.Name = "lblCantidadProductosSucursales"
        Me.lblCantidadProductosSucursales.Size = New System.Drawing.Size(128, 17)
        Me.lblCantidadProductosSucursales.TabIndex = 18
        Me.lblCantidadProductosSucursales.Tag = "Se sincronizarán {0} stocks"
        Me.lblCantidadProductosSucursales.Text = "Se sincronizarán 0 stocks"
        Me.lblCantidadProductosSucursales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantidadProductosSucursalesPrecios
        '
        Me.lblCantidadProductosSucursalesPrecios.AutoSize = True
        Me.lblCantidadProductosSucursalesPrecios.LabelAsoc = Nothing
        Me.lblCantidadProductosSucursalesPrecios.Location = New System.Drawing.Point(113, 105)
        Me.lblCantidadProductosSucursalesPrecios.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadProductosSucursalesPrecios.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadProductosSucursalesPrecios.Name = "lblCantidadProductosSucursalesPrecios"
        Me.lblCantidadProductosSucursalesPrecios.Size = New System.Drawing.Size(131, 17)
        Me.lblCantidadProductosSucursalesPrecios.TabIndex = 18
        Me.lblCantidadProductosSucursalesPrecios.Tag = "Se sincronizarán {0} precios"
        Me.lblCantidadProductosSucursalesPrecios.Text = "Se sincronizarán 0 precios"
        Me.lblCantidadProductosSucursalesPrecios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(571, 41)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 19
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'lblFechaActualizacionDesde
        '
        Me.lblFechaActualizacionDesde.AutoSize = True
        Me.lblFechaActualizacionDesde.LabelAsoc = Nothing
        Me.lblFechaActualizacionDesde.Location = New System.Drawing.Point(288, 0)
        Me.lblFechaActualizacionDesde.Name = "lblFechaActualizacionDesde"
        Me.lblFechaActualizacionDesde.Size = New System.Drawing.Size(69, 13)
        Me.lblFechaActualizacionDesde.TabIndex = 20
        Me.lblFechaActualizacionDesde.Text = "&Fecha desde"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.chbLocalidades, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpClientes, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chbClientes, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosClientes, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFechaActualizacionDesde, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chbProductos, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadClientes, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadProductos, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadProductosSucursalesPrecios, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadProductosSucursales, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chbRubros, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadLocalidades, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadRubros, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadSubRubros, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadSubSubRubros, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpProductos, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpProductosSucursales, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpProductosSucursalesPrecios, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpLocalidades, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpRubros, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpSubRubros, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpSubSubRubros, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosProductos, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosProductosSucursales, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosProductosSucursalesPrecios, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosLocalidades, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosRubros, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosSubRubros, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosSubSubRubros, 3, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblClientePaginaActual, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblClienteTotalPaginas, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProductosPaginaActual, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProductosTotalPaginas, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProductosSucursalesPaginaActual, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProductosSucursalesTotalPaginas, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProductosSucursalesPreciosPaginaActual, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProductosSucursalesPreciosTotalPaginas, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLocalidadesPaginaActual, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLocalidadesTotalPaginas, 6, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRubrosPaginaActual, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRubrosTotalPaginas, 6, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSubRubrosPaginaActual, 4, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSubRubrosTotalPaginas, 6, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSubSubRubrosPaginaActual, 4, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSubSubRubrosTotalPaginas, 6, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label22, 5, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodos, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chbMarcas, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadMarcas, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpMarcas, 2, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosMarcas, 3, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMarcasPaginaActual, 4, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 5, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMarcasTotalPaginas, 6, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.chbProveedores, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpProveedores, 2, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosProveedores, 3, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProveedoresPaginaActual, 4, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHashProv, 5, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.chbRubrosCompras, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProveedoresTotalPaginas, 6, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadProveedores, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidadRubrosCompras, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpRubrosCompras, 2, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.chbTodosRubrosCompras, 3, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRubrosComprasPaginaActual, 4, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHashRuCom, 5, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRubrosComprasTotalPaginas, 6, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProductosPublicarEnWeb, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbProductosPublicarEnWeb, 8, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.chbProductosIncluirImagenes, 8, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProductosIncluirImagenes, 7, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 92)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 13
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(767, 323)
        Me.TableLayoutPanel1.TabIndex = 22
        '
        'chbLocalidades
        '
        Me.chbLocalidades.AutoSize = True
        Me.chbLocalidades.BindearPropiedadControl = Nothing
        Me.chbLocalidades.BindearPropiedadEntidad = Nothing
        Me.chbLocalidades.Enabled = False
        Me.chbLocalidades.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLocalidades.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLocalidades.IsPK = False
        Me.chbLocalidades.IsRequired = False
        Me.chbLocalidades.Key = Nothing
        Me.chbLocalidades.LabelAsoc = Nothing
        Me.chbLocalidades.Location = New System.Drawing.Point(3, 131)
        Me.chbLocalidades.Name = "chbLocalidades"
        Me.chbLocalidades.Size = New System.Drawing.Size(83, 17)
        Me.chbLocalidades.TabIndex = 23
        Me.chbLocalidades.Text = "Localidades"
        Me.chbLocalidades.UseVisualStyleBackColor = True
        '
        'dtpClientes
        '
        Me.dtpClientes.BindearPropiedadControl = Nothing
        Me.dtpClientes.BindearPropiedadEntidad = Nothing
        Me.dtpClientes.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpClientes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpClientes.IsPK = False
        Me.dtpClientes.IsRequired = False
        Me.dtpClientes.Key = ""
        Me.dtpClientes.LabelAsoc = Nothing
        Me.dtpClientes.Location = New System.Drawing.Point(288, 26)
        Me.dtpClientes.Name = "dtpClientes"
        Me.dtpClientes.Size = New System.Drawing.Size(143, 20)
        Me.dtpClientes.TabIndex = 21
        '
        'chbTodosClientes
        '
        Me.chbTodosClientes.AutoSize = True
        Me.chbTodosClientes.BindearPropiedadControl = Nothing
        Me.chbTodosClientes.BindearPropiedadEntidad = Nothing
        Me.chbTodosClientes.Checked = True
        Me.chbTodosClientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosClientes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosClientes.IsPK = False
        Me.chbTodosClientes.IsRequired = False
        Me.chbTodosClientes.Key = Nothing
        Me.chbTodosClientes.LabelAsoc = Nothing
        Me.chbTodosClientes.Location = New System.Drawing.Point(437, 26)
        Me.chbTodosClientes.Name = "chbTodosClientes"
        Me.chbTodosClientes.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosClientes.TabIndex = 17
        Me.chbTodosClientes.Text = "Reenviar todo"
        Me.chbTodosClientes.UseVisualStyleBackColor = True
        '
        'chbRubros
        '
        Me.chbRubros.AutoSize = True
        Me.chbRubros.BindearPropiedadControl = Nothing
        Me.chbRubros.BindearPropiedadEntidad = Nothing
        Me.chbRubros.Enabled = False
        Me.chbRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRubros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRubros.IsPK = False
        Me.chbRubros.IsRequired = False
        Me.chbRubros.Key = Nothing
        Me.chbRubros.LabelAsoc = Nothing
        Me.chbRubros.Location = New System.Drawing.Point(3, 157)
        Me.chbRubros.Name = "chbRubros"
        Me.chbRubros.Size = New System.Drawing.Size(60, 17)
        Me.chbRubros.TabIndex = 23
        Me.chbRubros.Text = "Rubros"
        Me.chbRubros.UseVisualStyleBackColor = True
        '
        'lblCantidadLocalidades
        '
        Me.lblCantidadLocalidades.AutoSize = True
        Me.lblCantidadLocalidades.LabelAsoc = Nothing
        Me.lblCantidadLocalidades.Location = New System.Drawing.Point(113, 131)
        Me.lblCantidadLocalidades.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadLocalidades.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadLocalidades.Name = "lblCantidadLocalidades"
        Me.lblCantidadLocalidades.Size = New System.Drawing.Size(150, 17)
        Me.lblCantidadLocalidades.TabIndex = 18
        Me.lblCantidadLocalidades.Tag = "Se sincronizarán {0} localidades"
        Me.lblCantidadLocalidades.Text = "Se sincronizarán 0 localidades"
        Me.lblCantidadLocalidades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantidadRubros
        '
        Me.lblCantidadRubros.AutoSize = True
        Me.lblCantidadRubros.LabelAsoc = Nothing
        Me.lblCantidadRubros.Location = New System.Drawing.Point(113, 157)
        Me.lblCantidadRubros.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadRubros.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadRubros.Name = "lblCantidadRubros"
        Me.lblCantidadRubros.Size = New System.Drawing.Size(126, 17)
        Me.lblCantidadRubros.TabIndex = 18
        Me.lblCantidadRubros.Tag = "Se sincronizarán {0} rubros"
        Me.lblCantidadRubros.Text = "Se sincronizarán 0 rubros"
        Me.lblCantidadRubros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantidadSubRubros
        '
        Me.lblCantidadSubRubros.AutoSize = True
        Me.lblCantidadSubRubros.LabelAsoc = Nothing
        Me.lblCantidadSubRubros.Location = New System.Drawing.Point(113, 183)
        Me.lblCantidadSubRubros.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadSubRubros.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadSubRubros.Name = "lblCantidadSubRubros"
        Me.lblCantidadSubRubros.Size = New System.Drawing.Size(146, 17)
        Me.lblCantidadSubRubros.TabIndex = 18
        Me.lblCantidadSubRubros.Tag = "Se sincronizarán {0} sub-rubros"
        Me.lblCantidadSubRubros.Text = "Se sincronizarán 0 sub-rubros"
        Me.lblCantidadSubRubros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantidadSubSubRubros
        '
        Me.lblCantidadSubSubRubros.AutoSize = True
        Me.lblCantidadSubSubRubros.LabelAsoc = Nothing
        Me.lblCantidadSubSubRubros.Location = New System.Drawing.Point(113, 209)
        Me.lblCantidadSubSubRubros.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadSubSubRubros.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadSubSubRubros.Name = "lblCantidadSubSubRubros"
        Me.lblCantidadSubSubRubros.Size = New System.Drawing.Size(166, 17)
        Me.lblCantidadSubSubRubros.TabIndex = 18
        Me.lblCantidadSubSubRubros.Tag = "Se sincronizarán {0} sub-sub-rubros"
        Me.lblCantidadSubSubRubros.Text = "Se sincronizarán 0 sub-sub-rubros"
        Me.lblCantidadSubSubRubros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpProductos
        '
        Me.dtpProductos.BindearPropiedadControl = Nothing
        Me.dtpProductos.BindearPropiedadEntidad = Nothing
        Me.dtpProductos.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpProductos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpProductos.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProductos.IsPK = False
        Me.dtpProductos.IsRequired = False
        Me.dtpProductos.Key = ""
        Me.dtpProductos.LabelAsoc = Nothing
        Me.dtpProductos.Location = New System.Drawing.Point(288, 52)
        Me.dtpProductos.Name = "dtpProductos"
        Me.dtpProductos.Size = New System.Drawing.Size(143, 20)
        Me.dtpProductos.TabIndex = 21
        '
        'dtpProductosSucursales
        '
        Me.dtpProductosSucursales.BindearPropiedadControl = Nothing
        Me.dtpProductosSucursales.BindearPropiedadEntidad = Nothing
        Me.dtpProductosSucursales.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpProductosSucursales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpProductosSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpProductosSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpProductosSucursales.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProductosSucursales.IsPK = False
        Me.dtpProductosSucursales.IsRequired = False
        Me.dtpProductosSucursales.Key = ""
        Me.dtpProductosSucursales.LabelAsoc = Nothing
        Me.dtpProductosSucursales.Location = New System.Drawing.Point(288, 79)
        Me.dtpProductosSucursales.Name = "dtpProductosSucursales"
        Me.dtpProductosSucursales.Size = New System.Drawing.Size(143, 20)
        Me.dtpProductosSucursales.TabIndex = 21
        '
        'dtpProductosSucursalesPrecios
        '
        Me.dtpProductosSucursalesPrecios.BindearPropiedadControl = Nothing
        Me.dtpProductosSucursalesPrecios.BindearPropiedadEntidad = Nothing
        Me.dtpProductosSucursalesPrecios.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpProductosSucursalesPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpProductosSucursalesPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpProductosSucursalesPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpProductosSucursalesPrecios.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProductosSucursalesPrecios.IsPK = False
        Me.dtpProductosSucursalesPrecios.IsRequired = False
        Me.dtpProductosSucursalesPrecios.Key = ""
        Me.dtpProductosSucursalesPrecios.LabelAsoc = Nothing
        Me.dtpProductosSucursalesPrecios.Location = New System.Drawing.Point(288, 105)
        Me.dtpProductosSucursalesPrecios.Name = "dtpProductosSucursalesPrecios"
        Me.dtpProductosSucursalesPrecios.Size = New System.Drawing.Size(143, 20)
        Me.dtpProductosSucursalesPrecios.TabIndex = 21
        '
        'dtpLocalidades
        '
        Me.dtpLocalidades.BindearPropiedadControl = Nothing
        Me.dtpLocalidades.BindearPropiedadEntidad = Nothing
        Me.dtpLocalidades.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpLocalidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLocalidades.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpLocalidades.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpLocalidades.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLocalidades.IsPK = False
        Me.dtpLocalidades.IsRequired = False
        Me.dtpLocalidades.Key = ""
        Me.dtpLocalidades.LabelAsoc = Nothing
        Me.dtpLocalidades.Location = New System.Drawing.Point(288, 131)
        Me.dtpLocalidades.Name = "dtpLocalidades"
        Me.dtpLocalidades.Size = New System.Drawing.Size(143, 20)
        Me.dtpLocalidades.TabIndex = 21
        '
        'dtpRubros
        '
        Me.dtpRubros.BindearPropiedadControl = Nothing
        Me.dtpRubros.BindearPropiedadEntidad = Nothing
        Me.dtpRubros.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpRubros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpRubros.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRubros.IsPK = False
        Me.dtpRubros.IsRequired = False
        Me.dtpRubros.Key = ""
        Me.dtpRubros.LabelAsoc = Nothing
        Me.dtpRubros.Location = New System.Drawing.Point(288, 157)
        Me.dtpRubros.Name = "dtpRubros"
        Me.dtpRubros.Size = New System.Drawing.Size(143, 20)
        Me.dtpRubros.TabIndex = 21
        '
        'dtpSubRubros
        '
        Me.dtpSubRubros.BindearPropiedadControl = Nothing
        Me.dtpSubRubros.BindearPropiedadEntidad = Nothing
        Me.dtpSubRubros.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpSubRubros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpSubRubros.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSubRubros.IsPK = False
        Me.dtpSubRubros.IsRequired = False
        Me.dtpSubRubros.Key = ""
        Me.dtpSubRubros.LabelAsoc = Nothing
        Me.dtpSubRubros.Location = New System.Drawing.Point(288, 183)
        Me.dtpSubRubros.Name = "dtpSubRubros"
        Me.dtpSubRubros.Size = New System.Drawing.Size(143, 20)
        Me.dtpSubRubros.TabIndex = 21
        '
        'dtpSubSubRubros
        '
        Me.dtpSubSubRubros.BindearPropiedadControl = Nothing
        Me.dtpSubSubRubros.BindearPropiedadEntidad = Nothing
        Me.dtpSubSubRubros.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpSubSubRubros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSubSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpSubSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpSubSubRubros.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSubSubRubros.IsPK = False
        Me.dtpSubSubRubros.IsRequired = False
        Me.dtpSubSubRubros.Key = ""
        Me.dtpSubSubRubros.LabelAsoc = Nothing
        Me.dtpSubSubRubros.Location = New System.Drawing.Point(288, 209)
        Me.dtpSubSubRubros.Name = "dtpSubSubRubros"
        Me.dtpSubSubRubros.Size = New System.Drawing.Size(143, 20)
        Me.dtpSubSubRubros.TabIndex = 21
        '
        'chbTodosProductos
        '
        Me.chbTodosProductos.AutoSize = True
        Me.chbTodosProductos.BindearPropiedadControl = Nothing
        Me.chbTodosProductos.BindearPropiedadEntidad = Nothing
        Me.chbTodosProductos.Checked = True
        Me.chbTodosProductos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosProductos.IsPK = False
        Me.chbTodosProductos.IsRequired = False
        Me.chbTodosProductos.Key = Nothing
        Me.chbTodosProductos.LabelAsoc = Nothing
        Me.chbTodosProductos.Location = New System.Drawing.Point(437, 52)
        Me.chbTodosProductos.Name = "chbTodosProductos"
        Me.chbTodosProductos.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosProductos.TabIndex = 17
        Me.chbTodosProductos.Text = "Reenviar todo"
        Me.chbTodosProductos.UseVisualStyleBackColor = True
        '
        'chbTodosProductosSucursales
        '
        Me.chbTodosProductosSucursales.AutoSize = True
        Me.chbTodosProductosSucursales.BindearPropiedadControl = Nothing
        Me.chbTodosProductosSucursales.BindearPropiedadEntidad = Nothing
        Me.chbTodosProductosSucursales.Checked = True
        Me.chbTodosProductosSucursales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosProductosSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosProductosSucursales.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosProductosSucursales.IsPK = False
        Me.chbTodosProductosSucursales.IsRequired = False
        Me.chbTodosProductosSucursales.Key = Nothing
        Me.chbTodosProductosSucursales.LabelAsoc = Nothing
        Me.chbTodosProductosSucursales.Location = New System.Drawing.Point(437, 79)
        Me.chbTodosProductosSucursales.Name = "chbTodosProductosSucursales"
        Me.chbTodosProductosSucursales.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosProductosSucursales.TabIndex = 17
        Me.chbTodosProductosSucursales.Text = "Reenviar todo"
        Me.chbTodosProductosSucursales.UseVisualStyleBackColor = True
        '
        'chbTodosProductosSucursalesPrecios
        '
        Me.chbTodosProductosSucursalesPrecios.AutoSize = True
        Me.chbTodosProductosSucursalesPrecios.BindearPropiedadControl = Nothing
        Me.chbTodosProductosSucursalesPrecios.BindearPropiedadEntidad = Nothing
        Me.chbTodosProductosSucursalesPrecios.Checked = True
        Me.chbTodosProductosSucursalesPrecios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosProductosSucursalesPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosProductosSucursalesPrecios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosProductosSucursalesPrecios.IsPK = False
        Me.chbTodosProductosSucursalesPrecios.IsRequired = False
        Me.chbTodosProductosSucursalesPrecios.Key = Nothing
        Me.chbTodosProductosSucursalesPrecios.LabelAsoc = Nothing
        Me.chbTodosProductosSucursalesPrecios.Location = New System.Drawing.Point(437, 105)
        Me.chbTodosProductosSucursalesPrecios.Name = "chbTodosProductosSucursalesPrecios"
        Me.chbTodosProductosSucursalesPrecios.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosProductosSucursalesPrecios.TabIndex = 17
        Me.chbTodosProductosSucursalesPrecios.Text = "Reenviar todo"
        Me.chbTodosProductosSucursalesPrecios.UseVisualStyleBackColor = True
        '
        'chbTodosLocalidades
        '
        Me.chbTodosLocalidades.AutoSize = True
        Me.chbTodosLocalidades.BindearPropiedadControl = Nothing
        Me.chbTodosLocalidades.BindearPropiedadEntidad = Nothing
        Me.chbTodosLocalidades.Checked = True
        Me.chbTodosLocalidades.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosLocalidades.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosLocalidades.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosLocalidades.IsPK = False
        Me.chbTodosLocalidades.IsRequired = False
        Me.chbTodosLocalidades.Key = Nothing
        Me.chbTodosLocalidades.LabelAsoc = Nothing
        Me.chbTodosLocalidades.Location = New System.Drawing.Point(437, 131)
        Me.chbTodosLocalidades.Name = "chbTodosLocalidades"
        Me.chbTodosLocalidades.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosLocalidades.TabIndex = 17
        Me.chbTodosLocalidades.Text = "Reenviar todo"
        Me.chbTodosLocalidades.UseVisualStyleBackColor = True
        '
        'chbTodosRubros
        '
        Me.chbTodosRubros.AutoSize = True
        Me.chbTodosRubros.BindearPropiedadControl = Nothing
        Me.chbTodosRubros.BindearPropiedadEntidad = Nothing
        Me.chbTodosRubros.Checked = True
        Me.chbTodosRubros.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosRubros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosRubros.IsPK = False
        Me.chbTodosRubros.IsRequired = False
        Me.chbTodosRubros.Key = Nothing
        Me.chbTodosRubros.LabelAsoc = Nothing
        Me.chbTodosRubros.Location = New System.Drawing.Point(437, 157)
        Me.chbTodosRubros.Name = "chbTodosRubros"
        Me.chbTodosRubros.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosRubros.TabIndex = 17
        Me.chbTodosRubros.Text = "Reenviar todo"
        Me.chbTodosRubros.UseVisualStyleBackColor = True
        '
        'chbTodosSubRubros
        '
        Me.chbTodosSubRubros.AutoSize = True
        Me.chbTodosSubRubros.BindearPropiedadControl = Nothing
        Me.chbTodosSubRubros.BindearPropiedadEntidad = Nothing
        Me.chbTodosSubRubros.Checked = True
        Me.chbTodosSubRubros.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosSubRubros.IsPK = False
        Me.chbTodosSubRubros.IsRequired = False
        Me.chbTodosSubRubros.Key = Nothing
        Me.chbTodosSubRubros.LabelAsoc = Nothing
        Me.chbTodosSubRubros.Location = New System.Drawing.Point(437, 183)
        Me.chbTodosSubRubros.Name = "chbTodosSubRubros"
        Me.chbTodosSubRubros.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosSubRubros.TabIndex = 17
        Me.chbTodosSubRubros.Text = "Reenviar todo"
        Me.chbTodosSubRubros.UseVisualStyleBackColor = True
        '
        'chbTodosSubSubRubros
        '
        Me.chbTodosSubSubRubros.AutoSize = True
        Me.chbTodosSubSubRubros.BindearPropiedadControl = Nothing
        Me.chbTodosSubSubRubros.BindearPropiedadEntidad = Nothing
        Me.chbTodosSubSubRubros.Checked = True
        Me.chbTodosSubSubRubros.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosSubSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosSubSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosSubSubRubros.IsPK = False
        Me.chbTodosSubSubRubros.IsRequired = False
        Me.chbTodosSubSubRubros.Key = Nothing
        Me.chbTodosSubSubRubros.LabelAsoc = Nothing
        Me.chbTodosSubSubRubros.Location = New System.Drawing.Point(437, 209)
        Me.chbTodosSubSubRubros.Name = "chbTodosSubSubRubros"
        Me.chbTodosSubSubRubros.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosSubSubRubros.TabIndex = 17
        Me.chbTodosSubSubRubros.Text = "Reenviar todo"
        Me.chbTodosSubSubRubros.UseVisualStyleBackColor = True
        '
        'lblClientePaginaActual
        '
        Me.lblClientePaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblClientePaginaActual.AutoSize = True
        Me.lblClientePaginaActual.LabelAsoc = Nothing
        Me.lblClientePaginaActual.Location = New System.Drawing.Point(538, 26)
        Me.lblClientePaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblClientePaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblClientePaginaActual.Name = "lblClientePaginaActual"
        Me.lblClientePaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblClientePaginaActual.TabIndex = 18
        Me.lblClientePaginaActual.Tag = ""
        Me.lblClientePaginaActual.Text = "0"
        Me.lblClientePaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClienteTotalPaginas
        '
        Me.lblClienteTotalPaginas.AutoSize = True
        Me.lblClienteTotalPaginas.LabelAsoc = Nothing
        Me.lblClienteTotalPaginas.Location = New System.Drawing.Point(563, 26)
        Me.lblClienteTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblClienteTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblClienteTotalPaginas.Name = "lblClienteTotalPaginas"
        Me.lblClienteTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblClienteTotalPaginas.TabIndex = 18
        Me.lblClienteTotalPaginas.Tag = ""
        Me.lblClienteTotalPaginas.Text = "0"
        Me.lblClienteTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(551, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label3.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Tag = ""
        Me.Label3.Text = "/"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(551, 52)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label4.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Tag = ""
        Me.Label4.Text = "/"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(551, 79)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label5.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 17)
        Me.Label5.TabIndex = 18
        Me.Label5.Tag = ""
        Me.Label5.Text = "/"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(551, 105)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label6.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Tag = ""
        Me.Label6.Text = "/"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(551, 131)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label7.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Tag = ""
        Me.Label7.Text = "/"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.LabelAsoc = Nothing
        Me.Label8.Location = New System.Drawing.Point(551, 157)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label8.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Tag = ""
        Me.Label8.Text = "/"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.LabelAsoc = Nothing
        Me.Label9.Location = New System.Drawing.Point(551, 183)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label9.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Tag = ""
        Me.Label9.Text = "/"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductosPaginaActual
        '
        Me.lblProductosPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProductosPaginaActual.AutoSize = True
        Me.lblProductosPaginaActual.LabelAsoc = Nothing
        Me.lblProductosPaginaActual.Location = New System.Drawing.Point(538, 52)
        Me.lblProductosPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblProductosPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProductosPaginaActual.Name = "lblProductosPaginaActual"
        Me.lblProductosPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblProductosPaginaActual.TabIndex = 18
        Me.lblProductosPaginaActual.Tag = ""
        Me.lblProductosPaginaActual.Text = "0"
        Me.lblProductosPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductosTotalPaginas
        '
        Me.lblProductosTotalPaginas.AutoSize = True
        Me.lblProductosTotalPaginas.LabelAsoc = Nothing
        Me.lblProductosTotalPaginas.Location = New System.Drawing.Point(563, 52)
        Me.lblProductosTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblProductosTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProductosTotalPaginas.Name = "lblProductosTotalPaginas"
        Me.lblProductosTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblProductosTotalPaginas.TabIndex = 18
        Me.lblProductosTotalPaginas.Tag = ""
        Me.lblProductosTotalPaginas.Text = "0"
        Me.lblProductosTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductosSucursalesPaginaActual
        '
        Me.lblProductosSucursalesPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProductosSucursalesPaginaActual.AutoSize = True
        Me.lblProductosSucursalesPaginaActual.LabelAsoc = Nothing
        Me.lblProductosSucursalesPaginaActual.Location = New System.Drawing.Point(538, 79)
        Me.lblProductosSucursalesPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblProductosSucursalesPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProductosSucursalesPaginaActual.Name = "lblProductosSucursalesPaginaActual"
        Me.lblProductosSucursalesPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblProductosSucursalesPaginaActual.TabIndex = 18
        Me.lblProductosSucursalesPaginaActual.Tag = ""
        Me.lblProductosSucursalesPaginaActual.Text = "0"
        Me.lblProductosSucursalesPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductosSucursalesTotalPaginas
        '
        Me.lblProductosSucursalesTotalPaginas.AutoSize = True
        Me.lblProductosSucursalesTotalPaginas.LabelAsoc = Nothing
        Me.lblProductosSucursalesTotalPaginas.Location = New System.Drawing.Point(563, 79)
        Me.lblProductosSucursalesTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblProductosSucursalesTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProductosSucursalesTotalPaginas.Name = "lblProductosSucursalesTotalPaginas"
        Me.lblProductosSucursalesTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblProductosSucursalesTotalPaginas.TabIndex = 18
        Me.lblProductosSucursalesTotalPaginas.Tag = ""
        Me.lblProductosSucursalesTotalPaginas.Text = "0"
        Me.lblProductosSucursalesTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductosSucursalesPreciosPaginaActual
        '
        Me.lblProductosSucursalesPreciosPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProductosSucursalesPreciosPaginaActual.AutoSize = True
        Me.lblProductosSucursalesPreciosPaginaActual.LabelAsoc = Nothing
        Me.lblProductosSucursalesPreciosPaginaActual.Location = New System.Drawing.Point(538, 105)
        Me.lblProductosSucursalesPreciosPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblProductosSucursalesPreciosPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProductosSucursalesPreciosPaginaActual.Name = "lblProductosSucursalesPreciosPaginaActual"
        Me.lblProductosSucursalesPreciosPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblProductosSucursalesPreciosPaginaActual.TabIndex = 18
        Me.lblProductosSucursalesPreciosPaginaActual.Tag = ""
        Me.lblProductosSucursalesPreciosPaginaActual.Text = "0"
        Me.lblProductosSucursalesPreciosPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductosSucursalesPreciosTotalPaginas
        '
        Me.lblProductosSucursalesPreciosTotalPaginas.AutoSize = True
        Me.lblProductosSucursalesPreciosTotalPaginas.LabelAsoc = Nothing
        Me.lblProductosSucursalesPreciosTotalPaginas.Location = New System.Drawing.Point(563, 105)
        Me.lblProductosSucursalesPreciosTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblProductosSucursalesPreciosTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProductosSucursalesPreciosTotalPaginas.Name = "lblProductosSucursalesPreciosTotalPaginas"
        Me.lblProductosSucursalesPreciosTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblProductosSucursalesPreciosTotalPaginas.TabIndex = 18
        Me.lblProductosSucursalesPreciosTotalPaginas.Tag = ""
        Me.lblProductosSucursalesPreciosTotalPaginas.Text = "0"
        Me.lblProductosSucursalesPreciosTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLocalidadesPaginaActual
        '
        Me.lblLocalidadesPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLocalidadesPaginaActual.AutoSize = True
        Me.lblLocalidadesPaginaActual.LabelAsoc = Nothing
        Me.lblLocalidadesPaginaActual.Location = New System.Drawing.Point(538, 131)
        Me.lblLocalidadesPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblLocalidadesPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblLocalidadesPaginaActual.Name = "lblLocalidadesPaginaActual"
        Me.lblLocalidadesPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblLocalidadesPaginaActual.TabIndex = 18
        Me.lblLocalidadesPaginaActual.Tag = ""
        Me.lblLocalidadesPaginaActual.Text = "0"
        Me.lblLocalidadesPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLocalidadesTotalPaginas
        '
        Me.lblLocalidadesTotalPaginas.AutoSize = True
        Me.lblLocalidadesTotalPaginas.LabelAsoc = Nothing
        Me.lblLocalidadesTotalPaginas.Location = New System.Drawing.Point(563, 131)
        Me.lblLocalidadesTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblLocalidadesTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblLocalidadesTotalPaginas.Name = "lblLocalidadesTotalPaginas"
        Me.lblLocalidadesTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblLocalidadesTotalPaginas.TabIndex = 18
        Me.lblLocalidadesTotalPaginas.Tag = ""
        Me.lblLocalidadesTotalPaginas.Text = "0"
        Me.lblLocalidadesTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRubrosPaginaActual
        '
        Me.lblRubrosPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRubrosPaginaActual.AutoSize = True
        Me.lblRubrosPaginaActual.LabelAsoc = Nothing
        Me.lblRubrosPaginaActual.Location = New System.Drawing.Point(538, 157)
        Me.lblRubrosPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblRubrosPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblRubrosPaginaActual.Name = "lblRubrosPaginaActual"
        Me.lblRubrosPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblRubrosPaginaActual.TabIndex = 18
        Me.lblRubrosPaginaActual.Tag = ""
        Me.lblRubrosPaginaActual.Text = "0"
        Me.lblRubrosPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRubrosTotalPaginas
        '
        Me.lblRubrosTotalPaginas.AutoSize = True
        Me.lblRubrosTotalPaginas.LabelAsoc = Nothing
        Me.lblRubrosTotalPaginas.Location = New System.Drawing.Point(563, 157)
        Me.lblRubrosTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblRubrosTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblRubrosTotalPaginas.Name = "lblRubrosTotalPaginas"
        Me.lblRubrosTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblRubrosTotalPaginas.TabIndex = 18
        Me.lblRubrosTotalPaginas.Tag = ""
        Me.lblRubrosTotalPaginas.Text = "0"
        Me.lblRubrosTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubRubrosPaginaActual
        '
        Me.lblSubRubrosPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubRubrosPaginaActual.AutoSize = True
        Me.lblSubRubrosPaginaActual.LabelAsoc = Nothing
        Me.lblSubRubrosPaginaActual.Location = New System.Drawing.Point(538, 183)
        Me.lblSubRubrosPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblSubRubrosPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblSubRubrosPaginaActual.Name = "lblSubRubrosPaginaActual"
        Me.lblSubRubrosPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblSubRubrosPaginaActual.TabIndex = 18
        Me.lblSubRubrosPaginaActual.Tag = ""
        Me.lblSubRubrosPaginaActual.Text = "0"
        Me.lblSubRubrosPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubRubrosTotalPaginas
        '
        Me.lblSubRubrosTotalPaginas.AutoSize = True
        Me.lblSubRubrosTotalPaginas.LabelAsoc = Nothing
        Me.lblSubRubrosTotalPaginas.Location = New System.Drawing.Point(563, 183)
        Me.lblSubRubrosTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblSubRubrosTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblSubRubrosTotalPaginas.Name = "lblSubRubrosTotalPaginas"
        Me.lblSubRubrosTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblSubRubrosTotalPaginas.TabIndex = 18
        Me.lblSubRubrosTotalPaginas.Tag = ""
        Me.lblSubRubrosTotalPaginas.Text = "0"
        Me.lblSubRubrosTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubSubRubrosPaginaActual
        '
        Me.lblSubSubRubrosPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubSubRubrosPaginaActual.AutoSize = True
        Me.lblSubSubRubrosPaginaActual.LabelAsoc = Nothing
        Me.lblSubSubRubrosPaginaActual.Location = New System.Drawing.Point(538, 209)
        Me.lblSubSubRubrosPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblSubSubRubrosPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblSubSubRubrosPaginaActual.Name = "lblSubSubRubrosPaginaActual"
        Me.lblSubSubRubrosPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblSubSubRubrosPaginaActual.TabIndex = 18
        Me.lblSubSubRubrosPaginaActual.Tag = ""
        Me.lblSubSubRubrosPaginaActual.Text = "0"
        Me.lblSubSubRubrosPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubSubRubrosTotalPaginas
        '
        Me.lblSubSubRubrosTotalPaginas.AutoSize = True
        Me.lblSubSubRubrosTotalPaginas.LabelAsoc = Nothing
        Me.lblSubSubRubrosTotalPaginas.Location = New System.Drawing.Point(563, 209)
        Me.lblSubSubRubrosTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblSubSubRubrosTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblSubSubRubrosTotalPaginas.Name = "lblSubSubRubrosTotalPaginas"
        Me.lblSubSubRubrosTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblSubSubRubrosTotalPaginas.TabIndex = 18
        Me.lblSubSubRubrosTotalPaginas.Tag = ""
        Me.lblSubSubRubrosTotalPaginas.Text = "0"
        Me.lblSubSubRubrosTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.LabelAsoc = Nothing
        Me.Label22.Location = New System.Drawing.Point(551, 209)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label22.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(12, 17)
        Me.Label22.TabIndex = 18
        Me.Label22.Tag = ""
        Me.Label22.Text = "/"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbTodos
        '
        Me.chbTodos.AutoSize = True
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(437, 3)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(98, 17)
        Me.chbTodos.TabIndex = 17
        Me.chbTodos.Text = "Reenviar todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'chbMarcas
        '
        Me.chbMarcas.AutoSize = True
        Me.chbMarcas.BindearPropiedadControl = Nothing
        Me.chbMarcas.BindearPropiedadEntidad = Nothing
        Me.chbMarcas.Enabled = False
        Me.chbMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarcas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarcas.IsPK = False
        Me.chbMarcas.IsRequired = False
        Me.chbMarcas.Key = Nothing
        Me.chbMarcas.LabelAsoc = Nothing
        Me.chbMarcas.Location = New System.Drawing.Point(3, 235)
        Me.chbMarcas.Name = "chbMarcas"
        Me.chbMarcas.Size = New System.Drawing.Size(61, 17)
        Me.chbMarcas.TabIndex = 23
        Me.chbMarcas.Text = "Marcas"
        Me.chbMarcas.UseVisualStyleBackColor = True
        '
        'lblCantidadMarcas
        '
        Me.lblCantidadMarcas.AutoSize = True
        Me.lblCantidadMarcas.LabelAsoc = Nothing
        Me.lblCantidadMarcas.Location = New System.Drawing.Point(113, 235)
        Me.lblCantidadMarcas.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadMarcas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadMarcas.Name = "lblCantidadMarcas"
        Me.lblCantidadMarcas.Size = New System.Drawing.Size(131, 17)
        Me.lblCantidadMarcas.TabIndex = 18
        Me.lblCantidadMarcas.Tag = "Se sincronizarán {0} marcas"
        Me.lblCantidadMarcas.Text = "Se sincronizarán 0 marcas"
        Me.lblCantidadMarcas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpMarcas
        '
        Me.dtpMarcas.BindearPropiedadControl = Nothing
        Me.dtpMarcas.BindearPropiedadEntidad = Nothing
        Me.dtpMarcas.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpMarcas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpMarcas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpMarcas.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMarcas.IsPK = False
        Me.dtpMarcas.IsRequired = False
        Me.dtpMarcas.Key = ""
        Me.dtpMarcas.LabelAsoc = Nothing
        Me.dtpMarcas.Location = New System.Drawing.Point(288, 235)
        Me.dtpMarcas.Name = "dtpMarcas"
        Me.dtpMarcas.Size = New System.Drawing.Size(143, 20)
        Me.dtpMarcas.TabIndex = 21
        Me.dtpMarcas.Visible = False
        '
        'chbTodosMarcas
        '
        Me.chbTodosMarcas.AutoSize = True
        Me.chbTodosMarcas.BindearPropiedadControl = Nothing
        Me.chbTodosMarcas.BindearPropiedadEntidad = Nothing
        Me.chbTodosMarcas.Checked = True
        Me.chbTodosMarcas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosMarcas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosMarcas.IsPK = False
        Me.chbTodosMarcas.IsRequired = False
        Me.chbTodosMarcas.Key = Nothing
        Me.chbTodosMarcas.LabelAsoc = Nothing
        Me.chbTodosMarcas.Location = New System.Drawing.Point(437, 235)
        Me.chbTodosMarcas.Name = "chbTodosMarcas"
        Me.chbTodosMarcas.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosMarcas.TabIndex = 17
        Me.chbTodosMarcas.Text = "Reenviar todo"
        Me.chbTodosMarcas.UseVisualStyleBackColor = True
        Me.chbTodosMarcas.Visible = False
        '
        'lblMarcasPaginaActual
        '
        Me.lblMarcasPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMarcasPaginaActual.AutoSize = True
        Me.lblMarcasPaginaActual.LabelAsoc = Nothing
        Me.lblMarcasPaginaActual.Location = New System.Drawing.Point(538, 235)
        Me.lblMarcasPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblMarcasPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblMarcasPaginaActual.Name = "lblMarcasPaginaActual"
        Me.lblMarcasPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblMarcasPaginaActual.TabIndex = 18
        Me.lblMarcasPaginaActual.Tag = ""
        Me.lblMarcasPaginaActual.Text = "0"
        Me.lblMarcasPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(551, 235)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Label2.MinimumSize = New System.Drawing.Size(0, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Tag = ""
        Me.Label2.Text = "/"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMarcasTotalPaginas
        '
        Me.lblMarcasTotalPaginas.AutoSize = True
        Me.lblMarcasTotalPaginas.LabelAsoc = Nothing
        Me.lblMarcasTotalPaginas.Location = New System.Drawing.Point(563, 235)
        Me.lblMarcasTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblMarcasTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblMarcasTotalPaginas.Name = "lblMarcasTotalPaginas"
        Me.lblMarcasTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblMarcasTotalPaginas.TabIndex = 18
        Me.lblMarcasTotalPaginas.Tag = ""
        Me.lblMarcasTotalPaginas.Text = "0"
        Me.lblMarcasTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbProveedores
        '
        Me.chbProveedores.AutoSize = True
        Me.chbProveedores.BindearPropiedadControl = Nothing
        Me.chbProveedores.BindearPropiedadEntidad = Nothing
        Me.chbProveedores.Enabled = False
        Me.chbProveedores.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedores.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedores.IsPK = False
        Me.chbProveedores.IsRequired = False
        Me.chbProveedores.Key = Nothing
        Me.chbProveedores.LabelAsoc = Nothing
        Me.chbProveedores.Location = New System.Drawing.Point(3, 287)
        Me.chbProveedores.Name = "chbProveedores"
        Me.chbProveedores.Size = New System.Drawing.Size(86, 17)
        Me.chbProveedores.TabIndex = 24
        Me.chbProveedores.Text = "Proveedores"
        Me.chbProveedores.UseVisualStyleBackColor = True
        '
        'dtpProveedores
        '
        Me.dtpProveedores.BindearPropiedadControl = Nothing
        Me.dtpProveedores.BindearPropiedadEntidad = Nothing
        Me.dtpProveedores.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpProveedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpProveedores.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpProveedores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpProveedores.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProveedores.IsPK = False
        Me.dtpProveedores.IsRequired = False
        Me.dtpProveedores.Key = ""
        Me.dtpProveedores.LabelAsoc = Nothing
        Me.dtpProveedores.Location = New System.Drawing.Point(288, 287)
        Me.dtpProveedores.Name = "dtpProveedores"
        Me.dtpProveedores.Size = New System.Drawing.Size(143, 20)
        Me.dtpProveedores.TabIndex = 21
        Me.dtpProveedores.Visible = False
        '
        'chbTodosProveedores
        '
        Me.chbTodosProveedores.AutoSize = True
        Me.chbTodosProveedores.BindearPropiedadControl = Nothing
        Me.chbTodosProveedores.BindearPropiedadEntidad = Nothing
        Me.chbTodosProveedores.Checked = True
        Me.chbTodosProveedores.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosProveedores.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosProveedores.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosProveedores.IsPK = False
        Me.chbTodosProveedores.IsRequired = False
        Me.chbTodosProveedores.Key = Nothing
        Me.chbTodosProveedores.LabelAsoc = Nothing
        Me.chbTodosProveedores.Location = New System.Drawing.Point(437, 287)
        Me.chbTodosProveedores.Name = "chbTodosProveedores"
        Me.chbTodosProveedores.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosProveedores.TabIndex = 17
        Me.chbTodosProveedores.Text = "Reenviar todo"
        Me.chbTodosProveedores.UseVisualStyleBackColor = True
        Me.chbTodosProveedores.Visible = False
        '
        'lblProveedoresPaginaActual
        '
        Me.lblProveedoresPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProveedoresPaginaActual.AutoSize = True
        Me.lblProveedoresPaginaActual.LabelAsoc = Nothing
        Me.lblProveedoresPaginaActual.Location = New System.Drawing.Point(538, 287)
        Me.lblProveedoresPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblProveedoresPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProveedoresPaginaActual.Name = "lblProveedoresPaginaActual"
        Me.lblProveedoresPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblProveedoresPaginaActual.TabIndex = 18
        Me.lblProveedoresPaginaActual.Tag = ""
        Me.lblProveedoresPaginaActual.Text = "0"
        Me.lblProveedoresPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHashProv
        '
        Me.lblHashProv.AutoSize = True
        Me.lblHashProv.LabelAsoc = Nothing
        Me.lblHashProv.Location = New System.Drawing.Point(551, 287)
        Me.lblHashProv.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblHashProv.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblHashProv.Name = "lblHashProv"
        Me.lblHashProv.Size = New System.Drawing.Size(12, 17)
        Me.lblHashProv.TabIndex = 18
        Me.lblHashProv.Tag = ""
        Me.lblHashProv.Text = "/"
        Me.lblHashProv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbRubrosCompras
        '
        Me.chbRubrosCompras.AutoSize = True
        Me.chbRubrosCompras.BindearPropiedadControl = Nothing
        Me.chbRubrosCompras.BindearPropiedadEntidad = Nothing
        Me.chbRubrosCompras.Enabled = False
        Me.chbRubrosCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRubrosCompras.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRubrosCompras.IsPK = False
        Me.chbRubrosCompras.IsRequired = False
        Me.chbRubrosCompras.Key = Nothing
        Me.chbRubrosCompras.LabelAsoc = Nothing
        Me.chbRubrosCompras.Location = New System.Drawing.Point(3, 261)
        Me.chbRubrosCompras.Name = "chbRubrosCompras"
        Me.chbRubrosCompras.Size = New System.Drawing.Size(104, 17)
        Me.chbRubrosCompras.TabIndex = 24
        Me.chbRubrosCompras.Text = "Rubros Compras"
        Me.chbRubrosCompras.UseVisualStyleBackColor = True
        '
        'lblProveedoresTotalPaginas
        '
        Me.lblProveedoresTotalPaginas.AutoSize = True
        Me.lblProveedoresTotalPaginas.LabelAsoc = Nothing
        Me.lblProveedoresTotalPaginas.Location = New System.Drawing.Point(563, 287)
        Me.lblProveedoresTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblProveedoresTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProveedoresTotalPaginas.Name = "lblProveedoresTotalPaginas"
        Me.lblProveedoresTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblProveedoresTotalPaginas.TabIndex = 18
        Me.lblProveedoresTotalPaginas.Tag = ""
        Me.lblProveedoresTotalPaginas.Text = "0"
        Me.lblProveedoresTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantidadProveedores
        '
        Me.lblCantidadProveedores.AutoSize = True
        Me.lblCantidadProveedores.LabelAsoc = Nothing
        Me.lblCantidadProveedores.Location = New System.Drawing.Point(113, 287)
        Me.lblCantidadProveedores.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadProveedores.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadProveedores.Name = "lblCantidadProveedores"
        Me.lblCantidadProveedores.Size = New System.Drawing.Size(156, 17)
        Me.lblCantidadProveedores.TabIndex = 18
        Me.lblCantidadProveedores.Tag = "Se sincronizarán {0} proveedores"
        Me.lblCantidadProveedores.Text = "Se sincronizarán 0 proveedores"
        Me.lblCantidadProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantidadRubrosCompras
        '
        Me.lblCantidadRubrosCompras.AutoSize = True
        Me.lblCantidadRubrosCompras.LabelAsoc = Nothing
        Me.lblCantidadRubrosCompras.Location = New System.Drawing.Point(113, 261)
        Me.lblCantidadRubrosCompras.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCantidadRubrosCompras.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblCantidadRubrosCompras.Name = "lblCantidadRubrosCompras"
        Me.lblCantidadRubrosCompras.Size = New System.Drawing.Size(169, 17)
        Me.lblCantidadRubrosCompras.TabIndex = 18
        Me.lblCantidadRubrosCompras.Tag = "Se sincronizarán {0} rubros compras"
        Me.lblCantidadRubrosCompras.Text = "Se sincronizarán 0 rubros compras"
        Me.lblCantidadRubrosCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpRubrosCompras
        '
        Me.dtpRubrosCompras.BindearPropiedadControl = Nothing
        Me.dtpRubrosCompras.BindearPropiedadEntidad = Nothing
        Me.dtpRubrosCompras.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpRubrosCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRubrosCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpRubrosCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpRubrosCompras.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRubrosCompras.IsPK = False
        Me.dtpRubrosCompras.IsRequired = False
        Me.dtpRubrosCompras.Key = ""
        Me.dtpRubrosCompras.LabelAsoc = Nothing
        Me.dtpRubrosCompras.Location = New System.Drawing.Point(288, 261)
        Me.dtpRubrosCompras.Name = "dtpRubrosCompras"
        Me.dtpRubrosCompras.Size = New System.Drawing.Size(143, 20)
        Me.dtpRubrosCompras.TabIndex = 21
        Me.dtpRubrosCompras.Visible = False
        '
        'chbTodosRubrosCompras
        '
        Me.chbTodosRubrosCompras.AutoSize = True
        Me.chbTodosRubrosCompras.BindearPropiedadControl = Nothing
        Me.chbTodosRubrosCompras.BindearPropiedadEntidad = Nothing
        Me.chbTodosRubrosCompras.Checked = True
        Me.chbTodosRubrosCompras.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTodosRubrosCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodosRubrosCompras.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodosRubrosCompras.IsPK = False
        Me.chbTodosRubrosCompras.IsRequired = False
        Me.chbTodosRubrosCompras.Key = Nothing
        Me.chbTodosRubrosCompras.LabelAsoc = Nothing
        Me.chbTodosRubrosCompras.Location = New System.Drawing.Point(437, 261)
        Me.chbTodosRubrosCompras.Name = "chbTodosRubrosCompras"
        Me.chbTodosRubrosCompras.Size = New System.Drawing.Size(93, 17)
        Me.chbTodosRubrosCompras.TabIndex = 17
        Me.chbTodosRubrosCompras.Text = "Reenviar todo"
        Me.chbTodosRubrosCompras.UseVisualStyleBackColor = True
        Me.chbTodosRubrosCompras.Visible = False
        '
        'lblRubrosComprasPaginaActual
        '
        Me.lblRubrosComprasPaginaActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRubrosComprasPaginaActual.AutoSize = True
        Me.lblRubrosComprasPaginaActual.LabelAsoc = Nothing
        Me.lblRubrosComprasPaginaActual.Location = New System.Drawing.Point(538, 261)
        Me.lblRubrosComprasPaginaActual.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblRubrosComprasPaginaActual.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblRubrosComprasPaginaActual.Name = "lblRubrosComprasPaginaActual"
        Me.lblRubrosComprasPaginaActual.Size = New System.Drawing.Size(13, 17)
        Me.lblRubrosComprasPaginaActual.TabIndex = 18
        Me.lblRubrosComprasPaginaActual.Tag = ""
        Me.lblRubrosComprasPaginaActual.Text = "0"
        Me.lblRubrosComprasPaginaActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHashRuCom
        '
        Me.lblHashRuCom.AutoSize = True
        Me.lblHashRuCom.LabelAsoc = Nothing
        Me.lblHashRuCom.Location = New System.Drawing.Point(551, 261)
        Me.lblHashRuCom.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblHashRuCom.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblHashRuCom.Name = "lblHashRuCom"
        Me.lblHashRuCom.Size = New System.Drawing.Size(12, 17)
        Me.lblHashRuCom.TabIndex = 18
        Me.lblHashRuCom.Tag = ""
        Me.lblHashRuCom.Text = "/"
        Me.lblHashRuCom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRubrosComprasTotalPaginas
        '
        Me.lblRubrosComprasTotalPaginas.AutoSize = True
        Me.lblRubrosComprasTotalPaginas.LabelAsoc = Nothing
        Me.lblRubrosComprasTotalPaginas.Location = New System.Drawing.Point(563, 261)
        Me.lblRubrosComprasTotalPaginas.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblRubrosComprasTotalPaginas.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblRubrosComprasTotalPaginas.Name = "lblRubrosComprasTotalPaginas"
        Me.lblRubrosComprasTotalPaginas.Size = New System.Drawing.Size(13, 17)
        Me.lblRubrosComprasTotalPaginas.TabIndex = 18
        Me.lblRubrosComprasTotalPaginas.Tag = ""
        Me.lblRubrosComprasTotalPaginas.Text = "0"
        Me.lblRubrosComprasTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductosPublicarEnWeb
        '
        Me.lblProductosPublicarEnWeb.AutoSize = True
        Me.lblProductosPublicarEnWeb.LabelAsoc = Nothing
        Me.lblProductosPublicarEnWeb.Location = New System.Drawing.Point(579, 52)
        Me.lblProductosPublicarEnWeb.Margin = New System.Windows.Forms.Padding(3)
        Me.lblProductosPublicarEnWeb.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProductosPublicarEnWeb.Name = "lblProductosPublicarEnWeb"
        Me.lblProductosPublicarEnWeb.Size = New System.Drawing.Size(86, 17)
        Me.lblProductosPublicarEnWeb.TabIndex = 18
        Me.lblProductosPublicarEnWeb.Tag = ""
        Me.lblProductosPublicarEnWeb.Text = "Publicar en Web"
        Me.lblProductosPublicarEnWeb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbProductosPublicarEnWeb
        '
        Me.cmbProductosPublicarEnWeb.BindearPropiedadControl = Nothing
        Me.cmbProductosPublicarEnWeb.BindearPropiedadEntidad = Nothing
        Me.cmbProductosPublicarEnWeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProductosPublicarEnWeb.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProductosPublicarEnWeb.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProductosPublicarEnWeb.FormattingEnabled = True
        Me.cmbProductosPublicarEnWeb.IsPK = False
        Me.cmbProductosPublicarEnWeb.IsRequired = False
        Me.cmbProductosPublicarEnWeb.Key = Nothing
        Me.cmbProductosPublicarEnWeb.LabelAsoc = Me.lblProductosPublicarEnWeb
        Me.cmbProductosPublicarEnWeb.Location = New System.Drawing.Point(671, 52)
        Me.cmbProductosPublicarEnWeb.Name = "cmbProductosPublicarEnWeb"
        Me.cmbProductosPublicarEnWeb.Size = New System.Drawing.Size(73, 21)
        Me.cmbProductosPublicarEnWeb.TabIndex = 25
        '
        'chbProductosIncluirImagenes
        '
        Me.chbProductosIncluirImagenes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chbProductosIncluirImagenes.AutoSize = True
        Me.chbProductosIncluirImagenes.BindearPropiedadControl = Nothing
        Me.chbProductosIncluirImagenes.BindearPropiedadEntidad = Nothing
        Me.chbProductosIncluirImagenes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductosIncluirImagenes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductosIncluirImagenes.IsPK = False
        Me.chbProductosIncluirImagenes.IsRequired = False
        Me.chbProductosIncluirImagenes.Key = Nothing
        Me.chbProductosIncluirImagenes.LabelAsoc = Me.lblProductosIncluirImagenes
        Me.chbProductosIncluirImagenes.Location = New System.Drawing.Point(671, 82)
        Me.chbProductosIncluirImagenes.Name = "chbProductosIncluirImagenes"
        Me.chbProductosIncluirImagenes.Size = New System.Drawing.Size(15, 14)
        Me.chbProductosIncluirImagenes.TabIndex = 17
        Me.chbProductosIncluirImagenes.UseVisualStyleBackColor = True
        '
        'lblProductosIncluirImagenes
        '
        Me.lblProductosIncluirImagenes.AutoSize = True
        Me.lblProductosIncluirImagenes.LabelAsoc = Nothing
        Me.lblProductosIncluirImagenes.Location = New System.Drawing.Point(579, 79)
        Me.lblProductosIncluirImagenes.Margin = New System.Windows.Forms.Padding(3)
        Me.lblProductosIncluirImagenes.MinimumSize = New System.Drawing.Size(0, 17)
        Me.lblProductosIncluirImagenes.Name = "lblProductosIncluirImagenes"
        Me.lblProductosIncluirImagenes.Size = New System.Drawing.Size(84, 17)
        Me.lblProductosIncluirImagenes.TabIndex = 26
        Me.lblProductosIncluirImagenes.Tag = ""
        Me.lblProductosIncluirImagenes.Text = "Incluir Imagenes"
        Me.lblProductosIncluirImagenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SincronizacionSubida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 440)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "SincronizacionSubida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sincronización - Subir a la Web"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblCantidadClientes As Eniac.Controles.Label
   Friend WithEvents chbClientes As Eniac.Controles.CheckBox
   Friend WithEvents chbProductos As Eniac.Controles.CheckBox
   Friend WithEvents lblCantidadProductos As Eniac.Controles.Label
   Friend WithEvents lblCantidadProductosSucursales As Eniac.Controles.Label
   Friend WithEvents lblCantidadProductosSucursalesPrecios As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents lblFechaActualizacionDesde As Eniac.Controles.Label
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents chbLocalidades As Eniac.Controles.CheckBox
   Friend WithEvents chbRubros As Eniac.Controles.CheckBox
   Friend WithEvents lblCantidadLocalidades As Eniac.Controles.Label
   Friend WithEvents lblCantidadRubros As Eniac.Controles.Label
   Friend WithEvents lblCantidadSubRubros As Eniac.Controles.Label
   Friend WithEvents lblCantidadSubSubRubros As Eniac.Controles.Label
   Friend WithEvents dtpClientes As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpProductos As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpProductosSucursales As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpProductosSucursalesPrecios As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpLocalidades As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpRubros As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpSubRubros As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpSubSubRubros As Eniac.Controles.DateTimePicker
   Friend WithEvents chbTodosClientes As Eniac.Controles.CheckBox
   Friend WithEvents chbTodosProductos As Eniac.Controles.CheckBox
   Friend WithEvents chbTodosProductosSucursales As Eniac.Controles.CheckBox
   Friend WithEvents chbTodosProductosSucursalesPrecios As Eniac.Controles.CheckBox
   Friend WithEvents chbTodosLocalidades As Eniac.Controles.CheckBox
   Friend WithEvents chbTodosRubros As Eniac.Controles.CheckBox
   Friend WithEvents chbTodosSubRubros As Eniac.Controles.CheckBox
   Friend WithEvents chbTodosSubSubRubros As Eniac.Controles.CheckBox
   Friend WithEvents lblClientePaginaActual As Eniac.Controles.Label
   Friend WithEvents lblClienteTotalPaginas As Eniac.Controles.Label
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents Label6 As Eniac.Controles.Label
   Friend WithEvents Label7 As Eniac.Controles.Label
   Friend WithEvents Label8 As Eniac.Controles.Label
   Friend WithEvents Label9 As Eniac.Controles.Label
   Friend WithEvents lblProductosPaginaActual As Eniac.Controles.Label
   Friend WithEvents lblProductosTotalPaginas As Eniac.Controles.Label
   Friend WithEvents lblProductosSucursalesPaginaActual As Eniac.Controles.Label
   Friend WithEvents lblProductosSucursalesTotalPaginas As Eniac.Controles.Label
   Friend WithEvents lblProductosSucursalesPreciosPaginaActual As Eniac.Controles.Label
   Friend WithEvents lblProductosSucursalesPreciosTotalPaginas As Eniac.Controles.Label
   Friend WithEvents lblLocalidadesPaginaActual As Eniac.Controles.Label
   Friend WithEvents lblLocalidadesTotalPaginas As Eniac.Controles.Label
   Friend WithEvents lblRubrosPaginaActual As Eniac.Controles.Label
   Friend WithEvents lblRubrosTotalPaginas As Eniac.Controles.Label
   Friend WithEvents lblSubRubrosPaginaActual As Eniac.Controles.Label
   Friend WithEvents lblSubRubrosTotalPaginas As Eniac.Controles.Label
   Friend WithEvents lblSubSubRubrosPaginaActual As Eniac.Controles.Label
   Friend WithEvents lblSubSubRubrosTotalPaginas As Eniac.Controles.Label
   Friend WithEvents Label22 As Eniac.Controles.Label
   Friend WithEvents tsbContinuar As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents chbMarcas As Eniac.Controles.CheckBox
   Friend WithEvents lblCantidadMarcas As Eniac.Controles.Label
   Friend WithEvents dtpMarcas As Eniac.Controles.DateTimePicker
   Friend WithEvents chbTodosMarcas As Eniac.Controles.CheckBox
   Friend WithEvents lblMarcasPaginaActual As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents lblMarcasTotalPaginas As Eniac.Controles.Label
   Friend WithEvents chbProveedores As Eniac.Controles.CheckBox
   Friend WithEvents lblCantidadProveedores As Eniac.Controles.Label
   Friend WithEvents dtpProveedores As Eniac.Controles.DateTimePicker
   Friend WithEvents chbTodosProveedores As Eniac.Controles.CheckBox
   Friend WithEvents lblProveedoresPaginaActual As Eniac.Controles.Label
   Friend WithEvents lblHashProv As Eniac.Controles.Label
   Friend WithEvents lblProveedoresTotalPaginas As Eniac.Controles.Label
   Friend WithEvents chbRubrosCompras As Eniac.Controles.CheckBox
   Friend WithEvents lblCantidadRubrosCompras As Eniac.Controles.Label
   Friend WithEvents dtpRubrosCompras As Eniac.Controles.DateTimePicker
   Friend WithEvents chbTodosRubrosCompras As Eniac.Controles.CheckBox
   Friend WithEvents lblRubrosComprasPaginaActual As Eniac.Controles.Label
   Friend WithEvents lblHashRuCom As Eniac.Controles.Label
   Friend WithEvents lblRubrosComprasTotalPaginas As Eniac.Controles.Label
   Friend WithEvents lblProductosPublicarEnWeb As Eniac.Controles.Label
   Friend WithEvents cmbProductosPublicarEnWeb As Eniac.Controles.ComboBox
   Friend WithEvents chbProductosIncluirImagenes As Eniac.Controles.CheckBox
   Friend WithEvents lblProductosIncluirImagenes As Eniac.Controles.Label
End Class
