<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaDeCostos
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaDeCostos))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.lblSubSubRubro = New System.Windows.Forms.Label()
      Me.lblRubro = New System.Windows.Forms.Label()
      Me.lblSubRubro = New System.Windows.Forms.Label()
      Me.cmbRubro = New Eniac.Win.ComboBoxRubro()
      Me.cmbSubSubRubro = New Eniac.Win.ComboBoxSubSubRubro()
      Me.cmbSubRubro = New Eniac.Win.ComboBoxSubRubro()
      Me.chbFechaActualizado = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chbImportarProductos = New System.Windows.Forms.CheckBox()
      Me.optAlfabetico = New System.Windows.Forms.RadioButton()
      Me.lblOrden = New System.Windows.Forms.Label()
      Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
      Me.lblListaPrecios = New Eniac.Controles.Label()
      Me.optPorRubro = New System.Windows.Forms.RadioButton()
      Me.optPorMarca = New System.Windows.Forms.RadioButton()
      Me.cmbMarca = New Eniac.Controles.ComboBox()
      Me.chbMarca = New Eniac.Controles.CheckBox()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra.SuspendLayout()
      Me.grbConsultar.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(438, 29)
      Me.tstBarra.TabIndex = 1
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Cerrar el formulario"
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
      Me.grbConsultar.Controls.Add(Me.lblSubSubRubro)
      Me.grbConsultar.Controls.Add(Me.lblRubro)
      Me.grbConsultar.Controls.Add(Me.lblSubRubro)
      Me.grbConsultar.Controls.Add(Me.cmbRubro)
      Me.grbConsultar.Controls.Add(Me.cmbSubSubRubro)
      Me.grbConsultar.Controls.Add(Me.cmbSubRubro)
      Me.grbConsultar.Controls.Add(Me.chbFechaActualizado)
      Me.grbConsultar.Controls.Add(Me.dtpHasta)
      Me.grbConsultar.Controls.Add(Me.dtpDesde)
      Me.grbConsultar.Controls.Add(Me.lblHasta)
      Me.grbConsultar.Controls.Add(Me.lblDesde)
      Me.grbConsultar.Controls.Add(Me.chbImportarProductos)
      Me.grbConsultar.Controls.Add(Me.optAlfabetico)
      Me.grbConsultar.Controls.Add(Me.lblOrden)
      Me.grbConsultar.Controls.Add(Me.cmbListaDePrecios)
      Me.grbConsultar.Controls.Add(Me.lblListaPrecios)
      Me.grbConsultar.Controls.Add(Me.optPorRubro)
      Me.grbConsultar.Controls.Add(Me.optPorMarca)
      Me.grbConsultar.Controls.Add(Me.cmbMarca)
      Me.grbConsultar.Controls.Add(Me.chbMarca)
      Me.grbConsultar.Location = New System.Drawing.Point(13, 38)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(413, 302)
      Me.grbConsultar.TabIndex = 0
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
      '
      'lblSubSubRubro
      '
      Me.lblSubSubRubro.AutoSize = True
      Me.lblSubSubRubro.Location = New System.Drawing.Point(2, 155)
      Me.lblSubSubRubro.Name = "lblSubSubRubro"
      Me.lblSubSubRubro.Size = New System.Drawing.Size(74, 13)
      Me.lblSubSubRubro.TabIndex = 21
      Me.lblSubSubRubro.Text = "SubSubRubro"
      '
      'lblRubro
      '
      Me.lblRubro.AutoSize = True
      Me.lblRubro.Location = New System.Drawing.Point(40, 101)
      Me.lblRubro.Name = "lblRubro"
      Me.lblRubro.Size = New System.Drawing.Size(36, 13)
      Me.lblRubro.TabIndex = 20
      Me.lblRubro.Text = "Rubro"
      '
      'lblSubRubro
      '
      Me.lblSubRubro.AutoSize = True
      Me.lblSubRubro.Location = New System.Drawing.Point(21, 128)
      Me.lblSubRubro.Name = "lblSubRubro"
      Me.lblSubRubro.Size = New System.Drawing.Size(55, 13)
      Me.lblSubRubro.TabIndex = 19
      Me.lblSubRubro.Text = "SubRubro"
      '
      'cmbRubro
      '
      Me.cmbRubro.BindearPropiedadControl = Nothing
      Me.cmbRubro.BindearPropiedadEntidad = Nothing
      Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRubro.FormattingEnabled = True
      Me.cmbRubro.IsPK = False
      Me.cmbRubro.IsRequired = False
      Me.cmbRubro.Key = Nothing
      Me.cmbRubro.LabelAsoc = Nothing
      Me.cmbRubro.Location = New System.Drawing.Point(82, 98)
      Me.cmbRubro.Name = "cmbRubro"
      Me.cmbRubro.Size = New System.Drawing.Size(191, 21)
      Me.cmbRubro.TabIndex = 18
      '
      'cmbSubSubRubro
      '
      Me.cmbSubSubRubro.BindearPropiedadControl = Nothing
      Me.cmbSubSubRubro.BindearPropiedadEntidad = Nothing
      Me.cmbSubSubRubro.ConcatenarNombreSubRubro = False
      Me.cmbSubSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSubSubRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSubSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSubSubRubro.FormattingEnabled = True
      Me.cmbSubSubRubro.IsPK = False
      Me.cmbSubSubRubro.IsRequired = False
      Me.cmbSubSubRubro.Key = Nothing
      Me.cmbSubSubRubro.LabelAsoc = Nothing
      Me.cmbSubSubRubro.Location = New System.Drawing.Point(82, 152)
      Me.cmbSubSubRubro.Name = "cmbSubSubRubro"
      Me.cmbSubSubRubro.Size = New System.Drawing.Size(191, 21)
      Me.cmbSubSubRubro.TabIndex = 17
      '
      'cmbSubRubro
      '
      Me.cmbSubRubro.BindearPropiedadControl = Nothing
      Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
      Me.cmbSubRubro.ConcatenarNombreRubro = False
      Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSubRubro.FormattingEnabled = True
      Me.cmbSubRubro.IsPK = False
      Me.cmbSubRubro.IsRequired = False
      Me.cmbSubRubro.Key = Nothing
      Me.cmbSubRubro.LabelAsoc = Nothing
      Me.cmbSubRubro.Location = New System.Drawing.Point(82, 125)
      Me.cmbSubRubro.Name = "cmbSubRubro"
      Me.cmbSubRubro.Size = New System.Drawing.Size(191, 21)
      Me.cmbSubRubro.TabIndex = 16
      '
      'chbFechaActualizado
      '
      Me.chbFechaActualizado.AutoSize = True
      Me.chbFechaActualizado.BindearPropiedadControl = Nothing
      Me.chbFechaActualizado.BindearPropiedadEntidad = Nothing
      Me.chbFechaActualizado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaActualizado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaActualizado.IsPK = False
      Me.chbFechaActualizado.IsRequired = False
      Me.chbFechaActualizado.Key = Nothing
      Me.chbFechaActualizado.LabelAsoc = Nothing
      Me.chbFechaActualizado.Location = New System.Drawing.Point(20, 199)
      Me.chbFechaActualizado.Name = "chbFechaActualizado"
      Me.chbFechaActualizado.Size = New System.Drawing.Size(114, 17)
      Me.chbFechaActualizado.TabIndex = 6
      Me.chbFechaActualizado.Text = "Fecha Actualizado"
      Me.chbFechaActualizado.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.Enabled = False
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(179, 211)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 10
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(139, 215)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 9
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.Enabled = False
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(179, 185)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 8
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(138, 189)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 7
      Me.lblDesde.Text = "Desde"
      '
      'chbImportarProductos
      '
      Me.chbImportarProductos.AutoSize = True
      Me.chbImportarProductos.Location = New System.Drawing.Point(141, 282)
      Me.chbImportarProductos.Name = "chbImportarProductos"
      Me.chbImportarProductos.Size = New System.Drawing.Size(180, 17)
      Me.chbImportarProductos.TabIndex = 15
      Me.chbImportarProductos.Text = "Formato para Importar Productos"
      Me.chbImportarProductos.UseVisualStyleBackColor = True
      Me.chbImportarProductos.Visible = False
      '
      'optAlfabetico
      '
      Me.optAlfabetico.AutoSize = True
      Me.optAlfabetico.Location = New System.Drawing.Point(63, 281)
      Me.optAlfabetico.Name = "optAlfabetico"
      Me.optAlfabetico.Size = New System.Drawing.Size(72, 17)
      Me.optAlfabetico.TabIndex = 14
      Me.optAlfabetico.TabStop = True
      Me.optAlfabetico.Text = "Alfabético"
      Me.optAlfabetico.UseVisualStyleBackColor = True
      '
      'lblOrden
      '
      Me.lblOrden.AutoSize = True
      Me.lblOrden.Location = New System.Drawing.Point(17, 228)
      Me.lblOrden.Name = "lblOrden"
      Me.lblOrden.Size = New System.Drawing.Size(42, 13)
      Me.lblOrden.TabIndex = 11
      Me.lblOrden.Text = "Orden :"
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
      Me.cmbListaDePrecios.Location = New System.Drawing.Point(9, 31)
      Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
      Me.cmbListaDePrecios.Size = New System.Drawing.Size(234, 21)
      Me.cmbListaDePrecios.TabIndex = 1
      '
      'lblListaPrecios
      '
      Me.lblListaPrecios.AutoSize = True
      Me.lblListaPrecios.LabelAsoc = Nothing
      Me.lblListaPrecios.Location = New System.Drawing.Point(9, 16)
      Me.lblListaPrecios.Name = "lblListaPrecios"
      Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
      Me.lblListaPrecios.TabIndex = 0
      Me.lblListaPrecios.Text = "Lista de Precios"
      '
      'optPorRubro
      '
      Me.optPorRubro.AutoSize = True
      Me.optPorRubro.Location = New System.Drawing.Point(63, 253)
      Me.optPorRubro.Name = "optPorRubro"
      Me.optPorRubro.Size = New System.Drawing.Size(73, 17)
      Me.optPorRubro.TabIndex = 13
      Me.optPorRubro.TabStop = True
      Me.optPorRubro.Text = "Por Rubro"
      Me.optPorRubro.UseVisualStyleBackColor = True
      '
      'optPorMarca
      '
      Me.optPorMarca.AutoSize = True
      Me.optPorMarca.Checked = True
      Me.optPorMarca.Location = New System.Drawing.Point(63, 226)
      Me.optPorMarca.Name = "optPorMarca"
      Me.optPorMarca.Size = New System.Drawing.Size(74, 17)
      Me.optPorMarca.TabIndex = 12
      Me.optPorMarca.TabStop = True
      Me.optPorMarca.Text = "Por Marca"
      Me.optPorMarca.UseVisualStyleBackColor = True
      '
      'cmbMarca
      '
      Me.cmbMarca.BindearPropiedadControl = Nothing
      Me.cmbMarca.BindearPropiedadEntidad = Nothing
      Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarca.Enabled = False
      Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMarca.FormattingEnabled = True
      Me.cmbMarca.IsPK = False
      Me.cmbMarca.IsRequired = False
      Me.cmbMarca.Key = Nothing
      Me.cmbMarca.LabelAsoc = Nothing
      Me.cmbMarca.Location = New System.Drawing.Point(82, 71)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(191, 21)
      Me.cmbMarca.TabIndex = 3
      '
      'chbMarca
      '
      Me.chbMarca.AutoSize = True
      Me.chbMarca.BindearPropiedadControl = Nothing
      Me.chbMarca.BindearPropiedadEntidad = Nothing
      Me.chbMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMarca.IsPK = False
      Me.chbMarca.IsRequired = False
      Me.chbMarca.Key = Nothing
      Me.chbMarca.LabelAsoc = Nothing
      Me.chbMarca.Location = New System.Drawing.Point(20, 73)
      Me.chbMarca.Name = "chbMarca"
      Me.chbMarca.Size = New System.Drawing.Size(56, 17)
      Me.chbMarca.TabIndex = 2
      Me.chbMarca.Text = "Marca"
      Me.chbMarca.UseVisualStyleBackColor = True
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "printer.ico")
      '
      'ListaDeCostos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(438, 349)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbConsultar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ListaDeCostos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Emisión de Lista de Costos"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents optPorRubro As System.Windows.Forms.RadioButton
   Friend WithEvents optPorMarca As System.Windows.Forms.RadioButton
   Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
   Friend WithEvents lblListaPrecios As Eniac.Controles.Label
   Friend WithEvents lblOrden As System.Windows.Forms.Label
   Friend WithEvents optAlfabetico As System.Windows.Forms.RadioButton
   Friend WithEvents chbImportarProductos As System.Windows.Forms.CheckBox
   Friend WithEvents chbFechaActualizado As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Public WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblSubSubRubro As System.Windows.Forms.Label
   Friend WithEvents lblRubro As System.Windows.Forms.Label
   Friend WithEvents lblSubRubro As System.Windows.Forms.Label
   Friend WithEvents cmbRubro As Eniac.Win.ComboBoxRubro
   Friend WithEvents cmbSubSubRubro As Eniac.Win.ComboBoxSubSubRubro
   Friend WithEvents cmbSubRubro As Eniac.Win.ComboBoxSubRubro
End Class
