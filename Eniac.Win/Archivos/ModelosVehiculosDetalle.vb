Public Class ModelosVehiculosDetalle

#Region "Campos"
   Private _Publicos As Publicos
   Public IdMarca As Integer = 0
   Public IdModelo As Integer
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.ModeloVehiculo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      _Publicos = New Eniac.Win.Publicos()
      '-- REQ-33388.- -----------------------------------------------
      _Publicos.CargaComboMarcaVehiculo(Me.cmbNombreMarca)
      'seteo el primero del combo para que no molesto el campo nuevo
      If cmbNombreMarca.Items.Count > 0 Then
         cmbNombreMarca.SelectedIndex = -1
      End If

      BindearControles(Me._entidad, _liSources)

      If StateForm = Eniac.Win.StateForm.Insertar Then
         txtIdModelosVehiculos.Text = (DirectCast(GetReglas(), Reglas.ModelosVehiculos).GetCodigoMaximo() + 1).ToString()
         If IdMarca <> 0 Then
            cmbNombreMarca.SelectedValue = IdMarca
         End If
      End If

   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ModelosVehiculos()
   End Function
#End Region

End Class