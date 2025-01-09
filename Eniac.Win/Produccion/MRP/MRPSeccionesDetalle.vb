Public Class MRPSeccionesDetalle
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.MRPSeccion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      _publicos = New Publicos()

      _publicos.CargaComboDesdeEnum(cmbClaseSeccion, GetType(Entidades.MRPSeccion.ClaseSecciones))

      BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         CargarProximoNumero()
         InicializaCampos()
      End If
      txtCodigoSeccion.Focus()
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.MRPSecciones
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         If New Reglas.MRPSecciones().Existe(txtCodigoSeccion.Text.ToUpper()) Then
            txtCodigoSeccion.Select()
            Return "Ya existe el codigo de Sección."
         End If
      End If
      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Métodos"
   Private Sub InicializaCampos()
      cmbClaseSeccion.SelectedIndex = 0
   End Sub
   Private Sub CargarProximoNumero()
      Dim oSeccion = New Reglas.MRPSecciones()
      DirectCast(_entidad, Entidades.MRPSeccion).IdSeccion = (oSeccion.GetCodigoMaximo() + 1)
      txtCodigoSeccion.Text = DirectCast(_entidad, Entidades.MRPSeccion).IdSeccion.ToString()
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