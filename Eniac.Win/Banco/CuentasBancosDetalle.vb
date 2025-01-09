Public Class CuentasBancosDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _publicosCont As ContabilidadPublicos

#End Region

   Public ReadOnly Property CuentaBanco As Entidades.CuentaBanco
      Get
         Return DirectCast(Me._entidad, Entidades.CuentaBanco)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Entidad)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      TryCatched(
         Sub()
            _publicos = New Publicos()
            _publicosCont = New ContabilidadPublicos()
            _tituloNuevo = "Nueva"
         End Sub)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos.CargaComboAFIPConceptoCM05(cmbAFIPConceptoCM05, tipo:=Nothing)

            BindearControles(_entidad)

            If Reglas.Publicos.TieneModuloContabilidad Then
               gpoContabilidad.Visible = True
               'Width = 576
               'Height = 370
               If bscCodCuenta.Text <> "0" Then
                  bscCodCuenta.PresionarBoton()
               End If
            Else
               gpoContabilidad.Visible = False
               'Width = 428
               'Height = 250

            End If

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               CargarProximoNumero()
               CuentaBanco.Usuario = actual.Nombre
               CuentaBanco.IdTipoCuenta = "I"
            Else
               'Predeterminado esta chequeado el Ingreso.
               If CuentaBanco.IdTipoCuenta = "E" Then
                  optEgreso.Checked = True
               End If

               If Reglas.Publicos.TieneModuloContabilidad Then
                  'If Me.bscCodCuenta.Text <> "0" Then
                  '   Me.bscCodCuenta.PresionarBoton()
                  'End If
                  If Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
                     If CuentaBanco.IdCentroCosto.HasValue Then
                        bscCodigoCentroCosto.Text = CuentaBanco.IdCentroCosto.Value.ToString()
                        bscCodigoCentroCosto.PresionarBoton()
                     End If
                  End If
               End If

               chbAFIPConceptoCM05.Checked = CuentaBanco.IdConceptoCM05.HasValue

            End If

            If Not Reglas.Publicos.AFIPUtilizaCM05 Then
               chbAFIPConceptoCM05.Checked = False
               chbAFIPConceptoCM05.Enabled = False
            End If

            If New Reglas.Publicos().ExisteParametroCuenta(txtCodigo.Text, "BANCO") Then
               txtNombre.Enabled = False
               optEgreso.Enabled = False
               optIngreso.Enabled = False
            End If

            bscCodigoCentroCosto.Visible = Reglas.ContabilidadPublicos.UtilizaCentroCostos
            bscNombreCentroCosto.Visible = bscCodigoCentroCosto.Visible
            lblCentroCostos.Visible = bscCodigoCentroCosto.Visible

            _estaCargando = False
         End Sub)

   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CuentasBancos()
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If txtCodigo.ValorNumericoPorDefecto(0I) <= 0 Then
         txtCodigo.Select()
         Return "Debe ingresar un Código de Cuenta positivo"
      End If

      If chbAFIPConceptoCM05.Checked And cmbAFIPConceptoCM05.SelectedIndex = -1 Then
         cmbAFIPConceptoCM05.Select()
         Return "ATENCION: Activo el Concepto de CM05 pero no seleccionó uno. Debe elegir una."
      End If

      Return String.Empty
   End Function

   Protected Overrides Sub Aceptar()
      If Reglas.Publicos.TieneModuloContabilidad Then
         CuentaBanco.IdCuentaContable = CInt(Me.bscCodCuenta.Text)
         If Reglas.ContabilidadPublicos.UtilizaCentroCostos AndAlso IsNumeric(bscCodigoCentroCosto.Text) Then
            CuentaBanco.CentroCosto = New Reglas.ContabilidadCentrosCostos().GetUna(Integer.Parse(bscCodigoCentroCosto.Text))
         Else
            CuentaBanco.CentroCosto = Nothing
         End If
      Else
         CuentaBanco.IdCuentaContable = 0
         CuentaBanco.CentroCosto = Nothing
      End If

      CuentaBanco.IdConceptoCM05 = cmbAFIPConceptoCM05.ValorSeleccionado(Of Integer?)(chbAFIPConceptoCM05, Nothing)

      MyBase.Aceptar()
   End Sub



#End Region

#Region "Eventos"

   Private Sub optIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles optIngreso.CheckedChanged
      TryCatched(
         Sub()
            If _estaCargando Then Exit Sub
            CuentaBanco.IdTipoCuenta = If(optIngreso.Checked, "I", "E")
         End Sub)
   End Sub

   Private Sub optEgreso_CheckedChanged(sender As Object, e As EventArgs) Handles optEgreso.CheckedChanged
      TryCatched(
         Sub()
            If _estaCargando Then Exit Sub
            CuentaBanco.IdTipoCuenta = If(optIngreso.Checked, "I", "E")
         End Sub)
   End Sub

   Private Sub chbAFIPConceptoCM05_CheckedChanged(sender As Object, e As EventArgs) Handles chbAFIPConceptoCM05.CheckedChanged

      If Not chbAFIPConceptoCM05.Checked Then
         cmbAFIPConceptoCM05.SelectedIndex = -1
         CuentaBanco.IdConceptoCM05 = Nothing
      End If

      cmbAFIPConceptoCM05.Enabled = chbAFIPConceptoCM05.Checked

      If chbAFIPConceptoCM05.Checked Then
         cmbAFIPConceptoCM05.Select()
      End If
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

#Region "Buscadores Cuenta Contable"

   Private Sub bscCodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick
      TryCatched(
         Sub()
            _publicosCont.PreparaGrillaCuentas(bscCodCuenta)
            bscCodCuenta.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXCodigo(bscCodCuenta.Text.ValorNumericoPorDefecto(0L))
         End Sub)
   End Sub
   Private Sub bscDescCuenta_BuscadorClick() Handles bscDescCuenta.BuscadorClick
      TryCatched(
         Sub()
            _publicosCont.PreparaGrillaCuentas(bscDescCuenta)
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

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      txtCodigo.Text = (New Reglas.CuentasBancos().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class