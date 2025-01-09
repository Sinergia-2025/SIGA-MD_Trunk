Public Class ChequesDeTercerosDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _utilizaCentroCostos As Boolean = False
   Private _permisoPlanillaDeCaja As Boolean = False
   Private _vieneDelActualizar As Boolean = False

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.Cheque)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            '_publicos.CargaComboLocalidades(Me.cmbLocalidad)
            _publicos.CargaComboBancos(cmbBanco)
            _publicos.CargaComboSituacionCheques(cmbSituacionCheque)

            _publicos.CargaComboCajas(cmbCaja, actual.Sucursal.Id, miraUsuario:=True, miraPC:=False, cajasModificables:=True)
            cmbCaja.SelectedIndex = -1

            If Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
               _utilizaCentroCostos = True
               _publicos.CargaComboCentroCostos(cmbCentroCosto)
               cmbCentroCosto.Visible = True
               cmbCentroCosto.LabelAsoc.Visible = True
               cmbCentroCosto.Enabled = Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosCaja
            End If

            '# Carga Combo Tipos Cheques
            _publicos.CargaComboTiposCheques(cmbTipoCheque)

            _liSources.Add("Banco", DirectCast(_entidad, Entidades.Cheque).Banco)
            _liSources.Add("Localidad", DirectCast(_entidad, Entidades.Cheque).Localidad)
            _liSources.Add("Cliente", DirectCast(_entidad, Entidades.Cheque).Cliente)
            _liSources.Add("Proveedor", DirectCast(_entidad, Entidades.Cheque).Proveedor)
            _liSources.Add("CuentaBancaria", DirectCast(_entidad, Entidades.Cheque).CuentaBancaria)
            '''''PE-31207
            ''''Me._liSources.Add("SituacionCheque", DirectCast(Me._entidad, Entidades.Cheque).SituacionCheque)

            BindearControles(_entidad, _liSources)

            If txtNumeroCheque.Enabled Then
               dtpFechaEmision.Value = Date.Today
               dtpFechaCobro.Value = Date.Today
               dtpFechaIngresoCaja.Value = Date.Today
            End If

            'Si el cheque tiene movimiento de Ingreso Caja, mejor que no cambie nada.
            'If Integer.Parse(Me.txtNroPlanillaIngreso.Text) > 0 Then
            '   Me.grbDetalle.Enabled = False
            'End If

            Dim oUsuario = New Reglas.Usuarios()
            _permisoPlanillaDeCaja = oUsuario.TienePermisos("PlanillaDeCaja")
            TabControl1.TabPages.Remove(tbpIngresoCaja)

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then

               txtEstadoActual.Text = "ALTA"
               txtEstadoActualAnt.Text = "ALTA"

               'bscCodigoLocalidad.Text = actual.Sucursal.Localidad.IdLocalidad.ToString()
               bscCodigoLocalidad.Text = actual.Sucursal.LocalidadComercial.IdLocalidad.ToString()
               bscCodigoLocalidad.PresionarBoton()

               If _permisoPlanillaDeCaja Then
                  TabControl1.TabPages.Add(tbpIngresoCaja)
                  btnIngresoPorCaja.Enabled = True
                  cmbCaja.Enabled = True
               End If

               'Me.txtNumeroCheque.Focus()   'NO anda

               cmbTipoCheque.SelectedValue = "F"
            Else
               txtBancoSucursal.Text = DirectCast(_entidad, Entidades.Cheque).IdBancoSucursal.ToString()
               txtBancoSucursal.Enabled = True

               bscCodigoLocalidad.PresionarBoton()

               'bscCodigoLocalidad.Enabled = False
               'bscNombreLocalidad.Enabled = False

               pcbChequeFrente.Image = DirectCast(_entidad, Entidades.Cheque).FotoFrente
               PcbChequeDorso.Image = DirectCast(_entidad, Entidades.Cheque).FotoDorso

               Dim ModificaFechas As Boolean = False

               If txtEstadoActual.Text = "ALTA" Or txtEstadoActual.Text = "ENCARTERA" Then
                  ModificaFechas = True
               End If

               dtpFechaEmision.Enabled = ModificaFechas
               dtpFechaCobro.Enabled = ModificaFechas

               txtTitular.ReadOnly = Not ModificaFechas
               txtTitular.IsRequired = ModificaFechas

               txtCUIT.ReadOnly = Not ModificaFechas

               If txtEstadoActual.Text = "ALTA" Then
                  txtImporte.Enabled = True

                  _vieneDelActualizar = True
                  If _permisoPlanillaDeCaja Then
                     TabControl1.TabPages.Add(tbpIngresoCaja)
                     btnIngresoPorCaja.Enabled = True
                     cmbCaja.Enabled = True
                  End If

               End If

               If DirectCast(_entidad, Entidades.Cheque).IdCajaIngreso > 0 Then
                  txtNombreCajaIngreso.Text = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, DirectCast(_entidad, Entidades.Cheque).IdCajaIngreso).NombreCaja
               End If

               If DirectCast(_entidad, Entidades.Cheque).IdCajaEgreso > 0 Then
                  txtNombreCajaEgreso.Text = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, DirectCast(_entidad, Entidades.Cheque).IdCajaEgreso).NombreCaja
               End If

               If DirectCast(_entidad, Entidades.Cheque).CodigoProveedorPreasignado > 0 Then
                  chbProveedor.Checked = True
                  bscCodigoProveedor.Text = DirectCast(_entidad, Entidades.Cheque).CodigoProveedorPreasignado.ToString()
                  bscCodigoProveedor.PresionarBoton()
               End If

            End If
         End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Cheques()
   End Function

   Protected Overrides Sub Aceptar()

      If cmbCaja.SelectedIndex <> -1 And Me.bscCuentaCaja.Text.Trim.Length > 0 Then
         Dim eCajaDetalle = New Entidades.CajaDetalles()
         With eCajaDetalle
            .IdSucursal = actual.Sucursal.Id
            .IdCaja = cmbCaja.ValorSeleccionado(Of Integer)()
            .NumeroPlanilla = txtPlanillaActual.Text.ValorNumericoPorDefecto(0I)
            .IdCuentaCaja = bscCuentaCaja.Text.ValorNumericoPorDefecto(0I)
            .IdTipoMovimiento = "I"c 'CChar(txtTipoMovimiento.Text) -- Fuerzo Ingreso por si eligio una cuenta de egreso.
            .Observacion = txtObservaciones.Text
            .FechaMovimiento = dtpFechaIngresoCaja.Value
            .ImportePesos = 0
            .ImporteCheques = txtImporte.ValorNumericoPorDefecto(0D)
            .ImporteTarjetas = 0
            .ImporteTickets = 0
            .ImporteDolares = 0
            .ImporteBancos = 0
            .Usuario = actual.Nombre

            'este campo es para ver si se puede modificar o no un movimiento de caja
            .EsModificable = True
            .GeneraContabilidad = True

            If _utilizaCentroCostos Then
               .CentroCosto = DirectCast(cmbCentroCosto.SelectedItem, Entidades.ContabilidadCentroCosto)
            End If
         End With
         DirectCast(_entidad, Entidades.Cheque).CajaDetalleParaIngresoDirectoPorABM = eCajaDetalle
      End If
      If Not String.IsNullOrWhiteSpace(Me.bscCodigoProveedor.Text) Then
         DirectCast(_entidad, Entidades.Cheque).IdProveedorPreasignado = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      Else
         DirectCast(_entidad, Entidades.Cheque).IdProveedorPreasignado = 0
      End If

      DirectCast(_entidad, Entidades.Cheque).IdBancoSucursal = Integer.Parse(txtBancoSucursal.Text)

      MyBase.Aceptar()

   End Sub

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If txtNumeroCheque.ValorNumericoPorDefecto(0I) <= 0 Then
         txtNumeroCheque.Select()
         Return "El Número de Cheque es inválido."
      End If

      If txtBancoSucursal.ValorNumericoPorDefecto(0I) < 0 Then
         txtBancoSucursal.Select()
         Return "La Sucursal del Banco es inválida."
      End If

      If Not bscCodigoLocalidad.Selecciono And Not bscNombreLocalidad.Selecciono Then
         bscCodigoLocalidad.Select()
         Return "No selecciono la Localidad."
      End If
      'Valida fecha cobro sea mayor a fecha emision
      If dtpFechaCobro.Value.Date < dtpFechaEmision.Value.Date Then
         dtpFechaCobro.Select()
         Return "La Fecha de Cobro NO puede ser menor a la Fecha de Emisión"
      End If

      If txtImporte.ValorNumericoPorDefecto(0D) <= 0 Then
         txtImporte.Select()
         Return "El Importe del Cheque es inválido."
      End If

      '# Validación del CUIT
      If String.IsNullOrEmpty(txtCUIT.Text) OrElse txtCUIT.Text = "0" Then
         txtCUIT.Select()
         Return "Debe ingresar un Nro. CUIT para el Cheque."
      Else

         Dim result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.
                        Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() With
                                    {
                                       .IdFiscal = txtCUIT.Text,
                                       .SolicitaCUIT = True
                                    }) '# Siempre solicitamos el CUIT al insertar el cheque por la nueva Alternative Key en BD
         If result.Error Then
            txtCUIT.Focus()
            Return result.MensajeError
         End If

      End If

      If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
         bscCodigoProveedor.Focus()
         Return "ATENCION: NO seleccionó un Proveedor"
      End If

      If txtEstadoActual.Text = "ALTA" And cmbCaja.SelectedIndex <> -1 Then
         Dim idCaja = bscCuentaCaja.Text.ValorNumericoPorDefecto(0I)
         If idCaja = 0 Then
            'If Me.bscCuentaCaja.Text.Trim.Length = 0 Then
            bscCuentaCaja.Select()
            Return "No selecciono la cuenta de caja para el ingreso directo."
         End If

         If cmbCentroCosto.Enabled AndAlso cmbCentroCosto.SelectedIndex = -1 Then
            cmbCentroCosto.Select()
            Return "No selecciono ningún Centro de Costos"
         End If

         If dtpFechaIngresoCaja.Value > Date.Today Then
            Return "La fecha de Ingreso de Cheque a Caja no puede ser Mayor a Hoy"
         End If

      End If

      '# Tipo de Cheque
      If cmbTipoCheque.SelectedIndex = -1 Then
         cmbTipoCheque.Focus()
         Return "ATENCIÓN: No seleccionó un Tipo de Cheque"
      End If

      If cmbTipoCheque.SelectedIndex <> -1 Then
         If DirectCast(cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion AndAlso
            String.IsNullOrEmpty(txtNroOperacion.Text) Then
            txtNroOperacion.Focus()
            Return "ATENCIÓN: Debe ingresar un Número de Operación para el Tipo de Cheque seleccionado."
         End If
      End If

      ''NO SE REQUIERE VALIDACION PORQUE NO ES REQ. LA SIT DE CHQ
      'If Me.cmbNombreSituacionCheque.SelectedIndex = -1 Then
      '   Me.cmbNombreSituacionCheque.Focus()
      '   Return "ATENCIÓN: No seleccionó una Situación de Cheque"
      'End If
      Return vacio

   End Function

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
         Sub()
            If Not HayError Then Close()
            txtNumeroCheque.Select()
         End Sub)
   End Sub
   Private Sub btnIngresoPorCaja_Click(sender As Object, e As EventArgs) Handles btnIngresoPorCaja.Click
      TryCatched(
       Sub()
          TabControl1.SelectedIndex = 3
          cmbCaja.Focus()
       End Sub)
   End Sub
   Private Sub btnLimpiarTamaño_Click(sender As Object, e As EventArgs) Handles btnLimpiarIngresoEnCaja.Click
      TryCatched(
         Sub()
            cmbCaja.SelectedIndex = -1
            txtPlanillaActual.Text = ""
            txtNMovimiento.Text = ""
            dtpFechaIngresoCaja.Value = Date.Today
            bscCuentaCaja.Text = ""
            bscNombreCuentaCaja.Text = ""
            txtTipoMovimiento.Text = ""
            txtObservaciones.Text = ""

            If _utilizaCentroCostos Then
               cmbCentroCosto.SelectedIndex = -1
            End If
         End Sub)
   End Sub
   Private Sub cmbCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCaja.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbCaja.SelectedIndex > -1 Then
               txtPlanillaActual.Text = New Reglas.Cajas().GetPlanillaActual(actual.Sucursal.Id, cmbCaja.ValorSeleccionado(Of Integer)).NumeroPlanilla.ToString()
               txtNMovimiento.Text = New Reglas.CajaDetalles().GetProximoNumeroDeMovimiento(actual.Sucursal.Id, cmbCaja.ValorSeleccionado(Of Integer), Integer.Parse(txtPlanillaActual.Text)).ToString()

               dtpFechaIngresoCaja.IsRequired = True
               bscCuentaCaja.IsRequired = True
               bscNombreCuentaCaja.IsRequired = True

               If _utilizaCentroCostos Then
                  cmbCentroCosto.IsRequired = True
               End If
            Else

               txtPlanillaActual.Text = ""
               txtNMovimiento.Text = ""

               dtpFechaIngresoCaja.IsRequired = False
               bscCuentaCaja.IsRequired = False
               bscNombreCuentaCaja.IsRequired = False

               If _utilizaCentroCostos Then
                  cmbCentroCosto.IsRequired = False
               End If

            End If
         End Sub)
   End Sub
   Private Sub cmbTipoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCheque.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbTipoCheque.SelectedIndex <> -1 Then
               If DirectCast(cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion Then
                  txtNroOperacion.Enabled = True
               Else
                  txtNroOperacion.Clear()
                  txtNroOperacion.Enabled = False
               End If
            End If
         End Sub)
   End Sub

