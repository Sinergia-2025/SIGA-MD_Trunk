﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SucursalesUbicacionesEstadosDetalle
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
      Me.lblCapMaxima = New Eniac.Controles.Label()
      Me.txtCapacidadMaxima = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(249, 112)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(335, 112)
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(148, 112)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(91, 112)
      '
      'lblCapMaxima
      '
      Me.lblCapMaxima.AutoSize = True
      Me.lblCapMaxima.LabelAsoc = Me.lblCapMaxima
      Me.lblCapMaxima.Location = New System.Drawing.Point(20, 68)
      Me.lblCapMaxima.Name = "lblCapMaxima"
      Me.lblCapMaxima.Size = New System.Drawing.Size(36, 13)
      Me.lblCapMaxima.TabIndex = 10
      Me.lblCapMaxima.Text = "Orden"
      '
      'txtCapacidadMaxima
      '
      Me.txtCapacidadMaxima.BindearPropiedadControl = "Text"
      Me.txtCapacidadMaxima.BindearPropiedadEntidad = "OrdenEstado"
      Me.txtCapacidadMaxima.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCapacidadMaxima.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCapacidadMaxima.Formato = ""
      Me.txtCapacidadMaxima.IsDecimal = False
      Me.txtCapacidadMaxima.IsNumber = True
      Me.txtCapacidadMaxima.IsPK = False
      Me.txtCapacidadMaxima.IsRequired = False
      Me.txtCapacidadMaxima.Key = ""
      Me.txtCapacidadMaxima.LabelAsoc = Me.lblId
      Me.txtCapacidadMaxima.Location = New System.Drawing.Point(94, 64)
      Me.txtCapacidadMaxima.MaxLength = 3
      Me.txtCapacidadMaxima.Name = "txtCapacidadMaxima"
      Me.txtCapacidadMaxima.Size = New System.Drawing.Size(48, 20)
      Me.txtCapacidadMaxima.TabIndex = 11
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.LabelAsoc = Nothing
      Me.lblId.Location = New System.Drawing.Point(20, 16)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 6
      Me.lblId.Text = "Código"
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(20, 42)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 8
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreEstado"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(94, 38)
      Me.txtNombre.MaxLength = 100
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(294, 20)
      Me.txtNombre.TabIndex = 9
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "IdEstado"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = True
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(94, 12)
      Me.txtId.MaxLength = 3
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(48, 20)
      Me.txtId.TabIndex = 7
      '
      'chbActivo
      '
      Me.chbActivo.AutoSize = True
      Me.chbActivo.BindearPropiedadControl = "Checked"
      Me.chbActivo.BindearPropiedadEntidad = "Activo"
      Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbActivo.IsPK = False
      Me.chbActivo.IsRequired = False
      Me.chbActivo.Key = Nothing
      Me.chbActivo.LabelAsoc = Nothing
      Me.chbActivo.Location = New System.Drawing.Point(332, 14)
      Me.chbActivo.Name = "chbActivo"
      Me.chbActivo.Size = New System.Drawing.Size(56, 17)
      Me.chbActivo.TabIndex = 12
      Me.chbActivo.Text = "Activo"
      Me.chbActivo.UseVisualStyleBackColor = True
      '
      'SucursalesUbicacionesEstadosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(424, 147)
      Me.Controls.Add(Me.chbActivo)
      Me.Controls.Add(Me.lblCapMaxima)
      Me.Controls.Add(Me.txtCapacidadMaxima)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtId)
      Me.Name = "SucursalesUbicacionesEstadosDetalle"
      Me.Text = "Ubicaciones Estados Detalle"
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
      Me.Controls.SetChildIndex(Me.chbActivo, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents lblCapMaxima As Controles.Label
   Friend WithEvents txtCapacidadMaxima As Controles.TextBox
   Friend WithEvents lblId As Controles.Label
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtNombre As Controles.TextBox
   Friend WithEvents txtId As Controles.TextBox
   Friend WithEvents chbActivo As Controles.CheckBox
End Class