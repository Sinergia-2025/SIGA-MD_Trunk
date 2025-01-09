<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArchivoDestinoExportacion
    Inherits BaseForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.grbArchivoDestino = New System.Windows.Forms.GroupBox()
      Me.btnArchivo = New Eniac.Controles.Button()
      Me.txtArchivoDestino = New Eniac.Controles.TextBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbConfirmar = New System.Windows.Forms.ToolStripButton()
      Me.grbArchivoDestino.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbArchivoDestino
      '
      Me.grbArchivoDestino.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbArchivoDestino.Controls.Add(Me.btnArchivo)
      Me.grbArchivoDestino.Controls.Add(Me.txtArchivoDestino)
      Me.grbArchivoDestino.Location = New System.Drawing.Point(2, 37)
      Me.grbArchivoDestino.Name = "grbArchivoDestino"
      Me.grbArchivoDestino.Size = New System.Drawing.Size(592, 67)
      Me.grbArchivoDestino.TabIndex = 0
      Me.grbArchivoDestino.TabStop = False
      Me.grbArchivoDestino.Text = "Archivo destino..."
      '
      'btnArchivo
      '
      Me.btnArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnArchivo.ImageKey = "(none)"
      Me.btnArchivo.Location = New System.Drawing.Point(484, 17)
      Me.btnArchivo.Name = "btnArchivo"
      Me.btnArchivo.Size = New System.Drawing.Size(97, 40)
      Me.btnArchivo.TabIndex = 12
      Me.btnArchivo.Text = "&Examinar..."
      Me.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnArchivo.UseVisualStyleBackColor = True
      '
      'txtArchivoDestino
      '
      Me.txtArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtArchivoDestino.BindearPropiedadControl = ""
      Me.txtArchivoDestino.BindearPropiedadEntidad = ""
      Me.txtArchivoDestino.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoDestino.Formato = ""
      Me.txtArchivoDestino.IsDecimal = False
      Me.txtArchivoDestino.IsNumber = False
      Me.txtArchivoDestino.IsPK = False
      Me.txtArchivoDestino.IsRequired = False
      Me.txtArchivoDestino.Key = ""
      Me.txtArchivoDestino.LabelAsoc = Nothing
      Me.txtArchivoDestino.Location = New System.Drawing.Point(15, 28)
      Me.txtArchivoDestino.Name = "txtArchivoDestino"
      Me.txtArchivoDestino.ReadOnly = True
      Me.txtArchivoDestino.Size = New System.Drawing.Size(463, 20)
      Me.txtArchivoDestino.TabIndex = 11
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConfirmar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(597, 29)
      Me.tstBarra.TabIndex = 6
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbConfirmar
      '
      Me.tsbConfirmar.Image = Global.Eniac.Win.My.Resources.Resources.check2
      Me.tsbConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbConfirmar.Name = "tsbConfirmar"
      Me.tsbConfirmar.Size = New System.Drawing.Size(87, 26)
      Me.tsbConfirmar.Text = "&Confirmar"
      '
      'ArchivoDestinoExportacion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(597, 106)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbArchivoDestino)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "ArchivoDestinoExportacion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Destino"
      Me.grbArchivoDestino.ResumeLayout(False)
      Me.grbArchivoDestino.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbArchivoDestino As System.Windows.Forms.GroupBox
   Friend WithEvents btnArchivo As Eniac.Controles.Button
   Friend WithEvents txtArchivoDestino As Eniac.Controles.TextBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbConfirmar As System.Windows.Forms.ToolStripButton
End Class
