Option Strict On
Option Explicit On
Public Class EmpresasDetalle

   Private ReadOnly Property Empresa As Entidades.Empresa
      Get
         Return DirectCast(Me._entidad, Entidades.Empresa)
      End Get
   End Property

   Private _publicos As Publicos
#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.Empresa)
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
      Return New Reglas.Empresas()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If Me.txtCuitEmpresa.Text = String.Empty Then
         Return "No ingreso un número de CUIT "
      End If

      If Me.txtCuitEmpresa.Text.Length <> 11 Then
         Return "El número de CUIT ingresado es inválido, deben ser 11 caracteres y posee "
      End If

      If Not Publicos.EsCuitValido(Me.txtCuitEmpresa.Text) Then
         Return "El número de CUIT ingresado es inválido."
         Me.txtCuitEmpresa.Focus()
      End If

      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Metodos"
   Private Sub CargarProximoNumero()
      Me.txtIdEmpresa.Text = (New Reglas.Empresas().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class