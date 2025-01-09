<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreventaV3CambioProducto
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreventaV3CambioProducto))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.lblProductoNuevo = New Eniac.Controles.Label()
      Me.lblIdProductoAnterior = New Eniac.Controles.Label()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.txtIdProductoAnterior = New Eniac.Controles.TextBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.txtIdListaPreciosAnterior = New Eniac.Controles.TextBox()
      Me.lblIdListaPreciosAnterior = New Eniac.Controles.Label()
      Me.lblListaPreciosNueva = New Eniac.Controles.Label()
      Me.cmbListaPreciosNueva = New Eniac.Controles.ComboBox()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(784, 29)
      Me.tstBarra.TabIndex = 5
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
      Me.tsbGrabar.Text = "&Grabar (F4)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
      '
      'lblProductoNuevo
      '
      Me.lblProductoNuevo.AutoSize = True
      Me.lblProductoNuevo.LabelAsoc = Nothing
      Me.lblProductoNuevo.Location = New System.Drawing.Point(264, 51)
      Me.lblProductoNuevo.Name = "lblProductoNuevo"
      Me.lblProductoNuevo.Size = New System.Drawing.Size(85, 13)
      Me.lblProductoNuevo.TabIndex = 2
      Me.lblProductoNuevo.Text = "Producto Nuevo"
      '
      'lblIdProductoAnterior
      '
      Me.lblIdProductoAnterior.AutoSize = True
      Me.lblIdProductoAnterior.LabelAsoc = Nothing
      Me.lblIdProductoAnterior.Location = New System.Drawing.Point(29, 51)
      Me.lblIdProductoAnterior.Name = "lblIdProductoAnterior"
      Me.lblIdProductoAnterior.Size = New System.Drawing.Size(86, 13)
      Me.lblIdProductoAnterior.TabIndex = 0
      Me.lblIdProductoAnterior.Text = "Código Producto"
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2.ConfigBuscador = Nothing
      Me.bscCodigoProducto2.Datos = Nothing
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto2.IsDecimal = False
      Me.bscCodigoProducto2.IsNumber = False
      Me.bscCodigoProducto2.IsPK = False
      Me.bscCodigoProducto2.IsRequired = False
      Me.bscCodigoProducto2.Key = ""
      Me.bscCodigoProducto2.LabelAsoc = Nothing
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(387, 47)
      Me.bscCodigoProducto2.MaxLengh = "15"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(127, 20)
      Me.bscCodigoProducto2.TabIndex = 3
      '
      'txtIdProductoAnterior
      '
      Me.txtIdProductoAnterior.BindearPropiedadControl = Nothing
      Me.txtIdProductoAnterior.BindearPropiedadEntidad = Nothing
      Me.txtIdProductoAnterior.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProductoAnterior.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProductoAnterior.Formato = ""
      Me.txtIdProductoAnterior.IsDecimal = False
      Me.txtIdProductoAnterior.IsNumber = False
      Me.txtIdProductoAnterior.IsPK = False
      Me.txtIdProductoAnterior.IsRequired = False
      Me.txtIdProductoAnterior.Key = ""
      Me.txtIdProductoAnterior.LabelAsoc = Me.lblIdProductoAnterior
      Me.txtIdProductoAnterior.Location = New System.Drawing.Point(121, 47)
      Me.txtIdProductoAnterior.Name = "txtIdProductoAnterior"
      Me.txtIdProductoAnterior.ReadOnly = True
      Me.txtIdProductoAnterior.Size = New System.Drawing.Size(127, 20)
      Me.txtIdProductoAnterior.TabIndex = 1
      Me.txtIdProductoAnterior.TabStop = False
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
      Me.bscProducto2.Location = New System.Drawing.Point(520, 47)
      Me.bscProducto2.MaxLengh = "60"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(238, 20)
      Me.bscProducto2.TabIndex = 4
      '
      'txtIdListaPreciosAnterior
      '
      Me.txtIdListaPreciosAnterior.BindearPropiedadControl = Nothing
      Me.txtIdListaPreciosAnterior.BindearPropiedadEntidad = Nothing
      Me.txtIdListaPreciosAnterior.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdListaPreciosAnterior.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdListaPreciosAnterior.Formato = ""
      Me.txtIdListaPreciosAnterior.IsDecimal = False
      Me.txtIdListaPreciosAnterior.IsNumber = False
      Me.txtIdListaPreciosAnterior.IsPK = False
      Me.txtIdListaPreciosAnterior.IsRequired = False
      Me.txtIdListaPreciosAnterior.Key = ""
      Me.txtIdListaPreciosAnterior.LabelAsoc = Me.lblIdListaPreciosAnterior
      Me.txtIdListaPreciosAnterior.Location = New System.Drawing.Point(121, 73)
      Me.txtIdListaPreciosAnterior.Name = "txtIdListaPreciosAnterior"
      Me.txtIdListaPreciosAnterior.ReadOnly = True
      Me.txtIdListaPreciosAnterior.Size = New System.Drawing.Size(127, 20)
      Me.txtIdListaPreciosAnterior.TabIndex = 7
      Me.txtIdListaPreciosAnterior.TabStop = False
      '
      'lblIdListaPreciosAnterior
      '
      Me.lblIdListaPreciosAnterior.AutoSize = True
      Me.lblIdListaPreciosAnterior.LabelAsoc = Nothing
      Me.lblIdListaPreciosAnterior.Location = New System.Drawing.Point(29, 77)
      Me.lblIdListaPreciosAnterior.Name = "lblIdListaPreciosAnterior"
      Me.lblIdListaPreciosAnterior.Size = New System.Drawing.Size(82, 13)
      Me.lblIdListaPreciosAnterior.TabIndex = 6
      Me.lblIdListaPreciosAnterior.Text = "Lista de Precios"
      '
      'lblListaPreciosNueva
      '
      Me.lblListaPreciosNueva.AutoSize = True
      Me.lblListaPreciosNueva.LabelAsoc = Nothing
      Me.lblListaPreciosNueva.Location = New System.Drawing.Point(264, 77)
      Me.lblListaPreciosNueva.Name = "lblListaPreciosNueva"
      Me.lblListaPreciosNueva.Size = New System.Drawing.Size(117, 13)
      Me.lblListaPreciosNueva.TabIndex = 8
      Me.lblListaPreciosNueva.Text = "Lista de Precios Nueva"
      '
      'cmbListaPreciosNueva
      '
      Me.cmbListaPreciosNueva.BindearPropiedadControl = "SelectedValue"
      Me.cmbListaPreciosNueva.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbListaPreciosNueva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListaPreciosNueva.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbListaPreciosNueva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbListaPreciosNueva.FormattingEnabled = True
      Me.cmbListaPreciosNueva.IsPK = False
      Me.cmbListaPreciosNueva.IsRequired = True
      Me.cmbListaPreciosNueva.Key = Nothing
      Me.cmbListaPreciosNueva.LabelAsoc = Me.lblProductoNuevo
      Me.cmbListaPreciosNueva.Location = New System.Drawing.Point(387, 72)
      Me.cmbListaPreciosNueva.Name = "cmbListaPreciosNueva"
      Me.cmbListaPreciosNueva.Size = New System.Drawing.Size(181, 21)
      Me.cmbListaPreciosNueva.TabIndex = 9
      '
      'PreventaV3CambioProducto
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(784, 121)
      Me.ControlBox = False
      Me.Controls.Add(Me.cmbListaPreciosNueva)
      Me.Controls.Add(Me.lblListaPreciosNueva)
      Me.Controls.Add(Me.txtIdListaPreciosAnterior)
      Me.Controls.Add(Me.lblIdListaPreciosAnterior)
      Me.Controls.Add(Me.bscProducto2)
      Me.Controls.Add(Me.txtIdProductoAnterior)
      Me.Controls.Add(Me.bscCodigoProducto2)
      Me.Controls.Add(Me.lblProductoNuevo)
      Me.Controls.Add(Me.lblIdProductoAnterior)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "PreventaV3CambioProducto"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Modificar detalle"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblProductoNuevo As Eniac.Controles.Label
   Friend WithEvents lblIdProductoAnterior As Eniac.Controles.Label
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents txtIdProductoAnterior As Eniac.Controles.TextBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents txtIdListaPreciosAnterior As Eniac.Controles.TextBox
   Friend WithEvents lblIdListaPreciosAnterior As Eniac.Controles.Label
   Friend WithEvents lblListaPreciosNueva As Eniac.Controles.Label
   Friend WithEvents cmbListaPreciosNueva As Eniac.Controles.ComboBox
End Class
