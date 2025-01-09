Imports Eniac.Entidades

Public Class MRPTareasDetalle

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.MRPTarea)
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
      Else
         If DirectCast(_entidad, MRPTarea).IdCentroProductor > 0 Then
            bscCodigoCentroProductor.Text = New Reglas.MRPCentrosProductores().GetUno(DirectCast(_entidad, MRPTarea).IdCentroProductor).CodigoCentroProductor
            bscCodigoCentroProductor.PresionarBoton()
         End If
      End If
      txtCodigoTarea.Focus()

   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.MRPTareas
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         If New Reglas.MRPTareas().Existe(txtCodigoTarea.Text.ToUpper()) Then
            txtCodigoTarea.Select()
            Return "Ya existe el codigo de Tarea."
         End If
      End If
      If bscCodigoCentroProductor.Selecciono() Or bscNombreCentrosProductores.Selecciono() Then
         DirectCast(_entidad, MRPTarea).IdCentroProductor = Integer.Parse(bscCodigoCentroProductor.Tag.ToString())
      End If
      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Métodos"
   Private Sub CargarProximoNumero()
      Dim oTareas = New Reglas.MRPTareas()
      DirectCast(_entidad, Entidades.MRPTarea).IdTarea = (oTareas.GetCodigoMaximo() + 1)
      txtCodigoTarea.Text = DirectCast(_entidad, Entidades.MRPTarea).IdTarea.ToString()
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

   Private Sub bscCodigoCentroProductor_BuscadorClick() Handles bscCodigoCentroProductor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMRPCentrosProductores(bscCodigoCentroProductor)
            bscCodigoCentroProductor.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorCodigo(bscCodigoCentroProductor.Text.Trim(), Entidades.Publicos.SiNoTodos.TODOS, True)
         End Sub)
   End Sub
   Private Sub bscNombreCentrosProductores_BuscadorClick() Handles bscNombreCentrosProductores.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMRPCentrosProductores(bscNombreCentrosProductores)
            bscNombreCentrosProductores.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorNombre(bscNombreCentrosProductores.Text.Trim(), Entidades.Publicos.SiNoTodos.SI, Entidades.Publicos.SiNoTodos.TODOS)
         End Sub)
   End Sub
   Private Sub bscCodigoCentroProductor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCentroProductor.BuscadorSeleccion, bscNombreCentrosProductores.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCentroProductor(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

   Private Sub CargarDatosCentroProductor(dr As DataGridViewRow)
      bscCodigoCentroProductor.Text = dr.Cells("CodigoCentroProductor").Value.ToString()
      bscCodigoCentroProductor.Tag = dr.Cells("IdCentroProductor").Value.ToString()
      bscNombreCentrosProductores.Text = dr.Cells("Descripcion").Value.ToString()
   End Sub
#End Region
End Class