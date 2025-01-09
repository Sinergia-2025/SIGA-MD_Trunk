#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports Infragistics.Win.UltraWinGrid
#End Region
Public Class GridContextMenuManager
   Inherits System.ComponentModel.Component

#Region "Eventos propios"
   Public Event RefrecarGrilla As EventHandler
   Private Sub OnRefrecarGrilla()
      RaiseEvent RefrecarGrilla(Me, Nothing)
   End Sub

   Public Class EjecutarComandoEventArgs
      Inherits CancelableEventArgs
      Public Property Filas As DataRow()
      Public Property SelectedItem As ToolStripItem
   End Class
   Public Event EjecutarComando As EventHandler(Of EjecutarComandoEventArgs)
   Public Function OnEjecutarComando(filas As DataRow(), selectedItem As ToolStripItem) As Boolean
      Dim e = New EjecutarComandoEventArgs() With {.Filas = filas, .SelectedItem = selectedItem}
      RaiseEvent EjecutarComando(Me, e)
      Return Not e.Cancel
   End Function
#End Region

#Region "Propiedades"
   Public Property Menu As ContextMenuStrip
   Public Property Grilla As UltraGrid
   Private Property ListaContextual As New List(Of MenuBase)()
#End Region

   Public Sub CargarMenuContextualGrilla()
      InicializaOpcionesEstandar(Menu)
      ListaContextual.All(Function(x) x.Ejecutar(Menu.Items))
   End Sub

   Public Sub AgregarMenu(menu As MenuBase)
      ListaContextual.Add(menu)
   End Sub
   Public Function NewSeparador() As MenuBase
      Return New MenuSeparator(Me)
   End Function
   Public Function NewMenuAccion(menu As String, menuHijos As IEnumerable(Of MenuBase)) As MenuBase
      Return NewMenuAccion(menu, menuHijos, acciones:=New TodasMenuManager(Me))
   End Function
   Public Function NewMenuAccion(menu As String, menuHijos As IEnumerable(Of MenuBase), acciones As MenuManager) As MenuBase
      Return New MenuAccion(menu, menuHijos, Me, acciones)
   End Function
   Public Function NewMenuAccion(Of T)(menu As String, dataSource As DataSourceMenu(Of T)) As MenuBase
      Return NewMenuAccion(menu, dataSource, menuHijos:={})
   End Function
   Public Function NewMenuAccion(Of T)(menu As String, dataSource As DataSourceMenu(Of T), acciones As MenuManager) As MenuBase
      Return NewMenuAccion(menu, dataSource, menuHijos:={}, acciones:=acciones)
   End Function
   Public Function NewMenuAccion(Of T)(menu As String, dataSource As DataSourceMenu(Of T), menuHijos As IEnumerable(Of MenuBase)) As MenuBase
      Return NewMenuAccion(menu, dataSource, menuHijos, acciones:=New TodasMenuManager(Me))
   End Function
   Public Function NewMenuAccion(Of T)(menu As String, dataSource As DataSourceMenu(Of T), menuHijos As IEnumerable(Of MenuBase), acciones As MenuManager) As MenuBase
      Return New MenuAccion(Of T)(menu, dataSource, menuHijos, Me, acciones)
   End Function

   Public Sub BuscarRecursivo(Of T)(ByRef cambio As T, item As ToolStripItem, accion As Action(Of ToolStripItem))
      If item.Tag IsNot Nothing Then
         accion(item)
      End If
      If item.OwnerItem IsNot Nothing Then
         BuscarRecursivo(cambio, item.OwnerItem, accion)
      End If
   End Sub

   Private Sub Cambiar(sender As Object, cualesCambiar As CualesCambiar)
      Try
         Grilla.FindForm().Cursor = Cursors.WaitCursor

         If OnEjecutarComando(GetFilasCambiar(cualesCambiar), DirectCast(sender, ToolStripItem)) Then
            OnRefrecarGrilla()
         End If

      Catch ex As Exception
         Grilla.FindForm().ShowError(ex)
      Finally
         Grilla.FindForm().Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub Cambiar(cambio As Entidades.CRMNovedad.CambioMasivo, drCol As DataRow())
      If drCol.Length > 0 Then
         Using dt As DataTable = drCol(0).Table.Clone()
            dt.Columns.Add("selec", GetType(Boolean), Boolean.TrueString)
            dt.ImportRowRange(drCol)

            Dim rNovedad As New Reglas.CRMNovedades()
            rNovedad.ActualizacionMasiva(dt, cambio)
         End Using
      End If
   End Sub
   Private Function GetFilasCambiar(cualesCambiar As CualesCambiar) As DataRow()
      Select Case cualesCambiar
         Case GridContextMenuManager.CualesCambiar.Actual
            Return {Grilla.FilaSeleccionada(Of DataRow)()}

         Case GridContextMenuManager.CualesCambiar.Seleccionados
            Dim rows = New List(Of DataRow)
            If Grilla.Selected.Rows.Count > 0 Then
               For Each ugr As UltraGridRow In Grilla.Selected.Rows
                  Dim dr As DataRow = Grilla.FilaSeleccionada(Of DataRow)(ugr)
                  If dr IsNot Nothing Then
                     rows.Add(dr)
                  End If
               Next
            ElseIf Grilla.Selected.Cells.Count > 0 Then
               For Each ugc As UltraGridCell In Grilla.Selected.Cells
                  Dim dr As DataRow = Grilla.FilaSeleccionada(Of DataRow)(ugc.Row)
                  If dr IsNot Nothing AndAlso Not rows.Contains(dr) Then
                     rows.Add(dr)
                  End If
               Next
            Else
               Return {Grilla.FilaSeleccionada(Of DataRow)()}
            End If
            Return rows.ToArray()

         Case GridContextMenuManager.CualesCambiar.Filtrados
            Return Grilla.Rows.GetFilteredInNonGroupByRows().ToList().ConvertAll(Function(x) Grilla.FilaSeleccionada(Of DataRow)(x)).ToArray()

         Case GridContextMenuManager.CualesCambiar.Todos
            Return Grilla.Rows.ToList().ConvertAll(Function(x) Grilla.FilaSeleccionada(Of DataRow)(x)).ToArray()

         Case Else
            Throw New NotImplementedException()
      End Select
   End Function

   Private Const CORTAR_MENUITEM_KEY As String = "__CORTAR_MENUITEM__"
   Private Const COPIAR_MENUITEM_KEY As String = "__COPIAR_MENUITEM__"
   Private Const PEGAR_MENUITEM_KEY As String = "__PEGAR_MENUITEM__"
   Private Const ELIMINAR_MENUITEM_KEY As String = "__ELIMINAR_MENUITEM__"
   Private Const SEPARADOR_SELECTODO_MENUITEM_KEY As String = "__SEPARADOR_SELECTODO_MENUITEM__"
   Private Const SELECTODO_MENUITEM_KEY As String = "__SELECTODO_MENUITEM__"
   Private Const SEPARADOR_MENUITEM_KEY As String = "__SEPARADOR_MENUITEM__"

   Private Const CORTAR_MENUITEM_TEXT As String = "Cortar"
   Private Const COPIAR_MENUITEM_TEXT As String = "Copiar"
   Private Const PEGAR_MENUITEM_TEXT As String = "Pegar"
   Private Const ELIMINAR_MENUITEM_TEXT As String = "Eliminar"
   Private Const SELECTODO_MENUITEM_TEXT As String = "Seleccionar Todo"
   Private Sub InicializaOpcionesEstandar(menuContextual As ContextMenuStrip)

      If Not menuContextual.Items.ContainsKey(CORTAR_MENUITEM_KEY) Then
         Dim itemMenu = New ToolStripMenuItem() With {.Text = CORTAR_MENUITEM_TEXT, .Name = CORTAR_MENUITEM_KEY}
         AddHandler itemMenu.Click, Sub(sender, e) Grilla.ActiveCell.Cortar()
         menuContextual.Items.Add(itemMenu)
      End If
      If Not menuContextual.Items.ContainsKey(COPIAR_MENUITEM_KEY) Then
         Dim itemMenu = New ToolStripMenuItem() With {.Text = COPIAR_MENUITEM_TEXT, .Name = COPIAR_MENUITEM_KEY}
         AddHandler itemMenu.Click, Sub(sender, e) Grilla.ActiveCell.Copiar()
         menuContextual.Items.Add(itemMenu)
      End If
      If Not menuContextual.Items.ContainsKey(PEGAR_MENUITEM_KEY) Then
         Dim itemMenu = New ToolStripMenuItem() With {.Text = PEGAR_MENUITEM_TEXT, .Name = PEGAR_MENUITEM_KEY}
         AddHandler itemMenu.Click, Sub(sender, e) Grilla.ActiveCell.Pegar()
         menuContextual.Items.Add(itemMenu)
      End If
      If Not menuContextual.Items.ContainsKey(ELIMINAR_MENUITEM_KEY) Then
         Dim itemMenu = New ToolStripMenuItem() With {.Text = ELIMINAR_MENUITEM_TEXT, .Name = ELIMINAR_MENUITEM_KEY}
         AddHandler itemMenu.Click, Sub(sender, e) Grilla.ActiveCell.Eliminar()
         menuContextual.Items.Add(itemMenu)
      End If
      If Not menuContextual.Items.ContainsKey(SEPARADOR_SELECTODO_MENUITEM_KEY) Then
         menuContextual.Items.Add(New ToolStripSeparator() With {.Name = SEPARADOR_SELECTODO_MENUITEM_KEY})
      End If
      If Not menuContextual.Items.ContainsKey(SELECTODO_MENUITEM_KEY) Then
         Dim itemMenu = New ToolStripMenuItem() With {.Text = SELECTODO_MENUITEM_TEXT, .Name = SELECTODO_MENUITEM_KEY}
         AddHandler itemMenu.Click, Sub(sender, e) Grilla.ActiveCell.SeleccionarTodo()
         menuContextual.Items.Add(itemMenu)
      End If
      If Not menuContextual.Items.ContainsKey(SEPARADOR_MENUITEM_KEY) Then
         menuContextual.Items.Add(New ToolStripSeparator() With {.Name = SEPARADOR_MENUITEM_KEY})
      End If

      AddHandler menuContextual.Opening, Sub(sender, e)
                                            TryCatched(Grilla.FindForm(), Sub() menuContextual.Items(CORTAR_MENUITEM_KEY).Enabled = Grilla.ActiveCell.PuedeEditar And Not Grilla.ActiveCell.TextoSeleccionadoVacio)
                                            TryCatched(Grilla.FindForm(), Sub() menuContextual.Items(COPIAR_MENUITEM_KEY).Enabled = Not Grilla.ActiveCell.TextoSeleccionadoVacio)
                                            TryCatched(Grilla.FindForm(), Sub() menuContextual.Items(PEGAR_MENUITEM_KEY).Enabled = Grilla.ActiveCell.PuedeEditar And Clipboard.ContainsText())
                                            TryCatched(Grilla.FindForm(), Sub() menuContextual.Items(ELIMINAR_MENUITEM_KEY).Enabled = Grilla.ActiveCell.PuedeEditar And Not Grilla.ActiveCell.TextoSeleccionadoVacio)
                                            'TryCatched (menuContextual.FindForm(), Sub()  menuContextual.Items(SELECTODO_MENUITEM_KEY).Enabled = Grilla.ActiveCell.PuedeEditar)
                                         End Sub


   End Sub


