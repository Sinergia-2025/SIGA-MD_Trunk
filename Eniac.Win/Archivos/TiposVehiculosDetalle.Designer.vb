﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposVehiculosDetalle
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
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.lblCapMaxima = New Eniac.Controles.Label()
      Me.txtCapacidadMaxima = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(254, 108)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(340, 108)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(153, 108)
      Me.btnCopiar.TabIndex = 9
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(96, 108)
      Me.btnAplicar.TabIndex = 8
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(30, 46)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreTipoVehiculo"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(104, 42)
      Me.txtNombre.MaxLength = 100
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(294, 20)
      Me.txtNombre.TabIndex = 3
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.LabelAsoc = Nothing
      Me.lblId.Location = New System.Drawing.Point(30, 20)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 0
      Me.lblId.Text = "Código"
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "IdTipoVehiculo"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = True
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(104, 16)
      Me.txtId.MaxLength = 3
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(48, 20)
      Me.txtId.TabIndex = 1
      '
      'lblCapMaxima
      '
      Me.lblCapMaxima.AutoSize = True
      Me.lblCapMaxima.LabelAsoc = Me.lblCapMaxima
      Me.lblCapMaxima.Location = New System.Drawing.Point(30, 72)
      Me.lblCapMaxima.Name = "lblCapMaxima"
      Me.lblCapMaxima.Size = New System.Drawing.Size(68, 13)
      Me.lblCapMaxima.TabIndex = 4
      Me.lblCapMaxima.Text = "Cap. Máxima"
      '
      'txtCapacidadMaxima
      '
      Me.txtCapacidadMaxima.BindearPropiedadControl = "Text"
      Me.txtCapacidadMaxima.BindearPropiedadEntidad = "CapacidadMaxima"
      Me.txtCapacidadMaxima.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCapacidadMaxima.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCapacidadMaxima.Formato = ""
      Me.txtCapacidadMaxima.IsDecimal = False
      Me.txtCapacidadMaxima.IsNumber = True
      Me.txtCapacidadMaxima.IsPK = False
      Me.txtCapacidadMaxima.IsRequired = False
      Me.txtCapacidadMaxima.Key = ""
      Me.txtCapacidadMaxima.LabelAsoc = Me.lblId
      Me.txtCapacidadMaxima.Location = New System.Drawing.Point(104, 68)
      Me.txtCapacidadMaxima.MaxLength = 3
      Me.txtCapacidadMaxima.Name = "txtCapacidadMaxima"
      Me.txtCapacidadMaxima.Size = New System.Drawing.Size(48, 20)
      Me.txtCapacidadMaxima.TabIndex = 5
      '
      'TiposVehiculosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(429, 143)
      Me.Controls.Add(Me.lblCapMaxima)
      Me.Controls.Add(Me.txtCapacidadMaxima)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtId)
      Me.Name = "TiposVehiculosDetalle"
      Me.Text = "Tipos de Vehículos"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtId, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtCapacidadMaxima, 0)
      Me.Controls.SetChildIndex(Me.lblCapMaxima, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents lblCapMaxima As Eniac.Controles.Label
   Friend WithEvents txtCapacidadMaxima As Eniac.Controles.TextBox
End Class