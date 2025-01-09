<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarOtros
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.stsStado = New System.Windows.Forms.StatusStrip
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel
      Me.grbConsulta01 = New System.Windows.Forms.GroupBox
      Me.txtCantidadMaxRegistrosDetalle = New Eniac.Controles.TextBox
      Me.btnConsultarCantMaxRegDet = New Eniac.Controles.Button
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.grbConsulta01.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(254, 29)
      Me.tstBarra.TabIndex = 2
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(64, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 130)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(254, 22)
      Me.stsStado.TabIndex = 3
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(239, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(0, 17)
      '
      'grbConsulta01
      '
      Me.grbConsulta01.Controls.Add(Me.txtCantidadMaxRegistrosDetalle)
      Me.grbConsulta01.Controls.Add(Me.btnConsultarCantMaxRegDet)
      Me.grbConsulta01.Location = New System.Drawing.Point(12, 37)
      Me.grbConsulta01.Name = "grbConsulta01"
      Me.grbConsulta01.Size = New System.Drawing.Size(209, 90)
      Me.grbConsulta01.TabIndex = 0
      Me.grbConsulta01.TabStop = False
      Me.grbConsulta01.Text = "Cantidad máxima de registros de detalle"
      '
      'txtCantidadMaxRegistrosDetalle
      '
      Me.txtCantidadMaxRegistrosDetalle.BindearPropiedadControl = Nothing
      Me.txtCantidadMaxRegistrosDetalle.BindearPropiedadEntidad = Nothing
      Me.txtCantidadMaxRegistrosDetalle.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadMaxRegistrosDetalle.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadMaxRegistrosDetalle.Formato = ""
      Me.txtCantidadMaxRegistrosDetalle.IsDecimal = False
      Me.txtCantidadMaxRegistrosDetalle.IsNumber = False
      Me.txtCantidadMaxRegistrosDetalle.IsPK = False
      Me.txtCantidadMaxRegistrosDetalle.IsRequired = False
      Me.txtCantidadMaxRegistrosDetalle.Key = ""
      Me.txtCantidadMaxRegistrosDetalle.LabelAsoc = Nothing
      Me.txtCantidadMaxRegistrosDetalle.Location = New System.Drawing.Point(108, 40)
      Me.txtCantidadMaxRegistrosDetalle.Name = "txtCantidadMaxRegistrosDetalle"
      Me.txtCantidadMaxRegistrosDetalle.ReadOnly = True
      Me.txtCantidadMaxRegistrosDetalle.Size = New System.Drawing.Size(95, 20)
      Me.txtCantidadMaxRegistrosDetalle.TabIndex = 1
      Me.txtCantidadMaxRegistrosDetalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnConsultarCantMaxRegDet
      '
      Me.btnConsultarCantMaxRegDet.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultarCantMaxRegDet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultarCantMaxRegDet.Location = New System.Drawing.Point(6, 28)
      Me.btnConsultarCantMaxRegDet.Name = "btnConsultarCantMaxRegDet"
      Me.btnConsultarCantMaxRegDet.Size = New System.Drawing.Size(96, 45)
      Me.btnConsultarCantMaxRegDet.TabIndex = 0
      Me.btnConsultarCantMaxRegDet.Text = "&Obtener"
      Me.btnConsultarCantMaxRegDet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultarCantMaxRegDet.UseVisualStyleBackColor = True
      '
      'ConsultarOtros
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(254, 152)
      Me.Controls.Add(Me.grbConsulta01)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "ConsultarOtros"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar Otros (interno)"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.grbConsulta01.ResumeLayout(False)
      Me.grbConsulta01.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbConsulta01 As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultarCantMaxRegDet As Eniac.Controles.Button
   Friend WithEvents txtCantidadMaxRegistrosDetalle As Eniac.Controles.TextBox
End Class
