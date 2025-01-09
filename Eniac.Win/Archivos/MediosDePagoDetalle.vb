Public Class MediosDePagoDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _publicosContabilidad As ContabilidadPublicos

#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.MedioDePago)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      TryCatched(
      Sub()
         If Reglas.Publicos.TieneModuloContabilidad Then
            Height = 280
         Else
            Height = 160
            Width = 380
            gpoContabilidad.Visible = False
         End If
      End Sub)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         _publicosContabilidad = New ContabilidadPublicos()

         BindearControles(_entidad)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            CargarProximoNumero()
         End If
         If Reglas.Publicos.TieneModuloContabilidad Then
            If bscCodCuenta.Text <> "0" Then
               bscCodCuenta.PresionarBoton()
            End If
         End If
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MediosdePago()
   End Function

   Protected Overrides Sub Aceptar()
      DirectCast(_entidad, Entidades.MedioDePago).IdCuenta = bscCodCuenta.Text.ValorNumericoPorDefecto(0I)
      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not HayError Then Close()
      txtIdMediodePago.Focus()
   End Sub

#Region "Eventos Buscador Cuenta"
   Private Sub bscCodCuenta_Leave(sender As Object, e As EventArgs) Handles bscCodCuenta.Leave
      TryCatched(Sub() If Not IsNumeric(bscCodCuenta.Text.Trim()) Then bscCodCuenta.Text = "0")
   End Sub
   Private Sub bscCodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick
      TryCatched(
      Sub()
         _publicosContabilidad.PreparaGrillaCuentas(bscCodCuenta)
         bscCodCuenta.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXCodigo(bscCodCuenta.Text.ValorNumericoPorDefecto(0L))
      End Sub)
   End Sub
   Private Sub bscDescCuenta_BuscadorClick() Handles bscDescCuenta.BuscadorClick
      TryCatched(
      Sub()
         _publicosContabilidad.PreparaGrillaCuentas(bscDescCuenta)
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
      txtIdMediodePago.Text = (New Reglas.MediosdePago().GetCodigoMaximo() + 1).ToString()
   End Sub
#End Region

End Class