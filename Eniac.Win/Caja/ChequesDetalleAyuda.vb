Public Class ChequesDetalleAyuda

#Region "Properties"

   Public dtSelectedCheques As DataTable
   Public blSeleccionados As Boolean = False
   Public strTipoDeMovimiento As String
   Private tdCliente As String
   Private dCliente As String

   Public Property TipoDeMovimiento As String

#End Region
   Private _publicos As Publicos
   Private _idCaja As Integer
   Private cliente As Entidades.Cliente
   Private _IdCliente1 As Long

   Public Sub New(idCaja As Integer, CodigoCliente As Long)
      InitializeComponent()
      _idCaja = idCaja
      If CodigoCliente <> 0 Then
         cliente = New Reglas.Clientes().GetUnoPorCodigo(CodigoCliente)
         _IdCliente1 = cliente.IdCliente
      End If
   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            SetColumnIndexes()
            SetValoresFechaCobro()
            CargarComboBancos()

            '# Cargar combo filtro por Tipos de Cheque
            _publicos.CargaComboTiposCheques(cmbTiposCheques)
            cmbTiposCheques.SelectedIndex = -1

            If cliente IsNot Nothing Then
               chbCliente.Checked = True
               bscCodigoCliente.Text = cliente.CodigoCliente.ToString()
               bscCodigoCliente.Tag = _IdCliente1
               bscCodigoCliente.PresionarBoton()
            End If

            _publicos.CargaComboLocalidades(cmbLocalidad)

            CargarCheques()
         End Sub)
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbBanco.Checked And cmbBancos.SelectedIndex = -1 Then
               ShowMessage("ATENCIÓN: Activó filtro de Banco pero no seleccionó un valor.")
               cmbBancos.Focus()
               Exit Sub
            End If
            If chbLocalidad.Checked And cmbLocalidad.SelectedIndex = -1 Then
               ShowMessage("ATENCIÓN: Activó filtro de Localidad pero no seleccionó un valor.")
               cmbLocalidad.Focus()
               Exit Sub
            End If

            If chbCliente.Checked And bscCodigoCliente.Tag Is Nothing Then
               ShowMessage("ATENCIÓN: Activó filtro de Cliente pero no seleccionó un valor.")
               bscCodigoCliente.Focus()
               Exit Sub
            End If
            If chbProveedor.Checked And bscCodigoProveedor.Tag Is Nothing Then
               ShowMessage("ATENCIÓN: Activó filtro de Proveedor pero no seleccionó un valor.")
               bscCodigoProveedor.Focus()
               Exit Sub
            End If

            If chbTipoCheque.Checked And cmbTiposCheques.SelectedIndex = -1 Then
               ShowMessage("ATENCIÓN: Activó filtro de Tipo de Cheque pero no seleccionó un valor.")
               cmbTiposCheques.Focus()
               Exit Sub
            End If
            CargarCheques()
         End Sub)
   End Sub

   Private Sub dgvDetalle_DoubleClick(sender As Object, e As EventArgs) Handles dgvDetalle.DoubleClick
      TryCatched(
         Sub()
            If dgvDetalle.SelectedRows.Count > 0 Then
               dgvDetalle.Rows(dgvDetalle.SelectedRows(0).Index).Cells("Check").Value = True
            End If

            btnAceptar.PerformClick()
         End Sub)
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
         Sub()
            For Each dr As DataGridViewRow In dgvDetalle.Rows
               dr.Cells("Check").Value = chbTodos.Checked
            Next
         End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
         Sub()
            GuardarChequesSeleccionados()
            blSeleccionados = (dtSelectedCheques.Rows.Count > 0)
            Close()
         End Sub)
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(
         Sub()
            txtNumero.Enabled = chbNumero.Checked
            If Not chbNumero.Checked Then
               txtNumero.Clear()
            Else
               txtNumero.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbTitular_CheckedChanged(sender As Object, e As EventArgs) Handles chbTitular.CheckedChanged
      TryCatched(
         Sub()
            txtTitular.Enabled = chbTitular.Checked
            If Not chbTitular.Checked Then
               txtTitular.Clear()
            Else
               txtTitular.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbBanco_CheckedChanged(sender As Object, e As EventArgs) Handles chbBanco.CheckedChanged
      TryCatched(
         Sub()
            If Not chbBanco.Checked Then
               cmbBancos.SelectedIndex = -1
            End If
            cmbBancos.Enabled = chbBanco.Checked
         End Sub)
   End Sub

   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(
         Sub()
            If Not chbLocalidad.Checked Then
               cmbLocalidad.SelectedIndex = -1
            End If
            cmbLocalidad.Enabled = chbLocalidad.Checked
         End Sub)
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(
         Sub()
            bscCodigoCliente.Enabled = chbCliente.Checked
            bscCliente.Enabled = chbCliente.Checked
            If chbCliente.Checked = False Then
               bscCodigoCliente.Text = String.Empty
               bscCodigoCliente.Tag = Nothing
               bscCliente.Text = String.Empty
            End If
            bscCodigoCliente.Focus()
         End Sub)
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(
         Sub()
            bscCodigoProveedor.Enabled = chbProveedor.Checked
            bscProveedor.Enabled = chbProveedor.Checked
            bscCodigoProveedor.Text = String.Empty
            bscCodigoProveedor.Tag = Nothing
            bscProveedor.Text = String.Empty
            bscCodigoProveedor.Focus()
         End Sub)
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
            Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
         End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores2(bscProveedor)
            bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub

   Private Sub dgvDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
      TryCatched(
         Sub()
            If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
               dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Display)
            End If
         End Sub)
   End Sub

   Private Sub dgvDetalle_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellValueChanged
      TryCatched(
         Sub()
            If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
               CalcularTotal()
            End If
         End Sub)
   End Sub

   Private Sub dgvDetalle_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellLeave
      TryCatched(
         Sub()
            If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
               CalcularTotal()
            End If
         End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
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


   Private Sub chbFechaEnCarteraAl_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEnCarteraAl.CheckedChanged
      TryCatched(
         Sub()
            If Not chbFechaEnCarteraAl.Checked Then
               dtpFechaEnCarteraAl.Value = Date.Now
            End If
            dtpFechaEnCarteraAl.Enabled = chbFechaEnCarteraAl.Checked
         End Sub)
   End Sub

   Private Sub chbTipoCheque_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoCheque.CheckedChanged
      cmbTiposCheques.Enabled = chbTipoCheque.Checked
      If Not chbTipoCheque.Checked Then
         cmbTiposCheques.SelectedIndex = -1
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarCheques()
      Me.chbTodos.Checked = False

      Dim oCheques As Reglas.Cheques = New Reglas.Cheques()
      Dim blnCheqPropios As Boolean = False

      'Dim EstadoCheque As Entidades.Cheque.Estados

      Dim fechaEnCarteraAl As Date = Nothing

      Dim numero As Long = 0
      Dim idBanco As Integer = 0
      Dim idLocalidad As Integer = 0

      Dim idCliente As Long = 0

      Dim idProveedor As Long = 0

      Dim titular As String = String.Empty

      'Si es I lee en estado "ALTA" y esos todavia no tienen caja.
      If _TipoDeMovimiento = "I" Then
         _idCaja = 0
      End If

      If Me.chbFechaEnCarteraAl.Checked Then
         fechaEnCarteraAl = Me.dtpFechaEnCarteraAl.Value
      End If

      If Me.chbNumero.Checked Then
         Numero = Long.Parse(Me.txtNumero.Text)
      End If

      If Me.chbBanco.Checked Then
         IdBanco = Integer.Parse(Me.cmbBancos.SelectedValue.ToString())
      End If

      If Me.chbLocalidad.Checked Then
         IdLocalidad = Integer.Parse(Me.cmbLocalidad.SelectedValue.ToString())
      End If

      If bscCodigoCliente.Tag IsNot Nothing Then
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If bscCodigoProveedor.Tag IsNot Nothing Then
         idProveedor = Long.Parse(bscCodigoProveedor.Tag.ToString())
      End If

      If Me.chbTitular.Checked Then
         Titular = Me.txtTitular.Text
      End If

      '# Filtro Tipo de Cheque
      Dim tipoCheque As String = String.Empty
      If Me.chbTipoCheque.Checked Then
         tipoCheque = Me.cmbTiposCheques.SelectedValue.ToString()
      End If

      Dim dtDetalle As DataTable

      dtDetalle = oCheques.GetChequesDetalleAyuda(actual.Sucursal.Id,
                                       _idCaja,
                                       FechaCobroDesde:=dpFechaCobroDesde.Value, FechaCobroHasta:=dpFechaCobroHasta.Value, fechaEnCarteraAl,
                                       numero,
                                       idBanco, idLocalidad,
                                       False,
                                       idCliente, idProveedor,
                                       titular,
                                       _TipoDeMovimiento, tipoCheque)

      dgvDetalle.DataSource = dtDetalle

      dtSelectedCheques = DirectCast(Me.dgvDetalle.DataSource, DataTable).Clone()

      'DirectCast(Me.dgvDetalle.DataSource, DataTable).Columns.Add("Check", System.Type.GetType("System.Boolean"))

      For Each dgv As DataGridViewRow In Me.dgvDetalle.Rows
         dgv.Cells("Check").Value = False
      Next

      dgvDetalle.Columns("Check").DisplayIndex = 0
   End Sub

   Private Sub SetValoresFechaCobro()
      dpFechaCobroDesde.Value = Date.Now.AddMonths(-1)
      dpFechaCobroHasta.Value = Date.Now.AddYears(1)
   End Sub

   Private Sub GuardarChequesSeleccionados()
      dtSelectedCheques.Rows.Clear()

      For Each dgv As DataGridViewRow In Me.dgvDetalle.Rows

         If dgv.Cells("Check").Value IsNot Nothing AndAlso Boolean.Parse(dgv.Cells("Check").Value.ToString()) Then
            Dim drC = dtSelectedCheques.NewRow()

            drC("IdCheque") = dgv.Cells("IdCheque").Value
            drC("NumeroCheque") = dgv.Cells("NumeroCheque").Value
            drC("IdBanco") = dgv.Cells("IdBanco").Value
            drC("NombreBanco") = dgv.Cells("NombreBanco").Value
            drC("IdBancoSucursal") = dgv.Cells("IdBancoSucursal").Value
            drC("FechaEmision") = dgv.Cells("FechaEmision").Value
            drC("FechaCobro") = dgv.Cells("FechaCobro").Value
            drC("Titular") = dgv.Cells("Titular").Value
            drC("IdLocalidad") = dgv.Cells("IdLocalidad").Value
            drC("NombreLocalidad") = dgv.Cells("Localidad").Value
            drC("Importe") = dgv.Cells("Importe").Value
            drC("IdEstadoCheque") = dgv.Cells("IdEstadoCheque").Value
            drC("NroPlanillaIngreso") = dgv.Cells("NroPlanillaIngreso").Value
            drC("NroMovimientoIngreso") = dgv.Cells("NroMovimientoIngreso").Value
            drC("NroPlanillaEgreso") = dgv.Cells("NroPlanillaEgreso").Value
            drC("NroMovimientoEgreso") = dgv.Cells("NroMovimientoEgreso").Value
            drC("IdTipoCheque") = dgv.Cells("IdTipoCheque").Value
            drC("NombreTipoCheque") = dgv.Cells("NombreTipoCheque").Value
            drC("NroOperacion") = dgv.Cells("NroOperacion").Value
            '-- REQ-32950.- --
            drC("Cuit") = dgv.Cells("Cuit").Value
            dtSelectedCheques.Rows.Add(drC)
         End If
      Next
   End Sub

   Private Sub CargarComboBancos()
      Dim oBancos As Reglas.Bancos = New Reglas.Bancos()
      Dim dtdbCheques As DataTable = oBancos.GetTodos()
      Dim dtCheques As DataTable = dtdbCheques.Clone()

      Dim chRow As DataRow = dtCheques.NewRow()
      chRow("NombreBanco") = String.Empty
      chRow("IdBanco") = 0
      dtCheques.Rows.Add(chRow)
      dtCheques.Merge(dtdbCheques)

      cmbBancos.DataSource = dtCheques
      cmbBancos.DisplayMember = "NombreBanco"
      cmbBancos.ValueMember = "IdBanco"
   End Sub

   Private Sub SetColumnIndexes()

      IdBanco.DisplayIndex = 0
      NombreTipoCheque.DisplayIndex = 1
      NombreBanco.DisplayIndex = 2
      IdBancoSucursal.DisplayIndex = 3
      Localidad.DisplayIndex = 4
      NumeroCheque.DisplayIndex = 5
      FechaCobro.DisplayIndex = 6
      NroOperacion.DisplayIndex = 7
      FechaEmision.DisplayIndex = 8
      Titular.DisplayIndex = 9
      Importe.DisplayIndex = 10
      IdEstadoCheque.DisplayIndex = 11
      NroPlanillaIngreso.DisplayIndex = 12
      NroMovimientoIngreso.DisplayIndex = 13
      NroPlanillaEgreso.DisplayIndex = 14
      NroMovimientoEgreso.DisplayIndex = 15

   End Sub

   Private Sub CalcularTotal()

      Dim ImporteTotal As Decimal = 0

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If dr.Cells("Check").Value IsNot Nothing Then
            If Boolean.Parse(dr.Cells("Check").Value.ToString()) Then
               ImporteTotal = ImporteTotal + Decimal.Parse(dr.Cells("Importe").Value.ToString())
            End If
         End If
      Next

      txtImporteTotal.Text = ImporteTotal.ToString("#,##0.00")

   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Enabled = False
         bscCodigoProveedor.Enabled = False

         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Enabled = False
         bscCodigoCliente.Enabled = False

         btnConsultar.Focus()
      End If
   End Sub

#End Region

End Class