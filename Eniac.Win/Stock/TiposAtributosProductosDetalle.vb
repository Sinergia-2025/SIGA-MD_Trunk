#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class TiposAtributosProductosDetalle

#Region "Campos"
   Private _Publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.TipoAtributoProducto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me._Publicos = New Eniac.Win.Publicos()
      Me.BindearControles(Me._entidad, _liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         txtId.Text = (DirectCast(GetReglas(), Reglas.TiposAtributosProductos).GetCodigoMaximo() + 1).ToString()
      End If
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposAtributosProductos()
   End Function
#End Region

#Region "Eventos"

#End Region

#Region "Metodos"

#End Region

End Class