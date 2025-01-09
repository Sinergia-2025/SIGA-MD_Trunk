Public Class ComboBoxMarcas
   Inherits ComboBoxMultipleSeleccion2

   Private _listaMarcas As List(Of Entidades.Marca)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Event AfterSelectedIndexChanged As EventHandler

   Public Sub New()
      MyBase.New()
      _listaMarcas = New List(Of Entidades.Marca)()
   End Sub

   Public Overrides Function GetTodos() As IEnumerable(Of Entidades.IComboBoxMultipleSeleccionElement)
      Return GetMarcas()
   End Function
   Public Function GetMarcas() As Entidades.Marca()
      Return GetMarcas(False)
   End Function
   Public Function GetMarcas(todosVacio As Boolean) As Entidades.Marca()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFMarcas.GetTodas().ToArray()
      End If
      Return _listaMarcas.ToArray()
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
      _publicos.CargaComboMarcas(Me, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaMarcas.Clear()
      _listaMarcas.Add(DirectCast(SelectedItem, Entidades.Marca))

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
            Using filtromultiplecomprobantes As New MFMarcas(_permiteSinSeleccion)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaMarcas.Any() AndAlso _listaMarcas(0).IdMarca = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFMarcas.GetTodas())
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaMarcas)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaMarcas.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaMarcas.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaMarcas.Count = 1 Then
                     SelectedValue = _listaMarcas(0).IdMarca
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaMarcas.Clear()
                  _listaMarcas.Add(DirectCast(SelectedItem, Entidades.Marca))
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
      Return New CargaFiltroImpresionParams("Marca", "Marcas")
   End Function

   <Obsolete()>
   Public Sub CargarFiltrosImpresionMarcas(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, todosVacio:=False)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionMarcas(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, prefijo, sufijo)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionMarcas(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String, todosVacio As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, prefijo, sufijo, todosVacio)
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFMarcas.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFMarcas = New MFMarcas(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaMarcas.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaMarcas.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub

End Class