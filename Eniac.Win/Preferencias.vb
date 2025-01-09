Imports System.Windows.Forms
Imports System.IO
Imports System.Xml

Public Class Preferencias
   Inherits BaseForm

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents tbcPreferencias As System.Windows.Forms.TabControl
   Friend WithEvents tbpGrid As System.Windows.Forms.TabPage
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnCancel As Button
   Friend WithEvents btnApply As Button
   Friend WithEvents dtgGrid As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnOk As Button
   Friend WithEvents lnkEliminarPreferencias As System.Windows.Forms.LinkLabel
   Friend WithEvents udsGrid As Infragistics.Win.UltraWinDataSource.UltraDataSource
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Column")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Visible")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Key")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ancho")
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
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Column")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Visible")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Key")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Ancho")
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Preferencias))
      Me.tbcPreferencias = New System.Windows.Forms.TabControl()
      Me.tbpGrid = New System.Windows.Forms.TabPage()
      Me.dtgGrid = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.udsGrid = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnApply = New System.Windows.Forms.Button()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.lnkEliminarPreferencias = New System.Windows.Forms.LinkLabel()
      Me.tbcPreferencias.SuspendLayout()
      Me.tbpGrid.SuspendLayout()
      CType(Me.dtgGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.udsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tbcPreferencias
      '
      Me.tbcPreferencias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbcPreferencias.Controls.Add(Me.tbpGrid)
      Me.tbcPreferencias.ImageList = Me.imgIconos
      Me.tbcPreferencias.Location = New System.Drawing.Point(8, 8)
      Me.tbcPreferencias.Name = "tbcPreferencias"
      Me.tbcPreferencias.SelectedIndex = 0
      Me.tbcPreferencias.Size = New System.Drawing.Size(416, 376)
      Me.tbcPreferencias.TabIndex = 0
      '
      'tbpGrid
      '
      Me.tbpGrid.Controls.Add(Me.dtgGrid)
      Me.tbpGrid.ImageIndex = 0
      Me.tbpGrid.Location = New System.Drawing.Point(4, 23)
      Me.tbpGrid.Name = "tbpGrid"
      Me.tbpGrid.Size = New System.Drawing.Size(408, 349)
      Me.tbpGrid.TabIndex = 0
      Me.tbpGrid.Text = "Grilla"
      '
      'dtgGrid
      '
      Me.dtgGrid.DataSource = Me.udsGrid
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dtgGrid.DisplayLayout.Appearance = Appearance1
      Me.dtgGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn1.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
      UltraGridColumn1.Header.Caption = "Columna"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 276
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.MaxWidth = 47
      UltraGridColumn2.MinWidth = 47
      UltraGridColumn2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn2.Width = 47
      UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Hidden = True
      UltraGridColumn3.MaxWidth = 47
      UltraGridColumn3.MinWidth = 47
      UltraGridColumn3.Width = 47
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance2
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.MaxWidth = 47
      UltraGridColumn4.MinWidth = 47
      UltraGridColumn4.Width = 47
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
      Me.dtgGrid.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.dtgGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dtgGrid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance3.BorderColor = System.Drawing.SystemColors.Window
      Me.dtgGrid.DisplayLayout.GroupByBox.Appearance = Appearance3
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dtgGrid.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
      Me.dtgGrid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance5.BackColor2 = System.Drawing.SystemColors.Control
      Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dtgGrid.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
      Me.dtgGrid.DisplayLayout.MaxColScrollRegions = 1
      Me.dtgGrid.DisplayLayout.MaxRowScrollRegions = 1
      Appearance6.BackColor = System.Drawing.SystemColors.Window
      Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dtgGrid.DisplayLayout.Override.ActiveCellAppearance = Appearance6
      Appearance7.BackColor = System.Drawing.SystemColors.Highlight
      Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dtgGrid.DisplayLayout.Override.ActiveRowAppearance = Appearance7
      Me.dtgGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.dtgGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.dtgGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
      Me.dtgGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.dtgGrid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dtgGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance8.BackColor = System.Drawing.SystemColors.Window
      Me.dtgGrid.DisplayLayout.Override.CardAreaAppearance = Appearance8
      Appearance9.BorderColor = System.Drawing.Color.Silver
      Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dtgGrid.DisplayLayout.Override.CellAppearance = Appearance9
      Me.dtgGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.dtgGrid.DisplayLayout.Override.CellPadding = 0
      Me.dtgGrid.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
      Me.dtgGrid.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
      Appearance10.BackColor = System.Drawing.Color.AntiqueWhite
      Me.dtgGrid.DisplayLayout.Override.FilterRowAppearance = Appearance10
      Me.dtgGrid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
      Appearance11.BackColor = System.Drawing.SystemColors.Control
      Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.BorderColor = System.Drawing.SystemColors.Window
      Me.dtgGrid.DisplayLayout.Override.GroupByRowAppearance = Appearance11
      Appearance12.TextHAlignAsString = "Left"
      Me.dtgGrid.DisplayLayout.Override.HeaderAppearance = Appearance12
      Me.dtgGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dtgGrid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Me.dtgGrid.DisplayLayout.Override.RowAppearance = Appearance13
      Me.dtgGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dtgGrid.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
      Me.dtgGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Vertical
      Me.dtgGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dtgGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dtgGrid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dtgGrid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dtgGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtgGrid.Location = New System.Drawing.Point(0, 0)
      Me.dtgGrid.Name = "dtgGrid"
      Me.dtgGrid.Size = New System.Drawing.Size(408, 349)
      Me.dtgGrid.TabIndex = 0
      '
      'udsGrid
      '
      UltraDataColumn2.DataType = GetType(Boolean)
      UltraDataColumn4.DataType = GetType(Integer)
      Me.udsGrid.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4})
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "")
      Me.imgIconos.Images.SetKeyName(1, "")
      Me.imgIconos.Images.SetKeyName(2, "")
      Me.imgIconos.Images.SetKeyName(3, "")
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancel.Location = New System.Drawing.Point(333, 390)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(90, 35)
      Me.btnCancel.TabIndex = 3
      Me.btnCancel.Text = "&Cancelar"
      Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnApply
      '
      Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApply.Enabled = False
      Me.btnApply.Image = Global.Eniac.Win.My.Resources.Resources.hand_ok_24
      Me.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnApply.Location = New System.Drawing.Point(141, 390)
      Me.btnApply.Name = "btnApply"
      Me.btnApply.Size = New System.Drawing.Size(90, 35)
      Me.btnApply.TabIndex = 1
      Me.btnApply.Text = "&Aplicar"
      Me.btnApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnOk.Image = Global.Eniac.Win.My.Resources.Resources.ok_32
      Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnOk.Location = New System.Drawing.Point(237, 390)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(90, 35)
      Me.btnOk.TabIndex = 2
      Me.btnOk.Text = "&Aceptar"
      Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lnkEliminarPreferencias
      '
      Me.lnkEliminarPreferencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lnkEliminarPreferencias.Location = New System.Drawing.Point(-3, 409)
      Me.lnkEliminarPreferencias.Name = "lnkEliminarPreferencias"
      Me.lnkEliminarPreferencias.Size = New System.Drawing.Size(107, 21)
      Me.lnkEliminarPreferencias.TabIndex = 4
      Me.lnkEliminarPreferencias.TabStop = True
      Me.lnkEliminarPreferencias.Text = "Eliminar preferencias"
      Me.lnkEliminarPreferencias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Preferencias
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(432, 427)
      Me.Controls.Add(Me.lnkEliminarPreferencias)
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.btnApply)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.tbcPreferencias)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Preferencias"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Preferencias"
      Me.tbcPreferencias.ResumeLayout(False)
      Me.tbpGrid.ResumeLayout(False)
      CType(Me.dtgGrid, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.udsGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private grilla As Infragistics.Win.UltraWinGrid.UltraGrid
   Private modificadaGrilla As Boolean

   Public Sub New(ByVal grilla As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal modificada As Boolean)
      Me.New()
      Me.grilla = grilla
      Me.modificadaGrilla = modificada
   End Sub

   Private _sufijoXML As String = String.Empty
   Public Property SufijoXML() As String
      Get
         Return _sufijoXML
      End Get
      Set(ByVal value As String)
         _sufijoXML = value
      End Set
   End Property


   Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      Me.Close()
   End Sub

   Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
      Me.Aplicar()
      Me.btnApply.Enabled = False
   End Sub

   Protected Overridable Sub Aplicar()
      Try
         For Each dr As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.dtgGrid.Rows
            For Each bd In Me.grilla.DisplayLayout.Bands
               bd.Columns(dr.Cells("Key").Text).Hidden = Not Boolean.Parse(dr.Cells("Visible").Value.ToString())
               bd.Columns(dr.Cells("Key").Text).Width = Integer.Parse(dr.Cells("Ancho").Value.ToString())
            Next
         Next
         Me.GrabarPreferencias()
         MessageBox.Show("El cambio se efectuó satisfactoriamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overridable Sub GrabarPreferencias()
      Try
         Dim xmlNameGrid As String = Me.grilla.FindForm().Name + Me.SufijoXML + "Grid.xml"
         Me.grilla.DisplayLayout.SaveAsXml(xmlNameGrid)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
      If Me.btnApply.Enabled Then
         Me.btnApply.PerformClick()
      End If
      Me.Close()
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Try
         If Me.modificadaGrilla Then
            Me.btnApply.Enabled = True
         End If
         Dim i As Integer = 0
         For Each cl As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.grilla.DisplayLayout.Bands(0).Columns
            If cl.ExcludeFromColumnChooser = UltraWinGrid.ExcludeFromColumnChooser.True Then
               Continue For
            End If
            Me.udsGrid.Rows.Add()
            Me.udsGrid.Rows(i)(0) = cl.Header.Caption  'Columna
            Me.udsGrid.Rows(i)(1) = Not cl.Hidden      'Visible
            Me.udsGrid.Rows(i)(2) = cl.Key         'Key
            Me.udsGrid.Rows(i)(3) = cl.Width
            i += 1
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub frmPreferencias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
      Me.btnApply.Enabled = True
   End Sub

   Private Sub dtgGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgGrid.Click
      Me.btnApply.Enabled = True
   End Sub

   Private Sub lnkEliminarPreferencias_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEliminarPreferencias.LinkClicked
      Try
         Dim xmlNameGrid As String = Me.grilla.FindForm().Name + Me.SufijoXML + "Grid.xml"

         System.IO.File.Delete(xmlNameGrid)

         MessageBox.Show("Por favor, cierre la pantalla " + Me.grilla.FindForm().Text + " para que se apliquen los cambios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.Close()

      Catch ex As Exception
         'si da error no hago nada
      End Try
   End Sub

End Class
