Public Class TableroDeComando
   Inherits BaseForm
   Implements IConParametros

#Region "Campos"
   Private _publicos As Publicos
   Private _initializing As Boolean = True
   Private _controller As TableroDeComandoController
   Private _parametros As String
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _controller = New TableroDeComandoController(Me, {tsbRefrescar, btnConsultar}) _
                           With {.Timer1 = Timer1,
                                 .tssInfo = tssInfo,
                                 .bwkBajarDatosBackup = bwkBajarDatosBackup}

         Dim tablero = _controller.Inicializar(_parametros, {ugGrilla1, ugGrilla2, ugGrilla3, ugGrilla4, ugGrilla5, ugGrilla6},
                                               Panel1, New Point(lblSegundos.Left + lblSegundos.Width, 5))

         Me._publicos = New Publicos()

         Me.txtMinutos.Value = Reglas.Publicos.MinutosTableroComando
         chbActualizacionAutomatica.Checked = New Reglas.Usuarios().TienePermisos("TableroDeComando-Automatica")

         _controller.Intervalo = Convert.ToInt32(txtMinutos.Value)
         _controller.ActualizacionAutomatica = chbActualizacionAutomatica.Checked

      Catch ex As Exception
         ShowError(ex)
      Finally
         _initializing = False
      End Try

      Try
         CargarDatosGrillas()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      End If

      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Metodos"
   Private Sub RefrescarGrilla()
      _controller.RefrescarGrillas()
      If New Reglas.Usuarios().TienePermisos("TableroDeComando-Automatica") Then
         _controller.InicializaBackgroundWorker()
      End If
   End Sub
   Private Sub CargarDatosGrillas()
      _controller.CargarGrillaDetalle()
   End Sub

#End Region

#Region "Eventos"
   Private Sub chbActualizacionAutomatica_CheckedChanged(sender As Object, e As EventArgs) Handles chbActualizacionAutomatica.CheckedChanged
      Try
         If _initializing Then Return
         _controller.ActualizacionAutomatica = chbActualizacionAutomatica.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtSegundos_ValueChanged(sender As Object, e As EventArgs) Handles txtMinutos.ValueChanged
      Try
         If _initializing Then Return
         _controller.Intervalo = Convert.ToInt32(txtMinutos.Value)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         CargarDatosGrillas()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _parametros = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function
End Class