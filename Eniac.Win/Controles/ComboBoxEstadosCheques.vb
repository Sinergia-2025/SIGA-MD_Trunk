Public Class ComboBoxEstadosCheques
   Inherits ComboBoxMultipleSeleccion

   Private _listaEstadosCheques As List(Of Entidades.EstadoCheque)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Sub New()
      MyBase.New()
      _listaEstadosCheques = New List(Of Entidades.EstadoCheque)()
   End Sub

   Public Function GetEstados() As Entidades.EstadoCheque()
      Return GetEstados(False)
   End Function
   Public Function GetEstados(todosVacio As Boolean) As Entidades.EstadoCheque()
      If SelectedValue.ToString() = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFEstadosCheques.GetTodas().ToArray()
      End If
      Return _listaEstadosCheques.ToArray()
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
      _publicos.CargaComboEstadosCheques(Me, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaEstadosCheques.Clear()
      _listaEstadosCheques.Add(DirectCast(SelectedItem, Entidades.EstadoCheque))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Public Sub Refrescar()
      SelectedValue = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFEstadosCheques(_permiteSinSeleccion)
               If SelectedValue.ToString() = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaEstadosCheques.Any() AndAlso _listaEstadosCheques(0).IdEstadoCheque = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFEstadosCheques.GetTodas())
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaEstadosCheques)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaEstadosCheques.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaEstadosCheques.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaEstadosCheques.Count = 1 Then
                     SelectedValue = _listaEstadosCheques(0).IdEstadoCheque
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaEstadosCheques.Clear()
                  _listaEstadosCheques.Add(DirectCast(SelectedItem, Entidades.EstadoCheque))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Sub CargarFiltrosImpresionMarcas(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim Estados As Entidades.EstadoCheque() = GetEstados()
            Dim formatoMarca As String = String.Empty
            If muestraId And muestraNombre Then formatoMarca = "{0} - {1}"
            If muestraId And Not muestraNombre Then formatoMarca = "{0}"
            If Not muestraId And muestraNombre Then formatoMarca = "{1}"
            If Not muestraId And Not muestraNombre Then formatoMarca = ""
            If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
               .AppendFormat("Estados: {0}", Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
            Else
               If Estados.Count = 1 Then
                  .AppendFormat("Estado: ").AppendFormat(formatoMarca, Estados(0).IdEstadoCheque)
               ElseIf Estados.Count > 1 Then
                  .AppendFormat("Estado: ")
                  Dim primera As Boolean = True
                  For Each suc As Entidades.EstadoCheque In Estados
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formatoMarca, suc.IdEstadoCheque)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFEstadosCheques.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFEstadosCheques = New MFEstadosCheques(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaEstadosCheques.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaEstadosCheques.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class