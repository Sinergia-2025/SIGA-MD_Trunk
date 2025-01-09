Public Class FormasDePagoDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _ConfiguracionImpresoras As Boolean = False
   Private _ConfiguracionImpresorasFR As Boolean = False

   Public ReadOnly Property FormaPago() As Entidades.VentaFormaPago
      Get
         Return DirectCast(_entidad, Entidades.VentaFormaPago)
      End Get
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.VentaFormaPago)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboDesdeEnum(cmbFechaBaseProximaCuota, GetType(Entidades.VentaFormaPago.ProximaCuota))
            cmbListaDePrecios.SelectedIndex = -1

            _publicos.CargaComboListaDePrecios(cmbListaDePrecios)
            If FormaPago.IdListaPrecios.HasValue Then
               chbListaDePrecios.Checked = True
            End If

            '-- REQ-33409.- -------------------------------------------------------------
            _publicos.CargaComboTiposComprobantes(cmbTipoComprobantes, MiraPC:=False, "VENTAS", , , , UsaFacturacion:=True)
            If cmbTipoComprobantes.Items.Count = 0 Then
               _ConfiguracionImpresoras = True
            End If

            _publicos.CargaComboTiposComprobantes(cmbTipoComprobantesFR, MiraPC:=False, "VENTAS", , , UsaFacturacionRapida:="SI", UsaFacturacion:=True)
            If cmbTipoComprobantesFR.Items.Count = 0 Then
               _ConfiguracionImpresorasFR = True
            End If
            '-----------------------------------------------------------------------------

            If Not IsNothing(FormaPago.IdTipoComprobantes) Then
               chbTipoComprobante.Checked = True
            End If
            If Not IsNothing(FormaPago.IdTipoComprobantesFR) Then
               chbTipoComprobanteFR.Checked = True
            End If

            BindearControles(_entidad, _liSources)

            FormaPago.Usuario = actual.Nombre

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               CargarProximoNumero()
            Else
               If FormaPago.IdCuentaBancariaEfectivo.IfNull(0) <> 0 Then
                  chbCuentaBancaria.Checked = True
                  bscCodigoCuentaBancariaTransfBanc.Text = FormaPago.IdCuentaBancariaEfectivo.ToString()
                  bscCodigoCuentaBancariaTransfBanc.Visible = True
                  bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
                  bscCodigoCuentaBancariaTransfBanc.Visible = False
               End If
            End If

            If Not Reglas.Publicos.TieneModuloFichas Then
               lblOrdenFichas.Visible = False
               txtOrdenFichas.Visible = False
            End If
            '-- REQ-35955.- -------------------------------------------------------------------------------------------------------------
            chbArchivoComplementario.Checked = Not String.IsNullOrEmpty(DirectCast(_entidad, Entidades.VentaFormaPago).ArchivoComplementario)
            '----------------------------------------------------------------------------------------------------------------------------
         End Sub)

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.VentasFormasPago()
   End Function

   Protected Overrides Sub Aceptar()

      If Not chbListaDePrecios.Checked Then
         FormaPago.IdListaPrecios = Nothing
      End If
      FormaPago.IdCuentaBancariaEfectivo = If(chbCuentaBancaria.Checked, bscCodigoCuentaBancariaTransfBanc.Text.ValorNumericoPorDefecto(0I), DirectCast(Nothing, Integer?))

      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      Dim vacio = String.Empty
      If cmbFechaBaseProximaCuota.SelectedIndex < 0 Then
         cmbFechaBaseProximaCuota.Select()
         Return String.Format("Debe seleccionar una {0}", lblFechaBaseProximaCuota.Text)
      End If
      If chbCuentaBancaria.Checked And Not bscCodigoCuentaBancariaTransfBanc.Selecciono And Not bscCuentaBancariaTransfBanc.Selecciono Then
         bscCuentaBancariaTransfBanc.Select()
         Return String.Format("Debe seleccionar una Cuenta Bancaria")
      End If
      Return vacio
   End Function

#End Region

#Region "Eventos"

   'Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
   '   If Me.StateForm = Eniac.Win.StateForm.Insertar And Not HayError Then
   '      'Me.CargarProximoNumero()
   '      'Me.cmbLocalidad.SelectedIndex = -1
   '      'Me.chbAsociaSucursal.Checked = False
   '      Close()
   '   End If
   '   txtDescripcionFormasPago.Select()
   'End Sub

   Private Sub chbListaDePrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaDePrecios.CheckedChanged
      TryCatched(Sub() chbListaDePrecios.FiltroCheckedChanged(cmbListaDePrecios))
   End Sub
   '-- REQ-33317.- --
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTipoComprobantes))
   End Sub
   '-- REQ-33409.- --
   Private Sub chbTipoComprobanteFR_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobanteFR.CheckedChanged
      TryCatched(Sub() chbTipoComprobanteFR.FiltroCheckedChanged(cmbTipoComprobantesFR))
   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaTransfBanc)
            bscCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBanc.Text.Trim(), Entidades.Moneda.Peso)
         End Sub)
   End Sub
   Private Sub bscCodigoCuentaBancariaTransfBanc_BuscadorClick() Handles bscCodigoCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCodigoCuentaBancariaTransfBanc)
            bscCodigoCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorCodigo(bscCodigoCuentaBancariaTransfBanc.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion, bscCodigoCuentaBancariaTransfBanc.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCodigoCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()

               bscCuentaBancariaTransfBanc.Permitido = False
               bscCodigoCuentaBancariaTransfBanc.Permitido = False

               'bscCuentaBancariaTransfBanc.Tag = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               ProcessTabKey(True)
            End If
         End Sub)
   End Sub

   Private Sub chbCuentaBancaria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCuentaBancaria.CheckedChanged
      TryCatched(Sub() chbCuentaBancaria.FiltroCheckedChanged(usaPermitido:=True, bscCuentaBancariaTransfBanc))
   End Sub

   '-- REQ-33409.- --
   Private Sub FormasDePagoDetalle_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      Try
         If _ConfiguracionImpresoras Then
            '-- Deshabilita los Check.- ---
            chbTipoComprobante.Checked = False
            cmbTipoComprobantes.Enabled = False
            cmbTipoComprobantes.SelectedIndex = -1
         End If
         If _ConfiguracionImpresorasFR Then
            '-- Deshabilita los Check.- ---
            chbTipoComprobanteFR.Checked = False
            cmbTipoComprobantesFR.Enabled = False
            cmbTipoComprobantesFR.SelectedIndex = -1
         End If
      Catch ex As Exception

      End Try
   End Sub
   '-- REQ-35955.- ----------------------------------------------------------------------------------------------------------------------
   Private Sub chbArchivoComplementario_CheckedChanged(sender As Object, e As EventArgs) Handles chbArchivoComplementario.CheckedChanged
      txtArchivoComplementario.Enabled = chbArchivoComplementario.Checked
      chbArchivoEmbebido.Enabled = chbArchivoComplementario.Checked
      If Not chbArchivoComplementario.Checked Then
         txtArchivoComplementario.Text = String.Empty
         chbArchivoEmbebido.Checked = False
      End If
   End Sub
   '------------------------------------------------------------------------------------------------------------------------------------

#End Region

#Region "Metodos"
   Private Sub CargarProximoNumero()
      txtIdFormasPago.Text = (New Reglas.VentasFormasPago().GetCodigoMaximo() + 1).ToString()
   End Sub


#End Region

End Class