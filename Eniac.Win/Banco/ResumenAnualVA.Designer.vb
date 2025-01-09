<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResumenAnualVA
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
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.btnImprimir1 = New System.Windows.Forms.Button()
      Me.cmbAnios = New Eniac.Controles.ComboBox()
      Me.lblAnio = New Eniac.Controles.Label()
      Me.lblCuentaBancaria = New Eniac.Controles.Label()
      Me.bscCuentaBancaria = New Eniac.Controles.Buscador()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbConsultar.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbConsultar
      '
      Me.grbConsultar.Controls.Add(Me.btnImprimir1)
      Me.grbConsultar.Controls.Add(Me.cmbAnios)
      Me.grbConsultar.Controls.Add(Me.lblAnio)
      Me.grbConsultar.Controls.Add(Me.lblCuentaBancaria)
      Me.grbConsultar.Controls.Add(Me.bscCuentaBancaria)
      Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(453, 158)
      Me.grbConsultar.TabIndex = 1
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
      '
      'btnImprimir1
      '
      Me.btnImprimir1.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.btnImprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnImprimir1.Location = New System.Drawing.Point(336, 94)
      Me.btnImprimir1.Name = "btnImprimir1"
      Me.btnImprimir1.Size = New System.Drawing.Size(100, 43)
      Me.btnImprimir1.TabIndex = 91
      Me.btnImprimir1.Text = "&Imprimir"
      Me.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnImprimir1.UseVisualStyleBackColor = True
      '
      'cmbAnios
      '
      Me.cmbAnios.BindearPropiedadControl = Nothing
      Me.cmbAnios.BindearPropiedadEntidad = Nothing
      Me.cmbAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAnios.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAnios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAnios.FormattingEnabled = True
      Me.cmbAnios.IsPK = False
      Me.cmbAnios.IsRequired = False
      Me.cmbAnios.Key = Nothing
      Me.cmbAnios.LabelAsoc = Nothing
      Me.cmbAnios.Location = New System.Drawing.Point(109, 67)
      Me.cmbAnios.Name = "cmbAnios"
      Me.cmbAnios.Size = New System.Drawing.Size(124, 21)
      Me.cmbAnios.TabIndex = 1
      '
      'lblAnio
      '
      Me.lblAnio.AutoSize = True
      Me.lblAnio.Location = New System.Drawing.Point(18, 70)
      Me.lblAnio.Name = "lblAnio"
      Me.lblAnio.Size = New System.Drawing.Size(26, 13)
      Me.lblAnio.TabIndex = 90
      Me.lblAnio.Text = "Año"
      '
      'lblCuentaBancaria
      '
      Me.lblCuentaBancaria.AutoSize = True
      Me.lblCuentaBancaria.Location = New System.Drawing.Point(18, 39)
      Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
      Me.lblCuentaBancaria.Size = New System.Drawing.Size(86, 13)
      Me.lblCuentaBancaria.TabIndex = 89
      Me.lblCuentaBancaria.Text = "Cuenta Bancaria"
      '
      'bscCuentaBancaria
      '
      Me.bscCuentaBancaria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCuentaBancaria.AyudaAncho = 608
      Me.bscCuentaBancaria.BindearPropiedadControl = Nothing
      Me.bscCuentaBancaria.BindearPropiedadEntidad = Nothing
      Me.bscCuentaBancaria.ColumnasAlineacion = Nothing
      Me.bscCuentaBancaria.ColumnasAncho = Nothing
      Me.bscCuentaBancaria.ColumnasFormato = Nothing
      Me.bscCuentaBancaria.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
      Me.bscCuentaBancaria.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
      Me.bscCuentaBancaria.Datos = Nothing
      Me.bscCuentaBancaria.FilaDevuelta = Nothing
      Me.bscCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCuentaBancaria.IsDecimal = False
      Me.bscCuentaBancaria.IsNumber = False
      Me.bscCuentaBancaria.IsPK = False
      Me.bscCuentaBancaria.IsRequired = False
      Me.bscCuentaBancaria.Key = ""
      Me.bscCuentaBancaria.LabelAsoc = Me.lblCuentaBancaria
      Me.bscCuentaBancaria.Location = New System.Drawing.Point(109, 35)
      Me.bscCuentaBancaria.MaxLengh = "32767"
      Me.bscCuentaBancaria.Name = "bscCuentaBancaria"
      Me.bscCuentaBancaria.Permitido = True
      Me.bscCuentaBancaria.Selecciono = False
      Me.bscCuentaBancaria.Size = New System.Drawing.Size(327, 20)
      Me.bscCuentaBancaria.TabIndex = 0
      Me.bscCuentaBancaria.Titulo = "Clientes"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(473, 29)
      Me.tstBarra.TabIndex = 0
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'ResumenAnual
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(473, 200)
      Me.Controls.Add(Me.grbConsultar)
      Me.Controls.Add(Me.tstBarra)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ResumenAnual"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Resumen Anual"
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbAnios As Eniac.Controles.ComboBox
   Friend WithEvents lblAnio As Eniac.Controles.Label
   Friend WithEvents lblCuentaBancaria As Eniac.Controles.Label
   Friend WithEvents bscCuentaBancaria As Eniac.Controles.Buscador
   Friend WithEvents btnImprimir1 As System.Windows.Forms.Button
End Class
