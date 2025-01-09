<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VinculacionTokenML
    Inherits BaseForm

    'Form overrides dispose to clean up the component list.
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
        Me.btnInicializar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtToken = New System.Windows.Forms.TextBox()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.txtCodigoAutorizacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnInicializar
        '
        Me.btnInicializar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInicializar.Image = Global.Eniac.Win.My.Resources.Resources.exchange
        Me.btnInicializar.Location = New System.Drawing.Point(123, 41)
        Me.btnInicializar.Name = "btnInicializar"
        Me.btnInicializar.Size = New System.Drawing.Size(220, 67)
        Me.btnInicializar.TabIndex = 1
        Me.btnInicializar.Text = "Inicializar ML"
        Me.btnInicializar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInicializar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInicializar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Token Actual"
        '
        'txtToken
        '
        Me.txtToken.Location = New System.Drawing.Point(123, 151)
        Me.txtToken.Name = "txtToken"
        Me.txtToken.ReadOnly = True
        Me.txtToken.Size = New System.Drawing.Size(368, 20)
        Me.txtToken.TabIndex = 6
        Me.txtToken.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(503, 29)
        Me.tstBarra.TabIndex = 0
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(432, 115)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(60, 27)
        Me.btnEnviar.TabIndex = 4
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'txtCodigoAutorizacion
        '
        Me.txtCodigoAutorizacion.Location = New System.Drawing.Point(123, 118)
        Me.txtCodigoAutorizacion.Name = "txtCodigoAutorizacion"
        Me.txtCodigoAutorizacion.Size = New System.Drawing.Size(303, 20)
        Me.txtCodigoAutorizacion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código Autorizacion:"
        '
        'VinculacionTokenML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 180)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtCodigoAutorizacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.txtToken)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnInicializar)
        Me.Name = "VinculacionTokenML"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mercado Libre - Vinculacion Token"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInicializar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtToken As System.Windows.Forms.TextBox
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEnviar As Button
    Friend WithEvents txtCodigoAutorizacion As TextBox
    Friend WithEvents Label2 As Label
End Class
