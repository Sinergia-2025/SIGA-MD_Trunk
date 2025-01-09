Public Class CalidadListasControlConfigAsig

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() CargaPantalla())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbGrabar.PerformClick()

      ElseIf keyData = (Keys.Add Or Keys.Control) Then
         btnAgregar.PerformClick()
      ElseIf keyData = (Keys.Subtract Or Keys.Control) Then
         btnQuitar.PerformClick()

      ElseIf keyData = (Keys.Up Or Keys.Control) Then
         btnSubir.PerformClick()
      ElseIf keyData = (Keys.Down Or Keys.Control) Then
         btnBajar.PerformClick()

      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() CargaPantalla())
   End Sub
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(Sub() Grabar())
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub cmbListasControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListasControl.SelectedIndexChanged
      TryCatched(Sub() CargarItemsListaControl())
   End Sub

#Region "Eventos Acciones"
   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      TryCatched(Sub() AgregarItems())
   End Sub
   Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
      TryCatched(Sub() EliminarItems())
   End Sub
   Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
      TryCatched(Sub() SubirItems())
   End Sub

   Private Sub btnBajar_Click(sender As Object, e As EventArgs) Handles btnBajar.Click
      TryCatched(Sub() BajarItems())
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub CargaPantalla()
      Dim lstItems = New Reglas.CalidadListasControlItems().GetTodos()
      ugItemsSistema.DataSource = lstItems

      FormatearGrillaItemsSistema()

      _publicos.CargaComboCalidadListasControl(cmbListasControl)
      cmbListasControl.SetSelectedIndexSecure(0I)

      EstadoCuandoSinEditar()

   End Sub
   Private Sub CargarItemsListaControl()

      Dim listaControl = cmbListasControl.ItemSeleccionado(Of Entidades.CalidadListaControl)
      If listaControl IsNot Nothing Then
         listaControl = New Reglas.CalidadListasControl().GetUno(listaControl.IdListaControl, cargaItems:=True)
         ugItemsListaControl.Tag = listaControl

         ugItemsListaControl.DataSource = listaControl.Items

         FormatearGrillaItemsListaControl()
      End If
   End Sub
   Private Sub Grabar()
      Dim listaControl = DirectCast(ugItemsListaControl.Tag, Entidades.CalidadListaControl)
      If listaControl IsNot Nothing Then
         Dim rConfig = New Reglas.CalidadListasControlConfig()
         rConfig.Actualizar(listaControl)
      End If

      ShowMessage("Los items han sido modificados en la lista de control!!")
      CargaPantalla()
   End Sub

   Protected Sub FormatearGrillaItemsSistema()

      With ugItemsSistema.DisplayLayout.Bands(0)
         ugItemsSistema.OcultaTodasLasColumnas()

         Dim pos = 0I
         .Columns(Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString()).FormatearColumna("Código", pos, 80, , True)
         .Columns(Entidades.CalidadListaControlItem.Columnas.NombreListaControlItem.ToString()).FormatearColumna("Nombre", pos, 250)

         .Columns(Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString()).FormatearColumna("Grupo", pos, 120)
         .Columns(Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString()).FormatearColumna("SubGrupo", pos, 120)
      End With

   End Sub
   Protected Sub FormatearGrillaItemsListaControl()
      With ugItemsListaControl.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         .Columns(Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString()).FormatearColumna("Código", pos, 80, , True)
         .Columns(Entidades.CalidadListaControlItem.Columnas.NombreListaControlItem.ToString()).FormatearColumna("Nombre", pos, 250)
         .Columns(Entidades.CalidadListaControlConfig.Columnas.Orden.ToString()).FormatearColumna("Orden", pos, 60, HAlign.Right)

         .Columns(Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString()).FormatearColumna("Grupo", pos, 120)
         .Columns(Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString()).FormatearColumna("SubGrupo", pos, 120)

         'Debo ordenar por Orden por defecto ya que, si no lo hago, al modificar el orden de las filas (por acción del usuario) no se ve el cambio de posición de las filas.
         'En caso de que el usuario lo cambie por decisión propia ya queda de esa manera, pero por defecto lo seteamos así
         If .SortedColumns.Count = 0 Then
            .SortedColumns.Add(Entidades.CalidadListaControlConfig.Columnas.Orden.ToString(), descending:=False)
         End If

      End With
   End Sub

   Private Sub AgregarItems()
      Dim items = ugItemsSistema.FilasSeleccionadas(Of Entidades.CalidadListaControlItem)
      If Not items.AnySecure() Then
         Throw New Exception("Debe seleccionar al menos un item de sistema")
      End If

      Dim listaControl = DirectCast(ugItemsListaControl.Tag, Entidades.CalidadListaControl)
      For Each i In items
         If Not listaControl.Items.Any(Function(c) c.IdListaControlItem = i.IdListaControlItem) Then
            Dim orden = listaControl.Items.MaxSecure(Function(c) c.Orden).IfNull()
            Dim config = New Entidades.CalidadListaControlConfig() With {.Item = i, .Orden = orden + 10}
            listaControl.Items.Add(config)
         End If
      Next
      ugItemsListaControl.RowsRefresh(RefreshRow.ReloadData)
      EstadoCuandoEmpiezaAEditar()
   End Sub
   Private Sub EliminarItems()
      Dim items = ugItemsListaControl.FilasSeleccionadas(Of Entidades.CalidadListaControlConfig)
      If Not items.AnySecure() Then
         Throw New Exception("Debe seleccionar al menos un item de la lista de control")
      End If

      Dim listaControl = DirectCast(ugItemsListaControl.Tag, Entidades.CalidadListaControl)
      For Each i In items
         listaControl.Items.Remove(i)
      Next
      ugItemsListaControl.RowsRefresh(RefreshRow.ReloadData)
      ReordenarItems()
      EstadoCuandoEmpiezaAEditar()
   End Sub

   Private Sub SubirItems()
      Dim items = ugItemsListaControl.FilasSeleccionadas(Of Entidades.CalidadListaControlConfig)
      If Not items.AnySecure() Then
         Throw New Exception("Debe seleccionar al menos un item de la lista de control")
      End If

      Dim minOrden = items.MinSecure(Function(i) i.Orden).IfNull(0)
      Dim maxOrden = items.MaxSecure(Function(i) i.Orden).IfNull(0)

      Dim listaControl = DirectCast(ugItemsListaControl.Tag, Entidades.CalidadListaControl)
      Dim anterior = listaControl.Items.Where(Function(i) i.Orden < minOrden).OrderBy(Function(i) i.Orden).LastOrDefault()
      If anterior IsNot Nothing Then
         anterior.Orden = maxOrden + 5
      End If
      ReordenarItems()
      EstadoCuandoEmpiezaAEditar()
   End Sub
   Private Sub BajarItems()
      Dim items = ugItemsListaControl.FilasSeleccionadas(Of Entidades.CalidadListaControlConfig)
      If Not items.AnySecure() Then
         Throw New Exception("Debe seleccionar al menos un item de la lista de control")
      End If

      Dim minOrden = items.MinSecure(Function(i) i.Orden).IfNull(0)
      Dim maxOrden = items.MaxSecure(Function(i) i.Orden).IfNull(0)

      Dim listaControl = DirectCast(ugItemsListaControl.Tag, Entidades.CalidadListaControl)
      Dim anterior = listaControl.Items.Where(Function(i) i.Orden > maxOrden).OrderBy(Function(i) i.Orden).FirstOrDefault()
      If anterior IsNot Nothing Then
         anterior.Orden = minOrden - 5
      End If
      ReordenarItems()
      EstadoCuandoEmpiezaAEditar()
   End Sub

   Private Sub ReordenarItems()
      Dim orden = 0I
      Dim listaControl = DirectCast(ugItemsListaControl.Tag, Entidades.CalidadListaControl)
      listaControl.Items.OrderBy(Function(i) i.Orden).ToList().ForEach(
         Sub(i)
            orden += 10
            i.Orden = orden
         End Sub)
      ugItemsListaControl.RowsRefresh(RefreshRow.ReloadData)
      ugItemsListaControl.DisplayLayout.Bands(0).SortedColumns.RefreshSort(regroupBy:=False)
   End Sub

   Private Sub EstadoCuandoEmpiezaAEditar()
      tsbGrabar.Enabled = True
      cmbListasControl.Enabled = False
   End Sub
   Private Sub EstadoCuandoSinEditar()
      tsbGrabar.Enabled = False
      cmbListasControl.Enabled = True
   End Sub

#End Region
End Class