Option Strict Off
Imports Infragistics.Win.UltraWinGrid
Public Class TiposListasMetasDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.TipoListaMeta)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      _publicos = New Publicos()
      _publicos.CargaComboTiposListasControl(cmbTipoListaControl)
      _publicos.CargaComboUsuarios(cmbSolicitante)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then

         Me.dtpMes.Value = Date.Today()

         '  Me.CargarProximoNumero()

      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposListasMetas()
   End Function

   Protected Overrides Function ValidarDetalle() As String


      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      ' DirectCast(Me._entidad, Entidades.TipoListaMeta).Mes = dtpMes.Value.ToString("MM/yyyy")
      DirectCast(Me._entidad, Entidades.TipoListaMeta).IdUsuario = actual.Nombre
      DirectCast(Me._entidad, Entidades.TipoListaMeta).FechaModificacion = Date.Now
      MyBase.Aceptar()

   End Sub


#End Region

#Region "Eventos"




#End Region

End Class