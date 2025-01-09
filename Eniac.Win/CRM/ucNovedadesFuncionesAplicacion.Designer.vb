<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucNovedadesFuncionesAplicacion
   Inherits ucNovedades

   'UserControl overrides dispose to clean up the component list.
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
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.lnkNombre = New Eniac.Controles.LinkLabel()
      Me.bscFuncion = New Eniac.Controles.Buscador2()
      Me.bscCodigoFuncion = New Eniac.Controles.Buscador2()
      Me.lnkCantidadLinks = New Eniac.Controles.LinkLabel()
      Me.ctxLinks = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.ctxVinculados = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.lnkFuncionesVinculadas = New Eniac.Controles.LinkLabel()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.lnkFuncionesVinculadas)
      Me.GroupBox1.Controls.Add(Me.lnkCantidadLinks)
      Me.GroupBox1.Controls.Add(Me.bscCodigoFuncion)
      Me.GroupBox1.Controls.Add(Me.bscFuncion)
      Me.GroupBox1.Controls.Add(Me.lblCodigoCliente)
      Me.GroupBox1.Controls.Add(Me.lnkNombre)
      Me.GroupBox1.Size = New System.Drawing.Size(385, 52)
      Me.GroupBox1.Text = "Función del sistema"
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(5, 14)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 10
      Me.lblCodigoCliente.Text = "Código"
      '
      'lnkNombre
      '
      Me.lnkNombre.AutoSize = True
      Me.lnkNombre.LabelAsoc = Nothing
      Me.lnkNombre.Location = New System.Drawing.Point(96, 14)
      Me.lnkNombre.Name = "lnkNombre"
      Me.lnkNombre.Size = New System.Drawing.Size(44, 13)
      Me.lnkNombre.TabIndex = 12
      Me.lnkNombre.TabStop = True
      Me.lnkNombre.Text = "&Nombre"
      '
      'bscFuncion
      '
      Me.bscFuncion.ActivarFiltroEnGrilla = True
      Me.bscFuncion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscFuncion.BindearPropiedadControl = Nothing
      Me.bscFuncion.BindearPropiedadEntidad = Nothing
      Me.bscFuncion.ConfigBuscador = Nothing
      Me.bscFuncion.Datos = Nothing
      Me.bscFuncion.FilaDevuelta = Nothing
      Me.bscFuncion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscFuncion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscFuncion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscFuncion.IsDecimal = False
      Me.bscFuncion.IsNumber = False
      Me.bscFuncion.IsPK = False
      Me.bscFuncion.IsRequired = False
      Me.bscFuncion.Key = ""
      Me.bscFuncion.LabelAsoc = Me.lnkNombre
      Me.bscFuncion.Location = New System.Drawing.Point(99, 27)
      Me.bscFuncion.Margin = New System.Windows.Forms.Padding(4)
      Me.bscFuncion.MaxLengh = "32767"
      Me.bscFuncion.Name = "bscFuncion"
      Me.bscFuncion.Permitido = True
      Me.bscFuncion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscFuncion.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscFuncion.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscFuncion.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscFuncion.Selecciono = False
      Me.bscFuncion.Size = New System.Drawing.Size(279, 23)
      Me.bscFuncion.TabIndex = 13
      '
      'bscCodigoFuncion
      '
      Me.bscCodigoFuncion.ActivarFiltroEnGrilla = True
      Me.bscCodigoFuncion.BindearPropiedadControl = Nothing
      Me.bscCodigoFuncion.BindearPropiedadEntidad = Nothing
      Me.bscCodigoFuncion.ConfigBuscador = Nothing
      Me.bscCodigoFuncion.Datos = Nothing
      Me.bscCodigoFuncion.FilaDevuelta = Nothing
      Me.bscCodigoFuncion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoFuncion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoFuncion.IsDecimal = False
      Me.bscCodigoFuncion.IsNumber = False
      Me.bscCodigoFuncion.IsPK = False
      Me.bscCodigoFuncion.IsRequired = False
      Me.bscCodigoFuncion.Key = ""
      Me.bscCodigoFuncion.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoFuncion.Location = New System.Drawing.Point(5, 28)
      Me.bscCodigoFuncion.MaxLengh = "32767"
      Me.bscCodigoFuncion.Name = "bscCodigoFuncion"
      Me.bscCodigoFuncion.Permitido = True
      Me.bscCodigoFuncion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoFuncion.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoFuncion.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoFuncion.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoFuncion.Selecciono = False
      Me.bscCodigoFuncion.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoFuncion.TabIndex = 11
      '
      'lnkCantidadLinks
      '
      Me.lnkCantidadLinks.LabelAsoc = Nothing
      Me.lnkCantidadLinks.Location = New System.Drawing.Point(304, 14)
      Me.lnkCantidadLinks.Name = "lnkCantidadLinks"
      Me.lnkCantidadLinks.Size = New System.Drawing.Size(74, 13)
      Me.lnkCantidadLinks.TabIndex = 14
      Me.lnkCantidadLinks.TabStop = True
      Me.lnkCantidadLinks.Text = "0 Links"
      Me.lnkCantidadLinks.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'ctxLinks
      '
      Me.ctxLinks.Name = "ContextMenuStrip1"
      Me.ctxLinks.Size = New System.Drawing.Size(181, 26)
      '
      'ctxVinculados
      '
      Me.ctxVinculados.Name = "ctxVinculados"
      Me.ctxVinculados.Size = New System.Drawing.Size(61, 4)
      '
      'lnkFuncionesVinculadas
      '
      Me.lnkFuncionesVinculadas.LabelAsoc = Nothing
      Me.lnkFuncionesVinculadas.Location = New System.Drawing.Point(146, 14)
      Me.lnkFuncionesVinculadas.Name = "lnkFuncionesVinculadas"
      Me.lnkFuncionesVinculadas.Size = New System.Drawing.Size(152, 13)
      Me.lnkFuncionesVinculadas.TabIndex = 15
      Me.lnkFuncionesVinculadas.TabStop = True
      Me.lnkFuncionesVinculadas.Text = "0 Funciones Vinculadas"
      Me.lnkFuncionesVinculadas.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'ucNovedadesFuncionesAplicacion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Margin = New System.Windows.Forms.Padding(0)
      Me.Name = "ucNovedadesFuncionesAplicacion"
      Me.Size = New System.Drawing.Size(385, 52)
      Me.Controls.SetChildIndex(Me.GroupBox1, 0)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents lnkNombre As Eniac.Controles.LinkLabel
   Friend WithEvents bscCodigoFuncion As Eniac.Controles.Buscador2
   Friend WithEvents bscFuncion As Eniac.Controles.Buscador2
   Friend WithEvents lnkCantidadLinks As Eniac.Controles.LinkLabel
   Friend WithEvents ctxLinks As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ctxVinculados As ContextMenuStrip
   Friend WithEvents lnkFuncionesVinculadas As Controles.LinkLabel
End Class
