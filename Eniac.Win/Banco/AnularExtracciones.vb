Public Class AnularExtracciones

#Region "Constantes"
   Private Const funcionActual As String = "AnularExtracciones"
#End Region

#Region "Campos"

   Private _publicos As Publicos
   Private _puedeAnularComprobantes As Boolean
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = True
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()
            _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
            ugDetalle.AgregarFiltroEnLinea({"NombreCuenta", "Observacion"})
            ugDetalle.AgregarTotalesSuma({"ImportePesos", "ImporteDolares", "ImporteTickets", "ImporteTarjetas", "ImporteCheques", "ImporteTotal"})

            _tit = GetColumnasVisiblesGrilla(ugDetalle)

         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            RefrescarDatosGrilla()
            tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbCuentaBancaria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCuentaBancaria.CheckedChanged
      TryCatched(
         Sub()
            bscCuentaBancaria.Enabled = chbCuentaBancaria.Checked
            If Not chbCuentaBancaria.Checked Then
               bscCuentaBancaria.Text = String.Empty
            Else
               bscCuentaBancaria.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancaria.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancaria)
            Dim rCBancarias = New Reglas.CuentasBancarias()
            bscCuentaBancaria.Datos = rCBancarias.GetFiltradoPorNombre(bscCuentaBancaria.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancaria.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not bscCuentaBancaria.FilaDevuelta Is Nothing Then
               bscCuentaBancaria.Text = bscCuentaBancaria.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCuentaBancaria.Enabled = False
            End If
         End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCuentaBancaria.Checked And Not bscCuentaBancaria.Selecciono Then
               MessageBox.Show("ATENCION: NO seleccionó una Cuenta Bancaria aunque activó ese Filtro.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               bscCuentaBancaria.Focus()
               Exit Sub
            End If

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         End Sub)
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               Dim rExtracciones = New Reglas.Depositos()
               Dim extraccion = rExtracciones.GetUna(actual.Sucursal.Id, dr.Field(Of Long)("NumeroDeposito"), "EXTRACCION")
               Dim di = New ExtraccionesImprimir()
               di.ImprimirExtraccion(extraccion)
            End If
         End Sub)
   End Sub

   Private Sub tsbAnular_Click(sender As Object, e As EventArgs) Handles tsbAnular.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub
            ugDetalle.UpdateData()

            Dim tablaAnular = DirectCast(ugDetalle.DataSource, DataTable).Clone

            For Each fila As UltraGridRow In ugDetalle.Rows
               If Boolean.Parse(fila.Cells("anula").Value.ToString) Then

                  If Integer.Parse(fila.Cells("IdCaja").Value.ToString()) <> Integer.Parse(Me.cmbCajas.SelectedValue.ToString()) And Decimal.Parse(fila.Cells("ImportePesos").Value.ToString()) = Decimal.Parse(fila.Cells("ImporteTotal").Value.ToString()) Then
                     If MessageBox.Show("ATENCION: La Extracción " & fila.Cells("NumeroDeposito").Value.ToString & " tiene una Caja distinta, esta seguro de aplicarlo a otra caja?!!", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                     End If
                  End If

                  Dim dr As DataRow = tablaAnular.NewRow
                  dr("NumeroDeposito") = fila.Cells("NumeroDeposito").Value
                  tablaAnular.Rows.Add(dr)

               End If
            Next

            If tablaAnular.Rows.Count = 0 Then
               MessageBox.Show("ATENCION: NO Seleccionó ninguna Extracción para Anular!!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            End If

            Dim rExtracciones = New Reglas.Depositos()
            rExtracciones.AnularDepositos(tablaAnular, Integer.Parse(cmbCajas.SelectedValue.ToString()), "EXTRACCION")

            MessageBox.Show("¡¡¡ Extracción/s Anulada/s Exitosamente !!!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            btnConsultar.PerformClick()
         End Sub)
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
         Sub()
            For Each dr As UltraGridRow In ugDetalle.Rows
               dr.Cells("Anula").Value = chbTodos.Checked
            Next
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now

      chbCuentaBancaria.Checked = False

      ugDetalle.ClearFilas()

      _publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
      cmbCajas.Enabled = True

      dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oExtraccion = New Reglas.Depositos()
      Dim idCuentaBancaria = 0I

      If bscCuentaBancaria.Selecciono Then
         idCuentaBancaria = Integer.Parse(bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString())
      End If

      Dim idEstado = "NORMAL"
      Dim dtDetalle = oExtraccion.GetPorRangoFechas(actual.Sucursal.Id,
                                                    dtpDesde.Value, dtpHasta.Value,
                                                    idCuentaBancaria,
                                                    idEstado, cmbCajas.ValorSeleccionado(Of Integer)(),
                                                    "EXTRACCION")

      dtDetalle.Columns.Add("anula", GetType(Boolean))
      dtDetalle.Columns.Add("Ver", GetType(String))
      dtDetalle.Select().All(
         Function(dr)
            dr.SetField("anula", "false")
            dr.SetField("Ver", "...")
            Return True
         End Function)

      ugDetalle.DataSource = dtDetalle

      FormatearGrilla()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub FormatearGrilla()
      With ugDetalle.DisplayLayout.Bands(0)
         For Each col In .Columns
            col.CellActivation = Activation.NoEdit
         Next
         .Columns("anula").CellActivation = Activation.AllowEdit
      End With

      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

#End Region

End Class