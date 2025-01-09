<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VincularDispositivos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VincularDispositivos))
      Me.grpVincularOficina = New System.Windows.Forms.GroupBox()
      Me.pnlVincularOficina = New System.Windows.Forms.Panel()
      Me.grpVincularCobranza = New System.Windows.Forms.GroupBox()
      Me.pnlVincularCobranza = New System.Windows.Forms.Panel()
      Me.grpVincularPedido = New System.Windows.Forms.GroupBox()
      Me.pnlVincularPedido = New System.Windows.Forms.Panel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbSincronicionAutomatica = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.btnCopiarOficina = New System.Windows.Forms.Button()
      Me.btnCopiarCobranza = New System.Windows.Forms.Button()
      Me.btnCopiarPedido = New System.Windows.Forms.Button()
        Me.grpVincularOficina.SuspendLayout()
        Me.grpVincularCobranza.SuspendLayout()
        Me.grpVincularPedido.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpVincularOficina
        '
        Me.grpVincularOficina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.grpVincularOficina.Controls.Add(Me.pnlVincularOficina)
        Me.grpVincularOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpVincularOficina.Location = New System.Drawing.Point(12, 44)
        Me.grpVincularOficina.Name = "grpVincularOficina"
        Me.grpVincularOficina.Size = New System.Drawing.Size(192, 192)
        Me.grpVincularOficina.TabIndex = 7
        Me.grpVincularOficina.TabStop = False
        Me.grpVincularOficina.Text = "Sinergia Oficina"
        '
        'pnlVincularOficina
        '
        Me.pnlVincularOficina.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.delete2
        Me.pnlVincularOficina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlVincularOficina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVincularOficina.Location = New System.Drawing.Point(3, 22)
        Me.pnlVincularOficina.Name = "pnlVincularOficina"
        Me.pnlVincularOficina.Size = New System.Drawing.Size(186, 167)
        Me.pnlVincularOficina.TabIndex = 0
        '
        'grpVincularCobranza
        '
        Me.grpVincularCobranza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.grpVincularCobranza.Controls.Add(Me.pnlVincularCobranza)
        Me.grpVincularCobranza.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpVincularCobranza.Location = New System.Drawing.Point(346, 44)
        Me.grpVincularCobranza.Name = "grpVincularCobranza"
        Me.grpVincularCobranza.Size = New System.Drawing.Size(192, 192)
        Me.grpVincularCobranza.TabIndex = 8
        Me.grpVincularCobranza.TabStop = False
        Me.grpVincularCobranza.Text = "Sinergia Cobranza"
        '
        'pnlVincularCobranza
        '
        Me.pnlVincularCobranza.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.delete2
        Me.pnlVincularCobranza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlVincularCobranza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVincularCobranza.Location = New System.Drawing.Point(3, 22)
        Me.pnlVincularCobranza.Name = "pnlVincularCobranza"
        Me.pnlVincularCobranza.Size = New System.Drawing.Size(186, 167)
        Me.pnlVincularCobranza.TabIndex = 0
        '
        'grpVincularPedido
        '
        Me.grpVincularPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.grpVincularPedido.Controls.Add(Me.pnlVincularPedido)
        Me.grpVincularPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpVincularPedido.Location = New System.Drawing.Point(680, 44)
        Me.grpVincularPedido.Name = "grpVincularPedido"
        Me.grpVincularPedido.Size = New System.Drawing.Size(192, 192)
        Me.grpVincularPedido.TabIndex = 8
        Me.grpVincularPedido.TabStop = False
        Me.grpVincularPedido.Text = "Sinergia Pedido"
        '
        'pnlVincularPedido
        '
        Me.pnlVincularPedido.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.delete2
        Me.pnlVincularPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlVincularPedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVincularPedido.Location = New System.Drawing.Point(3, 22)
        Me.pnlVincularPedido.Name = "pnlVincularPedido"
        Me.pnlVincularPedido.Size = New System.Drawing.Size(186, 167)
        Me.pnlVincularPedido.TabIndex = 0
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbSincronicionAutomatica, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(884, 29)
        Me.tstBarra.TabIndex = 9
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'tsbSincronicionAutomatica
        '
        Me.tsbSincronicionAutomatica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSincronicionAutomatica.Image = CType(resources.GetObject("tsbSincronicionAutomatica.Image"), System.Drawing.Image)
        Me.tsbSincronicionAutomatica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSincronicionAutomatica.Name = "tsbSincronicionAutomatica"
        Me.tsbSincronicionAutomatica.Size = New System.Drawing.Size(113, 26)
        Me.tsbSincronicionAutomatica.Text = "Sincronizar Soporte"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'btnCopiarOficina
        '
        Me.btnCopiarOficina.Location = New System.Drawing.Point(15, 239)
        Me.btnCopiarOficina.Name = "btnCopiarOficina"
        Me.btnCopiarOficina.Size = New System.Drawing.Size(93, 23)
        Me.btnCopiarOficina.TabIndex = 10
        Me.btnCopiarOficina.Text = "Copiar Oficina"
        Me.btnCopiarOficina.UseVisualStyleBackColor = True
        '
        'btnCopiarCobranza
        '
        Me.btnCopiarCobranza.Location = New System.Drawing.Point(346, 239)
        Me.btnCopiarCobranza.Name = "btnCopiarCobranza"
        Me.btnCopiarCobranza.Size = New System.Drawing.Size(93, 23)
        Me.btnCopiarCobranza.TabIndex = 11
        Me.btnCopiarCobranza.Text = "Copiar Cobranza"
        Me.btnCopiarCobranza.UseVisualStyleBackColor = True
        '
        'btnCopiarPedido
        '
        Me.btnCopiarPedido.Location = New System.Drawing.Point(683, 239)
        Me.btnCopiarPedido.Name = "btnCopiarPedido"
        Me.btnCopiarPedido.Size = New System.Drawing.Size(93, 23)
        Me.btnCopiarPedido.TabIndex = 12
        Me.btnCopiarPedido.Text = "Copiar Pedido"
        Me.btnCopiarPedido.UseVisualStyleBackColor = True
        '
        'VincularDispositivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 266)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCopiarPedido)
        Me.Controls.Add(Me.btnCopiarCobranza)
        Me.Controls.Add(Me.btnCopiarOficina)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grpVincularPedido)
        Me.Controls.Add(Me.grpVincularCobranza)
        Me.Controls.Add(Me.grpVincularOficina)
        Me.MinimumSize = New System.Drawing.Size(643, 283)
        Me.Name = "VincularDispositivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vincular Dispositivos"
        Me.grpVincularOficina.ResumeLayout(False)
        Me.grpVincularCobranza.ResumeLayout(False)
        Me.grpVincularPedido.ResumeLayout(False)
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpVincularOficina As System.Windows.Forms.GroupBox
   Friend WithEvents pnlVincularOficina As System.Windows.Forms.Panel
   Friend WithEvents grpVincularCobranza As System.Windows.Forms.GroupBox
   Friend WithEvents pnlVincularCobranza As System.Windows.Forms.Panel
   Friend WithEvents grpVincularPedido As System.Windows.Forms.GroupBox
   Friend WithEvents pnlVincularPedido As System.Windows.Forms.Panel
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnCopiarOficina As System.Windows.Forms.Button
   Friend WithEvents btnCopiarCobranza As System.Windows.Forms.Button
   Friend WithEvents btnCopiarPedido As System.Windows.Forms.Button
   Friend WithEvents tsbSincronicionAutomatica As System.Windows.Forms.ToolStripButton
End Class
