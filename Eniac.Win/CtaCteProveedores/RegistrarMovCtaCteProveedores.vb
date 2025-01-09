Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class RegistrarMovCtaCteProveedores

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos
   Private _ProveedorE As Entidades.Proveedor
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()

         'Me._publicos.CargaComboEmpleados(Me.cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "COMPRAS", , "SI")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me.dtpFechaEmision.Value = Date.Now

         Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub RegistrarMovCtaCteProveedores_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.dtpFechaEmision.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Nuevo()
      End Try
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
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

   Private Sub cmbTiposComprobantes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTiposComprobantes.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbTiposComprobantes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged

      If _estaCargando Then Exit Sub

      Try
         '-- Inicializa Variables.- ---
         txtEmisorComprobante.Text = ""
         txtNumeroComprobante.Text = ""
         txtLetra.Text = ""
         chbNumeroDeCtaCte.Checked = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).NumeracionAutomatica
         '------------------------------

         'solo habilito el boton de Facturables segun corresponde (si Eligio Factura en blanco o negro, tickets, etc)
         If cmbTiposComprobantes.SelectedValue IsNot Nothing Then

            'Si es X es remito, siempre debe tener esa letra, sino dejo la que esta.
            If DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Or
               DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "R" Then
               Me.txtLetra.Text = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If _ProveedorE IsNot Nothing Then
                  txtLetra.Text = _ProveedorE.CategoriaFiscal.LetraFiscalCompra
               End If
            End If
            '-- REQ-31998.- ---------------------
            If chbNumeroDeCtaCte.Checked Then
               CargarProximoNumeroProveedor()
            ElseIf DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 And
               Not DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja And
               Not DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ActualizaCtaCte Then
               CargarProximoNumero()
            End If
            '------------------------------------
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'Private Sub cmbComprador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
   '   Me.PresionarTab(e)
   'End Sub

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

#End Region

