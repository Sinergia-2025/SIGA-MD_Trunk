Public Class ComboBoxVendedores
   Inherits ComboBoxMultipleSeleccion

   Private _listaEmpleados As List(Of Entidades.Empleado)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Public Sub New()
      MyBase.New()
      _listaEmpleados = New List(Of Entidades.Empleado)()
   End Sub

   Public Function GetEmpleados() As Entidades.Empleado()
      Return GetEmpleados(False)
   End Function
   Public Function GetEmpleados(todosVacio As Boolean) As Entidades.Empleado()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFEmpleados.GetTodas().ToArray()
      End If
      Return _listaEmpleados.ToArray()
   End Function

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
      _publicos.CargaComboEmpleados(Me, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaEmpleados.Clear()
      _listaEmpleados.Add(DirectCast(SelectedItem, Entidades.Empleado))

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
            Using filtromultiplecomprobantes As New MFEmpleados(_permiteSinSeleccion)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaEmpleados.Any() AndAlso _listaEmpleados(0).IdEmpleado = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFEmpleados.GetTodas())
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaEmpleados)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaEmpleados.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaEmpleados.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaEmpleados.Count = 1 Then
                     SelectedValue = _listaEmpleados(0).IdEmpleado
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaEmpleados.Clear()
                  _listaEmpleados.Add(DirectCast(SelectedItem, Entidades.Empleado))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub
   Public Sub CargarFiltrosImpresionMarcas(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim Empleados = GetEmpleados()
            Dim formatoEmpleados As String = String.Empty
            If muestraId And muestraNombre Then formatoEmpleados = "{0} - {1}"
            If muestraId And Not muestraNombre Then formatoEmpleados = "{0}"
            If Not muestraId And muestraNombre Then formatoEmpleados = "{1}"
            If Not muestraId And Not muestraNombre Then formatoEmpleados = ""
            If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
               .AppendFormat("Empleados: {0}", Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
            Else
               If Empleados.Count = 1 Then
                  .AppendFormat("Empleado: ").AppendFormat(formatoEmpleados, Empleados(0).IdEmpleado, Empleados(0).NombreEmpleado)
               ElseIf Empleados.Count > 1 Then
                  .AppendFormat("Empleados: ")
                  Dim primera As Boolean = True
                  For Each suc As Entidades.Empleado In Empleados
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formatoEmpleados, suc.IdEmpleado, suc.NombreEmpleado)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub
   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFEmpleados.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm = New MFEmpleados(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaEmpleados.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaEmpleados.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class