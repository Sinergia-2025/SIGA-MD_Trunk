Public Class CuentasDeCajasDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _publicosCont As ContabilidadPublicos
   Private _generaContabilidadTemporal As Boolean

#End Region

   Public ReadOnly Property CuentaDeCaja As Entidades.CuentaDeCaja
      Get
         Return DirectCast(Me._entidad, Entidades.CuentaDeCaja)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.CuentaDeCaja)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      TryCatched(
         Sub()
            _publicos = New Publicos()
            _tituloNuevo = "Nueva"
         End Sub)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos.CargaComboAFIPConceptoCM05(cmbAFIPConceptoCM05, tipo:=Nothing)

            BindearControles(_entidad)

            _publicosCont = New ContabilidadPublicos()

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               CargarProximoNumero()
               CuentaDeCaja.Usuario = actual.Nombre
               CuentaDeCaja.IdTipoCuenta = "E"
               chbGeneraContabilidad.Checked = True
            Else
               'Predeterminado esta chequeado el Egreso.
               If CuentaDeCaja.IdTipoCuenta = "I" Then
                  optIngreso.Checked = True
               End If

               If Reglas.Publicos.TieneModuloContabilidad Then
                  _generaContabilidadTemporal = CuentaDeCaja.GeneraContabilidad

                  If bscCodCuenta.Text <> "0" Then
                     bscCodCuenta.PresionarBoton()
                  End If
                  If Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
                     If CuentaDeCaja.IdCentroCosto.HasValue Then
                        bscCodigoCentroCosto.Text = CuentaDeCaja.IdCentroCosto.Value.ToString()
                        bscCodigoCentroCosto.PresionarBoton()
                     End If
                  End If
               End If

               chbAFIPConceptoCM05.Checked = CuentaDeCaja.IdConceptoCM05.HasValue

               If Not Reglas.Publicos.AFIPUtilizaCM05 Then
                  chbAFIPConceptoCM05.Checked = False
                  chbAFIPConceptoCM05.Enabled = False
               End If

            End If

            gpoContabilidad.Visible = Reglas.Publicos.TieneModuloContabilidad
            bscCodigoCentroCosto.Visible = Reglas.ContabilidadPublicos.UtilizaCentroCostos
            bscNombreCentroCosto.Visible = bscCodigoCentroCosto.Visible
            lblCentroCostos.Visible = bscCodigoCentroCosto.Visible

            If New Reglas.Publicos().ExisteParametroCuenta(txtCodigo.Text, "CAJA") Then
               txtNombre.Enabled = False
               optEgreso.Enabled = False
               optIngreso.Enabled = False
            End If

            _estaCargando = False
         End Sub)

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CuentasDeCajas()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If Integer.Parse(txtCodigo.Text) <= 0 Then
         txtCodigo.Focus()
         Return "Debe ingresar un Código de Cuenta positivo"
      End If

      '# Validar que la cuenta seleccionada no haya generado movimientos previos en caja, de ser así no se debe permitir cambiar éste valor de TRUE > FALSE
      If Reglas.Publicos.TieneModuloContabilidad Then
         If Not chbGeneraContabilidad.Checked AndAlso
            chbGeneraContabilidad.Checked <> _generaContabilidadTemporal Then
            If TieneMovimientosEnCaja(CuentaDeCaja.IdCuentaCaja) Then
               Return "Esta cuenta ya posee movimientos de caja realizados. No puede desactivarse la generación de contabilidad."
            End If
         End If
      End If

      If chbAFIPConceptoCM05.Checked And cmbAFIPConceptoCM05.SelectedIndex = -1 Then
         cmbAFIPConceptoCM05.Select()
         Return "ATENCION: Activo el Concepto de CM05 pero no seleccionó uno. Debe elegir una."
      End If

      Return String.Empty
   End Function

   Protected Overrides Sub Aceptar()
      If Reglas.Publicos.TieneModuloContabilidad Then
         CuentaDeCaja.IdCuentaContable = Long.Parse(Me.bscCodCuenta.Text)
         If Reglas.ContabilidadPublicos.UtilizaCentroCostos AndAlso IsNumeric(bscCodigoCentroCosto.Text) Then
            CuentaDeCaja.CentroCosto = New Reglas.ContabilidadCentrosCostos().GetUna(Integer.Parse(bscCodigoCentroCosto.Text))
         Else
            CuentaDeCaja.CentroCosto = Nothing
         End If
      Else
         CuentaDeCaja.IdCuentaContable = 0
         CuentaDeCaja.CentroCosto = Nothing
      End If

      CuentaDeCaja.IdConceptoCM05 = cmbAFIPConceptoCM05.ValorSeleccionado(Of Integer?)(chbAFIPConceptoCM05, Nothing)

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub optIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles optIngreso.CheckedChanged
      TryCatched(
         Sub()
            If _estaCargando Then Exit Sub
            CuentaDeCaja.IdTipoCuenta = If(optIngreso.Checked, "I", "E")
         End Sub)
   End Sub

   Private Sub optEgreso_CheckedChanged(sender As Object, e As EventArgs) Handles optEgreso.CheckedChanged
      TryCatched(
         Sub()
            If _estaCargando Then Exit Sub
            CuentaDeCaja.IdTipoCuenta = If(optIngreso.Checked, "I", "E")
         End Sub)
   End Sub

   Private Sub chbAFIPConceptoCM05_CheckedChanged(sender As Object, e As EventArgs) Handles chbAFIPConceptoCM05.CheckedChanged
      TryCatched(
        Sub()
           If Not chbAFIPConceptoCM05.Checked Then
              cmbAFIPConceptoCM05.SelectedIndex = -1
              CuentaDeCaja.IdConceptoCM05 = Nothing
           End If

           cmbAFIPConceptoCM05.Enabled = chbAFIPConceptoCM05.Checked

           If chbAFIPConceptoCM05.Checked Then
              cmbAFIPConceptoCM05.Select()
           End If
        End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
        Sub()
           If Not HayError Then Close()

           'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
           '   Me.CargarProximoNumero()
           'End If

           txtCodigo.Focus()
        End Sub)
   End Sub

