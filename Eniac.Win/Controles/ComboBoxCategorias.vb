Public Class ComboBoxCategorias
   Inherits ComboBoxMultipleSeleccion

   Private _listaCategorias As List(Of Entidades.Categoria)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Sub New()
      MyBase.New()
      _listaCategorias = New List(Of Entidades.Categoria)()
   End Sub

   Public Function GetCategorias() As Entidades.Categoria()
      Return GetCategorias(False)
   End Function
   Public Function GetCategorias(todosVacio As Boolean) As Entidades.Categoria()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFCategorias.GetTodas().ToArray()
      End If
      Return _listaCategorias.ToArray()
   End Function

   Public Sub Inicializar(permiteSinSeleccion As Boolean)
      Inicializar(permiteSinSeleccion, True, True)
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean)

      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboCategorias(Me, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaCategorias.Clear()
      _listaCategorias.Add(DirectCast(SelectedItem, Entidades.Categoria))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Public Sub Refrescar()
      SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFCategorias(_permiteSinSeleccion)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaCategorias.Any() AndAlso _listaCategorias(0).IdCategoria = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFCategorias.GetTodas())
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaCategorias)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaCategorias.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaCategorias.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaCategorias.Count = 1 Then
                     SelectedValue = _listaCategorias(0).IdCategoria
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaCategorias.Clear()
                  _listaCategorias.Add(DirectCast(SelectedItem, Entidades.Categoria))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Sub CargarFiltrosImpresionCategorias(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim categorias As Entidades.Categoria() = GetCategorias()
            Dim formatoCategoria As String = String.Empty
            If muestraId And muestraNombre Then formatoCategoria = "{0} - {1}"
            If muestraId And Not muestraNombre Then formatoCategoria = "{0}"
            If Not muestraId And muestraNombre Then formatoCategoria = "{1}"
            If Not muestraId And Not muestraNombre Then formatoCategoria = ""
            If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
               .AppendFormat("Categorias: {0}", Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
            Else
               If categorias.Count = 1 Then
                  .AppendFormat("Categoria: ").AppendFormat(formatoCategoria, categorias(0).IdCategoria, categorias(0).NombreCategoria)
               ElseIf categorias.Count > 1 Then
                  .AppendFormat("Categorias: ")
                  Dim primera As Boolean = True
                  For Each suc As Entidades.Categoria In categorias
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formatoCategoria, suc.IdCategoria, suc.NombreCategoria)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFCategorias.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFCategorias = New MFCategorias(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaCategorias.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaCategorias.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class