Option Strict On
Option Explicit On
Public Class CategoriasAccionesDetalle
#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.CategoriaAccion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

   Private _publicos As Publicos

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Me._tituloNuevo = "Nueva"

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoCodigo()
      End If
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasAcciones()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdCategoriaAccion.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      Dim rCategoriasAcciones As Reglas.CategoriasAcciones = New Reglas.CategoriasAcciones()
      Dim ProximaCategoria As Integer
      ProximaCategoria = rCategoriasAcciones.GetCodigoMaximo() + 1
      Me.txtIdCategoriaAccion.Text = ProximaCategoria.ToString()
   End Sub

#End Region

   Private Sub txtCoeficienteDistribucionExpensas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPies.KeyDown, txtNombreCategoriaAccion.KeyDown, txtIdCategoriaAccion.KeyDown, txtCoeficienteDistribucionExpensas.KeyDown
      PresionarTab(e)
   End Sub
End Class