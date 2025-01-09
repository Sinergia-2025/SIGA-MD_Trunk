Public Class ComboBoxSubSubRubro
   Inherits ComboBoxMultipleSeleccion2

   Private _listaSubSubRubros As List(Of Entidades.SubSubRubro)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean
   Private _subRubro As Entidades.SubRubro()

   Public Property ConcatenarNombreSubRubro As Boolean = False

   Public Sub New()
      MyBase.New()
      _listaSubSubRubros = New List(Of Entidades.SubSubRubro)()
   End Sub

   Public Overrides Function GetTodos() As IEnumerable(Of Entidades.IComboBoxMultipleSeleccionElement)
      Return GetSubSubRubros()
   End Function
   Public Function GetSubSubRubros() As Entidades.SubSubRubro()
      Return GetSubSubRubros(False)
   End Function
   Public Function GetSubSubRubros(todosVacio As Boolean) As Entidades.SubSubRubro()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFSubSubRubros.GetTodos(_subRubro).ToArray()
      End If
      Return _listaSubSubRubros.ToArray()
   End Function

   Public Sub Inicializar(permiteSinSeleccion As Boolean)
      Inicializar(permiteSinSeleccion, True, True, {})
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean,
                          subRubro As Entidades.SubRubro)
      Inicializar(permiteSinSeleccion, seleccionMultiple, seleccionTodos, {subRubro})
   End Sub
   Public Function Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean,
                               subRubro As Entidades.SubRubro()) As ComboBoxSubSubRubro
      _subRubro = subRubro
      _initialized = False
      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboSubSubRubros(Me, If(ConcatenarNombreSubRubro, "NombreRubroSubRubroSubSubRubro", "NombreSubSubRubro"), seleccionMultiple, seleccionTodos, _subRubro)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaSubSubRubros.Clear()
      _listaSubSubRubros.Add(DirectCast(SelectedItem, Entidades.SubSubRubro))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

      Return Me
   End Function

   Public Sub Refrescar()
      SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFSubSubRubros(_permiteSinSeleccion, ConcatenarNombreSubRubro)
               filtromultiplecomprobantes.SubRubro = _subRubro
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaSubSubRubros.Any() AndAlso _listaSubSubRubros(0).IdSubSubRubro = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFSubSubRubros.GetTodos(_subRubro))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaSubSubRubros)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaSubSubRubros.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaSubSubRubros.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaSubSubRubros.Count = 1 Then
                     SelectedValue = _listaSubSubRubros(0).IdSubSubRubro
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaSubSubRubros.Clear()
                  _listaSubSubRubros.Add(DirectCast(SelectedItem, Entidades.SubSubRubro))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Overrides Function GetDefaultParametrosImpresion() As CargaFiltroImpresionParams
      Return New CargaFiltroImpresionParams("SubSubRubro", "SubSubRubros")
   End Function
   <Obsolete()>
   Public Sub CargarFiltrosImpresionSubRubros(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, todosVacio:=False)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionSubSubRubros(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, todosVacio:=False)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionSubSubRubros(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, prefijo, sufijo, todosVacio:=False)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionSubSubRubros(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String, todosVacio As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, prefijo, sufijo, todosVacio)
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFSubSubRubros.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFSubSubRubros = New MFSubSubRubros(_permiteSinSeleccion, ConcatenarNombreSubRubro)
            frm.SubRubro = _subRubro
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaSubSubRubros.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaSubSubRubros.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub

End Class