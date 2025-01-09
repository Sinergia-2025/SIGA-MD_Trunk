Public Class ComboBoxCRMMediosComunicacionNovedades
   Inherits ComboBoxMultipleSeleccion2

   Private _listaMedios As List(Of Entidades.CRMMedioComunicacionNovedad)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _idTipoNovedad As String
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Event AfterSelectedIndexChanged As EventHandler

   Public Sub New()
      MyBase.New()
      _listaMedios = New List(Of Entidades.CRMMedioComunicacionNovedad)()
   End Sub

   Public Overrides Function GetTodos() As IEnumerable(Of Entidades.IComboBoxMultipleSeleccionElement)
      'Return GetCategorias(idTipoNovedad:=_idTipoNovedad, ordenarPosicion:=False)
   End Function
   Public Function GetMedio(idEstadoNovedad As String, Optional ordenarPosicion As Boolean = False) As Entidades.CRMMedioComunicacionNovedad()
      Return GetMedio(False, idEstadoNovedad)
   End Function
   Public Function GetMedio(todosVacio As Boolean, idTipoNovedad As String) As Entidades.CRMMedioComunicacionNovedad()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFCRMMedios.GetTodas(idTipoNovedad:=idTipoNovedad, ordenarPosicion:=False).ToArray()
      End If
      Return _listaMedios.ToArray()
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
      _publicos.CargaComboCRMMediosComunicacionesNovedades(Me, seleccionMultiple, seleccionTodos, idTipoNovedad)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaMedios.Clear()
      _listaMedios.Add(DirectCast(SelectedItem, Entidades.CRMMedioComunicacionNovedad))

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
            Using filtromultiplecomprobantes As New MFCRMMedios(_permiteSinSeleccion, _idTipoNovedad)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaMedios.Any() AndAlso _listaMedios(0).IdMedioComunicacionNovedad = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFCRMMedios.GetTodas(idTipoNovedad:=_idTipoNovedad, ordenarPosicion:=False))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaMedios)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaMedios.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaMedios.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaMedios.Count = 1 Then
                     SelectedValue = _listaMedios(0).IdMedioComunicacionNovedad
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaMedios.Clear()
                  _listaMedios.Add(DirectCast(SelectedItem, Entidades.CRMMedioComunicacionNovedad))
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
      Return New CargaFiltroImpresionParams("Medios", "Medios")
   End Function

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFCRMMedios.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFCRMMedios = New MFCRMMedios(_permiteSinSeleccion, _idTipoNovedad)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaMedios.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            '_listaEstados.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub

End Class