#Region "Metodos"

   Private Sub Nuevo()
      '-- REQ-31998.- ---------------------
      Me.chbNumeroDeCtaCte.Checked = False
      Me._estaCargando = True
      '------------------------------------
      Me.cmbTiposComprobantes.SelectedIndex = -1
      Me.bscCodigoProveedor.Text = ""
      Me.bscProveedor.Text = ""
      Me.bscCodigoProveedor.Enabled = True
      Me.bscProveedor.Enabled = True
      Me._ProveedorE = Nothing
      Me.dtpFechaEmision.Value = Date.Now
      Me.txtEmisorComprobante.Text = ""
      Me.txtNumeroComprobante.Text = ""
      Me.txtImporte.Text = "0.00"
      Me.txtObservacion.Text = ""
      Me.bscCodigoProveedor.Focus()
      '-- REQ-31998.- ---------------------
      Me._estaCargando = False
      '------------------------------------
   End Sub

   Private Sub PresionarTab(ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      'Si es X es remito y siempre debe tener esa letra
      If Me.txtLetra.Text <> "X" And Me.txtLetra.Text <> "R" Then
         Me.txtLetra.Text = dr.Cells("LetraFiscal").Value.ToString()
      End If
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

      'Dim Vend As Reglas.Empleados = New Reglas.Empleados()
      'Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(dr.Cells("TipoDocVendedor").Value.ToString(), dr.Cells("NroDocVendedor").Value.ToString())

      Dim oProveedor As Reglas.Proveedores = New Reglas.Proveedores()
      Me._ProveedorE = oProveedor.Proveedores_G1Todos(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))

      'Me.CargarProximoNumero()

      Me.tsbGrabar.Enabled = True

   End Sub

   Private Sub GrabarComprobante()

      If Me.ValidarComprobante() Then

         Try

            Me.tsbGrabar.Enabled = False

            'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
            Dim coe As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores

            'cargo el comprobante en el objeto CuentasCorrientes
            Dim oCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
            Dim CC As Entidades.CuentaCorrienteProv = New Entidades.CuentaCorrienteProv()

            With CC
               .IdSucursal = actual.Sucursal.Id
               .Proveedor = Me._ProveedorE
               .TipoComprobante.IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
               .Letra = Me.txtLetra.Text
               .CentroEmisor = Short.Parse(Me.txtEmisorComprobante.Text)
               .NumeroComprobante = Long.Parse(Me.txtNumeroComprobante.Text)
               .Fecha = Me.dtpFechaEmision.Value
               .FechaVencimiento = Me.dtpFechaVencimiento.Value
               '.Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
               .FormaPago.IdFormasPago = 3
               .ImporteTotal = Decimal.Parse(Me.txtImporte.Text) * coe
               .Saldo = .ImporteTotal
               .Cuotas = 1
               .Observacion = Me.txtObservacion.Text
               .Usuario = actual.Nombre
               .IdEstado = "NORMAL"
            End With

            Dim CCP As Entidades.CuentaCorrienteProvPago = New Entidades.CuentaCorrienteProvPago()

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
               .SaldoCuota = CC.ImporteTotal
               .CuentaCorrienteProv = CC
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

      Dim oCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv
      If oCtaCte.Existe(actual.Sucursal.Id, _
                        Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), _
                        Me.cmbTiposComprobantes.SelectedValue.ToString(), _
                        Me.txtLetra.Text, _
                        Integer.Parse(Me.txtEmisorComprobante.Text), _
                        Long.Parse(Me.txtNumeroComprobante.Text)) Then

         MessageBox.Show("El Comprobante YA Existe en la Cuenta Corriente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtImporte.Focus()
         Return False
      End If

      Dim oCompras As Reglas.Compras = New Reglas.Compras
      If oCompras.Existe(actual.Sucursal.Id, _
                         Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), _
                         Me.cmbTiposComprobantes.SelectedValue.ToString(), _
                         Me.txtLetra.Text, _
                         Short.Parse(Me.txtEmisorComprobante.Text), _
                         Long.Parse(Me.txtNumeroComprobante.Text)) Then

         Dim ImporteTotal As Decimal
         ImporteTotal = oCompras.GetUna(actual.Sucursal.Id, _
                                    Me.cmbTiposComprobantes.SelectedValue.ToString(), _
                                    Me.txtLetra.Text, _
                                    Short.Parse(Me.txtEmisorComprobante.Text), _
                                    Long.Parse(Me.txtNumeroComprobante.Text), _
                                    Long.Parse(Me.bscCodigoProveedor.Tag.ToString())).ImporteTotal

         If Math.Abs(ImporteTotal) = Decimal.Parse(Me.txtImporte.Text) Then
            MessageBox.Show("El Comprobante YA Existe como Contado!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtImporte.Focus()
            Return False
         Else
            MessageBox.Show("El Comprobante Existe en Compras y no coincide el Importe, el cual es " & Math.Abs(ImporteTotal).ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtImporte.Focus()
            Return False
         End If

      End If

      Return True

   End Function

   ''' <summary>
   ''' REQ-31998.- -Traiga por el numero del proximo movimiento a realizar-
   ''' </summary>
   Private Sub CargarProximoNumero()


      If Me.txtLetra.Text <> "" Then
         Dim oImpresoras As New Reglas.Impresoras
         Dim oCN As New Reglas.ComprasNumeros
         Dim CentroEmisor As Short

         'CentroEmisor = oImpresoras.GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, False).CentroEmisor
         CentroEmisor = oImpresoras.GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString()).CentroEmisor

         Me.txtEmisorComprobante.Text = CentroEmisor.ToString()

         Me.txtNumeroComprobante.Text = oCN.GetProximoNumero(actual.Sucursal.Id,
                                                      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                      Me.txtLetra.Text,
                                                      CentroEmisor).ToString()
      Else
         Me.txtEmisorComprobante.Text = ""
         Me.txtNumeroComprobante.Text = ""
      End If
   End Sub

   Private Sub CargarProximoNumeroProveedor()
      Dim oVentasNumeros As New Reglas.VentasNumeros()

      Dim ventaNumero As Entidades.VentaNumero = oVentasNumeros.GetUnoPorRelacionado(DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante)
      If ventaNumero IsNot Nothing Then
         txtLetra.Text = ventaNumero.LetraFiscal
         txtEmisorComprobante.Text = ventaNumero.CentroEmisor.ToString()
         txtNumeroComprobante.Text = ventaNumero.Numero.ToString()
         txtNumeroComprobante.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal,
                                                                     DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                                     ventaNumero.LetraFiscal,
                                                                     ventaNumero.CentroEmisor).ToString()
         txtLetra.Enabled = False
         txtEmisorComprobante.Enabled = False
         txtNumeroComprobante.Enabled = False
      Else

         If txtLetra.Text <> "" And _ProveedorE IsNot Nothing Then
            Dim oCompras As New Reglas.Compras
            Dim oCtaCte As New Reglas.CuentasCorrientesProv
            Dim nCompras, nCtasCte As Long

            txtEmisorComprobante.Text = "1"

            nCompras = oCompras.GetProximoNumero(actual.Sucursal.Id,
                                                                  Long.Parse(bscCodigoProveedor.Tag.ToString),
                                                                  DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                                  txtLetra.Text,
                                                                  Short.Parse("0" & txtEmisorComprobante.Text))

            nCtasCte = oCtaCte.GetProximoNumeroCC(actual.Sucursal.Id,
                                                  DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                  txtLetra.Text,
                                                  Short.Parse("0" & txtEmisorComprobante.Text))

            If nCompras >= nCtasCte Then
               txtNumeroComprobante.Text = nCompras.ToString()
            Else
               txtNumeroComprobante.Text = nCtasCte.ToString()
            End If

         Else
            txtEmisorComprobante.Text = ""
            txtNumeroComprobante.Text = ""
         End If
      End If
   End Sub


#End Region

End Class