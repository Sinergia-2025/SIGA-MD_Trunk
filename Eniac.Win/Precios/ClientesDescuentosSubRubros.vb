Public Class ClientesDescuentosSubRubros

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         bscSubRubro.Permitido = False
         txtDescuento.Enabled = False

         bscCodigoCliente.Focus()

         ugDetalle.AgregarFiltroEnLinea({"NombreRubro", "NombreSubRubro"})
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
      ElseIf keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = (Keys.Control Or Keys.Add) Then
         btnInsertar.PerformClick()
      ElseIf keyData = (Keys.Control Or Keys.Subtract) Then
         btnEliminar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
      Sub()
         If ugDetalle.DataSource(Of DataTable).Any() And tsbGrabar.Enabled Then
            If ShowPregunta("¿Desea limpiar todos los datos ingresados") = Windows.Forms.DialogResult.Yes Then
               Refrescar()
            End If
         Else
            Refrescar()
         End If
      End Sub)
   End Sub
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
      Sub()
         Dim reg = New Reglas.ClientesDescuentosSubRubros()
         reg.GrabarClientesDescuentosSubRubros(Long.Parse(bscCodigoCliente.Tag.ToString()), ugDetalle.DataSource(Of DataTable))

         ShowMessage("Se actualizaron los datos correctamente.")
         Refrescar()
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Buscador Clientes"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, busquedaParcial:=True, soloActivos:=False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador SubRubros"
   Private Sub bscSubRubro_BuscadorClick() Handles bscSubRubro.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubRubros2(bscSubRubro)
         bscSubRubro.Datos = New Reglas.SubRubros().GetPorNombre(0I, bscSubRubro.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscSubRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscSubRubro.BuscadorSeleccion
      TryCatched(Sub() CargarDatosSubRubro(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub txtDescuento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuento.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
      Sub()
         If bscSubRubro.FilaDevuelta IsNot Nothing And txtDescuento.ValorNumericoPorDefecto(0D) <> 0D Then
            If ExisteSubRubro(Integer.Parse(txtNombreRubro.Tag.ToString()), Integer.Parse(bscSubRubro.FilaDevuelta.Cells("IdSubRubro").Value.ToString())) Then
               ShowMessage("Ya existe el subrubro.")
            Else
               tsbGrabar.Enabled = True
               AgregarSubRubro()
            End If
            txtNombreRubro.Tag = ""
            txtNombreRubro.Text = ""
            bscSubRubro.Text = ""
            txtDescuento.SetValor(0D)
            bscSubRubro.Focus()
         Else
            ShowMessage("El Descuento no puede ser 0")
         End If
      End Sub)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If ShowPregunta("¿Esta Seguro de Eliminar el Rubro Seleccionado?") = Windows.Forms.DialogResult.Yes Then
               tsbGrabar.Enabled = True
               EliminarLineaDescuentoRecargo()
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()
      tsbGrabar.Enabled = False
      bscCodigoCliente.Enabled = True
      bscCodigoCliente.Text = ""
      bscCliente.Enabled = True
      bscCliente.Text = ""
      txtNombreRubro.Tag = ""
      txtNombreRubro.Text = ""
      bscSubRubro.Text = ""
      txtDescuento.SetValor(0D)
      bscSubRubro.Permitido = False
      txtDescuento.Enabled = False
      ugDetalle.ClearFilas()
      bscCodigoCliente.Focus()
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Enabled = False
         bscCodigoCliente.Enabled = False
         bscSubRubro.Permitido = True
         txtDescuento.Enabled = True

         ugDetalle.DataSource = New Reglas.ClientesDescuentosSubRubros().GetClientesDescuentosSubRubros(Long.Parse(bscCodigoCliente.Tag.ToString()))
      End If
   End Sub

   Private Sub AgregarSubRubro()
      Dim dtDescuentos = ugDetalle.DataSource(Of DataTable)
      If dtDescuentos IsNot Nothing Then
         Dim idRubro = Integer.Parse(txtNombreRubro.Tag.ToString())
         Dim idSubRubro = Integer.Parse(bscSubRubro.Tag.ToString())

         If ExisteSubRubro(idRubro, idSubRubro) Then
            ShowMessage("El SubRubro seleccionado ya existe")
         Else
            Dim dr = dtDescuentos.NewRow()
            dr("IdCliente") = Long.Parse(bscCodigoCliente.Tag.ToString())
            dr("IdRubro") = idRubro
            dr("NombreRubro") = txtNombreRubro.Text
            dr("IdSubRubro") = idSubRubro
            dr("NombreSubRubro") = bscSubRubro.Text
            dr("DescuentoRecargo") = txtDescuento.Text

            dtDescuentos.Rows.Add(dr)
            ugDetalle.RowsRefresh(RefreshRow.ReloadData)
         End If
         bscSubRubro.Focus()
      End If
   End Sub
   Private Function ExisteSubRubro(idRubro As Integer, idSubRubro As Integer) As Boolean
      Return ugDetalle.DataSource(Of DataTable).
                  Any(Function(dr) dr.Field(Of Integer)("IdRubro") = idRubro And dr.Field(Of Integer)("IdSubRubro") = idSubRubro)
   End Function
   Private Sub EliminarLineaDescuentoRecargo()
      Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
      Dim dt = ugDetalle.DataSource(Of DataTable)
      If dr IsNot Nothing AndAlso dt IsNot Nothing Then
         dt.Rows.Remove(dr)
      End If
      ugDetalle.RowsRefresh(RefreshRow.ReloadData)
   End Sub

   Private Sub CargarDatosSubRubro(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         txtNombreRubro.Text = dr.Cells("NombreRubro").Value.ToString()
         txtNombreRubro.Tag = dr.Cells("IdRubro").Value.ToString()
         bscSubRubro.Text = dr.Cells("NombreSubRubro").Value.ToString()
         bscSubRubro.Tag = dr.Cells("IdSubRubro").Value.ToString()

         Dim idRubro = Integer.Parse(txtNombreRubro.Tag.ToString())
         Dim idSubRubro = Integer.Parse(bscSubRubro.Tag.ToString())
         If ExisteSubRubro(idRubro, idSubRubro) Then
            ShowMessage("El SubRubro seleccionado ya existe")
            bscSubRubro.Focus()
         Else
            txtDescuento.Focus()
         End If
      End If
   End Sub

#End Region

End Class