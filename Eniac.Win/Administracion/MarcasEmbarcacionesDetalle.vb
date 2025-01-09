Public Class MarcasEmbarcacionesDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.MarcaEmbarcacion)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      TryCatched(Sub() _tituloNuevo = "Nueva")
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         BindearControles(_entidad)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            CargarProximoCodigo()
         End If
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MarcasEmbarcaciones()
   End Function

   'Protected Overrides Function ValidarDetalle() As String

   '   'If Math.Abs(Decimal.Parse(Me.txtDescuentoRecargo.Text)) >= 100 Then
   '   '   Return "El Descuento/Recargo NO es Válido."
   '   'End If

   '   Return MyBase.ValidarDetalle()

   'End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not HayError Then Close()
      txtIdMarcaEmbarcacion.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      Dim proxima = New Reglas.MarcasEmbarcaciones().GetCodigoMaximo() + 1
      txtIdMarcaEmbarcacion.Text = proxima.ToString()
   End Sub

#End Region

End Class