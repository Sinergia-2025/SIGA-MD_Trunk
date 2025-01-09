<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreventaV3CambioEstado
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreventaV3CambioEstado))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.cmbEstadoVisitaNuevo = New Eniac.Controles.ComboBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.cmbEstadoVisita = New Eniac.Controles.ComboBox()
      Me.Label2 = New Eniac.Controles.Label()
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
      Me.tstBarra.Size = New System.Drawing.Size(376, 29)
      Me.tstBarra.TabIndex = 4
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabar.Text = "&Grabar"
      Me.tsbGrabar.ToolTipText = "Cerrar el formulario"
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
      'cmbEstadoVisitaNuevo
      '
      Me.cmbEstadoVisitaNuevo.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstadoVisitaNuevo.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbEstadoVisitaNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoVisitaNuevo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoVisitaNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoVisitaNuevo.FormattingEnabled = True
      Me.cmbEstadoVisitaNuevo.IsPK = False
      Me.cmbEstadoVisitaNuevo.IsRequired = True
      Me.cmbEstadoVisitaNuevo.Key = Nothing
      Me.cmbEstadoVisitaNuevo.LabelAsoc = Me.Label3
      Me.cmbEstadoVisitaNuevo.Location = New System.Drawing.Point(162, 74)
      Me.cmbEstadoVisitaNuevo.Name = "cmbEstadoVisitaNuevo"
      Me.cmbEstadoVisitaNuevo.Size = New System.Drawing.Size(181, 21)
      Me.cmbEstadoVisitaNuevo.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(29, 77)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(118, 13)
      Me.Label3.TabIndex = 2
      Me.Label3.Text = "Estado de Visita Nuevo"
      '
      'cmbEstadoVisita
      '
      Me.cmbEstadoVisita.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstadoVisita.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbEstadoVisita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoVisita.Enabled = False
      Me.cmbEstadoVisita.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoVisita.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoVisita.FormattingEnabled = True
      Me.cmbEstadoVisita.IsPK = False
      Me.cmbEstadoVisita.IsRequired = True
      Me.cmbEstadoVisita.Key = Nothing
      Me.cmbEstadoVisita.LabelAsoc = Me.Label2
      Me.cmbEstadoVisita.Location = New System.Drawing.Point(162, 47)
      Me.cmbEstadoVisita.Name = "cmbEstadoVisita"
      Me.cmbEstadoVisita.Size = New System.Drawing.Size(181, 21)
      Me.cmbEstadoVisita.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(29, 50)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(86, 13)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "Estado de Visita:"
      '
      'PreventaV3CambioEstado
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(376, 123)
      Me.Controls.Add(Me.cmbEstadoVisitaNuevo)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cmbEstadoVisita)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "PreventaV3CambioEstado"
      Me.Text = "PreventaV2CambioEstado"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbEstadoVisitaNuevo As Eniac.Controles.ComboBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cmbEstadoVisita As Eniac.Controles.ComboBox
   Friend WithEvents Label2 As Eniac.Controles.Label
End Class