#Region "Inner Classes/Enums"

   Public MustInherit Class MenuManager
      Private Property Manager As GridContextMenuManager
      Public MustOverride Function AgregarAcciones(ddi As ToolStripItemCollection) As Boolean
      Protected Sub New(manager As GridContextMenuManager)
         Me.Manager = manager
      End Sub

      Public Sub AgregarTitulo(ddi As ToolStripItemCollection, titulo As String, separadorSuperior As Boolean)
         Dim label As ToolStripLabel = New ToolStripLabel(titulo)
         label.Font = New Font(label.Font, FontStyle.Bold)
         If separadorSuperior Then
            ddi.Add(New ToolStripSeparator())
         End If
         ddi.Add(label)
         ddi.Add(New ToolStripSeparator())
      End Sub


      Protected Sub MenuItemActual_OnClick(sender As Object, e As EventArgs)
         Manager.Cambiar(sender, CualesCambiar.Actual)
      End Sub
      Protected Sub MenuItemSeleccionados_OnClick(sender As Object, e As EventArgs)
         Manager.Cambiar(sender, CualesCambiar.Seleccionados)
      End Sub
      Protected Sub MenuItemFiltrados_OnClick(sender As Object, e As EventArgs)
         Manager.Cambiar(sender, CualesCambiar.Filtrados)
      End Sub
      Protected Sub MenuItemTodos_OnClick(sender As Object, e As EventArgs)
         Manager.Cambiar(sender, CualesCambiar.Todos)
      End Sub
   End Class
   Public Class SoloActualMenuManager
      Inherits MenuManager

      Private Property OnClickCallback As EventHandler

      Public Overrides Function AgregarAcciones(ddi As ToolStripItemCollection) As Boolean
         ddi.Add("Actual", Nothing, OnClickCallback)
      End Function
      Public Sub New(manager As GridContextMenuManager)
         MyBase.New(manager)
         Me.OnClickCallback = AddressOf MenuItemActual_OnClick
      End Sub
   End Class
   Public Class TodasMenuManager
      Inherits MenuManager

      Public Overrides Function AgregarAcciones(ddi As ToolStripItemCollection) As Boolean
         AgregarTitulo(ddi, "Aplicar a", separadorSuperior:=False)
         ddi.Add("Actual", Nothing, AddressOf MenuItemActual_OnClick)
         ddi.Add("Seleccionados", Nothing, AddressOf MenuItemSeleccionados_OnClick)
         ddi.Add("Filtrados", Nothing, AddressOf MenuItemFiltrados_OnClick)
         ddi.Add("Todos", Nothing, AddressOf MenuItemTodos_OnClick)
      End Function
      Public Sub New(manager As GridContextMenuManager)
         MyBase.New(manager)
      End Sub
   End Class

   Public MustInherit Class MenuBase
      Public Property MenuManager As MenuManager
      Public Property MenuName As String
      Public Property MenuHijos As IEnumerable(Of MenuBase)
      Protected Property Manager As GridContextMenuManager

      Protected Sub AgregarMenuHijos(ddi As ToolStripItemCollection, Optional agregarTituloCombinar As Boolean = True)
         If CargarHijos() Then
            If agregarTituloCombinar Then
               If MenuManager IsNot Nothing Then MenuManager.AgregarTitulo(ddi, "Combinar con", separadorSuperior:=True)
            End If
            MenuHijos.All(Function(x) x.Ejecutar(ddi))
         End If
      End Sub

      Public MustOverride Function CargarHijos() As Boolean

      Protected Function AgregarAccionesEHijos(ddi As ToolStripItemCollection) As Boolean
         If MenuManager IsNot Nothing Then
            MenuManager.AgregarAcciones(ddi)
         End If

         AgregarMenuHijos(ddi)
         Return True
      End Function

      Private Sub MenuItemActual_OnClick(sender As Object, e As EventArgs)
         Manager.Cambiar(sender, CualesCambiar.Actual)
      End Sub
      Private Sub MenuItemSeleccionados_OnClick(sender As Object, e As EventArgs)
         Manager.Cambiar(sender, CualesCambiar.Seleccionados)
      End Sub
      Private Sub MenuItemFiltrados_OnClick(sender As Object, e As EventArgs)
         Manager.Cambiar(sender, CualesCambiar.Filtrados)
      End Sub
      Private Sub MenuItemTodos_OnClick(sender As Object, e As EventArgs)
         Manager.Cambiar(sender, CualesCambiar.Todos)
      End Sub

      Public MustOverride Function Ejecutar(ddi As ToolStripItemCollection) As Boolean
      Public MustOverride Sub CargarColeccion(ddi As ToolStripItemCollection)

      Protected Sub MenuItem_DropDownOpening(sender As Object, e As EventArgs)
         Dim tsmi As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
         If TypeOf (tsmi.Tag) Is MenuBase Then
            Dim mnu As MenuBase = DirectCast(tsmi.Tag, MenuBase)
            CargarColeccion(tsmi.DropDownItems)
         End If
      End Sub

      Protected Sub New(menu As String, menuHijos As IEnumerable(Of MenuBase), manager As GridContextMenuManager, acciones As MenuManager)
         Me.MenuName = menu
         Me.MenuHijos = menuHijos
         Me.Manager = manager
         Me.MenuManager = acciones
      End Sub

   End Class

   Public Class MenuAccion
      Inherits MenuBase

      Public Overrides Sub CargarColeccion(ddi As ToolStripItemCollection)
         AgregarMenuHijos(ddi, agregarTituloCombinar:=False)
      End Sub

      Public Overrides Function Ejecutar(ddi As ToolStripItemCollection) As Boolean
         ddi = ddi.AddMenuItem(Me.MenuName, tag:=Me, openingCallback:=AddressOf MenuItem_DropDownOpening).DropDownItems
         Return True
      End Function

      Friend Sub New(menu As String, menuHijos As IEnumerable(Of MenuBase), manager As GridContextMenuManager, acciones As MenuManager)
         MyBase.New(menu, menuHijos, manager, acciones)
      End Sub

      Private _cargarHijos As Boolean = True
      Public Overrides Function CargarHijos() As Boolean
         Dim _result As Boolean = _cargarHijos
         _cargarHijos = False
         Return MenuHijos IsNot Nothing AndAlso MenuHijos.Count > 0 AndAlso _result
      End Function
   End Class

   Public Class MenuAccion(Of T)
      Inherits MenuBase
      Public Property DataSource As DataSourceMenu(Of T)
      Private Property Cargado As Boolean = False

      Public Overrides Sub CargarColeccion(ddi As ToolStripItemCollection)
         If ddi.Count = 0 Then
            DataSource.Coleccion.All(Function(x) AgregarAccionesEHijos(ddi.AddMenuItem(DataSource.FuncionNombre(x), x).DropDownItems))
         End If
      End Sub

      Public Overrides Function Ejecutar(ddi As ToolStripItemCollection) As Boolean
         ddi = ddi.AddMenuItem(Me.MenuName, tag:=Me, openingCallback:=AddressOf MenuItem_DropDownOpening).DropDownItems
         Return True
      End Function

      Public Overrides Function CargarHijos() As Boolean
         Return MenuHijos IsNot Nothing AndAlso MenuHijos.Count > 0 AndAlso DataSource.Coleccion.Count > 0
      End Function

      Friend Sub New(menu As String, dataSource As DataSourceMenu(Of T), menuHijos As IEnumerable(Of MenuBase), manager As GridContextMenuManager, acciones As MenuManager)
         MyBase.New(menu, menuHijos, manager, acciones)
         Me.DataSource = dataSource
      End Sub
   End Class

   Public Class MenuSeparator
      Inherits MenuBase

      Public Overrides Sub CargarColeccion(ddi As ToolStripItemCollection)
      End Sub
      Public Overrides Function CargarHijos() As Boolean
         Return True
      End Function

      Public Overrides Function Ejecutar(ddi As ToolStripItemCollection) As Boolean
         Return ddi.Add(New ToolStripSeparator()) > -1
      End Function

      Friend Sub New(manager As GridContextMenuManager)
         MyBase.New(String.Empty, {}, manager, acciones:=Nothing)
      End Sub
   End Class

   Public Class DataSourceMenu(Of T)
      Public Property Coleccion As IEnumerable(Of T)
      Public Property FuncionNombre As Func(Of T, String)
      Public Sub New(coleccion As IEnumerable(Of T), funcionNombre As Func(Of T, String))
         Me.Coleccion = coleccion
         Me.FuncionNombre = funcionNombre
      End Sub
   End Class

   Private Enum CualesCambiar
      Actual
      Seleccionados
      Filtrados
      Todos
   End Enum
#End Region

End Class