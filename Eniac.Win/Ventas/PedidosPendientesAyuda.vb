Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class PedidosPendientesAyuda

#Region "Campos"

   Private _publicos As Publicos

   Private _tipoComprobFacturador As Entidades.TipoComprobante
   Private _idListaPrecios As Integer
   Private _idTipoComprob As String    'No puede tener el nombre _idTipoComprobante porque coincide con el parametro.
    Private _idCliente As Long

   Private _comprobantes As List(Of Entidades.Venta)
   Private _comprobantesSeleccionados As List(Of Entidades.Venta)

   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargarValoresIniciales()

         'En forma predeterminada ya no busco, el usuario debe elegir buscar, sobre todo por aquellos que tienen mucha informacion y demora demasiado.
         'Me.CargaGrillaDetalle()

         _tit = GetColumnasVisiblesGrilla(dgvDetalle)

         Me.Cursor = Cursors.Default

      Catch ex As Exception

         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Constructores"

   Public Sub New(ByVal idTipoComprobanteFacturador As String, ByVal idListaPrecios As Integer, ByVal idTipoComprobante As String, ByVal IdCliente As Long)

      Me.InitializeComponent()

      Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
      Dim _cliente As Entidades.Cliente = oClientes.GetUno(IdCliente)

      Me._tipoComprobFacturador = New Reglas.TiposComprobantes().GetUno(idTipoComprobanteFacturador)
      Me._idListaPrecios = idListaPrecios
      Me._idTipoComprob = idTipoComprobante
        Me._idCliente = _cliente.IdCliente

      If Me._comprobantesSeleccionados Is Nothing Then
         Me._comprobantesSeleccionados = New List(Of Entidades.Venta)
      End If

   End Sub

   Public Sub New(ByVal idTipoComprobanteFacturador As String, ByVal idListaPrecios As Integer, ByVal tipoComprobante As String, ByVal IdCliente As Long, ByVal comprobantesSeleccionados As List(Of Entidades.Venta))
      Me.New(idTipoComprobanteFacturador, idListaPrecios, tipoComprobante, IdCliente)
      Me._comprobantesSeleccionados = comprobantesSeleccionados
   End Sub

#End Region

