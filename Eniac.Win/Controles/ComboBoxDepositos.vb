Public Class ComboBoxDepositos
   Inherits ComboBoxMultipleSeleccion

   Private _listaDepositos As List(Of Entidades.SucursalDeposito)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean
   Private _sucursales As Entidades.Sucursal()

   Public Event AfterSelectedIndexChanged As EventHandler

   Public Sub New()
      MyBase.New()
      _listaDepositos = New List(Of Entidades.SucursalDeposito)()
   End Sub

   Public Function GetDepositos() As Entidades.SucursalDeposito()
      Return GetDepositos(False)
   End Function
   Public Function GetDepositos(todosVacio As Boolean) As Entidades.SucursalDeposito()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Dim result = MFDepositos.GetTodos(_sucursales)
         result.Add(New Entidades.SucursalDeposito() With {.IdSucursal = -1, .IdDeposito = -1})
         Return result.ToArray()
      End If
      Return _listaDepositos.ToArray()
   End Function

   Public Sub Inicializar()
      Inicializar(True)
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean)
      Inicializar(permiteSinSeleccion, True, True, {})
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean,
                          sucursal As Entidades.Sucursal)
      Inicializar(permiteSinSeleccion, seleccionMultiple, seleccionTodos, {sucursal})
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, sucursales As Entidades.Sucursal())

      _sucursales = sucursales
      _initialized = False

      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboDepositos(Me, seleccionMultiple, seleccionTodos, _sucursales)
      Refrescar()

      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaDepositos.Clear()
      _listaDepositos.Add(DirectCast(SelectedItem, Entidades.SucursalDeposito))

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
            Using filtromultiplecomprobantes As New MFDepositos(_permiteSinSeleccion)
               filtromultiplecomprobantes.Sucursales = _sucursales
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaDepositos.Any() AndAlso _listaDepositos(0).IdSucursal = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFDepositos.GetTodos(_sucursales))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaDepositos)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaDepositos.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaDepositos.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaDepositos.Count = 1 Then
                     SelectedValue = _listaDepositos(0).IdSucursal
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaDepositos.Clear()
                  _listaDepositos.Add(DirectCast(SelectedItem, Entidades.SucursalDeposito))
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

   Public Sub CargarFiltrosImpresionDepositos(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim Depositos = GetDepositos()
            Dim formatoDeposito = String.Empty
            If muestraId And muestraNombre Then formatoDeposito = "{0} - {1}"
            If muestraId And Not muestraNombre Then formatoDeposito = "{0}"
            If Not muestraId And muestraNombre Then formatoDeposito = "{1}"
            If Not muestraId And Not muestraNombre Then formatoDeposito = ""
            If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
               .AppendFormat("Depositos: {0}", Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
            Else
               If Depositos.Count = 1 Then
                  .AppendFormat("Deposito: ").AppendFormat(formatoDeposito, Depositos(0).IdDeposito, Depositos(0).NombreDeposito)
               ElseIf Depositos.Count > 1 Then
                  .AppendFormat("Depositos: ")
                  Dim primera As Boolean = True
                  For Each suc In Depositos
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formatoDeposito, suc.IdDeposito, suc.NombreDeposito)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFRubros.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm = New MFDepositos(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaDepositos.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaDepositos.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class