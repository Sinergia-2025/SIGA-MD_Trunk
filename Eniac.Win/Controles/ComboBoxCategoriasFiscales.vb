Public Class ComboBoxCategoriasFiscales
   Inherits ComboBoxMultipleSeleccion

   Private _listaCategorias As List(Of Entidades.CategoriaFiscal)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Sub New()
      MyBase.New()
      _listaCategorias = New List(Of Entidades.CategoriaFiscal)()
   End Sub

   Public Function GetCategoriasFIscales() As Entidades.CategoriaFiscal()
      Return GetCategoriasFiscales(True)
   End Function
   Public Function GetCategoriasFiscales(todosVacio As Boolean) As Entidades.CategoriaFiscal()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFCategoriasFiscales.GetTodas().ToArray()
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
      _publicos.CargaComboCategoriasFiscales(Me, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaCategorias.Clear()
      _listaCategorias.Add(DirectCast(SelectedItem, Entidades.CategoriaFiscal))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Public Sub Refrescar()
      SelectedValue = Short.Parse(Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos).ToString())
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecategorias As New MFCategoriasFiscales(_permiteSinSeleccion)
               If SelectedValue.Equals(Short.Parse(Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple).ToString())) Then
                  If _listaCategorias IsNot Nothing AndAlso _listaCategorias.Count > 0 AndAlso _listaCategorias(0) IsNot Nothing Then
                     If _listaCategorias.Any() AndAlso _listaCategorias(0).IdCategoriaFiscal.Equals(Short.Parse(Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos).ToString())) Then
                        filtromultiplecategorias.Filtros.AddRange(MFCategoriasFiscales.GetTodas())
                     Else
                        filtromultiplecategorias.Filtros.AddRange(_listaCategorias)
                     End If
                  End If
                  filtromultiplecategorias.ShowDialog()
                  _listaCategorias.Clear()
                  If filtromultiplecategorias.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaCategorias.AddRange(filtromultiplecategorias.Filtros)
                  End If
                  If _listaCategorias.Count = 1 Then
                     SelectedValue = _listaCategorias(0).IdCategoriaFiscal
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaCategorias.Clear()
                  _listaCategorias.Add(DirectCast(SelectedItem, Entidades.CategoriaFiscal))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Sub CargarFiltrosImpresionCategorias(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim categorias As Entidades.CategoriaFiscal() = GetCategoriasFIscales()
            Dim formatoCategoria As String = String.Empty
            If muestraId And muestraNombre Then formatoCategoria = "{0} - {1}"
            If muestraId And Not muestraNombre Then formatoCategoria = "{0}"
            If Not muestraId And muestraNombre Then formatoCategoria = "{1}"
            If Not muestraId And Not muestraNombre Then formatoCategoria = ""
            If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
               .AppendFormat("Categorias: {0}", Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
            Else
               If categorias.Count = 1 Then
                  .AppendFormat("Categoria: ").AppendFormat(formatoCategoria, categorias(0).IdCategoriaFiscal, categorias(0).NombreCategoriaFiscal)
               ElseIf categorias.Count > 1 Then
                  .AppendFormat("Categorias: ")
                  Dim primera As Boolean = True
                  For Each suc As Entidades.CategoriaFiscal In categorias
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formatoCategoria, suc.IdCategoriaFiscal, suc.NombreCategoriaFiscal)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFCategoriasFiscales.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFCategoriasFiscales = New MFCategoriasFiscales(_permiteSinSeleccion)
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