Public Class CRMCiclosPlanificacionDetalle

   Private _publicos As Publicos

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.CRMCicloPlanificacion)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

   Private ReadOnly Property CicloPlanificacion As Entidades.CRMCicloPlanificacion
      Get
         Return DirectCast(_entidad, Entidades.CRMCicloPlanificacion)
      End Get
   End Property

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
      Sub()
         _publicos = New Publicos()
         _publicos.CargaComboCRMEstadosCiclosPlanificacion(cmbEstadoCicloPlanificacion)

         _liSources.Add("EstadoCicloPlanificacion", CicloPlanificacion.EstadoCicloPlanificacion)

         BindearControles(_entidad, _liSources)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdCicloPlanificacion.SetValor(GetRegla().GetProximoCodigo())
            pnlUsuarios.Visible = False
         Else

         End If

      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return GetRegla()
   End Function
   Private Function GetRegla() As Reglas.CRMCiclosPlanificacion
      Return New Reglas.CRMCiclosPlanificacion()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      If cmbEstadoCicloPlanificacion.SelectedIndex = -1 Then
         cmbEstadoCicloPlanificacion.Focus()
         Return "Debe seleccionar un Estado."
      End If
      Return MyBase.ValidarDetalle()
   End Function

#End Region

End Class