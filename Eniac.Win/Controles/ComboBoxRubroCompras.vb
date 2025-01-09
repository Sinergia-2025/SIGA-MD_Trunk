Public Class ComboBoxRubroCompras
   Inherits ComboBoxMultipleSeleccion2

   Private _listaRubros As List(Of Entidades.RubroCompra)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Event AfterSelectedIndexChanged As EventHandler

   Public Sub New()
      MyBase.New()
      _listaRubros = New List(Of Entidades.RubroCompra)()
   End Sub

   Public Overrides Function GetTodos() As IEnumerable(Of Entidades.IComboBoxMultipleSeleccionElement)
      Return GetRubrosCompras()
   End Function
   Public Function GetRubrosCompras() As Entidades.RubroCompra()
      Return GetRubrosCompras(True)
   End Function
   Public Function GetRubrosCompras(todosVacio As Boolean) As Entidades.RubroCompra()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFRubrosCompras.GetTodos().ToArray()
      End If
      Return _listaRubros.ToArray()
   End Function

   Public Sub Inicializar()
      Inicializar(True)
   End Sub
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
      _publicos.CargaComboRubrosCompras(Me, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaRubros.Clear()
      _listaRubros.Add(DirectCast(SelectedItem, Entidades.RubroCompra))

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
            Using filtromultiplecomprobantes As New MFRubrosCompras(_permiteSinSeleccion)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaRubros.Any() AndAlso _listaRubros(0).IdRubro = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFRubrosCompras.GetTodos())
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaRubros)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaRubros.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaRubros.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaRubros.Count = 1 Then
                     SelectedValue = _listaRubros(0).IdRubro
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaRubros.Clear()
                  _listaRubros.Add(DirectCast(SelectedItem, Entidades.RubroCompra))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
      OnAfterSelectedIndexChanged(Nothing)
   End Sub

   Protected Overridable Sub OnAfterSelectedIndexChanged(e As EventArgs)
      RaiseEvent AfterSelectedIndexChanged(Me, e)
   End Sub

   Public Overrides Function GetDefaultParametrosImpresion() As CargaFiltroImpresionParams
      Return New CargaFiltroImpresionParams("Rubro", "Rubros")
   End Function

   <Obsolete()>
   Public Sub CargarFiltrosImpresionRubros(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, todosVacio:=False)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionRubros(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, prefijo, sufijo, todosVacio:=False)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionRubros(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String, todosVacio As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, prefijo, sufijo, todosVacio)
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFRubros.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm = New MFRubrosCompras(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaRubros.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaRubros.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub

End Class