Public Class ModificarNumeracionVentas
   Implements IConParametros

   Private _reciboComparteNumeracionEntreSucursales As Boolean
   Private _tipoTipoComprobante As String

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _reciboComparteNumeracionEntreSucursales = Reglas.Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales

            ComparteEntreSucursales.Visible = _reciboComparteNumeracionEntreSucursales And _tipoTipoComprobante = "CTACTECLIE"
            Actualizar()
         End Sub)
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
         Sub()

            Dim oRegVN As Reglas.VentasNumeros = New Reglas.VentasNumeros()
            Dim oVN As Entidades.VentaNumero = New Entidades.VentaNumero()

            With oVN
               If _reciboComparteNumeracionEntreSucursales Then
                  .IdSucursal = Convert.ToInt32(IIf(chbComparteSucursal.Checked, 0, actual.Sucursal.Id))
               Else
                  .IdSucursal = actual.Sucursal.Id
               End If
               .IdEmpresa = actual.Sucursal.IdEmpresa
               .IdTipoComprobante = Me.dgvDatos.SelectedCells.Item(Me.dgvDatos.Columns("idTipoComprobante").Index).Value.ToString()
               .LetraFiscal = Me.dgvDatos.SelectedCells.Item(Me.dgvDatos.Columns("LetraFiscal").Index).Value.ToString()
               .CentroEmisor = Short.Parse(Me.dgvDatos.SelectedCells.Item(Me.dgvDatos.Columns("CentroEmisor").Index).Value.ToString())
               .Numero = Long.Parse(txtNroComprobante.Text)
               .Fecha = Me.dtpFecha.Value
               'GAR: 23/08/2017 Por el momento no permito tocarlo por sistema.
               '.IdTipoComprobanteRelacionado = Me.dgvDatos.SelectedCells.Item(Me.dgvDatos.Columns("IdTipoComprobanteRelacionado").Index).Value.ToString()
            End With

            oRegVN.ActualizarNumero2(oVN)

            MessageBox.Show("Ajuste Realizado Con EXITO !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         End Sub,
         onFinallyAction:=
         Sub(owner)
            Actualizar()
            SetEditarEnabled(False)
         End Sub)
   End Sub
   Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
      TryCatched(Sub() SetEditarEnabled(False))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub dgvDatos_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
      TryCatched(
         Sub()
            SetEditarEnabled(True)

            txtidTipoComprobante.Text = dgvDatos.SelectedRows(0).Cells("idTipoComprobante").Value.ToString()
            txtNroComprobante.Text = dgvDatos.SelectedRows(0).Cells("Numero").Value.ToString()
            dtpFecha.Value = Date.Parse(dgvDatos.SelectedRows(0).Cells("Fecha").Value.ToString())
            txtIdTipoComprobanteRelacionado.Text = dgvDatos.SelectedRows(0).Cells("IdTipoComprobanteRelacionado").Value.ToString()
            'Me.txtNroComprobante.Focus()

            chbComparteSucursal.Checked = CBool(dgvDatos.SelectedRows(0).Cells("ComparteEntreSucursales").Value.ToString())
            If _reciboComparteNumeracionEntreSucursales AndAlso
               Boolean.Parse(dgvDatos.SelectedRows(0).Cells("EsRecibo").Value.ToString()) Then
               chbComparteSucursal.Visible = True
            Else
               chbComparteSucursal.Visible = False
            End If
         End Sub)
   End Sub

   Private Sub Actualizar()
      'En caso de que no haya recibido el parámetro (por el motivo que sea) lo dejo funcionando como hasta ahora.
      If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "VENTAS"
      Dim rVentas = New Reglas.Ventas()
      dgvDatos.DataSource = rVentas.GetUltimosNumerosComprobantes(actual.Sucursal.Id, _tipoTipoComprobante, anularComprobantesSinEmitir:=False)
   End Sub
   Private Sub SetEditarEnabled(value As Boolean)
      tsbGrabar.Enabled = value
      tsbCancelar.Enabled = value
      grpEditar.Enabled = value
      dgvDatos.Enabled = Not (value)
      If value = False Then
         txtidTipoComprobante.Text = ""
         txtNroComprobante.Text = ""
         dtpFecha.Value = Now()
         Me.txtIdTipoComprobanteRelacionado.Text = ""
      End If
   End Sub

   Private Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el tipo de Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: CTACTECLIE")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

End Class