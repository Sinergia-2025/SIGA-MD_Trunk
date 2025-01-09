Public Class ComboBoxTipoCliente
   Inherits ComboBoxMultipleSeleccion

   Private _listaTipoCliente As List(Of Entidades.TipoCliente)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean
   Private _idFuncion As String

   Public Sub New()
      MyBase.New()
      _listaTipoCliente = New List(Of Entidades.TipoCliente)()
   End Sub

   Public Function GetTipoClientes() As Entidades.TipoCliente()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         Return MFTiposCliente.GetTodas(_idFuncion).ToArray()
      End If
      Return _listaTipoCliente.ToArray()
   End Function

   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String)

      ctxMenu = New ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _idFuncion = idFuncion
      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboTipoClientes(Me, seleccionMultiple, seleccionTodos, idFuncion)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaTipoCliente.Clear()
      _listaTipoCliente.Add(DirectCast(SelectedItem, Entidades.TipoCliente))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Public Sub Refrescar()
      SelectedValue = actual.Sucursal.IdSucursal
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFTiposCliente(_permiteSinSeleccion, _idFuncion)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaTipoCliente.Any() AndAlso _listaTipoCliente(0).IdSucursal = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFTiposCliente.GetTodas(_idFuncion))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaTipoCliente)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaTipoCliente.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaTipoCliente.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaTipoCliente.Count = 1 Then
                     SelectedValue = _listaTipoCliente(0).IdTipoCliente
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaTipoCliente.Clear()
                  _listaTipoCliente.Add(DirectCast(SelectedItem, Entidades.TipoCliente))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
      RaiseEvent AfterSelectedIndexChanged(Me, Nothing)
   End Sub

   Public Event AfterSelectedIndexChanged(sender As Object, e As EventArgs)

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFTiposCliente.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFTiposCliente = New MFTiposCliente(_permiteSinSeleccion, _idFuncion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaTipoCliente.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaTipoCliente.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class
