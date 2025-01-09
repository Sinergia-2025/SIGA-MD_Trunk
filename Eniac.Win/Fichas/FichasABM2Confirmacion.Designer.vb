<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichasABM2Confirmacion
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FichasABM2Confirmacion))
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.btnGrabar = New Eniac.Controles.Button()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.lblFichaAnticipo = New Eniac.Controles.Label()
      Me.pnlFichaAnticipo = New System.Windows.Forms.Panel()
      Me.radFichaAnticipo_NO = New Eniac.Controles.RadioButton()
      Me.radFichaAnticipo_SI = New Eniac.Controles.RadioButton()
      Me.pnlFichaCliente = New System.Windows.Forms.Panel()
      Me.radFichaCliente_NO = New Eniac.Controles.RadioButton()
      Me.radFichaCliente_SI = New Eniac.Controles.RadioButton()
      Me.lblFichaCliente = New Eniac.Controles.Label()
      Me.pnlReemplazaFicha = New System.Windows.Forms.Panel()
      Me.radReemplazaFicha_NO = New Eniac.Controles.RadioButton()
      Me.radReemplazaFicha_SI = New Eniac.Controles.RadioButton()
      Me.lblReemplazaFicha = New Eniac.Controles.Label()
      Me.lblComprobante = New Eniac.Controles.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblImporteTotal = New Eniac.Controles.Label()
      Me.lblCliente = New Eniac.Controles.Label()
      Me.pnlFichaAnticipo.SuspendLayout()
      Me.pnlFichaCliente.SuspendLayout()
      Me.pnlReemplazaFicha.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "check2.ico")
      Me.imgGrabar.Images.SetKeyName(1, "delete2.ico")
      '
      'btnGrabar
      '
      Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGrabar.ImageKey = "check2.ico"
      Me.btnGrabar.ImageList = Me.imgGrabar
      Me.btnGrabar.Location = New System.Drawing.Point(182, 156)
      Me.btnGrabar.Name = "btnGrabar"
      Me.btnGrabar.Size = New System.Drawing.Size(85, 30)
      Me.btnGrabar.TabIndex = 6
      Me.btnGrabar.Text = "Grabar"
      Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGrabar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgGrabar
      Me.btnCancelar.Location = New System.Drawing.Point(273, 156)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 7
      Me.btnCancelar.Text = "Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'lblFichaAnticipo
      '
      Me.lblFichaAnticipo.AutoSize = True
      Me.lblFichaAnticipo.Location = New System.Drawing.Point(0, 0)
      Me.lblFichaAnticipo.Margin = New System.Windows.Forms.Padding(0)
      Me.lblFichaAnticipo.Name = "lblFichaAnticipo"
      Me.lblFichaAnticipo.Size = New System.Drawing.Size(150, 13)
      Me.lblFichaAnticipo.TabIndex = 0
      Me.lblFichaAnticipo.Text = "¿Imprimir la ficha y el anticipo?"
      '
      'pnlFichaAnticipo
      '
      Me.pnlFichaAnticipo.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.pnlFichaAnticipo.AutoSize = True
      Me.pnlFichaAnticipo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlFichaAnticipo.Controls.Add(Me.radFichaAnticipo_NO)
      Me.pnlFichaAnticipo.Controls.Add(Me.radFichaAnticipo_SI)
      Me.pnlFichaAnticipo.Controls.Add(Me.lblFichaAnticipo)
      Me.pnlFichaAnticipo.Location = New System.Drawing.Point(59, 77)
      Me.pnlFichaAnticipo.Name = "pnlFichaAnticipo"
      Me.pnlFichaAnticipo.Size = New System.Drawing.Size(258, 15)
      Me.pnlFichaAnticipo.TabIndex = 3
      '
      'radFichaAnticipo_NO
      '
      Me.radFichaAnticipo_NO.AutoSize = True
      Me.radFichaAnticipo_NO.BindearPropiedadControl = Nothing
      Me.radFichaAnticipo_NO.BindearPropiedadEntidad = Nothing
      Me.radFichaAnticipo_NO.ForeColorFocus = System.Drawing.Color.Red
      Me.radFichaAnticipo_NO.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.radFichaAnticipo_NO.IsPK = False
      Me.radFichaAnticipo_NO.IsRequired = False
      Me.radFichaAnticipo_NO.Key = Nothing
      Me.radFichaAnticipo_NO.LabelAsoc = Nothing
      Me.radFichaAnticipo_NO.Location = New System.Drawing.Point(219, -2)
      Me.radFichaAnticipo_NO.Margin = New System.Windows.Forms.Padding(0)
      Me.radFichaAnticipo_NO.Name = "radFichaAnticipo_NO"
      Me.radFichaAnticipo_NO.Size = New System.Drawing.Size(39, 17)
      Me.radFichaAnticipo_NO.TabIndex = 2
      Me.radFichaAnticipo_NO.Text = "No"
      Me.radFichaAnticipo_NO.UseVisualStyleBackColor = True
      '
      'radFichaAnticipo_SI
      '
      Me.radFichaAnticipo_SI.AutoSize = True
      Me.radFichaAnticipo_SI.BindearPropiedadControl = Nothing
      Me.radFichaAnticipo_SI.BindearPropiedadEntidad = Nothing
      Me.radFichaAnticipo_SI.Checked = True
      Me.radFichaAnticipo_SI.ForeColorFocus = System.Drawing.Color.Red
      Me.radFichaAnticipo_SI.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.radFichaAnticipo_SI.IsPK = False
      Me.radFichaAnticipo_SI.IsRequired = False
      Me.radFichaAnticipo_SI.Key = Nothing
      Me.radFichaAnticipo_SI.LabelAsoc = Nothing
      Me.radFichaAnticipo_SI.Location = New System.Drawing.Point(179, -2)
      Me.radFichaAnticipo_SI.Margin = New System.Windows.Forms.Padding(0)
      Me.radFichaAnticipo_SI.Name = "radFichaAnticipo_SI"
      Me.radFichaAnticipo_SI.Size = New System.Drawing.Size(34, 17)
      Me.radFichaAnticipo_SI.TabIndex = 1
      Me.radFichaAnticipo_SI.TabStop = True
      Me.radFichaAnticipo_SI.Text = "Si"
      Me.radFichaAnticipo_SI.UseVisualStyleBackColor = True
      '
      'pnlFichaCliente
      '
      Me.pnlFichaCliente.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.pnlFichaCliente.AutoSize = True
      Me.pnlFichaCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlFichaCliente.Controls.Add(Me.radFichaCliente_NO)
      Me.pnlFichaCliente.Controls.Add(Me.radFichaCliente_SI)
      Me.pnlFichaCliente.Controls.Add(Me.lblFichaCliente)
      Me.pnlFichaCliente.Location = New System.Drawing.Point(59, 98)
      Me.pnlFichaCliente.Name = "pnlFichaCliente"
      Me.pnlFichaCliente.Size = New System.Drawing.Size(258, 15)
      Me.pnlFichaCliente.TabIndex = 4
      '
      'radFichaCliente_NO
      '
      Me.radFichaCliente_NO.AutoSize = True
      Me.radFichaCliente_NO.BindearPropiedadControl = Nothing
      Me.radFichaCliente_NO.BindearPropiedadEntidad = Nothing
      Me.radFichaCliente_NO.ForeColorFocus = System.Drawing.Color.Red
      Me.radFichaCliente_NO.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.radFichaCliente_NO.IsPK = False
      Me.radFichaCliente_NO.IsRequired = False
      Me.radFichaCliente_NO.Key = Nothing
      Me.radFichaCliente_NO.LabelAsoc = Nothing
      Me.radFichaCliente_NO.Location = New System.Drawing.Point(219, -2)
      Me.radFichaCliente_NO.Margin = New System.Windows.Forms.Padding(0)
      Me.radFichaCliente_NO.Name = "radFichaCliente_NO"
      Me.radFichaCliente_NO.Size = New System.Drawing.Size(39, 17)
      Me.radFichaCliente_NO.TabIndex = 2
      Me.radFichaCliente_NO.Text = "No"
      Me.radFichaCliente_NO.UseVisualStyleBackColor = True
      '
      'radFichaCliente_SI
      '
      Me.radFichaCliente_SI.AutoSize = True
      Me.radFichaCliente_SI.BindearPropiedadControl = Nothing
      Me.radFichaCliente_SI.BindearPropiedadEntidad = Nothing
      Me.radFichaCliente_SI.Checked = True
      Me.radFichaCliente_SI.ForeColorFocus = System.Drawing.Color.Red
      Me.radFichaCliente_SI.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.radFichaCliente_SI.IsPK = False
      Me.radFichaCliente_SI.IsRequired = False
      Me.radFichaCliente_SI.Key = Nothing
      Me.radFichaCliente_SI.LabelAsoc = Nothing
      Me.radFichaCliente_SI.Location = New System.Drawing.Point(179, -2)
      Me.radFichaCliente_SI.Margin = New System.Windows.Forms.Padding(0)
      Me.radFichaCliente_SI.Name = "radFichaCliente_SI"
      Me.radFichaCliente_SI.Size = New System.Drawing.Size(34, 17)
      Me.radFichaCliente_SI.TabIndex = 1
      Me.radFichaCliente_SI.TabStop = True
      Me.radFichaCliente_SI.Text = "Si"
      Me.radFichaCliente_SI.UseVisualStyleBackColor = True
      '
      'lblFichaCliente
      '
      Me.lblFichaCliente.AutoSize = True
      Me.lblFichaCliente.Location = New System.Drawing.Point(0, 0)
      Me.lblFichaCliente.Margin = New System.Windows.Forms.Padding(0)
      Me.lblFichaCliente.Name = "lblFichaCliente"
      Me.lblFichaCliente.Size = New System.Drawing.Size(160, 13)
      Me.lblFichaCliente.TabIndex = 0
      Me.lblFichaCliente.Text = "¿Imprimir la ficha para el cliente?"
      '
      'pnlReemplazaFicha
      '
      Me.pnlReemplazaFicha.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.pnlReemplazaFicha.AutoSize = True
      Me.pnlReemplazaFicha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlReemplazaFicha.Controls.Add(Me.radReemplazaFicha_NO)
      Me.pnlReemplazaFicha.Controls.Add(Me.radReemplazaFicha_SI)
      Me.pnlReemplazaFicha.Controls.Add(Me.lblReemplazaFicha)
      Me.pnlReemplazaFicha.Location = New System.Drawing.Point(59, 119)
      Me.pnlReemplazaFicha.Name = "pnlReemplazaFicha"
      Me.pnlReemplazaFicha.Size = New System.Drawing.Size(258, 15)
      Me.pnlReemplazaFicha.TabIndex = 5
      '
      'radReemplazaFicha_NO
      '
      Me.radReemplazaFicha_NO.AutoSize = True
      Me.radReemplazaFicha_NO.BindearPropiedadControl = Nothing
      Me.radReemplazaFicha_NO.BindearPropiedadEntidad = Nothing
      Me.radReemplazaFicha_NO.Checked = True
      Me.radReemplazaFicha_NO.ForeColorFocus = System.Drawing.Color.Red
      Me.radReemplazaFicha_NO.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.radReemplazaFicha_NO.IsPK = False
      Me.radReemplazaFicha_NO.IsRequired = False
      Me.radReemplazaFicha_NO.Key = Nothing
      Me.radReemplazaFicha_NO.LabelAsoc = Nothing
      Me.radReemplazaFicha_NO.Location = New System.Drawing.Point(219, -2)
      Me.radReemplazaFicha_NO.Margin = New System.Windows.Forms.Padding(0)
      Me.radReemplazaFicha_NO.Name = "radReemplazaFicha_NO"
      Me.radReemplazaFicha_NO.Size = New System.Drawing.Size(39, 17)
      Me.radReemplazaFicha_NO.TabIndex = 2
      Me.radReemplazaFicha_NO.TabStop = True
      Me.radReemplazaFicha_NO.Text = "No"
      Me.radReemplazaFicha_NO.UseVisualStyleBackColor = True
      '
      'radReemplazaFicha_SI
      '
      Me.radReemplazaFicha_SI.AutoSize = True
      Me.radReemplazaFicha_SI.BindearPropiedadControl = Nothing
      Me.radReemplazaFicha_SI.BindearPropiedadEntidad = Nothing
      Me.radReemplazaFicha_SI.ForeColorFocus = System.Drawing.Color.Red
      Me.radReemplazaFicha_SI.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.radReemplazaFicha_SI.IsPK = False
      Me.radReemplazaFicha_SI.IsRequired = False
      Me.radReemplazaFicha_SI.Key = Nothing
      Me.radReemplazaFicha_SI.LabelAsoc = Nothing
      Me.radReemplazaFicha_SI.Location = New System.Drawing.Point(179, -2)
      Me.radReemplazaFicha_SI.Margin = New System.Windows.Forms.Padding(0)
      Me.radReemplazaFicha_SI.Name = "radReemplazaFicha_SI"
      Me.radReemplazaFicha_SI.Size = New System.Drawing.Size(34, 17)
      Me.radReemplazaFicha_SI.TabIndex = 1
      Me.radReemplazaFicha_SI.Text = "Si"
      Me.radReemplazaFicha_SI.UseVisualStyleBackColor = True
      '
      'lblReemplazaFicha
      '
      Me.lblReemplazaFicha.AutoSize = True
      Me.lblReemplazaFicha.Location = New System.Drawing.Point(0, 0)
      Me.lblReemplazaFicha.Margin = New System.Windows.Forms.Padding(0)
      Me.lblReemplazaFicha.Name = "lblReemplazaFicha"
      Me.lblReemplazaFicha.Size = New System.Drawing.Size(179, 13)
      Me.lblReemplazaFicha.TabIndex = 0
      Me.lblReemplazaFicha.Text = "¿Realizar el reemplazo de la FICHA?"
      '
      'lblComprobante
      '
      Me.lblComprobante.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.lblComprobante.AutoSize = True
      Me.lblComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblComprobante.Location = New System.Drawing.Point(102, 9)
      Me.lblComprobante.Name = "lblComprobante"
      Me.lblComprobante.Size = New System.Drawing.Size(165, 17)
      Me.lblComprobante.TabIndex = 0
      Me.lblComprobante.Text = "FICHA X 0001-00000001"
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.lblImporteTotal)
      Me.Panel1.Controls.Add(Me.lblCliente)
      Me.Panel1.Controls.Add(Me.pnlFichaCliente)
      Me.Panel1.Controls.Add(Me.btnGrabar)
      Me.Panel1.Controls.Add(Me.lblComprobante)
      Me.Panel1.Controls.Add(Me.btnCancelar)
      Me.Panel1.Controls.Add(Me.pnlFichaAnticipo)
      Me.Panel1.Controls.Add(Me.pnlReemplazaFicha)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(370, 198)
      Me.Panel1.TabIndex = 0
      '
      'lblImporteTotal
      '
      Me.lblImporteTotal.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.lblImporteTotal.AutoSize = True
      Me.lblImporteTotal.Location = New System.Drawing.Point(9, 51)
      Me.lblImporteTotal.Name = "lblImporteTotal"
      Me.lblImporteTotal.Size = New System.Drawing.Size(110, 13)
      Me.lblImporteTotal.TabIndex = 2
      Me.lblImporteTotal.Text = "Importe total: 5000.00"
      '
      'lblCliente
      '
      Me.lblCliente.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.lblCliente.AutoSize = True
      Me.lblCliente.Location = New System.Drawing.Point(9, 32)
      Me.lblCliente.Name = "lblCliente"
      Me.lblCliente.Size = New System.Drawing.Size(85, 13)
      Me.lblCliente.TabIndex = 1
      Me.lblCliente.Text = "Cliente: Juancito"
      '
      'FichasABM2Confirmacion
      '
      Me.AcceptButton = Me.btnGrabar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(370, 198)
      Me.ControlBox = False
      Me.Controls.Add(Me.Panel1)
      Me.Name = "FichasABM2Confirmacion"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Fichas - Grabación exitosa"
      Me.pnlFichaAnticipo.ResumeLayout(False)
      Me.pnlFichaAnticipo.PerformLayout()
      Me.pnlFichaCliente.ResumeLayout(False)
      Me.pnlFichaCliente.PerformLayout()
      Me.pnlReemplazaFicha.ResumeLayout(False)
      Me.pnlReemplazaFicha.PerformLayout()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents btnGrabar As Eniac.Controles.Button
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents lblFichaAnticipo As Eniac.Controles.Label
   Friend WithEvents pnlFichaAnticipo As System.Windows.Forms.Panel
   Friend WithEvents radFichaAnticipo_NO As Eniac.Controles.RadioButton
   Friend WithEvents radFichaAnticipo_SI As Eniac.Controles.RadioButton
   Friend WithEvents pnlFichaCliente As System.Windows.Forms.Panel
   Friend WithEvents radFichaCliente_NO As Eniac.Controles.RadioButton
   Friend WithEvents radFichaCliente_SI As Eniac.Controles.RadioButton
   Friend WithEvents lblFichaCliente As Eniac.Controles.Label
   Friend WithEvents pnlReemplazaFicha As System.Windows.Forms.Panel
   Friend WithEvents radReemplazaFicha_NO As Eniac.Controles.RadioButton
   Friend WithEvents radReemplazaFicha_SI As Eniac.Controles.RadioButton
   Friend WithEvents lblReemplazaFicha As Eniac.Controles.Label
   Friend WithEvents lblComprobante As Eniac.Controles.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblImporteTotal As Eniac.Controles.Label
   Friend WithEvents lblCliente As Eniac.Controles.Label
End Class
