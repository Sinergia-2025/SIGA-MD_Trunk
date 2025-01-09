<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MediosDePagoDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediosDePagoDetalle))
      Me.lblNombreMediodePago = New Eniac.Controles.Label()
      Me.lblIdMediodePago = New Eniac.Controles.Label()
      Me.txtIdMediodePago = New Eniac.Controles.TextBox()
      Me.txtNombreMedioPago = New Eniac.Controles.TextBox()
      Me.gpoContabilidad = New System.Windows.Forms.GroupBox()
      Me.lblCuentaCodigo = New Eniac.Controles.Label()
      Me.lblDesc = New Eniac.Controles.Label()
      Me.bscDescCuenta = New Eniac.Controles.Buscador()
      Me.bscCodCuenta = New Eniac.Controles.Buscador()
      Me.gpoContabilidad.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(277, 200)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(363, 200)
      Me.btnCancelar.TabIndex = 6
      '
      'lblNombreMediodePago
      '
      Me.lblNombreMediodePago.AutoSize = True
      Me.lblNombreMediodePago.LabelAsoc = Nothing
      Me.lblNombreMediodePago.Location = New System.Drawing.Point(31, 48)
      Me.lblNombreMediodePago.Name = "lblNombreMediodePago"
      Me.lblNombreMediodePago.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreMediodePago.TabIndex = 2
      Me.lblNombreMediodePago.Text = "Nombre"
      '
      'lblIdMediodePago
      '
      Me.lblIdMediodePago.AutoSize = True
      Me.lblIdMediodePago.LabelAsoc = Nothing
      Me.lblIdMediodePago.Location = New System.Drawing.Point(31, 20)
      Me.lblIdMediodePago.Name = "lblIdMediodePago"
      Me.lblIdMediodePago.Size = New System.Drawing.Size(40, 13)
      Me.lblIdMediodePago.TabIndex = 0
      Me.lblIdMediodePago.Text = "Código"
      '
      'txtIdMediodePago
      '
      Me.txtIdMediodePago.BindearPropiedadControl = "Text"
      Me.txtIdMediodePago.BindearPropiedadEntidad = "IdMediodePago"
      Me.txtIdMediodePago.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdMediodePago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdMediodePago.Formato = ""
      Me.txtIdMediodePago.IsDecimal = False
      Me.txtIdMediodePago.IsNumber = True
      Me.txtIdMediodePago.IsPK = True
      Me.txtIdMediodePago.IsRequired = True
      Me.txtIdMediodePago.Key = ""
      Me.txtIdMediodePago.LabelAsoc = Me.lblIdMediodePago
      Me.txtIdMediodePago.Location = New System.Drawing.Point(76, 16)
      Me.txtIdMediodePago.MaxLength = 9
      Me.txtIdMediodePago.Name = "txtIdMediodePago"
      Me.txtIdMediodePago.Size = New System.Drawing.Size(50, 20)
      Me.txtIdMediodePago.TabIndex = 1
      Me.txtIdMediodePago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNombreMedioPago
      '
      Me.txtNombreMedioPago.BindearPropiedadControl = "Text"
      Me.txtNombreMedioPago.BindearPropiedadEntidad = "nombreMedioDePago"
      Me.txtNombreMedioPago.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreMedioPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreMedioPago.Formato = ""
      Me.txtNombreMedioPago.IsDecimal = False
      Me.txtNombreMedioPago.IsNumber = False
      Me.txtNombreMedioPago.IsPK = False
      Me.txtNombreMedioPago.IsRequired = True
      Me.txtNombreMedioPago.Key = ""
      Me.txtNombreMedioPago.LabelAsoc = Me.lblNombreMediodePago
      Me.txtNombreMedioPago.Location = New System.Drawing.Point(76, 44)
      Me.txtNombreMedioPago.MaxLength = 20
      Me.txtNombreMedioPago.Name = "txtNombreMedioPago"
      Me.txtNombreMedioPago.Size = New System.Drawing.Size(150, 20)
      Me.txtNombreMedioPago.TabIndex = 3
      '
      'gpoContabilidad
      '
      Me.gpoContabilidad.Controls.Add(Me.lblCuentaCodigo)
      Me.gpoContabilidad.Controls.Add(Me.lblDesc)
      Me.gpoContabilidad.Controls.Add(Me.bscDescCuenta)
      Me.gpoContabilidad.Controls.Add(Me.bscCodCuenta)
      Me.gpoContabilidad.Location = New System.Drawing.Point(12, 92)
      Me.gpoContabilidad.Name = "gpoContabilidad"
      Me.gpoContabilidad.Size = New System.Drawing.Size(431, 85)
      Me.gpoContabilidad.TabIndex = 4
      Me.gpoContabilidad.TabStop = False
      Me.gpoContabilidad.Text = "Contabilidad"
      '
      'lblCuentaCodigo
      '
      Me.lblCuentaCodigo.AutoSize = True
      Me.lblCuentaCodigo.LabelAsoc = Nothing
      Me.lblCuentaCodigo.Location = New System.Drawing.Point(24, 31)
      Me.lblCuentaCodigo.Name = "lblCuentaCodigo"
      Me.lblCuentaCodigo.Size = New System.Drawing.Size(77, 13)
      Me.lblCuentaCodigo.TabIndex = 0
      Me.lblCuentaCodigo.Text = "Cuenta Código"
      '
      'lblDesc
      '
      Me.lblDesc.AutoSize = True
      Me.lblDesc.LabelAsoc = Nothing
      Me.lblDesc.Location = New System.Drawing.Point(129, 31)
      Me.lblDesc.Name = "lblDesc"
      Me.lblDesc.Size = New System.Drawing.Size(100, 13)
      Me.lblDesc.TabIndex = 2
      Me.lblDesc.Text = "Cuenta Descripción"
      '
      'bscDescCuenta
      '
      Me.bscDescCuenta.AyudaAncho = 608
      Me.bscDescCuenta.BindearPropiedadControl = ""
      Me.bscDescCuenta.BindearPropiedadEntidad = ""
      Me.bscDescCuenta.ColumnasAlineacion = Nothing
      Me.bscDescCuenta.ColumnasAncho = Nothing
      Me.bscDescCuenta.ColumnasFormato = Nothing
      Me.bscDescCuenta.ColumnasOcultas = Nothing
      Me.bscDescCuenta.ColumnasTitulos = Nothing
      Me.bscDescCuenta.Datos = Nothing
      Me.bscDescCuenta.FilaDevuelta = Nothing
      Me.bscDescCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDescCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDescCuenta.IsDecimal = False
      Me.bscDescCuenta.IsNumber = False
      Me.bscDescCuenta.IsPK = False
      Me.bscDescCuenta.IsRequired = False
      Me.bscDescCuenta.Key = ""
      Me.bscDescCuenta.LabelAsoc = Me.lblDesc
      Me.bscDescCuenta.Location = New System.Drawing.Point(132, 47)
      Me.bscDescCuenta.MaxLengh = "32767"
      Me.bscDescCuenta.Name = "bscDescCuenta"
      Me.bscDescCuenta.Permitido = True
      Me.bscDescCuenta.Selecciono = False
      Me.bscDescCuenta.Size = New System.Drawing.Size(293, 20)
      Me.bscDescCuenta.TabIndex = 3
      Me.bscDescCuenta.Titulo = Nothing
      '
      'bscCodCuenta
      '
      Me.bscCodCuenta.AyudaAncho = 608
      Me.bscCodCuenta.BindearPropiedadControl = "Text"
      Me.bscCodCuenta.BindearPropiedadEntidad = "idCuenta"
      Me.bscCodCuenta.ColumnasAlineacion = Nothing
      Me.bscCodCuenta.ColumnasAncho = Nothing
      Me.bscCodCuenta.ColumnasFormato = Nothing
      Me.bscCodCuenta.ColumnasOcultas = Nothing
      Me.bscCodCuenta.ColumnasTitulos = Nothing
      Me.bscCodCuenta.Datos = Nothing
      Me.bscCodCuenta.FilaDevuelta = Nothing
      Me.bscCodCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodCuenta.IsDecimal = False
      Me.bscCodCuenta.IsNumber = True
      Me.bscCodCuenta.IsPK = False
      Me.bscCodCuenta.IsRequired = False
      Me.bscCodCuenta.Key = ""
      Me.bscCodCuenta.LabelAsoc = Nothing
      Me.bscCodCuenta.Location = New System.Drawing.Point(27, 47)
      Me.bscCodCuenta.MaxLengh = "32767"
      Me.bscCodCuenta.Name = "bscCodCuenta"
      Me.bscCodCuenta.Permitido = True
      Me.bscCodCuenta.Selecciono = False
      Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
      Me.bscCodCuenta.TabIndex = 1
      Me.bscCodCuenta.Titulo = Nothing
      '
      'MediosDePagoDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(452, 235)
      Me.Controls.Add(Me.gpoContabilidad)
      Me.Controls.Add(Me.lblNombreMediodePago)
      Me.Controls.Add(Me.txtNombreMedioPago)
      Me.Controls.Add(Me.lblIdMediodePago)
      Me.Controls.Add(Me.txtIdMediodePago)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "MediosDePagoDetalle"
      Me.Text = "Medio de Pago"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdMediodePago, 0)
      Me.Controls.SetChildIndex(Me.lblIdMediodePago, 0)
      Me.Controls.SetChildIndex(Me.txtNombreMedioPago, 0)
      Me.Controls.SetChildIndex(Me.lblNombreMediodePago, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.gpoContabilidad, 0)
      Me.gpoContabilidad.ResumeLayout(False)
      Me.gpoContabilidad.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreMediodePago As Eniac.Controles.Label
   Friend WithEvents lblIdMediodePago As Eniac.Controles.Label
   Friend WithEvents txtIdMediodePago As Eniac.Controles.TextBox
   Friend WithEvents txtNombreMedioPago As Eniac.Controles.TextBox
   Friend WithEvents gpoContabilidad As System.Windows.Forms.GroupBox
   Friend WithEvents lblCuentaCodigo As Eniac.Controles.Label
   Friend WithEvents lblDesc As Eniac.Controles.Label
   Friend WithEvents bscDescCuenta As Eniac.Controles.Buscador
   Friend WithEvents bscCodCuenta As Eniac.Controles.Buscador

End Class
