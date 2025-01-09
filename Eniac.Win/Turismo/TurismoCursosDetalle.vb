Public Class TurismoCursosDetalle

#Region "Constructores"
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Eniac.Entidades.TurismoCurso)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Campos"

   Private _publicos As Reglas.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Reglas.Publicos

         Me.BindearControles(Me._entidad, Me._liSources)

         ' I
         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.txtIdCurso.Text = (DirectCast(GetReglas(), Reglas.TurismoCursos).GetCodigoMaximo() + 1).ToString()
         Else ' U
            Me.txtIdCurso.Enabled = False
            Me.txtNombreCurso.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TurismoCursos()
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