Public Class MRPNormasFabricacionDetalle
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.MRPNormaFabricacion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      _publicos = New Publicos()

      BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         CargarProximoNumero()
      End If
      txtCodigoNorma.Focus()
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.MRPNormasFabricacion
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         If New Reglas.MRPNormasFabricacion().Existe(txtCodigoNorma.Text.ToUpper()) Then
            txtCodigoNorma.Select()
            Return "Ya existe el codigo de Norma de Fabricación."
         End If
      End If
      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Métodos"
   Private Sub CargarProximoNumero()
      Dim oNormaFab = New Reglas.MRPNormasFabricacion()
      DirectCast(_entidad, Entidades.MRPNormaFabricacion).IdNormaFab = (oNormaFab.GetCodigoMaximo() + 1)
      txtCodigoNorma.Text = DirectCast(_entidad, Entidades.MRPNormaFabricacion).IdNormaFab.ToString()
   End Sub
#End Region

#Region "Eventos"
   Protected Overrides Sub Aceptar()
      Dim mensaje = ValidarDetalle()
      If String.IsNullOrEmpty(mensaje) Then
         MyBase.Aceptar()
      Else
         MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
   End Sub
#End Region
End Class