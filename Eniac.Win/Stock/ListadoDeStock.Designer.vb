<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoDeStock
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.chbEmbalaje = New Eniac.Controles.CheckBox()
        Me.cmbSubSubRubro_M = New Eniac.Win.ComboBoxSubSubRubro()
        Me.lblSubSubRubro = New Eniac.Controles.Label()
        Me.grpOrden = New System.Windows.Forms.GroupBox()
        Me.optAlfabetico = New System.Windows.Forms.RadioButton()
        Me.optPorMarca = New System.Windows.Forms.RadioButton()
        Me.optPorRubro = New System.Windows.Forms.RadioButton()
        Me.optPorSubRubro = New System.Windows.Forms.RadioButton()
        Me.cmbSubRubro_M = New Eniac.Win.ComboBoxSubRubro()
        Me.lblSubRubro = New Eniac.Controles.Label()
        Me.cmbRubro_M = New Eniac.Win.ComboBoxRubro()
        Me.lblRubro = New Eniac.Controles.Label()
        Me.cmbMarca_M = New Eniac.Win.ComboBoxMarcas()
        Me.lblMarca = New Eniac.Controles.Label()
        Me.chbProveedorHabitual = New Eniac.Controles.CheckBox()
        Me.lblNombreProv = New Eniac.Controles.Label()
        Me.lblCodigoProveedor = New Eniac.Controles.Label()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.grbPrecio = New System.Windows.Forms.GroupBox()
        Me.rdbNinguno = New Eniac.Controles.RadioButton()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.rdbPrecioDeCosto = New Eniac.Controles.RadioButton()
        Me.rdbPrecioDeVenta = New Eniac.Controles.RadioButton()
        Me.cmbTipoInforme = New Eniac.Controles.ComboBox()
        Me.lblTipoInforme = New System.Windows.Forms.Label()
        Me.btnImprimir = New Eniac.Controles.Button()
        Me.bscProveedor = New Eniac.Controles.Buscador2()
        Me.tstBarra.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        Me.grpOrden.SuspendLayout()
        Me.grbPrecio.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(505, 29)
        Me.tstBarra.TabIndex = 1
        Me.tstBarra.Text = "toolStrip1"
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
        Me.grbConsultar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbConsultar.Controls.Add(Me.bscProveedor)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
        Me.grbConsultar.Controls.Add(Me.chbEmbalaje)
        Me.grbConsultar.Controls.Add(Me.cmbSubSubRubro_M)
        Me.grbConsultar.Controls.Add(Me.lblSubSubRubro)
        Me.grbConsultar.Controls.Add(Me.grpOrden)
        Me.grbConsultar.Controls.Add(Me.cmbSubRubro_M)
        Me.grbConsultar.Controls.Add(Me.cmbRubro_M)
        Me.grbConsultar.Controls.Add(Me.cmbMarca_M)
        Me.grbConsultar.Controls.Add(Me.chbProveedorHabitual)
        Me.grbConsultar.Controls.Add(Me.lblCodigoProveedor)
        Me.grbConsultar.Controls.Add(Me.lblNombreProv)
        Me.grbConsultar.Controls.Add(Me.chbProveedor)
        Me.grbConsultar.Controls.Add(Me.grbPrecio)
        Me.grbConsultar.Controls.Add(Me.lblSubRubro)
        Me.grbConsultar.Controls.Add(Me.cmbTipoInforme)
        Me.grbConsultar.Controls.Add(Me.lblTipoInforme)
        Me.grbConsultar.Controls.Add(Me.btnImprimir)
        Me.grbConsultar.Controls.Add(Me.lblRubro)
        Me.grbConsultar.Controls.Add(Me.lblMarca)
        Me.grbConsultar.Location = New System.Drawing.Point(8, 33)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(493, 389)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.Enabled = False
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Nothing
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(86, 284)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoProveedor.TabIndex = 14
        '
        'chbEmbalaje
        '
        Me.chbEmbalaje.AutoSize = True
        Me.chbEmbalaje.BindearPropiedadControl = Nothing
        Me.chbEmbalaje.BindearPropiedadEntidad = Nothing
        Me.chbEmbalaje.Enabled = False
        Me.chbEmbalaje.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmbalaje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmbalaje.IsPK = False
        Me.chbEmbalaje.IsRequired = False
        Me.chbEmbalaje.Key = Nothing
        Me.chbEmbalaje.LabelAsoc = Nothing
        Me.chbEmbalaje.Location = New System.Drawing.Point(159, 317)
        Me.chbEmbalaje.Name = "chbEmbalaje"
        Me.chbEmbalaje.Size = New System.Drawing.Size(220, 17)
        Me.chbEmbalaje.TabIndex = 18
        Me.chbEmbalaje.Text = "Mostrar Código del Proveedor y Embalaje"
        Me.chbEmbalaje.UseVisualStyleBackColor = True
        '
        'cmbSubSubRubro_M
        '
        Me.cmbSubSubRubro_M.BindearPropiedadControl = Nothing
        Me.cmbSubSubRubro_M.BindearPropiedadEntidad = Nothing
        Me.cmbSubSubRubro_M.ConcatenarNombreSubRubro = False
        Me.cmbSubSubRubro_M.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubSubRubro_M.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubSubRubro_M.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubSubRubro_M.FormattingEnabled = True
        Me.cmbSubSubRubro_M.IsPK = False
        Me.cmbSubSubRubro_M.IsRequired = False
        Me.cmbSubSubRubro_M.Key = Nothing
        Me.cmbSubSubRubro_M.LabelAsoc = Me.lblSubSubRubro
        Me.cmbSubSubRubro_M.Location = New System.Drawing.Point(92, 102)
        Me.cmbSubSubRubro_M.Name = "cmbSubSubRubro_M"
        Me.cmbSubSubRubro_M.Size = New System.Drawing.Size(301, 21)
        Me.cmbSubSubRubro_M.TabIndex = 7
        '
        'lblSubSubRubro
        '
        Me.lblSubSubRubro.AutoSize = True
        Me.lblSubSubRubro.LabelAsoc = Nothing
        Me.lblSubSubRubro.Location = New System.Drawing.Point(12, 105)
        Me.lblSubSubRubro.Name = "lblSubSubRubro"
        Me.lblSubSubRubro.Size = New System.Drawing.Size(74, 13)
        Me.lblSubSubRubro.TabIndex = 6
        Me.lblSubSubRubro.Text = "SubSubRubro"
        '
        'grpOrden
        '
        Me.grpOrden.Controls.Add(Me.optAlfabetico)
        Me.grpOrden.Controls.Add(Me.optPorMarca)
        Me.grpOrden.Controls.Add(Me.optPorRubro)
        Me.grpOrden.Controls.Add(Me.optPorSubRubro)
        Me.grpOrden.Location = New System.Drawing.Point(12, 153)
        Me.grpOrden.Name = "grpOrden"
        Me.grpOrden.Size = New System.Drawing.Size(455, 51)
        Me.grpOrden.TabIndex = 10
        Me.grpOrden.TabStop = False
        Me.grpOrden.Text = "Ordenado por..."
        '
        'optAlfabetico
        '
        Me.optAlfabetico.AutoSize = True
        Me.optAlfabetico.Checked = True
        Me.optAlfabetico.Location = New System.Drawing.Point(6, 21)
        Me.optAlfabetico.Name = "optAlfabetico"
        Me.optAlfabetico.Size = New System.Drawing.Size(72, 17)
        Me.optAlfabetico.TabIndex = 0
        Me.optAlfabetico.TabStop = True
        Me.optAlfabetico.Text = "Alfabético"
        Me.optAlfabetico.UseVisualStyleBackColor = True
        '
        'optPorMarca
        '
        Me.optPorMarca.AutoSize = True
        Me.optPorMarca.Location = New System.Drawing.Point(103, 21)
        Me.optPorMarca.Name = "optPorMarca"
        Me.optPorMarca.Size = New System.Drawing.Size(74, 17)
        Me.optPorMarca.TabIndex = 1
        Me.optPorMarca.Text = "Por Marca"
        Me.optPorMarca.UseVisualStyleBackColor = True
        '
        'optPorRubro
        '
        Me.optPorRubro.AutoSize = True
        Me.optPorRubro.Location = New System.Drawing.Point(183, 21)
        Me.optPorRubro.Name = "optPorRubro"
        Me.optPorRubro.Size = New System.Drawing.Size(73, 17)
        Me.optPorRubro.TabIndex = 2
        Me.optPorRubro.Text = "Por Rubro"
        Me.optPorRubro.UseVisualStyleBackColor = True
        '
        'optPorSubRubro
        '
        Me.optPorSubRubro.AutoSize = True
        Me.optPorSubRubro.Location = New System.Drawing.Point(262, 21)
        Me.optPorSubRubro.Name = "optPorSubRubro"
        Me.optPorSubRubro.Size = New System.Drawing.Size(92, 17)
        Me.optPorSubRubro.TabIndex = 3
        Me.optPorSubRubro.Text = "Por SubRubro"
        Me.optPorSubRubro.UseVisualStyleBackColor = True
        '
        'cmbSubRubro_M
        '
        Me.cmbSubRubro_M.BindearPropiedadControl = Nothing
        Me.cmbSubRubro_M.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubro_M.ConcatenarNombreRubro = False
        Me.cmbSubRubro_M.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubro_M.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubro_M.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubro_M.FormattingEnabled = True
        Me.cmbSubRubro_M.IsPK = False
        Me.cmbSubRubro_M.IsRequired = False
        Me.cmbSubRubro_M.Key = Nothing
        Me.cmbSubRubro_M.LabelAsoc = Me.lblSubRubro
        Me.cmbSubRubro_M.Location = New System.Drawing.Point(92, 75)
        Me.cmbSubRubro_M.Name = "cmbSubRubro_M"
        Me.cmbSubRubro_M.Size = New System.Drawing.Size(301, 21)
        Me.cmbSubRubro_M.TabIndex = 5
        '
        'lblSubRubro
        '
        Me.lblSubRubro.AutoSize = True
        Me.lblSubRubro.LabelAsoc = Nothing
        Me.lblSubRubro.Location = New System.Drawing.Point(12, 78)
        Me.lblSubRubro.Name = "lblSubRubro"
        Me.lblSubRubro.Size = New System.Drawing.Size(55, 13)
        Me.lblSubRubro.TabIndex = 4
        Me.lblSubRubro.Text = "SubRubro"
        '
        'cmbRubro_M
        '
        Me.cmbRubro_M.BindearPropiedadControl = Nothing
        Me.cmbRubro_M.BindearPropiedadEntidad = Nothing
        Me.cmbRubro_M.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro_M.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubro_M.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubro_M.FormattingEnabled = True
        Me.cmbRubro_M.IsPK = False
        Me.cmbRubro_M.IsRequired = False
        Me.cmbRubro_M.Key = Nothing
        Me.cmbRubro_M.LabelAsoc = Me.lblRubro
        Me.cmbRubro_M.Location = New System.Drawing.Point(92, 48)
        Me.cmbRubro_M.Name = "cmbRubro_M"
        Me.cmbRubro_M.Size = New System.Drawing.Size(301, 21)
        Me.cmbRubro_M.TabIndex = 3
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(12, 54)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 2
        Me.lblRubro.Text = "Rubro"
        '
        'cmbMarca_M
        '
        Me.cmbMarca_M.BindearPropiedadControl = Nothing
        Me.cmbMarca_M.BindearPropiedadEntidad = Nothing
        Me.cmbMarca_M.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca_M.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca_M.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca_M.FormattingEnabled = True
        Me.cmbMarca_M.IsPK = False
        Me.cmbMarca_M.IsRequired = False
        Me.cmbMarca_M.Key = Nothing
        Me.cmbMarca_M.LabelAsoc = Me.lblMarca
        Me.cmbMarca_M.Location = New System.Drawing.Point(92, 21)
        Me.cmbMarca_M.Name = "cmbMarca_M"
        Me.cmbMarca_M.Size = New System.Drawing.Size(301, 21)
        Me.cmbMarca_M.TabIndex = 1
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.LabelAsoc = Nothing
        Me.lblMarca.Location = New System.Drawing.Point(12, 23)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblMarca.TabIndex = 0
        Me.lblMarca.Text = "Marca"
        '
        'chbProveedorHabitual
        '
        Me.chbProveedorHabitual.AutoSize = True
        Me.chbProveedorHabitual.BindearPropiedadControl = Nothing
        Me.chbProveedorHabitual.BindearPropiedadEntidad = Nothing
        Me.chbProveedorHabitual.Enabled = False
        Me.chbProveedorHabitual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedorHabitual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedorHabitual.IsPK = False
        Me.chbProveedorHabitual.IsRequired = False
        Me.chbProveedorHabitual.Key = Nothing
        Me.chbProveedorHabitual.LabelAsoc = Nothing
        Me.chbProveedorHabitual.Location = New System.Drawing.Point(88, 317)
        Me.chbProveedorHabitual.Name = "chbProveedorHabitual"
        Me.chbProveedorHabitual.Size = New System.Drawing.Size(65, 17)
        Me.chbProveedorHabitual.TabIndex = 17
        Me.chbProveedorHabitual.Text = "Habitual"
        Me.chbProveedorHabitual.UseVisualStyleBackColor = True
        '
        'lblNombreProv
        '
        Me.lblNombreProv.AutoSize = True
        Me.lblNombreProv.LabelAsoc = Nothing
        Me.lblNombreProv.Location = New System.Drawing.Point(180, 268)
        Me.lblNombreProv.Name = "lblNombreProv"
        Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreProv.TabIndex = 15
        Me.lblNombreProv.Text = "Nombre"
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(85, 268)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 13
        Me.lblCodigoProveedor.Text = "Código"
        '
        'chbProveedor
        '
        Me.chbProveedor.AutoSize = True
        Me.chbProveedor.BindearPropiedadControl = Nothing
        Me.chbProveedor.BindearPropiedadEntidad = Nothing
        Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedor.IsPK = False
        Me.chbProveedor.IsRequired = False
        Me.chbProveedor.Key = Nothing
        Me.chbProveedor.LabelAsoc = Nothing
        Me.chbProveedor.Location = New System.Drawing.Point(12, 284)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 12
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'grbPrecio
        '
        Me.grbPrecio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPrecio.Controls.Add(Me.rdbNinguno)
        Me.grbPrecio.Controls.Add(Me.chbConIVA)
        Me.grbPrecio.Controls.Add(Me.rdbPrecioDeCosto)
        Me.grbPrecio.Controls.Add(Me.rdbPrecioDeVenta)
        Me.grbPrecio.Location = New System.Drawing.Point(12, 210)
        Me.grbPrecio.Name = "grbPrecio"
        Me.grbPrecio.Size = New System.Drawing.Size(455, 53)
        Me.grbPrecio.TabIndex = 11
        Me.grbPrecio.TabStop = False
        Me.grbPrecio.Text = "Mostrar precio..."
        '
        'rdbNinguno
        '
        Me.rdbNinguno.AutoSize = True
        Me.rdbNinguno.BindearPropiedadControl = Nothing
        Me.rdbNinguno.BindearPropiedadEntidad = Nothing
        Me.rdbNinguno.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbNinguno.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbNinguno.IsPK = False
        Me.rdbNinguno.IsRequired = False
        Me.rdbNinguno.Key = Nothing
        Me.rdbNinguno.LabelAsoc = Nothing
        Me.rdbNinguno.Location = New System.Drawing.Point(6, 19)
        Me.rdbNinguno.Name = "rdbNinguno"
        Me.rdbNinguno.Size = New System.Drawing.Size(91, 17)
        Me.rdbNinguno.TabIndex = 0
        Me.rdbNinguno.Text = "Ningún precio"
        Me.rdbNinguno.UseVisualStyleBackColor = True
        '
        'chbConIVA
        '
        Me.chbConIVA.AutoSize = True
        Me.chbConIVA.BindearPropiedadControl = Nothing
        Me.chbConIVA.BindearPropiedadEntidad = Nothing
        Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConIVA.IsPK = False
        Me.chbConIVA.IsRequired = False
        Me.chbConIVA.Key = Nothing
        Me.chbConIVA.LabelAsoc = Nothing
        Me.chbConIVA.Location = New System.Drawing.Point(316, 20)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 3
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = True
        '
        'rdbPrecioDeCosto
        '
        Me.rdbPrecioDeCosto.AutoSize = True
        Me.rdbPrecioDeCosto.BindearPropiedadControl = Nothing
        Me.rdbPrecioDeCosto.BindearPropiedadEntidad = Nothing
        Me.rdbPrecioDeCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbPrecioDeCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbPrecioDeCosto.IsPK = False
        Me.rdbPrecioDeCosto.IsRequired = False
        Me.rdbPrecioDeCosto.Key = Nothing
        Me.rdbPrecioDeCosto.LabelAsoc = Nothing
        Me.rdbPrecioDeCosto.Location = New System.Drawing.Point(210, 19)
        Me.rdbPrecioDeCosto.Name = "rdbPrecioDeCosto"
        Me.rdbPrecioDeCosto.Size = New System.Drawing.Size(100, 17)
        Me.rdbPrecioDeCosto.TabIndex = 2
        Me.rdbPrecioDeCosto.Text = "Precio de Costo"
        Me.rdbPrecioDeCosto.UseVisualStyleBackColor = True
        '
        'rdbPrecioDeVenta
        '
        Me.rdbPrecioDeVenta.AutoSize = True
        Me.rdbPrecioDeVenta.BindearPropiedadControl = Nothing
        Me.rdbPrecioDeVenta.BindearPropiedadEntidad = Nothing
        Me.rdbPrecioDeVenta.Checked = True
        Me.rdbPrecioDeVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbPrecioDeVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbPrecioDeVenta.IsPK = False
        Me.rdbPrecioDeVenta.IsRequired = False
        Me.rdbPrecioDeVenta.Key = Nothing
        Me.rdbPrecioDeVenta.LabelAsoc = Nothing
        Me.rdbPrecioDeVenta.Location = New System.Drawing.Point(103, 19)
        Me.rdbPrecioDeVenta.Name = "rdbPrecioDeVenta"
        Me.rdbPrecioDeVenta.Size = New System.Drawing.Size(101, 17)
        Me.rdbPrecioDeVenta.TabIndex = 1
        Me.rdbPrecioDeVenta.TabStop = True
        Me.rdbPrecioDeVenta.Text = "Precio de Venta"
        Me.rdbPrecioDeVenta.UseVisualStyleBackColor = True
        '
        'cmbTipoInforme
        '
        Me.cmbTipoInforme.BindearPropiedadControl = Nothing
        Me.cmbTipoInforme.BindearPropiedadEntidad = Nothing
        Me.cmbTipoInforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoInforme.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoInforme.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoInforme.FormattingEnabled = True
        Me.cmbTipoInforme.IsPK = False
        Me.cmbTipoInforme.IsRequired = False
        Me.cmbTipoInforme.Key = Nothing
        Me.cmbTipoInforme.LabelAsoc = Nothing
        Me.cmbTipoInforme.Location = New System.Drawing.Point(92, 129)
        Me.cmbTipoInforme.Name = "cmbTipoInforme"
        Me.cmbTipoInforme.Size = New System.Drawing.Size(159, 21)
        Me.cmbTipoInforme.TabIndex = 9
        '
        'lblTipoInforme
        '
        Me.lblTipoInforme.AutoSize = True
        Me.lblTipoInforme.Location = New System.Drawing.Point(12, 132)
        Me.lblTipoInforme.Name = "lblTipoInforme"
        Me.lblTipoInforme.Size = New System.Drawing.Size(69, 13)
        Me.lblTipoInforme.TabIndex = 8
        Me.lblTipoInforme.Text = "Tipo Informe:"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(372, 340)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(95, 43)
        Me.btnImprimir.TabIndex = 19
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'bscProveedor
        '
        Me.bscProveedor.ActivarFiltroEnGrilla = True
        Me.bscProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ConfigBuscador = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.Enabled = False
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = False
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Nothing
        Me.bscProveedor.Location = New System.Drawing.Point(182, 284)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(285, 20)
        Me.bscProveedor.TabIndex = 16
        '
        'ListadoDeStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 428)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbConsultar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ListadoDeStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Stock"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.grpOrden.ResumeLayout(False)
        Me.grpOrden.PerformLayout()
        Me.grbPrecio.ResumeLayout(False)
        Me.grbPrecio.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents btnImprimir As Eniac.Controles.Button
   Friend WithEvents optPorRubro As System.Windows.Forms.RadioButton
   Friend WithEvents optPorMarca As System.Windows.Forms.RadioButton
   Friend WithEvents cmbTipoInforme As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoInforme As System.Windows.Forms.Label
   Friend WithEvents optAlfabetico As System.Windows.Forms.RadioButton
   Friend WithEvents optPorSubRubro As System.Windows.Forms.RadioButton
   Friend WithEvents lblSubRubro As Eniac.Controles.Label
   Friend WithEvents grbPrecio As System.Windows.Forms.GroupBox
   Friend WithEvents rdbPrecioDeCosto As Eniac.Controles.RadioButton
   Friend WithEvents rdbPrecioDeVenta As Eniac.Controles.RadioButton
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
    Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
    Friend WithEvents lblNombreProv As Eniac.Controles.Label
    Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
    Friend WithEvents chbProveedorHabitual As Eniac.Controles.CheckBox
    Friend WithEvents rdbNinguno As Eniac.Controles.RadioButton
    Friend WithEvents cmbMarca_M As Eniac.Win.ComboBoxMarcas
    Friend WithEvents cmbSubRubro_M As Eniac.Win.ComboBoxSubRubro
    Friend WithEvents cmbRubro_M As Eniac.Win.ComboBoxRubro
    Friend WithEvents grpOrden As System.Windows.Forms.GroupBox
    Friend WithEvents lblSubSubRubro As Eniac.Controles.Label
    Friend WithEvents cmbSubSubRubro_M As Eniac.Win.ComboBoxSubSubRubro
    Friend WithEvents chbEmbalaje As Eniac.Controles.CheckBox
    Friend WithEvents bscCodigoProveedor As Controles.Buscador2
    Friend WithEvents bscProveedor As Controles.Buscador2
End Class
