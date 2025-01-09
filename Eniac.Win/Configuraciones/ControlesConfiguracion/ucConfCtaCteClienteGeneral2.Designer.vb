<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucConfCtaCteClienteGeneral2
    Inherits ucConfBase

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos = New Eniac.Controles.CheckBox()
        Me.chbSaldoLimiteDeCreditoContemplaPedidos = New Eniac.Controles.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro = New Eniac.Controles.TextBox()
        Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro = New Eniac.Controles.Label()
        Me.gpbPremioPorCobranza = New System.Windows.Forms.GroupBox()
        Me.txtPremioPorCobranza = New Eniac.Controles.TextBox()
        Me.lblPremioPorCobranza = New Eniac.Controles.Label()
        Me.GroupBox1.SuspendLayout()
        Me.gpbPremioPorCobranza.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbSaldoLimiteDeCreditoContemplaAnticipos
        '
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.AutoSize = True
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.BindearPropiedadControl = Nothing
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.BindearPropiedadEntidad = Nothing
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.IsPK = False
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.IsRequired = False
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.Key = Nothing
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.LabelAsoc = Nothing
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.Location = New System.Drawing.Point(13, 42)
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.Name = "chbSaldoLimiteDeCreditoContemplaAnticipos"
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.Size = New System.Drawing.Size(282, 17)
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.TabIndex = 18
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.Tag = ""
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.Text = "Contempla Anticipos para Cálculo de Límite de Crédito"
        Me.chbSaldoLimiteDeCreditoContemplaAnticipos.UseVisualStyleBackColor = True
        '
        'chbSaldoLimiteDeCreditoContemplaPedidos
        '
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.AutoSize = True
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.BindearPropiedadControl = Nothing
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.BindearPropiedadEntidad = Nothing
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.IsPK = False
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.IsRequired = False
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.Key = Nothing
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.LabelAsoc = Nothing
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.Location = New System.Drawing.Point(13, 19)
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.Name = "chbSaldoLimiteDeCreditoContemplaPedidos"
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.Size = New System.Drawing.Size(277, 17)
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.TabIndex = 17
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.Text = "Contempla Pedidos para Cálculo de Límite de Crédito"
        Me.chbSaldoLimiteDeCreditoContemplaPedidos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro)
        Me.GroupBox1.Controls.Add(Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro)
        Me.GroupBox1.Controls.Add(Me.chbSaldoLimiteDeCreditoContemplaAnticipos)
        Me.GroupBox1.Controls.Add(Me.chbSaldoLimiteDeCreditoContemplaPedidos)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(359, 99)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cálculo Situación Crediticia"
        '
        'txtSaldoLimiteDeCreditoDiasSumarFechaCobro
        '
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.BindearPropiedadControl = Nothing
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.BindearPropiedadEntidad = Nothing
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.Formato = ""
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.IsDecimal = True
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.IsNumber = True
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.IsPK = False
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.IsRequired = False
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.Key = ""
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.LabelAsoc = Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.Location = New System.Drawing.Point(306, 65)
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.MaxLength = 3
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.Name = "txtSaldoLimiteDeCreditoDiasSumarFechaCobro"
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.Size = New System.Drawing.Size(46, 20)
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.TabIndex = 29
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.Text = "-15"
        Me.txtSaldoLimiteDeCreditoDiasSumarFechaCobro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoLimiteDeCreditoDiasSumarFechaCobro
        '
        Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro.AutoSize = True
        Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro.LabelAsoc = Nothing
        Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro.Location = New System.Drawing.Point(29, 69)
        Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro.Name = "lblSaldoLimiteDeCreditoDiasSumarFechaCobro"
        Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro.Size = New System.Drawing.Size(271, 13)
        Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro.TabIndex = 30
        Me.lblSaldoLimiteDeCreditoDiasSumarFechaCobro.Text = "Cantidad días sumar a Fecha Desde de Cobro Cheques"
        '
        'gpbPremioPorCobranza
        '
        Me.gpbPremioPorCobranza.Controls.Add(Me.txtPremioPorCobranza)
        Me.gpbPremioPorCobranza.Controls.Add(Me.lblPremioPorCobranza)
        Me.gpbPremioPorCobranza.Location = New System.Drawing.Point(7, 151)
        Me.gpbPremioPorCobranza.Name = "gpbPremioPorCobranza"
        Me.gpbPremioPorCobranza.Size = New System.Drawing.Size(359, 58)
        Me.gpbPremioPorCobranza.TabIndex = 60
        Me.gpbPremioPorCobranza.TabStop = False
        Me.gpbPremioPorCobranza.Text = "Premios por Cobranza"
        '
        'txtPremioPorCobranza
        '
        Me.txtPremioPorCobranza.BindearPropiedadControl = Nothing
        Me.txtPremioPorCobranza.BindearPropiedadEntidad = Nothing
        Me.txtPremioPorCobranza.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPremioPorCobranza.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPremioPorCobranza.Formato = ""
        Me.txtPremioPorCobranza.IsDecimal = False
        Me.txtPremioPorCobranza.IsNumber = True
        Me.txtPremioPorCobranza.IsPK = False
        Me.txtPremioPorCobranza.IsRequired = False
        Me.txtPremioPorCobranza.Key = ""
        Me.txtPremioPorCobranza.LabelAsoc = Me.lblPremioPorCobranza
        Me.txtPremioPorCobranza.Location = New System.Drawing.Point(306, 22)
        Me.txtPremioPorCobranza.MaxLength = 3
        Me.txtPremioPorCobranza.Name = "txtPremioPorCobranza"
        Me.txtPremioPorCobranza.Size = New System.Drawing.Size(46, 20)
        Me.txtPremioPorCobranza.TabIndex = 29
        Me.txtPremioPorCobranza.Text = "0"
        Me.txtPremioPorCobranza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPremioPorCobranza
        '
        Me.lblPremioPorCobranza.AutoSize = True
        Me.lblPremioPorCobranza.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPremioPorCobranza.LabelAsoc = Nothing
        Me.lblPremioPorCobranza.Location = New System.Drawing.Point(10, 25)
        Me.lblPremioPorCobranza.Name = "lblPremioPorCobranza"
        Me.lblPremioPorCobranza.Size = New System.Drawing.Size(274, 13)
        Me.lblPremioPorCobranza.TabIndex = 30
        Me.lblPremioPorCobranza.Text = "Cantidad de Días cobra Premio (desde Emisión de Fact.)"
        '
        'ucConfCtaCteClienteGeneral2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gpbPremioPorCobranza)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ucConfCtaCteClienteGeneral2"
        Me.Size = New System.Drawing.Size(900, 428)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.gpbPremioPorCobranza, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpbPremioPorCobranza.ResumeLayout(False)
        Me.gpbPremioPorCobranza.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chbSaldoLimiteDeCreditoContemplaAnticipos As Controles.CheckBox
    Friend WithEvents chbSaldoLimiteDeCreditoContemplaPedidos As Controles.CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtSaldoLimiteDeCreditoDiasSumarFechaCobro As Controles.TextBox
    Friend WithEvents lblSaldoLimiteDeCreditoDiasSumarFechaCobro As Controles.Label
    Friend WithEvents gpbPremioPorCobranza As GroupBox
    Friend WithEvents txtPremioPorCobranza As Controles.TextBox
    Friend WithEvents lblPremioPorCobranza As Controles.Label
End Class
