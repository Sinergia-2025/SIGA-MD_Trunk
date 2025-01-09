#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class ClasificacionesDetalle

#Region "Campos"
   Private _Publicos As Publicos
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.Clasificacion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._Publicos = New Eniac.Win.Publicos()

      BindearControles(Me._entidad, _liSources)

      '-- REQ-32957.- --------------------------------------------------
      CargarProximoCodigo()

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Clasificaciones()
   End Function

#End Region

#Region "Eventos"

#End Region

#Region "Metodos"
   '-- REQ-32957.- --------------------------------------------------
   Private Sub CargarProximoCodigo()

      Dim rClasificaciones = New Reglas.Clasificaciones()
      Dim proxClasificacion As Long

      proxClasificacion = rClasificaciones.GetCodigoMaximo() + 1
      Me.txtIdCalificacion.Text = proxClasificacion.ToString()

   End Sub
#End Region

End Class