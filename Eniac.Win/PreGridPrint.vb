Imports Infragistics.Win
Imports System.Drawing
Imports System.Xml

Public Class PreGridPrint
   Inherits BaseForm

#Region " Windows Form Designer generated code "

   Public Sub New(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal data As DataTable, ByVal title As String, ByVal filter As String)
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      Me._grid = grid
      Me._dtDatos = data
      Me._title = title
      Me._filter = filter

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
   Friend WithEvents clbColumns As CheckedListBox
   Friend WithEvents Label1 As Label
   Friend WithEvents ugpDocumento As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents btnPrint As Button
   Friend WithEvents btnCancel As Button
   Public WithEvents dtgPreview As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents uppPrint As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents lklColumns As LinkLabel
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.clbColumns = New System.Windows.Forms.CheckedListBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtgPreview = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.btnPrint = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.ugpDocumento = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.lklColumns = New System.Windows.Forms.LinkLabel()
      Me.uppPrint = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      CType(Me.dtgPreview, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'clbColumns
      '
      Me.clbColumns.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.clbColumns.CheckOnClick = True
      Me.clbColumns.Location = New System.Drawing.Point(16, 24)
      Me.clbColumns.MultiColumn = True
      Me.clbColumns.Name = "clbColumns"
      Me.clbColumns.Size = New System.Drawing.Size(795, 139)
      Me.clbColumns.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(16, 168)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(90, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Previsualizar grilla"
      '
      'dtgPreview
      '
      Me.dtgPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtgPreview.Location = New System.Drawing.Point(16, 184)
      Me.dtgPreview.Name = "dtgPreview"
      Me.dtgPreview.Size = New System.Drawing.Size(795, 232)
      Me.dtgPreview.TabIndex = 4
      '
      'btnPrint
      '
      Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnPrint.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnPrint.Location = New System.Drawing.Point(611, 424)
      Me.btnPrint.Name = "btnPrint"
      Me.btnPrint.Size = New System.Drawing.Size(104, 30)
      Me.btnPrint.TabIndex = 5
      Me.btnPrint.Text = "&Visualizar"
      Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancel.Location = New System.Drawing.Point(723, 424)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(90, 30)
      Me.btnCancel.TabIndex = 6
      Me.btnCancel.Text = "&Cancel"
      Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ugpDocumento
      '
      Me.ugpDocumento.Grid = Me.dtgPreview
      '
      'lklColumns
      '
      Me.lklColumns.AutoSize = True
      Me.lklColumns.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
      Me.lklColumns.LinkColor = System.Drawing.Color.Black
      Me.lklColumns.Location = New System.Drawing.Point(16, 8)
      Me.lklColumns.Name = "lklColumns"
      Me.lklColumns.Size = New System.Drawing.Size(53, 13)
      Me.lklColumns.TabIndex = 0
      Me.lklColumns.TabStop = True
      Me.lklColumns.Text = "Columnas"
      '
      'uppPrint
      '
      Me.uppPrint.Name = "uppPrint"
      '
      'chbTodos
      '
      Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.Checked = True
      Me.chbTodos.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.chbTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(705, 3)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(106, 18)
      Me.chbTodos.TabIndex = 2
      Me.chbTodos.Text = "Chequear todos"
      Me.chbTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'chkExpandAll
      '
      Me.chkExpandAll.AutoSize = True
      Me.chkExpandAll.Location = New System.Drawing.Point(16, 424)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chkExpandAll.TabIndex = 54
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'PreGridPrint
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(827, 459)
      Me.Controls.Add(Me.chkExpandAll)
      Me.Controls.Add(Me.chbTodos)
      Me.Controls.Add(Me.lklColumns)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnPrint)
      Me.Controls.Add(Me.dtgPreview)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.clbColumns)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PreGridPrint"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleccionar columnas"
      CType(Me.dtgPreview, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Campos"

   Private _grid As Infragistics.Win.UltraWinGrid.UltraGrid
   Private _dtDatos As DataTable
   Private _title As String
   Private _filter As String

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      'Recorro la columnas de la grilla principal y cargo los nombres en el CheckedListBox 
      With Me.clbColumns
         For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me._grid.DisplayLayout.Bands(0).Columns
            If Not col.Hidden Then
               .Items.Add(col.Header.Caption)
            End If
         Next
      End With
      'Asigno los datos a la grilla secundaria que se utiliza para la impresion
      Me.dtgPreview.DataSource = Me._dtDatos
      'Copio el comportamiento de la grilla principal a la secundaria
      Me.dtgPreview.DisplayLayout.CopyFrom(Me._grid.DisplayLayout, Infragistics.Win.UltraWinGrid.PropertyCategories.All)
      'Descheckeo todas las columnas para que el usuario seleccione las que le gustan
      'For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.dtgPreview.DisplayLayout.Bands(0).Columns
      '   col.Hidden = True
      'Next
      'Pongo el fonde de la grilla en blanco, para que no salga en la impresion
      Me.dtgPreview.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White
      'Leo el archivo xml que tiene la configuracion del ultimo reporte impreso
      Me.SeleccionoTodasLasColumnas()
      Me.LeerXMLConfiguracion()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      Me.Close()
   End Sub

   Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
      Me.uppPrint.Document = Me.ugpDocumento
      Me.ugpDocumento.Header.TextLeft = Me._filter
      Me.ugpDocumento.Header.TextRight = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
      Me.ugpDocumento.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
      Me.ugpDocumento.Header.Appearance.FontData.SizeInPoints = 8
      ugpDocumento.InicializaDocumento()
      ''Me.ugpDocumento.Footer.TextRight = "Page:" & "[Page #]"

      Me.uppPrint.ShowDialog()
      Me.GuardarXMLConfiguracion()
   End Sub

   Private Sub clbColumns_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbColumns.ItemCheck
      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.dtgPreview.DisplayLayout.Bands(0).Columns
         If col.Header.Caption = Me.clbColumns.Items(e.Index).ToString() Then
            If e.NewValue = Windows.Forms.CheckState.Checked Then
               col.Hidden = False
            Else
               col.Hidden = True
            End If
         End If
      Next
   End Sub

   Private Sub dtgPreview_InitializePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs) Handles dtgPreview.InitializePrint
      e.DefaultLogicalPageLayoutInfo.PageHeader = Me._title

      'e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.ImageBackground = Image.FromFile("c:\Proyectos\CAM Fase 2\CAM_F2_Cliente\CAM_F2.ico")
      'e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.ImageBackground = Image.FromFile("c:\Proyectos\CAM Fase 2\CAM_F2_Cliente\fondosolo.jpg")
      'e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.ImageBackgroundStyle = ImageBackgroundStyle.Stretched
      'If System.IO.File.Exists("escritorio.ico") Then
      '   e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.Image = Image.FromFile("escritorio.ico")
      'End If
      If System.IO.File.Exists("App.ico") Then
         e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.Image = Image.FromFile("App.ico")
      End If

      e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.ImageHAlign = HAlign.Right
      e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.ImageVAlign = VAlign.Middle
      'e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.ForeColor = Color.Blue
      ''e.PrintDocument.DefaultPageSettings.Landscape = Not chkPortrait.Checked
      'e.DefaultLogicalPageLayoutInfo.PageHeader = T("CUSTOMER HISTORY")
      e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
      e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
      e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center
      e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 12


      e.DefaultLogicalPageLayoutInfo.PageFooter = "Page <#>."
      e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 40
      e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = HAlign.Right
      'e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.FontData.Italic = DefaultableBoolean.True
      'e.DefaultLogicalPageLayoutInfo.PageFooterBorderStyle = UIElementBorderStyle.Solid

   End Sub

   Private Sub lklColumns_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lklColumns.LinkClicked
      If Me.clbColumns.Items.Count > 0 Then
         Dim val As Boolean = Not Me.clbColumns.GetItemChecked(0)
         For i As Integer = 0 To Me.clbColumns.Items.Count - 1
            Me.clbColumns.SetItemChecked(i, val)
         Next
      End If
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         For i As Integer = 0 To Me.clbColumns.Items.Count - 1
            Me.clbColumns.SetItemChecked(i, chbTodos.Checked)
         Next
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.dtgPreview.Rows.ExpandAll(True)
      Else
         Me.dtgPreview.Rows.CollapseAll(True)
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub SeleccionoTodasLasColumnas()
      For Each cl As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.dtgPreview.DisplayLayout.Bands(0).Columns
         If Not cl.Hidden Then
            For i As Integer = 0 To Me.clbColumns.Items.Count - 1
               If Me.clbColumns.Items(i).ToString() = cl.Header.Caption Then
                  Me.clbColumns.SetItemChecked(i, True)
                  Exit For
               End If
            Next
         End If
      Next
   End Sub

   Private Sub GuardarXMLConfiguracion()
      Me.dtgPreview.DisplayLayout.SaveAsXml(Me._title & ".xml")
   End Sub

   Private Sub LeerXMLConfiguracion()
      If System.IO.File.Exists(Me._title & ".xml") Then
         Me.dtgPreview.DisplayLayout.LoadFromXml(Me._title & ".xml")
         For Each cl As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.dtgPreview.DisplayLayout.Bands(0).Columns
            If Not cl.Hidden Then
               For i As Integer = 0 To Me.clbColumns.Items.Count - 1
                  If Me.clbColumns.Items(i).ToString() = cl.Header.Caption Then
                     Me.clbColumns.SetItemChecked(i, True)
                     Exit For
                  End If
               Next
            End If
         Next
      End If
   End Sub

#End Region


End Class