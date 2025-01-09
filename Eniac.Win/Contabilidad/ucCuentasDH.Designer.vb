<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCuentasDH
   Inherits System.Windows.Forms.UserControl

   'UserControl overrides dispose to clean up the component list.
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
      Me.lblHaber = New Eniac.Controles.Label()
      Me.lblDebe = New Eniac.Controles.Label()
      Me.bscDescripcionH = New Eniac.Controles.Buscador()
      Me.lblDesc = New Eniac.Controles.Label()
      Me.bscCodCuentaH = New Eniac.Controles.Buscador()
      Me.lblCta = New Eniac.Controles.Label()
      Me.bscDescripcion = New Eniac.Controles.Buscador()
      Me.bscCodCuenta = New Eniac.Controles.Buscador()
      Me.gbTipo = New System.Windows.Forms.GroupBox()
      Me.gbTipo.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblHaber
      '
      Me.lblHaber.AutoSize = True
      Me.lblHaber.Location = New System.Drawing.Point(10, 61)
      Me.lblHaber.Name = "lblHaber"
      Me.lblHaber.Size = New System.Drawing.Size(36, 13)
      Me.lblHaber.TabIndex = 31
      Me.lblHaber.Text = "Haber"
      '
      'lblDebe
      '
      Me.lblDebe.AutoSize = True
      Me.lblDebe.Location = New System.Drawing.Point(10, 36)
      Me.lblDebe.Name = "lblDebe"
      Me.lblDebe.Size = New System.Drawing.Size(33, 13)
      Me.lblDebe.TabIndex = 30
      Me.lblDebe.Text = "Debe"
      '
      'bscDescripcionH
      '
      Me.bscDescripcionH.AyudaAncho = 608
      Me.bscDescripcionH.BindearPropiedadControl = ""
      Me.bscDescripcionH.BindearPropiedadEntidad = ""
      Me.bscDescripcionH.ColumnasAlineacion = Nothing
      Me.bscDescripcionH.ColumnasAncho = Nothing
      Me.bscDescripcionH.ColumnasFormato = Nothing
      Me.bscDescripcionH.ColumnasOcultas = Nothing
      Me.bscDescripcionH.ColumnasTitulos = Nothing
      Me.bscDescripcionH.Datos = Nothing
      Me.bscDescripcionH.FilaDevuelta = Nothing
      Me.bscDescripcionH.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDescripcionH.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDescripcionH.IsDecimal = False
      Me.bscDescripcionH.IsNumber = False
      Me.bscDescripcionH.IsPK = False
      Me.bscDescripcionH.IsRequired = False
      Me.bscDescripcionH.Key = ""
      Me.bscDescripcionH.LabelAsoc = Me.lblDesc
      Me.bscDescripcionH.Location = New System.Drawing.Point(149, 58)
      Me.bscDescripcionH.MaxLengh = "32767"
      Me.bscDescripcionH.Name = "bscDescripcionH"
      Me.bscDescripcionH.Permitido = True
      Me.bscDescripcionH.Selecciono = False
      Me.bscDescripcionH.Size = New System.Drawing.Size(275, 20)
      Me.bscDescripcionH.TabIndex = 29
      Me.bscDescripcionH.Titulo = Nothing
      '
      'lblDesc
      '
      Me.lblDesc.AutoSize = True
      Me.lblDesc.Location = New System.Drawing.Point(146, 16)
      Me.lblDesc.Name = "lblDesc"
      Me.lblDesc.Size = New System.Drawing.Size(63, 13)
      Me.lblDesc.TabIndex = 27
      Me.lblDesc.Text = "Descripción"
      '
      'bscCodCuentaH
      '
      Me.bscCodCuentaH.AyudaAncho = 608
      Me.bscCodCuentaH.BindearPropiedadControl = "Text"
      Me.bscCodCuentaH.BindearPropiedadEntidad = "idCuentaHaber"
      Me.bscCodCuentaH.ColumnasAlineacion = Nothing
      Me.bscCodCuentaH.ColumnasAncho = Nothing
      Me.bscCodCuentaH.ColumnasFormato = Nothing
      Me.bscCodCuentaH.ColumnasOcultas = Nothing
      Me.bscCodCuentaH.ColumnasTitulos = Nothing
      Me.bscCodCuentaH.Datos = Nothing
      Me.bscCodCuentaH.FilaDevuelta = Nothing
      Me.bscCodCuentaH.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodCuentaH.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodCuentaH.IsDecimal = False
      Me.bscCodCuentaH.IsNumber = True
      Me.bscCodCuentaH.IsPK = False
      Me.bscCodCuentaH.IsRequired = False
      Me.bscCodCuentaH.Key = ""
      Me.bscCodCuentaH.LabelAsoc = Me.lblCta
      Me.bscCodCuentaH.Location = New System.Drawing.Point(49, 58)
      Me.bscCodCuentaH.MaxLengh = "32767"
      Me.bscCodCuentaH.Name = "bscCodCuentaH"
      Me.bscCodCuentaH.Permitido = True
      Me.bscCodCuentaH.Selecciono = False
      Me.bscCodCuentaH.Size = New System.Drawing.Size(95, 20)
      Me.bscCodCuentaH.TabIndex = 28
      Me.bscCodCuentaH.Titulo = Nothing
      '
      'lblCta
      '
      Me.lblCta.AutoSize = True
      Me.lblCta.Location = New System.Drawing.Point(48, 16)
      Me.lblCta.Name = "lblCta"
      Me.lblCta.Size = New System.Drawing.Size(40, 13)
      Me.lblCta.TabIndex = 25
      Me.lblCta.Text = "Código"
      '
      'bscDescripcion
      '
      Me.bscDescripcion.AyudaAncho = 608
      Me.bscDescripcion.BindearPropiedadControl = ""
      Me.bscDescripcion.BindearPropiedadEntidad = ""
      Me.bscDescripcion.ColumnasAlineacion = Nothing
      Me.bscDescripcion.ColumnasAncho = Nothing
      Me.bscDescripcion.ColumnasFormato = Nothing
      Me.bscDescripcion.ColumnasOcultas = Nothing
      Me.bscDescripcion.ColumnasTitulos = Nothing
      Me.bscDescripcion.Datos = Nothing
      Me.bscDescripcion.FilaDevuelta = Nothing
      Me.bscDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDescripcion.IsDecimal = False
      Me.bscDescripcion.IsNumber = False
      Me.bscDescripcion.IsPK = False
      Me.bscDescripcion.IsRequired = False
      Me.bscDescripcion.Key = ""
      Me.bscDescripcion.LabelAsoc = Me.lblDesc
      Me.bscDescripcion.Location = New System.Drawing.Point(149, 32)
      Me.bscDescripcion.MaxLengh = "32767"
      Me.bscDescripcion.Name = "bscDescripcion"
      Me.bscDescripcion.Permitido = True
      Me.bscDescripcion.Selecciono = False
      Me.bscDescripcion.Size = New System.Drawing.Size(275, 20)
      Me.bscDescripcion.TabIndex = 26
      Me.bscDescripcion.Titulo = Nothing
      '
      'bscCodCuenta
      '
      Me.bscCodCuenta.AyudaAncho = 608
      Me.bscCodCuenta.BindearPropiedadControl = "Text"
      Me.bscCodCuenta.BindearPropiedadEntidad = "idCuentaDebe"
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
      Me.bscCodCuenta.LabelAsoc = Me.lblCta
      Me.bscCodCuenta.Location = New System.Drawing.Point(49, 32)
      Me.bscCodCuenta.MaxLengh = "32767"
      Me.bscCodCuenta.Name = "bscCodCuenta"
      Me.bscCodCuenta.Permitido = True
      Me.bscCodCuenta.Selecciono = False
      Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
      Me.bscCodCuenta.TabIndex = 24
      Me.bscCodCuenta.Titulo = Nothing
      '
      'gbTipo
      '
      Me.gbTipo.Controls.Add(Me.lblCta)
      Me.gbTipo.Controls.Add(Me.lblHaber)
      Me.gbTipo.Controls.Add(Me.bscCodCuenta)
      Me.gbTipo.Controls.Add(Me.lblDebe)
      Me.gbTipo.Controls.Add(Me.bscDescripcion)
      Me.gbTipo.Controls.Add(Me.bscDescripcionH)
      Me.gbTipo.Controls.Add(Me.lblDesc)
      Me.gbTipo.Controls.Add(Me.bscCodCuentaH)
      Me.gbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.gbTipo.ForeColor = System.Drawing.SystemColors.ActiveCaption
      Me.gbTipo.Location = New System.Drawing.Point(3, 3)
      Me.gbTipo.Name = "gbTipo"
      Me.gbTipo.Size = New System.Drawing.Size(433, 89)
      Me.gbTipo.TabIndex = 32
      Me.gbTipo.TabStop = False
      '
      'ucCuentasDH
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.gbTipo)
      Me.Name = "ucCuentasDH"
      Me.Size = New System.Drawing.Size(439, 95)
      Me.gbTipo.ResumeLayout(False)
      Me.gbTipo.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents lblHaber As Eniac.Controles.Label
   Friend WithEvents lblDebe As Eniac.Controles.Label
   Friend WithEvents bscDescripcionH As Eniac.Controles.Buscador
   Friend WithEvents lblDesc As Eniac.Controles.Label
   Friend WithEvents lblCta As Eniac.Controles.Label
   Friend WithEvents bscDescripcion As Eniac.Controles.Buscador
   Public WithEvents bscCodCuentaH As Eniac.Controles.Buscador
   Public WithEvents bscCodCuenta As Eniac.Controles.Buscador
   Public WithEvents gbTipo As System.Windows.Forms.GroupBox

End Class
