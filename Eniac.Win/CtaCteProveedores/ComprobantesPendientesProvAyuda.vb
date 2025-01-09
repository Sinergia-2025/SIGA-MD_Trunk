Public Class ComprobantesPendientesProvAyuda

#Region "Campos"

   Private _publicos As Publicos

   Private _tipoComprobFacturador As Entidades.TipoComprobante
   Private _idListaPrecios As Integer
   Private _idTipoComprob As String    'No puede tener el nombre _idTipoComprobante porque coincide con el parametro.
   Private _idProveedor As Long
   Private _grabaLibro As Boolean
   Private _proveedorGrilla As Entidades.Proveedor
   '-.PE-31850.-
   Private _compra As Entidades.Compra

   Private _comprobantes As List(Of Entidades.CuentaCorrienteProvPago)
   Private _comprobantesSeleccionados As List(Of Entidades.CuentaCorrienteProvPago)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         CargarValoresIniciales()
         'En forma predeterminada ya no busco, el usuario debe elegir buscar, sobre todo por aquellos que tienen mucha informacion y demora demasiado.
         'Me.CargaGrillaDetalle()
      End Sub)

   End Sub

#End Region

#Region "Constructores"

   Public Sub New(idTipoComprobanteFacturador As String, idTipoComprobante As String, IdProveedor As Long, grabaLibro As Boolean)

      InitializeComponent()

      _tipoComprobFacturador = New Reglas.TiposComprobantes().GetUno(idTipoComprobanteFacturador)

      _idTipoComprob = idTipoComprobante
      _idProveedor = IdProveedor
      _grabaLibro = grabaLibro

      If _comprobantesSeleccionados Is Nothing Then
         _comprobantesSeleccionados = New List(Of Entidades.CuentaCorrienteProvPago)
      End If

   End Sub

   Public Sub New(idTipoComprobanteFacturador As String, tipoComprobante As String, idProveedor As Long, comprobantesSeleccionados As List(Of Entidades.CuentaCorrienteProvPago), grabaLibro As Boolean)
      Me.New(idTipoComprobanteFacturador, tipoComprobante, idProveedor, grabaLibro)
      Me._comprobantesSeleccionados = comprobantesSeleccionados
   End Sub

#End Region

#Region "Eventos"


   Private Sub btnBuscar_Click(sender As Object, e As EventArgs)
      TryCatched(Sub() CargaGrillaDetalle())
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
         Dim entro As Boolean = False
         'Dim ent As Entidades.CuentaCorrientePago
         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            If dr.Cells("Check").Value IsNot Nothing Then
               If Boolean.Parse(dr.Cells("Check").Value.ToString()) = True Then

                  'For i As Integer = 0 To Me._comprobantesSeleccionados.Count - 1
                  '    ent = Me._comprobantesSeleccionados(i)
                  If Me._comprobantesSeleccionados.Count <> 0 Then
                     For Each dr1 As Entidades.CuentaCorrienteProvPago In Me._comprobantesSeleccionados
                        If dr.Cells("gcoIdTipoComprobante").Value.ToString() = dr1.IdTipoComprobante And
                                               dr.Cells("gcoLetra").Value.ToString() = dr1.Letra And
                                               Double.Parse(dr.Cells("gcoCentroEmisor").Value.ToString()) = dr1.CentroEmisor And
                                               Double.Parse(dr.Cells("gcoNumeroComprobante").Value.ToString()) = dr1.NumeroComprobante And
                                               Double.Parse(dr.Cells("gcoCuota").Value.ToString()) = dr1.Cuota Then
                           MessageBox.Show("La cuota del comprobante ya esta ingresado: " & dr1.IdTipoComprobante & "-" & dr1.Letra & "-" & dr1.CentroEmisor & "-" & dr1.NumeroComprobante & "", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                           entro = True
                        End If
                     Next
                  End If


                  'Next

                  ' Me._comprobantesSeleccionados.Add(Me._comprobantes(dr.Index))
               End If
            End If
         Next

         If entro = False Then
            For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
               If dr.Cells("Check").Value IsNot Nothing Then
                  If Boolean.Parse(dr.Cells("Check").Value.ToString()) = True Then

                     Me._comprobantesSeleccionados.Add(Me._comprobantes(dr.Index))
                  End If
               End If
            Next
            DialogResult = DialogResult.OK
         End If
      End Sub)
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

   Private Sub dgvDetalle_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellValueChanged
      If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
         CalcularTotal()
      End If
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

   Private Sub dgvDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
      TryCatched(
      Sub()
         If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Display)
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


