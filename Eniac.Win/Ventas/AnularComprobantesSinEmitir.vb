Public Class AnularComprobantesSinEmitir

#Region "Campos"

   Private _publicos As Publicos

   Private _idTipoComprob As String
   Private _letra As String
   Private _emisor As Short
   Private _numeroComprobante As Long

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me._publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")

         Me.RefrescarDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click

      Try
         Me.RefrescarDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click

      Try
         Me.AnularComprobante()

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

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.cmbCategoriaFiscal.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.LimpiarControles()
      End Try
   End Sub


   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.cmbCategoriaFiscal.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.LimpiarControles()
      End Try
   End Sub

   Private Sub dgvDetalle_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

      Try

         If e.RowIndex <> -1 Then

            Me._idTipoComprob = Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString()
            Me._letra = Me.dgvDetalle.Rows(e.RowIndex).Cells("LetraFiscal").Value.ToString()
            Me._emisor = Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString())
            Me._numeroComprobante = Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("Numero").Value.ToString())

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      LimpiarControles()

      Dim rVentas = New Reglas.Ventas()
      dgvDetalle.DataSource = rVentas.GetUltimosNumerosComprobantes(actual.Sucursal.Id, "VENTAS", anularComprobantesSinEmitir:=True)

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

      bscCliente.Enabled = False
      bscCodigoCliente.Enabled = False

      cmbCategoriaFiscal.SelectedValue = dr.Cells("IdCategoriaFiscal").Value

      Dim Vend = New Reglas.Empleados()
      cmbVendedor.SelectedItem = GetVendedorCombo(Integer.Parse(dr.Cells("IdVendedor").Value.ToString()))
      cmbCobrador.SelectedItem = GetCobradorrCombo(Integer.Parse(dr.Cells("IdCobrador").Value.ToString()))

   End Sub

   Private Sub LimpiarControles()

      txtNumeroTope.Text = String.Empty
      dtpFecha.Value = Date.Now

      bscCodigoCliente.Enabled = True
      bscCodigoCliente.Text = String.Empty
      bscCodigoCliente.Tag = Nothing
      bscCliente.Enabled = True
      bscCliente.Text = String.Empty

      cmbCategoriaFiscal.SelectedIndex = -1
      cmbVendedor.SelectedIndex = -1
      cmbCobrador.SelectedIndex = -1
      cmbFormaPago.SelectedIndex = -1

      _numeroComprobante = -1

      dgvDetalle.Focus()

   End Sub

   Private Function GetVendedorCombo(id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Function GetCobradorrCombo(id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbCobrador.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub AnularComprobante()

      Me._idTipoComprob = Me.dgvDetalle.SelectedRows(0).Cells("IdTipoComprobante").Value.ToString()
      Me._letra = Me.dgvDetalle.SelectedRows(0).Cells("LetraFiscal").Value.ToString()
      Me._emisor = Short.Parse(Me.dgvDetalle.SelectedRows(0).Cells("CentroEmisor").Value.ToString())
      Me._numeroComprobante = Long.Parse(Me.dgvDetalle.SelectedRows(0).Cells("Numero").Value.ToString())

      If Me.ValidarComprobante() Then

         Dim oFaturacion As Reglas.Ventas = New Reglas.Ventas
         Dim oVentas As New Entidades.Venta

         With oVentas

            .IdEstadoComprobante = "ANULADO"

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre

            'cargo el comprobante
            .TipoComprobante = New Reglas.TiposComprobantes().GetUno(Me._idTipoComprob)

            .LetraComprobante = Me._letra

            .CentroEmisor = Me._emisor

            'Numero TOPE de Anulacion
            .NumeroComprobante = Long.Parse(Me.txtNumeroTope.Text)

            'cargo el cliente
            .Cliente = New Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))
            .IdCategoria = .Cliente.IdCategoria
            .Direccion = .Cliente.Direccion
            .IdLocalidad = .Cliente.IdLocalidad

            'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
            .CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)

            .Fecha = Me.dtpFecha.Value

            .Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
            .Cobrador = DirectCast(Me.cmbCobrador.SelectedItem, Entidades.Empleado)
            .FormaPago = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago)

            .Observacion = "*** COMPROBANTE ANULADO SIN EMITIR ***"

            'cargo valores del comprobante
            .ImporteBruto = 0
            .DescuentoRecargo = 0
            .DescuentoRecargoPorc = 0
            .Subtotal = 0
            .ImporteTotal = 0

            .Kilos = 0

            'cargo la impresora
            '.Impresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.EsFiscal)
            .Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

            'Fuerzo el Emisor porque despues usa eso.
            .Impresora.CentroEmisor = Short.Parse(Me._emisor.ToString())

            'cargo los productos
            .VentasProductos = Nothing

            'Cargo los Comprobantes Facturados
            '.Facturables = Nothing

            'cargo las monedas de pago (Efectivo, Cheques, etc)
            .Cheques = Nothing

            .ImportePesos = 0
            '.ImporteTarjetas = 0
            .ImporteTickets = 0

         End With

         oFaturacion.AnularComprobantesSinEmitir(oVentas, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)

         MessageBox.Show("¡¡¡ Comprobante(s) Anulado(s) Exitosamente !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.RefrescarDatosGrilla()

      End If

   End Sub

   Private Function ValidarComprobante() As Boolean

      If Me._numeroComprobante = -1 Then
         MessageBox.Show("Tiene que seleccionar un comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dgvDetalle.Focus()
         Return False
      End If

      If Long.Parse("0" & Me.txtNumeroTope.Text) <= 0 Then
         MessageBox.Show("El Proximo Numero debe ser positivo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroTope.Focus()
         Return False
      End If

      If Long.Parse(Me.txtNumeroTope.Text) < Me._numeroComprobante Then
         MessageBox.Show("El numero ingresado debe ser Mayor al actual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroTope.Focus()
         Return False
      End If

      If Me.dtpFecha.Value.Date > Date.Now.Date Then
         MessageBox.Show("La Fecha No puede ser mayor al dia de HOY.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dtpFecha.Focus()
         Return False
      End If

      If Me.cmbCategoriaFiscal.SelectedIndex = -1 Then
         MessageBox.Show("Debe Seleccionar una Categoria Fiscal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbCategoriaFiscal.Focus()
         Return False
      End If

      If Me.cmbVendedor.SelectedIndex = -1 Then
         MessageBox.Show("Debe Seleccionar un Vendedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbVendedor.Focus()
         Return False
      End If

      If Me.cmbCobrador.SelectedIndex = -1 Then
         MessageBox.Show("Debe Seleccionar un Cobrador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbCobrador.Focus()
         Return False
      End If

      If Me.cmbFormaPago.SelectedIndex = -1 Then
         MessageBox.Show("Debe Seleccionar una Forma de Pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbFormaPago.Focus()
         Return False
      End If

      If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
         MessageBox.Show("Debe Seleccionar un Cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      'Remitos, Recibos y otros presupuesto no deben comparar con la letra del cliente
      If Me._letra <> "X" And DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal <> Me._letra Then
         MessageBox.Show("La Letra de la Categoria Fiscal NO coincide con la del Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbCategoriaFiscal.Focus()
         Return False
      End If

      Dim Cantidad As Long
      Cantidad = Long.Parse(Me.txtNumeroTope.Text) - Me._numeroComprobante

      If MessageBox.Show("¿ Esta Seguro de Anular " & Cantidad.ToString() & " Comprobante(s) ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
         Return False
      End If

      If Cantidad > 10 Then
         If MessageBox.Show("ATENCION: ¿ REALMENTE DESEA ANULAR " & Cantidad.ToString() & " COMPROBANTES ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Return False
         End If
      End If

      Return True

   End Function

#End Region

End Class