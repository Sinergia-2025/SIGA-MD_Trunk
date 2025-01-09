Public Class TiposCalendariosDetalle
   Private _publicos As Publicos

   Public ReadOnly Property TipoCalendario As Entidades.TipoCalendario
      Get
         Return DirectCast(_entidad, Entidades.TipoCalendario)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Eniac.Entidades.TipoCalendario)
      Me.New()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then

         Else

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposCalendarios()
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


   Private Sub txtIdTipoCalendario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreTipoCalendario.KeyDown, txtIdTipoCalendario.KeyDown
      PresionarTab(e)
   End Sub

End Class