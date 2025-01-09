<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
   Inherits Eniac.Win.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.LabelCompanyName = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.txtTelefono = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.Label()
        Me.txtPaginaWeb = New System.Windows.Forms.LinkLabel()
        Me.txtCorreoElectronico = New System.Windows.Forms.LinkLabel()
        Me.TableLayoutPanel.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCompanyName, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 1, 9)
        Me.TableLayoutPanel.Controls.Add(Me.txtTelefono, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.txtDomicilio, 1, 6)
        Me.TableLayoutPanel.Controls.Add(Me.txtCelular, 1, 5)
        Me.TableLayoutPanel.Controls.Add(Me.txtPaginaWeb, 1, 8)
        Me.TableLayoutPanel.Controls.Add(Me.txtCorreoElectronico, 1, 7)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(9, 9)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 10
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(478, 386)
        Me.TableLayoutPanel.TabIndex = 1
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(3, 3)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 10)
        Me.LogoPictureBox.Size = New System.Drawing.Size(151, 380)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'LabelProductName
        '
        Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductName.Location = New System.Drawing.Point(163, 0)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(312, 17)
        Me.LabelProductName.TabIndex = 0
        Me.LabelProductName.Text = "Product Name"
        Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelVersion
        '
        Me.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelVersion.Location = New System.Drawing.Point(163, 38)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(312, 17)
        Me.LabelVersion.TabIndex = 0
        Me.LabelVersion.Text = "Version"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCopyright.Location = New System.Drawing.Point(163, 76)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(312, 17)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCompanyName.Location = New System.Drawing.Point(163, 114)
        Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCompanyName.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.Size = New System.Drawing.Size(312, 17)
        Me.LabelCompanyName.TabIndex = 0
        Me.LabelCompanyName.Text = "Company Name"
        Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(400, 360)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'txtTelefono
        '
        Me.txtTelefono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTelefono.Location = New System.Drawing.Point(163, 152)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.txtTelefono.MaximumSize = New System.Drawing.Size(0, 17)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(312, 17)
        Me.txtTelefono.TabIndex = 1
        Me.txtTelefono.Text = "Teléfonos: (0341) 430-0770 "
        '
        'txtDomicilio
        '
        Me.txtDomicilio.AutoSize = True
        Me.txtDomicilio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDomicilio.Location = New System.Drawing.Point(163, 228)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.txtDomicilio.MaximumSize = New System.Drawing.Size(0, 17)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(312, 17)
        Me.txtDomicilio.TabIndex = 3
        Me.txtDomicilio.Text = "Alsina 1070 P.B Rosario, Santa Fe"
        '
        'txtCelular
        '
        Me.txtCelular.AutoSize = True
        Me.txtCelular.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCelular.Location = New System.Drawing.Point(163, 190)
        Me.txtCelular.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.txtCelular.MaximumSize = New System.Drawing.Size(0, 17)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(312, 17)
        Me.txtCelular.TabIndex = 5
        Me.txtCelular.Text = "Celulares: (0341) 152-570900 / 155-767535"
        '
        'txtPaginaWeb
        '
        Me.txtPaginaWeb.AutoSize = True
        Me.txtPaginaWeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPaginaWeb.Location = New System.Drawing.Point(163, 304)
        Me.txtPaginaWeb.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.txtPaginaWeb.MaximumSize = New System.Drawing.Size(0, 17)
        Me.txtPaginaWeb.Name = "txtPaginaWeb"
        Me.txtPaginaWeb.Size = New System.Drawing.Size(312, 17)
        Me.txtPaginaWeb.TabIndex = 6
        Me.txtPaginaWeb.TabStop = True
        Me.txtPaginaWeb.Text = "www.sinergiasoftware.com.ar"
        '
        'txtCorreoElectronico
        '
        Me.txtCorreoElectronico.AutoSize = True
        Me.txtCorreoElectronico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCorreoElectronico.Location = New System.Drawing.Point(163, 266)
        Me.txtCorreoElectronico.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.txtCorreoElectronico.MaximumSize = New System.Drawing.Size(0, 17)
        Me.txtCorreoElectronico.Name = "txtCorreoElectronico"
        Me.txtCorreoElectronico.Size = New System.Drawing.Size(312, 17)
        Me.txtCorreoElectronico.TabIndex = 7
        Me.txtCorreoElectronico.TabStop = True
        Me.txtCorreoElectronico.Text = "soporte@sinergiasoftware.com.ar"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 404)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acerca de..."
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
   Friend WithEvents LabelProductName As System.Windows.Forms.Label
   Friend WithEvents LabelVersion As System.Windows.Forms.Label
   Friend WithEvents LabelCopyright As System.Windows.Forms.Label
   Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
   Friend WithEvents OKButton As System.Windows.Forms.Button
   Friend WithEvents txtTelefono As System.Windows.Forms.Label
   Friend WithEvents txtDomicilio As System.Windows.Forms.Label
   Friend WithEvents txtCelular As System.Windows.Forms.Label
   Friend WithEvents txtPaginaWeb As System.Windows.Forms.LinkLabel
   Friend WithEvents txtCorreoElectronico As System.Windows.Forms.LinkLabel

End Class
