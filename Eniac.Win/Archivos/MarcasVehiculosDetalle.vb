Public Class MarcasVehiculosDetalle


#Region "Campos"
   Private _Publicos As Publicos
   Public idMarca As Integer
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.MarcaVehiculo)
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
         txtIdMarcaVehiculo.Text = (DirectCast(GetReglas(), Reglas.MarcasVehiculos).GetCodigoMaximo() + 1).ToString()
      End If

      '-- Recupera el Id de Marca.- ---
      idMarca = Integer.Parse(txtIdMarcaVehiculo.Text.ToString())

   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MarcasVehiculos()
   End Function
#End Region

End Class