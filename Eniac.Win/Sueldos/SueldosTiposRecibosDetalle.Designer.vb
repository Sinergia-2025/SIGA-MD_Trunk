<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosTiposRecibosDetalle
   Inherits BaseDetalle

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.txtNombreTipoRecibo = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtIdTipoRecibo = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtPeriodoLiquidacion = New Eniac.Controles.TextBox()
      Me.lblPeriodoLiquidacion = New Eniac.Controles.Label()
      Me.txtNumeroLiquidacion = New Eniac.Controles.TextBox()
      Me.lblNroLiquidacion = New Eniac.Controles.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.chbImprimeRecibo = New Eniac.Controles.CheckBox()
      Me.TextBox1 = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.TextBox2 = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.chbLiquidacionEventual = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(193, 175)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(279, 175)
      Me.btnCancelar.TabIndex = 9
      '
      'txtNombreTipoRecibo
      '
      Me.txtNombreTipoRecibo.BindearPropiedadControl = "Text"
      Me.txtNombreTipoRecibo.BindearPropiedadEntidad = "NombreTipoRecibo"
      Me.txtNombreTipoRecibo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTipoRecibo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTipoRecibo.Formato = ""
      Me.txtNombreTipoRecibo.IsDecimal = False
      Me.txtNombreTipoRecibo.IsNumber = False
      Me.txtNombreTipoRecibo.IsPK = False
      Me.txtNombreTipoRecibo.IsRequired = True
      Me.txtNombreTipoRecibo.Key = ""
      Me.txtNombreTipoRecibo.LabelAsoc = Me.lblNombre
      Me.txtNombreTipoRecibo.Location = New System.Drawing.Point(63, 42)
      Me.txtNombreTipoRecibo.MaxLength = 50
      Me.txtNombreTipoRecibo.Name = "txtNombreTipoRecibo"
      Me.txtNombreTipoRecibo.Size = New System.Drawing.Size(291, 20)
      Me.txtNombreTipoRecibo.TabIndex = 1
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(8, 49)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 11
      Me.lblNombre.Text = "Nombre"
      '
      'txtIdTipoRecibo
      '
      Me.txtIdTipoRecibo.BindearPropiedadControl = "Text"
      Me.txtIdTipoRecibo.BindearPropiedadEntidad = "IdTipoRecibo"
      Me.txtIdTipoRecibo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoRecibo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoRecibo.Formato = ""
      Me.txtIdTipoRecibo.IsDecimal = False
      Me.txtIdTipoRecibo.IsNumber = False
      Me.txtIdTipoRecibo.IsPK = True
      Me.txtIdTipoRecibo.IsRequired = True
      Me.txtIdTipoRecibo.Key = ""
      Me.txtIdTipoRecibo.LabelAsoc = Me.lblCodigo
      Me.txtIdTipoRecibo.Location = New System.Drawing.Point(63, 16)
      Me.txtIdTipoRecibo.MaxLength = 4
      Me.txtIdTipoRecibo.Name = "txtIdTipoRecibo"
      Me.txtIdTipoRecibo.Size = New System.Drawing.Size(69, 20)
      Me.txtIdTipoRecibo.TabIndex = 0
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(8, 23)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(28, 13)
      Me.lblCodigo.TabIndex = 10
      Me.lblCodigo.Text = "Tipo"
      '
      'txtPeriodoLiquidacion
      '
      Me.txtPeriodoLiquidacion.BindearPropiedadControl = "Text"
      Me.txtPeriodoLiquidacion.BindearPropiedadEntidad = "PeriodoLiquidacion"
      Me.txtPeriodoLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPeriodoLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPeriodoLiquidacion.Formato = "9999-99"
      Me.txtPeriodoLiquidacion.IsDecimal = False
      Me.txtPeriodoLiquidacion.IsNumber = True
      Me.txtPeriodoLiquidacion.IsPK = True
      Me.txtPeriodoLiquidacion.IsRequired = True
      Me.txtPeriodoLiquidacion.Key = ""
      Me.txtPeriodoLiquidacion.LabelAsoc = Me.lblPeriodoLiquidacion
      Me.txtPeriodoLiquidacion.Location = New System.Drawing.Point(146, 68)
      Me.txtPeriodoLiquidacion.MaxLength = 6
      Me.txtPeriodoLiquidacion.Name = "txtPeriodoLiquidacion"
      Me.txtPeriodoLiquidacion.Size = New System.Drawing.Size(55, 20)
      Me.txtPeriodoLiquidacion.TabIndex = 2
      Me.ToolTip1.SetToolTip(Me.txtPeriodoLiquidacion, "Año y Mes (aaaamm)")
      '
      'lblPeriodoLiquidacion
      '
      Me.lblPeriodoLiquidacion.Location = New System.Drawing.Point(2, 73)
      Me.lblPeriodoLiquidacion.Name = "lblPeriodoLiquidacion"
      Me.lblPeriodoLiquidacion.Size = New System.Drawing.Size(127, 30)
      Me.lblPeriodoLiquidacion.TabIndex = 12
      Me.lblPeriodoLiquidacion.Text = "Período Liquidación - Año Mes (aaaamm)"
      Me.lblPeriodoLiquidacion.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'txtNumeroLiquidacion
      '
      Me.txtNumeroLiquidacion.BindearPropiedadControl = "Text"
      Me.txtNumeroLiquidacion.BindearPropiedadEntidad = "NumeroLiquidacion"
      Me.txtNumeroLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroLiquidacion.Formato = ""
      Me.txtNumeroLiquidacion.IsDecimal = False
      Me.txtNumeroLiquidacion.IsNumber = True
      Me.txtNumeroLiquidacion.IsPK = True
      Me.txtNumeroLiquidacion.IsRequired = True
      Me.txtNumeroLiquidacion.Key = ""
      Me.txtNumeroLiquidacion.LabelAsoc = Me.lblNroLiquidacion
      Me.txtNumeroLiquidacion.Location = New System.Drawing.Point(301, 68)
      Me.txtNumeroLiquidacion.MaxLength = 4
      Me.txtNumeroLiquidacion.Name = "txtNumeroLiquidacion"
      Me.txtNumeroLiquidacion.Size = New System.Drawing.Size(53, 20)
      Me.txtNumeroLiquidacion.TabIndex = 3
      Me.txtNumeroLiquidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNroLiquidacion
      '
      Me.lblNroLiquidacion.AutoSize = True
      Me.lblNroLiquidacion.Location = New System.Drawing.Point(211, 73)
      Me.lblNroLiquidacion.Name = "lblNroLiquidacion"
      Me.lblNroLiquidacion.Size = New System.Drawing.Size(84, 13)
      Me.lblNroLiquidacion.TabIndex = 15
      Me.lblNroLiquidacion.Text = "Nro. Liquidación"
      '
      'chbImprimeRecibo
      '
      Me.chbImprimeRecibo.AutoSize = True
      Me.chbImprimeRecibo.BindearPropiedadControl = "Checked"
      Me.chbImprimeRecibo.BindearPropiedadEntidad = "ImprimeRecibo"
      Me.chbImprimeRecibo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImprimeRecibo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImprimeRecibo.IsPK = False
      Me.chbImprimeRecibo.IsRequired = False
      Me.chbImprimeRecibo.Key = Nothing
      Me.chbImprimeRecibo.LabelAsoc = Nothing
      Me.chbImprimeRecibo.Location = New System.Drawing.Point(243, 120)
      Me.chbImprimeRecibo.Name = "chbImprimeRecibo"
      Me.chbImprimeRecibo.Size = New System.Drawing.Size(99, 17)
      Me.chbImprimeRecibo.TabIndex = 6
      Me.chbImprimeRecibo.Text = "Imprime Recibo"
      Me.chbImprimeRecibo.UseVisualStyleBackColor = True
      '
      'TextBox1
      '
      Me.TextBox1.BindearPropiedadControl = "Text"
      Me.TextBox1.BindearPropiedadEntidad = "CantidadLiquid"
      Me.TextBox1.ForeColorFocus = System.Drawing.Color.Red
      Me.TextBox1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.TextBox1.Formato = ""
      Me.TextBox1.IsDecimal = False
      Me.TextBox1.IsNumber = True
      Me.TextBox1.IsPK = True
      Me.TextBox1.IsRequired = True
      Me.TextBox1.Key = ""
      Me.TextBox1.LabelAsoc = Me.Label1
      Me.TextBox1.Location = New System.Drawing.Point(170, 115)
      Me.TextBox1.MaxLength = 4
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(53, 20)
      Me.TextBox1.TabIndex = 4
      Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 121)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(117, 13)
      Me.Label1.TabIndex = 13
      Me.Label1.Text = "Cantidad Liquidaciones"
      '
      'TextBox2
      '
      Me.TextBox2.BindearPropiedadControl = "Text"
      Me.TextBox2.BindearPropiedadEntidad = "CantidadLiquidPeriodo"
      Me.TextBox2.ForeColorFocus = System.Drawing.Color.Red
      Me.TextBox2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.TextBox2.Formato = ""
      Me.TextBox2.IsDecimal = False
      Me.TextBox2.IsNumber = True
      Me.TextBox2.IsPK = True
      Me.TextBox2.IsRequired = True
      Me.TextBox2.Key = ""
      Me.TextBox2.LabelAsoc = Me.Label2
      Me.TextBox2.Location = New System.Drawing.Point(170, 141)
      Me.TextBox2.MaxLength = 4
      Me.TextBox2.Name = "TextBox2"
      Me.TextBox2.Size = New System.Drawing.Size(53, 20)
      Me.TextBox2.TabIndex = 5
      Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 147)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(156, 13)
      Me.Label2.TabIndex = 14
      Me.Label2.Text = "Cantidad Liquidaciones Periodo"
      '
      'chbLiquidacionEventual
      '
      Me.chbLiquidacionEventual.AutoSize = True
      Me.chbLiquidacionEventual.BindearPropiedadControl = "Checked"
      Me.chbLiquidacionEventual.BindearPropiedadEntidad = "LiquidacionEventual"
      Me.chbLiquidacionEventual.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLiquidacionEventual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLiquidacionEventual.IsPK = False
      Me.chbLiquidacionEventual.IsRequired = False
      Me.chbLiquidacionEventual.Key = Nothing
      Me.chbLiquidacionEventual.LabelAsoc = Nothing
      Me.chbLiquidacionEventual.Location = New System.Drawing.Point(243, 143)
      Me.chbLiquidacionEventual.Name = "chbLiquidacionEventual"
      Me.chbLiquidacionEventual.Size = New System.Drawing.Size(124, 17)
      Me.chbLiquidacionEventual.TabIndex = 7
      Me.chbLiquidacionEventual.Text = "Liquidación eventual"
      Me.chbLiquidacionEventual.UseVisualStyleBackColor = True
      '
      'SueldosTiposRecibosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(368, 210)
      Me.Controls.Add(Me.chbLiquidacionEventual)
      Me.Controls.Add(Me.TextBox2)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.chbImprimeRecibo)
      Me.Controls.Add(Me.txtNumeroLiquidacion)
      Me.Controls.Add(Me.lblNroLiquidacion)
      Me.Controls.Add(Me.txtPeriodoLiquidacion)
      Me.Controls.Add(Me.lblPeriodoLiquidacion)
      Me.Controls.Add(Me.txtNombreTipoRecibo)
      Me.Controls.Add(Me.txtIdTipoRecibo)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Name = "SueldosTiposRecibosDetalle"
      Me.Text = "Tipo de Recibo"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoRecibo, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTipoRecibo, 0)
      Me.Controls.SetChildIndex(Me.lblPeriodoLiquidacion, 0)
      Me.Controls.SetChildIndex(Me.txtPeriodoLiquidacion, 0)
      Me.Controls.SetChildIndex(Me.lblNroLiquidacion, 0)
      Me.Controls.SetChildIndex(Me.txtNumeroLiquidacion, 0)
      Me.Controls.SetChildIndex(Me.chbImprimeRecibo, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.TextBox1, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.TextBox2, 0)
      Me.Controls.SetChildIndex(Me.chbLiquidacionEventual, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtNombreTipoRecibo As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtIdTipoRecibo As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtPeriodoLiquidacion As Eniac.Controles.TextBox
   Friend WithEvents lblPeriodoLiquidacion As Eniac.Controles.Label
   Friend WithEvents txtNumeroLiquidacion As Eniac.Controles.TextBox
   Friend WithEvents lblNroLiquidacion As Eniac.Controles.Label
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents chbImprimeRecibo As Eniac.Controles.CheckBox
   Friend WithEvents TextBox1 As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents TextBox2 As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents chbLiquidacionEventual As Eniac.Controles.CheckBox
End Class
