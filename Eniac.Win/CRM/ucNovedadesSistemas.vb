Public Class ucNovedadesSistemas

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      _publicos.CargaComboZonasGeograficas(cmbSistema)
      'Dim lista As List(Of String) = New List(Of String)()

      'lista.Add("")
      'lista.Add("SIGA")
      'lista.Add("SiSeN")
      'lista.Add("SiLIVE")
      'lista.Add("SiCAP")

      'cmbSistema.DataSource = lista
   End Sub

   Public Property IdSistema() As String
      Get
         If cmbSistema.SelectedValue Is Nothing Then Return String.Empty
         Return cmbSistema.SelectedValue.ToString()
      End Get
      Set(ByVal value As String)
         Try
            cmbSistema.SelectedValue = value

         Catch ex As Exception
            cmbSistema.SelectedIndex = 0

         End Try
      End Set
   End Property

   Private Sub cmbSistema_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSistema.SelectedValueChanged
      OnSelectedChanged(Nothing)
   End Sub
End Class
