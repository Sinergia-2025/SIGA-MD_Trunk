Public Class ComboBoxSubRubro
   Inherits ComboBoxMultipleSeleccion2

   Private _listaSubRubros As List(Of Entidades.SubRubro)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean
   Private _rubros As Entidades.Rubro()

   Public Property ConcatenarNombreRubro As Boolean = False

   Public Event AfterSelectedIndexChanged As EventHandler
   Public Sub New()
      MyBase.New()
      _listaSubRubros = New List(Of Entidades.SubRubro)()
   End Sub

   Public Overrides Function GetTodos() As IEnumerable(Of Entidades.IComboBoxMultipleSeleccionElement)
      Return GetSubRubros()
   End Function
   Public Function GetSubRubros() As Entidades.SubRubro()
      Return GetSubRubros(False)
   End Function
   Public Function GetSubRubros(todosVacio As Boolean) As Entidades.SubRubro()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFSubRubros.GetTodos(_rubros).ToArray()
      End If
      Return _listaSubRubros.ToArray()
   End Function

   Public Sub Inicializar(permiteSinSeleccion As Boolean)
      Inicializar(permiteSinSeleccion, True, True, {})
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean,
                          rubro As Entidades.Rubro)
      Inicializar(permiteSinSeleccion, seleccionMultiple, seleccionTodos, {rubro})
   End Sub
   Public Function Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean,
                               rubros As Entidades.Rubro()) As ComboBoxSubRubro
      _rubros = rubros
      _initialized = False
      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboSubRubros(Me, If(ConcatenarNombreRubro, "NombreRubroSubRubro", "NombreSubRubro"), seleccionMultiple, seleccionTodos, _rubros)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaSubRubros.Clear()
      _listaSubRubros.Add(DirectCast(SelectedItem, Entidades.SubRubro))

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
            Using filtromultiplecomprobantes As New MFSubRubros(_permiteSinSeleccion, ConcatenarNombreRubro)
               filtromultiplecomprobantes.Rubros = _rubros
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaSubRubros.Any() AndAlso _listaSubRubros(0).IdSubRubro = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFSubRubros.GetTodos(_rubros))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaSubRubros)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaSubRubros.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaSubRubros.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaSubRubros.Count = 1 Then
                     SelectedValue = _listaSubRubros(0).IdSubRubro
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaSubRubros.Clear()
                  _listaSubRubros.Add(DirectCast(SelectedItem, Entidades.SubRubro))
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
      Return New CargaFiltroImpresionParams("SubRubro", "SubRubros")
   End Function
   <Obsolete()>
   Public Sub CargarFiltrosImpresionSubRubros(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, todosVacio:=False)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionSubRubros(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, prefijo, sufijo, todosVacio:=False)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionSubRubros(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String, todosVacio As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, prefijo, sufijo, todosVacio)
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFSubRubros.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFSubRubros = New MFSubRubros(_permiteSinSeleccion, ConcatenarNombreRubro)
            frm.Rubros = _rubros
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaSubRubros.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaSubRubros.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub

End Class