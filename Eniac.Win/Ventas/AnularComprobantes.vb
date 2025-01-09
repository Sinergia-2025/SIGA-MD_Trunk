Public Class AnularComprobantes

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _numeroComprobanteDesdeAnterior As Long = 0

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "VENTAS")
         cmbTiposComprobantes.SelectedIndex = -1
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(cmbAfectaCaja, GetType(Entidades.Publicos.SiNoTodos))

         With cboLetra
            .DisplayMember = "LetraFiscal"
            .ValueMember = "LetraFiscal"
            .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
            .SelectedIndex = -1
         End With

         With cmbEmisor
            .DisplayMember = "CentroEmisor"
            .ValueMember = "CentroEmisor"
            .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
            .SelectedIndex = -1
         End With

         RefrescarDatosGrilla()
         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "Observacion"})
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
         ugDetalle.AgregarTotalesSuma({"Subtotal", "TotalImpuestos", "ImporteTotal"})
      End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbAnular2_Click(sender As Object, e As EventArgs) Handles tsbAnular2.Click
      TryCatched(
      Sub()
         Dim entro = False

         ugDetalle.UpdateData()

         Dim dt = DirectCast(ugDetalle.DataSource, DataTable)
         If dt.Rows.Count = 0 Then
            ShowMessage("Consulta sin resultado de movimientos")
            Exit Sub
         End If

         If dt.Select("Selec").Length = 0 Then
            ShowMessage("No seleccionó ningún movimiento")
            Exit Sub
         End If
         'For Each dr As UltraGridRow In Me.ugDetalle.Rows
         '   If dr.Cells("Selec").Value IsNot Nothing Then
         '      If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then
         '         entro = True
         '         Exit For
         '      End If
         '   End If
         'Next

         'If Not entro Then
         '   MessageBox.Show("No seleccionó ningún movimiento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Exit Sub
         'End If

         'Me.Cursor = Cursors.WaitCursor

         Dim ctactes = New List(Of Entidades.CuentaCorriente)()
         Dim rFaturacion = New Reglas.Ventas()

         For Each dr As DataRow In dt.Select("Selec")
            'For Each dr As UltraGridRow In Me.ugDetalle.Rows
            'If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then

            Dim rVentas = New Reglas.Ventas()
            Dim rVinculados = New Reglas.VentasInvocados()
            'Dim oVenta As Entidades.Venta
            'oVenta = New Entidades.Venta()

            Dim oVenta = rVentas.GetUna(dr.Field(Of Integer)("IdSucursal"), dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                                        dr.Field(Of Integer)("CentroEmisor").ToShort(), dr.Field(Of Long)("NumeroComprobante"))
            oVenta.Usuario = actual.Nombre

            Dim comprobante = String.Format("{0} {1} {2:0000}-{3:00000000}", oVenta.IdTipoComprobante, oVenta.LetraComprobante, oVenta.CentroEmisor, oVenta.NumeroComprobante)

            If oVenta.Impresora.TipoImpresora = "FISCAL" Then
               'Si es ficticio (ejemplo CIERREZ), le pongo que puede ser borrado.
               If Not New Reglas.TiposComprobantes().GetUno(dr.Field(Of String)("IdTipoComprobante")).PuedeSerBorrado Then
                  ShowMessage(String.Format("ATENCION: El comprobante: {0} seleccionado es del tipo '{1}', NO podra Anularse.", comprobante, oVenta.Impresora.TipoImpresora))
                  Exit Sub
               End If
            End If

            If oVenta.IdEstadoComprobante = "FACTURADO" Then
               ShowMessage(String.Format("ATENCION: El comprobante: {0} se encuentra '{1}', NO podra anularse", comprobante, oVenta.IdEstadoComprobante))
               Exit Sub
            End If

            Dim invocadores = rVinculados.GetInvocadores(oVenta)
            If invocadores.Count > 0 Then
               ShowMessage(String.Format("ATENCION: El comprobante: {0} fue invocado por los comprobantes {1}, NO podra anularse", comprobante,
                                            String.Join(",", invocadores.ToList().ConvertAll(Function(v) String.Format("{0} {1} {2:0000}-{3:00000000}",
                                                                                                                       v.IdTipoComprobante, v.Letra,
                                                                                                                       v.CentroEmisor, v.NumeroComprobante)))))
               Exit Sub
            End If

            'solamente verifico esto si el tipo de comprobante es Electronico contra el AFIP
            If oVenta.TipoComprobante.EsElectronico Then
               If Not String.IsNullOrEmpty(oVenta.AFIPCAE.CAE) Then
                  ShowMessage(String.Format("ATENCION: El comprobante: {0} ya tiene Nro. de CAE '{1}', NO podra Anularse.", comprobante, oVenta.AFIPCAE.CAE))
                  Exit Sub
               End If

               'controle que el ultimo nro. del AFIP sea igual que el local, eso implica que
               'no importa si se transmitio o no los numeros estarian bien y dejaria anular los comprobantes
               If Not rVentas.EsCorrectoElUltimoNumeroDeAFIP(oVenta.IdSucursal, oVenta.TipoComprobante.IdTipoComprobante, oVenta.LetraComprobante, oVenta.CentroEmisor) Then
                  If oVenta.FechaTransmisionAFIP <> Nothing Then
                     ShowMessage(String.Format("ATENCION: El comprobante: {0} se transmitio al AFIP el '{0}', NO podra Anularse.", comprobante, oVenta.FechaTransmisionAFIP))
                     Exit Sub
                  End If
               End If
            End If

            rFaturacion.AnularComprobante(oVenta, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
            'End If
         Next

         ShowMessage("¡¡La anulación se realizo con éxito!!")

         btnConsultar.PerformClick()
      End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()

         If chbCliente.Checked And bscCodigoCliente.Text.Length = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         If chbLetra.Checked And cboLetra.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Letra aunque activó ese Filtro")
            cboLetra.Focus()
            Exit Sub
         End If

         If chbEmisor.Checked And cmbEmisor.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Centro Emisor aunque activó ese Filtro")
            cmbEmisor.Focus()
            Exit Sub
         End If

         If chbNumero.Checked And txtNumeroCompDesde.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO Informó un Numero Comprobante Desde aunque activó ese Filtro.")
            txtNumeroCompDesde.Focus()
            Exit Sub
         End If

         chbTodos.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub


#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta, True))
   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      TryCatched(Sub() chbLetra.FiltroCheckedChanged(cboLetra))
   End Sub

   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      TryCatched(Sub() chbEmisor.FiltroCheckedChanged(cmbEmisor))
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(
      Sub()
         txtNumeroCompDesde.Enabled = chbNumero.Checked
         txtNumeroCompHasta.Enabled = txtNumeroCompDesde.Enabled
         If Not chbNumero.Checked Then
            txtNumeroCompDesde.Text = String.Empty
            txtNumeroCompHasta.Text = String.Empty
         Else
            txtNumeroCompDesde.Focus()
         End If
      End Sub)
   End Sub

   Private Sub txtNumeroCompDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Enter
      TryCatched(Sub() _numeroComprobanteDesdeAnterior = txtNumeroCompDesde.ValorNumericoPorDefecto(0L))
   End Sub
   Private Sub txtNumeroCompDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Leave
      TryCatched(
      Sub()
         Dim desde = txtNumeroCompDesde.ValorNumericoPorDefecto(0L)
         Dim hasta = txtNumeroCompHasta.ValorNumericoPorDefecto(0L)
         Dim delta = desde - _numeroComprobanteDesdeAnterior
         txtNumeroCompHasta.Text = (hasta + delta).ToString()
      End Sub)
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub

#Region "Eventos Busqueda Clientes"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCodigoCliente)
         Dim rClientes = New Reglas.Clientes()
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = rClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      TryCatched(
      Sub()
         If e.FilaDevuelta IsNot Nothing Then
            CargarDatosCliente(e.FilaDevuelta)
            btnConsultar.Focus()
         End If
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim rClientes = New Reglas.Clientes()
         bscCliente.Datos = rClientes.GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      TryCatched(
      Sub()
         If e.FilaDevuelta IsNot Nothing Then
            CargarDatosCliente(e.FilaDevuelta)
            btnConsultar.Focus()
         End If
      End Sub)
   End Sub
#End Region

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
#End Region

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
         If dr IsNot Nothing Then
            If e.Cell.Column.Key = "Ver" Then
               Dim rVentas = New Reglas.Ventas()
               Dim venta = rVentas.GetUna(actual.Sucursal.Id,
                                             dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                                             dr.Field(Of Integer)("CentroEmisor").ToShort(), dr.Field(Of Long)("NumeroComprobante"))
               Dim oImpr = New Impresion(venta)
               If dr.Field(Of String)("TipoImpresora") = "NORMAL" Then
                  oImpr.ImprimirComprobanteNoFiscal(True)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If
            End If
         End If
      End Sub)
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
      Sub()
         If TypeOf (ugDetalle.DataSource) Is DataTable Then
            For Each dr As DataRow In DirectCast(ugDetalle.DataSource, DataTable).Rows
               dr("Selec") = chbTodos.Checked
            Next
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      bscCliente.Enabled = False
      bscCodigoCliente.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbCliente.Checked = False
      chbTipoComprobante.Checked = False
      chbVendedor.Checked = False
      chbEmisor.Checked = False
      chbLetra.Checked = False
      chbNumero.Checked = False
      cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbAfectaCaja.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      ugDetalle.ClearFilas()
      tssRegistros.Text = "0 Registros"
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idCliente = If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L)
      Dim idTipoComprobante = If(chbTipoComprobante.Checked, cmbTiposComprobantes.ValorSeleccionado(Of String), String.Empty)
      Dim letra = If(chbLetra.Checked, cboLetra.ValorSeleccionado(Of String), String.Empty)
      Dim idVendedor = If(chbVendedor.Checked, cmbVendedor.ValorSeleccionado(Of Integer), 0I)
      Dim nComprobanteDesde As Long? = Nothing
      If chbNumero.Checked Then nComprobanteDesde = txtNumeroCompDesde.ValorNumericoPorDefecto(0L)
      Dim nComprobanteHasta As Long? = Nothing
      If chbNumero.Checked Then nComprobanteHasta = txtNumeroCompHasta.ValorNumericoPorDefecto(0L)
      Dim emisor As Integer? = Nothing
      If chbEmisor.Checked Then emisor = cmbEmisor.ValorSeleccionado(Of Integer)

      Dim rVenta = New Reglas.Ventas()
      Dim dtDetalle = rVenta.GetPorRangoFechas(
                                 agregarSelec:=True, agregarVer:=True,
                                 {actual.Sucursal},
                                 dtpDesde.Value, dtpHasta.Value,
                                 idVendedor, Entidades.OrigenFK.Movimiento,
                                 cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                 idCliente,
                                 cmbAfectaCaja.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                 idTipoComprobante, numeroComprobante:=0, idFormasPago:=0, idUsuario:=String.Empty,
                                 idEstadoComprobante:="NO ANULADO", porcUtilidadDesde:=-1, porcUtilidadHasta:=-1,
                                 mercDespachada:="TODOS", comercial:="TODOS", idCategoria:=0, numeroReparto:=0, ctaCte:=False,
                                 exclurirComprobanteFiscal:=True, exclurirComprobanteElectronico:=True,
                                 letra, emisor, nComprobanteDesde, nComprobanteHasta)
      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub


#End Region

End Class