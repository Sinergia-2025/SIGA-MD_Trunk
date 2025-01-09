<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaDePrecios
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaDePrecios))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.gpbOrdenarPor = New System.Windows.Forms.GroupBox()
      Me.rbtOrdenPorCodigo = New System.Windows.Forms.RadioButton()
      Me.rbtOrdenAlfabetico = New System.Windows.Forms.RadioButton()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.optPorCodigo = New System.Windows.Forms.RadioButton()
      Me.optPorMarca = New System.Windows.Forms.RadioButton()
      Me.optPorRubro = New System.Windows.Forms.RadioButton()
      Me.optAlfabetico = New System.Windows.Forms.RadioButton()
      Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
      Me.lblListaPrecios = New Eniac.Controles.Label()
      Me.cmbRubro = New Eniac.Controles.ComboBox()
      Me.chbRubro = New Eniac.Controles.CheckBox()
      Me.cmbMarca = New Eniac.Controles.ComboBox()
      Me.chbMarca = New Eniac.Controles.CheckBox()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra.SuspendLayout()
      Me.grbConsultar.SuspendLayout()
      Me.gpbOrdenarPor.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(493, 29)
      Me.tstBarra.TabIndex = 7
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
      Me.grbConsultar.Controls.Add(Me.gpbOrdenarPor)
      Me.grbConsultar.Controls.Add(Me.GroupBox1)
      Me.grbConsultar.Controls.Add(Me.cmbListaDePrecios)
      Me.grbConsultar.Controls.Add(Me.lblListaPrecios)
      Me.grbConsultar.Controls.Add(Me.cmbRubro)
      Me.grbConsultar.Controls.Add(Me.chbRubro)
      Me.grbConsultar.Controls.Add(Me.cmbMarca)
      Me.grbConsultar.Controls.Add(Me.chbMarca)
      Me.grbConsultar.Location = New System.Drawing.Point(12, 41)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(469, 271)
      Me.grbConsultar.TabIndex = 5
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
      '
      'gpbOrdenarPor
      '
      Me.gpbOrdenarPor.Controls.Add(Me.rbtOrdenPorCodigo)
      Me.gpbOrdenarPor.Controls.Add(Me.rbtOrdenAlfabetico)
      Me.gpbOrdenarPor.Location = New System.Drawing.Point(13, 215)
      Me.gpbOrdenarPor.Name = "gpbOrdenarPor"
      Me.gpbOrdenarPor.Size = New System.Drawing.Size(447, 43)
      Me.gpbOrdenarPor.TabIndex = 51
      Me.gpbOrdenarPor.TabStop = False
      Me.gpbOrdenarPor.Text = "Ordenar por:"
      '
      'rbtOrdenPorCodigo
      '
      Me.rbtOrdenPorCodigo.AutoSize = True
      Me.rbtOrdenPorCodigo.Location = New System.Drawing.Point(139, 19)
      Me.rbtOrdenPorCodigo.Name = "rbtOrdenPorCodigo"
      Me.rbtOrdenPorCodigo.Size = New System.Drawing.Size(77, 17)
      Me.rbtOrdenPorCodigo.TabIndex = 48
      Me.rbtOrdenPorCodigo.Text = "Por Código"
      Me.rbtOrdenPorCodigo.UseVisualStyleBackColor = True
      '
      'rbtOrdenAlfabetico
      '
      Me.rbtOrdenAlfabetico.AutoSize = True
      Me.rbtOrdenAlfabetico.Checked = True
      Me.rbtOrdenAlfabetico.Location = New System.Drawing.Point(23, 19)
      Me.rbtOrdenAlfabetico.Name = "rbtOrdenAlfabetico"
      Me.rbtOrdenAlfabetico.Size = New System.Drawing.Size(72, 17)
      Me.rbtOrdenAlfabetico.TabIndex = 5
      Me.rbtOrdenAlfabetico.TabStop = True
      Me.rbtOrdenAlfabetico.Text = "Alfabético"
      Me.rbtOrdenAlfabetico.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.optPorCodigo)
      Me.GroupBox1.Controls.Add(Me.optPorMarca)
      Me.GroupBox1.Controls.Add(Me.optPorRubro)
      Me.GroupBox1.Controls.Add(Me.optAlfabetico)
      Me.GroupBox1.Location = New System.Drawing.Point(13, 166)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(447, 43)
      Me.GroupBox1.TabIndex = 50
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Agrupar por:"
      '
      'optPorCodigo
      '
      Me.optPorCodigo.AutoSize = True
      Me.optPorCodigo.Location = New System.Drawing.Point(355, 20)
      Me.optPorCodigo.Name = "optPorCodigo"
      Me.optPorCodigo.Size = New System.Drawing.Size(77, 17)
      Me.optPorCodigo.TabIndex = 48
      Me.optPorCodigo.TabStop = True
      Me.optPorCodigo.Text = "Por Código"
      Me.optPorCodigo.UseVisualStyleBackColor = True
      '
      'optPorMarca
      '
      Me.optPorMarca.AutoSize = True
      Me.optPorMarca.Checked = True
      Me.optPorMarca.Location = New System.Drawing.Point(23, 19)
      Me.optPorMarca.Name = "optPorMarca"
      Me.optPorMarca.Size = New System.Drawing.Size(109, 17)
      Me.optPorMarca.TabIndex = 3
      Me.optPorMarca.TabStop = True
      Me.optPorMarca.Text = "Por Marca_Rubro"
      Me.optPorMarca.UseVisualStyleBackColor = True
      '
      'optPorRubro
      '
      Me.optPorRubro.AutoSize = True
      Me.optPorRubro.Location = New System.Drawing.Point(139, 19)
      Me.optPorRubro.Name = "optPorRubro"
      Me.optPorRubro.Size = New System.Drawing.Size(109, 17)
      Me.optPorRubro.TabIndex = 4
      Me.optPorRubro.TabStop = True
      Me.optPorRubro.Text = "Por Rubro_Marca"
      Me.optPorRubro.UseVisualStyleBackColor = True
      '
      'optAlfabetico
      '
      Me.optAlfabetico.AutoSize = True
      Me.optAlfabetico.Location = New System.Drawing.Point(265, 19)
      Me.optAlfabetico.Name = "optAlfabetico"
      Me.optAlfabetico.Size = New System.Drawing.Size(72, 17)
      Me.optAlfabetico.TabIndex = 5
      Me.optAlfabetico.TabStop = True
      Me.optAlfabetico.Text = "Alfabético"
      Me.optAlfabetico.UseVisualStyleBackColor = True
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
      Me.cmbListaDePrecios.Location = New System.Drawing.Point(13, 40)
      Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
      Me.cmbListaDePrecios.Size = New System.Drawing.Size(291, 21)
      Me.cmbListaDePrecios.TabIndex = 0
      '
      'lblListaPrecios
      '
      Me.lblListaPrecios.AutoSize = True
      Me.lblListaPrecios.Location = New System.Drawing.Point(13, 25)
      Me.lblListaPrecios.Name = "lblListaPrecios"
      Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
      Me.lblListaPrecios.TabIndex = 47
      Me.lblListaPrecios.Text = "Lista de Precios"
      '
      'cmbRubro
      '
      Me.cmbRubro.BindearPropiedadControl = Nothing
      Me.cmbRubro.BindearPropiedadEntidad = Nothing
      Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRubro.Enabled = False
      Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRubro.FormattingEnabled = True
      Me.cmbRubro.IsPK = False
      Me.cmbRubro.IsRequired = False
      Me.cmbRubro.Key = Nothing
      Me.cmbRubro.LabelAsoc = Nothing
      Me.cmbRubro.Location = New System.Drawing.Point(12, 130)
      Me.cmbRubro.Name = "cmbRubro"
      Me.cmbRubro.Size = New System.Drawing.Size(292, 21)
      Me.cmbRubro.TabIndex = 2
      '
      'chbRubro
      '
      Me.chbRubro.AutoSize = True
      Me.chbRubro.BindearPropiedadControl = Nothing
      Me.chbRubro.BindearPropiedadEntidad = Nothing
      Me.chbRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRubro.IsPK = False
      Me.chbRubro.IsRequired = False
      Me.chbRubro.Key = Nothing
      Me.chbRubro.LabelAsoc = Nothing
      Me.chbRubro.Location = New System.Drawing.Point(12, 114)
      Me.chbRubro.Name = "chbRubro"
      Me.chbRubro.Size = New System.Drawing.Size(55, 17)
      Me.chbRubro.TabIndex = 5
      Me.chbRubro.Text = "Rubro"
      Me.chbRubro.UseVisualStyleBackColor = True
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
      Me.cmbMarca.Location = New System.Drawing.Point(12, 85)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(292, 21)
      Me.cmbMarca.TabIndex = 1
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
      Me.chbMarca.Location = New System.Drawing.Point(12, 69)
      Me.chbMarca.Name = "chbMarca"
      Me.chbMarca.Size = New System.Drawing.Size(56, 17)
      Me.chbMarca.TabIndex = 3
      Me.chbMarca.Text = "Marca"
      Me.chbMarca.UseVisualStyleBackColor = True
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "printer.ico")
      '
      'ListaDePrecios
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(493, 324)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbConsultar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ListaDePrecios"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Emisión de Lista de Precios"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.gpbOrdenarPor.ResumeLayout(False)
      Me.gpbOrdenarPor.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents optPorRubro As System.Windows.Forms.RadioButton
   Friend WithEvents optPorMarca As System.Windows.Forms.RadioButton
   Friend WithEvents optAlfabetico As System.Windows.Forms.RadioButton
   Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
   Friend WithEvents lblListaPrecios As Eniac.Controles.Label
   Friend WithEvents optPorCodigo As System.Windows.Forms.RadioButton
   Public WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents gpbOrdenarPor As System.Windows.Forms.GroupBox
   Friend WithEvents rbtOrdenPorCodigo As System.Windows.Forms.RadioButton
   Friend WithEvents rbtOrdenAlfabetico As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