#Region "Eventos Buscador Localidad"
   Private Sub lnkLocalidad_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocalidad.LinkClicked
      TryCatched(
         Sub()
            Using frmLocalidad = New LocalidadesDetalle(New Entidades.Localidad())
               frmLocalidad.StateForm = StateForm.Insertar
               frmLocalidad.CierraAutomaticamente = True
               If frmLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  bscCodigoLocalidad.Text = frmLocalidad.txtIdLocalidad.Text
                  bscCodigoLocalidad.PresionarBoton()
               End If
            End Using
         End Sub)
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaLocalidades(bscCodigoLocalidad)
            bscCodigoLocalidad.Datos = New Reglas.Localidades().GetPorCodigo(bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaLocalidades(bscNombreLocalidad)
            bscNombreLocalidad.Datos = New Reglas.Localidades().GetPorNombre(bscNombreLocalidad.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion, bscNombreLocalidad.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarLocalidad(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

#Region "Eventos Buscador Cuenta de Caja"
   Private Sub bscCodigoCuenta_BuscadorClick() Handles bscCuentaCaja.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeCajas(bscCuentaCaja)
            bscCuentaCaja.Datos = New Reglas.CuentasDeCajas().GetTodas(bscCuentaCaja.Text)
         End Sub)
   End Sub
   Private Sub bscNombreCuentaCaja_BuscadorClick() Handles bscNombreCuentaCaja.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeCajas(bscNombreCuentaCaja)
            bscNombreCuentaCaja.Datos = New Reglas.CuentasDeCajas().GetPorNombre(bscNombreCuentaCaja.Text)
         End Sub)
   End Sub
   Private Sub bscCodigoCuenta_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaCaja.BuscadorSeleccion, bscNombreCuentaCaja.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCuentaDeCaja(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

#Region "Eventos Buscador Proveedor pre-seleccionado"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(
         Sub()
            bscCodigoProveedor.Enabled = chbProveedor.Checked
            bscProveedor.Enabled = chbProveedor.Checked

            If Not chbProveedor.Checked Then
               bscCodigoProveedor.Tag = Nothing
               bscCodigoProveedor.Text = ""
               bscProveedor.Text = ""
            Else
               bscCodigoProveedor.Focus()
            End If
         End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
            Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
         End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores(bscProveedor)
            bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text)
         End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosProveedor(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

#End Region

#Region "Eventos Toolbar"
   Private Sub tsbBuscar_Click(sender As Object, e As EventArgs) Handles tsbBuscar.Click
      TryCatched(
         Sub()
            If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
               If Not String.IsNullOrEmpty(ofdArchivos.FileName) Then
                  If IO.File.ReadAllBytes(ofdArchivos.FileName).Length > Reglas.Publicos.TamañoMaximoImagenes Then
                     ShowMessage(String.Format("El tamaño de la imagen no puede ser mayor a {0} KB", Reglas.Publicos.TamañoMaximoImagenes / 1000))
                     Exit Sub
                  End If
                  If rbtFrente.Checked Then
                     pcbChequeFrente.Image = New Bitmap(Me.ofdArchivos.FileName)
                     DirectCast(_entidad, Entidades.Cheque).FotoFrente = pcbChequeFrente.Image
                  Else
                     PcbChequeDorso.Image = New Bitmap(ofdArchivos.FileName)
                     DirectCast(_entidad, Entidades.Cheque).FotoDorso = PcbChequeDorso.Image
                  End If

               End If
            End If
         End Sub)
   End Sub

   Private Sub tsbGuardar_Click(sender As Object, e As EventArgs) Handles tsbGuardar.Click
      TryCatched(
         Sub()
            Using saveFileDialog1 As New SaveFileDialog()
               saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
               saveFileDialog1.Title = "Save an Image File"
               saveFileDialog1.ShowDialog()

               ' If the file name is not an empty string open it for saving.
               If saveFileDialog1.FileName <> "" Then
                  ' Saves the Image via a FileStream created by the OpenFile method.
                  Using fs = saveFileDialog1.OpenFile()
                     ' Saves the Image in the appropriate ImageFormat based upon the
                     ' file type selected in the dialog box.
                     ' NOTE that the FilterIndex property is one-based.
                     Select Case saveFileDialog1.FilterIndex
                        Case 1
                           If rbtFrente.Checked Then
                              pcbChequeFrente.Image.Save(fs, Imaging.ImageFormat.Jpeg)
                           Else
                              PcbChequeDorso.Image.Save(fs, Imaging.ImageFormat.Jpeg)
                           End If
                     End Select

                     fs.Close()
                  End Using
                  ShowMessage("La imagen fue guardada con éxito")
               End If
            End Using
         End Sub)
   End Sub

   Private Sub tsbLimpiar_Click(sender As Object, e As EventArgs) Handles tsbLimpiar.Click
      TryCatched(
         Sub()
            If rbtFrente.Checked Then
               DirectCast(_entidad, Entidades.Cheque).FotoFrente = Nothing
               pcbChequeFrente.Image = Nothing
            Else
               DirectCast(_entidad, Entidades.Cheque).FotoDorso = Nothing
               PcbChequeDorso.Image = Nothing
            End If
         End Sub)
   End Sub
#End Region

#End Region

#Region "Metodos"
   Private Sub CargarLocalidad(dr As DataGridViewRow)
      DirectCast(_entidad, Entidades.Cheque).Localidad.IdLocalidad = Integer.Parse(dr.Cells("IdLocalidad").Value.ToString())
      bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()

      dtpFechaEmision.Select()

   End Sub

   Private Sub CargarDatosCuentaDeCaja(dr As DataGridViewRow)

      bscCuentaCaja.Text = dr.Cells("IdCuentaCaja").Value.ToString()
      bscNombreCuentaCaja.Text = dr.Cells("NombreCuentaCaja").Value.ToString()
      txtTipoMovimiento.Text = dr.Cells("IdTipoCuenta").Value.ToString()

      If _utilizaCentroCostos Then
         cmbCentroCosto.SelectedValue = dr.Cells(Entidades.CuentaDeCaja.Columnas.IdCentroCosto.ToString()).Value
      End If

      If _utilizaCentroCostos Then
         cmbCentroCosto.Focus()
      Else
         txtObservaciones.Focus()
      End If

   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      bscProveedor.Enabled = False
      bscCodigoProveedor.Enabled = False
   End Sub
#End Region

End Class