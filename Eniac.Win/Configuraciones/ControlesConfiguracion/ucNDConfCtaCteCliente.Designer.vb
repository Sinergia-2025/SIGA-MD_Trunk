<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNDConfCtaCteCliente
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
      Me.chbCtaCtePermitirModificarComprobanteAsociado = New Eniac.Controles.CheckBox()
        Me.grpCobranzaElectronica = New System.Windows.Forms.GroupBox()
        Me.chbCobranzaElectronicaHabilitaSirPlus = New Eniac.Controles.CheckBox()
        Me.chbCobranzaElectronicaHabilitaRoela = New Eniac.Controles.CheckBox()
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico = New Eniac.Controles.CheckBox()
        Me.grpCobranzaElectronica.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbCtaCtePermitirModificarComprobanteAsociado
        '
        Me.chbCtaCtePermitirModificarComprobanteAsociado.BindearPropiedadControl = Nothing
        Me.chbCtaCtePermitirModificarComprobanteAsociado.BindearPropiedadEntidad = Nothing
        Me.chbCtaCtePermitirModificarComprobanteAsociado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCtaCtePermitirModificarComprobanteAsociado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCtaCtePermitirModificarComprobanteAsociado.IsPK = False
        Me.chbCtaCtePermitirModificarComprobanteAsociado.IsRequired = False
        Me.chbCtaCtePermitirModificarComprobanteAsociado.Key = Nothing
        Me.chbCtaCtePermitirModificarComprobanteAsociado.LabelAsoc = Nothing
        Me.chbCtaCtePermitirModificarComprobanteAsociado.Location = New System.Drawing.Point(16, 14)
        Me.chbCtaCtePermitirModificarComprobanteAsociado.Name = "chbCtaCtePermitirModificarComprobanteAsociado"
        Me.chbCtaCtePermitirModificarComprobanteAsociado.Size = New System.Drawing.Size(371, 29)
        Me.chbCtaCtePermitirModificarComprobanteAsociado.TabIndex = 59
        Me.chbCtaCtePermitirModificarComprobanteAsociado.Text = "Permitir modificar Comprobante Asociado en Consulta de Debe haber"
        Me.chbCtaCtePermitirModificarComprobanteAsociado.UseVisualStyleBackColor = True
        '
        'grpCobranzaElectronica
        '
        Me.grpCobranzaElectronica.Controls.Add(Me.chbCobranzaElectronicaHabilitaDebitoAutomatico)
        Me.grpCobranzaElectronica.Controls.Add(Me.chbCobranzaElectronicaHabilitaSirPlus)
        Me.grpCobranzaElectronica.Controls.Add(Me.chbCobranzaElectronicaHabilitaRoela)
        Me.grpCobranzaElectronica.Location = New System.Drawing.Point(16, 46)
        Me.grpCobranzaElectronica.Name = "grpCobranzaElectronica"
        Me.grpCobranzaElectronica.Size = New System.Drawing.Size(346, 102)
        Me.grpCobranzaElectronica.TabIndex = 60
        Me.grpCobranzaElectronica.TabStop = False
        Me.grpCobranzaElectronica.Text = "Cobranza Electrónica"
        '
        'chbCobranzaElectronicaHabilitaSirPlus
        '
        Me.chbCobranzaElectronicaHabilitaSirPlus.AutoSize = True
        Me.chbCobranzaElectronicaHabilitaSirPlus.BindearPropiedadControl = Nothing
        Me.chbCobranzaElectronicaHabilitaSirPlus.BindearPropiedadEntidad = Nothing
        Me.chbCobranzaElectronicaHabilitaSirPlus.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCobranzaElectronicaHabilitaSirPlus.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCobranzaElectronicaHabilitaSirPlus.IsPK = False
        Me.chbCobranzaElectronicaHabilitaSirPlus.IsRequired = False
        Me.chbCobranzaElectronicaHabilitaSirPlus.Key = Nothing
        Me.chbCobranzaElectronicaHabilitaSirPlus.LabelAsoc = Nothing
        Me.chbCobranzaElectronicaHabilitaSirPlus.Location = New System.Drawing.Point(20, 46)
        Me.chbCobranzaElectronicaHabilitaSirPlus.Name = "chbCobranzaElectronicaHabilitaSirPlus"
        Me.chbCobranzaElectronicaHabilitaSirPlus.Size = New System.Drawing.Size(158, 17)
        Me.chbCobranzaElectronicaHabilitaSirPlus.TabIndex = 3
        Me.chbCobranzaElectronicaHabilitaSirPlus.Text = "Habilita Cobranza SIRPLUS"
        Me.chbCobranzaElectronicaHabilitaSirPlus.UseVisualStyleBackColor = True
        '
        'chbCobranzaElectronicaHabilitaRoela
        '
        Me.chbCobranzaElectronicaHabilitaRoela.AutoSize = True
        Me.chbCobranzaElectronicaHabilitaRoela.BindearPropiedadControl = Nothing
        Me.chbCobranzaElectronicaHabilitaRoela.BindearPropiedadEntidad = Nothing
        Me.chbCobranzaElectronicaHabilitaRoela.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCobranzaElectronicaHabilitaRoela.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCobranzaElectronicaHabilitaRoela.IsPK = False
        Me.chbCobranzaElectronicaHabilitaRoela.IsRequired = False
        Me.chbCobranzaElectronicaHabilitaRoela.Key = Nothing
        Me.chbCobranzaElectronicaHabilitaRoela.LabelAsoc = Nothing
        Me.chbCobranzaElectronicaHabilitaRoela.Location = New System.Drawing.Point(20, 23)
        Me.chbCobranzaElectronicaHabilitaRoela.Name = "chbCobranzaElectronicaHabilitaRoela"
        Me.chbCobranzaElectronicaHabilitaRoela.Size = New System.Drawing.Size(148, 17)
        Me.chbCobranzaElectronicaHabilitaRoela.TabIndex = 1
        Me.chbCobranzaElectronicaHabilitaRoela.Text = "Habilita Cobranza ROELA"
        Me.chbCobranzaElectronicaHabilitaRoela.UseVisualStyleBackColor = True
        '
        'chbCobranzaElectronicaHabilitaDebitoAutomatico
        '
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.AutoSize = True
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.BindearPropiedadControl = Nothing
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.BindearPropiedadEntidad = Nothing
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.IsPK = False
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.IsRequired = False
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.Key = Nothing
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.LabelAsoc = Nothing
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.Location = New System.Drawing.Point(20, 69)
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.Name = "chbCobranzaElectronicaHabilitaDebitoAutomatico"
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.Size = New System.Drawing.Size(161, 17)
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.TabIndex = 4
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.Text = "Habilita Débitos Automáticos"
        Me.chbCobranzaElectronicaHabilitaDebitoAutomatico.UseVisualStyleBackColor = True
        '
        'ucNDConfCtaCteCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpCobranzaElectronica)
        Me.Controls.Add(Me.chbCtaCtePermitirModificarComprobanteAsociado)
        Me.Name = "ucNDConfCtaCteCliente"
        Me.Controls.SetChildIndex(Me.chbCtaCtePermitirModificarComprobanteAsociado, 0)
        Me.Controls.SetChildIndex(Me.grpCobranzaElectronica, 0)
        Me.grpCobranzaElectronica.ResumeLayout(False)
        Me.grpCobranzaElectronica.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbCtaCtePermitirModificarComprobanteAsociado As Controles.CheckBox
    Friend WithEvents grpCobranzaElectronica As GroupBox
    Friend WithEvents chbCobranzaElectronicaHabilitaDebitoAutomatico As Controles.CheckBox
    Friend WithEvents chbCobranzaElectronicaHabilitaSirPlus As Controles.CheckBox
    Friend WithEvents chbCobranzaElectronicaHabilitaRoela As Controles.CheckBox
End Class
