Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Public Class CtaCteModificarComprobanteAplicado

#Region "Campos"
   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private drCtaCte As DataRow
   Private _tit As Dictionary(Of String, String)
   Private _numeroComprobanteDesdeAnterior As Long = 0
#End Region


#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal dr As DataRow)
      Me.New()
      drCtaCte = dr
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me._publicos = New Publicos()
      Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "TODOS")
      Me.cmbTiposComprobantes.SelectedIndex = -1

      If drCtaCte IsNot Nothing Then
         CargarDatosCliente(drCtaCte)
      End If
      With Me.cboLetra
         .DisplayMember = "LetraFiscal"
         .ValueMember = "LetraFiscal"
         .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
         .SelectedIndex = -1
      End With

      With Me.cmbEmisor
         .DisplayMember = "CentroEmisor"
         .ValueMember = "CentroEmisor"
         .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
         .SelectedIndex = -1
      End With

      ugDetalle.AgregarFiltroEnLinea({""})
   End Sub

#End Region

#Region "Eventos"



   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Dim drCC As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
      If drCC IsNot Nothing Then
         Dim CCP As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos()
         CCP.ActualizaComprobantes(Integer.Parse(drCtaCte("IdSucursal").ToString()),
                                                drCtaCte("idTipoComprobante").ToString(),
                                                drCtaCte("Letra").ToString(),
                                                Short.Parse(drCtaCte("CentroEmisor").ToString()),
                                                Integer.Parse(drCtaCte("numeroComprobante").ToString()),
                                                Integer.Parse(drCtaCte("CuotaNumero").ToString()),
                                                drCC("idTipoComprobante").ToString(),
                                                Integer.Parse(drCC("numeroComprobante").ToString()),
                                                Integer.Parse(drCC("CentroEmisor").ToString()),
                                                Integer.Parse(drCC("CuotaNumero").ToString()),
                                                drCC("Letra").ToString())
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      End If
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataRow)

      Me.bscCliente.Text = dr("NombreCliente").ToString()
      Me.bscCodigoCliente.Text = dr("CodigoCliente").ToString()
      Me.bscCodigoCliente.Tag = dr("IdCliente").ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
      Me.txtImporteCuota.Text = dr("ImporteCuota").ToString()
      Me.chbTipoComprobante.Checked = True
      Me.cmbTiposComprobantes.SelectedValue = dr("IdTipoComprobante2").ToString()
   End Sub
#End Region

#Region "Metodos"


