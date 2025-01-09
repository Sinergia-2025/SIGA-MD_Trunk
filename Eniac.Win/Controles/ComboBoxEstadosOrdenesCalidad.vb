Public Class ComboBoxEstadosOrdenesCalidad
   Inherits ComboBoxMultipleSeleccion

   Private _listaEstadosComprobantes As List(Of Entidades.EstadoOrdenCalidad)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean
   Private _idFuncion As String
   Private _defaultValue As String

   Public Sub New()
      MyBase.New()
      _listaEstadosComprobantes = New List(Of Entidades.EstadoOrdenCalidad)()
   End Sub

   Public Function GetEstadosOrdenesCalidad() As Entidades.EstadoOrdenCalidad()
      Return GetEstadosOrdenesCalidad(todosVacio:=True)
   End Function
   Public Function GetEstadosOrdenesCalidad(todosVacio As Boolean) As Entidades.EstadoOrdenCalidad()
      If SelectedValue.ToString() = Publicos.GetEnumString(Entidades.EstadoOrdenCalidad.ValoresFijosEstadosOrdenesCalidad.Todos) Then
         If todosVacio Then Return {}
         Return MFEstadosOrdenesCalidad.GetTodas().ToArray()
      End If
      Return _listaEstadosComprobantes.ToArray()
   End Function

   Public Sub Initializar()
      Initializar(True)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean)
      Initializar(permiteSinSeleccion, True, True, String.Empty, Publicos.GetEnumString(Entidades.EstadoOrdenCalidad.ValoresFijosEstadosOrdenesCalidad.Todos))
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, idFuncion As String, defaultValue As String)
      Initializar(permiteSinSeleccion, True, True, idFuncion, defaultValue)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String)
      Initializar(permiteSinSeleccion, seleccionMultiple, seleccionTodos, idFuncion, Publicos.GetEnumString(Entidades.EstadoOrdenCalidad.ValoresFijosEstadosOrdenesCalidad.Todos))
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String,
                          defaultValue As String)

      _defaultValue = defaultValue

      ctxMenu = New ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _idFuncion = idFuncion
      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboEstadosOrdenCalidad(Me, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaEstadosComprobantes.Clear()
      _listaEstadosComprobantes.Add(DirectCast(SelectedItem, Entidades.EstadoOrdenCalidad))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Public Sub Refrescar()
      SelectedValue = _defaultValue
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFEstadosOrdenesCalidad(_permiteSinSeleccion, _idFuncion)
               If SelectedValue.ToString() = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaEstadosComprobantes.Any() Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFEstadosOrdenesCalidad.GetTodas())
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaEstadosComprobantes)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaEstadosComprobantes.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaEstadosComprobantes.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaEstadosComprobantes.Count = 1 Then
                     SelectedValue = _listaEstadosComprobantes(0).IdEstadoCalidad
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaEstadosComprobantes.Clear()
                  _listaEstadosComprobantes.Add(DirectCast(SelectedItem, Entidades.EstadoOrdenCalidad))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
      RaiseEvent AfterSelectedIndexChanged(Me, Nothing)
   End Sub

   Public Event AfterSelectedIndexChanged(sender As Object, e As EventArgs)

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFEstadosOrdenesCalidad.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm = New MFEstadosOrdenesCalidad(_permiteSinSeleccion, _idFuncion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaEstadosComprobantes.Clear()
            SelectedValue = Convert.ToInt32(Entidades.EstadoOrdenCalidad.ValoresFijosEstadosOrdenesCalidad.SeleccionMultiple)
            _listaEstadosComprobantes.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class