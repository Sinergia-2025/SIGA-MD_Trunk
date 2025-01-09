Public Class ComboBoxEmpresas
   Inherits ComboBoxMultipleSeleccion

   Private _listaEmpresas As List(Of Entidades.Empresa)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean
   Private _idFuncion As String
   Private _defaultValue As Integer

   Public Sub New()
      MyBase.New()
      _listaEmpresas = New List(Of Entidades.Empresa)()
   End Sub

   Public Function GetEmpresas() As Entidades.Empresa()
      If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
         Return MFEmpresas.GetTodas(_idFuncion).ToArray()
      End If
      Return _listaEmpresas.ToArray()
   End Function

   Public Sub Initializar(idFuncion As String)
      Initializar(True, idFuncion)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, idFuncion As String)
      Initializar(permiteSinSeleccion, True, True, idFuncion, actual.Sucursal.IdEmpresa)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, idFuncion As String, defaultValue As Integer)
      Initializar(permiteSinSeleccion, True, True, idFuncion, defaultValue)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String)
      Initializar(permiteSinSeleccion, seleccionMultiple, seleccionTodos, idFuncion, actual.Sucursal.IdEmpresa)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String,
                          defaultValue As Integer)

      _defaultValue = defaultValue

      ctxMenu = New ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _idFuncion = idFuncion
      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboEmpresas(Me, seleccionMultiple, seleccionTodos, idFuncion)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaEmpresas.Clear()
      _listaEmpresas.Add(DirectCast(SelectedItem, Entidades.Empresa))

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
            Using filtromultiplecomprobantes As New MFEmpresas(_permiteSinSeleccion, _idFuncion)
               If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple) Then
                  If _listaEmpresas.Any() AndAlso _listaEmpresas(0).IdEmpresa = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
                     filtromultiplecomprobantes.Filtros.AddRange(MFEmpresas.GetTodas(_idFuncion))
                  Else
                     filtromultiplecomprobantes.Filtros.AddRange(_listaEmpresas)
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaEmpresas.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaEmpresas.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaEmpresas.Count = 1 Then
                     SelectedValue = _listaEmpresas(0).IdEmpresa
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaEmpresas.Clear()
                  _listaEmpresas.Add(DirectCast(SelectedItem, Entidades.Empresa))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
      RaiseEvent AfterSelectedIndexChanged(Me, Nothing)
   End Sub

   Public Event AfterSelectedIndexChanged(sender As Object, e As EventArgs)

   Public Sub CargarFiltrosImpresionEmpresas(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim Empresas As Entidades.Empresa() = GetEmpresas()
            Dim formatoEmpresa As String = String.Empty
            If muestraId And muestraNombre Then formatoEmpresa = "{0} - {1}"
            If muestraId And Not muestraNombre Then formatoEmpresa = "{0}"
            If Not muestraId And muestraNombre Then formatoEmpresa = "{1}"
            If Not muestraId And Not muestraNombre Then formatoEmpresa = ""
            If Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos) Then
               .AppendFormat("Empresas: {0}", Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
            Else
               If Empresas.Count = 1 Then
                  .AppendFormat("Empresa: ").AppendFormat(formatoEmpresa, Empresas(0).IdEmpresa, Empresas(0).NombreEmpresa)
               ElseIf Empresas.Count > 1 Then
                  .AppendFormat("Empresas: ")
                  Dim primera As Boolean = True
                  For Each suc As Entidades.Empresa In Empresas
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formatoEmpresa, suc.IdEmpresa, suc.NombreEmpresa)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFEmpresas.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFEmpresas = New MFEmpresas(_permiteSinSeleccion, _idFuncion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaEmpresas.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            _listaEmpresas.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class