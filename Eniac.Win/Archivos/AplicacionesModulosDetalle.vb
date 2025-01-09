Option Strict On
Option Explicit On
Public Class AplicacionesModulosDetalle

   Private ReadOnly Property Empresa As Entidades.AplicacionModulo
      Get
         Return DirectCast(Me._entidad, Entidades.AplicacionModulo)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.AplicacionModulo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
      End If

   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AplicacionesModulos()
   End Function
#End Region

#Region "Metodos"
   Private Sub CargarProximoNumero()
      Me.txtIdEmpresa.Text = (New Reglas.AplicacionesModulos().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class