Public Class ComboBoxMovilRutas
   Inherits ComboBoxMultipleSeleccion

   Private _listaMovilRutas As List(Of Entidades.MovilRuta)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Sub New()
      MyBase.New()
      _listaMovilRutas = New List(Of Entidades.MovilRuta)()
   End Sub

   Public Function GetMovilRutas() As Entidades.MovilRuta()
      Return GetMovilRutas(False)
   End Function
   Public Function GetMovilRutas(todosVacio As Boolean) As Entidades.MovilRuta()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFMovilRutas.GetTodas().ToArray()
      End If
      Return _listaMovilRutas.ToArray()
   End Function

   Public Sub Inicializar(permiteSinSeleccion As Boolean)
      Inicializar(permiteSinSeleccion, seleccionMultiple:=True, seleccionTodos:=True, cargarListaPrecios:=True)
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, cargarListaPrecios As Boolean)

      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboRutas(Me, True, seleccionMultiple, seleccionTodos, cargarListaPrecios)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaMovilRutas.Clear()
      _listaMovilRutas.Add(DirectCast(SelectedItem, Entidades.MovilRuta))

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
            Using filtromultiplecomprobantes As New MFMovilRutas(_permiteSinSeleccion)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaMovilRutas.Any() AndAlso _listaMovilRutas(0).IdRuta = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFMovilRutas.GetTodas())
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaMovilRutas)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaMovilRutas.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaMovilRutas.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaMovilRutas.Count = 1 Then
                     SelectedValue = _listaMovilRutas(0).IdRuta
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaMovilRutas.Clear()
                  _listaMovilRutas.Add(DirectCast(SelectedItem, Entidades.MovilRuta))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Sub CargarFiltrosImpresionMovilRutas(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim MovilRutas As Entidades.MovilRuta() = GetMovilRutas()
            Dim formatoMovilRuta As String = String.Empty
            If muestraId And muestraNombre Then formatoMovilRuta = "{0} - {1}"
            If muestraId And Not muestraNombre Then formatoMovilRuta = "{0}"
            If Not muestraId And muestraNombre Then formatoMovilRuta = "{1}"
            If Not muestraId And Not muestraNombre Then formatoMovilRuta = ""
            If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
               .AppendFormat("MovilRutas: {0}", Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
            Else
               If MovilRutas.Count = 1 Then
                  .AppendFormat("MovilRuta: ").AppendFormat(formatoMovilRuta, MovilRutas(0).IdRuta, MovilRutas(0).NombreRuta)
               ElseIf MovilRutas.Count > 1 Then
                  .AppendFormat("MovilRutas: ")
                  Dim primera As Boolean = True
                  For Each suc As Entidades.MovilRuta In MovilRutas
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formatoMovilRuta, suc.IdRuta, suc.NombreRuta)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFMovilRutas.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm = New MFMovilRutas(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaMovilRutas.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaMovilRutas.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class