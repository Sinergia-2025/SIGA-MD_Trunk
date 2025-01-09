Public Class ConcesionarioDistribucionEjesDetalle

#Region "Campos"
   Private _publicos As Publicos
   Private _idTipoUnidad As Integer
#End Region

#Region "Constructores"
   Public Sub New(idEje As Integer)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(idTipoUnidad As Integer, distribucionEje As Entidades.ConcesionarioDistribucionEje)
      Me.InitializeComponent()
      Me._entidad = distribucionEje
      _idTipoUnidad = idTipoUnidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
         Me.bscCodigoUnidad.PresionarBoton()
      Else
         If _idTipoUnidad > 0 Then
            bscCodigoUnidad.Text = _idTipoUnidad.ToString()
            bscCodigoUnidad.PresionarBoton()
         End If
      End If
   End Sub
   'VALIDAR DETALLE
   Protected Overrides Function ValidarDetalle() As String

      If Not Me.bscCodigoUnidad.Selecciono And Not Me.bscUnidad.Selecciono Then
         Me.bscUnidad.Focus()
         Return "No selecciono la Unidad."
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ConcesionarioDistribucionEjes()
   End Function
#End Region

#Region "Eventos"
   Private Sub bscCodigoUnidad_BuscadorClick() Handles bscCodigoUnidad.BuscadorClick
      Try
         Dim rUnidad As Reglas.ConcesionarioTiposUnidades = New Reglas.ConcesionarioTiposUnidades
         Me._publicos.PreparaGrillaTiposUnidades(Me.bscCodigoUnidad)
         Me.bscCodigoUnidad.Datos = rUnidad.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoUnidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoUnidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoUnidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarUnidad(e.FilaDevuelta)
            Me.txtIdEje.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscUnidad_BuscadorClick() Handles bscUnidad.BuscadorClick
      Try
         Dim rUnidad As Reglas.ConcesionarioTiposUnidades = New Reglas.ConcesionarioTiposUnidades
         Me._publicos.PreparaGrillaTiposUnidades(Me.bscUnidad)
         Me.bscUnidad.Datos = rUnidad.GetPorNombre(Me.bscUnidad.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscUnidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscUnidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarUnidad(e.FilaDevuelta)
            Me.txtIdEje.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdEje.Focus()
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarUnidad(ByVal dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.ConcesionarioDistribucionEje).IdTipoUnidad = Integer.Parse(dr.Cells("IdTipoUnidad").Value.ToString())
      Me.bscCodigoUnidad.Text = dr.Cells("IdTipoUnidad").Value.ToString()
      Me.bscUnidad.Text = dr.Cells("NombreTipoUnidad").Value.ToString()

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
      End If
   End Sub
   Private Sub CargarProximoNumero()
      Dim rEje As Reglas.ConcesionarioDistribucionEjes = New Reglas.ConcesionarioDistribucionEjes()
      Me.txtIdEje.Text = (rEje.GetCodigoMaximo(Integer.Parse(Me.bscCodigoUnidad.Text)) + 1).ToString()
   End Sub

#End Region
End Class