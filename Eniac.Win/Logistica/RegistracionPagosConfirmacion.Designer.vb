<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistracionPagosConfirmacion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistracionPagosConfirmacion))
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.chbSolicitarCae = New System.Windows.Forms.CheckBox()
      Me.lblSolicitarCae = New Eniac.Controles.Label()
      Me.chbResumenDetallado = New System.Windows.Forms.CheckBox()
      Me.chbResumen = New System.Windows.Forms.CheckBox()
      Me.lblFichaCliente = New Eniac.Controles.Label()
      Me.lblFichaAnticipo = New Eniac.Controles.Label()
      Me.btnGrabar = New Eniac.Controles.Button()
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.lblComprobante = New Eniac.Controles.Label()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.pnlReemplazaFicha = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chbSolicitarCae)
        Me.Panel1.Controls.Add(Me.lblSolicitarCae)
        Me.Panel1.Controls.Add(Me.chbResumenDetallado)
        Me.Panel1.Controls.Add(Me.chbResumen)
        Me.Panel1.Controls.Add(Me.lblFichaCliente)
        Me.Panel1.Controls.Add(Me.lblFichaAnticipo)
        Me.Panel1.Controls.Add(Me.btnGrabar)
        Me.Panel1.Controls.Add(Me.lblComprobante)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.pnlReemplazaFicha)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(345, 188)
        Me.Panel1.TabIndex = 1
        '
        'chbSolicitarCae
        '
        Me.chbSolicitarCae.AutoSize = True
        Me.chbSolicitarCae.Location = New System.Drawing.Point(229, 104)
        Me.chbSolicitarCae.Name = "chbSolicitarCae"
        Me.chbSolicitarCae.Size = New System.Drawing.Size(15, 14)
        Me.chbSolicitarCae.TabIndex = 11
        Me.chbSolicitarCae.UseVisualStyleBackColor = True
        '
        'lblSolicitarCae
        '
        Me.lblSolicitarCae.AutoSize = True
        Me.lblSolicitarCae.LabelAsoc = Nothing
        Me.lblSolicitarCae.Location = New System.Drawing.Point(68, 105)
        Me.lblSolicitarCae.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSolicitarCae.Name = "lblSolicitarCae"
        Me.lblSolicitarCae.Size = New System.Drawing.Size(68, 13)
        Me.lblSolicitarCae.TabIndex = 10
        Me.lblSolicitarCae.Text = "Solicitar CAE"
        '
        'chbResumenDetallado
        '
        Me.chbResumenDetallado.AutoSize = True
        Me.chbResumenDetallado.Location = New System.Drawing.Point(229, 77)
        Me.chbResumenDetallado.Name = "chbResumenDetallado"
        Me.chbResumenDetallado.Size = New System.Drawing.Size(15, 14)
        Me.chbResumenDetallado.TabIndex = 9
        Me.chbResumenDetallado.UseVisualStyleBackColor = True
        '
        'chbResumen
        '
        Me.chbResumen.AutoSize = True
        Me.chbResumen.Location = New System.Drawing.Point(229, 50)
        Me.chbResumen.Name = "chbResumen"
        Me.chbResumen.Size = New System.Drawing.Size(15, 14)
        Me.chbResumen.TabIndex = 8
        Me.chbResumen.UseVisualStyleBackColor = True
        '
        'lblFichaCliente
        '
        Me.lblFichaCliente.AutoSize = True
        Me.lblFichaCliente.LabelAsoc = Nothing
        Me.lblFichaCliente.Location = New System.Drawing.Point(68, 78)
        Me.lblFichaCliente.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFichaCliente.Name = "lblFichaCliente"
        Me.lblFichaCliente.Size = New System.Drawing.Size(138, 13)
        Me.lblFichaCliente.TabIndex = 0
        Me.lblFichaCliente.Text = "Imprimir Resumen Detallado"
        '
        'lblFichaAnticipo
        '
        Me.lblFichaAnticipo.AutoSize = True
        Me.lblFichaAnticipo.LabelAsoc = Nothing
        Me.lblFichaAnticipo.Location = New System.Drawing.Point(68, 51)
        Me.lblFichaAnticipo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFichaAnticipo.Name = "lblFichaAnticipo"
        Me.lblFichaAnticipo.Size = New System.Drawing.Size(90, 13)
        Me.lblFichaAnticipo.TabIndex = 0
        Me.lblFichaAnticipo.Text = "Imprimir Resumen"
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.ImageKey = "check2.ico"
        Me.btnGrabar.ImageList = Me.imgGrabar
        Me.btnGrabar.Location = New System.Drawing.Point(157, 146)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(85, 30)
        Me.btnGrabar.TabIndex = 6
        Me.btnGrabar.Text = "Imprimir"
        Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'imgGrabar
        '
        Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
        Me.imgGrabar.Images.SetKeyName(0, "check2.ico")
        Me.imgGrabar.Images.SetKeyName(1, "delete2.ico")
        '
        'lblComprobante
        '
        Me.lblComprobante.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblComprobante.AutoSize = True
        Me.lblComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.LabelAsoc = Nothing
        Me.lblComprobante.Location = New System.Drawing.Point(15, 9)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(320, 17)
        Me.lblComprobante.TabIndex = 0
        Me.lblComprobante.Text = "REGISTRACIÓN DE PAGOS CONTRA ENTREGA"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageKey = "delete2.ico"
        Me.btnCancelar.ImageList = Me.imgGrabar
        Me.btnCancelar.Location = New System.Drawing.Point(248, 146)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pnlReemplazaFicha
        '
        Me.pnlReemplazaFicha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlReemplazaFicha.AutoSize = True
        Me.pnlReemplazaFicha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlReemplazaFicha.Location = New System.Drawing.Point(108, 64)
        Me.pnlReemplazaFicha.Name = "pnlReemplazaFicha"
        Me.pnlReemplazaFicha.Size = New System.Drawing.Size(0, 0)
        Me.pnlReemplazaFicha.TabIndex = 5
        '
        'RegistracionPagosConfirmacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 188)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "RegistracionPagosConfirmacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registración de Pagos Exitoso"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblFichaCliente As Eniac.Controles.Label
   Friend WithEvents btnGrabar As Eniac.Controles.Button
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents lblFichaAnticipo As Eniac.Controles.Label
   Friend WithEvents pnlReemplazaFicha As System.Windows.Forms.Panel
   Friend WithEvents lblComprobante As Eniac.Controles.Label
   Friend WithEvents chbResumenDetallado As System.Windows.Forms.CheckBox
   Friend WithEvents chbResumen As System.Windows.Forms.CheckBox
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents chbSolicitarCae As CheckBox
   Friend WithEvents lblSolicitarCae As Controles.Label
End Class
