Public Class TiposImpuestosDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private ReadOnly Property TipoImpuesto As Entidades.TipoImpuesto
      Get
         Return DirectCast(_entidad, Entidades.TipoImpuesto)
      End Get
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.TipoImpuesto)
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

         If StateForm = Win.StateForm.Insertar Then

         Else

            bscCuentaCaja.Text = TipoImpuesto.IdCuentaCaja.ToString
            If bscCuentaCaja.Text <> "0" Then
               bscCuentaCaja.PresionarBoton()
            End If

            If Reglas.Publicos.TieneModuloContabilidad Then
               UcCuentasCompras.Cuenta = TipoImpuesto.CuentaCompras
               UcCuentasVentas.Cuenta = TipoImpuesto.CuentaVentas
            Else
               UcCuentasCompras.Visible = False
               UcCuentasVentas.Visible = False
            End If

         End If

         BindearControles(_entidad)
      End Sub)

   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposImpuestos()
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If txtTipo.Text = "RETENCION" And Not bscCuentaCaja.Selecciono And Not bscNombreCuentaCaja.Selecciono Then
         Return "Debe ingresar la Cuenta de Caja"
         bscCuentaCaja.Focus()
      End If

      If Reglas.Publicos.TieneModuloContabilidad Then
         If UcCuentasCompras.Cuenta Is Nothing OrElse UcCuentasCompras.Cuenta.IdCuenta = 0 Then
            UcCuentasCompras.Focus()
            Return "Debe indicar una cuenta contable para Compras."
         End If
         If UcCuentasVentas.Cuenta Is Nothing OrElse UcCuentasVentas.Cuenta.IdCuenta = 0 Then
            UcCuentasVentas.Focus()
            Return "Debe indicar una cuenta contable para Ventas."
         End If
      End If

      Return MyBase.ValidarDetalle()
   End Function
   Protected Overrides Sub Aceptar()
      TipoImpuesto.IdCuentaCaja = bscCuentaCaja.Text.ValorNumericoPorDefecto(0I)

      If Reglas.Publicos.TieneModuloContabilidad Then
         TipoImpuesto.CuentaCompras = UcCuentasCompras.Cuenta
         TipoImpuesto.CuentaVentas = UcCuentasVentas.Cuenta
      Else
         TipoImpuesto.CuentaCompras = Nothing
         TipoImpuesto.CuentaVentas = Nothing
      End If

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdTipoImpuesto.Focus()
   End Sub

#Region "Eventos Buscador Cuenta Caja"
   Private Sub bscCuentaCaja_BuscadorClick() Handles bscCuentaCaja.BuscadorClick
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
   Private Sub bscCuentaCaja_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaCaja.BuscadorSeleccion, bscNombreCuentaCaja.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCuentaDeCaja(e.FilaDevuelta))
   End Sub
#End Region

#End Region

#Region "Metodos"
   Private Sub CargarDatosCuentaDeCaja(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreCuentaCaja.Text = dr.Cells("NombreCuentaCaja").Value.ToString()
         bscCuentaCaja.Text = dr.Cells("IdCuentaCaja").Value.ToString()
      End If
   End Sub

#End Region

End Class