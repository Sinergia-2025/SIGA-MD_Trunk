Public Class TurismoTurnosDetalle

#Region "Constructores"
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Eniac.Entidades.TurismoTurno)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos

         Me.BindearControles(Me._entidad, Me._liSources)

         ' I
         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.txtIdTurno.Text = (DirectCast(GetReglas(), Reglas.TurismoTurnos).GetCodigoMaximo() + 1).ToString()
         Else ' U
            Me.txtIdTurno.Enabled = False
            Me.txtNombreTurno.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TurismoTurnos()
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