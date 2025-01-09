<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichasClienteAct
   Inherits Eniac.Win.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FichasClienteAct))
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblOperacion = New Eniac.Controles.Label()
      Me.cmbOperacion = New Eniac.Controles.ComboBox()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.Label1 = New Eniac.Controles.Label()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.bscCodigoClienteRec = New Eniac.Controles.Buscador2()
      Me.lblCodigoClienteRec = New Eniac.Controles.Label()
      Me.dgvOperaciones = New Eniac.Controles.DataGridView()
      Me.bscClienteRec = New Eniac.Controles.Buscador2()
      Me.Label3 = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbActualizar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbCliente.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.dgvOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbCliente
      '
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Controls.Add(Me.lblOperacion)
      Me.grbCliente.Controls.Add(Me.cmbOperacion)
      Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.Label1)
      Me.grbCliente.Location = New System.Drawing.Point(23, 36)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(589, 103)
      Me.grbCliente.TabIndex = 0
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Cliente Emisor"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Nothing
      Me.bscCodigoCliente.Location = New System.Drawing.Point(23, 33)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoCliente.TabIndex = 10
      '
      'lblOperacion
      '
      Me.lblOperacion.AutoSize = True
      Me.lblOperacion.Location = New System.Drawing.Point(21, 60)
      Me.lblOperacion.Name = "lblOperacion"
      Me.lblOperacion.Size = New System.Drawing.Size(56, 13)
      Me.lblOperacion.TabIndex = 27
      Me.lblOperacion.Text = "Operación"
      '
      'cmbOperacion
      '
      Me.cmbOperacion.BindearPropiedadControl = Nothing
      Me.cmbOperacion.BindearPropiedadEntidad = Nothing
      Me.cmbOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbOperacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbOperacion.FormattingEnabled = True
      Me.cmbOperacion.IsPK = False
      Me.cmbOperacion.IsRequired = False
      Me.cmbOperacion.Key = Nothing
      Me.cmbOperacion.LabelAsoc = Me.lblOperacion
      Me.cmbOperacion.Location = New System.Drawing.Point(21, 76)
      Me.cmbOperacion.Name = "cmbOperacion"
      Me.cmbOperacion.Size = New System.Drawing.Size(431, 21)
      Me.cmbOperacion.TabIndex = 26
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(23, 18)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 12
      Me.lblCodigoCliente.Text = "Codigo"
      '
      'bscCliente
      '
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.Datos = Nothing
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
      Me.bscCliente.Location = New System.Drawing.Point(151, 33)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(336, 23)
      Me.bscCliente.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(148, 19)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(44, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Nombre"
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "row_add.ico")
      Me.imgIconos.Images.SetKeyName(1, "row_delete.ico")
      Me.imgIconos.Images.SetKeyName(2, "disk_blue.ico")
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.bscCodigoClienteRec)
      Me.GroupBox1.Controls.Add(Me.lblCodigoClienteRec)
      Me.GroupBox1.Controls.Add(Me.dgvOperaciones)
      Me.GroupBox1.Controls.Add(Me.bscClienteRec)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Location = New System.Drawing.Point(23, 142)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(589, 209)
      Me.GroupBox1.TabIndex = 29
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Cliente Receptor"
      '
      'bscCodigoClienteRec
      '
      Me.bscCodigoClienteRec.BindearPropiedadControl = Nothing
      Me.bscCodigoClienteRec.BindearPropiedadEntidad = Nothing
      Me.bscCodigoClienteRec.Datos = Nothing
      Me.bscCodigoClienteRec.FilaDevuelta = Nothing
      Me.bscCodigoClienteRec.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoClienteRec.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoClienteRec.IsDecimal = False
      Me.bscCodigoClienteRec.IsNumber = False
      Me.bscCodigoClienteRec.IsPK = False
      Me.bscCodigoClienteRec.IsRequired = False
      Me.bscCodigoClienteRec.Key = ""
      Me.bscCodigoClienteRec.LabelAsoc = Nothing
      Me.bscCodigoClienteRec.Location = New System.Drawing.Point(26, 39)
      Me.bscCodigoClienteRec.MaxLengh = "32767"
      Me.bscCodigoClienteRec.Name = "bscCodigoClienteRec"
      Me.bscCodigoClienteRec.Permitido = True
      Me.bscCodigoClienteRec.Selecciono = False
      Me.bscCodigoClienteRec.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoClienteRec.TabIndex = 30
      '
      'lblCodigoClienteRec
      '
      Me.lblCodigoClienteRec.AutoSize = True
      Me.lblCodigoClienteRec.Location = New System.Drawing.Point(26, 24)
      Me.lblCodigoClienteRec.Name = "lblCodigoClienteRec"
      Me.lblCodigoClienteRec.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoClienteRec.TabIndex = 32
      Me.lblCodigoClienteRec.Text = "Codigo"
      '
      'dgvOperaciones
      '
      Me.dgvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvOperaciones.Location = New System.Drawing.Point(7, 69)
      Me.dgvOperaciones.Name = "dgvOperaciones"
      Me.dgvOperaciones.Size = New System.Drawing.Size(567, 124)
      Me.dgvOperaciones.TabIndex = 29
      '
      'bscClienteRec
      '
      Me.bscClienteRec.AutoSize = True
      Me.bscClienteRec.BindearPropiedadControl = Nothing
      Me.bscClienteRec.BindearPropiedadEntidad = Nothing
      Me.bscClienteRec.Datos = Nothing
      Me.bscClienteRec.FilaDevuelta = Nothing
      Me.bscClienteRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscClienteRec.ForeColorFocus = System.Drawing.Color.Red
      Me.bscClienteRec.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscClienteRec.IsDecimal = False
      Me.bscClienteRec.IsNumber = False
      Me.bscClienteRec.IsPK = False
      Me.bscClienteRec.IsRequired = False
      Me.bscClienteRec.Key = ""
      Me.bscClienteRec.LabelAsoc = Nothing
      Me.bscClienteRec.Location = New System.Drawing.Point(151, 39)
      Me.bscClienteRec.Margin = New System.Windows.Forms.Padding(4)
      Me.bscClienteRec.MaxLengh = "32767"
      Me.bscClienteRec.Name = "bscClienteRec"
      Me.bscClienteRec.Permitido = True
      Me.bscClienteRec.Selecciono = False
      Me.bscClienteRec.Size = New System.Drawing.Size(336, 23)
      Me.bscClienteRec.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(150, 25)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(44, 13)
      Me.Label3.TabIndex = 2
      Me.Label3.Text = "Nombre"
      '
      'tstBarra
      '
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbActualizar, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(624, 29)
      Me.tstBarra.TabIndex = 30
      Me.tstBarra.Text = "ToolStrip1"
      '
      'tsbActualizar
      '
      Me.tsbActualizar.Image = Global.Eniac.Win.My.Resources.Resources.check2
      Me.tsbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbActualizar.Name = "tsbActualizar"
      Me.tsbActualizar.Size = New System.Drawing.Size(85, 26)
      Me.tsbActualizar.Text = "&Actualizar"
      Me.tsbActualizar.ToolTipText = "Refrescar el formulario"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'FichasClienteAct
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(624, 362)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.grbCliente)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FichasClienteAct"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Actualizar las fichas a los clientes"
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.dgvOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbOperacion As Eniac.Controles.ComboBox
   Friend WithEvents lblOperacion As Eniac.Controles.Label
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents bscClienteRec As Eniac.Controles.Buscador2
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents dgvOperaciones As Eniac.Controles.DataGridView
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCodigoClienteRec As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoClienteRec As Eniac.Controles.Label
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbActualizar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton

End Class
