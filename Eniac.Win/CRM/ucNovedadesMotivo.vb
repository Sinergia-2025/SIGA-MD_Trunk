Public Class ucNovedadesMotivo

   Private _terminoCargaInicial As Boolean = False

   Private _idTipoNovedad As String
   Public Property IdTipoNovedad() As String
      Get
         Return _idTipoNovedad
      End Get
      Set(value As String)
         _idTipoNovedad = value
         If _terminoCargaInicial Then
            _publicos.CargaComboCRMMotivosNovedades(cmbMotivoNovedad, value)
         End If
      End Set
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      _publicos.CargaComboCRMMotivosNovedades(cmbMotivoNovedad, IdTipoNovedad)
      _terminoCargaInicial = True
   End Sub

   Public Property IdMotivoNovedad() As Integer
      Get
         If cmbMotivoNovedad.SelectedValue Is Nothing Then Return 0
         Return Integer.Parse(cmbMotivoNovedad.SelectedValue.ToString())
      End Get
      Set(value As Integer)
         Try
            cmbMotivoNovedad.SelectedValue = value

         Catch ex As Exception
            cmbMotivoNovedad.SelectedIndex = -1

         End Try
      End Set
   End Property

   Private Sub cmbMotivoNovedad_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMotivoNovedad.SelectedValueChanged
      OnSelectedChanged(Nothing)
   End Sub

End Class