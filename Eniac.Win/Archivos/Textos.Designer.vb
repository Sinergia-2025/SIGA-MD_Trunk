<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Textos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Textos))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.txtAsunto = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.rtbCuerpoMail = New MSDN.Html.Editor.HtmlEditorControl()
      Me.btnExpandirHtml = New Eniac.Controles.Button()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtModalidad = New System.Windows.Forms.TextBox()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(720, 29)
      Me.tstBarra.TabIndex = 5
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
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
      Me.tsbGrabar.Text = "Grabar (F4)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'txtAsunto
      '
      Me.txtAsunto.Location = New System.Drawing.Point(83, 52)
      Me.txtAsunto.Name = "txtAsunto"
      Me.txtAsunto.Size = New System.Drawing.Size(472, 20)
      Me.txtAsunto.TabIndex = 6
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(21, 55)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "Asunto"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(21, 90)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(41, 13)
      Me.Label2.TabIndex = 9
      Me.Label2.Text = "Cuerpo"
      '
      'rtbCuerpoMail
      '
      Me.rtbCuerpoMail.InnerText = Nothing
      Me.rtbCuerpoMail.Location = New System.Drawing.Point(83, 90)
      Me.rtbCuerpoMail.Name = "rtbCuerpoMail"
      Me.rtbCuerpoMail.Size = New System.Drawing.Size(625, 342)
      Me.rtbCuerpoMail.TabIndex = 17
      '
      'btnExpandirHtml
      '
      Me.btnExpandirHtml.Image = CType(resources.GetObject("btnExpandirHtml.Image"), System.Drawing.Image)
      Me.btnExpandirHtml.Location = New System.Drawing.Point(24, 392)
      Me.btnExpandirHtml.Name = "btnExpandirHtml"
      Me.btnExpandirHtml.Size = New System.Drawing.Size(40, 40)
      Me.btnExpandirHtml.TabIndex = 18
      Me.btnExpandirHtml.Text = "..."
      Me.btnExpandirHtml.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(564, 56)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(56, 13)
      Me.Label3.TabIndex = 20
      Me.Label3.Text = "Modalidad"
      '
      'txtModalidad
      '
      Me.txtModalidad.Location = New System.Drawing.Point(623, 52)
      Me.txtModalidad.Name = "txtModalidad"
      Me.txtModalidad.Size = New System.Drawing.Size(85, 20)
      Me.txtModalidad.TabIndex = 19
      '
      'Textos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(720, 444)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtModalidad)
      Me.Controls.Add(Me.btnExpandirHtml)
      Me.Controls.Add(Me.rtbCuerpoMail)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtAsunto)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "Textos"
      Me.Text = "Textos"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents rtbCuerpoMail As MSDN.Html.Editor.HtmlEditorControl
   Friend WithEvents btnExpandirHtml As Eniac.Controles.Button
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtModalidad As System.Windows.Forms.TextBox
End Class
