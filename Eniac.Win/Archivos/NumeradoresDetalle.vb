Option Strict On
Option Explicit On
Public Class NumeradoresDetalle
   Private _publicos As Publicos

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Eniac.Entidades.Numerador)
      Me.New()
      Me._entidad = entidad
   End Sub

#End Region

   Public ReadOnly Property Numerador() As Entidades.Numerador
      Get
         Return DirectCast(Me._entidad, Entidades.Numerador)
      End Get
   End Property


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Win.StateForm.Insertar Then
            
         Else

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.Numeradores()
   End Function

   'Protected Overrides Function ValidarDetalle() As String

   '   MyBase.ValidarDetalle()

   '   Return String.Empty
   'End Function

#End Region

End Class