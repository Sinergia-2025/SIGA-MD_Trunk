Option Strict On
Option Explicit On
Public Class FeriadosDetalle
   Private _publicos As Publicos

   Public ReadOnly Property Feriado As Entidades.Feriado
      Get
         Return DirectCast(_entidad, Entidades.Feriado)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.Feriado)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Eventos"
   Private Sub dtpFechaFeriado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreFeriado.KeyDown, dtpFechaFeriado.KeyDown
      PresionarTab(e)
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            dtpFechaFeriado.Value = Today
         Else

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Feriados()
   End Function

   Protected Overrides Sub Aceptar()

      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      Return MyBase.ValidarDetalle()
   End Function

#End Region

End Class