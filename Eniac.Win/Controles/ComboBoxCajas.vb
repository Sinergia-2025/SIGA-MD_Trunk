Public Class ComboBoxCajas
   Inherits ComboBoxMultipleSeleccion

   Private _listaCajaNombres As List(Of Entidades.CajaNombre)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Private _blnMiraUsuario As Boolean
   Private _blnMiraPC As Boolean
   Private _blnCajasModificables As Boolean
   Public Property SucursalesSeleccionadas As Entidades.Sucursal()

   Public Sub New()
      MyBase.New()
      _listaCajaNombres = New List(Of Entidades.CajaNombre)()
   End Sub

   Public Function GetCajas() As Entidades.CajaNombre()
      Return GetCajas(False)
   End Function
   Public Function GetCajas(todosVacio As Boolean) As Entidades.CajaNombre()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         If todosVacio Then Return {}
         Return MFCajas.GetTodas(SucursalesSeleccionadas, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables).ToArray()
      End If
      Return _listaCajaNombres.ToArray()
   End Function

   Public Sub Inicializar(sucursales As Entidades.Sucursal(), blnMiraUsuario As Boolean, blnMiraPC As Boolean, blnCajasModificables As Boolean)
      Inicializar(sucursales, blnMiraUsuario, blnMiraPC, blnCajasModificables, True)
   End Sub
   Public Sub Inicializar(sucursales As Entidades.Sucursal(), blnMiraUsuario As Boolean, blnMiraPC As Boolean, blnCajasModificables As Boolean, permiteSinSeleccion As Boolean)
      Inicializar(sucursales, blnMiraUsuario, blnMiraPC, blnCajasModificables, permiteSinSeleccion, True, True)
   End Sub
   Public Sub Inicializar(sucursales As Entidades.Sucursal(), blnMiraUsuario As Boolean, blnMiraPC As Boolean, blnCajasModificables As Boolean, permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      _blnMiraUsuario = blnMiraUsuario
      _blnMiraPC = blnMiraPC
      _blnCajasModificables = blnCajasModificables
      SucursalesSeleccionadas = sucursales

      _initialized = False

      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboCajas(Me, SucursalesSeleccionadas, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaCajaNombres.Clear()
      _listaCajaNombres.Add(DirectCast(SelectedItem, Entidades.CajaNombre))

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
            Using filtromultiplecomprobantes As New MFCajas(_blnMiraUsuario, _blnMiraPC, _blnCajasModificables, _permiteSinSeleccion)
               filtromultiplecomprobantes.SucursalesSeleccionadas = SucursalesSeleccionadas
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaCajaNombres.Any() AndAlso _listaCajaNombres(0).IdCaja = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFCajas.GetTodas(SucursalesSeleccionadas, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaCajaNombres)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaCajaNombres.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaCajaNombres.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaCajaNombres.Count = 1 Then
                     SelectedValue = _listaCajaNombres(0).IdCaja
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaCajaNombres.Clear()
                  _listaCajaNombres.Add(DirectCast(SelectedItem, Entidades.CajaNombre))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Sub CargarFiltrosImpresionCajaNombres(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim CajaNombres As Entidades.CajaNombre() = GetCajas()
            Dim formatoCajaNombre As String = String.Empty
            If muestraId And muestraNombre Then formatoCajaNombre = "{0} - {1}"
            If muestraId And Not muestraNombre Then formatoCajaNombre = "{0}"
            If Not muestraId And muestraNombre Then formatoCajaNombre = "{1}"
            If Not muestraId And Not muestraNombre Then formatoCajaNombre = ""
            If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
               .AppendFormat("Cajas: {0}", Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
            Else
               If CajaNombres.Count = 1 Then
                  .AppendFormat("Caja: ").AppendFormat(formatoCajaNombre, CajaNombres(0).IdCaja, CajaNombres(0).NombreCaja)
               ElseIf CajaNombres.Count > 1 Then
                  .AppendFormat("Cajas: ")
                  Dim primera As Boolean = True
                  For Each suc As Entidades.CajaNombre In CajaNombres
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formatoCajaNombre, suc.IdCaja, suc.NombreCaja)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFCajas.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFCajas = New MFCajas(_blnMiraUsuario, _blnMiraPC, _blnCajasModificables, _permiteSinSeleccion)
            frm.SucursalesSeleccionadas = SucursalesSeleccionadas
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaCajaNombres.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaCajaNombres.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class