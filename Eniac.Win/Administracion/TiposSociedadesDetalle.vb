Public Class TiposSociedadesDetalle
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(tipoSociedad As Entidades.TipoSociedad)
      Me.InitializeComponent()
      Me._entidad = tipoSociedad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Win.Publicos

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
      End If
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposSociedades()
   End Function
#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdTipoSociedad.Focus()
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarProximoNumero()
      Dim rTiposSociedades As Reglas.TiposSociedades = New Reglas.TiposSociedades()
      Dim proxId As Integer
      proxId = rTiposSociedades.GetCodigoMaximo() + 1
      Me.txtIdTipoSociedad.Text = proxId.ToString()
   End Sub
#End Region
End Class