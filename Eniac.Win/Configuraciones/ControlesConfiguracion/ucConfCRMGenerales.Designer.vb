<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfCRMGenerales
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
      Me.chbPermiteAbrirMultiplesNovedadesNuevas = New Eniac.Controles.CheckBox()
      Me.txtDiasAVencerAlertas = New Eniac.Controles.TextBox()
      Me.lblDiasAVencerAlertas = New Eniac.Controles.Label()
      Me.chbSoloMuestraUsuariosActivos = New Eniac.Controles.CheckBox()
      Me.chbPermiteEnvioMailsDesdeNovedad = New Eniac.Controles.CheckBox()
      Me.chbMuestraSolapaMasInfo = New Eniac.Controles.CheckBox()
      Me.chbReportaCategoriaNovedades = New Eniac.Controles.CheckBox()
        Me.chbPermiteAbrirMultiplesNovedadesEditar = New Eniac.Controles.CheckBox()
        Me.chbCRMImporteConIVA = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'chbPermiteAbrirMultiplesNovedadesNuevas
        '
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.BindearPropiedadControl = Nothing
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.BindearPropiedadEntidad = Nothing
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.IsPK = False
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.IsRequired = False
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.Key = Nothing
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.LabelAsoc = Nothing
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.Location = New System.Drawing.Point(30, 56)
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.Name = "chbPermiteAbrirMultiplesNovedadesNuevas"
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.Size = New System.Drawing.Size(230, 27)
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.TabIndex = 0
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.Tag = "PERMITEABRIRMULTIPLESNOVEDADESNUEVAS"
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.Text = "Permite abrir múltiples Novedades nuevas"
        Me.chbPermiteAbrirMultiplesNovedadesNuevas.UseVisualStyleBackColor = True
        '
        'txtDiasAVencerAlertas
        '
        Me.txtDiasAVencerAlertas.BindearPropiedadControl = Nothing
        Me.txtDiasAVencerAlertas.BindearPropiedadEntidad = Nothing
        Me.txtDiasAVencerAlertas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasAVencerAlertas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasAVencerAlertas.Formato = ""
        Me.txtDiasAVencerAlertas.IsDecimal = False
        Me.txtDiasAVencerAlertas.IsNumber = True
        Me.txtDiasAVencerAlertas.IsPK = False
        Me.txtDiasAVencerAlertas.IsRequired = False
        Me.txtDiasAVencerAlertas.Key = ""
        Me.txtDiasAVencerAlertas.LabelAsoc = Me.lblDiasAVencerAlertas
        Me.txtDiasAVencerAlertas.Location = New System.Drawing.Point(30, 122)
        Me.txtDiasAVencerAlertas.MaxLength = 5
        Me.txtDiasAVencerAlertas.Name = "txtDiasAVencerAlertas"
        Me.txtDiasAVencerAlertas.Size = New System.Drawing.Size(40, 20)
        Me.txtDiasAVencerAlertas.TabIndex = 2
        Me.txtDiasAVencerAlertas.Tag = ""
        Me.txtDiasAVencerAlertas.Text = "0"
        Me.txtDiasAVencerAlertas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiasAVencerAlertas
        '
        Me.lblDiasAVencerAlertas.AutoSize = True
        Me.lblDiasAVencerAlertas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDiasAVencerAlertas.LabelAsoc = Nothing
        Me.lblDiasAVencerAlertas.Location = New System.Drawing.Point(76, 125)
        Me.lblDiasAVencerAlertas.Name = "lblDiasAVencerAlertas"
        Me.lblDiasAVencerAlertas.Size = New System.Drawing.Size(344, 13)
        Me.lblDiasAVencerAlertas.TabIndex = 3
        Me.lblDiasAVencerAlertas.Text = "Cant. de Días para mostrar Alerta de Novedades con Próximo Contacto"
        '
        'chbSoloMuestraUsuariosActivos
        '
        Me.chbSoloMuestraUsuariosActivos.BindearPropiedadControl = Nothing
        Me.chbSoloMuestraUsuariosActivos.BindearPropiedadEntidad = Nothing
        Me.chbSoloMuestraUsuariosActivos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSoloMuestraUsuariosActivos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSoloMuestraUsuariosActivos.IsPK = False
        Me.chbSoloMuestraUsuariosActivos.IsRequired = False
        Me.chbSoloMuestraUsuariosActivos.Key = Nothing
        Me.chbSoloMuestraUsuariosActivos.LabelAsoc = Nothing
        Me.chbSoloMuestraUsuariosActivos.Location = New System.Drawing.Point(30, 158)
        Me.chbSoloMuestraUsuariosActivos.Name = "chbSoloMuestraUsuariosActivos"
        Me.chbSoloMuestraUsuariosActivos.Size = New System.Drawing.Size(230, 23)
        Me.chbSoloMuestraUsuariosActivos.TabIndex = 4
        Me.chbSoloMuestraUsuariosActivos.Tag = "CRMSOLOMUESTRAUSUARIOSACTIVOS"
        Me.chbSoloMuestraUsuariosActivos.Text = "Solo muestra usuarios activos"
        Me.chbSoloMuestraUsuariosActivos.UseVisualStyleBackColor = True
        '
        'chbPermiteEnvioMailsDesdeNovedad
        '
        Me.chbPermiteEnvioMailsDesdeNovedad.BindearPropiedadControl = Nothing
        Me.chbPermiteEnvioMailsDesdeNovedad.BindearPropiedadEntidad = Nothing
        Me.chbPermiteEnvioMailsDesdeNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteEnvioMailsDesdeNovedad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteEnvioMailsDesdeNovedad.IsPK = False
        Me.chbPermiteEnvioMailsDesdeNovedad.IsRequired = False
        Me.chbPermiteEnvioMailsDesdeNovedad.Key = Nothing
        Me.chbPermiteEnvioMailsDesdeNovedad.LabelAsoc = Nothing
        Me.chbPermiteEnvioMailsDesdeNovedad.Location = New System.Drawing.Point(30, 187)
        Me.chbPermiteEnvioMailsDesdeNovedad.Name = "chbPermiteEnvioMailsDesdeNovedad"
        Me.chbPermiteEnvioMailsDesdeNovedad.Size = New System.Drawing.Size(246, 23)
        Me.chbPermiteEnvioMailsDesdeNovedad.TabIndex = 5
        Me.chbPermiteEnvioMailsDesdeNovedad.Tag = "CRMPERMITEENVIOMAILS"
        Me.chbPermiteEnvioMailsDesdeNovedad.Text = "Permite el envio de mails desde la Novedad"
        Me.chbPermiteEnvioMailsDesdeNovedad.UseVisualStyleBackColor = True
        '
        'chbMuestraSolapaMasInfo
        '
        Me.chbMuestraSolapaMasInfo.BindearPropiedadControl = Nothing
        Me.chbMuestraSolapaMasInfo.BindearPropiedadEntidad = Nothing
        Me.chbMuestraSolapaMasInfo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMuestraSolapaMasInfo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMuestraSolapaMasInfo.IsPK = False
        Me.chbMuestraSolapaMasInfo.IsRequired = False
        Me.chbMuestraSolapaMasInfo.Key = Nothing
        Me.chbMuestraSolapaMasInfo.LabelAsoc = Nothing
        Me.chbMuestraSolapaMasInfo.Location = New System.Drawing.Point(30, 216)
        Me.chbMuestraSolapaMasInfo.Name = "chbMuestraSolapaMasInfo"
        Me.chbMuestraSolapaMasInfo.Size = New System.Drawing.Size(246, 23)
        Me.chbMuestraSolapaMasInfo.TabIndex = 6
        Me.chbMuestraSolapaMasInfo.Tag = "CRMMUESTRASOLAPAMASINFO"
        Me.chbMuestraSolapaMasInfo.Text = "Muestra solapa ""Mas info..."""
        Me.chbMuestraSolapaMasInfo.UseVisualStyleBackColor = True
        '
        'chbReportaCategoriaNovedades
        '
        Me.chbReportaCategoriaNovedades.BindearPropiedadControl = Nothing
        Me.chbReportaCategoriaNovedades.BindearPropiedadEntidad = Nothing
        Me.chbReportaCategoriaNovedades.ForeColorFocus = System.Drawing.Color.Red
        Me.chbReportaCategoriaNovedades.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbReportaCategoriaNovedades.IsPK = False
        Me.chbReportaCategoriaNovedades.IsRequired = False
        Me.chbReportaCategoriaNovedades.Key = Nothing
        Me.chbReportaCategoriaNovedades.LabelAsoc = Nothing
        Me.chbReportaCategoriaNovedades.Location = New System.Drawing.Point(30, 245)
        Me.chbReportaCategoriaNovedades.Name = "chbReportaCategoriaNovedades"
        Me.chbReportaCategoriaNovedades.Size = New System.Drawing.Size(246, 23)
        Me.chbReportaCategoriaNovedades.TabIndex = 7
        Me.chbReportaCategoriaNovedades.Tag = "CRMMUESTRAREPORTACATEGORIASNOVEDADES"
        Me.chbReportaCategoriaNovedades.Text = "Muestra ""Reporta"" en Categorías Novedades"
        Me.chbReportaCategoriaNovedades.UseVisualStyleBackColor = True
        '
        'chbPermiteAbrirMultiplesNovedadesEditar
        '
        Me.chbPermiteAbrirMultiplesNovedadesEditar.BindearPropiedadControl = Nothing
        Me.chbPermiteAbrirMultiplesNovedadesEditar.BindearPropiedadEntidad = Nothing
        Me.chbPermiteAbrirMultiplesNovedadesEditar.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteAbrirMultiplesNovedadesEditar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteAbrirMultiplesNovedadesEditar.IsPK = False
        Me.chbPermiteAbrirMultiplesNovedadesEditar.IsRequired = False
        Me.chbPermiteAbrirMultiplesNovedadesEditar.Key = Nothing
        Me.chbPermiteAbrirMultiplesNovedadesEditar.LabelAsoc = Nothing
        Me.chbPermiteAbrirMultiplesNovedadesEditar.Location = New System.Drawing.Point(30, 89)
        Me.chbPermiteAbrirMultiplesNovedadesEditar.Name = "chbPermiteAbrirMultiplesNovedadesEditar"
        Me.chbPermiteAbrirMultiplesNovedadesEditar.Size = New System.Drawing.Size(230, 27)
        Me.chbPermiteAbrirMultiplesNovedadesEditar.TabIndex = 1
        Me.chbPermiteAbrirMultiplesNovedadesEditar.Tag = "PERMITEABRIRMULTIPLESNOVEDADESNUEVAS"
        Me.chbPermiteAbrirMultiplesNovedadesEditar.Text = "Permite abrir múltiples Novedades al editar"
        Me.chbPermiteAbrirMultiplesNovedadesEditar.UseVisualStyleBackColor = True
        '
        'chbCRMImporteConIVA
        '
        Me.chbCRMImporteConIVA.BindearPropiedadControl = Nothing
        Me.chbCRMImporteConIVA.BindearPropiedadEntidad = Nothing
        Me.chbCRMImporteConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCRMImporteConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCRMImporteConIVA.IsPK = False
        Me.chbCRMImporteConIVA.IsRequired = False
        Me.chbCRMImporteConIVA.Key = Nothing
        Me.chbCRMImporteConIVA.LabelAsoc = Nothing
        Me.chbCRMImporteConIVA.Location = New System.Drawing.Point(30, 274)
        Me.chbCRMImporteConIVA.Name = "chbCRMImporteConIVA"
        Me.chbCRMImporteConIVA.Size = New System.Drawing.Size(246, 23)
        Me.chbCRMImporteConIVA.TabIndex = 59
        Me.chbCRMImporteConIVA.Tag = "CRMIMPORTECONIVA"
        Me.chbCRMImporteConIVA.Text = "Importe con IVA en Service"
        Me.chbCRMImporteConIVA.UseVisualStyleBackColor = True
        '
        'ucConfCRMGenerales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbCRMImporteConIVA)
        Me.Controls.Add(Me.chbPermiteAbrirMultiplesNovedadesEditar)
        Me.Controls.Add(Me.chbPermiteAbrirMultiplesNovedadesNuevas)
        Me.Controls.Add(Me.txtDiasAVencerAlertas)
        Me.Controls.Add(Me.lblDiasAVencerAlertas)
        Me.Controls.Add(Me.chbSoloMuestraUsuariosActivos)
        Me.Controls.Add(Me.chbPermiteEnvioMailsDesdeNovedad)
        Me.Controls.Add(Me.chbMuestraSolapaMasInfo)
        Me.Controls.Add(Me.chbReportaCategoriaNovedades)
        Me.Name = "ucConfCRMGenerales"
        Me.Controls.SetChildIndex(Me.chbReportaCategoriaNovedades, 0)
        Me.Controls.SetChildIndex(Me.chbMuestraSolapaMasInfo, 0)
        Me.Controls.SetChildIndex(Me.chbPermiteEnvioMailsDesdeNovedad, 0)
        Me.Controls.SetChildIndex(Me.chbSoloMuestraUsuariosActivos, 0)
        Me.Controls.SetChildIndex(Me.lblDiasAVencerAlertas, 0)
        Me.Controls.SetChildIndex(Me.txtDiasAVencerAlertas, 0)
        Me.Controls.SetChildIndex(Me.chbPermiteAbrirMultiplesNovedadesNuevas, 0)
        Me.Controls.SetChildIndex(Me.chbPermiteAbrirMultiplesNovedadesEditar, 0)
        Me.Controls.SetChildIndex(Me.chbCRMImporteConIVA, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbPermiteAbrirMultiplesNovedadesNuevas As Controles.CheckBox
   Friend WithEvents txtDiasAVencerAlertas As Controles.TextBox
   Friend WithEvents lblDiasAVencerAlertas As Controles.Label
   Friend WithEvents chbSoloMuestraUsuariosActivos As Controles.CheckBox
   Friend WithEvents chbPermiteEnvioMailsDesdeNovedad As Controles.CheckBox
   Friend WithEvents chbMuestraSolapaMasInfo As Controles.CheckBox
   Friend WithEvents chbReportaCategoriaNovedades As Controles.CheckBox
    Friend WithEvents chbPermiteAbrirMultiplesNovedadesEditar As Controles.CheckBox
    Friend WithEvents chbCRMImporteConIVA As Controles.CheckBox
End Class
