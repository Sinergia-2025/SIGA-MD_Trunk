Public Class MarcasDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Marca)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Propiedades"

   Public Property IdMarca As String

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      BindearControles(_entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         CargarProximoNumero()
         DirectCast(_entidad, Entidades.Marca).Usuario = actual.Nombre
      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Marcas()
   End Function

   Protected Overrides Sub Aceptar()
      IdMarca = txtIdMarca.Text

      MyBase.Aceptar()

      If Not HayError Then Close()
   End Sub
   Protected Overrides Function ValidarDetalle() As String
      If txtDescuentoRecargo1.ValorNumericoPorDefecto(0D) <= -100 Or txtDescuentoRecargo1.ValorNumericoPorDefecto(0D) >= 100 Then
         txtDescuentoRecargo1.Focus()
         Return "El Descuento/Recargo 1 NO es Válido."
      End If
      If txtDescuentoRecargo2.ValorNumericoPorDefecto(0D) <= -100 Or txtDescuentoRecargo2.ValorNumericoPorDefecto(0D) >= 100 Then
         txtDescuentoRecargo2.Focus()
         Return "El Descuento/Recargo 2 NO es Válido."
      End If

      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not HayError Then Close()
      txtIdMarca.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      txtIdMarca.Text = (New Reglas.Marcas().GetCodigoMaximo() + 1).ToString("####0")
   End Sub

#End Region

   Private Sub txtIdMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdMarca.KeyPress, txtNombreMarca.KeyPress, txtComisionPorVenta.KeyPress, txtDescuentoRecargo1.KeyPress, txtDescuentoRecargo2.KeyPress
      PresionarTab(e)
   End Sub

End Class