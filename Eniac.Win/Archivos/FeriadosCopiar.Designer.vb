<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FeriadosCopiar
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FeriadosCopiar))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.lblAnoDesde = New Eniac.Controles.Label()
      Me.lblAnoHasta = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.dtpAnoDesde = New Eniac.Controles.DateTimePicker()
      Me.dtpAnoHasta = New Eniac.Controles.DateTimePicker()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(250, 132)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(336, 132)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(149, 132)
      Me.btnCopiar.TabIndex = 8
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'lblAnoDesde
      '
      Me.lblAnoDesde.AutoSize = True
      Me.lblAnoDesde.Location = New System.Drawing.Point(58, 30)
      Me.lblAnoDesde.Name = "lblAnoDesde"
      Me.lblAnoDesde.Size = New System.Drawing.Size(206, 13)
      Me.lblAnoDesde.TabIndex = 0
      Me.lblAnoDesde.Text = "Año del cual se desean copiar los feriados"
      '
      'lblAnoHasta
      '
      Me.lblAnoHasta.AutoSize = True
      Me.lblAnoHasta.Location = New System.Drawing.Point(58, 56)
      Me.lblAnoHasta.Name = "lblAnoHasta"
      Me.lblAnoHasta.Size = New System.Drawing.Size(200, 13)
      Me.lblAnoHasta.TabIndex = 2
      Me.lblAnoHasta.Text = "Año al cual se desean copiar los feriados"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(38, 88)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(343, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Solo se agregarán los feriados que no se encuentren en el año destino."
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(85, 105)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(249, 13)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "En caso de duplicado prevalece el del año destino."
      '
      'dtpAnoDesde
      '
      Me.dtpAnoDesde.BindearPropiedadControl = ""
      Me.dtpAnoDesde.BindearPropiedadEntidad = ""
      Me.dtpAnoDesde.CustomFormat = "yyyy"
      Me.dtpAnoDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpAnoDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpAnoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpAnoDesde.IsPK = True
      Me.dtpAnoDesde.IsRequired = True
      Me.dtpAnoDesde.Key = ""
      Me.dtpAnoDesde.LabelAsoc = Nothing
      Me.dtpAnoDesde.Location = New System.Drawing.Point(270, 28)
      Me.dtpAnoDesde.Name = "dtpAnoDesde"
      Me.dtpAnoDesde.Size = New System.Drawing.Size(64, 20)
      Me.dtpAnoDesde.TabIndex = 1
      '
      'dtpAnoHasta
      '
      Me.dtpAnoHasta.BindearPropiedadControl = ""
      Me.dtpAnoHasta.BindearPropiedadEntidad = ""
      Me.dtpAnoHasta.CustomFormat = "yyyy"
      Me.dtpAnoHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpAnoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpAnoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpAnoHasta.IsPK = True
      Me.dtpAnoHasta.IsRequired = True
      Me.dtpAnoHasta.Key = ""
      Me.dtpAnoHasta.LabelAsoc = Nothing
      Me.dtpAnoHasta.Location = New System.Drawing.Point(270, 54)
      Me.dtpAnoHasta.Name = "dtpAnoHasta"
      Me.dtpAnoHasta.Size = New System.Drawing.Size(64, 20)
      Me.dtpAnoHasta.TabIndex = 3
      '
      'FeriadosCopiar
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(428, 174)
      Me.Controls.Add(Me.dtpAnoHasta)
      Me.Controls.Add(Me.dtpAnoDesde)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblAnoHasta)
      Me.Controls.Add(Me.lblAnoDesde)
      Me.Name = "FeriadosCopiar"
      Me.Text = "Copiar Feriados"
      Me.Controls.SetChildIndex(Me.lblAnoDesde, 0)
      Me.Controls.SetChildIndex(Me.lblAnoHasta, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.dtpAnoDesde, 0)
      Me.Controls.SetChildIndex(Me.dtpAnoHasta, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Friend WithEvents lblAnoDesde As Eniac.Controles.Label
   Friend WithEvents lblAnoHasta As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Protected WithEvents dtpAnoDesde As Eniac.Controles.DateTimePicker
   Protected WithEvents dtpAnoHasta As Eniac.Controles.DateTimePicker
End Class
