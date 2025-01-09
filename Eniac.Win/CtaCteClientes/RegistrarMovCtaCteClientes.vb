Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class RegistrarMovCtaCteClientes

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos
   Private _clienteE As Entidades.Cliente
   Private _estaCargando As Boolean = True
   Private Const BusquedaClienteSecundaria_DOMICILIO As String = "DOMICILIO"
   Private Const BusquedaClienteSecundaria_CUIT As String = "CUIT"
   Private Const BusquedaClienteSecundaria_EMBARCACION As String = "EMBARCACION"
   Private Const BusquedaClienteSecundaria_CAMA As String = "CAMA"
   Private _idEmbarcacion As Long = 0
   Private _idCama As Long = 0

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", , "SI")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")

         Me.dtpFechaEmision.Value = Date.Now

         CargaComboBusquedaDomicilio()
         cmbBusquedaDomicilio.Text = Reglas.Publicos.BusquedaClienteFacturacion
         cmbBusquedaDomicilio.Enabled = True


         Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub RegistrarMovCtaCteClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F4 And Me.tsbGrabar.Enabled Then
         Me.tsbGrabar_Click(Me.tsbGrabar, New EventArgs())
      End If
   End Sub

   Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.Nuevo()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.GrabarComprobante()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tbsSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsSalir.Click
      Me.Close()
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
            Me.dtpFechaEmision.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Nuevo()
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

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.dtpFechaEmision.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Nuevo()
      End Try
   End Sub

   Private Sub dtpFechaEmision_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaEmision.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaEmision_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaEmision.ValueChanged
      Me.dtpFechaVencimiento.Value = Me.dtpFechaEmision.Value.AddMonths(1)
   End Sub

   Private Sub dtpFechaVencimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaVencimiento.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbVendedor.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbTiposComprobantes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTiposComprobantes.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbTiposComprobantes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try

         'solo habilito el boton de Facturables segun corresponde (si Eligio Factura en blanco o negro, tickets, etc)
         If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

            'Si es X es remito, siempre debe tener esa letra, sino dejo la que esta.
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Or _
               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "R" Then
               Me.txtLetra.Text = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If Me._clienteE IsNot Nothing Then
                  Me.txtLetra.Text = Me._clienteE.CategoriaFiscal.LetraFiscal
               Else
                  Me.txtLetra.Text = ""
               End If
            End If

            Try
               Me.txtEmisorComprobante.Text = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString()).CentroEmisor.ToString()
            Catch ex As Exception
               'Si Da error es porque no esta seteado para esta PC
               Me.txtEmisorComprobante.Text = New Reglas.Impresoras().GetPorSucursalTipoComprobante(actual.Sucursal.Id, Me.cmbTiposComprobantes.SelectedValue.ToString()).CentroEmisor.ToString()
            End Try

         Else
            Me.txtEmisorComprobante.Text = ""
         End If

            Me.CargarProximoNumero()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtLetra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLetra.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEmisorComprobante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmisorComprobante.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNumeroComprobante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroComprobante.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtImporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporte.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub bscDireccion_BuscadorClick() Handles bscDireccion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Select Case cmbBusquedaDomicilio.SelectedItem.ToString()
            Case BusquedaClienteSecundaria_DOMICILIO
               _publicos.PreparaGrillaClientes2(bscDireccion)
               Dim oClientes As Reglas.Clientes = New Reglas.Clientes
               bscDireccion.Datos = oClientes.GetFiltradoPorDireccion(bscDireccion.Text.Trim())
            Case BusquedaClienteSecundaria_CUIT
               _publicos.PreparaGrillaClientes2(bscDireccion)
               Dim oClientes As Reglas.Clientes = New Reglas.Clientes
               bscDireccion.Datos = oClientes.GetFiltradoPorCUIT(bscDireccion.Text.Trim())
            Case BusquedaClienteSecundaria_EMBARCACION
               _publicos.PreparaGrillaEmbarcaciones(bscDireccion)
               Dim oEmbarcaciones As Reglas.Embarcaciones = New Reglas.Embarcaciones()
               bscDireccion.Datos = oEmbarcaciones.GetFiltradoPorNombre(bscDireccion.Text.Trim())
            Case BusquedaClienteSecundaria_CAMA
               _publicos.PreparaGrillaCamas(bscDireccion)
               Dim oCamas As Reglas.Camas = New Reglas.Camas
               bscDireccion.Datos = oCamas.GetCamaPorCodigo(bscDireccion.Text.Trim())
         End Select
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscDireccion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDireccion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Select Case cmbBusquedaDomicilio.SelectedItem.ToString()
               Case BusquedaClienteSecundaria_DOMICILIO
                  CargarDatosCliente(e.FilaDevuelta)
               Case BusquedaClienteSecundaria_CUIT
                  CargarDatosCliente(e.FilaDevuelta)
               Case BusquedaClienteSecundaria_EMBARCACION
                  CargarDatosEmbarcacion(e.FilaDevuelta)
               Case BusquedaClienteSecundaria_CAMA
                  CargarDatosCama(e.FilaDevuelta)
            End Select
         End If
      Catch ex As Exception
         ShowError(ex)
         Try
            Me.Nuevo()
         Catch ex1 As Exception
            MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub Nuevo()
      Me._estaCargando = True
      Me.chbNumeroDeCtaCte.Checked = False
      Me.cmbTiposComprobantes.SelectedIndex = -1
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCodigoCliente.Text = ""
      Me.bscCliente.Text = ""
      Me.bscCodigoCliente.Enabled = True
      Me.bscCliente.Enabled = True
      Me._clienteE = Nothing
      Me.dtpFechaEmision.Value = Date.Now
      Me.txtEmisorComprobante.Text = ""
      Me.txtNumeroComprobante.Text = ""
      Me.txtImporte.Text = "0.00"
      Me.txtObservacion.Text = ""
      Me.bscCodigoCliente.Focus()
      cmbBusquedaDomicilio.Text = Reglas.Publicos.BusquedaClienteFacturacion
      cmbBusquedaDomicilio.Enabled = True
      Me.bscDireccion.Permitido = True
      bscDireccion.Text = ""
      _idCama = 0
      _idEmbarcacion = 0
      Me._estaCargando = False
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())

      'Si es X es remito y siempre debe tener esa letra
      If Me.txtLetra.Text <> "X" And Me.txtLetra.Text <> "R" Then
         Me.txtLetra.Text = dr.Cells("LetraFiscal").Value.ToString()
      End If
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      Dim Vend As Reglas.Empleados = New Reglas.Empleados()
      Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(Integer.Parse(dr.Cells("IdVendedor").Value.ToString()))

      Dim oCliente As Reglas.Clientes = New Reglas.Clientes()
      Me._clienteE = oCliente.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

      'Me.CargarProximoNumero()

      Me.tsbGrabar.Enabled = True

   End Sub

   Private Sub PresionarTab(ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Function GetVendedorCombo(ByVal id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub GrabarComprobante()

      If Me.ValidarComprobante() Then

         Try

            Me.tsbGrabar.Enabled = False

            'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
            Dim coe As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores

            'cargo el comprobante en el objeto CuentasCorrientes
            Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
            Dim CC As Entidades.CuentaCorriente = New Entidades.CuentaCorriente()

            With CC
               .IdSucursal = actual.Sucursal.Id
               .TipoComprobante.IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
               .Letra = Me.txtLetra.Text
               .CentroEmisor = Short.Parse(Me.txtEmisorComprobante.Text)
               .NumeroComprobante = Long.Parse(Me.txtNumeroComprobante.Text)
               .Fecha = Me.dtpFechaEmision.Value
               .FechaVencimiento = Me.dtpFechaVencimiento.Value
               .Cliente = Me._clienteE
               .Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
               .FormaPago.IdFormasPago = 3
               .ImporteTotal = Decimal.Parse(Me.txtImporte.Text) * coe
               .Saldo = .ImporteTotal
               .CantidadCuotas = 1
               .Observacion = Me.txtObservacion.Text
               .Usuario = actual.Nombre
               .IdEstado = "NORMAL"

               If .Cliente.IdClienteCtaCte <> 0 Then
                  .IdClienteCtaCte = .Cliente.IdClienteCtaCte
               Else
                  .IdClienteCtaCte = .Cliente.IdCliente
               End If

               .IdCategoria = .Cliente.IdCategoria
               .CotizacionDolar = Decimal.Parse(Me.txtCotizacionDolar.Text)
               .Direccion = .Cliente.Direccion
               .IdLocalidad = .Cliente.IdLocalidad
               .IdEmbarcacion = _idEmbarcacion
               .IdCama = _idCama
            End With

            Dim CCP As Entidades.CuentaCorrientePago = New Entidades.CuentaCorrientePago()

            With CCP
               .IdSucursal = CC.IdSucursal
               .TipoComprobante.IdTipoComprobante = CC.TipoComprobante.IdTipoComprobante
               .Letra = CC.Letra
               .CentroEmisor = CC.CentroEmisor
               .NumeroComprobante = CC.NumeroComprobante
               .Cuota = 1
               '.Fecha = Me.dtpFechaEmision.Value
               .FechaVencimiento = CC.FechaVencimiento
               .ImporteCuota = CC.ImporteTotal
               .ImporteCapital = .ImporteCuota
               .SaldoCuota = CC.ImporteTotal
               .IdEmbarcacion = _idEmbarcacion
               .IdCama = _idCama
               .CuentaCorriente = CC
            End With

            oCtaCte.GrabaCtaCte(CC, CCP, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)

            MessageBox.Show("Los datos se grabaron correctamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Nuevo()

         Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tsbGrabar.Enabled = True
         End Try

      End If

   End Sub

   Private Function ValidarComprobante() As Boolean

      If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         MessageBox.Show("Debe Informar el Tipo de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If Integer.Parse("0" & Me.txtEmisorComprobante.Text) <= 0 Then
         MessageBox.Show("Debe Informar el Emisor de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtEmisorComprobante.Focus()
         Return False
      End If

      If Long.Parse("0" & Me.txtNumeroComprobante.Text) <= 0 Then
         MessageBox.Show("Debe Informar el Numero de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroComprobante.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtImporte.Text) <= 0 Then
         MessageBox.Show("Debe Informar el Importe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtImporte.Focus()
         Return False
      End If

      Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes
      If oCtaCte.Existe(actual.Sucursal.Id, _
                        Me.cmbTiposComprobantes.SelectedValue.ToString(), _
                        Me.txtLetra.Text, _
                        Short.Parse(Me.txtEmisorComprobante.Text), _
                        Long.Parse(Me.txtNumeroComprobante.Text)) Then

         MessageBox.Show("El Comprobante YA Existe en la Cuenta Corriente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtImporte.Focus()
         Return False
      End If

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas
      If oVentas.Existe(actual.Sucursal.Id, _
                        Me.cmbTiposComprobantes.SelectedValue.ToString(), _
                        Me.txtLetra.Text, _
                        Short.Parse(Me.txtEmisorComprobante.Text), _
                        Long.Parse(Me.txtNumeroComprobante.Text)) Then

         Dim ImporteTotal As Decimal
         ImporteTotal = oVentas.GetUna(actual.Sucursal.Id, _
                                    Me.cmbTiposComprobantes.SelectedValue.ToString(), _
                                    Me.txtLetra.Text, _
                                    Short.Parse(Me.txtEmisorComprobante.Text), _
                                    Long.Parse(Me.txtNumeroComprobante.Text)).ImporteTotal

         If Math.Abs(ImporteTotal) = Decimal.Parse(Me.txtImporte.Text) Then
            MessageBox.Show("El Comprobante YA Existe como Contado!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtImporte.Focus()
            Return False
         Else
            MessageBox.Show("El Comprobante Existe en Ventas y no coincide el Importe, el cual es " & Math.Abs(ImporteTotal).ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtImporte.Focus()
            Return False
         End If

      End If

      Return True

   End Function

    Private Sub CargarProximoNumero()

        If Me.txtLetra.Text <> "" Then

            Dim oVentasNumeros As New Reglas.VentasNumeros
            Dim oCtaCte As New Reglas.CuentasCorrientes
            Dim CentroEmisor As Short

            CentroEmisor = Short.Parse(Me.txtEmisorComprobante.Text)   'oImpresora.CentroEmisor

            If Me.chbNumeroDeCtaCte.Checked Then

                Me.txtNumeroComprobante.Text = oCtaCte.GetProximoNumeroCC(actual.Sucursal.Id, _
                                                                      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante, _
                                                                      Me.txtLetra.Text, _
                                                                      CentroEmisor).ToString()

            Else

            Me.txtNumeroComprobante.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal, _
                                                                      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante, _
                                                                      Me.txtLetra.Text, _
                                                                      CentroEmisor).ToString()
            End If

        Else

            Me.txtNumeroComprobante.Text = ""

        End If

    End Sub

   Private Sub CargaComboBusquedaDomicilio()
      cmbBusquedaDomicilio.Items.Add(BusquedaClienteSecundaria_CUIT)
      cmbBusquedaDomicilio.Items.Add(BusquedaClienteSecundaria_DOMICILIO)
      If New Reglas.Generales().ExisteTabla("Embarcaciones") Then
         cmbBusquedaDomicilio.Items.Add(BusquedaClienteSecundaria_EMBARCACION)
      End If
      If New Reglas.Generales().ExisteTabla("Camas") Then
         cmbBusquedaDomicilio.Items.Add(BusquedaClienteSecundaria_CAMA)
      End If
   End Sub
   Private Sub CargarDatosEmbarcacion(dr As DataGridViewRow)

      _idEmbarcacion = Long.Parse(dr.Cells("idEmbarcacion").Value.ToString())

      bscDireccion.Text = dr.Cells("NombreEmbarcacion").Value.ToString()
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      If Not String.IsNullOrEmpty(bscCodigoCliente.Text) Then
         bscCliente.PresionarBoton()
         Me.bscDireccion.Permitido = False
         Me.cmbBusquedaDomicilio.Enabled = False
      Else
         MessageBox.Show("La EMBARCACION no posee Cliente Responsable de Cargo Asignado!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscDireccion.Permitido = True
         Me.cmbBusquedaDomicilio.Enabled = True
      End If

   End Sub

   Private Sub CargarDatosCama(dr As DataGridViewRow)


      _idCama = Long.Parse(dr.Cells("idCama").Value.ToString())

      bscDireccion.Text = dr.Cells("CodigoCama").Value.ToString()

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      If Not String.IsNullOrEmpty(bscCodigoCliente.Text) Then
         bscCliente.PresionarBoton()
         Me.bscDireccion.Permitido = False
         Me.cmbBusquedaDomicilio.Enabled = False
      Else
         MessageBox.Show("La CAMA no posee Cliente Responsable de Cargo Asignado!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscDireccion.Permitido = True
         Me.cmbBusquedaDomicilio.Enabled = True
      End If

   End Sub

#End Region

End Class