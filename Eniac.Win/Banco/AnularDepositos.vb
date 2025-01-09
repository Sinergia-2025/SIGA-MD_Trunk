Public Class AnularDepositos
   Implements IConParametros

#Region "Constantes"
   Private Const funcionActual As String = "AnularDepositos"
#End Region

#Region "Campos"

   Private _publicos As Publicos
   Private _tipoComprobante As String
   Private _puedeAnularComprobantes As Boolean
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()
         _publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

         '# Seteo el tipo de comprobante según la pantalla
         If Not Me._tipoComprobante = "LIQUIDATARJETA" Then
            _tipoComprobante = "DEPOSITO"
         Else
            Me.Text = "Anular Liquidaciones"
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarDepositos_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbCuentaBancaria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCuentaBancaria.CheckedChanged
      Try
         Me.bscCuentaBancaria.Enabled = Me.chbCuentaBancaria.Checked

         If Not Me.chbCuentaBancaria.Checked Then
            Me.bscCuentaBancaria.Text = ""
         Else
            Me.bscCuentaBancaria.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancaria.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias2(Me.bscCuentaBancaria)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancaria.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancaria.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancaria.BuscadorSeleccion

      Try

         If Not Me.bscCuentaBancaria.FilaDevuelta Is Nothing Then
            Me.bscCuentaBancaria.Text = Me.bscCuentaBancaria.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCuentaBancaria.Enabled = False
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCuentaBancaria.Checked And Not Me.bscCuentaBancaria.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó una Cuenta Bancaria aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCuentaBancaria.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton

      If e.Cell.Column.Index = 0 And e.Cell.Row.Index <> -1 Then

         Try

            Me.Cursor = Cursors.WaitCursor

            Dim oDepositos As Reglas.Depositos = New Reglas.Depositos()

            Dim Deposito As Entidades.Deposito

            Deposito = oDepositos.GetUna(actual.Sucursal.Id,
                                         Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroDeposito").Value.ToString()),
                                         _tipoComprobante)

            Dim di As DepositosImprimir = New DepositosImprimir()

            di.ImprimirDeposito(Deposito)

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

   Private Sub ugDetalle_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugDetalle.ClickCell
      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
   End Sub

   Private Sub tsbAnular_Click(sender As Object, e As EventArgs) Handles tsbAnular.Click

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.ugDetalle.UpdateData()

         Dim tablaAnular As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable).Clone

         For Each fila As UltraGridRow In Me.ugDetalle.Rows
            If Boolean.Parse(fila.Cells("anula").Value.ToString) Then

               If Integer.Parse(fila.Cells("IdCaja").Value.ToString()) <> Integer.Parse(Me.cmbCajas.SelectedValue.ToString()) And Decimal.Parse(fila.Cells("ImportePesos").Value.ToString()) = Decimal.Parse(fila.Cells("ImporteTotal").Value.ToString()) Then
                  If MessageBox.Show("ATENCION: El Depósito " & fila.Cells("NumeroDeposito").Value.ToString & " tiene una Caja distinta, esta seguro de aplicarlo a otra caja?!!", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                     Exit Sub
                  End If
               End If

               Dim dr As DataRow = tablaAnular.NewRow
               dr("NumeroDeposito") = fila.Cells("NumeroDeposito").Value
               tablaAnular.Rows.Add(dr)

            End If
         Next

         If tablaAnular.Rows.Count = 0 Then
            MessageBox.Show("ATENCION: NO Seleccionó ningún Depósito para Anular!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
         End If

         Dim oDepositos As Reglas.Depositos = New Reglas.Depositos

         oDepositos.AnularDepositos(tablaAnular, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), _tipoComprobante)

         MessageBox.Show("¡¡¡ Depósito/s Anulado/s Exitosamente !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub


#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      Me.chbCuentaBancaria.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      _publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
      Me.cmbCajas.Enabled = True

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oDeposito As Reglas.Depositos = New Reglas.Depositos()

      Try

         Dim IdCuentaBancaria As Integer = 0

         If Me.bscCuentaBancaria.Selecciono Then
            IdCuentaBancaria = Integer.Parse(Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString())
         End If
         Dim IdEstado As String = "NORMAL"

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oDeposito.GetPorRangoFechas(actual.Sucursal.Id,
                                                 Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                 IdCuentaBancaria,
                                                 IdEstado, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()),
                                                 _tipoComprobante)

         dt = Me.CrearDT()


         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("Ver") = "..."

            drCl("NumeroDeposito") = Long.Parse(dr("NumeroDeposito").ToString())
            drCl("NombreCuenta") = dr("NombreCuenta").ToString()
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("FechaAplicado") = Date.Parse(dr("FechaAplicado").ToString())
            drCl("ImportePesos") = Decimal.Parse(dr("ImportePesos").ToString())
            drCl("ImporteDolares") = Decimal.Parse(dr("ImporteDolares").ToString())
            drCl("ImporteTickets") = Decimal.Parse(dr("ImporteTickets").ToString())
            drCl("ImporteTarjetas") = Decimal.Parse(dr("ImporteTarjetas").ToString())
            drCl("ImporteCheques") = Decimal.Parse(dr("ImporteCheques").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("UsoFechaCheque") = Boolean.Parse(dr("UsoFechaCheque").ToString())
            drCl("Observacion") = dr("Observacion").ToString()
            drCl("IdCaja") = dr("IdCaja").ToString()

            dt.Rows.Add(drCl)

         Next

         Me.ugDetalle.DataSource = dt

         Me.FormatearGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub FormatearGrilla()
      With Me.ugDetalle.DisplayLayout.Bands(0)
         .Columns("Ver").CellActivation = Activation.NoEdit
         .Columns("NumeroDeposito").CellActivation = Activation.NoEdit
         .Columns("NombreCuenta").CellActivation = Activation.NoEdit
         .Columns("Fecha").CellActivation = Activation.NoEdit
         .Columns("FechaAplicado").CellActivation = Activation.NoEdit
         .Columns("ImportePesos").CellActivation = Activation.NoEdit
         .Columns("ImporteDolares").CellActivation = Activation.NoEdit
         .Columns("ImporteTickets").CellActivation = Activation.NoEdit
         .Columns("ImporteTarjetas").CellActivation = Activation.NoEdit
         .Columns("ImporteCheques").CellActivation = Activation.NoEdit
         .Columns("ImporteTotal").CellActivation = Activation.NoEdit
         .Columns("UsoFechaCheque").CellActivation = Activation.NoEdit
         .Columns("Observacion").CellActivation = Activation.NoEdit
         .Columns("IdCaja").CellActivation = Activation.NoEdit
      End With
   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         '.Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroDeposito", System.Type.GetType("System.Int64"))
         '.Columns.Add("IdCuentaBancaria", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreCuenta", System.Type.GetType("System.String"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("FechaAplicado", System.Type.GetType("System.DateTime"))
         .Columns.Add("ImportePesos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteDolares", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTickets", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTarjetas", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteCheques", System.Type.GetType("System.Decimal"))
         '.Columns.Add("ImporteEuros", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("UsoFechaCheque", System.Type.GetType("System.Boolean"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("IdCaja", System.Type.GetType("System.Int32"))
      End With

      Return dtTemp

   End Function

#End Region

#Region "Métodos Públicos"

   '# Implemento la I para setear el tipo de comprobante, en caso que venga de la funcion Liquidaciones de Tarjetas
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoComprobante = parametros
   End Sub

   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: LIQUIDATARJETA")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

#End Region

End Class