#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      _publicos = New Publicos()
      CargaGrillaDetalle()
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idTiposComprobantes = New List(Of String)()

      Dim oProveedor = New Reglas.Proveedores()
      _proveedorGrilla = oProveedor._GetUno(_idProveedor)

      _comprobantes = New List(Of Entidades.CuentaCorrienteProvPago)
      Dim rComprobantes = New Reglas.CuentasCorrientesProv()

      Using dt = rComprobantes.BuscarPendientes(actual.Sucursal.Id, _proveedorGrilla, _tipoComprobFacturador.ComprobantesAsociados, 0)

         Using dt1 = dt.Clone()
            Dim dr2 As DataRow

            Dim rows_a_remover = New List(Of DataRow)()
            For Each row1 In dt.AsEnumerable()
               For Each row2 In _comprobantesSeleccionados
                  If row1("Sucursal").ToString() = row2.IdSucursal.ToString() AndAlso row1("IdTipoComprobante").ToString() = row2.IdTipoComprobante.ToString() AndAlso
                     row1("Letra").ToString() = row2.Letra AndAlso row1("Emisor").ToString() = row2.CentroEmisor.ToString() AndAlso
                     row1("Numero").ToString() = row2.NumeroComprobante.ToString() Then
                     rows_a_remover.Add(row1)
                  End If
               Next
            Next

            For Each row In rows_a_remover
               dt.Rows.Remove(row)
               dt.AcceptChanges()
            Next

            For Each dr In dt.AsEnumerable()
               dr2 = dt1.NewRow()
               dr2.ItemArray = dr.ItemArray
               dt1.Rows.Add(dr2)
               dt1.AcceptChanges()

            Next

            Dim cache = New Reglas.BusquedasCacheadas()
            For Each dr1 In dt1.AsEnumerable()
               Dim oLineaDetalle = New Entidades.CuentaCorrienteProvPago()
               With oLineaDetalle
                  .TipoComprobante = cache.BuscaTipoComprobante(dr1.Field(Of String)("IdTipoComprobante"))
                  .Letra = dr1.Field(Of String)("Letra")
                  .CentroEmisor = dr1.Field(Of Integer)("Emisor").ToShort()
                  .NumeroComprobante = dr1.Field(Of Long)("Numero")
                  .Cuota = dr1.Field(Of Integer)("Cuota")
                  .Fecha = dr1.Field(Of Date)("Fecha")
                  .FechaVencimiento = dr1.Field(Of Date)("FechaVencimiento")
                  .ImporteCuota = dr1.Field(Of Decimal)("Importe")
                  .SaldoCuota = dr1.Field(Of Decimal)("Saldo")

                  .DescuentoRecargoPorc = If(Reglas.Publicos.CtaCteProv.ImputacionAutomaticaDRFormaPago, dr1.Field(Of Decimal?)("Porcentaje").IfNull(), 0D)
                  .DescuentoRecargo = .SaldoCuota * .DescuentoRecargoPorc / 100

                  .Paga = .SaldoCuota + .DescuentoRecargo
                  '.FormPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(dr1("IdFormasPago").ToString()))
                  '.DescuentoRecargoPorc = Decimal.Parse(dr1("DescuentoRecargoPorc").ToString())
                  '.DescuentoRecargo = Decimal.Parse(dr1("DescuentoRecargo").ToString())
                  .IdSucursal = dr1.Field(Of Integer)("Sucursal")
                  .Usuario = actual.Nombre
                  .MercEnviada = dr1.Field(Of Boolean)("MercEnviada") 'Y esto
                  .Observacion = dr1.Field(Of String)("Observacion")

               End With

               _comprobantes.Add(oLineaDetalle)
            Next
         End Using
      End Using

      dgvDetalle.DataSource = _comprobantes

      chbTodos.Checked = False

      tssRegistros.Text = _comprobantes.Count.ToString() & " Registros"
   End Sub

   Private Sub CalcularTotal()

      Dim ImporteTotal As Decimal = 0

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If dr.Cells("Check").Value IsNot Nothing Then
            If Boolean.Parse(dr.Cells("Check").Value.ToString()) Then
               ImporteTotal = ImporteTotal + Decimal.Parse(dr.Cells("gcoSaldoCuota").Value.ToString())
            End If
         End If
      Next

      txtTotal.Text = ImporteTotal.ToString("N2")

   End Sub


#End Region

#Region "Propiedades"

   Public ReadOnly Property ComprobantesSeleccionados() As List(Of Entidades.CuentaCorrienteProvPago)
      Get
         Return _comprobantesSeleccionados
      End Get
   End Property

#End Region

End Class