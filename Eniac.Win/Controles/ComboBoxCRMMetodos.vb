Public Class ComboBoxCRMMetodos
   Inherits ComboBoxMultipleSeleccion2

   Private _listaMetodos As List(Of Entidades.CRMMetodoResolucionNovedad)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _idTipoNovedad As String
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Event AfterSelectedIndexChanged As EventHandler

   Public Sub New()
      MyBase.New()
      _listaMetodos = New List(Of Entidades.CRMMetodoResolucionNovedad)()
   End Sub

   Public Overrides Function GetTodos() As IEnumerable(Of Entidades.IComboBoxMultipleSeleccionElement)
      'Return GetCategorias(idTipoNovedad:=_idTipoNovedad, ordenarPosicion:=False)
   End Function
   Public Function GetMetodos(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As Entidades.CRMMetodoResolucionNovedad()
      Return GetMetodos(False, idTipoNovedad)
   End Function
   Public Function GetMetodos(todosVacio As Boolean, idTipoNovedad As String) As Entidades.CRMMetodoResolucionNovedad()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFCRMMetodos.GetTodas(idTipoNovedad:=idTipoNovedad, ordenarPosicion:=False).ToArray()
      End If
      Return _listaMetodos.ToArray()
   End Function

   Public Sub Inicializar()
      Inicializar(True)
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean)
      Inicializar(permiteSinSeleccion, True, True)
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, Optional idTipoNovedad As String = "")
      _idTipoNovedad = idTipoNovedad
      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboCRMMetodoResolucionNovedad(Me, seleccionMultiple, seleccionTodos, idTipoNovedad)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaMetodos.Clear()
      _listaMetodos.Add(DirectCast(SelectedItem, Entidades.CRMMetodoResolucionNovedad))

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
            Using filtromultiplecomprobantes As New MFCRMMetodos(_permiteSinSeleccion, _idTipoNovedad)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaMetodos.Any() AndAlso _listaMetodos(0).IdMetodoResolucionNovedad = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFCRMMetodos.GetTodas(idTipoNovedad:=_idTipoNovedad, ordenarPosicion:=False))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaMetodos)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaMetodos.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaMetodos.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaMetodos.Count = 1 Then
                     SelectedValue = _listaMetodos(0).IdMetodoResolucionNovedad
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaMetodos.Clear()
                  _listaMetodos.Add(DirectCast(SelectedItem, Entidades.CRMMetodoResolucionNovedad))
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
      Return New CargaFiltroImpresionParams("Categoria", "Categorias")
   End Function

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFCRMMetodos.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFCRMMetodos = New MFCRMMetodos(_permiteSinSeleccion, _idTipoNovedad)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaMetodos.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            '     _listaCategorias.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub

End Class