<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Parametros
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
      Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tbpArchivos = New System.Windows.Forms.TabPage()
        Me.UcNDConfArchivos1 = New Eniac.Win.ucNDConfArchivos()
        Me.tbpCtaCteProveedores = New System.Windows.Forms.TabPage()
        Me.UcNDConfCtaCteProv1 = New Eniac.Win.ucNDConfCtaCteProv()
        Me.tbpCtaCteClientes = New System.Windows.Forms.TabPage()
        Me.UcNDConfCtaCteCliente1 = New Eniac.Win.ucNDConfCtaCteCliente()
        Me.tbpPrecios = New System.Windows.Forms.TabPage()
        Me.UcNDConfPrecios1 = New Eniac.Win.ucNDConfPrecios()
        Me.tbpVentas = New System.Windows.Forms.TabPage()
        Me.UcNDConfVentas1 = New Eniac.Win.ucNDConfVentas()
        Me.tbpDatosEmpresa = New System.Windows.Forms.TabPage()
        Me.UcNDConfDatosEmpresa1 = New Eniac.Win.ucConfNDDatosEmpresa()
        Me.tbcParametros = New System.Windows.Forms.TabControl()
        Me.tbpModulos = New System.Windows.Forms.TabPage()
        Me.UcNDConfModulos1 = New Eniac.Win.ucNDConfModulos()
        Me.tbpFactElectronica = New System.Windows.Forms.TabPage()
        Me.UcNDConfFacturaElectronica1 = New Eniac.Win.ucNDConfFacturaElectronica()
        Me.tbpPedidos = New System.Windows.Forms.TabPage()
        Me.UcNDConfPedidos1 = New Eniac.Win.ucNDConfPedidos()
        Me.tbpExpensas = New System.Windows.Forms.TabPage()
        Me.UcNDConfExpensas1 = New Eniac.Win.ucNDConfExpensas()
        Me.tbpStock = New System.Windows.Forms.TabPage()
        Me.UcNDConfStock1 = New Eniac.Win.ucNDConfStock()
        Me.tbpBaseSecundaria = New System.Windows.Forms.TabPage()
        Me.UcNDConfBasesSecundarias1 = New Eniac.Win.ucNDConfBasesSecundarias()
        Me.tbpActualizador = New System.Windows.Forms.TabPage()
        Me.UcNDConfActualizador1 = New Eniac.Win.ucNDConfActualizador()
        Me.tspFacturacion.SuspendLayout()
        Me.tbpArchivos.SuspendLayout()
        Me.tbpCtaCteProveedores.SuspendLayout()
        Me.tbpCtaCteClientes.SuspendLayout()
        Me.tbpPrecios.SuspendLayout()
        Me.tbpVentas.SuspendLayout()
        Me.tbpDatosEmpresa.SuspendLayout()
        Me.tbcParametros.SuspendLayout()
        Me.tbpModulos.SuspendLayout()
        Me.tbpFactElectronica.SuspendLayout()
        Me.tbpPedidos.SuspendLayout()
        Me.tbpExpensas.SuspendLayout()
        Me.tbpStock.SuspendLayout()
        Me.tbpBaseSecundaria.SuspendLayout()
        Me.tbpActualizador.SuspendLayout()
        Me.SuspendLayout()
        '
        'tspFacturacion
        '
        Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
        Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
        Me.tspFacturacion.Name = "tspFacturacion"
        Me.tspFacturacion.Size = New System.Drawing.Size(1132, 25)
        Me.tspFacturacion.TabIndex = 1
        Me.tspFacturacion.Text = "ToolStrip1"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(85, 22)
        Me.tsbGrabar.Text = "&Grabar (F4)"
        Me.tsbGrabar.ToolTipText = "Imprimir y Grabar (F4)"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'tbpArchivos
        '
        Me.tbpArchivos.Controls.Add(Me.UcNDConfArchivos1)
        Me.tbpArchivos.Location = New System.Drawing.Point(4, 25)
        Me.tbpArchivos.Name = "tbpArchivos"
        Me.tbpArchivos.Size = New System.Drawing.Size(1124, 532)
        Me.tbpArchivos.TabIndex = 6
        Me.tbpArchivos.Text = "Archivos"
        Me.tbpArchivos.UseVisualStyleBackColor = True
        '
        'UcNDConfArchivos1
        '
        Me.UcNDConfArchivos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfArchivos1.Location = New System.Drawing.Point(0, 0)
        Me.UcNDConfArchivos1.Name = "UcNDConfArchivos1"
        Me.UcNDConfArchivos1.Size = New System.Drawing.Size(1124, 532)
        Me.UcNDConfArchivos1.TabIndex = 0
        '
        'tbpCtaCteProveedores
        '
        Me.tbpCtaCteProveedores.Controls.Add(Me.UcNDConfCtaCteProv1)
        Me.tbpCtaCteProveedores.Location = New System.Drawing.Point(4, 25)
        Me.tbpCtaCteProveedores.Name = "tbpCtaCteProveedores"
        Me.tbpCtaCteProveedores.Size = New System.Drawing.Size(1124, 532)
        Me.tbpCtaCteProveedores.TabIndex = 8
        Me.tbpCtaCteProveedores.Text = "Cta. Cte. Proveedores"
        Me.tbpCtaCteProveedores.UseVisualStyleBackColor = True
        '
        'UcNDConfCtaCteProv1
        '
        Me.UcNDConfCtaCteProv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfCtaCteProv1.Location = New System.Drawing.Point(0, 0)
        Me.UcNDConfCtaCteProv1.Name = "UcNDConfCtaCteProv1"
        Me.UcNDConfCtaCteProv1.Size = New System.Drawing.Size(1124, 532)
        Me.UcNDConfCtaCteProv1.TabIndex = 0
        '
        'tbpCtaCteClientes
        '
        Me.tbpCtaCteClientes.Controls.Add(Me.UcNDConfCtaCteCliente1)
        Me.tbpCtaCteClientes.Location = New System.Drawing.Point(4, 25)
        Me.tbpCtaCteClientes.Name = "tbpCtaCteClientes"
        Me.tbpCtaCteClientes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCtaCteClientes.Size = New System.Drawing.Size(1124, 532)
        Me.tbpCtaCteClientes.TabIndex = 1
        Me.tbpCtaCteClientes.Text = "Cta. Cte. Clientes"
        Me.tbpCtaCteClientes.UseVisualStyleBackColor = True
        '
        'UcNDConfCtaCteCliente1
        '
        Me.UcNDConfCtaCteCliente1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfCtaCteCliente1.Location = New System.Drawing.Point(3, 3)
        Me.UcNDConfCtaCteCliente1.Name = "UcNDConfCtaCteCliente1"
        Me.UcNDConfCtaCteCliente1.Size = New System.Drawing.Size(1118, 526)
        Me.UcNDConfCtaCteCliente1.TabIndex = 0
        '
        'tbpPrecios
        '
        Me.tbpPrecios.Controls.Add(Me.UcNDConfPrecios1)
        Me.tbpPrecios.Location = New System.Drawing.Point(4, 25)
        Me.tbpPrecios.Name = "tbpPrecios"
        Me.tbpPrecios.Size = New System.Drawing.Size(1124, 532)
        Me.tbpPrecios.TabIndex = 7
        Me.tbpPrecios.Text = "Precios"
        Me.tbpPrecios.UseVisualStyleBackColor = True
        '
        'UcNDConfPrecios1
        '
        Me.UcNDConfPrecios1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfPrecios1.Location = New System.Drawing.Point(0, 0)
        Me.UcNDConfPrecios1.Name = "UcNDConfPrecios1"
        Me.UcNDConfPrecios1.Size = New System.Drawing.Size(1124, 532)
        Me.UcNDConfPrecios1.TabIndex = 0
        '
        'tbpVentas
        '
        Me.tbpVentas.Controls.Add(Me.UcNDConfVentas1)
        Me.tbpVentas.Location = New System.Drawing.Point(4, 25)
        Me.tbpVentas.Name = "tbpVentas"
        Me.tbpVentas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpVentas.Size = New System.Drawing.Size(1124, 532)
        Me.tbpVentas.TabIndex = 3
        Me.tbpVentas.Text = "Ventas"
        Me.tbpVentas.UseVisualStyleBackColor = True
        '
        'UcNDConfVentas1
        '
        Me.UcNDConfVentas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfVentas1.Location = New System.Drawing.Point(3, 3)
        Me.UcNDConfVentas1.Name = "UcNDConfVentas1"
        Me.UcNDConfVentas1.Size = New System.Drawing.Size(1118, 526)
        Me.UcNDConfVentas1.TabIndex = 0
        '
        'tbpDatosEmpresa
        '
        Me.tbpDatosEmpresa.Controls.Add(Me.UcNDConfDatosEmpresa1)
        Me.tbpDatosEmpresa.Location = New System.Drawing.Point(4, 25)
        Me.tbpDatosEmpresa.Name = "tbpDatosEmpresa"
        Me.tbpDatosEmpresa.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDatosEmpresa.Size = New System.Drawing.Size(1124, 532)
        Me.tbpDatosEmpresa.TabIndex = 0
        Me.tbpDatosEmpresa.Text = "Datos Empresa"
        Me.tbpDatosEmpresa.UseVisualStyleBackColor = True
        '
        'UcNDConfDatosEmpresa1
        '
        Me.UcNDConfDatosEmpresa1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfDatosEmpresa1.Location = New System.Drawing.Point(3, 3)
        Me.UcNDConfDatosEmpresa1.Name = "UcNDConfDatosEmpresa1"
        Me.UcNDConfDatosEmpresa1.Size = New System.Drawing.Size(1118, 526)
        Me.UcNDConfDatosEmpresa1.TabIndex = 70
        '
        'tbcParametros
        '
        Me.tbcParametros.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcParametros.Controls.Add(Me.tbpDatosEmpresa)
        Me.tbcParametros.Controls.Add(Me.tbpModulos)
        Me.tbcParametros.Controls.Add(Me.tbpVentas)
        Me.tbcParametros.Controls.Add(Me.tbpFactElectronica)
        Me.tbcParametros.Controls.Add(Me.tbpPrecios)
        Me.tbcParametros.Controls.Add(Me.tbpCtaCteClientes)
        Me.tbcParametros.Controls.Add(Me.tbpCtaCteProveedores)
        Me.tbcParametros.Controls.Add(Me.tbpPedidos)
        Me.tbcParametros.Controls.Add(Me.tbpArchivos)
        Me.tbcParametros.Controls.Add(Me.tbpExpensas)
        Me.tbcParametros.Controls.Add(Me.tbpStock)
        Me.tbcParametros.Controls.Add(Me.tbpBaseSecundaria)
        Me.tbcParametros.Controls.Add(Me.tbpActualizador)
        Me.tbcParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcParametros.HotTrack = True
        Me.tbcParametros.Location = New System.Drawing.Point(0, 25)
        Me.tbcParametros.Multiline = True
        Me.tbcParametros.Name = "tbcParametros"
        Me.tbcParametros.SelectedIndex = 0
        Me.tbcParametros.Size = New System.Drawing.Size(1132, 561)
        Me.tbcParametros.TabIndex = 0
        '
        'tbpModulos
        '
        Me.tbpModulos.Controls.Add(Me.UcNDConfModulos1)
        Me.tbpModulos.Location = New System.Drawing.Point(4, 25)
        Me.tbpModulos.Name = "tbpModulos"
        Me.tbpModulos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpModulos.Size = New System.Drawing.Size(1124, 532)
        Me.tbpModulos.TabIndex = 26
        Me.tbpModulos.Text = "Utiliza Módulos"
        Me.tbpModulos.UseVisualStyleBackColor = True
        '
        'UcNDConfModulos1
        '
        Me.UcNDConfModulos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfModulos1.Location = New System.Drawing.Point(3, 3)
        Me.UcNDConfModulos1.Name = "UcNDConfModulos1"
        Me.UcNDConfModulos1.Size = New System.Drawing.Size(1118, 526)
        Me.UcNDConfModulos1.TabIndex = 0
        '
        'tbpFactElectronica
        '
        Me.tbpFactElectronica.Controls.Add(Me.UcNDConfFacturaElectronica1)
        Me.tbpFactElectronica.Location = New System.Drawing.Point(4, 25)
        Me.tbpFactElectronica.Name = "tbpFactElectronica"
        Me.tbpFactElectronica.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFactElectronica.Size = New System.Drawing.Size(1124, 532)
        Me.tbpFactElectronica.TabIndex = 9
        Me.tbpFactElectronica.Text = "Fact.Electr."
        Me.tbpFactElectronica.UseVisualStyleBackColor = True
        '
        'UcNDConfFacturaElectronica1
        '
        Me.UcNDConfFacturaElectronica1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfFacturaElectronica1.Location = New System.Drawing.Point(3, 3)
        Me.UcNDConfFacturaElectronica1.Name = "UcNDConfFacturaElectronica1"
        Me.UcNDConfFacturaElectronica1.Size = New System.Drawing.Size(1118, 526)
        Me.UcNDConfFacturaElectronica1.TabIndex = 0
        '
        'tbpPedidos
        '
        Me.tbpPedidos.Controls.Add(Me.UcNDConfPedidos1)
        Me.tbpPedidos.Location = New System.Drawing.Point(4, 25)
        Me.tbpPedidos.Name = "tbpPedidos"
        Me.tbpPedidos.Size = New System.Drawing.Size(1124, 532)
        Me.tbpPedidos.TabIndex = 27
        Me.tbpPedidos.Text = "Pedidos"
        Me.tbpPedidos.UseVisualStyleBackColor = True
        '
        'UcNDConfPedidos1
        '
        Me.UcNDConfPedidos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfPedidos1.Location = New System.Drawing.Point(0, 0)
        Me.UcNDConfPedidos1.Name = "UcNDConfPedidos1"
        Me.UcNDConfPedidos1.Size = New System.Drawing.Size(1124, 532)
        Me.UcNDConfPedidos1.TabIndex = 0
        '
        'tbpExpensas
        '
        Me.tbpExpensas.Controls.Add(Me.UcNDConfExpensas1)
        Me.tbpExpensas.Location = New System.Drawing.Point(4, 25)
        Me.tbpExpensas.Name = "tbpExpensas"
        Me.tbpExpensas.Size = New System.Drawing.Size(1124, 532)
        Me.tbpExpensas.TabIndex = 16
        Me.tbpExpensas.Text = "Expensas"
        Me.tbpExpensas.UseVisualStyleBackColor = True
        '
        'UcNDConfExpensas1
        '
        Me.UcNDConfExpensas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfExpensas1.Location = New System.Drawing.Point(0, 0)
        Me.UcNDConfExpensas1.Name = "UcNDConfExpensas1"
        Me.UcNDConfExpensas1.Size = New System.Drawing.Size(1124, 532)
        Me.UcNDConfExpensas1.TabIndex = 0
        '
        'tbpStock
        '
        Me.tbpStock.Controls.Add(Me.UcNDConfStock1)
        Me.tbpStock.Location = New System.Drawing.Point(4, 25)
        Me.tbpStock.Name = "tbpStock"
        Me.tbpStock.Size = New System.Drawing.Size(1124, 532)
        Me.tbpStock.TabIndex = 21
        Me.tbpStock.Text = "Stock"
        Me.tbpStock.UseVisualStyleBackColor = True
        '
        'UcNDConfStock1
        '
        Me.UcNDConfStock1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfStock1.Location = New System.Drawing.Point(0, 0)
        Me.UcNDConfStock1.Name = "UcNDConfStock1"
        Me.UcNDConfStock1.Size = New System.Drawing.Size(1124, 532)
        Me.UcNDConfStock1.TabIndex = 0
        '
        'tbpBaseSecundaria
        '
        Me.tbpBaseSecundaria.Controls.Add(Me.UcNDConfBasesSecundarias1)
        Me.tbpBaseSecundaria.Location = New System.Drawing.Point(4, 25)
        Me.tbpBaseSecundaria.Name = "tbpBaseSecundaria"
        Me.tbpBaseSecundaria.Size = New System.Drawing.Size(1124, 532)
        Me.tbpBaseSecundaria.TabIndex = 22
        Me.tbpBaseSecundaria.Text = "Bases Secundarias"
        Me.tbpBaseSecundaria.UseVisualStyleBackColor = True
        '
        'UcNDConfBasesSecundarias1
        '
        Me.UcNDConfBasesSecundarias1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfBasesSecundarias1.Location = New System.Drawing.Point(0, 0)
        Me.UcNDConfBasesSecundarias1.Name = "UcNDConfBasesSecundarias1"
        Me.UcNDConfBasesSecundarias1.Size = New System.Drawing.Size(1124, 532)
        Me.UcNDConfBasesSecundarias1.TabIndex = 0
        '
        'tbpActualizador
        '
        Me.tbpActualizador.Controls.Add(Me.UcNDConfActualizador1)
        Me.tbpActualizador.Location = New System.Drawing.Point(4, 25)
        Me.tbpActualizador.Name = "tbpActualizador"
        Me.tbpActualizador.Size = New System.Drawing.Size(1124, 532)
        Me.tbpActualizador.TabIndex = 25
        Me.tbpActualizador.Text = "Actualizador"
        Me.tbpActualizador.UseVisualStyleBackColor = True
        '
        'UcNDConfActualizador1
        '
        Me.UcNDConfActualizador1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcNDConfActualizador1.Location = New System.Drawing.Point(0, 0)
        Me.UcNDConfActualizador1.Name = "UcNDConfActualizador1"
        Me.UcNDConfActualizador1.Size = New System.Drawing.Size(1124, 532)
        Me.UcNDConfActualizador1.TabIndex = 0
        '
        'Parametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 586)
        Me.Controls.Add(Me.tbcParametros)
        Me.Controls.Add(Me.tspFacturacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Parametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametros No Derivables"
        Me.tspFacturacion.ResumeLayout(False)
        Me.tspFacturacion.PerformLayout()
        Me.tbpArchivos.ResumeLayout(False)
        Me.tbpCtaCteProveedores.ResumeLayout(False)
        Me.tbpCtaCteClientes.ResumeLayout(False)
        Me.tbpPrecios.ResumeLayout(False)
        Me.tbpVentas.ResumeLayout(False)
        Me.tbpDatosEmpresa.ResumeLayout(False)
        Me.tbcParametros.ResumeLayout(False)
        Me.tbpModulos.ResumeLayout(False)
        Me.tbpFactElectronica.ResumeLayout(False)
        Me.tbpPedidos.ResumeLayout(False)
        Me.tbpExpensas.ResumeLayout(False)
        Me.tbpStock.ResumeLayout(False)
        Me.tbpBaseSecundaria.ResumeLayout(False)
        Me.tbpActualizador.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tbpArchivos As System.Windows.Forms.TabPage
    Friend WithEvents tbpCtaCteProveedores As System.Windows.Forms.TabPage
    Friend WithEvents tbpCtaCteClientes As System.Windows.Forms.TabPage
    Friend WithEvents tbpPrecios As System.Windows.Forms.TabPage
    Friend WithEvents tbpVentas As System.Windows.Forms.TabPage
    Friend WithEvents tbpDatosEmpresa As System.Windows.Forms.TabPage
    Friend WithEvents tbcParametros As System.Windows.Forms.TabControl
    Friend WithEvents tbpFactElectronica As System.Windows.Forms.TabPage
    Friend WithEvents tbpExpensas As System.Windows.Forms.TabPage
    Friend WithEvents tbpStock As System.Windows.Forms.TabPage
    Friend WithEvents tbpBaseSecundaria As System.Windows.Forms.TabPage
    Friend WithEvents tbpActualizador As TabPage
    Friend WithEvents UcNDConfDatosEmpresa1 As ucConfNDDatosEmpresa
    Friend WithEvents tbpModulos As TabPage
    Friend WithEvents UcNDConfModulos1 As ucNDConfModulos
    Friend WithEvents UcNDConfVentas1 As ucNDConfVentas
    Friend WithEvents UcNDConfFacturaElectronica1 As ucNDConfFacturaElectronica
    Friend WithEvents UcNDConfPrecios1 As ucNDConfPrecios
    Friend WithEvents UcNDConfCtaCteCliente1 As ucNDConfCtaCteCliente
    Friend WithEvents UcNDConfCtaCteProv1 As ucNDConfCtaCteProv
    Friend WithEvents UcNDConfArchivos1 As ucNDConfArchivos
    Friend WithEvents UcNDConfExpensas1 As ucNDConfExpensas
    Friend WithEvents UcNDConfStock1 As ucNDConfStock
    Friend WithEvents UcNDConfBasesSecundarias1 As ucNDConfBasesSecundarias
    Friend WithEvents UcNDConfActualizador1 As ucNDConfActualizador
    Friend WithEvents tbpPedidos As TabPage
    Friend WithEvents UcNDConfPedidos1 As ucNDConfPedidos
End Class
