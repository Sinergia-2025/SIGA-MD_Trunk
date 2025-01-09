<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArchivosAImprimirDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Me.txtNombreReporte = New Eniac.Controles.TextBox
      Me.lblNombreReporte = New Eniac.Controles.Label
      Me.txtReporteSecundario = New Eniac.Controles.TextBox
      Me.lblReporteSecundario = New Eniac.Controles.Label
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(458, 419)
      Me.btnAceptar.TabIndex = 2
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(544, 419)
      Me.btnCancelar.TabIndex = 3
      '
      'txtNombreReporte
      '
      Me.txtNombreReporte.BindearPropiedadControl = "Text"
      Me.txtNombreReporte.BindearPropiedadEntidad = "NombreReporteOriginal"
      Me.txtNombreReporte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreReporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreReporte.Formato = ""
      Me.txtNombreReporte.IsDecimal = False
      Me.txtNombreReporte.IsNumber = False
      Me.txtNombreReporte.IsPK = True
      Me.txtNombreReporte.IsRequired = True
      Me.txtNombreReporte.Key = ""
      Me.txtNombreReporte.LabelAsoc = Me.lblNombreReporte
      Me.txtNombreReporte.Location = New System.Drawing.Point(12, 38)
      Me.txtNombreReporte.MaxLength = 200
      Me.txtNombreReporte.Name = "txtNombreReporte"
      Me.txtNombreReporte.Size = New System.Drawing.Size(609, 20)
      Me.txtNombreReporte.TabIndex = 0
      '
      'lblNombreReporte
      '
      Me.lblNombreReporte.AutoSize = True
      Me.lblNombreReporte.Location = New System.Drawing.Point(12, 22)
      Me.lblNombreReporte.Name = "lblNombreReporte"
      Me.lblNombreReporte.Size = New System.Drawing.Size(83, 13)
      Me.lblNombreReporte.TabIndex = 4
      Me.lblNombreReporte.Text = "Reporte Original"
      '
      'txtReporteSecundario
      '
      Me.txtReporteSecundario.BindearPropiedadControl = "Text"
      Me.txtReporteSecundario.BindearPropiedadEntidad = "ReporteSecundario"
      Me.txtReporteSecundario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtReporteSecundario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtReporteSecundario.Formato = ""
      Me.txtReporteSecundario.IsDecimal = False
      Me.txtReporteSecundario.IsNumber = False
      Me.txtReporteSecundario.IsPK = False
      Me.txtReporteSecundario.IsRequired = True
      Me.txtReporteSecundario.Key = ""
      Me.txtReporteSecundario.LabelAsoc = Me.lblReporteSecundario
      Me.txtReporteSecundario.Location = New System.Drawing.Point(15, 87)
      Me.txtReporteSecundario.MaxLength = 100000
      Me.txtReporteSecundario.Multiline = True
      Me.txtReporteSecundario.Name = "txtReporteSecundario"
      Me.txtReporteSecundario.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtReporteSecundario.Size = New System.Drawing.Size(606, 326)
      Me.txtReporteSecundario.TabIndex = 1
      '
      'lblReporteSecundario
      '
      Me.lblReporteSecundario.AutoSize = True
      Me.lblReporteSecundario.Location = New System.Drawing.Point(15, 71)
      Me.lblReporteSecundario.Name = "lblReporteSecundario"
      Me.lblReporteSecundario.Size = New System.Drawing.Size(102, 13)
      Me.lblReporteSecundario.TabIndex = 5
      Me.lblReporteSecundario.Text = "Reporte Secundario"
      '
      'ArchivosAImprimirDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(633, 454)
      Me.Controls.Add(Me.txtReporteSecundario)
      Me.Controls.Add(Me.lblReporteSecundario)
      Me.Controls.Add(Me.txtNombreReporte)
      Me.Controls.Add(Me.lblNombreReporte)
      Me.Name = "ArchivosAImprimirDetalle"
      Me.Text = "Archivo a Imprimir"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblNombreReporte, 0)
      Me.Controls.SetChildIndex(Me.txtNombreReporte, 0)
      Me.Controls.SetChildIndex(Me.lblReporteSecundario, 0)
      Me.Controls.SetChildIndex(Me.txtReporteSecundario, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtNombreReporte As Eniac.Controles.TextBox
   Friend WithEvents lblNombreReporte As Eniac.Controles.Label
   Friend WithEvents txtReporteSecundario As Eniac.Controles.TextBox
   Friend WithEvents lblReporteSecundario As Eniac.Controles.Label
End Class
