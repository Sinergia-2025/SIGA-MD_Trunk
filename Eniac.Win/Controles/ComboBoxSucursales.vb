Public Class ComboBoxSucursales
   Inherits ComboBoxMultipleSeleccion

   Private _listaSucursales As List(Of Entidades.Sucursal)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean
   Private _idFuncion As String
   Private _defaultValue As Integer
   Private _idEmpresa As Integer?

   Public Sub New()
      MyBase.New()
      _listaSucursales = New List(Of Entidades.Sucursal)()
   End Sub

   Public Function GetSucursales() As Entidades.Sucursal()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         Return MFSucursales.GetTodas(_idFuncion, _idEmpresa).ToArray()
      End If
      Return _listaSucursales.ToArray()
   End Function

   Public Sub Initializar(idFuncion As String)
      Initializar(True, idFuncion)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, idFuncion As String)
      Initializar(permiteSinSeleccion, True, True, idFuncion, actual.Sucursal.IdSucursal)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, idFuncion As String, defaultValue As Integer)
      Initializar(permiteSinSeleccion, True, True, idFuncion, defaultValue)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String)
      Initializar(permiteSinSeleccion, seleccionMultiple, seleccionTodos, idFuncion, actual.Sucursal.IdSucursal)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String,
                          defaultValue As Integer)
      Initializar(idEmpresa:=Nothing, permiteSinSeleccion, seleccionMultiple, seleccionTodos, idFuncion, defaultValue)
   End Sub
   Public Sub Initializar(idEmpresa As Integer?, permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String,
                          defaultValue As Integer)

      _defaultValue = defaultValue

      ctxMenu = New ContextMenuStrip(components) With {
         .Name = "ctxMenu",
         .Text = "Filtros guardados"
      }

      _idFuncion = idFuncion
      _idEmpresa = idEmpresa
      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboSucursales(Me, _idEmpresa, seleccionMultiple, seleccionTodos, idFuncion)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaSucursales.Clear()
      _listaSucursales.Add(DirectCast(SelectedItem, Entidades.Sucursal))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Public Sub Refrescar()
      SelectedValue = _defaultValue
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFSucursales(_permiteSinSeleccion, _idFuncion, _idEmpresa)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaSucursales(0).IdSucursal = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFSucursales.GetTodas(_idFuncion, _idEmpresa))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaSucursales)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaSucursales.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaSucursales.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaSucursales.Count = 1 Then
                     SelectedValue = _listaSucursales(0).Id
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaSucursales.Clear()
                  _listaSucursales.Add(DirectCast(SelectedItem, Entidades.Sucursal))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
      RaiseEvent AfterSelectedIndexChanged(Me, Nothing)
   End Sub

   Public Event AfterSelectedIndexChanged(sender As Object, e As EventArgs)

   Public Sub CargarFiltrosImpresionSucursales(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      CargarFiltrosImpresionSucursales(filtro, muestraId, muestraNombre, String.Empty, String.Empty)
   End Sub
   Public Sub CargarFiltrosImpresionSucursales(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String)
      CargarFiltrosImpresionSucursales(filtro, muestraId, muestraNombre, nombreSingularFiltro:="Sucursal", nombrePluralFiltro:="Sucursales", prefijo, sufijo)
   End Sub
   Public Sub CargarFiltrosImpresionSucursales(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, nombreSingularFiltro As String, nombrePluralFiltro As String, prefijo As String, sufijo As String)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim sucursales As Entidades.Sucursal() = GetSucursales()
            Dim formatoSucursal As String = String.Empty
            If muestraId And muestraNombre Then formatoSucursal = "{0} - {1}"
            If muestraId And Not muestraNombre Then formatoSucursal = "{0}"
            If Not muestraId And muestraNombre Then formatoSucursal = "{1}"
            If Not muestraId And Not muestraNombre Then formatoSucursal = ""
            .Append(prefijo)
            If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
               .AppendFormat("{0}: {1}", nombrePluralFiltro, Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
            Else
               If sucursales.Count = 1 Then
                  .AppendFormat("{0}: ", nombreSingularFiltro).AppendFormat(formatoSucursal, sucursales(0).IdSucursal, sucursales(0).Nombre)
               ElseIf sucursales.Count > 1 Then
                  .AppendFormat("{0}: ", nombrePluralFiltro)
                  Dim primera As Boolean = True
                  For Each suc In sucursales
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formatoSucursal, suc.IdSucursal, suc.Nombre)
                     primera = False
                  Next
               End If
            End If
            .Append(sufijo)
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFSucursales.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFSucursales = New MFSucursales(_permiteSinSeleccion, _idFuncion, _idEmpresa)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaSucursales.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaSucursales.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class