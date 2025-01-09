Public Class ucNovedadesAplicacionesTerceros
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      _publicos.CargaComboAplicaciones(cmbAplicacionTerceros, propietarioAplicacion:=Entidades.AplicacionPropietario.TERCERO)
   End Sub

   Public Property IdAplicacion() As String
      Get
         If cmbAplicacionTerceros.SelectedValue Is Nothing Then Return String.Empty
         Return cmbAplicacionTerceros.SelectedValue.ToString()
      End Get
      Set(value As String)
         Try
            cmbAplicacionTerceros.SelectedValue = value

         Catch ex As Exception
            cmbAplicacionTerceros.SelectedIndex = 0

         End Try
      End Set
   End Property

   Private Sub cmbAplicacionTerceros_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAplicacionTerceros.SelectedValueChanged
      OnSelectedChanged(Nothing)
   End Sub
End Class