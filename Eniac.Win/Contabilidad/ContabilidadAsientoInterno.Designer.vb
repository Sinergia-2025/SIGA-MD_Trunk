<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadAsientoInterno
    Inherits System.Windows.Forms.Form

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.txtTotalHaber = New Eniac.Controles.TextBox()
      Me.txtTotalDebe = New Eniac.Controles.TextBox()
      Me.lblTotales = New Eniac.Controles.Label()
      Me.txtConcepto = New Eniac.Controles.TextBox()
      Me.lbloncept = New Eniac.Controles.Label()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.dtAsientos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      CType(Me.dtAsientos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtTotalHaber
      '
      Me.txtTotalHaber.BindearPropiedadControl = ""
      Me.txtTotalHaber.BindearPropiedadEntidad = ""
      Me.txtTotalHaber.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalHaber.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalHaber.Formato = ""
      Me.txtTotalHaber.IsDecimal = True
      Me.txtTotalHaber.IsNumber = True
      Me.txtTotalHaber.IsPK = False
      Me.txtTotalHaber.IsRequired = False
      Me.txtTotalHaber.Key = ""
      Me.txtTotalHaber.LabelAsoc = Nothing
      Me.txtTotalHaber.Location = New System.Drawing.Point(469, 377)
      Me.txtTotalHaber.MaxLength = 8
      Me.txtTotalHaber.Name = "txtTotalHaber"
      Me.txtTotalHaber.ReadOnly = True
      Me.txtTotalHaber.Size = New System.Drawing.Size(106, 20)
      Me.txtTotalHaber.TabIndex = 22
      Me.txtTotalHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalDebe
      '
      Me.txtTotalDebe.BindearPropiedadControl = ""
      Me.txtTotalDebe.BindearPropiedadEntidad = ""
      Me.txtTotalDebe.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalDebe.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalDebe.Formato = ""
      Me.txtTotalDebe.IsDecimal = True
      Me.txtTotalDebe.IsNumber = True
      Me.txtTotalDebe.IsPK = False
      Me.txtTotalDebe.IsRequired = False
      Me.txtTotalDebe.Key = ""
      Me.txtTotalDebe.LabelAsoc = Nothing
      Me.txtTotalDebe.Location = New System.Drawing.Point(375, 377)
      Me.txtTotalDebe.MaxLength = 8
      Me.txtTotalDebe.Name = "txtTotalDebe"
      Me.txtTotalDebe.ReadOnly = True
      Me.txtTotalDebe.Size = New System.Drawing.Size(94, 20)
      Me.txtTotalDebe.TabIndex = 21
      Me.txtTotalDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotales
      '
      Me.lblTotales.AutoSize = True
      Me.lblTotales.Location = New System.Drawing.Point(316, 384)
      Me.lblTotales.Name = "lblTotales"
      Me.lblTotales.Size = New System.Drawing.Size(42, 13)
      Me.lblTotales.TabIndex = 20
      Me.lblTotales.Text = "Totales"
      '
      'txtConcepto
      '
      Me.txtConcepto.BindearPropiedadControl = "Text"
      Me.txtConcepto.BindearPropiedadEntidad = "NombreAsiento"
      Me.txtConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtConcepto.Formato = ""
      Me.txtConcepto.IsDecimal = False
      Me.txtConcepto.IsNumber = False
      Me.txtConcepto.IsPK = False
      Me.txtConcepto.IsRequired = True
      Me.txtConcepto.Key = ""
      Me.txtConcepto.LabelAsoc = Me.lbloncept
      Me.txtConcepto.Location = New System.Drawing.Point(99, 18)
      Me.txtConcepto.MaxLength = 50
      Me.txtConcepto.Name = "txtConcepto"
      Me.txtConcepto.Size = New System.Drawing.Size(476, 20)
      Me.txtConcepto.TabIndex = 13
      '
      'lbloncept
      '
      Me.lbloncept.AutoSize = True
      Me.lbloncept.Location = New System.Drawing.Point(15, 18)
      Me.lbloncept.Name = "lbloncept"
      Me.lbloncept.Size = New System.Drawing.Size(53, 13)
      Me.lbloncept.TabIndex = 14
      Me.lbloncept.Text = "Concepto"
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(385, 423)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(96, 23)
      Me.cmdAceptar.TabIndex = 23
      Me.cmdAceptar.Text = "Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Location = New System.Drawing.Point(487, 423)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(88, 23)
      Me.cmdCancelar.TabIndex = 24
      Me.cmdCancelar.Text = "Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'dtAsientos
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dtAsientos.DisplayLayout.Appearance = Appearance1
      Me.dtAsientos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dtAsientos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.dtAsientos.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dtAsientos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.dtAsientos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dtAsientos.DisplayLayout.GroupByBox.Hidden = True
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dtAsientos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.dtAsientos.DisplayLayout.MaxColScrollRegions = 1
      Me.dtAsientos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dtAsientos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dtAsientos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.dtAsientos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
      Me.dtAsientos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dtAsientos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.dtAsientos.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dtAsientos.DisplayLayout.Override.CellAppearance = Appearance8
      Me.dtAsientos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.dtAsientos.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.dtAsientos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.dtAsientos.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.dtAsientos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dtAsientos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.dtAsientos.DisplayLayout.Override.RowAppearance = Appearance11
      Me.dtAsientos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dtAsientos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.dtAsientos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dtAsientos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dtAsientos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dtAsientos.Location = New System.Drawing.Point(18, 44)
      Me.dtAsientos.Name = "dtAsientos"
      Me.dtAsientos.Size = New System.Drawing.Size(557, 327)
      Me.dtAsientos.TabIndex = 25
      Me.dtAsientos.Text = "Asientos"
      '
      'ContabilidadAsientoInterno
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(607, 459)
      Me.Controls.Add(Me.dtAsientos)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.txtTotalHaber)
      Me.Controls.Add(Me.txtTotalDebe)
      Me.Controls.Add(Me.lblTotales)
      Me.Controls.Add(Me.txtConcepto)
      Me.Controls.Add(Me.lbloncept)
      Me.Name = "ContabilidadAsientoInterno"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Registro Contabilidad"
      CType(Me.dtAsientos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents txtTotalHaber As Eniac.Controles.TextBox
    Friend WithEvents txtTotalDebe As Eniac.Controles.TextBox
    Friend WithEvents lblTotales As Eniac.Controles.Label
    Friend WithEvents txtConcepto As Eniac.Controles.TextBox
    Friend WithEvents lbloncept As Eniac.Controles.Label
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents dtAsientos As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
