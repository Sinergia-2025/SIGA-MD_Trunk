<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCuentas
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
      Me.bscCodCuenta = New Eniac.Controles.Buscador()
      Me.lblDebe = New Eniac.Controles.Label()
      Me.bscDescripcion = New Eniac.Controles.Buscador()
      Me.SuspendLayout()
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
      Me.bscCodCuenta.LabelAsoc = Nothing
      Me.bscCodCuenta.Location = New System.Drawing.Point(43, 0)
      Me.bscCodCuenta.MaxLengh = "32767"
      Me.bscCodCuenta.Name = "bscCodCuenta"
      Me.bscCodCuenta.Permitido = True
      Me.bscCodCuenta.Selecciono = False
      Me.bscCodCuenta.Size = New System.Drawing.Size(123, 20)
      Me.bscCodCuenta.TabIndex = 1
      Me.bscCodCuenta.Titulo = Nothing
      '
      'lblDebe
      '
      Me.lblDebe.AutoSize = True
      Me.lblDebe.LabelAsoc = Nothing
      Me.lblDebe.Location = New System.Drawing.Point(0, 4)
      Me.lblDebe.Name = "lblDebe"
      Me.lblDebe.Size = New System.Drawing.Size(41, 13)
      Me.lblDebe.TabIndex = 0
      Me.lblDebe.Text = "Cuenta"
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
      Me.bscDescripcion.LabelAsoc = Nothing
      Me.bscDescripcion.Location = New System.Drawing.Point(169, 0)
      Me.bscDescripcion.MaxLengh = "32767"
      Me.bscDescripcion.Name = "bscDescripcion"
      Me.bscDescripcion.Permitido = True
      Me.bscDescripcion.Selecciono = False
      Me.bscDescripcion.Size = New System.Drawing.Size(275, 20)
      Me.bscDescripcion.TabIndex = 2
      Me.bscDescripcion.Titulo = Nothing
      '
      'ucCuentas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.bscCodCuenta)
      Me.Controls.Add(Me.lblDebe)
      Me.Controls.Add(Me.bscDescripcion)
      Me.Name = "ucCuentas"
      Me.Size = New System.Drawing.Size(444, 20)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents bscCodCuenta As Eniac.Controles.Buscador
   Friend WithEvents lblDebe As Eniac.Controles.Label
   Friend WithEvents bscDescripcion As Eniac.Controles.Buscador

End Class
