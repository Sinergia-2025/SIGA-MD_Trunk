
Public Class CallesDetalle

#Region "Constructores"
   Public Property _idLocalidad() As Integer
   Public Property _idCalle() As Integer
   Public Property _NombreCalle() As String
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Calle)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.Text = "Nueva Calle"

      Dim pub As Publicos = New Publicos()
      pub.CargaComboLocalidades(Me.cmbLocalidades)

      Me._liSources.Add("Localidad", DirectCast(Me._entidad, Entidades.Calle).Localidad)
      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         'Me.cmbLocalidades.SelectedIndex = -1
         Me.CargarProximoNumero()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Calles()
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.DialogResult = Windows.Forms.DialogResult.OK
      End If
      Me.txtId.Focus()
   End Sub
   Protected Overrides Sub Aceptar()
      Me._idCalle = Integer.Parse(Me.txtId.Text)
      Me._NombreCalle = Me.txtNombreCategoria.Text
      Me._idLocalidad = Integer.Parse(Me.cmbLocalidades.SelectedValue.ToString())
      MyBase.Aceptar()
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim reg As Reglas.Calles = New Reglas.Calles()
      Me.txtId.Text = (reg.GetCodigoMaximo() + 1).ToString("####0")
   End Sub

#End Region

End Class
