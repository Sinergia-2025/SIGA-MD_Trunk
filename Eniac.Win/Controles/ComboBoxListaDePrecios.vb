Public Class ComboBoxListaDePrecios
   Inherits ComboBoxMultipleSeleccion

   Private _listaDePrecios As List(Of Entidades.ListaDePrecios)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Sub New()
      MyBase.New()
      _listaDePrecios = New List(Of Entidades.ListaDePrecios)()
   End Sub

   Public Function GetListaDePrecios() As Entidades.ListaDePrecios()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         Return MFListaDePrecios.GetTodas().ToArray()
      End If
      Return _listaDePrecios.ToArray()
   End Function

   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean)

      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboListasDePrecios(Me, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaDePrecios.Clear()
      _listaDePrecios.Add(DirectCast(SelectedItem, Entidades.ListaDePrecios))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Public Sub Refrescar()
      SelectedValue = Publicos.ListaPreciosPredeterminada
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFListaDePrecios(_permiteSinSeleccion)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaDePrecios.Any() AndAlso _listaDePrecios(0).IdSucursal = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFListaDePrecios.GetTodas())
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaDePrecios)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaDePrecios.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaDePrecios.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaDePrecios.Count = 1 Then
                     SelectedValue = _listaDePrecios(0).IdListaPrecios
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaDePrecios.Clear()
                  _listaDePrecios.Add(DirectCast(SelectedItem, Entidades.ListaDePrecios))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
      RaiseEvent AfterSelectedIndexChanged(Me, Nothing)
   End Sub

   Public Event AfterSelectedIndexChanged(sender As Object, e As EventArgs)

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFListaDePrecios.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFListaDePrecios = New MFListaDePrecios(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaDePrecios.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaDePrecios.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class
