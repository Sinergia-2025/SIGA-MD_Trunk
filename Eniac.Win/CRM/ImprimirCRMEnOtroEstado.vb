Public Class ImprimirCRMEnOtroEstado

#Region "Propiedades y Campos"
   Public Property EstadoSeleccionado As Entidades.CRMEstadoNovedad = Nothing
   Private _publicos As Publicos
   Private _idTipoNovedad As String
#End Region

   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(idTipoNovedad As String)
      Me.new()
      _idTipoNovedad = idTipoNovedad
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      _publicos = New Publicos

      '# Cargar combo de Estado
      Me._publicos.CargaComboCRMEstadosNovedades(Me.cmbEstadoCRM, _idTipoNovedad)
      Me.cmbEstadoCRM.SelectedIndex = 0

   End Sub

   Protected Overrides Sub Aceptar()

      '# Guardo el nuevo estado seleccionado por el usuario
      Me.EstadoSeleccionado = DirectCast(Me.cmbEstadoCRM.SelectedItem, Entidades.CRMEstadoNovedad)
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()

   End Sub
End Class