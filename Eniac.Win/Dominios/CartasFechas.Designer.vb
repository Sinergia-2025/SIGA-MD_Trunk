<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CartasFechas
    Inherits System.Windows.Forms.Form

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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CartasFechas))
      Me.btnAceptar = New Eniac.Controles.Button
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New Eniac.Controles.Button
      Me.dtpFechaLiquidacion = New Eniac.Controles.DateTimePicker
      Me.lblFechaLiquidacion = New Eniac.Controles.Label
      Me.lblAlertaLlamado = New Eniac.Controles.Label
      Me.dtpFechaAlertaLlamado = New Eniac.Controles.DateTimePicker
      Me.txtDiasAvisoPrevio = New Eniac.Controles.TextBox
      Me.lblDias = New Eniac.Controles.Label
      Me.chbEnlazaProxCarta = New Eniac.Controles.CheckBox
      Me.txtDiasAlertaProxCarta = New Eniac.Controles.TextBox
      Me.lblDiasAlerta = New Eniac.Controles.Label
      Me.lblAlertaProximaCarta = New Eniac.Controles.Label
      Me.dtpFechaAlertaProxCarta = New Eniac.Controles.DateTimePicker
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imgIconos
      Me.btnAceptar.Location = New System.Drawing.Point(159, 161)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 3
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "check2.ico")
      Me.imgIconos.Images.SetKeyName(1, "delete2.ico")
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imgIconos
      Me.btnCancelar.Location = New System.Drawing.Point(245, 161)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 4
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'dtpFechaLiquidacion
      '
      Me.dtpFechaLiquidacion.BindearPropiedadControl = Nothing
      Me.dtpFechaLiquidacion.BindearPropiedadEntidad = Nothing
      Me.dtpFechaLiquidacion.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaLiquidacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaLiquidacion.IsPK = False
      Me.dtpFechaLiquidacion.IsRequired = False
      Me.dtpFechaLiquidacion.Key = ""
      Me.dtpFechaLiquidacion.LabelAsoc = Me.lblFechaLiquidacion
      Me.dtpFechaLiquidacion.Location = New System.Drawing.Point(29, 47)
      Me.dtpFechaLiquidacion.Name = "dtpFechaLiquidacion"
      Me.dtpFechaLiquidacion.Size = New System.Drawing.Size(91, 20)
      Me.dtpFechaLiquidacion.TabIndex = 0
      '
      'lblFechaLiquidacion
      '
      Me.lblFechaLiquidacion.AutoSize = True
      Me.lblFechaLiquidacion.Location = New System.Drawing.Point(26, 31)
      Me.lblFechaLiquidacion.Name = "lblFechaLiquidacion"
      Me.lblFechaLiquidacion.Size = New System.Drawing.Size(94, 13)
      Me.lblFechaLiquidacion.TabIndex = 5
      Me.lblFechaLiquidacion.Text = "Fecha Liquidación"
      '
      'lblAlertaLlamado
      '
      Me.lblAlertaLlamado.AutoSize = True
      Me.lblAlertaLlamado.Location = New System.Drawing.Point(209, 31)
      Me.lblAlertaLlamado.Name = "lblAlertaLlamado"
      Me.lblAlertaLlamado.Size = New System.Drawing.Size(77, 13)
      Me.lblAlertaLlamado.TabIndex = 7
      Me.lblAlertaLlamado.Text = "Alerta Llamado"
      '
      'dtpFechaAlertaLlamado
      '
      Me.dtpFechaAlertaLlamado.BindearPropiedadControl = Nothing
      Me.dtpFechaAlertaLlamado.BindearPropiedadEntidad = Nothing
      Me.dtpFechaAlertaLlamado.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaAlertaLlamado.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAlertaLlamado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAlertaLlamado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAlertaLlamado.IsPK = False
      Me.dtpFechaAlertaLlamado.IsRequired = False
      Me.dtpFechaAlertaLlamado.Key = ""
      Me.dtpFechaAlertaLlamado.LabelAsoc = Me.lblAlertaLlamado
      Me.dtpFechaAlertaLlamado.Location = New System.Drawing.Point(212, 47)
      Me.dtpFechaAlertaLlamado.Name = "dtpFechaAlertaLlamado"
      Me.dtpFechaAlertaLlamado.Size = New System.Drawing.Size(91, 20)
      Me.dtpFechaAlertaLlamado.TabIndex = 2
      '
      'txtDiasAvisoPrevio
      '
      Me.txtDiasAvisoPrevio.BindearPropiedadControl = Nothing
      Me.txtDiasAvisoPrevio.BindearPropiedadEntidad = Nothing
      Me.txtDiasAvisoPrevio.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDiasAvisoPrevio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDiasAvisoPrevio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDiasAvisoPrevio.Formato = ""
      Me.txtDiasAvisoPrevio.IsDecimal = False
      Me.txtDiasAvisoPrevio.IsNumber = True
      Me.txtDiasAvisoPrevio.IsPK = False
      Me.txtDiasAvisoPrevio.IsRequired = False
      Me.txtDiasAvisoPrevio.Key = ""
      Me.txtDiasAvisoPrevio.LabelAsoc = Me.lblDias
      Me.txtDiasAvisoPrevio.Location = New System.Drawing.Point(140, 48)
      Me.txtDiasAvisoPrevio.MaxLength = 4
      Me.txtDiasAvisoPrevio.Name = "txtDiasAvisoPrevio"
      Me.txtDiasAvisoPrevio.Size = New System.Drawing.Size(53, 19)
      Me.txtDiasAvisoPrevio.TabIndex = 1
      Me.txtDiasAvisoPrevio.Text = "0"
      Me.txtDiasAvisoPrevio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDias
      '
      Me.lblDias.AutoSize = True
      Me.lblDias.Location = New System.Drawing.Point(153, 32)
      Me.lblDias.Name = "lblDias"
      Me.lblDias.Size = New System.Drawing.Size(28, 13)
      Me.lblDias.TabIndex = 6
      Me.lblDias.Text = "Dias"
      '
      'chbEnlazaProxCarta
      '
      Me.chbEnlazaProxCarta.AutoSize = True
      Me.chbEnlazaProxCarta.BindearPropiedadControl = ""
      Me.chbEnlazaProxCarta.BindearPropiedadEntidad = ""
      Me.chbEnlazaProxCarta.Checked = True
      Me.chbEnlazaProxCarta.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbEnlazaProxCarta.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEnlazaProxCarta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEnlazaProxCarta.IsPK = False
      Me.chbEnlazaProxCarta.IsRequired = False
      Me.chbEnlazaProxCarta.Key = Nothing
      Me.chbEnlazaProxCarta.LabelAsoc = Nothing
      Me.chbEnlazaProxCarta.Location = New System.Drawing.Point(18, 107)
      Me.chbEnlazaProxCarta.Name = "chbEnlazaProxCarta"
      Me.chbEnlazaProxCarta.Size = New System.Drawing.Size(113, 17)
      Me.chbEnlazaProxCarta.TabIndex = 25
      Me.chbEnlazaProxCarta.Text = "Enlaza Prox. Carta"
      Me.chbEnlazaProxCarta.UseVisualStyleBackColor = True
      '
      'txtDiasAlertaProxCarta
      '
      Me.txtDiasAlertaProxCarta.BindearPropiedadControl = Nothing
      Me.txtDiasAlertaProxCarta.BindearPropiedadEntidad = Nothing
      Me.txtDiasAlertaProxCarta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDiasAlertaProxCarta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDiasAlertaProxCarta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDiasAlertaProxCarta.Formato = ""
      Me.txtDiasAlertaProxCarta.IsDecimal = False
      Me.txtDiasAlertaProxCarta.IsNumber = True
      Me.txtDiasAlertaProxCarta.IsPK = False
      Me.txtDiasAlertaProxCarta.IsRequired = False
      Me.txtDiasAlertaProxCarta.Key = ""
      Me.txtDiasAlertaProxCarta.LabelAsoc = Nothing
      Me.txtDiasAlertaProxCarta.Location = New System.Drawing.Point(140, 107)
      Me.txtDiasAlertaProxCarta.Name = "txtDiasAlertaProxCarta"
      Me.txtDiasAlertaProxCarta.Size = New System.Drawing.Size(53, 19)
      Me.txtDiasAlertaProxCarta.TabIndex = 26
      Me.txtDiasAlertaProxCarta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiasAlerta
      '
      Me.lblDiasAlerta.AutoSize = True
      Me.lblDiasAlerta.Location = New System.Drawing.Point(153, 91)
      Me.lblDiasAlerta.Name = "lblDiasAlerta"
      Me.lblDiasAlerta.Size = New System.Drawing.Size(28, 13)
      Me.lblDiasAlerta.TabIndex = 27
      Me.lblDiasAlerta.Text = "Dias"
      '
      'lblAlertaProximaCarta
      '
      Me.lblAlertaProximaCarta.AutoSize = True
      Me.lblAlertaProximaCarta.Location = New System.Drawing.Point(209, 91)
      Me.lblAlertaProximaCarta.Name = "lblAlertaProximaCarta"
      Me.lblAlertaProximaCarta.Size = New System.Drawing.Size(102, 13)
      Me.lblAlertaProximaCarta.TabIndex = 29
      Me.lblAlertaProximaCarta.Text = "Alerta Proxima Carta"
      '
      'dtpFechaAlertaProxCarta
      '
      Me.dtpFechaAlertaProxCarta.BindearPropiedadControl = Nothing
      Me.dtpFechaAlertaProxCarta.BindearPropiedadEntidad = Nothing
      Me.dtpFechaAlertaProxCarta.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaAlertaProxCarta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAlertaProxCarta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAlertaProxCarta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAlertaProxCarta.IsPK = False
      Me.dtpFechaAlertaProxCarta.IsRequired = False
      Me.dtpFechaAlertaProxCarta.Key = ""
      Me.dtpFechaAlertaProxCarta.LabelAsoc = Me.lblAlertaProximaCarta
      Me.dtpFechaAlertaProxCarta.Location = New System.Drawing.Point(212, 107)
      Me.dtpFechaAlertaProxCarta.Name = "dtpFechaAlertaProxCarta"
      Me.dtpFechaAlertaProxCarta.Size = New System.Drawing.Size(91, 20)
      Me.dtpFechaAlertaProxCarta.TabIndex = 28
      '
      'CartasFechas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(337, 203)
      Me.Controls.Add(Me.lblAlertaProximaCarta)
      Me.Controls.Add(Me.dtpFechaAlertaProxCarta)
      Me.Controls.Add(Me.txtDiasAlertaProxCarta)
      Me.Controls.Add(Me.lblDiasAlerta)
      Me.Controls.Add(Me.chbEnlazaProxCarta)
      Me.Controls.Add(Me.txtDiasAvisoPrevio)
      Me.Controls.Add(Me.lblDias)
      Me.Controls.Add(Me.lblAlertaLlamado)
      Me.Controls.Add(Me.dtpFechaAlertaLlamado)
      Me.Controls.Add(Me.lblFechaLiquidacion)
      Me.Controls.Add(Me.dtpFechaLiquidacion)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CartasFechas"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Fechas"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents dtpFechaLiquidacion As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaLiquidacion As Eniac.Controles.Label
   Friend WithEvents lblAlertaLlamado As Eniac.Controles.Label
   Friend WithEvents dtpFechaAlertaLlamado As Eniac.Controles.DateTimePicker
   Friend WithEvents txtDiasAvisoPrevio As Eniac.Controles.TextBox
   Friend WithEvents lblDias As Eniac.Controles.Label
   Friend WithEvents chbEnlazaProxCarta As Eniac.Controles.CheckBox
   Friend WithEvents txtDiasAlertaProxCarta As Eniac.Controles.TextBox
   Friend WithEvents lblDiasAlerta As Eniac.Controles.Label
   Friend WithEvents lblAlertaProximaCarta As Eniac.Controles.Label
   Friend WithEvents dtpFechaAlertaProxCarta As Eniac.Controles.DateTimePicker
End Class
