<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotivoNC
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMotivoNC))
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
        Me.cmbMotivo = New Eniac.Controles.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLetra = New System.Windows.Forms.TextBox()
        Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
        Me.txtIdTipoComprobante = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.tstBarra.Size = New System.Drawing.Size(406, 29)
        Me.tstBarra.TabIndex = 67
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
        'cmbMotivo
        '
        Me.cmbMotivo.BindearPropiedadControl = "SelectedValue"
        Me.cmbMotivo.BindearPropiedadEntidad = "ventas.idformaspago"
        Me.cmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMotivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMotivo.FormattingEnabled = True
        Me.cmbMotivo.IsPK = False
        Me.cmbMotivo.IsRequired = True
        Me.cmbMotivo.Key = Nothing
        Me.cmbMotivo.LabelAsoc = Nothing
        Me.cmbMotivo.Location = New System.Drawing.Point(87, 94)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(266, 21)
        Me.cmbMotivo.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Motivo:"
        '
        'txtLetra
        '
        Me.txtLetra.Enabled = False
        Me.txtLetra.Location = New System.Drawing.Point(218, 53)
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.Size = New System.Drawing.Size(44, 20)
        Me.txtLetra.TabIndex = 71
        Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.Enabled = False
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(268, 53)
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(87, 20)
        Me.txtNumeroComprobante.TabIndex = 70
        Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIdTipoComprobante
        '
        Me.txtIdTipoComprobante.Enabled = False
        Me.txtIdTipoComprobante.Location = New System.Drawing.Point(87, 53)
        Me.txtIdTipoComprobante.Name = "txtIdTipoComprobante"
        Me.txtIdTipoComprobante.Size = New System.Drawing.Size(125, 20)
        Me.txtIdTipoComprobante.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Documento"
        '
        'frmMotivoNC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 154)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbMotivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLetra)
        Me.Controls.Add(Me.txtNumeroComprobante)
        Me.Controls.Add(Me.txtIdTipoComprobante)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "frmMotivoNC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motivo NC"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbMotivo As Eniac.Controles.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLetra As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents txtIdTipoComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
