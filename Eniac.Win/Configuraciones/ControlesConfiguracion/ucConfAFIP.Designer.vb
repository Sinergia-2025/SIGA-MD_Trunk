<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfAFIP
   Inherits ucConfBase

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
      Me.grpProrrateoCitiCompras = New System.Windows.Forms.GroupBox()
      Me.radProrrateoCitiComprasGlobal = New System.Windows.Forms.RadioButton()
      Me.radProrrateoCitiComprasPorComprobante = New System.Windows.Forms.RadioButton()
      Me.chbProrrateoCitiCompras = New Eniac.Controles.CheckBox()
      Me.chbAFIPHabilitaVentasPeriodoAutomaticamente = New Eniac.Controles.CheckBox()
        Me.chbAFIPUtilizaCM05 = New Eniac.Controles.CheckBox()
        Me.grpProrrateoCitiCompras.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpProrrateoCitiCompras
        '
        Me.grpProrrateoCitiCompras.Controls.Add(Me.radProrrateoCitiComprasGlobal)
        Me.grpProrrateoCitiCompras.Controls.Add(Me.radProrrateoCitiComprasPorComprobante)
        Me.grpProrrateoCitiCompras.Controls.Add(Me.chbProrrateoCitiCompras)
        Me.grpProrrateoCitiCompras.Location = New System.Drawing.Point(31, 72)
        Me.grpProrrateoCitiCompras.Name = "grpProrrateoCitiCompras"
        Me.grpProrrateoCitiCompras.Size = New System.Drawing.Size(249, 94)
        Me.grpProrrateoCitiCompras.TabIndex = 60
        Me.grpProrrateoCitiCompras.TabStop = False
        Me.grpProrrateoCitiCompras.Text = "Prorrateo Citi Compras"
        '
        'radProrrateoCitiComprasGlobal
        '
        Me.radProrrateoCitiComprasGlobal.AutoSize = True
        Me.radProrrateoCitiComprasGlobal.Location = New System.Drawing.Point(25, 65)
        Me.radProrrateoCitiComprasGlobal.Name = "radProrrateoCitiComprasGlobal"
        Me.radProrrateoCitiComprasGlobal.Size = New System.Drawing.Size(55, 17)
        Me.radProrrateoCitiComprasGlobal.TabIndex = 14
        Me.radProrrateoCitiComprasGlobal.Tag = ""
        Me.radProrrateoCitiComprasGlobal.Text = "Global"
        Me.radProrrateoCitiComprasGlobal.UseVisualStyleBackColor = True
        Me.radProrrateoCitiComprasGlobal.Visible = False
        '
        'radProrrateoCitiComprasPorComprobante
        '
        Me.radProrrateoCitiComprasPorComprobante.AutoSize = True
        Me.radProrrateoCitiComprasPorComprobante.Checked = True
        Me.radProrrateoCitiComprasPorComprobante.Location = New System.Drawing.Point(25, 42)
        Me.radProrrateoCitiComprasPorComprobante.Name = "radProrrateoCitiComprasPorComprobante"
        Me.radProrrateoCitiComprasPorComprobante.Size = New System.Drawing.Size(107, 17)
        Me.radProrrateoCitiComprasPorComprobante.TabIndex = 13
        Me.radProrrateoCitiComprasPorComprobante.TabStop = True
        Me.radProrrateoCitiComprasPorComprobante.Tag = ""
        Me.radProrrateoCitiComprasPorComprobante.Text = "Por Comprobante"
        Me.radProrrateoCitiComprasPorComprobante.UseVisualStyleBackColor = True
        Me.radProrrateoCitiComprasPorComprobante.Visible = False
        '
        'chbProrrateoCitiCompras
        '
        Me.chbProrrateoCitiCompras.AutoSize = True
        Me.chbProrrateoCitiCompras.BindearPropiedadControl = Nothing
        Me.chbProrrateoCitiCompras.BindearPropiedadEntidad = Nothing
        Me.chbProrrateoCitiCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProrrateoCitiCompras.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProrrateoCitiCompras.IsPK = False
        Me.chbProrrateoCitiCompras.IsRequired = False
        Me.chbProrrateoCitiCompras.Key = Nothing
        Me.chbProrrateoCitiCompras.LabelAsoc = Nothing
        Me.chbProrrateoCitiCompras.Location = New System.Drawing.Point(25, 19)
        Me.chbProrrateoCitiCompras.Name = "chbProrrateoCitiCompras"
        Me.chbProrrateoCitiCompras.Size = New System.Drawing.Size(209, 17)
        Me.chbProrrateoCitiCompras.TabIndex = 12
        Me.chbProrrateoCitiCompras.Text = "¿Prorratear Crédito Fiscal Computable?"
        Me.chbProrrateoCitiCompras.UseVisualStyleBackColor = True
        '
        'chbAFIPHabilitaVentasPeriodoAutomaticamente
        '
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.AutoSize = True
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.BindearPropiedadControl = Nothing
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.BindearPropiedadEntidad = Nothing
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.IsPK = False
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.IsRequired = False
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.Key = Nothing
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.LabelAsoc = Nothing
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.Location = New System.Drawing.Point(31, 26)
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.Name = "chbAFIPHabilitaVentasPeriodoAutomaticamente"
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.Size = New System.Drawing.Size(239, 17)
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.TabIndex = 59
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.Text = "Habilita ventas en nuevo periodo por defecto"
        Me.chbAFIPHabilitaVentasPeriodoAutomaticamente.UseVisualStyleBackColor = True
        '
        'chbAFIPUtilizaCM05
        '
        Me.chbAFIPUtilizaCM05.AutoSize = True
        Me.chbAFIPUtilizaCM05.BindearPropiedadControl = Nothing
        Me.chbAFIPUtilizaCM05.BindearPropiedadEntidad = Nothing
        Me.chbAFIPUtilizaCM05.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAFIPUtilizaCM05.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAFIPUtilizaCM05.IsPK = False
        Me.chbAFIPUtilizaCM05.IsRequired = False
        Me.chbAFIPUtilizaCM05.Key = Nothing
        Me.chbAFIPUtilizaCM05.LabelAsoc = Nothing
        Me.chbAFIPUtilizaCM05.Location = New System.Drawing.Point(31, 194)
        Me.chbAFIPUtilizaCM05.Name = "chbAFIPUtilizaCM05"
        Me.chbAFIPUtilizaCM05.Size = New System.Drawing.Size(213, 17)
        Me.chbAFIPUtilizaCM05.TabIndex = 61
        Me.chbAFIPUtilizaCM05.Text = "Utiliza declaración jurada anual o CM05"
        Me.chbAFIPUtilizaCM05.UseVisualStyleBackColor = True
        '
        'ucConfAFIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbAFIPUtilizaCM05)
        Me.Controls.Add(Me.grpProrrateoCitiCompras)
        Me.Controls.Add(Me.chbAFIPHabilitaVentasPeriodoAutomaticamente)
        Me.Name = "ucConfAFIP"
        Me.Controls.SetChildIndex(Me.chbAFIPHabilitaVentasPeriodoAutomaticamente, 0)
        Me.Controls.SetChildIndex(Me.grpProrrateoCitiCompras, 0)
        Me.Controls.SetChildIndex(Me.chbAFIPUtilizaCM05, 0)
        Me.grpProrrateoCitiCompras.ResumeLayout(False)
        Me.grpProrrateoCitiCompras.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpProrrateoCitiCompras As GroupBox
   Friend WithEvents radProrrateoCitiComprasGlobal As RadioButton
   Friend WithEvents radProrrateoCitiComprasPorComprobante As RadioButton
   Friend WithEvents chbProrrateoCitiCompras As Controles.CheckBox
   Friend WithEvents chbAFIPHabilitaVentasPeriodoAutomaticamente As Controles.CheckBox
    Friend WithEvents chbAFIPUtilizaCM05 As Controles.CheckBox
End Class
