Public Class PasajerosAyuda

#Region "Campos"

   Private _publicos As Publicos
   Private _pasajeros As List(Of Entidades.ReservaTurismoPasajero)
   Private _pasajerosSeleccionados As List(Of Entidades.Cliente)
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Propiedades"

   Public ReadOnly Property PasajerosSeleccionados() As List(Of Entidades.Cliente)
      Get
         Return _pasajerosSeleccionados
      End Get
   End Property

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _tit = GetColumnasVisiblesGrilla(ugPasajeros)
            _publicos = New Publicos()
            ugPasajeros.AgregarFiltroEnLinea({"NombreCliente", "NombreCategoria"})
            RefrescarDatosGrilla()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(Pasajeros As Entidades.ListConBorrados(Of Entidades.ReservaTurismoPasajero))
      Me.New()

      If _pasajerosSeleccionados Is Nothing Then
         _pasajerosSeleccionados = New List(Of Entidades.Cliente)
      End If
      _pasajeros = Pasajeros
   End Sub

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
#End Region

#Region "Eventos Botones"
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbZonaGeografica.Checked And Not bscCodigoZonaGeografica2.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó una Zona Geográfica aunque activó ese Filtro")
               bscCodigoZonaGeografica2.Focus()
               Exit Sub
            End If

            CargaGrillaDetalle()

            If ugPasajeros.Rows.Count > 0 Then
               btnConsultar.Select()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
               Exit Sub
            End If
         End Sub)
   End Sub
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
         Sub()
            ugPasajeros.UpdateData()
            Dim dt = DirectCast(ugPasajeros.DataSource, DataTable)

            Dim drSel = dt.Select("sel")

            If ValidarPreSeleccionados(drSel) Then
               AgregaPasajerosNuevos(drSel)

               DialogResult = DialogResult.OK
               Close()
            End If
         End Sub)
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = DialogResult.Cancel
      Close()
   End Sub
#End Region

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
         Sub()
            For Each dr As UltraGridRow In Me.ugPasajeros.Rows.GetFilteredInNonGroupByRows
               dr.Cells("Sel").Value = Me.chbTodos.Checked
            Next
         End Sub)
   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugPasajeros.ColapsarExpandir(expandir:=chkExpandAll.Checked))
   End Sub
   Private Sub dgvDetalle_DoubleClick(sender As Object, e As EventArgs)
      TryCatched(Sub() btnAceptar.PerformClick())
   End Sub

#Region "Eventos Busqueda Zona Geografica"
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(usaPermitido:=True, bscCodigoZonaGeografica2, bscNombreZonaGeografica2))
   End Sub
   Private Sub bscCodigoZonaGeografica2_BuscadorClick() Handles bscCodigoZonaGeografica2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaZonasGeograficas2(bscCodigoZonaGeografica2)
            bscCodigoZonaGeografica2.Datos = New Reglas.ZonasGeograficas().GetPorCodigo(bscCodigoZonaGeografica2.Text)
         End Sub)
   End Sub
   Private Sub bscNombreZonaGeografica2_BuscadorClick() Handles bscNombreZonaGeografica2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaZonasGeograficas2(bscNombreZonaGeografica2)
            bscNombreZonaGeografica2.Datos = New Reglas.ZonasGeograficas().GetPorNombre(bscNombreZonaGeografica2.Text)
         End Sub)
   End Sub
   Private Sub bscZonaGeografica2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoZonaGeografica2.BuscadorSeleccion, bscNombreZonaGeografica2.BuscadorSeleccion
      TryCatched(Sub() CargarZonaGeografica(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub txtNombrePasajero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombrePasajero.KeyDown
      TryCatched(Sub() If e.KeyCode = Keys.Enter Then btnConsultar.Select())
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()
      chbZonaGeografica.Checked = False
      txtNombrePasajero.Clear()
      chbTodos.Checked = False
      ugPasajeros.ClearFilas()
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim rPasajeros = New Reglas.Clientes()
      Dim dt = rPasajeros.GetAll(
                  New Entidades.Filtros.ClientesABMFiltros() With
                  {
                     .IdZonaGeografica = bscCodigoZonaGeografica2.Text,
                     .NombreCliente = txtNombrePasajero.Text,
                     .NombreClienteExacto = False
                  })

      dt.Columns.Add("Sel", GetType(Boolean))
      For Each dr As DataRow In dt.Rows
         dr("Sel") = False
      Next

      ugPasajeros.DataSource = dt

      AjustarColumnasGrilla(ugPasajeros, _tit)

      chbTodos.Checked = False

      tssRegistros.Text = ugPasajeros.CantidadRegistrosParaStatusbar

   End Sub
   Public Function ValidarPreSeleccionados(drSel As DataRow()) As Boolean
      Dim cantidadSeleccionados = drSel.Count
      Dim pasajerosEncontrados = New List(Of Entidades.ReservaTurismoPasajero)()

      For Each dr In drSel
         Dim dr1 = _pasajeros.FirstOrDefault(Function(dra) dra.IdClientePasajero = dr.Field(Of Long)("IdCliente"))
         If dr1 IsNot Nothing Then
            pasajerosEncontrados.Add(dr1)
         End If
      Next

      If pasajerosEncontrados.Count > 0 Then
         Dim stbMensaje = New StringBuilder()
         If pasajerosEncontrados.Count <= 5 Then
            stbMensaje.AppendFormatLine("Los siguientes pasajeros ya fueron seleccionados:")
         Else
            stbMensaje.AppendFormatLine("Hay {0} pasajeros que ya fueron seleccionados.", pasajerosEncontrados.Count)
            stbMensaje.AppendFormatLine("Algunos de ellos son:")
         End If

         pasajerosEncontrados.OrderBy(Function(dr) dr.NombrePasajero).Take(Math.Min(5, pasajerosEncontrados.Count)).
                  ToList().ForEach(Sub(dr) stbMensaje.AppendFormatLine("    {0}", dr.NombrePasajero))

         stbMensaje.AppendLine()

         stbMensaje.AppendFormatLine("¿Desea asociar los {0} pasajeron restantes?", cantidadSeleccionados - pasajerosEncontrados.Count)

         Return ShowPregunta(stbMensaje.ToString()) = DialogResult.Yes
      End If
      Return True
   End Function
   Public Sub AgregaPasajerosNuevos(drSel As DataRow())
      Dim rPasajero = New Reglas.Clientes()
      For Each dr In drSel
         If Not _pasajeros.Any(Function(dra) dra.IdClientePasajero = dr.Field(Of Long)("IdCliente")) Then
            Dim pasajero = rPasajero.GetUnoPorCodigo(dr.Field(Of Long)("CodigoCliente"))
            _pasajerosSeleccionados.Add(pasajero)
         End If
      Next
   End Sub
   Private Sub CargarZonaGeografica(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoZonaGeografica2.Text = dr.Cells(Entidades.ZonaGeografica.Columnas.IdZonaGeografica.ToString()).Value.ToString()
         bscNombreZonaGeografica2.Text = dr.Cells(Entidades.ZonaGeografica.Columnas.NombreZonaGeografica.ToString()).Value.ToString()

         bscCodigoZonaGeografica2.Selecciono = True
         bscNombreZonaGeografica2.Selecciono = True

         btnConsultar.Select()
      End If
   End Sub
#End Region

End Class