#End Region



   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      Try

         If Me.chbFechas.Checked And Me.dtpDesde.Value.Date > Me.dtpHasta.Value.Date Then
            MessageBox.Show("ATENCION: La fecha 'Desde' NO puede ser mayor la la fecha 'Hasta'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If
         If Me.chbNumero.Checked And (Long.Parse("0" & Me.txtNumeroCompDesde.Text) = 0) Then
            MessageBox.Show("ATENCION: NO Informó un Numero Comprobante Desde aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtNumeroCompDesde.Focus()
            Exit Sub
         End If
         If Me.chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registro/s"
            Me.btnBuscar.Focus()
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
   Private Sub CargaGrillaDetalle()
      Try
         Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
         Dim dtDetalle As DataTable

         Dim desde As Date? = Nothing
         Dim hasta As Date? = Nothing
         Dim importeTotal As Decimal = 0
         Dim idCliente As Long = 0
         Dim idTipoComprobante As String = String.Empty
         Dim idSucursal As Integer = 0

         Dim Letra As String = ""
         Dim emisor As Integer = 0
         Dim NumeroComprobanteDesde As Long = 0
         Dim NumeroComprobanteHasta As Long = 0

         If Me.chbFechas.Checked Then
            desde = Me.dtpDesde.Value
            hasta = Me.dtpHasta.Value
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            idTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         If Me.chkImporteCuota.Checked Then
            importeTotal = Decimal.Parse(Me.txtImporteCuota.Text)
         End If
         idSucursal = Integer.Parse(drCtaCte("IdSucursal").ToString())

         If Me.chbNumero.Checked Then
            NumeroComprobanteDesde = Long.Parse(Me.txtNumeroCompDesde.Text)
            NumeroComprobanteHasta = Long.Parse(Me.txtNumeroCompHasta.Text)
         End If

         If Me.cboLetra.Enabled Then
            Letra = Me.cboLetra.SelectedValue.ToString()
         End If

         If Me.cmbEmisor.Enabled Then
            emisor = Integer.Parse(Me.cmbEmisor.SelectedValue.ToString())
         End If

         dtDetalle = oCtaCte.GetPorClienteImporte(idSucursal,
                                                  desde,
                                                  hasta,
                                                  idTipoComprobante,
                                                  importeTotal,
                                                  idCliente,
                                                  optConSaldo.Checked,
                                                  NumeroComprobanteDesde,
                                                  NumeroComprobanteHasta,
                                                  Letra,
                                                  emisor)

         ugDetalle.DataSource = dtDetalle
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chkImporteTotal_CheckedChanged(sender As Object, e As EventArgs) Handles chkImporteCuota.CheckedChanged
      Me.txtImporteCuota.Enabled = Me.chkImporteCuota.Checked
   End Sub

   Private Sub chbFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechas.CheckedChanged

      Me.dtpDesde.Enabled = Me.chbFechas.Checked
      Me.dtpHasta.Enabled = Me.chbFechas.Checked

      If Me.chbFechas.Checked Then
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now
      End If

      Me.dtpDesde.Focus()
   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

      If Not Me.chbTipoComprobante.Checked Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      Else
         If Me.cmbTiposComprobantes.Items.Count > 0 Then
            Me.cmbTiposComprobantes.SelectedIndex = 0
         End If
      End If

      Me.cmbTiposComprobantes.Focus()

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

   Private Sub RefrescarDatosGrilla()

      Me.dtpDesde.Value = DateTime.Today
      Me.dtpHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbTipoComprobante.Checked = False


      Me.chbNumero.Checked = False
      Me.chbLetra.Checked = False
      Me.chbEmisor.Checked = False


      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      Me.cboLetra.Enabled = Me.chbLetra.Checked
      If Not Me.chbLetra.Checked Then
         Me.cboLetra.SelectedIndex = -1
      Else
         If Me.cboLetra.Items.Count > 0 Then
            Me.cboLetra.SelectedIndex = 0
         End If
      End If
      Me.cboLetra.Focus()

   End Sub

   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      Me.cmbEmisor.Enabled = Me.chbEmisor.Checked
      If Not Me.chbEmisor.Checked Then
         Me.cmbEmisor.SelectedIndex = -1
      Else
         If Me.cmbEmisor.Items.Count > 0 Then
            Me.cmbEmisor.SelectedIndex = 0
         End If
      End If
      Me.cmbEmisor.Focus()

   End Sub
   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumeroCompDesde.Enabled = Me.chbNumero.Checked
      Me.txtNumeroCompHasta.Enabled = Me.txtNumeroCompDesde.Enabled
      If Not Me.chbNumero.Checked Then
         Me.txtNumeroCompDesde.Text = ""
         Me.txtNumeroCompHasta.Text = ""
      Else
         Me.txtNumeroCompDesde.Focus()
      End If
   End Sub
   Private Sub txtNumeroCompDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Enter
      _numeroComprobanteDesdeAnterior = If(IsNumeric(txtNumeroCompDesde.Text), Long.Parse(txtNumeroCompDesde.Text), 0)
   End Sub
   Private Sub txtNumeroCompDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Leave
      Try
         Dim desde As Long = If(IsNumeric(txtNumeroCompDesde.Text), Long.Parse(txtNumeroCompDesde.Text), 0)
         Dim hasta As Long = If(IsNumeric(txtNumeroCompHasta.Text), Long.Parse(txtNumeroCompHasta.Text), 0)
         Dim delta As Long = desde - _numeroComprobanteDesdeAnterior
         txtNumeroCompHasta.Text = (hasta + delta).ToString()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub
   Private Sub CtaCteModificarComprobanteAplicado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyData = Keys.F5 Then
         Me.tsbRefrescar.PerformClick()
      End If
   End Sub

End Class