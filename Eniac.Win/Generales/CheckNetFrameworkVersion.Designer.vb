<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckNetFrameworkVersion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckNetFrameworkVersion))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.CopiarLinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
      Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
      Me.lblTecnicoConfianza = New System.Windows.Forms.Label()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(160, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 20, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(664, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Se detectó que no tiene instalada la versión 4.8 de .Net Framework o posterior"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(21, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 20, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(943, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "A partir del 01/02/2024 será requerida dicha versión o superior para que SIGA con" &
    "tinúe funcionando"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarLinkToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(135, 26)
        '
        'CopiarLinkToolStripMenuItem
        '
        Me.CopiarLinkToolStripMenuItem.Name = "CopiarLinkToolStripMenuItem"
        Me.CopiarLinkToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.CopiarLinkToolStripMenuItem.Text = "Copiar Link"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(199, 117)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 20, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(586, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Puede descargar la versión 4.8 de .Net Framework del siguiente link:"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 308)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 10)
        Me.Panel1.TabIndex = 2
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LinkLabel2.Location = New System.Drawing.Point(185, 205)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(3, 20, 3, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(614, 24)
        Me.LinkLabel2.TabIndex = 3
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = "https://support.microsoft.com/es-es/topic/instalador-sin-conexi%C3%B3n-de-microso" &
    "ft-net-framework-4-8-para-windows-9d23f658-3b97-68ab-d013-aa3c3e7495e0"
        Me.LinkLabel2.Text = "Instalador sin conexión de Microsoft .NET Framework 4.8 para Windows"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.ContextMenuStrip = Me.ContextMenuStrip1
        Me.LinkLabel3.Location = New System.Drawing.Point(330, 161)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(3, 20, 3, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(324, 24)
        Me.LinkLabel3.TabIndex = 3
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "https://dotnet.microsoft.com/en-us/download/dotnet-framework"
        Me.LinkLabel3.Text = "Download Microsoft .NET Framework"
        '
        'lblTecnicoConfianza
        '
        Me.lblTecnicoConfianza.AutoSize = True
        Me.lblTecnicoConfianza.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTecnicoConfianza.ForeColor = System.Drawing.Color.Red
        Me.lblTecnicoConfianza.Location = New System.Drawing.Point(189, 249)
        Me.lblTecnicoConfianza.Margin = New System.Windows.Forms.Padding(3, 20, 3, 0)
        Me.lblTecnicoConfianza.Name = "lblTecnicoConfianza"
        Me.lblTecnicoConfianza.Size = New System.Drawing.Size(606, 24)
        Me.lblTecnicoConfianza.TabIndex = 4
        Me.lblTecnicoConfianza.Text = "Contacte a su técnico de confianza para realizar la actualización"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'CheckNetFrameworkVersion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 318)
        Me.Controls.Add(Me.lblTecnicoConfianza)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CheckNetFrameworkVersion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controlar versión de Net Framework"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
   Friend WithEvents Label2 As Label
   Friend WithEvents Label3 As Label
   Friend WithEvents Panel1 As Panel
   Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
   Friend WithEvents CopiarLinkToolStripMenuItem As ToolStripMenuItem
   Friend WithEvents LinkLabel2 As LinkLabel
   Friend WithEvents LinkLabel3 As LinkLabel
   Friend WithEvents lblTecnicoConfianza As Label
   Friend WithEvents Timer1 As Timer
End Class