#Region "Eventos"

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Try

         Me.bscCodigoCliente.Permitido = Me.chbCliente.Checked
         Me.bscCliente.Permitido = Me.chbCliente.Checked

         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty

         Me.bscCodigoCliente.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

      Try

         If Me.clbTiposComprobantes.CheckedItems.Count = 0 Then
            MessageBox.Show("ATENCION: Debe elegir al menos un Tipo de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.clbTiposComprobantes.Focus()
            Exit Sub
         End If

         Dim oTC As Entidades.TipoComprobante
         Dim PrimerTipoComprobante As String = String.Empty
         Dim blnAfectaCaja As Boolean = False
         Dim blnGrabaLibro As Boolean = False
         Dim blnCoeficienteStockCero As Boolean = False
         Dim intCoeficienteStock As Integer
         Dim Cont As Integer = 0

         For Each doc As DataRowView In Me.clbTiposComprobantes.CheckedItems

            oTC = New Reglas.TiposComprobantes().GetUno(doc("IdTipoComprobante").ToString())

            'Permito que un Presupuesto elija Presupuesto.
            If oTC.IdTipoComprobante = Me._tipoComprobFacturador.IdTipoComprobante And Me._tipoComprobFacturador.CoeficienteStock <> 0 Then
               MessageBox.Show("ATENCION: no puede elegir el mismo comprobante que el Invocador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
               Me.clbTiposComprobantes.Focus()
               Exit Sub
            End If

            Cont += 1

            If Cont = 1 Then
               PrimerTipoComprobante = oTC.Descripcion.Trim().ToUpper()
               blnAfectaCaja = oTC.AfectaCaja
               blnGrabaLibro = oTC.GrabaLibro
               blnCoeficienteStockCero = (oTC.CoeficienteStock = 0)
               intCoeficienteStock = oTC.CoeficienteStock
            Else

               If blnGrabaLibro <> oTC.GrabaLibro Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de IVA del '" & PrimerTipoComprobante & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

               If blnAfectaCaja <> oTC.AfectaCaja Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Caja del '" & PrimerTipoComprobante & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

               'If blnCoeficienteStockCero <> (oTC.CoeficienteStock = 0) Then
               '   MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Coeficiente Stock del '" & PrimerTipoComprobante & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
               '   Me.clbTiposComprobantes.Focus()
               '   Exit Sub
               'End If

               'Permito que sean -1 y 1, pero no uno que sea 0 (y 1 / -1)
               If intCoeficienteStock <> oTC.CoeficienteStock And (intCoeficienteStock = 0 Or oTC.CoeficienteStock = 0) Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Coeficiente Stock del '" & PrimerTipoComprobante & "' cuando algun valor es 0 (Cero).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

               'Permito que sean -1 y 1, pero no uno que sea 0 (y 1 / -1), pero tampoco permito distintos si el invocador es una NCRED.
               If intCoeficienteStock <> oTC.CoeficienteStock And Me._tipoComprobFacturador.CoeficienteValores = -1 Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Coeficiente Stock del '" & PrimerTipoComprobante & "', y NO lo permite el invocador '" & Me._tipoComprobFacturador.Descripcion.Trim.ToUpper() & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

            End If

         Next

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

      'La situacion qeu controlo se da si tiene activado la posibilidad de Invocar Comprobantes que invocaron.
      'o bien si alguna vez lo tuvo, pero por performance (por ahora), pregunto una vez.

      If Reglas.Publicos.Facturacion.FacturacionInvocarInvocador Then

         '' ''Try

         '' ''   If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         '' ''   'If Me.dgvDetalle.SelectedRows.Count = 0 Then Exit Sub

         '' ''   If e.RowIndex <> -1 And e.ColumnIndex = 0 Then

         '' ''      Me.Cursor = Cursors.WaitCursor

         '' ''      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

         '' ''      Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
         '' ''                  Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
         '' ''                  Me.dgvDetalle.Rows(e.RowIndex).Cells("LetraComprobante").Value.ToString(), _
         '' ''                  Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
         '' ''                  Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))


         '' ''      'Si invoco a uno que en el extremo movia stock, el codigo no esta previsto y vuelve a descontar stock.
         '' ''      'Habria que ahcer el codigo recurrente en el analisis de los facturables.

         '' ''      'Controlo si el que facturo movia stock.
         '' ''      If Me._tipoComprobFacturador.CoeficienteStock <> 0 And venta.Facturables.Count > 0 AndAlso venta.Facturables(0).TipoComprobante.CoeficienteStock <> 0 Then
         '' ''         MessageBox.Show("El Comprobante que intenta seleccionar Invoco a otro que afecto Stock, NO puede seleccionarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
         '' ''         Me.dgvDetalle.EndEdit() 'Fuerzo el fin de la edicion para poder ponerlo en falso.
         '' ''         Me.dgvDetalle.Rows(e.RowIndex).Cells("Check").Value = False
         '' ''         Exit Sub
         '' ''      End If

         '' ''   End If

         '' ''Catch ex As Exception
         '' ''   Me.Cursor = Cursors.Default
         '' ''   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '' ''Finally
         '' ''   Me.Cursor = Cursors.Default
         '' ''End Try

      End If

   End Sub

   'Private Sub dgvDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle.DoubleClick

   '   Try

   '      If Me.dgvDetalle.SelectedRows.Count > 0 Then
   '         Me.dgvDetalle.Rows(Me.dgvDetalle.SelectedRows(0).Index).Cells("Check").Value = True
   '      End If

   '      Me.btnAceptar_Click(sender, e)

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged

      Me.Cursor = Cursors.WaitCursor

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         dr.Cells("Check").Value = Me.chbTodos.Checked
      Next

      Me.Cursor = Cursors.Default

   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim drGral As Decimal? = Nothing

         Dim idClienteVinculado As Long = -1

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            If dr.Cells("Check").Value IsNot Nothing Then
               If Boolean.Parse(dr.Cells("Check").Value.ToString()) = True Then
                  If idClienteVinculado < 0 Then idClienteVinculado = _comprobantes(dr.Index).IdClienteVinculado

                  If _comprobantes(dr.Index).IdClienteVinculado <> idClienteVinculado Then
                     _comprobantesSeleccionados.Clear()
                     ShowMessage("No se permite seleccionar comprobantes de diferentes clientes vinculados.")
                     Exit Sub
                  End If

                  Me._comprobantesSeleccionados.Add(Me._comprobantes(dr.Index))
                  If _tipoComprobFacturador.CargaDescRecGralActual Then
                     If Not drGral.HasValue Then
                        drGral = _comprobantes(dr.Index).DescuentoRecargoPorc
                     End If
                     If drGral.Value <> _comprobantes(dr.Index).DescuentoRecargoPorc Then
                        _comprobantesSeleccionados.Clear()
                        ShowMessage("No se permite seleccionar comprobantes con diferentes descuentos y recargos.")
                        Exit Sub
                     End If
                  End If
               End If
            End If
         Next

         '---PE-44280- impedir seleccionar si los comprobantes tienen distinta cotización dólar y si comprobante no carga precio según parametrización mantiene valoración del dólar del comprobante invocado
         Dim CantidadSeleccionados As Integer = dgvDetalle.Rows.Cast(Of DataGridViewRow)().
                          Count(Function(dr) dr.Cells("Check").Value IsNot Nothing AndAlso Boolean.TryParse(dr.Cells("Check").Value.ToString(), True))
         If CantidadSeleccionados > 1 Then
            If (_comprobantes(0).IdMoneda = Entidades.Moneda.Dolar And Reglas.Publicos.Facturacion.CotizacionDolarPedidoInvocado <> Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO) Or
                       (_comprobantes(0).IdMoneda = Entidades.Moneda.Peso And Reglas.Publicos.Facturacion.CotizacionDolarPedidoPesosInvocado <> Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO) Then
               Dim DolarPedido As Decimal = _comprobantes(0).CotizacionDolar
               If Not _comprobantes(0).TipoComprobante.CargaPrecioActual Then
                  For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
                     If dr.Cells("Check").Value IsNot Nothing Then
                        If Boolean.Parse(dr.Cells("Check").Value.ToString()) = True Then
                           If _comprobantes(dr.Index).CotizacionDolar <> DolarPedido Then
                              _comprobantesSeleccionados.Clear()
                              ShowMessage("No se permite seleccionar comprobantes de diferentes cotizaciones de dólar.")
                              Exit Sub
                           End If
                        End If
                     End If
                  Next
               End If
            End If
         End If



         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me._publicos = New Publicos()

      If Me._idTipoComprob = "" Then
         Dim ComprobAsoc As String
         'ComprobAsoc = New Reglas.TiposComprobantes().GetUno(Me._idTipoComprobFacturador).ComprobantesAsociados
         ComprobAsoc = Me._tipoComprobFacturador.ComprobantesAsociados
         Me._publicos.CargaListaTiposComprobantesFacturables(Me.clbTiposComprobantes, ComprobAsoc, False)
      Else
         Me._publicos.CargaListaTiposComprobantesPedidos(Me.clbTiposComprobantes)
      End If

      If Me.clbTiposComprobantes.Items.Count > 0 And Me._idTipoComprob <> "" Then
         Dim Cont As Integer = 0
         For i As Integer = 0 To Me.clbTiposComprobantes.Items.Count - 1
            'If DirectCast(Me.clbTiposComprobantes.Items(i), System.Data.DataRowView)("IdTipoComprobante").ToString() = Me._idTipoComprob Then
            Me.clbTiposComprobantes.SetItemChecked(Cont, True)
            'Exit For
            'End If
            Cont += 1
         Next
         'For Each doc As DataRowView In Me.clbTiposComprobantes.Items
         '   If doc("IdTipoComprobante").ToString() = Me._idTipoComprob Then
         '      Me.clbTiposComprobantes.SetItemChecked(Cont, True)
         '      'Exit For
         '   End If
         '   Cont += 1
         'Next
      End If

      If Me.clbTiposComprobantes.Items.Count = 1 Then
         Me.clbTiposComprobantes.SetItemChecked(0, True)
      End If
      '-- REQ-33223.- ---------------------------------------------------------------------------------------------------
      Me.dtpDesde.Value = Date.Now.AddMonths(Reglas.Publicos.Facturacion.FacturacionRangoFechaFiltroInvocarPedidos * -1)
      '------------------------------------------------------------------------------------------------------------------
      Me.dtpHasta.Value = Date.Now

      Me.chbCliente.Enabled = Reglas.Publicos.Facturacion.FacturacionInvocarDeOtroCliente

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Permitido = False
      Me.bscCodigoCliente.Permitido = False

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idTiposComprobantes As List(Of String) = New List(Of String)()

      Dim IdCliente As Long = Me._idCliente

      For Each doc As DataRowView In Me.clbTiposComprobantes.CheckedItems
         idTiposComprobantes.Add(doc("IdTipoComprobante").ToString())
      Next

      'If Me.clbTiposComprobantes.Items.Count > 0 Then
      '   If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
      '      'strTipoComprobante = Me.cmbTiposComprobantes.SelectedItem("IdTipoComprobante").ToString()
      '      IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
      '   End If
      'End If

      Dim numeroOrdenCompra As Long = 0
      If Me.chbOrdenCompra.Checked Then
         Long.TryParse(Me.txtOrdenCompra.Text.ToString(), numeroOrdenCompra)
      End If

      If Me.chbCliente.Checked Then
         IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      Dim decTotal As Decimal

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Dim estado As String = String.Empty
      If _tipoComprobFacturador.InvocarPedidosConEstadoEspecifico Then
         estado = Publicos.EstadoPedidoPendiente
      End If

      Dim idSucursal As Integer = actual.Sucursal.Id
      If Reglas.Publicos.Facturacion.FacturacionInvocarPedidosDeOtrasSucursales Then
         idSucursal = 0
      End If

      Me._comprobantes = Nothing
      Me._comprobantes = oVentas.GetFacturablesPedidos(idSucursal,
                                                       Me.dtpDesde.Value,
                                                       Me.dtpHasta.Value,
                                                       idTiposComprobantes,
                                                       IdCliente,
                                                       estado,
                                                       Me._idListaPrecios,
                                                       _tipoComprobFacturador,
                                                       numeroOrdenCompra)

      decTotal = 0

      Me.dgvDetalle.DataSource = Me._comprobantes

      AjustarColumnasGrilla(dgvDetalle, _tit)

      For Each row As DataGridViewRow In Me.dgvDetalle.Rows
         'row.Cells("Check").Value = False
         decTotal = decTotal + Decimal.Parse(row.Cells("Total").Value.ToString())
      Next

      Me.chbTodos.Checked = False

      Me.txtTotal.Text = decTotal.ToString("##,##0.00")

      Me.tssRegistros.Text = Me._comprobantes.Count.ToString() & " Registros"

      If Me._comprobantesSeleccionados.Count > 0 Then
         For Each row As DataGridViewRow In Me.dgvDetalle.Rows
            Dim vent As Entidades.Venta = DirectCast(row.DataBoundItem, Entidades.Venta)
            For Each vent1 As Entidades.Venta In Me._comprobantesSeleccionados
               If vent.TipoComprobante.IdTipoComprobante = vent1.TipoComprobante.IdTipoComprobante And
                  vent.LetraComprobante = vent1.LetraComprobante And
                  vent.CentroEmisor = vent1.CentroEmisor And
                  vent.NumeroComprobante = vent1.NumeroComprobante Then
                  row.Cells("Check").Value = True
               End If
            Next
         Next
         Me._comprobantesSeleccionados = New List(Of Entidades.Venta)
      End If

      With Me.dgvDetalle
         .Columns("Check").DisplayIndex = 0
         .Columns("Fecha").DisplayIndex = 1
         .Columns("facIdSucursal").DisplayIndex = 2
         .Columns("TipoComprobanteDescripcion").DisplayIndex = 3
         .Columns("LetraComprobante").DisplayIndex = 4
         .Columns("CentroEmisor").DisplayIndex = 5
         .Columns("NumeroComprobante").DisplayIndex = 6
         .Columns("Kilos").DisplayIndex = 7
         .Columns("Total").DisplayIndex = 8
         .Columns("facObservacion").DisplayIndex = 9
      End With

   End Sub

#End Region

#Region "Propiedades"

   Public ReadOnly Property ComprobantesSeleccionados() As List(Of Entidades.Venta)
      Get
         Return Me._comprobantesSeleccionados
      End Get
   End Property

#End Region

   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      Try
         Me.txtOrdenCompra.Enabled = Me.chbOrdenCompra.Checked

         If Not Me.chbOrdenCompra.Checked Then
            Me.txtOrdenCompra.Text = String.Empty
         Else
            Me.txtOrdenCompra.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class