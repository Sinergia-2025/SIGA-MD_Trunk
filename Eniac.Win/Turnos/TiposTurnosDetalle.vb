Public Class TiposTurnosDetalle
   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)

   Public ReadOnly Property TipoTurno As Entidades.TipoTurno
      Get
         Return DirectCast(_entidad, Entidades.TipoTurno)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.TipoTurno)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         _publicos.CargaComboTiposCalendarios(cmbTipoCalendario)

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then

         Else

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposTurnos()
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


   Private Sub txtIdTipoTurno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreTipoTurno.KeyDown, txtIdTipoTurno.KeyDown, cmbTipoCalendario.KeyDown
      PresionarTab(e)
   End Sub
End Class