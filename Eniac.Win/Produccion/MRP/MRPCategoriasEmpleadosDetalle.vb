Public Class MRPCategoriasEmpleadosDetalle

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.MRPCategoriaEmpleado)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      _publicos = New Publicos()
      InicializaCampos()

      BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         CargarProximoNumero()
      End If
      txtCodigoCategoria.Focus()

   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.MRPCategoriasEmpleados
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         If New Reglas.MRPCategoriasEmpleados().Existe(txtCodigoCategoria.Text.ToUpper()) Then
            txtCodigoCategoria.Select()
            Return "Ya existe el codigo de Categoría Empleado."
         End If
      End If
      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Métodos"
   Private Sub InicializaCampos()
      txtValorHora.Formato = "#0.00"
   End Sub
   Private Sub CargarProximoNumero()
      Dim oCategorias = New Reglas.MRPCategoriasEmpleados()
      DirectCast(_entidad, Entidades.MRPCategoriaEmpleado).IdCategoriaEmpleado = (oCategorias.GetCodigoMaximo() + 1)
      txtCodigoCategoria.Text = DirectCast(_entidad, Entidades.MRPCategoriaEmpleado).IdCategoriaEmpleado.ToString()
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