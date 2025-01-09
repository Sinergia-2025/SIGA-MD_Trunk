Public Class CategoriasCamasDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.CategoriaCama)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      Me._tituloNuevo = "Nueva"

      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoCodigo()
      End If

      If Publicos.CargosCalcularPor = "CAMA" Then
         Me.lblCantidadAccionesRequeridas.Visible = False
         Me.txtCantidadAccionesRequeridas.Visible = False
      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasCamas()
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

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdCategoriaCama.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      Dim oRegCategoriasCamas As Reglas.CategoriasCamas = New Reglas.CategoriasCamas()
      Dim ProximaCategoria As Integer
      ProximaCategoria = oRegCategoriasCamas.GetCodigoMaximo() + 1
      Me.txtIdCategoriaCama.Text = ProximaCategoria.ToString()
   End Sub

#End Region

End Class
