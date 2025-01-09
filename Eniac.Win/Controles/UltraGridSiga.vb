Imports System.ComponentModel
Public Class UltraGridSiga
   Inherits UltraGrid

   <Category("Eniac")>
   Public Property ToolStripLabelRegistros As ToolStripStatusLabel

   Private WithEvents _tsbExpandirTodos As ToolStripMenuItem
   Private WithEvents _tsbColapsarTodos As ToolStripMenuItem
   Private WithEvents _tsbExpandir As ToolStripSplitButton
   <Category("Eniac")>
   Public Property ToolStripMenuExpandir As ToolStripSplitButton
      Get
         Return _tsbExpandir
      End Get
      Set
         InitializeExpandir(Value)

         '_ToolStripMenuExpandir = Value
      End Set
   End Property

   Private Const _expandirText As String = "Expandir grupos"
   Private Const _colapsarText As String = "Colapsar grupos"


   Private Sub InitializeExpandir(value As ToolStripSplitButton)
      _tsbExpandir = value

      If Not DesignMode Then
         If _tsbExpandir IsNot Nothing Then
            If Not _tsbExpandir.DropDownItems.ContainsKey("tsbExpandirTodos") Then
               '
               'tsbExpandirTodos
               '
               _tsbExpandirTodos = New ToolStripMenuItem With {
                  .Name = "tsbExpandirTodos",
                  .Size = New System.Drawing.Size(211, 22),
                  .Text = "Expandir todos los grupos",
                  .Image = My.Resources.navigate_down,
                  .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                  .TextImageRelation = TextImageRelation.ImageBeforeText
               }
               _tsbExpandir.DropDownItems.Add(_tsbExpandirTodos)
            Else
               _tsbExpandirTodos = DirectCast(_tsbExpandir.DropDownItems.Item("tsbExpandirTodos"), ToolStripMenuItem)
            End If
            If Not _tsbExpandir.DropDownItems.ContainsKey("tsbColapsarTodos") Then
               '
               'tsbColapsarTodos
               '
               _tsbColapsarTodos = New ToolStripMenuItem With {
               .Name = "tsbColapsarTodos",
               .Size = New System.Drawing.Size(211, 22),
               .Text = "Colapsar todos los grupos",
               .Image = My.Resources.navigate_up,
               .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
               .TextImageRelation = TextImageRelation.ImageBeforeText
            }
               _tsbExpandir.DropDownItems.Add(_tsbColapsarTodos)
            Else
               _tsbExpandirTodos = DirectCast(_tsbExpandir.DropDownItems.Item("tsbColapsarTodos"), ToolStripMenuItem)
            End If

            _tsbExpandir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            _tsbExpandir.TextImageRelation = TextImageRelation.ImageBeforeText

            ResetearExpandirTodos()
         End If
      End If
   End Sub

   Private Sub _tsbExpandir_ButtonClick(sender As Object, e As EventArgs) Handles _tsbExpandir.ButtonClick
      FindForm().TryCatched(
      Sub()
         If _tsbExpandir.Text = _expandirText Then
            ExpandirTodos()
         Else
            ColapsarTodos()
         End If
      End Sub)
   End Sub
   Private Sub tsbExpandirTodos_Click(sender As Object, e As EventArgs) Handles _tsbExpandirTodos.Click
      FindForm().TryCatched(Sub() ExpandirTodos())
   End Sub

   Private Sub tsbColapsarTodos_Click(sender As Object, e As EventArgs) Handles _tsbColapsarTodos.Click
      FindForm().TryCatched(Sub() ColapsarTodos())
   End Sub

   Public Sub ResetearExpandirTodos()
      ColapsarTodos()
   End Sub
   Private Sub ExpandirTodos()
      ColapsarExpandir(expandir:=True)
      _tsbExpandir.Text = _colapsarText
      _tsbExpandir.Image = My.Resources.navigate_up
   End Sub
   Private Sub ColapsarTodos()
      ColapsarExpandir(expandir:=False)
      _tsbExpandir.Text = _expandirText
      _tsbExpandir.Image = My.Resources.navigate_down
   End Sub


   <Category("Eniac")>
   Public Event CantidadFilasChanged As EventHandler(Of CantidadFilasChangedEventArgs)
   Private Sub OnCantidadFilasChanged()
      OnCantidadFilasChanged(Rows.FilteredInRowCount)
   End Sub
   Private Sub OnCantidadFilasChanged(cantidadFilas As Integer)
      OnCantidadFilasChanged(New CantidadFilasChangedEventArgs(cantidadFilas))
   End Sub
   Protected Overridable Sub OnCantidadFilasChanged(e As CantidadFilasChangedEventArgs)
      RaiseEvent CantidadFilasChanged(Me, e)
   End Sub

   Protected Overrides Sub OnAfterRowFilterChanged(e As AfterRowFilterChangedEventArgs)
      MyBase.OnAfterRowFilterChanged(e)
      MostrarRegistros()
   End Sub

   Protected Overrides Sub OnInitializeLayout(e As InitializeLayoutEventArgs)
      MyBase.OnInitializeLayout(e)
      MostrarRegistros()
   End Sub

   Protected Overrides Sub OnAfterRowInsert(e As RowEventArgs)
      MyBase.OnAfterRowInsert(e)
      MostrarRegistros()
   End Sub
   Protected Overrides Sub OnAfterRowsDeleted()
      MyBase.OnAfterRowsDeleted()
      MostrarRegistros()
   End Sub

   Public Sub RowsRefresh(action As RefreshRow)
      Rows.Refresh(action)
      MostrarRegistros()
   End Sub

   Private Sub MostrarRegistros()
      If Not DesignMode Then
         If ToolStripLabelRegistros IsNot Nothing Then
            ActualizarInfoRegistros(ToolStripLabelRegistros)
         End If
         OnCantidadFilasChanged()
      End If
   End Sub

   Protected Overrides Sub OnListManagerSet()
      MyBase.OnListManagerSet()
      If TypeOf (DataSource) Is DataTable Then
         AddHandler DirectCast(DataSource, DataTable).TableCleared, Sub(sender, e) MostrarRegistros()
      ElseIf TypeOf (DataSource) Is DataSet Then
         'AddHandler DirectCast(DataSource, DataSet )., Sub(sender, e) MostrarRegistros()
      End If
   End Sub


   Public Class CantidadFilasChangedEventArgs
      Inherits EventArgs
      Public ReadOnly Property CantidadFilas As Integer
      Public Sub New(cantidadFilas As Integer)
         Me.CantidadFilas = cantidadFilas
      End Sub
   End Class

End Class