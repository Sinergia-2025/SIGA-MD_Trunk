Public Class ComboBoxModelos
   Inherits ComboBoxMultipleSeleccion2

   Private _listaModelos As List(Of Entidades.Modelo)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean
   Private _marcas As Entidades.Marca()

   Public Property ConcatenarNombreMarca As Boolean = False

   Public Event AfterSelectedIndexChanged As EventHandler
   Public Sub New()
      MyBase.New()
      _listaModelos = New List(Of Entidades.Modelo)()
   End Sub

   Public Overrides Function GetTodos() As IEnumerable(Of Entidades.IComboBoxMultipleSeleccionElement)
      Return GetModelos()
   End Function
   Public Function GetModelos() As Entidades.Modelo()
      Return GetModelos(False)
   End Function
   Public Function GetModelos(todosVacio As Boolean) As Entidades.Modelo()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFModelos.GetTodos(_marcas).ToArray()
      End If
      Return _listaModelos.ToArray()
   End Function

   Public Sub Inicializar(permiteSinSeleccion As Boolean)
      Inicializar(permiteSinSeleccion, True, True, {})
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean,
                          marca As Entidades.Marca)
      Inicializar(permiteSinSeleccion, seleccionMultiple, seleccionTodos, {marca})
   End Sub
   Public Function Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean,
                               marcas As Entidades.Marca()) As ComboBoxModelos
      _marcas = marcas
      _initialized = False
      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboModelos(Me, If(ConcatenarNombreMarca, "NombreMarcaModelo", "NombreModelo"), seleccionMultiple, seleccionTodos, _marcas)
      '_publicos.CargaComboModelos(Me, seleccionMultiple, seleccionTodos, _marcas)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaModelos.Clear()
      _listaModelos.Add(DirectCast(SelectedItem, Entidades.Modelo))

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
            Using filtromultiplecomprobantes As New MFModelos(_permiteSinSeleccion, ConcatenarNombreMarca)
               filtromultiplecomprobantes.Marcas = _marcas
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaModelos.Any() AndAlso _listaModelos(0).IdModelo = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFModelos.GetTodos(_marcas))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaModelos)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaModelos.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaModelos.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaModelos.Count = 1 Then
                     SelectedValue = _listaModelos(0).IdModelo
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaModelos.Clear()
                  _listaModelos.Add(DirectCast(SelectedItem, Entidades.Modelo))
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
      Return New CargaFiltroImpresionParams("Modelo", "Modelos")
   End Function

   <Obsolete()>
   Public Sub CargarFiltrosImpresionModelos(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, todosVacio:=False)
   End Sub
   <Obsolete()>
   Public Sub CargarFiltrosImpresionModelos(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String)
      CargaFiltroImpresion(filtro, muestraId, muestraNombre, prefijo, sufijo, todosVacio:=False)
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFModelos.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFModelos = New MFModelos(_permiteSinSeleccion, ConcatenarNombreMarca)
            frm.Marcas = _marcas
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaModelos.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaModelos.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub

End Class