#Region "Buscadores Cuenta Contable"

   Private Sub bsccodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick
      TryCatched(
        Sub()
           _publicos.PreparaGrillaCuentasContables(bscCodCuenta)
           bscCodCuenta.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXCodigo(bscCodCuenta.Text.ValorNumericoPorDefecto(0L))
        End Sub)
   End Sub
   Private Sub bscDescripcion_BuscadorClick() Handles bscDescCuenta.BuscadorClick
      TryCatched(
        Sub()
           _publicos.PreparaGrillaCuentasContables(bscDescCuenta)
           bscDescCuenta.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXNombre(bscDescCuenta.Text.Trim())
        End Sub)
   End Sub
   Private Sub bscCodCuenta_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodCuenta.BuscadorSeleccion, bscDescCuenta.BuscadorSeleccion
      TryCatched(
        Sub()
           If e.FilaDevuelta IsNot Nothing Then
              bscDescCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
              bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()
           End If
        End Sub)
   End Sub

#End Region

#Region "Buscador Centro de Costos"
   Private Sub bscCodigoCentroCosto_BuscadorClick() Handles bscCodigoCentroCosto.BuscadorClick
      TryCatched(
        Sub()
           _publicos.PreparaGrillaCentroCosto(bscCodigoCentroCosto)
           bscCodigoCentroCosto.Datos = New Reglas.ContabilidadCentrosCostos().GetPorCodigo(bscCodigoCentroCosto.Text.ValorNumericoPorDefecto(0I))
        End Sub)
   End Sub
   Private Sub bscNombreCentroCosto_BuscadorClick() Handles bscNombreCentroCosto.BuscadorClick
      TryCatched(
        Sub()
           _publicos.PreparaGrillaCentroCosto(bscNombreCentroCosto)
           bscNombreCentroCosto.Datos = New Reglas.ContabilidadCentrosCostos().GetPorNombre(bscNombreCentroCosto.Text)
        End Sub)
   End Sub
   Private Sub bscCentroCosto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCentroCosto.BuscadorSeleccion, bscNombreCentroCosto.BuscadorSeleccion
      TryCatched(
        Sub()
           If e.FilaDevuelta IsNot Nothing Then
              bscCodigoCentroCosto.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Value.ToString()
              bscNombreCentroCosto.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Value.ToString()
           End If
        End Sub)
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Function TieneMovimientosEnCaja(idCuentaCaja As Integer) As Boolean
      Return New Reglas.CajaDetalles().TieneMovimientosEnCaja(idCuentaCaja)
   End Function

   Private Sub CargarProximoNumero()
      txtCodigo.Text = (New Reglas.CuentasDeCajas().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class