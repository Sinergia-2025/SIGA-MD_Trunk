<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosVentaDetalle
   Inherits BaseDetalle

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
      Me.lblNombreEstadoVenta = New Eniac.Controles.Label()
      Me.txtNombreEstadoVenta = New Eniac.Controles.TextBox()
      Me.lblIdEstadoVenta = New Eniac.Controles.Label()
      Me.txtIdEstadoVenta = New Eniac.Controles.TextBox()
      Me.chbRealizaContramovStockNC = New Eniac.Controles.CheckBox()
      Me.cmbTipoMovimiento = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(211, 143)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(297, 143)
      Me.btnCancelar.TabIndex = 5
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 143)
      Me.btnCopiar.TabIndex = 10
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(53, 143)
      Me.btnAplicar.TabIndex = 9
      '
      'lblNombreEstadoVenta
      '
      Me.lblNombreEstadoVenta.AutoSize = True
      Me.lblNombreEstadoVenta.LabelAsoc = Nothing
      Me.lblNombreEstadoVenta.Location = New System.Drawing.Point(32, 56)
      Me.lblNombreEstadoVenta.Name = "lblNombreEstadoVenta"
      Me.lblNombreEstadoVenta.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreEstadoVenta.TabIndex = 7
      Me.lblNombreEstadoVenta.Text = "Nombre"
      '
      'txtNombreEstadoVenta
      '
      Me.txtNombreEstadoVenta.BindearPropiedadControl = "Text"
      Me.txtNombreEstadoVenta.BindearPropiedadEntidad = "NombreEstadoVenta"
      Me.txtNombreEstadoVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreEstadoVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreEstadoVenta.Formato = ""
      Me.txtNombreEstadoVenta.IsDecimal = False
      Me.txtNombreEstadoVenta.IsNumber = False
      Me.txtNombreEstadoVenta.IsPK = False
      Me.txtNombreEstadoVenta.IsRequired = True
      Me.txtNombreEstadoVenta.Key = ""
      Me.txtNombreEstadoVenta.LabelAsoc = Me.lblNombreEstadoVenta
      Me.txtNombreEstadoVenta.Location = New System.Drawing.Point(88, 49)
      Me.txtNombreEstadoVenta.MaxLength = 50
      Me.txtNombreEstadoVenta.Name = "txtNombreEstadoVenta"
      Me.txtNombreEstadoVenta.Size = New System.Drawing.Size(275, 20)
      Me.txtNombreEstadoVenta.TabIndex = 1
      '
      'lblIdEstadoVenta
      '
      Me.lblIdEstadoVenta.AutoSize = True
      Me.lblIdEstadoVenta.LabelAsoc = Nothing
      Me.lblIdEstadoVenta.Location = New System.Drawing.Point(32, 30)
      Me.lblIdEstadoVenta.Name = "lblIdEstadoVenta"
      Me.lblIdEstadoVenta.Size = New System.Drawing.Size(40, 13)
      Me.lblIdEstadoVenta.TabIndex = 6
      Me.lblIdEstadoVenta.Text = "Código"
      '
      'txtIdEstadoVenta
      '
      Me.txtIdEstadoVenta.BindearPropiedadControl = "Text"
      Me.txtIdEstadoVenta.BindearPropiedadEntidad = "IdEstadoVenta"
      Me.txtIdEstadoVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdEstadoVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdEstadoVenta.Formato = ""
      Me.txtIdEstadoVenta.IsDecimal = False
      Me.txtIdEstadoVenta.IsNumber = True
      Me.txtIdEstadoVenta.IsPK = True
      Me.txtIdEstadoVenta.IsRequired = True
      Me.txtIdEstadoVenta.Key = ""
      Me.txtIdEstadoVenta.LabelAsoc = Me.lblIdEstadoVenta
      Me.txtIdEstadoVenta.Location = New System.Drawing.Point(88, 23)
      Me.txtIdEstadoVenta.MaxLength = 9
      Me.txtIdEstadoVenta.Name = "txtIdEstadoVenta"
      Me.txtIdEstadoVenta.Size = New System.Drawing.Size(77, 20)
      Me.txtIdEstadoVenta.TabIndex = 0
      Me.txtIdEstadoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbRealizaContramovStockNC
      '
      Me.chbRealizaContramovStockNC.AutoSize = True
      Me.chbRealizaContramovStockNC.BindearPropiedadControl = ""
      Me.chbRealizaContramovStockNC.BindearPropiedadEntidad = ""
      Me.chbRealizaContramovStockNC.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRealizaContramovStockNC.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRealizaContramovStockNC.IsPK = False
      Me.chbRealizaContramovStockNC.IsRequired = False
      Me.chbRealizaContramovStockNC.Key = Nothing
      Me.chbRealizaContramovStockNC.LabelAsoc = Nothing
      Me.chbRealizaContramovStockNC.Location = New System.Drawing.Point(88, 82)
      Me.chbRealizaContramovStockNC.Name = "chbRealizaContramovStockNC"
      Me.chbRealizaContramovStockNC.Size = New System.Drawing.Size(227, 17)
      Me.chbRealizaContramovStockNC.TabIndex = 2
      Me.chbRealizaContramovStockNC.Text = "Realiza Contramovimiento de Stock en NC"
      Me.chbRealizaContramovStockNC.UseVisualStyleBackColor = True
      '
      'cmbTipoMovimiento
      '
      Me.cmbTipoMovimiento.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoMovimiento.BindearPropiedadEntidad = "IdTipoMovimiento"
      Me.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoMovimiento.Enabled = False
      Me.cmbTipoMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoMovimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoMovimiento.FormattingEnabled = True
      Me.cmbTipoMovimiento.IsPK = False
      Me.cmbTipoMovimiento.IsRequired = False
      Me.cmbTipoMovimiento.Key = Nothing
      Me.cmbTipoMovimiento.LabelAsoc = Nothing
      Me.cmbTipoMovimiento.Location = New System.Drawing.Point(199, 105)
      Me.cmbTipoMovimiento.Name = "cmbTipoMovimiento"
      Me.cmbTipoMovimiento.Size = New System.Drawing.Size(164, 21)
      Me.cmbTipoMovimiento.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(107, 108)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(85, 13)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "Tipo Movimiento"
      '
      'EstadosVentaDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 178)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmbTipoMovimiento)
      Me.Controls.Add(Me.chbRealizaContramovStockNC)
      Me.Controls.Add(Me.lblNombreEstadoVenta)
      Me.Controls.Add(Me.txtNombreEstadoVenta)
      Me.Controls.Add(Me.lblIdEstadoVenta)
      Me.Controls.Add(Me.txtIdEstadoVenta)
      Me.Name = "EstadosVentaDetalle"
      Me.Text = "Estado de Venta"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdEstadoVenta, 0)
      Me.Controls.SetChildIndex(Me.lblIdEstadoVenta, 0)
      Me.Controls.SetChildIndex(Me.txtNombreEstadoVenta, 0)
      Me.Controls.SetChildIndex(Me.lblNombreEstadoVenta, 0)
      Me.Controls.SetChildIndex(Me.chbRealizaContramovStockNC, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoMovimiento, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreEstadoVenta As Eniac.Controles.Label
   Friend WithEvents txtNombreEstadoVenta As Eniac.Controles.TextBox
   Friend WithEvents lblIdEstadoVenta As Eniac.Controles.Label
   Friend WithEvents txtIdEstadoVenta As Eniac.Controles.TextBox
   Friend WithEvents chbRealizaContramovStockNC As Eniac.Controles.CheckBox
   Friend WithEvents cmbTipoMovimiento As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
End Class
